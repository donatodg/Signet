import { FormEvent, useState } from 'react';
import { api, ApiError } from '../api';
import { Modal } from './Modal';

export function CambiarClave({ onClose }: { onClose: () => void }) {
  const [actual, setActual] = useState('');
  const [nueva, setNueva] = useState('');
  const [nueva2, setNueva2] = useState('');
  const [error, setError] = useState('');
  const [ok, setOk] = useState(false);
  const [guardando, setGuardando] = useState(false);

  const submit = async (e: FormEvent) => {
    e.preventDefault();
    setError('');
    setGuardando(true);
    try {
      await api.cambiarClave(actual, nueva, nueva2);
      setOk(true);
    } catch (err) {
      setError((err as ApiError).message);
    } finally {
      setGuardando(false);
    }
  };

  return (
    <Modal titulo="Cambiar clave" onClose={onClose}>
      {ok ? (
        <>
          <p>La clave se cambió correctamente.</p>
          <div className="actions"><button className="btn primary" onClick={onClose}>Aceptar</button></div>
        </>
      ) : (
        <form onSubmit={submit}>
          <div className="field"><label>Clave actual</label>
            <input type="password" value={actual} onChange={(e) => setActual(e.target.value)} required autoComplete="current-password" /></div>
          <div className="field"><label>Clave nueva</label>
            <input type="password" value={nueva} onChange={(e) => setNueva(e.target.value)} required autoComplete="new-password" /></div>
          <div className="field"><label>Repetir clave nueva</label>
            <input type="password" value={nueva2} onChange={(e) => setNueva2(e.target.value)} required autoComplete="new-password" /></div>
          {error && <div className="alert">{error}</div>}
          <div className="actions">
            <button type="button" className="btn" onClick={onClose}>Cancelar</button>
            <button type="submit" className="btn primary" disabled={guardando}>Guardar</button>
          </div>
        </form>
      )}
    </Modal>
  );
}
