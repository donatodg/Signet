export type FieldType = 'string' | 'int' | 'decimal' | 'bool' | 'date' | 'time' | 'enum' | 'binary' | 'multi' | 'file';

/** Archivo subido por el usuario (campo 'file'). */
export interface ArchivoSubido {
  nombre: string;
  base64: string;
}

export interface TablaResultado {
  titulo: string;
  resumen?: string;
  columnas: FieldSchema[];
  filas: Row[];
}

export interface LookupItem {
  key: string | number;
  name: string;
}

export interface PortalEstado { ingresar: boolean; precios: boolean; cuenta: boolean; ventas: boolean }
export interface PortalOpciones {
  sucursales: LookupItem[]; comprobantes: LookupItem[]; centros: LookupItem[];
  vendedores: LookupItem[]; formasPago: LookupItem[];
}
export interface ProductoMovil {
  id: number; codigo: string; nombre: string; precio: number; descuento: number;
  iva: number; moneda: string; cantidadStock: boolean;
}
export interface VentaMovil {
  cliente: number; sucursal: number; tipoComprobante: number; talonario: number;
  centroCosto: number; vendedor: number; formaPago: number; observaciones: string;
  productos: { producto: number; cantidad: number; cantidadStock?: number }[];
}
export interface RevisionMovil {
  token: string; resumen: ChatVenta;
  impuestos: { nombre: string; alicuota: number; importe: number }[];
}
export interface CuentaMovil {
  saldo: number; saldoAnterior: number;
  movimientos: { id: number; fecha: string; concepto: string; movimiento: string;
    debito: number; credito: number; saldo: number }[];
}

export interface FieldSchema {
  name: string;
  label: string;
  type: FieldType;
  nullable: boolean;
  required: boolean;
  maxLength?: number;
  hidden: boolean;
  sensitive: boolean;
  advanced?: boolean;
  visibleWhen?: string;
  lookup?: string;
  default?: unknown;
  options?: LookupItem[];
}

export interface AccionSchema {
  key: string;
  menu: 'Imprimir' | 'Operaciones' | string;
  titulo: string;
  seleccion: 'Ninguna' | 'Una' | 'Varias';
  confirmacion?: string;
  campos: FieldSchema[];
  tieneCamposDinamicos: boolean;
  soloEscritorio?: string;
  separador: boolean;
}

export interface AccionResultado {
  navegar?: string;
  imagenesTabla?: string;
  imagenesId?: number;
  parametros?: Record<string, unknown>;
  mensaje?: string;
  titulo?: string;
  refrescar: boolean;
  html?: string;
  pdf?: { nombre: string; contentType: string; base64: string };
  archivo?: { nombre: string; contentType: string; base64: string };
  imprimirGrilla: boolean;
  horizontal: boolean;
  tablas?: TablaResultado[];
  alta?: AltaPrecargada;
}

export interface DependentLookups {
  lookups: Lookups;
  valores?: Row;
}

/** Datos para abrir el alta de otra pantalla con valores y detalles precargados. */
export interface AltaPrecargada {
  pantalla: string;
  valores: Row;
  detalles: Record<string, Row[]>;
}

export interface ColeccionSchema {
  name: string;
  label: string;
  puedeQuitar: boolean;
  campos: FieldSchema[];
  lookups: string[];
}

export interface ScreenSchema {
  tipo: 'normal' | 'consulta' | 'hijo' | 'proceso' | 'alta' | 'edicion';
  edicion?: { selector: string; editables: string[]; clave: string } | null;
  colecciones: ColeccionSchema[];
  key: string;
  titulo: string;
  area: string;
  formulario: string;
  modulo: string;
  parametros: FieldSchema[];
  columnas: FieldSchema[];
  camposEdicion: FieldSchema[];
  parametrosGuardar: FieldSchema[];
  detalles: string[];
  acciones: AccionSchema[];
  lookups: string[];
  permisos: { buscar: boolean; agregar: boolean; modificar: boolean; eliminar: boolean };
  informe?: boolean;
  textoBoton?: string | null;
  descripcion?: string | null;
}

export interface MenuArea {
  area: string;
  pantallas: { key: string; titulo: string }[];
}

export interface Usuario {
  id: number;
  nombre: string;
  empresa: string;
  esAdministrador: boolean;
}

export type Row = Record<string, unknown>;
export type Lookups = Record<string, LookupItem[]>;

export interface TileInicio {
  id: number;
  grupo: number;
  titulo: string;
  subtitulo: string;
  pantalla: string;
  orden: number;
  tamano: TamanoTile;
  tamanoDefecto: TamanoTile;
  colorDefecto: string;
  color1?: string | null;
  color2?: string | null;
  colorFuente?: string | null;
  visible: boolean;
}

export interface InicioConfig {
  colorFondo?: string | null;
  mostrarTitulos: boolean;
  guardaEnBase: boolean;
  grupos: GrupoInicio[];
  tiles: TileInicio[];
}

export type TamanoTile = 'Small' | 'Medium' | 'Wide' | 'Large';

export interface GrupoInicio {
  id: number;
  titulo: string;
  colorTitulo?: string | null;
}
export interface BasesInfo {
  sistema: string;
  web?: string;
  bases: string[];
  desarrollo?: boolean;
  login?: { titulo?: string; mensaje?: string; color?: string; pie?: string; imagen: boolean };
}

export interface ChatEstado {
  habilitado: boolean;
  permitido: boolean;
  configurado: boolean;
  modelo: string;
  tokensMes: number;
  limiteMes: number;
}

export interface ChatMensaje {
  rol: 'usuario' | 'asistente';
  texto: string;
}

export interface ChatResultado {
  sql: string;
  columnas: string[];
  filas: unknown[][];
  truncado: boolean;
}

export interface ChatRespuesta {
  respuesta: string;
  resultado?: ChatResultado | null;
  consultas: string[];
  tokensPregunta: number;
  tokensMes: number;
  limiteMes: number;
  venta?: ChatVenta | null;
}

export interface ChatVentaSolicitud {
  cliente: string;
  sucursal?: string;
  tipoComprobante?: string;
  formaPago?: string;
  productos: { producto: string; cantidad: number }[];
}

export interface ChatVenta {
  solicitud: ChatVentaSolicitud;
  cliente: string;
  sucursal: string;
  tipoComprobante: string;
  formaPago: string;
  lineas: { producto: string; moneda: string; cantidad: number; precioUnitario: number; descuento: number; iva: number; total: number }[];
  total: number;
  advertencias: string[];
}

export interface ImagenGaleria { id: number; descripcion: string; idCategoria: number; orden: number; fecha: string; datos: string }
export interface ImagenesGaleria { categorias: { key: number; name: string }[]; imagenes: ImagenGaleria[] }
