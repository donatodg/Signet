namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using VENET_Comun;
    using System.Linq;
    using VENET_DataEntity;
    using VENET_Common;

    public class ParametrosManager : IDisposable
    {
        private GeneralContext db;
        public Parametros Parametro { get; set; }

        public ParametrosManager(Parametros o)
        {
            db = new GeneralContext();
            Parametro = o;
            db.Parametros.Attach(Parametro);
            db.Entry(Parametro).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            db.Entry(Parametro).State = EntityState.Modified;
            Parametro.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            Parametro.FechaMod = Sistema.ObtenerFechaHora();

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            VENET_Common.Parametro.Reload();
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Parametros
                     where (p.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                     select new SearchResult
                     {
                         Nombre = p.Nombre,
                         Valor = p.Valor,
                         Descripcion = p.Descripcion,
                         TipoDato = p.TipoDato,
                         Modulo = p.Modulo,
                         FechaMod = p.FechaMod,
                         UserMod = p.UserMod
                     }).ToList();

                foreach (SearchResult item in r.Where(t => t.TipoDato == Enums.TipoDato.Password))
                {
                    item.Valor = "********";
                }
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public string Nombre { get; set; }
        }

        public class SearchResult : Parametros
        {

        }
    }
}
