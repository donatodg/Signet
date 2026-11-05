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

    public class PedidosEstadosManager //: IDisposable
    {
        private GestionContext db;
        public List<SearchResult> PedidosList { get; set; }


        public PedidosEstadosManager(int Id_Pedido)
        {
            db = new GestionContext();
            PedidosList = new List<SearchResult>();
            Load(Id_Pedido);
        }

        public List<PersonalCombo> Personal
        {
            get
            {
                return (db.Personal.Where(t => t.UserDel == null).Select(t => new PersonalCombo()
                {
                    Id = t.Id,
                    Legajo = t.LaboralLegajo.Value,
                    Apellido = t.Apellido,
                    Nombre = t.Nombre
                })).ToList();
            }
        }

        private void Load(int Id_Pedido)
        {
            PedidosList.Clear();

            using (var db = new GestionContext())
            {
                PedidosList = (from p in db.Pedidos
                               join pdet in db.PedidosDetalle on p.Id equals pdet.Id_Pedido into listPD
                               from pd in listPD
                               join s in db.Sucursales on p.Id_Sucursal equals s.Id into listSuc
                               from suc in listSuc
                               join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                               from emp in listEmp
                               join per1 in db.Personal on pd.Id_Personal1 equals per1.Id into listPer1
                               from pe1 in listPer1.DefaultIfEmpty()
                               join per2 in db.Personal on pd.Id_Personal2 equals per2.Id into listPer2
                               from pe2 in listPer2.DefaultIfEmpty()
                               join per3 in db.Personal on pd.Id_Personal3 equals per3.Id into listPer3
                               from pe3 in listPer3.DefaultIfEmpty()
                               join vend in db.Vendedores on p.Id_Vendedor equals vend.Id into listVend
                               from v in listVend.DefaultIfEmpty()
                               join es in db.Especies on pd.Id_Especie equals es.Id into listEsp
                               from esp in listEsp.DefaultIfEmpty()
                               where (p.Id == Id_Pedido)
                                   // && (p.Id_TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                                   //&& (p.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                                   //&& (p.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                                   //&& (p.Fecha >= parametros.Fecha_Desde && p.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Desde == null)
                                   //&& (p.FechaEntrega >= parametros.FechaEntrega_Desde && p.FechaEntrega <= parametros.FechaEntrega_Hasta || parametros.FechaEntrega_Desde == null)
                                   && (Seguridad.IdSucursalesAsignadas.Contains(p.Id_Sucursal))
                                   && (p.UserDel == null)
                               //&& (pd.UserDel == null)
                               //&& ((parametros.Estado == Enums.PedidosEstados.Pendiente && parametros.Id_Pedido == null && p.FechaLiquidacion == null && p.FechaAnulacion == null)
                               // || (parametros.Estado == Enums.PedidosEstados.Produccion && parametros.Id_Pedido == null && p.FechaLiquidacion != null && p.FechaAnulacion == null && p.FechaEntregado == null)
                               // || (parametros.Estado == Enums.PedidosEstados.Entregado && parametros.Id_Pedido == null && p.FechaEntregado != null && p.FechaAnulacion == null)
                               // || (parametros.Estado == Enums.PedidosEstados.Anulado && parametros.Id_Pedido == null && p.FechaAnulacion != null)
                               // || (parametros.Estado == Enums.PedidosEstados.Todos))
                               select new SearchResult
                               {
                                   Id = pd.Id,
                                   Id_Sucursal = p.Id_Sucursal,
                                   Sucursal = suc.Descripcion,
                                   FechaAnulacion = p.FechaAnulacion,
                                   Fecha = p.Fecha,
                                   FechaEntrega = p.FechaEntrega,
                                   FechaEntregado = pd.FechaEntregado,
                                   FechaLiquidacion = p.FechaLiquidacion,
                                   FechaFinalizacion = pd.FechaFinalizacion,
                                   Cantidad = pd.Cantidad,
                                   Cotizacion = pd.Cotizacion,
                                   AlicuotaIva = pd.AlicuotaIva,
                                   Avance = pd.Avance,
                                   Descripcion = pd.Descripcion,
                                   Id_AlicuotaIva = pd.Id_AlicuotaIva,
                                   Id_Pedido = pd.Id_Pedido,
                                   Id_Personal1 = pd.Id_Personal1,
                                   Id_Personal2 = pd.Id_Personal2,
                                   Id_Personal3 = pd.Id_Personal3,
                                   Id_Producto = pd.Id_Producto,
                                   Id_ProductoCompuesto = pd.Id_ProductoCompuesto,
                                   Id_Vendedor = p.Id_Vendedor,
                                   ImporteIVA = pd.ImporteIVA,
                                   ImporteUnitario = pd.ImporteUnitario,
                                   Letra = p.Letra,
                                   MotivoAnulacion = p.MotivoAnulacion,
                                   NroComprobante = p.NroComprobante,
                                   Importe = pd.Importe,
                                   Id_Especie = pd.Id_Especie,
                                   //Personal1 = pe1.Apellido + " " + pe1.Nombre,
                                   //Personal2 = pe2.Apellido + " " + pe2.Nombre,
                                   //Personal3 = pe3.Apellido + " " + pe3.Nombre,
                                   Especie = esp.Descripcion,
                                   Vendedor = v.Nombre,
                                   PorcDescuento = pd.PorcDescuento,
                                   PuntoVenta = p.PuntoVenta,
                                   Id_TipoEntidad = p.Id_TipoEntidad,
                                   Id_Entidad = p.Id_Entidad,
                                   Nombre_Entidad = p.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == p.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                                  : p.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == p.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                                  : p.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                                  join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                                  from prov in listPF
                                                                                                                  where pfc.Id == p.Id_Entidad
                                                                                                                  select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                                  : p.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == p.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                                   FechaAdd = pd.FechaAdd,
                                   FechaMod = pd.FechaMod,
                                   UserAdd = pd.UserAdd,
                                   UserMod = pd.UserMod
                               }).ToList();

            }
        }

        public void Save()
        {
            //if (Pedido.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");

            int IdPedido = 0;

            using (GestionContext db = new GestionContext())
            {
                string error = "";
                DateTime? FechaEntregado = DateTime.MinValue;
                bool Entregado = true;

                if (PedidosList.Count() > 0)
                {
                    foreach (SearchResult x in PedidosList)
                    {
                        if (Entregado)
                            if (x.FechaEntregado == null)
                                Entregado = false;
                            else
                            {
                                if (x.FechaEntregado > FechaEntregado)
                                {
                                    IdPedido = x.Id_Pedido;
                                    FechaEntregado = x.FechaEntregado;
                                }
                            }

                        PedidosDetalle o = new PedidosDetalle()
                        {
                            Id = x.Id,
                            Id_Personal1 = x.Id_Personal1,
                            Id_Personal2 = x.Id_Personal2,
                            Id_Personal3 = x.Id_Personal3,
                            AlicuotaIva = x.AlicuotaIva,
                            Avance = x.Avance,
                            Cantidad = x.Cantidad,
                            Codigo = x.Codigo,
                            Cotizacion = x.Cotizacion,
                            Descripcion = x.Descripcion,
                            Especie = x.Especie,
                            FechaEntregado = x.FechaEntregado,
                            FechaFinalizacion = x.FechaFinalizacion,
                            Id_AlicuotaIva = x.Id_AlicuotaIva,
                            Id_Especie = x.Id_Especie,
                            Id_Pedido = x.Id_Pedido,
                            Id_Producto = x.Id_Producto,
                            Id_ProductoCompuesto = x.Id_ProductoCompuesto,
                            Importe = x.Importe,
                            ImporteIVA = x.ImporteIVA,
                            ImporteUnitario = x.ImporteUnitario,
                            //Pedido = x.Pedido,
                            //Personal1 = x.Personal1,
                            //Personal2 = x.Personal2,
                            //Personal3 = x.Personal3,
                            PorcDescuento = x.PorcDescuento,
                            FechaAdd = x.FechaAdd,
                            FechaMod = x.FechaMod,
                            FechaDel = x.FechaDel,
                            UserAdd = x.UserAdd,
                            UserMod = x.UserMod,
                            UserDel = x.UserDel
                        };
                        if (o.Id_Personal1 == null) o.Id_Personal1 = 0;
                        if (o.Id_Personal2 == null) o.Id_Personal2 = 0;
                        if (o.Id_Personal3 == null) o.Id_Personal3 = 0;

                        //Validar si la fecha es mayor a hoy

                        //si esta todo entregado y no esta entregado el pedido -> entregar a mayor fecha

                        ////VALIDACION DEL SERVICIO SI TIENE 2 CHOFERES Y AZAFATA
                        //CodigosServicios cs = db.CodigosServicios.Find((db.CodigosServiciosVueltas.Where(t => t.Id == o.Id_CodigoServicioVuelta).Select(t => t.Id_CodigoServicio).FirstOrDefault()));
                        //CodigosServiciosVueltas csv = db.CodigosServiciosVueltas.Find(o.Id_CodigoServicioVuelta);

                        //if (cs.CantidadChoferes == 1 && o.Id_Personal2 != 0 && o.Id_Estado != 4) error += string.Format("El servicio {0}, vuelta {1} es para un solo conductor.", cs.Codigo, csv.NroVuelta) + Environment.NewLine;
                        //if (cs.Auxiliar == false && o.Id_Personal3 != 0) error += string.Format("El servicio {0}, vuelta {1} no posee auxiliar.", cs.Codigo, csv.NroVuelta) + Environment.NewLine;

                        if (o.Id == 0)
                        {
                            db.Entry(o).State = EntityState.Added;
                            o.FechaAdd = Sistema.ObtenerFechaHora();
                            o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        }
                        else
                        {
                            db.Entry(o).State = EntityState.Modified;
                            o.FechaMod = Sistema.ObtenerFechaHora();
                            o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        }
                    }

                    if (Entregado)
                    {
                        //grabar en cabecera
                        Pedidos o = new Pedidos() { Id = IdPedido };

                        db.Entry(o).State = EntityState.Modified;
                        db.Entry(o).Reload();
                        o.FechaEntregado = FechaEntregado;

                    }

                    var err = db.GetValidationErrors();
                    if (err.Count() > 0)
                        throw new ValidationException(
                            (from e in err
                             from er in e.ValidationErrors
                             select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                    if (error != "") throw new ValidationException(error);

                    db.SaveChanges();
                }
            }

        }

        public static void Entregar(int Id_Pedido, DateTime? Fecha)
        {
            Pedidos o = new Pedidos() { Id = Id_Pedido };

            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (o.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");

                foreach (PedidosDetalle d in o.Detalle)
                {
                    d.FechaEntregado = Fecha;
                    if (Fecha != null)
                        d.Avance = 100;

                    d.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    d.FechaMod = Sistema.ObtenerFechaHora();
                }

                o.FechaEntregado = Fecha;

                db.SaveChanges();
            }
        }

        public static void AsignaPersonal(int Id_Pedido, int? Id_Personal1, int? Id_Personal2, int? Id_Personal3)
        {
            Pedidos o = new Pedidos() { Id = Id_Pedido };

            if (Id_Personal1 == 0) Id_Personal1 = null;
            if (Id_Personal2 == 0) Id_Personal2 = null;
            if (Id_Personal3 == 0) Id_Personal3 = null;

            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (o.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");

                foreach (PedidosDetalle d in o.Detalle)
                {
                    d.Id_Personal1 = Id_Personal1;
                    d.Id_Personal2 = Id_Personal2;
                    d.Id_Personal3 = Id_Personal3;
                    d.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    d.FechaMod = Sistema.ObtenerFechaHora();
                }

                db.SaveChanges();
            }
        }

        public static void Cumplimiento(int Id_Pedido, int Avance)
        {
            Pedidos o = new Pedidos() { Id = Id_Pedido };

            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                if (o.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");

                foreach (PedidosDetalle d in o.Detalle)
                {
                    d.Avance = Avance;
                    d.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    d.FechaMod = Sistema.ObtenerFechaHora();
                }

                db.SaveChanges();
            }
        }

        public class SearchResult : PedidosDetalle
        {
            public int Id_Sucursal { get; set; }
            public string Sucursal { get; set; }
            public string Letra { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public string Comprobante { get { return Letra + " " + PuntoVenta + "-" + NroComprobante; } }
            public Enums.TipoEntidad Id_TipoEntidad { get; set; }
            public int? Id_Entidad { get; set; }
            public string Nombre_Entidad { get; set; }
            public int? Id_Vendedor { get; set; }
            public string Vendedor { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaEntrega { get; set; }
            //public DateTime? FechaEntregado { get; set; }
            public DateTime? FechaLiquidacion { get; set; }
            public DateTime? FechaAnulacion { get; set; }
            public string MotivoAnulacion { get; set; }
            //public string Personal1 { get; set; }
            //public string Personal2 { get; set; }
            //public string Personal3 { get; set; }
        }

        public class PersonalCombo
        {
            public int Id { get; set; }
            public int Legajo { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get { return Legajo.ToString() + "-" + Apellido + ", " + Nombre; } }
        }

    }
}
