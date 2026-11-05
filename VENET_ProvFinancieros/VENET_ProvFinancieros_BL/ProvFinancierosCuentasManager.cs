namespace VENET_ProvFinancieros_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProvFinancierosCuentasManager : IDisposable
    {
        private TesoreriaContext db;
        public ProvFinancierosCuentas Cuenta { get; set; }
        public List<SearchResult> ListProvFinancieros { get; set; }

        public ProvFinancierosCuentasManager(Int32 Id_ProeevedorF)
        {
            db = new TesoreriaContext();
            ListProvFinancieros = (from pf in db.ProvFinancierosCuentas
                                   join e in db.EntidadesBancarias on pf.Id_EntidadBancaria equals e.Codigo into listEB
                                   from eb in listEB
                                   join es in db.Especies on pf.Id_Especie equals es.Id into listEsp
                                   from esp in listEsp
                                   where pf.Id_ProvFinanciero == Id_ProeevedorF
                                       && pf.UserDel == null
                                   select new SearchResult()
                                   {
                                       Id = pf.Id,
                                       Banco = eb.Descripcion,
                                       CBU = pf.CBU,
                                       Id_EntidadBancaria = pf.Id_EntidadBancaria,
                                       Id_ProvFinanciero = pf.Id_ProvFinanciero,
                                       Id_Especie = pf.Id_Especie,
                                       Especie = esp.Descripcion,
                                       NroCuenta = pf.NroCuenta,
                                       NroSucursal = pf.NroSucursal,
                                       FechaAdd = pf.FechaAdd,
                                       FechaMod = pf.FechaMod,
                                       UserAdd = pf.UserAdd,
                                       UserMod = pf.UserMod
                                   }).ToList();

        }

        public ProvFinancierosCuentasManager(ProvFinancierosCuentas o)
        {
            db = new TesoreriaContext();
            Cuenta = o;

            db.ProvFinancierosCuentas.Attach(Cuenta);

            if (Cuenta.Id > 0)
                db.Entry(Cuenta).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Entidades { get { return db.EntidadesBancarias.Select(t => new KeyNamePair() { Key = t.Codigo, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }

        public void Save()
        {
            //validar que no este duplicada la cuenta
            if (db.ProvFinancierosCuentas.Where(t => t.Id != Cuenta.Id && t.UserDel == null && t.Id_EntidadBancaria == Cuenta.Id_EntidadBancaria && t.NroCuenta == Cuenta.NroCuenta && t.NroSucursal == Cuenta.NroSucursal).Count() > 0)
                throw new ValidationException("La cuenta esta asociada a otro proveedor financiero");

            if (Cuenta.Id == 0)
            {
                db.Entry(Cuenta).State = EntityState.Added;
                Cuenta.FechaAdd = Sistema.ObtenerFechaHora();
                Cuenta.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Cuenta).State = EntityState.Modified;
                Cuenta.FechaMod = Sistema.ObtenerFechaHora();
                Cuenta.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ProvFinancierosCuentas o)
        {
            using (var db = new TesoreriaContext())
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
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.ProvFinancierosCuentas
                     join e in db.EntidadesBancarias on p.Id_EntidadBancaria equals e.Codigo into listEnt
                     from eb in listEnt
                     join es in db.Especies on p.Id_Especie equals es.Id into listEsp
                     from esp in listEsp
                     where (p.Id == parametros.Id || parametros.Id == null)
                        && (p.UserDel == null)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Banco = eb.Descripcion,
                         Id_EntidadBancaria = p.Id_EntidadBancaria,
                         Id_ProvFinanciero = p.Id_ProvFinanciero,
                         Id_Especie = p.Id_Especie,
                         Especie = esp.Descripcion,
                         NroCuenta = p.NroCuenta,
                         NroSucursal = p.NroSucursal,
                         CBU = p.CBU,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod,
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
        }

        public class SearchResult : ProvFinancierosCuentas
        {
            public string Especie { get; set; }
            public string Banco { get; set; }
        }

    }
}
