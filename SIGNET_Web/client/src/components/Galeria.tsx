import { useCallback, useEffect, useState } from 'react';
import { api, ApiError } from '../api';
import type { ImagenesGaleria } from '../types';
import { Modal } from './Modal';

const TAMANOS = { Chico: 110, Mediano: 180, Grande: 280 } as const;

function leer(file: File): Promise<{ nombre: string; base64: string }> {
  return new Promise((ok, fail) => {
    const fr = new FileReader();
    fr.onload = () => ok({ nombre: file.name, base64: String(fr.result).split(',')[1] ?? '' });
    fr.onerror = () => fail(new Error('No se pudo leer ' + file.name));
    fr.readAsDataURL(file);
  });
}

/** Equivalente web de frmImagenes: galería con alta múltiple, edición de descripción/categoría/orden, baja, rotación y descarga. */
export function Galeria({ tabla, id, onClose }: { tabla: string; id: number; onClose: () => void }) {
  const [data, setData] = useState<ImagenesGaleria>();
  const [error, setError] = useState('');
  const [info, setInfo] = useState('');
  const [sel, setSel] = useState<number>();
  const [tam, setTam] = useState<keyof typeof TAMANOS>('Mediano');
  const [desc, setDesc] = useState('');
  const [cat, setCat] = useState(0);
  const [orden, setOrden] = useState(1);
  const [grados, setGrados] = useState(0);
  const [ocupado, setOcupado] = useState(false);

  const cargar = useCallback(async () => {
    try { setData(await api.imagenes(tabla, id)); } catch (e) { setError((e as ApiError).message); }
  }, [tabla, id]);
  useEffect(() => { void cargar(); }, [cargar]);

  const actual = data?.imagenes.find((i) => i.id === sel);
  const elegir = (i: ImagenesGaleria['imagenes'][number]) => { setSel(i.id); setDesc(i.descripcion); setCat(i.idCategoria); setOrden(i.orden); setGrados(0); };

  const ejecutar = async (fn: () => Promise<{ mensaje: string }>) => {
    setError(''); setInfo(''); setOcupado(true);
    try { setInfo((await fn()).mensaje); await cargar(); } catch (e) { setError((e as ApiError).message ?? String(e)); } finally { setOcupado(false); }
  };

  const agregar = (files: FileList | null) => {
    if (!files?.length) return;
    void ejecutar(async () => api.imagenesAgregar(tabla, id, await Promise.all(Array.from(files).map(leer))));
  };
  const modificar = () => actual && window.confirm('¿Desea Modificar la Imagen Seleccionada?') &&
    ejecutar(() => api.imagenModificar(tabla, id, actual.id, { descripcion: desc, idCategoria: cat, orden })).then(() => undefined);
  const eliminar = () => actual && window.confirm('¿Desea Eliminar la Imagen Seleccionada?') &&
    ejecutar(async () => { const r = await api.imagenEliminar(tabla, id, actual.id); setSel(undefined); return r; }).then(() => undefined);
  const imprimir = () => {
    if (!actual) return;
    const w = window.open('', '_blank');
    if (!w) return;
    w.document.write(`<img src="${actual.datos}" style="max-width:100%;transform:rotate(${grados}deg)" onload="window.print()">`);
    w.document.close();
  };
  const guardar = () => {
    if (!actual) return;
    const a = document.createElement('a');
    a.href = actual.datos; a.download = `imagen-${actual.id}.jpg`; a.click();
  };

  return (
    <Modal titulo={`Imágenes - ${tabla} ${id}`} onClose={onClose} ancho="grande">
      {error && <div className="alert error" role="alert">{error}</div>}
      {info && <div className="alert info">{info}</div>}
      <div className="toolbar">
        <label className="btn primary">
          + Agregar
          <input type="file" multiple hidden accept=".jpg,.jpeg,.png,.gif,.tif,.tiff" disabled={ocupado}
            onChange={(e) => { agregar(e.target.files); e.target.value = ''; }} />
        </label>
        {(Object.keys(TAMANOS) as (keyof typeof TAMANOS)[]).map((k) => (
          <button key={k} className={`btn${tam === k ? ' primary' : ''}`} onClick={() => setTam(k)}>{k}</button>
        ))}
        <span className="muted">Cantidad de imágenes: {data?.imagenes.length ?? 0}</span>
      </div>
      <div style={{ display: 'flex', gap: 16, alignItems: 'flex-start' }}>
        <div style={{ flex: 1, display: 'flex', flexWrap: 'wrap', gap: 8, maxHeight: '60vh', overflow: 'auto' }}>
          {!data && !error && <p className="muted">Cargando…</p>}
          {data?.imagenes.map((i) => (
            <img key={i.id} src={i.datos} alt={i.descripcion} title={i.descripcion} onClick={() => elegir(i)}
              style={{ width: TAMANOS[tam], height: TAMANOS[tam], objectFit: 'cover', cursor: 'pointer', border: i.id === sel ? '3px solid #2563eb' : '1px solid #ccc' }} />
          ))}
          {data && !data.imagenes.length && <p className="muted">No hay imágenes cargadas.</p>}
        </div>
        {actual && (
          <div style={{ width: 320 }}>
            <div style={{ overflow: 'auto', maxHeight: 280, textAlign: 'center' }}>
              <img src={actual.datos} alt={actual.descripcion} style={{ maxWidth: '100%', transform: `rotate(${grados}deg)` }} />
            </div>
            <div className="toolbar">
              <button className="btn" onClick={() => setGrados((g) => g - 90)}>⟲ Izquierda</button>
              <button className="btn" onClick={() => setGrados((g) => g + 90)}>⟳ Derecha</button>
              <button className="btn" onClick={guardar}>Guardar imagen</button>
              <button className="btn" onClick={imprimir}>Imprimir</button>
            </div>
            <div className="form-grid">
              <label className="field"><span>Descripción</span><input className="input" maxLength={100} value={desc} onChange={(e) => setDesc(e.target.value)} /></label>
              <label className="field"><span>Categoría</span>
                <select className="input" value={cat} onChange={(e) => setCat(Number(e.target.value))}>
                  {data?.categorias.map((c) => <option key={c.key} value={c.key}>{c.name}</option>)}
                </select>
              </label>
              <label className="field"><span>Orden</span><input className="input" type="number" value={orden} onChange={(e) => setOrden(Number(e.target.value))} /></label>
            </div>
            <div className="toolbar">
              <button className="btn primary" disabled={ocupado} onClick={() => void modificar()}>Modificar</button>
              <button className="btn danger" disabled={ocupado} onClick={() => void eliminar()}>Eliminar</button>
            </div>
          </div>
        )}
      </div>
    </Modal>
  );
}
