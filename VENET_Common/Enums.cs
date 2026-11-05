using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VENET_Common
{
    public class Enums
    {
        public static string GetDescription(Enum value)
        {
            string Description = value.ToString();

            try
            {
                Description = ((System.ComponentModel.DescriptionAttribute)(value.GetType().GetField(Description).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0])).Description;
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

        public enum TipoEntidad
        {
            Cliente = 1,
            Proveedor = 2,
            [Description("Proveedor Financiero")]
            Proveedor_Financiero = 3,
            Personal = 4
        };

        public enum Accion
        {
            Ingreso = 1,
            Alta = 2,
            Baja = 3,
            Eliminar = 4
        }

        public enum TipoComprobante
        {
            Default = 1,
            Recibos = 2,
            Vales = 3,
            Rendiciones = 4,
            [Description("Boletas de Depósito")]
            BoletasDeposito = 5
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

        public enum TipoDato
        {
            Bit = 1,
            Decimal = 2,
            Entero = 3,
            Fecha = 4,
            Texto = 5
        }
    }
}
