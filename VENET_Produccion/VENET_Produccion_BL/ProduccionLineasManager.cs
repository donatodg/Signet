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

    public class ProduccionLineasManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_Lineas Linea { get; set; }

        public ProduccionLineasManager(Produccion_Lineas o)
        {
            db = new ProduccionContext();
            Linea = o;

            db.Produccion_Lineas.Attach(Linea);

            if (Linea.Id > 0) db.Entry(Linea).Reload();
            else Linea.DescripcionCorta = "-";
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Linea.Id == 0)
            {
                db.Entry(Linea).State = EntityState.Added;
                Linea.FechaAdd = Sistema.ObtenerFechaHora();
                Linea.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Linea).State = EntityState.Modified;
                Linea.FechaMod = Sistema.ObtenerFechaHora();
                Linea.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Produccion_Lineas o)
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

                r = (from l in db.Produccion_Lineas
                     join e in db.Empresas on l.Id_Empresa equals e.Id into listEmpresas
                     from emp in listEmpresas.DefaultIfEmpty()
                     where (l.Id == parametros.Id || parametros.Id == null)
                      && (l.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                      && (l.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                      && (l.UserDel == null)
                     select new SearchResult()
                     {
                         Id = l.Id,
                         Id_Empresa = l.Id_Empresa,
                         Descripcion = l.Descripcion,
                         DescripcionCorta = l.DescripcionCorta,
                         Empresa = emp.Nombre,
                         Codigo = l.Codigo,
                         ImprimirConCodigo = l.ImprimirConCodigo,
                         ImprimirVertical = l.ImprimirVertical,
                         ObservacionesImpresion = l.ObservacionesImpresion,
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
            public int? Id_Empresa { get; set; }
        }

        public class SearchResult : Produccion_Lineas
        {
            public string Empresa { get; set; }
        }

    }
}
