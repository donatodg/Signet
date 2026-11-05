namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_DataEntity;

    public class SeguridadUsuariosUltimoLogManager
    {
        public SeguridadUsuariosUltimoLogManager()
        {

        }

        public List<SearchResult> Buscar(int IdUser)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("UsuarioLog", sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    SqlParameter Parameter1 = new SqlParameter("IdUser", IdUser);

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);

                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    using (IDataReader dr = cmdReport.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.Add(Load(dr));
                        }
                    }
                }
            }
            return r;
        }

        private SearchResult Load(IDataRecord dr)
        {
            SearchResult o = new SearchResult();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Accion": o.Accion = dr.GetString(i); break;
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Host": o.Host = dr.GetString(i); break;
                        case "UserLocal": o.UserLocal = dr.GetString(i); break;
                        case "IP_Local": o.IP_Local = dr.GetString(i); break;
                        case "IP_Publica": o.IP_Publica = dr.GetString(i); break;
                        case "VersionSistema": o.VersionSistema = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        public class SearchResult
        {
            public string Accion { get; set; }
            public DateTime Fecha { get; set; }
            public string Host { get; set; }
            public string UserLocal { get; set; }
            public string IP_Local { get; set; }
            public string IP_Publica { get; set; }
            public string VersionSistema { get; set; }
        }
    }
}
