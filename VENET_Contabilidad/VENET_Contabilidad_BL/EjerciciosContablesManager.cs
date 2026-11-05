namespace VENET_Contabilidad_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class EjerciciosContablesManager : IDisposable
    {
        private GestionContext db;
        public EjerciciosContables Ejercicio { get; set; }

        public EjerciciosContablesManager(EjerciciosContables o)
        {
            db = new GestionContext();
            Ejercicio = o;

            db.EjerciciosContables.Attach(Ejercicio);

            if (Ejercicio.Id > 0)
                db.Entry(Ejercicio).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                ContabilidadService.Bloquear(db, tx, Ejercicio.Id_Empresa);
                if (Ejercicio.Id > 0)
                {
                    var anterior = db.EjerciciosContables.AsNoTracking().Single(e => e.Id == Ejercicio.Id);
                    if (anterior.Id_Empresa != Ejercicio.Id_Empresa)
                        throw new ValidationException("No se puede cambiar la empresa de un ejercicio existente.");
                    var cierre = db.Database.SqlQuery<int>(@"IF OBJECT_ID('dbo.ContabilidadDocumentos','U') IS NULL SELECT 0
                    ELSE SELECT COUNT(*) FROM dbo.ContabilidadDocumentos d INNER JOIN dbo.ContabilidadLotes l
                    ON l.Documento=d.Id AND l.Empresa=d.Empresa AND l.Operatoria=d.Operatoria
                    WHERE d.EjercicioOrigen=@p0 AND d.Operatoria=12 AND l.ReversionDe IS NULL", Ejercicio.Id).Single();
                    if (cierre > 0 && (!Ejercicio.Cerrado || anterior.VigenciaDesde != Ejercicio.VigenciaDesde || anterior.VigenciaHasta != Ejercicio.VigenciaHasta))
                        throw new ValidationException("El ejercicio tiene un cierre registrado. No se puede reabrir ni cambiar su periodo desde el maestro.");
                    if ((anterior.VigenciaDesde != Ejercicio.VigenciaDesde || anterior.VigenciaHasta != Ejercicio.VigenciaHasta)
                        && db.Asientos.Any(a => a.Id_Empresa == anterior.Id_Empresa && a.UserDel == null
                            && a.Fecha >= anterior.VigenciaDesde && a.Fecha <= anterior.VigenciaHasta))
                        throw new ValidationException("No se puede cambiar el periodo de un ejercicio con asientos.");
                }
                if (Ejercicio.VigenciaDesde.Date > Ejercicio.VigenciaHasta.Date)
                    throw new ValidationException("La fecha desde debe ser anterior a la fecha hasta.");
                if (db.EjerciciosContables.Any(t => t.Id_Empresa == Ejercicio.Id_Empresa
                    && Ejercicio.VigenciaDesde <= t.VigenciaHasta && Ejercicio.VigenciaHasta >= t.VigenciaDesde
                    && t.Id != Ejercicio.Id && t.UserDel == null))
                    throw new ValidationException("Las fechas indicadas se superponen con otro ejercicio.");

                if (Ejercicio.Id == 0)
                {
                    db.Entry(Ejercicio).State = EntityState.Added;
                    Ejercicio.FechaAdd = Sistema.ObtenerFechaHora();
                    Ejercicio.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }
                else
                {
                    db.Entry(Ejercicio).State = EntityState.Modified;
                    Ejercicio.FechaMod = Sistema.ObtenerFechaHora();
                    Ejercicio.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
                tx.Commit();
            }
        }

        public static void Eliminar(EjerciciosContables o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();
                if (db.Asientos.Any(a => a.Id_Empresa == o.Id_Empresa && a.Fecha >= o.VigenciaDesde && a.Fecha <= o.VigenciaHasta && a.UserDel == null))
                    throw new ValidationException("El ejercicio tiene asientos y no puede eliminarse.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from ec in db.EjerciciosContables
                     join emp in db.Empresas on ec.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     where (ec.Id == parametros.Id || parametros.Id == null)
                        && (ec.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        //    && (ec.Cerrado == parametros.Cerrado)
                        && (ec.UserDel == null)
                     select new SearchResult()
                     {
                         Id = ec.Id,
                         FechaAdd = ec.FechaAdd,
                         FechaMod = ec.FechaMod,
                         UserAdd = ec.UserAdd,
                         UserMod = ec.UserMod,
                         Id_Empresa = ec.Id_Empresa,
                         Descripcion = ec.Descripcion,
                         Cerrado = ec.Cerrado,
                         VigenciaDesde = ec.VigenciaDesde,
                         VigenciaHasta = ec.VigenciaHasta,
                         Empresa = e.Nombre,
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            //public ParametrosBusquedas()
            //{
            //    //Id_Empresa = Sistema.Empresas.First().Key;
            //    Cerrado = false;
            //}

            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            //public bool Cerrado { get; set; }
        }

        public class SearchResult : EjerciciosContables
        {
            public string Empresa { get; set; }
        }

    }
}
