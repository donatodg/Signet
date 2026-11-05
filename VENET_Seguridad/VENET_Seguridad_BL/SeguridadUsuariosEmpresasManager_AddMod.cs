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

    public class SeguridadUsuariosEmpresasManager_AddMod : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuariosEmpresas EmpresasAsignadas { get; set; }

        public List<KeyNamePair> Empresas { get { return db.Empresas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> Suscursales { get { return db.Sucursales.Where(t => t.UserDel == null && t.Id_Empresa == EmpresasAsignadas.Id_Empresa).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> PuntoVenta { get { return db.PuntosVentas.Where(t => t.UserDel == null && t.Id_Sucursal == EmpresasAsignadas.Id_Sucursal).Select(t => new KeyNamePair() { Key = t.Id, Name = t.PuntoVenta.ToString() }).OrderBy(t => t.Name).ToList(); } }

        public SeguridadUsuariosEmpresasManager_AddMod(SeguridadUsuariosEmpresas o)
        {
            db = new SeguridadContext();

            EmpresasAsignadas = o;

            db.SeguridadUsuariosEmpresas.Attach(EmpresasAsignadas);

            if (EmpresasAsignadas.Id > 0)
                db.Entry(EmpresasAsignadas).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (db.SeguridadUsuariosEmpresas.Where(t => t.Id_Empresa == EmpresasAsignadas.Id_Empresa && t.Id_PuntoVenta == EmpresasAsignadas.Id_PuntoVenta && t.Id_Sucursal == EmpresasAsignadas.Id_Sucursal && t.UserDel == null && t.Id != EmpresasAsignadas.Id).Count() > 0)
                throw new ValidationException("La asignación ya existe para el usuario.");

            if (EmpresasAsignadas.Id == 0)
            {
                db.Entry(EmpresasAsignadas).State = EntityState.Added;

                EmpresasAsignadas.FechaAdd = DateTime.Now;
                EmpresasAsignadas.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(EmpresasAsignadas).State = EntityState.Modified;
                EmpresasAsignadas.FechaMod = DateTime.Now;
                EmpresasAsignadas.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(SeguridadUsuariosEmpresas o)
        {
            using (var db = new SeguridadContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = DateTime.Now;

                db.SaveChanges();
            }
        }
    }
}