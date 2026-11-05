namespace VENET_Personal_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class PersonalNovedadesManager : IDisposable
    {
        private PersonalContext db;
        public PersonalNovedades Novedad { get; set; }

        public PersonalNovedadesManager(PersonalNovedades o)
        {
            db = new PersonalContext();
            Novedad = o;

            db.PersonalNovedades.Attach(Novedad);

            if (Novedad.Id > 0) db.Entry(Novedad).Reload();
            else Novedad.Fecha = Sistema.ObtenerFechaHora();
        }

        public List<KeyNamePair> TipoNovedad { get { return db.TipoNovedades.Where(t => t.UserDel == null && t.ALaOrden == false).Select(t => new KeyNamePair() { Key = t.Id, Name = t.DescripcionLarga }).OrderBy(t => t.Name).ToList(); } }

        public List<PersonalLista> Personal { get { return db.Personal.Where(t => t.UserDel == null && Seguridad.IdUnidadesNegociosAsignadas.Contains(t.LaboralId_UnidadNegocio)).Select(t => new PersonalLista() { Id = t.Id, Legajo = t.LaboralLegajo, Nombre = t.Apellido.Trim() + ", " + t.Nombre.Trim() }).OrderBy(t => t.Legajo).ToList(); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save(DateTime FechaHasta)
        {
            if (FechaHasta < Novedad.Fecha) throw new ValidationException("La fecha hasta es inferior a fecha desde.");

            if (db.PersonalNovedades.Where(t => t.Id_Personal == Novedad.Id_Personal && t.Fecha >= Novedad.Fecha && t.Fecha <= FechaHasta && t.UserDel == null && t.Id != Novedad.Id).Count() > 0)
                throw new ValidationException("Existe una novedad para el personal seleccionado.");

            if (Novedad.Id == 0)
            {
                db.Entry(Novedad).State = EntityState.Added;
                Novedad.FechaAdd = Sistema.ObtenerFechaHora();
                Novedad.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Novedad).State = EntityState.Modified;
                Novedad.FechaMod = Sistema.ObtenerFechaHora();
                Novedad.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            //Novedad.Fecha 
            DateTime StartDate = Novedad.Fecha.AddDays(1);
            DateTime EndDate = FechaHasta.AddDays(1);

            while (StartDate.AddDays(1) <= EndDate)
            {
                PersonalNovedades o = new PersonalNovedades()
                {
                    Fecha = StartDate,
                    Id_Personal = Novedad.Id_Personal,
                    Id_TipoNovedad = Novedad.Id_TipoNovedad,
                    Observaciones = Novedad.Observaciones,
                    FechaAdd = Novedad.FechaAdd,
                    UserAdd = Novedad.UserAdd
                };

                db.PersonalNovedades.Attach(o);
                db.Entry(o).State = EntityState.Added;

                StartDate = StartDate.AddDays(1);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(PersonalNovedades o)
        {
            using (var db = new PersonalContext())
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
            using (var db = new PersonalContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from e in db.PersonalNovedades
                     join p in db.Personal on e.Id_Personal equals p.Id into listPer
                     from per in listPer.DefaultIfEmpty()
                     join n in db.TipoNovedades on e.Id_TipoNovedad equals n.Id into listNov
                     from nov in listNov.DefaultIfEmpty()
                     where (e.Id == parametros.Id || parametros.Id == null)
                        && (e.Fecha >= parametros.FechaDesde && e.Fecha <= parametros.FechaHasta || parametros.FechaHasta == null || parametros.Id > 0)
                        && (e.Observaciones.Contains(parametros.Observaciones) || parametros.Observaciones == null)
                        && (e.Id_Personal == parametros.Id_Personal || parametros.Id_Personal == null)
                        && (e.Id_TipoNovedad == parametros.Id_TipoNovedad || parametros.Id_TipoNovedad == null)
                        && (e.UserDel == null)
                        && (Seguridad.IdUnidadesNegociosAsignadas.Contains(per.LaboralId_UnidadNegocio))
                     select new SearchResult()
                     {
                         Id = e.Id,
                         Fecha = e.Fecha,
                         Id_Personal = e.Id_Personal,
                         Id_TipoNovedad = e.Id_TipoNovedad,
                         Legajo = per.LaboralLegajo.ToString(),
                         Novedad = nov.DescripcionLarga,
                         Personal = per.Apellido + ", " + per.Nombre,
                         Observaciones = e.Observaciones,
                         FechaAdd = e.FechaAdd,
                         FechaMod = e.FechaMod,
                         UserAdd = e.UserAdd,
                         UserMod = e.UserMod
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, Sistema.ObtenerFechaHora().Day);
                FechaHasta = FechaDesde.Value.AddDays(30);
            }

            PersonalContext db = new PersonalContext();

            public int? Id { get; set; }
            public DateTime? FechaDesde { get; set; }
            public DateTime? FechaHasta { get; set; }
            public int? Id_Personal { get; set; }
            public List<PersonalLista> Personal { get { return db.Personal.Where(t => t.UserDel == null && Seguridad.IdUnidadesNegociosAsignadas.Contains(t.LaboralId_UnidadNegocio)).Select(t => new PersonalLista() { Id = t.Id, Legajo = t.LaboralLegajo, Nombre = t.Apellido.Trim() + ", " + t.Nombre.Trim() }).OrderBy(t => t.Legajo).ToList(); } }
            public int? Id_TipoNovedad { get; set; }
            public string Observaciones { get; set; }
            public List<KeyNamePair> TipoNovedad { get { return db.TipoNovedades.Where(t => t.UserDel == null && t.ALaOrden == false).Select(t => new KeyNamePair() { Key = t.Id, Name = t.DescripcionLarga }).OrderBy(t => t.Name).ToList(); } }
        }

        public class SearchResult : PersonalNovedades
        {
            public string Legajo { get; set; }
            public string Personal { get; set; }
            public string Novedad { get; set; }
        }

        public class PersonalLista
        {
            public int Id { get; set; }
            public int? Legajo { get; set; }
            public string Nombre { get; set; }
            public string LegajoNombre { get { return Legajo + " - " + Nombre; } }
        }

    }
}
