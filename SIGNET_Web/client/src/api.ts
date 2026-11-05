import type { AccionResultado, AltaPrecargada, BasesInfo, ChatEstado, ChatMensaje, ChatRespuesta, ChatVentaSolicitud, DependentLookups, FieldSchema, GrupoInicio, ImagenesGaleria, InicioConfig, Lookups, MenuArea, Row, ScreenSchema, TamanoTile, TileInicio, Usuario } from './types';
import type { CuentaMovil, LookupItem, PortalEstado, PortalOpciones, ProductoMovil, RevisionMovil, VentaMovil } from './types';
import type { Catalogos, Configuracion, DocumentoComplementario, Estado, Mayor, Registro, Saldo, Simulacion, Solicitud } from './components/contabilidad/types';
import type { Clasificacion, FilaInforme, Operativa, Pendiente, Periodo, RevisionLote } from './components/contabilidad/types';
import type { ImportacionCompra, OpcionesCompraDocumento, ResultadoRevisionCompra, RevisionCompraDocumento } from './components/compras-documentos/types';

const TOKEN_KEY = 'signet.token';

export class ApiError extends Error {
  constructor(public status: number, message: string, public titulo = 'Atención') {
    super(message);
  }
}

let onUnauthorized: () => void = () => {};
export const setUnauthorizedHandler = (fn: () => void) => { onUnauthorized = fn; };

export const getToken = () => sessionStorage.getItem(TOKEN_KEY);
const setToken = (t: string | null) => (t ? sessionStorage.setItem(TOKEN_KEY, t) : sessionStorage.removeItem(TOKEN_KEY));

async function request<T>(method: string, url: string, body?: unknown): Promise<T> {
  const headers: Record<string, string> = { Accept: 'application/json' };
  const token = getToken();
  if (token) headers.Authorization = `Bearer ${token}`;
  if (body !== undefined) headers['Content-Type'] = 'application/json';

  let res: Response;
  try {
    res = await fetch(url, { method, headers, body: body !== undefined ? JSON.stringify(body) : undefined });
  } catch {
    throw new ApiError(0, 'No se pudo conectar con el servidor.');
  }

  if (res.status === 204) return undefined as T;
  const text = await res.text();
  let data: any = null;
  try { data = text ? JSON.parse(text) : null; } catch { data = null; }

  if (!res.ok) {
    if (res.status === 401 && token && !url.endsWith('/login')) {
      setToken(null);
      onUnauthorized();
    }
    const msg = data?.mensaje ?? (data && typeof data === 'object' ? Object.values(data).flat().join('\n') : '') ?? '';
    throw new ApiError(res.status, msg || `Error ${res.status}`, data?.titulo);
  }
  return data as T;
}

const s = (key: string) => `/api/screens/${encodeURIComponent(key)}`;

