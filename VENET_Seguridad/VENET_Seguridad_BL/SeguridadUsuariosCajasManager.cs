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

    public class SeguridadUsuariosCajasManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<Sistema.CajasList> CajasSinAsignar { get; private set; }

        public SeguridadUsuariosCajasManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();

            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            CajasSinAsignar = (from c in db.Cajas
                               join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                               from suc in listSuc
                               join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                               from emp in listEmp
                               join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                               from esp in listEsp
                               where (c.UserDel == null)
                                     && (db.SeguridadUsuariosSucursales.Where(p => p.Id_Usuario == o.Id && p.UserDel == null).Select(p => p.Id_Sucursal).ToList()).Contains(c.Id_Sucursal)
                                     && !(db.SeguridadUsuariosCajas.Where(p => p.Id_Usuario == o.Id && p.UserDel == null).Select(p => p.Id_Caja).ToList()).Contains(c.Id)
                               select new Sistema.CajasList()
                               {
                                   Id_Caja = c.Id,
                                   Caja = c.Descripcion,
                                   Empresa = emp.Nombre,
                                   Especie = esp.Descripcion,
                                   Sucursal = suc.Descripcion
                               }).OrderBy(t => t.Empresa).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosCajas o)
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

                r = (from u in db.SeguridadUsuariosCajas
                     join c in db.Cajas on u.Id_Caja equals c.Id into listCC
                     from cc in listCC
                     join e in db.Especies on cc.Id_Especie equals e.Id into listEsp
                     from esp in listEsp
                     join s in db.Sucursales on cc.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join em in db.Empresas on suc.Id_Empresa equals em.Id into listEmp
                     from emp in listEmp
                     join sucd in db.SeguridadUsuarioCajaDefault on new { u.Id_Caja, u.Id_Usuario } equals new { sucd.Id_Caja, sucd.Id_Usuario } into listDef
                     from def in listDef.DefaultIfEmpty()
                     where (u.Id_Usuario == Usuario.Id)
                           && (cc.UserDel == null)
                           && (u.UserDel == null)
                           && (esp.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         Caja = cc.Descripcion,
                         Especie = esp.Descripcion,
                         Id_Caja = u.Id_Caja,
                         Id_Usuario = u.Id_Usuario,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod,
                         Default = def.Id_Caja
                     }).ToList();


                return r;
            }
        }

        public void Save(int IdCaja)
        {
            if (IdCaja == 0) throw new ValidationException("Debe ingresar una caja.");
            if (db.SeguridadUsuariosCajas.Where(t => t.Id_Caja == IdCaja && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("La caja ya está asignado");

            SeguridadUsuariosCajas o = new SeguridadUsuariosCajas()
            {
                Id_Caja = IdCaja,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void SetDefault(int Id_Caja, int Id_Usuario)
        {
            using (var db = new SeguridadContext())
            {
                //Elimina los asociacion anterior
                var query = from d in db.SeguridadUsuarioCajaDefault
                            where d.Id_Usuario == Id_Usuario
                            select d;

                foreach (SeguridadUsuarioCajaDefault def in query)
                {
                    db.SeguridadUsuarioCajaDefault.Attach(def);
                    db.Entry(def).State = EntityState.Deleted;
                }

                SeguridadUsuarioCajaDefault o = new SeguridadUsuarioCajaDefault()
                {
                    Id_Caja = Id_Caja,
                    Id_Usuario = Id_Usuario,
                };

                db.Entry(o).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public class SearchResult : SeguridadUsuariosCajas
        {
            public string Caja { get; set; }
            public string Especie { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public int? Default { get; set; }
        }
    }
}
