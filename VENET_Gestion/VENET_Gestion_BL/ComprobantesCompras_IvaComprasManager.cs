namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ComprobantesCompras_IvaComprasManager
    {
        public ComprobantesCompras_IvaComprasManager()
        {

        }

        public static List<SearchResultDetalle> BuscarIvaDetalle(ParametrosBusquedas parametros)
        {
            List<SearchResultDetalle> r = new List<SearchResultDetalle>();

            using (var db = new TesoreriaContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("IVA_ComprasDetalle", sqlConn);

                using (cmd)
                {
                    DateTime Fecha = new DateTime(parametros.Año, parametros.Mes, 1);

                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_Empresa", parametros.Id_Empresa);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Fecha", Fecha);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    using (System.Data.IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.Add(LoadDetalle(dr));
                        }
                    }
                }
                return r;
            }
        }

        private static SearchResultDetalle LoadDetalle(System.Data.IDataRecord dr)
        {
            SearchResultDetalle o = new SearchResultDetalle();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "TipoComprobante": o.TipoComprobante = dr.GetString(i); break;
                        case "Letra": o.Letra = dr.GetString(i); break;
                        case "PuntoVenta": o.PuntoVenta = dr.GetString(i); break;
                        case "NroComprobante": o.NroComprobante = dr.GetString(i); break;
                        case "Entidad": o.Entidad = dr.GetString(i); break;
                        case "Cuit": o.Cuit = dr.GetString(i); break;
                        case "ImporteGravado": o.ImporteGravado = dr.GetDecimal(i); break;
                        case "ImporteNoGravado": o.ImporteNoGravado = dr.GetDecimal(i); break;
                        case "IVA21": o.IVA21 = dr.GetDecimal(i); break;
                        case "IVA105": o.IVA105 = dr.GetDecimal(i); break;
                        case "IVA27": o.IVA27 = dr.GetDecimal(i); break;
                        case "IngresosBrutosCaba": o.IngresosBrutosCaba = dr.GetDecimal(i); break;
                        case "IngresosBrutosBsAs": o.IngresosBrutosBsAs = dr.GetDecimal(i); break;
                        case "PercepcionGanancias": o.PercepcionGanancias = dr.GetDecimal(i); break;
                        case "PercepcionIva": o.PercepcionIva= dr.GetDecimal(i); break;
                        case "OtrasPercepciones": o.OtrasPercepciones = dr.GetDecimal(i); break;
                        case "Total": o.Total = dr.GetDecimal(i); break;
                        case "Observaciones": o.Observaciones = dr.GetString(i); break;
                        case "Concepto": o.Concepto = dr.GetString(i); break;
                    }
                }
            }
            return o;
        }

        public static List<SearchResultIVA> BuscarIva(ParametrosBusquedas parametros)
        {
            List<SearchResultIVA> r = new List<SearchResultIVA>();

            using (var db = new TesoreriaContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("IVA_Compras", sqlConn);

                using (cmd)
                {
                    DateTime Fecha = new DateTime(parametros.Año, parametros.Mes, 1);

                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_Empresa", parametros.Id_Empresa);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Fecha", Fecha);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    using (System.Data.IDataReader dr = cmd.ExecuteReader())
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

        private static SearchResultIVA Load(System.Data.IDataRecord dr)
        {
            SearchResultIVA o = new SearchResultIVA();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "IVA_COMPRAS": o.IVA_COMPRAS = dr.GetString(i); break;
                        case "Fecha": o.Fecha = dr.GetDateTime(i); break;
                        case "TipoComprobante": o.TipoComprobante = dr.GetString(i); break;
                        case "PuntoVenta": o.PuntoVenta = dr.GetString(i); break;
                        case "NroComprobante": o.NroComprobante = dr.GetString(i); break;
                        case "Cuit": o.Cuit = dr.GetString(i); break;
                        case "Entidad": o.Entidad = dr.GetString(i); break;
                        case "Importe": o.Importe = dr.GetDecimal(i); break;
                        case "ImporteSinIva": o.ImporteSinIva = dr.GetDecimal(i); break;
                        case "AlicuotaIvas": o.AlicuotaIvas = dr.GetInt32(i); break;
                    }
                }
            }

            return o;
        }

        public static List<SearchResultAlicuota> BuscarAlicuotaIva(ParametrosBusquedas parametros)
        {
            List<SearchResultAlicuota> r = new List<SearchResultAlicuota>();

            using (var db = new TesoreriaContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("IVA_ComprasAlicuotas", sqlConn);

                using (cmd)
                {
                    DateTime Fecha = new DateTime(parametros.Año, parametros.Mes, 1);

                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_Empresa", parametros.Id_Empresa);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Fecha", Fecha);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    using (System.Data.IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.Add(LoadAlicuotas(dr));
                        }
                    }
                }
                return r;
            }
        }

        private static SearchResultAlicuota LoadAlicuotas(System.Data.IDataRecord dr)
        {
            SearchResultAlicuota o = new SearchResultAlicuota();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "ALICUOTAS": o.ALICUOTAS = dr.GetString(i); break;
                        case "TipoComprobante": o.TipoComprobante = dr.GetString(i); break;
                        case "PuntoVenta": o.PuntoVenta = dr.GetString(i); break;
                        case "NroComprobante": o.NroComprobante = dr.GetString(i); break;
                        case "ImporteGravado": o.ImporteGravado = dr.GetDecimal(i); break;
                        case "AlicuotaIva": o.AlicuotaIva = dr.GetDecimal(i); break;
                        case "ImporteIva": o.ImporteIva = dr.GetDecimal(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Id_Empresa = Sistema.Empresas.First().Key;
                DateTime Fecha = Sistema.ObtenerFecha().AddMonths(-1);

                Mes = Fecha.Month;
                Año = Fecha.Year;
            }

            public int Id_Empresa { get; set; }
            public int Mes { get; set; }
            public int Año { get; set; }
        }

        public class SearchResultDetalle
        {
            public DateTime Fecha { get; set; }
            public string TipoComprobante { get; set; }
            public string Letra { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public string Entidad { get; set; }
            public string Cuit { get; set; }
            public decimal ImporteGravado { get; set; }
            public decimal ImporteNoGravado { get; set; }
            public decimal IVA21 { get; set; }
            public decimal IVA105 { get; set; }
            public decimal IVA27 { get; set; }
            public decimal IngresosBrutosCaba { get; set; }
            public decimal IngresosBrutosBsAs { get; set; }
            public decimal PercepcionGanancias { get; set; }
            public decimal PercepcionIva { get; set; }
            public decimal OtrasPercepciones { get; set; }
            public decimal Total { get; set; }
            public string Observaciones { get; set; }
            public string Concepto { get; set; }

        }

        public class SearchResultIVA
        {
            public string IVA_COMPRAS { get; set; }
            public DateTime Fecha { get; set; }
            public string TipoComprobante { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public string Cuit { get; set; }
            public string Entidad { get; set; }
            public decimal Importe { get; set; }
            public decimal ImporteSinIva { get; set; }
            public int AlicuotaIvas { get; set; }
        }

        public class SearchResultAlicuota
        {
            public string ALICUOTAS { get; set; }
            public string TipoComprobante { get; set; }
            public string PuntoVenta { get; set; }
            public string NroComprobante { get; set; }
            public decimal ImporteGravado { get; set; }
            public decimal AlicuotaIva { get; set; }
            public decimal ImporteIva { get; set; }
        }
    }
}
