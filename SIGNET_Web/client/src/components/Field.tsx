import type { FieldSchema, LookupItem, Lookups, Row } from '../types';
import { fromInputValue, toInputValue } from '../format';

interface Props {
  field: FieldSchema;
  value: unknown;
  lookups?: Lookups;
  onChange: (v: unknown) => void;
  /** En búsquedas nada es obligatorio y los bool admiten "todos" si son anulables. */
  modoBusqueda?: boolean;
  esNuevo?: boolean;
  disabled?: boolean;
  values?: Row;
}

export function Field({ field: f, value, lookups, onChange, modoBusqueda, esNuevo, disabled, values }: Props) {
  const id = `f_${f.name}`;
  const required = !modoBusqueda && f.required && !(f.sensitive && !esNuevo);
  const options: LookupItem[] | undefined = f.options ?? (f.lookup ? lookups?.[f.lookup] : undefined);
  if (f.visibleWhen && !Boolean(values?.[f.visibleWhen])) return null;

  let input: JSX.Element;
  if (f.type === 'bool' && !(modoBusqueda && f.nullable)) {
    return (
      <label className="field field-check" htmlFor={id}>
        <input id={id} type="checkbox" checked={Boolean(value)} disabled={disabled}
          onChange={(e) => onChange(e.target.checked)} />
        <span>{f.label}</span>
      </label>
    );
  } else if (f.type === 'bool') {
    input = (
      <select id={id} value={value === null || value === undefined ? '' : String(value)} disabled={disabled}
        onChange={(e) => onChange(e.target.value === '' ? null : e.target.value === 'true')}>
        <option value="">(Todos)</option>
        <option value="true">Sí</option>
        <option value="false">No</option>
      </select>
    );
  } else if (f.type === 'multi') {
    const sel = Array.isArray(value) ? (value as unknown[]).map(String) : [];
    input = (
      <select id={id} multiple size={Math.min(8, Math.max(3, options?.length ?? 3))} value={sel} required={required} disabled={disabled}
        onChange={(e) => onChange(Array.from(e.target.selectedOptions).map((o) => Number(o.value)))}>
        {(options ?? []).map((o) => (
          <option key={String(o.key)} value={String(o.key)}>{o.name}</option>
        ))}
      </select>
    );
  } else if (f.type === 'file') {
    input = (
      <input id={id} type="file" required={required} disabled={disabled} accept=".xlsx,.xls"
        onChange={(e) => {
          const file = e.target.files?.[0];
          if (!file) { onChange(null); return; }
          const reader = new FileReader();
          reader.onload = () => onChange({ nombre: file.name, base64: String(reader.result).split(',')[1] ?? '' });
          reader.readAsDataURL(file);
        }} />
    );
  } else if (options) {
    input = (
      <select id={id} value={toInputValue(f, value)} required={required} disabled={disabled}
        onChange={(e) => onChange(fromInputValue(f, e.target.value))}>
        <option value="">{modoBusqueda ? '(Todos)' : '(Seleccione)'}</option>
        {options.map((o) => (
          <option key={String(o.key)} value={String(o.key)}>{o.name}</option>
        ))}
      </select>
    );
  } else {
    const type = f.sensitive ? 'password'
      : f.type === 'date' ? 'date'
      : f.type === 'int' || f.type === 'decimal' ? 'number'
      : 'text';
    input = (
      <input id={id} type={type} value={toInputValue(f, value)} required={required} disabled={disabled}
        maxLength={f.maxLength} step={f.type === 'decimal' ? 'any' : undefined}
        autoComplete={f.sensitive ? 'new-password' : 'off'}
        placeholder={f.sensitive && !esNuevo ? '(sin cambios)' : undefined}
        onChange={(e) => onChange(fromInputValue(f, e.target.value))} />
    );
  }

  return (
    <div className="field">
      <label htmlFor={id}>{f.label}{required && <span className="req">*</span>}</label>
      {input}
    </div>
  );
}
