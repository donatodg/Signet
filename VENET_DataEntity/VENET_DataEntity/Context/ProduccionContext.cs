namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class ProduccionContext : DbContext, IDisposable
    {
        public ProduccionContext()
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

        public ProduccionContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public ProduccionContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Produccion_Lineas> Produccion_Lineas { get; set; }
        public DbSet<Produccion_LineasMedidas> Produccion_LineasMedidas { get; set; }
        public DbSet<Produccion_Variantes> Produccion_Variantes { get; set; }
        public DbSet<Produccion_Medidas> Produccion_Medidas { get; set; }
        public DbSet<Produccion_ManoDeObra> Produccion_ManoDeObra { get; set; }
        public DbSet<Produccion_ManoDeObraHistorial> Produccion_ManoDeObraHistorial { get; set; }
        public DbSet<Produccion_Tareas> Produccion_Tareas { get; set; }
        public DbSet<Produccion_VariantesTareas> Produccion_VariantesTareas { get; set; }
        public DbSet<Produccion> Produccion { get; set; }
        public DbSet<Produccion_ListaPrecioActual> Produccion_ListaPrecioActual { get; set; }
        public DbSet<Produccion_ListaPrecioActual_VariantesTareas> Produccion_ListaPrecioActual_VariantesTareas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosCategorias> ProductosCategorias { get; set; }
        public DbSet<Produccion_ListaPrecios> Produccion_ListaPrecios { get; set; }
        public DbSet<Produccion_ListaPreciosDetalle> Produccion_ListaPreciosDetalle { get; set; }
        public DbSet<ProductosDerivados> ProductosDerivados { get; set; }
        public DbSet<ProductosCompuestos> ProductosCompuestos { get; set; }
        public DbSet<ProductosCompuestosDetalle> ProductosCompuestosDetalle { get; set; }
        public DbSet<TipoProduccion> TipoProduccion { get; set; }
        public DbSet<IvaAlicuotas> IvaAlicuotas { get; set; }
        public DbSet<ProductosListaPrecioActual> ProductosListaPrecioActual { get; set; }



    }
}
