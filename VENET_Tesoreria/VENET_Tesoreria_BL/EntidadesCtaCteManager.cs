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

    public class EntidadesCtaCteManager : IDisposable
    {
        private TesoreriaContext db;
        public EntidadesCtaCte CtaCte { get; set; }

        public EntidadesCtaCteManager(EntidadesCtaCte o)
        {
            db = new TesoreriaContext();
            CtaCte = o;

            db.EntidadesCtaCte.Attach(CtaCte);

            if (CtaCte.Id > 0) db.Entry(CtaCte).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (CtaCte.Debito > 0 && CtaCte.Credito > 0) throw new ValidationException("Solo debe ingresar un importe.");
            if (CtaCte.Debito == 0 && CtaCte.Credito == 0) throw new ValidationException("Debe ingresar un importe.");
            if (CtaCte.Debito < 0 || CtaCte.Credito < 0) throw new ValidationException("Debe ingresar un importe válido.");

            if (CtaCte.Id == 0)
            {
                db.Entry(CtaCte).State = EntityState.Added;
                CtaCte.FechaAdd = Sistema.ObtenerFechaHora();
                CtaCte.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(CtaCte).State = EntityState.Modified;
                CtaCte.FechaMod = Sistema.ObtenerFechaHora();
                CtaCte.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(EntidadesCtaCte o)
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

        public static void ActualizaComentario(int Id, int Id_Comentario)
        {
            using (var db = new TesoreriaContext())
            {
                EntidadesCtaCte o = new EntidadesCtaCte() { Id = Id };

                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();
                
                o.Id_Comentario = Id_Comentario;

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            if (parametros.Id_Entidad == null) throw new ValidationException("Debe seleccionar una entidad.");
            if (parametros.Id_Especie == null) throw new ValidationException("Debe seleccionar una especie.");

            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();
                List<SearchResult> Result = new List<SearchResult>();

                double? SaldoAnterior;
                if (parametros.FechaDesde == null)
                { SaldoAnterior = 0; }
                else
                {
                    SaldoAnterior = (from e in db.EntidadesCtaCte
                                     where e.Fecha < parametros.FechaDesde
                                           && e.Id_TipoEntidad == parametros.Id_TipoEntidad
                                           && e.Id_Entidad == parametros.Id_Entidad
                                           && e.Id_Especie == parametros.Id_Especie
                                           && e.UserDel == null
                                     select new { D = e.Debito, C = e.Credito }
                                              ).Sum(s => (double?)(s.D - s.C)) ?? 0;
                }
                Result.Add(new SearchResult() { Id = 0, Concepto = "Saldo Anterior", Credito = 0, Debito = 0, Fecha = new DateTime(1900, 01, 01), Saldo = (decimal)SaldoAnterior, InternoSistema = true });

                if (parametros.FechaHasta != null && parametros.FechaHasta == parametros.FechaDesde) parametros.FechaHasta = parametros.FechaHasta.Value.AddDays(1);

                r = (from ecc in db.EntidadesCtaCte
                     join e in db.Especies on ecc.Id_Especie equals e.Id into listEspecies
                     from esp in listEspecies.DefaultIfEmpty()
                     join t in db.TipoComprobante on ecc.Id_TipoComprobante equals t.Id into listTipo
                     from tip in listTipo.DefaultIfEmpty()
                     join cc in db.CentrosCostos on ecc.Id_CentroCosto equals cc.Id into listCC
                     from centro in listCC
                     where (ecc.Id == parametros.Id || parametros.Id == null)
                      && (ecc.Concepto.Contains(parametros.Concepto) || parametros.Concepto == null)
                      && (ecc.Id_TipoComprobante == parametros.Id_TipoComprobante || parametros.Id_TipoComprobante == null)
                      && (ecc.Fecha >= parametros.FechaDesde && ecc.Fecha <= parametros.FechaHasta || parametros.FechaHasta == null || parametros.Id != null)
                      && (ecc.Id_Especie == parametros.Id_Especie || parametros.Id != null)
                      && (ecc.Id_TipoEntidad == parametros.Id_TipoEntidad || parametros.Id != null)
                      && (ecc.Id_Entidad == parametros.Id_Entidad || parametros.Id != null)
                      && (ecc.UserDel == null)
                     orderby ecc.Fecha, ecc.FechaAdd 
                     select new SearchResult
                     {
                         Id = ecc.Id,
                         Id_Entidad = ecc.Id_Entidad,
                         Id_TipoEntidad = ecc.Id_TipoEntidad,
                         NombreEntidad = ecc.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == ecc.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                         : ecc.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == ecc.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                         : ecc.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? db.ProvFinancieros.Where(c => c.Id == ecc.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                         : ecc.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == ecc.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         TipoEntidad = ecc.Id_TipoEntidad,
                         Fecha = ecc.Fecha,
                         Id_CentroCosto = ecc.Id_CentroCosto,
                         Id_Comprobante = ecc.Id_Comprobante,
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
                         Id_Comentario = ecc.Id_Comentario,
                         FechaAdd = ecc.FechaAdd,
                         FechaMod = ecc.FechaMod,
                         UserAdd = ecc.UserAdd,
                         UserMod = ecc.UserMod
                     }).ToList();

                foreach (SearchResult row in r)
                {
                    SaldoAnterior += (double)(row.Debito - row.Credito);
                    row.Saldo = (decimal)SaldoAnterior;

                    if (row.Id_Comentario != null)
                        row.Color = db.Comentarios.Where(t => t.Id == row.Id_Comentario && t.Tabla == "EntidadesCtaCte").Select(t => t.Color).FirstOrDefault();
                             
                    Result.Add(row);
                }

                return Result;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = Convert.ToDateTime(Parametro.ObtenerValor(Parametro.Param.Parametro_FechaDesde));
                FechaHasta = Sistema.ObtenerFecha();

                if (FechaDesde.Value == new DateTime(2001, 01, 01))
                    FechaDesde = FechaHasta;

            }

            public Enums.TipoEntidad Id_TipoEntidad { get; set; }
            public int? Id_Entidad { get; set; }
            public int? Id_Especie { get; set; }
            public int? Id { get; set; }
            public DateTime? FechaDesde { get; set; }
            public DateTime? FechaHasta { get; set; }
            public string Concepto { get; set; }
            public int? Id_TipoComprobante { get; set; }


            public List<KeyNamePair> Entidades
            {
                get
                {
                    return Sistema.ObtenerEntidades(Id_TipoEntidad);
                }
            }

            public List<KeyNamePair> EspeciesPF
            {
                get
                {
                    using (var db = new TesoreriaContext())
                        return db.Especies.Where(t => t.UserDel == null && t.Id == (db.ProvFinancierosCuentas.Where(tt => tt.Id == Id_Entidad).Select(tt => tt.Id_Especie).FirstOrDefault())).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList();
                }
            }
        }

        public class SearchResult : EntidadesCtaCte
        {
            public Enums.TipoEntidad TipoEntidad { get; set; }
            public string NombreEntidad { get; set; }
            public string Especie { get; set; }
            public string Movimiento { get; set; }
            public decimal Saldo { get; set; }
            public string CentroCosto { get; set; }
            public bool InternoSistema { get; set; }
            public Enums.ComprobanteArea Id_Area { get; set; }
            public string Color { get; set; }
        }

    }
}
