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

    public class TipoImpuestosManager : IDisposable
    {
        private GestionContext db;
        public TipoImpuestos Impuesto { get; set; }

        public TipoImpuestosManager(TipoImpuestos o)
        {
            db = new GestionContext();
            Impuesto = o;

            db.TipoImpuestos.Attach(o);

            if (Impuesto.Id > 0) db.Entry(Impuesto).Reload();
            else
            {
                Impuesto.AplicaSobre = VENET_Comun.Enums.AplicaSobre.Bruto;
                Impuesto.Id_TipoImpuesto = VENET_Comun.Enums.TipoImpuesto.Retencion;
            }
        }

        public List<KeyNamePair> AfipTributo { get { using (var db = new GestionContext()) { return db.AFIP_Tributos.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            //if (!Impuesto.Percepcion && !Impuesto.Retencion) throw new ValidationException("Debe seleccionar un tipo de impuesto.");
            //if (Impuesto.Percepcion && Impuesto.Retencion) throw new ValidationException("Debe seleccionar un solo tipo de impuesto.");

            if (Impuesto.Id == 0)
            {
                db.Entry(Impuesto).State = EntityState.Added;

                Impuesto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Impuesto.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Impuesto).State = EntityState.Modified;
                Impuesto.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Impuesto.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoImpuestos o)
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

                r = (from t in db.TipoImpuestos
                     join at in db.AFIP_Tributos on t.Id_AFIP_Tributos equals at.Id into listAT
                     from a in listAT.DefaultIfEmpty()
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         AplicaSobre = t.AplicaSobre,
                         Id_TipoImpuesto = t.Id_TipoImpuesto,
                         Id_AFIP_Tributos = t.Id_AFIP_Tributos,
                         TributoAfip = a.Descripcion,
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

        public class SearchResult : TipoImpuestos
        {
            public string TributoAfip { get; set; }
        }

    }
}
