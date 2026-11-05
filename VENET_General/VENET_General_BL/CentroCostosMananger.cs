namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class CentroCostosMananger : IDisposable
    {
        private GeneralContext db;
        public CentrosCostos CentroCosto { get; set; }

        public CentroCostosMananger(CentrosCostos o)
        {
            db = new GeneralContext();
            CentroCosto = o;

            db.CentrosCostos.Attach(CentroCosto);

            if (CentroCosto.Id > 0) db.Entry(CentroCosto).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {

            if (CentroCosto.Id == 0)
            {
                db.Entry(CentroCosto).State = EntityState.Added;

                CentroCosto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                CentroCosto.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(CentroCosto).State = EntityState.Modified;
                CentroCosto.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                CentroCosto.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(CentrosCostos o)
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

                r = (from e in db.CentrosCostos
                     where (e.Id == parametros.Id || parametros.Id == null)
                            && (e.Descripcion .Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (e.UserDel == null)
                            //&& (Seguridad.IdCentrosCostosAsignados.Contains(e.Id))
                     select new SearchResult
                     {
                         Id = e.Id,
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
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : CentrosCostos
        {

        }
    }
}
