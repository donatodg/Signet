namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TipoComprobanteManager : IDisposable
    {
        private TesoreriaContext db;
        public TipoComprobante TipoComp { get; set; }

        public TipoComprobanteManager(TipoComprobante o)
        {
            db = new TesoreriaContext();
            TipoComp = o;

            db.TipoComprobante.Attach(TipoComp);

            if (TipoComp.Id > 0) db.Entry(TipoComp).Reload();
            else
            {
                TipoComp.Id_Area = VENET_Comun.Enums.ComprobanteArea.Libre;
                TipoComp.Orden = 1;
            }
        }

        public List<KeyNamePair> TiposComprobantes { get { return (from tc in db.TipoComprobante where tc.Id != TipoComp.Id && tc.Id_Area == VENET_Comun.Enums.ComprobanteArea.Ventas && tc.UserDel == null select new KeyNamePair() { Key = tc.Id, Name = tc.Descripcion }).OrderBy(t => t.Name).ToList(); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (TipoComp.MueveStock == true && TipoComp.RestaStock == true)
                throw new ValidationException("Debe elegir si incrementa o decrementa stock.");

            if (TipoComp.Id == 0)
            {
                db.Entry(TipoComp).State = EntityState.Added;
                TipoComp.FechaAdd = Sistema.ObtenerFechaHora();
                TipoComp.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                TipoComp.InternoSistema = false;
            }
            else
            {
                db.Entry(TipoComp).State = EntityState.Modified;
                TipoComp.FechaMod = Sistema.ObtenerFechaHora();
                TipoComp.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoComprobante o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.InternoSistema == true) throw new ValidationException("No se puede eliminar un tipo de comprobante interno del sistema.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static string ObtenerTipoComprobante(int Id_TipoComprobante)
        {
            using (var db = new TesoreriaContext())
            {
                return db.TipoComprobante.Where(t => t.Id == Id_TipoComprobante).Select(t => t.DescripcionCorta).FirstOrDefault();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.TipoComprobante
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.InternoSistema == false)
                            && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         DescripcionCorta = t.DescripcionCorta,
                         Orden = t.Orden,
                         Id_Area = t.Id_Area,
                         InternoSistema = t.InternoSistema,
                         Id_TipoCompAnula = t.Id_TipoCompAnula,
                         Id_TipoCompProcesa = t.Id_TipoCompProcesa,
                         MueveStock = t.MueveStock,
                         RestaStock = t.RestaStock,
                         Id_MovimientoCaja = t.Id_MovimientoCaja,
                         Id_MovimientoEntidad = t.Id_MovimientoEntidad,
                         GeneraDeuda = t.GeneraDeuda,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();

                return r;

            }
        }

        public static bool GeneraDeuda(int Id_TipoComprobante)
        {
            using (var db = new TesoreriaContext())
            {
                return db.TipoComprobante.Where(t => t.Id == Id_TipoComprobante).Select(t => t.GeneraDeuda).FirstOrDefault();
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : TipoComprobante
        {

        }
    }
}
