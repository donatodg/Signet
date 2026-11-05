namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class LogisticaContext : DbContext, IDisposable
    {
        public LogisticaContext()
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

        public LogisticaContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public LogisticaContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<Datos> Datos { get; set; }
        public DbSet<FacturasTango> FacturasTango { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Retenes> Retenes { get; set; }
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<IvaAlicuotas> IvaAlicuotas { get; set; }
        public DbSet<Reclamos> Reclamos { get; set; }
        public DbSet<UnidadesEventuales> UnidadesEventuales { get; set; }
        public DbSet<EstadosFacturas> EstadosFacturas { get; set; }
        public DbSet<Autorizaciones> Autorizaciones { get; set; }
        public DbSet<Archivos> Archivos { get; set; }
        public DbSet<ArchivosDetalle> ArchivosDetalle { get; set; }
        public DbSet<ArchivosUbicacion> ArchivosUbicacion { get; set; }
        public DbSet<ArchivosCajasUsuarios> ArchivosCajasUsuarios { get; set; }
        public DbSet<CircuitosAutorizados> CircuitosAutorizados { get; set; }
        public DbSet<CircuitosAutorizadosDetalle> CircuitosAutorizadosDetalle { get; set; }
    }

}
