namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Comun;
    using VENET_DataEntity;

    public sealed class Parametro
    {
        private static volatile List<Parametros> instance = null;
        private static object syncRoot = new object();

        /// <summary>
        /// El constructor es privado
        /// se accede solo de la instancia
        /// </summary>
        private Parametro()
        {
            using (var db = new GeneralContext())
                instance = (from p in db.Parametros select p).ToList();
        }

        public static List<Parametros> Instance
        {
            get
            {
                if (instance == null)
                    lock (syncRoot)
                        if (instance == null)
                            new Parametro();

                return instance;
            }
        }

        private static string GetDescription(Enum value)
        {
            string Description = value.ToString();

            try
            {
                Description = ((System.ComponentModel.DescriptionAttribute)(value.GetType().GetField(Description).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0])).Description;
            }
            catch (Exception) { }

            return Description;
        }

        public static void Reload()
        {
            new Parametro();
        }

        public static string ObtenerValor(Param o)
        {
            if (instance == null) new Parametro();

            string n = GetDescription(o);
            string r = instance.Where(t => t.Nombre == n).Select(t => t.Valor).FirstOrDefault();

            if (string.IsNullOrEmpty(r))
            {
                using (var db = new GeneralContext())
                    r = db.Parametros.Where(t => t.Nombre == n).Select(t => t.Valor).FirstOrDefault();

                if (string.IsNullOrEmpty(r))
                {
                    GrabarParametro(n);
                    Reload();
                    r = instance.Where(t => t.Nombre == n).Select(t => t.Valor).FirstOrDefault();
                }
            }
            return r;
        }

        public enum Param
        {
            ImpresionPlanillaViaje_CantidadSeccionesApaisado = 1,
            ImpresionDiagramaVertical_Apaisado = 2,
            Personal_VerSolapaDetalleLaboral = 3,
            Usuarios_VerCentrosCostos = 4,
            Usuarios_VerCajas = 5,
            Usuarios_VerPuntosDeVentas = 6,
            Usuarios_VerUnidadesDeNegocios = 7,
            Usuarios_VerSucursales = 8,
            Talonarios_ModificarNroActual = 9,
            Planificacion_ModificarDiagramas = 10,
            Planificacion_DiaDeCorte = 11,
            Personal_VerMenuOperaciones = 12,
            ImpresionPlanillaViaje_TamañoHoja = 13,
            ImpresionPlanillaViaje_MargenSuperior = 14,
            ImpresionPlanillaViaje_MargenInferior = 15,
            ImpresionPlanillaViaje_MargenIzquierdo = 16,
            ImpresionPlanillaViaje_MargenDerecho = 17,
            Planificacion_CambioCoche_DiaCerrado = 18,
            DocumentoVersionesSistema = 19,
            MailSoporteSistemas = 20,
            RutaManualesSistema = 21,
            ComprobantesGestion_ModificarFechaCreacion = 22,
            GestionBusquedaProductosDefecto = 23,
            Usuarios_ClaveUnicaParaLosSistemas = 24,
            Sistema_MensajesAlIniciar = 25,
            Usuarios_VerDepositos = 26,
            AFIP_URL_WSAA = 27,
            AFIP_URL_WSFE = 28,
            SistemaEnMantenimiento = 29,
            MensajeAlIniciarSistema = 30,
            OrdenesDePago_UtilizaRetenciones = 31,
            RutaOriginalesComprobantesVentas = 32,
            RutaGeneracionComprobantesVentas = 33,
            Mail_CuentaDeEnvio = 34,
            Mail_NombrePersonaEnvio = 35,
            Mail_SmtpParaEnvioMail = 36,
            Mail_PuertoEnvioMail = 37,
            Mail_ContraseñaCuentaEnvioMail = 38,
            GestionModificaImporteProductosEnVenta = 39,
            GestionModificaIvaProductosEnVenta = 40,
            ImpresionPlanillaViaje_TamañoHojaPorLineas = 41,
            DefaultPendientesAProcesar_Id_Deposito = 42,
            DefaultPendientesAProcesar_Id_CentroCosto = 43,
            DefaultPendientesAProcesar_Id_FormaPago = 44,
            DefaultPendientesAProcesar_Id_Sucursal = 45,
            DefaultPendientesAProcesar_Id_TipoComprobante = 46,
            DefaultPendientesAProcesar_Id_Vendedor = 47,
            Chats = 48,
            Personal_VerImportacionSisorg = 49,
            Sistema_VisualizaIndicadores = 50,
            AFIP_WebService_Presentacion = 51,
            MovimientosInternosPermiteModificarAdministrador = 52,
            Entidades_UtilizaEntidadesPorEmpresas = 53,
            ImprimeComprobantesLiquidados = 54,
            ImprimeComprobantesDuplicadosPorHoja = 55,
            ComprobantesVentas_ImprimirRemito = 56,
            ComprobantesVentasRemito_ImprimirCopias = 57,
            Asientos_ModificarFechaCreacion = 58,
            Asientos_ModificarNumero = 59,
            Mail_EnviarconCopia = 60,
            Mail_TextoDelCuerpo = 61,
            ComprobantesVentas_UtilizaColor = 62,
            AFIP_UtilizaDocumentoCeroASinCuit = 63,
            Clientes_VerDescuentos = 64,
            ComprobantesCompra_PermiteEliminar = 65,
            ComprobantesVenta_ProductosConPrecio = 66,
            ComprobantesVenta_DescuentoPorClienteEnElectronico = 67,
            IdTipoServiciosConPersonalAuxiliar = 68,
            NombreRegedit = 69,
            UtilizaProductoCompuesto = 70,
            ComprobanteVentaCreaCAE = 71,
            ComprobantesCompra_ActualizaCostos = 72,
            Cotizaciones_GeneraPedido = 73,
            DiasAdicionalesFechaEntrega = 74,
            UtilizaReporte_B = 75,
            Mail_EnableSSL = 76,
            ComprobantesVentas_ConfirmaParcial = 77,
            ComprobantesVentas_AnchoPantalla = 78,
            ImprimeCotizacionesSinLiquidar = 79,
            Entidades_UtilizaEntidadesPorUN = 80,
            ComprobantesVenta_IdIvaAlicuotas = 81,
            ComprobantesVenta_ProductosExcluidos = 82,
            ComprobantesVentasPresentar_Actualizar = 83,
            UtilizaImagenes_Cotizaciones = 84,
            UtilizaImagenes_ComprobanteVentas = 85,
            UtilizaImagenes_Productos = 86,
            ComprobantesVentas_UtilizaDeposito = 87,
            ComprobantesCompras_UtilizaColorIds = 88,
            ComprobantesVentas_CambiaEspecie = 89,
            UtilizaDistintaUnidadStock = 90,
            UtilizaDistintaUnidadStockConDescripcion = 91,
            GrabaTodosLosParametros = 92,
            Ventas_Confirmar_GeneraArchivoDeudas = 93,
            Ventas_Confirmar_GeneraArchivoStock = 94,
            Ventas_Confirmar_RutaGeneraArchivoDeudas = 95,  
            Ventas_Confirmar_RutaGeneraArchivoStock = 96,
            Genera_Backup_Sistema = 97,
            Genera_Backup_Al_Salir_Sistema = 98,
            Ruta_Backup_Sistema = 99,
            Ventas_Confirmar_Genera_Recibo = 100,
            Ventas_Confirmar_Recibo_Generado = 101,
            Ventas_UtilizaSugerencias = 102,
            Ventas_NombreRemito= 103,
            Excel_ModeloProductosPrecios = 104,
            //******************************************************
            Menu_Tesoreria_CuentaCorrienteEspecies = 1000,
            Menu_Tesoreria_CuentaCorrienteEntidades = 1001,
            Menu_Tesoreria_Recibos = 1002,
            Menu_Tesoreria_OrdenesDePago = 1003,
            Menu_Tesoreria_Vales = 1004,
            Menu_Tesoreria_Rendiciones = 1005,
            Menu_Tesoreria_ListaDePagos = 1006,
            Menu_Tesoreria_ChequesDeTerceros = 1007,
            Menu_Tesoreria_BoletasDeDepositos = 1008,
            Menu_Tesoreria_DescuentoDeCheques = 1009,
            Menu_Tesoreria_ChequesPropios = 1010,
            Menu_Tesoreria_ComprobantesDeVentas = 1011,
            Menu_Tesoreria_ComprobantesDeCompras = 1012,
            Menu_Tesoreria_Control = 1013,
            Menu_Tesoreria_Cotizaciones = 1014,
            Menu_Entidades_Personal = 2000,
            Menu_Entidades_TiposDePersonal = 2001,
            Menu_Entidades_JerarquiasDePersonal = 2002,
            Menu_Entidades_Clientes = 2003,
            Menu_Entidades_Proveedores = 2004,
            Menu_Entidades_ProveedorFinanciero = 2005,
            Menu_Configuracion_Empresas = 3000,
            Menu_Configuracion_Sucursales = 3001,
            Menu_Configuracion_PuntosDeVentas = 3002,
            Menu_Configuracion_CentrosDeCostos = 3003,
            Menu_Configuracion_Localidades = 3004,
            Menu_Configuracion_Cajas = 3005,
            Menu_Configuracion_TiposDeComprobantes = 3006,
            Menu_Configuracion_Especies = 3007,
            Menu_Configuracion_Talonarios = 3008,
            Menu_Configuracion_EntidadesBancarias = 3009,
            Menu_Configuracion_Firmantes = 3010,
            Menu_Configuracion_FormasDePagos = 3011,
            Menu_Configuracion_TiposDeIva = 3012,
            Menu_Configuracion_AlicuotasDeIva = 3013,
            Menu_Configuracion_CategoriasDeProductos = 3014,
            Menu_Configuracion_UnidadDeVentaDeProductos = 3015,
            Menu_Configuracion_Productos = 3016,
            Menu_Configuracion_Vendedores = 3017,
            Menu_Configuracion_Depositos = 3018,
            Menu_Configuracion_Feriados = 3019,
            Menu_Configuracion_Parametros = 3020,
            Menu_Configuracion_Usuarios = 3021,
            Menu_Configuracion_GrupoDeUsuarios = 3022,
            Menu_Configuracion_CambioDeClave = 3023,
            Menu_Configuracion_Tema = 3024,
            Menu_Configuracion_TiposImpuestos = 3025,
            Menu_Configuracion_IIBB = 3026,
            Menu_Configuracion_UnidadNegocios = 3027,
            Menu_Configuracion_Categorias2DeProductos = 3028,
            Menu_Tesoreria_Pedidos = 3029,
            Menu_Configuracion_ProductosListasPrecios = 3030,
            //******************************************************

            //******************************************************
            // ACTIVOS
            //******************************************************
            Menu_General_Activos = 4000,
            Menu_Configuracion_Familias = 4001,
            Menu_Configuracion_Clases = 4002,
            Menu_Configuracion_Servicios = 4003,
            Menu_General_RepositorioServicios = 4004,

            //******************************************************

            //******************************************************
            // LOGISTICA
            //******************************************************
            Menu_General_Datos = 5000,
            Menu_General_Facturas = 5001,
            Menu_General_Retenes = 5002,
            Menu_General_Descuentos = 5003,
            Menu_General_Reclamos = 5004,
            Menu_General_Autorizaciones = 5005,
            Menu_General_Proveedores = 5006,
            Menu_General_UnidadesEventuales = 5007,
            Menu_Configuracion_Importacion = 5008,
            Menu_Configuracion_TipoComprobante = 5009,
            Menu_Configuracion_TipoIva = 5010,
            Menu_Configuracion_Alicuotas = 5011,
            Parametro_FechaDesde = 5012,
            Parametro_FechaHasta = 5013,
            Parametro_FechaMinimaApertura = 5014,
            Descuentos_ImporteMaximoDescontar = 5015,
            Menu_General_Archivos = 5016,
            Menu_General_PendientesFacturar = 5017,
            //******************************************************

            //******************************************************
            // GPS
            //******************************************************
            IntervaloMinutosSinReporteGps = 6000,
            IntervaloDeReporteDeAlarmas = 6001,
            IntervaloDeActulizarEquiposMapaGrilla = 6002,
            DistanciaMetrosFueraDeRuta = 6003,

            //******************************************************
            // Produccion
            //******************************************************
            Menu_Produccion_Produccion = 7001,
            Menu_Produccion_Lineas = 7002,
            Menu_Produccion_Variantes = 7003,
            Menu_Produccion_Tareas = 7004,
            Menu_Produccion_ListaPrecios = 7005,
            Menu_Produccion_Medidas = 7006,
            Menu_Produccion_ManoObra = 7007,
            Menu_Produccion_PProductos = 7008,
            Menu_Produccion_PProdDerivado = 7009,
            Produccion_ImprimeListaConDecimales = 7010,
            Produccion_ExcelEnA4 = 7011,
            ProduccionProductoComposicion = 7012,
            //******************************************************

            //******************************************************
            // ASISTENTE IA
            //******************************************************
            Menu_Sistema_AsistenteIA = 8000,
            IA_ApiKey = 8001,
            IA_Url = 8002,
            IA_Modelo = 8003,
            IA_LimiteTokensMes = 8004,
            IA_ConsumoTokensMes = 8005,
            IA_TablasExcluidas = 8006,
            IA_Contexto = 8007,
            IA_ConexionSoloLectura = 8008
            //******************************************************

        }

        private static void GrabarParametro(string o)
        {
            Parametros p = new Parametros();
            p.Nombre = o;
            switch (o)
            {
                case "ImpresionPlanillaViaje_CantidadSeccionesApaisado":
                    {
                        p.Valor = "12";
                        p.Descripcion = "Cantidad de secciones para imprimir apaisado.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "ImpresionDiagramaVertical_Apaisado":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime apaisado el informe vertical de diagrama.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "Personal_VerSolapaDetalleLaboral":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar la solapa de detalle laboral en personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "Usuarios_VerCentrosCostos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú ver centros de costos en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }

                case "Usuarios_VerCajas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú Ver cajas en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "Usuarios_VerPuntosDeVentas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú ver puntos de ventas en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "Usuarios_VerUnidadesDeNegocios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú ver unidades de negocios en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "Usuarios_VerSucursales":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú ver sucursales en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "Talonarios_ModificarNroActual":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar el número actual de formulario.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Planificacion_ModificarDiagramas":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar los diagramas asignados en planificaciones confirmadas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "Planificacion_DiaDeCorte":
                    {
                        p.Valor = "28";
                        p.Descripcion = "Día de corte por defecto al crear planificaciones.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "Personal_VerMenuOperaciones":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú operaciones en personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Personal;
                        break;
                    }
                case "ImpresionPlanillaViaje_TamañoHoja":
                    {
                        p.Valor = "A5";
                        p.Descripcion = "Tamaño de la hoja de ruta de viaje.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "ImpresionPlanillaViaje_MargenSuperior":
                    {
                        p.Valor = "20";
                        p.Descripcion = "Margen Superior de la hoja de ruta de viaje.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "ImpresionPlanillaViaje_MargenInferior":
                    {
                        p.Valor = "16";
                        p.Descripcion = "Margen Inferior de la hoja de ruta de viaje.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "ImpresionPlanillaViaje_MargenIzquierdo":
                    {
                        p.Valor = "30";
                        p.Descripcion = "Margen Izquierdo de la hoja de ruta de viaje.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "ImpresionPlanillaViaje_MargenDerecho":
                    {
                        p.Valor = "30";
                        p.Descripcion = "Margen Derecho de la hoja de ruta de viaje.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "Planificacion_CambioCoche_DiaCerrado":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar el coche en la planificación con días cerrados.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "DocumentoVersionesSistema":
                    {
                        p.Valor = "http://181.14.247.42:1111/Versiones.html";
                        p.Descripcion = "Ruta del documento de versionado del sistema.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.General;
                        break;
                    }
                case "MailSoporteSistemas":
                    {
                        p.Valor = "sigayuda@grupoersa.com";
                        p.Descripcion = "Mail de soporte del sistema.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.General;
                        break;
                    }
                case "RutaManualesSistema":
                    {
                        p.Valor = "c:\\Manuales\\Manual.docx";
                        p.Descripcion = "Ruta del documento del manual del sistema.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.General;
                        break;
                    }
                case "ComprobantesGestion_ModificarFechaCreacion":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar la fecha al crear los comprobantes de gestión.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "GestionBusquedaProductosDefecto":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Permite definir el código de búsqueda de los productos." + Environment.NewLine + "1-Código | 2-Código Fábrica | 3-Código Barras";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Usuarios_ClaveUnicaParaLosSistemas":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite utilizar clave unica para todos los sistemas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "Sistema_MensajesAlIniciar":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Informa Mensajes al Iniciar el Sistema.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Usuarios_VerDepositos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite visualizar el menú ver depósitos en usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Seguridad;
                        break;
                    }
                case "AFIP_URL_WSAA":
                    {
                        p.Valor = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl";
                        p.Descripcion = "Url del Servicio de WSAA Ticket de AFIP.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "AFIP_URL_WSFE":
                    {
                        p.Valor = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL";
                        p.Descripcion = "Url del Servicio de Facturación Electrónica de AFIP.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "SistemaEnMantenimiento":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Impide el ingreso al sistema, y muestra el mensaje del parametro MensajeAlIniciarSistema.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "MensajeAlIniciarSistema":
                    {
                        p.Valor = "El sistema se encuentra en mantenimiento, por favor comunicarse con sistemas para obtener más detalles.";
                        p.Descripcion = "Mensaje que se muestra al iniciar el sistema si el Parametro SistemaEnMantenimiento está activo.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "OrdenesDePago_UtilizaRetenciones":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza impresión de Ordenes de Pagos con Retenciones.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "RutaOriginalesComprobantesVentas":
                    {
                        p.Valor = "C:\\Reportes\\";
                        p.Descripcion = "Ruta de orginales de Comprobantes de Ventas.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "RutaGeneracionComprobantesVentas":
                    {
                        p.Valor = "C:\\Comprobantes\\";
                        p.Descripcion = "Ruta donde se generarán los Comprobantes de Ventas.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_CuentaDeEnvio":
                    {
                        p.Valor = "someone@someone.com";
                        p.Descripcion = "Dirección de correo electrónico para enviar mails.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_NombrePersonaEnvio":
                    {
                        p.Valor = "Someone";
                        p.Descripcion = "Nombre de la persona que envia los mails.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_SmtpParaEnvioMail":
                    {
                        p.Valor = "smtp.gmail.com";
                        p.Descripcion = "SMTP para enviar los mails.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_PuertoEnvioMail":
                    {
                        p.Valor = "25";
                        p.Descripcion = "Valor por defecto del puerto para enviar los mails.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_ContraseñaCuentaEnvioMail":
                    {
                        p.Valor = "********";
                        p.Descripcion = "Clave de la cuenta de envío de mails.";
                        p.TipoDato = Enums.TipoDato.Password;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "GestionModificaImporteProductosEnVenta":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar el importe del producto en ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "GestionModificaIvaProductosEnVenta":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar el iva del producto en ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ImpresionPlanillaViaje_TamañoHojaPorLineas":
                    {
                        p.Valor = "12,14,2,20,3,4,7,8,9";
                        p.Descripcion = "Líneas que imnprimen en Legal la planilla de viaje.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }

                case "DefaultPendientesAProcesar_Id_Deposito":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Depósitos en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "DefaultPendientesAProcesar_Id_CentroCosto":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Centro de Costo en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "DefaultPendientesAProcesar_Id_FormaPago":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Forma de Pago en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "DefaultPendientesAProcesar_Id_Sucursal":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Sucursal en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "DefaultPendientesAProcesar_Id_TipoComprobante":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Tipo de Comprobante en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "DefaultPendientesAProcesar_Id_Vendedor":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Importe Default para Vendedor en Comprobantes Pendientes a Procesar.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Tesoreria;
                        break;
                    }
                case "Chats":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Habilita al sistema a utilizar el chat interno.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Personal_VerImportacionSisorg":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite visualizar el menú importar a Sisorg en personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Personal;
                        break;
                    }

                case "Sistema_VisualizaIndicadores":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Visualiza los Indicadores en el Sistema.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "AFIP_WebService_Presentacion":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Define el WebService a utilizar en presentaciones electrónicas." + Environment.NewLine + "1-WSFEV1 | 2-WSMTXCA";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "MovimientosInternosPermiteModificarAdministrador":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Permite al administrador modificar movimientos en cta cte anteriores a la fecha.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Entidades_UtilizaEntidadesPorEmpresas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza las entidades con la asociación de Empresas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ImprimeComprobantesLiquidados":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime solamente comprobantes liquidados.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ImprimeComprobantesDuplicadosPorHoja":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime comprobantes duplicado en un hoja.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentas_ImprimirRemito":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Menú de Imprime Remito en Comprobantes de Ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentasRemito_ImprimirCopias":
                    {
                        p.Valor = "1";
                        p.Descripcion = "Cantidad de Copias de Remitos a Imprimir.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Asientos_ModificarFechaCreacion":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar la fecha de creación de asientos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Asientos_ModificarNumero":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite modificar el número de asientos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Mail_EnviarconCopia":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Envia el mail con copia a la cuenta configurada.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Mail_TextoDelCuerpo":
                    {
                        p.Valor = "Este es un mail automático enviado por la aplicación.";
                        p.Descripcion = "Texto del cuerpo del Mail.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "ComprobantesVentas_UtilizaColor":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza color en comprobantes de ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "AFIP_UtilizaDocumentoCeroASinCuit":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza documento 0 en facturas con clientes sin cuit.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }

                case "Clientes_VerDescuentos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Visualizar solapa descuentos en clientes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesCompra_PermiteEliminar":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite eliminar comprobantes confirmados y sus movimientos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVenta_ProductosConPrecio":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Visualiza solamente los productos con precio mayor a 0.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVenta_DescuentoPorClienteEnElectronico":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza Porcentaje Personalizado por Cliente en Comprobantes Electrónicos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "IdTipoServiciosConPersonalAuxiliar":
                    {
                        p.Valor = "359,361,363,365,367";
                        p.Descripcion = "Listado de Id_TipoServicios que utilizan Chofer/Auxiliar.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Trafico;
                        break;
                    }
                case "NombreRegedit":
                    {
                        p.Valor = "ERSA";
                        p.Descripcion = "Ruta de la cadena del registro HKEY_CURRENT_USER\\Software\\";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "UtilizaProductoCompuesto":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza Producto Compuesto en Comprobante de Ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobanteVentaCreaCAE":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Crea CAE en Comprobante de Ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesCompra_ActualizaCostos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Actualiza costo de productos al confirmar Comprobantes de Compra.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Cotizaciones_GeneraPedido":
                    {
                        p.Valor = "False";
                        p.Descripcion = "En menú operaciones genera solamente Pedidos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "DiasAdicionalesFechaEntrega":
                    {
                        p.Valor = "14";
                        p.Descripcion = "Días adicionales que agrega a la Fecha de Entrega.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaReporte_B":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza reporte B para entidades distintas de Responsable Inscripto.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Mail_EnableSSL":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza SSL para enviar mails.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "ComprobantesVentas_ConfirmaParcial":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza confirmación parcial en comprobantes de ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentas_AnchoPantalla":
                    {
                        p.Valor = "424";
                        p.Descripcion = "Ancho pantalla detalle de comprobantes de ventas (Mínimo 424 - Máximo 1024).";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ImprimeCotizacionesSinLiquidar":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite imprimir solo las cotizaciones sin liquidar.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Entidades_UtilizaEntidadesPorUN":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza las entidades con la asociación de UN.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVenta_IdIvaAlicuotas":
                    {
                        p.Valor = "5";
                        p.Descripcion = "Id de IvaAlicuotas para comprobantes de ventas.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVenta_ProductosExcluidos":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza lista de productos excluidos por usuario.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentasPresentar_Actualizar":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Actualiza de Afip comprabantes con error.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaImagenes_Cotizaciones":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza Imagenes en Cotizaciones.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaImagenes_ComprobanteVentas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza Imagenes en Comprobantes de Venta.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaImagenes_Productos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza Imagenes en Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentas_UtilizaDeposito":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Utiliza centro costo en comprobantes de ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesCompras_UtilizaColorIds":
                    {
                        p.Valor = "101,102,103";
                        p.Descripcion = "Ids de Tipo Comprobante de venta.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "ComprobantesVentas_CambiaEspecie":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Permite cambiar la especie en comprobantes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaDistintaUnidadStock":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime la cantidad de la unidad de stock en impresión.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "UtilizaDistintaUnidadStockConDescripcion":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime la cantidad y descripcion de la unidad de stock en impresión.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "GrabaTodosLosParametros":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Graba todos los parámetros del sistema.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ventas_Confirmar_GeneraArchivoStock":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Graba el archivo de stock al confirmar.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Ventas_Confirmar_GeneraArchivoDeudas":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Graba el archivo de deudas al confirmar.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Ventas_Confirmar_RutaGeneraArchivoDeudas":
                    {
                        p.Valor = "C:\\Sistema Ozono\\";
                        p.Descripcion = "Ruta donde se genera el archivo de deuda.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Ventas_Confirmar_RutaGeneraArchivoStock":
                    {
                        p.Valor = "C:\\Sistema Ozono\\";
                        p.Descripcion = "Ruta donde se genera el archivo de stock.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Gestion;
                        break;
                    }
                case "Genera_Backup_Sistema":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Genera el backup del sistmea.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Genera_Backup_Al_Salir_Sistema":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Genera el backup al salir del sistmea.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ruta_Backup_Sistema":
                    {
                        p.Valor = "C:\\Sistema Ozono\\Backup\\backup.bat";
                        p.Descripcion = "Ruta donde se encuentra el backup.bat.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ventas_Confirmar_Genera_Recibo":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Genera el recibo de la venta confirmada. Solo Forma pago Contado.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ventas_Confirmar_Recibo_Generado":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Confirma el recibo generado automaticamente desde ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ventas_UtilizaSugerencias":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Utiliza sugerencias en comprobantes ventas..";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Ventas_NombreRemito":
                    {
                        p.Valor = "Remito.repx";
                        p.Descripcion = "Nombre del reporte de Remito.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Excel_ModeloProductosPrecios":
                    p.Valor = "1";
                    p.Descripcion = "Ordenar Excel por: 1-Id | 2-Codigo | 3-Descripcion | 4-Categoría";
                    p.TipoDato = Enums.TipoDato.Entero;
                    p.Modulo = Enums.Modulos.Gestion;
                    break;
                //************************************************************************************
                case "Menu_Tesoreria_CuentaCorrienteEspecies":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Cuenta Corriente Especies.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_CuentaCorrienteEntidades":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Cuenta Corriente Entidades.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Recibos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Recibos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_OrdenesDePago":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Ordenes De Pago.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Vales":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Vales.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Rendiciones":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Rendiciones.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_ListaDePagos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Lista De Pagos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Cotizaciones":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Cotizaciones.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }

                case "Menu_Tesoreria_ChequesDeTerceros":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Cheques De Terceros.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_BoletasDeDepositos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Boletas De Depósitos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_DescuentoDeCheques":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Descuento De Cheques.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_ChequesPropios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Cheques Propios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_ComprobantesDeVentas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Comprobantes De Ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_ComprobantesDeCompras":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Comprobantes De Compras.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Control":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Menú Tesorería Control de Gestión.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_Personal":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Entidades Personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_TiposDePersonal":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Entidades Tipos De Personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_JerarquiasDePersonal":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Entidades Jerarquías De Personal.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_Clientes":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menu Entidades Clientes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_Proveedores":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Entidades Proveedores.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Entidades_ProveedorFinanciero":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Entidades Proveedor Financiero.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Empresas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Empresas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Sucursales":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Sucursales.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_PuntosDeVentas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Puntos De Ventas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_CentrosDeCostos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Centros De Costos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Localidades":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Localidades.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Cajas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Cajas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_TiposDeComprobantes":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tipos De Comprobantes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Especies":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Especies.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Talonarios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Talonarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_EntidadesBancarias":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Entidades Bancarias.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Firmantes":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Firmantes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_FormasDePagos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Formas De Pagos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_TiposDeIva":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tipos De Iva.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_AlicuotasDeIva":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Alícuotas De Iva.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_CategoriasDeProductos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Categorías De Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_UnidadDeVentaDeProductos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Unidad De Venta De Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Productos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Vendedores":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Vendedores.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Depositos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Depósitos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Feriados":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Feriados.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Parametros":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Parametros.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Usuarios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_GrupoDeUsuarios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Grupo De Usuarios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_CambioDeClave":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Cambio De Clave.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Tema":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tema.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_TiposImpuestos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tipos de Impuestos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_IIBB":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración IIBB.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_UnidadNegocios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Unidades de Negocios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Categorias2DeProductos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Categorías 2 De Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Tesoreria_Pedidos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Tesorería Pedidos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_ProductosListasPrecios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Productos Listas de Precios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                //************************************************************************************

                //************************************************************************************
                // ACTIVOS
                //************************************************************************************
                case "Menu_General_Activos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Activos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Activos;
                        break;
                    }

                case "Menu_Configuracion_Familias":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Familias.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Activos;
                        break;
                    }
                case "Menu_Configuracion_Clases":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Clases.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Activos;
                        break;
                    }
                case "Menu_Configuracion_Servicios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Servicios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Activos;
                        break;
                    }
                case "Menu_General_RepositorioServicios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Repositorio Servicios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Activos;
                        break;
                    }

                //************************************************************************************
                // LOGISTICA
                //************************************************************************************
                case "Menu_General_Datos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Datos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Facturas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Facturas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Retenes":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Retenes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Descuentos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Descuentos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Reclamos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Reclamos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Autorizaciones":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Autorizaciones.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }

                case "Menu_General_Proveedores":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Proveedores.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_UnidadesEventuales":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Unidades Eventuales.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_Archivos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Archivos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_General_PendientesFacturar":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú General Pendientes Facturar.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Importacion":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Importación.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_TipoComprobante":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tipo de Comprobante.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_TipoIva":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Tipo de Iva.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Configuracion_Alicuotas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Alícuotas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Parametro_FechaDesde":
                    {
                        p.Valor = "01/01/2001";
                        p.Descripcion = "Fecha desde definida para búsquedas.";
                        p.TipoDato = Enums.TipoDato.Fecha;
                        p.Modulo = Enums.Modulos.Logistica;
                        break;
                    }
                case "Parametro_FechaHasta":
                    {
                        p.Valor = "01/01/2001";
                        p.Descripcion = "Fecha hasta definida para búsquedas.";
                        p.TipoDato = Enums.TipoDato.Fecha;
                        p.Modulo = Enums.Modulos.Logistica;
                        break;
                    }
                case "Parametro_FechaMinimaApertura":
                    {
                        p.Valor = "01/01/2001";
                        p.Descripcion = "Fecha mínima definida para cambiar el estado del control.";
                        p.TipoDato = Enums.TipoDato.Fecha;
                        p.Modulo = Enums.Modulos.Logistica;
                        break;
                    }
                case "Descuentos_ImporteMaximoDescontar":
                    {
                        p.Valor = "100";
                        p.Descripcion = "Importe máximo que se permite para declarar un descuento sin descontar.";
                        p.TipoDato = Enums.TipoDato.Decimal;
                        p.Modulo = Enums.Modulos.Logistica;
                        break;
                    }

                //************************************************************************************
                // GPS
                //************************************************************************************
                case "IntervaloMinutosSinReporteGps":
                    {
                        p.Valor = "30";
                        p.Descripcion = "Intervalo de tiempo para cambio de color Vehículos sin GPS.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.GPS;
                        break;
                    }
                case "IntervaloDeReporteDeAlarmas":
                    {
                        p.Valor = "20";
                        p.Descripcion = "Intervalo de tiempo para reporte de Alarmas.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.GPS;
                        break;
                    }
                case "IntervaloDeActulizarEquiposMapaGrilla":
                    {
                        p.Valor = "10";
                        p.Descripcion = "Intervalo de tiempo para actualizar equipos en mapa y en grilla.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.GPS;
                        break;
                    }
                case "DistanciaMetrosFueraDeRuta":
                    {
                        p.Valor = "300";
                        p.Descripcion = "Distancia mínima para reportar vehículo fuera de ruta";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.GPS;
                        break;
                    }

                //************************************************************************************

                //************************************************************************************
                // Produccion
                //************************************************************************************
                case "Menu_Produccion_Produccion":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_Lineas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Líneas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_Variantes":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Variantes.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_Tareas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Tareas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_ListaPrecios":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Lista Precios.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_Medidas":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Medidas.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_ManoObra":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Producción Mano Obra.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }

                case "Menu_Produccion_PProductos":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Producción Productos.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Menu_Produccion_PProdDerivado":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Menú Configuración Producción Productos Derivados.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "Produccion_ImprimeListaConDecimales":
                    {
                        p.Valor = "False";
                        p.Descripcion = "Imprime la lista de precio con decimales.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Produccion;
                        break;
                    }
                case "Produccion_ExcelEnA4":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Imprime la lista de precio en Hoja A4.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Produccion;
                        break;
                    }
                case "ProduccionProductoComposicion":
                    {
                        p.Valor = "1";
                        p.Descripcion = "1=Linea-Medida-Variante, 2=LineaVarianteMedida.";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Produccion;
                        break;
                    }
                //************************************************************************************
                // ASISTENTE IA
                //************************************************************************************
                case "Menu_Sistema_AsistenteIA":
                    {
                        p.Valor = "True";
                        p.Descripcion = "Muestra el menú Asistente IA (consultas a la base de datos en lenguaje natural). El acceso se controla con el permiso Ingresar del formulario AsistenteIA.";
                        p.TipoDato = Enums.TipoDato.Bit;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_ApiKey":
                    {
                        p.Valor = "SinConfigurar";
                        p.Descripcion = "Clave de API del servicio de IA (Google Gemini: https://aistudio.google.com/apikey).";
                        p.TipoDato = Enums.TipoDato.Password;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_Url":
                    {
                        p.Valor = "https://generativelanguage.googleapis.com/v1beta/openai/";
                        p.Descripcion = "Url del servicio de IA compatible con OpenAI (Gemini, OpenAI, Azure, Groq, Ollama).";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_Modelo":
                    {
                        p.Valor = "gemini-2.5-flash";
                        p.Descripcion = "Modelo de IA a utilizar por el asistente.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_LimiteTokensMes":
                    {
                        p.Valor = "1000000";
                        p.Descripcion = "Tope de tokens por mes del asistente IA para toda la empresa (0 = sin tope).";
                        p.TipoDato = Enums.TipoDato.Entero;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_ConsumoTokensMes":
                    {
                        p.Valor = DateTime.Now.ToString("yyyy-MM") + "|0";
                        p.Descripcion = "Consumo de tokens del asistente IA en el mes (AAAA-MM|tokens). Lo actualiza el sistema; poner 0 para reiniciarlo.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_TablasExcluidas":
                    {
                        p.Valor = "-";
                        p.Descripcion = "Tablas que el asistente IA no puede consultar, separadas por ; (admite *, ej. Sueldos*;Personal). - = ninguna.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_Contexto":
                    {
                        p.Valor = "-";
                        p.Descripcion = "Aclaraciones del negocio que se le informan al asistente IA para mejorar sus respuestas. - = ninguna.";
                        p.TipoDato = Enums.TipoDato.Texto;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                case "IA_ConexionSoloLectura":
                    {
                        p.Valor = "-";
                        p.Descripcion = "Cadena de conexión con un usuario SQL de solo lectura (db_datareader) para las consultas del asistente IA. - = usa la conexión del sistema.";
                        p.TipoDato = Enums.TipoDato.Password;
                        p.Modulo = Enums.Modulos.Sistema;
                        break;
                    }
                    //************************************************************************************
            }

            using (var db = new GeneralContext())
            {
                db.Parametros.Attach(p);
                db.Entry(p).State = EntityState.Added;

                var err = db.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db.SaveChanges();
            }
        }

        public class P : Parametros { }
        public static List<P> ObtenerParamterosMenuPrincipalDeshabilitados()
        {
            using (var db = new GeneralContext())
            {
                return db.Parametros.Where(t => t.Modulo == Enums.Modulos.Sistema && t.Valor == "False").Select(t => new P
                {
                    Descripcion = t.Descripcion,
                    Modulo = t.Modulo,
                    Nombre = t.Nombre,
                    TipoDato = t.TipoDato,
                    Valor = t.Valor
                }).ToList();
            }
        }
    }
}
