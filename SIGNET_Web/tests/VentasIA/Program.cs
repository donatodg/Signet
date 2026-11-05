using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;
using VENET_IA_BL;

internal static class Program
{
    private static int Main()
    {
        try
        {
            Validacion();
            Resolucion();
            Calculos();
            DesvincularDetalle();
            Herramientas().GetAwaiter().GetResult();
            Console.WriteLine("OK: cantidades, ambiguedades, referencias, precios/IVA, impuestos y rechazo de herramientas invalidas.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }

    private static AsistenteIAVentaSolicitud Solicitud(decimal cantidad = 2)
    {
        return new AsistenteIAVentaSolicitud
        {
            Cliente = "Cliente de prueba",
            Productos = new List<AsistenteIAVentaItem> { new AsistenteIAVentaItem { Producto = "P1", Cantidad = cantidad } }
        };
    }

    private static void Validacion()
    {
        foreach (var cantidad in new[] { -1m, 0m, 1000001m })
            Rechaza(() => new AsistenteIAVentas().Preparar(Solicitud(cantidad)), "cantidad");
        AsistenteIAVentas.ValidarSolicitud(Solicitud(0.5m));
        Rechaza(() => AsistenteIAVentas.ValidarSolicitud(null), "cliente");
        var vacia = Solicitud();
        vacia.Productos.Clear();
        Rechaza(() => AsistenteIAVentas.ValidarSolicitud(vacia), "renglones");
        var demasiados = Solicitud();
        demasiados.Productos = Enumerable.Range(0, 101).Select(i => new AsistenteIAVentaItem { Producto = "P1", Cantidad = 1 }).ToList();
        Rechaza(() => AsistenteIAVentas.ValidarSolicitud(demasiados), "renglones");
    }

    private static void Resolucion()
    {
        var opciones = new List<KeyNamePair>
        {
            new KeyNamePair { Key = 1, Name = "Lopez" },
            new KeyNamePair { Key = 2, Name = "Lopez" },
            new KeyNamePair { Key = 3, Name = "Lopez Hermanos" }
        };
        Rechaza(() => AsistenteIAVentas.Resolver(opciones, "Lopez", "cliente"), "ambiguedades");
        Rechaza(() => AsistenteIAVentas.Resolver(opciones, null, "cliente"), "ambiguedades");
        Rechaza(() => AsistenteIAVentas.Resolver(opciones, "Lopez [#999]", "cliente"), "ambiguedades");
        Igual(AsistenteIAVentas.Resolver(opciones, "Lopez [#2]", "cliente").Key, 2, "Referencia exacta");
        Igual(AsistenteIAVentas.Resolver(opciones, " lopez hermanos ", "cliente").Key, 3, "Nombre exacto");
        Igual(AsistenteIAVentas.Resolver(opciones.Take(1).ToList(), null, "sucursal").Key, 1, "Unica opcion");
    }

    private static void Calculos()
    {
        var linea = new ComprobantesVentasDetalle { Cantidad = 3, ImporteUnitario = 100, PorcDescuento = 10, AlicuotaIva = 21 };
        AsistenteIAVentas.CalcularLinea(linea);
        Igual(linea.ImporteIVA, 56.70m, "IVA con descuento");
        Igual(linea.Importe, 326.70m, "Total con descuento");
        var noGravada = new ComprobantesVentasDetalle { Cantidad = 2, ImporteUnitario = 10, AlicuotaIva = 0 };
        AsistenteIAVentas.CalcularLinea(noGravada);
        Igual(noGravada.Importe, 20m, "Producto sin IVA");
        var venta = new ComprobantesVentas
        {
            Detalle = new List<ComprobantesVentasDetalle> { linea, noGravada },
            Impuestos = new List<ComprobantesVentasImpuestos>
            {
                new ComprobantesVentasImpuestos { AplicaSobre = Enums.AplicaSobre.Bruto, Alicuota = 3 },
                new ComprobantesVentasImpuestos { AplicaSobre = Enums.AplicaSobre.Neto, Alicuota = 2 }
            }
        };
        typeof(AsistenteIAVentas).GetMethod("CalcularImpuestos", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new object[] { venta });
        Igual(venta.Impuestos.First().Importe, 8.10m, "Impuesto bruto");
        Igual(venta.Impuestos.Last().Importe, 5.96m, "Impuesto neto");
        var json = JsonConvert.SerializeObject(new AsistenteIAVentaBorrador { Comprobante = venta, Total = 360.76m });
        if (json.Contains("\"Comprobante\":")) throw new Exception("El chat no debe serializar la entidad interna.");
    }

    private static async Task Herramientas()
    {
        var manager = new AsistenteIAManager(new AsistenteIAConfiguracion());
        var metodo = typeof(AsistenteIAManager).GetMethod("HerramientaAsync", BindingFlags.Instance | BindingFlags.NonPublic);
        var respuesta = new AsistenteIARespuesta { Venta = new AsistenteIAVentaBorrador() };
        var salida = await (Task<string>)metodo.Invoke(manager, new object[] { "preparar_venta", "{", respuesta, CancellationToken.None });
        if (!salida.Contains("Error") || respuesta.Venta != null) throw new Exception("JSON invalido debe invalidar el borrador anterior.");
        salida = await (Task<string>)metodo.Invoke(manager, new object[] { "preparar_venta",
            "{\"cliente\":\"Prueba\",\"productos\":[{\"producto\":\"P1\",\"cantidad\":-1}]}", respuesta, CancellationToken.None });
        if (!salida.Contains("rechazada") || respuesta.Venta != null) throw new Exception("Cantidad invalida no debe preparar ni guardar.");
        salida = await (Task<string>)metodo.Invoke(manager, new object[] { "guardar_venta", "{}", respuesta, CancellationToken.None });
        if (!salida.Contains("desconocida")) throw new Exception("No debe existir una herramienta de guardado.");
    }

    private static void DesvincularDetalle()
    {
        var manager = (ComprobantesVentasDetalleManager)System.Runtime.Serialization.FormatterServices
            .GetUninitializedObject(typeof(ComprobantesVentasDetalleManager));
        var linea = new ComprobantesVentasDetalle { Visible_Cantidad_Stock = true };
        manager.Detalle = linea;
        var metodo = typeof(ComprobantesVentasDetalleManager).GetMethod("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
        linea.PropertyChanged += (System.ComponentModel.PropertyChangedEventHandler)metodo.CreateDelegate(
            typeof(System.ComponentModel.PropertyChangedEventHandler), manager);
        int avisos = 0;
        linea.PropertyChanged += (sender, e) => avisos++;
        manager.Dispose();
        linea.RaisePropertyChanged("Id_Producto");
        if (!linea.Visible_Cantidad_Stock || avisos != 1)
            throw new Exception("Un detalle precargado no debe conservar reglas de un manager ya cerrado ni perder otros suscriptores.");
    }

    private static void Rechaza(Action action, string mensaje)
    {
        try { action(); }
        catch (AsistenteIAException ex) when (ex.Codigo == 400 && ex.Message.Contains(mensaje)) { return; }
        throw new Exception("Se esperaba rechazo: " + mensaje);
    }

    private static void Igual<T>(T actual, T esperado, string caso)
    {
        if (!Equals(actual, esperado)) throw new Exception(caso + ": esperado " + esperado + ", obtenido " + actual);
    }
}
