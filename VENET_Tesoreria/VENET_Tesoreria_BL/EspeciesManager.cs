namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class EspeciesManager : IDisposable
    {
        private TesoreriaContext db;
        public Especies Especie { get; set; }
        private decimal Cotizacion;

        public EspeciesManager(Especies o)
        {
            db = new TesoreriaContext();
            Especie = o;

            db.Especies.Attach(Especie);

            if (Especie.Id > 0) db.Entry(Especie).Reload();
            Cotizacion = Especie.Cotizacion;
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Especie.Id == 0)
            {
                db.Entry(Especie).State = EntityState.Added;
                Especie.FechaAdd = Sistema.ObtenerFechaHora();
                Especie.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Especie).State = EntityState.Modified;
                Especie.FechaMod = Sistema.ObtenerFechaHora();
                Especie.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            EspeciesCotizaciones EspecieCotizacion = new EspeciesCotizaciones() { Id_Especie = Especie.Id, Cotizacion = Especie.Cotizacion, FechaAdd = Sistema.ObtenerFechaHora(), UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]) };

            if (Cotizacion != Especie.Cotizacion)
            {
                db.EspeciesCotizaciones.Attach(EspecieCotizacion);
                db.Entry(EspecieCotizacion).State = EntityState.Added;
            }

            db.SaveChanges();
        }

        public static void Eliminar(Especies o)
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

                r = (from e in db.Especies
                     where (e.Id == parametros.Id || parametros.Id == null)
                     && (e.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                     && (e.UserDel == null)
                     select new SearchResult
                     {
                         Id = e.Id,
                         Descripcion = e.Descripcion,
                         Cotizacion = e.Cotizacion,
                         Sigla = e.Sigla,
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
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Especies
        {

        }
    }
}
