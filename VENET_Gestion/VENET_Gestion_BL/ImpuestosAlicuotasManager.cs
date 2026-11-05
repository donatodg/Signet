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

    public class ImpuestosAlicuotasManager : IDisposable
    {
        private GestionContext db;
        public ImpuestosAlicuotas Alicuota { get; set; }
        //private int Id_Impuesto { get; set; }

        public ImpuestosAlicuotasManager(ImpuestosAlicuotas o)
        {
            db = new GestionContext();
            Alicuota = o;
            //Id_Impuesto = o.Id_Impuesto;

            db.ImpuestosAlicuotas.Attach(o);

            if (Alicuota.Id > 0) db.Entry(Alicuota).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Alicuota.Alicuota > 100)
                throw new ValidationException("El valor máximo para Alícuota es 100,00.");

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

        public static void Eliminar(ImpuestosAlicuotas o)
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

                r = (from t in db.ImpuestosAlicuotas
                     join p in db.Provincias on t.Id_Provincia equals p.Id into listProv
                     from prov in listProv.DefaultIfEmpty()
                     where (t.Id == parametros.Id || parametros.Id == null)
                              && (t.Id_Impuesto == parametros.Id_Impuesto)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Alicuota = t.Alicuota,
                         BaseImponible = t.BaseImponible,
                         //AcumuladoMes = t.AcumuladoMes,
                         Id_Impuesto = t.Id_Impuesto,
                         Id_Provincia = t.Id_Provincia,
                         ImporteMinimo = t.ImporteMinimo,
                         Provincia = prov.Descripcion,
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
            public int Id_Impuesto { get; set; }
        }

        public class SearchResult : ImpuestosAlicuotas
        {
            //public string Provincia { get; set; }
        }
    }
}
