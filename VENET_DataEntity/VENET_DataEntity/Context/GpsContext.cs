namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class GpsContext : DbContext, IDisposable
    {
        public GpsContext()
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

        public GpsContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public GpsContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<EquiposGps> EquiposGps { get; set; }
        public DbSet<EquiposSensores> EquiposSensores { get; set; }
        public DbSet<SensoresUltimo> SensoresUltimo { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<GpsUltimo> GpsUltimo { get; set; }
        public DbSet<GpsHistorico> GpsHistorico { get; set; }
        public DbSet<SensoresHistorico> SensoresHistorico { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<EventosHistorico> EventosHistorico { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<VehiculosEntradas> VehiculosEntradas { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Puntos> Puntos { get; set; }
        public DbSet<Alarmas> Alarmas { get; set; }
        public DbSet<AlarmasHistorico> AlarmasHistorico { get; set; }
        public DbSet<EquiposGpsMovimientos> EquiposGpsMovimientos { get; set; }
        public DbSet<VehiculosPersonal> VehiculosPersonal { get; set; }
        public DbSet<VehiculosPersonalDiario> VehiculosPersonalDiario { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Lineas> Lineas{ get; set; }
        public DbSet<Ramales> Ramales { get; set; }
        public DbSet<TipoServicios> TipoServicios { get; set; }

    }

}
