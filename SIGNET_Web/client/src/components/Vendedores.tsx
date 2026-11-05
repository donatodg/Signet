import { FormEvent, useEffect, useRef, useState } from 'react';
import { api } from '../api';
import type { CuentaMovil, LookupItem, PortalEstado, PortalOpciones, ProductoMovil, RevisionMovil, VentaMovil } from '../types';
import './Vendedores.css';
import { escribirVentana, mostrarPdf } from './Acciones';
import { confirmar } from './Dialogos';

type Vista = 'inicio' | 'precios' | 'cuenta' | 'venta';
const numero = (n: number) => n.toLocaleString('es-AR', { maximumFractionDigits: 2 });
const hoy = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};
const unica = (opciones: LookupItem[]) => opciones.length === 1 ? Number(opciones[0].key) : 0;
const nuevaVenta = (): VentaMovil => ({ cliente: 0, sucursal: 0, tipoComprobante: 0, talonario: 0,
  centroCosto: 0, vendedor: 0, formaPago: 0, observaciones: '', productos: [] });

function Elegir({ titulo, opciones, valor, cambiar, opcional = false }: {
  titulo: string; opciones: LookupItem[]; valor: number; cambiar: (v: number) => void; opcional?: boolean;
}) {
  return <label className="seller-field">{titulo}<select value={valor || ''} required={!opcional}
    onChange={e => cambiar(Number(e.target.value))}>
    <option value="">{opcional ? 'Del cliente / predeterminada' : 'Seleccione'}</option>
    {opciones.map(o => <option key={o.key} value={o.key}>{o.name}</option>)}
  </select></label>;
}

function BuscarEntidad({ uso, tipo = 1, cambiar }: {
  uso: string; tipo?: number; cambiar: (opcion: LookupItem | undefined) => void;
}) {
  const [texto, setTexto] = useState('');
  const [opciones, setOpciones] = useState<LookupItem[]>([]);
  const [elegida, setElegida] = useState<LookupItem>();
  const [error, setError] = useState('');
  const [mas, setMas] = useState(false);
  const [cargando, setCargando] = useState(false);
  const secuencia = useRef(0);
  useEffect(() => {
    let vivo = true;
    const n = ++secuencia.current;
    if (elegida) return;
    const h = setTimeout(() => {
      setCargando(true);
      api.portalEntidades(uso, texto, tipo).then(r => {
        if (vivo && n === secuencia.current) { setOpciones(r.opciones); setMas(r.hayMas); setError(''); }
      }).catch(e => vivo && n === secuencia.current && setError(e.message))
        .finally(() => vivo && n === secuencia.current && setCargando(false));
    }, 300);
    return () => { vivo = false; clearTimeout(h); };
  }, [texto, uso, tipo, elegida]);
  return <section className="seller-card">
    <label className="seller-field">{uso === 'cuenta' ? 'Entidad' : 'Cliente'}
      <input type="search" placeholder="Buscar por nombre" value={texto} onChange={e => {
        setTexto(e.target.value); setElegida(undefined); setOpciones([]); cambiar(undefined); secuencia.current++;
      }} />
    </label>
    {cargando && <p role="status">Buscando...</p>}
    {error && <p role="alert" className="alert">{error}</p>}
    {elegida ? <p className="seller-selected">Seleccionado: <strong>{elegida.name}</strong></p>
      : <div className="seller-options">{opciones.map(o => <button type="button" className="btn" key={o.key}
        onClick={() => { secuencia.current++; setCargando(false); setElegida(o); setTexto(o.name); cambiar(o); }}>{o.name}</button>)}
        {mas && <p className="muted">Hay más resultados; refine el nombre.</p>}
        {!cargando && !error && !opciones.length && <p className="muted">Sin coincidencias.</p>}
      </div>}
  </section>;
}

