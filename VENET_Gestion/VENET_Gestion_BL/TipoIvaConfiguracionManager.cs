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

    public class TipoIvaConfiguracionManager : IDisposable
    {
        private GestionContext db;
        public TipoIva_Configuracion Config { get; set; }
        public List<SearchResult> ListConfig { get; set; }

        public TipoIvaConfiguracionManager(int Id_TipoIvaDestino)
        {
            db = new GestionContext();

            ListConfig = (from tic in db.TipoIva_Configuracion
                          join o in db.TipoIva on tic.Id_TipoIvaOrigen equals o.Id into listOrig
                          from orig in listOrig
                          join d in db.TipoIva on tic.Id_TipoIvaDestino equals d.Id into listDest
                          from dest in listDest
                          join tc in db.TipoComprobante on tic.Id_TipoComprobante equals tc.Id into listTc
                          from tipoc in listTc
                          where tic.Id_TipoIvaDestino == Id_TipoIvaDestino
                             && tic.UserDel == null
                          select new SearchResult()
                          {
                              Id = tic.Id,
                              Comprobante = tipoc.Descripcion,
                              Destino = dest.Nombre,
                              Id_TipoComprobante = tic.Id_TipoComprobante,
                              Id_TipoIvaDestino = tic.Id_TipoIvaDestino,
                              Id_TipoIvaOrigen = tic.Id_TipoIvaOrigen,
                              Letra = tic.Letra,
                              Origen = orig.Nombre,
                              FechaAdd = tic.FechaAdd,
                              FechaMod = tic.FechaMod,
                              UserAdd = tic.UserAdd,
                              UserMod = tic.UserMod
                          }).ToList();
        }

        public TipoIvaConfiguracionManager(TipoIva_Configuracion o)
        {
            db = new GestionContext();
            Config = o;

            db.TipoIva_Configuracion.Attach(Config);

            if (Config.Id > 0)
                db.Entry(Config).Reload();
            else
            {
                Config.Id_TipoComprobante = Sistema.TipoComprobanteVentas.First().Key;
                Config.Id_TipoIvaOrigen = Sistema.TiposIva.First().Key;
                Config.Id_TipoIvaDestino = o.Id_TipoIvaDestino;
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            //validar que no este duplicado
            //&& t.Letra == Config.Letra
            if (db.TipoIva_Configuracion.Where(t => t.Id != Config.Id && t.UserDel == null && t.Id_TipoIvaOrigen == Config.Id_TipoIvaOrigen && t.Id_TipoIvaDestino == Config.Id_TipoIvaDestino && t.Id_TipoComprobante == Config.Id_TipoComprobante).Count() > 0)
                throw new ValidationException("La configuración ya se encuentra registrada.");

            if (Config.Id == 0)
            {
                db.Entry(Config).State = EntityState.Added;
                Config.FechaAdd = Sistema.ObtenerFechaHora();
                Config.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Config).State = EntityState.Modified;
                Config.FechaMod = Sistema.ObtenerFechaHora();
                Config.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoIva_Configuracion o)
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

                r = (from tic in db.TipoIva_Configuracion
                     join o in db.TipoIva on tic.Id_TipoIvaOrigen equals o.Id into listOrig
                     from orig in listOrig
                     join d in db.TipoIva on tic.Id_TipoIvaDestino equals d.Id into listDest
                     from dest in listDest
                     join tc in db.TipoComprobante on tic.Id_TipoComprobante equals tc.Id into listTc
                     from tipoc in listTc
                     where (tic.Id == parametros.Id || parametros.Id == null)
                        && (tic.UserDel == null)
                     select new SearchResult()
                     {
                         Id = tic.Id,
                         Comprobante = tipoc.Descripcion,
                         Destino = dest.Nombre,
                         Id_TipoComprobante = tic.Id_TipoComprobante,
                         Id_TipoIvaDestino = tic.Id_TipoIvaDestino,
                         Id_TipoIvaOrigen = tic.Id_TipoIvaOrigen,
                         Letra = tic.Letra,
                         Origen = orig.Nombre,
                         FechaAdd = tic.FechaAdd,
                         FechaMod = tic.FechaMod,
                         UserAdd = tic.UserAdd,
                         UserMod = tic.UserMod
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
        }

        public class SearchResult : TipoIva_Configuracion
        {
            public string Origen { get; set; }
            public string Destino { get; set; }
            public string Comprobante { get; set; }
        }
    }
}
