namespace VENET_Tesoreria_BL
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

    public class BoletaDepositoEfectivoManager : IDisposable
    {
        private TesoreriaContext db;
        public BoletasDepositosEfectivo Boleta { get; set; }

        public BoletaDepositoEfectivoManager(int Id_Caja)
        {
            db = new TesoreriaContext();
            Boleta = new BoletasDepositosEfectivo();

            Boleta.Id_Caja = Id_Caja;
            Boleta.Fecha = Sistema.ObtenerFecha();
            Boleta.Descripcion = "-";

            if (Sistema.CentrosCostos.Count() > 0)
                Boleta.Id_CentroCosto = Sistema.CentrosCostos.First().Key;

        }

        public List<KeyNamePair> CuentasPF
        {
            get
            {
                return (from p in db.ProvFinancieros
                        join c in db.ProvFinancierosCuentas on p.Id equals c.Id_ProvFinanciero into listPFC
                        from pfc in listPFC
                        where p.UserDel == null && pfc.UserDel == null
                        select new KeyNamePair() { Key = pfc.Id, Name = p.Nombre + " - " + pfc.CBU }).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Boleta.Id_CuentaPF == 0) throw new ValidationException("Debe seleccionar una cuenta.");
            if (Boleta.Importe <= 0) throw new ValidationException("Debe ingresar un importe válido.");

            EspeciesCtaCte ecc = new EspeciesCtaCte();
            ecc.Fecha = Boleta.Fecha;
            ecc.Id_Caja = Boleta.Id_Caja;
            ecc.Id_CentroCosto = Boleta.Id_CentroCosto;
            ecc.Id_TipoComprobante = (int)Enums.TipoComprobante.BoletasDeposito;
            ecc.Id_Comprobante = 0;
            ecc.Concepto = (from c in db.ProvFinancierosCuentas
                            join p in db.ProvFinancieros on c.Id_ProvFinanciero equals p.Id into listPF
                            from pf in listPF
                            where c.Id == Boleta.Id_CuentaPF
                            select pf.Nombre +  " - " + c.CBU).FirstOrDefault() +
                            " - Boleta Nro. " + Boleta.Numero.ToString();
            if (Boleta.Descripcion != "-")
                ecc.Concepto += " - " + Boleta.Descripcion;
            ecc.Credito = Boleta.Importe;
            ecc.FechaAdd = Sistema.ObtenerFechaHora();
            ecc.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

            db.EspeciesCtaCte.Attach(ecc);
            db.Entry(ecc).State = EntityState.Added;

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public class BoletasDepositosEfectivo
        {
            public DateTime Fecha { get; set; }
            public int Id_Caja { get; set; }
            public int Id_CuentaPF { get; set; }
            public int Id_CentroCosto { get; set; }
            public int Numero { get; set; }
            public decimal Importe { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
