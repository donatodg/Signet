namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class RendicionesManager : IDisposable
    {
        private TesoreriaContext db;
        public Rendiciones Rendicion { get; set; }

        public RendicionesManager(Rendiciones o)
        {
            db = new TesoreriaContext();
            Rendicion = o;

            db.Rendiciones.Attach(Rendicion);
            db.Entry(Rendicion).Collection(p => p.Detalle).Load();

            IdVale = new List<int>();

            if (Rendicion.Id > 0)
            {
                db.Entry(Rendicion).Reload();

                if (Rendicion.Detalle.Count > 0)
                {
                    foreach (RendicionesDetalle row in Rendicion.Detalle)
                    {
                        row.Cuenta = db.Cuentas.Where(t => t.Id == row.Id_Cuenta).Select(t => t.Descripcion).SingleOrDefault();
                    }
                }
            }
            else
            {
                Rendicion.Id_CentroCosto = 1;
            }

            if (Rendicion.Ids_Vales != null)
            {
                var result = from s in Rendicion.Ids_Vales.Split(',') select (s);
                foreach (string r in result)
                    IdVale.Add(int.Parse(r));
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<PersonalList> ListaPersonal
        {
            get
            {
                return (db.Personal
                    .Where(t => Seguridad.IdEmpresasAsignadas.Contains(t.Id_Empresa) && t.UserDel == null)
                    .Select(t => new PersonalList()
                    {
                        Id = t.Id,
                        Legajo = t.LaboralLegajo,
                        Nombre = t.Apellido + ", " + t.Nombre
                    }).ToList());
            }
        }

        public List<int> IdVale { get; private set; }

        public void Save()
        {
            if (Rendicion.Id == 0)
            {
                db.Entry(Rendicion).State = EntityState.Added;
                Rendicion.Fecha = Rendicion.FechaAdd = Sistema.ObtenerFechaHora();
                Rendicion.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Rendicion).State = EntityState.Modified;
                Rendicion.FechaMod = Sistema.ObtenerFechaHora();
                Rendicion.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            //Marca al vale como rendido para que no se repita la rendicion
            foreach (int i in IdVale)
            {
                Vales v = db.Vales.Where(t => t.Id_Caja == Rendicion.Id_Caja && t.Numero == i && t.Id_Personal == Rendicion.Id_Personal && t.UserDel == null).Select(t => t).FirstOrDefault();
                db.Vales.Attach(v);
                db.Entry(v).Reload();
                db.Entry(v).State = EntityState.Modified;
                v.Id_Rendicion = Rendicion.Id;
            }
            db.SaveChanges();
        }

        public static void Eliminar(Rendiciones o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar una rendición anulada.");
                if (o.FechaConfirmacion != null) throw new ValidationException("No se puede eliminar una rendición confirmada.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                ////Desmarca La rendicion de los vales
                var result = from s in o.Ids_Vales.Split(',') select (s);
                foreach (string r in result)
                {
                    int nro = Convert.ToInt32(r);
                    Vales v = db.Vales.Where(t => t.Id_Caja == o.Id_Caja && t.Numero == nro && t.Id_Personal == o.Id_Personal && t.UserDel == null).Select(t => t).FirstOrDefault();
                    db.Vales.Attach(v);
                    db.Entry(v).Reload();
                    db.Entry(v).State = EntityState.Modified;
                    v.Id_Rendicion = 0;
                }

                db.SaveChanges();
            }
        }

        public static void Confirmar(Rendiciones o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("La rendición se encuentra anulada.");
                if (o.FechaConfirmacion != null) throw new ValidationException("La rendición ya se encuentra confirmada.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                //*******************************************
                //TODO: Hacer split y foreach
                //*******************************************
                //Vales v = new Vales();
                //Vales v = new Vales() { Id = o.Id_Vale };
                //db.Vales.Attach(v);
                //db.Entry(v).Reload();
                //db.Entry(v).State = EntityState.Modified;
                //v.Id_Rendicion = o.Id;
                //*******************************************

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.FechaConfirmacion = (DateTime)o.FechaMod;

                string Nombre = db.Personal.Where(c => c.Id == o.Id_Personal).Select(c => (c.Apellido + ", " + c.Nombre)).FirstOrDefault();
                int IdEspecie = db.Cajas.Where(t => t.Id == o.Id_Caja).Select(t => t.Id_Especie).FirstOrDefault();

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("Rendición Vale Nº {0} - {1}", o.Ids_Vales, Nombre),
                    Credito = o.ImporteVale + o.Diferencia * -1,
                    Fecha = (DateTime)o.FechaConfirmacion,
                    FechaAdd = (DateTime)o.FechaConfirmacion,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_Personal,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                    Id_TipoEntidad = Enums.TipoEntidad.Personal,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                if (o.Devolucion > 0)
                {
                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = "Rendición Vale Nº " + o.Ids_Vales + " - " + Nombre + " - Devolución Efectivo",
                        Debito = o.Devolucion,
                        Fecha = (DateTime)o.FechaConfirmacion,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        Id_Caja = o.Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Attach(ecc);
                    db.Entry(ecc).State = EntityState.Added;
                }
                if (o.Diferencia < 0)
                {
                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = "Rendición Vale Nº " + o.Ids_Vales + " - " + Nombre + " - Pago de Diferencia",
                        Credito = o.Diferencia * -1,
                        Fecha = (DateTime)o.FechaConfirmacion,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        Id_Caja = o.Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Attach(ecc);
                    db.Entry(ecc).State = EntityState.Added;

                    EntidadesCtaCte encc1 = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("Rendición Vale Nº {0} - {1} - Pago de Diferencia", o.Ids_Vales, Nombre),
                        Debito = o.Diferencia * -1,
                        Fecha = (DateTime)o.FechaConfirmacion,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = o.Id_Personal,
                        Id_Especie = IdEspecie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        Id_TipoEntidad = Enums.TipoEntidad.Personal,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc1);
                }

                if (o.Diferencia > 0)
                {
                    //int Nro = db.Vales.Where(t => t.Id_Caja == o.Id_Caja && t.UserDel == null).OrderByDescending(t => t.Numero).Select(t => t.Numero).FirstOrDefault() + 1;
                    int Nro = ValesManager.ObtenerProximoNumero(o.Id_Caja);

                    Vales ValeNuevo = new Vales()
                    {
                        Id_Caja = o.Id_Caja,
                        Numero = Nro,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Descripcion = "Por Diferencia Rendición Vale " + o.Ids_Vales,
                        Fecha = (DateTime)o.FechaConfirmacion,
                        FechaAdd = (DateTime)o.FechaConfirmacion,
                        FechaConfirmacion = (DateTime)o.FechaConfirmacion,
                        Id_Personal = o.Id_Personal,
                        Importe = o.Diferencia,
                        UserAdd = (int)o.UserMod
                    };

                    db.Vales.Attach(ValeNuevo);
                    db.Entry(ValeNuevo).State = EntityState.Added;
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static void Anular(Rendiciones o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("La rendición ya se encuentra anulada.");
                if (o.FechaConfirmacion == null) throw new ValidationException("La rendición no se encuentra confirmada. Solo se puede eliminar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();


                var result = from s in o.Ids_Vales.Split(',') select (s);
                foreach (string r in result)
                {
                    int nro = Convert.ToInt32(r);
                    Vales v = db.Vales.Where(t => t.Id_Caja == o.Id_Caja && t.Numero == nro && t.Id_Personal == o.Id_Personal && t.UserDel == null).Select(t => t).FirstOrDefault();
                    db.Vales.Attach(v);
                    db.Entry(v).Reload();
                    db.Entry(v).State = EntityState.Modified;
                    v.Id_Rendicion = 0;
                }

                //*******************************************
                //TODO: Hacer split y foreach
                //*******************************************
                //Vales v = new Vales();
                //Vales v = new Vales() { Id = o.Id_Vale };
                //db.Vales.Attach(v);
                //db.Entry(v).Reload();
                //db.Entry(v).State = EntityState.Modified;
                //v.Id_Rendicion = 0;
                //*******************************************

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.FechaAnulacion = (DateTime)o.FechaMod;
                o.MotivoAnulacion = MotivoAnulacion;

                string Nombre = db.Personal.Where(c => c.Id == o.Id_Personal).Select(c => (c.Apellido + ", " + c.Nombre)).FirstOrDefault();
                int IdEspecie = db.Cajas.Where(t => t.Id == o.Id_Caja).Select(t => t.Id_Especie).FirstOrDefault();

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("Anulación Rendición Vale Nº {0} - {1}", o.Ids_Vales, Nombre),
                    Debito = o.ImporteVale + o.Diferencia * -1,
                    Fecha = (DateTime)o.FechaConfirmacion,
                    FechaAdd = (DateTime)o.FechaConfirmacion,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_Personal,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                    Id_TipoEntidad = Enums.TipoEntidad.Personal,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                if (o.Devolucion > 0)
                {
                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = "Anulación Rendición Vale Nº " + o.Ids_Vales + " - " + Nombre + " - Devolución Efectivo",
                        Credito = o.Devolucion,
                        Fecha = (DateTime)o.FechaAnulacion,
                        FechaAdd = (DateTime)o.FechaAnulacion,
                        Id_Caja = o.Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod,
                        Debito = 0
                    };
                    db.EspeciesCtaCte.Attach(ecc);
                    db.Entry(ecc).State = EntityState.Added;
                }

                if (o.Diferencia < 0)
                {
                    EspeciesCtaCte ecc = new EspeciesCtaCte()
                    {
                        Id_CentroCosto = o.Id_CentroCosto,
                        Concepto = "Anulación Rendición Vale Nº " + o.Ids_Vales + " - " + Nombre + " - Pago de Diferencia",
                        Debito = o.Diferencia * -1,
                        Fecha = (DateTime)o.FechaAnulacion,
                        FechaAdd = (DateTime)o.FechaAnulacion,
                        Id_Caja = o.Id_Caja,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        Id_Comprobante = o.Id,
                        UserAdd = (int)o.UserMod
                    };
                    db.EspeciesCtaCte.Attach(ecc);
                    db.Entry(ecc).State = EntityState.Added;

                    EntidadesCtaCte encc1 = new EntidadesCtaCte()
                    {
                        Concepto = string.Format("Anulación Rendición Vale Nº {0} - {1} - Pago de Diferencia", o.Ids_Vales, Nombre),
                        Credito = o.Diferencia * -1,
                        Fecha = (DateTime)o.FechaAnulacion,
                        FechaAdd = (DateTime)o.FechaAnulacion,
                        Id_CentroCosto = o.Id_CentroCosto,
                        Id_Comprobante = o.Id,
                        Id_Entidad = o.Id_Personal,
                        Id_Especie = IdEspecie,
                        Id_TipoComprobante = (int)Enums.TipoComprobante.Rendiciones,
                        Id_TipoEntidad = Enums.TipoEntidad.Personal,
                        UserAdd = (int)o.UserMod
                    };
                    db.EntidadesCtaCte.Add(encc1);
                }

                if (o.Diferencia > 0)
                {
                    Vales va = db.Vales.Where(t => t.Descripcion == "Por Diferencia Rendición Vale " + o.Ids_Vales && t.Id_Personal == o.Id_Personal && t.Importe == o.Diferencia && t.UserDel == null).FirstOrDefault();

                    va.UserDel = (int)o.UserMod;
                    va.FechaDel = (DateTime)o.FechaMod;

                    db.Vales.Attach(va);
                    db.Entry(va).State = EntityState.Modified;
                }

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.Rendiciones
                     join p in db.Personal on t.Id_Personal equals p.Id into listPersonal
                     from per in listPersonal.DefaultIfEmpty()
                     join c in db.CentrosCostos on t.Id_CentroCosto equals c.Id into listCC
                     from cen in listCC.DefaultIfEmpty()
                     join ca in db.Cajas on t.Id_Caja equals ca.Id into listCa
                     from caja in listCa
                     where (t.Id == parametros.Id || parametros.Id == null)
                           && (t.Id_Caja == parametros.Id_Caja || parametros.Id_Caja == null)
                           && (t.Fecha >= parametros.Fecha_Desde && t.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                           && (Seguridad.IdCajasAsignadas.Contains(t.Id_Caja))
                           && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Id_Personal = t.Id_Personal,
                         Id_CentroCosto = t.Id_CentroCosto,
                         Id_Caja = t.Id_Caja,
                         Caja = caja.Descripcion,
                         Fecha = t.Fecha,
                         Ids_Vales = t.Ids_Vales,
                         ImporteVale = t.ImporteVale,
                         Devolucion = t.Devolucion,
                         Diferencia = t.Diferencia,
                         FechaAnulacion = t.FechaAnulacion,
                         FechaConfirmacion = t.FechaConfirmacion,
                         MotivoAnulacion = t.MotivoAnulacion,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod,
                         Nombre_Entidad = per.Apellido + ", " + per.Nombre,
                         Centro_Costo = cen.Descripcion,
                         Legajo = Convert.ToInt32(per.LaboralLegajo)
                     }).ToList();

                return r;
            }
        }

        public void AgregarVale(int Id_Vale)
        {
            Vales v;

            using (TesoreriaContext db = new TesoreriaContext())
            {
                v = db.Vales.Find(Id_Vale);

                if (v.FechaConfirmacion == null) throw new ValidationException(string.Format("El vale nro. {0} no se encuentra confirmado.", v.Numero));
                if (v.FechaAnulacion != null) throw new ValidationException(string.Format("El vale nro. {0} no se encuentra anulado.", v.Numero));
                if (v.Id_Caja != Rendicion.Id_Caja) throw new ValidationException("La caja del vale es distinto a la caja de la rendición.");
                if (IdVale.Contains(v.Numero)) throw new ValidationException(string.Format("El vale nro. {0} ya se encuentra en la rendición", v.Numero));

                if (Rendicion.Ids_Vales == null || Rendicion.Ids_Vales == "")
                    Rendicion.Ids_Vales = v.Numero.ToString();
                else
                    Rendicion.Ids_Vales += ", " + v.Numero.ToString();

                IdVale.Add(v.Numero);
                Rendicion.ImporteVale += v.Importe;
            }
        }

        public class PersonalList
        {
            public int Id { get; set; }
            public int? Legajo { get; set; }
            public string Nombre { get; set; }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Fecha_Desde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                Fecha_Hasta = Fecha_Desde.AddMonths(1).AddDays(-1);
            }
            public int? Id { get; set; }
            public int? Id_Personal { get; set; }
            public int? Id_Caja { get; set; }
            public DateTime Fecha_Desde { get; set; }
            public DateTime Fecha_Hasta { get; set; }
            public DateTime? Fecha_Confirmacion_Desde { get; set; }
            public DateTime? Fecha_Confirmacion_Hasta { get; set; }
        }

        public class SearchResult : Rendiciones
        {
            public string Nombre_Entidad { get; set; }
            public string Centro_Costo { get; set; }
            public string Caja { get; set; }
            public int Legajo { get; set; }
        }

        public static List<DatosReporte> ImprimeRendicion(Rendiciones o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                List<DatosReporte> l = new List<DatosReporte>();

                string Nombre = db.Personal.Where(c => c.Id == o.Id_Personal).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault();
                Personal per = db.Personal.Where(t => t.Id == o.Id_Personal).FirstOrDefault();

                DatosReporte i = new DatosReporte()
                {
                    Empresa = (from c in db.Cajas
                               join suc in db.Sucursales on c.Id_Sucursal equals suc.Id into listSuc
                               from s in listSuc
                               join emp in db.Empresas on s.Id_Empresa equals emp.Id into listEmp
                               from e in listEmp
                               where c.Id == o.Id_Caja
                               select e.Nombre).FirstOrDefault(),
                    Caja = db.Cajas.Where(t => t.Id == o.Id_Caja).Select(t => t.Descripcion).FirstOrDefault(),
                    Fecha = o.Fecha,
                    Nombre = Nombre,
                    ImporteTotal = o.Detalle.Sum(t => t.Importe),
                    //TotalEnLetras = NumeroALetras.Convertir((o.Detalle.Sum(t => t.Importe)).ToString()),
                    ImporteDevolucion = o.Devolucion,
                    ImporteDiferencia = o.Diferencia,
                    ImporteVales = o.ImporteVale,
                    Vales = o.Ids_Vales,
                    Localidad = (from c in db.Cajas
                                 join suc in db.Sucursales on c.Id_Sucursal equals suc.Id into listSuc
                                 from s in listSuc
                                 join lo in db.Localidades on s.CodPos equals lo.Id into listCP
                                 from cp in listCP
                                 where c.Id == o.Id_Caja
                                 select cp.Localidad).FirstOrDefault(),
                    NroDoc = per.NroDoc.Value,
                    TipoDoc = db.TipoDoc.Where(t => t.Id == per.Id_TipoDoc).Select(t => t.Descripcion).FirstOrDefault(),
                    Especie = (from c in db.Cajas
                               join e in db.Especies on c.Id_Especie equals e.Id into listEsp
                               from esp in listEsp
                               where c.Id == o.Id_Caja
                               select esp.Descripcion).FirstOrDefault(),
                    Detalle = o.Detalle
                };
                i.Detalle = o.Detalle;
                foreach (RendicionesDetalle x in o.Detalle)
                {
                    x.Cuenta = db.Cuentas.Where(t => t.Id == x.Id_Cuenta).Select(t => t.Descripcion).FirstOrDefault();
                }

                l.Add(i);

                return l;
            }
        }

        public class DatosReporte
        {
            public string Empresa { get; set; }
            public string Caja { get; set; }
            public DateTime Fecha { get; set; }
            public string Especie { get; set; }
            public string Localidad { get; set; }
            public string Nombre { get; set; }
            public string Vales { get; set; }
            public decimal ImporteVales { get; set; }
            public decimal ImporteDevolucion { get; set; }
            public decimal ImporteDiferencia { get; set; }
            public decimal ImporteTotal { get; set; }
            // public string TotalEnLetras { get; set; }
            public string TipoDoc { get; set; }
            public int NroDoc { get; set; }
            public virtual ICollection<RendicionesDetalle> Detalle { get; set; }
        }
    }
}
