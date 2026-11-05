namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ComprobantesComprasManager : IDisposable
    {
        private GestionContext db;
        public ComprobantesCompras Comprobante { get; set; }

        public ComprobantesComprasManager(ComprobantesCompras o) : this(o, null, null) { }

        public ComprobantesComprasManager(ComprobantesCompras o, System.Data.Common.DbConnection conexion, System.Data.Common.DbTransaction transaccion)
        {
            db = conexion == null ? new GestionContext() : new GestionContext(conexion, false);
            if (transaccion != null) db.Database.UseTransaction(transaccion);
            Comprobante = o;

            db.ComprobantesCompras.Attach(Comprobante);

            if (Comprobante.Id > 0)
            {
                db.Entry(Comprobante).Reload();

                if (Comprobante.Detalle == null)
                    db.Entry(Comprobante).Collection(p => p.Detalle).Load();

                if (Comprobante.Detalle.Count > 0)
                {
                    foreach (ComprobantesComprasDetalle row in Comprobante.Detalle)
                    {
                        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();
                    }
                }
            }
            else
            {
                Comprobante.Fecha = Comprobante.FechaRecepcion = Comprobante.FechaVto = Sistema.ObtenerFechaHora();
                db.Entry(Comprobante).Collection(p => p.Detalle).Load();
                Comprobante.Observaciones = "-";
                //Comprobante.Id_TipoFacturacion = 1;

                try
                {
                    //if (Sistema.CentrosCostos.Count() > 0)
                    Comprobante.Id_CentroCosto = Sistema.CentrosCostos.First().Key;
                    //if (Vendedores.Count() > 0)
                    //if (Sistema.FormasPagos.Count() > 0)
                    Comprobante.Id_FormaPago = Sistema.FormasPagos.First().Key;
                    Comprobante.Id_TipoEntidad = Enums.TipoEntidad.Proveedor;
                    Comprobante.Id_Deposito = Sistema.Depositos.First().Key;
                }
                catch { }
            }
        }

        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new GestionContext())
                    return Sistema.ObtenerEntidades(Comprobante.Id_TipoEntidad);
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Comprobante.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");
            if (Comprobante.Fecha > Comprobante.FechaRecepcion) throw new ValidationException("La fecha es posterior a la fecha de entrega.");
            //if (Comprobante.Fecha > Comprobante.FechaVto) throw new ValidationException("La fecha es posterior a la fecha de vencimiento.");
            if (db.ComprobantesCompras.Where(t => t.Id != Comprobante.Id && t.Id_TipoComprobante == Comprobante.Id_TipoComprobante && t.Id_TipoEntidad == Comprobante.Id_TipoEntidad && t.Id_Entidad == Comprobante.Id_Entidad && t.Letra == Comprobante.Letra && t.PuntoVenta == Comprobante.PuntoVenta && t.NroComprobante == Comprobante.NroComprobante && t.FechaAnulacion == null && t.UserDel == null).Count() > 0) throw new ValidationException("El comprobante ya fue ingresado.");

            if (Comprobante.Id == 0)
            {
                db.Entry(Comprobante).State = EntityState.Added;
                Comprobante.FechaAdd = Sistema.ObtenerFechaHora();
                Comprobante.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Comprobante).State = EntityState.Modified;
                Comprobante.FechaMod = Sistema.ObtenerFechaHora();
                Comprobante.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            Comprobante.Importe = Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe).Sum() + Comprobante.ImpuestoNoGravado + Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.PercepcionGanancias + Comprobante.ITC + Comprobante.PercepcionIIBBCapital - Comprobante.Descuento;
            Comprobante.ImportePesos = Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe * t.Cotizacion).Sum() + Comprobante.ImpuestoNoGravado + Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.PercepcionGanancias + Comprobante.ITC + Comprobante.PercepcionIIBBCapital - Comprobante.Descuento;


            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));


            db.SaveChanges();

            bool Flag = false;

            using (var db1 = new GestionContext())
            {
                Flag = false;
                foreach (ComprobantesComprasDetalle row in Comprobante.Detalle.Where(t => t.Borrado == true))
                {
                    ComprobantesComprasDetalle o = new ComprobantesComprasDetalle() { Id = row.Id };
                    db1.ComprobantesComprasDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(ComprobantesCompras o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesCompra_PermiteEliminar)))
                {
                    if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un comprobante anulado.");
                    if (o.FechaLiquidacion != null) throw new ValidationException("No se puede eliminar un comprobante liquidado.");
                }

                var db1 = new GestionContext();
                bool Flag = false;

                foreach (EntidadesCtaCte ecc in (db.EntidadesCtaCte.Where(t => t.UserDel == null &&
                                                                               t.Id_TipoEntidad == o.Id_TipoEntidad &&
                                                                               t.Id_Entidad == o.Id_Entidad &&
                                                                               t.Id_TipoComprobante == o.Id_TipoComprobante &&
                                                                               t.Id_Comprobante == o.Id).ToList()))
                {
                    db1.EntidadesCtaCte.Attach(ecc);
                    db1.Entry(ecc).Reload();
                    db1.Entry(ecc).State = EntityState.Modified;

                    ecc.FechaDel = Sistema.ObtenerFechaHora();
                    ecc.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    Flag = true;
                }

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
                if (Flag) db1.SaveChanges();
            }
        }

        public static string Confirmar(ComprobantesCompras o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un comprobante anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede confirmar un comprobante liquidado.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                TipoComprobante tc = new TipoComprobante() { Id = o.Id_TipoComprobante };
                db.Entry(tc).State = EntityState.Unchanged;
                db.Entry(tc).Reload();


                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaLiquidacion = o.FechaMod = Sistema.ObtenerFechaHora();

                string Nombre = Sistema.GetNombreEntidad(o.Id_TipoEntidad, o.Id_Entidad);

                List<EspeciesCantidad> r = (from d in o.Detalle
                                            where d.UserDel == null
                                            group d by d.Id_Especie into g
                                            orderby g.Sum(x => x.Importe)
                                            select new EspeciesCantidad
                                            {
                                                Id_Especie = g.Key,
                                                Importe = g.Sum(x => x.Importe)
                                            }).ToList();


                int i = 0;

                foreach (EspeciesCantidad od in r)
                {
                    i += 1;

                    int Id_Caja = (from c in db.Cajas
                                   where Seguridad.IdCajasAsignadas.Contains(c.Id) &&
                                         c.Id_Sucursal == o.Id_Sucursal &&
                                         c.Id_Especie == od.Id_Especie
                                   select c.Id).FirstOrDefault();

                    if (Id_Caja == 0)
                    {
                        string Especie = (from e in db.Especies where e.Id == od.Id_Especie select e.Descripcion).FirstOrDefault();
                        throw new ValidationException(string.Format("La Caja para la especie {0} no existe o el usuario no tiene su asignación.", Especie));
                    }

                    if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito || tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito)
                    {
                        EspeciesCtaCte ecc = new EspeciesCtaCte()
                        {
                            Id_CentroCosto = o.Id_CentroCosto,
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_Caja = Id_Caja,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_Comprobante = o.Id,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                        {
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        }
                        else
                        {
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Debito = od.Importe;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Credito = od.Importe;
                        }

                        db.EspeciesCtaCte.Add(ecc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito || tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                        {
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        }
                        else
                        {
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Debito = od.Importe;
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Credito = od.Importe;
                        }
                        db.EntidadesCtaCte.Add(encc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.CreditoDebito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                            encc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 0)
                            encc1.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc1);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.DebitoCredito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 0)
                            encc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 0)
                            encc1.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc1);
                    }
                }

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesCompra_ActualizaCostos)))
                {
                    List<int> IdProducto = new List<int>();
                    foreach (ComprobantesComprasDetalle d in o.Detalle.Where(t => t.Id_Producto > 0))
                    {
                        if (!IdProducto.Contains(d.Id_Producto.Value))
                        {
                            Productos prod = new Productos() { Id = d.Id_Producto.Value };
                            db.Entry(prod).State = EntityState.Modified;
                            db.Entry(prod).Reload();
                            prod.ImporteCosto = d.ImporteUnitario;
                            prod.FechaActualizacionCosto = (DateTime)o.FechaLiquidacion;
                            prod.Id_EspecieCosto = d.Id_Especie;
                            prod.FechaMod = (DateTime)o.FechaLiquidacion;
                            prod.UserMod = (int)o.UserMod;
                            IdProducto.Add(d.Id_Producto.Value);
                        }
                    }
                }

                ComprobantesCompras n = new ComprobantesCompras();
                if (tc.Id_TipoCompProcesa != null)
                {
                    n.Fecha = (DateTime)o.FechaLiquidacion;
                    n.FechaAdd = (DateTime)o.FechaLiquidacion;
                    n.FechaVto = (DateTime)o.FechaLiquidacion;
                    n.FechaRecepcion = (DateTime)o.FechaRecepcion;
                    n.Id_CentroCosto = o.Id_CentroCosto;
                    n.Id_Entidad = o.Id_Entidad;
                    n.Id_FormaPago = o.Id_FormaPago;
                    n.Id_Sucursal = o.Id_Sucursal;
                    //n.Id_TalonariosComprobantes = Id_TalonariosComprobantes;
                    n.Id_TipoComprobante = (int)tc.Id_TipoCompProcesa;
                    n.Id_TipoEntidad = o.Id_TipoEntidad;
                    //n.Id_TipoFacturacion = o.Id_TipoFacturacion;
                    //n.Id_Vendedor = o.Id_Vendedor;
                    n.Id_Deposito = o.Id_Deposito;
                    n.Letra = o.Letra;
                    n.NroComprobante = o.NroComprobante;
                    n.Observaciones = o.Observaciones;
                    n.OtrosImpuestos = o.OtrosImpuestos;
                    n.PercepcionIIBB = o.PercepcionIIBB;
                    n.PercepcionIva = o.PercepcionIva;
                    n.PuntoVenta = o.PuntoVenta;
                    n.PercepcionGanancias = o.PercepcionGanancias;
                    n.UserAdd = (int)o.UserMod;

                    n.Detalle = new List<ComprobantesComprasDetalle>();

                    foreach (ComprobantesComprasDetalle d in o.Detalle)
                    {
                        ComprobantesComprasDetalle vd = new ComprobantesComprasDetalle()
                        {
                            Cantidad = d.Cantidad,
                            Cotizacion = d.Cotizacion,
                            Descripcion = d.Descripcion,
                            Especie = d.Especie,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_AlicuotaIva = d.Id_AlicuotaIva,
                            Id_Especie = d.Id_Especie,
                            Id_Producto = d.Id_Producto,
                            Importe = d.Importe,
                            AlicuotaIva = d.AlicuotaIva,
                            //ImporteCosto = d.ImporteCosto,
                            ImporteIVA = d.ImporteIVA,
                            ImporteUnitario = d.ImporteUnitario,
                            PorcDescuento = d.PorcDescuento,
                            UserAdd = (int)o.UserMod,
                            ComprobanteCompra = n
                        };
                        n.Detalle.Add(vd);

                    }

                    db.Entry(n).State = EntityState.Added;
                    //}
                    //else
                    //{
                    //    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    //}
                }

                db.SaveChanges();

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_GeneraArchivoStock)))
                {
                    Thread threadStock;
                    threadStock = new Thread(new ThreadStart(new ProductosStockManager().GenerarArchivoStock));
                    threadStock.Start();
                }
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_GeneraArchivoDeudas)))
                {
                    Thread threadDeuda;
                    threadDeuda = new Thread(new ThreadStart(new ComprobantesVentasManager().GenerarArchivoDeuda));
                    threadDeuda.Start();
                }
                string result = "";
                //if (tc.Id_TipoCompProcesa != null)
                //{
                //    o.Id_ComprobanteCompra_Procesado = n.Id;
                //    result = string.Format("Se ha generado el comprobante {0} {1}", (db.TipoComprobante.Where(t => t.Id == n.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()), n.Comprobante);
                //}

                //db.SaveChanges();

                return result;
            }
        }

        public static string Anular(ComprobantesCompras o, string MotivoAnulacion)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede anular un comprobante sin liquidar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                TipoComprobante tc = new TipoComprobante() { Id = o.Id_TipoComprobante };
                db.Entry(tc).State = EntityState.Unchanged;
                db.Entry(tc).Reload();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaAnulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.MotivoAnulacion = MotivoAnulacion;

                string Nombre = Sistema.GetNombreEntidad(o.Id_TipoEntidad, o.Id_Entidad);

                List<EspeciesCantidad> r = (from d in o.Detalle
                                            where d.UserDel == null
                                            group d by d.Id_Especie into g
                                            orderby g.Sum(x => x.Importe)
                                            select new EspeciesCantidad
                                            {
                                                Id_Especie = g.Key,
                                                Importe = g.Sum(x => x.Importe)
                                            }).ToList();

                int i = 0;

                foreach (EspeciesCantidad od in r)
                {
                    i += 1;

                    int Id_Caja = (from c in db.Cajas
                                   where Seguridad.IdCajasAsignadas.Contains(c.Id) &&
                                         c.Id_Sucursal == o.Id_Sucursal &&
                                         c.Id_Especie == od.Id_Especie
                                   select c.Id).FirstOrDefault();

                    if (Id_Caja == 0)
                    {
                        string Especie = (from e in db.Especies where e.Id == od.Id_Especie select e.Descripcion).FirstOrDefault();
                        throw new ValidationException(string.Format("La Caja para la especie {0} no existe o el usuario no tiene su asignación.", Especie));
                    }

                    if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito || tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito)
                    {
                        EspeciesCtaCte ecc = new EspeciesCtaCte()
                        {
                            Id_CentroCosto = o.Id_CentroCosto,
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaAnulacion,
                            FechaAdd = (DateTime)o.FechaAnulacion,
                            Id_Caja = Id_Caja,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_Comprobante = o.Id,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                        {
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        }
                        else
                        {
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Debito = od.Importe;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Credito = od.Importe;
                        }
                        db.EspeciesCtaCte.Add(ecc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito || tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaAnulacion,
                            FechaAdd = (DateTime)o.FechaAnulacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                        {
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        }
                        else
                        {
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Debito = od.Importe;
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Credito = od.Importe;
                        }
                        db.EntidadesCtaCte.Add(encc);
                    }
                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.CreditoDebito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                            encc.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                            encc1.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc1);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.DebitoCredito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                            encc.Credito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("Anulación {0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        if (i == 1)
                            encc1.Debito = od.Importe + o.ImpuestoNoGravado + o.PercepcionIIBB + o.PercepcionIva + o.OtrosImpuestos + o.ITC + o.PercepcionIIBBCapital + o.PercepcionGanancias - o.Descuento;
                        db.EntidadesCtaCte.Add(encc1);
                    }
                }

                ComprobantesCompras n = new ComprobantesCompras();
                if (tc.Id_TipoCompAnula != null)
                {
                    //int Id_TalonariosComprobantes = Sistema.ObtenerTalonario(o.Id_Sucursal, tc.Id_TipoCompAnula.Value, o.Id_TipoEntidad, o.Id_Entidad.Value).FirstOrDefault().Key;

                    ////int Id_TalonariosComprobantes = (from tc1 in db.TalonariosComprobantes
                    ////                                 join pv in db.PuntosVentas on tc1.Id_PuntoVenta equals pv.Id into listPV
                    ////                                 from punto in listPV
                    ////                                 where tc1.UserDel == null &&
                    ////                                       tc1.Id_Comprobante == tc.Id_TipoCompAnula &&
                    ////                                      (from pv in db.PuntosVentas
                    ////                                       where pv.Id_Sucursal == o.Id_Sucursal
                    ////                                       select pv.Id).Contains(tc1.Id_PuntoVenta) &&
                    ////                                       Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                    ////                                 select tc1.Id).FirstOrDefault();

                    //TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                    //                                     where d.Id_TalonarioComprobante == Id_TalonariosComprobantes
                    //                                           && d.FechaVencimiento >= o.FechaLiquidacion
                    //                                           && d.NroActual < d.NroHasta
                    //                                     orderby d.NroDesde
                    //                                     select d).FirstOrDefault();

                    //if (tcd != null)
                    //{
                    //    db.TalonariosComprobantesDetalle.Attach(tcd);
                    //    tcd.NroActual += 1;

                    //    TalonariosComprobantes tc1 = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();

                    n = new ComprobantesCompras()
                    {
                        Fecha = (DateTime)o.FechaLiquidacion,
                        FechaAdd = (DateTime)o.FechaLiquidacion,
                        FechaVto = (DateTime)o.FechaLiquidacion,
                        FechaRecepcion = o.FechaRecepcion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Entidad = o.Id_Entidad,
                        Id_FormaPago = o.Id_FormaPago,
                        Id_Sucursal = o.Id_Sucursal,
                        //Id_TalonariosComprobantes = Id_TalonariosComprobantes,
                        Id_TipoComprobante = (int)tc.Id_TipoCompAnula,
                        Id_TipoEntidad = o.Id_TipoEntidad,
                        //Id_TipoFacturacion = o.Id_TipoFacturacion,
                        //Id_Vendedor = o.Id_Vendedor,
                        Id_Deposito = o.Id_Deposito,
                        Letra = o.Letra,
                        NroComprobante = o.NroComprobante,
                        Observaciones = o.Observaciones,
                        OtrosImpuestos = o.OtrosImpuestos,
                        PercepcionIIBB = o.PercepcionIIBB,
                        PercepcionIva = o.PercepcionIva,
                        PuntoVenta = o.PuntoVenta,
                        PercepcionGanancias = o.PercepcionGanancias,
                        UserAdd = (int)o.UserMod
                    };
                    n.Detalle = new List<ComprobantesComprasDetalle>();
                    foreach (ComprobantesComprasDetalle d in o.Detalle)
                    {
                        ComprobantesComprasDetalle vd = new ComprobantesComprasDetalle()
                        {
                            Cantidad = d.Cantidad,
                            Cotizacion = d.Cotizacion,
                            Descripcion = d.Descripcion,
                            Especie = d.Especie,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            Id_AlicuotaIva = d.Id_AlicuotaIva,
                            Id_Especie = d.Id_Especie,
                            Id_Producto = d.Id_Producto,
                            Importe = d.Importe,
                            AlicuotaIva = d.AlicuotaIva,
                            //importecosto = d.importecosto,
                            ImporteIVA = d.ImporteIVA,
                            ImporteUnitario = d.ImporteUnitario,
                            PorcDescuento = d.PorcDescuento,
                            UserAdd = (int)o.UserMod
                        };
                        n.Detalle.Add(vd);
                    }

                    db.Entry(n).State = EntityState.Added;
                    //}
                    //else
                    //{
                    //    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    //}
                }

                //Restablece precio ultimo producto
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesCompra_ActualizaCostos)))
                {
                    List<int> IdProducto = new List<int>();
                    foreach (ComprobantesComprasDetalle d in o.Detalle.Where(t => t.Id_Producto > 0))
                    {
                        if (!IdProducto.Contains(d.Id_Producto.Value))
                        {
                            Productos prod = new Productos() { Id = d.Id_Producto.Value };
                            db.Entry(prod).State = EntityState.Modified;
                            db.Entry(prod).Reload();

                            //prod.ImporteCosto = d.Importe / d.Cantidad;
                            prod.ImporteCosto = (from cc in db.ComprobantesCompras
                                                 join det in db.ComprobantesComprasDetalle on cc.Id equals det.Id_ComprobanteCompra into listDet
                                                 from ccd in listDet
                                                 where cc.FechaLiquidacion < o.FechaLiquidacion
                                                    && cc.FechaLiquidacion != null
                                                    && ccd.Id_Producto == d.Id_Producto
                                                    && cc.UserDel == null
                                                    && ccd.UserDel == null
                                                 select new FechaImporte() { Fecha = cc.FechaLiquidacion.Value, Importe = ccd.ImporteUnitario }).OrderByDescending(t => t.Fecha).FirstOrDefault().Importe;
                            prod.FechaActualizacionCosto = (DateTime)o.FechaLiquidacion;
                            prod.Id_EspecieCosto = d.Id_Especie;
                            prod.FechaMod = (DateTime)o.FechaLiquidacion;
                            prod.UserMod = (int)o.UserMod;

                            IdProducto.Add(d.Id_Producto.Value);
                        }
                    }
                }


                db.SaveChanges();

                string result = "";
                //if (tc.Id_TipoCompAnula != null)
                //{
                //    o.Id_ComprobanteCompra_Anulado = n.Id;
                //    result = string.Format("Se ha generado el comprobante {0} {1}", (db.TipoComprobante.Where(t => t.Id == n.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()), n.Comprobante);
                //}

                //db.SaveChanges();

                return result;
            }
        }

        public static void CambiarFecha(ComprobantesCompras o, DateTime Fecha)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.Fecha = Fecha;

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from v in db.ComprobantesCompras
                     join c in db.CentrosCostos on v.Id_CentroCosto equals c.Id into listCC
                     from cen in listCC.DefaultIfEmpty()
                     join s in db.Sucursales on v.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where (v.Id == parametros.Id || parametros.Id == null)
                        && (v.Id_TipoComprobante == parametros.Id_TipoComprobante)
                        && (v.Id_Sucursal == parametros.Id_Sucursal)
                        && (v.Id_TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                        && (v.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                        && (v.Fecha >= parametros.Fecha_Desde && v.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                        && (v.Letra == parametros.Letra || parametros.Letra == null)
                        && (v.PuntoVenta == parametros.PuntoVenta || parametros.PuntoVenta == null)
                        && (v.NroComprobante == parametros.NroComprobante || parametros.NroComprobante == null)
                        && (v.Observaciones.Contains(parametros.Concepto) || parametros.Concepto == null)
                        && (v.FechaLiquidacion >= parametros.Fecha_Liquidacion_Desde && v.FechaLiquidacion <= parametros.Fecha_Liquidacion_Hasta || parametros.Fecha_Liquidacion_Hasta == null)
                        && (v.FechaAnulacion != null || parametros.Anulado == false)
                        && (v.UserDel == null)
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Centro_Costo = cen.Descripcion,
                         Fecha = v.Fecha,
                         FechaRecepcion = v.FechaRecepcion,
                         FechaAdd = v.FechaAdd,
                         FechaAnulacion = v.FechaAnulacion,
                         FechaLiquidacion = v.FechaLiquidacion,
                         FechaMod = v.FechaMod,
                         FechaVto = v.FechaVto,
                         Id_CentroCosto = v.Id_CentroCosto,
                         Id_Entidad = v.Id_Entidad,
                         Id_FormaPago = v.Id_FormaPago,
                         Id_Sucursal = v.Id_Sucursal,
                         Id_TipoComprobante = v.Id_TipoComprobante,
                         Id_TipoEntidad = v.Id_TipoEntidad,
                         Importe = v.Importe,
                         ImportePesos = v.ImportePesos,
                         //Importe = db.ComprobantesComprasDetalle.Where(rd => rd.Id_ComprobanteCompra == v.Id).Select(rd => rd.Importe).Sum() + v.ImpuestoNoGravado + v.OtrosImpuestos + v.PercepcionIIBB + v.PercepcionIva + v.PercepcionGanancias + v.ITC + v.PercepcionIIBBCapital - v.Descuento,
                         //Importe_Pesos = db.ComprobantesComprasDetalle.Where(rd => rd.Id_ComprobanteCompra == v.Id).Select(rd => rd.Importe * rd.Cotizacion).Sum() + v.ImpuestoNoGravado + v.OtrosImpuestos + v.PercepcionIIBB + v.PercepcionIva + v.PercepcionGanancias + v.ITC + v.PercepcionIIBBCapital - v.Descuento,
                         Letra = v.Letra,
                         MotivoAnulacion = v.MotivoAnulacion,
                         Nombre_Entidad = v.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == v.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == v.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                        join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                        from prov in listPF
                                                                                                        where pfc.Id == v.Id_Entidad
                                                                                                        select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == v.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",

                         NroComprobante = v.NroComprobante,
                         Observaciones = v.Observaciones,
                         OtrosImpuestos = v.OtrosImpuestos,
                         PercepcionIIBB = v.PercepcionIIBB,
                         PercepcionIva = v.PercepcionIva,
                         PercepcionGanancias = v.PercepcionGanancias,
                         PuntoVenta = v.PuntoVenta,
                         Sucursal = suc.Descripcion,
                         Id_Deposito = v.Id_Deposito,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();

                return r;
            }
        }

        public static Especies GetEspecieDefault()
        {
            using (var db = new GestionContext())
            {
                return db.Especies.Where(t => t.Cotizacion == 1).Select(t => t).OrderBy(t => t.Id).FirstOrDefault();
            }
        }

        public static string GetNombreComprobante(int Id_Comprobante)
        {
            using (var db = new GestionContext())
            {
                return db.TipoComprobante.Where(t => t.Id == Id_Comprobante).Select(t => t.DescripcionCorta).FirstOrDefault();
            }
        }

        public static decimal GetImportePagoComprobante(int Id_Comprobante)
        {
            using (var db = new TesoreriaContext())
            {
                return (from cc in db.ComprobantesCompras
                        join oc in db.OrdenesPagoComprobantes on cc.Id equals oc.Id_ComprobantesCompras into listComp
                        from opc in listComp
                        join o in db.OrdenesPago on opc.Id_OrdenPago equals o.Id into listOP
                        from op in listOP
                        where op.UserDel == null
                           && cc.Id == Id_Comprobante
                           && cc.UserDel == null
                           && opc.UserDel == null
                           && op.Fecha_Anulacion == null
                        select opc.ImportePago).DefaultIfEmpty(0).Sum();
            }
        }

        public static bool ComprobanteEnOP(int IdComp)
        {
            using (var db = new TesoreriaContext())
            {
                int Cant = (from op in db.OrdenesPago
                            join c in db.OrdenesPagoComprobantes on op.Id equals c.Id_OrdenPago into listOPC
                            from opc in listOPC
                            where op.UserDel == null
                               && op.Fecha_Anulacion == null
                               && opc.Id_ComprobantesCompras == IdComp
                            select opc.Id_ComprobantesCompras).Count();

                if (Cant == 0) return false; else return true;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                //DateTime fd = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                //DateTime fh = fd.AddMonths(1).AddDays(-1);

                //Fecha_Desde = fd;
                //Fecha_Hasta = fh;
                Fecha_Desde = Sistema.ObtenerFecha();
                Fecha_Hasta = Fecha_Desde;

                if (Sistema.Sucursales.Count() > 0)
                    Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
            }

            public List<KeyNamePair> Entidades
            {
                get
                {
                    using (var db = new GestionContext()) return Sistema.ObtenerEntidades(TipoEntidad);
                }
            }

            public int Id_TipoComprobante { get; set; }
            public int? Id { get; set; }
            public int Id_Sucursal { get; set; }
            public Enums.TipoEntidad? TipoEntidad { get; set; }
            public int? Id_Entidad { get; set; }
            public DateTime? Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public string Letra { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public string Concepto { get; set; }
            public DateTime? Fecha_Liquidacion_Desde { get; set; }
            public DateTime? Fecha_Liquidacion_Hasta { get; set; }
            public bool Anulado { get; set; }
        }

        public class SearchResult : ComprobantesCompras
        {
            public string Sucursal { get; set; }
            public string Nombre_Entidad { get; set; }
            public string Centro_Costo { get; set; }
            //public decimal Importe_Pesos { get; set; }
            //public decimal Importe { get; set; }
        }

        //public static List<DatosReporte> ImprimeComprobante(ComprobantesCompras o)
        //{
        //    using (var db = new GestionContext())
        //    {
        //        db.Entry(o).State = EntityState.Unchanged;
        //        db.Entry(o).Reload();

        //        if (o.Detalle == null)
        //            db.Entry(o).Collection(p => p.Detalle).Load();

        //        List<DatosReporte> l = new List<DatosReporte>();

        //        //TODO: Llenar la clase Entidad
        //        EntidadReporte EntReporte = new EntidadReporte();
        //        switch (o.Id_TipoEntidad)
        //        {
        //            case Enums.TipoEntidad.Cliente:
        //                Clientes c = new Clientes() { Id = o.Id_Entidad.Value };
        //                db.Entry(c).State = EntityState.Unchanged;
        //                db.Entry(c).Reload();

        //                EntReporte.Nombre = c.Nombre;
        //                EntReporte.Cuit = c.Cuit;
        //                EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == c.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
        //                EntReporte.Domicilio = c.Domicilio;
        //                EntReporte.Localidad = (db.Localidades.Where(t => t.Id == c.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
        //                break;

        //            case Enums.TipoEntidad.Personal:
        //                Personal p = new Personal() { Id = o.Id_Entidad.Value };
        //                db.Entry(p).State = EntityState.Unchanged;
        //                db.Entry(p).Reload();

        //                EntReporte.Nombre = p.Nombre;
        //                EntReporte.Cuit = p.Cuit;
        //                EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == p.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
        //                EntReporte.Domicilio = p.DomicilioCalle + " " + p.DomicilioNro + " " + p.DomicilioPiso + " " + p.DomicilioDpto;
        //                EntReporte.Localidad = p.CodPos.Value.ToString();
        //                break;

        //            case Enums.TipoEntidad.Proveedor:
        //                Proveedores pr = new Proveedores() { Id = o.Id_Entidad.Value };
        //                db.Entry(pr).State = EntityState.Unchanged;
        //                db.Entry(pr).Reload();

        //                EntReporte.Nombre = pr.Nombre;
        //                EntReporte.Cuit = pr.Cuit;
        //                EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == pr.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
        //                EntReporte.Domicilio = pr.Domicilio;
        //                EntReporte.Localidad = (db.Localidades.Where(t => t.Id == pr.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
        //                break;

        //            case Enums.TipoEntidad.Proveedor_Financiero:
        //                ProvFinancieros pf = new ProvFinancieros() { Id = o.Id_Entidad.Value };
        //                db.Entry(pf).State = EntityState.Unchanged;
        //                db.Entry(pf).Reload();

        //                EntReporte.Nombre = pf.Nombre;
        //                EntReporte.Cuit = pf.Cuit;
        //                EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == pf.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
        //                EntReporte.Domicilio = pf.Domicilio;
        //                EntReporte.Localidad = (db.Localidades.Where(t => t.Id == pf.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
        //                break;
        //        }

        //        int Id_Empresa = (from e in db.Empresas
        //                          join s in db.Sucursales on e.Id equals s.Id_Empresa into listSuc
        //                          from suc in listSuc
        //                          where suc.Id == o.Id_Sucursal
        //                          select e.Id).FirstOrDefault();

        //        Empresas emp = new Empresas() { Id = Id_Empresa };
        //        db.Entry(emp).State = EntityState.Unchanged;
        //        db.Entry(emp).Reload();

        //        Localidades loc = new Localidades();
        //        if (emp.Id_CodPostal > 0)
        //        {
        //            loc.Id = emp.Id_CodPostal.Value;
        //            db.Entry(loc).State = EntityState.Unchanged;
        //            db.Entry(loc).Reload();
        //        }


        //        EmpresasReporte EmpReporte = new EmpresasReporte()
        //        {
        //            Id = emp.Id,
        //            Nombre = emp.Nombre,
        //            Fantasia = emp.Fantasia,
        //            Direccion = emp.Direccion,
        //            Id_CodPostal = loc.CodPostal,
        //            Localidad = loc.Localidad,
        //            Cuit = emp.Cuit,
        //            Id_TipoIva = emp.Id_TipoIva,
        //            TipoIva = (db.TipoIva.Where(t => t.Id == emp.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault()),
        //            IngresosBrutos = emp.IngresosBrutos,
        //            InicioActividades = emp.InicioActividades
        //        };

        //        int IdEspecie = o.Detalle.First().Id_Especie;
        //        string Especie = db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault();

        //        DatosReporte i = new DatosReporte()
        //        {
        //            Empresa = EmpReporte,
        //            Entidad = EntReporte,
        //            Letra = o.Letra,
        //            //NroCodigo = (db.TalonariosComprobantes.Where(t => t.Id == o.Id_TalonariosComprobantes).Select(t => t.NroCodigo).FirstOrDefault()),
        //            PuntoVenta = o.PuntoVenta,
        //            NroComprobante = o.NroComprobante,
        //            Fecha = o.Fecha,
        //            Observaciones = o.Observaciones,
        //            TotalIva = o.Detalle.Sum(t => t.ImporteIVA),
        //            SubTotal = o.Detalle.Sum(t => t.Importe) - o.Detalle.Sum(t => t.ImporteIVA),
        //            ImporteTotal = o.Detalle.Sum(t => t.Importe),
        //            TotalEnLetras = Especie + " " + NumeroALetras.Convertir(o.Detalle.Sum(t => t.Importe).ToString()),
        //            //TotalEnLetras = (db.Especies.Where(t => t.Id == o.Detalle.First().Id_Especie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(o.Detalle.Sum(t => t.Importe).ToString()),
        //            Comprobante = (db.TipoComprobante.Where(t => t.Id == o.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()),
        //            FechaVto = o.FechaVto,
        //            FormaPago = (db.FormasPagos.Where(t => t.Id == o.Id_FormaPago).Select(t => t.Descripcion).FirstOrDefault()),
        //            OtrosImpuestos = o.OtrosImpuestos,
        //            PercepcionIIBB = o.PercepcionIIBB,
        //            PercepcionIva = o.PercepcionIva,
        //            Sucursal = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Descripcion).FirstOrDefault()),
        //            //TipoFacturacion = o.Id_TipoFacturacion == 1 ? "Manual" : "Electrónica",
        //        };

        //        i.Detalle = o.Detalle;
        //        foreach (ComprobantesComprasDetalle x in o.Detalle)
        //        {
        //            x.Especie = db.Especies.Where(t => t.Id == x.Id_Especie).Select(t => t.Descripcion).FirstOrDefault();
        //        }

        //        l.Add(i);

        //        return l;
        //    }
        //}

        public class EspeciesCantidad
        {
            public int Id_Especie { get; set; }
            public decimal Importe { get; set; }
        }

        public class FechaImporte
        {
            public DateTime Fecha { get; set; }
            public decimal Importe { get; set; }
        }

        //public class DatosReporte
        //{
        //    public string Sucursal { get; set; }
        //    public string Comprobante { get; set; }
        //    public string Letra { get; set; }
        //    public string NroCodigo { get; set; }
        //    public string PuntoVenta { get; set; }
        //    public string NroComprobante { get; set; }
        //    public EntidadReporte Entidad { get; set; }
        //    public string Vendedor { get; set; }
        //    public string FormaPago { get; set; }
        //    public DateTime Fecha { get; set; }
        //    public DateTime FechaVto { get; set; }
        //    public DateTime FechaEntrega { get; set; }
        //    public string Observaciones { get; set; }
        //    public decimal PercepcionIva { get; set; }
        //    public decimal OtrosImpuestos { get; set; }
        //    public decimal Retenciones { get; set; }
        //    public decimal PercepcionIIBB { get; set; }
        //    public decimal SubTotal { get; set; }
        //    public decimal TotalIva { get; set; }
        //    public decimal ImporteTotal { get; set; }
        //    public string TotalEnLetras { get; set; }
        //    public string TipoFacturacion { get; set; }
        //    public string AFIPCAE { get; set; }
        //    public DateTime? FechaVtoCAE { get; set; }
        //    public string ObservacionesCAE { get; set; }
        //    public virtual ICollection<ComprobantesComprasDetalle> Detalle { get; set; }
        //    public EmpresasReporte Empresa { get; set; }
        //}

        //public class EmpresasReporte : Empresas
        //{
        //    public string TipoIva { get; set; }
        //    public string Localidad { get; set; }
        //}

        //public class EntidadReporte
        //{
        //    public string Nombre { get; set; }
        //    public string Domicilio { get; set; }
        //    public string Localidad { get; set; }
        //    public string Cuit { get; set; }
        //    public string TipoIva { get; set; }
        //}
    }
}