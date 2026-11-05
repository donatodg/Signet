import { useCallback, useEffect, useState } from 'react';
import { api, getToken, setUnauthorizedHandler } from './api';
import { CambiarClave } from './components/CambiarClave';
import { Chat } from './components/Chat';
import { Inicio } from './components/Inicio';
import { Login } from './components/Login';
import { Screen } from './components/Screen';
import { Vendedores } from './components/Vendedores';
import { Contabilidad } from './components/contabilidad/Contabilidad';
import { SearchBox } from './components/SearchBox';
import type { MenuArea, Usuario } from './types';

const pantallaDeHash = () => decodeURIComponent(location.hash.replace(/^#\/?/, '')) || undefined;
const pantallaAngosta = window.matchMedia('(max-width: 900px)');
const MENU_KEY = 'signet.menuAbierto';
const menuInicial = (angosta: boolean) => !angosta && localStorage.getItem(MENU_KEY) !== '0';

export function App() {
  const [usuario, setUsuario] = useState<Usuario | null>();
  const [menu, setMenu] = useState<MenuArea[]>([]);
  const [contabilidadDisponible, setContabilidadDisponible] = useState(false);
  const [vendedoresDisponible, setVendedoresDisponible] = useState(false);
  const [errorMenu, setErrorMenu] = useState('');
  const [actual, setActual] = useState<string | undefined>(pantallaDeHash);
  const [filtro, setFiltro] = useState('');
  const [cambiarClave, setCambiarClave] = useState(false);
  const [chatDisponible, setChatDisponible] = useState(false);
  const [chatAbierto, setChatAbierto] = useState(false);
  const [chatUsado, setChatUsado] = useState(false);
  const [abiertas, setAbiertas] = useState<Set<string>>(new Set());
  const [angosta, setAngosta] = useState(pantallaAngosta.matches);
  const [menuAbierto, setMenuAbierto] = useState(() => menuInicial(pantallaAngosta.matches));

  useEffect(() => {
    const h = (e: MediaQueryListEvent) => { setAngosta(e.matches); setMenuAbierto(menuInicial(e.matches)); };
    pantallaAngosta.addEventListener('change', h);
    return () => pantallaAngosta.removeEventListener('change', h);
  }, []);

  const toggleMenu = () => setMenuAbierto((v) => {
    if (!pantallaAngosta.matches) localStorage.setItem(MENU_KEY, v ? '0' : '1');
    return !v;
  });

  const salir = useCallback(() => {
    setUsuario(null); setMenu([]); setContabilidadDisponible(false); setVendedoresDisponible(false);
    setChatDisponible(false); setChatAbierto(false); setChatUsado(false); setErrorMenu('');
  }, []);

  useEffect(() => {
    setUnauthorizedHandler(salir);
    if (getToken()) api.me().then(setUsuario).catch(() => setUsuario(null));
    else setUsuario(null);
    const h = () => {
      const p = pantallaDeHash();
      setActual(p);
      if (!p) setAbiertas(new Set());
      if (pantallaAngosta.matches) setMenuAbierto(false);
    };
    window.addEventListener('hashchange', h);
    return () => window.removeEventListener('hashchange', h);
  }, [salir]);

  useEffect(() => {
    let vigente = true;
    setMenu([]); setContabilidadDisponible(false); setVendedoresDisponible(false);
    setChatDisponible(false); setChatAbierto(false); setChatUsado(false); setErrorMenu('');
    if (!usuario) return;
    api.catalogo().then((m) => {
      if (!vigente) return;
      setMenu(m);
      // Las áreas arrancan colapsadas; sólo se expande la de la pantalla abierta (si hay)
      const p = pantallaDeHash();
      setAbiertas(new Set(m.filter((a) => a.pantallas.some((x) => x.key === p)).map((a) => a.area)));
    }).catch(e => { if (vigente) setErrorMenu((e as Error).message); });
    api.contabilidadEstado().then(e => {
      if (vigente) setContabilidadDisponible(e.ingresar);
    }).catch(e => { if (vigente) setErrorMenu((e as Error).message); });
    api.portalEstado().then(e => {
      if (vigente) setVendedoresDisponible(e.ingresar);
    }).catch(e => { if (vigente) setErrorMenu((e as Error).message); });
    api.chatEstado().then((e) => { if (vigente) setChatDisponible(e.habilitado && e.permitido); })
      .catch(() => { if (vigente) setChatDisponible(false); });
    return () => { vigente = false; };
  }, [usuario]);

  if (usuario === undefined) return <div className="login-page"><p className="muted">Cargando...</p></div>;
  if (usuario === null) return <Login onLogin={setUsuario} />;

  const f = filtro.trim().toLowerCase();
  const contabilidadVisible = contabilidadDisponible || menu.some(a => a.area === 'Contabilidad');
  const menuFiltrado = menu
    .map((a) => ({ ...a, pantallas: a.pantallas.filter((p) => !f || p.titulo.toLowerCase().includes(f) || a.area.toLowerCase().includes(f)) }))
    .filter((a) => a.pantallas.length);

  const toggleArea = (area: string) => {
    const n = new Set(abiertas);
    n.has(area) ? n.delete(area) : n.add(area);
    setAbiertas(n);
  };

  return (
    <div className={`layout${menuAbierto ? '' : ' menu-cerrado'}${angosta ? ' angosta' : ''}${actual === 'vendedores' ? ' seller-mode' : ''}`}>
      {angosta && menuAbierto && <div className="sidebar-backdrop" onClick={() => setMenuAbierto(false)} />}
      <aside className="sidebar" aria-hidden={!menuAbierto}>
        <a className="brand" href="#/" title="Ir al inicio" onClick={() => { setAbiertas(new Set()); setFiltro(''); }}>
          <img src="logo.png" alt="" onError={(e) => { e.currentTarget.style.display = 'none'; }} />
          <span className="brand-text">SIGNET <span>web</span></span>
        </a>
        <SearchBox placeholder="Buscar pantalla..." value={filtro} onChange={setFiltro} />
        <nav>
          {contabilidadVisible && <a href="#/contabilidad" className={actual === 'contabilidad' ? 'active' : ''}>Contabilidad</a>}
          {vendedoresDisponible && <a href="#/vendedores" className={actual === 'vendedores' ? 'active' : ''}>Portal de vendedores</a>}
          {menuFiltrado.map((a) => (
            <div key={a.area} className="menu-area">
              <button className="menu-area-title" onClick={() => toggleArea(a.area)}>
                {abiertas.has(a.area) || f ? '▾' : '▸'} {a.area}
              </button>
              {(abiertas.has(a.area) || f) && a.pantallas.map((p) => (
                <a key={p.key} href={`#/${p.key}`} className={p.key === actual ? 'active' : ''}>{p.titulo}</a>
              ))}
            </div>
          ))}
          {errorMenu && <p className="small pad" role="alert">No se pudo cargar el menú: {errorMenu}</p>}
          {!menu.length && !contabilidadVisible && !vendedoresDisponible && !errorMenu &&
            <p className="muted small pad">Sin pantallas habilitadas para su usuario.</p>}
        </nav>
      </aside>
      <div className="main">
        <header className="topbar">
          <button className="menu-toggle" onClick={toggleMenu} title={menuAbierto ? 'Ocultar menú' : 'Mostrar menú'}
            aria-label={menuAbierto ? 'Ocultar menú' : 'Mostrar menú'} aria-expanded={menuAbierto}>☰</button>
          <span className="muted">{usuario.empresa}</span>
          <span className="spacer" />
          <span>{usuario.nombre}</span>
          <button className="btn small" onClick={() => setCambiarClave(true)}>Cambiar clave</button>
          <button className="btn small" onClick={() => api.logout().finally(salir)}>Salir</button>
        </header>
        <main>
          {actual === 'contabilidad' ? <Contabilidad key={usuario.id} />
            : actual === 'vendedores' ? <Vendedores key={usuario.id} />
            : actual ? <Screen key={actual} screenKey={actual} /> : <Inicio usuarioId={usuario.id} />}
        </main>
      </div>
      {chatDisponible && !chatAbierto && (
        <button className="chat-fab" title="Asistente de datos (IA)" aria-label="Abrir asistente de datos"
          onClick={() => { setChatAbierto(true); setChatUsado(true); }}>✨</button>
      )}
      {chatDisponible && chatUsado && <div hidden={!chatAbierto}><Chat onClose={() => setChatAbierto(false)} /></div>}
      {cambiarClave && <CambiarClave onClose={() => setCambiarClave(false)} />}
    </div>
  );
}
