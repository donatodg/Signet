import { useEffect, useRef, useState } from 'react';
import { api } from '../../api';
import type { LookupItem } from '../../types';
import type { Catalogos, Clasificacion, Estado, FilaInforme, Operativa, Pendiente, Periodo, RevisionLote } from './types';
import { confirmar } from '../Dialogos';

const hoy = () => new Date().toLocaleDateString('sv-SE');
const dinero = (v: number) => v.toLocaleString('es-AR', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const nombre = (items: LookupItem[], id: number) => items.find(i => Number(i.key) === id)?.name ?? `#${id}`;
function Select({ titulo, items, valor, cambiar }: { titulo: string; items: LookupItem[]; valor: number; cambiar: (v: number) => void }) {
  return <label>{titulo}<select required value={valor || ''} onChange={e => cambiar(Number(e.target.value))}>
    <option value="">Seleccione</option>{items.map(i => <option key={i.key} value={i.key}>{i.name}</option>)}
  </select></label>;
}
function useOperacion() {
  const [ocupado, setOcupado] = useState(false);
  const [error, setError] = useState('');
  const [mensaje, setMensaje] = useState('');
  const bloqueo = useRef(false);
  const ejecutar = async (accion: () => Promise<void>) => {
    if (bloqueo.current) return;
    bloqueo.current = true; setOcupado(true); setError(''); setMensaje('');
    try { await accion(); } catch (e) { setError((e as Error).message); }
    finally { bloqueo.current = false; setOcupado(false); }
  };
  return { ocupado, ejecutar, setMensaje, avisos: <>{error && <p role="alert" className="alert">{error}</p>}{mensaje && <p role="status" className="info">{mensaje}</p>}</> };
}
export function TablaInforme({ filas }: { filas: FilaInforme[] }) {
  const columnas = Object.keys(filas[0] ?? {});
  return filas.length === 0 ? <p>Sin movimientos.</p> : <div className="account-table"><table><thead><tr>{columnas.map(c => <th key={c}>{c}</th>)}</tr></thead>
    <tbody>{filas.map((f, i) => <tr key={i}>{columnas.map(c => <td key={c}>{f[c] === null ? 'No disponible' :
      typeof f[c] === 'number' ? /importe|debe|haber|saldo|gestion|contabilidad|costo|cotiz|difer|presentacion|total/i.test(c) ? dinero(f[c]) : f[c].toLocaleString('es-AR') :
      typeof f[c] === 'boolean' ? f[c] ? 'Sí' : 'No' : f[c]}</td>)}</tr>)}</tbody></table></div>;
}
export function BandejaProductiva({ empresa, catalogos: c, permisos: p }: { empresa: number; catalogos: Catalogos; permisos: Estado }) {
  const [desde, setDesde] = useState(hoy().slice(0, 7) + '-01');
  const [hasta, setHasta] = useState(hoy());
  const [filas, setFilas] = useState<Pendiente[]>([]);
  const [seleccion, setSeleccion] = useState<Set<number>>(new Set());
  const [revisiones, setRevisiones] = useState<RevisionLote[]>([]);
  const [motivo, setMotivo] = useState('');
  const [costos, setCostos] = useState<FilaInforme[]>();
  const [ventaCosto, setVentaCosto] = useState(0);
  const operacion = useOperacion();
  const limpiar = () => { setRevisiones([]); setSeleccion(new Set()); setCostos(undefined); };
  const consultar = async () => { setFilas(await api.contabilidadBandeja(empresa, desde, hasta)); limpiar(); };
  const revisar = async () => {
    const pedidos = filas.filter(f => seleccion.has(f.id)).map(f => ({ documento: f.documento, operatoria: f.operatoria }));
    setRevisiones([]); setRevisiones(await api.contabilidadRevisarLote(empresa, pedidos));
  };
  return <><p>Confirmados sin contabilizar, errores persistentes y anulaciones posteriores. Descubrir históricos solo los incorpora a la bandeja;
    no captura costos antiguos ni habilita contabilización retroactiva automática.</p>
    <form onSubmit={e => { e.preventDefault(); void operacion.ejecutar(consultar); }}><fieldset disabled={operacion.ocupado} className="account-fields">
      <label>Desde<input type="date" required value={desde} onChange={e => { setDesde(e.target.value); limpiar(); setFilas([]); }} /></label>
      <label>Hasta<input type="date" min={desde} required value={hasta} onChange={e => { setHasta(e.target.value); limpiar(); setFilas([]); }} /></label>
      <button className="btn primary">Consultar pendientes</button>
      {p.registrarBandeja && <button className="btn" type="button" onClick={() => void operacion.ejecutar(async () => {
        if (!await confirmar('¿Descubrir comprobantes del período? No se contabilizarán automáticamente.')) return;
        const r = await api.contabilidadSincronizar(empresa, desde, hasta); await consultar();
        operacion.setMensaje(`${r.cantidad} documentos incorporados.`);
      })}>Descubrir comprobantes</button>}
    </fieldset></form>{operacion.avisos}
    <div className="account-table"><table><thead><tr><th>Revisar</th><th>Origen</th><th>Fecha</th><th>Estado</th><th>Lote</th><th>Intentos / error</th><th>Acciones</th></tr></thead>
      <tbody>{filas.map(f => <tr key={f.id}><td><input type="checkbox" aria-label={`Seleccionar documento ${f.documento}`}
        checked={seleccion.has(f.id)} disabled={operacion.ocupado || !!f.lote || f.anulado || seleccion.size >= 50 && !seleccion.has(f.id)}
        onChange={e => { const s = new Set(seleccion); e.target.checked ? s.add(f.id) : s.delete(f.id); setSeleccion(s); setRevisiones([]); }} /></td>
        <td>{nombre(c.operatorias, f.operatoria)} #{f.documento} · {f.descripcion}</td><td>{f.fecha.slice(0, 10)}</td>
        <td>{f.anulado ? f.lote ? 'Anulado contabilizado: revisar reversión' : 'Anulado' : f.lote ? 'Registrado' :
          f.estado === 4 ? 'Error' : f.estado === 2 ? 'Propuesto' : 'Pendiente'}{f.aprobado && ' · Aprobado'}</td>
        <td>{f.lote ?? '—'}</td><td>{f.intentos} · {f.error}</td><td>{p.registrarBandeja && !f.lote && <button className="btn" disabled={operacion.ocupado}
          onClick={() => void operacion.ejecutar(async () => { await api.contabilidadReintentar(empresa, f.id); await consultar(); })}>Solicitar reintento</button>}
          {[1, 13].includes(f.operatoria) && <button className="btn" disabled={operacion.ocupado} onClick={() => void operacion.ejecutar(async () => {
            setCostos(undefined); setVentaCosto(f.documento); setCostos(await api.contabilidadCostos(empresa, f.documento));
          })}>Ver costo capturado</button>}</td></tr>)}</tbody></table></div>
    {costos && <section><h3>Venta #{ventaCosto}: costo estándar vigente al confirmar, moneda y cotización capturadas</h3><TablaInforme filas={costos} /></section>}
    <button className="btn primary" disabled={operacion.ocupado || !seleccion.size} onClick={() => void operacion.ejecutar(revisar)}>Revisar selección</button>
    {p.aprobar && revisiones.length > 0 && <label>Motivo de aprobación independiente<input minLength={5} maxLength={500} value={motivo} onChange={e => setMotivo(e.target.value)} /></label>}
    {revisiones.map(r => <section className="account-card" key={`${r.operatoria}:${r.documento}`}>
      <h3>{nombre(c.operatorias, r.operatoria)} #{r.documento}</h3>
      {r.error && <p className="alert" role="alert">{r.error}</p>}
      {r.simulacion && <>{r.simulacion.asientos.map(a => <div key={a.plantilla}><h4>{a.plantilla} · Debe {dinero(a.debe)} / Haber {dinero(a.haber)}</h4>
        <TablaInforme filas={a.renglones.map(l => ({ cuenta: nombre(c.cuentas, l.cuenta), debe: l.debe, haber: l.haber, origen: l.origen, resolucion: l.resolucion }))} /></div>)}
        {p.aprobar && <button className="btn" disabled={operacion.ocupado || motivo.trim().length < 5} onClick={() => void operacion.ejecutar(async () => {
          if (!await confirmar(`¿Aprobar la revisión del documento #${r.documento}? Debe ser otro usuario distinto del responsable del origen.`)) return;
          await api.contabilidadAprobar(empresa, r, motivo); operacion.setMensaje(`Documento #${r.documento}: revisión aprobada.`);
        })}>Aprobar revisión #{r.documento}</button>}
      </>}
    </section>)}
    {p.registrarBandeja && revisiones.length > 0 && <button className="btn primary" disabled={operacion.ocupado || revisiones.some(r => !r.simulacion || !!r.error)}
      onClick={() => void operacion.ejecutar(async () => {
        if (!await confirmar('¿Registrar todos los documentos revisados? Se guardan juntos: si alguno falla, no se registra ninguno.')) return;
        const result = await api.contabilidadRegistrarLote(empresa, revisiones); await consultar();
        operacion.setMensaje(`Registrados ${result.length} lotes: ${result.map(r => r.id).join(', ')}.`);
      })}>Registrar lote revisado</button>}
  </>;
}
export function AutomatizacionProductiva({ empresa, catalogos: c, editable }: { empresa: number; catalogos: Catalogos; editable: boolean }) {
  const [config, setConfig] = useState<Operativa>();
  const [usuarios, setUsuarios] = useState<LookupItem[]>([]);
  const [motivo, setMotivo] = useState('');
  const op = useOperacion();
  useEffect(() => { let vigente = true; api.contabilidadOperativa(empresa).then(r => { if (vigente) setConfig(r); })
    .catch(e => { if (vigente) void op.ejecutar(async () => { throw e; }); }); return () => { vigente = false; }; }, [empresa]);
  useEffect(() => { let vigente = true; api.contabilidadUsuariosAutomaticos().then(r => { if (vigente) setUsuarios(r); })
    .catch(e => { if (vigente) void op.ejecutar(async () => { throw e; }); }); return () => { vigente = false; }; }, [empresa]);
  return <>{op.avisos}<p>La activación aplica a confirmaciones futuras, de web y WinForms. Automático utiliza un usuario autorizado y distinto del responsable del origen.
    Los errores quedan en cola con hasta 8 intentos. El worker debe estar configurado en el servidor.</p>
    {config && <form onSubmit={e => { e.preventDefault(); void op.ejecutar(async () => {
      if (!await confirmar('¿Guardar las políticas? Automático registra asientos futuros sin revisión humana individual, usando estas plantillas autorizadas.')) return;
      setConfig(await api.contabilidadGuardarOperativa(config, motivo)); op.setMensaje('Políticas guardadas.');
    }); }}><fieldset disabled={op.ocupado || !editable}>
      <p>Versión operativa {config.version}</p><div className="account-fields">
        <label><input type="checkbox" checked={config.activa} onChange={e => setConfig({ ...config, activa: e.target.checked })} /> Habilitar integración</label>
        <Select titulo="Moneda base" items={c.monedas} valor={config.moneda} cambiar={v => setConfig({ ...config, moneda: v })} />
        <label><input type="checkbox" checked={config.capturarCosto} onChange={e => setConfig({ ...config, capturarCosto: e.target.checked })} /> Capturar costo estándar vigente al confirmar</label>
        <label><input type="checkbox" checked={config.dobleControl} onChange={e => setConfig({ ...config, dobleControl: e.target.checked })} /> Aprobación independiente para registros manuales</label>
      </div>
      {config.politicas.map((p, i) => <section className="account-rule" key={i}><div className="account-fields">
        <Select titulo="Operatoria" items={c.operatorias.filter(o => [1, 2, 3, 4, 7, 13].includes(Number(o.key)))} valor={p.operatoria}
          cambiar={v => setConfig({ ...config, politicas: config.politicas.map((x, n) => n === i ? { ...x, operatoria: v } : x) })} />
        <Select titulo="Modo" items={[{ key: 1, name: 'Manual' }, { key: 2, name: 'Propuesto' }, { key: 3, name: 'Automático' }]} valor={p.modo}
          cambiar={v => setConfig({ ...config, politicas: config.politicas.map((x, n) => n === i ? { ...x, modo: v } : x) })} />
        {p.modo === 3 && <Select titulo="Usuario contable automático" items={usuarios} valor={p.usuarioAutomatico ?? 0}
          cambiar={v => setConfig({ ...config, politicas: config.politicas.map((x, n) => n === i ? { ...x, usuarioAutomatico: v } : x) })} />}
        <button className="btn" type="button" onClick={() => setConfig({ ...config, politicas: config.politicas.filter((_, n) => n !== i) })}>Quitar política</button>
      </div><p>Desde autorización: {p.desde?.slice(0, 19) || 'Al guardar'}</p></section>)}
      <button type="button" className="btn" disabled={config.politicas.length >= 6} onClick={() => setConfig({ ...config,
        politicas: [...config.politicas, { operatoria: 1, modo: 1, usuarioAutomatico: null, desde: '' }] })}>Agregar política</button>
      <label>Motivo del cambio<input required minLength={5} maxLength={500} value={motivo} onChange={e => setMotivo(e.target.value)} /></label>
      <button className="btn primary">Guardar políticas</button>
      <button className="btn" type="button" onClick={() => void op.ejecutar(async () => { const r = await api.contabilidadProcesar(empresa); op.setMensaje(`${r.procesados} eventos procesados.`); })}>Procesar cola ahora</button>
    </fieldset></form>}
  </>;
}
export function PeriodosProductivos({ empresa, permisos: p }: { empresa: number; permisos: Estado }) {
  const [periodos, setPeriodos] = useState<Periodo[]>([]);
  const [mes, setMes] = useState(hoy().slice(0, 7));
  const [motivo, setMotivo] = useState('');
  const [audit, setAudit] = useState<FilaInforme[]>([]);
  const op = useOperacion();
  const consultar = async () => setPeriodos(await api.contabilidadPeriodos(empresa));
  const cambiar = (cerrar: boolean) => op.ejecutar(async () => {
    if (!await confirmar(cerrar ? '¿Bloquear el mes para todos los asientos manuales, generados y reversiones?' : '¿Reabrir excepcionalmente el mes? Se registrarán usuario, fecha y motivo.')) return;
    await api.contabilidadPeriodo(empresa, mes + '-01', cerrar, motivo); await consultar(); op.setMensaje('Período actualizado.');
  });
  return <><p>Bloqueo mensual compartido por web y WinForms. La reapertura exige permiso específico, motivo y auditoría; no reabre un ejercicio cerrado.</p>
    {op.avisos}<button className="btn" disabled={op.ocupado} onClick={() => void op.ejecutar(consultar)}>Consultar períodos</button>
    <form onSubmit={e => e.preventDefault()}><fieldset disabled={op.ocupado} className="account-fields">
      <label>Mes<input type="month" required value={mes} onChange={e => setMes(e.target.value)} /></label>
      <label>Motivo<input required minLength={5} maxLength={500} value={motivo} onChange={e => setMotivo(e.target.value)} /></label>
      {p.bloquearPeriodos && <button type="button" className="btn primary" disabled={motivo.trim().length < 5} onClick={() => void cambiar(true)}>Bloquear mes</button>}
      {p.reabrirPeriodos && <button type="button" className="btn" disabled={motivo.trim().length < 5} onClick={() => void cambiar(false)}>Reabrir mes excepcionalmente</button>}
    </fieldset></form>
    <TablaInforme filas={periodos.map(x => ({ mes: x.mes.slice(0, 7), cerrado: x.cerrado, usuario: x.usuario, fecha: x.fecha, motivo: x.motivo }))} />
    <button className="btn" disabled={op.ocupado} onClick={() => void op.ejecutar(async () => setAudit(await api.contabilidadAuditoria(empresa)))}>Consultar auditoría</button>
    {audit.length > 0 && <TablaInforme filas={audit} />}
  </>;
}
export function ConciliacionProductiva({ empresa, catalogos: c, exportar }: { empresa: number; catalogos: Catalogos; exportar: boolean }) {
  const [moneda, setMoneda] = useState(0);
  const [desde, setDesde] = useState(hoy().slice(0, 4) + '-01-01');
  const [hasta, setHasta] = useState(hoy());
  const [tipo, setTipo] = useState('documentos');
  const [filas, setFilas] = useState<FilaInforme[]>();
  const op = useOperacion();
  return <><p>Control por origen y balance; N asientos no se comparan como si fueran un único importe.
    Cajas en otra moneda quedan marcadas no comparables, sin usar cotizaciones actuales. El balance clasificado es gerencial, no una presentación legal.</p>
    {op.avisos}<form onSubmit={e => { e.preventDefault(); void op.ejecutar(async () => { setFilas(undefined); setFilas(await api.contabilidadConciliacion(empresa, moneda, desde, hasta, tipo)); }); }}>
      <fieldset disabled={op.ocupado} className="account-fields">
        <label>Informe<select value={tipo} onChange={e => { setTipo(e.target.value); setFilas(undefined); }}>
          <option value="documentos">Gestión contra contabilidad</option><option value="cajas">Cajas / bancos contra mayor</option>
          <option value="balance">Balance y resultados por clasificación</option><option value="saldos">Sumas y saldos</option>
        </select></label>
        <Select titulo="Moneda del informe" items={c.monedas} valor={moneda} cambiar={v => { setMoneda(v); setFilas(undefined); }} />
        <label>Desde<input type="date" required value={desde} onChange={e => { setDesde(e.target.value); setFilas(undefined); }} /></label>
        <label>Hasta<input type="date" required min={desde} value={hasta} onChange={e => { setHasta(e.target.value); setFilas(undefined); }} /></label>
        <button className="btn primary">Conciliar / consultar informe</button>
      </fieldset>
    </form>
    {filas && <><TablaInforme filas={filas} />
      {exportar && ['xlsx', 'pdf'].map(formato => <button key={formato} className="btn" disabled={op.ocupado} onClick={() => void op.ejecutar(async () => {
        const f = await api.contabilidadExportar(empresa, moneda, desde, hasta, tipo, formato);
        const bytes = Uint8Array.from(atob(f.base64), c => c.charCodeAt(0));
        const url = URL.createObjectURL(new Blob([bytes], { type: f.contentType }));
        const a = document.createElement('a'); a.href = url; a.download = f.nombre; a.click();
        setTimeout(() => URL.revokeObjectURL(url), 1000);
      })}>Exportar {formato.toUpperCase()}</button>)}
    </>}
  </>;
}
export function ClasificacionProductiva({ empresa, catalogos: c, editable }: { empresa: number; catalogos: Catalogos; editable: boolean }) {
  const [config, setConfig] = useState<Clasificacion>();
  const [motivo, setMotivo] = useState('');
  const op = useOperacion();
  return <>{op.avisos}<p>Clasifique cuentas sin inferir su naturaleza por el código. Cada caja/banco debe vincularse a una cuenta propia.</p>
    <button className="btn" disabled={op.ocupado} onClick={() => void op.ejecutar(async () => setConfig(await api.contabilidadClasificacion(empresa)))}>Leer clasificación</button>
    {config && <form onSubmit={e => { e.preventDefault(); void op.ejecutar(async () => {
      if (!await confirmar('¿Guardar clasificación y vínculos de caja? El cambio queda auditado.')) return;
      await api.contabilidadGuardarClasificacion(empresa, config, motivo); op.setMensaje('Clasificación guardada.');
    }); }}><fieldset disabled={op.ocupado || !editable}>
      {config.cuentas.map((x, i) => <div className="account-fields account-rule" key={i}>
        <Select titulo="Cuenta a clasificar" items={c.cuentas} valor={x.cuenta} cambiar={v => setConfig({ ...config, cuentas: config.cuentas.map((a, n) => n === i ? { ...a, cuenta: v } : a) })} />
        <Select titulo="Clase" items={['Activo', 'Pasivo', 'Patrimonio', 'Ingreso', 'Gasto'].map((name, n) => ({ key: n + 1, name }))} valor={x.clase}
          cambiar={v => setConfig({ ...config, cuentas: config.cuentas.map((a, n) => n === i ? { ...a, clase: v } : a) })} />
        <label>Rubro<input required maxLength={100} value={x.rubro} onChange={e => setConfig({ ...config, cuentas: config.cuentas.map((a, n) => n === i ? { ...a, rubro: e.target.value } : a) })} /></label>
        <button type="button" className="btn" onClick={() => setConfig({ ...config, cuentas: config.cuentas.filter((_, n) => n !== i) })}>Quitar cuenta</button>
      </div>)}
      <button type="button" className="btn" onClick={() => setConfig({ ...config, cuentas: [...config.cuentas, { cuenta: 0, clase: 1, rubro: '' }] })}>Agregar clasificación</button>
      {config.cajas.map((x, i) => <div className="account-fields account-rule" key={i}>
        <Select titulo="Caja / banco" items={c.cajas ?? []} valor={x.caja}
          cambiar={v => setConfig({ ...config, cajas: config.cajas.map((a, n) => n === i ? { ...a, caja: v } : a) })} />
        <Select titulo="Cuenta de caja" items={c.cuentas} valor={x.cuenta} cambiar={v => setConfig({ ...config, cajas: config.cajas.map((a, n) => n === i ? { ...a, cuenta: v } : a) })} />
        <button type="button" className="btn" onClick={() => setConfig({ ...config, cajas: config.cajas.filter((_, n) => n !== i) })}>Quitar vínculo</button>
      </div>)}
      <button type="button" className="btn" onClick={() => setConfig({ ...config, cajas: [...config.cajas, { caja: 0, cuenta: 0 }] })}>Vincular caja</button>
      <label>Motivo de clasificación<input required minLength={5} maxLength={500} value={motivo} onChange={e => setMotivo(e.target.value)} /></label>
      <button className="btn primary">Guardar clasificación y cajas</button>
    </fieldset></form>}
  </>;
}
