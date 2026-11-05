namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ImagenesManager
    {
        private string _Tabla;
        private int _Id_Tabla;
        public List<Imagenes> ListImagen { get; set; }

        public ImagenesManager(string Tabla, int Id_Tabla)
        {
            _Tabla = Tabla;
            _Id_Tabla = Id_Tabla;

            GeneralContext db = new GeneralContext();

            ListImagen = new List<Imagenes>();
            ListImagen.AddRange(db.Imagenes.Where(t => t.Tabla == _Tabla & t.Id_Tabla == _Id_Tabla && t.UserDel == null).OrderBy(t => t.Orden).ToList());
        }

        public List<KeyNamePair> Categorias
        {
            get
            {
                using (var db = new GeneralContext())
                {
                    return db.TipoCategoriasImagenes.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
                }
            }
        }

        public static bool Modificar(Imagenes o, string Descripcion, int IdCategoria, int Orden)
        {
            try
            {
                using (var db = new GeneralContext())
                {
                    db.Imagenes.Attach(o);

                    db.Entry(o).State = EntityState.Modified;
                    db.Entry(o).Reload();

                    o.Descripcion = Descripcion;
                    o.Id_CategoriaImagen = IdCategoria;
                    o.Orden = Orden;
                    o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    o.FechaMod = Sistema.ObtenerFechaHora();

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool Eliminar(Imagenes o)
        {
            try
            {
                using (var db = new GeneralContext())
                {
                    db.Imagenes.Attach(o);
                    db.Entry(o).State = EntityState.Modified;
                    db.Entry(o).Reload();

                    o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    o.FechaDel = Sistema.ObtenerFechaHora();

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool Agregar(Imagenes o)
        {
            try
            {
                using (var db = new GeneralContext())
                {
                    db.Imagenes.Attach(o);
                    db.Entry(o).State = EntityState.Added;

                    o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    o.FechaAdd = Sistema.ObtenerFechaHora();

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception) { return false; }
        }

    }
}
