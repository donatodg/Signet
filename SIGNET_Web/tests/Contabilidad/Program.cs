using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using SIGNET_Web.Api.Controllers;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Screens;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using VENET_Common;
using VENET_Comun;
using VENET_Contabilidad_BL;
using VENET_DataEntity;

internal static class Program
{
    private static readonly HashSet<int> Cuentas = new HashSet<int> { 10, 20, 30, 40, 50, 60 };
    private static int Main(string[] args)
    {
        try
        {
            if (args.Length > 0 && args[0] == "--sql") return IntegracionSql.Ejecutar(args);
            Prioridades();
            MultiplesYDistribucion();
            Rechazos();
            PermisosYCatalogo();
            Transferencias();
            DocumentosComplementarios();
            AperturaYCierre();
            MenuPorPermisos();
            ContabilidadProductiva();
            Console.WriteLine("PASS: motor contable, permisos, transferencias historicas, documentos complementarios, apertura/cierre sin duplicar ni alterar saldos.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
        finally { SignetRequestContext.Current = null; }
    }
    private static T Copiar<T>(T value) => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
    private static void ContabilidadProductiva()
    {
        var politica = new OperativaContable
        {
            Empresa = 1,
            Moneda = 1,
            CapturarCosto = true,
            Politicas = new List<PoliticaContable> { new PoliticaContable { Operatoria = OperatoriaContable.Venta, Modo = ModoContable.Automatico, UsuarioAutomatico = 2 } }
        };
        ContabilidadService.ValidarOperativa(politica);
        var mala = Copiar(politica); mala.Politicas[0].UsuarioAutomatico = null;
        Rechaza(() => ContabilidadService.ValidarOperativa(mala), "Politicas");
        mala = Copiar(politica); mala.Politicas.Add(Copiar(mala.Politicas[0]));
        Rechaza(() => ContabilidadService.ValidarOperativa(mala), "Politicas");
        mala = Copiar(politica); mala.Politicas[0].Operatoria = OperatoriaContable.CostoVentaAutomatico; mala.CapturarCosto = false;
        Rechaza(() => ContabilidadService.ValidarOperativa(mala), "captura");
        Rechaza(() => ContabilidadService.ValidarSeparacion(2, 2), "otro usuario");
        Rechaza(() => ContabilidadService.ValidarSeparacion(null, 2), "otro usuario");
        ContabilidadService.ValidarSeparacion(1, 2);
        Igual(ContabilidadService.DemoraReintento(1).TotalSeconds, 30d, "Primer reintento");
        Igual(ContabilidadService.DemoraReintento(20).TotalSeconds, 3600d, "Reintento limitado");
        Rechaza(() => ContabilidadService.ValidarSeleccion(new List<RevisionLote> { new RevisionLote { Documento = 1, Operatoria = OperatoriaContable.Venta },
            new RevisionLote { Documento = 1, Operatoria = OperatoriaContable.Venta } }), "Seleccione");
        var costo = new CostoHistorico
        {
            Detalle = 1,
            Producto = 1,
            Categoria = 7,
            MonedaBase = 1,
            MonedaCosto = 2,
            Cantidad = 2,
            CantidadStock = 2,
            CostoUnitario = 3m,
            Cotizacion = 100m,
            CostoTotal = 600m
        };
        Igual(ContabilidadService.PartidasCostos(new[] { costo }, 1).Single().Costo, (decimal?)600m, "Usar costo historico local");
        var configCosto = Config();
        configCosto.Plantillas[0].Operatoria = OperatoriaContable.CostoVentaAutomatico;
        configCosto.Plantillas[0].TipoComprobante = null;
        Rechaza(() => MotorContable.ValidarConfiguracion(configCosto), "tipo de comprobante");
        configCosto.Plantillas[0].TipoComprobante = 2;
        configCosto.Plantillas[0].Reglas = new List<ReglaContable> { Fija(OrigenContable.Productos, MagnitudContable.Costo, LadoContable.Debe, 10),
            Fija(OrigenContable.Productos, MagnitudContable.Costo, LadoContable.Haber, 20) };
        var hechoCosto = Hecho(); hechoCosto.Operatoria = OperatoriaContable.CostoVentaAutomatico;
        hechoCosto.Partidas = ContabilidadService.PartidasCostos(new[] { costo }, 1);
        Igual(MotorContable.Simular(configCosto, hechoCosto, Cuentas).Asientos.Single().Debe, 600m, "Costo automatico usa snapshot");
        configCosto.Plantillas[0].Invertir = true;
        Igual(MotorContable.Simular(configCosto, hechoCosto, Cuentas).Asientos.Single().Renglones[0].Haber, 600m, "Nota de credito revierte costo con plantilla explicita");
        Rechaza(() => ContabilidadService.PartidasCostos(new[] { costo }, 2), "Costo historico incompleto");
        costo.CostoTotal = null;
        Rechaza(() => ContabilidadService.PartidasCostos(new[] { costo }, 1), "Costo historico incompleto");
        Igual(ContabilidadService.EstadoConciliacion(new ConciliacionDocumento { Anulado = true, Lote = 1 }), "Anulado contabilizado: requiere reversion", "Anulado posterior");
        Igual(ContabilidadService.EstadoConciliacion(new ConciliacionDocumento { Lote = 1, Gestion = 121, OrigenRegistrado = 121, DebeRegistrado = 242, HaberRegistrado = 242 }),
            "Conciliado por origen y balance", "N asientos no duplican diferencia");
        Igual(ContabilidadService.EstadoConciliacion(new ConciliacionDocumento { Lote = 1, Gestion = 0, DebeRegistrado = 100, HaberRegistrado = 100 }),
            "Importe local no disponible: no comparable", "No conciliar origen ausente como si fuera cero");
        var informe = new[] { new { Descripcion = "=HYPERLINK(\"bad\")", Importe = 123.45m, Fecha = new DateTime(2026, 5, 1) } };
        var pdf = VENET_Contabilidad_UI.InformeContable.Exportar("Prueba contable", informe, "pdf");
        Igual(System.Text.Encoding.ASCII.GetString(pdf, 0, 4), "%PDF", "Exportar PDF real");
        var xlsx = VENET_Contabilidad_UI.InformeContable.Exportar("Prueba contable", informe, "xlsx");
        using (var zip = new System.IO.Compression.ZipArchive(new System.IO.MemoryStream(xlsx)))
        {
            var hojas = zip.Entries.Where(e => e.FullName.StartsWith("xl/worksheets/") && e.FullName.EndsWith(".xml")).ToList();
            if (hojas.Count == 0) throw new Exception("XLSX sin hojas.");
            foreach (var entry in hojas)
                using (var reader = new System.IO.StreamReader(entry.Open()))
                    if (reader.ReadToEnd().Contains("<f")) throw new Exception("XLSX exporta formulas desde datos.");
            var textos = zip.GetEntry("xl/sharedStrings.xml");
            if (textos == null) throw new Exception("XLSX sin textos de informe.");
            using (var reader = new System.IO.StreamReader(textos.Open()))
                if (!reader.ReadToEnd().Contains("HYPERLINK")) throw new Exception("XLSX pierde descripcion del informe.");
        }
        Rechaza(() => VENET_Contabilidad_UI.InformeContable.Exportar("Prueba", informe, "csv"), "Formato admitido");
        Console.WriteLine("PASS productiva: politicas, separacion de roles, reintentos, seleccion, costos historicos, conciliacion N asientos y PDF/XLSX sin formulas.");
    }
    private static HechoContable Hecho() => new HechoContable
    {
        Empresa = 1,
        Documento = 8,
        Operatoria = OperatoriaContable.Venta,
        Fecha = new DateTime(2026, 11, 2),
        TipoComprobante = 2,
        Sucursal = 1,
        Total = 242,
        Neto = 200,
        Iva = 42,
        FormaPago = 1,
        Partidas = new List<PartidaOrigen> { new PartidaOrigen { Origen = OrigenContable.Productos,
            Referencia = "Producto 1", Producto = 1, Categoria = 7, Total = 242, Neto = 200, Iva = 42, Importe = 242, Costo = 100 } }
    };
    private static ReglaContable Fija(OrigenContable origen, MagnitudContable magnitud, LadoContable lado, int cuenta, decimal factor = 1) =>
        new ReglaContable { Origen = origen, Magnitud = magnitud, Lado = lado, CuentaFija = cuenta, Factor = factor };
    private static ConfiguracionContable Config() => new ConfiguracionContable
    {
        Empresa = 1,
        Version = 3,
        MonedaBase = 1,
        Plantillas = new List<PlantillaContable> { new PlantillaContable { Codigo = "VENTA", Nombre = "Venta", Operatoria = OperatoriaContable.Venta,
            Desde = new DateTime(2026, 1, 1), TipoComprobante = 2, Reglas = new List<ReglaContable>
            {
                Fija(OrigenContable.Cabecera, MagnitudContable.Total, LadoContable.Debe, 10),
                new ReglaContable { Origen = OrigenContable.Productos, Magnitud = MagnitudContable.Neto, Lado = LadoContable.Haber,
                    Rol = "Ventas", Prioridad = new List<DimensionCuenta> { DimensionCuenta.Producto, DimensionCuenta.Categoria, DimensionCuenta.Empresa } },
                Fija(OrigenContable.Productos, MagnitudContable.Iva, LadoContable.Haber, 30)
            } } },
        Asignaciones = new List<AsignacionCuenta> {
            new AsignacionCuenta { Rol = "Ventas", Dimension = DimensionCuenta.Empresa, Referencia = 1, Cuenta = 20 },
            new AsignacionCuenta { Rol = "Ventas", Dimension = DimensionCuenta.Categoria, Referencia = 7, Cuenta = 40 },
            new AsignacionCuenta { Rol = "Ventas", Dimension = DimensionCuenta.Producto, Referencia = 1, Cuenta = 50 }
        }
    };
    private static void Prioridades()
    {
        var config = Config(); var hecho = Hecho();
        var result = MotorContable.Simular(config, hecho, Cuentas);
        Igual(result.Asientos[0].Renglones[1].Cuenta, 50, "Producto debe prevalecer");
        Igual(result.Asientos[0].Debe, 242m, "Total con IVA");
        Igual(result.Firma, MotorContable.Simular(Copiar(config), Copiar(hecho), Cuentas).Firma, "Firma estable");
        config.Asignaciones.RemoveAt(2);
        Igual(MotorContable.Simular(config, hecho, Cuentas).Asientos[0].Renglones[1].Cuenta, 40, "Fallback categoria");
        config.Asignaciones.RemoveAt(1);
        Igual(MotorContable.Simular(config, hecho, Cuentas).Asientos[0].Renglones[1].Cuenta, 20, "Fallback empresa");
        config.Asignaciones.Clear();
        Rechaza(() => MotorContable.Simular(config, hecho, Cuentas), "Falta cuenta");
        config = Config(); config.Plantillas[0].Invertir = true;
        var inversa = MotorContable.Simular(config, hecho, Cuentas).Asientos.Single();
        Igual(inversa.Renglones[0].Haber, 242m, "Nota credito invierte lado");
        if (result.Firma == MotorContable.Simular(config, hecho, Cuentas).Firma) throw new Exception("La firma ignora cambio contable.");
        var tesoreria = Config();
        tesoreria.Plantillas[0].Reglas = new List<ReglaContable> {
            new ReglaContable { Origen = OrigenContable.Cabecera, Magnitud = MagnitudContable.Total, Lado = LadoContable.Debe,
                Rol = "Caja", Prioridad = new List<DimensionCuenta> { DimensionCuenta.FormaPago } },
            Fija(OrigenContable.Cabecera, MagnitudContable.Total, LadoContable.Haber, 20) };
        tesoreria.Asignaciones.Add(new AsignacionCuenta { Rol = "Caja", Dimension = DimensionCuenta.FormaPago, Referencia = 1, Cuenta = 60 });
        Igual(MotorContable.Simular(tesoreria, hecho, Cuentas).Asientos[0].Renglones[0].Cuenta, 60, "Cuenta por forma de pago");
    }
    private static void MultiplesYDistribucion()
    {
        var config = Config();
        var costo = new PlantillaContable
        {
            Codigo = "COSTO",
            Nombre = "Costo historico",
            Operatoria = OperatoriaContable.Venta,
            Desde = new DateTime(2026, 1, 1),
            TipoComprobante = 2,
            Reglas = new List<ReglaContable> {
                Fija(OrigenContable.Productos, MagnitudContable.Costo, LadoContable.Debe, 40),
                Fija(OrigenContable.Productos, MagnitudContable.Costo, LadoContable.Haber, 50) }
        };
        config.Plantillas.Add(costo);
        var result = MotorContable.Simular(config, Hecho(), Cuentas);
        Igual(result.Asientos.Count, 2, "Una venta genera N asientos");
        Igual(result.Asientos.Single(a => a.Plantilla == "COSTO").Debe, 100m, "Costo separado de precio venta");
        var h = Hecho(); h.Partidas[0].Costo = null;
        Rechaza(() => MotorContable.Simular(config, h, Cuentas), "costo historico");
        costo.Reglas = new List<ReglaContable> {
            Fija(OrigenContable.Cabecera, MagnitudContable.Neto, LadoContable.Debe, 10, 0.6m),
            Fija(OrigenContable.Cabecera, MagnitudContable.Neto, LadoContable.Debe, 20, 0.4m),
            Fija(OrigenContable.Cabecera, MagnitudContable.Neto, LadoContable.Haber, 30) };
        Igual(MotorContable.Simular(config, Hecho(), Cuentas).Asientos.Single(a => a.Plantilla == "COSTO").Renglones[0].Debe, 120m, "Distribucion 60/40");
        config.Plantillas[0].Hasta = new DateTime(2026, 10, 1);
        Igual(MotorContable.Simular(config, Hecho(), Cuentas).Asientos.Count, 1, "Vigencia excluye plantilla");
        costo.Sucursal = 2;
        Rechaza(() => MotorContable.Simular(config, Hecho(), Cuentas), "No hay plantillas");
    }
    private static void Rechazos()
    {
        var c = Config(); c.Plantillas[0].Reglas[0].Factor = 0.5m;
        Rechaza(() => MotorContable.Simular(c, Hecho(), Cuentas), "no balancea");
        c = Config(); c.Asignaciones.Add(Copiar(c.Asignaciones[0]));
        Rechaza(() => MotorContable.ValidarConfiguracion(c), "duplicadas");
        c = Config(); c.Plantillas[0].Reglas[1].Prioridad.Add(DimensionCuenta.Empresa);
        Rechaza(() => MotorContable.ValidarConfiguracion(c), "orden de resolucion");
        c = Config(); c.Plantillas[0].Reglas[0].CuentaFija = 99;
        Rechaza(() => MotorContable.Simular(c, Hecho(), Cuentas), "no existe");
        c = Config(); c.Empresa = 2;
        Rechaza(() => MotorContable.Simular(c, Hecho(), Cuentas), "Asignacion");
        c = Config(); c.Plantillas[0].TipoComprobante = null;
        Rechaza(() => MotorContable.ValidarConfiguracion(c), "tipo de comprobante");
        Rechaza(() => MotorContable.ValidarConfiguracion(null), "incompleta");
        c = Config(); c.Plantillas[0].Reglas[0].Magnitud = (MagnitudContable)999;
        Rechaza(() => MotorContable.ValidarConfiguracion(c), "invalida");
        c = Config(); var h = Hecho(); h.TipoComprobante = 999;
        Rechaza(() => MotorContable.Simular(c, h, Cuentas), "No hay plantillas");
        h = Hecho(); h.Empresa = 2;
        Rechaza(() => MotorContable.Simular(c, h, Cuentas), "esta empresa");
        c = Config(); c.Plantillas[0].Reglas[1].Producto = 999;
        Rechaza(() => MotorContable.Simular(c, Hecho(), Cuentas), "no balancea");
    }
    private static void PermisosYCatalogo()
    {
        var settings = new NameValueCollection { ["CurrentUserId"] = "23" };
        var sesion = new SignetSession("contabilidad-test", settings)
        {
            Seguridad = new SeguridadState
            {
                GrupoUsuario = new SeguridadGrupos { EsAdministrador = false },
                Objetos = new List<SeguridadObjetos>()
            }
        };
        SignetRequestContext.Current = new SignetRequestContext(sesion, settings);
        var api = new ContabilidadController();
        SinPermiso(() => api.Configuracion(1));
        SinPermiso(() => api.Guardar(Config()));
        SinPermiso(() => api.Simular(null));
        SinPermiso(() => api.Registrar(null));
        SinPermiso(() => api.Diario(1, DateTime.Today, DateTime.Today));
        SinPermiso(() => api.Bandeja(1, DateTime.Today, DateTime.Today));
        SinPermiso(() => api.Sincronizar(null));
        SinPermiso(() => api.RevisarBandeja(null));
        SinPermiso(() => api.RegistrarBandeja(null));
        SinPermiso(() => api.Aprobar(null));
        SinPermiso(() => api.Reintentar(1, null));
        SinPermiso(() => api.Operativa(1));
        SinPermiso(() => api.GuardarOperativa(null));
        SinPermiso(() => api.Procesar(null));
        SinPermiso(() => api.Costos(1, 1));
        SinPermiso(() => api.Periodos(1));
        SinPermiso(() => api.Clasificacion(1));
        SinPermiso(() => api.GuardarClasificacion(null));
        SinPermiso(() => api.Conciliacion(1, 1, DateTime.Today, DateTime.Today, "cajas"));
        SinPermiso(() => api.Exportar(1, 1, DateTime.Today, DateTime.Today, "cajas", "pdf"));
        SinPermiso(() => api.Auditoria(1));
        SinPermiso(() => api.UsuariosAutomaticos());
        SinPermiso(() => api.Revertir(null));
        SinPermiso(() => api.Referencias(1, DimensionCuenta.Producto));
        SinPermiso(() => api.Documentos(1, OperatoriaContable.Venta));
        SinPermiso(() => api.CrearDocumento(null));
        SinPermiso(() => api.PrepararEjercicio(null));
        SinPermiso(() => api.Saldos(1, 1, DateTime.Today, DateTime.Today));
        SinPermiso(() => api.Mayor(1, 1, 10, DateTime.Today, DateTime.Today));
        var catalogo = new ScreenCatalog(Options.Create(new SignetOptions()), NullLogger<ScreenCatalog>.Instance);
        foreach (var key in new[] { "PlanDeCuentas", "EjerciciosContables", "Asientos", "TipoAsientos", "TipoCategoriasContables" })
        {
            var screen = catalogo.Get(key);
            Igual(screen.Area, "Contabilidad", "Maestro en modulo contable");
            Igual(screen.ManagerType.Assembly.GetName().Name, "VENET_Contabilidad_BL", "BL sin duplicacion");
        }
    }
    private static void Transferencias()
    {
        var fecha = new DateTime(2026, 11, 2);
        var t = new Transferencias
        {
            Id = 8,
            Id_Caja_Origen = 1,
            Id_Caja_Destino = 2,
            Importe = 10,
            Cotizacion_Origen = 100,
            Cotizacion_Destino = 1,
            FechaAdd = fecha,
            Descripcion = "Transferencia prueba"
        };
        var origen = new Cajas { Id = 1, Id_Especie = 2, Id_Sucursal = 1 };
        var destino = new Cajas { Id = 2, Id_Especie = 1, Id_Sucursal = 2 };
        var m = new List<EspeciesCtaCte> {
                new EspeciesCtaCte { Id_Comprobante = 8, Id_TipoComprobante = (int)Enums.TipoComprobante.Transferencia, Id_Caja = 1, Credito = 10 },
                new EspeciesCtaCte { Id_Comprobante = 8, Id_TipoComprobante = (int)Enums.TipoComprobante.Transferencia, Id_Caja = 2, Debito = 1000 } };
        var h = OrigenGestion.Transferencia(t, origen, destino, 1, 1, m);
        Igual(h.Total, 1000m, "Cotizacion historica de transferencia");
        var c = Config(); c.Plantillas[0].Operatoria = OperatoriaContable.TransferenciaFondos; c.Plantillas[0].TipoComprobante = null;
        var entrada = Fija(OrigenContable.MediosPago, MagnitudContable.Total, LadoContable.Debe, 10); entrada.Caja = 2;
        var salida = Fija(OrigenContable.MediosPago, MagnitudContable.Total, LadoContable.Haber, 20); salida.Caja = 1;
        c.Plantillas[0].Reglas = new List<ReglaContable> { entrada, salida };
        Igual(MotorContable.Simular(c, h, Cuentas).Asientos[0].Debe, 1000m, "Transferencia entre cuentas/cajas");
        Rechaza(() => OrigenGestion.Transferencia(t, origen, destino, 1, 2, m), "interempresa");
        Rechaza(() => OrigenGestion.Transferencia(t, origen, destino, 1, 1, m.Take(1).ToList()), "movimientos");
        m[1].Debito = 999.99m;
        Rechaza(() => OrigenGestion.Transferencia(t, origen, destino, 1, 1, m), "diferencia");
        t.Cotizacion_Origen = 0;
        Rechaza(() => OrigenGestion.Transferencia(t, origen, destino, 1, 1, m), "invalida");
    }
    private static void DocumentosComplementarios()
    {
        var d = new DocumentoContable
        {
            Clave = Guid.NewGuid(),
            Moneda = 1,
            Respaldo = "Valuacion historica documentada",
            Hecho = new HechoContable
            {
                Empresa = 1,
                Sucursal = 1,
                Operatoria = OperatoriaContable.CostoVenta,
                Fecha = new DateTime(2026, 11, 2),
                Descripcion = "Costo factura #8",
                Partidas = new List<PartidaOrigen> {
                        new PartidaOrigen { Origen = OrigenContable.Productos, Producto = 1, Referencia = "Dos unidades, costo historico local", Importe = 100 } }
            }
        };
        ContabilidadService.ValidarDocumento(d);
        d.Respaldo = "";
        Rechaza(() => ContabilidadService.ValidarDocumento(d), "respaldo");
        d.Respaldo = "Liquidacion aprobada"; d.Hecho.Operatoria = OperatoriaContable.LiquidacionSueldos;
        d.Hecho.Partidas[0].Origen = OrigenContable.Conceptos;
        Rechaza(() => ContabilidadService.ValidarDocumento(d), "concepto");
        d.Hecho.Partidas[0].Concepto = 1; d.Hecho.Partidas[0].Producto = null;
        ContabilidadService.ValidarDocumento(d);
        var c = Config(); c.Plantillas[0].Operatoria = OperatoriaContable.LiquidacionSueldos; c.Plantillas[0].TipoComprobante = null;
        c.Plantillas[0].Reglas = new List<ReglaContable> {
                Fija(OrigenContable.Conceptos, MagnitudContable.Importe, LadoContable.Debe, 10),
                new ReglaContable { Origen = OrigenContable.Conceptos, Magnitud = MagnitudContable.Importe, Lado = LadoContable.Haber,
                    Rol = "Sueldos", Prioridad = new List<DimensionCuenta> { DimensionCuenta.Concepto } } };
        c.Asignaciones.Add(new AsignacionCuenta { Rol = "Sueldos", Dimension = DimensionCuenta.Concepto, Referencia = 1, Cuenta = 20 });
        d.Hecho.Documento = 8;
        Igual(MotorContable.Simular(c, d.Hecho, Cuentas).Asientos[0].Debe, 100m, "Cuenta segun concepto salarial");
        d.Hecho.Partidas[0].Importe = 1.001m;
        Rechaza(() => ContabilidadService.ValidarDocumento(d), "invalida");
        d.Hecho.Partidas[0].Importe = 100; d.Hecho.Operatoria = OperatoriaContable.Cierre;
        Rechaza(() => ContabilidadService.ValidarDocumento(d), "incompleto");
    }
    private static void AperturaYCierre()
    {
        var saldos = new[] { new SaldoCuenta { Cuenta = 10, Debe = 100 }, new SaldoCuenta { Cuenta = 20, Haber = 100 } };
        foreach (var op in new[] { OperatoriaContable.Cierre, OperatoriaContable.Apertura })
        {
            var h = ContabilidadService.DesdeSaldos(1, op, new DateTime(2026, 11, 2), 1, saldos); h.Documento = 8;
            var c = Config(); c.Plantillas[0].Operatoria = op; c.Plantillas[0].TipoComprobante = null;
            var deudor = op == OperatoriaContable.Cierre ? LadoContable.Haber : LadoContable.Debe;
            c.Plantillas[0].Reglas = new List<ReglaContable> {
                    new ReglaContable { Origen = OrigenContable.Saldos, Magnitud = MagnitudContable.SaldoDeudor, Lado = deudor,
                        Rol = "Saldo", Prioridad = new List<DimensionCuenta> { DimensionCuenta.CuentaOrigen } },
                    new ReglaContable { Origen = OrigenContable.Saldos, Magnitud = MagnitudContable.SaldoAcreedor,
                        Lado = deudor == LadoContable.Debe ? LadoContable.Haber : LadoContable.Debe,
                        Rol = "Saldo", Prioridad = new List<DimensionCuenta> { DimensionCuenta.CuentaOrigen } } };
            var sim = MotorContable.Simular(c, h, Cuentas);
            ContabilidadService.VerificarSaldos(sim);
            Igual(sim.Asientos[0].Renglones[0].Cuenta, 10, "No resuelve por cuenta actual alternativa");
            var copia = Copiar(sim); copia.Asientos.Add(Copiar(copia.Asientos[0]));
            Rechaza(() => ContabilidadService.VerificarSaldos(copia), "exactamente");
            copia = Copiar(sim); copia.Asientos[0].Renglones[0].Cuenta = 30;
            Rechaza(() => ContabilidadService.VerificarSaldos(copia), "exactamente");
        }
        Rechaza(() => ContabilidadService.DesdeSaldos(1, OperatoriaContable.Cierre, DateTime.Today, 1, saldos.Take(1)), "balanceados");
    }
    private static void MenuPorPermisos()
    {
        var settings = new NameValueCollection { ["CurrentUserId"] = "23" };
        var permisos = new SeguridadState
        {
            GrupoUsuario = new SeguridadGrupos { EsAdministrador = false },
            Objetos = new List<SeguridadObjetos>()
        };
        var sesion = new SignetSession("menu-test", settings) { Seguridad = permisos };
        SignetRequestContext.Current = new SignetRequestContext(sesion, settings);
        var opciones = Options.Create(new SignetOptions());
        var catalogo = new ScreenCatalog(opciones, NullLogger<ScreenCatalog>.Instance);
        var servicio = new ScreenService(catalogo, opciones);
        var cajas = catalogo.Get("Cajas");
        Igual(servicio.PantallasHabilitadas().Count, 0, "Ninguna pantalla sin permiso, incluidas personalizadas");
        permisos.Objetos.Add(new SeguridadObjetos { Id = 1, Modulo = cajas.Modulo, Formulario = cajas.Formulario, Permiso = "Buscar" });
        Igual(servicio.PantallasHabilitadas().Contains("Cajas"), false, "Buscar no habilita ingreso a Cajas");
        permisos.Objetos.Add(new SeguridadObjetos { Id = 2, Modulo = cajas.Modulo, Formulario = cajas.Formulario, Permiso = "Ingresar" });
        var menu = Newtonsoft.Json.Linq.JArray.FromObject(servicio.Menu());
        Igual(menu.SelectMany(a => a["pantallas"]).Select(p => (string)p["key"]).Single(), "Cajas", "Menu solo publica pantalla autorizada");
        Igual(servicio.PantallasHabilitadas().Contains("Cajas"), true, "Ingreso habilita Cajas");
        permisos.Objetos.RemoveAt(1);
        Igual(Newtonsoft.Json.Linq.JArray.FromObject(servicio.Menu()).Count, 0, "Area vacia oculta al retirar ingreso");
        var vendedores = new VendedoresController(null, null);
        Igual(Newtonsoft.Json.Linq.JObject.FromObject(vendedores.Estado())["ingresar"].ToObject<bool>(), false, "Portal oculto sin permisos");
        permisos.Objetos.Add(new SeguridadObjetos { Id = 3, Modulo = Enums.Modulos.Gestion, Formulario = "Productos", Permiso = "Ingresar" });
        var portal = Newtonsoft.Json.Linq.JObject.FromObject(vendedores.Estado());
        Igual(portal["ingresar"].ToObject<bool>(), true, "Portal considera Ingresar sin requerir Buscar");
        Igual(portal["precios"].ToObject<bool>(), false, "Mostrar menu no habilita acciones adicionales");
        permisos.GrupoUsuario.EsAdministrador = true;
        Igual(servicio.PantallasHabilitadas().Contains("Cajas"), true, "Administrador conserva acceso");
    }
    private static void Igual<T>(T actual, T esperado, string caso)
    { if (!EqualityComparer<T>.Default.Equals(actual, esperado)) throw new Exception(caso + ": " + actual + " != " + esperado); }
    private static void Rechaza(Action action, string texto)
    {
        try { action(); } catch (ValidationException e) { if (e.Message.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) return; throw; }
        throw new Exception("Se esperaba rechazo: " + texto);
    }
    private static void SinPermiso(Action action)
    {
        try { action(); } catch (ApiException e) { if (e.Status == 403) return; throw; }
        throw new Exception("Se esperaba permiso denegado.");
    }
}
