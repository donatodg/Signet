namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;

    public class SeguridadContext : DbContext, IDisposable
    {
        public SeguridadContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"]) { Database.SetInitializer<SeguridadContext>(null); }

        public SeguridadContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public SeguridadContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }


        public DbSet<SeguridadGrupos> SeguridadGrupos { get; set; }
        public DbSet<SeguridadGruposObjetos> SeguridadGruposObjetos { get; set; }
        public DbSet<SeguridadObjetos> SeguridadObjetos { get; set; }
        public DbSet<SeguridadUsuarios> SeguridadUsuarios { get; set; }
        public DbSet<SeguridadUsuariosConfiguracion> SeguridadUsuariosConfiguracion { get; set; }
        public DbSet<SeguridadUsuariosEmpresas> SeguridadUsuariosEmpresas { get; set; }
        public DbSet<SeguridadUsuariosSucursales> SeguridadUsuariosSucursales { get; set; }
        public DbSet<SeguridadUsuarioSucursalDefault> SeguridadUsuarioSucursalDefault { get; set; }
        public DbSet<SeguridadUsuariosCentrosCostos> SeguridadUsuariosCentrosCostos { get; set; }
        public DbSet<SeguridadUsuarioCentrosCostoDefault> SeguridadUsuarioCentrosCostoDefault { get; set; }
        public DbSet<SeguridadUsuariosUnidadNegocios> SeguridadUsuariosUnidadNegocios { get; set; }
        public DbSet<SeguridadUsuariosCajas> SeguridadUsuariosCajas { get; set; }
        public DbSet<SeguridadUsuarioCajaDefault> SeguridadUsuarioCajaDefault { get; set; }
        public DbSet<SeguridadUsuariosPuntosVentas> SeguridadUsuariosPuntosVentas { get; set; }
        public DbSet<SeguridadUsuariosDepositos> SeguridadUsuariosDepositos { get; set; }
        public DbSet<SeguridadUsuarioDepositoDefault> SeguridadUsuarioDepositoDefault { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<PuntosVentas> PuntosVentas { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<Cajas> Cajas { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<SistemaLog> SistemaLog { get; set; }
        public DbSet<Especies> Especies { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<SeguridadUsuariosIndicadores> SeguridadUsuariosIndicadores { get; set; }
    }
}
