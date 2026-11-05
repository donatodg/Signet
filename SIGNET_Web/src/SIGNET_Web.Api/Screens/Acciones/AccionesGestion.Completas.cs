using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;

namespace SIGNET_Web.Api.Screens.Acciones
{
    /// <summary>Operaciones que en el escritorio abren diálogos (confirmación parcial, duplicar, generar, mail, Excel).</summary>
    public sealed partial class AccionesGestion
    {
        private const int FactorEntidad = 100000000;

        private static AccionResultado Pdf(AccionResultado documento, string nombre) => Exportador.ComoPdf(documento, nombre);

        private static string Mail(Enums.TipoEntidad tipo, int? idEntidad)
        {
            if (idEntidad == null) throw new ValidationException("El comprobante no tiene entidad asignada.");
            var mail = ComprobantesVentasManager.ObtenerMail(tipo, idEntidad.Value);
            if (string.IsNullOrWhiteSpace(mail)) throw new ValidationException("La entidad no posee un mail cargado.");
            return mail;
        }

        private static AccionResultado EnviarMails(AccionContexto c, Func<int, (AccionResultado Doc, string Archivo, string Asunto, string Destino)> armar)
        {
            var enviados = new List<string>();
            foreach (var id in c.Ids)
            {
                var x = armar(id);
                Exportador.EnviarMail(x.Doc, x.Archivo, x.Asunto, x.Destino);
                enviados.Add(x.Destino);
            }
            return AccionResultado.Ok("Mail enviado a: " + string.Join(", ", enviados.Distinct()), false);
        }

        private static AccionContexto Uno(AccionContexto c, int id) =>
            new AccionContexto { Pantalla = c.Pantalla, Ids = new List<int> { id }, Valores = c.Valores, Service = c.Service };

        private static List<LookupItem> TiposComprobanteVentas() => Sistema.TipoComprobanteVentas.Select(LookupItem.From).ToList();

        private static string NombreOpcion(List<LookupItem> opciones, int key) =>
            opciones.FirstOrDefault(o => Convert.ToString(o.Key, CultureInfo.InvariantCulture) == key.ToString(CultureInfo.InvariantCulture))?.Name ?? key.ToString(CultureInfo.InvariantCulture);

        private static string Clave(string prefijo, int id) => prefijo + id.ToString(CultureInfo.InvariantCulture);

        // ---------- Comprobantes de Ventas ----------

        private static AccionDef VentasConfirmarParcial()
        {
            var a = Operacion("confirmar-parcial", "Confirmar Parcial", "ComprobantesVentas", "Confirmar parcialmente Comprobante de Venta", c =>
            {
                var filas = ComprobantesVentasConfirmacionParcialManager.Buscar(c.Id);
                var lista = new List<ComprobantesVentasDetalleProcesados>();
                var todo = true;
                var errores = "";
                foreach (var f in filas)
                {
                    var cant = c.Valor<decimal>(Clave("cant_", f.Id_ComprobanteVentaDetalle));
                    if (cant < 0) { errores += "La cantidad no puede ser negativa en " + f.Producto + "\r\n"; continue; }
                    if (cant > f.Cantidad - f.CantidadProcesada) { errores += "La cantidad procesada es mayor a la pendiente en " + f.Producto + "\r\n"; continue; }
                    if (todo && f.Cantidad != cant + f.CantidadProcesada) todo = false;
                    if (cant > 0)
                        lista.Add(new ComprobantesVentasDetalleProcesados
                        {
                            Id_ComprobanteVentaDetalle = f.Id_ComprobanteVentaDetalle,
                            Cantidad = cant,
                            Id_ComprobanteVentaOriginal = f.Id_ComprobanteVentaOriginal,
                            Id_ComprobanteVentaProcesado = f.Id_ComprobanteVentaProcesado
                        });
                }
                if (errores != "") throw new ValidationException(errores);
                if (lista.Count == 0) throw new ValidationException("Ingrese al menos una cantidad a procesar.");
                var msg = ComprobantesVentasManager.ConfirmarParcialmente(new ComprobantesVentas { Id = c.Id }, lista, todo);
                return AccionResultado.Ok(string.IsNullOrEmpty(msg) ? "Comprobante confirmado parcialmente." : msg);
            }, "¿Desea Confirmar parcialmente el Item Seleccionado?");
            a.CamposDinamicos = c => CamposCantidades(ComprobantesVentasConfirmacionParcialManager.Buscar(c.Id)
                .Select(f => (f.Id_ComprobanteVentaDetalle, f.Producto, f.Cantidad, f.CantidadProcesada)));
            return a;
        }

