namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TalonariosComprobantesManager : IDisposable
    {
        private GeneralContext db;
        public TalonariosComprobantes Talonario { get; set; }
        private int IdEmpresa;

        public TalonariosComprobantesManager(TalonariosComprobantes o, int Id_Empresa)
        {
            db = new GeneralContext();
            Talonario = o;
            IdEmpresa = Id_Empresa;

            db.TalonariosComprobantes.Attach(Talonario);

            if (Talonario.Id > 0)
            {
                db.Entry(Talonario).Reload();

                if (Talonario.Detalle == null)
                    db.Entry(Talonario).Collection(p => p.Detalle).Load();
            }
            else
            {
                Talonario.Reporte = "<Ninguno>";
                db.Entry(Talonario).Collection(p => p.Detalle).Load();
            }
        }

        public List<ListPuntoVenta> PuntosVentas
        {
            get
            {
                return
                    (from pv in db.PuntosVentas
                     join s in db.Sucursales on pv.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     where emp.Id == IdEmpresa &&
                           pv.UserDel == null &&
                           emp.UserDel == null &&
                           Seguridad.IdPuntosVentasAsignados.Contains(pv.Id)
                     select new ListPuntoVenta()
                     {
                         Id = pv.Id,
                         PuntoVenta = pv.PuntoVenta,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion
                     }).OrderBy(t => t.Empresa).ToList();
            }
        }
        public List<KeyNamePair> TiposComprobantesAFIP { get { using (GestionContext db = new GestionContext()) return (from tc in db.AFIP_Comprobantes select new KeyNamePair() { Key = tc.Id, Name = tc.Descripcion }).OrderBy(t => t.Key).ToList(); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Talonario.Detalle.Count == 0)
                throw new ValidationException("No se ingresó el detalle del talonario.");

            if (db.TalonariosComprobantes.Where(t => t.Id_Comprobante == Talonario.Id_Comprobante && t.Id_PuntoVenta == Talonario.Id_PuntoVenta && t.Letra == Talonario.Letra && t.Id != Talonario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("El talonario ya existe.");

            if (Talonario.Copias == null) Talonario.Copias = 1;

            if (Talonario.Id == 0)
            {
                db.Entry(Talonario).State = EntityState.Added;

                Talonario.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Talonario.FechaAdd = Sistema.ObtenerFechaHora();
                // Talonario.NroComprobante = db.Recibos.Where(t => t.Id_Sucursal == Recibo.Id_Sucursal).Select(t => t.NroComprobante).DefaultIfEmpty().Max() + 1;
            }
            else
            {
                db.Entry(Talonario).State = EntityState.Modified;
                Talonario.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Talonario.FechaMod = Sistema.ObtenerFechaHora();
            }

            if (!Talonario.Electronico)
                Talonario.Id_AFIP_Comprobante = null;

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TalonariosComprobantes o)
        {
            using (var db = new GeneralContext())
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
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from tc in db.TalonariosComprobantes
                     join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                     from pventa in listPV.DefaultIfEmpty()
                     join s in db.Sucursales on pventa.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                     from emp in listEmp
                     join c in db.TipoComprobante on tc.Id_Comprobante equals c.Id into listComp
                     from comp in listComp.DefaultIfEmpty()
                     where (tc.Id == parametros.Id || parametros.Id == null)
                           && (tc.Id_Comprobante == parametros.Id_Comprobante || parametros.Id_Comprobante == null)
                           && (emp.Id == parametros.Id_Empresa || parametros.Id_Empresa == 0)
                           && (tc.UserDel == null)
                           && (emp.UserDel == null)
                           && (pventa.UserDel == null)
                     select new SearchResult
                     {
                         Id = tc.Id,
                         Copias = tc.Copias,
                         // Detalle = tc.Detalle,
                         TipoComprobante = comp.Descripcion,
                         Comprobante = comp.DescripcionCorta,
                         Empresa = emp.Nombre,
                         Sucursal = suc.Descripcion,
                         Id_Comprobante = tc.Id_Comprobante,
                         Id_PuntoVenta = tc.Id_Comprobante,
                         Impresora = tc.Impresora,
                         Letra = tc.Letra,
                         NroCodigo = tc.NroCodigo,
                         Reporte = tc.Reporte,
                         PuntoVenta = pventa.PuntoVenta,
                         Electronico = tc.Electronico,
                         Id_AFIP_Comprobante = tc.Id_AFIP_Comprobante,
                         FechaAdd = tc.FechaAdd,
                         FechaMod = tc.FechaMod,
                         UserAdd = tc.UserAdd,
                         UserMod = tc.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public int Id_Empresa { get; set; }
            public int? Id_Comprobante { get; set; }
            public string Letra { get; set; }
        }

        public class SearchResult : TalonariosComprobantes
        {
            public string PuntoVenta { get; set; }
            public string Empresa { get; set; }
            public string Comprobante { get; set; }
            public string TipoComprobante { get; set; }
            public string Sucursal { get; set; }
        }

        public class ListPuntoVenta
        {
            public int Id { get; set; }
            public string PuntoVenta { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
        }
    }
}
