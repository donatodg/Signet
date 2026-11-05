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

    public class ProduccionMedidasManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_Medidas Medida { get; set; }

        public ProduccionMedidasManager(Produccion_Medidas o)
        {
            db = new ProduccionContext();
            Medida = o;

            db.Produccion_Medidas.Attach(Medida);

            if (Medida.Id > 0) db.Entry(Medida).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Medida.Id == 0)
            {
                db.Entry(Medida).State = EntityState.Added;
                Medida.FechaAdd = Sistema.ObtenerFechaHora();
                Medida.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Medida).State = EntityState.Modified;
                Medida.FechaMod = Sistema.ObtenerFechaHora();
                Medida.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            string a = ("000" + Medida.Ancho.ToString("n2").Replace(".", "").Replace(",", "")).Substring(3);
            string l = ("000" + Medida.Alto.ToString("n2").Replace(".", "").Replace(",", "")).Substring(3);
            Medida.Codigo = a + l;
            Medida.Medida = a + "x" + l;

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Produccion_Medidas o)
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

                r = (from m in db.Produccion_Medidas
                     where (m.Id == parametros.Id || parametros.Id == null)
                        && (m.UserDel == null)
                        && (m.Ancho == parametros.Ancho || parametros.Ancho == null)
                        && (m.Alto == parametros.Alto || parametros.Alto == null)
                     select new SearchResult()
                     {
                         Id = m.Id,
                         Ancho = m.Ancho,
                         Alto = m.Alto,
                         Codigo = m.Codigo,
                         Medida = m.Medida,
                         FechaAdd = m.FechaAdd,
                         FechaMod = m.FechaMod,
                         UserAdd = m.UserAdd,
                         UserMod = m.UserMod
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public decimal? Ancho { get; set; }
            public decimal? Alto { get; set; }
        }

        public class SearchResult : Produccion_Medidas
        {
        }

    }
}
