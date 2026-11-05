import { FormEvent, useEffect, useState } from 'react';
import { api, ApiError } from '../api';
import { defaults } from '../format';
import type { Lookups, Row, ScreenSchema } from '../types';
import { Field } from './Field';
import { Modal } from './Modal';

interface Props {
  schema: ScreenSchema;
  alcance: Row;
  onClose: () => void;
  onSaved: () => void;
}

/** Alta de un registro dependiente de un padre (ej. asignar una empresa a un usuario). */
export function AgregarHijoDialog({ schema, alcance, onClose, onSaved }: Props) {
  const [valores, setValores] = useState<Row>(() => defaults(schema.parametrosGuardar));
  const [lookups, setLookups] = useState<Lookups>({});
  const [error, setError] = useState('');
  const [guardando, setGuardando] = useState(false);

  useEffect(() => {
    api.lookupsDependientes(schema.key, 0, alcance).then((r) => setLookups(r.lookups)).catch((e: ApiError) => setError(e.message));
  }, [schema.key, alcance]);

  const submit = async (e: FormEvent) => {
    e.preventDefault();
    setError('');
    setGuardando(true);
    try {
      await api.agregarHijo(schema.key, alcance, valores);
      onSaved();
    } catch (err) {
      setError((err as ApiError).message);
    } finally {
      setGuardando(false);
    }
  };

  return (
    <Modal titulo={`${schema.titulo} - Nuevo`} onClose={onClose}>
      <form onSubmit={submit}>
        <div className="form-grid">
          {schema.parametrosGuardar.map((f) => (
            <Field key={f.name} field={f} value={valores[f.name]} lookups={lookups} esNuevo
              onChange={(v) => setValores((x) => ({ ...x, [f.name]: v }))} />
          ))}
        </div>
        {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
        <div className="actions">
          <button type="button" className="btn" onClick={onClose}>Cancelar</button>
          <button type="submit" className="btn primary" disabled={guardando}>{guardando ? 'Guardando...' : 'Guardar'}</button>
        </div>
      </form>
    </Modal>
  );
}
