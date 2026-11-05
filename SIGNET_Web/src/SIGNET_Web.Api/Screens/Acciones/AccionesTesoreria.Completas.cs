using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Globalization;
using System.Linq;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Tesoreria_BL;
using CVManager = VENET_Gestion_BL.ComprobantesVentasManager;

namespace SIGNET_Web.Api.Screens.Acciones
{
    /// <summary>Operaciones de Tesorería que en el escritorio abren diálogos (asignar comprobantes, mail, Excel).</summary>
    public sealed partial class AccionesTesoreria
    {
        private static string Clave(string prefijo, int id) => prefijo + id.ToString(CultureInfo.InvariantCulture);
        private static int UsuarioActual => Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

        private static void RegistrarCompletas(AccionesRegistro r)
        {
            r.Agregar("Recibos", AsignarRecibo());
            r.Agregar("Recibos", DesasignarRecibo());
            r.Agregar("Recibos", MailDoc("Recibos", "Enviar por Email", "Enviar por Mail", id =>
            {
                var f = new RecibosManager(new Recibos { Id = id }).Recibo;
                return (ImprimirRecibo(id), "REC-" + f.NroComprobante, "Comprobante REC-" + f.NroComprobante, MailEntidad(f.TipoEntidad, f.Id_Entidad));
            }));

            r.Agregar("OrdenesPago", AsignarOP());
            r.Agregar("OrdenesPago", DesasignarOP());
            r.Agregar("OrdenesPago", MailDoc("OrdenesPago", "Enviar por Email", "Enviar por Mail", id =>
            {
                var f = new OrdenesPagoManager(new OrdenesPago { Id = id }).OP;
                return (ImprimirOrdenPago(id), "OP-" + f.NroComprobante, "Comprobante OP-" + f.NroComprobante, MailEntidad(f.TipoEntidad, f.Id_Entidad));
            }));

            r.Agregar("Rendiciones", MailDoc("Rendiciones", "Enviar por EMail", "Enviar por Mail", id =>
            {
                Rendiciones f;
                using (var db = new TesoreriaContext()) f = db.Rendiciones.First(x => x.Id == id);
                if (f.FechaConfirmacion == null) throw new ValidationException("No se puede enviar por mail una rendición sin confirmar.");
                return (ImprimirRendicion(id), "Rendicion-" + id, "Comprobante Rendicion " + id, MailEntidad(Enums.TipoEntidad.Personal, f.Id_Personal));
            }, Enums.Modulos.Gestion));

            r.Agregar("Vales", MailDoc("Vales", "Enviar por EMail", "Enviar por Mail", id =>
            {
                Vales f;
                using (var db = new TesoreriaContext()) f = db.Vales.First(x => x.Id == id);
                if (f.FechaConfirmacion == null) throw new ValidationException("No se puede enviar por mail un vale sin confirmar.");
                return (ImprimirVale(id), "Vale-" + f.Numero, "Comprobante Vale " + f.Numero, MailEntidad(Enums.TipoEntidad.Personal, f.Id_Personal));
            }, Enums.Modulos.Gestion));

            r.Agregar("Vales", ImportarVales());
            r.Agregar("EntidadesCtaCte", MailCtaCte());
        }

        // ---------- Cta Cte por mail (frmEntidadesCtaCte.Enviar datos por Email) ----------

        private const long FactorEntidad = 100000000;

