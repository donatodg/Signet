using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Reporting;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;

namespace SIGNET_Web.Api.Screens.Acciones
{
    public sealed partial class AccionesGestion : IAccionesModulo
    {
        private const string Atencion = "¿Desea Confirmar el Item Seleccionado?";
        private const string AnularPregunta = "¿Desea Anular el Item Seleccionado?";

        public void Registrar(AccionesRegistro r)
        {
            RegistrarVentas(r);
            RegistrarCompras(r);
            RegistrarCotizaciones(r);
            RegistrarPedidos(r);
            RegistrarProcesar(r);
            RegistrarPadron(r);
            RegistrarListas(r);
            RegistrarProductos(r);
            RegistrarTipoIva(r);
            RegistrarImagenes(r);
        }

        private static AccionDef Def(string key, string titulo, string menu, Enums.Modulos modulo, string formulario,
            Enums.Accion accion, string descripcion, Seleccion seleccion = Seleccion.Una)
        {
            return new AccionDef
            {
                Key = key, Titulo = titulo, Menu = menu, Modulo = modulo, Formulario = formulario,
                Accion = accion, Descripcion = descripcion, Seleccion = seleccion
            };
        }

        private static AccionDef Operacion(string key, string titulo, string formulario, string descripcion,
            Func<AccionContexto, AccionResultado> ejecutar, string confirmacion = null, List<FieldSchema> campos = null,
            Enums.Modulos modulo = Enums.Modulos.Gestion, Seleccion seleccion = Seleccion.Una, Enums.Accion accionPermiso = Enums.Accion.Operaciones)
        {
            var a = Def(key, titulo, "Operaciones", modulo, formulario, accionPermiso, descripcion, seleccion);
            a.Ejecutar = ejecutar;
            a.Confirmacion = confirmacion;
            if (campos != null) a.Campos = campos;
            return a;
        }

        private static AccionDef Impresion(string key, string titulo, string formulario, string descripcion,
            Func<AccionContexto, AccionResultado> ejecutar, Enums.Modulos modulo = Enums.Modulos.Gestion,
            bool sinPermiso = false, Seleccion seleccion = Seleccion.Una, Enums.Accion accionPermiso = Enums.Accion.Imprimir)
        {
            var a = Def(key, titulo, "Imprimir", modulo, formulario, accionPermiso, descripcion, seleccion);
            a.Ejecutar = ejecutar;
            a.SinPermiso = sinPermiso;
            return a;
        }

