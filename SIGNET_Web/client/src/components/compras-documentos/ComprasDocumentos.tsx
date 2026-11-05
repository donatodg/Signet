import { useEffect, useRef, useState } from 'react';
import { api } from '../../api';
import type { LookupItem } from '../../types';
import { confirmar } from '../Dialogos';
import type { DocumentoCompraLeido, ImportacionCompra, ItemCompraDocumento, OpcionesCompraDocumento, ResultadoRevisionCompra, RevisionCompraDocumento } from './types';
import './ComprasDocumentos.css';

function clave() {
  const b = crypto.getRandomValues(new Uint8Array(16)); b[6] = b[6] & 15 | 64; b[8] = b[8] & 63 | 128;
  const t = Array.from(b, n => n.toString(16).padStart(2, '0')).join('');
  return `${t.slice(0, 8)}-${t.slice(8, 12)}-${t.slice(12, 16)}-${t.slice(16, 20)}-${t.slice(20)}`;
}
function Elegir({ titulo, opciones, valor, cambiar }: { titulo: string; opciones: LookupItem[]; valor: number; cambiar: (v: number) => void }) {
  return <label>{titulo}<select value={valor || ''} onChange={e => cambiar(Number(e.target.value))}>
    <option value="">Seleccione</option>{opciones.map(o => <option key={o.key} value={o.key}>{o.name}</option>)}
  </select></label>;
}
function Producto({ id, cambiar }: { id: number | null; cambiar: (v: number | null) => void }) {
  const [buscar, setBuscar] = useState('');
  const [opciones, setOpciones] = useState<LookupItem[]>([]);
  const [seleccionado, setSeleccionado] = useState<LookupItem>();
  const [error, setError] = useState('');
  useEffect(() => {
    let vivo = true; setSeleccionado(undefined); setError('');
    if (id) api.comprasDocProductos('', id).then(r => { if (vivo) setSeleccionado(r[0]); }).catch(e => { if (vivo) setError(e.message); });
    return () => { vivo = false; };
  }, [id]);
  useEffect(() => {
    let vivo = true; setOpciones([]);
    if (!buscar.trim()) return;
    const timer = setTimeout(() => api.comprasDocProductos(buscar).then(r => { if (vivo) { setOpciones(r); setError(''); } })
      .catch(e => { if (vivo) setError(e.message); }), 300);
    return () => { vivo = false; clearTimeout(timer); };
  }, [buscar]);
  const lista = seleccionado && !opciones.some(o => o.key === seleccionado.key) ? [seleccionado, ...opciones] : opciones;
  return <div><label>Buscar producto<input type="search" maxLength={100} value={buscar} onChange={e => setBuscar(e.target.value)} /></label>
    <Elegir titulo="Producto del sistema" opciones={lista} valor={id ?? 0} cambiar={v => cambiar(v || null)} />
    {error && <p role="alert">{error}</p>}</div>;
}
function Numerico({ titulo, valor, cambiar }: { titulo: string; valor: number | null; cambiar: (n: number | null) => void }) {
  return <label>{titulo}<input type="number" step="any" value={valor ?? ''} onChange={e => cambiar(e.target.value === '' ? null : Number(e.target.value))} /></label>;
}
const texto: [keyof DocumentoCompraLeido, string][] = [['proveedor', 'Proveedor leído'], ['cuit', 'CUIT del original'],
  ['tipo', 'Tipo leído (Factura / Nota de crédito)'], ['letra', 'Letra'], ['puntoVenta', 'Punto de venta'], ['numero', 'Número'],
  ['moneda', 'Moneda leída (ISO)']];
const importes: [keyof DocumentoCompraLeido, string][] = [['total', 'Total de la factura'], ['neto', 'Neto leído (opcional)'],
  ['iva', 'IVA leído (opcional)'], ['noGravado', 'No gravado'], ['otrosImpuestos', 'Otros impuestos'],
  ['percepcionIva', 'Percepción IVA'], ['percepcionIibb', 'Percepción IIBB'], ['percepcionGanancias', 'Percepción Ganancias'],
  ['itc', 'ITC'], ['percepcionIibbCapital', 'Percepción IIBB Capital'], ['descuento', 'Descuento de cabecera']];

