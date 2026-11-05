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

    public class SucursalesManager : IDisposable
    {
        private GeneralContext db;
        public Sucursales Sucursal { get; set; }

        public ParametrosBusquedas Parametros { get; set; }
        public List<SearchResult> Resultado { get; set; }

        public SucursalesManager()
        {
            Parametros = new ParametrosBusquedas();
            //  Resultado = new List<SearchResult>();
        }

        public SucursalesManager(Sucursales o)
        {
            db = new GeneralContext();
            Sucursal = o;
            db.Sucursales.Attach(Sucursal);

            if (Sucursal.Id > 0) db.Entry(Sucursal).Reload();

            Parametros = new ParametrosBusquedas();
            Resultado = new List<SearchResult>();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Sucursal.Id == 0)
            {
                db.Entry(Sucursal).State = EntityState.Added;

                Sucursal.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Sucursal.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Sucursal).State = EntityState.Modified;
                Sucursal.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Sucursal.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Sucursales o)
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

        //public List<SearchResult> Buscar(ParametrosBusquedas parametros)
        //{
        //    using (var db = new GeneralContext())
        //    {
        //        List<SearchResult> r = new List<SearchResult>();

        //        r = (from t in db.Sucursales
        //             join e in db.Empresas on t.Id_Empresa equals e.Id into listEmp
        //             from emp in listEmp.DefaultIfEmpty()
        //             join cp in db.Localidades on t.CodPos equals cp.Id into listCP
        //             from codpos in listCP.DefaultIfEmpty()
        //             where (t.Id == parametros.Id || parametros.Id == null)
        //                   && (t.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
        //                   && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
        //                   && (t.UserDel == null)
        //                   && (Seguridad.IdEmpresasAsignadas.Contains(emp.Id))
        //             select new SearchResult
        //             {
        //                 Id = t.Id,
        //                 Id_Empresa = t.Id_Empresa,
        //                 Descripcion = t.Descripcion,
        //                 Sigla = t.Sigla,
        //                 Numero = t.Numero,
        //                 Fecha_Apertura = t.Fecha_Apertura,
        //                 Fecha_Cierre = t.Fecha_Cierre,
        //                 DomicilioCalle = t.DomicilioCalle,
        //                 DomicilioDpto = t.DomicilioDpto,
        //                 DomicilioNro = t.DomicilioNro,
        //                 DomicilioPiso = t.DomicilioPiso,
        //                 CodPos = codpos.CodPostal,
        //                 Localidad = codpos.Localidad,
        //                 FechaAdd = t.FechaAdd,
        //                 FechaMod = t.FechaMod,
        //                 UserAdd = t.UserAdd,
        //                 UserMod = t.UserMod,
        //                 Empresa = emp.Nombre
        //             }).ToList();
        //        return r;
        //    }
        //}

        public void Buscar(int? Id = null)
        {
            //if (!Seguridad.ObtenerPermiso(VENET_Comun.Enums.Modulos.General, "Sucursales", VENET_Comun.Enums.Accion.Buscar))
            //        throw new UnauthorizedAccessException();

            int? _Id;
            _Id = Parametros.Id;

            if (Id != null) Parametros.Id = null;

            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.Sucursales
                     join e in db.Empresas on t.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp.DefaultIfEmpty()
                     join cp in db.Localidades on t.CodPos equals cp.Id into listCP
                     from codpos in listCP.DefaultIfEmpty()
                     where (t.Id == Id || Id == null)
                           && (t.Id == Parametros.Id || Parametros.Id == null)
                           && (t.Id_Empresa == Parametros.Id_Empresa || Parametros.Id_Empresa == null)
                           && (t.Descripcion.Contains(Parametros.Descripcion) || Parametros.Descripcion == null)
                           && (t.UserDel == null)
                           && (Seguridad.IdEmpresasAsignadas.Contains(emp.Id))
                     select new SearchResult
                     {
                         Id = t.Id,
                         Id_Empresa = t.Id_Empresa,
                         Descripcion = t.Descripcion,
                         Sigla = t.Sigla,
                         Numero = t.Numero,
                         Fecha_Apertura = t.Fecha_Apertura,
                         Fecha_Cierre = t.Fecha_Cierre,
                         DomicilioCalle = t.DomicilioCalle,
                         DomicilioDpto = t.DomicilioDpto,
                         DomicilioNro = t.DomicilioNro,
                         DomicilioPiso = t.DomicilioPiso,
                         CodPos = codpos.CodPostal,
                         Localidad = codpos.Localidad,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod,
                         Empresa = emp.Nombre
                     }).ToList();


                Resultado = r;
            }

            Parametros.Id = _Id;
        }


        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Sucursales
        {
            public string Empresa { get; set; }
            public string Localidad { get; set; }
        }

    }
}
