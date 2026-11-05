namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ComprobanteVentaAsociadoManager : IDisposable
    {
        private GestionContext db;
        public ComprobantesVentas Comprobante { get; set; }

        public ComprobanteVentaAsociadoManager(int Id_ComprobanteVenta)
        {
            db = new GestionContext();
            Comprobante = new ComprobantesVentas() { Id = Id_ComprobanteVenta };

            db.ComprobantesVentas.Attach(Comprobante);

            if (Comprobante.Id > 0)
            {
                db.Entry(Comprobante).Reload();
            }
            else
            {
                throw new ValidationException("Debe seleccionar un comprobante.");
            }
        }

        public List<KeyNamePair> ComprobantesLista
        {
            get
            {
                using (var db = new GestionContext())
                {
                    DateTime Fecha = Sistema.ObtenerFecha().AddMonths(-2);

                    return (from v in db.ComprobantesVentas
                            join tip in db.TipoComprobante on v.Id_TipoComprobante equals tip.Id into listTipo
                            from t in listTipo
                            where v.Id != Comprobante.Id
                              && v.Id_TipoEntidad == Comprobante.Id_TipoEntidad
                              && v.Id_Entidad == Comprobante.Id_Entidad
                              && v.Fecha > Fecha
                            select new KeyNamePair
                            {
                                Key = v.Id,
                                Name = t.Descripcion + " " + v.Letra + "-" + v.PuntoVenta + "-" + v.NroComprobante
                            }).OrderByDescending(t => t.Name).ToList();
                }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            db.Entry(Comprobante).State = EntityState.Modified;
            Comprobante.FechaMod = Sistema.ObtenerFechaHora();
            Comprobante.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

            db.SaveChanges();
        }

    }
}