        private static AccionDef MailCtaCte()
        {
            var a = Crear("Operaciones", "enviar-cta-cte-email", "Enviar Cta Cte por Mail", "EntidadesCtaCte", "Enviar datos por Email", Enums.Accion.Operaciones, c =>
            {
                var clave = c.Valor<long>("entidad");
                var tipo = (Enums.TipoEntidad)(int)(clave / FactorEntidad);
                var idEntidad = (int)(clave % FactorEntidad);
                var desde = c.Valor<DateTime?>("fechaDesde");
                var par = new EntidadesCtaCteManager.ParametrosBusquedas { Id_TipoEntidad = tipo, Id_Entidad = idEntidad, Id_Especie = c.Valor<int>("especie"), FechaDesde = desde, FechaHasta = c.Valor<DateTime?>("fechaHasta") };
                var filas = EntidadesCtaCteManager.Buscar(par);
                if (filas.Count == 0) throw new ValidationException("La búsqueda no arrojo datos para enviar.");
                var nombre = Sistema.ObtenerEntidades(tipo).FirstOrDefault(e => e.Key == idEntidad)?.Name ?? idEntidad.ToString(CultureInfo.InvariantCulture);
                var doc = new HtmlDocumento("Cuenta Corriente - " + nombre)
                    .Datos(("Entidad", nombre), ("Desde", desde), ("Hasta", par.FechaHasta))
                    .Tabla(filas,
                        ("Fecha", f => f.InternoSistema ? null : (object)f.Fecha),
                        ("Concepto", f => f.Concepto),
                        ("Movimiento", f => f.Movimiento),
                        ("Débito", f => f.Debito),
                        ("Crédito", f => f.Credito),
                        ("Saldo", f => f.Saldo));
                var destino = MailEntidad(tipo, idEntidad);
                Exportador.EnviarMail(AccionResultado.Documento(doc), "CtaCte-" + nombre + "-" + Sistema.ObtenerFechaHora().ToString("ddMMyyyyHHmmss"),
                    "Cta Cte " + nombre + " - desde " + (desde?.ToString("dd/MM/yyyy") ?? ""), destino);
                return AccionResultado.Ok("Mail enviado a: " + destino, false);
            }, "¿Desea enviar por Email la cuenta corriente?");
            a.Seleccion = Seleccion.Ninguna;
            a.CamposDinamicos = c =>
            {
                var entidades = new List<LookupItem>();
                foreach (Enums.TipoEntidad t in Enum.GetValues(typeof(Enums.TipoEntidad)))
                {
                    List<KeyNamePair> l;
                    try { l = Sistema.ObtenerEntidades(t); } catch (Exception) { continue; }
                    entidades.AddRange(l.Select(e => new LookupItem { Key = (long)(int)t * FactorEntidad + e.Key, Name = Enums.GetDescription(t) + " - " + e.Name }));
                }
                return new List<FieldSchema>
                {
                    Campo.Opciones("entidad", "Entidad", entidades),
                    Campo.Opciones("especie", "Especie", Sistema.EspeciesTodas.Select(e => new LookupItem { Key = e.Key, Name = e.Name }), true, Sistema.EspeciesTodas.FirstOrDefault()?.Key),
                    Campo.Fecha("fechaDesde", "Fecha Desde", false, Sistema.ObtenerFechaHora().Date.AddMonths(-3)),
                    Campo.Fecha("fechaHasta", "Fecha Hasta", false)
                };
            };
            return a;
        }

        private static string MailEntidad(Enums.TipoEntidad tipo, int? id)
        {
            if (id == null) throw new ValidationException("El comprobante no tiene entidad asignada.");
            var mail = CVManager.ObtenerMail(tipo, id.Value);
            if (string.IsNullOrWhiteSpace(mail)) throw new ValidationException("La entidad no posee un mail cargado.");
            return mail;
        }

        private static AccionDef MailDoc(string pantalla, string titulo, string permiso, Func<int, (AccionResultado Doc, string Archivo, string Asunto, string Destino)> armar, Enums.Modulos? modulo = null)
        {
            var a = Crear("Operaciones", "enviar-email", titulo, pantalla, permiso, Enums.Accion.Operaciones, c =>
            {
                var enviados = new List<string>();
                foreach (var id in c.Ids)
                {
                    var x = armar(id);
                    Exportador.EnviarMail(x.Doc, x.Archivo, x.Asunto, x.Destino);
                    enviados.Add(x.Destino);
                }
                return AccionResultado.Ok("Mail enviado a: " + string.Join(", ", enviados.Distinct()), false);
            }, "¿Desea enviar por mail el/los comprobante/s seleccionado/s?");
            a.Seleccion = Seleccion.Varias;
            if (modulo != null) a.Modulo = modulo.Value;
            return a;
        }

        // ---------- Asignar / desasignar comprobantes (frmRecibosComprobantes / frmOrdenesPagoComprobantes) ----------

        private static void ValidarAsignable(DateTime? anulado, DateTime? liquidado, decimal? sinAplicar)
        {
            if (anulado != null) throw new ValidationException("El comprobante se encuentra anulado.");
            if (liquidado == null) throw new ValidationException("El comprobante debe estar confirmado.");
            if ((sinAplicar ?? 0) <= 0) throw new ValidationException("El comprobante no posee importe sin aplicar.");
        }

        private static List<FieldSchema> CamposPago<T>(IEnumerable<T> filas, Func<T, int> id, Func<T, string> comp, Func<T, DateTime> fecha, Func<T, decimal> importe, Func<T, decimal> adeudado, decimal? sinAplicar)
        {
            var campos = filas.Select(f => Campo.Decimal(Clave("pago_", id(f)),
                comp(f) + " del " + fecha(f).ToString("dd/MM/yyyy") + " (importe " + HtmlDocumento.Formatear(importe(f)) + ", adeudado " + HtmlDocumento.Formatear(adeudado(f)) + ")",
                false, 0m)).ToList();
            if (campos.Count == 0) throw new ValidationException("La entidad no posee comprobantes pendientes de asignar.");
            campos[0].Label = "[Sin aplicar: " + HtmlDocumento.Formatear(sinAplicar ?? 0) + "] " + campos[0].Label;
            return campos;
        }

