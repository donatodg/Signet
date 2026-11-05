namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_DataEntity;
    using VENET_Common;

    public class FeriadosManager : IDisposable
    {
        private GeneralContext db;
        public Feriados Feriado { get; set; }

        public FeriadosManager(Feriados o)
        {
            db = new GeneralContext();
            Feriado = o;

            db.Feriados.Attach(Feriado);

            if (Feriado.Id > 0) db.Entry(Feriado).Reload();
            else Feriado.Fecha = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, Sistema.ObtenerFechaHora().Day);
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {

            if (Feriado.Id == 0)
            {
                db.Entry(Feriado).State = EntityState.Added;

                Feriado.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Feriado.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Feriado).State = EntityState.Modified;
                Feriado.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Feriado.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Feriados o)
        {
            using (var db = new GeneralContext())
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
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from e in db.Feriados
                     where (e.Id == parametros.Id || parametros.Id == null)
                     && (e.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                     && (e.Fecha.Year == parametros.Año)
                     && (e.UserDel == null)
                     select new SearchResult
                     {
                         Id = e.Id,
                         Fecha = e.Fecha,
                         Descripcion = e.Descripcion,
                         FechaAdd = e.FechaAdd,
                         FechaMod = e.FechaMod,
                         UserAdd = e.UserAdd,
                         UserMod = e.UserMod
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Año = Sistema.ObtenerFechaHora().Year;
            }

            public int? Id { get; set; }
            public string Descripcion { get; set; }
            public int Año { get; set; }
        }

        public class SearchResult : Feriados
        {

        }
    }
}
