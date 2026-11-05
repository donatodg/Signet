namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionVariantesActualizarUtilidadManager : IDisposable
    {
        private ProduccionContext db;

        public ProduccionVariantesActualizarUtilidadManager()
        {
            db = new ProduccionContext();
        }

        public int? Id_Linea { get; set; }
        public decimal Utilidad { get; set; }

        public List<KeyName2Pair> Lineas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        join emp in db.Empresas on l.Id_Empresa equals emp.Id into listEmp
                        from e in listEmp
                        where l.UserDel == null
                        select new KeyName2Pair()
                        {
                            Key = l.Id,
                            Name = l.Codigo + "-" + l.Descripcion,
                            Name2 = e.Nombre
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void ActualizarUtilidadMasivo()
        {
            using (var db = new ProduccionContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ActualizaUtilidadPorLinea", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id_Linea", Id_Linea);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Utilidad", Utilidad);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
