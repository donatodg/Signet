namespace VENET_Proveedores_BL
{
    using VENET_Comun;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProveedoresManager : IDisposable
    {
        private TesoreriaContext db;
        public Proveedores Proveedores { get; set; }

        public ProveedoresManager(Proveedores o)
        {
            db = new TesoreriaContext();
            Proveedores = o;

            db.Proveedores.Attach(Proveedores);

            if (Proveedores.Id > 0)
                db.Entry(Proveedores).Reload();
            else
            {
                Proveedores.Id_TipoIva = Sistema.TiposIva.First().Key;
                Proveedores.Id_CodPostal = Sistema.CodPostal.First().Id;
            }
        }

        public List<KeyNamePair> ListasPrecios { get { using (var db = new GestionContext()) { return db.ProductosListasPrecios.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            bool Nuevo = false;

            if (Proveedores.Id == 0)
            {
                db.Entry(Proveedores).State = EntityState.Added;
                Proveedores.FechaAdd = Sistema.ObtenerFechaHora();
                Proveedores.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Nuevo = true;
            }
            else
            {
                db.Entry(Proveedores).State = EntityState.Modified;
                Proveedores.FechaMod = Sistema.ObtenerFechaHora();
                Proveedores.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();


            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
            {
                int Id_UN = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_UN = db2.SeguridadUsuariosUnidadNegocios.Where(t => t.Id_Usuario == Proveedores.UserAdd && t.UserDel == null).Select(t => t.Id_UnidadNegocio).FirstOrDefault();

                    if (Id_UN == 0)
                        Id_UN = db2.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesUnidadNegocios o = new EntidadesUnidadNegocios()
                {
                    Id_Entidad = Proveedores.Id,
                    TipoEntidad = Enums.TipoEntidad.Proveedor,
                    Id_UnidadNegocio = Id_UN,
                    UserAdd = Proveedores.UserAdd,
                    FechaAdd = Proveedores.FechaAdd
                };

                db.EntidadesUnidadNegocios.Attach(o);
                db.Entry(o).State = EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }

            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
            {
                int Id_Empresa = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_Empresa = db2.SeguridadUsuariosEmpresas.Where(t => t.Id_Usuario == Proveedores.UserAdd && t.UserDel == null).Select(t => t.Id_Empresa).FirstOrDefault();

                    if (Id_Empresa == 0)
                        Id_Empresa = db2.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesEmpresas o = new EntidadesEmpresas()
                {
                    Id_Entidad = Proveedores.Id,
                    TipoEntidad = Enums.TipoEntidad.Proveedor,
                    Id_Empresa = Id_Empresa,
                    UserAdd = Proveedores.UserAdd,
                    FechaAdd = Proveedores.FechaAdd
                };

                db.EntidadesEmpresas.Attach(o);
                db.Entry(o).State = EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }
        }

        public static void Eliminar(Proveedores Proveedores)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(Proveedores).State = EntityState.Modified;
                db.Entry(Proveedores).Reload();

                Proveedores.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Proveedores.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Proveedores
                     join cp in db.Localidades on p.Id_CodPostal equals cp.Id into listCP
                     from codpos in listCP.DefaultIfEmpty()
                     join ti in db.TipoIva on p.Id_TipoIva equals ti.Id into listTI
                     from iva in listTI
                     where (p.Id == parametros.Id || parametros.Id == null)
                        && (p.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                        && (p.UserDel == null)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Nombre = p.Nombre,
                         Empresa = p.Empresa,
                         Estado = p.Estado,
                         Cuit = p.Cuit,
                         Domicilio = p.Domicilio,
                         Id_CodPostal = p.Id_CodPostal,
                         Id_TipoIva = p.Id_TipoIva,
                         CodPostal = codpos.CodPostal,
                         Localidad = codpos.Localidad,
                         TipoIva = iva.Nombre,
                         CodTango = p.CodTango,
                         Email = p.Email,
                         Id_ListaPrecio = p.Id_ListaPrecio,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod,
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Nombre { get; set; }
        }

        public class SearchResult : Proveedores
        {
            public int CodPostal { get; set; }
            public string Localidad { get; set; }
            public string TipoIva { get; set; }
        }

    }
}