        private static AccionDef AsignarRecibo()
        {
            var a = Crear("Operaciones", "asignar-comprobantes", "Asignar Comprobantes", "Recibos", "Asignar Comprobantes al recibo.", Enums.Accion.Operaciones, c =>
            {
                var rec = new RecibosManager(new Recibos { Id = c.Id }).Recibo;
                ValidarAsignable(rec.Fecha_Anulacion, rec.Fecha_Liquidacion, rec.ImporteSinAplicar);
                var lista = new List<RecibosComprobantes>();
                foreach (var f in new RecibosComprobantesManager().Buscar(rec.TipoEntidad, rec.Id_Entidad ?? 0, new List<RecibosComprobantes>()))
                {
                    var pago = c.Valor<decimal>(Clave("pago_", f.Id_ComprobantesVentas));
                    if (pago <= 0) continue;
                    if (pago > f.ImporteAdeudado) throw new ValidationException("El importe a aplicar supera al adeudado en " + f.Comprobante + ".");
                    f.ImportePago = pago;
                    lista.Add(f);
                }
                if (lista.Count == 0) throw new ValidationException("Ingrese el importe a aplicar en al menos un comprobante.");
                RecibosComprobantesManager.AsociarComprobantes(c.Id, lista);
                return AccionResultado.Ok("Comprobantes asignados al recibo.");
            });
            a.CamposDinamicos = c =>
            {
                var rec = new RecibosManager(new Recibos { Id = c.Id }).Recibo;
                ValidarAsignable(rec.Fecha_Anulacion, rec.Fecha_Liquidacion, rec.ImporteSinAplicar);
                return CamposPago(new RecibosComprobantesManager().Buscar(rec.TipoEntidad, rec.Id_Entidad ?? 0, new List<RecibosComprobantes>()),
                    f => f.Id_ComprobantesVentas, f => f.Comprobante, f => f.Fecha, f => f.Importe, f => f.ImporteAdeudado, rec.ImporteSinAplicar);
            };
            return a;
        }

        private static AccionDef AsignarOP()
        {
            var a = Crear("Operaciones", "asignar-comprobantes", "Asignar Comprobantes", "OrdenesPago", "Asignar Comprobantes a la orden de pago.", Enums.Accion.Operaciones, c =>
            {
                var op = new OrdenesPagoManager(new OrdenesPago { Id = c.Id }).OP;
                ValidarAsignable(op.Fecha_Anulacion, op.Fecha_Liquidacion, op.ImporteSinAplicar);
                var lista = new List<OrdenesPagoComprobantes>();
                foreach (var f in new OrdenesPagoComprobantesManager().Buscar(op.TipoEntidad, op.Id_Entidad ?? 0, new List<OrdenesPagoComprobantes>()))
                {
                    var pago = c.Valor<decimal>(Clave("pago_", f.Id_ComprobantesCompras));
                    if (pago <= 0) continue;
                    if (pago > f.ImporteAdeudado) throw new ValidationException("El importe a aplicar supera al adeudado en " + f.Comprobante + ".");
                    f.ImportePago = pago;
                    lista.Add(f);
                }
                if (lista.Count == 0) throw new ValidationException("Ingrese el importe a aplicar en al menos un comprobante.");
                OrdenesPagoComprobantesManager.AsociarComprobantes(c.Id, lista);
                return AccionResultado.Ok("Comprobantes asignados a la orden de pago.");
            });
            a.CamposDinamicos = c =>
            {
                var op = new OrdenesPagoManager(new OrdenesPago { Id = c.Id }).OP;
                ValidarAsignable(op.Fecha_Anulacion, op.Fecha_Liquidacion, op.ImporteSinAplicar);
                return CamposPago(new OrdenesPagoComprobantesManager().Buscar(op.TipoEntidad, op.Id_Entidad ?? 0, new List<OrdenesPagoComprobantes>()),
                    f => f.Id_ComprobantesCompras, f => f.Comprobante, f => f.Fecha, f => f.Importe, f => f.ImporteAdeudado, op.ImporteSinAplicar);
            };
            return a;
        }

