namespace VENET_Personal_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class PersonalManager : IDisposable
    {
        private PersonalContext db;
        public Personal Personal { get; set; }

        public PersonalManager(Personal o)
        {
            db = new PersonalContext();
            Personal = o;

            db.Personal.Attach(Personal);

            if (Personal.Id > 0)
            {
                db.Entry(Personal).Reload();
            }
            else
            {
                Personal.FechaAlta = Sistema.ObtenerFechaHora();
                Personal.Id_TipoDoc = 1;
                Personal.Id_Jerarquia = 1;
                Personal.Id_Tipo = 1;
                Personal.Id_TipoIva = 3;
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        #region AddMod

        public List<KeyNamePair> Provincias { get { return db.Provincias.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> Estados_Civiles { get { return db.EstadosCiviles.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> Tipos_Personal { get { return db.PersonalTipos.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> Jerarquias { get { return db.PersonalJerarquias.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> TipoDoc { get { return db.TipoDoc.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Key).ToList(); } }
        public List<KeyNamePair> UnidadNegocio { get { return db.UnidadNegocios.Where(t => t.UserDel == null && Seguridad.IdUnidadesNegociosAsignadas.Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }
        public List<KeyNamePair> Servicios
        {
            get
            {
                return (from l in db.Lineas
                        join r in db.Ramales on l.Id equals r.Id_Linea into listRam
                        from ram in listRam
                        join ts in db.TipoServicios on ram.Id equals ts.Id_Ramal into listServ
                        from tipoServ in listServ
                        join u in db.UnidadNegocios on l.Id_UnidadNegocio equals u.Id into listUN
                        from un in listUN
                        where (l.UserDel == null)
                          && (ram.UserDel == null)
                          && (tipoServ.UserDel == null)
                          && (un.Id == Personal.LaboralId_UnidadNegocio)
                          && Seguridad.IdUnidadesNegociosAsignadas.Contains(l.Id_UnidadNegocio)
                          && l.MediaLargaDistancia == true
                        select new KeyNamePair()
                        {
                            Key = tipoServ.Id,
                            Name = l.DescripcionCorta + " - " + ram.Descripcion + " - " + tipoServ.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Cabeceras
        {
            get
            {
                return (from ts in db.TipoServicios
                        join r in db.Ramales on ts.Id_Ramal equals r.Id into listRam
                        from ram in listRam
                        join l in db.Lineas on ram.Id_Linea equals l.Id into listLin
                        from lin in listLin
                        join c in db.Cabeceras on lin.Id equals c.Id_Linea into listCab
                        from cab in listCab
                        where (ts.UserDel == null)
                        && (ram.UserDel == null)
                        && (lin.UserDel == null)
                        && (cab.UserDel == null)
                        && Seguridad.IdUnidadesNegociosAsignadas.Contains(lin.Id_UnidadNegocio)
                        && lin.MediaLargaDistancia == true
                        && ts.Id == Personal.LaboralId_TipoServicio
                        select new KeyNamePair()
                        {
                            Key = cab.Id,
                            Name = cab.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> ServiciosInspectores
        {
            get
            {
                return (from si in db.ServiciosInspectores
                        where (si.UserDel == null)
                        && Seguridad.IdUnidadesNegociosAsignadas.Contains(si.Id_UnidadNegocio)
                        && si.Id_PuntaLinea == Personal.LaboralId_PuntaDeLinea
                        select new KeyNamePair()
                        {
                            Key = si.Id,
                            Name = si.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> GrupoLineas
        {
            get
            {
                return (from ts in db.TipoServicios
                        join r in db.Ramales on ts.Id_Ramal equals r.Id into listRam
                        from ram in listRam
                        join l in db.Lineas on ram.Id_Linea equals l.Id into listLin
                        from lin in listLin
                        join g in db.GruposLineas on lin.Id equals g.Id_Linea into listGL
                        from gl in listGL
                        where (ts.UserDel == null)
                        && (ram.UserDel == null)
                        && (lin.UserDel == null)
                        && (gl.UserDel == null)
                        && Seguridad.IdUnidadesNegociosAsignadas.Contains(lin.Id_UnidadNegocio)
                        && lin.MediaLargaDistancia == true
                        && ts.Id == Personal.LaboralId_TipoServicio
                        select new KeyNamePair()
                        {
                            Key = gl.Id,
                            Name = gl.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> PuntasDeLineas
        {
            get
            {
                return (from pl in db.PuntasDeLineas
                        where (pl.UserDel == null)
                        && Seguridad.IdUnidadesNegociosAsignadas.Contains(pl.Id_UnidadNegocio)
                        && pl.Id_UnidadNegocio == Personal.LaboralId_UnidadNegocio
                        select new KeyNamePair()
                        {
                            Key = pl.Id,
                            Name = pl.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        #endregion

        public void Save()
        {
            bool Nuevo = false;

            if (Personal.LaboralLegajo == 0 || Personal.LaboralLegajo == null)
                throw new ValidationException("Debe ingresar un legajo");

            if (Personal.LaboralId_UnidadNegocio == 0)
                throw new ValidationException("Debe ingresar una unidad de negocio");

            if (Personal.Id == 0)
            {
                db.Entry(Personal).State = System.Data.Entity.EntityState.Added;
                Personal.FechaAdd = Sistema.ObtenerFechaHora();
                Personal.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Nuevo = true;
            }
            else
            {
                db.Entry(Personal).State = System.Data.Entity.EntityState.Modified;
                Personal.FechaMod = Sistema.ObtenerFechaHora();
                Personal.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();


            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
            {
                int Id_UN = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_UN = db2.SeguridadUsuariosUnidadNegocios.Where(t => t.Id_Usuario == Personal.UserAdd && t.UserDel == null).Select(t => t.Id_UnidadNegocio).FirstOrDefault();

                    if (Id_UN == 0)
                        Id_UN = db2.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesUnidadNegocios o = new EntidadesUnidadNegocios()
                {
                    Id_Entidad = Personal.Id,
                    TipoEntidad = Enums.TipoEntidad.Personal,
                    Id_UnidadNegocio = Id_UN,
                    UserAdd = Personal.UserAdd,
                    FechaAdd = Personal.FechaAdd
                };

                db.EntidadesUnidadNegocios.Attach(o);
                db.Entry(o).State = System.Data.Entity.EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }

            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
            {
                int Id_Empresa = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_Empresa = db2.SeguridadUsuariosEmpresas.Where(t => t.Id_Usuario == Personal.UserAdd && t.UserDel == null).Select(t => t.Id_Empresa).FirstOrDefault();

                    if (Id_Empresa == 0)
                        Id_Empresa = db2.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesEmpresas o = new EntidadesEmpresas()
                {
                    Id_Entidad = Personal.Id,
                    TipoEntidad = Enums.TipoEntidad.Personal,
                    Id_Empresa = Id_Empresa,
                    UserAdd = Personal.UserAdd,
                    FechaAdd = Personal.FechaAdd
                };

                db.EntidadesEmpresas.Attach(o);
                db.Entry(o).State = System.Data.Entity.EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }
        }

        public static void Eliminar(Personal personal)
        {
            using (var db = new PersonalContext())
            {
                db.Entry(personal).State = System.Data.Entity.EntityState.Modified;
                db.Entry(personal).Reload();

                personal.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                personal.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            //if (parametros.Id_Empresa == 0) throw new ValidationException("Debe selccionar una empresa.");

            using (var db = new PersonalContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Personal
                     join t in db.TipoDoc on p.Id_TipoDoc equals t.Id into listTipoDoc
                     from td in listTipoDoc.DefaultIfEmpty()
                     join lp in db.Provincias on p.LaboralId_Provincia equals lp.Id into listProvLab
                     from labP in listProvLab.DefaultIfEmpty()
                     join dlp in db.Provincias on p.Id_Provincia equals dlp.Id into listProvDom
                     from DomP in listProvDom.DefaultIfEmpty()
                     join e in db.Empresas on p.Id_Empresa equals e.Id into listEmpre
                     from emp in listEmpre.DefaultIfEmpty()
                     join un in db.UnidadNegocios on p.LaboralId_UnidadNegocio equals un.Id into listUN
                     from uniNeg in listUN.DefaultIfEmpty()
                     join j in db.PersonalJerarquias on p.Id_Jerarquia equals j.Id into listJer
                     from jer in listJer.DefaultIfEmpty()
                     join grupol in db.GruposLineas on p.LaboralId_GrupoLinea equals grupol.Id into listGL
                     from gl in listGL.DefaultIfEmpty()
                     where (p.Id == parametros.Id || parametros.Id == null)
                     && (p.Apellido.Contains(parametros.Apellido) || parametros.Apellido == null)
                     && (p.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                     && (p.FechaAlta == parametros.FechaAlta || parametros.FechaAlta == null)
                     && (p.FechaBaja == parametros.FechaBaja || parametros.FechaBaja == null)
                     && (p.Id_TipoDoc == parametros.Id_TipoDoc || parametros.Id_TipoDoc == null)
                     && (p.NroDoc == parametros.NroDoc || parametros.NroDoc == null)
                     && (p.LaboralLegajo == parametros.Legajo || parametros.Legajo == null)
                     && (p.UserDel == null)
                     && (p.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == 0 || p.Id == parametros.Id)
                     && (Seguridad.IdUnidadesNegociosAsignadas.Contains(uniNeg.Id) || uniNeg.Id == 0)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Apellido = p.Apellido,
                         Nombre = p.Nombre,
                         ApellidoCasada = p.ApellidoCasada,
                         DomicilioCalle = p.DomicilioCalle,
                         DomicilioNro = p.DomicilioNro,
                         DomicilioPiso = p.DomicilioPiso,
                         DomicilioDpto = p.DomicilioDpto,
                         CodPos = p.CodPos,
                         Id_Provincia = p.Id_Provincia,
                         Telefono = p.Telefono,
                         Celular = p.Celular,
                         FechaAlta = p.FechaAlta,
                         FechaBaja = p.FechaBaja,
                         FechaNacimiento = p.FechaNacimiento,
                         Observaciones = p.Observaciones,
                         Id_EstadoCivil = p.Id_EstadoCivil,
                         Id_TipoDoc = p.Id_TipoDoc,
                         TipoDoc = td.Descripcion,
                         NroDoc = p.NroDoc,
                         Id_Tipo = p.Id_Tipo,
                         Id_Jerarquia = p.Id_Jerarquia,
                         Jerarquia = jer.Descripcion,
                         Cuit = p.Cuit,
                         LaboralLegajo = p.LaboralLegajo,
                         LaboralSucursal = p.LaboralSucursal,
                         LaboralDomicilio = p.LaboralDomicilio,
                         LaboralCodPos = p.LaboralCodPos,
                         LaboralTelefono = p.LaboralTelefono,
                         LaboralId_Provincia = p.LaboralId_Provincia,
                         LaboralTurnoFijo = p.LaboralTurnoFijo,
                         LaboralVencimientoCarnet = p.LaboralVencimientoCarnet,
                         LaboralVencimientoCarnetCNRT = p.LaboralVencimientoCarnetCNRT,
                         LaboralCarnetNumeroAdicional2 = p.LaboralCarnetNumeroAdicional2,
                         LaboralEmisionCarnetAdicional2 = p.LaboralEmisionCarnetAdicional2,
                         LaboralVencimientoCarnetAdicional2 = p.LaboralVencimientoCarnetAdicional2,
                         LaboralId_ServicioInspectores = p.LaboralId_ServicioInspectores,
                         //LaboralInspectoresFranco4x1 = p.LaboralInspectoresFranco4x1,
                         //LaboralInspectoresFrancoSD = p.LaboralInspectoresFrancoSD,
                         Email = p.Email,
                         LaboralDiaRotacion = p.LaboralDiaRotacion,
                         LaboralDiasRotacion = p.LaboralDiasRotacion,
                         LaboralFrancoDias = p.LaboralFrancoDias,
                         LaboralId_Cabecera = p.LaboralId_Cabecera,
                         LaboralId_TipoServicio = p.LaboralId_TipoServicio,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         FechaDel = p.FechaDel,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod,
                         UserDel = p.UserDel,
                         ProvinciaLaboral = labP.Descripcion,
                         Id_Empresa = p.Id_Empresa,
                         Empresa = emp.Nombre,
                         LaboralId_UnidadNegocio = p.LaboralId_UnidadNegocio,
                         UnidadNegocio = uniNeg.Descripcion,
                         DomicilioProvincia = DomP.Descripcion,
                         Id_TipoIva = p.Id_TipoIva,
                         LaboralCarnetNumero = p.LaboralCarnetNumero,
                         LaboralCarnetNumeroCNRT = p.LaboralCarnetNumeroCNRT,
                         LaboralEmisionCarnet = p.LaboralEmisionCarnet,
                         LaboralEmisionCarnetCNRT = p.LaboralEmisionCarnetCNRT,
                         LaboralCarnetNumeroAdicional = p.LaboralCarnetNumeroAdicional,
                         LaboralEmisionCarnetAdicional = p.LaboralEmisionCarnetAdicional,
                         LaboralVencimientoCarnetAdicional = p.LaboralVencimientoCarnetAdicional,
                         LaboralId_PuntaDeLinea = p.LaboralId_PuntaDeLinea,
                         LaboralId_GrupoLinea = p.LaboralId_GrupoLinea,
                         GrupoLinea = gl.Descripcion
                     }).ToList();
                return r;
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
            objCelda.Value = "Turno";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Día Semana Rotación";

            objCelda = HojaExcel.Range["D1", Type.Missing];
            objCelda.Value = "Cant. Días Rotación";

            objCelda = HojaExcel.Range["E1", Type.Missing];
            objCelda.Value = "Franco cada x días";

            Microsoft.Office.Interop.Excel.Range objRango = HojaExcel.Range["A1:E1"];
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

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;

            connExcel.Open();
            DataTable dtExcelSchema;
            DataTable Dt = new DataTable();

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(Dt);

            connExcel.Close();

            using (var db = new ErsaContext())
            {
                foreach (DataRow r in Dt.Rows)
                {
                    if (r[0].ToString() == "")
                    {
                        Sistema.Mensaje("Hay inconsistencia en los datos ingresados en el Excel. Por favor verifique que esten completas todas las celdas.");
                        return;
                    }

                    int Legajo = Convert.ToInt32(r[0].ToString() == "" ? "0" : r[0].ToString());
                    int Turno = Convert.ToInt32(r[1].ToString() == "" ? "0" : r[1].ToString());
                    int DiaRotacion = Convert.ToInt32(r[2].ToString() == "" ? "0" : r[2].ToString());
                    int DiasRotacion = Convert.ToInt32(r[3].ToString() == "" ? "0" : r[3].ToString());
                    int Franco = Convert.ToInt32(r[4].ToString() == "" ? "0" : r[4].ToString());

                    if (Turno < 1 || Turno > 6) Turno = 4;
                    if (Franco < 0 || Franco > 4) Franco = 4;
                    if (DiaRotacion < 0 || DiaRotacion > 7) DiaRotacion = 7;

                    //Setear los valores para el legajo
                    Personal p = (from pe in db.Personal where (pe.LaboralLegajo == Legajo && Seguridad.IdUnidadesNegociosAsignadas.Contains(pe.LaboralId_UnidadNegocio) && pe.UserDel == null) select (pe)).FirstOrDefault();

                    if (p == null || p.Id == 0)
                    {
                        Sistema.Mensaje(string.Format("No se encontro el legajo {0}.", Legajo));
                        return;
                    }

                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    p.LaboralTurnoFijo = (VENET_Comun.Enums.Turno)Turno;
                    p.LaboralDiaRotacion = (VENET_Comun.Enums.DiasSemana)DiaRotacion;
                    p.LaboralDiasRotacion = DiasRotacion;
                    p.LaboralFrancoDias = Franco;
                    p.FechaMod = Sistema.ObtenerFechaHora();
                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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

        public static void GenerarModeloExcelVencimientos()
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
            objCelda.Value = "Fecha Vencimiento";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Número";

            objCelda = HojaExcel.Range["D1", Type.Missing];
            objCelda.Value = "Fecha Emisión";

            objCelda = HojaExcel.Range["E1", Type.Missing];
            objCelda.Value = "Fecha Vencimiento CNRT";

            objCelda = HojaExcel.Range["F1", Type.Missing];
            objCelda.Value = "Número CNRT";

            objCelda = HojaExcel.Range["G1", Type.Missing];
            objCelda.Value = "Fecha Emisión CNRT";

            objCelda = HojaExcel.Range["H1", Type.Missing];
            objCelda.Value = "Fecha Vencimiento Adicional";

            objCelda = HojaExcel.Range["I1", Type.Missing];
            objCelda.Value = "Número Adicional";

            objCelda = HojaExcel.Range["J1", Type.Missing];
            objCelda.Value = "Fecha Emisión Adicional";

            objCelda = HojaExcel.Range["K1", Type.Missing];
            objCelda.Value = "Fecha Vencimiento Adicional 2";

            objCelda = HojaExcel.Range["L1", Type.Missing];
            objCelda.Value = "Número Adicional 2";

            objCelda = HojaExcel.Range["M1", Type.Missing];
            objCelda.Value = "Fecha Emisión Adicional 2";

            Microsoft.Office.Interop.Excel.Range objRango = HojaExcel.Range["A1:J1"];
            objRango.Select();

            objRango.Columns.AutoFit();

            Mi_Excel.Visible = true;
        }

        public static void ImportarExcelVencimientos(string file)
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

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;

            connExcel.Open();
            DataTable dtExcelSchema;
            DataTable Dt = new DataTable();

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(Dt);

            connExcel.Close();

            using (var db = new ErsaContext())
            {
                foreach (DataRow r in Dt.Rows)
                {
                    if (r[0].ToString() == "")
                    {
                        Sistema.Mensaje("Hay inconsistencia en los datos ingresados en el Excel. Por favor verifique que esten completas todas las celdas.");
                        return;
                    }

                    int Legajo = Convert.ToInt32(r[0].ToString() == "" ? "0" : r[0].ToString());
                    DateTime? Vencimiento = Convert.ToDateTime(r[1].ToString() == "" ? null : r[1].ToString());
                    int? Numero = Convert.ToInt32(r[2].ToString() == "" ? null : r[2].ToString());
                    DateTime? Emision = Convert.ToDateTime(r[3].ToString() == "" ? null : r[3].ToString());

                    DateTime? VencimientoCNRT = Convert.ToDateTime(r[4].ToString() == "" ? null : r[4].ToString());
                    int? NumeroCNRT = Convert.ToInt32(r[5].ToString() == "" ? null : r[5].ToString());
                    DateTime? EmisionCNRT = Convert.ToDateTime(r[6].ToString() == "" ? null : r[6].ToString());

                    DateTime? VencimientoAdicional = Convert.ToDateTime(r[7].ToString() == "" ? null : r[7].ToString());
                    int? NumeroAdicional = Convert.ToInt32(r[8].ToString() == "" ? null : r[8].ToString());
                    DateTime? EmisionAdicional = Convert.ToDateTime(r[9].ToString() == "" ? null : r[9].ToString());

                    DateTime? VencimientoAdicional2 = Convert.ToDateTime(r[10].ToString() == "" ? null : r[10].ToString());
                    int? NumeroAdicional2 = Convert.ToInt32(r[11].ToString() == "" ? null : r[11].ToString());
                    DateTime? EmisionAdicional2 = Convert.ToDateTime(r[12].ToString() == "" ? null : r[12].ToString());

                    //Setear los valores para el legajo
                    Personal p = (from pe in db.Personal where (pe.LaboralLegajo == Legajo && Seguridad.IdUnidadesNegociosAsignadas.Contains(pe.LaboralId_UnidadNegocio) && pe.UserDel == null) select (pe)).FirstOrDefault();

                    if (p == null || p.Id == 0)
                    {
                        Sistema.Mensaje(string.Format("No se encontro el legajo {0}.", Legajo));
                        return;
                    }

                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    if (Vencimiento != DateTime.MinValue) p.LaboralVencimientoCarnet = Vencimiento;
                    if (VencimientoCNRT != DateTime.MinValue) p.LaboralVencimientoCarnetCNRT = VencimientoCNRT;
                    if (VencimientoAdicional != DateTime.MinValue) p.LaboralVencimientoCarnetAdicional = VencimientoAdicional;
                    if (VencimientoAdicional2 != DateTime.MinValue) p.LaboralVencimientoCarnetAdicional2 = VencimientoAdicional2;

                    if (Numero != 0) p.LaboralCarnetNumero = Numero.ToString();
                    if (NumeroCNRT != 0) p.LaboralCarnetNumeroCNRT = NumeroCNRT.ToString();
                    if (NumeroAdicional != 0) p.LaboralCarnetNumeroAdicional = NumeroAdicional.ToString();
                    if (NumeroAdicional2 != 0) p.LaboralCarnetNumeroAdicional2 = NumeroAdicional2.ToString();

                    if (Emision != DateTime.MinValue) p.LaboralEmisionCarnet = Emision;
                    if (EmisionCNRT != DateTime.MinValue) p.LaboralEmisionCarnetCNRT = EmisionCNRT;
                    if (EmisionAdicional != DateTime.MinValue) p.LaboralEmisionCarnetAdicional = EmisionAdicional;
                    if (EmisionAdicional2 != DateTime.MinValue) p.LaboralEmisionCarnetAdicional2 = EmisionAdicional2;

                    p.FechaMod = Sistema.ObtenerFechaHora();
                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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

        public class ParametrosBusquedas
        {
            //public ParametrosBusquedas()
            //{
            //    Id_Empresa = Empresas.FirstOrDefault().Key;
            //}

            private PersonalContext db = new PersonalContext();
            public List<KeyNamePair> TipoDoc { get { return db.TipoDoc.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Key).ToList(); } }
            public List<KeyNamePair> Empresas { get { return db.Empresas.Where(t => t.UserDel == null && Seguridad.IdEmpresasAsignadas.Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList(); } }
            public int Id_Empresa { get; set; }
            public int? Id { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public DateTime? FechaAlta { get; set; }
            public DateTime? FechaBaja { get; set; }
            public int? Id_TipoDoc { get; set; }
            public int? NroDoc { get; set; }
            public int? Legajo { get; set; }
        }

        public class SearchResult : Personal
        {
            public string TipoDoc { get; set; }
            public string ProvinciaLaboral { get; set; }
            public string Empresa { get; set; }
            public string UnidadNegocio { get; set; }
            //   public String DomicilioLocalidad { get; set; }
            public string DomicilioProvincia { get; set; }
            public string Jerarquia { get; set; }
            public string GrupoLinea { get; set; }
        }

    }

}
