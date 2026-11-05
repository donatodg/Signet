namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ReporteCochesComparativoManager
    {
        public ReporteCochesComparativoManager()
        {

        }

        public List<Reporte> Buscar(ParametrosBusquedas par)
        {
            List<Reporte> r = new List<Reporte>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasCabecera", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    using (IDataReader dr = cmdReport.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.Add(Load(dr));
                        }
                    }
                }
                return r;
            }
        }

        private Reporte Load(IDataRecord dr)
        {
            Reporte o = new Reporte();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "TotalCoches": o.TotalCoches = dr.GetInt32(i); break;
                        case "CochesPlanificadosUtilizados": o.CochesPlanificadosUtilizados = dr.GetInt32(i); break;
                        case "Ejecutados": o.Ejecutados = dr.GetInt32(i); break;
                        case "Taller": o.Taller = dr.GetInt32(i); break;
                        case "CochesPlanificadosNoUtilizados": o.CochesPlanificadosNoUtilizados = dr.GetInt32(i); break;
                    }
                }
            }

            return o;
        }

        public DataTable BuscarFlota(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasFlota", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    SqlDataReader dr = cmdReport.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
            }
        }

        public DataTable BuscarPlanificados(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasPlanificados", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    SqlDataReader dr = cmdReport.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
            }
        }

        public DataTable BuscarParados(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasParados", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    SqlDataReader dr = cmdReport.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
            }
        }

        public DataTable BuscarEjecutados(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasEjecutados", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    if (cmdReport.Connection.State == ConnectionState.Closed) cmdReport.Connection.Open();
                    SqlDataReader dr = cmdReport.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    return dt;
                }
            }
        }

        public DataTable BuscarTaller(ParametrosBusquedas par)
        {
            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteCochesPorFechasTaller", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("IdUN", par.Id_UnidadNegocio);
                    SqlParameter Parameter4 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
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
            public int Id_UnidadNegocio { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public List<KeyNamePair> UnidadesNegocios { get; private set; }

            public ParametrosBusquedas()
            {
                UnidadesNegocios = Sistema.UnidadesNegocios;
                UnidadesNegocios.RemoveAll(x => x.Key == 23);
                UnidadesNegocios.Where(x => x.Key == 3).ToList().ForEach(x => x.Name = "Buses Urbanos Corrientes");

                UnidadesNegocios.Add(new KeyNamePair() { Key = 0, Name = "Todas" });
                Id_UnidadNegocio = 0;

                FechaDesde = FechaHasta = Sistema.ObtenerFecha().AddDays(-1);
                //DateTime f = Sistema.ObtenerFecha();
                //FechaDesde = new DateTime(f.Year, f.Month, 01);
                //FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
            }
        }

        public class Reporte
        {
            public int TotalCoches { get; set; }
            public int CochesPlanificadosUtilizados { get; set; }
            public int Ejecutados { get; set; }
            public int Taller { get; set; }
            public int CochesPlanificadosNoUtilizados { get; set; }
        }
    }
}
