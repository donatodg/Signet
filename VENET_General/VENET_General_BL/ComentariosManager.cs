namespace VENET_General_BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_DataEntity;
    using VENET_Common;
    using VENET_Comun;

    public class ComentariosManager : IDisposable
    {
        private GeneralContext db;
        public Comentarios Comentario { get; set; }

        public ComentariosManager(string Tabla, int Id_Tabla)
        {
            db = new GeneralContext();
            Comentario = db.Comentarios.Where(t => t.Tabla == Tabla && t.Id_Tabla == Id_Tabla).FirstOrDefault();

            if (Comentario == null)
                Comentario = new Comentarios() { Tabla = Tabla, Id_Tabla = Id_Tabla, Color = Enums.Colores.Ninguno.ToString() };

            db.Comentarios.Attach(Comentario);
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {

            if (Comentario.Id == 0)
            {
                db.Entry(Comentario).State = EntityState.Added;

                Comentario.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Comentario.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Comentario).State = EntityState.Modified;
                Comentario.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Comentario.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

    }
}
