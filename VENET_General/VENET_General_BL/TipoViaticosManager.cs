namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TipoViaticosManager : IDisposable
    {
        private GeneralContext db;
        public TipoViaticos Viatico { get; set; }
        //private Decimal Importe;

        public TipoViaticosManager(TipoViaticos o)
        {
            db = new GeneralContext();
            Viatico = o;
            db.TipoViaticos.Attach(Viatico);

            if (Viatico.Id > 0)
            {
                db.Entry(Viatico).Reload();
                if (Viatico.Detalle == null)
                    db.Entry(Viatico).Collection(p => p.Detalle).Load();

                //if (Viatico.Detalle.Count > 0)
                //{
                //    foreach (TipoViaticosPrecios row in Viatico.Detalle)
                //    {
                //        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();
                //    }
                //}

                //IdEntidad = Recibo.Id_Entidad;
            }
            else
            {
                //Viatico.Fecha = Sistema.ObtenerFechaHora();
                ////Recibo.TipoEntidad = Enums.TipoEntidad.Personal;
                //if (Sistema.CentrosCostos.Count() > 0)
                //    Viatico.Id_CentroCosto = Sistema.CentrosCostos.First().Key;

                db.Entry(Viatico).Collection(p => p.Detalle).Load();

            }
            //Importe = Viatico.Importe;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Viatico.Detalle.Count == 0)
                throw new ValidationException("No se ingresó el importe.");

            if (Viatico.Id == 0)
            {
                db.Entry(Viatico).State = EntityState.Added;
                Viatico.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Viatico.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Viatico).State = EntityState.Modified;
                Viatico.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Viatico.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            //TipoViaticosHistorial Historial = new TipoViaticosHistorial() { Id_TipoViatico = Viatico.Id, Importe = Viatico.Importe, FechaAdd = Sistema.ObtenerFechaHora(), UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]) };

            //if (Importe != Viatico.Importe)
            //{
            //    db.TipoViaticosHistorial.Attach(Historial);
            //    db.Entry(Historial).State = EntityState.Added;
            //}

            //db.SaveChanges();

            Boolean Flag = false;
            using (var db1 = new GeneralContext())
            {
                foreach (TipoViaticosPrecios row in Viatico.Detalle.Where(t => t.Borrado == true))
                {
                    TipoViaticosPrecios o = new TipoViaticosPrecios() { Id = row.Id };
                    db1.TipoViaticosPrecios.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(TipoViaticos o)
        {
            using (var db = new GeneralContext())
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
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();
                DateTime f = Sistema.ObtenerFecha();

                r = (from t in db.TipoViaticos
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         Importe = 0,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();

                foreach (SearchResult s in r)
                {
                    s.Importe = db.TipoViaticosPrecios.Where(t => t.Id_TipoViatico == s.Id && t.UserDel == null && t.VigenciaDesde <= f && t.VigenciaHasta >= f).Select(t => t.Importe).FirstOrDefault();
                }
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : TipoViaticos
        {
            public Decimal Importe { get; set; }
        }
    }
}
