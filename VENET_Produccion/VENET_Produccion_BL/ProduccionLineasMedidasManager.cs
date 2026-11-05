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

    public class ProduccionLineasMedidasManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion_Lineas Linea { get; private set; }
        public List<KeyNamePair> MedidasSinAsignar { get; private set; }

        public ProduccionLineasMedidasManager(Produccion_Lineas o)
        {
            db = new ProduccionContext();

            Linea = db.Produccion_Lineas.Where(t => t.Id == o.Id).FirstOrDefault();

            MedidasSinAsignar = (from m in db.Produccion_Medidas
                                 where (m.UserDel == null)
                                       && !(db.Produccion_LineasMedidas.Where(p => p.Id_Linea == o.Id && p.UserDel == null).Select(p => p.Id_Medida).ToList()).Contains(m.Id)
                                 select new KeyNamePair()
                                 {
                                     Key = m.Id,
                                     Name = m.Medida
                                 }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(Produccion_LineasMedidas o)
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

                r = (from lm in db.Produccion_LineasMedidas
                     join med in db.Produccion_Medidas on lm.Id_Medida equals med.Id into listMedidas
                     from m in listMedidas
                     join lin in db.Produccion_Lineas on lm.Id_Linea equals lin.Id into listLin
                     from l in listLin
                     where lm.Id_Linea == Linea.Id
                        && (lm.UserDel == null)
                        && (m.UserDel == null)
                        && (l.UserDel == null)
                     select new SearchResult
                     {
                         Id = lm.Id,
                         Ancho = m.Ancho,
                         Alto = m.Alto,
                         Id_Linea = l.Id,
                         Id_Medida = m.Id,
                         Linea = l.Codigo + "-" + l.Descripcion,
                         Medida = m.Medida,
                         UserAdd = lm.UserAdd,
                         UserMod = lm.UserMod,
                         FechaAdd = lm.FechaAdd,
                         FechaMod = lm.FechaMod,
                     }).ToList();


                return r;
            }
        }

        public void Save(int IdMedida)
        {
            if (IdMedida == 0) throw new ValidationException("Debe ingresar una medida.");
            if (db.Produccion_LineasMedidas.Where(t => t.Id_Medida == IdMedida && t.Id_Linea == Linea.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("La medida ya está asignada");

            Produccion_LineasMedidas o = new Produccion_LineasMedidas()
            {
                Id_Medida = IdMedida,
                Id_Linea = Linea.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public class SearchResult : Produccion_LineasMedidas
        {
            public string Linea { get; set; }
            public string Medida { get; set; }
            public decimal Ancho { get; set; }
            public decimal Alto { get; set; }
        }
    }
}
