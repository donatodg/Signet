import { useEffect, useRef } from 'react';
import { createRoot } from 'react-dom/client';

interface Opciones {
  titulo?: string;
  mensaje: string;
  aceptar?: string;
  cancelar?: string | null;
  peligro?: boolean;
}

function DialogoMensaje({ o, cerrar }: { o: Opciones; cerrar: (r: boolean) => void }) {
  const ok = useRef<HTMLButtonElement>(null);
  useEffect(() => ok.current?.focus(), []);
  return (
    <div className="modal-backdrop" onKeyDown={(e) => e.key === 'Escape' && cerrar(false)}>
      <div className="modal dialogo" role="alertdialog" aria-modal="true" aria-label={o.titulo}>
        <header><h3>{o.titulo ?? 'SIGNET'}</h3></header>
        <div className="modal-body">{o.mensaje}</div>
        <footer className="dialogo-pie">
          {o.cancelar !== null && <button className="btn" onClick={() => cerrar(false)}>{o.cancelar ?? 'Cancelar'}</button>}
          <button ref={ok} className={`btn ${o.peligro ? 'danger' : 'primary'}`} onClick={() => cerrar(true)}>{o.aceptar ?? 'Aceptar'}</button>
        </footer>
      </div>
    </div>
  );
}

function mostrar(o: Opciones): Promise<boolean> {
  return new Promise((resolve) => {
    const host = document.createElement('div');
    document.body.appendChild(host);
    const root = createRoot(host);
    const cerrar = (r: boolean) => {
      root.unmount();
      host.remove();
      resolve(r);
    };
    root.render(<DialogoMensaje o={o} cerrar={cerrar} />);
  });
}

export const confirmar = (mensaje: string, o: Omit<Opciones, 'mensaje'> = {}) => mostrar({ ...o, mensaje });
export const avisar = (mensaje: string, titulo?: string) => mostrar({ mensaje, titulo, cancelar: null }).then(() => undefined);
