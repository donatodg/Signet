namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_DataEntity;

    public class ComprobantesVentasDetalleMultipleManager : IDisposable
    {
        private GestionContext db = new GestionContext();

        public ComprobantesVentasDetalleMultipleManager()
        {

        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            List<SearchResult> r = new List<SearchResult>();

            SqlCommand cmdReport;

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;

                cmdReport = new SqlCommand("ProductosConLineas", sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(new SqlParameter("Id_TipoEntidad", parametros.Id_TipoEntidad));
                    cmdReport.Parameters.Add(new SqlParameter("Id_Entidad", parametros.Id_Entidad));
                    cmdReport.Parameters.Add(new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])));

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
                        case "Seleccionado": o.Seleccionado = false; break;
                        case "Id_Especie": o.Id_Especie = dr.GetInt32(i); break;
                        case "Cotizacion": o.Cotizacion = dr.GetDecimal(i); break;
                        case "Id_Producto": o.Id_Producto = dr.GetInt32(i); break;
                        case "Id_ProductoCompuesto": o.Id_ProductoCompuesto = dr.GetInt32(i); break;
                        case "Descripcion": o.Descripcion = dr.GetString(i); break;
                        case "Cantidad": o.Cantidad = dr.GetDecimal(i); break;
                        case "ImporteCosto": o.ImporteCosto = dr.GetDecimal(i); break;
                        case "PorcDescuento": o.PorcDescuento = dr.GetDecimal(i); break;
                        case "ImporteUnitario": o.ImporteUnitario = dr.GetDecimal(i); break;
                        case "Id_AlicuotaIva": o.Id_AlicuotaIva = dr.GetInt32(i); break;
                        case "AlicuotaIva": o.AlicuotaIva = dr.GetDecimal(i); break;
                        case "ImporteIVA": o.ImporteIVA = dr.GetDecimal(i); break;
                        case "Importe": o.Importe = dr.GetDecimal(i); break;
                        case "Especie": o.Especie = dr.GetString(i); break;
                        case "Linea": o.Linea = dr.GetString(i); break;
                        case "Variante": o.Variante = dr.GetString(i); break;
                        case "Medida": o.Medida = dr.GetString(i); break;
                        case "Codigo": o.Codigo = dr.GetString(i); break;
                        case "Visible_Cantidad_Stock": o.Visible_Cantidad_Stock = dr.GetBoolean(i); break;
                    }
                }
            }

            decimal ImporteDesc = o.ImporteUnitario * o.PorcDescuento / 100;
            o.ImporteIVA = Math.Round(Convert.ToDecimal(((o.ImporteUnitario - ImporteDesc) * o.AlicuotaIva / 100) * o.Cantidad), 2);
            decimal Subtotal = (o.ImporteUnitario - ImporteDesc + ((o.ImporteUnitario - ImporteDesc) * o.AlicuotaIva / 100)) * o.Cantidad;
            o.Importe = Math.Round(Subtotal, 2);

            return o;
        }

        public class ParametrosBusquedas
        {
            public VENET_Comun.Enums.TipoEntidad Id_TipoEntidad { get; set; }
            public int Id_Entidad { get; set; }
        }

        public class SearchResult : ComprobantesVentasDetalle
        {
            public bool Seleccionado { get; set; }
            public string Linea { get; set; }
            public string Variante { get; set; }
            public string Medida { get; set; }
            public string Codigo { get; set; }
        }

    }
}
