namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using VENET_DataEntity;

    public class TilePrincipal
    {
        public static void BackColor(int Color)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.BackColor = Color.ToString();
                    Usuario.BackImage = null;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void BackImage(Image Imagen)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.BackColor = null;

                    Image bmp = default(Image);
                    decimal escala = default(decimal);
                    int h = 0;
                    int w = 0;

                    h = 250; //Imagen.Height;
                    w = 250; // Imagen.Width;
                    bmp = new Bitmap(w, h);
                    escala = Convert.ToDecimal(Imagen.Height) / Convert.ToDecimal(Imagen.Width);

                    //if (escala > 1)
                    //{
                    //    h = Convert.ToInt32(h * escala);
                    //    y = 75 - Convert.ToInt32(h / 2);
                    //}
                    //else
                    //{
                    //    w = Convert.ToInt32(w / escala);
                    //    x = 75 - Convert.ToInt32(w / 2);
                    //}

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        //g.DrawImage(Imagen, x, y, w, h);
                        g.DrawImage(Imagen, w, h);
                    }

                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        Usuario.BackImage = ms.ToArray();
                    }

                    //Usuario.BackImage = Imagen;

                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Sistema.Mensaje(e.Message);
            }
        }

        public static void TileColor1(int Color, int IdTile)
        {
            try
            {
                using (SeguridadContext db = new SeguridadContext())
                {
                    int IdUsuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    int _Id = (from c in db.SeguridadUsuariosConfiguracion where c.Id_Usuario == IdUsuario && c.Id_Tile == IdTile select c.Id).FirstOrDefault();
                    SeguridadUsuariosConfiguracion u = new SeguridadUsuariosConfiguracion();

                    if (_Id > 0)
                    {
                        u.Id = _Id;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).Reload();
                    }
                    else
                    {
                        u.Id_Usuario = IdUsuario;
                        u.Id_Tile = IdTile;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).State = EntityState.Added;
                    }

                    u.Color1 = Color.ToString();

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void TileColor2(int Color, int IdTile)
        {
            try
            {
                using (SeguridadContext db = new SeguridadContext())
                {
                    int IdUsuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    int _Id = (from c in db.SeguridadUsuariosConfiguracion where c.Id_Usuario == IdUsuario && c.Id_Tile == IdTile select c.Id).FirstOrDefault();
                    SeguridadUsuariosConfiguracion u = new SeguridadUsuariosConfiguracion();

                    if (_Id > 0)
                    {
                        u.Id = _Id;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).Reload();
                    }
                    else
                    {
                        u.Id_Usuario = IdUsuario;
                        u.Id_Tile = IdTile;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).State = EntityState.Added;
                    }
                    u.Color2 = Color.ToString();

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ForeColor(int Color, int IdTile)
        {
            try
            {
                using (SeguridadContext db = new SeguridadContext())
                {
                    int IdUsuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    int _Id = (from c in db.SeguridadUsuariosConfiguracion where c.Id_Usuario == IdUsuario && c.Id_Tile == IdTile select c.Id).FirstOrDefault();

                    SeguridadUsuariosConfiguracion u = new SeguridadUsuariosConfiguracion();
                    if (_Id > 0)
                    {
                        u.Id = _Id;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).Reload();
                    }
                    else
                    {
                        u.Id_Usuario = IdUsuario;
                        u.Id_Tile = IdTile;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).State = EntityState.Added;
                    }
                    u.ColorFuente = Color.ToString();

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ItemOculto(bool Visible, int IdTile)
        {
            try
            {
                using (SeguridadContext db = new SeguridadContext())
                {
                    int IdUsuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    int _Id = (from c in db.SeguridadUsuariosConfiguracion where c.Id_Usuario == IdUsuario && c.Id_Tile == IdTile select c.Id).FirstOrDefault();

                    SeguridadUsuariosConfiguracion u = new SeguridadUsuariosConfiguracion();
                    if (_Id > 0)
                    {
                        u.Id = _Id;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).Reload();
                    }
                    else
                    {
                        u.Id_Usuario = IdUsuario;
                        u.Id_Tile = IdTile;
                        db.SeguridadUsuariosConfiguracion.Attach(u);
                        db.Entry(u).State = EntityState.Added;
                    }
                    u.Visible = Visible;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static List<int> ItemsEliminados()
        {
            using (SeguridadContext db = new SeguridadContext())
            {
                int IdUsuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                return db.SeguridadUsuariosConfiguracion.Where(t => t.Id_Usuario == IdUsuario && t.Visible == false).Select(t => t.Id_Tile).ToList();
            }
        }

        public static void RibbonMinimized(bool Minimized)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.RibbonMinimizado = Minimized;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void TileTitulo(bool Mostrar)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.TituloTile = Mostrar;

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void TileConfig(MemoryStream ms)
        {
            try
            {
                SeguridadUsuarios Usuario;

                using (SeguridadContext db = new SeguridadContext())
                {
                    Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    db.Entry(Usuario).State = EntityState.Modified;

                    Usuario.TileConfig = System.Text.Encoding.UTF8.GetString(ms.ToArray());

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        public static List<SeguridadUsuariosConfiguracion> ConfiguracionUsuario()
        {
            try
            {
                int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                using (SeguridadContext db = new SeguridadContext())
                    return (db.SeguridadUsuariosConfiguracion.Where(t => t.Id_Usuario == IdUser).Select(t => t)).ToList();
            }
            catch (Exception)
            {
                return new List<SeguridadUsuariosConfiguracion>();
            }
        }

    }
}