function BuscarProductos({ uso, cliente, agregar }: {
  uso: string; cliente: number; agregar?: (p: ProductoMovil) => void;
}) {
  const [texto, setTexto] = useState('');
  const [productos, setProductos] = useState<ProductoMovil[]>([]);
  const [error, setError] = useState('');
  const [mas, setMas] = useState(false);
  const [cargando, setCargando] = useState(false);
  useEffect(() => {
    let vivo = true;
    setProductos([]); setError(''); setMas(false);
    if (!cliente || texto.trim().length < 2) { setCargando(false); return; }
    setCargando(true);
    const h = setTimeout(() => {
      api.portalProductos(uso, cliente, texto).then(r => {
        if (vivo) { setProductos(r.productos); setMas(r.hayMas); }
      }).catch(e => vivo && setError(e.message)).finally(() => vivo && setCargando(false));
    }, 300);
    return () => { vivo = false; clearTimeout(h); };
  }, [texto, cliente, uso]);
  return <section className="seller-card">
    <label className="seller-field">Productos<input type="search" disabled={!cliente} value={texto}
      placeholder="Nombre o código (mínimo 2 letras)" onChange={e => setTexto(e.target.value)} /></label>
    <p className="muted small">Precios de la lista del cliente. Precio unitario sin IVA; descuentos e impuestos se recalculan al revisar.</p>
    {cargando && <p role="status">Buscando...</p>}
    {error && <p role="alert" className="alert">{error}</p>}
    {productos.map(p => <article className="seller-product" key={p.id}>
      <strong>{p.nombre}</strong><span className="muted">{p.codigo}</span>
      <span>{p.moneda} {numero(p.precio)} · IVA {numero(p.iva)}%{p.descuento > 0 && ` · Desc. ${numero(p.descuento)}%`}</span>
      {agregar && <button className="btn primary" type="button" onClick={() => agregar(p)}>Agregar {p.nombre}</button>}
    </article>)}
    {mas && <p>Hay más productos; refine la búsqueda.</p>}
    {!cargando && cliente > 0 && texto.length >= 2 && !productos.length && !error && <p>Sin productos para esta búsqueda.</p>}
  </section>;
}

