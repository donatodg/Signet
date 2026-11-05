namespace VENET_Contabilidad_BL
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

    public class TipoAsientosManager : IDisposable
    {
        private GestionContext db;
        public TipoAsientos Tipo { get; set; }

        public TipoAsientosManager(TipoAsientos o)
        {
            db = new GestionContext();
            Tipo = o;

            db.TipoAsientos.Attach(Tipo);

            if (Tipo.Id > 0)
            {
                db.Entry(Tipo).Reload();

                if (Tipo.Detalle == null)
                    db.Entry(Tipo).Collection(p => p.Detalle).Load();
            }
            else
            {
                db.Entry(Tipo).Collection(p => p.Detalle).Load();

                //try
                //{
                //    //if (Sistema.CentrosCostos.Count() > 0)
                //    Comprobante.Id_CentroCosto = Sistema.CentrosCostos.First().Key;
                //    //if (Vendedores.Count() > 0)
                //    Comprobante.Id_Vendedor = Vendedores.First().Key;
                //    //if (Sistema.FormasPagos.Count() > 0)
                //    Comprobante.Id_FormaPago = Sistema.FormasPagos.First().Key;
                //    Comprobante.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                //    Comprobante.Id_Deposito = Sistema.Depositos.First().Key;
                //}
                //catch { }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            //if (Comprobante.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");
            //if (Comprobante.Fecha > Comprobante.FechaEntrega) throw new ValidationException("La fecha es posterior a la fecha de entrega.");
            //if (Comprobante.Fecha > Comprobante.FechaVto) throw new ValidationException("La fecha es posterior a la fecha de vencimiento.");

            if (Tipo.Id == 0)
            {
                db.Entry(Tipo).State = EntityState.Added;
                Tipo.FechaAdd = Sistema.ObtenerFechaHora();
                Tipo.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                DateTime fecha = Sistema.ObtenerFecha();
            }
            else
            {
                db.Entry(Tipo).State = EntityState.Modified;
                Tipo.FechaMod = Sistema.ObtenerFechaHora();
                Tipo.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));


            db.SaveChanges();
        }

        public static void Eliminar(TipoAsientos o)
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

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.TipoAsientos
                     join e in db.Empresas on t.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp.DefaultIfEmpty()
                     where (t.Id == parametros.Id || parametros.Id == null)
                        && (t.Id_AsientoPredefinido == parametros.TipoAsientos || parametros.TipoAsientos == null)
                        && (t.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Empresa = emp.Nombre,
                         Concepto = t.Concepto,
                         Id_Empresa = t.Id_Empresa,
                         Id_AsientoPredefinido = t.Id_AsientoPredefinido,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            public Enums.TiposDeAsientos? TipoAsientos { get; set; }
        }

        public class SearchResult : TipoAsientos
        {
            public string Empresa { get; set; }
        }

    }
}
