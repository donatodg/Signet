namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class EntidadesImpuestosAlicuotasManager : IDisposable
    {
        private GestionContext db = new GestionContext();
        public EntidadesImpuestoAlicuotas EntidadAlicuota { get; set; }
        public List<Combo> EntidadAlicuotaSinAsignar { get; private set; }

        public EntidadesImpuestosAlicuotasManager(EntidadesImpuestoAlicuotas o)
        {
            EntidadAlicuota = o;

            EntidadAlicuotaSinAsignar = (from ia in db.ImpuestosAlicuotas
                                         join im in db.TipoImpuestos on ia.Id_Impuesto equals im.Id into listImp
                                         from i in listImp
                                         join pr in db.Provincias on ia.Id_Provincia equals pr.Id into listPr
                                         from p in listPr.DefaultIfEmpty()
                                         where ia.UserDel == null
                                            && i.UserDel == null
                                            && !(db.EntidadesImpuestosAlicuotas.Where(t => t.Id_TipoEntidad == EntidadAlicuota.Id_TipoEntidad && t.Id_Entidad == EntidadAlicuota.Id_Entidad && t.UserDel == null).Select(t => t.Id_ImpuestoAlicuota).ToList()).Contains(ia.Id)
                                         select new Combo()
                                         {
                                             Id = ia.Id,
                                             Descripcion = i.Id_TipoImpuesto.ToString() + "- " + i.Descripcion + "-" + ia.Alicuota,
                                             //Descripcion = i.Percepcion == true ? "Percep.- " + i.Descripcion + "-" + ia.Alicuota : "Reten.- " + i.Descripcion + "-" + ia.Alicuota,
                                             Alicuota = ia.Alicuota,
                                             BaseImponible = ia.BaseImponible,
                                             Impuesto = i.Descripcion,
                                             Provincia = p.Descripcion
                                         }).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<SearchResult> Buscar()
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from e in db.EntidadesImpuestosAlicuotas
                     join impa in db.ImpuestosAlicuotas on e.Id_ImpuestoAlicuota equals impa.Id into listIA
                     from ia in listIA
                     join imp in db.TipoImpuestos on ia.Id_Impuesto equals imp.Id into listImp
                     from i in listImp
                     join prov in db.Provincias on ia.Id_Provincia equals prov.Id into listProv
                     from p in listProv.DefaultIfEmpty()
                     where e.Id_TipoEntidad == EntidadAlicuota.Id_TipoEntidad
                        && e.Id_Entidad == EntidadAlicuota.Id_Entidad
                        && e.UserDel == null
                     select new SearchResult
                     {
                         Id = e.Id,
                         Id_ImpuestoAlicuota = e.Id_ImpuestoAlicuota,
                         Id_Entidad = e.Id_Entidad,
                         Id_TipoEntidad = e.Id_TipoEntidad,
                         Impuesto = i.Descripcion,
                         Alicuota = ia.Alicuota,
                         BaseImponible = ia.BaseImponible,
                         Provincia = p.Descripcion,
                         UserAdd = e.UserAdd,
                         UserMod = e.UserMod,
                         FechaAdd = e.FechaAdd,
                         FechaMod = e.FechaMod,
                         TipoImpuesto = i.Id_TipoImpuesto.ToString()
                         //TipoImpuesto = i.Retencion == true ? "Retención" : "Percepción"
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdImpuestoAlicuota)
        {
            if (IdImpuestoAlicuota == 0) throw new ValidationException("Debe ingresar una alícuota.");
            if (db.EntidadesImpuestosAlicuotas.Where(t => t.Id_ImpuestoAlicuota == IdImpuestoAlicuota && t.Id_TipoEntidad == EntidadAlicuota.Id_TipoEntidad && t.Id_Entidad == EntidadAlicuota.Id_Entidad && t.UserDel == null).Count() > 0)
                throw new ValidationException("La alícuota ya está asignada.");

            EntidadesImpuestoAlicuotas o = new EntidadesImpuestoAlicuotas()
            {
                Id_Entidad = EntidadAlicuota.Id_Entidad,
                Id_TipoEntidad = EntidadAlicuota.Id_TipoEntidad,
                Id_ImpuestoAlicuota = IdImpuestoAlicuota,
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

        public static void Eliminar(EntidadesImpuestoAlicuotas o)
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

        public class SearchResult : EntidadesImpuestoAlicuotas
        {
            public string Impuesto { get; set; }
            public decimal Alicuota { get; set; }
            public decimal BaseImponible { get; set; }
            public string Provincia { get; set; }
            public string TipoImpuesto { get; set; }
        }

        public class Combo
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public string Impuesto { get; set; }
            public decimal Alicuota { get; set; }
            public decimal BaseImponible { get; set; }
            public string Provincia { get; set; }
        }
    }
}
