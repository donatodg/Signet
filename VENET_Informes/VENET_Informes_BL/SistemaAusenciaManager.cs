namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using VENET_Common;
    using VENET_DataEntity;

    public class SistemaAusenciaManager
    {
        public SistemaAusenciaManager()
        {

        }

        public List<Reporte> Buscar(ParametrosBusquedas par)
        {
            List<Reporte> r = new List<Reporte>();

            using (var db = new ErsaContext())
            {
                SqlConnection sqlConn = (SqlConnection)db.Database.Connection;
                SqlCommand cmdReport = new SqlCommand("ListadoAusencias", sqlConn);
                using (cmdReport)
                {
                    string Ids = "";

                    foreach (int i in Seguridad.IdUnidadesNegociosAsignadas)
                        Ids += "," + i.ToString();

                    SqlParameter Parameter1 = new SqlParameter("Id_UN", Ids.Substring(1));
                    SqlParameter Parameter2 = new SqlParameter("FechaDesde", par.FechaDesde);
                    SqlParameter Parameter3 = new SqlParameter("FechaHasta", par.FechaHasta);
                    SqlParameter Parameter4 = new SqlParameter("Legajo", par.Legajo ?? 0);


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
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "Legajo": o.Legajo = dr.GetInt32(i); break;
                        case "Nombre": o.Nombre = dr.GetString(i); break;
                        case "Tipo": o.Tipo = dr.GetString(i); break;
                        case "Detalle": o.Detalle = dr.GetString(i); break;
                        case "Id": o.Id = dr.GetString(i); break;
                        case "UN": o.UN = dr.GetString(i); break;
                        case "Categoria": o.Categoria = dr.GetString(i); break;
                        case "Id_Personal": o.Id_Personal = dr.GetInt32(i); break;
                        case "Motivo": o.Motivo = dr.GetString(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public int? Legajo { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
        }

        public class Reporte
        {
            public DateTime Fecha { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Detalle { get; set; }
            public string Id { get; set; }
            public string UN { get; set; }
            public string Categoria { get; set; }
            public int Id_Personal { get; set; }
            public string Motivo { get; set; }


        }
    }
}
