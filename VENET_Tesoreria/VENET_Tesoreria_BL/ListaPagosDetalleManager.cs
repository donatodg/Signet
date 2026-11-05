namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ListaPagosDetalleManager
    {
        public ListaPagosDetalle ListaDetalle { get; set; }
        private Enums.TipoEntidad Tipo;

        public ListaPagosDetalleManager(ListaPagosDetalle o, Enums.TipoEntidad TipoEntidad)
        {
            ListaDetalle = o;
            Tipo = TipoEntidad;
        }

        public List<Key2NamePair> Entidades
        {
            get
            {
                List<Key2NamePair> r = new List<Key2NamePair>();

                using (var db = new GestionContext())
                {
                    switch (Tipo)
                    {
                        case Enums.TipoEntidad.Cliente:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Clientes.Where(t => t.UserDel == null).Select(t => new Key2NamePair() { Key = t.Id, Key2 = t.Id, Name = t.Nombre }).ToList();
                            else
                            {
                                int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                                r = (from c in db.Clientes
                                     join e in db.EntidadesEmpresas on c.Id equals e.Id_Entidad into listEmp
                                     from ee in listEmp
                                     where ee.TipoEntidad == Enums.TipoEntidad.Cliente
                                        && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                        && ee.UserDel == null
                                        && c.UserDel == null
                                     select new Key2NamePair() { Key = c.Id, Key2 = c.Id, Name = c.Nombre }).ToList();
                            }
                            break;

                        case Enums.TipoEntidad.Proveedor:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Proveedores.Where(t => t.UserDel == null).Select(t => new Key2NamePair() { Key = t.Id, Key2 = t.Id, Name = t.Nombre }).ToList();
                            else
                            {
                                int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                                r = (from c in db.Proveedores
                                     join e in db.EntidadesEmpresas on c.Id equals e.Id_Entidad into listEmp
                                     from ee in listEmp
                                     where ee.TipoEntidad == Enums.TipoEntidad.Proveedor
                                        && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                        && ee.UserDel == null
                                        && c.UserDel == null
                                     select new Key2NamePair() { Key = c.Id, Key2 = c.Id, Name = c.Nombre }).ToList();
                            }
                            break;

                        case Enums.TipoEntidad.Proveedor_Financiero:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = (from pf in db.ProvFinancieros
                                     join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                     from c in listCuentas
                                     where pf.UserDel == null
                                        && c.UserDel == null
                                     select new Key2NamePair() { Key = c.Id, Key2 = pf.Id, Name = pf.Nombre + " - " + c.CBU }).ToList();
                            else
                            {
                                int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                                r = (from pf in db.ProvFinancieros
                                     join pfc in db.ProvFinancierosCuentas on pf.Id equals pfc.Id_ProvFinanciero into listCuentas
                                     from c in listCuentas
                                     join e in db.EntidadesEmpresas on pf.Id equals e.Id_Entidad into listEmp
                                     from ee in listEmp
                                     where ee.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero
                                        && Seguridad.IdEmpresasAsignadas.Contains(ee.Id_Empresa)
                                        && pf.UserDel == null
                                        && c.UserDel == null
                                     select new Key2NamePair() { Key = c.Id, Key2 = pf.Id, Name = pf.Nombre + " - " + c.CBU }).ToList();
                            }


                            break;

                        case Enums.TipoEntidad.Personal:
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                                r = db.Personal.Where(t => t.UserDel == null).Select(t => new Key2NamePair() { Key = t.Id, Key2 = t.LaboralLegajo.Value, Name = t.Apellido + ", " + t.Nombre }).ToList();
                            else
                            {
                                int IdUser = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                                r = (from t in db.Personal
                                     where Seguridad.IdEmpresasAsignadas.Contains(t.Id_Empresa)
                                        && t.UserDel == null
                                     select new Key2NamePair() { Key = t.Id, Key2 = t.LaboralLegajo.Value, Name = t.Apellido + ", " + t.Nombre }).ToList();
                            }
                            break;
                    }
                }
                return r;
            }
        }

        public static void Eliminar(ListaPagosDetalle o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ListaPagosDetalle.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
