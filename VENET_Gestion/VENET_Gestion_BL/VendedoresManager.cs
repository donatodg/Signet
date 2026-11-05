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

    public class VendedoresManager : IDisposable
    {
        private GestionContext db;
        public Vendedores Vendedor { get; set; }

        public VendedoresManager(Vendedores o)
        {
            db = new GestionContext();
            Vendedor = o;

            db.Vendedores.Attach(o);

            if (Vendedor.Id > 0) db.Entry(Vendedor).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        //public List<Key2Name3Pair> CP
        //{
        //    get
        //    {
        //        return (from l in db.Localidades
        //                join p in db.Provincias on l.Id_Provincia equals p.Id into listProv
        //                from prov in listProv
        //                select new Key2Name3Pair()
        //                {
        //                    Key = l.Id,
        //                    Key2 = l.CodPostal,
        //                    Name = l.Localidad,
        //                    Name2 = prov.Descripcion,
        //                    Name3 = l.CodPostal.ToString() + " - " + l.Localidad
        //                }).ToList();
        //    }
        //}

        public void Save()
        {
            if (Vendedor.Id == 0)
            {
                db.Entry(Vendedor).State = EntityState.Added;

                Vendedor.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Vendedor.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Vendedor).State = EntityState.Modified;
                Vendedor.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Vendedor.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Vendedores o)
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

                r = (from t in db.Vendedores
                     join i in db.TipoIva on t.Id_TipoIVA equals i.Id into listTipoI
                     from TipoI in listTipoI
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Nombre = t.Nombre,
                         Cuit = t.Cuit,
                         Id_TipoIVA = t.Id_TipoIVA,
                         TipoIva = TipoI.Nombre,
                         DomicilioCalle = t.DomicilioCalle,
                         DomicilioNro = t.DomicilioNro,
                         DomicilioDpto = t.DomicilioDpto,
                         DomicilioPiso = t.DomicilioPiso,
                         Id_Localidad = t.Id_Localidad,
                         Telefono = t.Telefono,
                         Celular = t.Celular,
                         Email = t.Email,
                         Observaciones = t.Observaciones,
                         Comision = t.Comision,
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
            public string Nombre { get; set; }
        }

        public class SearchResult : Vendedores
        {
            public string TipoIva { get; set; }

        }
    }
}
