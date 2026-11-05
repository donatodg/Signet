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

    public class TipoNovedadesManager : IDisposable
    {
        private GeneralContext db;
        public TipoNovedades Novedad { get; set; }

        public TipoNovedadesManager(TipoNovedades o)
        {
            db = new GeneralContext();
            Novedad = o;

            db.TipoNovedades.Attach(Novedad);

            if (Novedad.Id > 0) db.Entry(Novedad).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (db.TipoNovedades.Where(t => t.UserDel == null && t.Id != Novedad.Id && t.Descripcion == Novedad.Descripcion).Count() > 0)
                throw new ValidationException("El tipo de novedad ya se encuentra cargado.");

            if (Novedad.Id == 0)
            {
                db.Entry(Novedad).State = EntityState.Added;

                Novedad.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Novedad.FechaAdd = Sistema.ObtenerFechaHora();
                Novedad.ALaOrden = false;
                Novedad.RRHH = false;
            }
            else
            {
                db.Entry(Novedad).State = EntityState.Modified;
                Novedad.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Novedad.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoNovedades o)
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

                r = (from t in db.TipoNovedades
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.ALaOrden == false)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         DescripcionLarga = t.DescripcionLarga,
                         RRHH = t.RRHH,
                         ALaOrden = t.ALaOrden,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : TipoNovedades
        {

        }
    }
}
