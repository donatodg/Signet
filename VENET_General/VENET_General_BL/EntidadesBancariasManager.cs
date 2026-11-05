namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class EntidadesBancariasManager : IDisposable
    {
        private GeneralContext db;
        public EntidadesBancarias Entidad { get; set; }

        public EntidadesBancariasManager(EntidadesBancarias o)
        {
            db = new GeneralContext();
            Entidad = o;

            db.EntidadesBancarias.Attach(Entidad);

            if (Entidad.Codigo > 0) db.Entry(Entidad).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Entidad.UserAdd != 0)
            {
                db.Entry(Entidad).State = EntityState.Modified;
                Entidad.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Entidad.FechaMod = Sistema.ObtenerFechaHora();


                var err = db.GetValidationErrors();
                if (err.Count() > 0) throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
            else
            {
                string q = string.Format("INSERT INTO EntidadesBancarias (Codigo,Descripcion,FechaAdd,FechaMod,UserAdd,UserMod) VALUES ({0},'{1}','{2}',null,{3},null)", Entidad.Codigo, Entidad.Descripcion, Sistema.ObtenerFechaHora(), Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand(q, sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    cmdReport.ExecuteNonQuery();
                }
            }
        }

        public static void Eliminar(EntidadesBancarias o)
        {
            using (var db = new GeneralContext())
            {
                string q = string.Format("DELETE EntidadesBancarias WHERE Codigo = {0}", o.Codigo);
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand(q, sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    cmdReport.ExecuteNonQuery();
                }
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from e in db.EntidadesBancarias
                     where (e.Codigo == parametros.Codigo || parametros.Codigo == null)
                            && (e.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                     select new SearchResult
                     {
                         Codigo = e.Codigo,
                         Descripcion = e.Descripcion,
                         FechaAdd = e.FechaAdd,
                         FechaMod = e.FechaMod,
                         UserAdd = e.UserAdd,
                         UserMod = e.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Codigo { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : EntidadesBancarias
        {

        }

    }
}
