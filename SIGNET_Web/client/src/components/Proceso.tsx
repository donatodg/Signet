import { FormEvent, useEffect, useState } from 'react';
import { api, ApiError } from '../api';
import { defaults, formatValue } from '../format';
import type { Lookups, Row, ScreenSchema, TablaResultado } from '../types';
import { descargar, escribirVentana, mostrarPdf } from './Acciones';
import { Field } from './Field';

/** Pantalla de proceso: un formulario de datos y un botón que ejecuta el Save del Manager. */
export function Proceso({ schema }: { schema: ScreenSchema }) {
  const [valores, setValores] = useState<Row>(() => defaults(schema.parametros));
  const [lookups, setLookups] = useState<Lookups>({});
  const [error, setError] = useState('');
  const [info, setInfo] = useState('');
  const [ejecutando, setEjecutando] = useState(false);
  const [tablas, setTablas] = useState<TablaResultado[]>([]);

  useEffect(() => {
    setValores(defaults(schema.parametros)); setError(''); setInfo(''); setTablas([]);
    if (schema.lookups.length || schema.parametros.some((f) => f.lookup)) api.lookups(schema.key).then(setLookups).catch(() => undefined);
  }, [schema]);

  const dep = JSON.stringify(schema.parametros.filter((f) => f.lookup).map((f) => valores[f.name]));
  useEffect(() => {
    if (!schema.parametros.some((f) => f.lookup)) return;
    const h = setTimeout(() => {
      api.lookupsDependientes(schema.key, 0, valores).then((r) => setLookups((x) => ({ ...x, ...r.lookups }))).catch(() => undefined);
    }, 400);
    return () => clearTimeout(h);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dep]);

  const ejecutar = async (e: FormEvent) => {
    e.preventDefault();
    setError(''); setInfo(''); setEjecutando(true);
    // Se abre en el mismo gesto del usuario para que el navegador no bloquee la ventana del informe
    const ventana = schema.informe ? window.open('', '_blank') : null;
    ventana?.document.write('<p style="font-family:sans-serif">Generando...</p>');
    try {
      const r = await api.procesar(schema.key, valores);
      if (r.pdf) mostrarPdf(ventana ?? window.open('', '_blank'), r.pdf);
      else if (r.html) escribirVentana(ventana ?? window.open('', '_blank'), r.html); else ventana?.close();
      if (r.archivo) descargar(r.archivo);
      setTablas(r.tablas ?? []);
      if (r.mensaje) setInfo(r.mensaje);
      if (r.navegar) location.hash = `#/${r.navegar}`;
    } catch (err) {
      ventana?.close();
      setError((err as ApiError).message);

    } finally {
      setEjecutando(false);
    }
  };

  return (
    <div className="screen">
      <div className="screen-header">
        <div>
          <span className="muted small">{schema.area}</span>
          <h2>{schema.titulo}</h2>
        </div>
      </div>
      <form className="search-panel" onSubmit={ejecutar}>
        <div className="form-grid cols-4">
          {schema.parametros.map((f) => (
            <Field key={f.name} field={f} value={valores[f.name]} lookups={lookups} esNuevo
              onChange={(v) => setValores((x) => ({ ...x, [f.name]: v }))} />
          ))}
        </div>
        <div className="actions">
          <button type="submit" className="btn primary" disabled={ejecutando}>{ejecutando ? 'Procesando...' : schema.textoBoton ?? 'Ejecutar'}</button>
        </div>
      </form>
      {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
      {schema.descripcion && !info && !error && <p className="muted" style={{ whiteSpace: 'pre-line' }}>{schema.descripcion}</p>}
      {info && <div className="info" style={{ whiteSpace: 'pre-line' }}>{info}</div>}
      <TablasResultado tablas={tablas} />
    </div>
  );
}

/** Tablas devueltas por un proceso o una acción (resultados de controles, validaciones, etc.). */
export function TablasResultado({ tablas }: { tablas: TablaResultado[] }) {
  return (
    <>
      {tablas.map((t, i) => (
        <section key={i} className="tabla-resultado">
          <h3>{t.titulo} <span className="muted small">({t.resumen ?? `${t.filas.length} registro(s)`})</span></h3>
          {t.filas.length > 0 && (
            <div className="grid-wrap">
              <table className="grid">
                <thead><tr>{t.columnas.map((c) => <th key={c.name}>{c.label}</th>)}</tr></thead>
                <tbody>
                  {t.filas.map((r, j) => (
                    <tr key={j}>{t.columnas.map((c) => (
                      <td key={c.name} className={c.type === 'int' || c.type === 'decimal' ? 'num' : undefined}>{formatValue(c, r[c.name])}</td>
                    ))}</tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </section>
      ))}
    </>
  );
}
