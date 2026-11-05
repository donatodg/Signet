namespace VENET_Gestion_BL
{
    using VENET_Tesoreria_BL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using static VENET_Common.Reportes;
    using static VENET_Common.Reportes.ComprobantesVentasReporte;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using OfficeOpenXml;
    using System.Drawing;
    using OfficeOpenXml.Style;

    public class ComprobantesVentasManager : IDisposable
    {

        private GestionContext db;

        //public decimal TotalMes { private set; get; }
        public ComprobantesVentas Comprobante { get; set; }

        public ComprobantesVentasManager()
        {
        }

        public ComprobantesVentasManager(ComprobantesVentas o)
        {
            db = new GestionContext();
            Comprobante = o;

            db.ComprobantesVentas.Attach(Comprobante);

            if (Comprobante.Id > 0)
            {
                db.Entry(Comprobante).Reload();

                if (Comprobante.Detalle == null)
                    db.Entry(Comprobante).Collection(p => p.Detalle).Load();

                if (Comprobante.Detalle.Count > 0)
                    foreach (ComprobantesVentasDetalle row in Comprobante.Detalle)
                        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();

                if (Comprobante.Impuestos == null)
                    db.Entry(Comprobante).Collection(p => p.Impuestos).Load();

                if (Comprobante.Impuestos.Count > 0)
                    foreach (ComprobantesVentasImpuestos row in Comprobante.Impuestos.Where(t => t.Id_Provincia > 0))
                        row.Provincia = db.Provincias.Where(t => t.Id == row.Id_Provincia).Select(t => t.Descripcion).SingleOrDefault();

            }
            else
            {
                Comprobante.Fecha = Comprobante.FechaEntrega = Comprobante.FechaVto = Sistema.ObtenerFechaHora();
                db.Entry(Comprobante).Collection(p => p.Detalle).Load();
                db.Entry(Comprobante).Collection(p => p.Impuestos).Load();
                Comprobante.Observaciones = "-";

                try
                {
                    if (Comprobante.Impuestos == null) db.Entry(Comprobante).Collection(p => p.Impuestos).Load();

                    //if (Sistema.CentrosCostos.Count() > 0)
                    //if (Vendedores.Count() > 0)
                    Comprobante.Id_Vendedor = Vendedores.First().Key;
                    //if (Sistema.FormasPagos.Count() > 0)
                    Comprobante.Id_FormaPago = Sistema.FormasPagos.First().Key;
                    Comprobante.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                    Comprobante.Id_CentroCosto = Sistema.CentrosCostos.First().Key;
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

        public List<KeyNamePair> ClienteEntrega
        {
            get
            {
                if (Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                    using (var db = new GestionContext())
                        return db.ClientesEntregas.Where(t => t.Id_Cliente == Comprobante.Id_Entidad && t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).ToList();
                else
                    return new List<KeyNamePair>();
            }
        }

        public int? FormaPagocliente
        {
            get
            {
                if (Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                    using (var db = new GestionContext())
                        return db.Clientes.Where(t => t.Id == Comprobante.Id_Entidad && t.UserDel == null).Select(t => t.Id_FormaPago).FirstOrDefault();
                else
                    return null;
            }
        }

        public List<KeyNamePair> Vendedores { get { using (var db = new GestionContext()) { return db.Vendedores.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList(); } } }

        public List<ComprobantesVentasImpuestos> EntidadesAlicuotas()
        {
            List<ComprobantesVentasImpuestos> r = new List<ComprobantesVentasImpuestos>();

            using (GestionContext db = new GestionContext())
            {
                var rr = (from e in db.EntidadesImpuestosAlicuotas
                          join impA in db.ImpuestosAlicuotas on e.Id_ImpuestoAlicuota equals impA.Id into listIA
                          from ia in listIA
                          join imp in db.TipoImpuestos on ia.Id_Impuesto equals imp.Id into listImp
                          from i in listImp
                          join pr in db.Provincias on ia.Id_Provincia equals pr.Id into listPr
                          from p in listPr.DefaultIfEmpty()
                          where e.Id_TipoEntidad == Comprobante.Id_TipoEntidad
                             && e.Id_Entidad == Comprobante.Id_Entidad
                             && i.Id_TipoImpuesto == Enums.TipoImpuesto.Percepcion
                             //&& i.Percepcion == true
                             && e.UserDel == null
                             && ia.UserDel == null
                             && i.UserDel == null
                          select new OrdenesPagoImpuestos()
                          {
                              Id = e.Id,
                              Alicuota = ia.Alicuota,
                              BaseImponible = ia.BaseImponible,
                              Id_Impuesto = i.Id,
                              AplicaSobre = i.AplicaSobre,
                              ImporteMinimo = ia.ImporteMinimo,
                              Importe = 0,
                              Id_Provincia = p.Id,
                              Impuesto = i.Descripcion,
                              Provincia = p.Descripcion,
                              FechaAdd = e.FechaAdd,
                              FechaMod = e.FechaMod,
                              UserAdd = e.UserAdd,
                              UserMod = e.UserMod
                          }).ToList();

                foreach (OrdenesPagoImpuestos x in rr)
                {
                    r.Add(new ComprobantesVentasImpuestos()
                    {
                        Id = x.Id,
                        Alicuota = x.Alicuota,
                        BaseImponible = x.BaseImponible,
                        Id_Impuesto = x.Id_Impuesto,
                        AplicaSobre = x.AplicaSobre,
                        ImporteMinimo = x.ImporteMinimo,
                        Importe = 0,
                        Id_Provincia = x.Id_Provincia,
                        Impuesto = x.Impuesto,
                        Provincia = x.Provincia,
                        FechaAdd = x.FechaAdd,
                        FechaMod = x.FechaMod,
                        UserAdd = x.UserAdd,
                        UserMod = x.UserMod
                    });
                }
            }

            DateTime f = Sistema.ObtenerFecha();
            f = new DateTime(f.Year, f.Month, 01);
            DateTime f1 = f.AddMonths(1).AddDays(-1);

            //TotalMes = (from o in db.ComprobantesVentas
            //            join det in db.ComprobantesVentasDetalle on o.Id equals det.Id_ComprobanteVenta into listDet
            //            from opd in listDet
            //            where o.Id_TipoEntidad == Comprobante.Id_TipoEntidad
            //               && o.Id_Entidad == Comprobante.Id_Entidad
            //               && o.UserDel == null
            //               && o.FechaAnulacion == null
            //               && (o.Id != Comprobante.Id)
            //               && o.FechaLiquidacion >= f
            //               && o.FechaLiquidacion <= f1
            //               && opd.UserDel == null
            //            select opd.Importe * opd.Cotizacion).DefaultIfEmpty(0).Sum();

            return r;
        }

        public static bool UtilizaImpuesto(int Id_TipoComprobante)
        {
            using (var db = new GestionContext())
            {
                TipoComprobante tc = new TipoComprobante() { Id = Id_TipoComprobante };
                db.Entry(tc).State = EntityState.Unchanged;
                db.Entry(tc).Reload();

                return tc.UtilizaImpuestos;
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void ActualizaDescuento(decimal PorcDesc)
        {
            foreach (ComprobantesVentasDetalle d in Comprobante.Detalle)
            {
                d.PorcDescuento = PorcDesc;

                decimal ImporteDesc = d.ImporteUnitario * PorcDesc / 100;
                d.ImporteIVA = Math.Round(Convert.ToDecimal(((d.ImporteUnitario - ImporteDesc) * d.AlicuotaIva / 100) * d.Cantidad), 2);

                decimal Subtotal = (d.ImporteUnitario - ImporteDesc + ((d.ImporteUnitario - ImporteDesc) * d.AlicuotaIva / 100)) * d.Cantidad;
                d.Importe = Math.Round(Subtotal, 2);
            }
        }

        public void Save()
        {
            if (Comprobante.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");
            if (Comprobante.Fecha > Comprobante.FechaEntrega) throw new ValidationException("La fecha es posterior a la fecha de entrega.");
            if (Comprobante.Fecha > Comprobante.FechaVto) throw new ValidationException("La fecha es posterior a la fecha de vencimiento.");

            //if (Comprobante.Detalle.Where(t => t.Borrado == false).Select(t => t.Importe).Sum() + decimal.Round((from d in Comprobante.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum(), 2) != (Comprobante.Importe + decimal.Round(Comprobante.Impuestos.Where(t => t.Borrado == false).Select(t => t.Importe).DefaultIfEmpty(0).Sum(), 2)))
            //    throw new ValidationException("El importe del detalle es distinto al importe ingresado.");

            //hacer inner con productos para validar cant stock

            if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock)))
            {
                if (Comprobante.Detalle.Where(t => t.Borrado == false && t.CantidadStock.GetValueOrDefault(0) == 0 && t.Visible_Cantidad_Stock == true).Count() > 0)
                    throw new ValidationException("Debe ingresar una cantidad de stock válida.");
            }

            if (Comprobante.Id == 0)
            {
                db.Entry(Comprobante).State = EntityState.Added;
                Comprobante.FechaAdd = Sistema.ObtenerFechaHora();
                Comprobante.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                DateTime fecha = Sistema.ObtenerFecha();

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == Comprobante.Id_TalonariosComprobantes
                                                           && d.FechaVencimiento >= fecha
                                                           && d.NroActual < d.NroHasta
                                                     orderby d.NroDesde
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual += 1;

                    TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                    Comprobante.Letra = tc.Letra;

                    Comprobante.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                    Comprobante.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                }
                else
                {
                    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                }
            }
            else
            {
                db.Entry(Comprobante).State = EntityState.Modified;
                Comprobante.FechaMod = Sistema.ObtenerFechaHora();
                Comprobante.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            //Comprobante.Importe =      Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe).Sum() + Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.Retenciones;
            //Comprobante.ImportePesos = Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe * t.Cotizacion).Sum() + Comprobante.OtrosImpuestos + Comprobante.PercepcionIIBB + Comprobante.PercepcionIva + Comprobante.Retenciones;

            Comprobante.Importe = Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe).Sum() + Comprobante.Impuestos.Where(x => x.Borrado == false).Select(x => x.Importe).Sum();
            Comprobante.ImportePesos = Comprobante.Detalle.Where(t => t.UserDel == null && t.Borrado == false).Select(t => t.Importe * t.Cotizacion).Sum() + Comprobante.Impuestos.Where(x => x.Borrado == false).Select(x => x.Importe).Sum();

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
                foreach (ComprobantesVentasDetalle row in Comprobante.Detalle.Where(t => t.Borrado == true))
                {
                    ComprobantesVentasDetalle o = new ComprobantesVentasDetalle() { Id = row.Id };
                    db1.ComprobantesVentasDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(ComprobantesVentas o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un comprobante anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede eliminar un comprobante liquidado.");

                if (db.TalonariosComprobantes.Where(t => t.Id_Comprobante == o.Id_TipoComprobante).Select(t => t.Electronico).FirstOrDefault() == true)
                {
                    if (o.AFIPCAE != null)
                        throw new ValidationException("No se puede eliminar un comprobante electrónico.");
                    if (db.ComprobantesVentas.Where(t => t.UserDel == null && t.Id_TalonariosComprobantes == o.Id_TalonariosComprobantes).Select(t => t.Id).Max() != o.Id)
                        throw new ValidationException("No se puede eliminar porque existe un comprobante electrónico posterior.");


                }
                //***************************************************************
                // Descuenta uno si el que se elimina es el ultimo comprobante
                //***************************************************************
                int NroCmp = Convert.ToInt32(o.NroComprobante.ToString());

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == o.Id_TalonariosComprobantes
                                                           && d.NroActual == NroCmp
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual -= 1;
                }
                //***************************************************************

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static string Confirmar(ComprobantesVentas o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un comprobante anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede confirmar un comprobante liquidado.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (o.Impuestos == null)
                    db.Entry(o).Collection(p => p.Impuestos).Load();

                var Procesado = (from cvdp in db.ComprobantesVentasDetalleProcesados
                                 join v in db.ComprobantesVentas on cvdp.Id_ComprobanteVentaOriginal equals v.Id into listCV
                                 from cv in listCV
                                 where cvdp.Id_ComprobanteVentaOriginal == o.Id
                                    && cv.FechaAnulacion == null
                                    && cvdp.UserDel == null
                                    && cv.UserDel == null
                                 select cvdp.Cantidad).DefaultIfEmpty(0).Sum();

                if (Convert.ToInt32(Procesado) > 0)
                    throw new ValidationException("El comprobante se ha confirmado de forma parcial, debe hacer una confirmación parcial.");


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
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
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
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
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
                            encc.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
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
                        if (i == 1)
                            encc1.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
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
                        if (i == 1)
                            encc.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
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
                        if (i == 1)
                            encc1.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + (db.ComprobantesVentasImpuestos.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == o.Id).Select(t => t.Importe).DefaultIfEmpty().Sum());
                        db.EntidadesCtaCte.Add(encc1);
                    }
                }

                ComprobantesVentas n = new ComprobantesVentas();

                if (tc.Id_TipoCompProcesa != null)
                {
                    int Id_TalonariosComprobantes = Sistema.ObtenerTalonario(o.Id_Sucursal, tc.Id_TipoCompProcesa.Value, o.Id_TipoEntidad, o.Id_Entidad.Value).FirstOrDefault().Key;

                    //int Id_TalonariosComprobantes = (from tc1 in db.TalonariosComprobantes
                    //                                 join pv in db.PuntosVentas on tc1.Id_PuntoVenta equals pv.Id into listPV
                    //                                 from punto in listPV
                    //                                 where tc1.UserDel == null &&
                    //                                       tc1.Id_Comprobante == tc.Id_TipoCompProcesa &&
                    //                                      (from pv in db.PuntosVentas
                    //                                       where pv.Id_Sucursal == o.Id_Sucursal
                    //                                       select pv.Id).Contains(tc1.Id_PuntoVenta) &&
                    //                                       Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                    //                                 select tc1.Id).FirstOrDefault();

                    TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                         where d.Id_TalonarioComprobante == Id_TalonariosComprobantes
                                                               && d.FechaVencimiento >= o.FechaLiquidacion
                                                               && d.NroActual < d.NroHasta
                                                         orderby d.NroDesde
                                                         select d).FirstOrDefault();

                    if (tcd != null)
                    {
                        db.TalonariosComprobantesDetalle.Attach(tcd);
                        tcd.NroActual += 1;

                        TalonariosComprobantes tc1 = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();

                        n.Fecha = (DateTime)o.FechaLiquidacion;
                        n.FechaAdd = (DateTime)o.FechaLiquidacion;
                        n.FechaVto = (DateTime)o.FechaLiquidacion;
                        n.FechaEntrega = (DateTime)o.FechaLiquidacion;
                        n.Id_CentroCosto = o.Id_CentroCosto;
                        n.Id_Entidad = o.Id_Entidad;
                        n.Id_FormaPago = o.Id_FormaPago;
                        n.Id_Sucursal = o.Id_Sucursal;
                        n.Id_TalonariosComprobantes = Id_TalonariosComprobantes;
                        n.Id_TipoComprobante = (int)tc.Id_TipoCompProcesa;
                        n.Id_TipoEntidad = o.Id_TipoEntidad;
                        n.Id_Vendedor = o.Id_Vendedor;
                        n.Id_Deposito = o.Id_Deposito;
                        n.Letra = tc1.Letra;
                        n.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                        n.Observaciones = o.Observaciones;
                        n.OtrosImpuestos = o.OtrosImpuestos;
                        n.PercepcionIIBB = o.PercepcionIIBB;
                        n.PercepcionIva = o.PercepcionIva;
                        n.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc1.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                        n.Retenciones = o.Retenciones;
                        n.Id_ComprobanteVenta_Original = o.Id;
                        n.UserAdd = (int)o.UserMod;

                        n.Detalle = new List<ComprobantesVentasDetalle>();

                        foreach (ComprobantesVentasDetalle d in o.Detalle)
                        {
                            ComprobantesVentasDetalle vd = new ComprobantesVentasDetalle()
                            {
                                Cantidad = d.Cantidad,
                                Cotizacion = d.Cotizacion,
                                Descripcion = d.Descripcion,
                                Especie = d.Especie,
                                FechaAdd = (DateTime)o.FechaLiquidacion,
                                AlicuotaIva = d.AlicuotaIva,
                                Id_AlicuotaIva = d.Id_AlicuotaIva,
                                Id_Especie = d.Id_Especie,
                                Id_Producto = d.Id_Producto,
                                Importe = d.Importe,
                                ImporteCosto = d.ImporteCosto,
                                ImporteIVA = d.ImporteIVA,
                                ImporteUnitario = d.ImporteUnitario,
                                PorcDescuento = d.PorcDescuento,
                                UserAdd = (int)o.UserMod,
                                ComprobanteVenta = n
                            };
                            n.Detalle.Add(vd);

                            ComprobantesVentasDetalleProcesados dp = new ComprobantesVentasDetalleProcesados()
                            {
                                Id_ComprobanteVentaDetalle = d.Id,
                                Id_ComprobanteVentaOriginal = d.Id_ComprobanteVenta,
                                Id_ComprobanteVentaProcesado = n.Id,
                                Cantidad = d.Cantidad,
                                UserAdd = (int)o.UserMod,
                                FechaAdd = (DateTime)o.FechaLiquidacion,
                            };
                            db.Entry(dp).State = EntityState.Added;

                        }

                        db.Entry(n).State = EntityState.Added;
                    }
                    else
                    {
                        throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    }
                }

                db.SaveChanges();

                string result = "";
                if (tc.Id_TipoCompProcesa != null)
                {
                    o.Id_ComprobanteVenta_Procesado = n.Id;
                    result = string.Format("Se ha generado el comprobante {0} {1}", (db.TipoComprobante.Where(t => t.Id == n.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()), n.Comprobante);
                    db.SaveChanges();
                }
                else
                {
                    if (o.Id_FormaPago == 1 && tc.GeneraDeuda && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_Genera_Recibo)))
                    {
                        Recibos or = new Recibos();
                        RecibosManager m = new RecibosManager(or);

                        or.Id_Entidad = o.Id_Entidad;
                        or.TipoEntidad = o.Id_TipoEntidad;
                        or.Id_Sucursal = o.Id_Sucursal;
                        or.Importe = o.ImportePesos.Value;
                        or.Id_TalonariosComprobantes = m.Letra.FirstOrDefault().Key;
                        or.Letra = m.Letra.FirstOrDefault().Name.Substring(0, 1);

                        or.Detalle.Add(new RecibosDetalle() { Cotizacion = 1, Id_Especie = 1, Especie = "PESOS", Importe = o.ImportePesos.Value, Detalle = "Efectivo", FechaAdd = o.FechaAdd, UserAdd = o.UserAdd });

                        or.Comprobantes.Add(new RecibosComprobantes() { Id_ComprobantesVentas = o.Id, Fecha = o.Fecha, ImporteAdeudado = o.ImportePesos.Value, Importe = o.ImportePesos.Value, ImportePago = o.ImportePesos.Value, UserAdd = o.UserAdd, FechaAdd = o.FechaAdd });

                        or.UserAdd = o.UserAdd;
                        or.FechaAdd = o.FechaAdd;

                        m.Save();

                        result = string.Format("Se ha generado el recibo {0}-{1}-{2} y debe confirmarse.", or.Letra, or.PuntoVenta, or.NroComprobante);

                        if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_Recibo_Generado)))
                        {
                            RecibosManager.Confirmar(or);
                            result = string.Format("Se ha generado y confirmado el recibo {0}-{1}-{2}.", or.Letra, or.PuntoVenta, or.NroComprobante);
                        }
                    }
                }

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

                return result;
            }
        }

        public static string ConfirmarParcialmente(ComprobantesVentas o, List<ComprobantesVentasDetalleProcesados> ListaAProcesar, bool TodoProcesado)
        {
            //***************************************************************
            //RESOLVER QUE HACER CON LOS IMPUESTOS!!!!!!!!!!!!
            //***************************************************************
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un comprobante anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede confirmar un comprobante liquidado.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                //var Procesado = (from cvdp in db.ComprobantesVentasDetalleProcesados
                //                 join v in db.ComprobantesVentas on cvdp.Id_ComprobanteVentaOriginal equals v.Id into listCV
                //                 from cv in listCV
                //                 where cvdp.Id_ComprobanteVentaOriginal == o.Id
                //                    && cv.FechaAnulacion == null
                //                    && cvdp.UserDel == null
                //                    && cv.UserDel == null
                //                 select cvdp.Cantidad).Sum();

                //if (Convert.ToInt32(Procesado) > 0)
                //    throw new ValidationException("El comprobante se ha confirmado de forma parcial, debe hacer una confirmación parcial.");


                TipoComprobante tc = new TipoComprobante() { Id = o.Id_TipoComprobante };
                db.Entry(tc).State = EntityState.Unchanged;
                db.Entry(tc).Reload();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                o.FechaMod = Sistema.ObtenerFechaHora();
                if (TodoProcesado)
                    o.FechaLiquidacion = (DateTime)o.FechaMod;

                string Nombre = Sistema.GetNombreEntidad(o.Id_TipoEntidad, o.Id_Entidad);

                List<EspeciesCantidad> AProcesar = (from d in o.Detalle
                                                    join p in ListaAProcesar on d.Id equals p.Id_ComprobanteVentaDetalle into listP
                                                    from proc in listP
                                                    where d.UserDel == null
                                                    select new EspeciesCantidad()
                                                    {
                                                        Id_Especie = d.Id_Especie,
                                                        Importe = (d.ImporteUnitario + d.ImporteIVA) * proc.Cantidad
                                                    }).ToList();

                List<EspeciesCantidad> r = (from d in AProcesar
                                            group d by d.Id_Especie into g
                                            orderby g.Sum(x => x.Importe)
                                            select new EspeciesCantidad
                                            {
                                                Id_Especie = g.Key,
                                                Importe = g.Sum(x => x.Importe)
                                            }).ToList();

                foreach (EspeciesCantidad od in r)
                {
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
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_Caja = Id_Caja,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_Comprobante = o.Id,
                            UserAdd = (int)o.UserMod
                        };
                        if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Debito = od.Importe;
                        if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Credito = od.Importe;
                        db.EspeciesCtaCte.Add(ecc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito || tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            UserAdd = (int)o.UserMod
                        };
                        if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Debito = od.Importe;
                        if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Credito = od.Importe;
                        db.EntidadesCtaCte.Add(encc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.CreditoDebito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        db.EntidadesCtaCte.Add(encc1);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.DebitoCredito)
                    {
                        EntidadesCtaCte encc = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Debito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        db.EntidadesCtaCte.Add(encc);

                        EntidadesCtaCte encc1 = new EntidadesCtaCte()
                        {
                            Concepto = string.Format("{0} {1} {2}-{3} - {4}", tc.DescripcionCorta, o.Letra, o.PuntoVenta, o.NroComprobante, Nombre),
                            Fecha = (DateTime)o.FechaMod,
                            FechaAdd = (DateTime)o.FechaMod,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Comprobante = o.Id,
                            Id_Entidad = (int)o.Id_Entidad,
                            Id_Especie = od.Id_Especie,
                            Id_TipoComprobante = o.Id_TipoComprobante,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Credito = od.Importe,
                            UserAdd = (int)o.UserMod
                        };
                        db.EntidadesCtaCte.Add(encc1);
                    }
                }

                ComprobantesVentas n = new ComprobantesVentas();

                if (tc.Id_TipoCompProcesa != null)
                {
                    int Id_TalonariosComprobantes = Sistema.ObtenerTalonario(o.Id_Sucursal, tc.Id_TipoCompProcesa.Value, o.Id_TipoEntidad, o.Id_Entidad.Value).FirstOrDefault().Key;

                    //int Id_TalonariosComprobantes = (from tc1 in db.TalonariosComprobantes
                    //                                 join pv in db.PuntosVentas on tc1.Id_PuntoVenta equals pv.Id into listPV
                    //                                 from punto in listPV
                    //                                 where tc1.UserDel == null &&
                    //                                       tc1.Id_Comprobante == tc.Id_TipoCompProcesa &&
                    //                                      (from pv in db.PuntosVentas
                    //                                       where pv.Id_Sucursal == o.Id_Sucursal
                    //                                       select pv.Id).Contains(tc1.Id_PuntoVenta) &&
                    //                                       Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                    //                                 select tc1.Id).FirstOrDefault();

                    TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                         where d.Id_TalonarioComprobante == Id_TalonariosComprobantes
                                                               && d.FechaVencimiento >= o.FechaMod
                                                               && d.NroActual < d.NroHasta
                                                         orderby d.NroDesde
                                                         select d).FirstOrDefault();

                    if (tcd != null)
                    {
                        db.TalonariosComprobantesDetalle.Attach(tcd);
                        tcd.NroActual += 1;

                        TalonariosComprobantes tc1 = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();

                        n.Fecha = (DateTime)o.FechaMod;
                        n.FechaAdd = (DateTime)o.FechaMod;
                        n.FechaVto = (DateTime)o.FechaMod;
                        n.FechaEntrega = (DateTime)o.FechaMod;
                        n.Id_CentroCosto = o.Id_CentroCosto;
                        n.Id_Entidad = o.Id_Entidad;
                        n.Id_FormaPago = o.Id_FormaPago;
                        n.Id_Sucursal = o.Id_Sucursal;
                        n.Id_TalonariosComprobantes = Id_TalonariosComprobantes;
                        n.Id_TipoComprobante = (int)tc.Id_TipoCompProcesa;
                        n.Id_TipoEntidad = o.Id_TipoEntidad;
                        n.Id_Vendedor = o.Id_Vendedor;
                        n.Id_Deposito = o.Id_Deposito;
                        n.Letra = tc1.Letra;
                        n.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                        n.Observaciones = o.Observaciones;
                        n.OtrosImpuestos = o.OtrosImpuestos;
                        n.PercepcionIIBB = o.PercepcionIIBB;
                        n.PercepcionIva = o.PercepcionIva;
                        n.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc1.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                        n.Retenciones = o.Retenciones;
                        n.Id_ComprobanteVenta_Original = o.Id;
                        n.UserAdd = (int)o.UserMod;

                        n.Detalle = new List<ComprobantesVentasDetalle>();

                        //foreach (ComprobantesVentasDetalle d in o.Detalle)
                        foreach (ComprobantesVentasDetalle d in o.Detalle.Where(t => (ListaAProcesar.Select(p => p.Id_ComprobanteVentaDetalle).ToList()).Contains(t.Id)))
                        {
                            ComprobantesVentasDetalle vd = new ComprobantesVentasDetalle()
                            {
                                Cantidad = (from a in ListaAProcesar where a.Id_ComprobanteVentaDetalle == d.Id select a.Cantidad).FirstOrDefault(), // d.Cantidad,
                                Cotizacion = d.Cotizacion,
                                Descripcion = d.Descripcion,
                                Especie = d.Especie,
                                FechaAdd = (DateTime)o.FechaMod,
                                AlicuotaIva = d.AlicuotaIva,
                                Id_AlicuotaIva = d.Id_AlicuotaIva,
                                Id_Especie = d.Id_Especie,
                                Id_Producto = d.Id_Producto,
                                Importe = (from a in ListaAProcesar where a.Id_ComprobanteVentaDetalle == d.Id select a.Cantidad * (d.ImporteUnitario + (d.ImporteUnitario * d.AlicuotaIva / 100))).FirstOrDefault(), // d.Importe,
                                ImporteCosto = d.ImporteCosto,
                                ImporteIVA = (from a in ListaAProcesar where a.Id_ComprobanteVentaDetalle == d.Id select a.Cantidad * d.ImporteUnitario * (d.AlicuotaIva / 100)).FirstOrDefault(), //d.ImporteIVA,
                                ImporteUnitario = d.ImporteUnitario,
                                PorcDescuento = d.PorcDescuento,
                                UserAdd = (int)o.UserMod,
                                ComprobanteVenta = n
                            };
                            n.Detalle.Add(vd);

                            ComprobantesVentasDetalleProcesados dp = new ComprobantesVentasDetalleProcesados()
                            {
                                Id_ComprobanteVentaDetalle = d.Id,
                                Id_ComprobanteVentaOriginal = d.Id_ComprobanteVenta,
                                Id_ComprobanteVentaProcesado = n.Id,
                                Cantidad = (from a in ListaAProcesar where a.Id_ComprobanteVentaDetalle == d.Id select a.Cantidad).FirstOrDefault(),//d.Cantidad,
                                UserAdd = (int)o.UserMod,
                                FechaAdd = (DateTime)o.FechaMod,
                            };
                            db.ComprobantesVentasDetalleProcesados.Attach(dp);
                            db.Entry(dp).State = EntityState.Added;

                        }

                        db.Entry(n).State = EntityState.Added;
                    }
                    else
                    {
                        throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    }
                }

                db.SaveChanges();

                string result = "";
                if (tc.Id_TipoCompProcesa != null)
                {
                    o.Id_ComprobanteVenta_Procesado = n.Id;
                    result = string.Format("Se ha generado el comprobante {0} {1}", (db.TipoComprobante.Where(t => t.Id == n.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()), n.Comprobante);
                }

                db.SaveChanges();

                return result;
            }
        }

        public static string Anular(ComprobantesVentas o, string MotivoAnulacion)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede anular un comprobante sin liquidar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (db.TalonariosComprobantes.Where(t => t.Id_Comprobante == o.Id_TipoComprobante).Select(t => t.Electronico).FirstOrDefault() == true)
                {
                    if (o.AFIPCAE != null)
                        throw new ValidationException("No se puede anular un comprobante electrónico.");

                    if (db.ComprobantesVentas.Where(t => t.UserDel == null && t.Id_TalonariosComprobantes == o.Id_TalonariosComprobantes).Select(t => t.Id).Max() != o.Id)
                        throw new ValidationException("No se puede anular porque existe un comprobante electrónico posterior.");

                    //***************************************************************
                    // Descuenta uno si el que se anula es el ultimo comprobante
                    //***************************************************************
                    int NroCmp = Convert.ToInt32(o.NroComprobante.ToString());

                    TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                         where d.Id_TalonarioComprobante == o.Id_TalonariosComprobantes
                                                               && d.NroActual == NroCmp
                                                         select d).FirstOrDefault();

                    if (tcd != null)
                    {
                        db.TalonariosComprobantesDetalle.Attach(tcd);
                        tcd.NroActual -= 1;
                    }
                    //***************************************************************
                }

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

                    if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito || tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito && tc.Id_TipoCompAnula == null)
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
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
                        }
                        else
                        {
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Credito) ecc.Debito = od.Importe;
                            if (tc.Id_MovimientoCaja == Enums.TipoMovimiento.Debito) ecc.Credito = od.Importe;
                        }
                        db.EspeciesCtaCte.Add(ecc);
                    }

                    if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito || tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito && tc.Id_TipoCompAnula == null)
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
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Credito) encc.Debito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
                            if (tc.Id_MovimientoEntidad == Enums.TipoMovimientoDebitoCredito.Debito) encc.Credito = od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
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
                            encc.Debito = +od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
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
                            encc1.Credito = +od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
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
                            encc.Credito = +od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
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
                            encc1.Debito = +od.Importe + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones;
                        db.EntidadesCtaCte.Add(encc1);
                    }
                }

                ComprobantesVentas n = new ComprobantesVentas();
                if (tc.Id_TipoCompAnula != null)
                {
                    int Id_TalonariosComprobantes = Sistema.ObtenerTalonario(o.Id_Sucursal, tc.Id_TipoCompAnula.Value, o.Id_TipoEntidad, o.Id_Entidad.Value).FirstOrDefault().Key;

                    //int Id_TalonariosComprobantes = (from tc1 in db.TalonariosComprobantes
                    //                                 join pv in db.PuntosVentas on tc1.Id_PuntoVenta equals pv.Id into listPV
                    //                                 from punto in listPV
                    //                                 where tc1.UserDel == null &&
                    //                                       tc1.Id_Comprobante == tc.Id_TipoCompAnula &&
                    //                                      (from pv in db.PuntosVentas
                    //                                       where pv.Id_Sucursal == o.Id_Sucursal
                    //                                       select pv.Id).Contains(tc1.Id_PuntoVenta) &&
                    //                                       Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                    //                                 select tc1.Id).FirstOrDefault();

                    TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                         where d.Id_TalonarioComprobante == Id_TalonariosComprobantes
                                                               && d.FechaVencimiento >= o.FechaLiquidacion
                                                               && d.NroActual < d.NroHasta
                                                         orderby d.NroDesde
                                                         select d).FirstOrDefault();

                    if (tcd != null)
                    {
                        db.TalonariosComprobantesDetalle.Attach(tcd);
                        tcd.NroActual += 1;

                        TalonariosComprobantes tc1 = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();

                        n = new ComprobantesVentas()
                        {
                            Fecha = (DateTime)o.FechaLiquidacion,
                            FechaAdd = (DateTime)o.FechaLiquidacion,
                            FechaVto = (DateTime)o.FechaLiquidacion,
                            FechaEntrega = (DateTime)o.FechaLiquidacion,
                            Id_CentroCosto = o.Id_CentroCosto,
                            Id_Entidad = o.Id_Entidad,
                            Id_FormaPago = o.Id_FormaPago,
                            Id_Sucursal = o.Id_Sucursal,
                            Id_TalonariosComprobantes = Id_TalonariosComprobantes,
                            Id_TipoComprobante = (int)tc.Id_TipoCompAnula,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Id_Vendedor = o.Id_Vendedor,
                            Id_Deposito = o.Id_Deposito,
                            Letra = tc1.Letra,
                            NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000"),
                            Observaciones = o.Observaciones,
                            OtrosImpuestos = o.OtrosImpuestos,
                            PercepcionIIBB = o.PercepcionIIBB,
                            PercepcionIva = o.PercepcionIva,
                            PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc1.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000"),
                            Retenciones = o.Retenciones,
                            Id_ComprobanteVenta_Original = o.Id,
                            UserAdd = (int)o.UserMod
                        };
                        n.Detalle = new List<ComprobantesVentasDetalle>();
                        foreach (ComprobantesVentasDetalle d in o.Detalle)
                        {
                            ComprobantesVentasDetalle vd = new ComprobantesVentasDetalle()
                            {
                                Cantidad = d.Cantidad,
                                Cotizacion = d.Cotizacion,
                                Descripcion = d.Descripcion,
                                Especie = d.Especie,
                                FechaAdd = (DateTime)o.FechaLiquidacion,
                                AlicuotaIva = d.AlicuotaIva,
                                Id_AlicuotaIva = d.Id_AlicuotaIva,
                                Id_Especie = d.Id_Especie,
                                Id_Producto = d.Id_Producto,
                                Importe = d.Importe,
                                ImporteCosto = d.ImporteCosto,
                                ImporteIVA = d.ImporteIVA,
                                ImporteUnitario = d.ImporteUnitario,
                                PorcDescuento = d.PorcDescuento,
                                UserAdd = (int)o.UserMod
                            };
                            n.Detalle.Add(vd);
                        }

                        db.Entry(n).State = EntityState.Added;
                    }
                    else
                    {
                        throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    }
                }

                db.SaveChanges();

                string result = "";
                if (tc.Id_TipoCompAnula != null)
                {
                    o.Id_ComprobanteVenta_Anulado = n.Id;
                    result = string.Format("Se ha generado el comprobante {0} {1}", (db.TipoComprobante.Where(t => t.Id == n.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()), n.Comprobante);
                }

                db.SaveChanges();

                return result;
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from v in db.ComprobantesVentas
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
                         AFIPCAE = v.AFIPCAE,
                         Centro_Costo = cen.Descripcion,
                         Fecha = v.Fecha,
                         FechaAdd = v.FechaAdd,
                         FechaAnulacion = v.FechaAnulacion,
                         FechaEntrega = v.FechaEntrega,
                         FechaEntregado = v.FechaEntregado,
                         FechaImpreso = v.FechaImpreso,
                         FechaLiquidacion = v.FechaLiquidacion,
                         FechaMod = v.FechaMod,
                         FechaVto = v.FechaVto,
                         FechaVtoCAE = v.FechaVtoCAE,
                         Id_CentroCosto = v.Id_CentroCosto,
                         Id_ComprobanteVenta_Original = v.Id_ComprobanteVenta_Original,
                         Id_ComprobanteVenta_Anulado = v.Id_ComprobanteVenta_Anulado,
                         Id_ComprobanteVenta_Procesado = v.Id_ComprobanteVenta_Procesado,
                         Id_Entidad = v.Id_Entidad,
                         Id_EntidadDomicilioEntrega = v.Id_EntidadDomicilioEntrega,
                         Id_FormaPago = v.Id_FormaPago,
                         Id_Sucursal = v.Id_Sucursal,
                         Id_TalonariosComprobantes = v.Id_TalonariosComprobantes,
                         Id_TipoComprobante = v.Id_TipoComprobante,
                         Id_TipoEntidad = v.Id_TipoEntidad,
                         Id_Vendedor = v.Id_Vendedor,
                         //Importe = db.ComprobantesVentasDetalle.Where(rd => rd.Id_ComprobanteVenta == v.Id).Select(rd => rd.Importe).Sum() + v.OtrosImpuestos + v.PercepcionIIBB + v.PercepcionIva + v.Retenciones,
                         //Importe_Pesos = db.ComprobantesVentasDetalle.Where(rd => rd.Id_ComprobanteVenta == v.Id).Select(rd => rd.Importe * rd.Cotizacion).Sum() + v.OtrosImpuestos + v.PercepcionIIBB + v.PercepcionIva + v.Retenciones,
                         Importe = v.Importe,
                         ImportePesos = v.ImportePesos,
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
                         ObservacionesCAE = v.ObservacionesCAE,
                         OtrosImpuestos = v.OtrosImpuestos,
                         PercepcionIIBB = v.PercepcionIIBB,
                         PercepcionIva = v.PercepcionIva,
                         PuntoVenta = v.PuntoVenta,
                         Retenciones = v.Retenciones,
                         Sucursal = suc.Descripcion,
                         Id_Deposito = v.Id_Deposito,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();

                return r;
            }
        }

        public static string GetEspecie(int Id_Especie)
        {
            using (var db = new GestionContext())
            {
                return db.Especies.Where(t => t.Id == Id_Especie).Select(t => t.Descripcion).FirstOrDefault();
            }
        }

        public bool EsElectronico()
        {
            using (var db = new GestionContext())
            {
                return db.TalonariosComprobantes.Where(t => t.Id_Comprobante == Comprobante.Id_TipoComprobante).Select(t => t.Electronico).FirstOrDefault();
            }
        }

        public static decimal GetCotizacion(int Id_Especie)
        {
            using (var db = new GestionContext())
            {
                return db.Especies.Where(t => t.Id == Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
            }
        }

        public static decimal GetImportePagoComprobante(int Id_Comprobante)
        {
            using (var db = new TesoreriaContext())
            {
                return (from cc in db.ComprobantesVentas
                        join oc in db.RecibosComprobantes on cc.Id equals oc.Id_ComprobantesVentas into listComp
                        from opc in listComp
                        join o in db.Recibos on opc.Id_Recibo equals o.Id into listOP
                        from op in listOP
                        where op.UserDel == null
                           && cc.Id == Id_Comprobante
                           && cc.UserDel == null
                           && opc.UserDel == null
                           && op.Fecha_Anulacion == null
                        select opc.ImportePago).DefaultIfEmpty(0).Sum();
            }
        }

        public static string ObtenerMail(Enums.TipoEntidad Id_TipoEntidad, int Id_Entidad)
        {
            using (var db = new TesoreriaContext())
            {
                if (Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                    return db.Clientes.Where(t => t.Id == Id_Entidad).Select(t => t.Email).FirstOrDefault();

                if (Id_TipoEntidad == Enums.TipoEntidad.Personal)
                    return db.Personal.Where(t => t.Id == Id_Entidad).Select(t => t.Email).FirstOrDefault();

                if (Id_TipoEntidad == Enums.TipoEntidad.Proveedor)
                    return db.Proveedores.Where(t => t.Id == Id_Entidad).Select(t => t.Email).FirstOrDefault();

                if (Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero)
                    return db.ProvFinancieros.Where(t => t.Id == Id_Entidad).Select(t => t.Email).FirstOrDefault();

                else return "";
            }
        }

        public static int DuplicarVenta(ComprobantesVentas o, int Id_Comprobante, Enums.TipoEntidad Id_TipoEntidad, int Id_Entidad)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                ComprobantesVentas cv = new ComprobantesVentas();
                db.ComprobantesVentas.Attach(cv);
                db.Entry(cv).State = EntityState.Added;

                cv.FechaAdd = Sistema.ObtenerFechaHora();
                cv.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                cv.Id_Deposito = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Deposito));
                cv.Id_Sucursal = o.Id_Sucursal;
                cv.Id_CentroCosto = o.Id_CentroCosto;
                cv.Id_TipoComprobante = Id_Comprobante;
                cv.Id_TipoEntidad = Id_TipoEntidad;
                cv.Id_Entidad = Id_Entidad;
                cv.Id_Vendedor = o.Id_Vendedor;
                cv.Id_FormaPago = o.Id_FormaPago;
                cv.Observaciones = o.Observaciones;
                cv.Id_TalonariosComprobantes = Sistema.ObtenerTalonario(cv.Id_Sucursal, cv.Id_TipoComprobante, cv.Id_TipoEntidad, cv.Id_Entidad.Value).FirstOrDefault().Key;

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == cv.Id_TalonariosComprobantes
                                                           && d.FechaVencimiento >= cv.FechaAdd
                                                           && d.NroActual < d.NroHasta
                                                     orderby d.NroDesde
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual += 1;

                    TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                    cv.Letra = tc.Letra;

                    cv.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                    cv.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                }
                else
                    throw new ValidationException("No hay talonarios vigentes para este comprobante.");

                cv.FechaVto = cv.FechaEntrega = cv.Fecha = cv.FechaAdd;
                cv.PercepcionIva = o.PercepcionIva;
                cv.OtrosImpuestos = o.OtrosImpuestos;
                cv.Retenciones = o.Retenciones;
                cv.PercepcionIIBB = o.PercepcionIIBB;
                cv.Importe = o.Importe; // Convert.ToDecimal(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) - ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100)) + t.ImporteIVA));
                cv.ImportePesos = o.ImportePesos;

                cv.Detalle = new List<ComprobantesVentasDetalle>();

                foreach (ComprobantesVentasDetalle z in o.Detalle)
                {
                    cv.Detalle.Add(new ComprobantesVentasDetalle()
                    {
                        AlicuotaIva = z.AlicuotaIva,
                        Cantidad = z.Cantidad,
                        Cotizacion = z.Cotizacion,
                        Descripcion = z.Descripcion,
                        Especie = z.Especie,
                        FechaAdd = cv.FechaAdd,
                        Id_AlicuotaIva = z.Id_AlicuotaIva,
                        Id_Especie = z.Id_Especie,
                        Id_Producto = z.Id_Producto,
                        Id_ProductoCompuesto = z.Id_ProductoCompuesto,
                        Importe = z.Importe,
                        ImporteCosto = z.ImporteCosto,
                        ImporteIVA = z.ImporteIVA,
                        ImporteUnitario = z.ImporteUnitario,
                        PorcDescuento = z.PorcDescuento,
                        UserAdd = cv.UserAdd
                    });
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();


                return cv.Id;
            }
        }

        public void GenerarArchivoDeuda()
        {
            try
            {
                string Ruta = Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_RutaGeneraArchivoDeudas);

                using (var db = new GestionContext())
                {
                    var selectdata = (from ecc in db.EntidadesCtaCte
                                      join e in db.Especies on ecc.Id_Especie equals e.Id
                                      where ecc.UserDel == null
                                      group new { ecc, e } by new { ecc.Id_TipoEntidad, ecc.Id_Entidad, ecc.Id_Especie, e.Descripcion } into g
                                      orderby g.Key.Id_TipoEntidad, g.Key.Id_Entidad
                                      select new
                                      {
                                          Tipo_Entidad = g.Key.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? "Clientes"
                                                         : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? "Proveedores"
                                                         : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? "Prov. Financieros"
                                                         : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Personal ? "Personal"
                                                         : "",
                                          Entidad = g.Key.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.FirstOrDefault(c => c.Id == g.Key.Id_Entidad).Nombre
                                                    : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.FirstOrDefault(p => p.Id == g.Key.Id_Entidad).Nombre
                                                    : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? db.ProvFinancieros.FirstOrDefault(pf => pf.Id == g.Key.Id_Entidad).Nombre
                                                    : g.Key.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(p => p.Id == g.Key.Id_Entidad).Select(p => p.Apellido + ", " + p.Nombre).FirstOrDefault()
                                                    : "",
                                          Especie = g.Key.Descripcion,
                                          Saldo = g.Sum(x => x.ecc.Debito) - g.Sum(x => x.ecc.Credito)
                                      }).ToList();

                    selectdata = selectdata.OrderBy(x => x.Tipo_Entidad).ThenBy(x => x.Entidad).ToList();


                    // Crea el archivo de Excel
                    string nombreArchivo = "Deuda.xlsx";
                    //string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
                    string rutaArchivo = Path.Combine(Ruta, nombreArchivo);

                    ExcelPackage excel = new ExcelPackage();
                    var workSheet = excel.Workbook.Worksheets.Add("Deuda");
                    workSheet.TabColor = Color.Black;
                    workSheet.DefaultRowHeight = 12;
                    workSheet.Row(1).Height = 20;
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;
                    workSheet.Cells[1, 1].Value = "Tipo Entidad";
                    workSheet.Cells[1, 2].Value = "Entidad";
                    workSheet.Cells[1, 3].Value = "Especie";
                    workSheet.Cells[1, 4].Value = "Saldo";
                    workSheet.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#B4C6E7"));

                    workSheet.Cells["A2"].LoadFromCollection(selectdata);

                    workSheet.Cells["A:D"].AutoFitColumns();

                    FileStream objFileStrm = File.Create(rutaArchivo);
                    objFileStrm.Close();
                    File.WriteAllBytes(rutaArchivo, excel.GetAsByteArray());
                    excel.Dispose();
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
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
                    //using (var db = new GestionContext())
                    return Sistema.ObtenerEntidades(TipoEntidad);
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

        public class SearchResult : ComprobantesVentas
        {
            public string Sucursal { get; set; }
            public string Nombre_Entidad { get; set; }
            public string Centro_Costo { get; set; }
            //public decimal Importe_Pesos { get; set; }
            //public decimal Importe { get; set; }
        }

        public static TalonariosComprobantes Reporte(ComprobantesVentas o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                return db.TalonariosComprobantes.Where(t => t.UserDel == null && t.Id == o.Id_TalonariosComprobantes).FirstOrDefault();
            }
        }

        public static List<DatosReporte> ImprimeComprobante(ComprobantesVentas o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                if (o.Detalle == null) db.Entry(o).Collection(p => p.Detalle).Load();
                if (o.Impuestos == null) db.Entry(o).Collection(p => p.Impuestos).Load();

                List<DatosReporte> l = new List<DatosReporte>();

                EntidadReporte EntReporte = new EntidadReporte();
                switch (o.Id_TipoEntidad)
                {
                    case Enums.TipoEntidad.Cliente:
                        Clientes c = new Clientes() { Id = o.Id_Entidad.Value };
                        db.Entry(c).State = EntityState.Unchanged;
                        db.Entry(c).Reload();

                        EntReporte.Nombre = (c.Empresa == "" || c.Empresa == null) ? c.Nombre : c.Empresa;
                        EntReporte.Cuit = c.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == c.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = c.Domicilio;
                        EntReporte.Localidad = (db.Localidades.Where(t => t.Id == c.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
                        EntReporte.Telefono = (db.ClientesContactos.Where(t => t.Id_Cliente == c.Id && t.UserDel == null).Select(t => t.Nombre + " " + t.Telefono1 + " " + t.Telefono2).FirstOrDefault());
                        EntReporte.DomicilioEntrega = (db.ClientesEntregas.Where(t => t.Id == o.Id_EntidadDomicilioEntrega).Select(t => t.Direccion + " " + t.Telefono + " " + t.Nombre).FirstOrDefault());
                        break;

                    case Enums.TipoEntidad.Personal:
                        Personal p = new Personal() { Id = o.Id_Entidad.Value };
                        db.Entry(p).State = EntityState.Unchanged;
                        db.Entry(p).Reload();

                        EntReporte.Nombre = p.Nombre;
                        EntReporte.Cuit = p.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == p.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = p.DomicilioCalle + " " + p.DomicilioNro + " " + p.DomicilioPiso + " " + p.DomicilioDpto;
                        EntReporte.Localidad = p.CodPos.Value.ToString();
                        break;

                    case Enums.TipoEntidad.Proveedor:
                        Proveedores pr = new Proveedores() { Id = o.Id_Entidad.Value };
                        db.Entry(pr).State = EntityState.Unchanged;
                        db.Entry(pr).Reload();

                        //EntReporte.Nombre = pr.Nombre;
                        EntReporte.Nombre = (pr.Empresa == "" || pr.Empresa == null) ? pr.Nombre : pr.Empresa;
                        EntReporte.Cuit = pr.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == pr.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = pr.Domicilio;
                        EntReporte.Localidad = (db.Localidades.Where(t => t.Id == pr.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
                        break;

                    case Enums.TipoEntidad.Proveedor_Financiero:
                        ProvFinancieros pf = new ProvFinancieros() { Id = o.Id_Entidad.Value };
                        db.Entry(pf).State = EntityState.Unchanged;
                        db.Entry(pf).Reload();

                        EntReporte.Nombre = pf.Nombre;
                        EntReporte.Cuit = pf.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == pf.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = pf.Domicilio;
                        EntReporte.Localidad = (db.Localidades.Where(t => t.Id == pf.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
                        break;
                }

                int IdEspecie = o.Detalle.First().Id_Especie;
                EntReporte.SaldoCtaCte = (from e in db.EntidadesCtaCte
                                          where e.Id_TipoEntidad == o.Id_TipoEntidad
                                                && e.Id_Entidad == o.Id_Entidad
                                                && e.Id_Especie == IdEspecie
                                                && e.UserDel == null
                                          select new { D = e.Debito, C = e.Credito }).Sum(s => (decimal?)(s.D - s.C)) ?? 0;

                int Id_Empresa = (from e in db.Empresas
                                  join s in db.Sucursales on e.Id equals s.Id_Empresa into listSuc
                                  from suc in listSuc
                                  where suc.Id == o.Id_Sucursal
                                  select e.Id).FirstOrDefault();

                Empresas emp = new Empresas() { Id = Id_Empresa };
                db.Entry(emp).State = EntityState.Unchanged;
                db.Entry(emp).Reload();

                Localidades loc = new Localidades();
                if (emp.Id_CodPostal > 0)
                {
                    loc.Id = emp.Id_CodPostal.Value;
                    db.Entry(loc).State = EntityState.Unchanged;
                    db.Entry(loc).Reload();
                }

                EmpresasReporte EmpReporte = new EmpresasReporte()
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre,
                    Fantasia = emp.Fantasia,
                    Direccion = emp.Direccion,
                    Id_CodPostal = loc.CodPostal,
                    Localidad = loc.Localidad,
                    Cuit = emp.Cuit,
                    Id_TipoIva = emp.Id_TipoIva,
                    TipoIva = (db.TipoIva.Where(t => t.Id == emp.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault()),
                    IngresosBrutos = emp.IngresosBrutos,
                    InicioActividades = emp.InicioActividades
                };

                string Especie = db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault();

                DatosReporte i = new DatosReporte()
                {
                    Empresa = EmpReporte,
                    Entidad = EntReporte,
                    Detalle = o.Detalle,
                    Impuestos = o.Impuestos,
                    Registro = o,
                    Letra = o.Letra,
                    NroCodigo = (db.TalonariosComprobantes.Where(t => t.Id == o.Id_TalonariosComprobantes).Select(t => t.NroCodigo).FirstOrDefault()),
                    PuntoVenta = o.PuntoVenta,
                    NroComprobante = o.NroComprobante,
                    Fecha = o.Fecha,
                    Observaciones = o.Observaciones,
                    TotalIva = o.Detalle.Sum(t => t.ImporteIVA),
                    SubTotal = o.Detalle.Sum(t => t.Importe) - o.Detalle.Sum(t => t.ImporteIVA),
                    SubTotal2 = o.Detalle.Sum(t => t.Importe) - o.Detalle.Sum(t => t.ImporteIVA) + o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + o.Impuestos.Where(t => t.Borrado == false && t.UserDel == null).Select(t => t.Importe).Sum(),
                    ImporteTotal = o.Importe.Value,  // o.Detalle.Sum(t => t.Importe),
                    TotalEnLetras = Especie + " " + NumeroALetras.Convertir(o.Importe.Value.ToString()),
                    //TotalEnLetras = (db.Especies.Where(t => t.Id == o.Detalle.First().Id_Especie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(o.Detalle.Sum(t => t.Importe).ToString()),
                    AFIPCAE = o.AFIPCAE,
                    Comprobante = (db.TipoComprobante.Where(t => t.Id == o.Id_TipoComprobante).Select(t => t.Descripcion).FirstOrDefault()),
                    FechaEntrega = o.FechaEntrega,
                    FechaVto = o.FechaVto,
                    FechaVtoCAE = o.FechaVtoCAE,
                    FormaPago = (db.FormasPagos.Where(t => t.Id == o.Id_FormaPago).Select(t => t.Descripcion).FirstOrDefault()),
                    ObservacionesCAE = o.ObservacionesCAE,
                    OtrosImpuestos = o.OtrosImpuestos,
                    PercepcionIIBB = o.PercepcionIIBB,
                    PercepcionIva = o.PercepcionIva,
                    Percepciones = o.Retenciones,
                    ImpuestosTotal = o.OtrosImpuestos + o.PercepcionIIBB + o.PercepcionIva + o.Retenciones + o.Impuestos.Where(t => t.Borrado == false && t.UserDel == null).Select(t => t.Importe).Sum(),
                    Sucursal = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Descripcion).FirstOrDefault()),
                    Vendedor = (db.Vendedores.Where(t => t.Id == o.Id_Vendedor).Select(t => t.Nombre).FirstOrDefault()),
                    FechaLiquidacion = o.FechaLiquidacion,
                    Pedido = (db.Pedidos.Where(t => t.UserDel == null && t.Id_ComprobanteGenerado == o.Id).Select(t => t.Letra + "-" + t.PuntoVenta + "-" + t.NroComprobante).FirstOrDefault()),
                    ImporteTotalSinDescuento_MAL = o.Detalle.Sum(t => t.ImporteSINDescuentoCONIva_MAL),
                    ImporteTotalDescuento_MAL = o.Detalle.Sum(t => t.ImporteDescuentoCONIva_MAL)
                };

                if (i.FechaVtoCAE != "" && i.FechaVtoCAE != null)
                {
                    i.FechaVtoCAE = i.FechaVtoCAE.ToString().Substring(6, 2) + "/" + i.FechaVtoCAE.ToString().Substring(4, 2) + "/" + i.FechaVtoCAE.ToString().Substring(0, 4);
                    string IdCompAFIP = (from tc in db.TalonariosComprobantes
                                         join a in db.AFIP_Comprobantes on tc.Id_AFIP_Comprobante equals a.Id into listAF
                                         from ac in listAF
                                         where tc.Id == o.Id_TalonariosComprobantes
                                         select ac.Id).FirstOrDefault().ToString("00");

                    i.CodigoBarraCAE = CalcularDigitoValidadorAFIP(emp.Cuit.Replace("-", "").ToString() + IdCompAFIP + o.PuntoVenta + o.AFIPCAE + o.FechaVtoCAE);

                    /*Texto codificado en el QR:
                      https://www.afip.gob.ar/fe/qr/?p=eyJ2ZXIiOjEsImZlY2hhIjoiMjAyMC0xMC0xMyIsImN1aXQiOjMwMDAwMDAwMDA3LCJwdG9WdGEiOjEwLCJ0aXBvQ21wIjoxLCJucm9DbXAiOjk0LCJpbXBvcnRlIjoxMjEwMCwibW9uZWRhIjoiRE9MIiwiY3R6Ijo2NSwidGlwb0RvY1JlYyI6ODAsIm5yb0RvY1JlYyI6MjAwMDAwMDAwMDEsInRpcG9Db2RBdXQiOiJFIiwiY29kQXV0Ijo3MDQxNzA1NDM2NzQ3Nn0=

                    JSON con datos del comprobante:
                    { "ver":1,"fecha":"2020-10-13","cuit":30000000007,"ptoVta":10,"tipoCmp":1,"nroCmp":94,"importe":12100,"moneda":"DOL","ctz":65,"tipoDocRec":80,"nroDocRec":20000000001,"tipoCodAut":"E","codAut":70417054367476}
                     */

                     int Id_AFIP_Comprobantes = db.TalonariosComprobantes.Where(t => t.Id == o.Id_TalonariosComprobantes).Select(t => t.Id_AFIP_Comprobante).FirstOrDefault().Value;

                    if (EntReporte.Cuit == null)
                        throw new ValidationException("La entidad no posee un cuit cargado.");

                    string plainText = "{\"ver\":1,\"fecha\":\"" + i.Fecha.ToString("yyyy-MM-dd") +
                                       "\",\"cuit\":" + emp.Cuit.Replace("-", "") +
                                       ",\"ptoVta\":" + int.Parse(o.PuntoVenta).ToString() +
                                       ",\"tipoCmp\":" + Id_AFIP_Comprobantes +
                                       ",\"nroCmp\":" + int.Parse(o.NroComprobante).ToString() +
                                       ",\"importe\":" + i.ImporteTotal.ToString().Replace(",", ".") +
                                       ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + EntReporte.Cuit.Replace("-", "") +
                                       ",\"tipoCodAut\":\"E\",\"codAut\":" + o.AFIPCAE + "}";


                    i.CodigoQrAfip = "https://www.afip.gob.ar/fe/qr/?p=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

                }
                else
                {
                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobanteVentaCreaCAE)))
                    {
                        if (!db.TalonariosComprobantes.Where(t => t.Id == o.Id_TalonariosComprobantes).Select(t => t.Electronico).FirstOrDefault())
                        {
                            i.FechaVtoCAE = i.Fecha.AddDays(10).ToString("dd/MM/yyyy");
                            i.AFIPCAE = "690676" + (98521574 - Convert.ToInt64(i.NroComprobante));
                            i.CodigoBarraCAE = CalcularDigitoValidadorAFIP(emp.Cuit.Replace("-", "").ToString() + "00" + o.PuntoVenta + i.AFIPCAE + i.Fecha.ToString("ddMMyyyy"));

                            string plainText = "{\"ver\":1,\"fecha\":\"2020-10-13\",\"cuit\":30000000007,\"ptoVta\":10,\"tipoCmp\":1,\"nroCmp\":94,\"importe\":12100,\"moneda\":\"DOL\",\"ctz\":65,\"tipoDocRec\":80,\"nroDocRec\":20000000001,\"tipoCodAut\":\"E\",\"codAut\":70417054367476}";
                            i.CodigoQrAfip = "https://www.afip.gob.ar/fe/qr/?p=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
                        }
                    }
                }

                foreach (ComprobantesVentasDetalle x in o.Detalle)
                {
                    x.Especie = db.Especies.Where(t => t.Id == x.Id_Especie).Select(t => t.Descripcion).FirstOrDefault();

                    if (x.Id_Producto != null)
                    {
                        Productos p = db.Productos.Where(t => t.Id == x.Id_Producto).FirstOrDefault();
                        if (p != null)
                        {
                            x.Unidad_Venta = db.ProductosUnidadVenta.Where(t => t.Id == p.Id_UnidadVenta).Select(t => t.Descripcion).FirstOrDefault();
                            x.Unidad_Stock = db.ProductosUnidadVenta.Where(t => t.Id == p.Id_UnidadStock).Select(t => t.Descripcion).FirstOrDefault();


                            if (p.Id_UnidadStock != null)
                            {
                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock)))
                                    x.Descripcion = Convert.ToInt16(x.CantidadStock) + " - " + x.Descripcion;

                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStockConDescripcion)))
                                    x.Descripcion = Convert.ToInt16(x.CantidadStock) + " " + x.Unidad_Stock + " - " + x.Descripcion;
                            }
                        }
                    }
                }

                int imp = 1;
                foreach (ComprobantesVentasImpuestos x in o.Impuestos)
                {
                    x.Impuesto = OrdenesPagoManager.NombreImpuesto(x.Id_Impuesto);
                    switch (imp)
                    {
                        case 1:
                            i.Impuestos1_Nombre = x.Impuesto + ' ' + x.Alicuota.ToString() + " %";
                            i.Impuestos1_Importe = x.Importe;
                            break;
                        case 2:
                            i.Impuestos2_Nombre = x.Impuesto + ' ' + x.Alicuota.ToString() + " %";
                            i.Impuestos2_Importe = x.Importe;
                            break;
                        case 3:
                            i.Impuestos3_Nombre = x.Impuesto + ' ' + x.Alicuota.ToString() + " %";
                            i.Impuestos3_Importe = x.Importe;
                            break;
                        case 4:
                            i.Impuestos4_Nombre = x.Impuesto + ' ' + x.Alicuota.ToString() + " %";
                            i.Impuestos4_Importe = x.Importe;
                            break;
                        case 5:
                            i.Impuestos5_Nombre = x.Impuesto + ' ' + x.Alicuota.ToString() + " %";
                            i.Impuestos5_Importe = x.Importe;
                            break;
                    }
                    imp += 1;
                }
                l.Add(i);

                return l;
            }
        }

        private static string CalcularDigitoValidadorAFIP(string Valor)
        {
            int SumaImpares = 0;
            int SumaPares = 0;
            int i = 1;

            foreach (char x in Valor.ToCharArray())
            {
                if ((i % 2) == 0)
                    SumaPares += Convert.ToInt32(x.ToString());
                else
                    SumaImpares += Convert.ToInt32(x.ToString());
                i += 1;
            }

            int Total = (SumaImpares * 3) + SumaPares;
            int Verificador = Convert.ToInt32(Total.ToString().Substring(Total.ToString().Length - 1, 1));

            if (Verificador > 0)
                Verificador = 10 - Verificador;

            return Valor + Verificador.ToString();
        }

        public class EspeciesCantidad
        {
            public int Id_Especie { get; set; }
            public decimal Importe { get; set; }
        }

        public class JsonAfip
        {
            public int ver { get; set; } //1,
            public string fecha { get; set; } //2020-10-13
            public Int64 cuit { get; set; } //30000000007
            public int ptoVta { get; set; } //10
            public int tipoCmp { get; set; } //1
            public int nroCmp { get; set; } //94
            public decimal importe { get; set; } //12100
            public string moneda { get; set; } //DOL
            public decimal ctz { get; set; } //65
            public int tipoDocRec { get; set; } //80
            public Int64 nroDocRec { get; set; } //20000000001
            public string tipoCodAut { get; set; } //E
            public Int64 codAut { get; set; } //70417054367476

        }
    }

    public class JsonSerializer
    {
        public string Serialize<T>(T aObject) where T : new()
        {
            T serializedObj = new T();
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, aObject);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public T Deserialize<T>(string aJSON) where T : new()
        {
            T deserializedObj = new T();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(aJSON));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(aJSON.GetType());
            deserializedObj = (T)ser.ReadObject(ms);
            ms.Close();
            return deserializedObj;
        }
    }

}
