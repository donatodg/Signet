namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.OleDb;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ListaPagosManager : IDisposable
    {
        private TesoreriaContext db;
        public ListaPagos Lista { get; set; }

        public ListaPagosManager(ListaPagos o)
        {
            db = new TesoreriaContext();
            Lista = o;

            db.ListaPagos.Attach(Lista);

            if (Lista.Id > 0)
            {
                db.Entry(Lista).Reload();

                if (Lista.Detalle == null)
                    db.Entry(Lista).Collection(p => p.Detalle).Load();

                if (Lista.Detalle.Count > 0)
                {
                    foreach (ListaPagosDetalle row in Lista.Detalle)
                    {
                        row.Entidad = Sistema.GetNombreEntidad(Lista.Id_TipoEntidad, row.Id_Entidad);
                    }
                }
            }
            else
            {
                Lista.Fecha = Sistema.ObtenerFechaHora();
                if (Sistema.CentrosCostos.Count() > 0) Lista.Id_CentroCosto = Sistema.CentrosCostos.First().Key;
                if (Sistema.Sucursales.Count() > 0) Lista.Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
                if (Sistema.Especies.Count() > 0) Lista.Id_Especie = Sistema.Especies.First().Key;
                Lista.Sentido = Enums.TipoMovimiento.Credito;

                Lista.Id_TipoEntidad = Enums.TipoEntidad.Personal;

                db.Entry(Lista).Collection(p => p.Detalle).Load();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Lista.Detalle.Count == 0)
                throw new ValidationException("No se ingresó el detalle de la lista.");

            if (Lista.Id == 0)
            {
                db.Entry(Lista).State = EntityState.Added;
                Lista.FechaAdd = Sistema.ObtenerFechaHora();
                Lista.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                Lista.Numero = db.ListaPagos.Where(t => t.Id_Sucursal == Lista.Id_Sucursal && t.UserDel == null).OrderByDescending(t => t.Numero).Select(t => t.Numero).FirstOrDefault() + 1;
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

        }

        public static void Eliminar(ListaPagos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar una lista anulada.");
                if (o.FechaConfirmacion != null) throw new ValidationException("No se puede eliminar una lista confirmada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static void Confirmar(ListaPagos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar una lista anulada.");
                if (o.FechaConfirmacion != null) throw new ValidationException("No se puede confirmar una lista confirmada.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaConfirmacion = o.FechaMod = Sistema.ObtenerFechaHora();

                foreach (ListaPagosDetalle lpd in o.Detalle)
                {
                    if (lpd.Descripcion == "")
                        lpd.Descripcion = o.Descripcion;
                    else
                        lpd.Descripcion = o.Descripcion + " - " + lpd.Descripcion;

                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("LP {0} - {1}", o.Numero, lpd.Descripcion),
                        Fecha = o.Fecha,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = lpd.Id_Entidad,
                        Id_Especie = o.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.ListaPago,
                        Id_TipoEntidad = o.Id_TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };

                    if (o.Sentido == Enums.TipoMovimiento.Credito)
                        encc.Credito = lpd.Importe;
                    else
                        encc.Debito = lpd.Importe;

                    db.EntidadesCtaCte.Add(encc);
                }

                db.SaveChanges();
            }
        }

        public static void Anular(ListaPagos o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("La lista ya se encuentra anulada.");
                if (o.FechaConfirmacion == null) throw new ValidationException("No se puede anular una lista sin liquidar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaAnulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.MotivoAnulacion = MotivoAnulacion;

                foreach (ListaPagosDetalle lpd in o.Detalle)
                {
                    if (lpd.Descripcion == "")
                        lpd.Descripcion = o.Descripcion;
                    else
                        lpd.Descripcion = o.Descripcion + " - " + lpd.Descripcion;

                    EntidadesCtaCte encc = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("Anulación LP {0} - {1}", o.Numero, lpd.Descripcion),
                        Fecha = (DateTime)o.FechaAnulacion,
                        FechaAdd = (DateTime)o.FechaAnulacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = lpd.Id_Entidad,
                        Id_Especie = o.Id_Especie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.ListaPago,
                        Id_TipoEntidad = o.Id_TipoEntidad,
                        UserAdd = (int)o.UserMod
                    };

                    if (o.Sentido == Enums.TipoMovimiento.Debito)
                        encc.Credito = lpd.Importe;
                    else
                        encc.Debito = lpd.Importe;

                    db.EntidadesCtaCte.Add(encc);
                }

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from l in db.ListaPagos
                     join c in db.CentrosCostos on l.Id_CentroCosto equals c.Id into listCC
                     from cen in listCC.DefaultIfEmpty()
                     join s in db.Sucursales on l.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where (l.Id == parametros.Id || parametros.Id == null)
                     && (l.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                     && (l.Fecha >= parametros.Fecha_Desde && l.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                     && ((l.FechaAnulacion == null && parametros.Anulado == false) || (l.FechaAnulacion != null && parametros.Anulado == true) || parametros.Id != null)
                     && (l.UserDel == null)
                     select new SearchResult()
                     {
                         Id = l.Id,
                         Id_Sucursal = l.Id_Sucursal,
                         Id_CentroCosto = l.Id_CentroCosto,
                         Numero = l.Numero,
                         Fecha = l.Fecha,
                         Id_TipoEntidad = l.Id_TipoEntidad,
                         Id_Especie = l.Id_Especie,
                         Sentido = l.Sentido,
                         Descripcion = l.Descripcion,
                         FechaConfirmacion = l.FechaConfirmacion,
                         FechaAnulacion = l.FechaAnulacion,
                         MotivoAnulacion = l.MotivoAnulacion,
                         FechaAdd = l.FechaAdd,
                         FechaMod = l.FechaMod,
                         UserAdd = l.UserAdd,
                         UserMod = l.UserMod,
                         Sucursal = suc.Descripcion,
                         Centro_Costo = cen.Descripcion,
                         Importe = db.ListaPagosDetalle.Where(d => d.Id_ListaPago == l.Id && d.UserDel == null).Select(d => d.Importe).Sum()
                     }).ToList();

                return r;
            }
        }

        public static string GetEspecie(int Id_Especie)
        {
            using (var db = new TesoreriaContext())
            {
                return db.Especies.Where(t => t.Id == Id_Especie).Select(t => t.Descripcion).FirstOrDefault();
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
            objCelda.Value = "Legajo";

            objCelda = HojaExcel.Range["B1", Type.Missing];
            objCelda.Value = "Importe";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Descripción";

            Microsoft.Office.Interop.Excel.Range objRango = HojaExcel.Range["A1:C1"];
            objRango.Select();

            objRango.Columns.AutoFit();

            Mi_Excel.Visible = true;
        }

        public static void GenerarOP(ListaPagos o)
        {
            try
            {
                ListaPagos Lista = o;
                DateTime f = Sistema.ObtenerFechaHora();

                using (var db = new TesoreriaContext())
                {
                    db.ListaPagos.Attach(Lista);
                    db.Entry(Lista).Reload();

                    if (Lista.Detalle == null)
                        db.Entry(Lista).Collection(p => p.Detalle).Load();

                    db.Entry(Lista).State = EntityState.Modified;

                    if (Lista.GeneroOP == null)
                        Lista.GeneroOP = 0;
                    //    throw new ValidationException("Ya se generaron las ordenes de pago para la lista seleccionada.");


                    foreach (ListaPagosDetalle d in Lista.Detalle.Where(t => t.Id > Lista.GeneroOP).OrderBy(t => t.Id))
                    {
                        OrdenesPago op = new OrdenesPago();

                        db.OrdenesPago.Attach(op);
                        db.Entry(op).Collection(p => p.Detalle).Load();

                        db.Entry(op).State = EntityState.Added;

                        if (d.Descripcion != "")
                            op.Concepto = string.Format("LP Nro. {0} - {1} - {2}", Lista.Numero, Lista.Descripcion, d.Descripcion);
                        else
                            op.Concepto = string.Format("LP Nro. {0} - {1}", Lista.Numero, Lista.Descripcion);
                        //op.Observaciones = d.Descripcion;
                        op.Fecha = Lista.Fecha;
                        op.FechaAdd = f;
                        op.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        op.Id_CentroCosto = Lista.Id_CentroCosto;
                        op.TipoEntidad = Lista.Id_TipoEntidad;
                        op.Id_Entidad = d.Id_Entidad;
                        op.Id_Sucursal = Lista.Id_Sucursal;
                        op.Importe = d.Importe;
                        op.ImporteSinAplicar = d.Importe;

                        OrdenesPagoDetalle opd = new OrdenesPagoDetalle();
                        opd.Id_Especie = Lista.Id_Especie;
                        opd.Cotizacion = db.Especies.Where(t => t.Id == Lista.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
                        opd.Importe = d.Importe;
                        opd.Detalle = d.Descripcion;
                        opd.FechaAdd = f;
                        opd.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                        TalonariosComprobantesDetalle tcd = (from td in db.TalonariosComprobantesDetalle
                                                             where td.Id_TalonarioComprobante == (from tc in db.TalonariosComprobantes
                                                                                                  join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                                                                                                  from punto in listPV
                                                                                                  where tc.UserDel == null &&
                                                                                                        tc.Id_Comprobante == 7 &&
                                                                                                       (from pv in db.PuntosVentas
                                                                                                        where pv.Id_Sucursal == Lista.Id_Sucursal
                                                                                                        select pv.Id).Contains(tc.Id_PuntoVenta) &&
                                                                                                        Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                                                                                                  select tc.Id).FirstOrDefault()
                                                                   && td.FechaVencimiento >= f
                                                                   && td.NroActual < td.NroHasta
                                                             orderby td.NroDesde
                                                             select td).FirstOrDefault();

                        if (tcd != null)
                        {
                            db.TalonariosComprobantesDetalle.Attach(tcd);
                            tcd.NroActual += 1;

                            TalonariosComprobantes tc = (from t in db.TalonariosComprobantes where t.Id == tcd.Id_TalonarioComprobante select t).FirstOrDefault();
                            op.Letra = tc.Letra;
                            op.Id_TalonariosComprobantes = tcd.Id_TalonarioComprobante;
                            op.PuntoVenta = Convert.ToInt32((from pv in db.PuntosVentas where pv.Id == tc.Id_PuntoVenta select pv.PuntoVenta).FirstOrDefault()).ToString("0000");
                            op.NroComprobante = Convert.ToInt32(tcd.NroActual).ToString("00000000");
                        }
                        else
                        {
                            throw new ValidationException("No hay talonarios vigentes para este comprobante.");
                        }

                        op.Detalle.Add(opd);

                        Lista.GeneroOP = d.Id;

                        db.SaveChanges();

                        d.Id_OP = op.Id;

                        db.SaveChanges();
                    }
                }
            }
            catch (System.Data.DataException e)
            {
                throw new ValidationException(e.Message);
            }
        }

        public List<ListaPagosDetalle> ImportarExcel(string file)
        {
            List<ListaPagosDetalle> result = new List<ListaPagosDetalle>();
            DateTime f = Sistema.ObtenerFechaHora();

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

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            System.Data.DataTable Dt = new System.Data.DataTable();

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(Dt);

            connExcel.Close();

            using (var db = new TesoreriaContext())
            {
                foreach (System.Data.DataRow r in Dt.Rows)
                {
                    if (r[0].ToString() == "" || r[1].ToString() == "")
                    {
                        Sistema.Mensaje("Hay inconsistencia en los datos ingresados en el Excel. Por favor verifique que esten completas todas las celdas.");
                        return new List<ListaPagosDetalle>();
                    }

                    int IdLegajo = Convert.ToInt32(r[0].ToString() == "" ? "0" : r[0].ToString());
                    decimal Importe = Convert.ToDecimal(r[1].ToString() == "" ? "0" : r[1].ToString());
                    string Observaciones = Convert.ToString(r[2].ToString() == "" ? "" : r[2].ToString());

                    int Id = IdLegajo;
                    string Nombre = "";

                    switch (Lista.Id_TipoEntidad)
                    {
                        case Enums.TipoEntidad.Personal:
                            Personal p = db.Personal.Where(t => t.UserDel == null && t.LaboralLegajo == IdLegajo).FirstOrDefault();

                            if (p == null || p.Id == 0)
                            {
                                Sistema.Mensaje(string.Format("No se encontro el legajo {0}.", IdLegajo));
                                return new List<ListaPagosDetalle>();
                            }
                            else
                            {
                                Id = p.Id;
                                Nombre = p.Apellido + ", " + p.Nombre;
                            }
                            break;
                        case Enums.TipoEntidad.Cliente:
                            Nombre = db.Clientes.Where(t => t.UserDel == null && t.Id == IdLegajo).Select(t => t.Nombre).FirstOrDefault();
                            break;

                        case Enums.TipoEntidad.Proveedor:
                            Nombre = db.Proveedores.Where(t => t.UserDel == null && t.Id == IdLegajo).Select(t => t.Nombre).FirstOrDefault();
                            break;

                        case Enums.TipoEntidad.Proveedor_Financiero:
                            Nombre = (from pf in db.ProvFinancieros
                                      join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                      from c in listCuentas
                                      where c.Id == IdLegajo
                                      select pf.Nombre).FirstOrDefault();
                            break;
                    }

                    if (Nombre == null || Nombre == "")
                    {
                        Sistema.Mensaje(string.Format("No se encontro el Id {0}.", IdLegajo));
                        return new List<ListaPagosDetalle>();
                    }

                    result.Add(new ListaPagosDetalle()
                    {
                        Id_Entidad = Id,
                        Importe = Importe,
                        Entidad = Nombre,
                        Descripcion = Observaciones,
                        FechaAdd = f,
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    });
                }
            }

            return result;
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                DateTime fd = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                DateTime fh = fd.AddMonths(1).AddDays(-1);

                Fecha_Desde = fd;
                Fecha_Hasta = fh;
            }

            public int? Id { get; set; }
            public int? Id_Sucursal { get; set; }
            public DateTime? Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public bool Anulado { get; set; }
        }

        public class SearchResult : ListaPagos
        {
            public string Sucursal { get; set; }
            public string Centro_Costo { get; set; }
            public decimal Importe { get; set; }
        }

        public static List<DatosReporte> ImprimeListaPago(ListaPagos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                List<DatosReporte> l = new List<DatosReporte>();

                DatosReporte i = new DatosReporte()
                {
                    Usuario = ConfigurationManager.AppSettings["CurrentUserName"],
                    FechaImpresion = Sistema.ObtenerFechaHora(),
                    Empresa = (from e in db.Empresas
                               join s in db.Sucursales on e.Id equals s.Id_Empresa into listSuc
                               from suc in listSuc
                               where suc.Id == o.Id_Sucursal
                               select e.Nombre).FirstOrDefault(),
                    CentroCosto = (db.CentrosCostos.Where(t => t.Id == o.Id_CentroCosto).Select(t => t.Descripcion).FirstOrDefault()),
                    FechaPago = o.Fecha,
                    FechaConfirmacion = o.FechaConfirmacion,
                    Descripcion = o.Descripcion,
                    Especie = (db.Especies.Where(t => t.Id == o.Id_Especie).Select(t => t.Descripcion).FirstOrDefault()),
                    Numero = o.Numero,
                    Sentido = Enums.GetDescription(o.Sentido),
                    Sucursal = (db.Sucursales.Where(t => t.Id == o.Id_Sucursal).Select(t => t.Descripcion).FirstOrDefault()),
                    Entidad = o.Id_TipoEntidad.ToString(),
                    ImporteTotal = o.Detalle.Sum(t => t.Importe)
                };

                i.Detalle = o.Detalle;
                foreach (ListaPagosDetalle x in o.Detalle)
                {
                    x.Entidad = Sistema.GetNombreEntidad(o.Id_TipoEntidad, x.Id_Entidad);
                }

                l.Add(i);

                return l;
            }
        }

        public class DatosReporte
        {
            public string Usuario { get; set; }
            public DateTime FechaImpresion { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public string CentroCosto { get; set; }
            public int Numero { get; set; }
            public DateTime FechaPago { get; set; }
            public string Especie { get; set; }
            public string Entidad { get; set; }
            public string Sentido { get; set; }
            public string Descripcion { get; set; }
            public DateTime? FechaConfirmacion { get; set; }
            public decimal ImporteTotal { get; set; }
            public virtual ICollection<ListaPagosDetalle> Detalle { get; set; }
        }
    }
}
