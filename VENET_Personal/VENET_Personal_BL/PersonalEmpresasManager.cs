namespace VENET_Personal_BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class PersonalEmpresasManager : IDisposable
    {
        private PersonalContext db;
        public Personal Personal { get; set; }

        public PersonalEmpresasManager(Personal o)
        {
            db = new PersonalContext();
            Personal = o;

            db.Personal.Attach(Personal);

            if (Personal.Id > 0)
            {
                db.Entry(Personal).Reload();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            db.Entry(Personal).State = System.Data.Entity.EntityState.Modified;
            Personal.FechaMod = Sistema.ObtenerFechaHora();
            Personal.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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