function Cuenta() {
  const [tipo, setTipo] = useState(1);
  const [entidad, setEntidad] = useState<LookupItem>();
  const [monedas, setMonedas] = useState<LookupItem[]>([]);
  const [moneda, setMoneda] = useState(0);
  const [desde, setDesde] = useState(hoy().slice(0, 7) + '-01');
  const [hasta, setHasta] = useState(hoy());
  const [resultado, setResultado] = useState<CuentaMovil>();
  const [error, setError] = useState('');
  const [cargando, setCargando] = useState(false);
  const version = useRef(0);
  useEffect(() => {
    let vivo = true;
    api.portalMonedas().then(r => { if (vivo) { setMonedas(r); setMoneda(unica(r)); } }).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, []);
  const limpiar = () => { version.current++; setResultado(undefined); setError(''); setCargando(false); };
  const consultar = async (e: FormEvent) => {
    e.preventDefault();
    const n = ++version.current; setCargando(true); setError(''); setResultado(undefined);
    try {
      const r = await api.portalCuenta(Number(entidad?.key), moneda, desde, hasta, tipo);
      if (n === version.current) setResultado(r);
    } catch (e) { if (n === version.current) setError((e as Error).message); }
    finally { if (n === version.current) setCargando(false); }
  };
  const comprobante = async (movimiento: number) => {
    const ventana = window.open('', '_blank');
    const n = version.current;
    try {
      const r = await api.portalComprobante(movimiento, Number(entidad?.key), moneda, tipo);
      if (n !== version.current) { ventana?.close(); return; }
      if (r.pdf) mostrarPdf(ventana, r.pdf);
      else if (r.html) escribirVentana(ventana, r.html);
      else { ventana?.close(); setError('El movimiento no tiene un comprobante imprimible.'); }
    } catch (e) { ventana?.close(); if (n === version.current) setError((e as Error).message); }
  };
  return <>
    <Elegir titulo="Tipo de entidad" opciones={[{ key: 1, name: 'Cliente' }, { key: 2, name: 'Proveedor' },
      { key: 3, name: 'Proveedor financiero' }, { key: 4, name: 'Personal' }]} valor={tipo}
      cambiar={v => { limpiar(); setTipo(v); setEntidad(undefined); }} />
    <BuscarEntidad key={tipo} uso="cuenta" tipo={tipo} cambiar={v => { limpiar(); setEntidad(v); }} />
    <form className="seller-card" onSubmit={consultar}>
      <Elegir titulo="Moneda" opciones={monedas} valor={moneda} cambiar={v => { limpiar(); setMoneda(v); }} />
      <div className="seller-two">
        <label className="seller-field">Desde<input type="date" required value={desde} onChange={e => { limpiar(); setDesde(e.target.value); }} /></label>
        <label className="seller-field">Hasta<input type="date" required value={hasta} min={desde} onChange={e => { limpiar(); setHasta(e.target.value); }} /></label>
      </div>
      <button className="btn primary" disabled={!entidad || !moneda || cargando}>{cargando ? 'Consultando...' : 'Consultar cuenta'}</button>
    </form>
    {error && <p className="alert" role="alert">{error}</p>}
    {resultado && <section aria-label="Movimientos">
      <h3>Saldo al cierre: {numero(resultado.saldo)}</h3><p>Saldo anterior: {numero(resultado.saldoAnterior)}</p>
      {resultado.movimientos.map(m => <article className="seller-card" key={m.id}>
        <strong>{m.movimiento}</strong><p>{new Date(m.fecha).toLocaleDateString('es-AR')} · {m.concepto}</p>
        <p>Debe {numero(m.debito)} · Haber {numero(m.credito)}</p><strong>Saldo {numero(m.saldo)}</strong>
        <button className="btn seller-wide" onClick={() => void comprobante(m.id)}>Ver comprobante</button>
      </article>)}
      {!resultado.movimientos.length && <p>Sin movimientos en el período.</p>}
    </section>}
  </>;
}

function Venta() {
  const [venta, setVenta] = useState(nuevaVenta);
  const [opciones, setOpciones] = useState<PortalOpciones>();
  const [talonarios, setTalonarios] = useState<LookupItem[]>([]);
  const [nombres, setNombres] = useState<Record<number, ProductoMovil>>({});
  const [revision, setRevision] = useState<RevisionMovil>();
  const [error, setError] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const [guardada, setGuardada] = useState('');
  const bloqueo = useRef(false);
  const cambiar = (cambio: Partial<VentaMovil>) => { setVenta(v => ({ ...v, ...cambio })); setRevision(undefined); setError(''); };
  useEffect(() => {
    const salir = (e: BeforeUnloadEvent) => { e.preventDefault(); e.returnValue = ''; };
    if (venta.productos.length) window.addEventListener('beforeunload', salir);
    return () => window.removeEventListener('beforeunload', salir);
  }, [venta.productos.length]);
  useEffect(() => {
    let vivo = true;
    api.portalOpciones().then(r => {
      if (!vivo) return;
      setOpciones(r);
      setVenta(v => ({ ...v, sucursal: unica(r.sucursales), tipoComprobante: unica(r.comprobantes),
        centroCosto: unica(r.centros), vendedor: unica(r.vendedores) }));
    }).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, []);
  useEffect(() => {
    let vivo = true;
    setTalonarios([]); setVenta(v => ({ ...v, talonario: 0 })); setRevision(undefined);
    if (venta.cliente && venta.sucursal && venta.tipoComprobante)
      api.portalTalonarios(venta.cliente, venta.sucursal, venta.tipoComprobante).then(r => {
        if (vivo) { setTalonarios(r); setVenta(v => ({ ...v, talonario: unica(r) })); }
      }).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [venta.cliente, venta.sucursal, venta.tipoComprobante]);
  const revisar = async (e: FormEvent) => {
    e.preventDefault(); if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError(''); setRevision(undefined);
    try { setRevision(await api.portalRevisar(venta)); }
    catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  const guardar = async () => {
    if (!revision || bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError('');
    try {
      const r = await api.portalGuardar(revision.token);
      setGuardada(`${r.comprobante}: ${r.mensaje}`); setRevision(undefined); setVenta(nuevaVenta());
    } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  if (guardada) return <section className="seller-card" role="status"><h3>Venta registrada</h3><p>{guardada}</p>
    <button className="btn primary" onClick={() => {
      if (opciones) setVenta({ ...nuevaVenta(), sucursal: unica(opciones.sucursales), tipoComprobante: unica(opciones.comprobantes),
        centroCosto: unica(opciones.centros), vendedor: unica(opciones.vendedores) });
      setNombres({}); setGuardada('');
    }}>Cargar otra venta</button></section>;
  return <>
    <p>La venta queda pendiente de confirmación por administración. No se factura en AFIP ni se cobra.</p>
    {error && <p role="alert" className="alert">{error}</p>}
    <form onSubmit={revisar}>
      <fieldset disabled={ocupado} className="seller-fields">
        <BuscarEntidad uso="venta" cambiar={c => { cambiar({ cliente: Number(c?.key) || 0, productos: [] }); setNombres({}); }} />
        {opciones && <section className="seller-card">
          <Elegir titulo="Sucursal" opciones={opciones.sucursales} valor={venta.sucursal} cambiar={v => cambiar({ sucursal: v })} />
          <Elegir titulo="Comprobante" opciones={opciones.comprobantes} valor={venta.tipoComprobante} cambiar={v => cambiar({ tipoComprobante: v })} />
          {talonarios.length > 1 && <Elegir titulo="Talonario" opciones={talonarios} valor={venta.talonario} cambiar={v => cambiar({ talonario: v })} />}
          <details><summary>Más datos</summary>
            <Elegir titulo="Centro de costo" opciones={opciones.centros} valor={venta.centroCosto} cambiar={v => cambiar({ centroCosto: v })} />
            <Elegir titulo="Vendedor" opciones={opciones.vendedores} valor={venta.vendedor} cambiar={v => cambiar({ vendedor: v })} />
            <Elegir titulo="Forma de pago" opcional opciones={opciones.formasPago} valor={venta.formaPago} cambiar={v => cambiar({ formaPago: v })} />
            <label className="seller-field">Observaciones<textarea maxLength={900} value={venta.observaciones}
              onChange={e => cambiar({ observaciones: e.target.value })} /></label>
          </details>
          {(!venta.centroCosto || !venta.vendedor) && <p>Complete centro de costo y vendedor en «Más datos».</p>}
        </section>}
        <BuscarProductos uso="venta" cliente={venta.cliente} agregar={p => {
          setNombres(n => ({ ...n, [p.id]: p }));
          const existente = venta.productos.some(x => x.producto === p.id);
          cambiar({ productos: existente ? venta.productos.map(x => x.producto === p.id ? { ...x, cantidad: x.cantidad + 1 } : x)
            : [...venta.productos, { producto: p.id, cantidad: 1 }] });
        }} />
        <section aria-label="Detalle de venta">
          {venta.productos.map((p, i) => <article className="seller-card" key={p.producto}>
            <strong>{nombres[p.producto]?.nombre}</strong>
            <label className="seller-field">Cantidad<input type="number" inputMode="decimal" min="0.01" max="1000000" step="any"
              required value={p.cantidad || ''} onChange={e => cambiar({ productos: venta.productos.map((x, n) =>
                n === i ? { ...x, cantidad: Number(e.target.value) } : x) })} /></label>
            {nombres[p.producto]?.cantidadStock && <label className="seller-field">Cantidad Stock<input type="number" inputMode="decimal"
              min="0.01" max="1000000" step="any" required value={p.cantidadStock ?? ''} onChange={e => cambiar({
                productos: venta.productos.map((x, n) => n === i ? { ...x, cantidadStock: Number(e.target.value) } : x) })} /></label>}
            <button type="button" className="btn" onClick={() => cambiar({ productos: venta.productos.filter((_, n) => n !== i) })}>Quitar {nombres[p.producto]?.nombre}</button>
          </article>)}
        </section>
        <button className="btn primary seller-wide" disabled={!opciones || !venta.cliente || !venta.productos.length
          || !venta.centroCosto || !venta.vendedor || !venta.talonario}>{ocupado ? 'Procesando...' : 'Revisar venta'}</button>
      </fieldset>
    </form>
    {revision && <section className="seller-card seller-review" aria-label="Revisión">
      <h3>Revisar antes de guardar</h3><strong>{revision.resumen.cliente}</strong>
      <p>{revision.resumen.tipoComprobante} · {revision.resumen.sucursal} · {revision.resumen.formaPago}</p>
      {revision.resumen.lineas.map((l, i) => <p key={i}>{l.producto}: {numero(l.cantidad)} × {numero(l.precioUnitario)} {l.moneda}
        {' · '}Desc. {numero(l.descuento)}% · IVA {numero(l.iva)} · Total {numero(l.total)}</p>)}
      {revision.impuestos.map((impuesto, i) => <p key={i}>{impuesto.nombre} ({numero(impuesto.alicuota)}%):
        {' '}{numero(impuesto.importe)} pesos</p>)}
      <h3>Total en pesos: {numero(revision.resumen.total)}</h3>
      {revision.resumen.advertencias.map((a, i) => <p key={i}>{a}</p>)}
      <button className="btn primary seller-wide" disabled={ocupado} onClick={() => void guardar()}>
        {ocupado ? 'Guardando...' : 'Guardar pendiente de confirmación'}</button>
      <button className="btn seller-wide" disabled={ocupado} onClick={() => setRevision(undefined)}>Volver a editar</button>
    </section>}
  </>;
}

function Precios() {
  const [cliente, setCliente] = useState<LookupItem>();
  return <><p>Elegí un cliente para consultar sus precios.</p>
    <BuscarEntidad uso="precios" cambiar={setCliente} />
    <BuscarProductos uso="precios" cliente={Number(cliente?.key) || 0} />
  </>;
}

export function Vendedores() {
  const [estado, setEstado] = useState<PortalEstado>();
  const [error, setError] = useState('');
  const [vista, setVista] = useState<Vista>('inicio');
  useEffect(() => {
    let vivo = true;
    api.portalEstado().then(r => vivo && setEstado(r)).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, []);
  return <div className="seller-portal">
    <header className="seller-header"><h2>{vista === 'inicio' ? 'Portal de vendedores' : vista === 'venta' ? 'Nueva venta' : vista === 'precios' ? 'Lista de precios' : 'Cuenta corriente'}</h2>
      {vista !== 'inicio' && <button className="btn" onClick={async () => {
        if (vista !== 'venta' || await confirmar('¿Volver al portal? Los datos no guardados se perderán.')) setVista('inicio');
      }}>Volver al portal</button>}
    </header>
    {error && <p role="alert" className="alert">{error}</p>}
    {!estado && !error && <p>Cargando permisos...</p>}
    {estado && vista === 'inicio' && <nav className="seller-home" aria-label="Opciones de vendedores">
      {estado.precios && <button className="btn" onClick={() => setVista('precios')}>Lista de precios</button>}
      {estado.cuenta && <button className="btn" onClick={() => setVista('cuenta')}>Cuenta corriente</button>}
      {estado.ventas && <button className="btn primary" onClick={() => setVista('venta')}>Nueva venta</button>}
      {!estado.precios && !estado.cuenta && !estado.ventas && <p>Sin permisos para estas funciones. Consulte a administración.</p>}
    </nav>}
    {vista === 'precios' && estado?.precios && <Precios />}
    {vista === 'cuenta' && estado?.cuenta && <Cuenta />}
    {vista === 'venta' && estado?.ventas && <Venta />}
  </div>;
}
