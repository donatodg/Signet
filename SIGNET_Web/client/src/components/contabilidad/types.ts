import type { LookupItem } from '../../types';

export interface Regla {
  origen: number; magnitud: number; lado: number; factor: number; cuentaFija: number | null;
  rol: string | null; prioridad: number[]; producto: number | null; categoria: number | null;
  impuesto: number | null; formaPago: number | null;
  concepto?: number | null; caja?: number | null;
}
export interface Plantilla {
  codigo: string; nombre: string; operatoria: number; desde: string; hasta: string | null;
  tipoComprobante: number | null; sucursal: number | null; invertir: boolean; reglas: Regla[];
}
export interface Asignacion { rol: string; dimension: number; referencia: number; cuenta: number }
export interface Configuracion {
  empresa: number; version: number; monedaBase: number; plantillas: Plantilla[]; asignaciones: Asignacion[];
}
export interface Estado {
  ingresar: boolean;
  bandeja: boolean; registrarBandeja: boolean; aprobar: boolean;
  automatizacion: boolean; editarAutomatizacion: boolean;
  periodos: boolean; bloquearPeriodos: boolean; reabrirPeriodos: boolean;
  conciliar: boolean; exportar: boolean;
  configurar: boolean; editar: boolean; simular: boolean; registrar: boolean; diario: boolean; revertir: boolean;
  empresas: LookupItem[];
}
export interface Catalogos {
  cajas?: LookupItem[];
  cuentas: LookupItem[]; monedas: LookupItem[]; sucursales: LookupItem[]; comprobantes: LookupItem[];
  operatorias: LookupItem[]; origenes: LookupItem[]; magnitudes: LookupItem[]; lados: LookupItem[];
  dimensiones: LookupItem[]; medios: LookupItem[];
  ejercicios: LookupItem[];
}
export interface Asiento {
  plantilla: string; descripcion: string; debe: number; haber: number;
  renglones: { cuenta: number; debe: number; haber: number; regla: number; origen: string; resolucion: string }[];
}
export interface Simulacion {
  version: number; firma: string; asientos: Asiento[];
  hecho: { empresa: number; operatoria: number; documento: number; fecha: string; descripcion: string; total: number };
}
export interface Registro {
  id: number; empresa: number; operatoria: number; documento: number; fecha: string; usuario: number;
  reversionDe: number | null; asientos: number[]; simulacion: Simulacion;
}
export interface Solicitud { empresa: number; operatoria: number; documento: number; firma?: string }
export interface PartidaComplementaria {
  origen: number; referencia: string; importe: number; producto: number | null; concepto: number | null; personal: number | null;
}
export interface DocumentoComplementario {
  id?: number; clave: string; moneda: number; respaldo: string;
  hecho: { empresa: number; operatoria: number; sucursal: number; fecha: string; descripcion: string; partidas: PartidaComplementaria[] };
}
export interface Saldo {
  cuenta: number; nombre: string; anterior: number; debe: number; haber: number; saldo: number;
}
export interface Mayor {
  anterior: number; saldo: number;
  movimientos: { asiento: number; numero: number; fecha: string; descripcion: string; debe: number; haber: number; saldo: number }[];
}
export interface Politica { operatoria: number; modo: number; usuarioAutomatico: number | null; desde: string }
export interface Operativa {
  empresa: number; activa: boolean; moneda: number; capturarCosto: boolean; dobleControl: boolean; version: number; politicas: Politica[];
}
export interface Pendiente {
  id: number; empresa: number; operatoria: number; documento: number; sucursal: number; usuarioOrigen: number | null;
  fecha: string; estado: number; intentos: number; error: string | null; firma: string | null; lote: number | null;
  anulado: boolean; descripcion: string | null; aprobado: boolean;
}
export interface RevisionLote { documento: number; operatoria: number; simulacion?: Simulacion; error?: string | null }
export interface Periodo { mes: string; cerrado: boolean; usuario: number; fecha: string; motivo: string }
export interface Clasificacion { cuentas: { cuenta: number; clase: number; rubro: string }[]; cajas: { caja: number; cuenta: number }[] }
export type FilaInforme = Record<string, string | number | boolean | null>;
