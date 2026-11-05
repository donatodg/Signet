namespace VENET_Tesoreria_BL
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Comun;
    using VENET_DataEntity;

    public class EntidadesCtaCteSaldosManager
    {
        public EntidadesCtaCteSaldosManager()
        {

        }

        public List<SearchResult> Buscar(ParametrosBusquedas p)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("CuentasCorrientesConSaldo", sqlConn);
                using (cmdReport)
                {
                    int Id = 0;
                    switch (p.Id_TipoEntidad)
                    {
                        case Enums.TipoEntidadTodos.Todos: Id = 0; break;
                        case Enums.TipoEntidadTodos.Cliente: Id = 1; break;
                        case Enums.TipoEntidadTodos.Proveedor: Id = 2; break;
                        case Enums.TipoEntidadTodos.Proveedor_Financiero: Id = 3; break;
                        case Enums.TipoEntidadTodos.Personal: Id = 4; break;
                    }

                    SqlParameter Parameter1 = new SqlParameter("Id_TipoEntidad", Id);

                    cmdReport.CommandTimeout = 0;

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
                        case "Tipo_Entidad": o.Tipo_Entidad = dr.GetString(i); break;
                        case "Id_Entidad": o.Id_Entidad = dr.GetInt32(i); break;
                        case "Entidad": o.Entidad = dr.GetString(i); break;
                        case "Id_Especie": o.Id_Especie = dr.GetInt32(i); break;
                        case "Especie": o.Especie = dr.GetString(i); break;
                        case "Saldo": o.Saldo = dr.GetDecimal(i); break;
                    }
                }
            }
            return o;
        }


        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Id_TipoEntidad = Enums.TipoEntidadTodos.Todos;
            }
            public Enums.TipoEntidadTodos Id_TipoEntidad { get; set; }
        }

        public class SearchResult
        {
            public string Tipo_Entidad { get; set; }
            public int Id_Entidad { get; set; }
            public string Entidad { get; set; }
            public int Id_Especie { get; set; }
            public string Especie { get; set; }
            public decimal Saldo { get; set; }
        }

    }
}
