import { FormEvent, KeyboardEvent, ReactNode, useEffect, useRef, useState } from 'react';
import { api, ApiError } from '../api';
import type { AltaPrecargada, ChatEstado, ChatMensaje, ChatResultado, ChatVenta, ScreenSchema } from '../types';
import { EditDialog } from './EditDialog';

interface Entrada extends ChatMensaje {
  resultado?: ChatResultado | null;
  consultas?: string[];
  error?: boolean;
  venta?: ChatVenta | null;
}

const SUGERENCIAS = [
  'Dame los 5 productos más vendidos el último mes',
  'Los 10 clientes que más compraron este año',
  'Ventas totales por mes de este año',
  '¿Cuántas facturas se emitieron esta semana?',
];

const num = new Intl.NumberFormat('es-AR', { maximumFractionDigits: 2 });
const fechaIso = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/;

function celda(v: unknown): string {
  if (v === null || v === undefined) return '';
  if (typeof v === 'number') return num.format(v);
  if (typeof v === 'boolean') return v ? 'Sí' : 'No';
  if (typeof v === 'string' && fechaIso.test(v)) {
    const d = new Date(v);
    return v.endsWith('T00:00:00') ? d.toLocaleDateString('es-AR') : d.toLocaleString('es-AR');
  }
  return String(v);
}