        private static void RegistrarVentas(AccionesRegistro r)
        {
            const string s = "ComprobantesVentas";
            r.Agregar(s, Impresion("comprobante", "Comprobante", s, "Imprimir Comprobante", c => DocumentoVentas(c, "Comprobante", null), seleccion: Seleccion.Varias));
            r.Agregar(s, Impresion("comprobante-duplicado", "Comprobante Solo Duplicado", s, "Imprimir Comprobante", c => DocumentoVentas(c, "Comprobante", new[] { "DUPLICADO" }), seleccion: Seleccion.Varias));
            r.Agregar(s, Impresion("comprobante-triplicado", "Comprobante por Triplicado", s, "Imprimir Comprobante", c => DocumentoVentas(c, "Comprobante", new[] { "ORIGINAL", "DUPLICADO", "TRIPLICADO" }), seleccion: Seleccion.Varias));
            r.Agregar(s, Impresion("remito", "Remito", s, "Imprimir Comprobantes de Ventas", c => DocumentoVentas(c, "Remito", null), Enums.Modulos.Tesoreria, seleccion: Seleccion.Varias));
            r.Agregar(s, Impresion("comprobante-por-pantalla", "Comprobante por pantalla", s, "Imprimir Comprobante", c => DocumentoVentas(c, "Comprobante", new[] { "ORIGINAL" }), seleccion: Seleccion.Varias));

            r.Agregar(s, Operacion("confirmar", "Confirmar", s, "Confirmar Comprobante de Venta", c =>
            {
                var msg = ComprobantesVentasManager.Confirmar(new ComprobantesVentas { Id = c.Id });
                return AccionResultado.Ok(msg, true);
            }, Atencion));
            r.Agregar(s, VentasConfirmarParcial());
            var descuento = Operacion("cargar-descuento", "Cargar Descuento", s, "Cargar Descuento", c =>
            {
                var fila = Fila<ComprobantesVentasManager.SearchResult>(c);
                if (fila.FechaLiquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");
                using (var m = new ComprobantesVentasManager(new ComprobantesVentas { Id = c.Id }))
                {
                    m.ActualizaDescuento(c.Valor<decimal>("porcentaje"));
                    m.Save();
                }
                return AccionResultado.Ok("Descuento actualizado.");
            }, campos: new List<FieldSchema> { Campo.Decimal("porcentaje", "Porcentaje", true, 0m) });
            r.Agregar(s, descuento);
            r.Agregar(s, Operacion("anular", "Anular", s, "Anular Comprobante de Venta", c =>
            {
                var fila = Fila<ComprobantesVentasManager.SearchResult>(c);
                if (fila.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulada.");
                return AccionResultado.Ok(ComprobantesVentasManager.Anular(new ComprobantesVentas { Id = c.Id }, c.Texto("motivo")), true);
            }, AnularPregunta, new List<FieldSchema> { Campo.Texto("motivo", "Motivo Anulación", true) }));
            r.Agregar(s, Operacion("generar-pdf", "Generar PDF", s, "Generar PDF", c => Pdf(DocumentoVentas(c, "Comprobante", null), "Comprobantes.pdf"), seleccion: Seleccion.Varias));
            r.Agregar(s, Operacion("enviar-email", "Enviar por Email", s, "Enviar por Mail", MailVentas, "¿Desea enviar por mail el/los comprobante/s seleccionado/s?", seleccion: Seleccion.Varias));
            r.Agregar(s, VentasGenerarRecibo());
            r.Navegar(s, "Operaciones", "asociar-comprobante", "Asociar Comprobante", "ComprobanteVentaAsociado");
            r.Agregar(s, VentasDuplicar());
            r.Agregar(s, VentasPresentar());
        }

        private static void RegistrarCompras(AccionesRegistro r)
        {
            const string s = "ComprobantesCompras";
            r.Agregar(s, Operacion("confirmar", "Confirmar", s, "Confirmar Comprobante de Compra", c =>
                AccionResultado.Ok(ComprobantesComprasManager.Confirmar(new ComprobantesCompras { Id = c.Id }), true), Atencion));
            r.Agregar(s, Operacion("anular", "Anular", s, "Anular Comprobante de Compra", c =>
            {
                var fila = Fila<ComprobantesComprasManager.SearchResult>(c);
                if (fila.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulada.");
                if (ComprobantesComprasManager.ComprobanteEnOP(c.Id)) throw new ValidationException("El comprobante se encuentra en una Orden de Pago.");
                return AccionResultado.Ok(ComprobantesComprasManager.Anular(new ComprobantesCompras { Id = c.Id }, c.Texto("motivo")), true);
            }, AnularPregunta, new List<FieldSchema> { Campo.Texto("motivo", "Motivo Anulación", true) }));
            r.Agregar(s, ComprasGenerarOP());
            r.Agregar(s, Operacion("modificar-fecha", "Modificar Fecha", s, "Modificar Fecha Comprobante", c =>
            {
                ComprobantesComprasManager.CambiarFecha(new ComprobantesCompras { Id = c.Id }, c.Valor<DateTime>("fecha"));
                return AccionResultado.Ok("Fecha del comprobante modificada.");
            }, campos: new List<FieldSchema> { Campo.Fecha("fecha", "Fecha", true) }));
        }

        private static void RegistrarCotizaciones(AccionesRegistro r)
        {
            const string s = "Cotizaciones";
            r.Agregar(s, Impresion("comprobante", "Comprobante", s, "", c => DocumentoCotizaciones(c), sinPermiso: true));
            r.Agregar(s, Operacion("confirmar", "Confirmar", s, "Confirmar Cotizaciones", c =>
            {
                CotizacionesManager.Confirmar(new Cotizaciones { Id = c.Id });
                return AccionResultado.Ok("Cotización confirmada.");
            }, Atencion, modulo: Enums.Modulos.Tesoreria));
            r.Agregar(s, Operacion("anular", "Anular", s, "Anular Cotizaciones", c =>
            {
                var fila = Fila<CotizacionesManager.SearchResult>(c);
                if (fila.Fecha_Anulacion != null) throw new ValidationException("La cotización ya se encuentra anulada.");
                CotizacionesManager.Anular(new Cotizaciones { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Cotización anulada.");
            }, AnularPregunta, new List<FieldSchema> { Campo.Texto("motivo", "Motivo Anulación", true) }, Enums.Modulos.Tesoreria));
            r.Agregar(s, Operacion("cargar-descuento", "Cargar Descuento", s, "Cargar Descuento", c =>
            {
                var fila = Fila<CotizacionesManager.SearchResult>(c);
                if (fila.Fecha_Liquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");
                using (var m = new CotizacionesManager(new Cotizaciones { Id = c.Id }))
                {
                    m.ActualizaDescuento(c.Valor<decimal>("porcentaje"));
                    m.Save();
                }
                return AccionResultado.Ok("Descuento actualizado.");
            }, campos: new List<FieldSchema> { Campo.Decimal("porcentaje", "Porcentaje", true, 0m) }));
            r.Agregar(s, CotizacionesGenerarVenta());
            r.Agregar(s, Operacion("generar-pdf", "Generar PDF", s, "Generar PDF", c => Pdf(DocumentoCotizaciones(c), "Cotizaciones.pdf"), seleccion: Seleccion.Varias));
            r.Agregar(s, Operacion("enviar-mail", "Enviar por Mail", s, "Enviar por Mail", MailCotizaciones, "¿Desea enviar por mail la/s cotización/es seleccionada/s?", seleccion: Seleccion.Varias));
        }

        private static void RegistrarPedidos(AccionesRegistro r)
        {
            const string s = "Pedidos";
            r.Agregar(s, Impresion("comprobante", "Comprobante", s, "Imprimir Comprobante", c => DocumentoPedidos(c, true), seleccion: Seleccion.Varias));
            r.Agregar(s, Operacion("confirmar", "Confirmar", s, "Confirmar Pedidos", c =>
            {
                PedidosManager.Confirmar(new Pedidos { Id = c.Id });
                return AccionResultado.Ok("Pedido confirmado.");
            }, Atencion, modulo: Enums.Modulos.Tesoreria));
            r.Agregar(s, Operacion("anular", "Anular", s, "Anular Pedidos", c =>
            {
                var fila = Fila<PedidosManager.SearchResult>(c);
                if (fila.FechaAnulacion != null) throw new ValidationException("El pedido ya se encuentra anulado.");
                if (fila.FechaEntregado != null) throw new ValidationException("El pedido se encuentra entregado.");
                if (fila.FechaLiquidacion == null) throw new ValidationException("No se puede anular un pedido sin confirmar.");
                PedidosManager.Anular(new Pedidos { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Pedido anulado.");
            }, AnularPregunta, new List<FieldSchema> { Campo.Texto("motivo", "Motivo Anulación", true) }, Enums.Modulos.Tesoreria));
            r.Agregar(s, Operacion("entregar-pedido", "Entregar Pedido", s, "Entregar Pedido", c =>
            {
                var fila = Fila<PedidosManager.SearchResult>(c);
                if (fila.FechaEntregado != null) throw new ValidationException("El pedido ya está entregado.");
                PedidosEstadosManager.Entregar(c.Id, c.Valor<DateTime>("fecha"));
                return AccionResultado.Ok("Pedido entregado.");
            }, campos: new List<FieldSchema> { Campo.Fecha("fecha", "Fecha", true, DateTime.Today) }));
            r.Agregar(s, Operacion("anular-entrega-pedido", "Anular Entrega Pedido", s, "Anular Entrega", c =>
            {
                var fila = Fila<PedidosManager.SearchResult>(c);
                if (fila.FechaEntregado == null) throw new ValidationException("El pedido no está entregado.");
                if (fila.FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");
                PedidosEstadosManager.Entregar(c.Id, null);
                return AccionResultado.Ok("Entrega del pedido anulada.");
            }, modulo: Enums.Modulos.Gestion, accionPermiso: Enums.Accion.Ver));
            r.Agregar(s, Operacion("cargar-descuentos", "Cargar Descuentos", s, "Cargar Descuento", c =>
            {
                var fila = Fila<PedidosManager.SearchResult>(c);
                if (fila.FechaLiquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");
                var m = new PedidosManager(new Pedidos { Id = c.Id });
                {
                    m.ActualizaDescuento(c.Valor<decimal>("porcentaje"));
                    m.Save();
                }
                return AccionResultado.Ok("Descuento actualizado.");
            }, campos: new List<FieldSchema> { Campo.Decimal("porcentaje", "Porcentaje", true, 0m) }));
            r.Agregar(s, PedidosGenerarVenta());
            r.Agregar(s, PedidosGenerarVentaParcial());
            r.Agregar(s, Operacion("generar-pdf", "Generar PDF", s, "Generar PDF", c => Pdf(DocumentoPedidos(c, true), "Pedidos.pdf"), seleccion: Seleccion.Varias));
            r.Agregar(s, Operacion("enviar-mail", "Enviar por Mail", s, "Enviar por Mail", MailPedidos, "¿Desea enviar por mail el/los pedido/s seleccionado/s?", seleccion: Seleccion.Varias));
            r.Agregar(s, PedidosEstado());
            r.Agregar(s, PedidosAsignarPersonal());
            r.Agregar(s, PedidosCumplimiento());
        }

        private static void RegistrarProcesar(AccionesRegistro r)
        {
            const string s = "ComprobantesVentasAProcesar";
            r.Agregar(s, Operacion("procesar-pendientes", "Procesar Pendientes", s, "Procesar pendientes", c =>
            {
                ComprobantesVentasAProcesarManager.ProcesarPendientes();
                return AccionResultado.Ok("Pendientes procesados.");
            }, modulo: Enums.Modulos.Personal, seleccion: Seleccion.Ninguna));
            r.Agregar(s, ImportarExcel(s, "importar-excel", "Importar Excel", s, "Importar Excel", Enums.Modulos.Personal, ruta => { ComprobantesVentasAProcesarManager.ImportarExcel(ruta); return "Archivo importado."; }));
            r.Agregar(s, new AccionDef
            {
                Key = "generar-excel-modelo", Titulo = "Generar Excel Modelo", Menu = "Operaciones", Modulo = Enums.Modulos.Personal,
                Formulario = s, Accion = Enums.Accion.Operaciones, Descripcion = "Generar Plantilla Excel con Configuración", Seleccion = Seleccion.Ninguna,
                Ejecutar = c => new AccionResultado { Archivo = ArchivoResultado.Csv("Modelo_Comprobantes_Ventas.csv", "Cod.Prov.Tango,Cod.Artículo,Importe\r\n") }
            });
        }

        private static void RegistrarPadron(AccionesRegistro r)
        {
            // El handler WinForms está vacío; el menú queda identificado como tarea local de escritorio.
            r.SoloEscritorio("PadronIIBB", "Operaciones", "importar-archivo", "Importar Archivo", "La acción original no tiene implementación en el formulario web y depende de un selector de archivo local.");
        }

        private static void RegistrarListas(AccionesRegistro r)
        {
            const string s = "ProductosListasPrecios";
            r.Agregar(s, Impresion("lista-de-precio", "Lista de Precio", s, "Reporte de Lista de Precio", c => DocumentoListaPrecio(c, null), Enums.Modulos.Tesoreria));
            var categoria = Impresion("lista-de-precio-por-categoria", "Lista de Precio por Categoría", s, "Reporte de Lista de Precio por Categoría", c =>
            {
                var ids = c.Enteros("categorias").Distinct().ToList();
                if (ids.Count == 0) throw new ValidationException("Debe seleccionar una categoría.");
                var doc = DocumentoListaPrecio(c, ids);
                var clientes = c.Enteros("clientes");
                if (clientes.Count == 0) return doc;
                string[] mails;
                using (var m = new ProductosListasPreciosImprimirManager())
                    mails = m.ClientesEmail.Where(x => clientes.Contains(x.Id)).Select(x => x.Email).Distinct().ToArray();
                foreach (var mail in mails)
                    Exportador.EnviarMail(doc, "ListaPrecios-" + Sistema.ObtenerFechaHora().ToString("ddMMyyyyHHmmss"), "Lista de Precios", mail);
                var r2 = doc;
                r2.Mensaje = "Se enviaron " + mails.Length + " mails.";
                return r2;
            }, Enums.Modulos.Tesoreria);
            categoria.CamposDinamicos = _ =>
            {
                using (var m = new ProductosListasPreciosImprimirManager())
                {
                    var cats = Campo.Multi("categorias", "Categorías", m.Categorias.Select(x => new LookupItem { Key = x.Id, Name = x.Descripcion }), true);
                    cats.Default = m.Categorias.Select(x => x.Id).ToArray();
                    var cli = Campo.Multi("clientes", "Enviar por mail a (opcional)", m.ClientesEmail.Select(x => new LookupItem { Key = x.Id, Name = x.Nombre + " <" + x.Email + ">" }), false);
                    return new List<FieldSchema> { cats, cli };
                }
            };
            r.Agregar(s, categoria);
            r.Agregar(s, Operacion("detalle", "Detalle (actualizar precios)", s, "Detalle de la lista de precios", c =>
                new AccionResultado { Navegar = "ProductosActualizaListasPrecios", Parametros = new Dictionary<string, object> { { "Id_ListasPrecios", c.Id } } },
                accionPermiso: Enums.Accion.Modificar, modulo: Enums.Modulos.Gestion));
            r.Agregar(s, Operacion("actualizar-precios-productos", "Actualizar Precios Productos desde Lista de Precio", s, "Actualizar Precios Productos desde Lista de Precio", c =>
            {
                ProductosListasPreciosManager.ActualizarImporteProductosSegunLista(c.Id);
                return AccionResultado.Ok("Precios de productos actualizados.");
            }, "¿Desea Actualizar los Precios de los Productos con los de la Lista de Precio seleccionada?", modulo: Enums.Modulos.Tesoreria));
        }

        private static void RegistrarProductos(AccionesRegistro r)
        {
            const string s = "Productos";
            r.Agregar(s, Impresion("lista-de-precios", "Lista de Precios", s, "Ver Lista de Precios", c => DocumentoProductos(), Enums.Modulos.Gestion, false, Seleccion.Ninguna, Enums.Accion.Ver));
            r.Navegar(s, "Operaciones", "actualizacion-masiva-precio-venta", "Actualización Masiva de Precio Venta", "ProductosActualizaPrecios");
            r.Agregar(s, Operacion("actualizacion-masiva-costos", "Actualizacion Masiva de Costos", s, "Actualización Masiva de Costos", c =>
            {
                ProductosManager.ActualizacionCostos();
                return AccionResultado.Ok("Costos actualizados.");
            }, seleccion: Seleccion.Ninguna));
            r.Navegar(s, "Operaciones", "actualizacion-masiva-costo-compra", "Actualización Masiva de Costo Compra", "ProductosActualizaPreciosCosto");
            r.Agregar(s, new AccionDef
            {
                Key = "generar-excel-modelo", Titulo = "Generar Excel Modelo", Menu = "Operaciones", Modulo = Enums.Modulos.Gestion,
                Formulario = s, Accion = Enums.Accion.Operaciones, Descripcion = "Generar Excel Modelo Precios", Seleccion = Seleccion.Ninguna,
                Ejecutar = c => ModeloExcelProductos()
            });
            r.Agregar(s, ImportarExcel(s, "actualizacion-precio-venta-desde-excel", "Actualización Precio de Venta desde Excel", s, "Actualizar Precios Ventas con Excel", Enums.Modulos.Gestion, ruta => { ProductosManager.ActualizardesdeExcel(ruta, true); return "Precios de venta actualizados."; }));
            r.Agregar(s, ImportarExcel(s, "actualizacion-precio-costo-desde-excel", "Actualización Precio de Costo desde Excel", s, "Actualizar Precios Costos con Excel", Enums.Modulos.Gestion, ruta => { ProductosManager.ActualizardesdeExcel(ruta, false); return "Precios de costo actualizados."; }));
        }

        private static void RegistrarImagenes(AccionesRegistro r)
        {
            foreach (var t in new[] { "Cotizaciones", "ComprobantesVentas", "Productos" })
            {
                var tabla = t;
                r.Agregar(tabla, Operacion("imagenes", "Imágenes", tabla, "Ver Imagenes", c =>
                    new AccionResultado { ImagenesTabla = tabla, ImagenesId = c.Id, Titulo = "Imágenes" },
                    accionPermiso: tabla == "Productos" ? Enums.Accion.Ver : Enums.Accion.Operaciones));
            }
        }

        private static void RegistrarTipoIva(AccionesRegistro r)
        {
            r.Agregar("TipoIva", Operacion("configurar-talonarios", "Configurar Talonarios", "TipoIva", "Configurar Talonarios", c =>
                new AccionResultado { Navegar = "TipoIvaConfiguracion", Parametros = new Dictionary<string, object> { { "Id_TipoIvaDestino", c.Id } } }));
        }

        internal static AccionResultado ImprimirVenta(int id) =>
            DocumentoVentas(new AccionContexto { Ids = new List<int> { id } }, "Comprobante", null);

        private static AccionResultado DocumentoVentas(AccionContexto c, string titulo, string[] copias)
        {
            ExigirPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobantes de Ventas");
            if (c.Ids.Count > 1 && (titulo == "Remito"
                ? RepxRenderer.Configurado(Convert.ToString(Parametro.ObtenerValor(Parametro.Param.Ventas_NombreRemito)))
                : c.Ids.Any(id => RepxRenderer.Configurado(ComprobantesVentasManager.Reporte(new ComprobantesVentas { Id = id })?.Reporte))))
                return Exportador.CombinarDocumentos(c.Ids.Select(id => DocumentoVentas(Uno(c, id), titulo, copias)), titulo + ".pdf");
            var doc = new HtmlDocumento(titulo);
            bool primeraHoja = true;
            var configuraciones = new List<string>();
            foreach (var id in c.Ids)
            {
                var cv = new ComprobantesVentas { Id = id };
                var datos = ComprobantesVentasManager.ImprimeComprobante(cv);
                if (datos == null || datos.Count == 0) throw new ValidationException("No se encontraron datos para imprimir el comprobante.");
                var reporte = ComprobantesVentasManager.Reporte(cv);
                configuraciones.Add("Comprobante #" + id + ": plantilla '" + Convert.ToString(Get(reporte, "Reporte"), CultureInfo.InvariantCulture)
                    + "', impresora '" + Convert.ToString(Get(reporte, "Impresora"), CultureInfo.InvariantCulture) + "'.");
                var soloLiquidados = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados));
                if (datos[0].FechaLiquidacion == null && soloLiquidados) throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");
                if (soloLiquidados && Get(reporte, "Electronico") is bool && (bool)Get(reporte, "Electronico") && datos[0].AFIPCAE == null)
                    throw new ValidationException("Antes de imprimir el comprobante debe presentarlo en AFIP.");
                var etiquetas = copias;
                if (etiquetas == null)
                {
                    int n;
                    if (titulo == "Remito") n = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentasRemito_ImprimirCopias));
                    else if (!int.TryParse(Convert.ToString(Get(reporte, "Copias"), CultureInfo.InvariantCulture), out n)) n = 1;
                    etiquetas = CopiasNormales(n);
                }
                var plantilla = titulo == "Remito"
                    ? Convert.ToString(Parametro.ObtenerValor(Parametro.Param.Ventas_NombreRemito))
                    : Convert.ToString(Get(reporte, "Reporte"));
                if (RepxRenderer.Configurado(plantilla))
                    return ReportesWeb.Documento(plantilla, datos, titulo + "-" + id + ".pdf", etiquetas);
                foreach (var etiqueta in etiquetas)
                {
                    if (!primeraHoja) doc.SaltoPagina();
                    primeraHoja = false;
                    datos[0].LeyendaOriginal = etiqueta;
                    RenderComprobanteVentas(doc, datos[0], titulo, etiqueta);
                }
            }
            var resultado = AccionResultado.Documento(doc);
            resultado.Mensaje = "La impresión web generó " + (primeraHoja ? 0 : configuraciones.Count) +
                " comprobante(s) en formato HTML. Configuración registrada: " + String.Join(" ", configuraciones) +
                " No tiene plantilla REPX configurada. La impresora local se elige en el dialogo del navegador.";
            return resultado;
        }
        private static string[] CopiasNormales(int cantidad)
        {
            if (cantidad > 100) throw new ValidationException("La cantidad de copias no puede superar 100.");
            if (cantidad <= 1) return new[] { "ORIGINAL" };
            var titulos = new[] { "ORIGINAL", "DUPLICADO", "TRIPLICADO", "CUADRUPLICADO", "QUINTUPLICADO" };
            return Enumerable.Range(0, cantidad).Select(i => i < titulos.Length ? titulos[i] : "COPIA " + (i + 1)).ToArray();
        }

        private static AccionResultado DocumentoCotizaciones(AccionContexto c)
        {
            if (c.Ids.Count > 1 && c.Ids.Any(id => RepxRenderer.Configurado(CotizacionesManager.Reporte(new Cotizaciones { Id = id })?.Reporte)))
                return Exportador.CombinarDocumentos(c.Ids.Select(id => DocumentoCotizaciones(Uno(c, id))), "Cotizaciones.pdf");
            var doc = new HtmlDocumento("Cotización");
            bool primeraHoja = true;
            foreach (var id in c.Ids)
            {
                var entidad = new Cotizaciones { Id = id };
                var datos = CotizacionesManager.ImprimeComprobante(entidad);
                if (datos == null || datos.Count == 0) throw new ValidationException("No se encontraron datos para imprimir la cotización.");
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeCotizacionesSinLiquidar))
                    && datos[0].Registro.Fecha_Liquidacion == null
                    && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                    throw new ValidationException("Antes debe confirmar el comprobante.");
                var talonario = CotizacionesManager.Reporte(entidad);
                var plantilla = talonario?.Reporte;
                if (RepxRenderer.Configurado(plantilla))
                    return ReportesWeb.Documento(ReportesWeb.VarianteB(plantilla, CotizacionesManager.EntidadResponsableInscripto(entidad)),
                        datos, "Cotizacion-" + id + ".pdf", ReportesWeb.Copias(talonario.Copias));
                if (!primeraHoja) doc.SaltoPagina();
                primeraHoja = false;
                RenderDocumentoBase(doc, datos[0], "Cotización");
            }
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado DocumentoPedidos(AccionContexto c, bool generarPdf = false)
        {
            if (c.Ids.Count > 1 && c.Ids.Any(id => RepxRenderer.Configurado(PedidosManager.Reporte(new Pedidos { Id = id })?.Reporte)))
                return Exportador.CombinarDocumentos(c.Ids.Select(id => DocumentoPedidos(Uno(c, id), generarPdf)), "Pedidos.pdf");
            var doc = new HtmlDocumento("Pedido");
            bool primeraHoja = true;
            foreach (var id in c.Ids)
            {
                var fila = Fila<PedidosManager.SearchResult>(c, id);
                if (fila.FechaLiquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                    throw new ValidationException("Debe confirmar el pedido antes de imprimirlo.");
                var datos = PedidosManager.ImprimeComprobante(new Pedidos { Id = id });
                if (datos == null || datos.Count == 0) throw new ValidationException("No se encontraron datos para imprimir el pedido.");
                if (!primeraHoja) doc.SaltoPagina();
                primeraHoja = false;
                var talonario = PedidosManager.Reporte(new Pedidos { Id = id });
                if (RepxRenderer.Configurado(talonario?.Reporte))
                    return ReportesWeb.Documento(talonario.Reporte, datos, "Pedido-" + id + ".pdf", ReportesWeb.Copias(talonario.Copias));
                if (talonario == null || talonario.Reporte == "<Ninguno>") { doc.Horizontal(); RenderPedidoHorizontal(doc, datos[0]); }
                else RenderDocumentoBase(doc, datos[0], "Pedido");
            }
            return AccionResultado.Documento(doc);
        }

        /// <summary>Equivalente a xrptPedidoHorizontal: empresa, renglones (cantidad, código, producto) y firma del responsable.</summary>
        private static void RenderPedidoHorizontal(HtmlDocumento doc, object d)
        {
            var empresa = Get(d, "Empresa");
            doc.Encabezado(Convert.ToString(First(empresa, "Fantasia", "RazonSocial", "Nombre") ?? ""), null,
                "PEDIDO Nº " + Convert.ToString(First(d, "Comprobante", "NroComprobante")), null,
                new[] { ("Fecha", (object)Get(d, "Fecha")), ("Cliente", First(Get(d, "Entidad"), "Nombre", "RazonSocial")) });
            doc.Datos(("Observaciones", Get(d, "Observaciones")));
            var detalle = Get(d, "Detalle") as IEnumerable;
            doc.Tabla<object>(detalle == null ? new List<object>() : detalle.Cast<object>().ToList(),
                ("Cant.", o => First(o, "Cantidad", "Unidades")),
                ("Código", o => First(o, "Codigo", "CodigoProducto")),
                ("Producto", o => First(o, "Descripcion", "Producto", "Nombre")));
            doc.Firma("Responsable");
        }
        private static AccionResultado DocumentoListaPrecio(AccionContexto c, List<int> categorias)
        {
            var datos = categorias == null || categorias.Count == 0
                ? ProductosListasPreciosManager.ImprimeComprobante(c.Id)
                : ProductosListasPreciosManager.ImprimeComprobante(c.Id, categorias);
            if (datos == null || datos.Count == 0) throw new ValidationException("La lista de precios no contiene productos para imprimir.");
            if (System.IO.File.Exists(System.IO.Path.Combine(ReportesWeb.Carpeta ?? "", "ListaPrecios.repx")))
                return ReportesWeb.Documento("ListaPrecios.repx", datos, "ListaPrecios-" + c.Id + ".pdf");
            var registro = datos[0];
            var empresa = Get(registro, "Empresa");
            var detalle = Get(registro, "Detalle") as IEnumerable;
            var doc = new HtmlDocumento("Lista de Precio").Horizontal();
            doc.Encabezado(Convert.ToString(First(empresa, "Nombre", "Fantasia") ?? ""),
                new[] { Join(Get(empresa, "Direccion"), Get(empresa, "Localidad")), Convert.ToString(Get(empresa, "Cuit")) },
                Convert.ToString(Get(registro, "NombreLista") ?? "Lista de Precio"));
            var filas = detalle == null ? new List<object>() : detalle.Cast<object>().ToList();
            doc.Tabla<object>(filas,
                ("Código", o => Get(o, "Codigo")), ("Producto", o => Get(o, "Producto")),
                ("Categoría", o => Get(o, "Categoria")), ("Especie", o => Get(o, "Especie")),
                ("Precio", o => Get(o, "Importe")), ("Especie original", o => Get(o, "EspecieOriginal")),
                ("Precio original", o => Get(o, "ImporteOriginal")));
            return AccionResultado.Documento(doc);
        }
        private static AccionResultado DocumentoProductos()
        {
            var filas = ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas { OrdenadoPorIdCategoria = true });
            var doc = new HtmlDocumento("Lista de Precios").Horizontal();
            return AccionResultado.Documento(doc.Titulo("Lista de Precios").Tabla<object>(filas.Cast<object>(),
                ("Código", o => Get(o, "Codigo")), ("Descripción", o => Get(o, "Descripcion")),
                ("Categoría", o => Get(o, "Categoria")), ("Precio de Venta", o => Get(o, "Importe")),
                ("Precio de Costo", o => Get(o, "ImporteCosto"))));
        }

        private static AccionResultado ExportarModeloProductos()
        {
            var filas = ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas());
            var sb = new StringBuilder("Id,Codigo,Descripcion,Categoria,Importe Venta,Importe Costo\r\n");
            foreach (var f in filas)
            {
                sb.Append(Csv(Get(f, "Id"))).Append(',').Append(Csv(Get(f, "Codigo"))).Append(',')
                    .Append(Csv(Get(f, "Descripcion"))).Append(',').Append(Csv(Get(f, "Categoria"))).Append(',')
                    .Append(Csv(Get(f, "Importe"))).Append(',').Append(Csv(Get(f, "ImporteCosto"))).Append("\r\n");
            }
            return new AccionResultado { Archivo = ArchivoResultado.Csv("Precios_Actualizar.csv", sb.ToString()) };
        }

        private static string Csv(object value)
        {
            var s = Convert.ToString(value, CultureInfo.GetCultureInfo("es-AR")) ?? "";
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }

        private static void RenderComprobanteVentas(HtmlDocumento doc, object d, string titulo, string leyenda)
        {
            RenderDocumentoBase(doc, d, titulo);
            var cae = Get(d, "AFIPCAE");
            var vto = Get(d, "FechaVtoCAE");
            if (cae != null) doc.Datos(("CAE", cae), ("Fecha Vto CAE", vto), ("Código QR AFIP", Get(d, "CodigoQrAfip")));
            if (!String.IsNullOrWhiteSpace(leyenda)) doc.Leyenda(leyenda);
        }

        private static void RenderDocumentoBase(HtmlDocumento doc, object d, string titulo)
        {
            var empresa = Get(d, "Empresa");
            var entidad = Get(d, "Entidad");
            var numero = First(d, "NroComprobante", "Comprobante");
            var lineas = new[] { Join(First(empresa, "Direccion", "Domicilio", "Calle"), First(empresa, "Localidad", "Ciudad")),
                Join(First(empresa, "Telefono", "Telefono1"), First(empresa, "Email")), Convert.ToString(Get(empresa, "CUIT")) };
            doc.Encabezado(Convert.ToString(First(empresa, "RazonSocial", "Nombre", "Empresa") ?? ""), lineas,
                Convert.ToString(First(d, "Comprobante", "Sucursal") ?? titulo), Convert.ToString(Get(d, "Letra")),
                new[] { ("Número", (object)numero), ("Fecha", Get(d, "Fecha")), ("Vencimiento", Get(d, "FechaVto")) });
            doc.Datos(("Cliente", First(entidad, "Nombre", "RazonSocial")), ("CUIT", Get(entidad, "CUIT")),
                ("Domicilio", First(entidad, "Domicilio", "Direccion")), ("Condición IVA", First(entidad, "TipoIva", "CondicionIva")),
                ("Forma de pago", Get(d, "FormaPago")), ("Vendedor", Get(d, "Vendedor")), ("Observaciones", Get(d, "Observaciones")));
            var detalle = Get(d, "Detalle") as IEnumerable;
            if (detalle != null)
            {
                var filas = detalle.Cast<object>().ToList();
                doc.TablaSinVacias<object>(filas,
                    ("Código", o => First(o, "Codigo", "CodigoProducto")),
                    ("Descripción", o => First(o, "Descripcion", "Producto", "Nombre")),
                    ("Cantidad", o => First(o, "Cantidad", "Unidades")),
                    ("Precio unitario", o => First(o, "ImporteUnitario", "Precio", "PrecioUnitario")),
                    ("% Desc.", o => First(o, "PorcDescuento", "Descuento", "PorcentajeDescuento")),
                    ("Importe sin IVA", o => First(o, "ImporteSinIVa", "ImporteSinIva")),
                    ("IVA", o => First(o, "ImporteIVA", "ImporteIva")),
                    ("Importe", o => First(o, "ImporteConDescuento", "ImporteTotal", "Importe", "Total", "Subtotal")));
            }
            doc.Totales(("Subtotal", First(d, "SubTotal", "ImporteSubTotal")), ("IVA", Get(d, "TotalIva")),
                ("Otros impuestos", First(d, "ImpuestosTotal", "OtrosImpuestos")), ("Total", First(d, "ImporteTotal", "ImporteTotal")),
                ("Total en letras", Get(d, "TotalEnLetras")));
        }

        private static string Join(object a, object b)
        {
            return String.Join(" - ", new[] { Convert.ToString(a), Convert.ToString(b) }.Where(x => !String.IsNullOrWhiteSpace(x)));
        }

        private static void ExigirPermiso(Enums.Modulos modulo, string pantalla, Enums.Accion accion, string descripcion)
        {
            if (!Seguridad.ObtenerPermiso(modulo, pantalla, accion, descripcion))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(accion, pantalla, descripcion));
        }

        private static T Fila<T>(AccionContexto c) where T : class => Fila<T>(c, c.Id);

        private static T Fila<T>(AccionContexto c, int id) where T : class
        {
            var f = c.Fila<T>(id);
            if (f == null) throw new ValidationException("No se encontró el registro seleccionado.");
            return f;
        }
        private static object Get(object obj, string name)
        {
            if (obj == null) return null;
            try { return obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)?.GetValue(obj); }
            catch { return null; }
        }

        private static object First(object obj, params string[] names)
        {
            foreach (var name in names)
            {
                var v = Get(obj, name);
                if (v != null && !String.IsNullOrWhiteSpace(Convert.ToString(v))) return v;
            }
            return null;
        }
    }
}


