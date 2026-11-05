namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class EntidadesEmpresasManager : IDisposable
    {
        private GestionContext db;
        private Enums.TipoEntidad _TipoEntidad;
        private int _Id_Entidad;
        public List<KeyNamePair> EmpresasSinAsignar { get; private set; }

        public EntidadesEmpresasManager(Enums.TipoEntidad TipoEntidad, int Id_Entidad)
        {
            db = new GestionContext();

            _Id_Entidad = Id_Entidad;
            _TipoEntidad = TipoEntidad;

            EmpresasSinAsignar = (from e in db.Empresas
                                  where (e.UserDel == null)
                                  && !(db.EntidadesEmpresas.Where(ee => ee.TipoEntidad == _TipoEntidad && ee.Id_Entidad == _Id_Entidad && ee.UserDel == null).Select(ee => ee.Id_Empresa).ToList()).Contains(e.Id)
                                  && Seguridad.IdEmpresasAsignadas.Contains(e.Id)
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

        public static void Eliminar(EntidadesEmpresas o)
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

        public List<SearchResult> Buscar()
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from ee in db.EntidadesEmpresas
                     join em in db.Empresas on ee.Id_Empresa equals em.Id into listEmp
                     from emp in listEmp
                     where (ee.TipoEntidad == _TipoEntidad)
                        && (ee.Id_Entidad == _Id_Entidad)
                        && (ee.UserDel == null)
                     select new SearchResult
                     {
                         Id = ee.Id,
                         Id_Entidad = ee.Id_Entidad,
                         TipoEntidad = ee.TipoEntidad,
                         Empresa = emp.Nombre,
                         Id_Empresa = ee.Id_Empresa,
                         UserAdd = ee.UserAdd,
                         UserMod = ee.UserMod,
                         FechaAdd = ee.FechaAdd,
                         FechaMod = ee.FechaMod
                     }).ToList();

                return r;
            }
        }

        public void Save(int Id_Empresa)
        {
            if (Id_Empresa == 0) throw new ValidationException("Debe ingresar una empresa.");

            if (db.EntidadesEmpresas.Where(t => t.TipoEntidad == _TipoEntidad && t.Id_Entidad == _Id_Entidad && t.Id_Empresa == Id_Empresa && t.UserDel == null).Count() > 0)
                throw new ValidationException("La empresa ya está asignada.");

            EntidadesEmpresas o = new EntidadesEmpresas()
            {
                TipoEntidad = _TipoEntidad,
                Id_Entidad = _Id_Entidad,
                Id_Empresa = Id_Empresa,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public class SearchResult : EntidadesEmpresas
        {
            public string Empresa { get; set; }
        }

    }
}
