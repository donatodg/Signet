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

    public class AsientosManager : IDisposable
    {
        private GestionContext db;
        public Asientos Asiento { get; set; }

        public AsientosManager(Asientos o)
        {
            db = new GestionContext();
            Asiento = o;

            db.Asientos.Attach(Asiento);

            if (Asiento.Id > 0)
            {
                db.Entry(Asiento).Reload();

                if (Asiento.Detalle == null)
                    db.Entry(Asiento).Collection(p => p.Detalle).Load();

                if (Asiento.Detalle.Count > 0)
                    foreach (AsientosDetalle row in Asiento.Detalle)
                        row.Cuenta = db.CuentasContables.Where(t => t.Id == row.Id_CuentaContable).Select(t => t.Descripcion.Trim()).FirstOrDefault();
            }
            else
            {
                Asiento.Fecha = Sistema.ObtenerFecha();
                db.Entry(Asiento).Collection(p => p.Detalle).Load();

                Asiento.Numero = 0;
                Asiento.Id_Empresa = Sistema.Empresas.First().Key;
                Asiento.Id_Especie = Sistema.Especies.First().Key;
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                ContabilidadService.Bloquear(db, tx, Asiento.Id_Empresa);
                ContabilidadService.ValidarEdicionManual(db, Asiento.Id_Empresa);
                ContabilidadService.ValidarPeriodoAbierto(db, Asiento.Id_Empresa, Asiento.Fecha);
                if (Asiento.Id > 0)
                {
                    var previo = db.Asientos.AsNoTracking().Single(a => a.Id == Asiento.Id);
                    if (previo.Id_Empresa != Asiento.Id_Empresa) throw new ValidationException("No se puede cambiar la empresa del asiento.");
                    ContabilidadService.ValidarPeriodoAbierto(db, previo.Id_Empresa, previo.Fecha);
                }
                if (Asiento.Id > 0) ContabilidadService.ProtegerAsiento(db, Asiento.Id);
                var lineas = Asiento.Detalle?.Where(t => !t.Borrado).ToList();
                if (lineas == null || lineas.Count < 2 || lineas.Any(t => t.Debe < 0 || t.Haber < 0
                    || (t.Debe == 0) == (t.Haber == 0) || decimal.Round(t.Debe, 2) != t.Debe || decimal.Round(t.Haber, 2) != t.Haber)
                    || lineas.Sum(t => t.Debe) != lineas.Sum(t => t.Haber))
                    throw new ValidationException("El asiento debe balancear con al menos dos renglones, importes positivos de dos decimales y un solo lado por renglon.");
                var cuentas = lineas.Select(t => t.Id_CuentaContable).Distinct().ToList();
                if (db.CuentasContables.Count(c => cuentas.Contains(c.Id) && c.UserDel == null && c.Subcuenta != "000000") != cuentas.Count)
                    throw new ValidationException("Hay cuentas inexistentes, dadas de baja o no imputables.");
                var ejercicios = db.EjerciciosContables.Where(e => e.UserDel == null && e.Id_Empresa == Asiento.Id_Empresa
                    && e.VigenciaDesde <= Asiento.Fecha && e.VigenciaHasta >= Asiento.Fecha).ToList();
                if (ejercicios.Count != 1 || ejercicios[0].Cerrado)
                    throw new ValidationException("Debe existir un unico ejercicio abierto para la empresa y fecha.");
                if (Asiento.Id == 0)
                {
                    db.Entry(Asiento).State = EntityState.Added;
                    Asiento.FechaAdd = Sistema.ObtenerFechaHora();
                    Asiento.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    if (Asiento.Numero == 0)
                        Asiento.Numero = (db.Asientos.Where(t => t.Id_Empresa == Asiento.Id_Empresa).Select(t => (int?)t.Numero).Max() ?? 0) + 1;
                }
                else
                {
                    db.Entry(Asiento).State = EntityState.Modified;
                    Asiento.FechaMod = Sistema.ObtenerFechaHora();
                    Asiento.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }
                foreach (var linea in lineas.Where(l => l.Id == 0))
                {
                    linea.FechaAdd = Sistema.ObtenerFechaHora();
                    linea.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }
                foreach (var eliminada in Asiento.Detalle.Where(l => l.Borrado).ToList())
                {
                    if (eliminada.Id == 0) db.Entry(eliminada).State = EntityState.Detached;
                    else db.AsientosDetalle.Remove(eliminada);
                    Asiento.Detalle.Remove(eliminada);
                }
                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                if (db.Asientos.Any(a => a.Id_Empresa == Asiento.Id_Empresa && a.Numero == Asiento.Numero && a.Id != Asiento.Id))
                    throw new ValidationException("El numero de asiento ya existe para esta empresa.");
                db.SaveChanges();
                tx.Commit();
            }
        }

        //public static void Anular(Asientos o, string MotivoAnulacion)
        //{
        //    using (var db = new GestionContext())
        //    {
        //        db.Entry(o).State = EntityState.Modified;
        //        db.Entry(o).Reload();

        //        if (o.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulado.");
        //        //Evaluar si hay un Ejecicio contable abierto.

        //        if (o.Detalle == null)
        //            db.Entry(o).Collection(p => p.Detalle).Load();

        //        o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
        //        o.FechaAnulacion = Sistema.ObtenerFechaHora();
        //        o.FechaMod = Sistema.ObtenerFechaHora();
        //        o.MotivoAnulacion = MotivoAnulacion;


        //        db.SaveChanges();
        //    }
        //}

        public static void Eliminar(Asientos o)
        {
            using (var db = new GestionContext())
            using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();
                ContabilidadService.Bloquear(db, tx, o.Id_Empresa);
                ContabilidadService.ValidarEdicionManual(db, o.Id_Empresa);
                ContabilidadService.ValidarPeriodoAbierto(db, o.Id_Empresa, o.Fecha);
                ContabilidadService.ProtegerAsiento(db, o.Id);

                //Evaluar si hay un Ejecicio contable abierto.
                if (db.EjerciciosContables.Where(t => t.UserDel == null && t.Cerrado == false && t.Id_Empresa == o.Id_Empresa && t.VigenciaDesde <= o.Fecha && t.VigenciaHasta >= o.Fecha).Count() == 0)
                    throw new ValidationException("No hay ejercicio contable activo para la fecha indicada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
                tx.Commit();
            }
        }

        public static bool EjercicioCerrado(DateTime Fecha, int Id_Empresa)
        {
            int Cant;
            using (var db = new GestionContext())
                Cant = db.EjerciciosContables.Where(t => t.UserDel == null && t.Cerrado == true && t.Id_Empresa == Id_Empresa && t.VigenciaDesde <= Fecha && t.VigenciaHasta >= Fecha).Select(t => t.Id).FirstOrDefault();

            if (Cant > 0) return true; else return false;
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from a in db.Asientos
                     join emp in db.Empresas on a.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     join esp in db.Especies on a.Id_Especie equals esp.Id into listEsp
                     from es in listEsp
                     where (a.Id == parametros.Id || parametros.Id == null)
                        && (a.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        && (a.Fecha >= parametros.Fecha_Desde && a.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                        && (a.Numero == parametros.Numero || parametros.Numero == null)
                        && (a.FechaAnulacion != null || parametros.Anulado == false)
                        && (a.UserDel == null)
                     select new SearchResult()
                     {
                         Id = a.Id,
                         Fecha = a.Fecha,
                         FechaAdd = a.FechaAdd,
                         FechaMod = a.FechaMod,
                         Detalle = a.Detalle,
                         UserAdd = a.UserAdd,
                         UserMod = a.UserMod,
                         FechaAnulacion = a.FechaAnulacion,
                         MotivoAnulacion = a.MotivoAnulacion,
                         Numero = a.Numero,
                         Id_Empresa = a.Id_Empresa,
                         Descripcion = a.Descripcion,
                         Empresa = e.Nombre,
                         Especie = es.Descripcion,
                         Id_Especie = a.Id_Especie
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Fecha_Desde = Sistema.ObtenerFecha();
                Fecha_Hasta = Fecha_Desde;

                Id_Empresa = Sistema.Empresas.First().Key;
            }

            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            public DateTime Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public int? Numero { get; set; }
            public bool Anulado { get; set; }
        }

        public class SearchResult : Asientos
        {
            public string Empresa { get; set; }
            public string Especie { get; set; }
        }
    }
}
