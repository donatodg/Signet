namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ChequeTercerosManager : IDisposable
    {
        private TesoreriaContext db;
        public ChequesTerceros Cheque { get; set; }
        private static DateTime F = Sistema.ObtenerFecha();

        public ChequeTercerosManager(ChequesTerceros o)
        {
            db = new TesoreriaContext();
            Cheque = o;
            Cheque.PropertyChanged += new PropertyChangedEventHandler(FechaPago_PropertyChanged);
            db.ChequesTerceros.Attach(Cheque);

            if (Cheque.Id > 0)
                db.Entry(Cheque).Reload();

            if (Cheque.Id_Especie == 0)
                Cheque.Id_Especie = 1;
        }

        private void FechaPago_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FechaPago" || e.PropertyName == "CodPostal")
            {
                if (Cheque.CodPostal > 0 && Cheque.FechaPago != DateTime.MinValue)
                {
                    DateTime f = Cheque.FechaPago;
                    DateTime f1 = Cheque.FechaPago;

                    using (var db = new TesoreriaContext())
                    {
                        int r = db.Localidades.Where(t => t.CodPostal == Cheque.CodPostal).Select(t => t.Clearing).FirstOrDefault();

                        if (r == 0) return;

                        SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                        SqlCommand cmdReport = new SqlCommand("ProximoDiaHabil", sqlConn);
                        using (cmdReport)
                        {
                            SqlParameter Parameter1 = new SqlParameter("Fecha", Cheque.FechaPago);
                            SqlParameter Parameter2 = new SqlParameter("Dias", Convert.ToInt16(0));

                            cmdReport.CommandTimeout = 0;

                            cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                            cmdReport.Parameters.Add(Parameter1);
                            cmdReport.Parameters.Add(Parameter2);
                            if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                            f = Convert.ToDateTime(cmdReport.ExecuteScalar());
                        }

                        cmdReport = new SqlCommand("ProximoDiaHabil", sqlConn);
                        using (cmdReport)
                        {
                            SqlParameter Parameter1 = new SqlParameter("Fecha", Cheque.FechaPago);
                            SqlParameter Parameter2 = new SqlParameter("Dias", Convert.ToInt16(r / 24));

                            cmdReport.CommandTimeout = 0;

                            cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                            cmdReport.Parameters.Add(Parameter1);
                            cmdReport.Parameters.Add(Parameter2);
                            if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                            f1 = Convert.ToDateTime(cmdReport.ExecuteScalar());
                        }
                    }
                    Cheque.FechaDeposito = f;
                    Cheque.FechaAcreditacion = f1;
                }
            }
            if ((Cheque.Id == 0) && (e.PropertyName == "NroCta" || e.PropertyName == "Id_EntidadBancaria" || e.PropertyName == "Sucursal" || e.PropertyName == "CodPostal"))
                if (Cheque.Id_EntidadBancaria > 0 && Cheque.Sucursal > 0 && Cheque.CodPostal > 0 && Cheque.NroCta > 0)
                    //buscar el firmante
                    using (var db = new TesoreriaContext())
                    {
                        Cheque.Id_Firmante = db.FirmantesCuentas.Where(t => t.CodigoBarra == Cheque.CodigoBarraSinCuenta).Select(t => t.Id_Firmante).FirstOrDefault();
                    }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Bancos
        {
            get
            {
                List<KeyNamePair> result = new List<KeyNamePair>();
                 
                foreach (EntidadesBancarias t in db.EntidadesBancarias)
                {
                    result.Add(new KeyNamePair()
                    {
                        Key = t.Codigo,
                        Name = t.Codigo + "-" + t.Descripcion
                    });


                }
                return result;
                //return db.EntidadesBancarias.Select(t => new KeyNamePair() { Key = t.Codigo, Name = t.Codigo + "-" + t.Descripcion }).ToList();
            }
        }
        public List<Firmantes> Firmantes { get { return db.Firmantes.Where(t => t.UserDel == null).OrderBy(t => t.Nombre).ToList(); } }

        public void Save()
        {
            if (db.ChequesTerceros.Where(t => t.Id != Cheque.Id && t.Id_EntidadBancaria == Cheque.Id_EntidadBancaria && t.Sucursal == Cheque.Sucursal && t.CodPostal == Cheque.CodPostal && t.NroCheque == Cheque.NroCheque && t.NroCta == Cheque.NroCta && t.UserDel == null && t.FechaDepositado == null && t.FechaRechazado == null).Count() > 0)
                throw new ValidationException("El cheque ya se encuentra cargado.");

            if (Cheque.Id == 0)
            {
                db.Entry(Cheque).State = EntityState.Added;
                Cheque.FechaAdd = Sistema.ObtenerFechaHora();
                Cheque.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                //FirmantesCuentas f = new FirmantesCuentas() { CodigoBarra = Cheque.CodigoBarraSinCuenta, Id_Firmante = Cheque.Id_Firmante };
                //db.FirmantesCuentas.Attach(f);
                //if (db.FirmantesCuentas.Where(t => t.CodigoBarra == Cheque.CodigoBarraSinCuenta).Count() == 0)
                //{
                //    db.Entry(f).State = EntityState.Added;
                //}
                //else
                //{
                //    db.Entry(f).State = EntityState.Modified;
                //}
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

            try
            {
                FirmantesCuentas f = new FirmantesCuentas() { CodigoBarra = Cheque.CodigoBarraSinCuenta, Id_Firmante = Cheque.Id_Firmante };
                db.FirmantesCuentas.Attach(f);
                if (db.FirmantesCuentas.Where(t => t.CodigoBarra == Cheque.CodigoBarraSinCuenta).Count() == 0)
                {
                    db.Entry(f).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }

        public static void Eliminar(ChequesTerceros o)
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

                r = (from c in db.ChequesTerceros
                     join b in db.EntidadesBancarias on c.Id_EntidadBancaria equals b.Codigo into listEB
                     from ban in listEB
                     join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                     from esp in listEsp
                     join re in db.Recibos on c.Id_Recibo equals re.Id into listRec
                     from rec in listRec.DefaultIfEmpty()
                         //join cl in db.Clientes on rec.Id_Entidad equals cl.Id into listClie
                         //from cli in listClie.DefaultIfEmpty()
                     join or in db.OrdenesPago on c.Id_OrdenPago equals or.Id into listOP
                     from op in listOP.DefaultIfEmpty()
                         //join pr in db.Proveedores on op.Id_Entidad equals pr.Id into listPR
                         //from prov in listPR.DefaultIfEmpty()
                     where
                         (c.Id == parametros.Id || parametros.Id == null)
                         && (c.Id_EntidadBancaria == parametros.Id_EntidadBancaria || parametros.Id_EntidadBancaria == null)
                         //&& (c.TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                         //&& (c.Id_Entidad == parametros.Id_Entidad || parametros.Id_Entidad == null)
                         && (c.Sucursal == parametros.Sucursal || parametros.Sucursal == null)
                         && (c.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                         && (c.NroCheque == parametros.NroCheque || parametros.NroCheque == null)
                         && (c.NroCta == parametros.NroCta || parametros.NroCta == null)
                         && (c.FechaEmision >= parametros.EmisionDesde && c.FechaEmision <= parametros.EmisionHasta || parametros.EmisionDesde == null)
                         && (c.FechaPago >= parametros.PagoDesde && c.FechaPago <= parametros.PagoHasta || parametros.PagoDesde == null)
                         && (c.Importe == parametros.Importe || parametros.Importe == null)
                         && (c.Id_Firmante == parametros.Id_Firmante || parametros.Id_Firmante == null)
                         && (c.FechaDeposito >= parametros.DepositadoDesde && c.FechaDeposito <= parametros.DepositadoHasta || parametros.DepositadoDesde == null)
                         && (c.FechaAcreditacion >= parametros.AcreditacionDesde && c.FechaAcreditacion <= parametros.AcreditacionHasta || parametros.AcreditacionDesde == null)
                         && (c.FechaAcreditado >= parametros.AcreditadoDesde && c.FechaAcreditado <= parametros.AcreditadoHasta || parametros.AcreditadoDesde == null)
                         && (c.FechaRechazado >= parametros.RechazadoDesde && c.FechaRechazado <= parametros.RechazadoHasta || parametros.RechazadoDesde == null)
                         && (c.ALaOrden == parametros.ALaOrden || parametros.ALaOrden == null)
                         && (Seguridad.IdSucursalesAsignadas.Contains(c.Id_Sucursal))
                         && (c.UserDel == null)
                         && (c.Id_Descuento == null || parametros.EnDescuento == null)
                         && (c.Id_Recibo == null || rec.Fecha_Liquidacion != null)
                         && ((parametros.Estado == Enums.ChequesEstados.Cartera && parametros.Id == null && c.FechaDepositado == null && c.FechaRechazado == null)
                          || (parametros.Estado == Enums.ChequesEstados.Depositado && parametros.Id == null && c.FechaDepositado != null && c.FechaRechazado == null)
                          || (parametros.Estado == Enums.ChequesEstados.Descuento && parametros.Id == null && c.FechaDescuento != null && c.FechaRechazado == null)
                          || (parametros.Estado == Enums.ChequesEstados.Rechazado && parametros.Id == null && c.FechaRechazado != null)
                          || (parametros.Estado == Enums.ChequesEstados.Todos))
                     select new SearchResult
                     {
                         Id = c.Id,
                         Id_EntidadBancaria = c.Id_EntidadBancaria,
                         Id_Sucursal = c.Id_Sucursal,
                         Suc = suc.Descripcion,
                         Empresa = emp.Nombre,
                         Sucursal = c.Sucursal,
                         CodPostal = c.CodPostal,
                         NroCheque = c.NroCheque,
                         NroCta = c.NroCta,
                         FechaEmision = c.FechaEmision,
                         FechaPago = c.FechaPago,
                         Importe = c.Importe,
                         Id_Especie = c.Id_Especie,
                         Especie = esp.Descripcion,
                         Id_Firmante = c.Id_Firmante,
                         //TipoEntidad = c.TipoEntidad,
                         //Id_Entidad = c.Id_Entidad,
                         Id_Recibo = c.Id_Recibo,
                         FechaDeposito = c.FechaDeposito,
                         FechaAcreditacion = c.FechaAcreditacion,
                         ALaOrden = c.ALaOrden,
                         FechaDepositado = c.FechaDepositado,
                         FechaAcreditado = c.FechaAcreditado,
                         FechaRechazado = c.FechaRechazado,
                         MotivoRechazo = c.MotivoRechazo,
                         Banco = ban.Descripcion,
                         Id_Descuento = c.Id_Descuento,
                         Id_BoletaDeposito = c.Id_BoletaDeposito,
                         FechaAdd = c.FechaAdd,
                         FechaMod = c.FechaMod,
                         UserAdd = c.UserAdd,
                         UserMod = c.UserMod,
                         Id_OrdenPago = c.Id_OrdenPago,
                         //Origen = cli.Nombre,
                         //Destino = prov.Nombre
                         Origen = rec.TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == rec.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : rec.TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == rec.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : rec.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                       join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                       from prov in listPF
                                                                                                       where pfc.Id == rec.Id_Entidad
                                                                                                       select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : rec.TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == rec.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
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

        public static ChequesTerceros Reload(ChequesTerceros o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();
                o.Banco = db.EntidadesBancarias.Where(t => t.Codigo == o.Id_EntidadBancaria).Select(t => t.Descripcion).FirstOrDefault();
            }

            return o;
        }

        public static string Depositar(List<int> o)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();

                List<int> l = new List<int>();

                var query = from c in db.ChequesTerceros
                            where o.Contains(c.Id) &&
                                  c.FechaDepositado == null &&
                                  c.FechaRechazado == null &&
                                  c.Id_BoletaDeposito == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaDepositado = f;
                    c.Id_BoletaDeposito = null;

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

                var query = from c in db.ChequesTerceros
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
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

        //public static string Rechazar(List<int> o, string Motivo, decimal ImporteGastos)
        //{
        //    using (var db = new TesoreriaContext())
        //    {
        //        DateTime f = Sistema.ObtenerFecha();
        //        DateTime FechaHora = Sistema.ObtenerFechaHora();
        //        int User = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

        //        List<int> l = new List<int>();

        //        var query = from c in db.ChequesTerceros
        //                    where o.Contains(c.Id) &&
        //                          c.FechaRechazado == null &&
        //                          c.UserDel == null
        //                    select c;

        //        foreach (ChequesTerceros c in query)
        //        {
        //            db.ChequesTerceros.Attach(c);
        //            db.Entry(c).State = EntityState.Modified;
        //            c.FechaRechazado = f;
        //            c.MotivoRechazo = Motivo;
        //            c.ImporteRechazo = ImporteGastos;
        //            l.Add(c.Id);

        //            //Importe de Descuento
        //            //if (ImporteGastos > 0)
        //            //{
        //            if (c.Id_Recibo > 0)
        //            {
        //                Recibos r;
        //                using (var db1 = new TesoreriaContext())
        //                {
        //                    r = new Recibos() { Id = c.Id_Recibo.Value };
        //                    db1.Entry(r).State = EntityState.Unchanged;
        //                    db1.Entry(r).Reload();
        //                }
        //                EntidadesCtaCte ecc0 = new EntidadesCtaCte()
        //                {
        //                    Concepto = "Rechazo Ch. " + c.NroCheque + " - " + Motivo,
        //                    Debito = c.Importe,
        //                    Fecha = f,
        //                    FechaAdd = FechaHora,
        //                    Id_CentroCosto = r.Id_CentroCosto,
        //                    Id_Comprobante = 0,
        //                    Id_Entidad = r.Id_Entidad.Value,
        //                    Id_Especie = c.Id_Especie,
        //                    Id_TipoComprobante = 111,
        //                    Id_TipoEntidad = r.TipoEntidad,
        //                    Credito = 0,
        //                    UserAdd = User
        //                };
        //                db.EntidadesCtaCte.Add(ecc0);

        //                if (ImporteGastos > 0)
        //                {
        //                    EntidadesCtaCte ecc = new EntidadesCtaCte()
        //                    {
        //                        Concepto = "Gastos Rechazo Ch. " + c.NroCheque + " - " + Motivo,
        //                        Debito = ImporteGastos,
        //                        Fecha = f,
        //                        FechaAdd = FechaHora,
        //                        Id_CentroCosto = r.Id_CentroCosto,
        //                        Id_Comprobante = 0,
        //                        Id_Entidad = r.Id_Entidad.Value,
        //                        Id_Especie = c.Id_Especie,
        //                        Id_TipoComprobante = 111,
        //                        Id_TipoEntidad = r.TipoEntidad,
        //                        Credito = 0,
        //                        UserAdd = User
        //                    };
        //                    db.EntidadesCtaCte.Add(ecc);
        //                }

        //                if (c.Id_OrdenPago > 0)
        //                {
        //                    OrdenesPago op;
        //                    using (var db1 = new TesoreriaContext())
        //                    {
        //                        op = new OrdenesPago() { Id = c.Id_OrdenPago.Value };
        //                        db1.Entry(op).State = EntityState.Unchanged;
        //                        db1.Entry(op).Reload();
        //                    }
        //                    EntidadesCtaCte ecc01 = new EntidadesCtaCte()
        //                    {
        //                        Concepto = "Rechazo Ch. " + c.NroCheque + " - " + Motivo,
        //                        Credito = c.Importe,
        //                        Fecha = f,
        //                        FechaAdd = FechaHora,
        //                        Id_CentroCosto = op.Id_CentroCosto,
        //                        Id_Comprobante = 0,
        //                        Id_Entidad = op.Id_Entidad.Value,
        //                        Id_Especie = c.Id_Especie,
        //                        Id_TipoComprobante = 111,
        //                        Id_TipoEntidad = op.TipoEntidad,
        //                        Debito = 0,
        //                        UserAdd = User
        //                    };
        //                    db.EntidadesCtaCte.Add(ecc01);

        //                    if (ImporteGastos > 0)
        //                    {
        //                        EntidadesCtaCte ecc1 = new EntidadesCtaCte()
        //                        {
        //                            Concepto = "Gastos Rechazo Ch. " + c.NroCheque + " - " + Motivo,
        //                            Credito = ImporteGastos,
        //                            Fecha = f,
        //                            FechaAdd = FechaHora,
        //                            Id_CentroCosto = op.Id_CentroCosto,
        //                            Id_Comprobante = 0,
        //                            Id_Entidad = op.Id_Entidad.Value,
        //                            Id_Especie = c.Id_Especie,
        //                            Id_TipoComprobante = 111,
        //                            Id_TipoEntidad = op.TipoEntidad,
        //                            Debito = 0,
        //                            UserAdd = User
        //                        };
        //                        db.EntidadesCtaCte.Add(ecc1);
        //                    }
        //                }
        //            }
        //            // }
        //        }

        //        var err = db.GetValidationErrors();
        //        if (err.Count() > 0)
        //            throw new ValidationException(
        //                (from e in err
        //                 from er in e.ValidationErrors
        //                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

        //        db.SaveChanges();

        //        if (o.Count != l.Count)
        //        {
        //            string r = "";
        //            foreach (int i in o)
        //            {
        //                if (!l.Contains(i))
        //                    r += ", " + i.ToString();
        //            }

        //            return "Debido a que ya fueron rechazados los siguientes Ids de cheques no se han rechazado: " + Environment.NewLine + r.Substring(2);
        //        }
        //        else
        //            return "";
        //    }
        //}

        //public static String Descontar(List<Int32> o)
        //{
        //    using (var db = new TesoreriaContext())
        //    {
        //        DateTime f = Sistema.ObtenerFecha();
        //        List<Int32> l = new List<Int32>();

        //        var query = from c in db.ChequesTerceros
        //                    where o.Contains(c.Id) &&
        //                          c.FechaDepositado == null &&
        //                          c.FechaRechazado == null &&
        //                          c.UserDel == null
        //                    select c;

        //        foreach (ChequesTerceros c in query)
        //        {
        //            db.ChequesTerceros.Attach(c);
        //            db.Entry(c).State = EntityState.Modified;
        //            c.FechaDescuento = f;
        //            c.FechaDepositado = f;
        //            l.Add(c.Id);
        //        }

        //        db.SaveChanges();

        //        if (o.Count != l.Count)
        //        {
        //            String r = "";
        //            foreach (Int32 i in o)
        //            {
        //                if (!l.Contains(i))
        //                    r += ", " + i.ToString();
        //            }

        //            return "Debido a que ya fueron depositados o rechazados los siguientes Ids de cheques no se han descontado: " + System.Environment.NewLine + r.Substring(2);
        //        }
        //        else
        //            return "";
        //    }
        //}

        public static string AnularDeposito(List<int> o)
        {
            using (var db = new TesoreriaContext())
            {
                DateTime f = Sistema.ObtenerFecha();
                List<int> l = new List<int>();

                var query = from c in db.ChequesTerceros
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado == null &&
                                  c.FechaDepositado != null &&
                                  c.Id_BoletaDeposito == null &&
                                  c.Id_Descuento == null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.Id_BoletaDeposito = null;
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

                var query = from c in db.ChequesTerceros
                            where o.Contains(c.Id) &&
                                  c.FechaRechazado != null &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaRechazado = null;
                    c.MotivoRechazo = null;
                    l.Add(c.Id);

                    //if (c.ImporteRechazo > 0)
                    //{
                    if (c.Id_Recibo > 0)
                    {
                        Recibos r;
                        using (var db1 = new TesoreriaContext())
                        {
                            r = new Recibos() { Id = c.Id_Recibo.Value };
                            db1.Entry(r).State = EntityState.Unchanged;
                            db1.Entry(r).Reload();
                        }
                        EntidadesCtaCte ecc0 = new EntidadesCtaCte()
                        {
                            Concepto = "Anulación Rechazo Ch. " + c.NroCheque,
                            Credito = c.Importe,
                            Fecha = f,
                            FechaAdd = FechaHora,
                            Id_CentroCosto = r.Id_CentroCosto,
                            Id_Comprobante = 0,
                            Id_Entidad = r.Id_Entidad.Value,
                            Id_Especie = c.Id_Especie,
                            Id_TipoComprobante = 111,
                            Id_TipoEntidad = r.TipoEntidad,
                            Debito = 0,
                            UserAdd = User
                        };
                        db.EntidadesCtaCte.Add(ecc0);

                        if (c.ImporteRechazo > 0)
                        {
                            EntidadesCtaCte ecc = new EntidadesCtaCte()
                            {
                                Concepto = "Anulación Gastos Rechazo Ch. " + c.NroCheque,
                                Credito = c.ImporteRechazo.Value,
                                Fecha = f,
                                FechaAdd = FechaHora,
                                Id_CentroCosto = r.Id_CentroCosto,
                                Id_Comprobante = 0,
                                Id_Entidad = r.Id_Entidad.Value,
                                Id_Especie = c.Id_Especie,
                                Id_TipoComprobante = 111,
                                Id_TipoEntidad = r.TipoEntidad,
                                Debito = 0,
                                UserAdd = User
                            };
                            db.EntidadesCtaCte.Add(ecc);
                        }
                    }

                    if (c.Id_OrdenPago > 0)
                    {
                        OrdenesPago op;
                        using (var db1 = new TesoreriaContext())
                        {
                            op = new OrdenesPago() { Id = c.Id_OrdenPago.Value };
                            db1.Entry(op).State = EntityState.Unchanged;
                            db1.Entry(op).Reload();
                        }
                        EntidadesCtaCte ecc01 = new EntidadesCtaCte()
                        {
                            Concepto = "Anulación Rechazo Ch. " + c.NroCheque,
                            Debito = c.Importe,
                            Fecha = f,
                            FechaAdd = FechaHora,
                            Id_CentroCosto = op.Id_CentroCosto,
                            Id_Comprobante = 0,
                            Id_Entidad = op.Id_Entidad.Value,
                            Id_Especie = c.Id_Especie,
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
                                Id_Especie = c.Id_Especie,
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
            public int? Id_EntidadBancaria { get; set; }
            public List<EntidadesBancarias> Bancos { get { return db.EntidadesBancarias.OrderBy(t => t.Descripcion).ToList(); } }
            public List<Firmantes> Firmantes { get { return db.Firmantes.Where(t => t.UserDel == null).OrderBy(t => t.Nombre).ToList(); } }
            //public List<KeyNamePair> Entidad
            //{
            //    get
            //    {
            //        List<KeyNamePair> r = new List<KeyNamePair>();

            //        if (TipoEntidad != null)
            //        {
            //            switch (TipoEntidad)
            //            {
            //                case Enums.TipoEntidad.Cliente:
            //                    r = db.Clientes.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList();
            //                    break;
            //                case Enums.TipoEntidad.Personal:
            //                    r = db.Personal.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Apellido + ", " + t.Nombre }).OrderBy(t => t.Name).ToList();
            //                    break;

            //                case Enums.TipoEntidad.Proveedor:
            //                    r = db.Proveedores.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList();
            //                    break;

            //                case Enums.TipoEntidad.Proveedor_Financiero:
            //                    r = db.ProvFinancieros.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList();
            //                    break;
            //            }
            //        }
            //        return r;
            //    }
            //}
            public int? Sucursal { get; set; }
            public int? CodPostal { get; set; }
            public int? NroCheque { get; set; }
            public int? NroCta { get; set; }
            public DateTime? EmisionDesde { get; set; }
            public DateTime? EmisionHasta { get; set; }
            public DateTime? PagoDesde { get; set; }
            public DateTime? PagoHasta { get; set; }
            public int? Importe { get; set; }
            public int? Id_Firmante { get; set; }
            //public Enums.TipoEntidad? TipoEntidad { get; set; }
            //public int? Id_Entidad { get; set; }
            public DateTime? DepositoDesde { get; set; }
            public DateTime? DepositoHasta { get; set; }
            public DateTime? AcreditacionDesde { get; set; }
            public DateTime? AcreditacionHasta { get; set; }
            public DateTime? DepositadoDesde { get; set; }
            public DateTime? DepositadoHasta { get; set; }
            public DateTime? AcreditadoDesde { get; set; }
            public DateTime? AcreditadoHasta { get; set; }
            public DateTime? RechazadoDesde { get; set; }
            public DateTime? RechazadoHasta { get; set; }
            public bool? ALaOrden { get; set; }
            public Enums.ChequesEstados Estado { get; set; }
            public int? EnDescuento { get; set; }
        }

        public class SearchResult : ChequesTerceros
        {
            public string Suc { get; set; }
            public string Empresa { get; set; }
            public string Especie { get; set; }
            public int? Dias
            {
                get
                {
                    TimeSpan ts = F - FechaDeposito;
                    if (FechaDepositado == null && FechaRechazado == null)
                        return ts.Days;
                    else
                        return null;
                }
            }
            public string Origen { get; set; }
            public string Destino { get; set; }

        }
    }
}
