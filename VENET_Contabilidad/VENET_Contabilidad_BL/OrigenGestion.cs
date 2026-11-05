using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using VENET_Comun;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public static class OrigenGestion
    {
        public static HechoContable Transferencia(Transferencias t, Cajas origen, Cajas destino, int empresaOrigen, int empresaDestino,
            System.Collections.Generic.IList<EspeciesCtaCte> movimientos)
        {
            if (t == null || origen == null || destino == null || t.Id <= 0 || t.UserDel != null
                || t.FechaAdd.Year < 1753 || t.Importe <= 0 || t.Cotizacion_Origen <= 0 || t.Cotizacion_Destino <= 0
                || origen.Id != t.Id_Caja_Origen || destino.Id != t.Id_Caja_Destino || origen.Id == destino.Id
                || empresaOrigen <= 0 || empresaOrigen != empresaDestino)
                throw new ValidationException("Transferencia invalida o entre empresas distintas; requiere tratamiento interempresa.");
            var salida = movimientos.Where(m => m.Id_Caja == origen.Id && m.Id_Comprobante == t.Id
                && m.Id_TipoComprobante == (int)Enums.TipoComprobante.Transferencia && m.UserDel == null).ToList();
            var entrada = movimientos.Where(m => m.Id_Caja == destino.Id && m.Id_Comprobante == t.Id
                && m.Id_TipoComprobante == (int)Enums.TipoComprobante.Transferencia && m.UserDel == null).ToList();
            if (salida.Count != 1 || entrada.Count != 1 || salida[0].Debito != 0 || entrada[0].Credito != 0
                || salida[0].Credito != t.Importe || entrada[0].Debito <= 0)
                throw new ValidationException("La transferencia no tiene sus dos movimientos de caja completos.");
            var importeSalida = decimal.Round(salida[0].Credito * t.Cotizacion_Origen, 2, MidpointRounding.AwayFromZero);
            var importeEntrada = decimal.Round(entrada[0].Debito * t.Cotizacion_Destino, 2, MidpointRounding.AwayFromZero);
            if (importeSalida != importeEntrada)
                throw new ValidationException("La transferencia tiene una diferencia de cambio/redondeo. Debe registrarse explicitamente, no ocultarse.");
            return new HechoContable
            {
                Empresa = empresaOrigen,
                Operatoria = OperatoriaContable.TransferenciaFondos,
                Documento = t.Id,
                Fecha = t.FechaAdd.Date,
                Sucursal = origen.Id_Sucursal,
                CentroCosto = t.Id_CentroCosto,
                TipoComprobante = (int)Enums.TipoComprobante.Transferencia,
                Descripcion = t.Descripcion,
                Total = importeSalida,
                Partidas = new System.Collections.Generic.List<PartidaOrigen> {
                    new PartidaOrigen { Origen = OrigenContable.MediosPago, Referencia = "Caja destino #" + destino.Id,
                        Caja = destino.Id, Especie = destino.Id_Especie, Importe = importeEntrada, Total = importeEntrada },
                    new PartidaOrigen { Origen = OrigenContable.MediosPago, Referencia = "Caja origen #" + origen.Id,
                        Caja = origen.Id, Especie = origen.Id_Especie, Importe = -importeSalida, Total = importeSalida }
                }
            };
        }
        public static HechoContable Obtener(OperatoriaContable operacion, int id, System.Data.Common.DbConnection conexion = null, System.Data.Common.DbTransaction transaccion = null)
        {
            if (id <= 0) throw new ValidationException("Indique el ID del documento original.");
            using (var db = Gestion(conexion, transaccion))
            {
                if (operacion == OperatoriaContable.Venta)
                {
                    var c = db.ComprobantesVentas.Include(x => x.Detalle).Include(x => x.Impuestos)
                        .SingleOrDefault(x => x.Id == id && x.UserDel == null)
                        ?? throw new ValidationException("No se encontro la venta.");
                    if (!c.FechaLiquidacion.HasValue || c.FechaAnulacion.HasValue)
                        throw new ValidationException("Solo se contabilizan ventas confirmadas y no anuladas.");
                    if (c.Id_TipoEntidad != Enums.TipoEntidad.Cliente)
                        throw new ValidationException("El adaptador de ventas requiere una entidad cliente.");
                    var h = Cabecera(db, operacion, id, c.Id_Sucursal, c.FechaLiquidacion.Value, c.Comprobante, c.Id_CentroCosto);
                    h.TipoComprobante = c.Id_TipoComprobante; h.Cliente = c.Id_Entidad; h.FormaPago = c.Id_FormaPago;
                    var productos = c.Detalle.Where(d => d.UserDel == null).Select(d => d.Id_Producto).ToList();
                    var categorias = db.Productos.Where(p => productos.Contains(p.Id)).ToDictionary(p => p.Id, p => p.Id_Categoria);
                    foreach (var d in c.Detalle.Where(d => d.UserDel == null).OrderBy(d => d.Id))
                    {
                        if (d.Cotizacion <= 0) throw new ValidationException("Cotizacion de venta no valida.");
                        h.Partidas.Add(new PartidaOrigen
                        {
                            Origen = OrigenContable.Productos,
                            Referencia = "Detalle #" + d.Id,
                            Producto = d.Id_Producto,
                            Categoria = d.Id_Producto.HasValue && categorias.ContainsKey(d.Id_Producto.Value) ? (int?)categorias[d.Id_Producto.Value] : null,
                            Especie = d.Id_Especie,
                            Total = d.Importe * d.Cotizacion,
                            Neto = (d.Importe - d.ImporteIVA) * d.Cotizacion,
                            Iva = d.ImporteIVA * d.Cotizacion,
                            Importe = d.Importe * d.Cotizacion
                        });
                    }
                    foreach (var i in c.Impuestos.Where(i => i.UserDel == null).OrderBy(i => i.Id))
                        h.Partidas.Add(new PartidaOrigen
                        {
                            Origen = OrigenContable.Impuestos,
                            Referencia = "Impuesto #" + i.Id,
                            Impuesto = i.Id_Impuesto,
                            Importe = i.Importe,
                            Total = i.Importe
                        });
                    Componente(h, ComponenteContable.OtrosImpuestos, c.OtrosImpuestos);
                    Componente(h, ComponenteContable.PercepcionIIBB, c.PercepcionIIBB);
                    Componente(h, ComponenteContable.PercepcionIva, c.PercepcionIva);
                    Componente(h, ComponenteContable.RetencionesVenta, c.Retenciones);
                    Totales(h);
                    return h;
                }
                if (operacion == OperatoriaContable.Compra)
                {
                    var c = db.ComprobantesCompras.Include(x => x.Detalle).SingleOrDefault(x => x.Id == id && x.UserDel == null)
                        ?? throw new ValidationException("No se encontro la compra.");
                    if (!c.FechaLiquidacion.HasValue || c.FechaAnulacion.HasValue || c.Id_TipoEntidad != Enums.TipoEntidad.Proveedor)
                        throw new ValidationException("Se requiere una compra confirmada, no anulada y de proveedor.");
                    var h = Cabecera(db, operacion, id, c.Id_Sucursal, c.FechaLiquidacion.Value, c.Comprobante, c.Id_CentroCosto);
                    h.TipoComprobante = c.Id_TipoComprobante; h.Proveedor = c.Id_Entidad; h.FormaPago = c.Id_FormaPago;
                    foreach (var d in c.Detalle.Where(d => d.UserDel == null).OrderBy(d => d.Id))
                    {
                        if (d.Cotizacion <= 0) throw new ValidationException("Cotizacion de compra no valida.");
                        h.Partidas.Add(new PartidaOrigen
                        {
                            Origen = OrigenContable.Productos,
                            Referencia = "Detalle #" + d.Id,
                            Producto = d.Id_Producto,
                            Categoria = db.Productos.Where(p => p.Id == d.Id_Producto).Select(p => (int?)p.Id_Categoria).FirstOrDefault(),
                            Especie = d.Id_Especie,
                            Total = d.Importe * d.Cotizacion,
                            Neto = (d.Importe - d.ImporteIVA) * d.Cotizacion,
                            Iva = d.ImporteIVA * d.Cotizacion,
                            Importe = d.Importe * d.Cotizacion
                        });
                    }
                    Componente(h, ComponenteContable.PercepcionIva, c.PercepcionIva);
                    Componente(h, ComponenteContable.OtrosImpuestos, c.OtrosImpuestos);
                    Componente(h, ComponenteContable.PercepcionGanancias, c.PercepcionGanancias);
                    Componente(h, ComponenteContable.PercepcionIIBB, c.PercepcionIIBB);
                    Componente(h, ComponenteContable.ImpuestoNoGravado, c.ImpuestoNoGravado);
                    Componente(h, ComponenteContable.ITC, c.ITC);
                    Componente(h, ComponenteContable.PercepcionIIBBCapital, c.PercepcionIIBBCapital);
                    Componente(h, ComponenteContable.DescuentoCompra, -c.Descuento);
                    Totales(h);
                    return h;
                }
            }
            if (operacion == OperatoriaContable.TransferenciaFondos)
                using (var db = Tesoreria(conexion, transaccion))
                {
                    var t = db.Transferencias.SingleOrDefault(x => x.Id == id && x.UserDel == null)
                        ?? throw new ValidationException("No se encontro la transferencia.");
                    var origen = db.Cajas.SingleOrDefault(c => c.Id == t.Id_Caja_Origen && c.UserDel == null);
                    var destino = db.Cajas.SingleOrDefault(c => c.Id == t.Id_Caja_Destino && c.UserDel == null);
                    if (origen == null || destino == null) throw new ValidationException("Falta una caja de la transferencia.");
                    var empresaOrigen = db.Sucursales.Where(s => s.Id == origen.Id_Sucursal).Select(s => s.Id_Empresa).Single();
                    var empresaDestino = db.Sucursales.Where(s => s.Id == destino.Id_Sucursal).Select(s => s.Id_Empresa).Single();
                    return Transferencia(t, origen, destino, empresaOrigen, empresaDestino, db.EspeciesCtaCte.Where(m =>
                        m.Id_Comprobante == id && m.Id_TipoComprobante == (int)Enums.TipoComprobante.Transferencia && m.UserDel == null).ToList());
                }
            if (operacion == OperatoriaContable.Cobranza || operacion == OperatoriaContable.Pago)
                using (var db = Tesoreria(conexion, transaccion))
                using (var gestion = Gestion(conexion, transaccion))
                {
                    if (operacion == OperatoriaContable.Cobranza)
                    {
                        var c = db.Recibos.Include(x => x.Detalle).SingleOrDefault(x => x.Id == id && x.UserDel == null)
                            ?? throw new ValidationException("No se encontro el recibo.");
                        if (!c.Fecha_Liquidacion.HasValue || c.Fecha_Anulacion.HasValue || c.TipoEntidad != Enums.TipoEntidad.Cliente)
                            throw new ValidationException("Se requiere un recibo confirmado, no anulado y de cliente.");
                        var h = Cabecera(gestion, operacion, id, c.Id_Sucursal, c.Fecha_Liquidacion.Value, c.Concepto, c.Id_CentroCosto);
                        h.Cliente = c.Id_Entidad;
                        foreach (var d in c.Detalle.Where(d => d.UserDel == null).OrderBy(d => d.Id))
                            h.Partidas.Add(Pago(d.Id, d.Id_Especie, d.Cotizacion, d.Importe,
                                d.Id_Documento > 0 ? MedioTesoreria.ChequeTercero : d.Id_TipoEntidad > 0 ? MedioTesoreria.CuentaCorriente
                                : d.TarjetaDebito == true ? MedioTesoreria.TarjetaDebito : d.TarjetaCredito == true ? MedioTesoreria.TarjetaCredito
                                : d.Id_TipoPercepcion > 0 ? MedioTesoreria.RetencionPercepcion : MedioTesoreria.Efectivo));
                        Totales(h); return h;
                    }
                    else
                    {
                        var c = db.OrdenesPago.Include(x => x.Detalle).Include(x => x.Impuestos).SingleOrDefault(x => x.Id == id && x.UserDel == null)
                            ?? throw new ValidationException("No se encontro la orden de pago.");
                        if (!c.Fecha_Liquidacion.HasValue || c.Fecha_Anulacion.HasValue || c.TipoEntidad != Enums.TipoEntidad.Proveedor)
                            throw new ValidationException("Se requiere una orden confirmada, no anulada y de proveedor.");
                        var h = Cabecera(gestion, operacion, id, c.Id_Sucursal, c.Fecha_Liquidacion.Value, c.Concepto, c.Id_CentroCosto);
                        h.Proveedor = c.Id_Entidad;
                        foreach (var d in c.Detalle.Where(d => d.UserDel == null).OrderBy(d => d.Id))
                            h.Partidas.Add(Pago(d.Id, d.Id_Especie, d.Cotizacion, d.Importe,
                                d.Id_Documento > 0 ? MedioTesoreria.ChequeTercero : d.Id_DocumentoPropio > 0 ? MedioTesoreria.ChequePropio
                                : d.Id_TipoEntidad > 0 ? MedioTesoreria.CuentaCorriente : MedioTesoreria.Efectivo));
                        foreach (var i in c.Impuestos.Where(i => i.UserDel == null).OrderBy(i => i.Id))
                            h.Partidas.Add(new PartidaOrigen
                            {
                                Origen = OrigenContable.Impuestos,
                                Referencia = "Retencion #" + i.Id,
                                Impuesto = i.Id_Impuesto,
                                Importe = i.Importe,
                                Total = i.Importe
                            });
                        Totales(h); return h;
                    }
                }
            throw new ValidationException("Esta operatoria todavia no tiene adaptador a un documento de gestion. No se infieren importes ni costos.");
        }

        private static HechoContable Cabecera(GestionContext db, OperatoriaContable op, int id, int sucursal, DateTime fecha, string descripcion, int centro)
        {
            var empresa = db.Sucursales.Where(s => s.Id == sucursal && s.UserDel == null).Select(s => s.Id_Empresa).Single();
            return new HechoContable
            {
                Empresa = empresa,
                Operatoria = op,
                Documento = id,
                Sucursal = sucursal,
                Fecha = fecha.Date,
                Descripcion = descripcion,
                CentroCosto = centro
            };
        }
        private static GestionContext Gestion(System.Data.Common.DbConnection conexion, System.Data.Common.DbTransaction tx)
        {
            var db = conexion == null ? new GestionContext() : new GestionContext(conexion, false);
            if (tx != null) db.Database.UseTransaction(tx);
            return db;
        }
        private static TesoreriaContext Tesoreria(System.Data.Common.DbConnection conexion, System.Data.Common.DbTransaction tx)
        {
            var db = conexion == null ? new TesoreriaContext() : new TesoreriaContext(conexion, false);
            if (tx != null) db.Database.UseTransaction(tx);
            return db;
        }
        private static PartidaOrigen Pago(int id, int especie, decimal cotizacion, decimal importe, MedioTesoreria medio)
        {
            if (cotizacion <= 0) throw new ValidationException("Cotizacion de tesoreria no valida.");
            return new PartidaOrigen
            {
                Origen = OrigenContable.MediosPago,
                Referencia = "Medio #" + id,
                Especie = especie,
                Medio = medio,
                Importe = importe * cotizacion,
                Total = importe * cotizacion
            };
        }
        private static void Totales(HechoContable h)
        {
            if (h.Partidas.Count == 0) throw new ValidationException("El documento no tiene partidas contabilizables.");
            h.Total = h.Partidas.Sum(p => p.Total);
            h.Neto = h.Partidas.Sum(p => p.Neto);
            h.Iva = h.Partidas.Sum(p => p.Iva);
        }
        private static void Componente(HechoContable h, ComponenteContable componente, decimal importe)
        {
            if (importe == 0) return;
            h.Partidas.Add(new PartidaOrigen
            {
                Origen = OrigenContable.Impuestos,
                Referencia = componente.ToString(),
                Componente = componente,
                Importe = importe,
                Total = importe
            });
        }
    }
}
