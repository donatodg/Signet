namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Comun;
    using VENET_DataEntity;

    public sealed class Seguridad
    {
        private static volatile List<SeguridadObjetos> instance = null;
        private static volatile SeguridadGrupos GrupoUsuario = null;
        private static object syncRoot = new object();
        public static volatile List<int> IdEmpresasAsignadas = null;
        public static volatile List<int> IdSucursalesAsignadas = null;
        public static volatile List<int> IdCentrosCostosAsignados = null;
        public static volatile List<int> IdPuntosVentasAsignados = null;
        public static volatile List<int> IdCajasAsignadas = null;
        public static volatile List<int> IdUnidadesNegociosAsignadas = null;
        public static volatile List<int> IdDepositosAsignados = null;

        /// <summary>
        /// El constructor es privado
        /// se accede solo de la instancia
        /// </summary>
        private Seguridad()
        {
            using (var db = new SeguridadContext())
            {
                int u = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                int IdGrupo = db.SeguridadUsuarios.Where(t => t.Id == u).Select(t => t.Id_Grupo).FirstOrDefault();
                GrupoUsuario = db.SeguridadGrupos.Find(IdGrupo);

                if (GrupoUsuario.EsAdministrador)
                {
                    IdEmpresasAsignadas = db.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdSucursalesAsignadas = db.Sucursales.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdCentrosCostosAsignados = db.CentrosCostos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdUnidadesNegociosAsignadas = db.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdPuntosVentasAsignados = db.PuntosVentas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdCajasAsignadas = db.Cajas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    IdDepositosAsignados = db.Depositos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                }
                else
                {
                    IdEmpresasAsignadas = db.SeguridadUsuariosEmpresas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Empresa).ToList();
                    IdSucursalesAsignadas = db.SeguridadUsuariosSucursales.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Sucursal).ToList();
                    IdCentrosCostosAsignados = db.SeguridadUsuariosCentrosCostos.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_CentroCosto).ToList();
                    IdUnidadesNegociosAsignadas = db.SeguridadUsuariosUnidadNegocios.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_UnidadNegocio).ToList();
                    IdPuntosVentasAsignados = db.SeguridadUsuariosPuntosVentas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_PuntoVenta).ToList();
                    IdCajasAsignadas = db.SeguridadUsuariosCajas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Caja).ToList();
                    IdDepositosAsignados = db.SeguridadUsuariosDepositos.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Deposito).ToList();
                }

                instance = (from sgo in db.SeguridadGruposObjetos
                            join so in db.SeguridadObjetos on sgo.Id_Objeto equals so.Id into listObj
                            from obj in listObj
                            where sgo.UserDel == null && sgo.Id_Grupo == IdGrupo
                            select obj).ToList();
            }
        }

        public static List<SeguridadObjetos> Instance
        {
            get
            {
                if (instance == null)
                    lock (syncRoot)
                        if (instance == null)
                            new Seguridad();

                return instance;
            }
        }

        private static string GetDescription(Enum value)
        {
            string Description = value.ToString();

            try
            {
                Description = ((System.ComponentModel.DescriptionAttribute)(value.GetType().GetField(Description).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0])).Description;
            }
            catch (Exception) { }

            return Description;
        }

        public static void Reload()
        {
            new Seguridad();
        }

        public static bool ObtenerPermiso(Enums.Modulos Modulo, string Formulario, Enums.Accion Accion, string TipoNuevoAccion = "")
        {
            if (instance == null) new Seguridad();

            string Permiso = "";

            if (Accion == Enums.Accion.Operaciones || Accion == Enums.Accion.Ver || Accion == Enums.Accion.Imprimir)
                Permiso = TipoNuevoAccion.ToString();

            if (string.IsNullOrEmpty(Permiso)) Permiso = Accion.ToString();

            int r = instance.Where(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso).Select(t => t.Id).FirstOrDefault();

            if (r == 0)
            {
                using (var db = new SeguridadContext())
                {
                    r = db.SeguridadObjetos.Where(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso).Select(t => t.Id).FirstOrDefault();
                }

                if (r == 0)
                {
                    GrabarPermiso(Modulo, Formulario, Permiso);
                }

                if (GrupoUsuario.EsAdministrador) return true;
                else
                {
                    Sistema.Mensaje("El usuario no cuenta con el permiso '" + Permiso + "' en el formulario '" + Formulario + "'.", "Usuario sin permiso.");
                    return false;
                }
            }

            return true;
        }

        private static void GrabarPermiso(Enums.Modulos Modulo, string Formulario, string Permiso)
        {
            SeguridadObjetos p = new SeguridadObjetos();
            p.Permiso = Permiso;
            p.Formulario = Formulario;
            p.Modulo = Modulo;

            using (var db = new SeguridadContext())
            {
                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SeguridadObjetos.Attach(p);
                db.Entry(p).State = EntityState.Added;
                db.SaveChanges();
            }
        }

    }
}
