import { FormEvent, useEffect, useRef, useState } from 'react';
import { api, ApiError } from '../api';
import { defaults, formatValue } from '../format';
import type { AccionResultado, AccionSchema, FieldSchema, Lookups, Row, ScreenSchema } from '../types';
import { Field } from './Field';
import { Modal } from './Modal';
import { avisar } from './Dialogos';

const esc = (s: string) => s.replace(/[&<>"']/g, (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[c]!));

/** Vista imprimible de la grilla (equivalente web de gridControl.ShowRibbonPrintPreview). */
export function htmlGrilla(schema: ScreenSchema, columnas: FieldSchema[], filas: Row[], parametros: Row, lookups: Lookups, horizontal: boolean): string {
  const filtros = schema.parametros
    .map((p) => ({ p, v: formatValue(p, parametros[p.name], lookups) }))
    .filter((x) => x.v !== '' && !(x.p.type === 'bool' && parametros[x.p.name] === false))
    .map((x) => `<span><b>${esc(x.p.label)}:</b> ${esc(x.v)}</span>`).join('');
  const num = (c: FieldSchema) => c.type === 'int' || c.type === 'decimal';
  const head = columnas.map((c) => `<th${num(c) ? ' class="n"' : ''}>${esc(c.label)}</th>`).join('');
  const body = filas.map((r) => `<tr>${columnas.map((c) => `<td${num(c) ? ' class="n"' : ''}>${esc(formatValue(c, r[c.name], lookups))}</td>`).join('')}</tr>`).join('');
  return `<!DOCTYPE html><html lang="es"><head><meta charset="utf-8"><title>${esc(schema.titulo)}</title><style>
@page{size:A4 ${horizontal ? 'landscape' : 'portrait'};margin:10mm}
body{font-family:Segoe UI,Arial,sans-serif;font-size:10px;margin:0;padding:12px;color:#000}
h1{font-size:16px;margin:0 0 2px}.sub{color:#444;margin-bottom:6px}.filtros{display:flex;flex-wrap:wrap;gap:4px 14px;margin-bottom:6px}
table{border-collapse:collapse;width:100%}th,td{border:1px solid #999;padding:2px 4px;text-align:left}th{background:#eee}
thead{display:table-header-group}.n{text-align:right;white-space:nowrap}.no-print{margin-bottom:10px}
@media print{.no-print{display:none}body{padding:0}}</style></head><body>
<div class="no-print"><button onclick="window.print()">Imprimir</button></div>
<h1>${esc(schema.titulo)}</h1><div class="sub">${esc(schema.area)} — ${filas.length} registro(s) — ${esc(new Date().toLocaleString('es-AR'))}</div>
<div class="filtros">${filtros}</div>
<table><thead><tr>${head}</tr></thead><tbody>${body}</tbody></table>
<script>window.addEventListener('load',function(){setTimeout(function(){window.print()},300)})</script></body></html>`;
}

export function escribirVentana(w: Window | null, html: string) {
  if (!w) {
    void avisar('El navegador bloqueó la ventana de impresión. Habilite las ventanas emergentes para este sitio.', 'Impresión');
    return;
  }
  w.document.open();
  w.document.write(html);
  w.document.close();
  w.focus();
}

export function descargar(archivo: NonNullable<AccionResultado['archivo']>) {
  const bin = atob(archivo.base64);
  const bytes = new Uint8Array(bin.length);
  for (let i = 0; i < bin.length; i++) bytes[i] = bin.charCodeAt(i);
  const a = document.createElement('a');
  a.href = URL.createObjectURL(new Blob([bytes], { type: archivo.contentType }));
  a.download = archivo.nombre;
  a.click();
  setTimeout(() => URL.revokeObjectURL(a.href), 1000);
}

export function mostrarPdf(w: Window | null, archivo: NonNullable<AccionResultado['pdf']>) {
  if (!w) {
    void avisar('El navegador bloqueó la vista previa. Habilite las ventanas emergentes para imprimir el PDF.', 'Impresión');
    return;
  }
  const bin = atob(archivo.base64);
  const bytes = Uint8Array.from(bin, (c) => c.charCodeAt(0));
  const url = URL.createObjectURL(new Blob([bytes], { type: 'application/pdf' }));
  w.location.replace(url);
  // Mantener el recurso mientras el visor nativo lo usa para imprimir o descargar.
  const h = window.setInterval(() => {
    if (w.closed) { URL.revokeObjectURL(url); window.clearInterval(h); }
  }, 1000);
}

interface MenuProps {
  titulo: string;
  acciones: AccionSchema[];
  habilitada: (a: AccionSchema) => boolean;
  onSelect: (a: AccionSchema) => void;
}

/** Menú desplegable "Imprimir" / "Operaciones" de la barra de la pantalla. */
export function MenuAcciones({ titulo, acciones, habilitada, onSelect }: MenuProps) {
  const [abierto, setAbierto] = useState(false);
  const ref = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (!abierto) return;
    const h = (e: MouseEvent) => ref.current && !ref.current.contains(e.target as Node) && setAbierto(false);
    const k = (e: KeyboardEvent) => e.key === 'Escape' && setAbierto(false);
    document.addEventListener('mousedown', h);
    document.addEventListener('keydown', k);
    return () => { document.removeEventListener('mousedown', h); document.removeEventListener('keydown', k); };
  }, [abierto]);

  if (!acciones.length) return null;
  return (
    <div className="dropdown" ref={ref}>
      <button className="btn" aria-haspopup="menu" aria-expanded={abierto} onClick={() => setAbierto((v) => !v)}>{titulo} ▾</button>
      {abierto && (
        <div className="dropdown-menu menu-acciones" role="menu">
          {acciones.map((a) => {
            const ok = habilitada(a);
            return (
              <div key={a.key}>
                {a.separador && <hr />}
                <button role="menuitem" className="menu-item" disabled={!ok}
                  title={(ok ? undefined : a.seleccion === 'Varias' ? 'Seleccione uno o más registros' : 'Seleccione un registro')}
                  onClick={() => { setAbierto(false); if (a.soloEscritorio) void avisar(`${a.titulo}: ${a.soloEscritorio}`, a.titulo); else onSelect(a); }}>
                  {a.titulo}
                </button>
              </div>
            );
          })}
        </div>
      )}
    </div>
  );
}

