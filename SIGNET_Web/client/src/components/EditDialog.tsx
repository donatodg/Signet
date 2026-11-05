import { FormEvent, useEffect, useRef, useState } from 'react';
import { api, ApiError } from '../api';
import { defaults } from '../format';
import type { FieldSchema, Lookups, Row, ScreenSchema } from '../types';
import { DetalleEditor } from './DetalleEditor';
import { Field } from './Field';
import { Modal } from './Modal';

interface Props {
  schema: ScreenSchema;
  id: number;
  onClose: () => void;
  onSaved: () => void;
  /** Valores y detalles precargados para un alta (por ejemplo, generada desde una acción de otra pantalla). */
  inicial?: { valores: Row; detalles: Record<string, Row[]> };
}

export function EditDialog({ schema, id, onClose, onSaved, inicial }: Props) {
  const esNuevo = id === 0;
  const soloLectura = !esNuevo && !schema.permisos.modificar;
  const [valores, setValores] = useState<Row>();
  const [opciones, setOpciones] = useState<Row>(() => defaults(schema.parametrosGuardar));
  const [lookups, setLookups] = useState<Lookups>({});
  const [detalles, setDetalles] = useState<Record<string, Row[]>>({});
  const [error, setError] = useState('');
  const [guardando, setGuardando] = useState(false);
  const [pestana, setPestana] = useState<'general' | 'impuestos'>('general');
  const valoresAnteriores = useRef<Row>();

  const seleccionarOpcionesUnicas = (actuales: Row, listas: Lookups): Row => {
    const siguientes = { ...actuales };
    for (const f of schema.camposEdicion) {
      if ((!f.lookup && !f.options) || (siguientes[f.name] !== null && siguientes[f.name] !== undefined && siguientes[f.name] !== '' && siguientes[f.name] !== 0)) continue;
      const lista = f.options ?? (f.lookup ? listas[f.lookup] : undefined);
      if (lista?.length === 1) siguientes[f.name] = lista[0].key;
    }
    return siguientes;
  };

  useEffect(() => {
    api.obtener(schema.key, id)
      .then((r) => {
        const v: Row = { ...r.datos, ...(esNuevo ? inicial?.valores : undefined) };
        for (const f of schema.camposEdicion) if (f.sensitive) v[f.name] = '';
        if (schema.key === 'Parametros' && String(v.TipoDato) === '7') v.Valor = '';
        setValores(seleccionarOpcionesUnicas(v, r.lookups));
        setLookups(r.lookups);
        setDetalles({ ...(r.detalles ?? {}), ...(esNuevo ? inicial?.detalles : undefined) });
      })
      .catch((e: ApiError) => setError(e.message));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [schema, id]);

  const claveDep = JSON.stringify(schema.camposEdicion.filter((f) => /^Id_|^Id[A-Z]/.test(f.name) || f.options).map((f) => valores?.[f.name]));
  useEffect(() => {
    if (!valores || soloLectura || schema.camposEdicion.every((f) => !f.lookup)) return;
    const anteriores = valoresAnteriores.current;
    const actualizaDependencias = anteriores
      ? ['Id_Entidad', 'Id_TipoEntidad', 'Id_Sucursal', 'Id_TipoComprobante']
        .some((name) => String(anteriores[name] ?? '') !== String(valores[name] ?? ''))
      : !inicial;
    valoresAnteriores.current = valores;
    const h = setTimeout(() => {
      api.lookupsDependientes(schema.key, id, valores)
        .then((r) => {
          setError('');
          setLookups((x) => ({ ...x, ...r.lookups }));
          setValores((x) => {
            if (!x) return x;
            const dependientes = esNuevo && actualizaDependencias ? r.valores : undefined;
            return seleccionarOpcionesUnicas({ ...x, ...dependientes }, { ...lookups, ...r.lookups });
          });
        })
        .catch((e: ApiError) => setError(e.message));
    }, 400);
    return () => clearTimeout(h);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [claveDep]);

  const submit = async (e: FormEvent) => {
    e.preventDefault();
    if (!valores) return;
    setError('');
    setGuardando(true);
    try {
      await api.guardar(schema.key, id, valores, opciones, schema.colecciones.length ? detalles : undefined);
      onSaved();
    } catch (err) {
      setError((err as ApiError).message);
    } finally {
      setGuardando(false);
    }
  };

  const titulo = `${schema.titulo} - ${esNuevo ? 'Nuevo' : soloLectura ? `Ver #${id}` : `Modificar #${id}`}`;
  const muchos = schema.camposEdicion.length > 12;
  const separaImpuestos = schema.key === 'ComprobantesVentas' && schema.colecciones.some((c) => c.name === 'Impuestos');
  const tipoDatoValor: Record<string, FieldSchema['type']> = {
    '1': 'bool', '2': 'decimal', '3': 'int', '4': 'date', '5': 'string', '6': 'string', '7': 'string'
  };
  const coleccionesVisibles = schema.colecciones.filter((c) => !separaImpuestos || (pestana === 'impuestos' ? c.name === 'Impuestos' : c.name !== 'Impuestos'));

  return (
    <Modal titulo={titulo} onClose={onClose} ancho={muchos ? 'grande' : 'normal'}>
      {!valores && !error && <p className="muted">Cargando...</p>}
      {valores && (
        <form onSubmit={submit}>
          <div className={`form-grid ${muchos ? 'cols-3' : ''}`}>
            {schema.camposEdicion.map((f) => {
              if (schema.key === 'ComprobantesVentas' && esNuevo && f.name === 'NroComprobante')
                return <div key={f.name} className="field"><label>{f.label}</label><input disabled value="Se asigna al guardar" /></div>;
              const campoValorParametro = schema.key === 'Parametros' && f.name === 'Valor';
              const campo = campoValorParametro
                ? { ...f, type: tipoDatoValor[String(valores.TipoDato)] ?? 'string', sensitive: String(valores.TipoDato).toLowerCase() === 'password' }
                : f;
              return <Field key={f.name} field={campo} value={valores[f.name]} lookups={lookups} esNuevo={esNuevo}
                disabled={soloLectura} onChange={(v) => setValores((x) => ({ ...x, [f.name]: campoValorParametro ? String(v ?? '') : v }))} />;
            })}
          </div>
          {separaImpuestos && <div className="actions">
            <button type="button" className={`btn ${pestana === 'general' ? 'primary' : ''}`} onClick={() => setPestana('general')}>Comprobante</button>
            <button type="button" className={`btn ${pestana === 'impuestos' ? 'primary' : ''}`} onClick={() => setPestana('impuestos')}>Impuestos</button>
          </div>}
          {coleccionesVisibles.map((c) => (
            <DetalleEditor key={c.name} schema={schema} coleccion={c} filas={detalles[c.name] ?? []} cabecera={valores}
              lookups={lookups} disabled={soloLectura} onChange={(f) => setDetalles((x) => ({ ...x, [c.name]: f }))} />
          ))}
          {!soloLectura && schema.parametrosGuardar.length > 0 && (
            <fieldset className="opciones">
              <legend>Opciones de guardado</legend>
              <div className="form-grid">
                {schema.parametrosGuardar.map((f) => (
                  <Field key={f.name} field={f} value={opciones[f.name]} lookups={lookups} esNuevo
                    onChange={(v) => setOpciones((x) => ({ ...x, [f.name]: v }))} />
                ))}
              </div>
            </fieldset>
          )}
          {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
          <div className="actions">
            <button type="button" className="btn" onClick={onClose}>{soloLectura ? 'Cerrar' : 'Cancelar'}</button>
            {!soloLectura && <button type="submit" className="btn primary" disabled={guardando}>{guardando ? 'Guardando...' : 'Guardar'}</button>}
          </div>
        </form>
      )}
      {!valores && error && <div className="alert">{error}</div>}
    </Modal>
  );
}
