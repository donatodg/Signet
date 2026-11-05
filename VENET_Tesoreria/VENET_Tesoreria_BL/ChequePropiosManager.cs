namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Objects.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ChequePropiosManager : IDisposable
    {
        private TesoreriaContext db;
        public ChequesPropios Cheque { get; set; }
        private static DateTime F = Sistema.ObtenerFecha();

        public ChequePropiosManager(ChequesPropios o)
        {
            db = new TesoreriaContext();
            Cheque = o;
            db.ChequesPropios.Attach(Cheque);

            if (Cheque.Id > 0)
                db.Entry(Cheque).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }
        public List<KeyNamePair> ListasPrecios
        {
            get
            {
                using (var db = new GestionContext())
                {
                    return db.ProductosListasPrecios.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<KeyNamePair> ProveedorFinancieroCuentas  
        {
            get
            {
                using (var db = new TesoreriaContext())
                {

                    return (from pf in db.ProvFinancieros
                            join pfcu in db.ProvFinancierosCuentas on pf.Id equals pfcu.Id_ProvFinanciero into listPFC
                            from pfc in listPFC
                            join bn in db.EntidadesBancarias on pfc.Id_EntidadBancaria equals bn.Codigo into listBan
                            from b in listBan
                            where pf.UserDel == null
                            && pfc.UserDel == null
                            select new KeyNamePair()
                            {
                                Key = pfc.Id,
                                Name = pf.Nombre + " - " + pfc.CBU
                            }).ToList();

                }
            }
        }

        public void Save()
        {
            string Errores = "";

            if (db.ChequesPropios.Where(t => t.Id != Cheque.Id && t.Id_ProvFinancierosCuenta == Cheque.Id_ProvFinancierosCuenta && t.NroCheque == Cheque.NroCheque && t.UserDel == null && t.FechaDepositado == null && t.FechaRechazado == null).Count() > 0)
                throw new ValidationException("El cheque ya se encuentra cargado.");

            if (Cheque.FechaPago < Cheque.FechaEmision)
                Errores = "La fecha de pago es menor a la de emisión" + "\n\r";
            if (Cheque.Importe == 0)
                Errores += "El importe debe ser mayor a cero.";

            if (Errores != "")
                throw new ValidationException(Errores);

            if (Cheque.Id == 0)
            {
                db.Entry(Cheque).State = EntityState.Added;
                Cheque.FechaAdd = Sistema.ObtenerFechaHora();
                Cheque.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Cheque).State = EntityState.Modified;
                Cheque.FechaMod = Sistema.ObtenerFechaHora();
                Cheque.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ChequesPropios o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                if (parametros.Id != null)
                    parametros.Estado = Enums.ChequesEstados.Todos;

                r = (from c in db.ChequesPropios
                     join provfc in db.ProvFinancierosCuentas on c.Id_ProvFinancierosCuenta equals provfc.Id into listPFC
                     from pfc in listPFC
                     join b in db.EntidadesBancarias on pfc.Id_EntidadBancaria equals b.Codigo into listEB
                     from ban in listEB
                     join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     join es in db.Especies on pfc.Id_Especie equals es.Id into listEsp
                     from esp in listEsp
                     join or in db.OrdenesPago on c.Id_OrdenPago equals or.Id into listOP
                     from op in listOP.DefaultIfEmpty()
                     where
                         (c.Id == parametros.Id || parametros.Id == null)
                         && (c.Id_ProvFinancierosCuenta == parametros.Id_ProvFinancierosCuenta || parametros.Id_ProvFinancierosCuenta == null)
                         //&& (c.TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                         //&& (c.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                         && (c.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                         && (c.NroCheque == parametros.NroCheque || parametros.NroCheque == null)
                         && (c.FechaEmision >= parametros.EmisionDesde && c.FechaEmision <= parametros.EmisionHasta || parametros.EmisionDesde == null)
                         && (c.FechaPago >= parametros.PagoDesde && c.FechaPago <= parametros.PagoHasta || parametros.PagoDesde == null)
                         && (c.Importe == parametros.Importe || parametros.Importe == null)
                         && (c.FechaDepositado >= parametros.DepositadoDesde && c.FechaDepositado <= parametros.DepositadoHasta || parametros.DepositadoDesde == null)
                            && (c.FechaRechazado >= parametros.RechazadoDesde && c.FechaRechazado <= parametros.RechazadoHasta || parametros.RechazadoDesde == null)
                         && (c.ALaOrden == parametros.ALaOrden || parametros.ALaOrden == null)
                         && (Seguridad.IdSucursalesAsignadas.Contains(c.Id_Sucursal))
                         && (c.UserDel == null)
                         && ((parametros.Estado == Enums.ChequesEstados.Cartera && parametros.Id == null && c.FechaDepositado == null && c.FechaRechazado == null)
                          || (parametros.Estado == Enums.ChequesEstados.Depositado && parametros.Id == null && c.FechaDepositado != null && c.FechaRechazado == null)
                          //|| (parametros.Estado == Enums.ChequesEstados.Descuento && parametros.Id == null && c.FechaDescuento != null && c.FechaRechazado == null)
                          || (parametros.Estado == Enums.ChequesEstados.Rechazado && parametros.Id == null && c.FechaRechazado != null)
                          || (parametros.Estado == Enums.ChequesEstados.Todos))
                     select new SearchResult
                     {
                         Id = c.Id,
                         Id_Sucursal = c.Id_Sucursal,
                         Id_ProvFinancierosCuenta = c.Id_ProvFinancierosCuenta,
                         Suc = suc.Descripcion,
                         Empresa = emp.Nombre,
                         NroCheque = c.NroCheque,
                         FechaEmision = c.FechaEmision,
                         FechaPago = c.FechaPago,
                         Importe = c.Importe,
                         Especie = esp.Descripcion,
                         ALaOrden = c.ALaOrden,
                         FechaDepositado = c.FechaDepositado,
                         FechaRechazado = c.FechaRechazado,
                         MotivoRechazo = c.MotivoRechazo,
                         ImporteRechazo = c.ImporteRechazo,
                         Banco = ban.Descripcion,
                         FechaAdd = c.FechaAdd,
                         FechaMod = c.FechaMod,
                         UserAdd = c.UserAdd,
                         UserMod = c.UserMod,
                         Id_OrdenPago = c.Id_OrdenPago,
                         Destino = op.TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == op.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : op.TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == op.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : op.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                      join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                      from prov in listPF
                                                                                                      where pfc.Id == op.Id_Entidad
                                                                                                      select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : op.TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == op.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : ""

                     }).ToList();
                return r;

            }
        }

        public static int GetId_Especie(int Id_ProvFinancierosCuenta)
        {
            using (var db = new TesoreriaContext())
            {
                return db.ProvFinancierosCuentas.Where(t => t.Id == Id_ProvFinancierosCuenta).Select(t => t.Id).FirstOrDefault();
            }
        }

        public static string GetEspecie(int Id_ProvFinancierosCuenta)
        {
            using (var db = new TesoreriaContext())
            {
                return (from pfc in db.ProvFinancierosCuentas
                        join esp in db.Especies on pfc.Id_Especie equals esp.Id into listEsp
                        from e in listEsp
                        where pfc.Id == Id_ProvFinancierosCuenta
                        select e.Descripcion).FirstOrDefault();
            }
        }

        public static decimal GetCotizacion(int Id_ProvFinancierosCuenta)
        {
            using (var db = new TesoreriaContext())
            {
                return (from pfc in db.ProvFinancierosCuentas
                        join esp in db.Especies on pfc.Id_Especie equals esp.Id into listEsp
                        from e in listEsp
                        where pfc.Id == Id_ProvFinancierosCuenta
                        select e.Cotizacion).FirstOrDefault();
            }
        }

        //public static ChequesPropios Reload(ChequesPropios o)
        //{
        //    using (var db = new TesoreriaContext())
        //    {
        //        db.Entry(o).State = EntityState.Unchanged;
        //        db.Entry(o).Reload();
        //        o.Banco = db.EntidadesBancarias.Where(t => t.Codigo == o.Id_EntidadBancaria).Select(t => t.Descripcion).FirstOrDefault();
        //    }

        //    return o;
        //}

        public static string Depositar(List<int> o)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();

                List<int> l = new List<int>();

                var query = from c in db.ChequesPropios
                            where o.Contains(c.Id) &&
                                  c.FechaDepositado == null &&
                                  c.FechaRechazado == null &&
                                  // c.Id_BoletaDeposito == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesPropios c in query)
                {
                    db.ChequesPropios.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaDepositado = f;
                    //   c.Id_BoletaDeposito = null;

                    l.Add(c.Id);
                }

                db.SaveChanges();

                if (o.Count != l.Count)
                {
                    string r = "";
                    foreach (int i in o)
                    {
                        if (!l.Contains(i))
                            r += ", " + i.ToString();
                    }

                    return "Debido a que ya fueron depositados o rechazados los siguientes Ids de cheques no se han depositado: " + Environment.NewLine + r.Substring(2);
                }
                else
                    return "";

            }
        }

        public static string Rechazar(List<int> o, string Motivo)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();
                DateTime FechaHora = Sistema.ObtenerFechaHora();
                int User = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                List<int> l = new List<int>();

                var query = from c in db.ChequesPropios
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesPropios c in query)
                {
                    db.ChequesPropios.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaRechazado = f;
                    c.MotivoRechazo = Motivo;
                    l.Add(c.Id);
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();

                if (o.Count != l.Count)
                {
                    string r = "";
                    foreach (int i in o)
                    {
                        if (!l.Contains(i))
                            r += ", " + i.ToString();
                    }

                    return "Debido a que ya fueron rechazados los siguientes Ids de cheques no se han rechazado: " + Environment.NewLine + r.Substring(2);
                }
                else
                    return "";
            }
        }

        public static string AnularDeposito(List<int> o)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();
                List<int> l = new List<int>();

                var query = from c in db.ChequesPropios
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado == null &&
                                  c.FechaDepositado != null &&
                                  //c.Id_BoletaDeposito == null &&
                                  //c.Id_Descuento == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesPropios c in query)
                {
                    db.ChequesPropios.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    //c.Id_BoletaDeposito = null;
                    c.FechaDepositado = null;
                    l.Add(c.Id);
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();

                if (o.Count != l.Count)
                {
                    string r = "";
                    foreach (int i in o)
                    {
                        if (!l.Contains(i))
                            r += ", " + i.ToString();
                    }

                    return "Debido a que ya fueron rechazados o nunca depositados o están en un descuento los siguientes Ids de cheques no se han anulado el depósito: " + Environment.NewLine + r.Substring(2);
                }
                else
                    return "";
            }
        }

        public static string AnularRechazo(List<int> o)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();
                DateTime FechaHora = Sistema.ObtenerFechaHora();
                int User = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                List<int> l = new List<int>();

                var query = from c in db.ChequesPropios
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado != null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesPropios c in query)
                {
                    db.ChequesPropios.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaRechazado = null;
                    c.MotivoRechazo = null;
                    l.Add(c.Id);


                    if (c.Id_OrdenPago > 0)
                    {
                        OrdenesPago op;
                        using (var db1 = new TesoreriaContext())
                        {
                            op = new OrdenesPago() { Id = c.Id_OrdenPago.Value };
                            db1.Entry(op).State = EntityState.Unchanged;
                            db1.Entry(op).Reload();
                        }

                        int Id_Especie = db.ProvFinancierosCuentas.Where(t => t.Id == c.Id_ProvFinancierosCuenta && t.UserDel == null).Select(t => t.Id_Especie).FirstOrDefault();

                        EntidadesCtaCte ecc01 = new EntidadesCtaCte()
                        {
                            Concepto = "Anulación Rechazo Ch. " + c.NroCheque,
                            Debito = c.Importe,
                            Fecha = f,
                            FechaAdd = FechaHora,
                            Id_CentroCosto = op.Id_CentroCosto,
                            Id_Comprobante = 0,
                            Id_Entidad = op.Id_Entidad.Value,
                            Id_Especie = Id_Especie,
                            Id_TipoComprobante = 111,
                            Id_TipoEntidad = op.TipoEntidad,
                            Credito = 0,
                            UserAdd = User
                        };
                        db.EntidadesCtaCte.Add(ecc01);

                        if (c.ImporteRechazo > 0)
                        {
                            EntidadesCtaCte ecc1 = new EntidadesCtaCte()
                            {
                                Concepto = "Anulación Gastos Rechazo Ch. " + c.NroCheque,
                                Debito = c.ImporteRechazo.Value,
                                Fecha = f,
                                FechaAdd = FechaHora,
                                Id_CentroCosto = op.Id_CentroCosto,
                                Id_Comprobante = 0,
                                Id_Entidad = op.Id_Entidad.Value,
                                Id_Especie = Id_Especie,
                                Id_TipoComprobante = 111,
                                Id_TipoEntidad = op.TipoEntidad,
                                Credito = 0,
                                UserAdd = User
                            };
                            db.EntidadesCtaCte.Add(ecc1);
                        }
                    }
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();

                if (o.Count != l.Count)
                {
                    string r = "";
                    foreach (int i in o)
                    {
                        if (!l.Contains(i))
                            r += ", " + i.ToString();
                    }

                    return "Debido a que nunca se rechazaron los siguientes Ids de cheques no se han anulado el rechazo: " + Environment.NewLine + r.Substring(2);
                }
                else
                    return "";
            }
        }

        public class ParametrosBusquedas
        {
            private TesoreriaContext db = new TesoreriaContext();
            public int? Id { get; set; }
            public int? Id_Sucursal { get; set; }
            public int? Id_ProvFinancierosCuenta { get; set; }
            public DateTime? EmisionDesde { get; set; }
            public DateTime? EmisionHasta { get; set; }
            public DateTime? PagoDesde { get; set; }
            public DateTime? PagoHasta { get; set; }
            public int? Importe { get; set; }
            public int? NroCheque { get; set; }
            public DateTime? DepositadoDesde { get; set; }
            public DateTime? DepositadoHasta { get; set; }
            public DateTime? RechazadoDesde { get; set; }
            public DateTime? RechazadoHasta { get; set; }
            public bool? ALaOrden { get; set; }
            public Enums.ChequesEstados Estado { get; set; }
        }

        public class SearchResult : ChequesPropios
        {
            public string Suc { get; set; }
            public string Empresa { get; set; }
            public string Especie { get; set; }
            public int? Dias
            {
                get
                {
                    TimeSpan ts = F - FechaPago;
                    if (FechaDepositado == null && FechaRechazado == null)
                        return ts.Days;
                    else
                        return null;
                }
            }
            public string Destino { get; set; }
        }

    }
}
