namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class PlanificacionCochesParadosPorFechasManager
    {
        public PlanificacionCochesParadosPorFechasManager()
        {

        }

        public DataTable Buscar(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("CochesPorServicioPorFecha", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    SqlDataReader dr = cmdReport.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
            }
        }

        public class ParametrosBusquedas
        {
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public int Id_UnidadNegocio { get; set; }
            public List<KeyNamePair> UnidadesNegocios { get; private set; }

            public ParametrosBusquedas()
            {
                DateTime f = Sistema.ObtenerFecha();
                FechaDesde = new DateTime(f.Year, f.Month, 01);
                FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
                UnidadesNegocios = Sistema.UnidadesNegocios;
                UnidadesNegocios.Add(new KeyNamePair() { Key = 0, Name = "Todas" });
                Id_UnidadNegocio = 0;
            }
        }

    }
}
