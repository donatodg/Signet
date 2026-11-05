namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class ReporteServiciosPorDiaManager
    {
        public ReporteServiciosPorDiaManager()
        {

        }
        public List<Reporte> Buscar(ParametrosBusquedas par)
        {
            List<Reporte> r = new List<Reporte>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteServciosPorDia", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter2 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter3 = new SqlParameter("UNegocio", par.Id_UnidadNegocio);
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
                        case "HoraInicio": o.HoraInicio = dr.GetDateTime(i).ToString("HH:mm"); break;
                        case "HoraFin": o.HoraFin = dr.GetDateTime(i).ToString("HH:mm"); break;
                        case "TotalHoras": o.TotalHoras = dr.GetString(i); break;
                        case "Linea": o.Linea = dr.GetString(i); break;
                        case "Turno": o.Turno = dr.GetString(i); break;
                        case "Legajo": o.Legajo = dr.GetInt32(i); break;
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Servicio": o.Servicio = dr.GetInt32(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = Sistema.ObtenerFecha();
                FechaHasta = Sistema.ObtenerFecha().AddMinutes(59);
            }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public int? Id_UnidadNegocio { get; set; }

        }

        public class Reporte
        {
            public string HoraInicio { get; set; }
            public string HoraFin { get; set; }
            public string TotalHoras { get; set; }
            public int? Legajo { get; set; }
            public string Linea { get; set; }
            public string Turno { get; set; }
            public DateTime Fecha { get; set; }
            public int Servicio { get; set; }
        }
    }
}
