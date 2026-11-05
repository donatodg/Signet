import type { FieldSchema, LookupItem, Lookups, Row } from './types';

export function formatValue(f: FieldSchema, v: unknown, lookups?: Lookups): string {
  if (v === null || v === undefined || v === '') return '';
  if (f.type === 'bool') return v ? 'Sí' : 'No';
  if (f.type === 'date') {
    const s = String(v);
    const m = /^(\d{4})-(\d{2})-(\d{2})(?:T(\d{2}):(\d{2}))?/.exec(s);
    if (!m) return s;
    const fecha = `${m[3]}/${m[2]}/${m[1]}`;
    return m[4] && (m[4] !== '00' || m[5] !== '00') ? `${fecha} ${m[4]}:${m[5]}` : fecha;
  }
  const opts: LookupItem[] | undefined = f.options ?? (f.lookup ? lookups?.[f.lookup] : undefined);
  if (opts) {
    const o = opts.find((x) => String(x.key) === String(v));
    if (o) return o.name;
  }
  if (f.type === 'decimal' && typeof v === 'number') return v.toLocaleString('es-AR', { maximumFractionDigits: 4 });
  return String(v);
}

/** Valor de un campo en formato apto para <input>. */
export function toInputValue(f: FieldSchema, v: unknown): string {
  if (v === null || v === undefined) return '';
  if (f.type === 'date') return String(v).substring(0, 10);
  return String(v);
}

/** Convierte el valor del input al tipo esperado por la API. */
export function fromInputValue(f: FieldSchema, raw: string | boolean): unknown {
  if (f.type === 'bool') return Boolean(raw);
  const s = String(raw);
  if (s === '') return f.type === 'string' && !f.nullable ? '' : null;
  if (f.type === 'int' || f.type === 'enum') return Number.parseInt(s, 10);
  if (f.type === 'decimal') return Number.parseFloat(s.replace(',', '.'));
  return s;
}

export function defaults(fields: FieldSchema[]): Row {
  const r: Row = {};
  for (const f of fields) r[f.name] = f.default ?? (f.type === 'bool' && !f.nullable ? false : null);
  return r;
}

export function compare(a: unknown, b: unknown): number {
  if (a === b) return 0;
  if (a === null || a === undefined || a === '') return -1;
  if (b === null || b === undefined || b === '') return 1;
  if (typeof a === 'number' && typeof b === 'number') return a - b;
  return String(a).localeCompare(String(b), 'es', { numeric: true, sensitivity: 'base' });
}

export function toCsv(cols: FieldSchema[], rows: Row[], lookups?: Lookups): string {
  const esc = (s: string) => (/[";\n]/.test(s) ? `"${s.replace(/"/g, '""')}"` : s);
  const lines = [cols.map((c) => esc(c.label)).join(';')];
  for (const r of rows) lines.push(cols.map((c) => esc(formatValue(c, r[c.name], lookups))).join(';'));
  return '\uFEFF' + lines.join('\r\n');
}

/** Excel 2003 SpreadsheetML; keeps the export dependency-free and preserves numeric cells. */
export function toExcelXml(cols: FieldSchema[], rows: Row[], lookups?: Lookups): string {
  const esc = (s: string) => s.replace(/[\u0000-\u0008\u000B\u000C\u000E-\u001F\uFFFE\uFFFF]/g, '')
    .replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
  const cell = (f: FieldSchema, row: Row, header = false) => {
    if (header) return `<Cell ss:StyleID="Header"><Data ss:Type="String">${esc(f.label)}</Data></Cell>`;
    const value = row[f.name];
    if (value === null || value === undefined || value === '') return '<Cell/>';
    if ((f.type === 'int' || f.type === 'decimal') && typeof value === 'number' && Number.isFinite(value))
      return `<Cell><Data ss:Type="Number">${value}</Data></Cell>`;
    return `<Cell><Data ss:Type="String">${esc(formatValue(f, value, lookups))}</Data></Cell>`;
  };
  const header = `<Row>${cols.map((c) => cell(c, {}, true)).join('')}</Row>`;
  const body = rows.map((r) => `<Row>${cols.map((c) => cell(c, r)).join('')}</Row>`).join('');
  return `<?xml version="1.0" encoding="UTF-8"?>
<?mso-application progid="Excel.Sheet"?>
<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet" xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
<Styles><Style ss:ID="Header"><Font ss:Bold="1"/><Interior ss:Color="#D9EAF7" ss:Pattern="Solid"/></Style></Styles>
<Worksheet ss:Name="Datos"><Table>${header}${body}</Table></Worksheet></Workbook>`;
}