/** Markdown mínimo: **negrita**, viñetas "- " y saltos de línea (sin HTML). */
function Texto({ texto }: { texto: string }) {
  const negrita = (s: string) => s.split(/(\*\*[^*]+\*\*)/g).map((p, i) =>
    p.startsWith('**') && p.endsWith('**') ? <strong key={i}>{p.slice(2, -2)}</strong> : p);
  const bloques: ReactNode[] = [];
  let lista: ReactNode[] = [];
  const cerrarLista = () => { if (lista.length) { bloques.push(<ul key={bloques.length}>{lista}</ul>); lista = []; } };
  texto.split('\n').forEach((linea, i) => {
    const m = /^\s*(?:[-*•]|\d+\.)\s+(.*)$/.exec(linea);
    if (m) { lista.push(<li key={i}>{negrita(m[1])}</li>); return; }
    cerrarLista();
    if (linea.trim()) bloques.push(<p key={`p${i}`}>{negrita(linea.replace(/^#+\s*/, ''))}</p>);
  });
  cerrarLista();
  return <>{bloques}</>;
}

function csv(r: ChatResultado) {
  const esc = (v: unknown) => { const s = celda(v); return /[;"\n]/.test(s) ? `"${s.replace(/"/g, '""')}"` : s; };
  const contenido = [r.columnas.map(esc).join(';'), ...r.filas.map((f) => f.map(esc).join(';'))].join('\r\n');
  const url = URL.createObjectURL(new Blob(['\ufeff' + contenido], { type: 'text/csv;charset=utf-8' }));
  const a = document.createElement('a');
  a.href = url;
  a.download = 'consulta.csv';
  a.click();
  URL.revokeObjectURL(url);
}

function Resultado({ r, consultas }: { r?: ChatResultado | null; consultas?: string[] }) {
  if (!r && !consultas?.length) return null;
  return (
    <div className="chat-resultado">
      {r && r.columnas.length > 0 && (
        <>
          <div className="chat-tabla">
            <table>
              <thead><tr>{r.columnas.map((c, i) => <th key={i}>{c}</th>)}</tr></thead>
              <tbody>
                {r.filas.map((f, i) => (
                  <tr key={i}>{f.map((v, j) => <td key={j} className={typeof v === 'number' ? 'num' : ''}>{celda(v)}</td>)}</tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="chat-resultado-pie">
            <span className="muted small">{r.filas.length}{r.truncado ? '+' : ''} fila{r.filas.length === 1 ? '' : 's'}</span>
            <button className="btn small" onClick={() => csv(r)}>Descargar CSV</button>
          </div>
        </>
      )}
      {!!consultas?.length && (
        <details className="chat-sql">
          <summary>Ver consulta{consultas.length > 1 ? 's' : ''} SQL ({consultas.length})</summary>
          {consultas.map((s, i) => <pre key={i}>{s}</pre>)}
        </details>
      )}
    </div>
  );
}

export function Chat({ onClose }: { onClose: () => void }) {
  const [estado, setEstado] = useState<ChatEstado>();
  const [mensajes, setMensajes] = useState<Entrada[]>([]);
  const [texto, setTexto] = useState('');
  const [pensando, setPensando] = useState(false);
  const [venta, setVenta] = useState<ChatVenta>();
  const [formulario, setFormulario] = useState<{ schema: ScreenSchema; alta: AltaPrecargada }>();
  const [abriendo, setAbriendo] = useState(false);
  const [ventaVigente, setVentaVigente] = useState(false);
  const fin = useRef<HTMLDivElement>(null);
  const entrada = useRef<HTMLTextAreaElement>(null);

  useEffect(() => { api.chatEstado().then(setEstado).catch(() => undefined); }, []);
  useEffect(() => { fin.current?.scrollIntoView({ behavior: 'smooth' }); }, [mensajes, pensando]);
  useEffect(() => { entrada.current?.focus(); }, []);

  const enviar = async (pregunta: string) => {
    pregunta = pregunta.trim();
    if (!pregunta || pensando || abriendo || formulario) return;
    const historial = mensajes.filter((m) => !m.error).map(({ rol, texto }) => ({ rol, texto }));
    setMensajes((m) => [...m, { rol: 'usuario', texto: pregunta }]);
    setTexto('');
    setPensando(true);
    setVentaVigente(false);
    try {
      const r = await api.chatPreguntar(pregunta, historial, venta?.solicitud);
      setMensajes((m) => [...m, { rol: 'asistente', texto: r.respuesta, resultado: r.resultado, consultas: r.consultas, venta: r.venta }]);
      if (r.venta) { setVenta(r.venta); setVentaVigente(true); }
      setEstado((e) => e && { ...e, tokensMes: r.tokensMes, limiteMes: r.limiteMes });
    } catch (err) {
      setMensajes((m) => [...m, { rol: 'asistente', texto: (err as ApiError).message, error: true }]);
    } finally {
      setPensando(false);
      entrada.current?.focus();
    }
  };

  const abrirVenta = async (borrador: ChatVenta) => {
    if (abriendo || pensando || formulario || !ventaVigente) return;
    setAbriendo(true);
    try {
      const [schema, alta] = await Promise.all([api.schema('ComprobantesVentas'), api.chatAbrirVenta(borrador.solicitud)]);
      if (!schema.permisos.agregar) throw new ApiError(403, 'No tiene permiso para agregar ventas.');
      setFormulario({ schema, alta });
    } catch (e) {
      setMensajes((m) => [...m, { rol: 'asistente', texto: (e as ApiError).message, error: true }]);
    } finally { setAbriendo(false); }
  };

  const submit = (e: FormEvent) => { e.preventDefault(); void enviar(texto); };
  const teclas = (e: KeyboardEvent<HTMLTextAreaElement>) => {
    if (e.key === 'Enter' && !e.shiftKey) { e.preventDefault(); void enviar(texto); }
    if (e.key === 'Escape') onClose();
  };

  const sinConfigurar = estado && !estado.configurado;

  return (
    <aside className="chat-panel" aria-label="Asistente de datos">
      <header>
        <strong>✨ Asistente de datos</strong>
        <span className="spacer" />
        {mensajes.length > 0 && <button className="btn small" onClick={() => { setMensajes([]); setVenta(undefined); setVentaVigente(false); }}
          disabled={pensando || abriendo || !!formulario}>Nueva</button>}
        <button className="btn icon" onClick={onClose} title="Cerrar" aria-label="Cerrar">✕</button>
      </header>

      <div className="chat-mensajes">
        {mensajes.length === 0 && (
          <div className="chat-bienvenida">
            <p>Consultá datos o pedime preparar una venta indicando cliente, productos y cantidades. Abrís el formulario para revisarla y guardarla manualmente; el chat no factura ni cobra.</p>
            {sinConfigurar
              ? <div className="alert">Falta configurar la clave del asistente: cargue el parámetro del sistema IA_ApiKey (Configuración › Parámetros).</div>
              : <div className="chat-sugerencias">{SUGERENCIAS.map((s) => <button key={s} className="btn small" onClick={() => void enviar(s)}>{s}</button>)}</div>}
          </div>
        )}
        {mensajes.map((m, i) => (
          <div key={i} className={`chat-msg ${m.rol}${m.error ? ' error' : ''}`}>
            <div className="chat-burbuja">
              {m.rol === 'asistente' ? <Texto texto={m.texto} /> : m.texto}
              {m.rol === 'asistente' && <Resultado r={m.resultado} consultas={m.consultas} />}
              {m.venta && <div className="chat-resultado">
                <strong>Venta sin guardar: {m.venta.cliente}</strong>
                <p>{m.venta.sucursal} · {m.venta.tipoComprobante} · {m.venta.formaPago}</p>
                <div className="chat-tabla"><table>
                  <thead><tr><th>Producto</th><th>Cantidad</th><th>Precio</th><th>Desc. %</th><th>IVA</th><th>Total</th></tr></thead>
                  <tbody>{m.venta.lineas.map((l, j) => <tr key={j}>
                    <td>{l.producto} ({l.moneda})</td><td>{num.format(l.cantidad)}</td><td>{num.format(l.precioUnitario)}</td>
                    <td>{num.format(l.descuento)}</td><td>{num.format(l.iva)}</td><td>{num.format(l.total)}</td>
                  </tr>)}</tbody>
                </table></div>
                <p><strong>Total en pesos: {num.format(m.venta.total)}</strong></p>
                {m.venta.advertencias.map((a, j) => <p key={j} className="muted small">{a}</p>)}
                <button type="button" className="btn primary" disabled={pensando || abriendo || !!formulario || venta !== m.venta || !ventaVigente}
                  onClick={() => void abrirVenta(m.venta!)}>Revisar en formulario (sin guardar)</button>
                <p className="muted small">Precios y permisos se vuelven a consultar al abrir. Revisá el total actualizado antes de guardar.</p>
              </div>}
            </div>
          </div>
        ))}
        {pensando && <div className="chat-msg asistente"><div className="chat-burbuja chat-pensando">Consultando la base<span>.</span><span>.</span><span>.</span></div></div>}
        <div ref={fin} />
      </div>

      <form className="chat-entrada" onSubmit={submit}>
        <textarea ref={entrada} rows={2} value={texto} maxLength={2000} placeholder="Escribí tu pregunta… (Enter envía, Shift+Enter nueva línea)"
          onChange={(e) => setTexto(e.target.value)} onKeyDown={teclas} disabled={pensando || abriendo || !!formulario || sinConfigurar} />
        <button className="btn primary" type="submit" disabled={pensando || abriendo || !!formulario || !texto.trim() || sinConfigurar} aria-label="Enviar">➤</button>
      </form>
      {estado && estado.limiteMes > 0 && (
        <div className="chat-uso muted small" title={`Modelo: ${estado.modelo}`}>
          Uso del mes: {num.format(estado.tokensMes)} / {num.format(estado.limiteMes)} tokens
          <progress value={Math.min(estado.tokensMes, estado.limiteMes)} max={estado.limiteMes} />
        </div>
      )}
      {formulario && <EditDialog schema={formulario.schema} id={0} inicial={{ valores: formulario.alta.valores, detalles: formulario.alta.detalles }}
        onClose={() => setFormulario(undefined)} onSaved={() => {
          setFormulario(undefined); setVenta(undefined); setVentaVigente(false);
          setMensajes((m) => [...m, { rol: 'asistente', texto: 'Venta guardada desde el formulario. No se emitió en AFIP ni se realizó un cobro desde el chat.' }]);
        }} />}
    </aside>
  );
}
