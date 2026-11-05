namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class KmsHsPlanificadasManager
    {
        public KmsHsPlanificadasManager()
        {

        }

        public List<Reporte> Buscar(ParametrosBusquedas par)
        {
            List<Reporte> r = new List<Reporte>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ReporteKmsHorasPlanificadas", sqlConn);
                using (cmdReport)
                {
                    SqlParameter Parameter1 = new SqlParameter("Planificado", par.Planificado);
                    SqlParameter Parameter2 = new SqlParameter("IdUnidadNegocio", par.Id_UnidadNegocio);
                    SqlParameter Parameter3 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter4 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter5 = new SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    cmdReport.Parameters.Add(Parameter3);
                    cmdReport.Parameters.Add(Parameter4);
                    cmdReport.Parameters.Add(Parameter5);
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
                        case "Descripcion": o.Descripcion = dr.GetString(i); break;
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Kms": o.Kms = dr.GetDecimal(i); break;
                        case "Minutos": o.Horas = Convert.ToDecimal(dr.GetInt32(i)) / 60; break;
                        case "Improductivo": o.Improductivo = dr.GetDecimal(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public int Id_UnidadNegocio { get; set; }
            public int Planificado { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public List<KeyNamePair> UnidadesNegocios { get; private set; }
            public List<KeyNamePair> PlanificadoList
            {
                get
                {
                    List<KeyNamePair> l = new List<KeyNamePair>();
                    l.Add(new KeyNamePair() { Key = 1, Name = "Planificado" });
                    l.Add(new KeyNamePair() { Key = 0, Name = "Ejecutado" });
                    return l;
                }
            }

            public ParametrosBusquedas()
            {
                UnidadesNegocios = Sistema.UnidadesNegocios;
                UnidadesNegocios.Add(new KeyNamePair() { Key = 0, Name = "Todas" });
                Id_UnidadNegocio = 0;
            }
        }

        public class Reporte
        {
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Kms { get; set; }
            public decimal Improductivo { get; set; }
            public decimal Horas { get; set; }
        }
    }
}
