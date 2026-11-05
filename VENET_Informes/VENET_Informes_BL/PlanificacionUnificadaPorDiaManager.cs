namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class PlanificacionUnificadaPorDiaManager
    {
        public PlanificacionUnificadaPorDiaManager()
        {

        }

        public List<Reporte> Buscar(ParametrosBusquedas par)
        {
            List<Reporte> r = new List<Reporte>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("PlanificacionUnificadaPorDia", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("Fecha", par.Fecha);
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
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Id_UnidadNegocio": o.Id_UnidadNegocio = dr.GetInt32(i); break;
                        case "UnidadNegocio": o.UnidadNegocio = dr.GetString(i); break;
                        case "Empresa": o.Empresa = dr.GetString(i); break;
                        case "Linea": o.Linea = dr.GetString(i); break;
                        case "Servicio": o.Servicio = dr.GetInt32(i); break;
                        case "Turno": o.Turno = dr.GetInt32(i); break;
                        case "Inicio": o.Inicio = dr.GetString(i); break;
                        case "Destino": o.Destino = dr.GetString(i); break;
                        case "Interno": o.Interno = dr.GetInt32(i); break;
                        case "Legajo": o.Legajo = dr.GetInt32(i); break;
                        case "Personal": o.Personal = dr.GetString(i); break;
                        case "HoraInicio": o.HoraInicio = dr.GetValue(i).ToString().PadLeft(5); break;
                        case "HoraFin": o.HoraFin = dr.GetValue(i).ToString().PadLeft(5); break;
                        case "MediasVueltas": o.MediasVueltas = dr.GetInt32(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public DateTime Fecha { get; set; }
            public ParametrosBusquedas()
            {
                Fecha = Sistema.ObtenerFecha();
            }
        }

        public class Reporte
        {
            public DateTime Fecha { get; set; }
            public int Id_UnidadNegocio { get; set; }
            public string UnidadNegocio { get; set; }
            public string Empresa { get; set; }
            public string Linea { get; set; }
            public int? Servicio { get; set; }
            public int? Turno { get; set; }
            public string Inicio { get; set; }
            public string Destino { get; set; }
            public int? Interno { get; set; }
            public int? Legajo { get; set; }
            public string Personal { get; set; }
            public string HoraInicio { get; set; }
            public string HoraFin { get; set; }
            public int? MediasVueltas { get; set; }
        }
    }
}
