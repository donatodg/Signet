namespace VENET_Chats_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using VENET_DataEntity;

    public class ChatsManager
    {
        public static List<Contactos> ObtenerContactos(int? Estado)
        {
            List<Contactos> r = new List<Contactos>();

            using (var db = new GeneralContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand("ChatsContactos", sqlConn);
                using (cmdReport)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Estado", Estado);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("IdUser", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdReport.Parameters.Add(Parameter1);
                    cmdReport.Parameters.Add(Parameter2);
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
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

        private static Contactos Load(System.Data.IDataRecord dr)
        {
            Contactos o = new Contactos();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Contacto": o.Contacto = dr.GetString(i); break;
                        case "Estado": if (dr.GetInt32(i) == 0) o.Estado = "Desconectado"; else o.Estado = "Conectado"; break;
                        case "Id_User": o.Id_User = dr.GetInt32(i); break;
                        case "Mensajes": o.Mensajes = dr.GetInt32(i); break;
                    }
                }
            }
            return o;
        }

        public static bool EnviarMensaje(int UserDestino, string Mensaje, DateTime f)
        {
            try
            {
                using (var db = new GeneralContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    string strSQL = string.Format("INSERT INTO Chats (UserDestino, Mensaje, FechaAdd, UserAdd) VALUES ({0}, '{1}','{2}',{3})", UserDestino, Mensaje, string.Format("{0:yyyyMMdd HH:mm:ss}", f), Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, sqlConn);
                    using (cmd)
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<string> RecibirMensajes(int UserOrigen)
        {
            List<string> r = new List<string>();

            try
            {
                using (var db = new GeneralContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand("ChatsNuevos", sqlConn);
                    using (cmdReport)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdUserOrigen", UserOrigen);
                        System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("IdUserDestino", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                        cmdReport.CommandTimeout = 0;

                        cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdReport.Parameters.Add(Parameter1);
                        cmdReport.Parameters.Add(Parameter2);
                        if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                        using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                r.Add(dr.GetString(0));
                            }
                        }
                    }

                    cmdReport = new System.Data.SqlClient.SqlCommand("ChatsMoverHistorial", sqlConn);
                    using (cmdReport)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdUserOrigen", UserOrigen);
                        System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("IdUserDestino", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                        cmdReport.CommandTimeout = 0;

                        cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdReport.Parameters.Add(Parameter1);
                        cmdReport.Parameters.Add(Parameter2);
                        if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                        cmdReport.ExecuteNonQuery();
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return r;
            }
        }

        public static List<string> VerHistorial(int UserOrigen)
        {
            List<string> r = new List<string>();

            try
            {
                using (var db = new GeneralContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand("ChatsVerHistorial", sqlConn);
                    using (cmdReport)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdUserOrigen", UserOrigen);
                        System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("IdUserDestino", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                        cmdReport.CommandTimeout = 0;

                        cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdReport.Parameters.Add(Parameter1);
                        cmdReport.Parameters.Add(Parameter2);
                        if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                        using (System.Data.IDataReader dr = cmdReport.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                r.Add(dr.GetString(0));
                            }
                        }
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return r;
            }
        }

        public static int PoseeChatsNuevos()
        {
            int r = 0;
            try
            {
                using (var db = new GeneralContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    string strSQL = "SELECT Top(1) UserAdd FROM CHATS WHERE UserDestino = " + Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand(strSQL, sqlConn);
                    using (cmdReport)
                    {
                        cmdReport.CommandType = System.Data.CommandType.Text;
                        if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                        r = Convert.ToInt32(cmdReport.ExecuteScalar());
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return r;
            }
        }

        public static string ObtenerNombreContacto(int IdUser)
        {
            using (var db = new GeneralContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmdReport = new System.Data.SqlClient.SqlCommand("SELECT TOP 1 Apellido + ', ' + Nombre FROM SeguridadUsuarios WHERE Id = " + IdUser, sqlConn);
                using (cmdReport)
                {
                    cmdReport.CommandTimeout = 0;

                    cmdReport.CommandType = System.Data.CommandType.Text;
                    if (cmdReport.Connection.State == System.Data.ConnectionState.Closed) cmdReport.Connection.Open();
                    return Convert.ToString(cmdReport.ExecuteScalar());
                }
            }
        }

        public class Contactos
        {
            public string Contacto { get; set; }
            public string Estado { get; set; }
            public int Id_User { get; set; }
            public int Mensajes { get; set; }
        }
    }
}
