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

    public class ProduccionTareasManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_Tareas Tarea { get; set; }

        public ProduccionTareasManager(Produccion_Tareas o)
        {
            db = new ProduccionContext();
            Tarea = o;

            db.Produccion_Tareas.Attach(Tarea);

            if (Tarea.Id > 0) db.Entry(Tarea).Reload();
            else
            {
                Tarea.Horas = new DateTime(2001, 01, 01);
                Tarea.DescripcionCorta = "-";
            }
        }

        //public List<KeyNamePair> ManoDeObra
        //{
        //    get
        //    {
        //        return (from m in db.Produccion_ManoDeObra
        //                where (m.UserDel == null)
        //                select new KeyNamePair()
        //                {
        //                    Key = m.Id,
        //                    Name = m.Descripcion
        //                }).OrderBy(t => t.Key).ToList();
        //    }
        //}

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Tarea.Id == 0)
            {
                db.Entry(Tarea).State = EntityState.Added;
                Tarea.FechaAdd = Sistema.ObtenerFechaHora();
                Tarea.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Tarea).State = EntityState.Modified;
                Tarea.FechaMod = Sistema.ObtenerFechaHora();
                Tarea.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Produccion_Tareas o)
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

                r = (from t in db.Produccion_Tareas
                         //join mdo in db.Produccion_ManoDeObra on t.Id_ManoObra equals mdo.Id into listMDO
                         //from mo in listMDO
                     where (t.Id == parametros.Id || parametros.Id == null)
                      && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                      && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         DescripcionCorta = t.DescripcionCorta,
                         Unidades = t.Unidades,
                         //Id_ManoObra = t.Id_ManoObra,
                         //CantidadUnidadesHora = t.CantidadUnidadesHora,
                         //ManoDeObra = mo.Descripcion,
                         //Costo = (mo.PrecioHora / 100) * t.CantidadUnidadesHora,
                         Horas = t.Horas,
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

        public class SearchResult : Produccion_Tareas
        {
            //public string ManoDeObra { get; set; }
            //public decimal Costo { get; set; }
        }
    }
}
