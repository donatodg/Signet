namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionManoDeObraManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_ManoDeObra ManoDeObra { get; set; }

        public ProduccionManoDeObraManager(Produccion_ManoDeObra o)
        {
            db = new ProduccionContext();
            ManoDeObra = o;

            db.Produccion_ManoDeObra.Attach(ManoDeObra);

            if (ManoDeObra.Id > 0) db.Entry(ManoDeObra).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save(bool RegistraHistorial)
        {
            if (ManoDeObra.Id == 0)
            {
                db.Entry(ManoDeObra).State = EntityState.Added;
                ManoDeObra.FechaAdd = Sistema.ObtenerFechaHora();
                ManoDeObra.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(ManoDeObra).State = EntityState.Modified;
                ManoDeObra.FechaMod = Sistema.ObtenerFechaHora();
                ManoDeObra.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            if (RegistraHistorial)
            {
                Produccion_ManoDeObraHistorial h = new Produccion_ManoDeObraHistorial()
                {
                    Id_ManoObra = ManoDeObra.Id,
                    PrecioHora = ManoDeObra.PrecioHora,
                    FechaAdd = Sistema.ObtenerFechaHora(),
                    UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                };

                db.Produccion_ManoDeObraHistorial.Attach(h);
                db.Entry(h).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static void Eliminar(Produccion_ManoDeObra o)
        {
            using (var db = new ProduccionContext())
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
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from l in db.Produccion_ManoDeObra
                     where (l.Id == parametros.Id || parametros.Id == null)
                        && (l.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                        && (l.UserDel == null)
                     select new SearchResult()
                     {
                         Id = l.Id,
                         Descripcion = l.Descripcion,
                         DescripcionCorta = l.DescripcionCorta,
                         PrecioHora = l.PrecioHora,
                         FechaAdd = l.FechaAdd,
                         FechaMod = l.FechaMod,
                         UserAdd = l.UserAdd,
                         UserMod = l.UserMod
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Produccion_ManoDeObra
        {
        }

    }
}
