namespace VENET_Comun
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Enums
    {
        public static string GetDescription(Enum value)
        {
            string Description = value.ToString();

            try
            {
                Description = ((DescriptionAttribute)(value.GetType().GetField(Description).GetCustomAttributes(typeof(DescriptionAttribute), false)[0])).Description;
            }
            catch (Exception) { }

            return Description;
        }

        public static IList ToList(Type type)
        {
            ArrayList List = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                List.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }
            return List;
        }

        public enum Modulos
        {
            Trafico = 1,
            Tesoreria = 2,
            Comun = 3,
            General = 4,
            Personal = 5,
            Seguridad = 6,
            Informes = 7,
            ViajesEspeciales = 8,
            Gestion = 9,
            Sistema = 10,
            Logistica = 11,
            Activos = 12,
            Mantenimiento = 13,
            GPS = 14,
            Produccion = 15
        }

        public enum TipoEntidad
        {
            Cliente = 1,
            Proveedor = 2,
            [Description("Proveedor Financiero")]
            Proveedor_Financiero = 3,
            Personal = 4
        };

        public enum TipoEntidadTodos
        {
            Todos = 0,
            Cliente = 1,
            Proveedor = 2,
            [Description("Proveedor Financiero")]
            Proveedor_Financiero = 3,
            Personal = 4
        };

        //public enum TipoEntidadSinPF
        //{
        //    Cliente = 1,
        //    Proveedor = 2,
        //    Personal = 4
        //};

        public enum Accion
        {
            Ingresar = 1,
            Agregar = 2,
            Modificar = 3,
            Eliminar = 4,
            Buscar = 5,
            Imprimir = 6,
            Ver = 7,
            Operaciones = 8
        }

        public enum TipoComprobante
        {
            Ventas = 1,
            Recibos = 2,
            Vales = 3,
            Rendiciones = 4,
            [Description("Boletas de Depósito")]
            BoletasDeposito = 5,
            Transferencia = 6,
            [Description("Ordenes de Pago")]
            OrdenesPago = 7,
            Compras = 8,
            Descuento = 9,
            [Description("Listas de Pago")]
            ListaPago = 10,
            Libre = 11

        }

        public enum ComprobanteArea
        {
            Compras = 1,
            Ventas = 2,
            //[Description("Compras-Venta")]
            //Compras_Ventas = 3,
            Libre = 4

        }

        public enum TipoMovimiento
        {
            [Description("Ingreso")]
            Debito = 1,
            [Description("Egreso")]
            Credito = 2
        }

        public enum TipoMovimientoDebitoCredito
        {
            [Description("Débito")]
            Debito = 1,
            [Description("Crédito")]
            Credito = 2,
            [Description("Crédito/Débito")]
            CreditoDebito = 3,
            [Description("Débito/Crédito")]
            DebitoCredito = 4
        }

        public enum TipoTitularidad
        {
            Titular = 1,
            Suplente = 2
        }

        public enum Meses
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12
        }

        public enum DiasSemana
        {
            Domingo = 1,
            Lunes = 2,
            Martes = 3,
            Miercoles = 4,
            Jueves = 5,
            Viernes = 6,
            Sabado = 7
        }

        public enum TipoDato
        {
            Bit = 1,
            Decimal = 2,
            Entero = 3,
            Fecha = 4,
            Texto = 5,
            Combo = 6,
            Password = 7
        }

        public enum ContenidoBrowser
        {
            Contenido = 1,
            DireccionURL = 2
        }

        public enum Turno
        {
            //[Description("No Rota")]
            //No_Rota = 0,
            Mañana = 1,
            Tarde = 2,
            Noche = 3,
            [Description("Mañana Tarde")]
            Mañana_Tarde = 4,
            [Description("Mañana Tarde Noche")]
            Mañana_Tarde_Noche = 5,
            [Description("Tarde Noche")]
            Tarde_Noche = 6
        }

        public enum TurnoMTN
        {
            Mañana = 1,
            [Description("Tarde Noche")]
            Tarde_Noche = 2
        }

        public enum ChequesEstados
        {
            Cartera = 0,
            Depositado = 1,
            Descuento = 2,
            Rechazado = 3,
            Todos = 4
        }

        public enum ValesEstados
        {
            [Description("Sin Rendir")]
            SinRendir = 0,
            Pendientes = 1,
            Rendidos = 2,
            Anulados = 3,
            Todos = 4
        }

        public enum OPEstados
        {
            Todos = 0,
            Confirmadas = 1,
            Pendientes = 2,
            Anuladas = 3
        }

        public enum ProductosFiltroBusquedas
        {
            [Description("Código")]
            Codigo = 1,
            [Description("Código Fábrica")]
            CodigoFabrica = 2,
            [Description("Código Barras")]
            CodigoBarras = 3
        }

        public enum HsKmUnd
        {
            Horas = 1,
            Kms = 2,
            Unidades = 3
        }

        public enum DatosEstados
        {
            Todos = 0,
            Confirmados = 1,
            Pendientes = 2,
            Anulados = 3
        }

        public enum FacturasEstados
        {
            Todas = 0,
            Confirmadas = 1,
            Pendientes = 2
        }

        public enum RetenesEstados
        {
            Todos = 0,
            Confirmados = 1,
            Pendientes = 2
        }

        public enum SiNo
        {
            SI = 1,
            NO = 2
        }

        public enum Regiones
        {
            [Description("REGION METRO")]
            METRO = 1,
            COL = 2,
            [Description("REGION BS. AS")]
            BUE = 3,
            [Description("REGION ESTE")]
            ESTE = 4,
            [Description("REGION CENTRO")]
            CENTRO = 5,
            [Description("REGION SUR")]
            SUR = 6,
            [Description("REGION OESTE")]
            OESTE = 7
        }

        public enum OfConcentradora
        {
            METRO = 1,
            COL = 2
        }

        public enum Grupos
        {
            ADICIONALES = 1,
            CIRCUITOS = 2,
            TRONCALES = 3
        }

        public enum Periodicidad
        {
            Mensual = 1,
            Quincenal = 2,
            Semanal = 3,
            Diario = 4
        }

        public enum TipoComp
        {
            Original,
            Fotocopia
        }

        public enum TipoDestinoRemito
        {
            Proveedor = 1,
            Deposito = 2
        };

        public enum TipoFrancoCompensatorio
        {
            Franco = 1,
            [Description("Doble Turno")]
            DobleTurno = 2
        };

        public enum TipoUnidades
        {
            Automovil = 1,
            Camioneta = 2,
            Camion = 3,
            Bus = 4,
            Maquinaria = 5,
            Moto = 6,
            Embarcacion = 7,
            Utilitario = 8
        }

        public enum TipoImpuesto
        {
            [Description("Retención")]
            Retencion = 1,
            [Description("Percepción")]
            Percepcion = 2
        }

        public enum AplicaSobre
        {
            Bruto = 1,
            Neto = 2
        }

        public enum PedidosEstados
        {
            Pendiente = 0,
            Produccion = 1,
            Entregado = 2,
            Anulado = 3,
            Todos = 4
        }
        public enum Tablas
        {
            EntidadesCtaCte = 1
        }
        public enum Colores
        {
            Ninguno = 1,
            Verde = 2,
            Amarillo = 3,
            Rojo = 4,
            Azul = 5
        };

        //********************************************************************
        // ASIENTOS
        //********************************************************************
        public enum TiposDeAsientos
        {
            Recibos = 1
        }

        //objeto.GetType().GetProperties().Name
        public enum ConceptosAsientos
        {
            [Description("Tipo de Comprobante")]
            TipoComprobante = 1,
            [Description("Letra de Comprobante")]
            LetraComprobante = 2,
            [Description("Nro. de Comprobante")]
            NroComprobante = 3,
            [Description("Concepto del Comprobante")]
            ConceptoComprobante = 4,
            [Description("Id del Comprobante")]
            IdComprobante = 5,
            [Description("Punto de Venta")]
            PtoVtaComprobante = 6,
            [Description("Tipo de Entidad")]
            TipoEntidad = 7,
            [Description("Nombre de Entidad")]
            NombreEntidad = 8,
            [Description("Id de la Entidad")]
            IdEntidad = 9
        }

        //********************************************************************

    }
}
