import { useState } from 'react';
import { api, ApiError } from '../api';
import { defaults, formatValue } from '../format';
import type { ColeccionSchema, Lookups, Row, ScreenSchema } from '../types';
import { Field } from './Field';
import { Modal } from './Modal';

interface Props {
  schema: ScreenSchema;
  coleccion: ColeccionSchema;
  filas: Row[];
  cabecera: Row;
  lookups: Lookups;
  disabled: boolean;
  onChange: (filas: Row[]) => void;
}

const redondear = (n: number) => Math.round((n + Number.EPSILON) * 100) / 100;
const num = (v: unknown) => (typeof v === 'number' ? v : Number(v) || 0);

/** Recalcula en el cliente los importes del renglón (misma fórmula que los Managers de escritorio). */
function recalcular(c: ColeccionSchema, fila: Row, lookups: Lookups): Row {
  const f = { ...fila };
  const tiene = (n: string) => c.campos.some((x) => x.name === n);
  const campoAlicuota = c.campos.find((x) => x.name === 'Id_AlicuotaIva');
  if (campoAlicuota?.lookup && tiene('AlicuotaIva') && f.Id_AlicuotaIva) {
    const op = lookups[campoAlicuota.lookup]?.find((o) => o.key === f.Id_AlicuotaIva);
    const m = op && /(-?\d+(?:[.,]\d+)?)/.exec(op.name.replace(',', '.'));
    if (m) f.AlicuotaIva = Number(m[1]);
  }
  if (tiene('ImporteUnitario') && tiene('Cantidad') && tiene('Importe')) {
    const desc = tiene('PorcDescuento') ? num(f.PorcDescuento) : 0;
    const neto = num(f.ImporteUnitario) - (num(f.ImporteUnitario) * desc) / 100;
    const iva = tiene('AlicuotaIva') ? redondear((neto * num(f.AlicuotaIva)) / 100 * num(f.Cantidad)) : 0;
    if (tiene('ImporteIVA')) f.ImporteIVA = iva;
    f.Importe = redondear(neto * num(f.Cantidad) + iva);
  } else if (tiene('Alicuota') && tiene('BaseImponible') && tiene('Importe')) {
    f.Importe = redondear((num(f.BaseImponible) * num(f.Alicuota)) / 100);
  }
  return f;
}

