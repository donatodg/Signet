namespace VENET_Tesoreria_BL
{
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
    using static VENET_Common.Reportes.OrdenesPagoReporte;

    public class OrdenesPagoManager : IDisposable
    {
        private TesoreriaContext db;
        public decimal TotalMes { private set; get; }
        public OrdenesPago OP { get; set; }

        public OrdenesPagoManager(OrdenesPago o)
        {
            db = new TesoreriaContext();
            OP = o;

            db.OrdenesPago.Attach(OP);

            if (OP.Id > 0)
            {
                db.Entry(OP).Reload();

                if (OP.Detalle == null)
                    db.Entry(OP).Collection(p => p.Detalle).Load();

                if (OP.Detalle.Count > 0)
                    foreach (OrdenesPagoDetalle row in OP.Detalle)
                        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();

                if (OP.Impuestos == null)
                    db.Entry(OP).Collection(p => p.Impuestos).Load();

                if (OP.Impuestos.Count > 0)
                    foreach (OrdenesPagoImpuestos row in OP.Impuestos.Where(t => t.Id_Provincia > 0))
                        row.Provincia = db.Provincias.Where(t => t.Id == row.Id_Provincia).Select(t => t.Descripcion).SingleOrDefault();

                if (OP.Comprobantes == null)
                    db.Entry(OP).Collection(p => p.Comprobantes).Load();

                //if (OP.Comprobantes.Count > 0)
                //    foreach (OrdenesPagoComprobantes row in OP.Comprobantes)
                //        row.Comprobante = db.ComprobantesCompras.Where(t => t.Id == row.Id_ComprobantesCompras).Select(t => t.Comprobante).FirstOrDefault();

            }
            else
            {
                if (OP.TipoEntidad == 0) OP.TipoEntidad = Enums.TipoEntidad.Proveedor;
                OP.Concepto = "Pago";
                OP.Fecha = Sistema.ObtenerFechaHora();
                if (Sistema.CentrosCostos.Count() > 0)
                    OP.Id_CentroCosto = Sistema.CentrosCostos.First().Key;

                if (OP.Detalle == null) db.Entry(OP).Collection(p => p.Detalle).Load();
                if (OP.Impuestos == null) db.Entry(OP).Collection(p => p.Impuestos).Load();
                if (OP.Comprobantes == null) db.Entry(OP).Collection(p => p.Comprobantes).Load();

                if (OP.Id_Sucursal == 0)
                    if (Sistema.Sucursales.Count() > 0)
                        OP.Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
            }
        }

        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return Sistema.ObtenerEntidades(OP.TipoEntidad);
            }
        }

        public List<KeyNamePair> Letra
        {
            get
            {
                return (from tc in db.TalonariosComprobantes
                        join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                        from punto in listPV
                        where tc.UserDel == null &&
                              tc.Id_Comprobante == 7 &&
                             (from pv in db.PuntosVentas
                              where pv.Id_Sucursal == OP.Id_Sucursal
                              select pv.Id).Contains(tc.Id_PuntoVenta) &&
                              Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                        select new KeyNamePair()
                        {
                            Key = tc.Id,
                            Name = tc.Letra + "-" + punto.PuntoVenta
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public static string NombreImpuesto(int Id_Impuesto)
        {
            using (var db = new TesoreriaContext())
                return db.TipoImpuestos.Where(t => t.Id == Id_Impuesto).Select(t => t.Descripcion).FirstOrDefault();
        }

        public static ComprobantesCompras GetComprobanteCompra(int Id)
        {
            using (var db = new TesoreriaContext())
                return db.ComprobantesCompras.Where(t => t.Id == Id).Select(t => t).FirstOrDefault();
        }

        public List<OrdenesPagoImpuestos> EntidadesAlicuotas()
        {
            List<OrdenesPagoImpuestos> r = new List<OrdenesPagoImpuestos>();

            using (GestionContext db = new GestionContext())
            {
                r = (from e in db.EntidadesImpuestosAlicuotas
                     join impA in db.ImpuestosAlicuotas on e.Id_ImpuestoAlicuota equals impA.Id into listIA
                     from ia in listIA
                     join imp in db.TipoImpuestos on ia.Id_Impuesto equals imp.Id into listImp
                     from i in listImp
                     join pr in db.Provincias on ia.Id_Provincia equals pr.Id into listPr
                     from p in listPr.DefaultIfEmpty()
                     where e.Id_TipoEntidad == OP.TipoEntidad
                        && e.Id_Entidad == OP.Id_Entidad
                        && i.Id_TipoImpuesto == Enums.TipoImpuesto.Retencion
                        //&& i.Retencion == true
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
            }

            DateTime f = Sistema.ObtenerFecha();
            f = new DateTime(f.Year, f.Month, 01);
            DateTime f1 = f.AddMonths(1).AddDays(-1);

            TotalMes = (from o in db.OrdenesPago
                        join det in db.OrdenesPagoDetalle on o.Id equals det.Id_OrdenPago into listDet
                        from opd in listDet
                        where o.TipoEntidad == OP.TipoEntidad
                           && o.Id_Entidad == OP.Id_Entidad
                           && o.UserDel == null
                           && o.Fecha_Anulacion == null
                           && o.Fecha_Liquidacion >= f
                           && o.Fecha_Liquidacion <= f1
                           && opd.UserDel == null
                        select opd.Importe * opd.Cotizacion).DefaultIfEmpty(0).Sum();

            return r;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (OP.Detalle.Count == 0)
                throw new ValidationException("No se ingresó el detalle de la orden de pago.");

            if (OP.Detalle.Where(t => t.Borrado == false).Select(t => t.Importe).Sum() + decimal.Round((from d in OP.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum(), 2) != (OP.Importe))
                //if (OP.Detalle.Where(t => t.Borrado == false).Select(t => t.Importe).Sum() + decimal.Round((from d in OP.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum(), 2) != (OP.Importe + decimal.Round(OP.Impuestos.Where(t => t.Borrado == false).Select(t => t.Importe).DefaultIfEmpty(0).Sum(), 2)))
                throw new ValidationException("El importe del detalle es distinto al importe ingresado.");

            if (OP.Comprobantes != null)
                if (OP.Detalle.Where(t => t.Borrado == false).Select(t => t.Importe).Sum() + OP.Impuestos.Where(t => t.Borrado == false).Select(t => t.Importe).DefaultIfEmpty(0).Sum() < OP.Comprobantes.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())
                    throw new ValidationException("El importe ingresado es menor a la asociación de los comprobantes.");

            if (OP.Fecha > Sistema.ObtenerFechaHora())
                throw new ValidationException("La fecha ingresada es mayor a hoy.");

            if (OP.Id == 0)
            {
                db.Entry(OP).State = EntityState.Added;
                OP.FechaAdd = Sistema.ObtenerFechaHora();
                OP.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                DateTime fecha = Sistema.ObtenerFecha();

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == OP.Id_TalonariosComprobantes
                                                           && d.FechaVencimiento >= fecha
                                                           && d.NroActual < d.NroHasta
                                                     orderby d.NroDesde
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual += 1;

                    TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                    OP.Letra = tc.Letra;

                    OP.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                    OP.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                }
                else
                {
                    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                }
            }
            else
            {
                db.Entry(OP).State = EntityState.Modified;
                OP.FechaMod = Sistema.ObtenerFechaHora();
                OP.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var r = OP.Comprobantes.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum();

            OP.ImporteSinAplicar = OP.Importe - OP.Comprobantes.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum();
            //OP.ImporteSinAplicar = OP.Importe;

            //if (OP.Comprobantes != null)
            //    OP.ImporteSinAplicar -= OP.Comprobantes.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum();


            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));


            db.SaveChanges();

            bool Flag = false;
            foreach (OrdenesPagoDetalle row in OP.Detalle.Where(t => t.Id_Documento > 0 && t.Borrado == false))
            {
                ChequesTerceros c = new ChequesTerceros() { Id = (int)row.Id_Documento };
                db.ChequesTerceros.Attach(c);
                db.Entry(c).Reload();
                db.Entry(c).State = EntityState.Modified;
                c.Id_OrdenPago = OP.Id;
                Flag = true;
            }
            if (Flag) db.SaveChanges();

            Flag = false;
            foreach (OrdenesPagoDetalle row in OP.Detalle.Where(t => t.Id_DocumentoPropio > 0 && t.Borrado == false))
            {
                ChequesPropios c = new ChequesPropios() { Id = (int)row.Id_DocumentoPropio };
                db.ChequesPropios.Attach(c);
                db.Entry(c).Reload();
                db.Entry(c).State = EntityState.Modified;
                c.Id_OrdenPago = OP.Id;
                Flag = true;
            }
            if (Flag) db.SaveChanges();


            using (var db1 = new TesoreriaContext())
            {
                Flag = false;
                foreach (OrdenesPagoDetalle row in OP.Detalle.Where(t => t.Borrado == true))
                {
                    OrdenesPagoDetalle o = new OrdenesPagoDetalle() { Id = row.Id };
                    db1.OrdenesPagoDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();

                Flag = false;
                foreach (OrdenesPagoComprobantes row in OP.Comprobantes.Where(t => t.Borrado == true))
                {
                    OrdenesPagoComprobantes o = new OrdenesPagoComprobantes() { Id = row.Id };
                    db1.OrdenesPagoComprobantes.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(OrdenesPago o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("No se puede eliminar una orden de pago anulada.");
                if (o.Fecha_Liquidacion != null) throw new ValidationException("No se puede eliminar una orden de pago liquidada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                //**********************************************************
                //Eliminación de comprobantes asociados
                //**********************************************************
                if (o.Comprobantes == null)
                    db.Entry(o).Collection(p => p.Comprobantes).Load();

                foreach (int IdCC in o.Comprobantes.Where(t => t.Id_ComprobantesCompras > 0 && t.Borrado == false).Select(t => t.Id))
                {
                    OrdenesPagoComprobantes c = new OrdenesPagoComprobantes() { Id = IdCC };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();

                    c.UserDel = o.UserDel;
                    c.FechaDel = (DateTime)o.FechaDel;
                }
                //**********************************************************

                //**********************************************************
                //Anular Depósito de cheques
                //**********************************************************
                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                foreach (int IdCheque in o.Detalle.Where(t => t.Id_Documento > 0 && t.Borrado == false).Select(t => t.Id_Documento))
                {
                    ChequesTerceros c = new ChequesTerceros() { Id = IdCheque };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();

                    //Validaciones
                    // if (c.FechaDepositado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra depositado.", c.NroCheque));
                    if (c.FechaRechazado != null) throw new ValidationException(string.Format("El Cheque Nro. {0} se encuentra rechazado.", c.NroCheque));
                    if (c.FechaDescuento != null) throw new ValidationException(string.Format("El Cheque Nro. {0} se encuentra descontado.", c.NroCheque));
                    //if (c.FechaAcreditado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra acreditado.", c.NroCheque));

                    c.Id_OrdenPago = null;
                    c.FechaDepositado = null;
                    c.FechaAcreditado = null;

                    c.UserMod = o.UserDel;
                    c.FechaMod = (DateTime)o.FechaDel;
                }

                foreach (int IdCheque in o.Detalle.Where(t => t.Id_DocumentoPropio > 0 && t.Borrado == false).Select(t => t.Id_DocumentoPropio))
                {
                    ChequesPropios c = new ChequesPropios() { Id = IdCheque };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();
                      
                    c.UserDel = o.UserDel;
                    c.FechaDel = (DateTime)o.FechaDel;
                }
                //**********************************************************

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static void Confirmar(OrdenesPago o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("No se puede confirmar una orden de pago anulada.");
                if (o.Fecha_Liquidacion != null) throw new ValidationException("No se puede confirmar una orden de pago liquidada.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (o.Impuestos == null)
                    db.Entry(o).Collection(p => p.Impuestos).Load();

                if (o.Comprobantes == null)
                    db.Entry(o).Collection(p => p.Comprobantes).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.Fecha_Liquidacion = o.FechaMod = Sistema.ObtenerFechaHora();

                string Nombre = Sistema.GetNombreEntidad(o.TipoEntidad, o.Id_Entidad);

                //**********************************************************
                // Movimiento en Cta Cte de la Entidad Destino
                //**********************************************************

                //VER IMPUESTOS 
                List<EspeciesCantidad> r = (from d in o.Detalle
                                            where d.Borrado == false
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
                    if (i == 0)
                    {
                        od.Importe += (db.OrdenesPagoImpuestos.Where(t => t.Id_OrdenPago == o.Id).Select(t => t.Importe)).DefaultIfEmpty().Sum();
                        i += 1;
                    }

                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Debito = od.Importe,
                        Fecha = (DateTime)o.Fecha_Liquidacion,
                        FechaAdd = (DateTime)o.Fecha_Liquidacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = (int)o.Id_Entidad,
                        Id_Especie = od.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_TipoEntidad = o.TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc);
                }
                //**********************************************************

                //**********************************************************
                // Movimientos De Especies en Origen
                //**********************************************************
                r = (from d in o.Detalle
                     where d.Id_Documento == null &&
                           d.Id_TipoEntidad == null &&
                           d.Borrado == false
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
                                         c.Id_Sucursal == o.Id_Sucursal &&//(from ca in db.Cajas where ca.Id == o.Id_Caja select ca.Id_Sucursal).FirstOrDefault() &&
                                         c.Id_Especie == od.Id_Especie
                                   select c.Id).FirstOrDefault();

                    if (Id_Caja == 0)
                    {
                        string Especie = (from e in db.Especies where e.Id == od.Id_Especie select e.Descripcion).FirstOrDefault();
                        throw new ValidationException(string.Format("La Caja para la especie {0} no existe o el usuario no tiene su asignación.", Especie));
                    }

                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = string.Format("OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Credito = od.Importe,
                        Fecha = (DateTime)o.Fecha_Liquidacion,
                        FechaAdd = (DateTime)o.Fecha_Liquidacion,
                        Id_Caja = Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Add(ecc);

                    //EntidadesCtaCte encc = new EntidadesCtaCte()
                    //{
                    //    Concepto = string.Format("OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                    //    Debito = od.Importe,
                    //    Fecha = (DateTime)o.Fecha_Liquidacion,
                    //    FechaAdd = (DateTime)o.Fecha_Liquidacion,
                    //    Id_CentroCosto = o.Id_CentroCosto,
                    //    Id_Comprobante = o.Id,
                    //    Id_Entidad = o.Id_Entidad,
                    //    Id_Especie = od.Id_Especie,
                    //    Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                    //    Id_TipoEntidad = o.TipoEntidad,
                    //    UserAdd = (int)o.UserMod
                    //};
                    //db.EntidadesCtaCte.Add(encc);
                }
                //**********************************************************

                db.SaveChanges();

                //**********************************************************
                //Depósito de cheques
                //**********************************************************
                foreach (int IdCheque in o.Detalle.Where(t => t.Id_Documento > 0 && t.Borrado == false).Select(t => t.Id_Documento))
                {
                    ChequesTerceros c = new ChequesTerceros() { Id = IdCheque };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();

                    //Validaciones
                    //if (c.FechaDepositado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra depositado.", c.NroCheque));
                    //if (c.FechaRechazado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra rechazado.", c.NroCheque));
                    //if (c.FechaDescuento != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra descontado.", c.NroCheque));
                    //if (c.FechaAcreditado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra acreditado.", c.NroCheque));

                    c.Id_OrdenPago = o.Id;
                    c.FechaDepositado = (DateTime)o.Fecha_Liquidacion;
                    c.FechaAcreditado = (DateTime)o.Fecha_Liquidacion;

                    c.UserMod = o.UserMod;
                    c.FechaMod = (DateTime)o.Fecha_Liquidacion;
                }
                //********************************************************** 

                //********************************************************** 
                // Movimiento en Cta Cte de la Entidad Origen
                //********************************************************** 
                foreach (Entidad e in o.Detalle.Where(t => t.Id_TipoEntidad > 0 && t.Borrado == false).Select(t => new Entidad() { TipoEntidad = t.Id_TipoEntidad.Value, Id_Entidad = t.Id_Entidad.Value, Importe = t.Importe, Id_Especie = t.Id_Especie }))
                {
                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Credito = e.Importe,
                        Fecha = (DateTime)o.Fecha_Liquidacion,
                        FechaAdd = (DateTime)o.Fecha_Liquidacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = e.Id_Entidad,
                        Id_Especie = e.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_TipoEntidad = e.TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc);
                }
                //********************************************************** 

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static void Anular(OrdenesPago o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("La orden de pago ya se encuentra anulada.");
                if (o.Fecha_Liquidacion == null) throw new ValidationException("No se puede anular una orden de pago sin liquidar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.Fecha_Anulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.Motivo_Anulacion = MotivoAnulacion;

                string Nombre = Sistema.GetNombreEntidad(o.TipoEntidad, o.Id_Entidad);

                //**********************************************************
                // Movimiento en Cta Cte de la Entidad Destino
                //**********************************************************
                List<EspeciesCantidad> r = (from d in o.Detalle
                                            where d.Borrado == false
                                            group d by d.Id_Especie into g
                                            orderby g.Sum(x => x.Importe)
                                            select new EspeciesCantidad
                                            {
                                                Id_Especie = g.Key,
                                                Importe = g.Sum(x => x.Importe)
                                            }).ToList();

                foreach (EspeciesCantidad od in r)
                {
                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("Anulación OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Credito = od.Importe,
                        Fecha = (DateTime)o.Fecha_Anulacion,
                        FechaAdd = (DateTime)o.Fecha_Anulacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = (int)o.Id_Entidad,
                        Id_Especie = od.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_TipoEntidad = o.TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc);
                }
                //**********************************************************

                //**********************************************************
                // Moviemientos De Especies en Origen
                //**********************************************************
                r = (from d in o.Detalle
                     where d.Id_Documento == null &&
                           d.Id_TipoEntidad == null &&
                           d.Borrado == false
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
                                         c.Id_Sucursal == o.Id_Sucursal && //(from ca in db.Cajas where ca.Id == o.Id_Caja select ca.Id_Sucursal).FirstOrDefault() &&
                                         c.Id_Especie == od.Id_Especie
                                   select c.Id).FirstOrDefault();

                    if (Id_Caja == 0)
                    {
                        string Especie = (from e in db.Especies where e.Id == od.Id_Especie select e.Descripcion).FirstOrDefault();
                        throw new ValidationException(string.Format("La Caja para la especie {0} no existe o el usuario no tiene su asignación.", Especie));
                    }

                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = string.Format("Anulación OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Debito = od.Importe,
                        Fecha = (DateTime)o.Fecha_Anulacion,
                        FechaAdd = (DateTime)o.Fecha_Anulacion,
                        Id_Caja = Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod

                    };
                    db.EspeciesCtaCte.Add(ecc);

                    //EntidadesCtaCte encc = new EntidadesCtaCte()
                    //{
                    //    Concepto = string.Format("Anulación OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                    //    Credito = od.Importe,
                    //    Fecha = (DateTime)o.Fecha_Anulacion,
                    //    FechaAdd = (DateTime)o.Fecha_Anulacion,
                    //    Id_CentroCosto = o.Id_CentroCosto,
                    //    Id_Comprobante = o.Id,
                    //    Id_Entidad = o.Id_Entidad,
                    //    Id_Especie = od.Id_Especie,
                    //    Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                    //    Id_TipoEntidad = o.TipoEntidad,
                    //    UserAdd = (int)o.UserMod
                    //};
                    //db.EntidadesCtaCte.Add(encc);
                }

                //**********************************************************
                //Anular Depósito de cheques
                //**********************************************************
                foreach (int IdCheque in o.Detalle.Where(t => t.Id_Documento > 0 && t.Borrado == false).Select(t => t.Id_Documento))
                {
                    ChequesTerceros c = new ChequesTerceros() { Id = IdCheque };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();

                    //Validaciones
                    // if (c.FechaDepositado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra depositado.", c.NroCheque));
                    if (c.FechaRechazado != null) throw new ValidationException(string.Format("El Cheque Nro. {0} se encuentra rechazado.", c.NroCheque));
                    if (c.FechaDescuento != null) throw new ValidationException(string.Format("El Cheque Nro. {0} se encuentra descontado.", c.NroCheque));
                    //if (c.FechaAcreditado != null) throw new ValidationException(String.Format("El Cheque Nro. {0} se encuentra acreditado.", c.NroCheque));

                    c.Id_OrdenPago = null;
                    c.FechaDepositado = null;
                    c.FechaAcreditado = null;

                    c.UserMod = o.UserMod;
                    c.FechaMod = (DateTime)o.Fecha_Anulacion;
                }

                foreach (int IdCheque in o.Detalle.Where(t => t.Id_DocumentoPropio > 0 && t.Borrado == false).Select(t => t.Id_DocumentoPropio))
                {
                    ChequesPropios c = new ChequesPropios() { Id = IdCheque };
                    db.Entry(c).State = EntityState.Modified;
                    db.Entry(c).Reload();

                    c.UserDel = o.UserDel;
                    c.FechaDel = (DateTime)o.FechaDel;
                }
                //**********************************************************

                //**********************************************************
                //Eliminación de comprobantes asociados
                //**********************************************************
                if (o.Comprobantes == null)
                    db.Entry(o).Collection(p => p.Comprobantes).Load();

                foreach (OrdenesPagoComprobantes c in o.Comprobantes)
                {
                    c.UserDel = o.UserMod;
                    c.FechaDel = (DateTime)o.Fecha_Anulacion;
                }
                //**********************************************************


                //********************************************************** 
                // Movimiento en Cta Cte de la Entidad Origen
                //********************************************************** 
                foreach (Entidad e in o.Detalle.Where(t => t.Id_TipoEntidad > 0 && t.Borrado == false).Select(t => new Entidad() { TipoEntidad = t.Id_TipoEntidad.Value, Id_Entidad = t.Id_Entidad.Value, Importe = t.Importe, Id_Especie = t.Id_Especie }))
                {
                    //int Id_Entidad = e.Id_Entidad;
                    //if (e.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero)
                    //    Id_Entidad = db.ProvFinancierosCuentas.Where(t => t.Id == e.Id_Entidad).Select(t => t.Id_ProvFinanciero).FirstOrDefault();

                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("Anulación OP {0} {1}-{2} - {3} - {4}", o.Letra, o.PuntoVenta, o.NroComprobante, Nombre, o.Concepto),
                        Debito = e.Importe,
                        Fecha = (DateTime)o.Fecha_Anulacion,
                        FechaAdd = (DateTime)o.Fecha_Anulacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = e.Id_Entidad,
                        Id_Especie = e.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.OrdenesPago,
                        Id_TipoEntidad = e.TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc);
                }
                //********************************************************** 

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.OrdenesPago
                     join c in db.CentrosCostos on t.Id_CentroCosto equals c.Id into listCC
                     from cen in listCC.DefaultIfEmpty()
                     join s in db.Sucursales on t.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where (t.Id == parametros.Id || parametros.Id == null)
                     && (t.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                     && (t.TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                     && (t.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                     && (t.Fecha >= parametros.Fecha_Desde && t.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                     && (t.Letra == parametros.Letra || parametros.Letra == null)
                     && (t.PuntoVenta == parametros.PuntoVenta || parametros.PuntoVenta == null)
                     && (t.NroComprobante == parametros.NroComprobante || parametros.NroComprobante == null)
                     && (t.Concepto.Contains(parametros.Concepto) || parametros.Concepto == null)
                     && (t.Fecha_Liquidacion >= parametros.Fecha_Liquidacion_Desde && t.Fecha_Liquidacion <= parametros.Fecha_Liquidacion_Hasta || parametros.Fecha_Liquidacion_Hasta == null)
                     && (t.Fecha_Anulacion != null || parametros.Anulado == false)
                     && (t.UserDel == null)
                     && (Seguridad.IdSucursalesAsignadas.Contains(suc.Id))
                     && ((parametros.Estado == Enums.OPEstados.Anuladas && parametros.Id == null && t.Fecha_Anulacion != null)
                      || (parametros.Estado == Enums.OPEstados.Pendientes && parametros.Id == null && t.Fecha_Liquidacion == null && t.Fecha_Anulacion == null)
                      || (parametros.Estado == Enums.OPEstados.Confirmadas && parametros.Id == null && t.Fecha_Liquidacion != null && t.Fecha_Anulacion == null)
                      || (parametros.Estado == Enums.OPEstados.Todos))
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Id_Sucursal = t.Id_Sucursal,
                         Id_CentroCosto = t.Id_CentroCosto,
                         TipoEntidad = t.TipoEntidad,
                         Id_Entidad = t.Id_Entidad,
                         Fecha = t.Fecha,
                         Concepto = t.Concepto,
                         PuntoVenta = t.PuntoVenta,
                         Letra = t.Letra,
                         NroComprobante = t.NroComprobante,
                         Fecha_Liquidacion = t.Fecha_Liquidacion,
                         Fecha_Anulacion = t.Fecha_Anulacion,
                         Motivo_Anulacion = t.Motivo_Anulacion,
                         Id_Entidad_Mov = t.Id_Entidad_Mov,
                         Observaciones = t.Observaciones,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod,
                         Sucursal = suc.Descripcion,
                         Comprobante = t.Letra + " " + t.PuntoVenta + "-" + t.NroComprobante,
                         Nombre_Entidad = t.TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == t.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                         : t.TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == t.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                         : t.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                      join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                      from prov in listPF
                                                                                      where pfc.Id == t.Id_Entidad
                                                                                      select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                         : t.TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == t.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         Centro_Costo = cen.Descripcion,
                         Importe_Pesos = db.OrdenesPagoDetalle.Where(rd => rd.Id_OrdenPago == t.Id).Select(rd => rd.Importe * rd.Cotizacion).DefaultIfEmpty(0).Sum(),
                         Importe = t.Importe,
                         ImporteSinAplicar = t.ImporteSinAplicar,
                         //Importe = db.OrdenesPagoDetalle.Where(rd => rd.Id_OrdenPago == t.Id).Select(rd => rd.Importe).DefaultIfEmpty(0).Sum(),
                         //Importe_Pago = db.OrdenesPagoDetalle.Where(rd => rd.Id_OrdenPago == t.Id).Select(rd => rd.Importe).DefaultIfEmpty(0).Sum() - db.OrdenesPagoImpuestos.Where(rd => rd.Id_OrdenPago == t.Id).Select(rd => rd.Importe).DefaultIfEmpty(0).Sum()
                         Importe_Pago = t.Importe //+ db.OrdenesPagoImpuestos.Where(rd => rd.Id_OrdenPago == t.Id).Select(rd => rd.Importe).DefaultIfEmpty(0).Sum()
                     }).ToList();

                return r;
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
            }

            public List<KeyNamePair> Entidades
            {
                get
                {
                    using (var db = new TesoreriaContext())
                        return Sistema.ObtenerEntidades(TipoEntidad);
                }
            }

            public int? Id { get; set; }
            public int? Id_Sucursal { get; set; }
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
            public Enums.OPEstados Estado { get; set; }
        }

        public class SearchResult : OrdenesPago
        {
            public string Sucursal { get; set; }
            public string Comprobante { get; set; }
            public string Nombre_Entidad { get; set; }
            public string Centro_Costo { get; set; }
            public decimal Importe_Pesos { get; set; }
            public decimal Importe_Pago { get; set; }
        }

        public static TalonariosComprobantes Reporte(OrdenesPago o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                return db.TalonariosComprobantes.Where(t => t.Id == o.Id_TalonariosComprobantes).FirstOrDefault();
            }
        }

        public static List<DatosReporte> ImprimeOP(OrdenesPago o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                if (o.Detalle == null) db.Entry(o).Collection(p => p.Detalle).Load();
                if (o.Comprobantes == null) db.Entry(o).Collection(p => p.Comprobantes).Load();
                if (o.Impuestos == null) db.Entry(o).Collection(p => p.Impuestos).Load();

                foreach (OrdenesPagoComprobantes x in o.Comprobantes)
                {
                    ComprobantesCompras cc = GetComprobanteCompra(x.Id_ComprobantesCompras);
                    x.Comprobante = cc.Comprobante;
                    x.Fecha = cc.Fecha;
                    x.Importe = cc.Importe.Value;
                }

                foreach (OrdenesPagoImpuestos x in o.Impuestos)
                    x.Impuesto = NombreImpuesto(x.Id_Impuesto);

                List<DatosReporte> l = new List<DatosReporte>();

                EntidadReporte EntReporte = new EntidadReporte();
                switch (o.TipoEntidad)
                {
                    case Enums.TipoEntidad.Cliente:
                        Clientes c = new Clientes() { Id = o.Id_Entidad.Value };
                        db.Entry(c).State = EntityState.Unchanged;
                        db.Entry(c).Reload();

                        EntReporte.Nombre = c.Nombre;
                        EntReporte.Cuit = c.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == c.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = c.Domicilio;
                        EntReporte.Localidad = (db.Localidades.Where(t => t.Id == c.Id_CodPostal).Select(t => t.Localidad).FirstOrDefault());
                        break;

                    case Enums.TipoEntidad.Personal:
                        Personal p = new Personal() { Id = o.Id_Entidad.Value };
                        db.Entry(p).State = EntityState.Unchanged;
                        db.Entry(p).Reload();

                        EntReporte.Nombre = p.Apellido + ", " + p.Nombre;
                        EntReporte.Cuit = p.Cuit;
                        EntReporte.TipoIva = (db.TipoIva.Where(t => t.Id == p.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault());
                        EntReporte.Domicilio = p.DomicilioCalle + " " + p.DomicilioNro + " " + p.DomicilioPiso + " " + p.DomicilioDpto;
                        EntReporte.Localidad = p.CodPos == null ? "" : p.CodPos.Value.ToString();
                        break;

                    case Enums.TipoEntidad.Proveedor:
                        Proveedores pr = new Proveedores() { Id = o.Id_Entidad.Value };
                        db.Entry(pr).State = EntityState.Unchanged;
                        db.Entry(pr).Reload();

                        EntReporte.Nombre = pr.Nombre;
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

                DatosReporte i = new DatosReporte()
                {
                    Empresa = EmpReporte,
                    Entidad = EntReporte,
                    Registro = o,
                    Letra = o.Letra,
                    Detalle = o.Detalle,
                    PuntoVenta = o.PuntoVenta,
                    NroComprobante = o.NroComprobante,
                    Fecha = o.Fecha,
                    Concepto = o.Concepto,
                    Observaciones = o.Observaciones,
                    ImporteTotal = o.Detalle.Sum(t => t.Importe) - o.Impuestos.Sum(t => t.Importe),
                    TotalEnLetras = NumeroALetras.Convertir((o.Detalle.Sum(t => t.Importe) - o.Impuestos.Sum(t => t.Importe)).ToString())
                };

                foreach (OrdenesPagoDetalle x in o.Detalle)
                    x.Especie = db.Especies.Where(t => t.Id == x.Id_Especie).Select(t => t.Descripcion).FirstOrDefault();

                l.Add(i);

                return l;
            }
        }

        public class EspeciesCantidad
        {
            public int Id_Especie { get; set; }
            public decimal Importe { get; set; }
        }

        public class Entidad
        {
            public int Id_Entidad { get; set; }
            public Enums.TipoEntidad TipoEntidad { get; set; }
            public decimal Importe { get; set; }
            public int Id_Especie { get; set; }
        }


    }
}