        /// <summary>Un campo de cantidad por renglón (reemplazo de la grilla editable de frm*ConfirmacionParcial).</summary>
        private static List<FieldSchema> CamposCantidades(IEnumerable<(int Id, string Producto, decimal Cantidad, decimal Procesada)> filas)
        {
            var campos = filas.Select(f => Campo.Decimal(Clave("cant_", f.Id),
                f.Producto + " (cant. " + HtmlDocumento.Formatear(f.Cantidad) + ", procesada " + HtmlDocumento.Formatear(f.Procesada) + ", pendiente " + HtmlDocumento.Formatear(f.Cantidad - f.Procesada) + ")",
                false, 0m)).ToList();
            if (campos.Count == 0) throw new ValidationException("No hay renglones pendientes para procesar.");
            return campos;
        }

        private static AccionDef VentasDuplicar()
        {
            var a = Operacion("duplicar", "Duplicar", "ComprobantesVentas", "Duplica Comprobante de Venta", c =>
            {
                var tipos = TiposComprobanteVentas();
                var tipo = c.Valor<int>("tipoComprobante");
                var clave = c.Valor<long>("entidad");
                var tipoEntidad = (Enums.TipoEntidad)(int)(clave / FactorEntidad);
                var idEntidad = (int)(clave % FactorEntidad);
                var id = ComprobantesVentasManager.DuplicarVenta(new ComprobantesVentas { Id = c.Id }, tipo, tipoEntidad, idEntidad);
                return AccionResultado.Ok("Se creó el comprobante " + NombreOpcion(tipos, tipo) + " - Id " + id);
            });
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
                    Campo.Opciones("tipoComprobante", "Tipo de Comprobante", TiposComprobanteVentas()),
                    Campo.Opciones("entidad", "Entidad", entidades),
                };
            };
            return a;
        }

        private static AccionDef VentasGenerarRecibo()
        {
            var a = Operacion("generar-recibo", "Generar Recibo", "ComprobantesVentas", "Generar Recibo", c =>
            {
                var f = Fila<ComprobantesVentasManager.SearchResult>(c);
                if (!VENET_Tesoreria_BL.TipoComprobanteManager.GeneraDeuda(f.Id_TipoComprobante)) throw new ValidationException("El comprobante no genera deuda y no se puede asignar un recibo.");
                if (f.FechaAnulacion != null) throw new ValidationException("El comprobante se encuentra anulado.");
                if (f.FechaLiquidacion == null) throw new ValidationException("El comprobante se encuentra pendiente.");
                var importe = Convert.ToDecimal(f.Importe);
                var pagado = ComprobantesVentasManager.GetImportePagoComprobante(f.Id);
                if (pagado >= importe) throw new ValidationException("El comprobante ya se ha abonado.");
                var saldo = importe - pagado;
                var alta = new AltaPrecargada { Pantalla = "Recibos" };
                alta.Valores["Concepto"] = ComprobantesComprasManager.GetNombreComprobante(f.Id_TipoComprobante) + " " + f.Comprobante;
                alta.Valores["Fecha"] = Sistema.ObtenerFecha();
                alta.Valores["Id_Entidad"] = f.Id_Entidad;
                alta.Valores["Id_CentroCosto"] = f.Id_CentroCosto;
                alta.Valores["Id_Sucursal"] = f.Id_Sucursal;
                alta.Valores["TipoEntidad"] = (int)f.Id_TipoEntidad;
                alta.Valores["Observaciones"] = "-";
                alta.Valores["Importe"] = saldo;
                alta.Detalles["Comprobantes"] = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { ["Id_ComprobantesVentas"] = f.Id, ["ImporteAdeudado"] = saldo, ["ImportePago"] = saldo }
                };
                return new AccionResultado { Alta = alta, Mensaje = "Complete el detalle (medios de pago) y guarde el recibo. Luego confírmelo desde Recibos > Operaciones > Confirmar." };
            }, "¿Desea Generar el Recibo del Item Seleccionado?");
            return a;
        }

        private static AccionResultado MailVentas(AccionContexto c) => EnviarMails(c, id =>
        {
            var f = Fila<ComprobantesVentasManager.SearchResult>(c, id);
            var tc = ComprobantesComprasManager.GetNombreComprobante(f.Id_TipoComprobante);
            return (DocumentoVentas(Uno(c, id), "Comprobante", null), tc + "-" + f.Comprobante + ".pdf", "Comprobante " + tc + f.Comprobante, Mail(f.Id_TipoEntidad, f.Id_Entidad));
        });

        // ---------- Compras ----------

        private static AccionDef ComprasGenerarOP()
        {
            return Operacion("generar-op", "Generar OP", "ComprobantesCompras", "Generar Orden de Pago", c =>
            {
                var f = Fila<ComprobantesComprasManager.SearchResult>(c);
                if (!VENET_Tesoreria_BL.TipoComprobanteManager.GeneraDeuda(f.Id_TipoComprobante)) throw new ValidationException("El comprobante no genera deuda y no se puede asignar una orden de pago.");
                if (f.FechaAnulacion != null) throw new ValidationException("El comprobante se encuentra anulado.");
                if (f.FechaLiquidacion == null) throw new ValidationException("El comprobante se encuentra pendiente.");
                var importe = Convert.ToDecimal(f.Importe);
                var pagado = ComprobantesComprasManager.GetImportePagoComprobante(f.Id);
                if (pagado >= importe) throw new ValidationException("El comprobante ya se ha abonado.");
                var saldo = importe - pagado;
                var alta = new AltaPrecargada { Pantalla = "OrdenesPago" };
                alta.Valores["Concepto"] = ComprobantesComprasManager.GetNombreComprobante(f.Id_TipoComprobante) + " " + f.Comprobante;
                alta.Valores["Fecha"] = Sistema.ObtenerFecha();
                alta.Valores["Id_Entidad"] = f.Id_Entidad;
                alta.Valores["Id_CentroCosto"] = f.Id_CentroCosto;
                alta.Valores["Id_Sucursal"] = f.Id_Sucursal;
                alta.Valores["TipoEntidad"] = (int)f.Id_TipoEntidad;
                alta.Valores["Observaciones"] = "-";
                alta.Valores["Importe"] = saldo;
                alta.Detalles["Comprobantes"] = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { ["Id_ComprobantesCompras"] = f.Id, ["ImporteAdeudado"] = saldo, ["ImportePago"] = saldo }
                };
                return new AccionResultado { Alta = alta, Mensaje = "Complete el detalle (medios de pago / impuestos) y guarde la orden de pago. Luego confírmela desde Órdenes de Pago > Operaciones > Confirmar." };
            }, "¿Desea Generar la Orden de Pago del Item Seleccionado?");
        }

        // ---------- Cotizaciones ----------

        private static AccionDef CotizacionesGenerarVenta()
        {
            var a = Operacion("generar-comprobante-venta", "Generar Comprobante Venta", "Cotizaciones", "Genera Comprobante de Venta", c =>
            {
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Cotizaciones_GeneraPedido)))
                    return AccionResultado.Ok("Se creó el comprobante Pedido - Id " + CotizacionesManager.GenerarPedido(new Cotizaciones { Id = c.Id }));
                var tipo = c.Valor<int>("tipoComprobante");
                var id = CotizacionesManager.GenerarVenta(new Cotizaciones { Id = c.Id }, tipo);
                return AccionResultado.Ok("Se creó el comprobante " + NombreOpcion(TiposComprobanteVentas(), tipo) + " - Id " + id);
            });
            a.CamposDinamicos = c => Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Cotizaciones_GeneraPedido))
                ? new List<FieldSchema>()
                : new List<FieldSchema> { Campo.Opciones("tipoComprobante", "Tipo de Comprobante", TiposComprobanteVentas()) };
            return a;
        }

        private static AccionResultado MailCotizaciones(AccionContexto c) => EnviarMails(c, id =>
        {
            var f = Fila<CotizacionesManager.SearchResult>(c, id);
            var mail = f.Id_Entidad == null ? null : CotizacionesManager.ObtenerMail(f.Id_TipoEntidad, f.Id_Entidad.Value);
            return (DocumentoCotizaciones(Uno(c, id)), "Cotizacion-" + f.Comprobante + ".pdf", "Comprobante Cotización " + f.Comprobante, mail);
        });

        // ---------- Pedidos ----------

        private static void ValidarPedidoGenerable(PedidosManager.SearchResult f)
        {
            if (f.Id_ComprobanteGenerado != null) throw new ValidationException("El pedido ya fue generado.");
            if (f.FechaLiquidacion == null) throw new ValidationException("No se puede generar a partir de un pedido sin confirmar.");
        }

        private static AccionDef PedidosGenerarVenta()
        {
            var a = Operacion("generar-comprobante-venta", "Generar Comprobante Venta", "Pedidos", "Genera Comprobante de Venta", c =>
            {
                ValidarPedidoGenerable(Fila<PedidosManager.SearchResult>(c));
                var tipo = c.Valor<int>("tipoComprobante");
                var id = PedidosManager.GenerarVenta(new Pedidos { Id = c.Id }, tipo);
                return AccionResultado.Ok("Se creó el comprobante " + NombreOpcion(TiposComprobanteVentas(), tipo) + " - Id " + id);
            });
            a.CamposDinamicos = c => new List<FieldSchema> { Campo.Opciones("tipoComprobante", "Tipo de Comprobante", TiposComprobanteVentas()) };
            return a;
        }

        private static AccionDef PedidosGenerarVentaParcial()
        {
            var a = Operacion("generar-comprobante-venta-parcial", "Generar Comprobante Venta Parcial", "Pedidos", "Genera Comprobante de Venta Parcial", c =>
            {
                ValidarPedidoGenerable(Fila<PedidosManager.SearchResult>(c));
                var filas = PedidosConfirmacionParcialManager.Buscar(c.Id);
                var lista = new List<PedidosDetalleProcesados>();
                var todo = true;
                var errores = "";
                foreach (var f in filas)
                {
                    var cant = c.Valor<decimal>(Clave("cant_", f.Id_PedidoDetalle));
                    if (cant < 0) { errores += "La cantidad no puede ser negativa en " + f.Producto + "\r\n"; continue; }
                    if (cant > f.Cantidad - f.CantidadProcesada) { errores += "La cantidad procesada es mayor a la pendiente en " + f.Producto + "\r\n"; continue; }
                    if (todo && f.Cantidad != cant + f.CantidadProcesada) todo = false;
                    if (cant > 0)
                        lista.Add(new PedidosDetalleProcesados
                        {
                            Id_PedidoDetalle = f.Id_PedidoDetalle,
                            Cantidad = cant,
                            Id_PedidoOriginal = f.Id_PedidoOriginal,
                            Id_ComprobanteVentaProcesado = f.Id_ComprobanteVentaProcesado
                        });
                }
                if (errores != "") throw new ValidationException(errores);
                if (lista.Count == 0) throw new ValidationException("Ingrese al menos una cantidad a procesar.");
                var tipo = c.Valor<int>("tipoComprobante");
                var id = PedidosManager.GenerarVentaParcial(new Pedidos { Id = c.Id }, tipo, lista, todo);
                return AccionResultado.Ok("Se creó el comprobante " + NombreOpcion(TiposComprobanteVentas(), tipo) + " - Id " + id);
            });
            a.CamposDinamicos = c =>
            {
                var campos = new List<FieldSchema> { Campo.Opciones("tipoComprobante", "Tipo de Comprobante", TiposComprobanteVentas()) };
                campos.AddRange(CamposCantidades(PedidosConfirmacionParcialManager.Buscar(c.Id)
                    .Select(f => (f.Id_PedidoDetalle, f.Producto, f.Cantidad, f.CantidadProcesada))));
                return campos;
            };
            return a;
        }

        private static AccionResultado MailPedidos(AccionContexto c) => EnviarMails(c, id =>
        {
            var f = Fila<PedidosManager.SearchResult>(c, id);
            return (DocumentoPedidos(Uno(c, id), true), "Pedido-" + f.Comprobante + ".pdf", "Comprobante Pedido " + f.Comprobante, Mail(f.Id_TipoEntidad, f.Id_Entidad));
        });

        // ---------- Estado del pedido (frmPedidosEstados) ----------

        private static void ValidarEstadoPedido(AccionContexto c)
        {
            var f = c.Fila<PedidosManager.SearchResult>(c.Id);
            if (f == null) return;
            if (f.FechaLiquidacion == null) throw new ValidationException("Debe confirmar el pedido antes para ver su estado.");
            if (f.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");
        }

        private static AccionDef PedidosEstado() =>
            Operacion("estado", "Estado del Pedido", "Pedidos", "Estado del Pedido", c =>
            {
                ValidarEstadoPedido(c);
                var m = new PedidosEstadosManager(c.Id);
                var personal = m.Personal.ToDictionary(p => p.Id, p => p.Descripcion);
                Func<int?, object> nombre = id => id != null && personal.TryGetValue(id.Value, out var n) ? n : null;
                var tabla = TablaResultado.Desde(m.PedidosList.Where(t => t.UserDel == null), "Estado del pedido",
                    ("Codigo", "Código", x => x.Codigo),
                    ("Descripcion", "Descripción", x => x.Descripcion),
                    ("Cantidad", "Cantidad", x => x.Cantidad),
                    ("Avance", "Avance %", x => x.Avance),
                    ("Personal1", "Personal 1", x => nombre(x.Id_Personal1)),
                    ("Personal2", "Personal 2", x => nombre(x.Id_Personal2)),
                    ("Personal3", "Personal 3", x => nombre(x.Id_Personal3)),
                    ("FechaFinalizacion", "Finalización", x => x.FechaFinalizacion),
                    ("FechaEntregado", "Entregado", x => x.FechaEntregado));
                return new AccionResultado { Tablas = new List<TablaResultado> { tabla }, Refrescar = false };
            }, accionPermiso: Enums.Accion.Ver);

        private static AccionDef PedidosAsignarPersonal()
        {
            var a = Operacion("asignar-personal", "Asignar Personal a Todo", "PedidosEstados", "", c =>
            {
                ValidarEstadoPedido(c);
                PedidosEstadosManager.AsignaPersonal(c.Id, c.Valor<int?>("personal1"), c.Valor<int?>("personal2"), c.Valor<int?>("personal3"));
                return AccionResultado.Ok("Personal asignado a todos los renglones del pedido.");
            }, accionPermiso: Enums.Accion.Modificar);
            a.CamposDinamicos = c =>
            {
                var op = new PedidosEstadosManager(c.Id).Personal.Select(p => new LookupItem { Key = p.Id, Name = p.Descripcion }).ToList();
                return new List<FieldSchema>
                {
                    Campo.Opciones("personal1", "Personal 1", op, false),
                    Campo.Opciones("personal2", "Personal 2", op, false),
                    Campo.Opciones("personal3", "Personal 3", op, false)
                };
            };
            return a;
        }

        private static AccionDef PedidosCumplimiento() =>
            Operacion("cambiar-avance", "Cambiar Avance a Todo", "PedidosEstados", "", c =>
            {
                ValidarEstadoPedido(c);
                var avance = c.Valor<int>("avance");
                if (avance < 0 || avance > 100) throw new ValidationException("El Avance debe estar entre 0 y 100");
                PedidosEstadosManager.Cumplimiento(c.Id, avance);
                return AccionResultado.Ok("Avance actualizado.");
            }, campos: new List<FieldSchema> { Campo.Entero("avance", "Avance (%)", true, 0) }, accionPermiso: Enums.Accion.Modificar);

        // ---------- Presentación AFIP (frmComprobantesVentasPresentacion) ----------

        private static AccionDef VentasPresentar()
        {
            var a = Operacion("presentar", "Presentar", "ComprobantesVentas", "Presentar Comprobantes", c =>
            {
                var empresa = c.Valor<int>("empresa");
                var pendientes = ComprobantesVentasPresentacionManager.Buscar(empresa);
                if (pendientes.Count == 0) return AccionResultado.Ok("No hay comprobantes pendientes de presentar para la empresa.", false);
                var ticket = new VENET_WSFE_BL.LoginTicket();
                var resultados = new List<ComprobantesVentas>();
                string error = null;
                foreach (var p in pendientes)
                {
                    if (!(ticket.ExpirationTime > DateTime.Now))
                    {
                        if (string.IsNullOrEmpty(ticket.ObtenerTicket(empresa)) || ticket.CuitEmisor == 0) throw new ValidationException("Error obteniendo Ticket.");
                    }
                    var r = ticket.PresentarComprobante(ticket, p.Id);
                    r.Id = p.Id;
                    if (string.IsNullOrEmpty(r.Letra)) { r.Letra = p.Letra; r.PuntoVenta = p.PuntoVenta; r.NroComprobante = p.NroComprobante; }
                    resultados.Add(r);
                    if (r.ResultadoCAE != "A") { error = "El comprobante no se ha podido procesar."; break; }
                }
                var tabla = TablaResultado.Desde(resultados, "Comprobantes presentados",
                    ("Id", "Id", x => x.Id),
                    ("Comprobante", "Comprobante", x => x.Letra + "-" + x.PuntoVenta + "-" + x.NroComprobante),
                    ("AFIPCAE", "CAE", x => x.AFIPCAE),
                    ("FechaVtoCAE", "Vto. CAE", x => x.FechaVtoCAE),
                    ("ResultadoCAE", "Resultado", x => x.ResultadoCAE),
                    ("ObservacionesCAE", "Observaciones", x => x.ObservacionesCAE),
                    ("EventosCAE", "Eventos", x => x.EventosCAE));
                return new AccionResultado { Mensaje = error ?? "Presentación finalizada.", Tablas = new List<TablaResultado> { tabla }, Refrescar = true };
            }, "¿Desea presentar en AFIP los comprobantes pendientes de la empresa?", seleccion: Seleccion.Ninguna);
            a.CamposDinamicos = c => new List<FieldSchema> { Campo.Entidades("empresa", "Empresa", Sistema.EmpresasCuit) };
            return a;
        }

        // ---------- Excel ----------

        private static AccionDef ImportarExcel(string pantalla, string key, string titulo, string formulario, string descripcion, Enums.Modulos modulo, Func<string, string> importar)
        {
            return Operacion(key, titulo, formulario, descripcion, c => AccionResultado.Ok(c.ConArchivo("archivo", importar)),
                campos: new List<FieldSchema> { Campo.Archivo("archivo") }, modulo: modulo, seleccion: Seleccion.Ninguna);
        }

        private static AccionResultado ModeloExcelProductos()
        {
            var dir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SIGNET_Web", Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(dir);
            try
            {
                var ruta = System.IO.Path.Combine(dir, "ModeloPrecios.xlsx");
                ProductosManager.GeneraExcelModelo(ruta);
                return new AccionResultado { Archivo = ArchivoResultado.Xlsx("ModeloPrecios.xlsx", System.IO.File.ReadAllBytes(ruta)) };
            }
            finally { try { System.IO.Directory.Delete(dir, true); } catch (Exception) { } }
        }
    }
}
