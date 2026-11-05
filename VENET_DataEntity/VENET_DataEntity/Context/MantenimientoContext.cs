namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class MantenimientoContext : DbContext, IDisposable
    {
        public MantenimientoContext()
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

        public MantenimientoContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public MantenimientoContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<CarroceriasCaracteristicas> CarroceriasCaracteristicas { get; set; }
        public DbSet<CarroceriasModelos> CarroceriasModelos { get; set; }
        public DbSet<ChasisMarcas> ChasisMarcas { get; set; }
        public DbSet<ChasisModelos> ChasisModelos { get; set; }
        public DbSet<ChasisTipos> ChasisTipos { get; set; }
        public DbSet<EmpresasTitulares> EmpresasTitulares { get; set; }
        public DbSet<EstadosDeudas> EstadosDeudas { get; set; }
        public DbSet<EstadosUnidades> EstadosUnidades { get; set; }
        public DbSet<MotorMarcas> MotorMarcas { get; set; }
        public DbSet<MotorModelos> MotorModelos { get; set; }
        public DbSet<ProveedoresCarroceria> ProveedoresCarroceria { get; set; }
        public DbSet<ProveedoresChasisMotor> ProveedoresChasisMotor { get; set; }
        public DbSet<TipoCombustibles> TipoCombustibles { get; set; }
        public DbSet<TipoCondicionUsos> TipoCondicionUsos { get; set; }
        public DbSet<TipoUnidades> TipoUnidades { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<Deudores> Deudores { get; set; }
        public DbSet<Acreedores> Acreedores { get; set; }
        public DbSet<Aseguradoras> Aseguradoras { get; set; }
    }

}
