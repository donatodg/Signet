using System;
using System.Configuration;
using System.Linq;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;

namespace VENET_IA_BL
{
    /// <summary>
    /// Permisos del asistente: objeto de seguridad Módulo Sistema / Formulario "AsistenteIA" / Permiso "Ingresar",
    /// el mismo que valida Sistema.AbrirForm al abrir frmAsistenteIA. Se asigna a los grupos desde Seguridad.
    /// </summary>
    public static class AsistenteIASeguridad
    {
        public const string Formulario = "AsistenteIA";

        /// <summary>Indica (sin mostrar mensajes) si el usuario actual puede usar el asistente.</summary>
        public static bool TienePermiso()
        {
            AsegurarObjeto();
            if (string.Equals(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"], bool.TrueString, StringComparison.OrdinalIgnoreCase))
                return true;

            var permiso = Enums.Accion.Ingresar.ToString();
            return Seguridad.Instance.Any(t => t.Modulo == Enums.Modulos.Sistema && t.Formulario == Formulario && t.Permiso == permiso);
        }

        /// <summary>Indica si el menú está habilitado en Parámetros (Menu_Sistema_AsistenteIA).</summary>
        public static bool MenuHabilitado()
        {
            try
            {
                return !string.Equals(Parametro.ObtenerValor(Parametro.Param.Menu_Sistema_AsistenteIA), bool.FalseString, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>Crea el objeto de seguridad si no existe, para que aparezca en la asignación de permisos de los grupos.</summary>
        public static void AsegurarObjeto()
        {
            try
            {
                var permiso = Enums.Accion.Ingresar.ToString();
                using (var db = new SeguridadContext())
                {
                    if (db.SeguridadObjetos.Any(t => t.Modulo == Enums.Modulos.Sistema && t.Formulario == Formulario && t.Permiso == permiso))
                        return;

                    db.SeguridadObjetos.Add(new SeguridadObjetos { Modulo = Enums.Modulos.Sistema, Formulario = Formulario, Permiso = permiso });
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                // Sin permisos de escritura o sin conexión: se ignora (Sistema.AbrirForm lo vuelve a intentar).
            }
        }
    }
}
