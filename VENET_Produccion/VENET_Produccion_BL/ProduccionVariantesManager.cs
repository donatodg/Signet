namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionVariantesManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_Variantes Variante { get; set; }

        public ProduccionVariantesManager(Produccion_Variantes o)
        {
            db = new ProduccionContext();
            Variante = o;

            db.Produccion_Variantes.Attach(Variante);

            if (Variante.Id > 0) db.Entry(Variante).Reload();
            else Variante.DescripcionCorta = "-";
        }

        public static List<KeyName2Pair> Lineas
        {
            get
            {
                using (var db = new ProduccionContext())
                {
                    return (from l in db.Produccion_Lineas
                            join e in db.Empresas on l.Id_Empresa equals e.Id into listEmp
                            from emp in listEmp
                            where l.UserDel == null &&
                                  Seguridad.IdEmpresasAsignadas.Contains(l.Id_Empresa)
                            select new KeyName2Pair()
                            {
                                Key = l.Id,
                                Name = l.Codigo + "-" + l.Descripcion,
                                Name2 = emp.Nombre
                            }).OrderBy(t => new { t.Name2, t.Name }).ToList();
                }
            }
        }

        public List<KeyName2Pair> Variantes
        {
            get
            {
                return (from v in db.Produccion_Variantes
                        join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLin
                        from l in listLin
                        where v.UserDel == null
                           && v.UserDel == null
                           && v.Id != Variante.Id
                        select new KeyName2Pair()
                        {
                            Key = v.Id,
                            Name = v.Codigo + "-" + v.Descripcion,
                            Name2 = l.Descripcion
                        }).OrderBy(t => t.Name2).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Variante.Id == 0)
            {
                db.Entry(Variante).State = EntityState.Added;
                Variante.FechaAdd = Sistema.ObtenerFechaHora();
                Variante.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Variante).State = EntityState.Modified;
                Variante.FechaMod = Sistema.ObtenerFechaHora();
                Variante.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public void Save(int IdVariante)
        {
            if (IdVariante == 0) throw new ValidationException("Debe ingresar una variante.");

            List<Produccion_VariantesTareas> ListVT = db.Produccion_VariantesTareas
                                                        .Where(t => t.UserDel == null
                                                                && t.Id_Variante == Variante.Id
                                                                && !(db.Produccion_VariantesTareas.Where(t2 => t2.UserDel == null && t2.Id_Variante == IdVariante).Select(t2 => t2.Id_Tarea)).Contains(t.Id_Tarea)
                                                                ).ToList();

            foreach (Produccion_VariantesTareas o in ListVT)
            {
                Produccion_VariantesTareas a = new Produccion_VariantesTareas()
                {
                    Id_Tarea = o.Id_Tarea,
                    Id_Variante = IdVariante,
                    UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                    FechaAdd = Sistema.ObtenerFechaHora()
                };

                db.Produccion_VariantesTareas.Add(a);
            }

            db.SaveChanges();
        }

        public static void Eliminar(Produccion_Variantes o)
        {
            using (var db = new ProduccionContext())
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
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from v in db.Produccion_Variantes
                     join l in db.Produccion_Lineas on v.Id_Linea equals l.Id into listLineas
                     from lin in listLineas
                     join emp in db.Empresas on lin.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     where (v.Id == parametros.Id || parametros.Id == null)
                      && (v.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                      && (v.Id_Linea == parametros.Id_Linea || parametros.Id_Linea == null)
                      && (v.UserDel == null)
                      && (lin.UserDel == null)
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Descripcion = v.Descripcion,
                         DescripcionCorta = v.DescripcionCorta,
                         Codigo = v.Codigo,
                         Id_Linea = v.Id_Linea,
                         Id_Empresa = lin.Id_Empresa,
                         Linea = lin.Codigo + "-" +  lin.Descripcion,
                         Empresa = e.Nombre,
                         Utilidad = v.Utilidad,
                         FechaAdd = v.FechaAdd,
                         FechaMod = v.FechaMod,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();
                return r;

            }
        }

        public static List<SearchResultCompleto> BuscarCompleto()
        {
            using (var db = new ProduccionContext())
            {
                List<SearchResultCompleto> r = new List<SearchResultCompleto>();

                //r = (from vt in db.Produccion_VariantesTareas
                //     join pta in db.Produccion_Tareas on vt.Id_Tarea equals pta.Id into listTareas
                //     from t in listTareas
                //     join prod in db.Produccion on vt.Id equals prod.Id_Variante
                //     join mdo in db.Produccion_ManoDeObra on t.Id_ManoObra equals mdo.Id into listMO
                //     from mo in listMO
                //     join var in db.Produccion_Variantes on vt.Id_Variante equals var.Id into listVar
                //     from v in listVar
                //     join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLin
                //     from l in listLin
                //     where (vt.UserDel == null)
                //        && (t.UserDel == null)
                //        && (mo.UserDel == null)
                //        && (v.UserDel == null)
                //        && (l.UserDel == null)
                //     select new SearchResultCompleto
                //     {
                //         Id = vt.Id,
                //         Id_Variante = l.Id,
                //         Id_Tarea = t.Id,
                //         Linea = l.Descripcion,
                //         Variante = v.Descripcion,
                //         Tarea = t.Descripcion,
                //         CantidadUnidadesHora = t.CantidadUnidadesHora,
                //         Costo = (mo.PrecioHora / 100) * t.CantidadUnidadesHora,
                //         ManoObra = mo.Descripcion,
                //         PrecioHora = mo.PrecioHora,
                //         UserAdd = vt.UserAdd,
                //         UserMod = vt.UserMod,
                //         FechaAdd = vt.FechaAdd,
                //         FechaMod = vt.FechaMod,
                //     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
            public int? Id_Linea { get; set; }
        }

        public class SearchResult : Produccion_Variantes
        {
            public string Linea { get; set; }
            public string Empresa { get; set; }
            public int Id_Empresa { get; set; }
        }

        public class SearchResultCompleto : Produccion_VariantesTareas
        {
            public string Linea { get; set; }
            public string Variante { get; set; }
            public string Tarea { get; set; }
            //public decimal Cantidad  { get; set; }
            public string ManoObra { get; set; }
            public decimal PrecioHora { get; set; }
            public decimal Costo { get; set; }
        }
    }
}
