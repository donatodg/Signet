namespace VENET_Gestion_BL
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
    using static VENET_Common.Reportes.CotizacionesReporte;

    public class CotizacionesManager : IDisposable
    {
        private GestionContext db;
        public Cotizaciones Cotiza { get; set; }

        public CotizacionesManager(Cotizaciones o)
        {
            db = new GestionContext();
            Cotiza = o;

            db.Cotizaciones.Attach(Cotiza);

            if (Cotiza.Id > 0)
            {
                db.Entry(Cotiza).Reload();

                if (Cotiza.Detalle == null)
                    db.Entry(Cotiza).Collection(p => p.Detalle).Load();

                if (Cotiza.Detalle.Count > 0)
                {
                    foreach (CotizacionesDetalle row in Cotiza.Detalle)
                    {
                        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();
                    }
                }
            }
            else
            {
                Cotiza.Fecha = Sistema.ObtenerFechaHora();
                db.Entry(Cotiza).Collection(p => p.Detalle).Load();
                Cotiza.Observaciones = "-";

                try
                {
                    Cotiza.Id_FormaPago = Sistema.FormasPagos.First().Key;
                    Cotiza.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                }
                catch { }
            }
        }

        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new GestionContext())
                    return Sistema.ObtenerEntidades(Cotiza.Id_TipoEntidad);
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }


        public void ActualizaDescuento(decimal PorcDesc)
        {
            foreach (CotizacionesDetalle d in Cotiza.Detalle)
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
            if (Cotiza.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");

            if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock)))
            {
                if (Cotiza.Detalle.Where(t => t.Borrado == false && t.CantidadStock.GetValueOrDefault(0) == 0 && t.Visible_Cantidad_Stock == true).Count() > 0)
                    throw new ValidationException("Debe ingresar una cantidad de stock válida.");
            }


            if (Cotiza.Id == 0)
            {
                db.Entry(Cotiza).State = EntityState.Added;
                Cotiza.FechaAdd = Sistema.ObtenerFechaHora();
                Cotiza.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                DateTime fecha = Sistema.ObtenerFecha();

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == Cotiza.Id_TalonariosComprobantes
                                                           && d.FechaVencimiento >= fecha
                                                           && d.NroActual < d.NroHasta
                                                     orderby d.NroDesde
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual += 1;

                    TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                    Cotiza.Letra = tc.Letra;

                    Cotiza.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                    Cotiza.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                }
                else
                {
                    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                }
            }
            else
            {
                db.Entry(Cotiza).State = EntityState.Modified;
                Cotiza.FechaMod = Sistema.ObtenerFechaHora();
                Cotiza.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

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
                foreach (CotizacionesDetalle row in Cotiza.Detalle.Where(t => t.Borrado == true))
                {
                    CotizacionesDetalle o = new CotizacionesDetalle() { Id = row.Id };
                    db1.CotizacionesDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(Cotizaciones o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("No se puede eliminar una cotización anulada.");
                if (o.Fecha_Liquidacion != null) throw new ValidationException("No se puede eliminar una cotización confirmada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static void Confirmar(Cotizaciones o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("No se puede confirmar una cotización anulada.");
                if (o.Fecha_Liquidacion != null) throw new ValidationException("No se puede confirmar una cotización confirmada.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.Fecha_Liquidacion = o.FechaMod = Sistema.ObtenerFechaHora();

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static void Anular(Cotizaciones o, string MotivoAnulacion)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Fecha_Anulacion != null) throw new ValidationException("La cotización ya se encuentra anulada.");
                if (o.Fecha_Liquidacion == null) throw new ValidationException("No se puede anular una cotización sin confirmar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.Fecha_Anulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.Motivo_Anulacion = MotivoAnulacion;

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
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from v in db.Cotizaciones
                     join s in db.Sucursales on v.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where (v.Id == parametros.Id || parametros.Id == null)
                        && (v.Id_Sucursal == parametros.Id_Sucursal)
                        && (v.Id_TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                        && (v.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                        && (v.Fecha >= parametros.Fecha_Desde && v.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                        && (v.Letra == parametros.Letra || parametros.Letra == null)
                        && (v.PuntoVenta == parametros.PuntoVenta || parametros.PuntoVenta == null)
                        && (v.NroComprobante == parametros.NroComprobante || parametros.NroComprobante == null)
                        && (v.UserDel == null)
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Fecha = v.Fecha,
                         FechaAdd = v.FechaAdd,
                         FechaMod = v.FechaMod,
                         Id_Entidad = v.Id_Entidad,
                         Id_FormaPago = v.Id_FormaPago,
                         Id_Sucursal = v.Id_Sucursal,
                         Id_TalonariosComprobantes = v.Id_TalonariosComprobantes,
                         Id_TipoEntidad = v.Id_TipoEntidad,
                         Letra = v.Letra,
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
                         PuntoVenta = v.PuntoVenta,
                         Sucursal = suc.Descripcion,
                         Detalle = v.Detalle,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod,
                         Fecha_Anulacion = v.Fecha_Anulacion,
                         Fecha_Liquidacion = v.Fecha_Liquidacion,
                         Motivo_Anulacion = v.Motivo_Anulacion
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

        public static decimal GetCotizacion(int Id_Especie)
        {
            using (var db = new GestionContext())
            {
                return db.Especies.Where(t => t.Id == Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
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

        public List<KeyNamePair> Letra
        {
            get
            {
                return (from tc in db.TalonariosComprobantes
                        join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                        from punto in listPV
                        where tc.UserDel == null &&
                              tc.Id_Comprobante == 11 &&
                             (from pv in db.PuntosVentas
                              where pv.Id_Sucursal == Cotiza.Id_Sucursal
                              select pv.Id).Contains(tc.Id_PuntoVenta) &&
                              Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                        select new KeyNamePair()
                        {
                            Key = tc.Id,
                            Name = tc.Letra + "-" + punto.PuntoVenta
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public static int GenerarVenta(Cotizaciones o, int Id_Comprobante)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Id_ComprobanteGenerado != null) throw new ValidationException("La cotización ya fue generada en el comprobante Id: " + Convert.ToInt32(o.Id_ComprobanteGenerado) + ".");
                if (o.Fecha_Anulacion != null) throw new ValidationException("La cotización se encuentra anulada.");
                if (o.Fecha_Liquidacion == null) throw new ValidationException("No se puede generar a partir de una cotización sin confirmar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                ComprobantesVentas cv = new ComprobantesVentas();
                db.ComprobantesVentas.Attach(cv);
                db.Entry(cv).State = EntityState.Added;

                cv.FechaAdd = Sistema.ObtenerFechaHora();
                cv.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                cv.Id_Deposito = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Deposito));
                cv.Id_Sucursal = o.Id_Sucursal;
                cv.Id_CentroCosto = 1;
                cv.Id_TipoComprobante = Id_Comprobante;
                //cv.Id_TipoComprobante = 103;
                cv.Id_TipoEntidad = o.Id_TipoEntidad;
                cv.Id_Entidad = o.Id_Entidad;
                cv.Id_Vendedor = 1;
                cv.Id_FormaPago = 1;
                cv.Observaciones = "-";
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
                cv.PercepcionIva = 0;
                cv.OtrosImpuestos = 0;
                cv.Retenciones = 0;
                cv.PercepcionIIBB = 0;
                cv.Importe = Convert.ToDecimal(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) - ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100)) + t.ImporteIVA));
                cv.ImportePesos = cv.Importe;

                cv.Detalle = new List<ComprobantesVentasDetalle>();

                foreach (CotizacionesDetalle z in o.Detalle)
                {
                    cv.Detalle.Add(new ComprobantesVentasDetalle()
                    {
                        AlicuotaIva = z.AlicuotaIva,
                        Cantidad = z.Cantidad,
                        CantidadStock = z.CantidadStock,
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

                o.Id_ComprobanteGenerado = cv.Id;

                db.SaveChanges();


                return cv.Id;
            }
        }

        public static int GenerarPedido(Cotizaciones o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Id_ComprobanteGenerado != null) throw new ValidationException("La cotización ya fue generada en el pedido Id: " + Convert.ToInt32(o.Id_ComprobanteGenerado) + ".");
                if (o.Fecha_Anulacion != null) throw new ValidationException("La cotización se encuentra anulada.");
                if (o.Fecha_Liquidacion == null) throw new ValidationException("No se puede generar a partir de una cotización sin confirmar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                Pedidos cv = new Pedidos();
                db.Pedidos.Attach(cv);
                db.Entry(cv).State = EntityState.Added;

                cv.FechaAdd = Sistema.ObtenerFechaHora();
                cv.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                cv.Fecha = cv.FechaAdd;
                cv.Id_Sucursal = o.Id_Sucursal;
                int Dias = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DiasAdicionalesFechaEntrega));
                cv.FechaEntrega = cv.Fecha.AddDays(Dias);
                cv.Id_TipoEntidad = o.Id_TipoEntidad;
                cv.Id_Entidad = o.Id_Entidad.Value;
                cv.Id_Vendedor = 1;
                //cv.Observaciones = "-";
                cv.Observaciones = o.Observaciones;
                //cv.Id_TalonariosComprobantes = Sistema.ObtenerTalonario(cv.Id_Sucursal, 12, cv.Id_TipoEntidad, cv.Id_Entidad.Value).FirstOrDefault().Key;

                cv.Id_TalonariosComprobantes = (from tc in db.TalonariosComprobantes
                                                join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                                                from punto in listPV
                                                where tc.UserDel == null &&
                                                      tc.Id_Comprobante == 12 &&
                                                     (from pv in db.PuntosVentas
                                                      where pv.Id_Sucursal == o.Id_Sucursal
                                                      select pv.Id).Contains(tc.Id_PuntoVenta) &&
                                                      Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                                                select tc.Id).FirstOrDefault();

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

                cv.Detalle = new List<PedidosDetalle>();

                foreach (CotizacionesDetalle z in o.Detalle)
                {
                    cv.Detalle.Add(new PedidosDetalle()
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
                        //ImporteCosto = z.ImporteCosto,
                        ImporteIVA = z.ImporteIVA,
                        ImporteUnitario = z.ImporteUnitario,
                        PorcDescuento = z.PorcDescuento,
                        Avance = 0,
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

                o.Id_ComprobanteGenerado = cv.Id;

                db.SaveChanges();


                return cv.Id;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Fecha_Desde = Sistema.ObtenerFecha();
                Fecha_Hasta = Fecha_Desde;

                if (Sistema.Sucursales.Count() > 0)
                    Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
            }

            public List<KeyNamePair> Entidades
            {
                get
                {
                    return Sistema.ObtenerEntidades(TipoEntidad);
                }
            }

            public int? Id { get; set; }
            public int Id_Sucursal { get; set; }
            public Enums.TipoEntidad? TipoEntidad { get; set; }
            public int? Id_Entidad { get; set; }
            public DateTime? Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public string Letra { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public bool Anulado { get; set; }
        }

        public class SearchResult : Cotizaciones
        {
            public string Sucursal { get; set; }
            public string Nombre_Entidad { get; set; }
        }

        public static TalonariosComprobantes Reporte(Cotizaciones o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                return db.TalonariosComprobantes.Where(t => t.UserDel == null && t.Id == o.Id_TalonariosComprobantes).FirstOrDefault();
            }
        }

        public static bool EntidadResponsableInscripto(Cotizaciones o)
        {
            bool Retorno = false;
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                switch (o.Id_TipoEntidad)
                {
                    case Enums.TipoEntidad.Cliente:
                        Retorno = Convert.ToBoolean(db.Clientes.Where(t => t.Id == o.Id_Entidad && t.Id_TipoIva == 1).Count());
                        break;

                    case Enums.TipoEntidad.Personal:
                        Retorno = Convert.ToBoolean(db.Personal.Where(t => t.Id == o.Id_Entidad && t.Id_TipoIva == 1).Count());
                        break;

                    case Enums.TipoEntidad.Proveedor:
                        Retorno = Convert.ToBoolean(db.Proveedores.Where(t => t.Id == o.Id_Entidad && t.Id_TipoIva == 1).Count());
                        break;

                    case Enums.TipoEntidad.Proveedor_Financiero:
                        Retorno = Convert.ToBoolean(db.ProvFinancieros.Where(t => t.Id == o.Id_Entidad && t.Id_TipoIva == 1).Count());
                        break;
                }
            }
            return Retorno;
        }

        public static List<DatosReporte> ImprimeComprobante(Cotizaciones o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                if (o.Detalle == null) db.Entry(o).Collection(p => p.Detalle).Load();

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
                //int Id_Especie = o.Detalle.First().Id_Especie;
                //EntReporte.SaldoCtaCte = (from e in db.EntidadesCtaCte
                //                          where e.Id_TipoEntidad == o.Id_TipoEntidad
                //                                && e.Id_Entidad == o.Id_Entidad
                //                                && e.Id_Especie == Id_Especie
                //                                && e.UserDel == null
                //                          select new { D = e.Debito, C = e.Credito }).Sum(s => (decimal?)(s.D - s.C)) ?? 0;

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

                int IdEspecie = o.Detalle.First().Id_Especie;
                string Especie = db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault();
                //decimal Importe = Convert.ToDecimal(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) - ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100))).ToString("N2"));
                decimal Importe = Convert.ToDecimal(o.Detalle.Sum(t => t.Importe).ToString("N2"));
                decimal ImporteSubTotal = Convert.ToDecimal(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) - (t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100)).ToString("N2"));

                DatosReporte i = new DatosReporte()
                {
                    Empresa = EmpReporte,
                    Entidad = EntReporte,
                    Detalle = o.Detalle,
                    Registro = o,
                    Letra = o.Letra,
                    PuntoVenta = o.PuntoVenta,
                    NroComprobante = o.NroComprobante,
                    Fecha = o.Fecha,
                    Observaciones = o.Observaciones,
                    //ImporteTotal = o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100) + t.ImporteIVA),
                    //TotalEnLetras = (db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100) + t.ImporteIVA).ToString()),
                    ImporteTotal = Importe,
                    TotalEnLetras = (db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(Importe.ToString()),

                    ImporteSubTotal = ImporteSubTotal,
                    SubTotalEnLetras = (db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(ImporteSubTotal.ToString()),

                    Comprobante = "Cotizaciones",
                    FormaPago = (db.FormasPagos.Where(t => t.Id == o.Id_FormaPago).Select(t => t.Descripcion).FirstOrDefault()),
                    Sucursal = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Descripcion).FirstOrDefault()),
                    FechaLiquidacion = o.Fecha_Liquidacion
                };

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaImagenes_Cotizaciones)))
                    o.Imagen = (db.Imagenes.Where(t => t.Tabla == "Cotizaciones" && t.Id_Tabla == o.Id && t.UserDel == null).OrderBy(t => t.Orden).Select(t => t.Imagen).FirstOrDefault());

                foreach (CotizacionesDetalle x in o.Detalle)
                {
                    x.Especie = db.Especies.Where(t => t.Id == x.Id_Especie).Select(t => t.Descripcion).FirstOrDefault();

                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaImagenes_Productos)))
                        x.Imagen = (db.Imagenes.Where(t => t.Tabla == "Productos" && t.Id_Tabla == x.Id_Producto && t.UserDel == null).OrderBy(t => t.Orden).Select(t => t.Imagen).FirstOrDefault());
                }

                l.Add(i);

                return l;
            }
        }

    }
}
