namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using VENET_Common;
    using VENET_DataEntity;

    public class EmpresasManager : IDisposable
    {
        private GeneralContext db;
        public Empresas Empresa { get; set; }

        public EmpresasManager(Empresas o)
        {
            db = new GeneralContext();
            Empresa = o;

            db.Empresas.Attach(Empresa);

            if (Empresa.Id > 0) db.Entry(Empresa).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Empresa.Id == 0)
            {
                db.Entry(Empresa).State = EntityState.Added;

                Empresa.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Empresa.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Empresa).State = EntityState.Modified;
                Empresa.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Empresa.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Empresas o)
        {
            using (var db = new GeneralContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static string EmpresasVencimiento()
        {
            using (var db = new GeneralContext())
            {
                DateTime f = Sistema.ObtenerFecha().AddMonths(1);
                string result = "";

                try
                {
                    List<string> r = (from e in db.Empresas
                                      where e.FechaVtoCert <= f
                                         && Seguridad.IdEmpresasAsignadas.Contains(e.Id)
                                         && e.UserDel == null
                                      select e.Nombre + " - Vto: " + e.FechaVtoCert).ToList();

                    foreach (string o in r)
                    {
                        result += "      " + o + "\n\r";
                    }

                    if (result != "")
                        result = "Empresas con vencimiento de Certificados AFIP: " + "\n\r" + result;
                }
                catch (Exception) { }
                return result;
            }
        }

        //public static System.Data.DataTable B()
        //{
        //    string cnnstrRemoto = "Data Source=181.14.247.42,2123;Initial Catalog=ErsaGeneral;user id=ersa;password=1234";
        //    SqlConnection cnnRemoto = new SqlConnection(cnnstrRemoto);
        //    cnnRemoto.Open();

        //    if (cnnRemoto.State == System.Data.ConnectionState.Closed) cnnRemoto.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cnnRemoto;
        //    cmd.CommandText = string.Format("exec informeFuelConsolidado_Itati");

        //    SqlDataReader dr = cmd.ExecuteReader();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    dt.Load(dr);

        //    return dt;
        //}
        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.Empresas
                     join cp in db.Localidades on t.Id_CodPostal equals cp.Id into listCP
                     from codpos in listCP.DefaultIfEmpty()
                     join ti in db.TipoIva on t.Id_TipoIva equals ti.Id into listTI
                     from iva in listTI
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Nombre.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.Cuit == parametros.Cuit || parametros.Cuit == null)
                            && (t.UserDel == null)
                            && (Seguridad.IdEmpresasAsignadas.Contains(t.Id))
                     select new SearchResult
                     {
                         Id = t.Id,
                         Nombre = t.Nombre,
                         Fantasia = t.Fantasia,
                         Direccion = t.Direccion,
                         Id_CodPostal = codpos.CodPostal,
                         Localidad = codpos.Localidad,
                         Cuit = t.Cuit,
                         Id_TipoIva = t.Id_TipoIva,
                         TipoIva = iva.Nombre,
                         Actividad = t.Actividad,
                         IngresosBrutos = t.IngresosBrutos,
                         InicioActividades = t.InicioActividades,
                         ClaveCertSigner = t.ClaveCertSigner,
                         FechaVtoCert = t.FechaVtoCert,
                         RutaCertSigner = t.RutaCertSigner,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
            public string Cuit { get; set; }
        }

        public class SearchResult : Empresas
        {
            public string Localidad { get; set; }
            public string TipoIva { get; set; }
        }
    }
}
