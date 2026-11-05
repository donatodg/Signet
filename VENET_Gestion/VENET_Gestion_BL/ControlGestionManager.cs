namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ControlGestionManager
    {
        public static DataSet Buscar(ParametrosBusquedas parametros)
        //public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                //List<SearchResult> r = new List<SearchResult>();
                DataSet ds = new DataSet();

                //ProcesosVarios

                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ProcesosVarios", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", parametros.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", parametros.FechaHasta);

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmdReport);
                    da.Fill(ds);
                }

                return ds;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaHasta = Sistema.ObtenerFecha();
                FechaDesde  = FechaHasta.AddMonths(-3);
            }

            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
        }

        public class SearchResult
        {

        }
    }
}
