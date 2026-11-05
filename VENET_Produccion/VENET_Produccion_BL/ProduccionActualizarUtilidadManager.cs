namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionActualizarUtilidadManager : IDisposable
    {
        private ProduccionContext db;

        public ProduccionActualizarUtilidadManager(int _Id_ListaPrecio)
        {
            db = new ProduccionContext();
            Id_ListaPrecio = _Id_ListaPrecio;
            Id_Empresa = db.Produccion_ListaPrecios.Where(t => t.Id == Id_ListaPrecio).Select(t => t.Id_Empresa).FirstOrDefault();
        }

        private int Id_Empresa { get; set; }
        public int Id_ListaPrecio { get; private set; }
        public int? Id_Linea { get; set; }
        public int? Id_Variante { get; set; }
        public decimal Utilidad { get; set; }

        public List<KeyName2Pair> Lineas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        join emp in db.Empresas on l.Id_Empresa equals emp.Id into listEmp
                        from e in listEmp
                        where l.UserDel == null
                           && l.Id_Empresa == Id_Empresa
                        select new KeyName2Pair()
                        {
                            Key = l.Id,
                            Name = l.Codigo + "-" + l.Descripcion,
                            Name2 = e.Nombre
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Variantes
        {
            get
            {
                List<KeyNamePair> r = new List<KeyNamePair>();

                r = (from v in db.Produccion_Variantes
                     where v.UserDel == null
                        && v.Id_Linea == Id_Linea
                     select new KeyNamePair()
                     {
                         Key = v.Id,
                         Name = v.Codigo + "-" + v.Descripcion
                     }).OrderBy(t => t.Name).ToList();

                //if (r.Count == 0) throw new ValidationException("La línea no posee variantes asociadas.");
                return r;
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ActualizaUtilidadVariante", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Id_ListaPrecio);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Utilidad", Utilidad);
                    System.Data.SqlClient.SqlParameter Parameter3 = new System.Data.SqlClient.SqlParameter("Id_Linea", Id_Linea);
                    System.Data.SqlClient.SqlParameter Parameter4 = new System.Data.SqlClient.SqlParameter("Id_Variante", Id_Variante);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    cmd.Parameters.Add(Parameter3);
                    cmd.Parameters.Add(Parameter4);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
