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

    public class PuntosVentaManager : IDisposable
    {
        private GeneralContext db;
        public PuntosVentas PuntoVenta { get; set; }

        public PuntosVentaManager(PuntosVentas o)
        {
            db = new GeneralContext();
            PuntoVenta = o;

            db.PuntosVentas.Attach(PuntoVenta);

            if (PuntoVenta.Id > 0)
            {
                db.Entry(PuntoVenta).Reload();
            }
        }
        public List<ComboSucursales> Sucursales
        {
            get
            {
                return (from s in db.Sucursales
                        join e in db.Empresas on s.Id_Empresa equals e.Id into listEmp
                        from emp in listEmp
                        where s.UserDel == null
                           && emp.UserDel == null
                           && Seguridad.IdEmpresasAsignadas.Contains(emp.Id)
                           && Seguridad.IdSucursalesAsignadas.Contains(s.Id)
                        select new ComboSucursales()
                        {
                            Id = s.Id,
                            Sucursal = s.Descripcion,
                            Empresa = emp.Nombre
                        }).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            int Id_Empresa = db.Sucursales.Where(t => t.Id == PuntoVenta.Id_Sucursal && t.UserDel == null).Select(t => t.Id_Empresa).FirstOrDefault();
            List<int> ListId_Sucursales = db.Sucursales.Where(t => t.Id_Empresa == Id_Empresa && t.UserDel == null).Select(t => t.Id).ToList();

            if (PuntoVenta.Id == 0)
            {
                if (db.PuntosVentas.Where(t => ListId_Sucursales.Contains(t.Id_Sucursal) && t.PuntoVenta == PuntoVenta.PuntoVenta && t.UserDel == null).Count() > 0)
                    throw new ValidationException("Ya existe dicho punto de venta en la empresa seleccionada.");

                db.Entry(PuntoVenta).State = EntityState.Added;

                PuntoVenta.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                PuntoVenta.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                if (db.PuntosVentas.Where(t => ListId_Sucursales.Contains(t.Id_Sucursal) && t.PuntoVenta == PuntoVenta.PuntoVenta && t.UserDel == null && t.Id != PuntoVenta.Id).Count() > 0)
                    throw new ValidationException("Ya existe dicho punto de venta en la empresa seleccionada.");

                db.Entry(PuntoVenta).State = EntityState.Modified;
                PuntoVenta.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                PuntoVenta.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(PuntosVentas o)
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

                r = (from p in db.PuntosVentas
                     join s in db.Sucursales on p.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     where (p.Id == parametros.Id || parametros.Id == null)
                         && (p.PuntoVenta == parametros.PuntoVenta || parametros.PuntoVenta == null)
                         && (suc.Id == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                         && (emp.Id == parametros.Id_Empresa || parametros.Id_Empresa == null)
                         && (p.UserDel == null)
                         && (Seguridad.IdEmpresasAsignadas.Contains(emp.Id))
                         && (Seguridad.IdSucursalesAsignadas.Contains(suc.Id))
                         && (Seguridad.IdPuntosVentasAsignados.Contains(p.Id))
                     select new SearchResult
                     {
                         Id = p.Id,
                         PuntoVenta = p.PuntoVenta,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id_Empresa { get; set; }
            public int? Id_Sucursal { get; set; }
            public int? Id { get; set; }
            public string PuntoVenta { get; set; }
        }

        public class SearchResult : PuntosVentas
        {
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }

        public class ComboSucursales
        {
            public int Id { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }
    }
}
