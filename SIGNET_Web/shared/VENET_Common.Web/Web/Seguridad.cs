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

    /// <summary>
    /// Versión web de VENET_Common\Seguridad.cs.
    /// Misma API pública y mismas consultas que el original, pero el estado (permisos y asignaciones)
    /// se guarda por sesión de usuario en lugar de en campos estáticos del proceso.
    /// </summary>
    public sealed class Seguridad
    {
        private Seguridad() { }

        private static SeguridadState State
        {
            get
            {
                var s = SignetRequestContext.RequireSession();
                if (s.Seguridad == null) s.Seguridad = Cargar();
                return s.Seguridad;
            }
        }

        private static SeguridadState Cargar()
        {
            var st = new SeguridadState();
            using (var db = new SeguridadContext())
            {
                int u = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                int IdGrupo = db.SeguridadUsuarios.Where(t => t.Id == u).Select(t => t.Id_Grupo).FirstOrDefault();
                st.GrupoUsuario = db.SeguridadGrupos.Find(IdGrupo);

                if (st.GrupoUsuario != null && st.GrupoUsuario.EsAdministrador)
                {
                    st.IdEmpresasAsignadas = db.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdSucursalesAsignadas = db.Sucursales.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdCentrosCostosAsignados = db.CentrosCostos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdUnidadesNegociosAsignadas = db.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdPuntosVentasAsignados = db.PuntosVentas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdCajasAsignadas = db.Cajas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdDepositosAsignados = db.Depositos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                }
                else
                {
                    st.IdEmpresasAsignadas = db.SeguridadUsuariosEmpresas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Empresa).ToList();
                    st.IdSucursalesAsignadas = db.SeguridadUsuariosSucursales.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Sucursal).ToList();
                    st.IdCentrosCostosAsignados = db.SeguridadUsuariosCentrosCostos.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_CentroCosto).ToList();
                    st.IdUnidadesNegociosAsignadas = db.SeguridadUsuariosUnidadNegocios.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_UnidadNegocio).ToList();
                    st.IdPuntosVentasAsignados = db.SeguridadUsuariosPuntosVentas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_PuntoVenta).ToList();
                    st.IdCajasAsignadas = db.SeguridadUsuariosCajas.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Caja).ToList();
                    st.IdDepositosAsignados = db.SeguridadUsuariosDepositos.Where(t => t.UserDel == null && t.Id_Usuario == u).Select(t => t.Id_Deposito).ToList();
                }

                st.Objetos = (from sgo in db.SeguridadGruposObjetos
                              join so in db.SeguridadObjetos on sgo.Id_Objeto equals so.Id into listObj
                              from obj in listObj
                              where sgo.UserDel == null && sgo.Id_Grupo == IdGrupo
                              select obj).ToList();
            }
            return st;
        }

        public static List<SeguridadObjetos> Instance { get { return State.Objetos; } }

        public static bool EsAdministrador { get { var g = State.GrupoUsuario; return g != null && g.EsAdministrador; } }

        /// <summary>Sesión del login de desarrollo (usuario 1 / clave 1).</summary>
        public static bool EsDesarrollo { get { return State.Desarrollo; } }

        public static List<int> IdEmpresasAsignadas { get { return State.IdEmpresasAsignadas; } set { State.IdEmpresasAsignadas = value; } }
        public static List<int> IdSucursalesAsignadas { get { return State.IdSucursalesAsignadas; } set { State.IdSucursalesAsignadas = value; } }
        public static List<int> IdCentrosCostosAsignados { get { return State.IdCentrosCostosAsignados; } set { State.IdCentrosCostosAsignados = value; } }
        public static List<int> IdPuntosVentasAsignados { get { return State.IdPuntosVentasAsignados; } set { State.IdPuntosVentasAsignados = value; } }
        public static List<int> IdCajasAsignadas { get { return State.IdCajasAsignadas; } set { State.IdCajasAsignadas = value; } }
        public static List<int> IdUnidadesNegociosAsignadas { get { return State.IdUnidadesNegociosAsignadas; } set { State.IdUnidadesNegociosAsignadas = value; } }
        public static List<int> IdDepositosAsignados { get { return State.IdDepositosAsignados; } set { State.IdDepositosAsignados = value; } }

        public static void Reload()
        {
            var s = SignetRequestContext.RequireSession();
            s.Seguridad = s.Seguridad != null && s.Seguridad.Desarrollo ? CargarDesarrollo() : Cargar();
        }

        /// <summary>
        /// Solo entorno de desarrollo: administrador con todas las asignaciones si la base responde,
        /// o listas vacías si no hay conexión.
        /// </summary>
        public static void IniciarDesarrollo()
        {
            SignetRequestContext.RequireSession().Seguridad = CargarDesarrollo();
        }

        private static SeguridadState CargarDesarrollo()
        {
            var st = new SeguridadState
            {
                Desarrollo = true,
                GrupoUsuario = new SeguridadGrupos { EsAdministrador = true },
                Objetos = new List<SeguridadObjetos>()
            };
            try
            {
                using (var db = new SeguridadContext())
                {
                    st.IdEmpresasAsignadas = db.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdSucursalesAsignadas = db.Sucursales.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdCentrosCostosAsignados = db.CentrosCostos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdUnidadesNegociosAsignadas = db.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdPuntosVentasAsignados = db.PuntosVentas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdCajasAsignadas = db.Cajas.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                    st.IdDepositosAsignados = db.Depositos.Where(t => t.UserDel == null).Select(t => t.Id).ToList();
                }
            }
            catch (Exception)
            {
                st.IdEmpresasAsignadas = new List<int>();
                st.IdSucursalesAsignadas = new List<int>();
                st.IdCentrosCostosAsignados = new List<int>();
                st.IdUnidadesNegociosAsignadas = new List<int>();
                st.IdPuntosVentasAsignados = new List<int>();
                st.IdCajasAsignadas = new List<int>();
                st.IdDepositosAsignados = new List<int>();
            }
            return st;
        }

        private static string NombrePermiso(Enums.Accion Accion, string TipoNuevoAccion)
        {
            string Permiso = "";
            if (Accion == Enums.Accion.Operaciones || Accion == Enums.Accion.Ver || Accion == Enums.Accion.Imprimir)
                Permiso = TipoNuevoAccion ?? "";
            if (string.IsNullOrEmpty(Permiso)) Permiso = Accion.ToString();
            return Permiso;
        }

        /// <summary>
        /// Misma lógica que el original: si el permiso no existe en SeguridadObjetos se registra,
        /// los administradores siempre tienen acceso. En la web no se muestra un mensaje: devuelve false
        /// y la API responde 403 con <see cref="MensajeSinPermiso"/>.
        /// </summary>
        public static bool ObtenerPermiso(Enums.Modulos Modulo, string Formulario, Enums.Accion Accion, string TipoNuevoAccion = "")
        {
            var st = State;
            if (st.Desarrollo) return true;
            string Permiso = NombrePermiso(Accion, TipoNuevoAccion);

            int r =  st.Objetos.Where(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso).Select(t => t.Id).FirstOrDefault();

            if (r == 0)
            {
                using (var db = new SeguridadContext())
                {
                    r = db.SeguridadObjetos.Where(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso).Select(t => t.Id).FirstOrDefault();
                }

                if (r == 0)
                    GrabarPermiso(Modulo, Formulario, Permiso);

                return st.GrupoUsuario != null && st.GrupoUsuario.EsAdministrador;
            }

            return true;
        }

        /// <summary>Consulta un permiso sin efectos secundarios (no registra objetos nuevos). Usado para armar el menú.</summary>
        public static bool TienePermiso(Enums.Modulos Modulo, string Formulario, Enums.Accion Accion, string TipoNuevoAccion = "")
        {
            var st = State;
            if (st.GrupoUsuario != null && st.GrupoUsuario.EsAdministrador) return true;
            string Permiso = NombrePermiso(Accion, TipoNuevoAccion);
            return st.Objetos.Any(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso);
        }

        public static string MensajeSinPermiso(Enums.Accion Accion, string Formulario, string TipoNuevoAccion = "")
        {
            return "El usuario no cuenta con el permiso '" + NombrePermiso(Accion, TipoNuevoAccion) + "' en el formulario '" + Formulario + "'.";
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
