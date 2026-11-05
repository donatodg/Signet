namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;

    public class GeneralContext : DbContext, IDisposable
    {
        public GeneralContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"])
        { Database.SetInitializer<GeneralContext>(null); }

        public GeneralContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public GeneralContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<Feriados> Feriados { get; set; }
        public DbSet<TipoNovedades> TipoNovedades { get; set; }
        public DbSet<TipoNovedadesCoches> TipoNovedadesCoches { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<PuntosVentas> PuntosVentas { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Cajas> Cajas { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<TalonariosComprobantes> TalonariosComprobantes { get; set; }
        public DbSet<TalonariosComprobantesDetalle> TalonariosComprobantesDetalle { get; set; }
        public DbSet<TipoComprobante> TipoComprobante { get; set; }
        public DbSet<Especies> Especies { get; set; }
        public DbSet<TipoComentarios> TipoComentarios { get; set; }
        public DbSet<SeguridadUsuariosCajas> SeguridadUsuariosCajas { get; set; }
        public DbSet<SeguridadUsuarioCajaDefault> SeguridadUsuarioCajaDefault { get; set; }
        public DbSet<SeguridadUsuariosSucursales> SeguridadUsuariosSucursales { get; set; }
        public DbSet<SeguridadUsuarioSucursalDefault> SeguridadUsuarioSucursalDefault { get; set; }
        public DbSet<SeguridadUsuariosCentrosCostos> SeguridadUsuariosCentrosCostos { get; set; }
        public DbSet<SeguridadUsuarioCentrosCostoDefault> SeguridadUsuarioCentrosCostoDefault { get; set; }
        public DbSet<EntidadesBancarias> EntidadesBancarias { get; set; }
        public DbSet<Jurisdicciones> Jurisdicciones { get; set; }
        public DbSet<TipoViaticos> TipoViaticos { get; set; }
        public DbSet<TipoViaticosPrecios> TipoViaticosPrecios { get; set; }
        public DbSet<TipoCodigoServicio> TipoCodigoServicio { get; set; }
        public DbSet<TipoIva> TipoIva { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<SeguridadUsuariosDepositos> SeguridadUsuariosDepositos { get; set; }
        public DbSet<SeguridadUsuarioDepositoDefault> SeguridadUsuarioDepositoDefault { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<TipoCategoriasImagenes> TipoCategoriasImagenes { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
    }
}
