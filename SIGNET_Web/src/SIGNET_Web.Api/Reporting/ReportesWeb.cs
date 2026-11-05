using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using SIGNET_Web.Api.Screens.Acciones;
using VENET_Common;

namespace SIGNET_Web.Api.Reporting
{
    public static class ReportesWeb
    {
        public static string Carpeta => Convert.ToString(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas));

        public static AccionResultado Documento(string plantilla, IEnumerable datos, string nombre, string[] leyendas = null) =>
            new AccionResultado { Pdf = ArchivoResultado.Pdf(nombre, RepxRenderer.Render(Carpeta, plantilla, datos, leyendas)) };

        public static string[] Copias(object valor)
        {
            if (!int.TryParse(Convert.ToString(valor), out var cantidad) || cantidad < 1 || cantidad > 100)
                throw new ValidationException("Configure entre 1 y 100 copias en el talonario.");
            return new string[cantidad];
        }

        public static string VarianteB(string plantilla, bool responsableInscripto)
        {
            if (RepxRenderer.Configurado(plantilla) && !responsableInscripto
                && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaReporte_B)))
                return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(plantilla) ?? "",
                    System.IO.Path.GetFileNameWithoutExtension(plantilla) + "B.repx");
            return plantilla;
        }
    }
}
