namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_DataEntity;

    public class ProductosSinMovimientosManager
    {
        public ProductosSinMovimientosManager()
        {

        }

        public List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ProductosSinVenta", sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(new SqlParameter("FechaDesde", parametros.FechaDesde));

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
                        case "Id": o.Id = dr.GetInt32(i); break;
                        case "Producto": o.Producto = dr.GetString(i); break;
                        case "Importe": o.Importe = dr.GetDecimal(i); break;
                        case "Stock": o.Stock = dr.GetDecimal(i); break;
                        case "UltimaCompra": o.UltimaCompra = dr.GetDateTime(i); break;
                    }
                }
            }
            return o;
        }

        public class ParametrosBusquedas
        {
            public DateTime FechaDesde { get; set; }
        }

        public class SearchResult
        {
            public int Id { get; set; }
            public string Producto { get; set; }
            public decimal Importe { get; set; }
            public DateTime? UltimaCompra { get; set; }
            public decimal? Stock { get; set; }
        }
    }
}
