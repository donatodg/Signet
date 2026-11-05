import { FormEvent, MouseEvent, useEffect, useMemo, useState } from 'react';
import { api, ApiError } from '../api';
import { compare, defaults, formatValue, toExcelXml } from '../format';
import type { AccionSchema, AltaPrecargada, FieldSchema, Lookups, Row, ScreenSchema, TablaResultado } from '../types';
import { descargar, DialogoAccion, escribirVentana, htmlGrilla, MenuAcciones, mostrarPdf } from './Acciones';
import { EditDialog } from './EditDialog';
import { SearchBox } from './SearchBox';
import { confirmar } from './Dialogos';
import { Field } from './Field';
import { AgregarHijoDialog } from './AgregarHijoDialog';
import { Proceso, TablasResultado } from './Proceso';
import { Galeria } from './Galeria';
import { ComprasDocumentos } from './compras-documentos/ComprasDocumentos';

const PAGINA = 100;

function ordenGuardado(key: string, nombres: string[]): string[] {
  try {
    const g: string[] = JSON.parse(localStorage.getItem(`signet.colorden.${key}`) || '[]');
    return [...g.filter((n) => nombres.includes(n)), ...nombres.filter((n) => !g.includes(n))];
  } catch {
    return nombres;
  }
}

export function Screen({ screenKey }: { screenKey: string }) {
  const [schema, setSchema] = useState<ScreenSchema>();
  const [lookups, setLookups] = useState<Lookups>({});
  const [parametros, setParametros] = useState<Row>({});
  const [filas, setFilas] = useState<Row[]>();
  const [truncado, setTruncado] = useState(false);
  const [error, setError] = useState('');
  const [buscando, setBuscando] = useState(false);
  const [filtro, setFiltro] = useState('');
  const [mostrarFiltrosAvanzados, setMostrarFiltrosAvanzados] = useState(false);
  const [orden, setOrden] = useState<{ col: string; asc: boolean }>();
  const [visibles, setVisibles] = useState<Set<string>>(new Set());
  const [verColumnas, setVerColumnas] = useState(false);
  const [ordenCols, setOrdenCols] = useState<string[]>([]);
  const [arrastrada, setArrastrada] = useState<string>();
  const [pagina, setPagina] = useState(0);
  const [seleccion, setSeleccion] = useState<number>();
  const [editar, setEditar] = useState<number>();
  const [agregarHijo, setAgregarHijo] = useState(false);
  const [edic, setEdic] = useState<Record<string, Row>>({});
  const [marcados, setMarcados] = useState<Set<number>>(new Set());
  const [ancla, setAncla] = useState<number>();
  const [accionActiva, setAccionActiva] = useState<{ accion: AccionSchema; ids: number[] }>();
  const [info, setInfo] = useState('');
  const [tablasAccion, setTablasAccion] = useState<TablaResultado[]>([]);
  const [inicial, setInicial] = useState<{ valores: Row; detalles: Record<string, Row[]> }>();
  const [fijo, setFijo] = useState<Row>({});
  const [galeria, setGaleria] = useState<{ tabla: string; id: number }>();
  const [fijoTitulo, setFijoTitulo] = useState('');
  const [autoBuscar, setAutoBuscar] = useState(0);
  const [comprasDocumentos, setComprasDocumentos] = useState(false);

  useEffect(() => {
    setSchema(undefined); setFilas(undefined); setError(''); setFiltro(''); setOrden(undefined); setSeleccion(undefined); setMarcados(new Set()); setInfo(''); setEdic({});
    setTablasAccion([]); setInicial(undefined); setEditar(undefined);
    let vivo = true;
    api.schema(screenKey)
      .then((s) => {
        if (!vivo) return;
        setSchema(s);
        // Parámetros enviados por una acción de otra pantalla (equivale a los argumentos del constructor del formulario)
        const navKey = `signet.nav.${s.key.toLowerCase()}`;
        const navRaw = sessionStorage.getItem(navKey);
        const navParams: Row = {}; const navFijo: Row = {};
        if (navRaw) {
          sessionStorage.removeItem(navKey);
          const nav = JSON.parse(navRaw) as { parametros: Row; titulo?: string };
          const nombres = new Set(s.parametros.map((f) => f.name));
          Object.entries(nav.parametros).forEach(([k, v]) => (nombres.has(k) ? (navParams[k] = v) : (navFijo[k] = v)));
          setFijoTitulo(nav.titulo ?? '');
        } else setFijoTitulo('');
        // Alta precargada por una acción de otra pantalla (p. ej. "Generar Nota de Crédito")
        const pendiente = sessionStorage.getItem(`signet.alta.${s.key.toLowerCase()}`);
        if (pendiente) {
          sessionStorage.removeItem(`signet.alta.${s.key.toLowerCase()}`);
          const a = JSON.parse(pendiente) as AltaPrecargada;
          setInicial({ valores: a.valores ?? {}, detalles: a.detalles ?? {} });
          setEditar(0);
        }
        setParametros({ ...defaults(s.parametros), ...navParams });
        setFijo(navFijo);
        if (Object.keys(navParams).length || Object.keys(navFijo).length) setAutoBuscar((n) => n + 1);
        const guardadas = localStorage.getItem(`signet.cols.${s.key}`);
        setVisibles(new Set(guardadas ? JSON.parse(guardadas) : s.columnas.filter((c) => !c.hidden).map((c) => c.name)));
        setOrdenCols(ordenGuardado(s.key, s.columnas.map((c) => c.name)));
        if (s.lookups.length) api.lookups(screenKey).then((l) => vivo && setLookups(l)).catch(() => {});
      })
      .catch((e: ApiError) => vivo && setError(e.message));
    return () => { vivo = false; };
  }, [screenKey]);

  const claveDep = JSON.stringify(parametros);
  useEffect(() => {
    if (!schema || schema.tipo !== 'edicion' || !schema.parametros.some((f) => f.lookup)) return;
    const h = setTimeout(() => {
      api.lookupsDependientes(schema.key, 0, parametros).then((r) => setLookups((x) => ({ ...x, ...r.lookups }))).catch(() => undefined);
    }, 400);
    return () => clearTimeout(h);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [claveDep, schema]);

  const buscar = async (e?: FormEvent) => {
    e?.preventDefault();
    if (!schema) return;
    if (e) setInfo('');
    setError(''); setBuscando(true);
    try {
      const r = await api.buscar(schema.key, parametros);
      setFilas(r.filas); setTruncado(r.truncado); setPagina(0); setEdic({});
      const ids = new Set(r.filas.map((f) => Number(f.Id)));
      setSeleccion((s) => (s !== undefined && ids.has(s) ? s : undefined));
      setMarcados((m) => new Set([...m].filter((x) => ids.has(x))));
    } catch (err) {
      setError((err as ApiError).message);
    } finally {
      setBuscando(false);
    }
  };

  useEffect(() => {
    if (autoBuscar > 0 && schema) void buscar();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [autoBuscar]);

  const todasOrdenadas: FieldSchema[] = useMemo(() => {
    if (!schema) return [];
    const pos = new Map(ordenCols.map((n, i) => [n, i] as [string, number]));
    return [...schema.columnas].sort((a, b) => (pos.get(a.name) ?? 9999) - (pos.get(b.name) ?? 9999));
  }, [schema, ordenCols]);
  const columnas: FieldSchema[] = useMemo(() => todasOrdenadas.filter((c) => visibles.has(c.name) && c.name !== schema?.edicion?.selector), [todasOrdenadas, visibles, schema]);

  const filtradas = useMemo(() => {
    if (!filas) return [];
    let r = filas;
    const claves = Object.keys(fijo);
    if (claves.length) r = r.filter((row) => claves.every((k) => String(row[k]) === String(fijo[k]))); 
    const f = filtro.trim().toLowerCase();
    if (f) r = r.filter((row) => columnas.some((c) => formatValue(c, row[c.name], lookups).toLowerCase().includes(f)));
    if (orden) {
      r = [...r].sort((a, b) => compare(a[orden.col], b[orden.col]) * (orden.asc ? 1 : -1));
    }
    return r;
  }, [filas, filtro, orden, columnas, lookups, fijo]);

  const paginas = Math.max(1, Math.ceil(filtradas.length / PAGINA));
  const visiblesPagina = filtradas.slice(pagina * PAGINA, (pagina + 1) * PAGINA);
  const totalizables = columnas.filter((c) => (c.type === 'decimal' || c.type === 'int') && /importe|cantidad|stock/i.test(c.name));
  const totalColumna = (name: string) => filtradas.reduce((s, r) => {
    const n = typeof r[name] === 'number' ? r[name] as number : Number(String(r[name] ?? '').replace(',', '.'));
    return s + (Number.isFinite(n) ? n : 0);
  }, 0);

  const toggleColumna = (name: string) => {
    const n = new Set(visibles);
    n.has(name) ? n.delete(name) : n.add(name);
    setVisibles(n);
    if (schema) localStorage.setItem(`signet.cols.${schema.key}`, JSON.stringify([...n]));
  };

  const guardarOrden = (nuevo: string[]) => {
    setOrdenCols(nuevo);
    if (schema) localStorage.setItem(`signet.colorden.${schema.key}`, JSON.stringify(nuevo));
  };

  const mover = (name: string, delta: number) => {
    const n = todasOrdenadas.map((c) => c.name);
    const i = n.indexOf(name), j = i + delta;
    if (i < 0 || j < 0 || j >= n.length) return;
    [n[i], n[j]] = [n[j], n[i]];
    guardarOrden(n);
  };

  const soltarEn = (destino: string) => {
    if (!arrastrada || arrastrada === destino) return;
    const n = todasOrdenadas.map((c) => c.name).filter((x) => x !== arrastrada);
    n.splice(n.indexOf(destino) + (todasOrdenadas.findIndex((c) => c.name === arrastrada) < todasOrdenadas.findIndex((c) => c.name === destino) ? 1 : 0), 0, arrastrada);
    guardarOrden(n);
    setArrastrada(undefined);
  };

  const eliminar = async () => {
    if (!schema || !seleccion) return;
    if (!(await confirmar(`¿Confirma la eliminación del registro #${seleccion}?`, { titulo: 'Eliminar registro', aceptar: 'Eliminar', peligro: true }))) return;
    try {
      await api.eliminar(schema.key, seleccion);
      await buscar();
    } catch (err) {
      setError((err as ApiError).message);
    }
  };

  const ed = schema?.edicion ?? undefined;
  const claveFila = (r: Row) => String(r[ed?.clave ?? 'Id']);
  const marcadaFila = (r: Row) => edic[claveFila(r)]?.sel ?? !!r[ed?.selector ?? ''];
  const valorFila = (r: Row, n: string) => edic[claveFila(r)]?.[n] ?? r[n];
  const cambiarFila = (r: Row, cambios: Row) => {
    if (!ed) return;
    const k = claveFila(r);
    setEdic((x) => {
      const base: Row = x[k] ?? { sel: !!r[ed.selector], ...Object.fromEntries(ed.editables.map((n) => [n, r[n]])) };
      return { ...x, [k]: { ...base, ...cambios } };
    });
  };
  const marcarTodas = (on: boolean) => filtradas.forEach((r) => cambiarFila(r, { sel: on }));
  const [calcPct, setCalcPct] = useState('');
  const [calcImp, setCalcImp] = useState('');
  const esDetallePrecios = schema?.key === 'ProductosActualizaListasPrecios';
  const redondear = (n: number) => Math.round(n * 10000) / 10000;
  // Calcular (frmProductosListasPreciosDetalle): porcentaje o importe, sobre Importe e ImporteOriginal
  const calcular = () => {
    const pct = Number(calcPct.replace(',', '.')) || 0;
    const imp = Number(calcImp.replace(',', '.')) || 0;
    if (pct !== 0 && imp !== 0) { setError('Ingrese un porcentaje o un importe, no ambos.'); return; }
    setError('');
    filas?.forEach((r) => {
      const base = Number(r.Importe) || 0; const orig = Number(r.ImporteOriginal) || 0;
      cambiarFila(r, pct !== 0
        ? { NuevoPrecio: redondear(base * (1 + pct / 100)), NuevoPrecio_Original: redondear(orig * (1 + pct / 100)) }
        : { NuevoPrecio: redondear(base + imp), NuevoPrecio_Original: redondear(orig + imp) });
    });
  };
  const importarPrecios = () => {
    if (!window.confirm('¿Desea importar los precios actuales de los productos como nuevos precios?')) return;
    filas?.forEach((r) => cambiarFila(r, { NuevoPrecio: Number(r.ImporteProducto) || 0, NuevoPrecio_Original: Number(r.ImporteOriginalProducto) || 0 }));
  };
  const guardarEdicion = async () => {
    if (!schema || !ed) return;
    setError(''); setInfo('');
    try {
      const r = await api.guardarEdicion(schema.key, parametros, Object.entries(edic).map(([k, v]) => ({ k, ...v })));
      setInfo(r.mensaje);
      await buscar();
    } catch (err) {
      setError((err as ApiError).message);
    }
  };

  const exportar = () => {
    if (!schema) return;
    const blob = new Blob([toExcelXml(columnas, filtradas, lookups)], { type: 'application/vnd.ms-excel;charset=utf-8' });
    const a = document.createElement('a');
    a.href = URL.createObjectURL(blob);
    a.download = `${schema.key}.xls`;
    a.click();
    setTimeout(() => URL.revokeObjectURL(a.href), 1000);
  };

  /** Ids para la acción: los marcados (Ctrl/Shift) o el registro actual. */
  const idsSeleccionados = (): number[] => {
    if (marcados.size) return [...marcados];
    return seleccion !== undefined ? [seleccion] : [];
  };

  const accionHabilitada = (a: AccionSchema) => {
    if (a.key === 'resultado-busqueda') return filas !== undefined;
    if (a.seleccion === 'Una') return seleccion !== undefined;
    if (a.seleccion === 'Varias') return idsSeleccionados().length > 0;
    return true;
  };

  const ejecutarAccion = async (a: AccionSchema, ids: number[], valores: Row) => {
    if (!schema) return;
    // La ventana se abre en el mismo gesto del usuario para que el navegador no la bloquee
    const ventana = a.menu === 'Imprimir' ? window.open('', '_blank') : null;
    ventana?.document.write('<p style="font-family:sans-serif">Generando...</p>');
    let r;
    try {
      r = await api.ejecutarAccion(schema.key, a.key, ids, valores);
    } catch (err) {
      ventana?.close();
      throw err;
    }
    setAccionActiva(undefined);
    if (r.imprimirGrilla) escribirVentana(ventana, htmlGrilla(schema, columnas, filtradas, parametros, lookups, r.horizontal));
    else if (r.pdf) mostrarPdf(ventana ?? window.open('', '_blank'), r.pdf);
    else if (r.html) escribirVentana(ventana ?? window.open('', '_blank'), r.html);
    else ventana?.close();
    if (r.archivo) descargar(r.archivo);
    setTablasAccion(r.tablas ?? []);
    if (r.alta) {
      if (r.alta.pantalla.toLowerCase() === schema.key.toLowerCase()) {
        setInicial({ valores: r.alta.valores, detalles: r.alta.detalles });
        setEditar(0);
      } else {
        sessionStorage.setItem(`signet.alta.${r.alta.pantalla.toLowerCase()}`, JSON.stringify(r.alta));
        location.hash = `#/${r.alta.pantalla}`;
        return;
      }
    }
    if (r.imagenesTabla) { setGaleria({ tabla: r.imagenesTabla, id: r.imagenesId ?? 0 }); return; }
    if (r.navegar) {
      if (r.parametros) sessionStorage.setItem(`signet.nav.${r.navegar.toLowerCase()}`, JSON.stringify({ parametros: r.parametros, titulo: r.titulo }));
      location.hash = `#/${r.navegar}`;
      return;
    }
    if (r.mensaje) setInfo(r.mensaje);
    if (r.refrescar && filas) await buscar();
  };

  const seleccionarAccion = (a: AccionSchema) => {
    setError('');
    const ids = a.seleccion === 'Varias' ? idsSeleccionados() : a.seleccion === 'Una' && seleccion !== undefined ? [seleccion] : [];
    if (a.confirmacion || a.campos.length || a.tieneCamposDinamicos) {
      setAccionActiva({ accion: a, ids });
      return;
    }
    ejecutarAccion(a, ids, {}).catch((err: ApiError) => setError(err.message));
  };

  const clickFila = (e: MouseEvent, id: number) => {
    if (e.ctrlKey || e.metaKey) {
      const n = new Set(marcados.size ? marcados : seleccion !== undefined ? [seleccion] : []);
      n.has(id) ? n.delete(id) : n.add(id);
      setMarcados(n);
      setAncla(id);
    } else if (e.shiftKey && ancla !== undefined) {
      const ids = visiblesPagina.map((r) => Number(r.Id));
      const [a, b] = [ids.indexOf(ancla), ids.indexOf(id)].sort((x, y) => x - y);
      if (a >= 0) setMarcados(new Set(ids.slice(a, b + 1)));
    } else {
      setMarcados(new Set());
      setAncla(id);
    }
    setSeleccion(id);
  };

  if (!schema) return <div className="screen">{error ? <div className="alert">{error}</div> : <p className="muted">Cargando...</p>}</div>;

  if (schema.tipo === 'proceso') return <Proceso schema={schema} />;

  const p = schema.permisos;
  const esHijo = schema.tipo === 'hijo';
  const esAlta = schema.tipo === 'alta';
  const puedeAbrir = !esHijo && (p.modificar || schema.camposEdicion.length > 0);

  return (
    <div className="screen">
      <div className="screen-header">
        <div>
          <span className="muted small">{schema.area}</span>
          <h2>{schema.titulo}</h2>
        </div>
        <div className="toolbar">
          {p.agregar && <button className="btn primary" onClick={() => {
            if (esHijo) { setAgregarHijo(true); return; }
            setInicial(Object.keys(fijo).length ? { valores: { ...fijo }, detalles: {} } : undefined);
            setEditar(0);
          }}>+ Nuevo</button>}
          {schema.key.toLowerCase() === 'comprobantescompras' && p.agregar && <button className="btn" onClick={() => setComprasDocumentos(true)}>Compra desde foto / PDF</button>}
          {puedeAbrir && (p.modificar || p.agregar) && (
            <button className="btn" disabled={!seleccion} onClick={() => setEditar(seleccion)}>{p.modificar ? 'Modificar' : 'Ver'}</button>
          )}
          {ed && p.modificar && <button className="btn primary" disabled={!Object.keys(edic).length} onClick={guardarEdicion}>Guardar cambios</button>}
          {p.eliminar && <button className="btn danger" disabled={!seleccion} onClick={eliminar}>Eliminar</button>}
          <MenuAcciones titulo="Imprimir" acciones={schema.acciones.filter((a) => a.menu === 'Imprimir')}
            habilitada={accionHabilitada} onSelect={seleccionarAccion} />
          <MenuAcciones titulo="Operaciones" acciones={schema.acciones.filter((a) => a.menu !== 'Imprimir')}
            habilitada={accionHabilitada} onSelect={seleccionarAccion} />
        </div>
      </div>

      {galeria && <Galeria tabla={galeria.tabla} id={galeria.id} onClose={() => setGaleria(undefined)} />}
      {comprasDocumentos && <ComprasDocumentos onClose={() => setComprasDocumentos(false)} />}
      {Object.keys(fijo).length > 0 && (
        <p className="muted">Filtrado por: {fijoTitulo || Object.entries(fijo).map(([k, v]) => `${k} = ${v}`).join(', ')}{' '}
          <button className="btn small" onClick={() => setFijo({})}>Quitar filtro</button></p>
      )}
      {esAlta && <p className="muted">Use "+ Nuevo" para cargar un registro.</p>}
      {!esAlta && <form className="search-panel" onSubmit={buscar}>
        <div className="form-grid cols-4">
          {schema.parametros.filter((f) => !f.advanced || mostrarFiltrosAvanzados).map((f) => (
            <Field key={f.name} field={f} value={parametros[f.name]} lookups={lookups} modoBusqueda
              onChange={(v) => setParametros((x) => ({ ...x, [f.name]: v }))} />
          ))}
        </div>
        <div className="actions">
          {schema.parametros.some((f) => f.advanced) && <button type="button" className="btn" onClick={() => setMostrarFiltrosAvanzados((v) => !v)}>
            {mostrarFiltrosAvanzados ? 'Menos filtros' : 'Más filtros'}
          </button>}
          <button type="button" className="btn" onClick={() => setParametros(defaults(schema.parametros))}>Limpiar</button>
          <button type="submit" className="btn primary" disabled={buscando || !p.buscar}>{buscando ? 'Buscando...' : 'Buscar'}</button>
        </div>
      </form>}

      {error && <div className="alert" style={{ whiteSpace: 'pre-line' }}>{error}</div>}
      {info && <div className="info" style={{ whiteSpace: 'pre-line' }}>{info} <button className="btn icon" onClick={() => setInfo('')} aria-label="Cerrar">✕</button></div>}
      {tablasAccion.length > 0 && (
        <div className="tablas-accion">
          <button className="btn small" onClick={() => setTablasAccion([])}>Cerrar resultados</button>
          <TablasResultado tablas={tablasAccion} />
        </div>
      )}

      {filas && (
        <div className="results">
          <div className="results-bar">
            <SearchBox className="results-filter" placeholder="Filtrar resultados..." value={filtro}
              onChange={(v) => { setFiltro(v); setPagina(0); }} />
            <span className="muted small">
              {filtradas.length} registro(s){truncado && ' — resultado truncado, refine la búsqueda'}
              {marcados.size > 1 && ` — ${marcados.size} seleccionados`}
            </span>
            <span className="spacer" />
            <div className="dropdown">
              <button className="btn" onClick={() => setVerColumnas((v) => !v)}>Columnas ▾</button>
              {verColumnas && (
                <div className="dropdown-menu" onMouseLeave={() => setVerColumnas(false)}>
                  {todasOrdenadas.map((c, i) => (
                    <div key={c.name} className="col-item">
                      <label><input type="checkbox" checked={visibles.has(c.name)} onChange={() => toggleColumna(c.name)} /> {c.label}</label>
                      <button type="button" className="col-mover" title="Subir" disabled={i === 0} onClick={() => mover(c.name, -1)}>▲</button>
                      <button type="button" className="col-mover" title="Bajar" disabled={i === todasOrdenadas.length - 1} onClick={() => mover(c.name, 1)}>▼</button>
                    </div>
                  ))}
                  <button type="button" className="btn" onClick={() => guardarOrden(schema.columnas.map((c) => c.name))}>Restablecer orden</button>
                </div>
              )}
            </div>
            {ed && p.modificar && <><button className="btn" onClick={() => marcarTodas(true)}>Marcar todos</button><button className="btn" onClick={() => marcarTodas(false)}>Desmarcar todos</button></>}
            {ed && p.modificar && esDetallePrecios && <>
              <input className="input small" style={{ width: 90 }} placeholder="Porcentaje %" value={calcPct} onChange={(e) => setCalcPct(e.target.value)} />
              <input className="input small" style={{ width: 90 }} placeholder="Importe" value={calcImp} onChange={(e) => setCalcImp(e.target.value)} />
              <button className="btn" onClick={calcular}>Calcular</button>
              <button className="btn" onClick={importarPrecios}>Importar precios productos</button>
            </>}
            <button className="btn" onClick={exportar} disabled={!filtradas.length}>Exportar Excel</button>
          </div>

          <div className="grid-wrap">
            <table className="grid">
              <thead>
                <tr>
                  {ed && <th>✓</th>}
                  {columnas.map((c) => (
                    <th key={c.name} className={(c.type === 'int' || c.type === 'decimal' ? 'num' : '') + (arrastrada === c.name ? ' arrastrando' : '')}
                      draggable title="Arrastre para mover la columna"
                      onDragStart={() => setArrastrada(c.name)} onDragEnd={() => setArrastrada(undefined)}
                      onDragOver={(e) => e.preventDefault()} onDrop={() => soltarEn(c.name)}
                      onClick={() => setOrden((o) => ({ col: c.name, asc: o?.col === c.name ? !o.asc : true }))}>
                      {c.label}{orden?.col === c.name && (orden.asc ? ' ▲' : ' ▼')}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {visiblesPagina.map((r, i) => {
                  const id = Number(r.Id);
                  return (
                    <tr key={Number.isFinite(id) ? id : i}
                      className={seleccion === id || marcados.has(id) ? 'selected' : ''}
                      title="Ctrl/Shift + clic para seleccionar varios"
                      onClick={(e) => clickFila(e, id)}
                      onDoubleClick={() => puedeAbrir && (p.modificar || p.agregar) && setEditar(id)}>
                      {ed && <td onClick={(e) => e.stopPropagation()}><input type="checkbox" disabled={!p.modificar} checked={Boolean(marcadaFila(r))} onChange={(e) => cambiarFila(r, { sel: e.target.checked })} /></td>}
                      {columnas.map((c) => (
                        <td key={c.name} className={c.type === 'int' || c.type === 'decimal' ? 'num' : ''}>
                          {ed && p.modificar && ed.editables.includes(c.name)
                            ? <input type="number" step="any" style={{ width: '8em' }} value={String(valorFila(r, c.name) ?? '')} onClick={(e) => e.stopPropagation()}
                                onChange={(e) => cambiarFila(r, { [c.name]: e.target.value === '' ? 0 : Number(e.target.value) })} />
                            : formatValue(c, r[c.name], lookups)}
                        </td>
                      ))}
                    </tr>
                  );
                })}
                {!visiblesPagina.length && <tr><td colSpan={columnas.length || 1} className="muted center">Sin resultados</td></tr>}
              </tbody>
              <tfoot>
                <tr><td colSpan={columnas.length + (ed ? 1 : 0)} className="muted small">Cantidad de registros: {filtradas.length}</td></tr>
                {totalizables.length > 0 && <tr>
                  {ed && <td className="muted small">Totales</td>}
                  {columnas.map((c, i) => <td key={c.name} className={c.type === 'int' || c.type === 'decimal' ? 'num' : ''}>
                    {totalizables.some((t) => t.name === c.name)
                      ? totalColumna(c.name).toLocaleString('es-AR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })
                      : i === 0 && !ed ? 'Totales' : ''}
                  </td>)}
                </tr>}
              </tfoot>
            </table>
          </div>

          {paginas > 1 && (
            <div className="pager">
              <button className="btn" disabled={pagina === 0} onClick={() => setPagina(pagina - 1)}>‹</button>
              <span>Página {pagina + 1} de {paginas}</span>
              <button className="btn" disabled={pagina >= paginas - 1} onClick={() => setPagina(pagina + 1)}>›</button>
            </div>
          )}
        </div>
      )}

      {accionActiva && (
        <DialogoAccion schema={schema} accion={accionActiva.accion} ids={accionActiva.ids}
          onClose={() => setAccionActiva(undefined)}
          onEjecutar={(v) => ejecutarAccion(accionActiva.accion, accionActiva.ids, v)} />
      )}

      {agregarHijo && (
        <AgregarHijoDialog schema={schema} alcance={parametros} onClose={() => setAgregarHijo(false)}
          onSaved={() => { setAgregarHijo(false); buscar(); }} />
      )}

      {editar !== undefined && (
        <EditDialog schema={schema} id={editar} inicial={editar === 0 ? inicial : undefined}
          onClose={() => { setEditar(undefined); setInicial(undefined); }}
          onSaved={() => { setEditar(undefined); setInicial(undefined); buscar(); }} />
      )}
    </div>
  );
}
