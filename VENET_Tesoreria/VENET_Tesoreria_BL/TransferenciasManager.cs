namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class TransferenciasManager : IDisposable
    {
        private TesoreriaContext db;
        public Transferencias Transferencia { get; set; }

        public TransferenciasManager(Transferencias o)
        {
            db = new TesoreriaContext();
            Transferencia = o;
            Transferencia.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);

            db.Transferencias.Attach(Transferencia);

            if (Transferencia.Id > 0)
            {
                db.Entry(Transferencia).Reload();
            }
            else
            {
                if (Sistema.CentrosCostos.Count > 0)
                    Transferencia.Id_CentroCosto = Sistema.CentrosCostos.First().Key;

                if (Transferencia.Id_Caja_Origen > 0)
                    Transferencia.Cotizacion_Origen = (from es in db.Especies
                                                       where db.Cajas.Where(t => t.Id == Transferencia.Id_Caja_Origen).Select(t => t.Id_Especie).Contains(es.Id)
                                                       select es.Cotizacion).FirstOrDefault();
            }

        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Transferencia.Id == 0)
            {
                if (e.PropertyName == "Id_Caja_Origen")
                    using (var db = new TesoreriaContext())
                        Transferencia.Cotizacion_Origen = (from es in db.Especies
                                                           where db.Cajas.Where(t => t.Id == Transferencia.Id_Caja_Origen).Select(t => t.Id_Especie).Contains(es.Id)
                                                           select es.Cotizacion).FirstOrDefault();

                if (e.PropertyName == "Id_Caja_Destino")
                    using (var db = new TesoreriaContext())
                        Transferencia.Cotizacion_Destino = (from es in db.Especies
                                                            where db.Cajas.Where(t => t.Id == Transferencia.Id_Caja_Destino).Select(t => t.Id_Especie).Contains(es.Id)
                                                            select es.Cotizacion).FirstOrDefault();

            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Transferencia.Id > 0) throw new ValidationException("No se puede modificar la transferencia.");

            //***********************************************
            // Validaciones
            //***********************************************
            string Error = "";
            if (Transferencia.Id_Caja_Origen == 0) Error += "Debe seleccionar una caja de origen.";
            if (Transferencia.Id_Caja_Destino == 0) Error += "Debe seleccionar una caja de destino.";
            if (Transferencia.Id_Caja_Origen == Transferencia.Id_Caja_Destino) Error += "Las cajas origen y destino no pueden ser iguales";
            if (Transferencia.Importe <= 0) Error += "Debe ingresar un importe válido.";

            if (Error != "") throw new ValidationException(Error);
            //***********************************************

            db.Entry(Transferencia).State = EntityState.Added;
            Transferencia.FechaAdd = Sistema.ObtenerFechaHora();
            Transferencia.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

            string CajaOrigen = (db.Cajas.Where(t => t.Id == Transferencia.Id_Caja_Origen).Select(t => t.Descripcion)).FirstOrDefault();
            string CajaDestino = (db.Cajas.Where(t => t.Id == Transferencia.Id_Caja_Destino).Select(t => t.Descripcion)).FirstOrDefault();
            string ConceptoOrigen = "Transferencia a " + CajaDestino + " - " + Transferencia.Descripcion;
            string ConceptoDestino = "Transferencia de " + CajaOrigen + " - " + Transferencia.Descripcion;

            if (ConceptoOrigen.Length > 100) ConceptoOrigen = ConceptoOrigen.Substring(0, 100);
            if (ConceptoDestino.Length > 100) ConceptoDestino = ConceptoDestino.Substring(0, 100);

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            EspeciesCtaCte o = new EspeciesCtaCte()
            {
                Concepto = ConceptoOrigen,
                Credito = Transferencia.Importe,
                Fecha = Transferencia.FechaAdd,
                FechaAdd = Transferencia.FechaAdd,
                Id_Caja = Transferencia.Id_Caja_Origen,
                Id_CentroCosto = Transferencia.Id_CentroCosto,
                Id_Comprobante = Transferencia.Id,
                UserAdd = Transferencia.UserAdd
            };

            o.Id_TipoComprobante = (int)Enums.TipoComprobante.Transferencia;

            EspeciesCtaCte d = new EspeciesCtaCte()
            {
                Concepto = ConceptoDestino,
                Debito = Transferencia.Debito,
                Fecha = Transferencia.FechaAdd,
                FechaAdd = Transferencia.FechaAdd,
                Id_Caja = Transferencia.Id_Caja_Destino,
                Id_CentroCosto = Transferencia.Id_CentroCosto,
                Id_Comprobante = Transferencia.Id,
                UserAdd = Transferencia.UserAdd
            };

            d.Id_TipoComprobante = o.Id_TipoComprobante = (int)Enums.TipoComprobante.Transferencia;


            db.EspeciesCtaCte.Attach(o);
            db.Entry(o).State = EntityState.Added;

            db.EspeciesCtaCte.Attach(d);
            db.Entry(d).State = EntityState.Added;

            db.SaveChanges();
        }

    }
}
