namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.Drawing;

    public class ProductosStockManager
    {
        public ProductosStockManager()
        {

        }

        public List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            List<SearchResult> r = new List<SearchResult>();

            if (parametros.Id_Producto == null) parametros.Id_Producto = 0;

            SqlCommand cmdReport;

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                if (parametros.Id_Deposito == null)
                    cmdReport = new SqlCommand("ProductosStockAgrupado", sqlConn);
                else
                    cmdReport = new SqlCommand("ProductosStock", sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(new SqlParameter("Id_Producto", parametros.Id_Producto));

                    if (parametros.Id_Deposito != null)
                        cmdReport.Parameters.Add(new SqlParameter("Id_Deposito", parametros.Id_Deposito));

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
                        case "Codigo": o.Codigo = dr.GetString(i); break;
                        case "CodigoFabrica": o.CodigoFabrica = dr.GetString(i); break;
                        case "Descripcion": o.Descripcion = dr.GetString(i); break;
                        case "Id_IvaAlicuota": o.Id_IvaAlicuota = dr.GetInt32(i); break;
                        case "Id_Categoria": o.Id_Categoria = dr.GetInt32(i); break;
                        case "Id_UnidadVenta": o.Id_UnidadVenta = dr.GetInt32(i); break;
                        case "CodigoBarras": o.CodigoBarras = dr.GetString(i); break;
                        case "Id_Especie": o.Id_Especie = dr.GetInt32(i); break;
                        case "Importe": o.Importe = dr.GetDecimal(i); break;
                        case "ImporteCosto": o.ImporteCosto = dr.GetDecimal(i); break;
                        case "StockMinimo": o.StockMinimo = dr.GetInt32(i); break;
                        case "StockMaximo": o.StockMaximo = dr.GetInt32(i); break;
                        case "Observaciones": o.Observaciones = dr.GetString(i); break;
                        case "FechaAdd": o.FechaAdd = dr.GetDateTime(i); break;
                        case "FechaMod": o.FechaMod = dr.GetDateTime(i); break;
                        case "UserAdd": o.UserAdd = dr.GetInt32(i); break;
                        case "UserMod": o.UserMod = dr.GetInt32(i); break;
                        case "Especie": o.Especie = dr.GetString(i); break;
                        case "Ingresos": o.Ingresos = dr.GetDecimal(i); break;
                        case "Egresos": o.Egresos = dr.GetDecimal(i); break;
                        case "StockInicial": o.StockInicial = dr.GetDecimal(i); break;
                    }
                }
            }
            return o;
        }

        public void GenerarArchivoStock()
        {
            try
            {
                string Ruta = Parametro.ObtenerValor(Parametro.Param.Ventas_Confirmar_RutaGeneraArchivoStock);

                List<SearchResult> selectdata = Buscar(new ParametrosBusquedas());

                // Crea el archivo de Excel
                string nombreArchivo = "Stock.xlsx";
                //string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
                string rutaArchivo = Path.Combine(Ruta, nombreArchivo);

                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Stock");
                workSheet.TabColor = Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Cells[1, 1].Value = "Producto";
                workSheet.Cells[1, 2].Value = "Codigo";
                workSheet.Cells[1, 3].Value = "Stock";
                workSheet.Cells[1, 4].Value = "Importe Costo";
                workSheet.Cells[1, 5].Value = "Valor";
                workSheet.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#B4C6E7"));

                //workSheet.Cells["A2"].LoadFromCollection(selectdata);
                int fila = 2;
                foreach (SearchResult item in selectdata)
                {
                    workSheet.Cells[fila, 1].Value = item.Descripcion;
                    workSheet.Cells[fila, 2].Value = item.Codigo;
                    workSheet.Cells[fila, 3].Value = item.Stock;
                    workSheet.Cells[fila, 4].Value = item.ImporteCosto;
                    workSheet.Cells[fila, 5].Value = item.ImporteStock;
                    fila++;
                }

                workSheet.Cells["A:E"].AutoFitColumns();

                FileStream objFileStrm = File.Create(rutaArchivo);
                objFileStrm.Close();
                File.WriteAllBytes(rutaArchivo, excel.GetAsByteArray());
                excel.Dispose();

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Id_Deposito = Sistema.Depositos.First().Key;
            }
            public List<ProductosBusqueda> Productos { get { using (GestionContext db = new GestionContext()) { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } } }

            public int? Id_Deposito { get; set; }
            public int? Id_Producto { get; set; }
        }


        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public int Id_Deposito { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Productos
        {
            public string Especie { get; set; }
            public decimal StockInicial { get; set; }
            public decimal Ingresos { get; set; }
            public decimal Egresos { get; set; }
            public decimal Stock { get { return Convert.ToDecimal(StockInicial) + Ingresos - Egresos; } }
            public decimal ImporteStock { get { return (Convert.ToDecimal(StockInicial) + Ingresos - Egresos) * ImporteCosto; } }
        }

    }
}