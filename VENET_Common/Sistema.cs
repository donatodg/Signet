namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Drawing;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Windows.Forms;
    using VENET_Comun;
    using VENET_DataEntity;

    public class Sistema
    {
        public static void AbrirForm(Form formParent, string formulario, string ensamblado, string namespaces, bool showDialog = false, bool showBottomRight = false, bool InstanciaUnica = false)
        {
            try
            {
                if (InstanciaUnica && ExisteFormulario(formParent, formulario))
                    return;

                Enums.Modulos Modulo;
                switch (ensamblado)
                {
                    case "VENET_Common":
                    case "VENET_Comun":
                        Modulo = Enums.Modulos.Comun;
                        break;

                    case "VENET_General_BL":
                    case "VENET_General_UI":
                        Modulo = Enums.Modulos.General;
                        break;

                    case "VENET_Personal_BL":
                    case "VENET_Personal_UI":
                        Modulo = Enums.Modulos.Personal;
                        break;

                    case "VENET_Seguridad_BL":
                    case "VENET_Seguridad_UI":
                        Modulo = Enums.Modulos.Seguridad;
                        break;

                    case "VENET_Trafico_BL":
                    case "VENET_Trafico_Reports":
                    case "VENET_Trafico_UI":
                        Modulo = Enums.Modulos.Trafico;
                        break;

                    case "VENET_Informes_BL":
                    case "VENET_Informes_UI":
                        Modulo = Enums.Modulos.Informes;
                        break;

                    case "VENET_ViajeEspeciales_BL":
                    case "VENET_ViajeEspeciales_UI":
                        Modulo = Enums.Modulos.ViajesEspeciales;
                        break;

                    case "VENET_Chats_BL":
                    case "VENET_Chats_UI":
                    case "VENET_IA_BL":
                    case "VENET_IA_UI":
                        Modulo = Enums.Modulos.Sistema;
                        break;

                    default:
                        Modulo = Enums.Modulos.General;
                        break;
                }


                string[] strArr = formulario.Split('_');
                if (!Seguridad.ObtenerPermiso(Modulo, strArr[0].Substring(3), Enums.Accion.Ingresar)) return;

                MultiForm f = default(MultiForm);
                f = (MultiForm)Activator.CreateInstance(ensamblado, namespaces + "." + formulario).Unwrap();
                f.Owner = formParent;

                f.StartPosition = FormStartPosition.Manual;
                if (showBottomRight)
                    f.Location = new Point(formParent.Location.X + (formParent.Width - f.Width), formParent.Location.Y + (formParent.Height - f.Height) - 5);
                else
                    f.Location = new Point(formParent.Location.X + (formParent.Width - f.Width) / 2, formParent.Location.Y + (formParent.Height - f.Height) / 2);

                f.ShowInTaskbar = false;
                if (showDialog)
                {
                    f.MinimumSize = f.Size;
                    f.MaximumSize = f.Size;
                    f.MinimizeBox = false;
                    f.MaximizeBox = false;
                    f.ControlBox = true;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.ShowDialog(formParent);
                }
                else
                {
                    f.Show(formParent);
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex);
            }
        }

        private static bool ExisteFormulario(Form formParent, string formulario)
        {
            foreach (Form r in formParent.OwnedForms)
            {
                if (r.Name == formulario)
                    return true;
            }
            return false;
        }

        public static void MensajeError(Exception ex)
        {
            Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
        }

        public static void Mensaje(string Mensaje, string Titulo = "", Exception ex = null, bool MuestraMensaje = true)
        {
            //Size desktopSize = SystemInformation.PrimaryMonitorSize;
            string strError = "";

            if (ex != null)
            {
                strError = "==========================================================================================" + "\r\n";
                strError += "     Fecha: " + Sistema.ObtenerFechaHora() + "\r\n";
                strError += "     Usuario: " + ConfigurationManager.AppSettings["CurrentUserName"] + "\r\n";
                strError += "     Equipo: " + ConfigurationManager.AppSettings["CurrentComputerName"] + "\r\n";
                strError += "     Sistema: " + ConfigurationManager.AppSettings["CurrentEmpresa"] + "\r\n";
                strError += "---------------------------------------------------------------------------------------------------------------------------------------------" + "\r\n";
                strError += "     Error: " + ex.Message + "\r\n";
                strError += "---------------------------------------------------------------------------------------------------------------------------------------------" + "\r\n";
                strError += ex.Source + "\r\n";
                strError += ex.StackTrace + "\r\n";
                strError += ex.HelpLink + "\r\n";
                if (ex.InnerException != null) strError += ex.InnerException + "\r\n";
                strError += "==========================================================================================" + "\r\n";

                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "LogError" + ".txt", strError, Encoding.Unicode);
            }

            if (Titulo == "") Titulo = "Atención";
            if (MuestraMensaje)
            {
                Form f = new frmMensaje(Titulo, Mensaje, strError);
                //f.Width = desktopSize.Width;
                f.ShowDialog();
                f.Dispose();
            }
            else
            {
                ConfigurationManager.AppSettings["Mensaje"] = Mensaje;
                ConfigurationManager.AppSettings["Titulo"] = Titulo;
            }
        }

        public static bool MensajeSiNo(string Mensaje, string Titulo = "")
        {

            if (Titulo == "") Titulo = "Atención";
            Form f = new frmMensajeSiNo(Titulo, Mensaje);
            //f.Width = desktopSize.Width;
            if (f.ShowDialog() == DialogResult.Yes) return true; else return false;
        }

        public static DateTime ObtenerFechaHora()
        {
            try
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        public static DateTime ObtenerFecha()
        {
            try
            {
                using (GeneralContext db = new GeneralContext())
                {
                    var r = db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                    return new DateTime(r.Year, r.Month, r.Day);
                }
            }
            catch (Exception)
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        public static void EnvioMail(string ArchivoAdjunto, string Asunto, string Cuerpo, string MailRecipiente)
        {
            using (MailMessage mail = new MailMessage())
            {
                if (ArchivoAdjunto != "")
                {
                    Attachment att = new Attachment(ArchivoAdjunto);
                    mail.Attachments.Add(att);
                }

                mail.From = new MailAddress(Parametro.ObtenerValor(Parametro.Param.Mail_CuentaDeEnvio), Parametro.ObtenerValor(Parametro.Param.Mail_NombrePersonaEnvio));
                mail.To.Add(new MailAddress(MailRecipiente));
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Mail_EnviarconCopia)))
                    mail.CC.Add(new MailAddress(Parametro.ObtenerValor(Parametro.Param.Mail_CuentaDeEnvio)));

                if (Cuerpo == "")
                    Cuerpo = Parametro.ObtenerValor(Parametro.Param.Mail_TextoDelCuerpo);

                mail.Subject = Asunto;
                mail.Body = Cuerpo;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(Parametro.ObtenerValor(Parametro.Param.Mail_SmtpParaEnvioMail), Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.Mail_PuertoEnvioMail)));

                smtp.Credentials = new System.Net.NetworkCredential(Parametro.ObtenerValor(Parametro.Param.Mail_CuentaDeEnvio), Parametro.ObtenerValor(Parametro.Param.Mail_ContraseñaCuentaEnvioMail));
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Mail_EnableSSL)))
                    smtp.EnableSsl = true;

                smtp.Send(mail);

                if (ArchivoAdjunto != "")
                    mail.Attachments.Clear();

                mail.Dispose();
            }
        }

        public static void ActualizarTema(string Tema)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.Tema = Tema;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ActualizarIndicador(bool Visible)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.Indicadores = Visible;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static List<CentrosCostosList> CentrosCostos
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                        return (from c in db.CentrosCostos
                                where c.UserDel == null
                                      && Seguridad.IdCentrosCostosAsignados.Contains(c.Id)
                                select new CentrosCostosList
                                {
                                    Key = c.Id,
                                    Name = c.Descripcion,
                                    Default = 0
                                }).OrderBy(t => t.Name).ToList();
                    else
                    {
                        int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                        return (from u in db.SeguridadUsuariosCentrosCostos
                                join cc in db.CentrosCostos on u.Id_CentroCosto equals cc.Id into listCC
                                from c in listCC
                                join suc in db.SeguridadUsuarioCentrosCostoDefault on new { u.Id_CentroCosto, u.Id_Usuario } equals new { suc.Id_CentroCosto, suc.Id_Usuario } into listDef
                                from def in listDef.DefaultIfEmpty()
                                where c.UserDel == null &&
                                      u.UserDel == null &&
                                      Seguridad.IdCentrosCostosAsignados.Contains(c.Id) &&
                                      u.Id_Usuario == IdUser
                                select new CentrosCostosList
                                {
                                    Key = c.Id,
                                    Name = c.Descripcion,
                                    Default = def.Id_CentroCosto
                                }).OrderByDescending(t => t.Default).ToList();
                    }
                }
            }
        }

        public class CentrosCostosList
        {
            public int Key { get; set; }
            public string Name { get; set; }
            public int? Default { get; set; }
        }

        public static List<CajasList> Cajas
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                        return (from c in db.Cajas
                                join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                                from suc in listSuc
                                join e in db.Empresas on suc.Id_Empresa equals e.Id into listEmp
                                from emp in listEmp
                                join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                                from esp in listEsp
                                where c.UserDel == null
                                select new CajasList
                                {
                                    Id_Caja = c.Id,
                                    Caja = c.Descripcion,
                                    Empresa = emp.Nombre,
                                    Especie = esp.Descripcion,
                                    Sucursal = suc.Descripcion,
                                    Default = 1
                                }).ToList();
                    else
                    {
                        int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                        return (from u in db.SeguridadUsuariosCajas
                                join ca in db.Cajas on u.Id_Caja equals ca.Id into listC
                                from c in listC
                                join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                                from suc1 in listSuc
                                join e in db.Empresas on suc1.Id_Empresa equals e.Id into listEmp
                                from emp in listEmp
                                join es in db.Especies on c.Id_Especie equals es.Id into listEsp
                                from esp in listEsp
                                join suc in db.SeguridadUsuarioCajaDefault on new { u.Id_Caja, u.Id_Usuario } equals new { suc.Id_Caja, suc.Id_Usuario } into listDef
                                from def in listDef.DefaultIfEmpty()
                                where c.UserDel == null &&
                                      suc1.UserDel == null &&
                                      esp.UserDel == null &&
                                      Seguridad.IdCajasAsignadas.Contains(c.Id) &&
                                      u.Id_Usuario == IdUser
                                select new CajasList
                                {
                                    Id_Caja = c.Id,
                                    Caja = c.Descripcion,
                                    Empresa = emp.Nombre,
                                    Especie = esp.Descripcion,
                                    Sucursal = suc1.Descripcion,
                                    Default = def.Id_Caja
                                }).OrderByDescending(t => t.Default).ToList();
                    }
                }
            }
        }

        public class CajasList
        {
            public int Id_Caja { get; set; }
            public string Caja { get; set; }
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public string Especie { get; set; }
            public int? Default { get; set; }
        }

        public static List<SucursalesList> Sucursales
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                    {

                        return (from s in db.Sucursales
                                join e in db.Empresas on s.Id_Empresa equals e.Id into listEmp
                                from emp in listEmp
                                where s.UserDel == null
                                      && emp.UserDel == null
                                      && Seguridad.IdSucursalesAsignadas.Contains(s.Id)
                                select new SucursalesList
                                {
                                    Id_Sucursal = s.Id,
                                    Empresa = emp.Nombre,
                                    Sucursal = s.Descripcion,
                                }).OrderBy(t => t.Sucursal).ToList();

                    }
                    else
                    {
                        int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);


                        return (from u in db.SeguridadUsuariosSucursales
                                join su in db.Sucursales on u.Id_Sucursal equals su.Id into listS
                                from s in listS
                                join e in db.Empresas on s.Id_Empresa equals e.Id into listEmp
                                from emp in listEmp
                                join suc in db.SeguridadUsuarioSucursalDefault on new { u.Id_Sucursal, u.Id_Usuario } equals new { suc.Id_Sucursal, suc.Id_Usuario } into listDef
                                from def in listDef.DefaultIfEmpty()
                                where s.UserDel == null &&
                                      emp.UserDel == null &&
                                      Seguridad.IdSucursalesAsignadas.Contains(s.Id) &&
                                      u.Id_Usuario == IdUser
                                select new SucursalesList
                                {
                                    Id_Sucursal = s.Id,
                                    Empresa = emp.Nombre,
                                    Sucursal = s.Descripcion,
                                    Default = def.Id_Sucursal
                                }).OrderByDescending(t => t.Default).ToList();

                        //return (from s in db.Sucursales
                        //        join e in db.Empresas on s.Id_Empresa equals e.Id into listEmp
                        //        from emp in listEmp
                        //        join suc in db.SeguridadUsuarioSucursalDefault on new { s.Id,  } equals new { suc.Id_Sucursal, suc.Id_Usuario } into listDef
                        //        from def in listDef.DefaultIfEmpty()
                        //        where s.UserDel == null
                        //              && emp.UserDel == null
                        //              //&& (def.Id_Usuario == IdUser || def.Id_Usuario == null)
                        //              && Seguridad.IdSucursalesAsignadas.Contains(s.Id)
                        //        select new SucursalesList
                        //        {
                        //            Id_Sucursal = s.Id,
                        //            Empresa = emp.Descripcion,
                        //            Sucursal = s.Descripcion,
                        //            Default = def.Id_Sucursal
                        //        }).OrderByDescending(t => t.Default).ToList();

                    }
                }
            }
        }

        public class SucursalesList
        {
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public int Id_Sucursal { get; set; }
            public int? Default { get; set; }
        }

        public static List<KeyNamePair> SeguridadUsuario
        {
            get
            {
                using (SeguridadContext db = new SeguridadContext())
                {
                    return (db.SeguridadUsuarios.Where(t => t.UserDel == null && t.Activo).
                        Select(t => new KeyNamePair() { Key = t.Id, Name = t.Apellido + ", " + t.Nombre }).OrderBy(t => t.Name)).ToList();
                }
            }
        }

        public static List<KeyNamePair> Entradas
        {
            get
            {
                using (GpsContext db = new GpsContext())
                {
                    return (db.Entradas.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name)).ToList();
                }
            }
        }

        public static List<DepositosList> Depositos
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                        return (from c in db.Depositos
                                where c.UserDel == null
                                      && Seguridad.IdDepositosAsignados.Contains(c.Id)
                                select new DepositosList
                                {
                                    Key = c.Id,
                                    Name = c.Descripcion,
                                    Default = 0
                                }).OrderBy(t => t.Name).ToList();
                    else
                    {
                        int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                        return (from u in db.SeguridadUsuariosDepositos
                                join cc in db.Depositos on u.Id_Deposito equals cc.Id into listCC
                                from c in listCC
                                join suc in db.SeguridadUsuarioDepositoDefault on new { u.Id_Deposito, u.Id_Usuario } equals new { suc.Id_Deposito, suc.Id_Usuario } into listDef
                                from def in listDef.DefaultIfEmpty()
                                where c.UserDel == null &&
                                      u.UserDel == null &&
                                      Seguridad.IdDepositosAsignados.Contains(c.Id) &&
                                      u.Id_Usuario == IdUser
                                select new DepositosList
                                {
                                    Key = c.Id,
                                    Name = c.Descripcion,
                                    Default = def.Id_Deposito
                                }).OrderByDescending(t => t.Default).ToList();
                    }
                }
            }
        }

        public class DepositosList
        {
            public int Key { get; set; }
            public string Name { get; set; }
            public int? Default { get; set; }
        }

        public static List<KeyNamePair> Provincias
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (db.Provincias.Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name)).ToList();
                }
            }
        }

        public static List<KeyNamePair> TipoComprobante
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (db.TipoComprobante.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name)).ToList();
                }
            }
        }

        public static List<KeyNamePair> TipoComprobanteVentas
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (db.TipoComprobante.Where(t => t.UserDel == null && t.InternoSistema == false && t.Id_Area == Enums.ComprobanteArea.Ventas).OrderBy(t => t.Orden).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion })).ToList();
                }
            }
        }

        public static List<KeyNamePair> TipoComprobanteCompras
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (db.TipoComprobante.Where(t => t.UserDel == null && t.InternoSistema == false && t.Id_Area == Enums.ComprobanteArea.Compras).OrderBy(t => t.Orden).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion })).ToList();
                }
            }
        }

        public static List<KeyNamePair> TipoComprobanteConTalonarios
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    List<KeyNamePair> result = new List<KeyNamePair>();

                    foreach (TipoComprobante t in db.TipoComprobante.Where(t => t.UserDel == null && (t.Id_Area == Enums.ComprobanteArea.Compras || t.Id_Area == Enums.ComprobanteArea.Ventas)))
                    {
                        result.Add(new KeyNamePair()
                        {
                            Key = t.Id,
                            Name = t.Descripcion + " - " + t.Id_Area
                        });
                    }

                    return result;
                }
            }
        }

        public static List<KeyNamePair> TipoComprobanteLibres
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (db.TipoComprobante.Where(t => t.UserDel == null && t.InternoSistema == false && t.Id_Area == Enums.ComprobanteArea.Libre).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name)).ToList();
                }
            }
        }

        public static List<KeyNamePair> EspeciesTodas
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.Especies.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public class EspeciesList
        {
            public int Key { get; set; }
            public string Name { get; set; }
            public int? Default { get; set; }
        }

        public static List<EspeciesList> Especies
        {
            get
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]) == false)
                {
                    int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                    using (GeneralContext db = new GeneralContext())
                    {
                        List<EspeciesList> r = (from e in db.Especies
                                                join c in db.Cajas on e.Id equals c.Id_Especie into listCajas
                                                from caja in listCajas
                                                where e.UserDel == null
                                                      && caja.UserDel == null
                                                      && Seguridad.IdCajasAsignadas.Contains(caja.Id)
                                                select new EspeciesList
                                                {
                                                    Key = e.Id,
                                                    Name = e.Descripcion,
                                                    Default = null
                                                }).Distinct().ToList();

                        int IdEspecie = (from d in db.SeguridadUsuarioCajaDefault
                                         join ca in db.Cajas on d.Id_Caja equals ca.Id into listCa
                                         from c in listCa
                                         where d.Id_Usuario == IdUser
                                         select c.Id_Especie).FirstOrDefault();

                        return r.Where(t => t.Key != IdEspecie).Select(t => new EspeciesList() { Key = t.Key, Name = t.Name, Default = t.Default })
                                .Union(r.Where(t => t.Key == IdEspecie).Select(t => new EspeciesList { Key = t.Key, Name = t.Name, Default = IdUser }).ToList()).OrderByDescending(t => t.Default).ToList();
                    }
                }
                else
                {

                    using (GeneralContext db = new GeneralContext())
                    {
                        return (db.Especies.Where(t => t.UserDel == null &&
                                                 (db.Cajas.Where(c => Seguridad.IdCajasAsignadas.Contains(c.Id)).Select(c => c.Id_Especie)).Contains(t.Id))
                                           .Select(t => new EspeciesList() { Key = t.Id, Name = t.Descripcion })).OrderByDescending(t => t.Name).ToList();
                    }
                }
            }
        }

        public static List<KeyNamePair> Empresas
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.Empresas.Where(t => t.UserDel == null && Seguridad.IdEmpresasAsignadas.Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<KeyName2Pair> EmpresasCuit
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.Empresas.Where(t => t.UserDel == null && (t.RutaCertSigner != "" && t.RutaCertSigner != null) && Seguridad.IdEmpresasAsignadas.Contains(t.Id)).Select(t => new KeyName2Pair() { Key = t.Id, Name = t.Cuit, Name2 = t.Nombre }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<KeyNamePair> UnidadesNegocios
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.UnidadNegocios.Where(t => t.UserDel == null && Seguridad.IdUnidadesNegociosAsignadas.Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<KeyNamePair> UnidadesNegociosTrafico
        {
            get
            {
                using (ErsaContext db = new ErsaContext())
                {
                    return (from c in db.UnidadNegocios_Configuracion
                            join un in db.UnidadesNegocios on c.Id_UnidadNegocio equals un.Id into listUN
                            from u in listUN
                            where u.UserDel == null &&
                                  Seguridad.IdUnidadesNegociosAsignadas.Contains(u.Id)
                            select new KeyNamePair() { Key = u.Id, Name = u.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<KeyNamePair> UnidadesNegociosLargaDistancia
        {
            get
            {
                using (ErsaContext db = new ErsaContext())
                {
                    return (from u in db.UnidadesNegocios
                            where u.UserDel == null
                              && (db.Lineas.Where(t => t.UserDel == null && t.MediaLargaDistancia == true).Select(t => t.Id_UnidadNegocio)).Contains(u.Id)
                              && Seguridad.IdUnidadesNegociosAsignadas.Contains(u.Id)
                            select new KeyNamePair() { Key = u.Id, Name = u.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static List<CodigoPostal> CodPostal
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return (from d in db.Localidades
                            join p in db.Provincias on d.Id_Provincia equals p.Id into listProv
                            from prov in listProv
                            where d.UserDel == null
                            select new CodigoPostal()
                            {
                                Id = d.Id,
                                CodPostal = d.CodPostal,
                                Localidad = d.Localidad,
                                Provincia = prov.Descripcion
                            }
                        ).ToList();
                }
            }
        }

        public class CodigoPostal
        {
            public int Id { get; set; }
            public int CodPostal { get; set; }
            public string Localidad { get; set; }
            public string Provincia { get; set; }

            public string Descripcion { get { return CodPostal + " - " + Localidad; } }
        }

        public static List<KeyNamePair> FormasPagos { get { using (var db = new GestionContext()) { return db.FormasPagos.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Key).ToList(); } } }

        public static List<KeyNamePair> TiposIva { get { using (var db = new GestionContext()) { return db.TipoIva.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Nombre }).OrderBy(t => t.Name).ToList(); } } }

        public static List<Key2NamePair> ObtenerTalonario(int Id_Sucursal, int Id_TipoComprobante, Enums.TipoEntidad Id_TipoEntidad, int Id_Entidad)
        {
            List<Key2NamePair> r = new List<Key2NamePair>();

            string Letra = "";
            int Id_TipoIvaDestino = 0;

            GestionContext db = new GestionContext();

            switch (Id_TipoEntidad)
            {
                case Enums.TipoEntidad.Cliente:
                    Id_TipoIvaDestino = (from t in db.Clientes where t.Id == Id_Entidad select t.Id_TipoIva).FirstOrDefault();
                    break;
                case Enums.TipoEntidad.Proveedor:
                    Id_TipoIvaDestino = (from t in db.Proveedores where t.Id == Id_Entidad select t.Id_TipoIva).FirstOrDefault();
                    break;
                case Enums.TipoEntidad.Proveedor_Financiero:
                    Id_TipoIvaDestino = (from t in db.ProvFinancieros where t.Id == Id_Entidad select t.Id_TipoIva).FirstOrDefault();
                    break;
                case Enums.TipoEntidad.Personal:
                    Id_TipoIvaDestino = (from t in db.Personal where t.Id == Id_Entidad select t.Id_TipoIva).FirstOrDefault();
                    break;
            }

            Letra = (from tic in db.TipoIva_Configuracion
                     join emp in db.Empresas on tic.Id_TipoIvaOrigen equals emp.Id_TipoIva into listEmp
                     from e in listEmp
                     join suc in db.Sucursales on e.Id equals suc.Id_Empresa into listSuc
                     from s in listSuc
                     where s.Id == Id_Sucursal
                     && tic.Id_TipoComprobante == Id_TipoComprobante
                     && tic.Id_TipoIvaDestino == Id_TipoIvaDestino
                     && tic.UserDel == null
                     && e.UserDel == null
                     && s.UserDel == null
                     select tic.Letra).FirstOrDefault();

            if (string.IsNullOrEmpty(Letra))
                throw new ValidationException("No existe la configuración para la empresa y el comprobante.");


            r = (from tc in db.TalonariosComprobantes
                 join pv in db.PuntosVentas on tc.Id_PuntoVenta equals pv.Id into listPV
                 from punto in listPV
                 where tc.UserDel == null &&
                       tc.Id_Comprobante == Id_TipoComprobante &&
                       tc.Letra == Letra &&
                      (from pv in db.PuntosVentas
                       where pv.Id_Sucursal == Id_Sucursal
                       select pv.Id).Contains(tc.Id_PuntoVenta) &&
                       Seguridad.IdPuntosVentasAsignados.Contains(punto.Id)
                 select new Key2NamePair()
                 {
                     Key = tc.Id,
                     Key2 = tc.Id_Deposito.Value,
                     Name = tc.Letra + "-" + punto.PuntoVenta
                 }).OrderBy(t => t.Name).ToList();

            if (r.Count == 0)
                throw new ValidationException("No hay talonarios disponibles.");
            else
                return r;
        }

        public static List<KeyNamePair> ObtenerEntidades(Enums.TipoEntidad? Id_TipoEntidad)
        {
            List<KeyNamePair> r = new List<KeyNamePair>();

            if (Id_TipoEntidad != null)
                using (GestionContext db = new GestionContext())
                {
                    switch (Id_TipoEntidad)
                    {
                        case Enums.TipoEntidad.Cliente:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Clientes.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Nombre }).ToList();
                            else
                            {
                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
                                    r = (from c in db.Clientes
                                         join e in db.EntidadesEmpresas on c.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Cliente
                                            && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                            && ee.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Nombre }).Distinct().ToList();

                                else if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
                                    r = (from c in db.Clientes
                                         join e in db.EntidadesUnidadNegocios on c.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Cliente
                                            && Seguridad.IdUnidadesNegociosAsignadas.Contains(ee.Id_UnidadNegocio)
                                            && ee.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Nombre }).Distinct().ToList();
                                else
                                    r = db.Clientes.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Nombre }).ToList();
                            }
                            break;

                        case Enums.TipoEntidad.Proveedor:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Proveedores.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Nombre }).ToList();
                            else
                            {
                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
                                    r = (from c in db.Proveedores
                                         join e in db.EntidadesEmpresas on c.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Proveedor
                                            && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                            && ee.UserDel == null
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Nombre }).Distinct().ToList();

                                else if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
                                    r = (from c in db.Proveedores
                                         join e in db.EntidadesUnidadNegocios on c.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Proveedor
                                            && Seguridad.IdUnidadesNegociosAsignadas.Contains(ee.Id_UnidadNegocio)
                                            && ee.UserDel == null
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Nombre }).Distinct().ToList();
                                else
                                    r = db.Proveedores.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Nombre }).ToList();
                            }
                            break;

                        case Enums.TipoEntidad.Proveedor_Financiero:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = (from pf in db.ProvFinancieros
                                     join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                     from c in listCuentas
                                     where pf.UserDel == null
                                        && c.UserDel == null
                                     select new KeyNamePair() { Key = c.Id, Name = pf.Nombre + " - " + c.CBU }).ToList();
                            else
                            {
                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
                                    r = (from pf in db.ProvFinancieros
                                         join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                         from c in listCuentas
                                         join e in db.EntidadesEmpresas on pf.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero
                                            && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                            && pf.UserDel == null
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = pf.Nombre + " - " + c.CBU }).Distinct().ToList();

                                else if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
                                    r = (from pf in db.ProvFinancieros
                                         join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                         from c in listCuentas
                                         join e in db.EntidadesUnidadNegocios on pf.Id equals e.Id_Entidad into listEmp
                                         from ee in listEmp
                                         where ee.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero
                                            && Seguridad.IdUnidadesNegociosAsignadas.Contains(ee.Id_UnidadNegocio)
                                            && pf.UserDel == null
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = pf.Nombre + " - " + c.CBU }).Distinct().ToList();
                                else
                                    r = (from pf in db.ProvFinancieros
                                         join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                         from c in listCuentas
                                         where pf.UserDel == null
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = pf.Nombre + " - " + c.CBU }).ToList();
                            }
                            break;

                        case Enums.TipoEntidad.Personal:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Personal.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Apellido + ", " + c.Nombre }).ToList();
                            else
                            {
                                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
                                    r = (from c in db.Personal
                                         where Seguridad.IdEmpresasAsignadas.Contains(c.Id_Empresa)
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Apellido + ", " + c.Nombre }).ToList();

                                else if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
                                    r = (from c in db.Personal
                                         where Seguridad.IdUnidadesNegociosAsignadas.Contains(c.LaboralId_UnidadNegocio)
                                            && c.UserDel == null
                                         select new KeyNamePair() { Key = c.Id, Name = c.Apellido + ", " + c.Nombre }).ToList();
                                else
                                    r = db.Personal.Where(c => c.UserDel == null).Select(c => new KeyNamePair() { Key = c.Id, Name = c.Apellido + ", " + c.Nombre }).ToList();
                            }
                            break;
                    }
                }
            return r.OrderBy(t => t.Name).ToList();
        }

        public static string GetNombreEntidad(Enums.TipoEntidad? Tipo, int? Id_Entidad)
        {
            string r = "";

            if (Tipo != null && Id_Entidad != null)
                using (var db = new TesoreriaContext())
                {
                    switch (Tipo)
                    {
                        case Enums.TipoEntidad.Cliente:
                            r = db.Clientes.Where(t => t.Id == Id_Entidad).Select(t => t.Nombre).FirstOrDefault();
                            break;
                        case Enums.TipoEntidad.Personal:
                            r = db.Personal.Where(t => t.Id == Id_Entidad).Select(t => t.Apellido + ", " + t.Nombre).FirstOrDefault();
                            break;
                        case Enums.TipoEntidad.Proveedor:
                            r = db.Proveedores.Where(t => t.Id == Id_Entidad).Select(t => t.Nombre).FirstOrDefault();
                            break;
                        case Enums.TipoEntidad.Proveedor_Financiero:
                            r = (from pf in db.ProvFinancieros
                                 join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                 from c in listCuentas
                                 where c.Id == Id_Entidad
                                 select pf.Nombre).FirstOrDefault();
                            break;
                    }
                }
            return r;
        }

        public static bool ValidarCUIT(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit) || cuit.Length != 11 || !cuit.All(Char.IsNumber)) return false;

            var factores = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            var acumulado = 0;

            for (int i = 0; i < factores.Length; i++)
                acumulado += int.Parse(cuit[i].ToString()) * factores[i];

            acumulado = 11 - (acumulado % 11);
            if (acumulado == 11)
                acumulado = 0;
            if (int.Parse(cuit[10].ToString()) != acumulado)
                return false;

            return true;
        }
    }
}
