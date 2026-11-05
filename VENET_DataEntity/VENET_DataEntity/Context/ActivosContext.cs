namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class ActivosContext : DbContext, IDisposable
    {
        public ActivosContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"])
        {
            Database.SetInitializer<LogisticaContext>(null);
            // Configuration.AutoDetectChangesEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false;

            // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 1800;
        }

        public ActivosContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public ActivosContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<ActivosFijos> ActivosFijos { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<Clases> Clases { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<EntidadesEmpresas> EntidadesEmpresas { get; set; }
        public DbSet<Especies> Especies { get; set; }
        public DbSet<Familias> Familias { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<ServiciosRepositorio> ServiciosRepositorio { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<Remitos> Remitos { get; set; }
        public DbSet<RemitosDetalle> RemitosDetalle { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
    }

}
