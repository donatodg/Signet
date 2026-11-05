namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_DataEntity;

    public class SeguridadUsuariosActivosManager
    {
        public SeguridadUsuariosActivosManager()
        {

        }

        public  List<SearchResult> Buscar()
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("UsuariosActivos", sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
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
                        case "Id_Usuario": o.Id_Usuario = dr.GetInt32(i); break;
                        case "Usuario": o.Usuario = dr.GetString(i); break;
                        case "Apellido": o.Apellido = dr.GetString(i); break;
                        case "Nombre": o.Nombre = dr.GetString(i); break;
                        case "Ingreso": o.Ingreso = dr.GetDateTime(i); break;
                        case "VersionSistema": o.VersionSistema = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        public class SearchResult
        {
            public int Id_Usuario { get; set; }
            public string Usuario { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public DateTime Ingreso { get; set; }
            public string VersionSistema { get; set; }
        }

    }
}