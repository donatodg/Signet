namespace VENET_Gestion_BL
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
    using static ComprobantesVentasDetalleManager;

    public class ComprobantesVentasAProcesarManager : IDisposable
    {
        private GestionContext db;
        public ComprobantesVentasAProcesar AProcesar { get; set; }

        public ComprobantesVentasAProcesarManager(ComprobantesVentasAProcesar o)
        {
            db = new GestionContext();
            AProcesar = o;
            AProcesar.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);

            db.ComprobantesVentasAProcesar.Attach(AProcesar);

            if (AProcesar.Id > 0)
                db.Entry(AProcesar).Reload();
            else
                AProcesar.Fecha = Sistema.ObtenerFecha();
        }

       // public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString() }).ToList()); } }
       //public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString().Replace(".", ",") }).ToList()); } }
        public List<KeyNameDecimalPair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNameDecimalPair() { Key = t.Id, Name = t.Alicuota }).ToList()); } }

        public List<ProductosBusqueda> Productos { get { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } }
        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new GestionContext())
                    return Sistema.ObtenerEntidades(AProcesar.Id_TipoEntidad);
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Id_Producto")
            {
                Productos p = new Productos();
                if (AProcesar.Id_Producto > 0)
                {
                    using (GestionContext db = new GestionContext())
                    {
                        p.Id = AProcesar.Id_Producto.Value;
                        db.Productos.Attach(p);
                        db.Entry(p).Reload();
                    }

                    AProcesar.Id_AlicuotaIva = p.Id_IvaAlicuota;
                    AProcesar.Id_Especie = p.Id_Especie;
                    AProcesar.ImporteUnitario = p.Importe;
                    AProcesar.Descripcion = p.Descripcion;
                    AProcesar.ImporteCosto = p.ImporteCosto;
                }
            }
            if (e.PropertyName == "Id_Especie")
            {
                using (GestionContext db = new GestionContext())
                {
                    AProcesar.Cotizacion = db.Especies.Where(t => t.Id == AProcesar.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
                }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (AProcesar.Id == 0)
            {
                db.Entry(AProcesar).State = EntityState.Added;
                AProcesar.FechaAdd = Sistema.ObtenerFechaHora();
                AProcesar.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(AProcesar).State = EntityState.Modified;
                AProcesar.FechaMod = Sistema.ObtenerFechaHora();
                AProcesar.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ComprobantesVentasAProcesar o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from a in db.ComprobantesVentasAProcesar
                     where (a.Id == parametros.Id || parametros.Id == null)
                        && ((a.Id_ComprobanteVenta == null && parametros.Pendientes) || (a.Id_ComprobanteVenta != null && parametros.Pendientes == false) || parametros.Id != null)
                        && (a.Id_TipoEntidad == parametros.TipoEntidad || parametros.TipoEntidad == null)
                        && (a.UserDel == null)
                     select new SearchResult()
                     {
                         Id = a.Id,
                         Fecha = a.Fecha,
                         Id_TipoEntidad = a.Id_TipoEntidad,
                         AlicuotaIva = a.AlicuotaIva,
                         Cantidad = a.Cantidad,
                         Descripcion = a.Descripcion,
                         Id_Especie = a.Id_Especie,
                         Id_AlicuotaIva = a.Id_AlicuotaIva,
                         Id_ComprobanteVenta = a.Id_ComprobanteVenta,
                         Id_Entidad = a.Id_Entidad,
                         Id_Producto = a.Id_Producto,
                         Importe = a.Importe,
                         ImporteCosto = a.ImporteCosto,
                         ImporteIVA = a.ImporteIVA,
                         ImporteUnitario = a.ImporteUnitario,
                         PorcDescuento = a.PorcDescuento,
                         Nombre_Entidad = a.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == a.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : a.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == a.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : a.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                        join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                        from prov in listPF
                                                                                                        where pfc.Id == a.Id_Entidad
                                                                                                        select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : a.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == a.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         FechaAdd = a.FechaAdd,
                         FechaMod = a.FechaMod,
                         UserAdd = a.UserAdd,
                         UserMod = a.UserMod
                     }).ToList();

                return r;
            }
        }

        public static void ProcesarPendientes()
        {
            using (var db = new GestionContext())
            {
                DateTime f = Sistema.ObtenerFechaHora();
                int _User = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                decimal _Cotizacion = 0;
                int _Id_Deposito = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Deposito));
                int _Id_CentroCosto = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_CentroCosto));
                int _Id_FormaPago = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_FormaPago));
                int _Id_Sucursal = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Sucursal));
                int _Id_TipoComprobante = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_TipoComprobante));
                int _Id_Vendedor = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.DefaultPendientesAProcesar_Id_Vendedor));

                decimal _Importe;

                foreach (int IdEntidad in db.ComprobantesVentasAProcesar.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == null).Select(t => t.Id_Entidad).Distinct().ToList())
                {
                    ComprobantesVentas o = new ComprobantesVentas()
                    {
                        Id_Deposito = _Id_Deposito,
                        Id_Entidad = IdEntidad,
                        Fecha = f,
                        FechaAdd = f,
                        FechaEntrega = f,
                        FechaVto = f,
                        Id_CentroCosto = _Id_CentroCosto,
                        Id_FormaPago = _Id_FormaPago,
                        Id_Sucursal = _Id_Sucursal,
                        Id_TipoComprobante = _Id_TipoComprobante,
                        Id_TipoEntidad = Enums.TipoEntidad.Proveedor,
                        Id_Vendedor = _Id_Vendedor,
                        UserAdd = _User,
                        Id_TalonariosComprobantes = Sistema.ObtenerTalonario(_Id_Sucursal, _Id_TipoComprobante, Enums.TipoEntidad.Proveedor, IdEntidad).First().Key, //VER
                        //Letra = "",
                        //NroComprobante = "0",
                        //PuntoVenta = ""
                        Observaciones = "-",
                        PercepcionIIBB = 0,
                        PercepcionIva = 0,
                        OtrosImpuestos = 0,
                        Retenciones = 0
                    };

                    TalonariosComprobantesDetalle tcd = (from d in db.TalonariosComprobantesDetalle
                                                         where d.Id_TalonarioComprobante == o.Id_TalonariosComprobantes
                                                               && d.FechaVencimiento >= f
                                                               && d.NroActual < d.NroHasta
                                                         orderby d.NroDesde
                                                         select d).FirstOrDefault();

                    if (tcd != null)
                    {
                        db.TalonariosComprobantesDetalle.Attach(tcd);
                        tcd.NroActual += 1;

                        TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                        o.Letra = tc.Letra;
                        o.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                        o.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                    }
                    else
                    {
                        throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                    }

                    _Importe = 0;

                    foreach (ComprobantesVentasAProcesar p in db.ComprobantesVentasAProcesar.Where(t => t.UserDel == null && t.Id_ComprobanteVenta == null && t.Id_Entidad == o.Id_Entidad).ToList())
                    {
                        _Importe += p.Importe;
                        _Cotizacion = p.Cotizacion;

                        if (o.Detalle == null) o.Detalle = new List<ComprobantesVentasDetalle>();

                        ComprobantesVentasDetalle d = new ComprobantesVentasDetalle()
                        {
                            AlicuotaIva = p.AlicuotaIva,
                            Cantidad = p.Cantidad,
                            Cotizacion = p.Cotizacion,
                            Descripcion = p.Descripcion,
                            Importe = p.Importe,
                            FechaAdd = f,
                            Id_AlicuotaIva = p.Id_AlicuotaIva,
                            Id_Especie = p.Id_Especie,
                            Id_Producto = p.Id_Producto,
                            ImporteCosto = p.ImporteCosto,
                            ImporteIVA = p.ImporteIVA,
                            ImporteUnitario = p.ImporteUnitario,
                            PorcDescuento = p.PorcDescuento,
                            UserAdd = _User
                        };
                        db.Entry(d).State = EntityState.Added;
                        o.Detalle.Add(d);

                        p.Id_ComprobanteVenta = o.Id;

                    }

                    o.Importe = _Importe;
                    o.ImportePesos = _Importe * _Cotizacion;

                    db.ComprobantesVentas.Attach(o);
                    db.Entry(o).State = EntityState.Added;

                    var err = db.GetValidationErrors();
                    if (err.Count() > 0)
                        throw new ValidationException(
                            (from e in err
                             from er in e.ValidationErrors
                             select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                    db.SaveChanges();
                }
            }
        }

        public static void GenerarModeloExcel()
        {
            // Creamos un objeto Excel.
            Microsoft.Office.Interop.Excel.Application Mi_Excel = default(Microsoft.Office.Interop.Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Microsoft.Office.Interop.Excel.Workbook LibroExcel = default(Microsoft.Office.Interop.Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.
            Microsoft.Office.Interop.Excel.Worksheet HojaExcel = default(Microsoft.Office.Interop.Excel.Worksheet);

            // Iniciamos una instancia a Excel, y Hacemos visibles para ver como se va creando el reporte, 
            // podemos hacerlo visible al final si se desea.
            Mi_Excel = new Microsoft.Office.Interop.Excel.Application();
            Mi_Excel.Visible = true;

            /* Ahora creamos un nuevo documento y seleccionamos la primera hoja del 
             * documento en la cual crearemos nuestro informe. 
             */
            // Creamos una instancia del Workbooks de excel.            
            LibroExcel = Mi_Excel.Workbooks.Add();
            // Creamos una instancia de la primera hoja de trabajo de excel            
            HojaExcel = LibroExcel.Worksheets[1];
            HojaExcel.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible;

            // Hacemos esta hoja la visible en pantalla 
            // (como seleccionamos la primera esto no es necesario
            // si seleccionamos una diferente a la primera si lo
            // necesitariamos).
            //HojaExcel.Activate();

            Microsoft.Office.Interop.Excel.Range objCelda = HojaExcel.Range["A1", Type.Missing];
            objCelda.Value = "Cod.Prov.Tango";

            objCelda = HojaExcel.Range["B1", Type.Missing];
            objCelda.Value = "Cod.Artículo";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Importe";

            Microsoft.Office.Interop.Excel.Range objRango = HojaExcel.Range["A1:C1"];
            objRango.Select();

            objRango.Columns.AutoFit();

            Mi_Excel.Visible = true;
        }

        public static void ImportarExcel(string file)
        {
            string Extension = System.IO.Path.GetExtension(file);

            string conStr = "";

            switch (Extension)
            {
                //case ".xls":
                //    //Excel 97-03 
                //    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR=yes'";
                //    break;
                case ".xlsx":
                    //Excel 07 
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 12.0 Macro;HDR=YES'";
                    break;
            }
            conStr = string.Format(conStr, file);

            System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(conStr);
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
            System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter();

            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            System.Data.DataTable Dt = new System.Data.DataTable();

            dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(Dt);

            connExcel.Close();

            DateTime f = Sistema.ObtenerFecha();

            using (var db = new GestionContext())
            {
                foreach (System.Data.DataRow r in Dt.Rows)
                {
                    if (r[0].ToString() == "" || r[1].ToString() == "" || r[2].ToString() == "")
                    {
                        Sistema.Mensaje("Hay inconsistencia en los datos ingresados en el Excel. Por favor verifique que esten completas todas las celdas.");
                        return;
                    }

                    string CodTango = r[0].ToString();
                    string CodArticulo = r[1].ToString();
                    decimal Importe = Convert.ToDecimal(r[2].ToString() == "" ? "0" : r[2].ToString());

                    //Setear los valores
                    int IdEntidad = (from p in db.Proveedores where (p.CodTango == CodTango && p.UserDel == null) select (p.Id)).FirstOrDefault();
                    if (IdEntidad == 0)
                    {
                        Sistema.Mensaje(string.Format("No se encontro el proveedor {0}.", CodTango));
                        return;
                    }

                    Productos prod = (from p in db.Productos where (p.Codigo == CodArticulo && p.UserDel == null) select (p)).FirstOrDefault();
                    if (prod.Id == 0)
                    {
                        Sistema.Mensaje(string.Format("No se encontro el producto {0}.", CodArticulo));
                        return;
                    }

                    decimal Alicuota = (db.IvaAlicuotas.Where(t => t.Id == prod.Id_IvaAlicuota).Select(t => t.Alicuota).FirstOrDefault());

                    ComprobantesVentasAProcesar a = new ComprobantesVentasAProcesar()
                    {
                        Id_Especie = 1,
                        Cotizacion = 1,
                        Id_TipoEntidad = Enums.TipoEntidad.Proveedor,
                        Cantidad = 1,
                        Id_Entidad = IdEntidad,
                        Id_Producto = prod.Id,
                        Importe = Importe + (Importe * Alicuota / 100),
                        ImporteCosto = prod.ImporteCosto,
                        Id_AlicuotaIva = prod.Id_IvaAlicuota,
                        AlicuotaIva = Alicuota,
                        ImporteIVA = Importe * Alicuota / 100,
                        ImporteUnitario = Importe,
                        PorcDescuento = 0,
                        Fecha = f,
                        Descripcion = prod.Descripcion,
                        FechaAdd = Sistema.ObtenerFechaHora(),
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    };

                    db.Entry(a).State = EntityState.Added;
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Pendientes = true;
            }
            public int? Id { get; set; }
            public bool Pendientes { get; set; }
            public Enums.TipoEntidad? TipoEntidad { get; set; }
            public DateTime? FechaDesde { get; set; }
        }

        public class SearchResult : ComprobantesVentasAProcesar
        {
            public string Nombre_Entidad { get; set; }
        }

    }
}
