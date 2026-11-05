using System;
using System.Collections.Generic;

namespace VENET_Contabilidad_BL
{
    // Los valores persistidos no se renumeran. Cada operatoria admite N plantillas.
    public enum OperatoriaContable
    {
        Venta = 1, Compra = 2, Cobranza = 3, Pago = 4,
        CostoVenta = 5, MovimientoStock = 6, TransferenciaFondos = 7,
        LiquidacionSueldos = 8, Devengamiento = 9, Ajuste = 10, Apertura = 11, Cierre = 12, CostoVentaAutomatico = 13
    }
    public enum OrigenContable { Cabecera = 1, Productos = 2, Impuestos = 3, MediosPago = 4, Conceptos = 5, Saldos = 6 }
    public enum MagnitudContable { Total = 1, Neto = 2, Iva = 3, Importe = 4, Costo = 5, SaldoDeudor = 6, SaldoAcreedor = 7 }
    public enum LadoContable { Debe = 1, Haber = 2 }
    public enum DimensionCuenta { Empresa = 1, Producto = 2, Categoria = 3, Cliente = 4, Proveedor = 5, FormaPago = 6, Impuesto = 7, Especie = 8, MedioTesoreria = 9, Componente = 10, Caja = 11, Personal = 12, Concepto = 13, CuentaOrigen = 14 }
    public enum MedioTesoreria { Efectivo = 1, ChequeTercero = 2, ChequePropio = 3, CuentaCorriente = 4, TarjetaDebito = 5, TarjetaCredito = 6, RetencionPercepcion = 7 }
    public enum ComponenteContable { PercepcionIva = 1, PercepcionIIBB = 2, PercepcionGanancias = 3, OtrosImpuestos = 4, ImpuestoNoGravado = 5, ITC = 6, PercepcionIIBBCapital = 7, DescuentoCompra = 8, RetencionesVenta = 9 }

    public sealed class ConfiguracionContable
    {
        public int Empresa { get; set; }
        public int Version { get; set; }
        public int MonedaBase { get; set; }
        public List<PlantillaContable> Plantillas { get; set; } = new List<PlantillaContable>();
        public List<AsignacionCuenta> Asignaciones { get; set; } = new List<AsignacionCuenta>();
    }
    public sealed class PlantillaContable
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public OperatoriaContable Operatoria { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public int? TipoComprobante { get; set; }
        public int? Sucursal { get; set; }
        public bool Invertir { get; set; }
        public List<ReglaContable> Reglas { get; set; } = new List<ReglaContable>();
    }
    public sealed class ReglaContable
    {
        public OrigenContable Origen { get; set; }
        public MagnitudContable Magnitud { get; set; }
        public LadoContable Lado { get; set; }
        public decimal Factor { get; set; } = 1m;
        public int? CuentaFija { get; set; }
        public string Rol { get; set; }
        public List<DimensionCuenta> Prioridad { get; set; } = new List<DimensionCuenta>();
        public int? Producto { get; set; }
        public int? Categoria { get; set; }
        public int? Impuesto { get; set; }
        public int? FormaPago { get; set; }
        public int? Concepto { get; set; }
        public int? Caja { get; set; }
    }
    public sealed class AsignacionCuenta
    {
        public string Rol { get; set; }
        public DimensionCuenta Dimension { get; set; }
        public int Referencia { get; set; }
        public int Cuenta { get; set; }
    }
    public sealed class HechoContable
    {
        public int Empresa { get; set; }
        public OperatoriaContable Operatoria { get; set; }
        public int Documento { get; set; }
        public DateTime Fecha { get; set; }
        public int Sucursal { get; set; }
        public int TipoComprobante { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public decimal Neto { get; set; }
        public decimal Iva { get; set; }
        public int? Cliente { get; set; }
        public int? Proveedor { get; set; }
        public int? FormaPago { get; set; }
        public int CentroCosto { get; set; }
        public List<PartidaOrigen> Partidas { get; set; } = new List<PartidaOrigen>();
    }
    public sealed class PartidaOrigen
    {
        public OrigenContable Origen { get; set; }
        public string Referencia { get; set; }
        public int? Producto { get; set; }
        public int? Categoria { get; set; }
        public int? Impuesto { get; set; }
        public int? FormaPago { get; set; }
        public int? Especie { get; set; }
        public MedioTesoreria? Medio { get; set; }
        public ComponenteContable? Componente { get; set; }
        public decimal Total { get; set; }
        public decimal Neto { get; set; }
        public decimal Iva { get; set; }
        public decimal Importe { get; set; }
        public decimal? Costo { get; set; }
        public int? Caja { get; set; }
        public int? Personal { get; set; }
        public int? Concepto { get; set; }
        public int? CuentaOrigen { get; set; }
        public decimal SaldoDeudor { get; set; }
        public decimal SaldoAcreedor { get; set; }
    }
    public sealed class RenglonContable
    {
        public int Cuenta { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public int Regla { get; set; }
        public string Origen { get; set; }
        public string Resolucion { get; set; }
    }
    public sealed class AsientoPropuesto
    {
        public string Plantilla { get; set; }
        public string Descripcion { get; set; }
        public List<RenglonContable> Renglones { get; set; } = new List<RenglonContable>();
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
    }
    public sealed class SimulacionContable
    {
        public int Version { get; set; }
        public HechoContable Hecho { get; set; }
        public List<AsientoPropuesto> Asientos { get; set; }
        public string Firma { get; set; }
    }
}
