using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace VENET_Contabilidad_UI
{
    public static class InformeContable
    {
        public static byte[] Exportar(string titulo, IEnumerable filas, string formato)
        {
            if (formato != "pdf" && formato != "xlsx") throw new ValidationException("Formato admitido: PDF o XLSX.");
            var valores = filas.Cast<object>().ToList();
            if (valores.Count > 2000) throw new ValidationException("Reduzca el periodo del informe (maximo 2000 filas).");
            var tabla = new DataTable("Contabilidad");
            if (valores.Count > 0)
            {
                var propiedades = valores[0].GetType().GetProperties().Where(p => p.CanRead &&
                    (p.PropertyType.IsValueType || p.PropertyType == typeof(string))).ToList();
                foreach (var p in propiedades) tabla.Columns.Add(p.Name, (Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType).IsEnum ? typeof(string) : Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                foreach (var fila in valores)
                    tabla.Rows.Add(propiedades.Select(p =>
                    {
                        var valor = p.GetValue(fila);
                        if (valor is Enum) return valor.ToString();
                        if (valor is string texto && texto.Length > 0 && "=+-@".Contains(texto[0]))
                            return "'" + texto;
                        return valor ?? DBNull.Value;
                    }).ToArray());
            }
            else tabla.Columns.Add("SinMovimientos", typeof(string));
            using (var informe = new XtraReport { DataSource = tabla, Landscape = true, PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3 })
            {
                var encabezado = new ReportHeaderBand { HeightF = 55 };
                encabezado.Controls.Add(new XRLabel { Text = titulo, WidthF = 1300, HeightF = 45, Font = new Font("Arial", 14, FontStyle.Bold) });
                informe.Bands.Add(encabezado);
                var cabecera = new PageHeaderBand { HeightF = 30 };
                var detalle = new DetailBand { HeightF = 30 };
                float ancho = 1400f / tabla.Columns.Count;
                var tablaCabecera = new XRTable { WidthF = 1400, HeightF = 30 };
                var tablaDetalle = new XRTable { WidthF = 1400, HeightF = 30 };
                var titulos = new XRTableRow(); var datos = new XRTableRow();
                foreach (DataColumn c in tabla.Columns)
                {
                    titulos.Cells.Add(new XRTableCell { Text = c.ColumnName, WidthF = ancho, Font = new Font("Arial", 8, FontStyle.Bold) });
                    var celda = new XRTableCell { WidthF = ancho, Font = new Font("Arial", 8) };
                    celda.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[" + c.ColumnName + "]"));
                    if (c.DataType == typeof(decimal)) celda.TextFormatString = "{0:n2}";
                    if (c.DataType == typeof(DateTime)) celda.TextFormatString = "{0:yyyy-MM-dd}";
                    datos.Cells.Add(celda);
                }
                tablaCabecera.Rows.Add(titulos); tablaDetalle.Rows.Add(datos);
                cabecera.Controls.Add(tablaCabecera); detalle.Controls.Add(tablaDetalle);
                informe.Bands.Add(cabecera); informe.Bands.Add(detalle);
                var pie = new PageFooterBand { HeightF = 25 };
                pie.Controls.Add(new XRPageInfo { WidthF = 1400, HeightF = 25, PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal });
                informe.Bands.Add(pie);
                using (var stream = new MemoryStream())
                {
                    if (formato == "pdf") informe.ExportToPdf(stream);
                    else informe.ExportToXlsx(stream, new DevExpress.XtraPrinting.XlsxExportOptions
                    {
                        TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value,
                        RawDataMode = true
                    });
                    return stream.ToArray();
                }
            }
        }
    }
}
