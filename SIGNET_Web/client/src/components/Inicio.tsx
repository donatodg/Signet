import { useEffect, useRef, useState } from 'react';
import { api } from '../api';
import { confirmar } from './Dialogos';
import type { GrupoInicio, InicioConfig, TamanoTile, TileInicio } from '../types';

type CambiosTile = Partial<Pick<TileInicio, 'visible' | 'color1' | 'color2' | 'colorFuente'>>;
type Local = { tiles?: Record<number, CambiosTile>; colorFondo?: string; mostrarTitulos?: boolean };

// Sin persistencia en base (login de desarrollo) colores/visibilidad quedan en el navegador.
const localKey = (usuario: number | string) => `signet.inicio.${usuario}`;
const leerLocal = (u: number | string): Local => {
  try { return JSON.parse(localStorage.getItem(localKey(u)) ?? '{}'); } catch { return {}; }
};

function aplicarLocal(cfg: InicioConfig, l: Local): InicioConfig {
  return {
    ...cfg,
    colorFondo: l.colorFondo ?? cfg.colorFondo,
    mostrarTitulos: l.mostrarTitulos ?? cfg.mostrarTitulos,
    tiles: cfg.tiles.map((t) => ({ ...t, ...(l.tiles?.[t.id] ?? {}) }))
  };
}

const TAMANOS: { valor: TamanoTile; texto: string }[] = [
  { valor: 'Small', texto: 'Pequeño' },
  { valor: 'Medium', texto: 'Mediano' },
  { valor: 'Wide', texto: 'Largo' },
  { valor: 'Large', texto: 'Grande' }
];

const fondoTile = (t: TileInicio) => {
  const c1 = t.color1 || t.colorDefecto;
  return t.color2 ? `linear-gradient(135deg, ${c1}, ${t.color2})` : c1;
};

const NUEVO_GRUPO = -1;

