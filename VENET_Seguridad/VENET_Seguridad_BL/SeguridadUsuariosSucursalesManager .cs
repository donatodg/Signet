namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class SeguridadUsuariosSucursalesManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<ComboSucursales> SucursalesSinAsignar { get; private set; }

        public SeguridadUsuariosSucursalesManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();
            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            SucursalesSinAsignar = (from s in db.Sucursales
                                    join e in db.Empresas on s.Id_Empresa equals e.Id into listEmp
                                    from emp in listEmp
                                    where (s.UserDel == null)
                                    && (db.SeguridadUsuariosEmpresas.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_Empresa).ToList()).Contains(s.Id_Empresa)
                                    && !(db.SeguridadUsuariosSucursales.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_Sucursal).ToList()).Contains(s.Id)
                                    select new ComboSucursales()
                                    {
                                        Id = s.Id,
                                        Empresa = emp.Nombre,
                                        Sucursal = s.Descripcion
                                    }).OrderBy(t => new { t.Empresa, t.Sucursal }).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosSucursales o)
        {
            using (var db = new SeguridadContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public List<SearchResult> Buscar()
        {
            using (var db = new SeguridadContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from g in db.SeguridadUsuariosSucursales
                     join s in db.Sucursales on g.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     join sucd in db.SeguridadUsuarioSucursalDefault on new { g.Id_Sucursal, g.Id_Usuario } equals new { sucd.Id_Sucursal, sucd.Id_Usuario } into listDef
                     from def in listDef.DefaultIfEmpty()
                     where (g.Id_Usuario == Usuario.Id)
                           && (g.UserDel == null)
                           && (suc.UserDel == null)
                           && (emp.UserDel == null)
                     select new SearchResult
                     {
                         Id = g.Id,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         Id_Sucursal = g.Id_Sucursal,
                         Id_Usuario = g.Id_Usuario,
                         UserAdd = g.UserAdd,
                         UserMod = g.UserMod,
                         FechaAdd = g.FechaAdd,
                         FechaMod = g.FechaMod,
                         Default = def.Id_Sucursal
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdSucursal)
        {
            if (IdSucursal == 0) throw new ValidationException("Debe ingresar una sucursal.");
            if (db.SeguridadUsuariosSucursales.Where(t => t.Id_Sucursal == IdSucursal && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("La sucursal ya está asignada");

            SeguridadUsuariosSucursales o = new SeguridadUsuariosSucursales()
            {
                Id_Sucursal = IdSucursal,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void SetDefault(int Id_Sucursal, int Id_Usuario)
        {
            using (var db = new SeguridadContext())
            {
                //Elimina los asociacion anterior
                var query = from d in db.SeguridadUsuarioSucursalDefault
                            where d.Id_Usuario == Id_Usuario
                            select d;

                foreach (SeguridadUsuarioSucursalDefault def in query)
                {
                    db.SeguridadUsuarioSucursalDefault.Attach(def);
                    db.Entry(def).State = EntityState.Deleted;
                }

                SeguridadUsuarioSucursalDefault o = new SeguridadUsuarioSucursalDefault()
                {
                    Id_Sucursal = Id_Sucursal,
                    Id_Usuario = Id_Usuario,
                };

                db.Entry(o).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public class SearchResult : SeguridadUsuariosSucursales
        {
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public int? Default { get; set; }
        }

        public class ComboSucursales
        {
            public int Id { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }
    }
}