interface DialogProps {
  schema: ScreenSchema;
  accion: AccionSchema;
  ids: number[];
  onClose: () => void;
  onEjecutar: (valores: Row) => Promise<void>;
}

/** Diálogo de datos de la operación (ej. "Motivo Anulación") y/o confirmación Sí/No. */
export function DialogoAccion({ schema, accion, ids, onClose, onEjecutar }: DialogProps) {
  const [campos, setCampos] = useState<FieldSchema[] | undefined>(accion.tieneCamposDinamicos ? undefined : accion.campos);
  const [valores, setValores] = useState<Row>(defaults(accion.campos));
  const [error, setError] = useState('');
  const [ejecutando, setEjecutando] = useState(false);

  useEffect(() => {
    if (!accion.tieneCamposDinamicos) return;
    let vivo = true;
    api.camposAccion(schema.key, accion.key, ids)
      .then((c) => { if (vivo) { setCampos(c); setValores(defaults(c)); } })
      .catch((e: ApiError) => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [schema.key, accion, ids]);

  const submit = async (e: FormEvent) => {
    e.preventDefault();
    setError(''); setEjecutando(true);
    try {
      await onEjecutar(valores);
    } catch (err) {
      setError((err as ApiError).message);
    } finally {
      setEjecutando(false);
    }
  };

  return (
    <Modal titulo={accion.titulo} onClose={onClose}
      footer={<>
        <button className="btn" type="button" onClick={onClose}>{campos?.length ? 'Cancelar' : 'No'}</button>
        <button className="btn primary" type="submit" form="form-accion" disabled={ejecutando || !campos}>
          {ejecutando ? 'Procesando...' : campos?.length ? 'Aceptar' : 'Sí'}
        </button>
      </>}>
      <form id="form-accion" onSubmit={submit}>
        {accion.confirmacion && <p className="confirmacion">{accion.confirmacion}</p>}
        {ids.length > 1 && <p className="muted small">{ids.length} registros seleccionados.</p>}
        {!campos && !error && <p className="muted">Cargando...</p>}
        {campos && campos.length > 0 && (
          <div className="form-grid">
            {campos.map((f) => (
              <Field key={f.name} field={f} value={valores[f.name]} esNuevo
                onChange={(v) => setValores((x) => ({ ...x, [f.name]: v }))} />
            ))}
          </div>
        )}
        {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
      </form>
    </Modal>
  );
}