export function DetalleEditor({ schema, coleccion: c, filas, cabecera, lookups, disabled, onChange }: Props) {
  const [edit, setEdit] = useState<{ indice: number; fila: Row } | null>(null);
  const [error, setError] = useState('');
  const claveColumnas = `signet.detalle.columnas.${schema.key}.${c.name}`;
  const [mostrarColumnas, setMostrarColumnas] = useState(false);
  const [config, setConfig] = useState(() => {
    try {
      const saved = JSON.parse(localStorage.getItem(claveColumnas) || '{}') as { orden?: string[]; visibles?: string[] };
      const disponibles = c.campos.filter((f) => !f.hidden).map((f) => f.name);
      return {
        orden: [...(saved.orden ?? []).filter((n) => disponibles.includes(n)), ...disponibles.filter((n) => !(saved.orden ?? []).includes(n))],
        visibles: new Set((saved.visibles ?? disponibles).filter((n) => disponibles.includes(n)))
      };
    } catch {
      const disponibles = c.campos.filter((f) => !f.hidden).map((f) => f.name);
      return { orden: disponibles, visibles: new Set(disponibles) };
    }
  });
  const columnas = config.orden
    .map((n) => c.campos.find((f) => f.name === n))
    .filter((f): f is (typeof c.campos)[number] => Boolean(f && !f.hidden && config.visibles.has(f.name)));

  const guardarConfig = (orden: string[], visibles: Set<string>) => {
    setConfig({ orden, visibles });
    localStorage.setItem(claveColumnas, JSON.stringify({ orden, visibles: [...visibles] }));
  };
  const moverColumna = (name: string, delta: number) => {
    const orden = [...config.orden];
    const i = orden.indexOf(name), j = i + delta;
    if (j < 0 || j >= orden.length) return;
    [orden[i], orden[j]] = [orden[j], orden[i]];
    guardarConfig(orden, config.visibles);
  };
  const totalizables = columnas.filter((f) => (f.type === 'decimal' || f.type === 'int') && /importe|cantidad|stock/i.test(f.name));

  const nuevaFila = async () => {
    setError('');
    let fila: Row = { Id: 0, ...defaults(c.campos) };
    for (const f of c.campos) {
      if (f.lookup && f.required && fila[f.name] == null) {
        const op = lookups[f.lookup]?.[0];
        if (op) fila[f.name] = op.key;
      }
    }
    try {
      fila = { ...fila, ...(await api.autocompletarRenglon(schema.key, c.name, fila, null, cabecera)) };
    } catch (e) {
      setError((e as ApiError).message);
    }
    setEdit({ indice: -1, fila: recalcular(c, fila, lookups) });
  };

  const cambiar = async (campo: string, valor: unknown) => {
    if (!edit) return;
    let fila = { ...edit.fila, [campo]: valor };
    setEdit({ ...edit, fila });
    if (campo.startsWith('Id_')) {
      try {
        fila = { ...fila, ...(await api.autocompletarRenglon(schema.key, c.name, fila, campo, cabecera)) };
      } catch (e) {
        setError((e as ApiError).message);
      }
    }
    setEdit((x) => (x ? { ...x, fila: recalcular(c, fila, lookups) } : x));
  };

  const aceptar = () => {
    if (!edit) return;
    const faltan = c.campos.filter((f) => f.required && f.type !== 'bool' && (edit.fila[f.name] == null || edit.fila[f.name] === ''));
    if (faltan.length) {
      setError(`Complete: ${faltan.map((f) => f.label).join(', ')}`);
      return;
    }
    const nuevas = [...filas];
    if (edit.indice < 0) nuevas.push(edit.fila);
    else nuevas[edit.indice] = edit.fila;
    onChange(nuevas);
    setError('');
    setEdit(null);
  };

  return (
    <fieldset className="opciones detalle">
      <legend>{c.label}</legend>
      <div className="actions">
        <div className="dropdown">
          <button type="button" className="btn small" onClick={() => setMostrarColumnas((v) => !v)}>Columnas ▾</button>
          {mostrarColumnas && (
            <div className="dropdown-menu">
              {config.orden.map((name, i) => {
                const f = c.campos.find((x) => x.name === name);
                if (!f || f.hidden) return null;
                return <div key={name} className="col-item">
                  <label><input type="checkbox" checked={config.visibles.has(name)} onChange={() => {
                    const visibles = new Set(config.visibles);
                    visibles.has(name) ? visibles.delete(name) : visibles.add(name);
                    guardarConfig(config.orden, visibles);
                  }} /> {f.label}</label>
                  <button type="button" className="col-mover" title="Subir" disabled={i === 0} onClick={() => moverColumna(name, -1)}>▲</button>
                  <button type="button" className="col-mover" title="Bajar" disabled={i === config.orden.length - 1} onClick={() => moverColumna(name, 1)}>▼</button>
                </div>;
              })}
            </div>
          )}
        </div>
      </div>
      <div className="table-wrap">
        <table className="grid">
          <thead>
            <tr>
              {columnas.map((f) => <th key={f.name}>{f.label}</th>)}
              <th />
            </tr>
          </thead>
          <tbody>
            {filas.map((r, i) => (
              <tr key={i}>
                {columnas.map((f) => <td key={f.name} className={f.type === 'decimal' || f.type === 'int' ? 'num' : ''}>{formatValue(f, r[f.name], lookups)}</td>)}
                <td className="acciones-fila">
                  <button type="button" className="btn small" onClick={() => setEdit({ indice: i, fila: r })}>{disabled ? 'Ver' : 'Editar'}</button>
                  {!disabled && (c.puedeQuitar || r.Id === 0 || r.Id == null) && (
                    <button type="button" className="btn small" onClick={() => onChange(filas.filter((_, k) => k !== i))}>Quitar</button>
                  )}
                </td>
              </tr>
            ))}
            {filas.length === 0 && <tr><td colSpan={columnas.length + 1} className="muted">Sin renglones</td></tr>}
          </tbody>
          {totalizables.length > 0 && <tfoot>
            <tr>
              {columnas.map((f) => <td key={f.name} className={f.type === 'decimal' || f.type === 'int' ? 'num' : ''}>
                {totalizables.some((t) => t.name === f.name)
                  ? filas.reduce((s, r) => s + num(r[f.name]), 0).toLocaleString('es-AR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })
                  : ''}
              </td>)}
              <td />
            </tr>
          </tfoot>}
        </table>
      </div>
      <div className="actions">
        {totalizables.length > 0 && <span className="muted">Totales por columna</span>}
        {!disabled && <button type="button" className="btn" onClick={nuevaFila}>+ Agregar</button>}
      </div>
      {error && !edit && <div className="alert">{error}</div>}
      {edit && (
        <Modal titulo={`${c.label} - ${edit.indice < 0 ? 'Nuevo' : 'Renglón'}`} onClose={() => setEdit(null)} ancho="grande">
          <div onKeyDown={(e) => { if (e.key === 'Enter' && (e.target as HTMLElement).tagName !== 'TEXTAREA') { e.preventDefault(); } }}>
            <div className="form-grid cols-3">
              {c.campos.filter((f) => !f.hidden).map((f) => (
                <Field key={f.name} field={f} value={edit.fila[f.name]} lookups={lookups} esNuevo disabled={disabled}
                  values={edit.fila}
                  onChange={(v) => cambiar(f.name, v)} />
              ))}
            </div>
            {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
            <div className="actions">
              <button type="button" className="btn" onClick={() => setEdit(null)}>Cancelar</button>
              {!disabled && <button type="button" className="btn primary" onClick={aceptar}>Aceptar</button>}
            </div>
          </div>
        </Modal>
      )}
    </fieldset>
  );
}
