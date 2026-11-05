import { ReactNode, useEffect } from 'react';

interface Props {
  titulo: string;
  onClose: () => void;
  children: ReactNode;
  footer?: ReactNode;
  ancho?: 'normal' | 'grande';
}

export function Modal({ titulo, onClose, children, footer, ancho = 'normal' }: Props) {
  useEffect(() => {
    const h = (e: KeyboardEvent) => e.key === 'Escape' && onClose();
    window.addEventListener('keydown', h);
    return () => window.removeEventListener('keydown', h);
  }, [onClose]);

  return (
    <div className="modal-backdrop" onMouseDown={(e) => e.target === e.currentTarget && onClose()}>
      <div className={`modal ${ancho}`} role="dialog" aria-modal="true" aria-label={titulo}>
        <header>
          <h2>{titulo}</h2>
          <button className="btn icon" onClick={onClose} aria-label="Cerrar">✕</button>
        </header>
        <div className="modal-body">{children}</div>
        {footer && <footer>{footer}</footer>}
      </div>
    </div>
  );
}
