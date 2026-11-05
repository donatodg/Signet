namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_DataEntity;
    using VENET_Common;
    using VENET_Comun;
    using System.Data.OleDb;

    public class ValesManager : IDisposable
    {
        private TesoreriaContext db;
        public Vales Vale { get; set; }

        public ValesManager(Vales o)
        {
            db = new TesoreriaContext();
            Vale = o;

            db.Vales.Attach(Vale);

            if (Vale.Id > 0)
                db.Entry(Vale).Reload();
            else
            {
                if (Sistema.CentrosCostos.Count() > 0)
                    Vale.Id_CentroCosto = Sistema.CentrosCostos.First().Key;
                Vale.Descripcion = "Adelanto";
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<PersonalList> ListaPersonal
        {
            get
            {
                return (db.Personal
                    .Where(t => Seguridad.IdEmpresasAsignadas.Contains(t.Id_Empresa) && t.UserDel == null)
                    .Select(t => new PersonalList()
                    {
                        Id = t.Id,
                        Legajo = t.LaboralLegajo,
                        Nombre = t.Apellido + ", " + t.Nombre
                    }).ToList());
            }
        }

        public static int ObtenerProximoNumero(int Id_Caja)
        {
            int result = 0;
            using (TesoreriaContext db = new TesoreriaContext())
            {
                int IdEmpresa = (from c in db.Cajas
                                 join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                                 from suc in listSuc
                                 where c.Id == Id_Caja &&
                                       c.UserDel == null &&
                                       suc.UserDel == null
                                 select suc.Id_Empresa).FirstOrDefault();

                result = (from v in db.Vales
                          where (from s in db.Sucursales
                                 join c in db.Cajas on s.Id equals c.Id_Sucursal into listCaja
                                 from caja in listCaja
                                 where s.Id_Empresa == IdEmpresa
                                 select caja.Id).ToList().Contains(v.Id_Caja) &&
                                 v.UserDel == null
                          orderby v.Numero descending
                          select v.Numero).FirstOrDefault();
            }
            return result + 1;
        }

        public void Save()
        {
            if (Vale.Id == 0)
            {
                db.Entry(Vale).State = EntityState.Added;
                Vale.Fecha = Vale.FechaAdd = Sistema.ObtenerFechaHora();
                Vale.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                //Vale.Numero = db.Vales.Where(t => t.Id_Caja == Vale.Id_Caja && t.UserDel == null).OrderByDescending(t => t.Numero).Select(t => t.Numero).FirstOrDefault() + 1;
                Vale.Numero = ObtenerProximoNumero(Vale.Id_Caja);
            }
            else
            {
                db.Entry(Vale).State = EntityState.Modified;
                Vale.FechaMod = Sistema.ObtenerFechaHora();
                Vale.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Vales o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaConfirmacion != null) throw new ValidationException("No se puede eliminar un vale confirmado.");
                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un vale anulado.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                if (parametros.FechaHasta != null && parametros.FechaHasta == parametros.FechaDesde) parametros.FechaHasta = parametros.FechaHasta.Value.AddDays(1);

                r = (from v in db.Vales
                     join c in db.Cajas on v.Id_Caja equals c.Id into listCaja
                     from caja in listCaja.DefaultIfEmpty()
                     join p in db.Personal on v.Id_Personal equals p.Id into listPersonal
                     from per in listPersonal.DefaultIfEmpty()
                     join re in db.Rendiciones on v.Id_Rendicion equals re.Id into listRendiciones
                     from ren in listRendiciones.DefaultIfEmpty()
                     join cc in db.CentrosCostos on v.Id_CentroCosto equals cc.Id into listCC
                     from centro in listCC
                     where (v.Id == parametros.Id || parametros.Id == null)
                     && (v.Numero == parametros.Numero || parametros.Numero == null)
                     && (v.Id_Caja == parametros.Id_Caja || parametros.Id_Caja == null)
                     && (v.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == "" || parametros.Descripcion == null)
                     && (v.Fecha >= parametros.FechaDesde && v.Fecha <= parametros.FechaHasta || parametros.FechaHasta == null || parametros.Id > 0)
                     && (v.Id_Personal == parametros.Id_Personal || parametros.Id_Personal == null)
                     && (v.UserDel == null)
                     && (Seguridad.IdCajasAsignadas.Contains(caja.Id))
                     && (((parametros.Estado == Enums.ValesEstados.Anulados && parametros.Id == null && v.FechaAnulacion != null) || (parametros.Estado == Enums.ValesEstados.Anulados && parametros.Id != null))
                      || ((parametros.Estado == Enums.ValesEstados.Pendientes && parametros.Id == null && v.FechaConfirmacion == null) || (parametros.Estado == Enums.ValesEstados.Pendientes && parametros.Id != null))
                      || ((parametros.Estado == Enums.ValesEstados.SinRendir && parametros.Id == null && v.FechaConfirmacion != null && v.FechaAnulacion == null && v.Id_Rendicion == 0) || (parametros.Estado == Enums.ValesEstados.SinRendir && parametros.Id != null))
                      || ((parametros.Estado == Enums.ValesEstados.Rendidos && parametros.Id == null && v.Id_Rendicion > 0) || (parametros.Estado == Enums.ValesEstados.Rendidos && parametros.Id != null))
                      || ((parametros.Estado == Enums.ValesEstados.Todos && parametros.Id == null) || (parametros.Estado == Enums.ValesEstados.Todos && parametros.Id != null)))
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Id_Caja = v.Id_Caja,
                         Numero = v.Numero,
                         Id_CentroCosto = v.Id_CentroCosto,
                         CentroCosto = centro.Descripcion,
                         Caja = caja.Descripcion,
                         Fecha = v.Fecha,
                         Id_Personal = v.Id_Personal,
                         Personal = per.Apellido + ", " + per.Nombre,
                         Legajo = per.LaboralLegajo.Value,
                         Importe = v.Importe,
                         Descripcion = v.Descripcion,
                         FechaConfirmacion = v.FechaConfirmacion,
                         Id_Rendicion = v.Id_Rendicion,
                         FechaRendicion = ren.FechaConfirmacion,
                         FechaAnulacion = v.FechaAnulacion,
                         MotivoAnulacion = v.MotivoAnulacion,
                         FechaAdd = v.FechaAdd,
                         FechaMod = v.FechaMod,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();
                return r;

            }
        }

        public static void Confirmar(Vales o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaConfirmacion != null) throw new ValidationException("El Vale ya está Confirmado.");
                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un vale anulado.");

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.FechaConfirmacion = o.FechaMod;

                string _Personal = db.Personal.Where(t => t.Id == o.Id_Personal).Select(t => t.Apellido + ", " + t.Nombre).FirstOrDefault();

                EspeciesCtaCte e = new EspeciesCtaCte()
                {
                    Fecha = (DateTime)o.FechaMod,
                    Concepto = string.Format("Vale Nro. {0} - {1}", o.Numero, _Personal),
                    Credito = o.Importe,
                    Id_Caja = o.Id_Caja,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Vales,
                    Id_Comprobante = o.Id,
                    Id_CentroCosto = o.Id_CentroCosto,
                    FechaAdd = (DateTime)o.FechaMod,
                    UserAdd = (int)o.UserMod
                };

                db.Entry(e).State = EntityState.Added;


                int IdEspecie = db.Cajas.Where(t => t.Id == o.Id_Caja).Select(t => t.Id_Especie).FirstOrDefault();

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("Vale Nro. {0} - {1}", o.Numero, _Personal),
                    Debito = o.Importe,
                    Fecha = (DateTime)o.FechaMod,
                    FechaAdd = (DateTime)o.FechaMod,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_Personal,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Vales,
                    Id_TipoEntidad = Enums.TipoEntidad.Personal,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
            }
        }

        public static void Anular(Vales o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede anular un Vale anulado.");
                if (o.FechaConfirmacion == null) throw new ValidationException("No se puede anular un Vale sin Confirmar.");
                if (o.Id_Rendicion > 0) throw new ValidationException("No se puede anular un Vale Rendido.");

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.FechaAnulacion = o.FechaMod;
                o.MotivoAnulacion = MotivoAnulacion;

                string _Personal = db.Personal.Where(t => t.Id == o.Id_Personal).Select(t => t.Apellido + ", " + t.Nombre).FirstOrDefault();

                EspeciesCtaCte e = new EspeciesCtaCte()
                {
                    Fecha = (DateTime)o.FechaMod,
                    Concepto = string.Format("Anulación Vale Nro. {0} - {1}", o.Numero, _Personal),
                    Debito = o.Importe,
                    Id_Caja = o.Id_Caja,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Vales,
                    Id_Comprobante = o.Id,
                    Id_CentroCosto = o.Id_CentroCosto,
                    FechaAdd = (DateTime)o.FechaMod,
                    UserAdd = (int)o.UserMod
                };

                db.Entry(e).State = EntityState.Added;

                int IdEspecie = db.Cajas.Where(t => t.Id == o.Id_Caja).Select(t => t.Id_Especie).FirstOrDefault();

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("Anulación Vale Nro. {0} - {1}", o.Numero, _Personal),
                    Credito = o.Importe,
                    Fecha = (DateTime)o.FechaMod,
                    FechaAdd = (DateTime)o.FechaMod,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_Personal,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Vales,
                    Id_TipoEntidad = Enums.TipoEntidad.Personal,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
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

        public static List<Vales> ImportarExcel(string file)
        {
            List<Vales> result = new List<Vales>();
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
                    if (r[0].ToString() == "" || r[1].ToString() == "" || r[2].ToString() == "")
                    {
                        Sistema.Mensaje("Hay inconsistencia en los datos ingresados en el Excel. Por favor verifique que esten completas todas las celdas.");
                        return new List<Vales>();
                    }

                    int IdLegajo = Convert.ToInt32(r[0].ToString() == "" ? "0" : r[0].ToString());
                    decimal Importe = Convert.ToDecimal(r[1].ToString() == "" ? "0" : r[1].ToString());
                    string Observaciones = Convert.ToString(r[2].ToString() == "" ? "-" : r[2].ToString());

                    int Id = IdLegajo;
                    string Nombre = "";


                    Personal p = db.Personal.Where(t => t.UserDel == null && t.LaboralLegajo == IdLegajo).FirstOrDefault();

                    if (p == null || p.Id == 0)
                    {
                        Sistema.Mensaje(string.Format("No se encontro el legajo {0}.", IdLegajo));
                        return new List<Vales>();
                    }
                    else
                    {
                        Id = p.Id;
                        Nombre = p.Apellido + ", " + p.Nombre;
                    }


                    if (Nombre == null || Nombre == "")
                    {
                        Sistema.Mensaje(string.Format("No se encontro el Legajo {0}.", IdLegajo));
                        return new List<Vales>();
                    }

                    result.Add(new Vales()
                    {
                        Id_Personal = Id,
                        Importe = Importe,
                        Nombre = Nombre,
                        Descripcion = Observaciones,
                        FechaAdd = f,
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    });
                }
            }

            return result;
        }

        public static List<ImprimeVales> ImprimeVale(Vales o)
        {
            using (var db = new TesoreriaContext())
            {
                return (from v in db.Vales
                        join c in db.Cajas on v.Id_Caja equals c.Id into listCajas
                        from ca in listCajas
                        join s in db.Sucursales on ca.Id_Sucursal equals s.Id into listSuc
                        from suc in listSuc
                        join lo in db.Localidades on suc.CodPos equals lo.Id into listCP
                        from cp in listCP
                        join em in db.Empresas on suc.Id_Empresa equals em.Id into listEmp
                        from emp in listEmp
                        join e in db.Especies on ca.Id_Especie equals e.Id into listEsp
                        from es in listEsp
                        join p in db.Personal on v.Id_Personal equals p.Id into listPer
                        from per in listPer
                        join td in db.TipoDoc on per.Id_TipoDoc equals td.Id into listTD
                        from tipoD in listTD
                        where v.Id == o.Id
                        select new ImprimeVales()
                        {
                            Nro = v.Numero,
                            Fecha = v.Fecha,
                            Importe = v.Importe,
                            Legajo = per.LaboralLegajo.Value,
                            Nombre = per.Apellido + ", " + per.Nombre,
                            Concepto = v.Descripcion,
                            Especie = es.Descripcion,
                            Localidad = cp.Localidad,
                            TipoDoc = tipoD.Descripcion,
                            NroDoc = per.NroDoc.Value,
                            Caja = ca.Descripcion,
                            Empresa = emp.Nombre
                        }).ToList();
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                DateTime fd = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                DateTime fh = fd.AddMonths(1).AddDays(-1);

                FechaDesde = fd;
                FechaHasta = fh;
            }

            private TesoreriaContext db = new TesoreriaContext();
            public int? Id { get; set; }
            public int? Numero { get; set; }
            public int? Id_Caja { get; set; }
            public DateTime? FechaDesde { get; set; }
            public DateTime? FechaHasta { get; set; }
            public int? Id_Personal { get; set; }
            public string Descripcion { get; set; }
            public List<PersonalList> ListaPersonal
            {
                get
                {
                    return (db.Personal
                        .Where(t => Seguridad.IdEmpresasAsignadas.Contains(t.Id_Empresa) && t.UserDel == null)
                        .Select(t => new PersonalList()
                        {
                            Id = t.Id,
                            Legajo = t.LaboralLegajo,
                            Nombre = t.Apellido + ", " + t.Nombre
                        }).ToList());
                }
            }
            public Enums.ValesEstados Estado { get; set; }

        }

        public class PersonalList
        {
            public int Id { get; set; }
            public int? Legajo { get; set; }
            public string Nombre { get; set; }
        }

        public class SearchResult : Vales
        {
            public string Caja { get; set; }
            public string Personal { get; set; }
            public string CentroCosto { get; set; }
            public int Legajo { get; set; }
            public DateTime? FechaRendicion { get; set; }
        }

        public class ImprimeVales
        {
            public int Nro { get; set; }
            public DateTime Fecha { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public decimal Importe { get; set; }
            public string Concepto { get; set; }
            public string Especie { get; set; }
            public string EnLetras { get { return NumeroALetras.Convertir(Importe.ToString()); } }
            public string Localidad { get; set; }
            public string TipoDoc { get; set; }
            public int NroDoc { get; set; }
            public string Empresa { get; set; }
            public string Caja { get; set; }

        }
    }
}