export function Inicio({ usuarioId }: { usuarioId: number | string }) {
  const [cfg, setCfg] = useState<InicioConfig | null>(null);
  const [error, setError] = useState('');
  const [editando, setEditando] = useState(false);
  const [aviso, setAviso] = useState('');
  const [menu, setMenu] = useState<{ id: number; x: number; y: number } | null>(null);
  const [arrastrando, setArrastrando] = useState<number | null>(null);
  const [destino, setDestino] = useState<string | null>(null);
  const timers = useRef<Record<string, number>>({});

  const cargar = () =>
    api.inicio()
      .then((c) => { setCfg(c.guardaEnBase ? c : aplicarLocal(c, leerLocal(usuarioId))); setError(''); })
      .catch((e) => setError(e.message));

  useEffect(() => { cargar(); }, [usuarioId]);

  useEffect(() => {
    if (!menu) return;
    const cerrar = () => setMenu(null);
    const tecla = (e: KeyboardEvent) => { if (e.key === 'Escape') cerrar(); };
    window.addEventListener('mousedown', cerrar);
    window.addEventListener('resize', cerrar);
    window.addEventListener('keydown', tecla);
    return () => {
      window.removeEventListener('mousedown', cerrar);
      window.removeEventListener('resize', cerrar);
      window.removeEventListener('keydown', tecla);
    };
  }, [menu]);

  // Los selectores de color disparan muchos cambios seguidos: se graba el último.
  const diferido = (clave: string, fn: () => void, ms = 400) => {
    window.clearTimeout(timers.current[clave]);
    timers.current[clave] = window.setTimeout(fn, ms);
  };

  const fallo = (e: Error) => setAviso(`No se pudo guardar la configuración: ${e.message}`);

  const persistir = (clave: string, accion: () => Promise<void>, local: (l: Local) => void) => {
    if (cfg?.guardaEnBase) {
      diferido(clave, () => accion().catch(fallo));
    } else {
      const l = leerLocal(usuarioId);
      local(l);
      localStorage.setItem(localKey(usuarioId), JSON.stringify(l));
    }
  };

  const cambiarTile = (id: number, cambios: CambiosTile) => {
    setCfg((c) => c && { ...c, tiles: c.tiles.map((t) => (t.id === id ? { ...t, ...cambios } : t)) });
    persistir(`tile-${id}-${Object.keys(cambios).join()}`, () => api.guardarTile(id, cambios), (l) => {
      l.tiles = { ...(l.tiles ?? {}), [id]: { ...(l.tiles?.[id] ?? {}), ...cambios } };
    });
  };

  const cambiarPreferencias = (cambios: { colorFondo?: string; mostrarTitulos?: boolean }) => {
    setCfg((c) => c && { ...c, ...cambios });
    persistir(`pref-${Object.keys(cambios).join()}`, () => api.guardarPreferenciasInicio(cambios), (l) => Object.assign(l, cambios));
  };

  const restablecerColores = (t: TileInicio) => {
    const cambios = { color1: t.colorDefecto, color2: null, colorFuente: '#FFFFFF' };
    setCfg((c) => c && { ...c, tiles: c.tiles.map((x) => (x.id === t.id ? { ...x, ...cambios } : x)) });
    persistir(
      `tile-${t.id}-reset`,
      () => api.guardarTile(t.id, { color1: t.colorDefecto, color2: t.colorDefecto, colorFuente: '#FFFFFF' }),
      (l) => { l.tiles = { ...(l.tiles ?? {}), [t.id]: { ...(l.tiles?.[t.id] ?? {}), ...cambios } }; }
    );
  };

  // ---- Diseño (grupo, orden, tamaño, títulos) ----
  const guardarLayout = (c: InicioConfig, inmediato = false) => {
    const usados = new Set(c.tiles.map((t) => t.grupo));
    const layout = {
      grupos: c.grupos.filter((g) => usados.has(g.id)),
      tiles: c.tiles.map((t) => ({ id: t.id, grupo: t.grupo, tamano: t.tamano }))
    };
    const enviar = () => api.guardarLayoutInicio(layout).catch(fallo);
    if (inmediato) { window.clearTimeout(timers.current.layout); enviar(); } else diferido('layout', enviar);
  };

  const actualizarLayout = (fn: (c: InicioConfig) => InicioConfig, inmediato = true) => {
    if (!cfg) return;
    const n = fn(cfg);
    const usados = new Set(n.tiles.map((t) => t.grupo));
    const r = { ...n, grupos: n.grupos.filter((g) => usados.has(g.id)) };
    setCfg(r);
    guardarLayout(r, inmediato);
  };

  const nuevoGrupo = (c: InicioConfig): { grupos: GrupoInicio[]; id: number } => {
    const id = Math.max(100, ...c.grupos.map((g) => g.id)) + 1;
    return { id, grupos: [...c.grupos, { id, titulo: 'Nuevo grupo', colorTitulo: null }] };
  };

  /** Mueve el azulejo al grupo indicado, antes de `antesDe` (o al final). */
  const mover = (id: number, grupo: number, antesDe?: number) => {
    if (id === antesDe) return;
    actualizarLayout((c) => {
      let grupos = c.grupos;
      if (grupo === NUEVO_GRUPO) ({ grupos, id: grupo } = nuevoGrupo(c));
      const tile = c.tiles.find((t) => t.id === id);
      if (!tile) return c;
      const resto = c.tiles.filter((t) => t.id !== id);
      const movido = { ...tile, grupo };
      let i = antesDe != null ? resto.findIndex((t) => t.id === antesDe) : -1;
      if (i < 0) {
        const ultimo = resto.map((t) => t.grupo).lastIndexOf(grupo);
        i = ultimo >= 0 ? ultimo + 1 : resto.length;
      }
      resto.splice(i, 0, movido);
      return { ...c, grupos, tiles: resto };
    });
  };

  const cambiarTamano = (id: number, tamano: TamanoTile) =>
    actualizarLayout((c) => ({ ...c, tiles: c.tiles.map((t) => (t.id === id ? { ...t, tamano } : t)) }));

  const cambiarGrupo = (id: number, cambios: Partial<GrupoInicio>) =>
    actualizarLayout((c) => ({ ...c, grupos: c.grupos.map((g) => (g.id === id ? { ...g, ...cambios } : g)) }), false);

  const colorTodosLosTitulos = (color: string) =>
    actualizarLayout((c) => ({ ...c, grupos: c.grupos.map((g) => ({ ...g, colorTitulo: color })) }), false);

  const restablecerDiseno = async () => {
    if (!(await confirmar('Se restablecen grupos, orden, tamaños, títulos, colores, fondo y accesos ocultos.', { titulo: '¿Volver al diseño original?', aceptar: 'Restablecer' }))) return;
    // Descarta grabaciones pendientes para que no vuelvan a escribir el diseño anterior.
    Object.values(timers.current).forEach((t) => window.clearTimeout(t));
    timers.current = {};
    localStorage.removeItem(localKey(usuarioId));
    setMenu(null);
    api.restablecerInicio().then(cargar).catch(fallo);
  };

  // ---- Arrastrar y soltar ----
  const soltar = (e: React.DragEvent, grupo: number, antesDe?: number) => {
    e.preventDefault();
    e.stopPropagation();
    const id = Number(e.dataTransfer.getData('text/plain'));
    setArrastrando(null);
    setDestino(null);
    if (id) mover(id, grupo, antesDe);
  };
  const sobre = (e: React.DragEvent, clave: string) => {
    if (arrastrando == null) return;
    e.preventDefault();
    e.stopPropagation();
    e.dataTransfer.dropEffect = 'move';
    if (destino !== clave) setDestino(clave);
  };

  const abrirMenu = (e: React.MouseEvent, id: number) => {
    e.preventDefault();
    e.stopPropagation();
    const ancho = 230, alto = 360;
    setMenu({ id, x: Math.min(e.clientX, window.innerWidth - ancho - 8), y: Math.min(e.clientY, window.innerHeight - alto - 8) });
  };

  const ir = (t: TileInicio) => { if (!editando) location.hash = `#/${t.pantalla}`; };

  const ocultos = cfg?.tiles.filter((t) => !t.visible) ?? [];
  const tileMenu = menu && cfg?.tiles.find((t) => t.id === menu.id);
  const colorTitulos = cfg?.grupos.find((g) => g.colorTitulo)?.colorTitulo ?? '#1F2933';

  return (
    <div className={`inicio${editando ? ' editando' : ''}`} style={cfg?.colorFondo ? { background: cfg.colorFondo } : undefined}>
      <div className="inicio-header">
        <span className="spacer" />
        {cfg && cfg.tiles.length > 0 && (
          <button className={`btn small btn-rueda${editando ? ' primary' : ''}`} onClick={() => setEditando((v) => !v)}
            title={editando ? 'Terminar personalización' : 'Personalizar'} aria-label={editando ? 'Terminar personalización' : 'Personalizar'}
            aria-pressed={editando}>⚙</button>
        )}
      </div>

      {error && <p className="error">{error}</p>}
      {aviso && <p className="error" onClick={() => setAviso('')}>{aviso}</p>}

      {editando && cfg && (
        <div className="inicio-config">
          <label className="check">
            <input type="checkbox" checked={cfg.mostrarTitulos}
              onChange={(e) => cambiarPreferencias({ mostrarTitulos: e.target.checked })} />
            Mostrar títulos de grupos
          </label>
          <label className="check" title="Aplica el color a los títulos de todos los grupos">
            Color de títulos
            <input type="color" value={colorTitulos} onChange={(e) => colorTodosLosTitulos(e.target.value)} />
          </label>
          <label className="check">
            Color de fondo
            <input type="color" value={cfg.colorFondo || '#F4F6F9'}
              onChange={(e) => cambiarPreferencias({ colorFondo: e.target.value })} />
          </label>
          {ocultos.length > 0 && (
            <label className="check">
              Agregar acceso
              <select value="" onChange={(e) => e.target.value && cambiarTile(Number(e.target.value), { visible: true })}>
                <option value="">Seleccione…</option>
                {ocultos.map((t) => <option key={t.id} value={t.id}>{t.titulo}</option>)}
              </select>
            </label>
          )}
          <button className="btn small" onClick={restablecerDiseno}>Restablecer diseño</button>
          <span className="muted small">
            Arrastre los azulejos para moverlos de grupo; clic derecho o ⋮ para tamaño, grupo y colores.
            {!cfg.guardaEnBase && ' Sesión de desarrollo: colores y visibilidad se guardan en este navegador.'}
          </span>
        </div>
      )}

      {cfg && cfg.tiles.length === 0 && <p className="muted">Seleccione una pantalla del menú.</p>}
      {cfg && cfg.tiles.length > 0 && !editando && ocultos.length === cfg.tiles.length && (
        <p className="muted">Todos los accesos están ocultos. Use la ruedita ⚙ para agregarlos.</p>
      )}

      <div className="tile-grupos">
        {cfg?.grupos.map((g) => {
          const tiles = cfg.tiles.filter((t) => t.grupo === g.id && (editando || t.visible));
          if (!tiles.length) return null;
          return (
            <section key={g.id} className={`tile-grupo${destino === `g${g.id}` ? ' destino' : ''}`}
              onDragOver={(e) => sobre(e, `g${g.id}`)} onDrop={(e) => soltar(e, g.id)}>
              {editando ? (
                <div className="tile-grupo-edit">
                  <input value={g.titulo} maxLength={60} placeholder="Título del grupo" style={{ color: g.colorTitulo || undefined }}
                    onChange={(e) => cambiarGrupo(g.id, { titulo: e.target.value })} />
                  <label className="tile-btn oscuro" title="Color del título">
                    <input type="color" value={g.colorTitulo || '#1F2933'} onChange={(e) => cambiarGrupo(g.id, { colorTitulo: e.target.value })} />A
                  </label>
                </div>
              ) : (
                cfg.mostrarTitulos && <h3 style={{ color: g.colorTitulo || undefined }}>{g.titulo}</h3>
              )}
              <div className="tile-grid">
                {tiles.map((t) => (
                  <div key={t.id}
                    className={`tile t-${t.tamano.toLowerCase()}${t.visible ? '' : ' oculto'}${arrastrando === t.id ? ' arrastrando' : ''}${destino === `t${t.id}` ? ' destino' : ''}`}
                    style={{ background: fondoTile(t), color: t.colorFuente || '#FFFFFF' }}
                    role="link" tabIndex={0} title={t.subtitulo}
                    draggable={editando}
                    onDragStart={(e) => { e.dataTransfer.setData('text/plain', String(t.id)); e.dataTransfer.effectAllowed = 'move'; setArrastrando(t.id); }}
                    onDragEnd={() => { setArrastrando(null); setDestino(null); }}
                    onDragOver={(e) => sobre(e, `t${t.id}`)}
                    onDrop={(e) => soltar(e, g.id, t.id)}
                    onContextMenu={(e) => abrirMenu(e, t.id)}
                    onClick={() => ir(t)}
                    onKeyDown={(e) => {
                      if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); ir(t); }
                      if (e.key === 'ContextMenu' || (e.shiftKey && e.key === 'F10')) {
                        e.preventDefault();
                        const r = e.currentTarget.getBoundingClientRect();
                        setMenu({ id: t.id, x: Math.min(r.left + 10, window.innerWidth - 238), y: Math.min(r.top + 10, window.innerHeight - 368) });
                      }
                    }}>
                    <span className="tile-titulo">{t.titulo}</span>
                    {(t.tamano === 'Wide' || t.tamano === 'Large') && <span className="tile-sub">{t.subtitulo}</span>}
                    {editando && (
                      <div className="tile-edit" onClick={(e) => e.stopPropagation()}>
                        <button className="tile-btn" title={t.visible ? 'Ocultar acceso' : 'Mostrar acceso'}
                          onClick={() => cambiarTile(t.id, { visible: !t.visible })}>{t.visible ? '✕' : '＋'}</button>
                        <button className="tile-btn" title="Opciones" onMouseDown={(e) => e.stopPropagation()}
                          onClick={(e) => abrirMenu(e, t.id)}>⋮</button>
                      </div>
                    )}
                  </div>
                ))}
              </div>
            </section>
          );
        })}
        {editando && arrastrando != null && (
          <section className={`tile-grupo tile-nuevo-grupo${destino === 'nuevo' ? ' destino' : ''}`}
            onDragOver={(e) => sobre(e, 'nuevo')} onDrop={(e) => soltar(e, NUEVO_GRUPO)}>
            Soltar aquí para crear un grupo nuevo
          </section>
        )}
      </div>

      {menu && tileMenu && cfg && (
        <div className="tile-menu" style={{ left: menu.x, top: menu.y }} role="menu"
          onMouseDown={(e) => e.stopPropagation()} onContextMenu={(e) => e.preventDefault()}>
          <div className="tile-menu-titulo">{tileMenu.titulo}</div>
          <div className="tile-menu-seccion">Tamaño</div>
          {TAMANOS.map((s) => (
            <button key={s.valor} role="menuitemradio" aria-checked={tileMenu.tamano === s.valor}
              onClick={() => { cambiarTamano(tileMenu.id, s.valor); setMenu(null); }}>
              <span className="tilde">{tileMenu.tamano === s.valor ? '✓' : ''}</span>{s.texto}
            </button>
          ))}
          <hr />
          <label className="tile-menu-fila">
            Grupo
            <select value={tileMenu.grupo} onChange={(e) => { mover(tileMenu.id, Number(e.target.value)); setMenu(null); }}>
              {cfg.grupos.map((g) => <option key={g.id} value={g.id}>{g.titulo || `Grupo ${g.id}`}</option>)}
              <option value={NUEVO_GRUPO}>+ Nuevo grupo</option>
            </select>
          </label>
          <hr />
          <label className="tile-menu-fila">Color 1
            <input type="color" value={tileMenu.color1 || tileMenu.colorDefecto} onChange={(e) => cambiarTile(tileMenu.id, { color1: e.target.value })} />
          </label>
          <label className="tile-menu-fila">Color 2
            <input type="color" value={tileMenu.color2 || tileMenu.color1 || tileMenu.colorDefecto} onChange={(e) => cambiarTile(tileMenu.id, { color2: e.target.value })} />
          </label>
          <label className="tile-menu-fila">Color fuente
            <input type="color" value={tileMenu.colorFuente || '#FFFFFF'} onChange={(e) => cambiarTile(tileMenu.id, { colorFuente: e.target.value })} />
          </label>
          <button onClick={() => { restablecerColores(tileMenu); setMenu(null); }}><span className="tilde" />Restablecer colores</button>
          <hr />
          <button onClick={() => { cambiarTile(tileMenu.id, { visible: !tileMenu.visible }); setMenu(null); }}>
            <span className="tilde" />{tileMenu.visible ? 'Eliminar (ocultar)' : 'Agregar (mostrar)'}
          </button>
        </div>
      )}
    </div>
  );
}
