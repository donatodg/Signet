namespace VENET_Clientes_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Comun;
    using VENET_Common;
    using VENET_DataEntity;

    public class ClientesManager : IDisposable
    {
        private TesoreriaContext db;
        public Clientes Cliente { get; set; }

        public ClientesManager(Clientes o)
        {
            db = new TesoreriaContext();
            Cliente = o;

            db.Clientes.Attach(Cliente);

            if (Cliente.Id > 0)
            {
                db.Entry(Cliente).Reload();

                if (Cliente.Contactos == null)
                    db.Entry(Cliente).Collection(p => p.Contactos).Load();

                if (Cliente.Descuentos == null)
                    db.Entry(Cliente).Collection(p => p.Descuentos).Load();

                if (Cliente.Entregas == null)
                    db.Entry(Cliente).Collection(p => p.Entregas).Load();

                if (Cliente.Descuentos.Count > 0)
                    foreach (ClientesDescuentos row in Cliente.Descuentos)
                    {
                        row.Categoria = db.ProductosCategorias2.Where(t => t.Id == row.Id_Categoria2).Select(t => t.Descripcion).FirstOrDefault();
                        if (String.IsNullOrEmpty(row.Categoria)) row.Categoria = "TODAS";
                    }
            }
            else
            {
                Cliente.Id_TipoIva = Sistema.TiposIva.First().Key;
                Cliente.Id_CodPostal = Sistema.CodPostal.First().Id;
                db.Entry(Cliente).Collection(p => p.Contactos).Load();
                db.Entry(Cliente).Collection(p => p.Descuentos).Load();
                db.Entry(Cliente).Collection(p => p.Entregas).Load();
            }
        }

        public List<KeyNamePair> ListasPrecios { get { using (var db = new GestionContext()) { return db.ProductosListasPrecios.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            bool Nuevo = false;

            if (Cliente.Id == 0)
            {
                db.Entry(Cliente).State = EntityState.Added;
                Cliente.FechaAdd = Sistema.ObtenerFechaHora();
                Cliente.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Nuevo = true;
            }
            else
            {
                db.Entry(Cliente).State = EntityState.Modified;
                Cliente.FechaMod = Sistema.ObtenerFechaHora();
                Cliente.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            bool Flag = false;
            using (var db1 = new TesoreriaContext())
            {
                Flag = false;
                foreach (ClientesContactos row in Cliente.Contactos.Where(t => t.Borrado == true))
                {
                    ClientesContactos o = new ClientesContactos() { Id = row.Id };
                    db1.ClientesContactos.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }

            Flag = false;
            using (var db1 = new TesoreriaContext())
            {
                Flag = false;
                foreach (ClientesDescuentos row in Cliente.Descuentos.Where(t => t.Borrado == true))
                {
                    ClientesDescuentos o = new ClientesDescuentos() { Id = row.Id };
                    db1.ClientesDescuentos.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }

            Flag = false;
            using (var db1 = new TesoreriaContext())
            {
                Flag = false;
                foreach (ClientesEntregas row in Cliente.Entregas.Where(t => t.Borrado == true))
                {
                    ClientesEntregas o = new ClientesEntregas() { Id = row.Id };
                    db1.ClientesEntregas.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }

            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorUN)))
            {
                int Id_UN = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_UN = db2.SeguridadUsuariosUnidadNegocios.Where(t => t.Id_Usuario == Cliente.UserAdd && t.UserDel == null).Select(t => t.Id_UnidadNegocio).FirstOrDefault();

                    if (Id_UN == 0)
                        Id_UN = db2.UnidadNegocios.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesUnidadNegocios o = new EntidadesUnidadNegocios()
                {
                    Id_Entidad = Cliente.Id,
                    TipoEntidad = Enums.TipoEntidad.Cliente,
                    Id_UnidadNegocio = Id_UN,
                    UserAdd = Cliente.UserAdd,
                    FechaAdd = Cliente.FechaAdd
                };

                db.EntidadesUnidadNegocios.Attach(o);
                db.Entry(o).State = EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }

            if (Nuevo && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Entidades_UtilizaEntidadesPorEmpresas)))
            {
                int Id_Empresa = 0;

                using (var db2 = new SeguridadContext())
                {
                    Id_Empresa = db2.SeguridadUsuariosEmpresas.Where(t => t.Id_Usuario == Cliente.UserAdd && t.UserDel == null).Select(t => t.Id_Empresa).FirstOrDefault();

                    if (Id_Empresa == 0)
                        Id_Empresa = db2.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();
                }

                EntidadesEmpresas o = new EntidadesEmpresas()
                {
                    Id_Entidad = Cliente.Id,
                    TipoEntidad = Enums.TipoEntidad.Cliente,
                    Id_Empresa = Id_Empresa,
                    UserAdd = Cliente.UserAdd,
                    FechaAdd = Cliente.FechaAdd
                };

                db.EntidadesEmpresas.Attach(o);
                db.Entry(o).State = EntityState.Added;

                err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));
                db.SaveChanges();
            }

        }

        public static void Eliminar(Clientes Cliente)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(Cliente).State = EntityState.Modified;
                db.Entry(Cliente).Reload();

                Cliente.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Cliente.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new TesoreriaContext())
            {
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("ClientesBuscar", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("Id", parametros.Id);
                    System.Data.SqlClient.SqlParameter Parameter2 = new System.Data.SqlClient.SqlParameter("Nombre", parametros.Nombre);
                    System.Data.SqlClient.SqlParameter Parameter3 = new System.Data.SqlClient.SqlParameter("IdUsuario", Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    cmd.Parameters.Add(Parameter2);
                    cmd.Parameters.Add(Parameter3);
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

        private static SearchResult Load(System.Data.IDataRecord dr)
        {
            SearchResult o = new SearchResult();

            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (!dr.IsDBNull(i))
                {
                    switch (dr.GetName(i))
                    {
                        case "Id":
                            {
                                o.Id = dr.GetInt32(i);
                                List<ClientesContactos> lc = new List<ClientesContactos>();
                                lc = new TesoreriaContext().ClientesContactos.Where(t => t.Id_Cliente == o.Id).ToList();
                                foreach (ClientesContactos c in lc)
                                {
                                    if (c.Telefono2 == null)
                                        o.Contacto += c.Telefono1 + " - " + c.Nombre + " // ";
                                    else
                                        o.Contacto += c.Telefono1 + " - " + c.Telefono2 + " - " + c.Nombre + " // ";
                                }
                                o.Contacto = o.Contacto.Substring(0, o.Contacto.Length - 4);
                                break;
                            }
                        case "Nombre": o.Nombre = dr.GetString(i); break;
                        case "Empresa": o.Empresa = dr.GetString(i); break;
                        case "Domicilio": o.Domicilio = dr.GetString(i); break;
                        case "Id_CodPostal":
                            {
                                o.Id_CodPostal = dr.GetInt32(i);
                                Localidades l = new Localidades();
                                l = new TesoreriaContext().Localidades.Where(t => t.Id == o.Id_CodPostal).FirstOrDefault();
                                o.Localidad = l.Localidad;
                                o.CodPostal = l.CodPostal;
                                break;
                            }
                        case "Cuit": o.Cuit = dr.GetString(i); break;
                        case "Id_TipoIva": o.Id_TipoIva = dr.GetInt32(i); break;
                        case "Email": o.Email = dr.GetString(i); break;
                        case "Id_ListaPrecio": o.Id_ListaPrecio = dr.GetInt32(i); break;
                        case "FechaAdd": o.FechaAdd = dr.GetDateTime(i); break;
                        case "FechaMod": o.FechaMod = dr.GetDateTime(i); break;
                        case "UserAdd": o.UserAdd = dr.GetInt32(i); break;
                        case "UserMod": o.UserMod = dr.GetInt32(i); break;
                    }
                }
            }

            return o;
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Nombre { get; set; }
        }

        public class SearchResult : Clientes
        {
            public int CodPostal { get; set; }
            public string Localidad { get; set; }
            public string TipoIva { get; set; }
            public string ListaPrecio { get; set; }
            public string Contacto { get; set; }
        }

    }

}
