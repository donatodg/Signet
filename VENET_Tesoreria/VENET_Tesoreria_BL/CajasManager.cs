namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class CajasManager : IDisposable
    {
        private TesoreriaContext db;
        public Cajas Caja { get; set; }

        public CajasManager(Cajas o)
        {
            db = new TesoreriaContext();
            Caja = o;

            db.Cajas.Attach(Caja);

            if (Caja.Id > 0)
            {
                db.Entry(Caja).Reload();
                Id_Empresa = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Id_Empresa).FirstOrDefault());
            }
        }

        public int Id_Empresa { get; set; }
     
        public List<KeyNamePair> Sucursales { get { return db.Sucursales.Where(t => t.Id_Empresa == Id_Empresa && t.UserDel == null && Seguridad.IdEmpresasAsignadas.Contains(t.Id_Empresa)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Caja.Id == 0)
            {
                if (db.Cajas.Where(t => t.Id_Sucursal == Caja.Id_Sucursal && t.Id_Especie == Caja.Id_Especie && t.UserDel == null).Count() > 0)
                    throw new ValidationException("Ya existe una caja para la especie seleccionada.");

                db.Entry(Caja).State = EntityState.Added;
                Caja.FechaAdd = Sistema.ObtenerFechaHora();
                Caja.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                if (db.Cajas.Where(t => t.Id != Caja.Id && t.Id_Sucursal == Caja.Id_Sucursal && t.Id_Especie == Caja.Id_Especie && t.UserDel == null).Count() > 0)
                    throw new ValidationException("Ya existe una caja para la especie seleccionada.");

                db.Entry(Caja).State = EntityState.Modified;
                Caja.FechaMod = Sistema.ObtenerFechaHora();
                Caja.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Cajas o)
        {
            using (var db = new TesoreriaContext())
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
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from c in db.Cajas
                     join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                     from esp in listEsp
                     where (c.Id == parametros.Id || parametros.Id == null)
                     && (suc.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                     && (c.Id_Especie == parametros.Id_Especie || parametros.Id_Especie == null)
                     && (c.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                     && (c.UserDel == null)
                     select new SearchResult
                     {
                         Id = c.Id,
                         Id_Sucursal = c.Id_Sucursal,
                         Id_Especie = c.Id_Especie,
                         Descripcion = c.Descripcion,
                         FechaAdd = c.FechaAdd,
                         FechaMod = c.FechaMod,
                         UserAdd = c.UserAdd,
                         UserMod = c.UserMod,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         Especie = esp.Descripcion
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            public int? Id_Especie { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Cajas
        {
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public string Especie { get; set; }
        }
    }
}
