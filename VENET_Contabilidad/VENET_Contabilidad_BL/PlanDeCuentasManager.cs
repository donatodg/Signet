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

    public class PlanDeCuentasManager : IDisposable
    {
        private GestionContext db;
        public CuentasContables CuentaContable { get; set; }

        public PlanDeCuentasManager(CuentasContables o)
        {
            db = new GestionContext();
            CuentaContable = o;

            db.CuentasContables.Attach(o);

            if (CuentaContable.Id > 0) db.Entry(CuentaContable).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (CuentaContable.Descripcion == null || CuentaContable.Descripcion == "")
                throw new ValidationException("Debe ingresar una descripción.");

            if (CuentaContable.Titulo == null) CuentaContable.Titulo = "00";
            if (CuentaContable.Capitulo == null) CuentaContable.Capitulo = "00";
            if (CuentaContable.Rubro == null) CuentaContable.Rubro = "00";
            if (CuentaContable.Cuenta == null) CuentaContable.Cuenta = "00";
            if (CuentaContable.Subcuenta == null) CuentaContable.Subcuenta = "000000";

            if (CuentaContable.Titulo.Length == 1) CuentaContable.Titulo = "0" + CuentaContable.Titulo;
            if (CuentaContable.Capitulo.Length == 1) CuentaContable.Capitulo = "0" + CuentaContable.Capitulo;
            if (CuentaContable.Rubro.Length == 1) CuentaContable.Rubro = "0" + CuentaContable.Rubro;
            if (CuentaContable.Cuenta.Length == 1) CuentaContable.Cuenta = "0" + CuentaContable.Cuenta;
            if (CuentaContable.Subcuenta.Length >= 1 && CuentaContable.Subcuenta.Length < 6) CuentaContable.Subcuenta = ("000000" + CuentaContable.Subcuenta).Substring(("000000" + CuentaContable.Subcuenta).Length - 6, 6);

            if (CuentaContable.Subcuenta == "000000")
            {
                CuentaContable.Descripcion = CuentaContable.Descripcion.ToUpper();
                if (CuentaContable.Cuenta != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Rubro != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Capitulo != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
            }
            else
            {
                CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Subcuenta != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Cuenta != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Rubro != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
                if (CuentaContable.Capitulo != "00") CuentaContable.Descripcion = " " + CuentaContable.Descripcion;
            }

            if (db.CuentasContables.Where(t => t.Id != CuentaContable.Id && t.Titulo == CuentaContable.Titulo && t.Capitulo == CuentaContable.Capitulo && t.Rubro == CuentaContable.Rubro && t.Cuenta == CuentaContable.Cuenta && t.Subcuenta == CuentaContable.Subcuenta && t.UserDel == null).Count() > 0)
                throw new ValidationException("La cuenta ingresada ya existe.");


            if (CuentaContable.Id == 0)
            {
                db.Entry(CuentaContable).State = EntityState.Added;

                CuentaContable.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                CuentaContable.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(CuentaContable).State = EntityState.Modified;
                CuentaContable.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                CuentaContable.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(CuentasContables o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();
                if (db.AsientosDetalle.Any(d => d.Id_CuentaContable == o.Id))
                    throw new ValidationException("La cuenta tiene movimientos y no puede darse de baja.");

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

                r = (from c in db.CuentasContables
                     where (c.Id == parametros.Id || parametros.Id == null)
                            && (c.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (c.UserDel == null)
                     select new SearchResult
                     {
                         Id = c.Id,
                         Titulo = c.Titulo,
                         Capitulo = c.Capitulo,
                         Rubro = c.Rubro,
                         Cuenta = c.Cuenta,
                         Subcuenta = c.Subcuenta,
                         Descripcion = c.Descripcion,
                         FechaAdd = c.FechaAdd,
                         FechaMod = c.FechaMod,
                         UserAdd = c.UserAdd,
                         UserMod = c.UserMod
                     }).OrderBy(t => new { t.Titulo, t.Capitulo, t.Rubro, t.Cuenta, t.Subcuenta }).ToList();
                return r;
            }
        }

        public string BuscaTitulo(string Titulo)
        {
            string r;
            using (var db = new GestionContext())
            {
                r = (from c in db.CuentasContables
                     where c.Titulo == Titulo &&
                           c.Capitulo == "00" &&
                           c.Rubro == "00" &&
                           c.Cuenta == "00" &&
                           c.Subcuenta == "000000" &&
                           c.UserDel == null
                     select c.Descripcion).FirstOrDefault();
            }
            if (r == null) return ""; else return r.Trim();
        }

        public string BuscaCapitulo(string Titulo, string Capitulo)
        {
            string r;
            using (var db = new GestionContext())
            {
                r = (from c in db.CuentasContables
                     where c.Titulo == Titulo &&
                           c.Capitulo == Capitulo &&
                           c.Rubro == "00" &&
                           c.Cuenta == "00" &&
                           c.Subcuenta == "000000" &&
                           c.UserDel == null
                     select c.Descripcion).FirstOrDefault();
            }
            if (r == null) return ""; else return r.Trim();
        }

        public string BuscaRubro(string Titulo, string Capitulo, string Rubro)
        {
            string r;
            using (var db = new GestionContext())
            {
                r = (from c in db.CuentasContables
                     where c.Titulo == Titulo &&
                           c.Capitulo == Capitulo &&
                           c.Rubro == Rubro &&
                           c.Cuenta == "00" &&
                           c.Subcuenta == "000000" &&
                           c.UserDel == null
                     select c.Descripcion).FirstOrDefault();
            }
            if (r == null) return ""; else return r.Trim();
        }

        public string BuscaCuenta(string Titulo, string Capitulo, string Rubro, string Cuenta)
        {
            string r;
            using (var db = new GestionContext())
            {
                r = (from c in db.CuentasContables
                     where c.Titulo == Titulo &&
                           c.Capitulo == Capitulo &&
                           c.Rubro == Rubro &&
                           c.Cuenta == Cuenta &&
                           c.Subcuenta == "000000" &&
                           c.UserDel == null
                     select c.Descripcion).FirstOrDefault();
            }
            if (r == null) return ""; else return r.Trim();
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : CuentasContables
        {

        }
    }
}
