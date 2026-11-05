namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class IvaAlicuotaManager : IDisposable
    {
        private GestionContext db;
        public IvaAlicuotas Alicuota { get; set; }

        public IvaAlicuotaManager(IvaAlicuotas o)
        {
            db = new GestionContext();
            Alicuota = o;

            db.IvaAlicuotas.Attach(o);

            if (Alicuota.Id > 0) db.Entry(Alicuota).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Alicuota.Id == 0)
            {
                db.Entry(Alicuota).State = EntityState.Added;

                Alicuota.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Alicuota.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Alicuota).State = EntityState.Modified;
                Alicuota.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Alicuota.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(IvaAlicuotas o)
        {
            using (var db = new GestionContext())
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
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from i in db.IvaAlicuotas
                     where (i.Id == parametros.Id || parametros.Id == null)
                            && (i.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (i.UserDel == null)
                     select new SearchResult
                     {
                         Id = i.Id,
                         Descripcion = i.Descripcion,
                         Alicuota = i.Alicuota,
                         FechaAdd = i.FechaAdd,
                         FechaMod = i.FechaMod,
                         UserAdd = i.UserAdd,
                         UserMod = i.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : IvaAlicuotas
        {

        }
    }
}
