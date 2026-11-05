namespace VENET_Gestion_BL
{
    using VENET_Comun;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using static VENET_Common.Reportes;
    using static VENET_Common.Reportes.PedidosReporte;

    public class PedidosManager
    {
        private GestionContext db;
        public Pedidos Pedido { get; set; }
        private static DateTime F = Sistema.ObtenerFecha();

        public PedidosManager(Pedidos o)
        {
            db = new GestionContext();
            Pedido = o;

            db.Pedidos.Attach(Pedido);

            if (Pedido.Id > 0)
            {
                db.Entry(Pedido).Reload();

                if (Pedido.Detalle == null)
                    db.Entry(Pedido).Collection(p => p.Detalle).Load();

                if (Pedido.Detalle.Count > 0)
                {
                    foreach (PedidosDetalle row in Pedido.Detalle)
                    {
                        //Pedido.Avance += Convert.ToDouble(row.Avance);
                        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();
                        //row.Personal1 = db.Personal.Where(t => t.Id == row.Id_Personal1).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                        //row.Personal2 = db.Personal.Where(t => t.Id == row.Id_Personal2).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                        //row.Personal3 = db.Personal.Where(t => t.Id == row.Id_Personal3).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                    }
                }
            }
            else
            {
                db.Entry(Pedido).Collection(p => p.Detalle).Load();

                int Dias = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DiasAdicionalesFechaEntrega));
                Pedido.Fecha = Sistema.ObtenerFechaHora();
                Pedido.FechaEntrega = Pedido.Fecha.AddDays(14);
                Pedido.Observaciones = "-";
                //Pedido.Avance = 0;

                try
                {
                    Pedido.Id_Vendedor = Vendedores.FirstOrDefault().Key;
                    Pedido.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                }
                catch { }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new GestionContext())
                    return Sistema.ObtenerEntidades(Pedido.Id_TipoEntidad);
            }
        }

        public List<KeyNamePair> Vendedores { get { using (var db = new GestionContext()) return db.Vendedores.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).ToList(); } }

        public List<KeyNamePair> Letra
        {
            get
            {
                return (from tc in db.TalonariosComprobantes
                        join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                        from punto in listPV
                        where tc.UserDel == null &&
                              tc.Id_Comprobante == 12 &&
                             (from pv in db.PuntosVentas
                              where pv.Id_Sucursal == Pedido.Id_Sucursal
                              select pv.Id).Contains(tc.Id_PuntoVenta) &&
                              Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                        select new KeyNamePair()
                        {
                            Key = tc.Id,
                            Name = tc.Letra + "-" + punto.PuntoVenta
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public void ActualizaDescuento(decimal PorcDesc)
        {
            foreach (PedidosDetalle d in Pedido.Detalle)
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
            if (Pedido.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");

            if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock)))
            {
                if (Pedido.Detalle.Where(t => t.Borrado == false && t.CantidadStock.GetValueOrDefault(0) == 0 && t.Visible_Cantidad_Stock == true).Count() > 0)
                    throw new ValidationException("Debe ingresar una cantidad de stock válida.");
            }

            if (Pedido.Id == 0)
            {
                db.Entry(Pedido).State = EntityState.Added;
                Pedido.FechaAdd = Sistema.ObtenerFechaHora();
                Pedido.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                DateTime fecha = Sistema.ObtenerFecha();

                TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                     where d.Id_TalonarioComprobante == Pedido.Id_TalonariosComprobantes
                                                           && d.FechaVencimiento >= fecha
                                                           && d.NroActual < d.NroHasta
                                                     orderby d.NroDesde
                                                     select d).FirstOrDefault();

                if (tcd != null)
                {
                    db.TalonariosComprobantesDetalle.Attach(tcd);
                    tcd.NroActual += 1;

                    TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                    Pedido.Letra = tc.Letra;

                    Pedido.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                    Pedido.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                }
                else
                {
                    throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                }
            }
            else
            {
                db.Entry(Pedido).State = EntityState.Modified;
                Pedido.FechaMod = Sistema.ObtenerFechaHora();
                Pedido.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
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
                foreach (PedidosDetalle row in Pedido.Detalle.Where(t => t.Borrado == true))
                {
                    PedidosDetalle o = new PedidosDetalle() { Id = row.Id };
                    db1.PedidosDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(Pedidos o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un pedido anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede eliminar un pedido confirmado.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static void AnularEntrega(Pedidos o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                foreach (PedidosDetalle d in o.Detalle)
                {
                    d.FechaEntregado = null;
                    d.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    d.FechaMod = Sistema.ObtenerFechaHora();
                }

                o.FechaEntregado = null;

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                if (parametros.Id_Pedido != null)
                    parametros.Estado = Enums.PedidosEstados.Todos;

                r = (from p in db.Pedidos
                     join s in db.Sucursales on p.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where (p.Id == parametros.Id_Pedido || parametros.Id_Pedido == null)
                        && (p.Id_TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                        && (p.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                        && (p.Id_Sucursal == parametros.Id_Sucursal)
                        && (p.Fecha >= parametros.Fecha_Desde || parametros.Fecha_Desde == null)
                        && (p.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null)
                        && (p.FechaEntrega >= parametros.FechaEntrega_Desde || parametros.FechaEntrega_Desde == null)
                        && (p.FechaEntrega <= parametros.FechaEntrega_Hasta || parametros.FechaEntrega_Hasta == null)
                        && (Seguridad.IdSucursalesAsignadas.Contains(p.Id_Sucursal))
                        && (p.UserDel == null)
                        && ((parametros.Estado == Enums.PedidosEstados.Pendiente && parametros.Id_Pedido == null && p.FechaLiquidacion == null && p.FechaAnulacion == null)
                         || (parametros.Estado == Enums.PedidosEstados.Produccion && parametros.Id_Pedido == null && p.FechaLiquidacion != null && p.FechaAnulacion == null && p.FechaEntregado == null)
                         || (parametros.Estado == Enums.PedidosEstados.Entregado && parametros.Id_Pedido == null && p.FechaEntregado != null && p.FechaAnulacion == null)
                         || (parametros.Estado == Enums.PedidosEstados.Anulado && parametros.Id_Pedido == null && p.FechaAnulacion != null)
                         || (parametros.Estado == Enums.PedidosEstados.Todos))
                     select new SearchResult()
                     {
                         Id = p.Id,
                         Id_TalonariosComprobantes = p.Id_TalonariosComprobantes,
                         Fecha = p.Fecha,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         Id_Entidad = p.Id_Entidad,
                         Id_Sucursal = p.Id_Sucursal,
                         Id_TipoEntidad = p.Id_TipoEntidad,
                         Letra = p.Letra,
                         Nombre_Entidad = p.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == p.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : p.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == p.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : p.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                        join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                        from prov in listPF
                                                                                                        where pfc.Id == p.Id_Entidad
                                                                                                        select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : p.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == p.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         NroComprobante = p.NroComprobante,
                         Observaciones = p.Observaciones,
                         PuntoVenta = p.PuntoVenta,
                         Sucursal = suc.Descripcion,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod,
                         FechaAnulacion = p.FechaAnulacion,
                         FechaLiquidacion = p.FechaLiquidacion,
                         MotivoAnulacion = p.MotivoAnulacion,
                         FechaEntrega = p.FechaEntrega,
                         FechaEntregado = p.FechaEntregado,
                         Id_Vendedor = p.Id_Vendedor,
                         Id_ComprobanteGenerado = p.Id_ComprobanteGenerado,
                         Detalle = p.Detalle
                     }).ToList();

                //foreach (Pedidos row in r)
                //row.Avance = db.PedidosDetalle.Where(t => t.Id_Pedido == row.Id && t.UserDel == null).Select(t => t.Avance).Average();

                return r;

            }
        }

        public static void Confirmar(Pedidos o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un pedido anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("El pedido ya está confirmado.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaLiquidacion = o.FechaMod = Sistema.ObtenerFechaHora();

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static void Anular(Pedidos o, string MotivoAnulacion)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("El pedido ya se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede anular un pedido sin confirmar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaAnulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.MotivoAnulacion = MotivoAnulacion;

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static int GenerarVenta(Pedidos o, int Id_Comprobante)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (db.PedidosDetalleProcesados.Where(t => t.UserDel == null && t.Id_PedidoOriginal == o.Id).Count() > 0) throw new ValidationException("El pedido ya fue generado parcialmente, continue la generación parcial.");
                if (o.Id_ComprobanteGenerado != null) throw new ValidationException("El pedido ya fue generado en el comprobante Id: " + Convert.ToInt32(o.Id_ComprobanteGenerado) + ".");
                if (o.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede generar a partir de un pedido sin confirmar.");

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
                cv.Id_Vendedor = o.Id_Vendedor;
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

                foreach (PedidosDetalle z in o.Detalle)
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
                        Importe = z.Importe,
                        ImporteCosto = 0,//z.ImporteCosto,
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

        public static int GenerarVentaParcial(Pedidos o, int Id_Comprobante, List<PedidosDetalleProcesados> ListaAProcesar, bool TodoProcesado)
        {
            List<PedidosDetalleProcesados> ListAProcesar = new List<PedidosDetalleProcesados>();

            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                //ver que pasa cuando se anula el comprobanteGenerado
                //sino poner if que busque que el comprobante no este anulado
                if (o.Id_ComprobanteGenerado != null) throw new ValidationException("El pedido ya fue generado en el comprobante Id: " + Convert.ToInt32(o.Id_ComprobanteGenerado) + ".");
                if (o.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede generar a partir de un pedido sin confirmar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                ComprobantesVentas cv = new ComprobantesVentas();
                db.ComprobantesVentas.Attach(cv);
                db.Entry(cv).State = EntityState.Added;

                cv.FechaAdd = Sistema.ObtenerFechaHora();
                cv.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                cv.Importe = 0;
                cv.Id_Deposito = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Deposito));
                cv.Id_Sucursal = o.Id_Sucursal;
                cv.Id_CentroCosto = 1;
                cv.Id_TipoComprobante = Id_Comprobante;
                //cv.Id_TipoComprobante = 103;
                cv.Id_TipoEntidad = o.Id_TipoEntidad;
                cv.Id_Entidad = o.Id_Entidad;
                cv.Id_Vendedor = o.Id_Vendedor;
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

                cv.Detalle = new List<ComprobantesVentasDetalle>();

                foreach (PedidosDetalle z in o.Detalle.Where(t => ListaAProcesar.Select(l => l.Id_PedidoDetalle).Contains(t.Id)))
                {
                    ComprobantesVentasDetalle cvd = new ComprobantesVentasDetalle()
                    {
                        AlicuotaIva = z.AlicuotaIva,
                        //Cantidad = z.Cantidad,
                        Cotizacion = z.Cotizacion,
                        Descripcion = z.Descripcion,
                        Especie = z.Especie,
                        FechaAdd = cv.FechaAdd,
                        Id_AlicuotaIva = z.Id_AlicuotaIva,
                        Id_Especie = z.Id_Especie,
                        Id_Producto = z.Id_Producto,
                        // Importe = z.Importe,
                        ImporteCosto = 0,//z.ImporteCosto,
                        //ImporteIVA = z.ImporteIVA,
                        ImporteUnitario = z.ImporteUnitario,
                        PorcDescuento = z.PorcDescuento,
                        UserAdd = cv.UserAdd
                    };

                    cvd.Cantidad = (ListaAProcesar.Where(t => t.Id_PedidoDetalle == z.Id).Select(t => t.Cantidad)).FirstOrDefault();

                    decimal Alicuota = (db.IvaAlicuotas.Where(t => t.Id == z.Id_AlicuotaIva).Select(t => t.Alicuota)).FirstOrDefault();
                    cvd.ImporteIVA = ((cvd.Cantidad * cvd.ImporteUnitario) - ((cvd.Cantidad * cvd.ImporteUnitario) * cvd.PorcDescuento / 100)) * Alicuota / 100;

                    cvd.Importe = ((cvd.Cantidad * cvd.ImporteUnitario) - ((cvd.Cantidad * cvd.ImporteUnitario) * cvd.PorcDescuento / 100)) + cvd.ImporteIVA;
                    cv.Importe += cvd.Importe;
                    cv.ImportePesos = cv.Importe;

                    cv.Detalle.Add(cvd);

                    PedidosDetalleProcesados dp = new PedidosDetalleProcesados()
                    {
                        Id_PedidoDetalle = z.Id,
                        Id_PedidoOriginal = z.Id_Pedido,
                        Id_ComprobanteVentaProcesado = cv.Id,
                        Cantidad = (from a in ListaAProcesar where a.Id_PedidoDetalle == z.Id select a.Cantidad).FirstOrDefault(),//d.Cantidad,
                        UserAdd = (int)o.UserMod,
                        FechaAdd = (DateTime)o.FechaMod,
                    };
                    ListaAProcesar.Add(dp);
                    db.Entry(dp).State = EntityState.Added;
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();

                foreach (PedidosDetalleProcesados p in ListaAProcesar)
                {
                    p.Id_ComprobanteVentaProcesado = cv.Id;
                }

                if (db.PedidosDetalle.Where(t => t.Id_Pedido == o.Id && t.UserDel == null).Sum(t => t.Cantidad) == (db.PedidosDetalleProcesados.Where(t => t.Id_PedidoOriginal == o.Id && t.UserDel == null).Sum(t => t.Cantidad)))
                    o.Id_ComprobanteGenerado = cv.Id;

                db.SaveChanges();


                return cv.Id;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                //    Fecha_Desde = Sistema.ObtenerFecha();
                //    Fecha_Hasta = Fecha_Desde;

                Estado = Enums.PedidosEstados.Todos;

                if (Sistema.Sucursales.Count() > 0)
                    Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
            }

            public List<KeyNamePair> Entidades { get { return Sistema.ObtenerEntidades(TipoEntidad); } }
            public int? Id_Pedido { get; set; }
            public int Id_Sucursal { get; set; }
            public Enums.TipoEntidad? TipoEntidad { get; set; }
            public int? Id_Entidad { get; set; }
            public DateTime? Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public DateTime? FechaEntrega_Desde { get; set; }
            public DateTime? FechaEntrega_Hasta { get; set; }
            public Enums.PedidosEstados Estado { get; set; }
        }

        public class SearchResult : Pedidos
        {
            public string Sucursal { get; set; }
            public string Nombre_Entidad { get; set; }
            public int? Dias
            {
                get
                {
                    TimeSpan ts = F - FechaEntrega;
                    if (FechaEntregado == null && FechaAnulacion == null)
                        return ts.Days;
                    else
                        return null;
                }
            }
        }

        public static TalonariosComprobantes Reporte(Pedidos o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                return db.TalonariosComprobantes.Where(t => t.UserDel == null && t.Id == o.Id_TalonariosComprobantes).FirstOrDefault();
            }
        }

        public static List<DatosReporte> ImprimeComprobante(Pedidos o)
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
                        EntReporte.Telefono = (db.ClientesContactos.Where(t => t.Id_Cliente == c.Id && t.UserDel == null).Select(t => t.Nombre + " " + t.Telefono1 + " " + t.Telefono2).FirstOrDefault());
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
                    FechaEntrega = o.FechaEntrega,
                    //ImporteTotal = o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100) + t.ImporteIVA),
                    //TotalEnLetras = (db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(o.Detalle.Sum(t => ((t.Cantidad * t.ImporteUnitario) * t.PorcDescuento / 100) + t.ImporteIVA).ToString()),
                    ImporteTotal = Importe,
                    TotalEnLetras = (db.Especies.Where(t => t.Id == IdEspecie).Select(t => t.Descripcion).FirstOrDefault()) + " " + NumeroALetras.Convertir(Importe.ToString()),
                    Comprobante = "Pedidos",
                    FormaPago = (db.FormasPagos.Where(t => t.Id == 1).Select(t => t.Descripcion).FirstOrDefault()),
                    Sucursal = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Descripcion).FirstOrDefault()),
                    FechaLiquidacion = o.FechaLiquidacion
                };

                foreach (PedidosDetalle x in o.Detalle)
                {
                    x.Codigo = db.Productos.Where(t => t.Id == x.Id_Producto).Select(t => t.Codigo).FirstOrDefault();
                    x.Especie = db.Especies.Where(t => t.Id == x.Id_Especie).Select(t => t.Descripcion).FirstOrDefault();
                    //x.Personal1 = db.Personal.Where(t => t.Id == x.Id_Personal1).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                    //x.Personal2 = db.Personal.Where(t => t.Id == x.Id_Personal2).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                    //x.Personal3 = db.Personal.Where(t => t.Id == x.Id_Personal3).Select(t => t.Apellido + " " + t.Nombre).FirstOrDefault();
                }

                l.Add(i);

                return l;
            }
        }
    }
}
