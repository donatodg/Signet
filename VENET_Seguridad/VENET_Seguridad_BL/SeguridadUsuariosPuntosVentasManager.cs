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

    public class SeguridadUsuariosPuntosVentasManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<Combo> PuntosVentasSinAsignar { get; private set; }

        public SeguridadUsuariosPuntosVentasManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();

            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            PuntosVentasSinAsignar = (from p in db.PuntosVentas
                                      join s in db.Sucursales on p.Id_Sucursal equals s.Id into listSuc
                                      from suc in listSuc
                                      join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                                      from emp in listEmp
                                      where (p.UserDel == null)
                                      && (suc.UserDel == null)
                                      && (emp.UserDel == null)
                                      && (db.SeguridadUsuariosEmpresas.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_Empresa).ToList()).Contains(emp.Id)
                                      && (db.SeguridadUsuariosSucursales.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_Sucursal).ToList()).Contains(suc.Id)
                                      && !(db.SeguridadUsuariosPuntosVentas.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_PuntoVenta).ToList()).Contains(p.Id)
                                      select new Combo()
                                      {
                                          Id = p.Id,
                                          PuntoVenta = p.PuntoVenta,
                                          Empresa = emp.Nombre,
                                          Sucursal = suc.Descripcion
                                      }).OrderBy(t => new { t.Empresa, t.Sucursal, t.PuntoVenta }).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosPuntosVentas o)
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

                r = (from u in db.SeguridadUsuariosPuntosVentas
                     join p in db.PuntosVentas on u.Id_PuntoVenta equals p.Id into listPV
                     from pv in listPV
                     join s in db.Sucursales on pv.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     where (u.Id_Usuario == Usuario.Id)
                           && (emp.UserDel == null)
                           && (suc.UserDel == null)
                           && (u.UserDel == null)
                           && (pv.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         Id_PuntoVenta = u.Id_PuntoVenta,
                         Id_Usuario = u.Id_Usuario,
                         PuntoVenta = pv.PuntoVenta,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod
                     }).ToList();
                return r;
            }
        }

        public void Save(int IdPuntoVenta)
        {
            if (IdPuntoVenta == 0) throw new ValidationException("Debe ingresar un punto de venta.");
            if (db.SeguridadUsuariosPuntosVentas.Where(t => t.Id_PuntoVenta == IdPuntoVenta && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("El punto de venta ya está asignado");

            SeguridadUsuariosPuntosVentas o = new SeguridadUsuariosPuntosVentas()
            {
                Id_PuntoVenta = IdPuntoVenta,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public class SearchResult : SeguridadUsuariosPuntosVentas
        {
            public string PuntoVenta { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }

        public class Combo
        {
            public int Id { get; set; }
            public string Descripcion { get { return PuntoVenta + "-" + Empresa + "-" + Sucursal; } }
            public string PuntoVenta { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }
    }
}