        private static List<LookupItem> Asignados<T>(IEnumerable<T> comps, Func<T, bool> borrado, Func<T, int> id, Func<T, string> comp, Func<T, decimal> pago)
        {
            var l = (comps ?? Enumerable.Empty<T>()).Where(x => !borrado(x))
                .Select(x => new LookupItem { Key = id(x), Name = comp(x) + " - aplicado " + HtmlDocumento.Formatear(pago(x)) }).ToList();
            if (l.Count == 0) throw new ValidationException("El comprobante no posee comprobantes asignados.");
            return l;
        }

        private static AccionDef DesasignarRecibo()
        {
            var a = Crear("Operaciones", "desasignar-comprobantes", "Desasignar Comprobantes", "Recibos", "Desasignar Comprobantes al recibo.", Enums.Accion.Operaciones, c =>
            {
                var ids = c.Enteros("comprobantes");
                using (var m = new RecibosManager(new Recibos { Id = c.Id }))
                {
                    if (m.Recibo.Fecha_Anulacion != null) throw new ValidationException("El recibo se encuentra anulado.");
                    foreach (var x in m.Recibo.Comprobantes.Where(x => ids.Contains(x.Id))) x.Borrado = true;
                    m.Save();
                }
                return AccionResultado.Ok("Comprobantes desasignados del recibo.");
            }, "¿Desea desasignar los comprobantes seleccionados?");
            a.CamposDinamicos = c =>
            {
                var rec = new RecibosManager(new Recibos { Id = c.Id }).Recibo;
                return new List<FieldSchema> { Campo.Multi("comprobantes", "Comprobantes a desasignar",
                    Asignados(rec.Comprobantes, x => x.Borrado, x => x.Id, x => x.Comprobante, x => x.ImportePago)) };
            };
            return a;
        }

        private static AccionDef DesasignarOP()
        {
            var a = Crear("Operaciones", "desasignar-comprobantes", "Desasignar Comprobantes", "OrdenesPago", "Desasignar Comprobantes a la orden de pago.", Enums.Accion.Operaciones, c =>
            {
                var ids = c.Enteros("comprobantes");
                var m = new OrdenesPagoManager(new OrdenesPago { Id = c.Id });
                if (m.OP.Fecha_Anulacion != null) throw new ValidationException("La orden de pago se encuentra anulada.");
                foreach (var x in m.OP.Comprobantes.Where(x => ids.Contains(x.Id))) x.Borrado = true;
                m.Save();
                return AccionResultado.Ok("Comprobantes desasignados de la orden de pago.");
            }, "¿Desea desasignar los comprobantes seleccionados?");
            a.CamposDinamicos = c =>
            {
                var op = new OrdenesPagoManager(new OrdenesPago { Id = c.Id }).OP;
                return new List<FieldSchema> { Campo.Multi("comprobantes", "Comprobantes a desasignar",
                    Asignados(op.Comprobantes, x => x.Borrado, x => x.Id, x => x.Comprobante, x => x.ImportePago)) };
            };
            return a;
        }

        // ---------- Vales masivos desde Excel (frmValesMasivo_AddMod) ----------

        private static AccionDef ImportarVales()
        {
            var a = Crear("Operaciones", "importar-excel", "Importar Excel con Vales", "ValesMasivo", "Importar Excel con Vales", Enums.Accion.Operaciones, c =>
            {
                var cc = c.Valor<int?>("centroCosto") ?? throw new ValidationException("Debe seleccionar un centro de costo.");
                var caja = c.Valor<int?>("caja") ?? throw new ValidationException("Debe seleccionar una caja.");
                var vales = c.ConArchivo("archivo", ValesManager.ImportarExcel);
                if (vales == null || vales.Count == 0) throw new ValidationException("El archivo no contiene vales.");
                foreach (var o in vales)
                {
                    var m = new ValesManager(o);
                    o.Id_CentroCosto = cc;
                    o.Id_Caja = caja;
                    m.Save();
                }
                return AccionResultado.Ok("Se importaron " + vales.Count + " vales.");
            }, "¿Desea importar y guardar los vales del archivo?");
            a.Seleccion = Seleccion.Ninguna;
            a.CamposDinamicos = c => new List<FieldSchema>
            {
                Campo.Opciones("caja", "Caja", Sistema.Cajas.Select(x => new LookupItem { Key = x.Id_Caja, Name = x.Caja + " - " + x.Sucursal }), true, Sistema.Cajas.FirstOrDefault()?.Id_Caja),
                Campo.Opciones("centroCosto", "Centro de Costo", Sistema.CentrosCostos.Select(x => new LookupItem { Key = x.Key, Name = x.Name }), true, Sistema.CentrosCostos.FirstOrDefault()?.Key),
                Campo.Archivo("archivo")
            };
            return a;
        }
    }
}
