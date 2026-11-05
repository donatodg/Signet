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

    public class BoletasDepositosManager : IDisposable
    {
        private TesoreriaContext db;
        public BoletasDepositos Boleta { get; set; }

        public BoletasDepositosManager(BoletasDepositos o)
        {
            db = new TesoreriaContext();
            Boleta = o;

            db.BoletasDepositos.Attach(Boleta);

            if (Boleta.Id > 0)
            {
                db.Entry(Boleta).Reload();
                if (Boleta.Detalle == null)
                    db.Entry(Boleta).Collection(p => p.Detalle).Load();

                if (Boleta.Detalle.Count > 0)
                {
                    foreach (BoletasDepositosDetalle row in Boleta.Detalle)
                    {
                        if (row.Id_Documento == 0)
                        {
                            row.Banco = "Efectivo";
                            row.Sucursal = "-";
                            row.NroCuenta = "-";
                            row.NroCheque = "-";
                            row.Importe = row.Importe;
                        }
                        else
                        {
                            ChequesTerceros c = new ChequesTerceros() { Id = row.Id_Documento };

                            db.Entry(c).State = EntityState.Unchanged;
                            db.Entry(c).Reload();

                            row.Banco = db.EntidadesBancarias.Where(t => t.Codigo == c.Id_EntidadBancaria).Select(t => t.Descripcion).FirstOrDefault();
                            row.Sucursal = c.Sucursal.Value.ToString();
                            row.NroCuenta = c.NroCta.Value.ToString();
                            row.NroCheque = c.NroCheque.Value.ToString();
                            row.Importe = c.Importe;
                        }
                    }
                }
            }
            else
            {
                Boleta.Fecha = Sistema.ObtenerFechaHora();
                Boleta.Descripcion = "-";
                if (Sistema.CentrosCostos.Count() > 0)
                    Boleta.Id_CentroCosto = Sistema.CentrosCostos.First().Key;

                db.Entry(Boleta).Collection(p => p.Detalle).Load();
            }
        }

        public List<KeyNamePair> CuentasPF
        {
            get
            {
                return (from p in db.ProvFinancieros
                        join c in db.ProvFinancierosCuentas on p.Id equals c.Id_ProvFinanciero into listPFC
                        from pfc in listPFC
                        where p.UserDel == null && pfc.UserDel == null
                        select new KeyNamePair() { Key = pfc.Id, Name = p.Nombre + " - " + pfc.CBU }).ToList();
            }
        }

        public int Id_Especie
        {
            get
            {
                return db.ProvFinancierosCuentas.Where(t => t.Id == Boleta.Id_ProvFinancieroCuenta).Select(t => t.Id_Especie).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Boleta.Detalle.Count() == 0) throw new ValidationException("No se agregaron items a la boleta de depósito.");

            if (Boleta.Id == 0)
            {
                db.Entry(Boleta).State = EntityState.Added;
                Boleta.FechaAdd = Sistema.ObtenerFechaHora();
                Boleta.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Boleta).State = EntityState.Modified;
                Boleta.FechaMod = Sistema.ObtenerFechaHora();
                Boleta.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            if (Boleta.Detalle != null)
            {
                var query = from c in db.ChequesTerceros
                            join bdd in db.BoletasDepositosDetalle on c.Id equals bdd.Id_Documento into listD
                            from b in listD
                            where b.Id_BoletaDeposito == Boleta.Id &&
                                  b.Id_Documento > 0
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.Id_BoletaDeposito = Boleta.Id;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }
            }

            db.SaveChanges();

            using (var db1 = new TesoreriaContext())
            {
                bool Flag = false;
                foreach (BoletasDepositosDetalle row in Boleta.Detalle.Where(t => t.Borrado == true))
                {
                    BoletasDepositosDetalle o = new BoletasDepositosDetalle() { Id = row.Id };
                    db1.BoletasDepositosDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;

                    ChequesTerceros c = new ChequesTerceros() { Id = row.Id_Documento };
                    db1.ChequesTerceros.Attach(c);
                    db1.Entry(c).Reload();
                    db1.Entry(c).State = EntityState.Modified;
                    c.Id_BoletaDeposito = null;

                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(BoletasDepositos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaConfirmacion != null) throw new ValidationException("No se puede eliminar un boleta ya confirmada.");
                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un boleta anulada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                // Desmarcar Cheques
                var query = from c in db.ChequesTerceros
                            where c.Id_BoletaDeposito == o.Id &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.Id_BoletaDeposito = null;
                    c.FechaDepositado = null;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        public void EliminarDetalle(BoletasDepositosDetalle o)
        {
            foreach (BoletasDepositosDetalle row in Boleta.Detalle)
                if (row.Id == o.Id)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    break;
                }
            if (o.Id_Documento != 0)
                using (var db = new TesoreriaContext())
                {
                    ChequesTerceros c = new ChequesTerceros() { Id = o.Id_Documento };
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).Reload();
                    db.Entry(c).State = EntityState.Modified;
                    c.Id_BoletaDeposito = null;

                    db.SaveChanges();
                }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from b in db.BoletasDepositos
                     join p in db.ProvFinancierosCuentas on b.Id_ProvFinancieroCuenta equals p.Id into listPFC
                     from provFC in listPFC
                     join p in db.ProvFinancieros on provFC.Id_ProvFinanciero equals p.Id into listPF
                     from provf in listPF.DefaultIfEmpty()
                     where (b.Id == parametros.Id || parametros.Id == null)
                     && (b.Id_ProvFinancieroCuenta == parametros.Id_ProvFinancieroCuenta || parametros.Id_ProvFinancieroCuenta == null)
                     && (b.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                     && (b.Nro == parametros.Nro || parametros.Nro == null)
                     && (b.Fecha >= parametros.FechaDesde && b.Fecha <= parametros.FechaHasta || parametros.FechaHasta == null || parametros.Id > 0)
                     select new SearchResult
                     {
                         Id = b.Id,
                         Id_CentroCosto = b.Id_CentroCosto,
                         Nro = b.Nro,
                         Fecha = b.Fecha,
                         Descripcion = b.Descripcion,
                         FechaConfirmacion = b.FechaConfirmacion,
                         FechaAnulacion = b.FechaAnulacion,
                         FechaAdd = b.FechaAdd,
                         FechaMod = b.FechaMod,
                         UserAdd = b.UserAdd,
                         UserMod = b.UserMod,
                         Entidad = provf.Nombre,
                         Cuenta = provFC.NroCuenta,
                         Importe = (from bdd in db.BoletasDepositosDetalle where bdd.Id_BoletaDeposito == b.Id select bdd.Importe).Sum()
                     }).ToList();

                return r;
            }
        }

        public static void Confirmar(BoletasDepositos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaConfirmacion != null) throw new ValidationException("La boleta ya se encuentra confirmada.");
                if (o.FechaAnulacion != null) throw new ValidationException("La boleta se encuentra anulada.");
                if (o.Nro == 0) throw new ValidationException("El número de boleta es obligatorio.");

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaConfirmacion = o.FechaMod = Sistema.ObtenerFechaHora();

                var query = from c in db.ChequesTerceros
                            where c.Id_BoletaDeposito == o.Id &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.FechaDepositado = o.FechaConfirmacion;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }

                //*****************************************************
                // Movimiento de salida de efectivo
                //*****************************************************
                decimal TotalEfectivo = (from bdd in db.BoletasDepositosDetalle
                                         where bdd.Id_Documento == 0
                                               && bdd.Id_BoletaDeposito == o.Id
                                               && bdd.UserDel == null
                                         select (decimal?)bdd.Importe).Sum() ?? 0;

                decimal Total = (from bdd in db.BoletasDepositosDetalle
                                 where bdd.Id_BoletaDeposito == o.Id
                                       && bdd.UserDel == null
                                 select (decimal?)bdd.Importe).Sum() ?? 0;

                string Proveedor = (from p in db.ProvFinancieros
                                    join pfc in db.ProvFinancierosCuentas on p.Id equals pfc.Id_ProvFinanciero into listC
                                    from c in listC
                                    where c.Id == o.Id_ProvFinancieroCuenta
                                    select p.Nombre).FirstOrDefault();

                int IdEspecie = (from bd in db.BoletasDepositos
                                 join pfc in db.ProvFinancierosCuentas on bd.Id_ProvFinancieroCuenta equals pfc.Id into listC
                                 from cuenta in listC
                                 where bd.Id == o.Id
                                 select cuenta.Id_Especie).FirstOrDefault();

                if (TotalEfectivo > 0)
                {
                    int Id_Caja = (from c in db.Cajas
                                   where c.Id_Especie == IdEspecie
                                         && c.Id_Sucursal == o.Id_Sucursal
                                         && c.UserDel == null
                                   select c.Id).FirstOrDefault();

                    if (!Seguridad.IdCajasAsignadas.Contains(Id_Caja)) throw new ValidationException("El Usuario no posee asignada la caja para descontar el efectivo o la caja no existe.");

                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = string.Format("DEP {0} - PF. {1} - {2}", o.Nro, Proveedor, o.Descripcion),
                        Credito = (decimal)TotalEfectivo,
                        Fecha = (DateTime)o.FechaConfirmacion,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        Id_Caja = Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.BoletasDeposito,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Add(ecc);


                }
                //*****************************************************

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("DEP {0} - PF. {1} - {2}", o.Nro, Proveedor, o.Descripcion),
                    Debito = Total,
                    Fecha = (DateTime)o.FechaConfirmacion,
                    FechaAdd = (DateTime)o.FechaConfirmacion,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_ProvFinancieroCuenta,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.BoletasDeposito,
                    Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
            }
        }

        public static void Anular(BoletasDepositos o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("La boleta ya se encuentra anulada.");
                if (o.FechaConfirmacion == null) throw new ValidationException("No se puede anular una orden de pago sin confirmar.");

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaAnulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.MotivoAnulacion = MotivoAnulacion;

                var query = from c in db.ChequesTerceros
                            where c.Id_BoletaDeposito == o.Id &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.Id_BoletaDeposito = null;
                    c.FechaDepositado = null;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }

                //*****************************************************
                //Movimiento de salida de efectivo
                //*****************************************************
                decimal TotalEfectivo = (from bdd in db.BoletasDepositosDetalle
                                         where bdd.Id_Documento == 0
                                               && bdd.Id_BoletaDeposito == o.Id
                                               && bdd.UserDel == null
                                         select (decimal?)bdd.Importe).Sum() ?? 0;

                decimal Total = (from bdd in db.BoletasDepositosDetalle
                                 where bdd.Id_BoletaDeposito == o.Id
                                       && bdd.UserDel == null
                                 select (decimal?)bdd.Importe).Sum() ?? 0;

                string Proveedor = (from p in db.ProvFinancieros
                                    join pfc in db.ProvFinancierosCuentas on p.Id equals pfc.Id_ProvFinanciero into listC
                                    from c in listC
                                    where c.Id == o.Id_ProvFinancieroCuenta
                                    select p.Nombre).FirstOrDefault();

                int IdEspecie = (from bd in db.BoletasDepositos
                                 join pfc in db.ProvFinancierosCuentas on bd.Id_ProvFinancieroCuenta equals pfc.Id into listC
                                 from cuenta in listC
                                 where bd.Id == o.Id
                                 select cuenta.Id_Especie).FirstOrDefault();

                if (TotalEfectivo > 0)
                {
                    int Id_Caja = (from c in db.Cajas
                                   where c.Id_Especie == (from bd in db.BoletasDepositos
                                                          join pfc in db.ProvFinancierosCuentas on bd.Id_ProvFinancieroCuenta equals pfc.Id into listC
                                                          from cuenta in listC
                                                          where bd.Id == o.Id
                                                          select cuenta.Id_Especie).FirstOrDefault()
                                         && c.Id_Sucursal == o.Id_Sucursal
                                         && c.UserDel == null
                                   select c.Id).FirstOrDefault();

                    if (!Seguridad.IdCajasAsignadas.Contains(Id_Caja)) throw new ValidationException("El Usuario no posee asignada la caja para descontar el efectivo o la caja no existe.");

                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = string.Format("Anulación DEP {0} - PF. {1} - {2}", o.Nro, Proveedor, o.Descripcion),
                        Debito = TotalEfectivo,
                        Fecha = (DateTime)o.FechaAnulacion,
                        FechaAdd = (DateTime)o.FechaAnulacion,
                        Id_Caja = Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.BoletasDeposito,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Add(ecc);
                }
                //*****************************************************

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("Anulación DEP {0} - PF. {1} - {2}", o.Nro, Proveedor, o.Descripcion),
                    Credito = Total,
                    Fecha = (DateTime)o.FechaConfirmacion,
                    FechaAdd = (DateTime)o.FechaConfirmacion,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_ProvFinancieroCuenta,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.BoletasDeposito,
                    Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
            }
        }

        public class ParametrosBusquedas
        {
            public TesoreriaContext db;
            public ParametrosBusquedas()
            {
                DateTime fd = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                DateTime fh = fd.AddMonths(1).AddDays(-1);

                FechaDesde = fd;
                FechaHasta = fh;

                db = new TesoreriaContext();
            }

            public List<KeyNamePair> CuentasPF
            {
                get
                {
                    return (from p in db.ProvFinancieros
                            join c in db.ProvFinancierosCuentas on p.Id equals c.Id_ProvFinanciero into listPFC
                            from pfc in listPFC
                            where p.UserDel == null && pfc.UserDel == null
                            select new KeyNamePair() { Key = pfc.Id, Name = p.Nombre + " - " + pfc.CBU }).ToList();
                }
            }

            public int? Id { get; set; }
            public DateTime? FechaDesde { get; set; }
            public DateTime? FechaHasta { get; set; }
            public int? Id_Sucursal { get; set; }
            public int? Id_ProvFinancieroCuenta { get; set; }
            public int? Nro { get; set; }
        }

        public class SearchResult : BoletasDepositos
        {
            public string Entidad { get; set; }
            public long Cuenta { get; set; }
            public decimal Importe { get; set; }
        }
    }
}
