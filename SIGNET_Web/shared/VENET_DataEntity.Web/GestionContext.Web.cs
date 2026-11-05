namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using VENET_DataEntity;

    public class GestionContext : DbContext, IDisposable
    {
        public GestionContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"])
        { Database.SetInitializer<GestionContext>(null); }

        public GestionContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public GestionContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<SeguridadUsuarios> SeguridadUsuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosPreciosHistorico> ProductosPreciosHistorico { get; set; }
        public DbSet<ProductosCategorias> ProductosCategorias { get; set; }
        public DbSet<ProductosCategorias2> ProductosCategorias2 { get; set; }
        public DbSet<ProductosUnidadVenta> ProductosUnidadVenta { get; set; }
        public DbSet<ProductosDepositos> ProductosDepositos { get; set; }
        public DbSet<IvaAlicuotas> IvaAlicuotas { get; set; }
        public DbSet<TipoComprobante> TipoComprobante { get; set; }
        public DbSet<Especies> Especies { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<EspeciesCtaCte> EspeciesCtaCte { get; set; }
        public DbSet<EntidadesCtaCte> EntidadesCtaCte { get; set; }
        public DbSet<EspeciesCotizaciones> EspeciesCotizaciones { get; set; }
        public DbSet<ComprobantesCompras> ComprobantesCompras { get; set; }
        public DbSet<ComprobantesComprasDetalle> ComprobantesComprasDetalle { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ClientesContactos> ClientesContactos { get; set; }
        public DbSet<ClientesDescuentos> ClientesDescuentos { get; set; }
        public DbSet<ClientesEntregas> ClientesEntregas { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<ProvFinancieros> ProvFinancieros { get; set; }
        public DbSet<ProvFinancierosCuentas> ProvFinancierosCuentas { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<ComprobantesVentas> ComprobantesVentas { get; set; }
        public DbSet<ComprobantesVentasDetalle> ComprobantesVentasDetalle { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<FormasPagos> FormasPagos { get; set; }
        public DbSet<TipoIva> TipoIva { get; set; }
        public DbSet<TipoCategoriasContables> TipoCategoriasContables { get; set; }
        public DbSet<TipoIva_Configuracion> TipoIva_Configuracion { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<Cajas> Cajas { get; set; }
        public DbSet<PuntosVentas> PuntosVentas { get; set; }
        public DbSet<TalonariosComprobantes> TalonariosComprobantes { get; set; }
        public DbSet<TalonariosComprobantesDetalle> TalonariosComprobantesDetalle { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<EntidadesEmpresas> EntidadesEmpresas { get; set; }
        public DbSet<TipoImpuestos> TipoImpuestos { get; set; }
        public DbSet<ImpuestosAlicuotas> ImpuestosAlicuotas { get; set; }
        public DbSet<EntidadesImpuestoAlicuotas> EntidadesImpuestosAlicuotas { get; set; }
        public DbSet<AFIP_Comprobantes> AFIP_Comprobantes { get; set; }
        public DbSet<ComprobantesVentasDetalleProcesados> ComprobantesVentasDetalleProcesados { get; set; }
        public DbSet<ComprobantesVentasAProcesar> ComprobantesVentasAProcesar { get; set; }
        public DbSet<EntidadesUnidadNegocios> EntidadesUnidadNegocios { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<CuentasContables> CuentasContables { get; set; }
        public DbSet<Cotizaciones> Cotizaciones { get; set; }
        public DbSet<CotizacionesDetalle> CotizacionesDetalle { get; set; }
        public DbSet<Asientos> Asientos { get; set; }
        public DbSet<AsientosDetalle> AsientosDetalle { get; set; }
        public DbSet<EjerciciosContables> EjerciciosContables { get; set; }
        public DbSet<TipoAsientos> TipoAsientos { get; set; }
        public DbSet<TipoAsientosDetalle> TipoAsientosDetalle { get; set; }
        public DbSet<ComprobantesVentasImpuestos> ComprobantesVentasImpuestos { get; set; }
        public DbSet<ProductosComposicion> ProductosComposicion { get; set; }
        public DbSet<AFIP_Tributos> AFIP_Tributos { get; set; }
        public DbSet<PadronIIBB> PadronIIBB { get; set; }
        public DbSet<PadronIIBB_Detalle> PadronIIBB_Detalle { get; set; }
        public DbSet<ProductosDerivados> ProductosDerivados { get; set; }
        public DbSet<ProductosCompuestos> ProductosCompuestos { get; set; }
        public DbSet<ProductosCompuestosDetalle> ProductosCompuestosDetalle { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PedidosDetalle> PedidosDetalle { get; set; }
        public DbSet<PedidosDetalleProcesados> PedidosDetalleProcesados { get; set; }
        public DbSet<ProductosUsuariosExcluidos> ProductosUsuariosExcluidos { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<ProductosListasPrecios> ProductosListasPrecios { get; set; }
        public DbSet<ProductosListasPreciosDetalle> ProductosListasPreciosDetalle { get; set; }
    }
}
