import { CSSProperties, FormEvent, useEffect, useState } from 'react';
import { api, ApiError } from '../api';
import type { BasesInfo, Usuario } from '../types';

export function Login({ onLogin }: { onLogin: (u: Usuario) => void }) {
  const [info, setInfo] = useState<BasesInfo>();
  const [base, setBase] = useState('');
  const [usuario, setUsuario] = useState('');
  const [clave, setClave] = useState('');
  const [error, setError] = useState('');
  const [cargando, setCargando] = useState(false);

  useEffect(() => {
    api.bases()
      .then((r) => {
        setInfo(r);
        const ultima = localStorage.getItem('signet.base');
        setBase(r.bases.includes(ultima ?? '') ? ultima! : r.bases[0] ?? '');
      })
      .catch((e: ApiError) => setError(e.message));
  }, []);

  const submit = async (e: FormEvent) => {
    e.preventDefault();
    setError('');
    setCargando(true);
    try {
      const u = await api.login(base, usuario, clave);
      localStorage.setItem('signet.base', base);
      onLogin(u);
    } catch (err) {
      setError((err as ApiError).message);
      setClave('');
    } finally {
      setCargando(false);
    }
  };

  const [fondo] = useState(() => `api/auth/login/imagen?r=${Date.now()}`);
  const l = info?.login;
  const estilo = l?.color ? ({ '--primary': l.color, '--primary-dark': l.color } as CSSProperties) : undefined;

  return (
    <div className="login-page" style={estilo}>
      <div className="login-shell">
        <aside className="login-hero" style={l?.imagen ? { backgroundImage: `url(${fondo})` } : undefined}>
          <div className="login-hero-texto">
            <img src="logo.png" alt="" className="login-logo" onError={(e) => { e.currentTarget.style.display = 'none'; }} />
            <h2>{l?.titulo || info?.sistema || 'SIGNET'}</h2>
            {l?.mensaje && <p>{l.mensaje}</p>}
          </div>
        </aside>
        <form className="login-panel" onSubmit={submit}>
          <h1>Bienvenido</h1>
          <p className="muted">Ingrese sus credenciales para continuar</p>
          <div className="field">
            <label htmlFor="base">Base de datos</label>
            <select id="base" value={base} onChange={(e) => setBase(e.target.value)} required>
              {info?.bases.map((b) => <option key={b} value={b}>{b}</option>)}
            </select>
          </div>
          <div className="field">
            <label htmlFor="usuario">Usuario</label>
            <input id="usuario" value={usuario} autoFocus autoComplete="username"
              onChange={(e) => setUsuario(e.target.value)} required />
          </div>
          <div className="field">
            <label htmlFor="clave">Clave</label>
            <input id="clave" type="password" value={clave} autoComplete="current-password"
              onChange={(e) => setClave(e.target.value)} required />
          </div>
          {error && <div className="alert">{error}</div>}
          {info?.desarrollo && <p className="muted small">Modo desarrollo: usuario <b>1</b> / clave <b>1</b> ingresa sin validar.</p>}
          <button className="btn primary login-submit" type="submit" disabled={cargando || !info}>
            {cargando ? 'Conectando...' : 'Ingresar'}
          </button>
          <div className="login-pie muted small">
            {l?.pie}
            {info?.web && <a href={`https://${info.web}`} target="_blank" rel="noreferrer">{info.web}</a>}
          </div>
        </form>
      </div>
    </div>
  );
}

