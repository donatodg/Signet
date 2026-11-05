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

    public class EspeciesCtaCteManager : IDisposable
    {
        private TesoreriaContext db;
        public EspeciesCtaCte EspecieCtaCte { get; set; }

        public EspeciesCtaCteManager(EspeciesCtaCte o)
        {
            db = new TesoreriaContext();
            EspecieCtaCte = o;

            db.EspeciesCtaCte.Attach(EspecieCtaCte);

            if (EspecieCtaCte.Id > 0) db.Entry(EspecieCtaCte).Reload();
            //if (EspecieCtaCte.Id_CentroCosto == 0) EspecieCtaCte.Id_CentroCosto = 1;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (EspecieCtaCte.Debito > 0 && EspecieCtaCte.Credito > 0) throw new ValidationException("Solo debe ingresar un importe.");
            if (EspecieCtaCte.Debito == 0 && EspecieCtaCte.Credito == 0) throw new ValidationException("Debe ingresar un importe.");
            if (EspecieCtaCte.Debito < 0 || EspecieCtaCte.Credito < 0) throw new ValidationException("Debe ingresar un importe válido.");

            //sucursal del usuario
            //EspecieCtaCte.Id_Sucursal = 1;

            if (EspecieCtaCte.Id == 0)
            {
                db.Entry(EspecieCtaCte).State = EntityState.Added;
                EspecieCtaCte.FechaAdd = Sistema.ObtenerFechaHora();
                EspecieCtaCte.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(EspecieCtaCte).State = EntityState.Modified;
                EspecieCtaCte.FechaMod = Sistema.ObtenerFechaHora();
                EspecieCtaCte.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(EspeciesCtaCte o)
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
            if (parametros.Id_Caja <= 0) throw new ValidationException("Debe seleccionar una caja.");

            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();
                List<SearchResult> Result = new List<SearchResult>();

                double? SaldoAnterior;
                DateTime? FechaHasta = parametros.FechaHasta;

                if (parametros.FechaDesde == null)
                { SaldoAnterior = 0; }
                else
                {
                    SaldoAnterior = (from e in db.EspeciesCtaCte
                                     where e.Fecha < parametros.FechaDesde
                                           && e.Id_Caja == parametros.Id_Caja
                                     && e.UserDel == null
                                     select new { D = e.Debito, C = e.Credito }
                                              ).Sum(s => (double?)(s.D - s.C)) ?? 0;
                }
                Result.Add(new SearchResult() { Id = 0, Concepto = "Saldo Anterior", Credito = 0, Debito = 0, Fecha = new DateTime(1900, 01, 01), Saldo = (decimal)SaldoAnterior, InternoSistema = true });

                if (FechaHasta != null) FechaHasta = FechaHasta.Value.AddHours(23).AddMinutes(59);

                r = (from ecc in db.EspeciesCtaCte
                     join c in db.Cajas on ecc.Id_Caja equals c.Id into listCaja
                     from caj in listCaja
                     join e in db.Especies on caj.Id_Especie equals e.Id into listEspecies
                     from esp in listEspecies.DefaultIfEmpty()
                     join t in db.TipoComprobante on ecc.Id_TipoComprobante equals t.Id into listTipo
                     from tip in listTipo.DefaultIfEmpty()
                     join cc in db.CentrosCostos on ecc.Id_CentroCosto equals cc.Id into listCC
                     from centro in listCC
                     where (ecc.Id == parametros.Id || parametros.Id == null)
                     && (ecc.Concepto.Contains(parametros.Concepto) || parametros.Concepto == null)
                     && (ecc.Id_Caja == parametros.Id_Caja)
                     && (ecc.Id_TipoComprobante == parametros.Id_TipoComprobante || parametros.Id_TipoComprobante == null)
                     && (ecc.Fecha >= parametros.FechaDesde && ecc.Fecha <= FechaHasta || parametros.FechaHasta == null || parametros.Id > 0)
                     && (ecc.UserDel == null)
                     orderby ecc.FechaAdd
                     select new SearchResult
                     {
                         Id = ecc.Id,
                         Fecha = ecc.Fecha,
                         Id_Caja = ecc.Id_Caja,
                         Id_CentroCosto = ecc.Id_CentroCosto,
                         Id_Comprobante = ecc.Id_Comprobante,
                         Caja = caj.Descripcion,
                         Id_TipoComprobante = ecc.Id_TipoComprobante,
                         InternoSistema = tip.InternoSistema,
                         Id_Area = tip.Id_Area,
                         Concepto = ecc.Concepto,
                         Id_Especie = esp.Id,
                         Especie = esp.Descripcion,
                         Movimiento = tip.Descripcion,
                         Debito = ecc.Debito,
                         Credito = ecc.Credito,
                         Saldo = 0,
                         CentroCosto = centro.Descripcion,
                         Tarjeta = ecc.Tarjeta,
                         FechaAdd = ecc.FechaAdd,
                         FechaMod = ecc.FechaMod,
                         UserAdd = ecc.UserAdd,
                         UserMod = ecc.UserMod
                     }).ToList();

                foreach (SearchResult row in r)
                {
                    SaldoAnterior += (double)(row.Debito - row.Credito);
                    row.Saldo = (decimal)SaldoAnterior;

                    Result.Add(row);
                }

                return Result;
            }
        }

        public static int ObtenerIdSucursal(int Id_Caja)
        {
            using (var db = new TesoreriaContext())
                return db.Cajas.Where(t => t.Id == Id_Caja).Select(t => t.Id_Sucursal).FirstOrDefault();
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                //FechaDesde = Convert.ToDateTime(Parametro.ObtenerValor(Parametro.Param.Parametro_FechaDesde));
                //FechaHasta = Sistema.ObtenerFecha();

                //if (FechaDesde.Value == new DateTime(2001, 01, 01))
                //    FechaDesde = FechaHasta;

                FechaDesde = Sistema.ObtenerFecha();
                FechaHasta = FechaDesde;
            }

            public int? Id { get; set; }
            public DateTime? FechaDesde { get; set; }
            public DateTime? FechaHasta { get; set; }
            public string Concepto { get; set; }
            public int? Id_TipoComprobante { get; set; }
            public int Id_Caja { get; set; }

        }

        public class SearchResult : EspeciesCtaCte
        {
            public string Caja { get; set; }
            public int Id_Especie { get; set; }
            public string Especie { get; set; }
            public string Movimiento { get; set; }
            public decimal Saldo { get; set; }
            public string CentroCosto { get; set; }
            public bool InternoSistema { get; set; }
            public Enums.ComprobanteArea Id_Area { get; set; }

        }

    }
}
