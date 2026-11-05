namespace VENET_Gestion_BL
{
    using OfficeOpenXml;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
    using OfficeOpenXml.Style;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Windows.Documents;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ProductosManager : IDisposable
    {
        private GestionContext db;
        public Productos Producto { get; set; }

        public ProductosManager(Productos o)
        {
            db = new GestionContext();
            Producto = o;

            db.Productos.Attach(o);

            if (Producto.Id > 0) db.Entry(Producto).Reload();
            else
            {
                Producto.Id_Categoria = Categorias.First().Key;
                Producto.Id_IvaAlicuota = Alicuotas.First().Key;
                Producto.Id_UnidadCompra = UnidadesVenta.First().Key;
                Producto.Id_UnidadVenta = UnidadesVenta.First().Key;
                Producto.Id_Especie = Sistema.Especies.First().Key;
                Producto.ImporteCosto = 0;
                Producto.Equivalencia = 1;
            }
        }

        public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }
        public List<KeyNamePair> Categorias { get { return (db.ProductosCategorias.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }
        public List<KeyNamePair> Categorias2 { get { return (db.ProductosCategorias2.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }
        public List<KeyNamePair> UnidadesVenta { get { return (db.ProductosUnidadVenta.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }

        public string EspecieSigla { get { return (db.Especies.Where(t => t.UserDel == null && t.Id == Producto.Id_EspecieCosto).Select(t => t.Sigla).FirstOrDefault()); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Producto.Id_UnidadStock == Producto.Id_UnidadVenta)
                Producto.Id_UnidadStock = null;

            if (Producto.Id == 0)
            {
                db.Entry(Producto).State = EntityState.Added;

                Producto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Producto.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Producto).State = EntityState.Modified;
                Producto.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Producto.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Productos o)
        {
            using (var db = new GestionContext())
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
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Productos
                     join a in db.IvaAlicuotas on p.Id_IvaAlicuota equals a.Id into listAlic
                     from alic in listAlic
                     join c in db.ProductosCategorias on p.Id_Categoria equals c.Id into listCat
                     from cat in listCat
                     join c2 in db.ProductosCategorias2 on p.Id_Categoria2 equals c2.Id into listCat2
                     from cat2 in listCat2.DefaultIfEmpty()
                     join u in db.ProductosUnidadVenta on p.Id_UnidadVenta equals u.Id into listUV
                     from uv in listUV
                     join u in db.ProductosUnidadVenta on p.Id_UnidadCompra equals u.Id into listUC
                     from uc in listUC
                     join esp in db.Especies on p.Id_Especie equals esp.Id into listEsp
                     from e in listEsp
                     join espo in db.Especies on p.Id_EspecieOriginal equals espo.Id into listEspOrig
                     from eo in listEspOrig.DefaultIfEmpty()
                     join espcos in db.Especies on p.Id_EspecieCosto equals espcos.Id into listEspCos
                     from ec in listEspCos.DefaultIfEmpty()
                     join uniStock in db.ProductosUnidadVenta on p.Id_UnidadStock equals uniStock.Id into listUniStock
                     from us in listUniStock.DefaultIfEmpty()
                     where (p.Id == parametros.Id || parametros.Id == null)
                            && (p.Codigo.Contains(parametros.Codigo) || parametros.Codigo == null)
                            && (p.CodigoFabrica.Contains(parametros.CodigoFabrica) || parametros.CodigoFabrica == null)
                            && (p.CodigoBarras.Contains(parametros.CodigoBarras) || parametros.CodigoBarras == null)
                            && (p.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (p.UserDel == null)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Codigo = p.Codigo,
                         CodigoFabrica = p.CodigoFabrica,
                         Descripcion = p.Descripcion,
                         Id_IvaAlicuota = p.Id_IvaAlicuota,
                         Id_Categoria = p.Id_Categoria,
                         Id_Categoria2 = p.Id_Categoria2,
                         Id_UnidadVenta = p.Id_UnidadVenta,
                         Id_UnidadCompra = p.Id_UnidadCompra,
                         Id_Especie = p.Id_Especie,
                         Especie = e.Descripcion,
                         Importe = p.Importe,
                         Id_EspecieOriginal = p.Id_EspecieOriginal,
                         EspecieOriginal = eo.Descripcion,
                         ImporteOriginal = p.ImporteOriginal,
                         ImporteCosto = p.ImporteCosto,
                         FechaActualizacionCosto = p.FechaActualizacionCosto,
                         Id_EspecieCosto = p.Id_EspecieCosto,
                         EspecieCosto = ec.Descripcion,
                         CodigoBarras = p.CodigoBarras,
                         StockMinimo = p.StockMinimo,
                         StockMaximo = p.StockMaximo,
                         Observaciones = p.Observaciones,
                         Alicuota = alic.Alicuota,
                         Categoria = cat.Descripcion,
                         Categoria2 = cat2.Descripcion,
                         UnidadVenta = uv.Descripcion,
                         UnidadCompra = uc.Descripcion,
                         Equivalencia = p.Equivalencia,
                         Id_UnidadStock = p.Id_UnidadStock,
                         UnidadStock = us.Descripcion,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod
                     }).ToList();

                if (parametros.OrdenadoPorIdCategoria)
                {
                    List<SearchResult> re = new List<SearchResult>();
                    foreach (SearchResult x in r)
                    {
                        //x.Categoria =  (100 + x.Id_Categoria) + " - " + x.Categoria;
                        x.Categoria = x.Id_Categoria.ToString("000") + " - " + x.Categoria;
                        re.Add(x);
                    }

                    return re;
                }
                else
                    return r;
            }

        }

        public static void ActualizacionCostos()
        {
            List<int> ListaProductos = new List<int>();

            using (var db = new GestionContext())
            {
                ListaProductos = (db.ProductosComposicion.Where(t => t.UserDel == null).Select(t => t.Id_ProductoFinal).Distinct()).ToList();
            }

            foreach (int o in ListaProductos)
                ProductosComposicion_AddModManager.ActualizarCostoProducto(new Productos() { Id = o });
        }

        public static void ActualizarImporteSeguncotizacion(int Id_EspecieOriginal, decimal Cotizacion)
        {
            GestionContext db1 = new GestionContext();

            using (var db = new GestionContext())
            {
                var query = from p in db.Productos
                            where p.Id_EspecieOriginal == Id_EspecieOriginal &&
                                  p.ImporteOriginal > 0 &&
                                  p.UserDel == null
                            select p;

                foreach (Productos p in query)
                {
                    db1.Productos.Attach(p);
                    db.Entry(p).State = EntityState.Modified;

                    p.Importe = (decimal)p.ImporteOriginal * Cotizacion;

                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    p.FechaMod = Sistema.ObtenerFechaHora();
                }

                var err = db1.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db1.SaveChanges();

                var query2 = (from pld in db.ProductosListasPreciosDetalle
                              where pld.Id_EspecieOriginal == Id_EspecieOriginal &&
                              pld.ImporteOriginal > 0
                              select pld);
                foreach (ProductosListasPreciosDetalle ld in query2)
                {
                    db1.ProductosListasPreciosDetalle.Attach(ld);
                    db.Entry(ld).State = EntityState.Modified;

                    ld.Importe = (decimal)ld.ImporteOriginal * Cotizacion;

                    ld.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    ld.FechaMod = Sistema.ObtenerFechaHora();
                }

                var err1 = db1.GetValidationErrors();
                if (err1.Count() > 0)
                    throw new ValidationException(
                        (from e in err1
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db1.SaveChanges();
            }
        }

        public static void ActualizardesdeExcel(string FilePath, bool ImporteVenta = true)
        {
            int Id_Producto;
            decimal ImporteNuevoVenta;
            decimal ImporteNuevoCosto;
            bool PuedeConvertir;

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)  //la primera fila es Titulos
                {
                    PuedeConvertir = int.TryParse(worksheet.Cells[row, 1].Value?.ToString().Trim(), out Id_Producto);
                    if (!PuedeConvertir)
                    {
                        throw new ValidationException("La celda A" + row.ToString() + " no contiene un número de ID válido.");
                    }
                    PuedeConvertir = decimal.TryParse(worksheet.Cells[row, 5].Value?.ToString().Trim(), out ImporteNuevoVenta);
                    if (!PuedeConvertir)
                    {
                        throw new ValidationException("La celda E" + row.ToString() + " no contiene un importe válido.");
                    }
                    PuedeConvertir = decimal.TryParse(worksheet.Cells[row, 6].Value?.ToString().Trim(), out ImporteNuevoCosto);
                    if (!PuedeConvertir)
                    {
                        throw new ValidationException("La celda F" + row.ToString() + " no contiene un importe válido.");
                    }

                    Productos o = new Productos() { Id = Id_Producto };
                    using (var db = new GestionContext())
                    {
                        db.Entry(o).State = EntityState.Modified;
                        db.Entry(o).Reload();

                        if (o.UserAdd == 0)
                            throw new ValidationException("No existe el producto Id " + Id_Producto.ToString());

                        if (ImporteVenta)
                            o.Importe = ImporteNuevoVenta;
                        else
                            o.ImporteCosto = ImporteNuevoCosto;

                        db.SaveChanges();
                    }

                }
            }
        }

        public static void GeneraExcelModelo(string file)
        {
            using (var db = new GestionContext())
            {
                var selectdata = (from p in db.Productos
                                  join cat in db.ProductosCategorias on p.Id_Categoria equals cat.Id into listCat
                                  from c in listCat.DefaultIfEmpty()
                                  where p.UserDel == null
                                  select new
                                  {
                                      Id = p.Id,
                                      Codigo = p.Codigo,
                                      Descripcion = p.Descripcion,
                                      Categoria = c.Descripcion,
                                      Precio_Venta = p.Importe,
                                      Precio_Costo = p.ImporteCosto
                                  }
                                  ).ToList();

                int TipoOrden = int.Parse(Parametro.ObtenerValor(Parametro.Param.Excel_ModeloProductosPrecios));

                switch (TipoOrden)
                {
                    case 1:
                        selectdata = selectdata.OrderBy(t => t.Id).ToList();
                        break;
                    case 2:
                        selectdata = selectdata.OrderBy(t => t.Codigo).ToList();
                        break;
                    case 3:
                        selectdata = selectdata.OrderBy(t => t.Descripcion).ToList();
                        break;
                    case 4:
                        selectdata = selectdata.OrderBy(t => t.Categoria).ToList();
                        break;
                }

                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Precios");
                workSheet.TabColor = Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Cells[1, 1].Value = "Id";
                workSheet.Cells[1, 2].Value = "Codigo";
                workSheet.Cells[1, 3].Value = "Descripcion";
                workSheet.Cells[1, 4].Value = "Categoria";
                workSheet.Cells[1, 5].Value = "Importe Venta";
                workSheet.Cells[1, 6].Value = "Importe Costo";
                workSheet.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#B4C6E7"));

                workSheet.Cells["A2"].LoadFromCollection(selectdata);

                workSheet.Cells["A:F"].AutoFitColumns();

                FileStream objFileStrm = File.Create(file);
                objFileStrm.Close();
                File.WriteAllBytes(file, excel.GetAsByteArray());
                excel.Dispose();
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
            public bool OrdenadoPorIdCategoria { get; set; }
        }

        public class SearchResult : Productos
        {
            public decimal Alicuota { get; set; }
            public string Categoria { get; set; }
            public string Categoria2 { get; set; }
            public string UnidadVenta { get; set; }
            public string UnidadCompra { get; set; }
            public string UnidadStock { get; set; }
            public string Especie { get; set; }
            public string EspecieOriginal { get; set; }
            public string EspecieCosto { get; set; }
            public string Ganacia { get { if (ImporteCosto > 0) return ((Importe * 100 / ImporteCosto) - 100).ToString("n") + "%"; else return "100%"; } }
        }
    }
}
