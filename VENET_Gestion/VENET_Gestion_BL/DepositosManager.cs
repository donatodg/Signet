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

    public class DepositosManager : IDisposable
    {
        private GestionContext db;
        public Depositos Deposito { get; set; }

        public DepositosManager(Depositos o)
        {
            db = new GestionContext();
            Deposito = o;

            db.Depositos.Attach(o);
             
            if (Deposito.Id > 0) db.Entry(o).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Deposito.Id == 0)
            {
                db.Entry(Deposito).State = EntityState.Added;

                Deposito.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Deposito.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Deposito).State = EntityState.Modified;
                Deposito.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Deposito.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Depositos o)
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

                r = (from f in db.Depositos
                     where (f.Id == parametros.Id || parametros.Id == null)
                            && (f.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (f.UserDel == null)
                     select new SearchResult
                     {
                         Id = f.Id,
                         Descripcion =f.Descripcion,
                         FechaAdd = f.FechaAdd,
                         FechaMod = f.FechaMod,
                         UserAdd = f.UserAdd,
                         UserMod = f.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Depositos
        {

        }
    }
}
