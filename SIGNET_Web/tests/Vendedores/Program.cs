using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Caching.Memory;
using SIGNET_Web.Api.Controllers;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Vendedores;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;

internal static class Program
{
    private static int Main()
    {
        try
        {
            Validaciones();
            Permisos();
            Console.WriteLine("OK: cantidades, opciones autorizadas, permisos de endpoints y tickets de revision sin acceso a BD.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
        finally { SignetRequestContext.Current = null; }
    }

    private static VentaMovil Venta(decimal cantidad = 2) => new VentaMovil
    {
        Cliente = 1, Productos = new List<LineaMovil> { new LineaMovil { Producto = 1, Cantidad = cantidad } }
    };

    private static void Validaciones()
    {
        PortalVentas.Validar(Venta(0.01m));
        PortalVentas.Validar(Venta(1000000m));
        foreach (var cantidad in new[] { -1m, 0m, 0.001m, 1000001m })
            Rechaza<ValidationException>(() => PortalVentas.Validar(Venta(cantidad)));
        Rechaza<ValidationException>(() => PortalVentas.Validar(null));
        Rechaza<ValidationException>(() => PortalVentas.Entidad(Enums.TipoEntidad.Cliente, 0));
        var venta = Venta();
        venta.Productos[0].CantidadStock = -1;
        Rechaza<ValidationException>(() => PortalVentas.Validar(venta));
        venta = Venta();
        venta.Observaciones = new string('x', 901);
        Rechaza<ValidationException>(() => PortalVentas.Validar(venta));
        var opciones = new List<KeyNamePair> { new KeyNamePair { Key = 3, Name = "Permitida" } };
        if (PortalVentas.Elegir(opciones, 0, "sucursal").Key != 3) throw new Exception("No selecciono la unica opcion.");
        Rechaza<ValidationException>(() => PortalVentas.Elegir(opciones, 99, "sucursal"));
        opciones.Add(new KeyNamePair { Key = 4, Name = "Otra" });
        Rechaza<ValidationException>(() => PortalVentas.Elegir(opciones, 0, "sucursal"));
    }

    private static void Contexto(bool desarrollo)
    {
        var settings = new NameValueCollection { ["CurrentUserId"] = "23" };
        var session = new SignetSession("sesion-prueba", settings)
        {
            Seguridad = new SeguridadState { Desarrollo = desarrollo, Objetos = new List<SeguridadObjetos>(),
                GrupoUsuario = new SeguridadGrupos { EsAdministrador = desarrollo } }
        };
        SignetRequestContext.Current = new SignetRequestContext(session, settings);
    }

    private static void Permisos()
    {
        Contexto(false);
        using (var cache = new MemoryCache(new MemoryCacheOptions()))
        {
            var service = new PortalVentas(cache);
            var controller = new VendedoresController(service, null);
            if (PortalVentas.Permiso("Productos", Enums.Modulos.Gestion, Enums.Accion.Ingresar))
                throw new Exception("Se otorgo un permiso inexistente.");
            Rechaza<ApiException>(() => controller.Productos("precios", 1, "abc"), 403);
            Rechaza<ApiException>(() => controller.Entidades("venta", "abc"), 403);
            Rechaza<ApiException>(() => controller.Cuenta(1, 1, DateTime.Today, DateTime.Today), 403);
            Rechaza<ApiException>(() => controller.Comprobante(1, 1, 1), 403);
            Rechaza<ApiException>(() => controller.Revisar(Venta()), 403);
            Rechaza<ApiException>(() => service.Guardar("inventado"), 403);
            Contexto(true);
            Rechaza<ValidationException>(() => controller.Productos("cuenta", 1, "abc"));
            Rechaza<ApiException>(() => service.Guardar("inventado"), 409);
            Rechaza<ApiException>(() => service.Guardar(null), 409);
            var tipoTicket = typeof(PortalVentas).GetNestedType("Ticket", System.Reflection.BindingFlags.NonPublic);
            var ticket = Activator.CreateInstance(tipoTicket, true);
            tipoTicket.GetField("Id").SetValue(ticket, "ya-guardado");
            var resultado = new { id = 12 };
            tipoTicket.GetField("Resultado").SetValue(ticket, resultado);
            cache.Set("vendedores:sesion-prueba", ticket);
            if (!ReferenceEquals(service.Guardar("ya-guardado"), resultado))
                throw new Exception("Un reintento debe devolver el resultado anterior, no guardar otra vez.");
            tipoTicket.GetField("Resultado").SetValue(ticket, null);
            tipoTicket.GetField("Intentado").SetValue(ticket, true);
            Rechaza<ApiException>(() => service.Guardar("ya-guardado"), 409);
            var settings = new NameValueCollection { ["CurrentUserId"] = "23" };
            var otra = new SignetSession("otra-sesion", settings) { Seguridad = SignetRequestContext.Current.Session.Seguridad };
            SignetRequestContext.Current = new SignetRequestContext(otra, settings);
            Rechaza<ApiException>(() => service.Guardar("ya-guardado"), 409);
        }
    }

    private static void Rechaza<T>(Action action, int? status = null) where T : Exception
    {
        try { action(); }
        catch (T ex)
        {
            if (status.HasValue && ((ApiException)(Exception)ex).Status != status)
                throw new Exception("Codigo HTTP incorrecto: " + ((ApiException)(Exception)ex).Status + ", esperado " + status);
            return;
        }
        throw new Exception("Se esperaba rechazo " + typeof(T).Name);
    }
}
