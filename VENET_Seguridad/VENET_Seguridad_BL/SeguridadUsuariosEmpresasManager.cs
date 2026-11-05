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

    public class SeguridadUsuariosEmpresasManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<KeyNamePair> EmpresasSinAsignar { get; private set; }

        public SeguridadUsuariosEmpresasManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();
            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            EmpresasSinAsignar = (from e in db.Empresas
                                  where (e.UserDel == null)
                                  && !(db.SeguridadUsuariosEmpresas.Where(pv => pv.Id_Usuario == o.Id && pv.UserDel == null).Select(pv => pv.Id_Empresa).ToList()).Contains(e.Id)
                                  select new KeyNamePair()
                                  {
                                      Key = e.Id,
                                      Name = e.Nombre
                                  }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosEmpresas o)
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

                r = (from g in db.SeguridadUsuariosEmpresas
                     join e in db.Empresas on g.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     where (g.Id_Usuario == Usuario.Id)
                           && (g.UserDel == null)
                           && (emp.UserDel == null)
                     select new SearchResult
                     {
                         Id = g.Id,
                         Empresa = emp.Nombre,
                         Id_Empresa = g.Id_Empresa,
                         Id_Usuario = g.Id_Usuario,
                         UserAdd = g.UserAdd,
                         UserMod = g.UserMod,
                         FechaAdd = g.FechaAdd,
                         FechaMod = g.FechaMod
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdEmpresa)
        {
            if (IdEmpresa == 0) throw new ValidationException("Debe ingresar una empresa.");
            if (db.SeguridadUsuariosEmpresas.Where(t => t.Id_Empresa == IdEmpresa && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("La empresa ya está asignada.");

            SeguridadUsuariosEmpresas o = new SeguridadUsuariosEmpresas()
            {
                Id_Empresa = IdEmpresa,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public class SearchResult : SeguridadUsuariosEmpresas
        {
            public string Empresa { get; set; }
        }
       
    }
}