export const api = {
  comprasDocOpciones: () => request<OpcionesCompraDocumento>('GET', '/api/compras-documentos/opciones'),
  comprasDocListar: () => request<ImportacionCompra[]>('GET', '/api/compras-documentos'),
  comprasDocProductos: (buscar: string, id?: number) => request<LookupItem[]>('GET', `/api/compras-documentos/productos?${new URLSearchParams({ buscar, ...(id ? { id: String(id) } : {}) })}`),
  comprasDocCargar: (id: string, sucursal: number, archivos: { nombre: string; base64: string }[]) =>
    request<ImportacionCompra>('POST', '/api/compras-documentos', { id, sucursal, archivos }),
  comprasDocObtener: (id: string) => request<ImportacionCompra>('GET', `/api/compras-documentos/${id}`),
  comprasDocLeer: (id: string, version: number) => request<ImportacionCompra>('POST', `/api/compras-documentos/${id}/leer`, { version }),
  comprasDocPropuesta: (id: string) => request<RevisionCompraDocumento>('GET', `/api/compras-documentos/${id}/propuesta`),
  comprasDocVista: (id: string) => request<string[]>('GET', `/api/compras-documentos/${id}/vista`),
  comprasDocOriginal: (id: string, orden: number) => request<{ nombre: string; contentType: string; base64: string }>('GET', `/api/compras-documentos/${id}/original/${orden}`),
  comprasDocRevisar: (r: RevisionCompraDocumento) => request<ResultadoRevisionCompra>('POST', '/api/compras-documentos/revisar', r),
  comprasDocRevision: (r: RevisionCompraDocumento) => request<ImportacionCompra>('POST', '/api/compras-documentos/revision', r),
  comprasDocGuardar: (revision: RevisionCompraDocumento, firma: string) =>
    request<ResultadoRevisionCompra>('POST', '/api/compras-documentos/guardar', { revision, firma }),
  contabilidadUsuariosAutomaticos: () => request<LookupItem[]>('GET', '/api/contabilidad/usuarios-automaticos'),
  contabilidadCostos: (empresa: number, venta: number) => request<FilaInforme[]>('GET', `/api/contabilidad/costos?empresa=${empresa}&venta=${venta}`),
  contabilidadBandeja: (empresa: number, desde: string, hasta: string) =>
    request<Pendiente[]>('GET', `/api/contabilidad/bandeja?${new URLSearchParams({ empresa: String(empresa), desde, hasta })}`),
  contabilidadSincronizar: (empresa: number, desde: string, hasta: string) =>
    request<{ cantidad: number }>('POST', '/api/contabilidad/bandeja/sincronizar', { empresa, desde, hasta }),
  contabilidadRevisarLote: (empresa: number, documentos: RevisionLote[]) =>
    request<RevisionLote[]>('POST', '/api/contabilidad/bandeja/revisar', { empresa, documentos }),
  contabilidadRegistrarLote: (empresa: number, documentos: RevisionLote[]) =>
    request<Registro[]>('POST', '/api/contabilidad/bandeja/registrar', { empresa, documentos }),
  contabilidadAprobar: (empresa: number, r: RevisionLote, motivo: string) =>
    request('POST', '/api/contabilidad/aprobar', { empresa, operatoria: r.operatoria, documento: r.documento, firma: r.simulacion?.firma, motivo }),
  contabilidadReintentar: (empresa: number, id: number) => request('POST', `/api/contabilidad/bandeja/${id}/reintentar`, { empresa }),
  contabilidadOperativa: (empresa: number) => request<Operativa>('GET', `/api/contabilidad/operativa?empresa=${empresa}`),
  contabilidadGuardarOperativa: (configuracion: Operativa, motivo: string) =>
    request<Operativa>('POST', '/api/contabilidad/operativa', { empresa: configuracion.empresa, configuracion, motivo }),
  contabilidadProcesar: (empresa: number) => request<{ procesados: number }>('POST', '/api/contabilidad/procesar', { empresa }),
  contabilidadPeriodos: (empresa: number) => request<Periodo[]>('GET', `/api/contabilidad/periodos?empresa=${empresa}`),
  contabilidadPeriodo: (empresa: number, mes: string, cerrar: boolean, motivo: string) =>
    request('POST', '/api/contabilidad/periodos', { empresa, mes, cerrar, motivo }),
  contabilidadAuditoria: (empresa: number) => request<FilaInforme[]>('GET', `/api/contabilidad/auditoria?empresa=${empresa}`),
  contabilidadClasificacion: (empresa: number) => request<Clasificacion>('GET', `/api/contabilidad/clasificacion?empresa=${empresa}`),
  contabilidadGuardarClasificacion: (empresa: number, c: Clasificacion, motivo: string) =>
    request('POST', '/api/contabilidad/clasificacion', { empresa, ...c, motivo }),
  contabilidadConciliacion: (empresa: number, moneda: number, desde: string, hasta: string, tipo: string) =>
    request<FilaInforme[]>('GET', `/api/contabilidad/conciliacion?${new URLSearchParams({ empresa: String(empresa), moneda: String(moneda), desde, hasta, tipo })}`),
  contabilidadExportar: (empresa: number, moneda: number, desde: string, hasta: string, tipo: string, formato: string) =>
    request<NonNullable<AccionResultado['archivo']>>('GET', `/api/contabilidad/exportar?${new URLSearchParams({ empresa: String(empresa), moneda: String(moneda), desde, hasta, tipo, formato })}`),
  contabilidadEstado: () => request<Estado>('GET', '/api/contabilidad/estado'),
  contabilidadCatalogos: (empresa: number) => request<Catalogos>('GET', `/api/contabilidad/catalogos?empresa=${empresa}`),
  contabilidadReferencias: (empresa: number, dimension: number, buscar: string, id?: number) =>
    request<LookupItem[]>('GET', `/api/contabilidad/referencias?${new URLSearchParams({ empresa: String(empresa), dimension: String(dimension),
      buscar, ...(id ? { id: String(id) } : {}) })}`),
  contabilidadConfiguracion: (empresa: number) => request<Configuracion>('GET', `/api/contabilidad/configuracion?empresa=${empresa}`),
  contabilidadGuardar: (config: Configuracion) => request<Configuracion>('POST', '/api/contabilidad/configuracion', config),
  contabilidadSimular: (s: Solicitud) => request<Simulacion>('POST', '/api/contabilidad/simular', s),
  contabilidadDocumentos: (empresa: number, operatoria: number, buscar: string) =>
    request<LookupItem[]>('GET', `/api/contabilidad/documentos?${new URLSearchParams({ empresa: String(empresa), operatoria: String(operatoria), buscar })}`),
  contabilidadRegistrar: (s: Solicitud) => request<Registro>('POST', '/api/contabilidad/registrar', s),
  contabilidadCrearDocumento: (d: DocumentoComplementario) => request<DocumentoComplementario>('POST', '/api/contabilidad/complementarios', d),
  contabilidadEjercicio: (s: { empresa: number; ejercicio: number; operatoria: number; sucursal: number; fecha: string; clave: string }) =>
    request<DocumentoComplementario>('POST', '/api/contabilidad/ejercicio', s),
  contabilidadSaldos: (empresa: number, moneda: number, desde: string, hasta: string) =>
    request<Saldo[]>('GET', `/api/contabilidad/saldos?${new URLSearchParams({ empresa: String(empresa), moneda: String(moneda), desde, hasta })}`),
  contabilidadMayor: (empresa: number, moneda: number, cuenta: number, desde: string, hasta: string) =>
    request<Mayor>('GET', `/api/contabilidad/mayor?${new URLSearchParams({ empresa: String(empresa), moneda: String(moneda), cuenta: String(cuenta), desde, hasta })}`),
  contabilidadDiario: (empresa: number, desde: string, hasta: string) =>
    request<Registro[]>('GET', `/api/contabilidad/diario?${new URLSearchParams({ empresa: String(empresa), desde, hasta })}`),
  contabilidadRevertir: (empresa: number, lote: number, fecha: string, motivo: string) =>
    request<Registro>('POST', '/api/contabilidad/revertir', { empresa, lote, fecha, motivo }),
  portalEstado: () => request<PortalEstado>('GET', '/api/vendedores'),
  portalOpciones: () => request<PortalOpciones>('GET', '/api/vendedores/opciones'),
  portalEntidades: (uso: string, buscar: string, tipo = 1) =>
    request<{ opciones: LookupItem[]; hayMas: boolean }>('GET', `/api/vendedores/entidades?${new URLSearchParams({ uso, buscar, tipo: String(tipo) })}`),
  portalProductos: (uso: string, cliente: number, buscar: string) =>
    request<{ productos: ProductoMovil[]; hayMas: boolean }>('GET', `/api/vendedores/productos?${new URLSearchParams({ uso, cliente: String(cliente), buscar })}`),
  portalTalonarios: (cliente: number, sucursal: number, comprobante: number) =>
    request<LookupItem[]>('GET', `/api/vendedores/talonarios?cliente=${cliente}&sucursal=${sucursal}&comprobante=${comprobante}`),
  portalMonedas: () => request<LookupItem[]>('GET', '/api/vendedores/monedas'),
  portalCuenta: (entidad: number, moneda: number, desde: string, hasta: string, tipo: number) =>
    request<CuentaMovil>('GET', `/api/vendedores/cuenta?${new URLSearchParams({ entidad: String(entidad), moneda: String(moneda), desde, hasta, tipo: String(tipo) })}`),
  portalComprobante: (movimiento: number, entidad: number, moneda: number, tipo: number) =>
    request<AccionResultado>('GET', `/api/vendedores/comprobante?movimiento=${movimiento}&entidad=${entidad}&moneda=${moneda}&tipo=${tipo}`),
  portalRevisar: (venta: VentaMovil) => request<RevisionMovil>('POST', '/api/vendedores/revisar', venta),
  portalGuardar: (token: string) =>
    request<{ id: number; comprobante: string; mensaje: string }>('POST', '/api/vendedores/guardar', { token }),
  bases: () => request<BasesInfo>('GET', '/api/auth/bases'),
  login: async (base: string, usuario: string, clave: string) => {
    const r = await request<{ token: string; usuario: Usuario }>('POST', '/api/auth/login', { base, usuario, clave });
    setToken(r.token);
    return r.usuario;
  },
  logout: async () => {
    try { await request('POST', '/api/auth/logout'); } finally { setToken(null); }
  },
  me: () => request<Usuario>('GET', '/api/auth/me'),
  cambiarClave: (claveActual: string, claveNueva: string, claveNueva2: string) =>
    request<void>('POST', '/api/auth/cambiar-clave', { claveActual, claveNueva, claveNueva2 }),
  catalogo: () => request<MenuArea[]>('GET', '/api/catalog'),
  inicio: () => request<InicioConfig>('GET', '/api/inicio'),
  guardarTile: (id: number, cambios: Partial<Pick<TileInicio, 'visible' | 'color1' | 'color2' | 'colorFuente'>>) =>
    request<void>('PUT', `/api/inicio/tiles/${id}`, cambios),
  guardarPreferenciasInicio: (cambios: { colorFondo?: string; mostrarTitulos?: boolean }) =>
    request<void>('PUT', '/api/inicio/preferencias', cambios),
  guardarLayoutInicio: (layout: { grupos: GrupoInicio[]; tiles: { id: number; grupo: number; tamano: TamanoTile }[] }) =>
    request<void>('PUT', '/api/inicio/layout', layout),
  restablecerInicio: () => request<void>('DELETE', '/api/inicio'),
  chatEstado: () => request<ChatEstado>('GET', '/api/chat'),
  chatPreguntar: (pregunta: string, historial: ChatMensaje[], ventaAnterior?: ChatVentaSolicitud) =>
    request<ChatRespuesta>('POST', '/api/chat', { pregunta, historial, ventaAnterior }),
  chatAbrirVenta: (solicitud: ChatVentaSolicitud) => request<AltaPrecargada>('POST', '/api/chat/venta/formulario', solicitud),

  schema: (key: string) => request<ScreenSchema>('GET', `${s(key)}/schema`),
  lookups: (key: string) => request<Lookups>('GET', `${s(key)}/lookups`),
  buscar: (key: string, parametros: Row) => request<{ filas: Row[]; truncado: boolean }>('POST', `${s(key)}/buscar`, parametros),
  obtener: (key: string, id: number) =>
    request<{ datos: Row; lookups: Lookups; detalles?: Record<string, Row[]> }>('GET', `${s(key)}/registros/${id === 0 ? 'nuevo' : id}`),
  guardar: (key: string, id: number, values: Row, opciones?: Row, detalles?: Record<string, Row[]>) =>
    request<{ id: number }>('POST', `${s(key)}/registros`, { id, values, opciones, detalles }),
  lookupsDependientes: (key: string, id: number, values: Row) =>
    request<DependentLookups>('POST', `${s(key)}/lookups-dependientes`, { id, values }),
  autocompletarRenglon: (key: string, coleccion: string, fila: Row, campo: string | null, cabecera: Row) =>
    request<Row>('POST', `${s(key)}/autocompletar-renglon`, { coleccion, campo, fila, cabecera }),
  agregarHijo: (key: string, values: Row, opciones: Row) => request<{ ok: boolean }>('POST', `${s(key)}/hijos`, { values, opciones }),
  guardarEdicion: (key: string, values: Row, filas: Row[]) => request<{ ok: boolean; mensaje: string }>('POST', `${s(key)}/edicion`, { values, filas }),
  imagenes: (tabla: string, id: number) => request<ImagenesGaleria>('GET', `/api/imagenes/${tabla}/${id}`),
  imagenesAgregar: (tabla: string, id: number, archivos: { nombre: string; base64: string }[]) => request<{ mensaje: string }>('POST', `/api/imagenes/${tabla}/${id}`, { archivos }),
  imagenModificar: (tabla: string, id: number, imagenId: number, d: { descripcion: string; idCategoria: number; orden: number }) => request<{ mensaje: string }>('PUT', `/api/imagenes/${tabla}/${id}/${imagenId}`, d),
  imagenEliminar: (tabla: string, id: number, imagenId: number) => request<{ mensaje: string }>('DELETE', `/api/imagenes/${tabla}/${id}/${imagenId}`),
  procesar: (key: string, values: Row) => request<AccionResultado & { ok: boolean }>('POST', `${s(key)}/procesar`, { values }),
  eliminar: (key: string, id: number) => request<void>('DELETE', `${s(key)}/registros/${id}`),
  camposAccion: (key: string, accion: string, ids: number[]) =>
    request<FieldSchema[]>('POST', `${s(key)}/acciones/${encodeURIComponent(accion)}/campos`, { ids }),
  ejecutarAccion: (key: string, accion: string, ids: number[], valores: Row) =>
    request<AccionResultado>('POST', `${s(key)}/acciones/${encodeURIComponent(accion)}`, { ids, valores })
};
