import type { LookupItem } from '../../types';

export interface OpcionesCompraDocumento {
  configurado: boolean; modelo: string | null;
  sucursales: LookupItem[]; proveedores: LookupItem[]; tipos: LookupItem[]; depositos: LookupItem[];
  centros: LookupItem[]; formas: LookupItem[]; monedas: LookupItem[]; alicuotas: number[];
}
export interface ItemCompraDocumento {
  codigo: string | null; descripcion: string | null; unidad: string | null;
  cantidad: number | null; precioNeto: number | null; descuento: number | null; iva: number | null; total: number | null; tipoTotal: 'Neto' | 'ConIva' | null;
  producto: number | null; cantidadStock: number | null; recordarEquivalencia: boolean;
}
export interface DocumentoCompraLeido {
  proveedor: string | null; cuit: string | null; tipo: string | null; letra: string | null;
  puntoVenta: string | null; numero: string | null; fecha: string | null; moneda: string | null;
  total: number | null; neto: number | null; iva: number | null; noGravado: number | null; otrosImpuestos: number | null;
  percepcionIva: number | null; percepcionIibb: number | null; percepcionGanancias: number | null;
  itc: number | null; percepcionIibbCapital: number | null; descuento: number | null;
  items: ItemCompraDocumento[]; advertencias: string[];
}
export interface RevisionCompraDocumento {
  id: string; version: number; sucursal: number; proveedor: number; tipoComprobante: number; deposito: number;
  centroCosto: number; formaPago: number; moneda: number; cotizacion: number; recepcion: string; vencimiento: string;
  revisado: boolean; documento: DocumentoCompraLeido;
}
export interface ImportacionCompra {
  id: string; version: number; sucursal: number; estado: string; error: string | null; fecha: string; compra: number | null;
  lectura: DocumentoCompraLeido | null; revision: RevisionCompraDocumento | null; archivos: string[];
}
export interface ResultadoRevisionCompra {
  total: number; neto: number; iva: number; firma: string | null; errores: string[]; advertencias: string[]; compra: number | null;
}
