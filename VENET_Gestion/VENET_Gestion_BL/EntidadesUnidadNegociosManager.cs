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

    public class EntidadesUnidadNegociosManager : IDisposable
    {
        private GestionContext db;
        private Enums.TipoEntidad _TipoEntidad;
        private int _Id_Entidad;
        public List<KeyNamePair> UnidadNegociosSinAsignar { get; private set; }

        public EntidadesUnidadNegociosManager(Enums.TipoEntidad TipoEntidad, int Id_Entidad)
        {
            db = new GestionContext();

            _Id_Entidad = Id_Entidad;
            _TipoEntidad = TipoEntidad;

            UnidadNegociosSinAsignar = (from e in db.UnidadNegocios
                                        where (e.UserDel == null)
                                          && !(db.EntidadesUnidadNegocios.Where(ee => ee.TipoEntidad == _TipoEntidad && ee.Id_Entidad == _Id_Entidad && ee.UserDel == null).Select(ee => ee.Id_UnidadNegocio).ToList()).Contains(e.Id)
                                          && Seguridad.IdUnidadesNegociosAsignadas.Contains(e.Id)
                                        select new KeyNamePair()
                                        {
                                            Key = e.Id,
                                            Name = e.Descripcion
                                        }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(EntidadesUnidadNegocios o)
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

                r = (from ee in db.EntidadesUnidadNegocios
                     join em in db.UnidadNegocios on ee.Id_UnidadNegocio equals em.Id into listEmp
                     from emp in listEmp
                     where (ee.TipoEntidad == _TipoEntidad)
                        && (ee.Id_Entidad == _Id_Entidad)
                        && (ee.UserDel == null)
                     select new SearchResult
                     {
                         Id = ee.Id,
                         Id_Entidad = ee.Id_Entidad,
                         TipoEntidad = ee.TipoEntidad,
                         UnidadNegocio = emp.Descripcion,
                         Id_UnidadNegocio = ee.Id_UnidadNegocio,
                         UserAdd = ee.UserAdd,
                         UserMod = ee.UserMod,
                         FechaAdd = ee.FechaAdd,
                         FechaMod = ee.FechaMod
                     }).ToList();

                return r;
            }
        }

        public void Save(int Id_UnidadNegocios)
        {
            if (Id_UnidadNegocios == 0) throw new ValidationException("Debe ingresar una unidad de negocio.");

            if (db.EntidadesUnidadNegocios.Where(t => t.TipoEntidad == _TipoEntidad && t.Id_Entidad == _Id_Entidad && t.Id_UnidadNegocio == Id_UnidadNegocios && t.UserDel == null).Count() > 0)
                throw new ValidationException("La unidad de negocio ya está asignada.");

            EntidadesUnidadNegocios o = new EntidadesUnidadNegocios()
            {
                TipoEntidad = _TipoEntidad,
                Id_Entidad = _Id_Entidad,
                Id_UnidadNegocio = Id_UnidadNegocios,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public class SearchResult : EntidadesUnidadNegocios
        {
            public string UnidadNegocio { get; set; }
        }

    }
}
