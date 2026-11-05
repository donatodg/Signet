namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TransferenciasManager_OLD : IDisposable
    {
        private TesoreriaContext db;
        public EspeciesCtaCte EspecieCtaCte { get; set; }
        public EspeciesCtaCte EspecieCtaCteDestino { get; set; }

        public TransferenciasManager_OLD(int IdEspecie)
        {
            db = new TesoreriaContext();
            EspecieCtaCte = new EspeciesCtaCte();//{ Id_Especie = IdEspecie };
            EspecieCtaCteDestino = new EspeciesCtaCte();

            db.EspeciesCtaCte.Attach(EspecieCtaCte);

            EspecieCtaCte.Id_CentroCosto = 1;
            EspecieCtaCte.Id_TipoComprobante = 1;
            IdEspecieOrigen = IdEspecie;
        }

        private decimal _CotizacionEspecieOrigen;
        public decimal CotizacionEspecieOrigen
        {
            get { return _CotizacionEspecieOrigen; }
            set
            {
                _CotizacionEspecieOrigen = value;
                try
                {
                    EspecieCtaCteDestino.Debito = Importe * _CotizacionEspecieOrigen / _CotizacionEspecieDestino;
                }
                catch (Exception)
                {
                    EspecieCtaCteDestino.Debito = 0;
                }
            }
        }

        public string Concepto { get; set; }

        public int IdEspecieOrigen
        {
            get
            {
                return 1;// EspecieCtaCte.Id_Especie;
            }
            set
            {
                if (value > 0)
                {
                    CotizacionEspecieOrigen = db.Especies.Where(t => t.Id == value).Select(t => t.Cotizacion).FirstOrDefault();

                    //EspecieCtaCte.Id_Especie = (int)value;
                }
            }
        }

        private decimal _CotizacionEspecieDestino;
        public decimal CotizacionEspecieDestino
        {
            get { return _CotizacionEspecieDestino; }
            set
            {
                _CotizacionEspecieDestino = value;
                try
                {
                    EspecieCtaCteDestino.Debito =  Importe * _CotizacionEspecieOrigen / _CotizacionEspecieDestino;
                }
                catch (Exception)
                {
                    EspecieCtaCteDestino.Debito = 0;
                }
            }
        }
        public int IdEspecieDestino
        {
            get
            {
                return 1;//EspecieCtaCteDestino.Id_Especie;
            }
            set
            {
                if (value > 0)
                {
                    CotizacionEspecieDestino = db.Especies.Where(t => t.Id == value).Select(t => t.Cotizacion).FirstOrDefault();
                    //EspecieCtaCteDestino.Id_Especie = (int)value;
                }
            }
        }

        public decimal Importe
        {
            get
            {
                return EspecieCtaCte.Credito;
            }
            set
            {
                EspecieCtaCte.Credito = value;
                EspecieCtaCteDestino.Debito = value * CotizacionEspecieOrigen / CotizacionEspecieDestino;

            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            db.Entry(EspecieCtaCte).State = EntityState.Added;
            EspecieCtaCte.Fecha = EspecieCtaCte.FechaAdd = Sistema.ObtenerFechaHora();
            EspecieCtaCte.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            //EspecieCtaCte.Id_Especie = IdEspecieOrigen;
            //EspecieCtaCte.Id_Sucursal = 1;
            EspecieCtaCte.Id_Comprobante = 0;
            EspecieCtaCte.Concepto = Concepto;

            EspeciesCtaCte o = new EspeciesCtaCte()
            {
                Concepto = EspecieCtaCte.Concepto,
                Credito = 0,
                Debito =  Importe * CotizacionEspecieOrigen / CotizacionEspecieDestino,
                Fecha = EspecieCtaCte.Fecha,
                FechaAdd = EspecieCtaCte.FechaAdd,
                Id_CentroCosto = EspecieCtaCte.Id_CentroCosto,
                Id_Comprobante = EspecieCtaCte.Id_Comprobante,
                //Id_Especie = IdEspecieDestino,
                //Id_Sucursal = EspecieCtaCte.Id_Sucursal,
                Id_TipoComprobante = EspecieCtaCte.Id_TipoComprobante,
                UserAdd = EspecieCtaCte.UserAdd
            };

            db.Entry(o).State = EntityState.Added;

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }
    }
}
