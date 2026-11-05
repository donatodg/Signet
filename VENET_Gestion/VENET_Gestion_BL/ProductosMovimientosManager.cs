namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProductosMovimientosManager
    {

        public ProductosMovimientosManager()
        {

        }

        public List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            List<SearchResult> r = new List<SearchResult>();

            if (parametros.Id_Producto == null) parametros.Id_Producto = 0;

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ProductosMovimientos", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("Id_Deposito", parametros.Id_Deposito);
                    SqlParameter Parameter2 = new SqlParameter("Id_Producto", parametros.Id_Producto);
                    SqlParameter Parameter3 = new SqlParameter("FechaDesde", parametros.FechaDesde);
                    SqlParameter Parameter4 = new SqlParameter("FechaHasta", parametros.FechaHasta);

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);

                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    using (IDataReader dr = cmdReport.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.Add(Load(dr));
                        }
                    }
                }
            }

            return r;
        }

        private SearchResult Load(IDataRecord dr)
        {
            SearchResult o = new SearchResult();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Entidad": o.Entidad = dr.GetString(i); break;
                        case "Nombre": o.Nombre = dr.GetString(i); break;
                        case "Tipo": o.Tipo = dr.GetString(i); break;
                        case "Comprobante": o.Comprobante = dr.GetString(i); break;
                        case "Id_Comprobante": o.Id_Comprobante = dr.GetInt32(i); break;
                        case "Id_Especie": o.Id_Especie = dr.GetInt32(i); break;
                        case "Especie": o.Especie = dr.GetString(i); break;
                        case "Cotizacion": o.Cotizacion = dr.GetDecimal(i); break;
                        case "Descripcion": o.Descripcion = dr.GetString(i); break;
                        case "Cantidad": o.Cantidad = dr.GetDecimal(i); break;
                        case "CantidadStock": o.CantidadStock = dr.GetDecimal(i); break;
                        case "PorcDescuento": o.PorcDescuento = dr.GetDecimal(i); break;
                        case "ImporteUnitario": o.ImporteUnitario = dr.GetDecimal(i); break;
                        case "Id_IvaAlicuota": o.Id_AlicuotaIva = dr.GetInt32(i); break;
                        case "AlicuotaIva": o.AlicuotaIva = dr.GetDecimal(i); break;
                        case "ImporteIva": o.ImporteIva = dr.GetDecimal(i); break;
                        case "Importe": o.Importe = dr.GetDecimal(i); break;
                        case "Codigo": o.Codigo = dr.GetString(i); break;
                        case "CodigoBarras": o.CodigoBarras = dr.GetString(i); break;
                        case "CodigoFabrica": o.CodigoFabrica = dr.GetString(i); break;
                        case "Id_Categoria": o.Id_Categoria = dr.GetInt32(i); break;
                        case "Categoria": o.Categoria = dr.GetString(i); break;
                    }
                }
            }
            return o;
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
                Id_Deposito = Sistema.Depositos.First().Key;
            }

            public List<ProductosBusqueda> Productos { get { using (GestionContext db = new GestionContext()) { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } } }

            public int Id_Deposito { get; set; }
            public int? Id_Producto { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
        }

        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult
        {
            public DateTime Fecha { get; set; }
            public string Entidad { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Comprobante { get; set; }
            public int Id_Comprobante { get; set; }
            public int Id_Especie { get; set; }
            public string Especie { get; set; }
            public decimal Cotizacion { get; set; }
            public string Descripcion { get; set; }
            public decimal Cantidad { get; set; }
            public decimal? CantidadStock { get; set; }
            public decimal PorcDescuento { get; set; }
            public decimal ImporteUnitario { get; set; }
            public int Id_AlicuotaIva { get; set; }
            public decimal AlicuotaIva { get; set; }
            public decimal ImporteIva { get; set; }
            public decimal Importe { get; set; }
            public string Codigo { get; set; }
            public string CodigoBarras { get; set; }
            public string CodigoFabrica { get; set; }
            public string Categoria { get; set; }
            public int Id_Categoria { get; set; }
        }
    }
}