export function ComprasDocumentos({ onClose }: { onClose: () => void }) {
  const [opciones, setOpciones] = useState<OpcionesCompraDocumento>();
  const [lista, setLista] = useState<ImportacionCompra[]>([]);
  const [sucursal, setSucursal] = useState(0);
  const [archivos, setArchivos] = useState<File[]>([]);
  const [idCarga, setIdCarga] = useState(clave);
  const [actual, setActual] = useState<ImportacionCompra>();
  const [revision, setRevision] = useState<RevisionCompraDocumento>();
  const [validacion, setValidacion] = useState<ResultadoRevisionCompra>();
  const [paginas, setPaginas] = useState<string[]>([]);
  const [pagina, setPagina] = useState(0);
  const [error, setError] = useState('');
  const [mensaje, setMensaje] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const [cambio, setCambio] = useState(false);
  const bloqueo = useRef(false);
  const vivo = useRef(true);
  const ejecutar = async (accion: () => Promise<void>) => {
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError(''); setMensaje('');
    try { await accion(); } catch (e) { if (vivo.current) setError((e as Error).message); }
    finally { bloqueo.current = false; if (vivo.current) setOcupado(false); }
  };
  useEffect(() => {
    vivo.current = true;
    api.comprasDocOpciones().then(r => { if (vivo.current) { setOpciones(r); if (r.sucursales.length === 1) setSucursal(Number(r.sucursales[0].key)); } })
      .catch(e => { if (vivo.current) setError(e.message); });
    api.comprasDocListar().then(r => { if (vivo.current) setLista(r); }).catch(e => { if (vivo.current) setError(e.message); });
    return () => { vivo.current = false; };
  }, []);
  useEffect(() => {
    const avisar = (e: BeforeUnloadEvent) => { if (cambio || ocupado) { e.preventDefault(); e.returnValue = ''; } };
    window.addEventListener('beforeunload', avisar); return () => window.removeEventListener('beforeunload', avisar);
  }, [cambio, ocupado]);
  const abrir = async (carga: ImportacionCompra) => {
    setActual(carga); setRevision(undefined); setValidacion(undefined); setPaginas([]); setPagina(0); setCambio(false);
    const [vista, propuesta] = await Promise.all([api.comprasDocVista(carga.id),
      carga.lectura || carga.revision ? api.comprasDocPropuesta(carga.id) : Promise.resolve(undefined)]);
    if (vivo.current) { setPaginas(vista); setRevision(propuesta); }
  };
  const editar = (r: RevisionCompraDocumento) => { setRevision({ ...r, revisado: false }); setValidacion(undefined); setCambio(true); };
  const cabecera = (key: keyof DocumentoCompraLeido, valor: string | number | null) => {
    if (revision) editar({ ...revision, documento: { ...revision.documento, [key]: valor } });
  };
  const item = (n: number, patch: Partial<ItemCompraDocumento>) => {
    if (revision) editar({ ...revision, documento: { ...revision.documento, items: revision.documento.items.map((p, i) => i === n ? { ...p, ...patch } : p) } });
  };
  const cerrar = async () => { if (!ocupado && (!cambio || await confirmar('¿Cerrar y descartar correcciones sin guardar?'))) onClose(); };
  const cargar = () => ejecutar(async () => {
    if (!sucursal || archivos.length === 0 || archivos.length > 6 || archivos.reduce((s, f) => s + f.size, 0) > 12 * 1024 * 1024)
      throw new Error('Seleccione sucursal y de 1 a 6 archivos, hasta 12 MB en total.');
    if (cambio && !await confirmar('¿Cargar otra factura y descartar correcciones sin guardar?')) return;
    const datos = await Promise.all(archivos.map(f => new Promise<{ nombre: string; base64: string }>((resolve, reject) => {
      const reader = new FileReader(); reader.onerror = () => reject(new Error('No se pudo leer ' + f.name));
      reader.onload = () => resolve({ nombre: f.name, base64: String(reader.result).split(',')[1] }); reader.readAsDataURL(f);
    })));
    const r = await api.comprasDocCargar(idCarga, sucursal, datos); await abrir(r);
    setLista(await api.comprasDocListar()); setMensaje(r.compra ? `Esta carga ya generó la compra #${r.compra}; no se creó otra.`
      : 'Originales guardados. Pulse Leer documento para generar una propuesta; todavía no hay compra.');
  });
  return <div className="modal-backdrop"><section className="purchase-document-dialog" role="dialog" aria-modal="true" aria-labelledby="purchase-doc-title">
    <header><h2 id="purchase-doc-title">Compra desde foto o PDF</h2><button className="btn" disabled={ocupado} onClick={() => void cerrar()}>Cerrar</button></header>
    <p>Factura o nota de crédito, hasta 6 páginas/12 MB. Lectura con modelo local, sin enviar a terceros. Siempre genera una propuesta:
      <strong> no confirma, no mueve stock ni registra pagos/asientos.</strong></p>
    {error && <p role="alert" className="alert">{error}</p>}{mensaje && <p role="status">{mensaje}</p>}
    {ocupado && <p role="status">Procesando… la lectura puede demorar hasta 3 minutos. No vuelva a cargar el archivo.</p>}
    {opciones && !opciones.configurado && <p className="alert">Falta configurar el lector local. Puede guardar originales y retomar la lectura cuando el administrador lo habilite.</p>}
    <fieldset disabled={ocupado}><div className="purchase-doc-fields">
      {opciones && <Elegir titulo="Sucursal de la carga" opciones={opciones.sucursales} valor={sucursal} cambiar={v => { setSucursal(v); setIdCarga(clave()); }} />}
      <label>Imágenes o PDF (en orden de páginas)<input type="file" accept=".jpg,.jpeg,.png,.pdf" multiple onChange={e => { setArchivos(Array.from(e.target.files ?? [])); setIdCarga(clave()); }} /></label>
      <label>Tomar foto<input type="file" accept="image/jpeg,image/png" capture="environment" onChange={e => {
        setArchivos(prev => [...prev, ...Array.from(e.target.files ?? [])]); setIdCarga(clave()); e.target.value = '';
      }} /></label>
      <button className="btn primary" onClick={() => void cargar()}>Guardar originales</button>
      <button className="btn" onClick={() => void ejecutar(async () => setLista(await api.comprasDocListar()))}>Actualizar mis cargas</button>
    </div><p>{archivos.map(f => f.name).join(' · ')}</p>
    <label>Retomar una carga propia<select value={actual?.id ?? ''} onChange={e => {
      const carga = lista.find(c => c.id === e.target.value); if (carga) void ejecutar(async () => {
        if (cambio && !await confirmar('¿Descartar correcciones sin guardar?')) return; await abrir(await api.comprasDocObtener(carga.id));
      });
    }}><option value="">Seleccione</option>{lista.map(c => <option key={c.id} value={c.id}>{c.fecha.slice(0, 10)} · {c.archivos.join(', ')} · {c.estado}{c.compra ? ' · Compra #' + c.compra : ''}</option>)}</select></label>
    {actual && <><p>Estado: {actual.estado} · versión {actual.version} {actual.compra && `· Compra #${actual.compra} creada pendiente de confirmación.`}</p>
      {actual.error && <p role="alert" className="alert">{actual.error}</p>}
      {!actual.compra && <button className="btn primary" disabled={!opciones?.configurado} onClick={() => void ejecutar(async () => {
        if ((cambio || actual.lectura) && !await confirmar('¿Releer y reemplazar la propuesta/correcciones de esta carga? Los originales se conservan.')) return;
        const r = await api.comprasDocLeer(actual.id, actual.version); await abrir(r); setLista(await api.comprasDocListar());
      })}>Leer documento</button>}
      {actual.archivos.map((a, orden) => <button key={orden} className="btn" onClick={() => void ejecutar(async () => {
        const f = await api.comprasDocOriginal(actual.id, orden);
        const url = URL.createObjectURL(new Blob([Uint8Array.from(atob(f.base64), c => c.charCodeAt(0))], { type: f.contentType }));
        const enlace = document.createElement('a'); enlace.href = url; enlace.download = f.nombre; enlace.click(); setTimeout(() => URL.revokeObjectURL(url), 1000);
      })}>Descargar original: {a}</button>)}
    </>}
    <div className="purchase-doc-split"><aside>{paginas.length > 0 && <>
      <div><button className="btn" disabled={pagina === 0} onClick={() => setPagina(pagina - 1)}>Página anterior</button>
        <span>{pagina + 1} / {paginas.length}</span><button className="btn" disabled={pagina + 1 === paginas.length} onClick={() => setPagina(pagina + 1)}>Página siguiente</button></div>
      <a href={'data:image/jpeg;base64,' + paginas[pagina]} target="_blank" rel="noreferrer">Ampliar página</a>
      <img alt={`Original de compra, página ${pagina + 1}`} src={'data:image/jpeg;base64,' + paginas[pagina]} /></>}</aside>
    <div>{revision && opciones && <fieldset disabled={!!actual?.compra}>
      <h3>Revisión obligatoria</h3>
      <p>Vacío significa dato no leído, no cero. Revise neto/IVA, unidades y cantidad de stock. Las equivalencias sugeridas también deben verificarse.</p>
      {revision.documento.advertencias.map((a, i) => <p key={i} className="alert">{a}</p>)}
      <div className="purchase-doc-fields">
        <Elegir titulo="Proveedor del sistema" opciones={opciones.proveedores} valor={revision.proveedor} cambiar={v => editar({ ...revision, proveedor: v,
          documento: { ...revision.documento, items: revision.documento.items.map(p => ({ ...p, producto: null, recordarEquivalencia: false })) } })} />
        <Elegir titulo="Tipo de comprobante" opciones={opciones.tipos} valor={revision.tipoComprobante} cambiar={v => editar({ ...revision, tipoComprobante: v })} />
        <Elegir titulo="Depósito" opciones={opciones.depositos} valor={revision.deposito} cambiar={v => editar({ ...revision, deposito: v })} />
        <Elegir titulo="Centro de costo" opciones={opciones.centros} valor={revision.centroCosto} cambiar={v => editar({ ...revision, centroCosto: v })} />
        <Elegir titulo="Forma de pago" opciones={opciones.formas} valor={revision.formaPago} cambiar={v => editar({ ...revision, formaPago: v })} />
        <Elegir titulo="Moneda del sistema" opciones={opciones.monedas} valor={revision.moneda} cambiar={v => editar({ ...revision, moneda: v })} />
        <Numerico titulo="Cotización revisada" valor={revision.cotizacion || null} cambiar={v => editar({ ...revision, cotizacion: v ?? 0 })} />
        {texto.map(([key, titulo]) => <label key={key}>{titulo}<input maxLength={key === 'puntoVenta' ? 5 : key === 'numero' ? 8 : 150}
          value={String(revision.documento[key] ?? '')} onChange={e => cabecera(key, e.target.value)} /></label>)}
        <label>Fecha de factura<input type="date" value={revision.documento.fecha?.slice(0, 10) ?? ''} onChange={e => cabecera('fecha', e.target.value || null)} /></label>
        <label>Recepción<input type="date" value={revision.recepcion.slice(0, 10)} onChange={e => editar({ ...revision, recepcion: e.target.value })} /></label>
        <label>Vencimiento<input type="date" value={revision.vencimiento.slice(0, 10)} onChange={e => editar({ ...revision, vencimiento: e.target.value })} /></label>
        {importes.map(([key, titulo]) => <Numerico key={key} titulo={titulo} valor={typeof revision.documento[key] === 'number' ? revision.documento[key] : null}
          cambiar={v => cabecera(key, v)} />)}
      </div>
      <h3>Ítems ({revision.documento.items.length})</h3>
      {revision.documento.items.map((p, i) => <section key={i} className="purchase-doc-item"><h4>Ítem {i + 1}</h4>
        <div className="purchase-doc-fields"><label>Código del proveedor<input maxLength={150} value={p.codigo ?? ''} onChange={e => item(i, { codigo: e.target.value, recordarEquivalencia: false })} /></label>
          <label>Descripción original<input maxLength={4000} value={p.descripcion ?? ''} onChange={e => item(i, { descripcion: e.target.value })} /></label>
          <label>Unidad leída<input value={p.unidad ?? ''} onChange={e => item(i, { unidad: e.target.value })} /></label>
          <Producto id={p.producto} cambiar={v => item(i, { producto: v, cantidadStock: null, recordarEquivalencia: false })} />
          <Numerico titulo="Cantidad comprada" valor={p.cantidad} cambiar={v => item(i, { cantidad: v })} />
          <Numerico titulo="Cantidad de stock (conversión revisada)" valor={p.cantidadStock} cambiar={v => item(i, { cantidadStock: v })} />
          <Numerico titulo="Precio unitario NETO sin IVA" valor={p.precioNeto} cambiar={v => item(i, { precioNeto: v })} />
          <Numerico titulo="Descuento del ítem %" valor={p.descuento} cambiar={v => item(i, { descuento: v })} />
          <Numerico titulo="IVA del ítem %" valor={p.iva} cambiar={v => item(i, { iva: v })} />
          <Numerico titulo="Total del ítem según factura" valor={p.total} cambiar={v => item(i, { total: v })} />
          <label>El total impreso del ítem es<select value={p.tipoTotal ?? ''} onChange={e => item(i, { tipoTotal: e.target.value === 'Neto' ? 'Neto' : e.target.value === 'ConIva' ? 'ConIva' : null })}>
            <option value="">Verificar</option><option value="Neto">Neto, sin IVA (habitual factura A)</option><option value="ConIva">Incluye IVA</option>
          </select></label>
        </div><label><input type="checkbox" checked={p.recordarEquivalencia} onChange={e => item(i, { recordarEquivalencia: e.target.checked })} />
          Recordar código de este proveedor → producto seleccionado (al guardar la compra)</label>
        <button className="btn" onClick={() => editar({ ...revision, documento: { ...revision.documento, items: revision.documento.items.filter((_, n) => n !== i) } })}>Quitar ítem {i + 1}</button>
      </section>)}
      <button className="btn" disabled={revision.documento.items.length >= 200} onClick={() => editar({ ...revision, documento: {
        ...revision.documento, items: [...revision.documento.items, { codigo: null, descripcion: null, unidad: null, producto: null, cantidad: null,
          cantidadStock: null, precioNeto: null, descuento: null, iva: null, total: null, tipoTotal: null, recordarEquivalencia: false }] } })}>Agregar ítem faltante</button>
      <div><label><input type="checkbox" checked={revision.revisado} onChange={e => {
        setRevision({ ...revision, revisado: e.target.checked }); setValidacion(undefined); setCambio(true);
      }} /> Revisé el original, tipo de comprobante, proveedor, productos, unidades, impuestos y totales.</label></div>
      <button className="btn" onClick={() => void ejecutar(async () => {
        const r = await api.comprasDocRevision(revision); setActual(r); setRevision({ ...revision, version: r.version }); setValidacion(undefined); setCambio(false);
        setLista(await api.comprasDocListar()); setMensaje('Correcciones guardadas. No se creó una compra.');
      })}>Guardar correcciones sin crear compra</button>
      <button className="btn primary" onClick={() => void ejecutar(async () => {
        setValidacion(undefined); setValidacion(await api.comprasDocRevisar(revision));
      })}>Validar borrador</button>
      {validacion && <section><p>Total recalculado: {validacion.total.toLocaleString('es-AR', { minimumFractionDigits: 2 })}</p>
        {validacion.errores.map((e, i) => <p role="alert" className="alert" key={i}>{e}</p>)}
        {validacion.advertencias.map((e, i) => <p key={i}>{e}</p>)}
        {validacion.firma && validacion.errores.length === 0 && <button className="btn primary" onClick={() => void ejecutar(async () => {
          if (!await confirmar('¿Crear el comprobante de compra PENDIENTE con estos datos revisados? No confirma, paga ni mueve stock.')) return;
          const r = await api.comprasDocGuardar(revision, validacion.firma!); setCambio(false); setValidacion(undefined);
          await abrir(await api.comprasDocObtener(revision.id)); setLista(await api.comprasDocListar());
          setMensaje(`Compra #${r.compra} creada PENDIENTE. Continúe desde Comprobantes de compras para confirmar por el circuito habitual.`);
        })}>Crear compra pendiente</button>}
      </section>}
    </fieldset>}</div></div></fieldset>
  </section></div>;
}
