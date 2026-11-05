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

    public class ProduccionVariantesTareasManager : IDisposable
    {
        private ProduccionContext db;
        //public Produccion_Variantes Variante { get; private set; }
        public Produccion_VariantesTareas VarianteTareas { get; set; }
        //int _Id_Variante;

        //public List<KeyNamePair> TareasSinAsignar { get; private set; }
        public List<KeyNamePair> Medidas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        join var in db.Produccion_Variantes on l.Id equals var.Id_Linea into listVar
                        from v in listVar
                        join linMed in db.Produccion_LineasMedidas on l.Id equals linMed.Id_Linea into listLM
                        from lm in listLM
                        join me in db.Produccion_Medidas on lm.Id_Medida equals me.Id into listMe
                        from m in listMe
                        where v.Id == VarianteTareas.Id_Variante
                        && l.UserDel == null
                        && lm.UserDel == null
                        && m.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = m.Id,
                            Name = m.Medida
                        }).OrderBy(t => t.Name).ToList();
                //db.Produccion_Medidas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Medida }).ToList();
            }
        }

        public List<KeyNamePair> ManoObras { get { return db.Produccion_ManoDeObra.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList(); } }

        public List<TareasList> Tareas { get { return db.Produccion_Tareas.Where(t => t.UserDel == null).Select(t => new TareasList() { Id = t.Id, Descripcion = t.Descripcion, Horas = t.Horas, Unidades = t.Unidades }).ToList(); } }

        public ProduccionVariantesTareasManager(Produccion_VariantesTareas o)
        //public ProduccionVariantesTareasManager(int Id_Variante)
        {
            db = new ProduccionContext();
            //_Id_Variante = Id_Variante;

            //VarianteTareas = new Produccion_VariantesTareas() { Id_Variante = Id_Variante, Horas = new DateTime(2001, 01, 01) };

            VarianteTareas = o;
            db.Produccion_VariantesTareas.Attach(VarianteTareas);

            if (VarianteTareas.Id > 0) db.Entry(VarianteTareas).Reload();
            else
            {
                VarianteTareas.Unidades = 0;
                VarianteTareas.Horas = new DateTime(2001, 01, 01);
                VarianteTareas.Id_ManoObra = ManoObras.First().Key;
                VarianteTareas.Cantidad = 1;
            }
            //if (VarianteTareas.Id_Variante > 0)
            //{
            //    //ver de como traerlo desde la bd
            //    VarianteTareas.Id = 1;
            //    db.Entry(VarianteTareas).Reload();
            //}

            //else
            //{
            //    //VarianteTareas.Incidencia = 1;
            //}

            //Variante = db.Produccion_Variantes.Where(t => t.Id == o.Id).FirstOrDefault();

            //TareasSinAsignar = (from m in db.Produccion_Tareas
            //                    where (m.UserDel == null)
            //                    //&& !(db.Produccion_VariantesTareas.Where(p => p.Id_Variante == _Id_Variante && p.UserDel == null).Select(p => p.Id_Tarea).ToList()).Contains(m.Id)
            //                    select new KeyNamePair()
            //                    {
            //                        Key = m.Id,
            //                        Name = m.Descripcion
            //                    }).OrderBy(t => t.Name).ToList();


            //Medidas = (from m in db.Produccion_Medidas
            //           where (m.UserDel == null)
            //           select new KeyNamePair()
            //           {
            //               Key = m.Id,
            //               Name = m.Medida
            //           }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(Produccion_VariantesTareas o)
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

        public List<SearchResult> Buscar()
        {
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from vt in db.Produccion_VariantesTareas
                     join pta in db.Produccion_Tareas on vt.Id_Tarea equals pta.Id into listTareas
                     from t in listTareas
                     join mdo in db.Produccion_ManoDeObra on vt.Id_ManoObra equals mdo.Id into listMO
                     from mo in listMO
                     join lin in db.Produccion_Variantes on vt.Id_Variante equals lin.Id into listLin
                     from l in listLin
                     join med in db.Produccion_Medidas on vt.Id_Medida equals med.Id into listMed
                     from m in listMed
                     where vt.Id_Variante == VarianteTareas.Id_Variante
                        && (vt.UserDel == null)
                        && (t.UserDel == null)
                        && (mo.UserDel == null)
                        && (l.UserDel == null)
                     select new SearchResult
                     {
                         Id = vt.Id,
                         Id_Variante = l.Id,
                         Id_Tarea = t.Id,
                         Variante = l.Codigo + "-" + l.Descripcion,
                         Tarea = t.Descripcion,
                         //CantidadUnidadesHora = vt.Cantidad,
                         Costo = (mo.PrecioHora / 60) * (vt.Horas.Hour * 60 + vt.Horas.Minute) * vt.Cantidad,
                         //Costo = (mo.PrecioHora / 100) * vt.Cantidad,
                         Cantidad = vt.Cantidad,
                         Unidades = vt.Unidades,
                         Horas = vt.Horas,
                         Id_Medida = vt.Id_Medida,
                         Medida = m.Medida,
                         Id_ManoObra = vt.Id_ManoObra,
                         ManoObra = mo.Descripcion,
                         PrecioHora = mo.PrecioHora,
                         UserAdd = vt.UserAdd,
                         UserMod = vt.UserMod,
                         FechaAdd = vt.FechaAdd,
                         FechaMod = vt.FechaMod,
                     }).ToList();

                return r;
            }
        }

        public void Save(int IdMedida)
        {
            //if (IdTarea == 0) throw new ValidationException("Debe ingresar una tarea.");
            //if (db.Produccion_VariantesTareas.Where(t => t.Id_Tarea == IdTarea && t.Id_Variante == _Id_Variante && t.UserDel == null).Count() > 0)
            //    throw new ValidationException("La tarea ya está asignada");

            ProduccionContext db1 = new ProduccionContext();
            Produccion_VariantesTareas o = new Produccion_VariantesTareas();

            //Ver si es un Insert o un Update
            int Id = (db1.Produccion_VariantesTareas.Where(t => t.UserDel == null && t.Id_Variante == VarianteTareas.Id_Variante && t.Id_Medida == IdMedida && t.Id_Tarea == VarianteTareas.Id_Tarea && t.Id_ManoObra == VarianteTareas.Id_ManoObra).Select(t => t.Id).FirstOrDefault());

            //si existe Add
            //else Update
            if (Id == 0)
            {
                db1.Entry(o).State = EntityState.Added;
                o.FechaAdd = Sistema.ObtenerFechaHora();
                o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                o.Id = Id;
                db1.Produccion_VariantesTareas.Attach(o);
                db1.Entry(o).Reload();
                db1.Entry(o).State = EntityState.Modified;


                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();
            }

            o.Id_Tarea = VarianteTareas.Id_Tarea;
            o.Id_Variante = VarianteTareas.Id_Variante;
            o.Cantidad = VarianteTareas.Cantidad;
            o.Unidades = VarianteTareas.Unidades;
            o.Horas = VarianteTareas.Horas;
            o.Id_ManoObra = VarianteTareas.Id_ManoObra;
            o.Id_Medida = IdMedida;

            var err = db1.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db1.SaveChanges();
        }

        public class SearchResult : Produccion_VariantesTareas
        {
            public string Variante { get; set; }
            public string Tarea { get; set; }
            //public decimal CantidadUnidadesHora { get; set; }
            public string ManoObra { get; set; }
            public string Medida { get; set; }
            public decimal PrecioHora { get; set; }
            public decimal Costo { get; set; }
        }

        public class TareasList
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public DateTime Horas { get; set; }
            public decimal Unidades { get; set; }
        }

    }
}
