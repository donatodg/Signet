using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Tesoreria_BL;

namespace SIGNET_Web.Api.Screens.Acciones
{
    public sealed partial class AccionesTesoreria : IAccionesModulo
    {
        private const string Motivo = "Motivo Anulación";
        private static readonly Enums.Modulos Tesoreria = Enums.Modulos.Tesoreria;

        public void Registrar(AccionesRegistro r)
        {
            Agregar(r, "BoletasDepositos", "confirmar", "Confirmar", "Confirmar Boleta de Depósito", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                BoletasDepositosManager.Confirmar(new BoletasDepositos { Id = c.Id });
                return AccionResultado.Ok("Boleta de depósito confirmada.");
            });
            Agregar(r, "BoletasDepositos", "anular", "Anular", "Anular Boleta de Depósito", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ValidarNoAnulado(c.Fila<BoletasDepositosManager.SearchResult>(c.Id), "FechaAnulacion", "La boleta ya se encuentra anulada.");
                BoletasDepositosManager.Anular(new BoletasDepositos { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Boleta de depósito anulada.");
            }, Campo.Texto("motivo", Motivo, false));

            Agregar(r, "ChequeDescuento", "confirmar", "Confirmar", "Confirmar Descuento", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                ChequeDescuentoManager.Confirmar(new ChequesDescuento { Id = c.Id });
                return AccionResultado.Ok("Descuento confirmado.");
            });
            Agregar(r, "ChequeDescuento", "anular", "Anular", "Anular Descuento", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ValidarNoAnulado(c.Fila<ChequeDescuentoManager.SearchResult>(c.Id), "FechaAnulacion", "El descuento ya se encuentra anulado.");
                ChequeDescuentoManager.Anular(new ChequesDescuento { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Descuento anulado.");
            }, Campo.Texto("motivo", Motivo, false));

            AgregarMultiple(r, "ChequePropios", "depositar", "Depositar", "Depositar Cheques", "¿Desea depositar el/los item/s seleccionado/s?", ids => ChequePropiosManager.Depositar(ids), formulario: "ChequesPropios");
            AgregarMultiple(r, "ChequePropios", "rechazar", "Rechazar", "Rechazar Cheques", "¿Desea rechazar el/los item/s seleccionado/s?", ids => ChequePropiosManager.Rechazar(ids, null), Campo.Texto("motivo", Motivo, false), (ids, c) => ChequePropiosManager.Rechazar(ids, c.Texto("motivo")), "ChequesPropios");
            AgregarMultiple(r, "ChequePropios", "anular-deposito", "Anular Depósito", "Anular Depósito Cheques", "¿Desea anular depósito de el/los item/s seleccionado/s?", ids => ChequePropiosManager.AnularDeposito(ids), formulario: "ChequesPropios");
            AgregarMultiple(r, "ChequePropios", "anular-rechazo", "Anular Rechazo", "Anular Rechazo Cheques", "¿Desea anular rechazo de el/los item/s seleccionado/s?", ids => ChequePropiosManager.AnularRechazo(ids), formulario: "ChequesPropios");

            AgregarMultiple(r, "ChequeTerceros", "depositar", "Depositar", "Depositar Cheques", "¿Desea depositar el/los item/s seleccionado/s?", ids => ChequeTercerosManager.Depositar(ids), formulario: "ChequesTercero");
            AgregarMultiple(r, "ChequeTerceros", "rechazar", "Rechazar", "Rechazar Cheques", "¿Desea rechazar el/los item/s seleccionado/s?", ids => ChequeTercerosManager.Rechazar(ids, null), Campo.Texto("motivo", Motivo, false), (ids, c) => ChequeTercerosManager.Rechazar(ids, c.Texto("motivo")), "ChequesTercero");
            AgregarMultiple(r, "ChequeTerceros", "anular-deposito", "Anular Depósito", "Anular Depósito Cheques", "¿Desea anular depósito de el/los item/s seleccionado/s?", ids => ChequeTercerosManager.AnularDeposito(ids), formulario: "ChequesTercero");
            AgregarMultiple(r, "ChequeTerceros", "anular-rechazo", "Anular Rechazo", "Anular Rechazo Cheques", "¿Desea anular rechazo de el/los item/s seleccionado/s?", ids => ChequeTercerosManager.AnularRechazo(ids), formulario: "ChequesTercero");
            r.Navegar("ChequeTerceros", "Operaciones", "descontar", "Descontar", "ChequeDescuento");

            r.Agregar("EntidadesCtaCte", Crear("Imprimir", "comprobante", "Comprobante", "EntidadesCtaCte", "Imprimir Comprobante", Enums.Accion.Ver, ctx => ImprimirComprobanteCtaCte(ctx, false)));

            Agregar(r, "Especies", "actualizar-precios-cotizacion", "Actualizar Precios Segun Cotización", "Actualizar Precios Según Cotización", "¿Desea Actualizar los Precios de los Productos?", c =>
            {
                var fila = c.Fila<EspeciesManager.SearchResult>(c.Id);
                if (fila == null) throw new ValidationException("No se encontró la especie seleccionada.");
                VENET_Gestion_BL.ProductosManager.ActualizarImporteSeguncotizacion(fila.Id, fila.Cotizacion);
                return AccionResultado.Ok("Precios actualizados según la cotización.");
            });

            r.Agregar("EspeciesCtaCte", Crear("Imprimir", "comprobante", "Comprobante", "EspeciesCtaCte", "Imprimir Comprobante", Enums.Accion.Ver, ctx => ImprimirComprobanteCtaCte(ctx, true)));

            r.Agregar("ListaPagos", Crear("Imprimir", "listado-detallado", "Listado Detallado", "ListaPagos", "Imprimir Listado Detallado", Enums.Accion.Imprimir, c => ImprimirListaPagos(c.Id)));
            Agregar(r, "ListaPagos", "confirmar", "Confirmar", "Confirmar Lista de Pagos", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                ListaPagosManager.Confirmar(new ListaPagos { Id = c.Id });
                return AccionResultado.Ok("Lista de pagos confirmada.");
            });
            Agregar(r, "ListaPagos", "anular", "Anular", "Anular Lista de Pagos", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ListaPagosManager.Anular(new ListaPagos { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Lista de pagos anulada.");
            }, Campo.Texto("motivo", Motivo, false));
            Agregar(r, "ListaPagos", "generar-ordenes-pago", "Generar Ordenes de Pagos", "Generar Ordenes de Pagos", "¿Desea Generar las Ordenes de Pagos para el Item Seleccionado?", c =>
            {
                ListaPagosManager.GenerarOP(new ListaPagos { Id = c.Id });
                return AccionResultado.Ok("Órdenes de pago generadas.");
            });
            r.Agregar("ListaPagos", Crear("Operaciones", "generar-modelo-excel", "Generar Modelo Excel Importación", "ListaPagos", "Generar Plantilla Excel para Importación", Enums.Accion.Operaciones, c => ModeloExcel("modelo-lista-pagos.csv")));

            r.Agregar("OrdenesPago", Crear("Imprimir", "orden-pago", "Orden de Pago", "OrdenesPago", "Imprimir Ordenes de Pago", Enums.Accion.Imprimir, c => ImprimirOrdenPago(c.Id)));
            Agregar(r, "OrdenesPago", "confirmar", "Confirmar", "Confirmar Ordenes de Pago", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                OrdenesPagoManager.Confirmar(new OrdenesPago { Id = c.Id });
                return AccionResultado.Ok("Orden de pago confirmada.");
            });
            Agregar(r, "OrdenesPago", "anular", "Anular", "Anular Ordenes de Pago", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ValidarNoAnulado(c.Fila<OrdenesPagoManager.SearchResult>(c.Id), "Fecha_Anulacion", "La orden de pago ya se encuentra anulada.");
                OrdenesPagoManager.Anular(new OrdenesPago { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Orden de pago anulada.");
            }, Campo.Texto("motivo", Motivo, false));
            r.Agregar("OrdenesPago", Crear("Operaciones", "generar-pdf", "Generar PDF", "OrdenesPago", "Generar PDF", Enums.Accion.Operaciones, c => Exportador.ComoPdf(ImprimirOrdenPago(c.Id), "OP-" + c.Id)));

            r.Agregar("Recibos", Crear("Imprimir", "recibo", "Recibo", "Recibos", "Imprimir Recibo", Enums.Accion.Imprimir, c => ImprimirRecibo(c.Id)));
            Agregar(r, "Recibos", "confirmar", "Confirmar", "Confirmar Recibo", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                RecibosManager.Confirmar(new Recibos { Id = c.Id });
                return AccionResultado.Ok("Recibo confirmado.");
            });
            Agregar(r, "Recibos", "anular", "Anular", "Anular Recibo", "¿Desea Anular el Item Seleccionado?", c =>
            {
                RecibosManager.Anular(new Recibos { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Recibo anulado.");
            }, Campo.Texto("motivo", Motivo, false));
            r.Agregar("Recibos", Crear("Operaciones", "generar-pdf", "Generar PDF", "Recibos", "Generar PDF", Enums.Accion.Operaciones, c => Exportador.ComoPdf(ImprimirRecibo(c.Id), "REC-" + c.Id)));

            r.Agregar("Rendiciones", Crear("Imprimir", "rendicion-vales", "Rendición de Vales", "Rendiciones", "Imprime Rendiciones", Enums.Accion.Imprimir, c => ImprimirRendicion(c.Id)));
            Agregar(r, "Rendiciones", "confirmar", "Confirmar", "Confirmar Rendición", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                RendicionesManager.Confirmar(new Rendiciones { Id = c.Id });
                return AccionResultado.Ok("Rendición confirmada.");
            });
            Agregar(r, "Rendiciones", "anular", "Anular", "Anular Rendición", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ValidarNoAnulado(c.Fila<RendicionesManager.SearchResult>(c.Id), "FechaAnulacion", "La rendición ya se encuentra anulado.");
                RendicionesManager.Anular(new Rendiciones { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Rendición anulada.");
            }, Campo.Texto("motivo", Motivo, false));

            r.Agregar("Vales", Crear("Imprimir", "vale", "Vale", "Vales", "Imprime Vale", Enums.Accion.Imprimir, c => ImprimirVale(c.Id)));
            Agregar(r, "Vales", "confirmar", "Confirmar", "Confirmar Vale", "¿Desea Confirmar el Item Seleccionado?", c =>
            {
                ValesManager.Confirmar(new Vales { Id = c.Id });
                return AccionResultado.Ok("Vale confirmado.");
            });
            Agregar(r, "Vales", "anular", "Anular", "Anular Vale", "¿Desea Anular el Item Seleccionado?", c =>
            {
                ValidarNoAnulado(c.Fila<ValesManager.SearchResult>(c.Id), "FechaAnulacion", "El vale ya se encuentra anulado.");
                ValesManager.Anular(new Vales { Id = c.Id }, c.Texto("motivo"));
                return AccionResultado.Ok("Vale anulado.");
            }, Campo.Texto("motivo", Motivo, false));
            r.Navegar("Vales", "Operaciones", "rendir", "Rendir", "Rendiciones");
            r.Navegar("Vales", "Operaciones", "transferir-vales", "Transferir Vales", "ValesTransferencia");
            r.Agregar("Vales", Crear("Operaciones", "generar-modelo-excel", "Generar Modelo Excel Importación", "Vales", "Generar Plantilla Excel para Importación", Enums.Accion.Operaciones, c => ModeloExcel("modelo-vales.csv")));
            RegistrarCompletas(r);
        }

        private static void Agregar(AccionesRegistro r, string pantalla, string key, string titulo, string descripcion, string confirmacion, Func<AccionContexto, AccionResultado> ejecutar, params FieldSchema[] campos)
        {
            r.Agregar(pantalla, Crear("Operaciones", key, titulo, pantalla, descripcion, Enums.Accion.Operaciones, ejecutar, confirmacion, campos));
        }

        private static void AgregarMultiple(AccionesRegistro r, string pantalla, string key, string titulo, string descripcion, string confirmacion, Func<List<int>, string> operacion, FieldSchema campo = null, Func<List<int>, AccionContexto, string> operacionConContexto = null, string formulario = null)
        {
            var form = formulario ?? pantalla;
            var accion = Crear("Operaciones", key, titulo, form, descripcion, Enums.Accion.Operaciones, c =>
            {
                var mensaje = operacionConContexto != null ? operacionConContexto(c.Ids, c) : operacion(c.Ids);
                return AccionResultado.Ok(string.IsNullOrWhiteSpace(mensaje) ? "Operación realizada." : mensaje);
            }, confirmacion, campo == null ? new FieldSchema[0] : new[] { campo });
            accion.Seleccion = Seleccion.Varias;
            r.Agregar(pantalla, accion);
        }

        private static AccionDef Crear(string menu, string key, string titulo, string formulario, string descripcion, Enums.Accion permiso, Func<AccionContexto, AccionResultado> ejecutar, string confirmacion = null, params FieldSchema[] campos)
        {
            return new AccionDef
            {
                Key = key,
                Menu = menu,
                Titulo = titulo,
                Modulo = Tesoreria,
                Formulario = formulario,
                Accion = permiso,
                Descripcion = descripcion,
                Seleccion = Seleccion.Una,
                Confirmacion = confirmacion,
                Campos = campos == null ? new List<FieldSchema>() : campos.ToList(),
                Ejecutar = ejecutar
            };
        }

        private static void ValidarNoAnulado(object fila, string propiedad, string mensaje)
        {
            if (fila == null) throw new ValidationException("No se encontró el registro seleccionado.");
            if (Obtener(fila, propiedad) != null) throw new ValidationException(mensaje);
        }

        private static AccionResultado ModeloExcel(string nombre) => new AccionResultado
        {
            Archivo = ArchivoResultado.Csv(nombre, "Legajo;Importe;Descripción\r\n")
        };

        private static AccionResultado ImprimirRecibo(int id)
        {
            var recibo = new Recibos { Id = id };
            var talonario = RecibosManager.Reporte(recibo);
            var datos = RecibosManager.ImprimeRecibo(recibo);
            if (datos == null || datos.Count == 0) throw new ValidationException("No hay datos para imprimir el recibo.");
            if (datos[0].Registro.Fecha_Liquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

            if (Reporting.RepxRenderer.Configurado(talonario?.Reporte))
                return Reporting.ReportesWeb.Documento(talonario.Reporte, datos, "Recibo-" + id + ".pdf", Reporting.ReportesWeb.Copias(talonario.Copias));
            bool duplicados = talonario != null && talonario.Reporte == "<Ninguno>" && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja));
            var doc = new HtmlDocumento("Recibo");
            RenderComprobante(doc, "Recibo", datos[0], "ORIGINAL");
            if (duplicados)
            {
                doc.Corte();
                RenderComprobante(doc, "Recibo", datos[0], "DUPLICADO");
            }
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado ImprimirOrdenPago(int id)
        {
            var orden = new OrdenesPago { Id = id };
            var talonario = OrdenesPagoManager.Reporte(orden);
            var datos = OrdenesPagoManager.ImprimeOP(orden);
            if (datos == null || datos.Count == 0) throw new ValidationException("No hay datos para imprimir la orden de pago.");
            if (datos[0].Registro.Fecha_Liquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

            if (Reporting.RepxRenderer.Configurado(talonario?.Reporte))
                return Reporting.ReportesWeb.Documento(talonario.Reporte, datos, "OrdenPago-" + id + ".pdf", Reporting.ReportesWeb.Copias(talonario.Copias));
            bool retenciones = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.OrdenesDePago_UtilizaRetenciones));
            bool duplicados = !retenciones && talonario != null && talonario.Reporte == "<Ninguno>" && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja));
            var doc = new HtmlDocumento("Orden de Pago");
            RenderComprobante(doc, "Orden de Pago", datos[0], retenciones ? null : "ORIGINAL");
            if (retenciones) RenderRetenciones(doc, datos[0]);
            if (duplicados)
            {
                doc.Corte();
                RenderComprobante(doc, "Orden de Pago", datos[0], "DUPLICADO");
            }
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado ImprimirVale(int id)
        {
            var datos = ValesManager.ImprimeVale(new Vales { Id = id });
            if (datos == null || datos.Count == 0) throw new ValidationException("No hay datos para imprimir el vale.");
            bool duplicados = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja));
            var doc = new HtmlDocumento("Vale");
            RenderVale(doc, datos[0]);
            if (duplicados)
            {
                doc.Corte();
                RenderVale(doc, datos[0]);
            }
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado ImprimirRendicion(int id)
        {
            var datos = RendicionesManager.ImprimeRendicion(new Rendiciones { Id = id });
            if (datos == null || datos.Count == 0) throw new ValidationException("No hay datos para imprimir la rendición.");
            var d = datos[0];
            var doc = new HtmlDocumento("Rendición de Vales");
            doc.Encabezado(Texto(Obtener(d, "Empresa")), new[] { Texto(Obtener(d, "Localidad")) }, "RENDICIÓN DE VALES", null,
                new[] { ("Fecha", (object)Obtener(d, "Fecha")), ("Caja", Obtener(d, "Caja")), ("Legajo", Obtener(d, "Legajo")), ("Personal", Obtener(d, "Nombre")) });
            doc.Datos(("Vales", Obtener(d, "Vales")), ("Especie", Obtener(d, "Especie")), ("Tipo de documento", Obtener(d, "TipoDoc")), ("Nº documento", Obtener(d, "NroDoc")));
            doc.Tabla<object>(Elementos(Obtener(d, "Detalle")),
                ("Cuenta", x => Obtener(x, "Nombre") ?? Obtener(x, "Concepto")),
                ("Tipo documento", x => Obtener(x, "TipoDoc")),
                ("Nº documento", x => Obtener(x, "NroDoc")),
                ("Importe", x => Obtener(x, "Importe")));
            doc.Totales(("Importe vales", Obtener(d, "ImporteVales")), ("Devolución", Obtener(d, "ImporteDevolucion")), ("Diferencia", Obtener(d, "ImporteDiferencia")), ("Total", Obtener(d, "ImporteTotal")));
            doc.Firma("Entregó", "Recibió");
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado ImprimirListaPagos(int id)
        {
            var datos = ListaPagosManager.ImprimeListaPago(new ListaPagos { Id = id });
            if (datos == null || datos.Count == 0) throw new ValidationException("No hay datos para imprimir la lista de pagos.");
            var d = datos[0];
            var doc = new HtmlDocumento("Listado Detallado de Pagos");
            doc.Encabezado(Texto(Obtener(d, "Empresa")), new[] { Texto(Obtener(d, "Sucursal")), Texto(Obtener(d, "CentroCosto")) }, "LISTADO DETALLADO DE PAGOS", null,
                new[] { ("Nº", (object)Obtener(d, "Numero")), ("Fecha", Obtener(d, "FechaPago")), ("Especie", Obtener(d, "Especie")), ("Entidad", Obtener(d, "Entidad")), ("Sentido", Obtener(d, "Sentido")) });
            doc.Datos(("Descripción", Obtener(d, "Descripcion")), ("Fecha de confirmación", Obtener(d, "FechaConfirmacion")), ("Usuario", Obtener(d, "Usuario")), ("Impreso", Obtener(d, "FechaImpresion")));
            doc.Tabla<object>(Elementos(Obtener(d, "Detalle")), ("Nombre", x => Obtener(x, "Nombre")), ("Importe", x => Obtener(x, "Importe")), ("Descripción", x => Obtener(x, "Descripcion")));
            doc.Totales(("Importe total", Obtener(d, "ImporteTotal")));
            return AccionResultado.Documento(doc);
        }

        private static AccionResultado ImprimirComprobanteCtaCte(AccionContexto c, bool especies)
        {
            var fila = c.Fila(c.Id);
            if (fila == null) throw new ValidationException("No se encontró el comprobante seleccionado.");
            bool interno = Convert.ToBoolean(Obtener(fila, "InternoSistema") ?? false);
            int idComprobante = Convert.ToInt32(Obtener(fila, "Id_Comprobante") ?? 0);
            int tipo = Convert.ToInt32(Obtener(fila, "Id_TipoComprobante") ?? 0);
            if (interno && idComprobante > 0)
            {
                if (tipo == (int)Enums.TipoComprobante.Recibos) { ExigirPermisoImpresion("Recibos", "Imprimir Recibo"); return ImprimirRecibo(idComprobante); }
                if (tipo == (int)Enums.TipoComprobante.Vales) { ExigirPermisoImpresion("Vales", "Imprime Vale"); return ImprimirVale(idComprobante); }
                if (tipo == (int)Enums.TipoComprobante.Rendiciones) { ExigirPermisoImpresion("Rendiciones", "Imprime Rendiciones"); return ImprimirRendicion(idComprobante); }
                if (tipo == (int)Enums.TipoComprobante.OrdenesPago) { ExigirPermisoImpresion("OrdenesPago", "Imprimir Ordenes de Pago"); return ImprimirOrdenPago(idComprobante); }
                if (tipo == (int)Enums.TipoComprobante.ListaPago) { ExigirPermisoImpresion("ListaPagos", "Imprimir Listado Detallado"); return ImprimirListaPagos(idComprobante); }
            }
            if (!interno && idComprobante > 0 && Convert.ToInt32(Obtener(fila, "Id_Area") ?? 0) == (int)Enums.ComprobanteArea.Ventas)
                return AccionesGestion.ImprimirVenta(idComprobante);
            string origen = especies ? "de especies" : "de entidades";
            throw new ValidationException("La impresión de este comprobante " + origen + " requiere reportes de Gestión o un diseño del escritorio. No está disponible en la web.");
        }

        private static void ExigirPermisoImpresion(string formulario, string descripcion)
        {
            if (!Seguridad.ObtenerPermiso(Tesoreria, formulario, Enums.Accion.Imprimir, descripcion))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(Enums.Accion.Imprimir, formulario, descripcion));
        }
        private static void RenderComprobante(HtmlDocumento doc, string titulo, object dato, string leyenda)
        {
            var empresa = Obtener(dato, "Empresa");
            var entidad = Obtener(dato, "Entidad");
            var registro = Obtener(dato, "Registro");
            var numero = Texto(Obtener(dato, "Letra")) + " " + Texto(Obtener(dato, "PuntoVenta")) + "-" + Texto(Obtener(dato, "NroComprobante"));
            doc.Encabezado(Texto(Obtener(empresa, "RazonSocial") ?? Obtener(empresa, "Nombre") ?? Obtener(empresa, "Descripcion")),
                new[] { Texto(Obtener(empresa, "Domicilio")), Texto(Obtener(empresa, "Localidad")), "CUIT: " + Texto(Obtener(empresa, "Cuit")) }, titulo.ToUpperInvariant() + " Nº " + numero,
                Texto(Obtener(dato, "Letra")), new[] { ("Fecha", (object)Obtener(dato, "Fecha")), ("Sucursal", Obtener(empresa, "Descripcion")) });
            doc.Leyenda(leyenda);
            doc.Datos(("Señor", Obtener(entidad, "Nombre")), ("Domicilio", Obtener(entidad, "Domicilio")), ("Localidad", Obtener(entidad, "Localidad")), ("CUIT", Obtener(entidad, "Cuit")), ("IVA", Obtener(entidad, "TipoIva")),
                ("Concepto", Obtener(dato, "Concepto") ?? Obtener(registro, "Concepto")), ("Observaciones", Obtener(dato, "Observaciones") ?? Obtener(registro, "Observaciones")),
                ("Total en letras", Obtener(dato, "TotalEnLetras")));
            doc.Tabla<object>(Elementos(Obtener(dato, "Detalle")),
                ("Especie", x => Obtener(x, "Especie") ?? Obtener(x, "DescripcionEspecie")),
                ("Detalle", x => Obtener(x, "Detalle") ?? Obtener(x, "Concepto")),
                ("Importe", x => Obtener(x, "Importe")));
            doc.Totales(("Importe total", Obtener(dato, "ImporteTotal")));
            doc.Firma("Aclaración", "Firma");
        }

        /// <summary>Secciones extra de xrptOrdenPagoRetenciones: comprobantes imputados, retenciones y pendiente de imputar.</summary>
        private static void RenderRetenciones(HtmlDocumento doc, object dato)
        {
            var registro = Obtener(dato, "Registro");
            doc.Titulo("Comprobantes Imputados");
            doc.Tabla<object>(Elementos(Obtener(registro, "Comprobantes")),
                ("Comprobante", x => Obtener(x, "Comprobante")), ("Fecha", x => Obtener(x, "Fecha")), ("Importe Imputado", x => Obtener(x, "ImportePago")));
            doc.Titulo("Retenciones");
            doc.Tabla<object>(Elementos(Obtener(registro, "Impuestos")),
                ("Impuesto", x => Obtener(x, "Impuesto")), ("Alícuota", x => Obtener(x, "Alicuota")),
                ("Base Imponible", x => Obtener(x, "BaseImponible")), ("Importe", x => Obtener(x, "Importe")));
            doc.Totales(("Pendiente Imputar", Obtener(registro, "ImporteSinAplicar")));
        }

        private static void RenderVale(HtmlDocumento doc, object dato)
        {
            doc.Encabezado(Texto(Obtener(dato, "Empresa")), new[] { Texto(Obtener(dato, "Localidad")) }, "VALE Nº " + Texto(Obtener(dato, "Nro")), null,
                new[] { ("Fecha", (object)Obtener(dato, "Fecha")), ("Caja", Obtener(dato, "Caja")) });
            doc.Datos(("Legajo", Obtener(dato, "Legajo")), ("Nombre", Obtener(dato, "Nombre")), ("Concepto", Obtener(dato, "Concepto")), ("Especie", Obtener(dato, "Especie")),
                ("Tipo de documento", Obtener(dato, "TipoDoc")), ("Nº documento", Obtener(dato, "NroDoc")), ("Localidad", Obtener(dato, "Localidad")));
            doc.Totales(("Importe", Obtener(dato, "Importe")));
            doc.Firma("Aclaración", "Firma");
        }

        private static object Obtener(object objeto, string nombre)
        {
            if (objeto == null) return null;
            var propiedad = objeto.GetType().GetProperty(nombre, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            return propiedad == null ? null : propiedad.GetValue(objeto, null);
        }

        private static string Texto(object valor) => valor == null ? "" : Convert.ToString(valor, CultureInfo.GetCultureInfo("es-AR"));

        private static IEnumerable<object> Elementos(object valor)
        {
            var enumerable = valor as IEnumerable;
            return enumerable == null ? Enumerable.Empty<object>() : enumerable.Cast<object>().Where(x => x != null);
        }
    }
}


