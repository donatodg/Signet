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

    public class ChequeDescuentoManager : IDisposable
    {
        private TesoreriaContext db;
        public ChequesDescuento Descuento { get; set; }
        public List<KeyNamePair> CuentasPF
        {
            get
            {
                return (from p in db.ProvFinancieros
                        join c in db.ProvFinancierosCuentas on p.Id equals c.Id_ProvFinanciero into listPFC
                        from pfc in listPFC
                        where p.UserDel == null && pfc.UserDel == null
                        select new KeyNamePair() { Key = pfc.Id, Name = p.Nombre + " - " + pfc.CBU }).ToList();
            }
        }
        public int Id_Especie { get { return db.ProvFinancierosCuentas.Where(t => t.Id == Descuento.Id_ProvFinancieroCuenta).Select(t => t.Id_Especie).FirstOrDefault(); } }

        public ChequeDescuentoManager(ChequesDescuento o)
        {
            db = new TesoreriaContext();
            Descuento = o;

            db.ChequesDescuento.Attach(Descuento);

            if (Descuento.Id > 0)
            {
                db.Entry(Descuento).Reload();

                if (Descuento.Detalle == null)
                    db.Entry(Descuento).Collection(p => p.Detalle).Load();

                if (Descuento.Detalle.Count > 0)
                {
                    foreach (ChequesDescuentoDetalle row in Descuento.Detalle)
                    {
                        ChequesTerceros c = new ChequesTerceros() { Id = row.Id_Documento };

                        db.Entry(c).State = EntityState.Unchanged;
                        db.Entry(c).Reload();

                        row.Banco = db.EntidadesBancarias.Where(t => t.Codigo == c.Id_EntidadBancaria).Select(t => t.Descripcion).FirstOrDefault();
                        row.Sucursal = c.Sucursal.Value.ToString();
                        row.NroCuenta = c.NroCta.Value.ToString();
                        row.NroCheque = c.NroCheque.Value.ToString();
                        row.Importe = c.Importe;
                    }
                }
            }
            else
            {
                Descuento.Fecha = Sistema.ObtenerFechaHora();
                db.Entry(Descuento).Collection(p => p.Detalle).Load();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Descuento.Detalle.Count == 0)
                throw new ValidationException("No se ingresaron documentos.");

            if (Descuento.Id == 0)
            {
                db.Entry(Descuento).State = EntityState.Added;
                Descuento.FechaAdd = Sistema.ObtenerFechaHora();
                Descuento.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Descuento).State = EntityState.Modified;
                Descuento.FechaMod = Sistema.ObtenerFechaHora();
                Descuento.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            if (Descuento.Detalle != null)
            {
                var query = from c in db.ChequesTerceros
                            join cdd in db.ChequesDescuentoDetalle on c.Id equals cdd.Id_Documento into listC
                            from d in listC
                            where d.Id_ChequeDescuento == Descuento.Id
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.Id_Descuento = Descuento.Id;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }
            }

            db.SaveChanges();

            using (var db1 = new TesoreriaContext())
            {
                bool Flag = false;
                foreach (ChequesDescuentoDetalle row in Descuento.Detalle.Where(t => t.Borrado == true))
                {
                    ChequesDescuentoDetalle o = new ChequesDescuentoDetalle() { Id = row.Id };
                    db1.ChequesDescuentoDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;

                    ChequesTerceros c = new ChequesTerceros() { Id = row.Id_Documento };
                    db1.ChequesTerceros.Attach(c);
                    db1.Entry(c).Reload();
                    db1.Entry(c).State = EntityState.Modified;
                    c.Id_Descuento = null;

                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public static void Eliminar(ChequesDescuento o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede eliminar un descuento anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede eliminar un descuento liquidado.");

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                //TODO: desmarcar Cheques
                var query = from c in db.ChequesTerceros
                            where c.Id_Descuento == o.Id &&
                                  c.UserDel == null
                            select c;

                foreach (ChequesTerceros c in query)
                {
                    c.Id_Descuento = null;
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        public void EliminarDetalle(ChequesDescuentoDetalle o)
        {
            foreach (ChequesDescuentoDetalle row in Descuento.Detalle)
                if (row.Id == o.Id)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    break;
                }
            using (var db = new TesoreriaContext())
            {
                ChequesTerceros c = new ChequesTerceros() { Id = o.Id_Documento };
                db.ChequesTerceros.Attach(c);
                db.Entry(c).Reload();
                db.Entry(c).State = EntityState.Modified;
                c.Id_Descuento = null;

                db.SaveChanges();
            }
        }

        public static void Confirmar(ChequesDescuento o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("No se puede confirmar un descuento anulado.");
                if (o.FechaLiquidacion != null) throw new ValidationException("No se puede confirmar un descuento liquidado.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaLiquidacion = o.FechaMod = Sistema.ObtenerFechaHora();

                var query = from cdd in db.ChequesDescuentoDetalle
                            join ch in db.ChequesTerceros on cdd.Id_Documento equals ch.Id into listCh
                            from c in listCh
                            where cdd.Id_ChequeDescuento == o.Id &&
                                  cdd.UserDel == null &&
                                  c.UserDel == null
                            select c;

                decimal Total = 0;
                int IdEspecie = 0;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaDepositado = c.FechaDescuento = o.FechaLiquidacion;
                    c.Id_Descuento = o.Id;
                    Total += c.Importe;
                    IdEspecie = c.Id_Especie;
                }

                string Proveedor = (from p in db.ProvFinancieros
                                    join pfc in db.ProvFinancierosCuentas on p.Id equals pfc.Id_ProvFinanciero into listC
                                    from c in listC
                                    where c.Id == o.Id_ProvFinancieroCuenta
                                    select p.Nombre).FirstOrDefault();

                EntidadesCtaCte encc = new EntidadesCtaCte()
                {
                    Concepto = string.Format("DESC {0} - PF. {1} - {2}", o.Id, Proveedor, o.Descripcion),
                    Debito = Total,
                    Fecha = (DateTime)o.FechaLiquidacion,
                    FechaAdd = (DateTime)o.FechaLiquidacion,
                    Id_CentroCosto = o.Id_CentroCosto,
                    Id_Comprobante = o.Id,
                    Id_Entidad = o.Id_ProvFinancieroCuenta,
                    Id_Especie = IdEspecie,
                    Id_TipoComprobante = (int)Enums.TipoComprobante.Descuento,
                    Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero,
                    UserAdd = (int)o.UserMod
                };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
            }
        }

        public static void Anular(ChequesDescuento o, string MotivoAnulacion)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                if (o.FechaAnulacion != null) throw new ValidationException("El descuento ya se encuentra anulado.");
                if (o.FechaLiquidacion == null) throw new ValidationException("No se puede anular un descuento sin liquidar.");

                if (o.Detalle == null)
                    db.Entry(o).Collection(p => p.Detalle).Load();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaAnulacion = Sistema.ObtenerFechaHora();
                o.FechaMod = Sistema.ObtenerFechaHora();
                o.MotivoAnulacion = MotivoAnulacion;

                string Proveedor = (from p in db.ProvFinancieros
                                    join pfc in db.ProvFinancierosCuentas on p.Id equals pfc.Id_ProvFinanciero into listC
                                    from c in listC
                                    where c.Id == o.Id_ProvFinancieroCuenta
                                    select p.Nombre).FirstOrDefault();


                var query = from cdd in db.ChequesDescuentoDetalle
                            join ch in db.ChequesTerceros on cdd.Id_Documento equals ch.Id into listCh
                            from c in listCh
                            where cdd.Id_ChequeDescuento == o.Id &&
                                  cdd.UserDel == null &&
                                  c.UserDel == null
                            select c;

                decimal Total = 0;
                int IdEspecie = 0;

                foreach (ChequesTerceros c in query)
                {
                    db.ChequesTerceros.Attach(c);
                    db.Entry(c).State = EntityState.Modified;
                    c.FechaDepositado = c.FechaDescuento = null;
                    c.Id_Descuento = null;
                    Total += c.Importe;
                    IdEspecie = c.Id_Especie;
                }

                EntidadesCtaCte encc = new EntidadesCtaCte()
              {
                  Concepto = string.Format("Anulación DESC {0} - PF. {1} - {2}", o.Id, Proveedor, o.Descripcion),
                  Credito = Total,
                  Fecha = (DateTime)o.FechaAnulacion,
                  FechaAdd = (DateTime)o.FechaAnulacion,
                  Id_CentroCosto = o.Id_CentroCosto,
                  Id_Comprobante = o.Id,
                  Id_Entidad = o.Id_ProvFinancieroCuenta,
                  Id_Especie = IdEspecie,
                  Id_TipoComprobante = (int)Enums.TipoComprobante.Descuento,
                  Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero,
                  UserAdd = (int)o.UserMod
              };
                db.EntidadesCtaCte.Add(encc);

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from c in db.ChequesDescuento
                     join s in db.Sucursales on c.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     join pfc in db.ProvFinancierosCuentas on c.Id_ProvFinancieroCuenta equals pfc.Id into listPFC
                     from cuenta in listPFC
                     join pf in db.ProvFinancieros on cuenta.Id_ProvFinanciero equals pf.Id into listPF
                     from provf in listPF
                     join cc in db.CentrosCostos on c.Id_CentroCosto equals cc.Id into listCC
                     from centro in listCC
                     where (c.Id == parametros.Id || parametros.Id == null)
                           && (c.Id_Sucursal == parametros.Id_Sucursal || parametros.Id_Sucursal == null)
                           && (c.Fecha >= parametros.Fecha_Desde && c.Fecha <= parametros.Fecha_Hasta || parametros.Fecha_Hasta == null || parametros.Id > 0)
                           && (c.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                           && (c.FechaLiquidacion >= parametros.Fecha_Liquidacion_Desde && c.FechaLiquidacion <= parametros.Fecha_Liquidacion_Hasta || parametros.Fecha_Liquidacion_Hasta == null)
                           && (c.FechaAnulacion != null || parametros.Anulado == false)
                           && (c.FechaAnulacion == null || parametros.Anulado == true)
                  && (c.UserDel == null)
                     select new SearchResult()
                  {
                      Id = c.Id,
                      Id_Sucursal = c.Id_Sucursal,
                      Id_CentroCosto = c.Id_CentroCosto,
                      CentroCosto = centro.Descripcion,
                      Descripcion = c.Descripcion,
                      Fecha = c.Fecha,
                      FechaAnulacion = c.FechaAnulacion,
                      MotivoAnulacion = c.MotivoAnulacion,
                      FechaLiquidacion = c.FechaLiquidacion,
                      Id_ProvFinancieroCuenta = c.Id_ProvFinancieroCuenta,
                      ProvFinanciero = provf.Nombre,
                      CBU = cuenta.CBU,
                      Importe = (from d in db.ChequesDescuentoDetalle
                                 join ch in db.ChequesTerceros on d.Id_Documento equals ch.Id into listCH
                                 from che in listCH
                                 where d.Id_ChequeDescuento == c.Id
                                       && d.UserDel == null
                                 select che.Importe).Sum(),
                      Sucursal = suc.Descripcion,
                      FechaAdd = c.FechaAdd,
                      FechaMod = c.FechaMod,
                      UserAdd = c.UserAdd,
                      UserMod = c.UserMod
                  }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                DateTime fd = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                DateTime fh = fd.AddMonths(1).AddDays(-1);

                Fecha_Desde = fd;
                Fecha_Hasta = fh;

                //if (Sistema.Cajas.Count() > 0)
                //    Id_Caja = Sistema.Cajas.First().Id_Caja;
            }
            public int? Id { get; set; }
            public int? Id_Sucursal { get; set; }
            public DateTime? Fecha_Desde { get; set; }
            public DateTime? Fecha_Hasta { get; set; }
            public string Descripcion { get; set; }
            public DateTime? Fecha_Liquidacion_Desde { get; set; }
            public DateTime? Fecha_Liquidacion_Hasta { get; set; }
            public bool Anulado { get; set; }
        }

        public class SearchResult : ChequesDescuento
        {
            public string ProvFinanciero { get; set; }
            public string CBU { get; set; }
            public string Sucursal { get; set; }
            public string CentroCosto { get; set; }
            public decimal Importe { get; set; }
        }
    }
}
