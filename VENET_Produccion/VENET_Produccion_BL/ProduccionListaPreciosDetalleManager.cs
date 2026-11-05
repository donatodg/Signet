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

    public class ProduccionListaPreciosDetalleManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_ListaPreciosDetalle Lista { get; set; }

        public ProduccionListaPreciosDetalleManager(Produccion_ListaPreciosDetalle o)
        {
            db = new ProduccionContext();
            Lista = o;

            db.Produccion_ListaPreciosDetalle.Attach(Lista);

            if (Lista.Id > 0) db.Entry(Lista).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Lista.Id == 0)
            {
                db.Entry(Lista).State = EntityState.Added;
                Lista.FechaAdd = Sistema.ObtenerFechaHora();
                Lista.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Lista).State = EntityState.Modified;
                Lista.FechaMod = Sistema.ObtenerFechaHora();
                Lista.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            Lista.Ajuste = (((Lista.CostoComposicion + Lista.CostoTareas) * Lista.Utilidad / 100) + (Lista.CostoComposicion + Lista.CostoTareas) - Lista.Total) * -1;

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Produccion_ListaPreciosDetalle o)
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

                r = (from p in db.Produccion_ListaPreciosDetalle
                     join var in db.Produccion_Variantes on p.Id_Variante equals var.Id into listVar
                     from v in listVar
                     join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLineas
                     from l in listLineas
                     join med in db.Produccion_Medidas on p.Id_Medida equals med.Id into listMed
                     from m in listMed
                     where (p.Id == parametros.Id || parametros.Id == null)
                        && (p.Id_ListaPrecios == parametros.Id_ListaPrecios || parametros.Id_ListaPrecios == null)
                        && (p.UserDel == null)
                        && (v.UserDel == null)
                        && (l.UserDel == null)
                        && (m.UserDel == null)
                     select new SearchResult()
                     {
                         Id = p.Id,
                         Id_Medida = p.Id_Medida,
                         Id_Linea = l.Id,
                         Id_Variante = p.Id_Variante,
                         Linea = l.Codigo + "-" + l.Descripcion,
                         Medida = m.Medida,
                         Producto = l.Descripcion + " - " + v.Descripcion + " - " + m.Medida,
                         Codigo = l.Codigo + v.Codigo + m.Codigo,
                         CostoComposicion = p.CostoComposicion,
                         CostoTareas = p.CostoTareas,
                         Total = p.Total,
                         Id_ListaPrecios = p.Id_ListaPrecios,
                         Ajuste = p.Ajuste,
                         Utilidad = p.Utilidad,
                         Variante = v.Codigo + "-" + v.Descripcion,
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
            public int? Id { get; set; }
            public int? Id_ListaPrecios { get; set; }
        }

        public class SearchResult : Produccion_ListaPreciosDetalle
        {
            public int Id_Linea { get; set; }
            public string Linea { get; set; }
            public string Variante { get; set; }
            public string Medida { get; set; }
            public string Producto { get; set; }
            public string Codigo { get; set; }
        }
    }
}
