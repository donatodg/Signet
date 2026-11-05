namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;

    public class TesoreriaContext : DbContext, IDisposable
    {
        public TesoreriaContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"])
        { Database.SetInitializer<TesoreriaContext>(null); }

        public TesoreriaContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public TesoreriaContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<SeguridadUsuarios> SeguridadUsuarios { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<TipoComprobante> TipoComprobante { get; set; }
        public DbSet<Especies> Especies { get; set; }
        public DbSet<EspeciesCtaCte> EspeciesCtaCte { get; set; }
        public DbSet<EntidadesCtaCte> EntidadesCtaCte { get; set; }
        public DbSet<EspeciesCotizaciones> EspeciesCotizaciones { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<RecibosDetalle> RecibosDetalle { get; set; }
        public DbSet<RecibosComprobantes> RecibosComprobantes { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ClientesContactos> ClientesContactos { get; set; }
        public DbSet<ClientesDescuentos> ClientesDescuentos { get; set; }
        public DbSet<ClientesEntregas> ClientesEntregas { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<ProvFinancieros> ProvFinancieros { get; set; }
        public DbSet<ProvFinancierosCuentas> ProvFinancierosCuentas { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<TipoDoc> TipoDoc { get; set; }
        public DbSet<Vales> Vales { get; set; }
        public DbSet<Rendiciones> Rendiciones { get; set; }
        public DbSet<RendicionesDetalle> RendicionesDetalle { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<BoletasDepositos> BoletasDepositos { get; set; }
        public DbSet<BoletasDepositosDetalle> BoletasDepositosDetalle { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<Cajas> Cajas { get; set; }
        public DbSet<PuntosVentas> PuntosVentas { get; set; }
        public DbSet<TalonariosComprobantes> TalonariosComprobantes { get; set; }
        public DbSet<TalonariosComprobantesDetalle> TalonariosComprobantesDetalle { get; set; }
        public DbSet<Firmantes> Firmantes { get; set; }
        public DbSet<FirmantesCuentas> FirmantesCuentas { get; set; }
        public DbSet<ChequesTerceros> ChequesTerceros { get; set; }
        public DbSet<EntidadesBancarias> EntidadesBancarias { get; set; }
        public DbSet<ChequesDescuento> ChequesDescuento { get; set; }
        public DbSet<ChequesDescuentoDetalle> ChequesDescuentoDetalle { get; set; }
        public DbSet<Transferencias> Transferencias { get; set; }
        public DbSet<OrdenesPago> OrdenesPago { get; set; }
        public DbSet<OrdenesPagoDetalle> OrdenesPagoDetalle { get; set; }
        public DbSet<OrdenesPagoImpuestos> OrdenesPagoImpuestos { get; set; }
        public DbSet<OrdenesPagoComprobantes> OrdenesPagoComprobantes { get; set; }
        public DbSet<ListaPagos> ListaPagos { get; set; }
        public DbSet<ListaPagosDetalle> ListaPagosDetalle { get; set; }
        public DbSet<TipoIva> TipoIva { get; set; }
        public DbSet<EntidadesImpuestoAlicuotas> EntidadesImpuestoAlicuotas { get; set; }
        public DbSet<TipoImpuestos> TipoImpuestos { get; set; }
        public DbSet<ComprobantesCompras> ComprobantesCompras { get; set; }
        public DbSet<ComprobantesComprasDetalle> ComprobantesComprasDetalle { get; set; }
        public DbSet<ComprobantesVentas> ComprobantesVentas { get; set; }
        public DbSet<ComprobantesVentasDetalle> ComprobantesVentasDetalle { get; set; }
        public DbSet<EntidadesEmpresas> EntidadesEmpresas { get; set; }
        public DbSet<EntidadesUnidadNegocios> EntidadesUnidadNegocios { get; set; }
        public DbSet<ProductosCategorias2> ProductosCategorias2 { get; set; }
        public DbSet<ChequesPropios> ChequesPropios { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<TipoPercepciones> TipoPercepciones { get; set; }
    }
}
