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

    public class PadronIIBBManager //: IDisposable
    {
        //private GestionContext db;

        public PadronIIBBManager()
        {
        }

        //public void Dispose()
        //{
        //    if (db != null) db.Dispose();
        //}


        public static void Eliminar(PadronIIBB o)
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

                r = (from p in db.PadronIIBB
                     where (p.Id == parametros.Id || parametros.Id == null)
                            && (p.UserDel == null)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Archivo = p.Archivo,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = Sistema.ObtenerFecha().AddMonths(-2);
            }
            public int? Id { get; set; }
            public DateTime FechaDesde { get; set; }
        }

        public class SearchResult : PadronIIBB
        {

        }
    }
}
