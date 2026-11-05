namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using VENET_Comum;
    using VENET_DataEntity;

    public sealed class SeguridadObjeto
    {
        private static volatile List<SeguridadObjetos> instance = null;
        private static volatile SeguridadGrupos GrupoUsuario = null;
        private static object syncRoot = new object();

        /// <summary>
        /// El constructor es privado
        /// se accede solo de la instancia
        /// </summary>
        private SeguridadObjeto()
        {
            using (var db = new SeguridadContext())
            {
                Int32 u = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Int32 IdGrupo = db.SeguridadUsuarios.Where(t => t.Id == u).Select(t => t.Id_Grupo).FirstOrDefault();
                GrupoUsuario = db.SeguridadGrupos.Find(IdGrupo);

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
                            new SeguridadObjeto();

                return instance;
            }
        }

        private static String GetDescription(Enum value)
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
            new SeguridadObjeto();
        }

        public static Boolean ObtenerPermiso(Enums.Modulos Modulo, String Formulario, Enums.Accion Accion, String TipoNuevoAccion = "")
        {
            if (instance == null) new SeguridadObjeto();

            String Permiso;
            if (Accion == Enums.Accion.Operaciones) Permiso = TipoNuevoAccion.ToString(); else Permiso = Accion.ToString();
            if (Accion == Enums.Accion.Ver) Permiso = TipoNuevoAccion.ToString(); else Permiso = Accion.ToString();

            Int32 r = instance.Where(t => t.Modulo == Modulo && t.Formulario == Formulario && t.Permiso == Permiso).Select(t => t.Id).FirstOrDefault();

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


        //public static Boolean ObtenerPermiso(Permiso o)
        //{
        //    //if (instance == null) new SeguridadObjeto();
        //    //if (GrupoUsuario.EsAdministrador) return true;

        //    //String n = GetDescription(o);

        //    //Int32 r = instance.Where(t => t.Permiso == n).Select(t => t.Id).FirstOrDefault();

        //    //if (r == 0)
        //    //{
        //    //    using (var db = new SeguridadContext())
        //    //    {
        //    //        r = db.SeguridadObjetos.Where(t => t.Permiso == n).Select(t => t.Id).FirstOrDefault();
        //    //    }

        //    //    if (r == 0)
        //    //    {
        //    //        GrabarPermiso(n);
        //    //    }

        //    //    Sistema.Mensaje("El usuario no cuenta con el permiso '" + n + "'.", "Usuario sin permiso.");
        //    //    return false;
        //    //}

        //    return true;
        //}

        //public enum Permiso
        //{
        //    Lineas_Ingresar = 1,
        //    Lineas_Agregar = 2,
        //    Lineas_Modificar = 3,
        //    Lineas_Eliminar = 4,
        //    Lineas_Buscar = 5
        //}

        private static void GrabarPermiso(Enums.Modulos Modulo, String Formulario, String Permiso)
        {
            SeguridadObjetos p = new SeguridadObjetos();
            p.Permiso = Permiso;
            p.Formulario = Formulario;
            p.Modulo = Modulo;

            //switch (o)
            //{
            //    case "Lineas_Ingresar":
            //        {

            //            p.Modulo = Enums.Modulos.Trafico;
            //            p.Formulario = "Líneas";
            //            p.Descripcion = "Permite el ingreso al formulario de líneas.";
            //            break;
            //        }
            //    case "Lineas_Agregar":
            //        {
            //            p.Modulo = Enums.Modulos.Trafico;
            //            p.Formulario = "Líneas";
            //            p.Descripcion = "Permite agregar líneas.";
            //            break;
            //        }
            //    case "Lineas_Modificar":
            //        {
            //            p.Modulo = Enums.Modulos.Trafico;
            //            p.Formulario = "Líneas";
            //            p.Descripcion = "Permite modificar líneas.";
            //            break;
            //        }
            //    case "Lineas_Eliminar":
            //        {
            //            p.Modulo = Enums.Modulos.Trafico;
            //            p.Formulario = "Líneas";
            //            p.Descripcion = "Permite eliminar líneas.";
            //            break;
            //        }
            //}

            using (var db = new SeguridadContext())
            {
                var err = db.GetValidationErrors();
                if (err.Count() > 0) throw new ValidationException(
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
