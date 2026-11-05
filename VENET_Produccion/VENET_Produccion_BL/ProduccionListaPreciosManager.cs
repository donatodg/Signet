namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Drawing;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using Microsoft.Office.Core;

    public class ProduccionListaPreciosManager : IDisposable
    {
        //  private object m_objOpt = System.Reflection.Missing.Value;
        //private Microsoft.Office.Interop.Excel.Range m_objRange = null;
        private ProduccionContext db;

        public Produccion_ListaPrecios Lista { get; set; }

        public ProduccionListaPreciosManager(Produccion_ListaPrecios o)
        {
            db = new ProduccionContext();
            Lista = o;

            db.Produccion_ListaPrecios.Attach(Lista);

            if (Lista.Id > 0) db.Entry(Lista).Reload();
            else
            {
                Lista.Id_Empresa = Sistema.Empresas.ElementAt(0).Key;
                Lista.VigenteDesde = Sistema.ObtenerFecha();
                Lista.VigenteHasta = Lista.VigenteDesde.AddYears(1);
                Lista.Descripcion = "Lista Nº ";
                //Lista.Descripcion = "Lista " + Lista.VigenteDesde.ToString("MMMMM yyyy");
                Lista.Utilidad = (db.Produccion_ListaPrecios.Where(t => t.UserDel == null).OrderByDescending(t => t.Id).Select(t => t.Utilidad)).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save(bool ActualizaUtilidad)
        {
            bool CreaLista = false;

            if (Lista.Id == 0)
            {
                db.Entry(Lista).State = EntityState.Added;
                Lista.FechaAdd = Sistema.ObtenerFechaHora();
                Lista.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                CreaLista = true;
            }
            else
            {
                db.Entry(Lista).State = EntityState.Modified;
                Lista.FechaMod = Sistema.ObtenerFechaHora();
                Lista.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            if (CreaLista)
            {
                List<ProduccionManager.SearchResult> Composicion;
                List<ProduccionManager.SearchResultTareas> Tareas;
                ProduccionManager.ParametrosBusquedas Parametros = new ProduccionManager.ParametrosBusquedas() { Id_Empresa = Lista.Id_Empresa };

                Composicion = ProduccionManager.Buscar(Parametros);
                Tareas = ProduccionManager.BuscarTareas(Parametros);

                List<ListaVariantesMedidas> VarMed = (from l in db.Produccion_Lineas
                                                      join var in db.Produccion_Variantes on l.Id equals var.Id_Linea into listVar
                                                      from v in listVar
                                                      join linmed in db.Produccion_LineasMedidas on l.Id equals linmed.Id_Linea into listLM
                                                      from lm in listLM
                                                      where l.Id_Empresa == Lista.Id_Empresa
                                                         && l.UserDel == null
                                                         && v.UserDel == null
                                                         && lm.UserDel == null
                                                      select new ListaVariantesMedidas()
                                                      {
                                                          Id_Medida = lm.Id_Medida,
                                                          Id_Variante = v.Id,
                                                          Utilidad = v.Utilidad
                                                      }).ToList();

                foreach (ListaVariantesMedidas lm in VarMed)
                {
                    decimal CostoComposicion = Composicion.Where(t => t.Id_Medida == lm.Id_Medida && t.Id_Variante == lm.Id_Variante).Select(t => t.Total).Sum();
                    decimal CostoTareas = Tareas.Where(t => t.Id_Medida == lm.Id_Medida && t.Id_Variante == lm.Id_Variante).Select(t => t.Costo).Sum();

                    decimal Utilidad = Lista.Utilidad;
                    if (lm.Utilidad > 0) Utilidad = lm.Utilidad;

                    Produccion_ListaPreciosDetalle d = new Produccion_ListaPreciosDetalle()
                    {
                        Id_ListaPrecios = Lista.Id,
                        Id_Medida = lm.Id_Medida,
                        Id_Variante = lm.Id_Variante,
                        Utilidad = Utilidad,
                        Ajuste = 0,
                        CostoComposicion = CostoComposicion,
                        CostoTareas = CostoTareas,
                        Total = ((CostoComposicion + CostoTareas) * Utilidad / 100) + (CostoComposicion + CostoTareas),
                        FechaAdd = Sistema.ObtenerFechaHora(),
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    };

                    db.Produccion_ListaPreciosDetalle.Attach(d);
                    db.Entry(d).State = EntityState.Added;
                }

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }

            if (ActualizaUtilidad)
            {
                using (var db = new ProduccionContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ActualizaUtilidad", sqlConn);

                    using (cmd)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Lista.Id);
                        System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Utilidad", Lista.Utilidad);

                        cmd.CommandTimeout = 0;

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter1);
                        cmd.Parameters.Add(Parameter2);
                        if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            if (CreaLista)
            {
                using (var db = new ProduccionContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ListaPreciosConImportesAFecha", sqlConn);

                    using (cmd)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Lista.Id);

                        cmd.CommandTimeout = 0;

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter1);
                        if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Eliminar(Produccion_ListaPrecios o)
        {
            using (var db = new ProduccionContext())
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
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.Produccion_ListaPrecios
                     join emp in db.Empresas on t.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     where (t.Id == parametros.Id || parametros.Id == null)
                      && (t.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                      && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                      && (t.VigenteDesde.Year >= parametros.AñoDesde)
                      && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         VigenteDesde = t.VigenteDesde,
                         VigenteHasta = t.VigenteHasta,
                         Id_Empresa = t.Id_Empresa,
                         Utilidad = t.Utilidad,
                         Empresa = e.Nombre,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();

                int IdListaUtilizada = db.ProductosListaPrecioActual.Where(t => t.UserDel == null).OrderByDescending(t => t.FechaAdd).Select(t => t.Id_Produccion_ListaPrecios).FirstOrDefault();

                foreach (SearchResult x in r.Where(t => t.Id == IdListaUtilizada))
                    x.EnUso = true;
                
                return r;
            }
        }

        public static void ActualizarPreciosProductos(int Id_ListaPrecio, decimal PorcentajeAdicional)
        {
            using (var db = new ProduccionContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("BajarListaPrecioProductos", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Id_ListaPrecio);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Porcentaje", PorcentajeAdicional);
                    System.Data.SqlClient.SqlParameter Parameter3 = new System.Data.SqlClient.SqlParameter("User", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    System.Data.SqlClient.SqlParameter outPutValor = new System.Data.SqlClient.SqlParameter("Resultado", System.Data.SqlDbType.Bit);
                    outPutValor.Direction = System.Data.ParameterDirection.Output;
                    System.Data.SqlClient.SqlParameter Parameter4 = outPutValor;

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    cmd.Parameters.Add(Parameter3);
                    cmd.Parameters.Add(Parameter4);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    if (!Convert.ToBoolean(outPutValor.Value))
                        throw new Exception("Error al ejecutar procedimiento.");
                }
            }
        }

        public void GenerarExcel()
        {
            List<ReporteExcel> Lineas = new List<ReporteExcel>();

            using (var db = new ProduccionContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ListaPrecioCabecera", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_ListaPrecio", Lista.Id);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    using (System.Data.IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lineas.Add(Load(dr));
                        }
                    }
                }

            }

            if (Lineas.Count <= 0)
                throw new ValidationException("No posee líneas para generar el excel.");

            //Levanto la imagen a usar en todas las hojas
            string Archivo = AppDomain.CurrentDomain.BaseDirectory + "Reportes\\LogoEmpresaId_" + Lineas[0].Id_Empresa + ".jpg";
            Bitmap bmp = new Bitmap(@Archivo);
            int Ancho = bmp.Width;
            int Alto = bmp.Height;
            bmp.Dispose();

            // Creamos un objeto Excel.
            Microsoft.Office.Interop.Excel.Application Mi_Excel = default(Microsoft.Office.Interop.Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Microsoft.Office.Interop.Excel.Workbook LibroExcel = default(Microsoft.Office.Interop.Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.
            Microsoft.Office.Interop.Excel.Worksheet HojaExcel = default(Microsoft.Office.Interop.Excel.Worksheet);

            // Iniciamos una instancia a Excel, y Hacemos visibles para ver como se va creando el reporte, 
            // podemos hacerlo visible al final si se desea.
            Mi_Excel = new Microsoft.Office.Interop.Excel.Application();
            Mi_Excel.Visible = false;
            Mi_Excel.ScreenUpdating = false;

            /* Ahora creamos un nuevo documento y seleccionamos la primera hoja del 
             * documento en la cual crearemos nuestro informe. 
             */

            // Creamos una instancia del Workbooks de excel.            
            LibroExcel = Mi_Excel.Workbooks.Add();

            // Creamos una instancia de la primera hoja de trabajo de excel            
            HojaExcel = LibroExcel.Worksheets[1];

            int Libro = 0;
            string ColAnt = "";
            int Fila = 3;
            string NombreHoja;
            string ImprimirConCodigoAnterior = "";

            foreach (ReporteExcel o in Lineas)
            {
                object missing = Type.Missing;

                //continuar en la misma hoja
                if (o.ImprimirConCodigo == ImprimirConCodigoAnterior)
                {
                    //ver nombre de hoja
                    List<string> Codigos = db.Produccion_Lineas.Where(t => t.ImprimirConCodigo == o.ImprimirConCodigo || t.Codigo == o.ImprimirConCodigo).OrderBy(t => t.Codigo).Select(t => t.Codigo).ToList();
                    NombreHoja = string.Join("-", Codigos);
                    if (NombreHoja.Length > 31)
                        HojaExcel.Name = NombreHoja.Substring(0, 31);
                    else
                        HojaExcel.Name = NombreHoja;

                    Fila += 2;
                }
                else
                {
                    if (Libro > 0)
                        HojaExcel = LibroExcel.Sheets.Add(missing, missing, 1, missing) as Microsoft.Office.Interop.Excel.Worksheet;

                    NombreHoja = o.Codigo + "-" + o.Linea.Replace("-", " ").Replace("/", " ");
                    if (NombreHoja.Length > 31)
                        HojaExcel.Name = NombreHoja.Substring(0, 31);
                    else
                        HojaExcel.Name = NombreHoja;

                    HojaExcel.PageSetup.CenterHorizontally = true;
                    HojaExcel.PageSetup.FitToPagesWide = 1;
                    HojaExcel.PageSetup.FitToPagesTall = 1;
                    HojaExcel.PageSetup.Zoom = false;

                    //******************************
                    HojaExcel.PageSetup.TopMargin = 1.2;
                    HojaExcel.PageSetup.FooterMargin = 1.2;
                    //******************************

                    HojaExcel.PageSetup.CenterFooter = "&B " + o.ListaPrecios + " &B";

                    HojaExcel.Shapes.AddPicture(@Archivo, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, Ancho, Alto);
                    HojaExcel.UsedRange.EntireRow.RowHeight = Alto;

                    Fila = 3;
                }

                HojaExcel.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                //HojaExcel.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperLegal;

                HojaExcel.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;

                //if (o.ImprimirVertical)
                //    HojaExcel.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait; 
                //else
                //    HojaExcel.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;

                System.Data.DataTable retVal;
                Libro += 1;

                using (var db = new ErsaContext())
                {
                    retVal = new System.Data.DataTable();
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    if (sqlConn.State == System.Data.ConnectionState.Closed) sqlConn.Open();
                    System.Data.SqlClient.SqlCommand cmdSql;
                    if (o.ImprimirVertical)
                        cmdSql = new System.Data.SqlClient.SqlCommand("ListaPreciosPorLineaVertical", sqlConn);
                    else
                        cmdSql = new System.Data.SqlClient.SqlCommand("ListaPreciosPorLinea", sqlConn);
                    System.Data.SqlClient.SqlDataAdapter daReport = new System.Data.SqlClient.SqlDataAdapter(cmdSql);
                    using (cmdSql)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_ListaPrecio", Lista.Id);
                        System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Id_Linea", o.Id_Linea);

                        cmdSql.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdSql.Parameters.Add(Parameter1);
                        cmdSql.Parameters.Add(Parameter2);

                        daReport.Fill(retVal);
                    }
                }

                string Col = "A";
                int CantColumnas = 0;

                ColAnt = "";

                Microsoft.Office.Interop.Excel.Range objCeldaT = HojaExcel.Range["A" + Fila, Type.Missing];
                objCeldaT.Interior.Color = ColorTranslator.ToOle(Color.Silver);
                objCeldaT.Font.Size = 14;
                objCeldaT.RowHeight = 18;
                objCeldaT.Font.Bold = true;
                objCeldaT.Value = o.Codigo + "-" + o.Linea;
                objCeldaT.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                objCeldaT.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                objCeldaT.BorderAround(missing, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, missing);

                Fila += 1;

                foreach (System.Data.DataColumn Columna in retVal.Columns)
                {
                    Microsoft.Office.Interop.Excel.Range objCelda = HojaExcel.Range[Col + Fila, Type.Missing];
                    objCelda.Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    objCelda.Font.Bold = true;

                    objCelda.WrapText = true;

                    objCelda.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    objCelda.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    objCelda.BorderAround(missing, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, missing);

                    objCelda.Value = Columna.Caption;
                    CantColumnas += 1;
                    ColAnt = Col;

                    switch (Col)
                    {
                        case "A": Col = "B"; break;
                        case "B": Col = "C"; break;
                        case "C": Col = "D"; break;
                        case "D": Col = "E"; break;
                        case "E": Col = "F"; break;
                        case "F": Col = "G"; break;
                        case "G": Col = "H"; break;
                        case "H": Col = "I"; break;
                        case "I": Col = "J"; break;
                        case "J": Col = "K"; break;
                        case "K": Col = "L"; break;
                        case "L": Col = "M"; break;
                        case "M": Col = "N"; break;
                        case "N": Col = "O"; break;
                        case "O": Col = "P"; break;
                        case "P": Col = "Q"; break;
                        case "Q": Col = "R"; break;
                        case "R": Col = "S"; break;
                        case "S": Col = "T"; break;
                        case "T": Col = "U"; break;
                        case "U": Col = "V"; break;
                        case "V": Col = "W"; break;
                        case "W": Col = "X"; break;
                        case "X": Col = "Y"; break;
                        case "Y": Col = "Z"; break;
                    }
                }

                Microsoft.Office.Interop.Excel.Range objRango = HojaExcel.Range["A" + (Fila - 1) + ":" + ColAnt + (Fila - 1)];
                if (o.ImprimirVertical)
                    objRango.Range["A3"].ColumnWidth = 35;
                else
                    objRango.Range["A3"].ColumnWidth = 9;

                objRango.MergeCells = true;
                objRango.WrapText = true;
                objRango.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, missing);

                int RowsCount = retVal.Rows.Count;
                int ColumnsCount = retVal.Columns.Count;

                object[,] Cells = new object[RowsCount, ColumnsCount];

                int j;
                for (j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        //Cells[j, i] = retVal.Rows[j][i];
                        Cells[j, i] = retVal.Rows[j][i].ToString() == "0" ? "" : retVal.Rows[j][i];

                HojaExcel.get_Range((Microsoft.Office.Interop.Excel.Range)(HojaExcel.Cells[(Fila + 1), 1]), (Microsoft.Office.Interop.Excel.Range)(HojaExcel.Cells[RowsCount + (Fila), ColumnsCount])).Value = Cells;

                objRango = HojaExcel.Range["A" + (Fila + 1) + ":A" + ((Fila + RowsCount))];
                objRango.Interior.Color = ColorTranslator.ToOle(Color.Silver);
                objRango.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                objRango.ShrinkToFit = true;
                objRango.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, missing);
                objRango.Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                objRango = HojaExcel.Range["B" + (Fila + 1) + ":" + ColAnt + ((Fila + RowsCount))];
                objRango.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, missing);
                objRango.Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                objRango.ShrinkToFit = true;
                objRango.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                objRango.ColumnWidth = 14;

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Produccion_ImprimeListaConDecimales)))
                    objRango.NumberFormat = "$ #,###,###.00";
                else
                    objRango.NumberFormat = "$ #,###,###";

                Fila += RowsCount;

                objCeldaT = HojaExcel.Range["A" + (Fila + 2), Type.Missing];
                objCeldaT.Value = o.ObservacionesImpresion;
                ImprimirConCodigoAnterior = o.ImprimirConCodigo;
            }

            Mi_Excel.Visible = true;
            Mi_Excel.ScreenUpdating = true;
        }

        private static ReporteExcel Load(System.Data.IDataRecord dr)
        {
            ReporteExcel o = new ReporteExcel();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Id_Empresa": o.Id_Empresa = dr.GetInt32(i); break;
                        case "Codigo": o.Codigo = dr.GetString(i); break;
                        case "Id_Linea": o.Id_Linea = dr.GetInt32(i); break;
                        case "Id_ListaPrecios": o.Id_ListaPrecios = dr.GetInt32(i); break;
                        case "ImprimirConCodigo": o.ImprimirConCodigo = dr.GetString(i); break;
                        case "ImprimirVertical": o.ImprimirVertical = dr.GetBoolean(i); break;
                        case "Linea": o.Linea = dr.GetString(i); break;
                        case "ListaPrecios": o.ListaPrecios = dr.GetString(i); break;
                        case "ObservacionesImpresion": o.ObservacionesImpresion = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                AñoDesde = Sistema.ObtenerFecha().Year;
            }
            public int? Id { get; set; }
            public int? Id_Empresa { get; set; }
            public int AñoDesde { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Produccion_ListaPrecios
        {
            private DateTime Fecha = Sistema.ObtenerFecha();
            public string Empresa { get; set; }
            public bool Vigente { get { if (VigenteDesde <= Fecha && VigenteHasta >= Fecha) return true; else return false; } }
            public bool EnUso { get; set; }
        }

        public class ListaVariantesMedidas
        {
            public int Id_Variante { get; set; }
            public int Id_Medida { get; set; }
            public decimal Utilidad { get; set; }
        }

        public class ReporteExcel
        {
            public int Id_Empresa { get; set; }
            public int Id_Linea { get; set; }
            public int Id_ListaPrecios { get; set; }
            public string ListaPrecios { get; set; }
            public string Linea { get; set; }
            public string Codigo { get; set; }
            public string ImprimirConCodigo { get; set; }
            public string ObservacionesImpresion { get; set; }
            public bool ImprimirVertical { get; set; }

        }
    }
}