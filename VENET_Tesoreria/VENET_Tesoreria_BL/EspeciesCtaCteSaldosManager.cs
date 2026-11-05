namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class EspeciesCtaCteSaldosManager
    {
        public EspeciesCtaCteSaldosManager()
        {

        }
        public List<SearchResult> Buscar(ParametrosBusquedas p)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("SaldosDeEspecies", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaHasta", p.FechaHasta);
                    SqlParameter Parameter2 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);

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
                        case "Empresa": o.Empresa = dr.GetString(i); break;
                        case "Sucursal": o.Sucursal = dr.GetString(i); break;
                        case "Caja": o.Caja = dr.GetString(i); break;
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
                FechaHasta = Sistema.ObtenerFecha();
            }
            public DateTime FechaHasta { get; set; }
        }

        public class SearchResult
        {
            public string Empresa { get; set; }
            public string Sucursal { get; set; }
            public string Caja { get; set; }
            public string Especie { get; set; }
            public decimal Saldo { get; set; }
        }

    }
}
