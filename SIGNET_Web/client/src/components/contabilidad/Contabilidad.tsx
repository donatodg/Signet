import { useEffect, useRef, useState } from 'react';
import { api } from '../../api';
import type { LookupItem } from '../../types';
import type { Asiento, Asignacion, Catalogos, Configuracion, Estado, Mayor, PartidaComplementaria, Plantilla, Regla, Registro, Saldo, Simulacion } from './types';
import { confirmar } from '../Dialogos';
import './Contabilidad.css';
import { AutomatizacionProductiva, BandejaProductiva, ClasificacionProductiva, ConciliacionProductiva, PeriodosProductivos } from './Productiva';

const fechaHoy = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};
const numero = (v: number) => v.toLocaleString('es-AR', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const nombre = (opciones: LookupItem[], id: number) => opciones.find(o => Number(o.key) === id)?.name ?? `#${id}`;
const claveNueva = () => {
  const bytes = crypto.getRandomValues(new Uint8Array(16));
  bytes[6] = (bytes[6] & 15) | 64; bytes[8] = (bytes[8] & 63) | 128;
  const hex = Array.from(bytes, b => b.toString(16).padStart(2, '0')).join('');
  return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20)}`;
};
const reglaNueva = (lado = 1): Regla => ({ origen: 1, magnitud: 1, lado, factor: 1, cuentaFija: null, rol: '',
  prioridad: [1], producto: null, categoria: null, impuesto: null, formaPago: null });
function Elegir({ titulo, opciones, valor, cambiar, opcional = false }: {
  titulo: string; opciones: LookupItem[]; valor: number | null; cambiar: (v: number | null) => void; opcional?: boolean;
}) {
  return <label>{titulo}<select value={valor || ''} required={!opcional} onChange={e => cambiar(Number(e.target.value) || null)}>
    <option value="">{opcional ? 'Sin filtro / no aplica' : 'Seleccione'}</option>
    {opciones.map(o => <option key={o.key} value={o.key}>{o.name}</option>)}
  </select></label>;
}
function Referencia({ empresa, dimension, valor, cambiar }: {
  empresa: number; dimension: number; valor: number; cambiar: (id: number) => void;
}) {
  const [buscar, setBuscar] = useState('');
  const [opciones, setOpciones] = useState<LookupItem[]>([]);
  const [seleccionada, setSeleccionada] = useState<LookupItem>();
  const [error, setError] = useState('');
  useEffect(() => {
    let vivo = true;
    setSeleccionada(undefined);
    if (valor && dimension !== 13) api.contabilidadReferencias(empresa, dimension, '', valor)
      .then(r => { if (vivo) setSeleccionada(r[0]); }).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [empresa, dimension, valor]);
  useEffect(() => {
    let vivo = true; setOpciones([]); setError('');
    if (dimension === 13) return;
    const timer = setTimeout(() => api.contabilidadReferencias(empresa, dimension, buscar)
      .then(r => vivo && setOpciones(r)).catch(e => vivo && setError(e.message)), 300);
    return () => { vivo = false; clearTimeout(timer); };
  }, [empresa, dimension, buscar]);
  const lista = seleccionada && !opciones.some(o => o.key === seleccionada.key) ? [seleccionada, ...opciones] : opciones;
  if (dimension === 13) return <label>Código de concepto<input type="number" required min="1" value={valor || ''}
    onChange={e => cambiar(Number(e.target.value))} /></label>;
  return <div><label>Buscar referencia<input type="search" maxLength={100} value={buscar} onChange={e => setBuscar(e.target.value)} /></label>
    <Elegir titulo="Referencia" opciones={lista} valor={valor} cambiar={v => cambiar(v || 0)} />
    {error && <p role="alert">{error}</p>}</div>;
}
function Reglas({ plantilla, catalogos: c, cambiar }: { plantilla: Plantilla; catalogos: Catalogos; cambiar: (p: Plantilla) => void }) {
  const actualizar = (i: number, patch: Partial<Regla>) => cambiar({ ...plantilla,
    reglas: plantilla.reglas.map((r, n) => n === i ? { ...r, ...patch } : r) });
  return <div>
    {plantilla.reglas.map((r, i) => <section className="account-rule" key={i}>
      <h4>Regla {i + 1}</h4>
      <div className="account-fields">
        <Elegir titulo="Origen de las partidas" opciones={c.origenes} valor={r.origen} cambiar={v => actualizar(i, { origen: v || 1 })} />
        <Elegir titulo="Importe a tomar" opciones={c.magnitudes} valor={r.magnitud} cambiar={v => actualizar(i, { magnitud: v || 1 })} />
        <Elegir titulo="Debe / Haber" opciones={c.lados} valor={r.lado} cambiar={v => actualizar(i, { lado: v || 1 })} />
        <label>Filtro concepto (código opcional)<input type="number" min="1" value={r.concepto ?? ''}
          onChange={e => actualizar(i, { concepto: Number(e.target.value) || null })} /></label>
        <label>Filtro caja (ID opcional)<input type="number" min="1" value={r.caja ?? ''}
          onChange={e => actualizar(i, { caja: Number(e.target.value) || null })} /></label>
        <label>Factor (1 = 100%)<input type="number" min="0.000001" max="100" step="any" required value={r.factor}
          onChange={e => actualizar(i, { factor: Number(e.target.value) })} /></label>
        <label>Resolución de cuenta<select value={r.cuentaFija !== null ? 'fija' : 'rol'}
          onChange={e => actualizar(i, e.target.value === 'fija' ? { cuentaFija: 0, rol: null, prioridad: [] }
            : { cuentaFija: null, rol: '', prioridad: [1] })}><option value="rol">Por rol y prioridades</option><option value="fija">Cuenta fija</option></select></label>
        {r.cuentaFija !== null
          ? <Elegir titulo="Cuenta contable" opciones={c.cuentas} valor={r.cuentaFija} cambiar={v => actualizar(i, { cuentaFija: v || 0 })} />
          : <label>Rol contable<input required maxLength={60} placeholder="Ej.: Ventas, Deudores, Caja" value={r.rol || ''}
            onChange={e => actualizar(i, { rol: e.target.value })} /></label>}
      </div>
      {r.cuentaFija === null && <div>
        <p>Buscar cuenta en este orden; si no existe ninguna asignación, se bloquea el asiento.</p>
        {r.prioridad.map((d, n) => <div className="account-priority" key={d}><span>{n + 1}. {nombre(c.dimensiones, d)}</span>
          <button type="button" className="btn small" disabled={n === 0} onClick={() => {
            const prioridades = [...r.prioridad]; [prioridades[n - 1], prioridades[n]] = [prioridades[n], prioridades[n - 1]];
            actualizar(i, { prioridad: prioridades });
          }}>Subir</button>
          <button type="button" className="btn small" onClick={() => actualizar(i, { prioridad: r.prioridad.filter(x => x !== d) })}>Quitar</button></div>)}
        <label>Agregar prioridad<select value="" onChange={e => e.target.value && actualizar(i, { prioridad: [...r.prioridad, Number(e.target.value)] })}>
          <option value="">Seleccione dimensión</option>{c.dimensiones.filter(o => !r.prioridad.includes(Number(o.key)))
            .map(o => <option key={o.key} value={o.key}>{o.name}</option>)}</select></label>
      </div>}
      <details><summary>Filtros opcionales de la regla</summary>
        <p>Estos filtros restringen partidas; no agregan importes. Usá varias reglas y factores para distribuir una partida.</p>
        <div className="account-fields">{(['producto', 'categoria', 'impuesto', 'formaPago'] as const).map(f =>
          <label key={f}>{f} (ID de origen)<input type="number" min="1" value={r[f] ?? ''}
            onChange={e => actualizar(i, { [f]: Number(e.target.value) || null })} /></label>)}</div>
      </details>
      <button type="button" className="btn" onClick={() => cambiar({ ...plantilla, reglas: plantilla.reglas.filter((_, n) => n !== i) })}>Quitar regla {i + 1}</button>
    </section>)}
    <button type="button" className="btn" onClick={() => cambiar({ ...plantilla, reglas: [...plantilla.reglas, reglaNueva()] })}>Agregar regla</button>
  </div>;
}
function Configurar({ empresa, catalogos: c, editable }: { empresa: number; catalogos: Catalogos; editable: boolean }) {
  const [config, setConfig] = useState<Configuracion>();
  const [error, setError] = useState('');
  const [mensaje, setMensaje] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const [sucio, setSucio] = useState(false);
  useEffect(() => {
    let vivo = true;
    api.contabilidadConfiguracion(empresa).then(r => vivo && setConfig(r)).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [empresa]);
  useEffect(() => {
    const salir = (e: BeforeUnloadEvent) => { e.preventDefault(); e.returnValue = ''; };
    if (sucio) window.addEventListener('beforeunload', salir);
    return () => window.removeEventListener('beforeunload', salir);
  }, [sucio]);
  const cambiar = (nuevo: Configuracion) => { setConfig(nuevo); setSucio(true); setMensaje(''); };
  const guardar = async () => {
    if (!config || ocupado || !await confirmar('¿Guardar una nueva versión de la configuración contable? Los asientos existentes no se modifican.')) return;
    setOcupado(true); setError('');
    try { setConfig(await api.contabilidadGuardar(config)); setSucio(false); setMensaje('Configuración guardada en una nueva versión.'); }
    catch (e) { setError((e as Error).message); }
    finally { setOcupado(false); }
  };
  if (!config) return <p role={error ? 'alert' : 'status'}>{error || 'Cargando configuración...'}</p>;
  const plantilla = (i: number, p: Plantilla) => cambiar({ ...config, plantillas: config.plantillas.map((x, n) => n === i ? p : x) });
  const asignar = (i: number, patch: Partial<Asignacion>) => cambiar({ ...config, asignaciones: config.asignaciones.map((a, n) => n === i ? { ...a, ...patch } : a) });
  return <form onSubmit={e => { e.preventDefault(); void guardar(); }}>
    <p>Versión {config.version || 'sin guardar'}{sucio && ' · Cambios sin guardar'}. Cada guardado conserva la versión anterior.</p>
    <p>Importes convertidos usando las cotizaciones históricas del documento. Seleccioná la moneda local a la que corresponden esas cotizaciones.</p>
    {error && <p className="alert" role="alert">{error}</p>}{mensaje && <p className="info" role="status">{mensaje}</p>}
    <fieldset disabled={!editable || ocupado}>
      <Elegir titulo="Moneda contable local" opciones={c.monedas} valor={config.monedaBase} cambiar={v => cambiar({ ...config, monedaBase: v || 0 })} />
      <h3>Plantillas por operatoria</h3>
      <p>Una operatoria puede generar varios asientos. Cada plantilla debe balancear por separado. Sin ajustes automáticos de diferencia.</p>
      {config.plantillas.map((p, i) => <details className="account-card" key={i} open>
        <summary>{p.codigo || 'Nueva plantilla'} · {p.nombre}</summary>
        <div className="account-fields">
          <label>Código único<input required maxLength={40} value={p.codigo} onChange={e => plantilla(i, { ...p, codigo: e.target.value })} /></label>
          <label>Nombre<input required maxLength={200} value={p.nombre} onChange={e => plantilla(i, { ...p, nombre: e.target.value })} /></label>
          <Elegir titulo="Operatoria" opciones={c.operatorias} valor={p.operatoria} cambiar={v => plantilla(i, { ...p, operatoria: v || 1 })} />
          <Elegir titulo="Tipo de comprobante" opciones={c.comprobantes} valor={p.tipoComprobante} opcional={p.operatoria !== 1 && p.operatoria !== 2}
            cambiar={v => plantilla(i, { ...p, tipoComprobante: v })} />
          <Elegir titulo="Sucursal" opciones={c.sucursales} valor={p.sucursal} opcional cambiar={v => plantilla(i, { ...p, sucursal: v })} />
          <label>Vigente desde<input type="date" required value={p.desde.slice(0, 10)} onChange={e => plantilla(i, { ...p, desde: e.target.value })} /></label>
          <label>Vigente hasta<input type="date" min={p.desde.slice(0, 10)} value={p.hasta?.slice(0, 10) || ''}
            onChange={e => plantilla(i, { ...p, hasta: e.target.value || null })} /></label>
          <label className="account-check"><input type="checkbox" checked={p.invertir} onChange={e => plantilla(i, { ...p, invertir: e.target.checked })} />
            Invertir Debe/Haber (ej.: nota de crédito)</label>
        </div>
        <Reglas plantilla={p} catalogos={c} cambiar={v => plantilla(i, v)} />
        <button type="button" className="btn" onClick={() => cambiar({ ...config, plantillas: [...config.plantillas,
          { ...p, codigo: p.codigo + '-copia', reglas: p.reglas.map(r => ({ ...r, prioridad: [...r.prioridad] })) }] })}>Duplicar plantilla</button>
        <button type="button" className="btn" onClick={async () => {
          if (await confirmar('¿Quitar esta plantilla de la nueva versión?')) cambiar({ ...config, plantillas: config.plantillas.filter((_, n) => n !== i) });
        }}>Quitar plantilla</button>
      </details>)}
      <button type="button" className="btn" onClick={() => cambiar({ ...config, plantillas: [...config.plantillas, { codigo: '', nombre: '',
        operatoria: 1, desde: fechaHoy(), hasta: null, tipoComprobante: null, sucursal: null, invertir: false, reglas: [reglaNueva(1), reglaNueva(2)] }] })}>Agregar plantilla</button>
      <h3>Asignación de cuentas por rol</h3>
      <p>Ejemplo: rol Ventas + Producto 1 → cuenta de ventas del producto. La prioridad de cada regla define si buscar producto, categoría o cuenta general.</p>
      {config.asignaciones.map((a, i) => <section className="account-card account-fields" key={i}>
        <label>Rol<input required maxLength={60} value={a.rol} onChange={e => asignar(i, { rol: e.target.value })} /></label>
        <Elegir titulo="Dimensión" opciones={c.dimensiones.filter(d => Number(d.key) !== 14)} valor={a.dimension} cambiar={v => asignar(i, { dimension: v || 1, referencia: 0 })} />
        <Referencia empresa={empresa} dimension={a.dimension} valor={a.referencia} cambiar={v => asignar(i, { referencia: v })} />
        <Elegir titulo="Cuenta imputable" opciones={c.cuentas} valor={a.cuenta} cambiar={v => asignar(i, { cuenta: v || 0 })} />
        <button type="button" className="btn" onClick={() => cambiar({ ...config, asignaciones: config.asignaciones.filter((_, n) => n !== i) })}>Quitar asignación</button>
      </section>)}
      <button type="button" className="btn" onClick={() => cambiar({ ...config, asignaciones: [...config.asignaciones,
        { rol: '', dimension: 1, referencia: empresa, cuenta: 0 }] })}>Agregar asignación</button>
      <p><button className="btn primary" disabled={!sucio}>{ocupado ? 'Guardando...' : 'Guardar nueva versión'}</button></p>
    </fieldset>
  </form>;
}

function DetalleAsientos({ asientos, catalogos: c }: { asientos: Asiento[]; catalogos: Catalogos }) {
  return <>{asientos.map((a, i) => <section className="account-card" key={i}><h4>{a.plantilla} · {a.descripcion}</h4>
    <div className="account-table"><table className="grid"><thead><tr><th>Cuenta</th><th>Debe</th><th>Haber</th><th>Origen / resolución</th></tr></thead>
      <tbody>{a.renglones.map((r, n) => <tr key={n}><td>{nombre(c.cuentas, r.cuenta)}</td><td>{numero(r.debe)}</td><td>{numero(r.haber)}</td>
        <td>Regla {r.regla} · {r.origen} · {r.resolucion}</td></tr>)}</tbody></table></div>
    <p>Debe {numero(a.debe)} · Haber {numero(a.haber)} · Diferencia {numero(a.debe - a.haber)}</p>
  </section>)}</>;
}
function Registrar({ empresa, catalogos: c, permitido }: { empresa: number; catalogos: Catalogos; permitido: boolean }) {
  const [operatoria, setOperatoria] = useState(1);
  const [documento, setDocumento] = useState('');
  const [buscar, setBuscar] = useState('');
  const [documentos, setDocumentos] = useState<LookupItem[]>([]);
  const [simulacion, setSimulacion] = useState<Simulacion>();
  const [error, setError] = useState('');
  const [registro, setRegistro] = useState<Registro>();
  const [ocupado, setOcupado] = useState(false);
  const bloqueo = useRef(false);
  useEffect(() => {
    let vivo = true;
    setDocumentos([]); setDocumento(''); setSimulacion(undefined); setRegistro(undefined);
    const timer = setTimeout(() => api.contabilidadDocumentos(empresa, operatoria, buscar)
      .then(r => vivo && setDocumentos(r)).catch(e => vivo && setError(e.message)), 300);
    return () => { vivo = false; clearTimeout(timer); };
  }, [empresa, operatoria, buscar]);
  const ejecutar = async (registrar: boolean) => {
    if (bloqueo.current || registrar && !simulacion) return;
    bloqueo.current = true;
    if (registrar && !await confirmar('¿Registrar todos los asientos simulados? Se guardarán juntos y solo podrán corregirse mediante reversión.')) {
      bloqueo.current = false; return;
    }
    setOcupado(true); setError(''); setRegistro(undefined);
    try {
      const solicitud = { empresa, operatoria, documento: Number(documento), firma: simulacion?.firma };
      if (registrar) { setRegistro(await api.contabilidadRegistrar(solicitud)); setSimulacion(undefined); }
      else { setSimulacion(undefined); setSimulacion(await api.contabilidadSimular(solicitud)); }
    } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  const limpiar = () => { setSimulacion(undefined); setRegistro(undefined); setError(''); };
  return <><p>Simulá usando un documento de gestión confirmado o un documento complementario aprobado. La registración vuelve a leer los importes del servidor.</p>
    <p>Transferencias: cotizaciones históricas y ambas cajas. Costos, stock y sueldos: importes documentados en Complementarios. Apertura/cierre: saldos del ejercicio; el cierre bloquea el ejercicio al registrar.</p>
    <form onSubmit={e => { e.preventDefault(); void ejecutar(false); }}><fieldset disabled={ocupado} className="account-fields">
      <Elegir titulo="Operatoria" opciones={c.operatorias} valor={operatoria}
        cambiar={v => { limpiar(); setOperatoria(v || 1); }} />
      <label>Buscar comprobante<input type="search" maxLength={100} value={buscar} placeholder="Número o concepto"
        onChange={e => { limpiar(); setBuscar(e.target.value); }} /></label>
      <Elegir titulo="Documento confirmado" opciones={documentos} valor={Number(documento)} cambiar={v => { limpiar(); setDocumento(String(v || '')); }} />
      <button className="btn primary">{ocupado ? 'Procesando...' : 'Simular asientos'}</button>
    </fieldset></form>
    {error && <p className="alert" role="alert">{error}</p>}
    {registro && <p className="info" role="status">Lote #{registro.id} registrado. Asientos: {registro.asientos.join(', ')}.</p>}
    {simulacion && <><h3>Revisión · Versión {simulacion.version}</h3>
      <p>{simulacion.hecho.descripcion} · Fecha contable: {simulacion.hecho.fecha.slice(0, 10)}</p>
      <DetalleAsientos asientos={simulacion.asientos} catalogos={c} />
      {permitido && <button className="btn primary" disabled={ocupado} onClick={() => void ejecutar(true)}>Registrar asientos revisados</button>}
    </>}
  </>;
}
function Complementarios({ empresa, catalogos: c }: { empresa: number; catalogos: Catalogos }) {
  const [op, setOp] = useState(5);
  const [fecha, setFecha] = useState(fechaHoy());
  const [sucursal, setSucursal] = useState(0);
  const [moneda, setMoneda] = useState(0);
  const [descripcion, setDescripcion] = useState('');
  const [respaldo, setRespaldo] = useState('');
  const [ejercicio, setEjercicio] = useState(0);
  const [partidas, setPartidas] = useState<PartidaComplementaria[]>([]);
  const [resultado, setResultado] = useState('');
  const [error, setError] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const bloqueo = useRef(false);
  const clave = useRef(claveNueva());
  const esEjercicio = op === 11 || op === 12;
  const esProducto = op === 5 || op === 6;
  const modificar = () => { clave.current = claveNueva(); setResultado(''); setError(''); };
  const cambiarPartida = (i: number, patch: Partial<PartidaComplementaria>) => {
    modificar(); setPartidas(ps => ps.map((p, n) => n === i ? { ...p, ...patch } : p));
  };
  const guardar = async () => {
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError('');
    try {
      if (!await confirmar(esEjercicio ? '¿Preparar un documento desde los saldos? Todavía no registra asientos ni cierra el ejercicio.'
        : '¿Aprobar estos importes y su respaldo? El documento será inmutable. Luego deberá simular y registrar los asientos.')) return;
      const doc = esEjercicio
        ? await api.contabilidadEjercicio({ empresa, ejercicio, operatoria: op, sucursal, fecha, clave: clave.current })
        : await api.contabilidadCrearDocumento({ clave: clave.current, moneda, respaldo,
          hecho: { empresa, operatoria: op, sucursal, fecha, descripcion, partidas } });
      setResultado(`Documento #${doc.id} aprobado. Seleccioná ${nombre(c.operatorias, op)} en Simular y registrar para revisar sus asientos.`);
    } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  return <><p>Documentos contables complementarios: no generan ventas, movimientos físicos de stock ni liquidan sueldos.
    Los importes deben provenir de una valuación o liquidación revisada y expresarse en moneda local; no se consulta el costo actual.</p>
    <form onSubmit={e => { e.preventDefault(); void guardar(); }}><fieldset disabled={ocupado}>
      <div className="account-fields">
        <Elegir titulo="Operatoria complementaria" opciones={c.operatorias.filter(o => [5, 6, 8, 9, 10, 11, 12].includes(Number(o.key)))}
          valor={op} cambiar={v => { modificar(); setOp(v || 5); setPartidas([]); }} />
        <Elegir titulo="Sucursal" opciones={c.sucursales} valor={sucursal} cambiar={v => { modificar(); setSucursal(v || 0); }} />
        <label>Fecha contable<input type="date" required value={fecha} onChange={e => { modificar(); setFecha(e.target.value); }} /></label>
        {esEjercicio ? <Elegir titulo="Ejercicio de origen" opciones={c.ejercicios} valor={ejercicio}
          cambiar={v => { modificar(); setEjercicio(v || 0); }} /> : <>
          <Elegir titulo="Moneda local de los importes" opciones={c.monedas} valor={moneda} cambiar={v => { modificar(); setMoneda(v || 0); }} />
          <label>Descripción<input required maxLength={300} value={descripcion} onChange={e => { modificar(); setDescripcion(e.target.value); }} /></label>
          <label>Respaldo (documento / liquidación / valuación)<input required maxLength={500} value={respaldo}
            onChange={e => { modificar(); setRespaldo(e.target.value); }} /></label>
        </>}
      </div>
      {esEjercicio ? <p>Cierre: fecha final del ejercicio abierto. Apertura: fecha inicial del nuevo ejercicio, con origen cerrado.
        El motor verifica que las plantillas trasladen exactamente los saldos; no calcula resultado fiscal ni ajustes por inflación.</p> : <>
        {partidas.map((p, i) => <section key={i} className="account-rule"><h4>Partida {i + 1}</h4>
          <div className="account-fields">
            <label>Referencia de partida<input required maxLength={200} value={p.referencia} onChange={e => cambiarPartida(i, { referencia: e.target.value })} /></label>
            <label>Importe local con signo<input type="number" required step="0.01" value={p.importe || ''}
              onChange={e => cambiarPartida(i, { importe: Number(e.target.value) })} /></label>
            {esProducto ? <Referencia empresa={empresa} dimension={2} valor={p.producto || 0} cambiar={v => cambiarPartida(i, { producto: v })} /> :
              <label>Código de concepto<input type="number" required min="1" value={p.concepto || ''}
                onChange={e => cambiarPartida(i, { concepto: Number(e.target.value) || null })} /></label>}
            {op === 8 && <Referencia empresa={empresa} dimension={12} valor={p.personal || 0} cambiar={v => cambiarPartida(i, { personal: v || null })} />}
            <button type="button" className="btn" onClick={() => { modificar(); setPartidas(ps => ps.filter((_, n) => n !== i)); }}>Quitar partida</button>
          </div>
        </section>)}
        <button type="button" className="btn" disabled={partidas.length >= 500} onClick={() => {
          modificar(); setPartidas(ps => [...ps, { origen: esProducto ? 2 : 5, referencia: '', importe: 0, producto: null, concepto: null, personal: null }]);
        }}>Agregar partida</button>
      </>}
      <button className="btn primary" disabled={!esEjercicio && partidas.length === 0}>{esEjercicio ? 'Preparar apertura / cierre' : 'Aprobar documento complementario'}</button>
    </fieldset></form>
    {error && <p className="alert" role="alert">{error}</p>}
    {resultado && <p className="info" role="status">{resultado}</p>}
  </>;
}
function Libros({ empresa, catalogos: c }: { empresa: number; catalogos: Catalogos }) {
  const [desde, setDesde] = useState(fechaHoy().slice(0, 4) + '-01-01');
  const [hasta, setHasta] = useState(fechaHoy());
  const [moneda, setMoneda] = useState(0);
  const [cuenta, setCuenta] = useState(0);
  const [saldos, setSaldos] = useState<Saldo[]>();
  const [mayor, setMayor] = useState<Mayor>();
  const [error, setError] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const bloqueo = useRef(false);
  const limpiar = () => { setSaldos(undefined); setMayor(undefined); setError(''); };
  const consultar = async () => {
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); limpiar();
    try {
      if (cuenta) setMayor(await api.contabilidadMayor(empresa, moneda, cuenta, desde, hasta));
      else setSaldos(await api.contabilidadSaldos(empresa, moneda, desde, hasta));
    } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  return <><p>Incluye asientos manuales y generados, excluye bajas y anulados. Cada moneda se consulta por separado.
    Saldo anterior: todos los movimientos previos al período seleccionado.</p>
    <form onSubmit={e => { e.preventDefault(); void consultar(); }}><fieldset disabled={ocupado} className="account-fields">
      <Elegir titulo="Moneda del libro" opciones={c.monedas} valor={moneda} cambiar={v => { limpiar(); setMoneda(v || 0); }} />
      <Elegir titulo="Cuenta del mayor (vacío = sumas y saldos)" opciones={c.cuentas} valor={cuenta} opcional
        cambiar={v => { limpiar(); setCuenta(v || 0); }} />
      <label>Desde<input type="date" required value={desde} onChange={e => { limpiar(); setDesde(e.target.value); }} /></label>
      <label>Hasta<input type="date" required min={desde} value={hasta} onChange={e => { limpiar(); setHasta(e.target.value); }} /></label>
      <button className="btn primary">Consultar libro</button>
    </fieldset></form>
    {error && <p className="alert" role="alert">{error}</p>}
    {saldos && <div className="account-table"><table><thead><tr><th>Cuenta</th><th>Anterior</th><th>Debe</th><th>Haber</th><th>Saldo</th></tr></thead>
      <tbody>{saldos.map(s => <tr key={s.cuenta}><td>{s.nombre}</td><td>{numero(s.anterior)}</td><td>{numero(s.debe)}</td><td>{numero(s.haber)}</td><td>{numero(s.saldo)}</td></tr>)}</tbody>
      <tfoot><tr><th>Totales</th>{(['anterior', 'debe', 'haber', 'saldo'] as const).map(k =>
        <td key={k}>{numero(saldos.reduce((sum, s) => sum + s[k], 0))}</td>)}</tr></tfoot></table></div>}
    {mayor && <><p>Saldo anterior {numero(mayor.anterior)} · Saldo final {numero(mayor.saldo)}</p>
      <div className="account-table"><table><thead><tr><th>Fecha</th><th>Asiento</th><th>Descripción</th><th>Debe</th><th>Haber</th><th>Saldo</th></tr></thead>
        <tbody>{mayor.movimientos.map((m, i) => <tr key={i}><td>{m.fecha.slice(0, 10)}</td><td>{m.numero}</td><td>{m.descripcion}</td>
          <td>{numero(m.debe)}</td><td>{numero(m.haber)}</td><td>{numero(m.saldo)}</td></tr>)}</tbody></table></div></>}
  </>;
}
function Diario({ empresa, catalogos: c, permitido }: { empresa: number; catalogos: Catalogos; permitido: boolean }) {
  const [desde, setDesde] = useState(fechaHoy().slice(0, 7) + '-01');
  const [hasta, setHasta] = useState(fechaHoy());
  const [lotes, setLotes] = useState<Registro[]>([]);
  const [error, setError] = useState('');
  const [ocupado, setOcupado] = useState(false);
  const [reversion, setReversion] = useState<Registro>();
  const [fecha, setFecha] = useState(fechaHoy());
  const [motivo, setMotivo] = useState('');
  const bloqueo = useRef(false);
  const consultar = async () => {
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError(''); setLotes([]);
    try { setLotes(await api.contabilidadDiario(empresa, desde, hasta)); }
    catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  const revertir = async () => {
    if (!reversion || bloqueo.current || !await confirmar(`¿Generar el contraasiento del lote #${reversion.id}? El original se conserva.`)) return;
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError('');
    try {
      await api.contabilidadRevertir(empresa, reversion.id, fecha, motivo); setReversion(undefined); setMotivo('');
      setLotes(await api.contabilidadDiario(empresa, desde, hasta));
    } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  return <><p>Lotes del motor parametrizable. Los asientos también están en la pantalla Asientos, junto con los manuales.</p>
    <form onSubmit={e => { e.preventDefault(); void consultar(); }}><fieldset disabled={ocupado} className="account-fields">
      <label>Desde<input type="date" required value={desde} onChange={e => { setDesde(e.target.value); setLotes([]); }} /></label>
      <label>Hasta<input type="date" required min={desde} value={hasta} onChange={e => { setHasta(e.target.value); setLotes([]); }} /></label>
      <button className="btn primary">Consultar diario</button>
    </fieldset></form>
    {error && <p className="alert" role="alert">{error}</p>}
    {lotes.map(l => <details key={l.id} className="account-card"><summary>Lote #{l.id} · {l.fecha.slice(0, 10)} · {nombre(c.operatorias, l.operatoria)}
      {' '}#{l.documento}{l.reversionDe && ` · Reversión de #${l.reversionDe}`}</summary>
      <p>Usuario #{l.usuario} · Versión {l.simulacion.version} · Asientos {l.asientos.join(', ')}</p>
      <DetalleAsientos asientos={l.simulacion.asientos} catalogos={c} />
      {permitido && !l.reversionDe && !lotes.some(r => r.reversionDe === l.id) && <button className="btn" disabled={ocupado}
        onClick={() => { setReversion(l); setMotivo(''); }}>Revertir lote #{l.id}</button>}
    </details>)}
    {reversion && <form className="account-card" onSubmit={e => { e.preventDefault(); void revertir(); }}>
      <h3>Revertir lote #{reversion.id}</h3><fieldset disabled={ocupado}>
        <label>Fecha contable de reversión<input type="date" required value={fecha} onChange={e => setFecha(e.target.value)} /></label>
        <label>Motivo<input required maxLength={200} value={motivo} onChange={e => setMotivo(e.target.value)} /></label>
        <button className="btn primary">Confirmar reversión</button>
        <button type="button" className="btn" onClick={() => setReversion(undefined)}>Cancelar</button>
      </fieldset></form>}
  </>;
}
export function Contabilidad() {
  const [estado, setEstado] = useState<Estado>();
  const [empresa, setEmpresa] = useState(0);
  const [catalogos, setCatalogos] = useState<Catalogos>();
  const [vista, setVista] = useState('inicio');
  const [error, setError] = useState('');
  useEffect(() => {
    let vivo = true;
    api.contabilidadEstado().then(r => { if (vivo) { setEstado(r); if (r.empresas.length === 1) setEmpresa(Number(r.empresas[0].key)); } })
      .catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, []);
  useEffect(() => {
    let vivo = true; setCatalogos(undefined); setError('');
    if (empresa && estado && (estado.configurar || estado.simular || estado.diario || estado.bandeja || estado.automatizacion || estado.periodos || estado.conciliar || estado.aprobar))
      api.contabilidadCatalogos(empresa).then(r => vivo && setCatalogos(r)).catch(e => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [empresa, estado]);
  return <div className="accounting"><h2>Contabilidad</h2>
    <p>Plantillas versionadas, cuentas por dimensión y registración trazable. La automatización es opcional y requiere políticas autorizadas y el worker habilitado.</p>
    {error && <p className="alert" role="alert">{error}</p>}
    {!estado && !error && <p>Cargando permisos...</p>}
    {estado && <>
      <Elegir titulo="Empresa contable" opciones={estado.empresas} valor={empresa} cambiar={async v => {
        if (vista !== 'inicio' && !await confirmar('¿Cambiar de empresa? Se perderán los cambios y simulaciones sin guardar.')) return;
        setVista('inicio'); setEmpresa(v || 0);
      }} />
      <nav className="account-tabs" aria-label="Contabilidad">
        {[['inicio', 'Maestros', true], ['configuracion', 'Parametrización', estado.configurar],
          ['registracion', 'Simular y registrar', estado.simular], ['complementarios', 'Complementarios y ejercicios', estado.registrar],
          ['libros', 'Mayor y sumas y saldos', estado.diario], ['diario', 'Diario y reversiones', estado.diario],
          ['bandeja', 'Bandeja y aprobaciones', estado.bandeja], ['automatizacion', 'Automatización', estado.automatizacion],
          ['periodos', 'Períodos y auditoría', estado.periodos], ['conciliacion', 'Conciliación e informes', estado.conciliar],
          ['clasificacion', 'Clasificación y cajas', estado.configurar]].map(([key, titulo, visible]) =>
          visible && <button className={`btn${vista === key ? ' primary' : ''}`} key={String(key)} onClick={async () => {
            if (vista === key || vista === 'inicio' || await confirmar('¿Cambiar de sección? Se perderán los cambios y simulaciones sin guardar.')) setVista(String(key));
          }}>{titulo}</button>)}
      </nav>
      {vista === 'inicio' && <section className="account-card"><h3>Maestros y asientos</h3>
        <p>Conservan sus permisos originales. Las plantillas antiguas no se convierten automáticamente a reglas nuevas.</p>
        <div className="account-tabs">{[['PlanDeCuentas', 'Plan de cuentas'], ['EjerciciosContables', 'Ejercicios contables'],
          ['Asientos', 'Asientos manuales y generados'], ['TipoAsientos', 'Tipos de asiento heredados'],
          ['TipoCategoriasContables', 'Categorías contables']].map(([key, titulo]) => <a className="btn" key={key} href={`#/${key}`}>{titulo}</a>)}</div>
      </section>}
      {vista !== 'inicio' && !empresa && <p>Seleccione una empresa.</p>}
      {empresa > 0 && vista !== 'inicio' && !catalogos && !error && <p>Cargando catálogos...</p>}
      {catalogos && <div key={`${empresa}-${vista}`}>
        {vista === 'configuracion' && estado.configurar && <Configurar empresa={empresa} catalogos={catalogos} editable={estado.editar} />}
        {vista === 'registracion' && estado.simular && <Registrar empresa={empresa} catalogos={catalogos} permitido={estado.registrar} />}
        {vista === 'diario' && estado.diario && <Diario empresa={empresa} catalogos={catalogos} permitido={estado.revertir} />}
        {vista === 'complementarios' && estado.registrar && <Complementarios empresa={empresa} catalogos={catalogos} />}
        {vista === 'libros' && estado.diario && <Libros empresa={empresa} catalogos={catalogos} />}
        {vista === 'bandeja' && estado.bandeja && <BandejaProductiva empresa={empresa} catalogos={catalogos} permisos={estado} />}
        {vista === 'automatizacion' && estado.automatizacion && <AutomatizacionProductiva empresa={empresa} catalogos={catalogos} editable={estado.editarAutomatizacion} />}
        {vista === 'periodos' && estado.periodos && <PeriodosProductivos empresa={empresa} permisos={estado} />}
        {vista === 'conciliacion' && estado.conciliar && <ConciliacionProductiva empresa={empresa} catalogos={catalogos} exportar={estado.exportar} />}
        {vista === 'clasificacion' && estado.configurar && <ClasificacionProductiva empresa={empresa} catalogos={catalogos} editable={estado.editar} />}
      </div>}
    </>}
  </div>;
}
