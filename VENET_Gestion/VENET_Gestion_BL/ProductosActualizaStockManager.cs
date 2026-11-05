namespace VENET_Gestion_BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProductosActualizaStockManager
    {

        public ProductosActualizaStockManager() { }

        public static decimal ActualizarStock(int Id_Producto, int Id_Deposito, decimal CantidadActual)
        {
            using (var db = new GestionContext())
            {
                Productos o = new Productos() { Id = Id_Producto };
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                decimal Ingresos = (from ccd in db.ComprobantesComprasDetalle
                                join compC in db.ComprobantesCompras on ccd.Id_ComprobanteCompra equals compC.Id into listCC
                                from cc in listCC
                                join tipoC in db.TipoComprobante on cc.Id_TipoComprobante equals tipoC.Id into listTC
                                from tc in listTC
                                where tc.MueveStock == true
                                   && ccd.Id_Producto == Id_Producto
                                   && cc.Id_Deposito == Id_Deposito
                                   && ccd.UserDel == null
                                   && cc.UserDel == null
                                   && cc.FechaAnulacion == null
                                   && cc.FechaLiquidacion != null
                                select ccd.Cantidad).DefaultIfEmpty(0).Sum();

                decimal Egresos = (from ccd in db.ComprobantesVentasDetalle
                               join compC in db.ComprobantesVentas on ccd.Id_ComprobanteVenta equals compC.Id into listCC
                               from cc in listCC
                               join tipoC in db.TipoComprobante on cc.Id_TipoComprobante equals tipoC.Id into listTC
                               from tc in listTC
                               //where tc.MueveStock == true
                               where tc.RestaStock == true
                                  && ccd.Id_Producto == Id_Producto
                                  && cc.Id_Deposito == Id_Deposito
                                  && ccd.UserDel == null
                                  && cc.UserDel == null
                                  && cc.FechaAnulacion == null
                                  && cc.FechaLiquidacion != null
                               select ccd.Cantidad).DefaultIfEmpty(0).Sum();


                ProductosDepositos pd = new ProductosDepositos();
                pd.Id = (db.ProductosDepositos.Where(t => t.Id_Producto == Id_Producto && t.Id_Deposito == Id_Deposito && t.UserDel == null).Select(t => t.Id)).FirstOrDefault();
                if (pd.Id > 0)
                {
                    db.Entry(pd).State = EntityState.Modified;
                    db.Entry(pd).Reload();
                    pd.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    pd.FechaMod = Sistema.ObtenerFechaHora();
                }
                else
                {
                    db.Entry(pd).State = EntityState.Added;
                    pd.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    pd.FechaAdd = Sistema.ObtenerFechaHora();
                }
                pd.Id_Deposito = Id_Deposito;
                pd.Id_Producto = Id_Producto;

                decimal Stock = Convert.ToDecimal(pd.StockInicial + Ingresos - Egresos);
                pd.StockInicial = pd.StockInicial - Stock + CantidadActual;

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();

                return pd.StockInicial;
            }
        }
    }
}
