namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;

    public class PersonalContext : DbContext, IDisposable
    {
        public PersonalContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"]) { Database.SetInitializer<PersonalContext>(null); }
        public PersonalContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public PersonalContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<PersonalTipos> PersonalTipos { get; set; }
        public DbSet<PersonalJerarquias> PersonalJerarquias { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<TipoDoc> TipoDoc { get; set; }
        public DbSet<CentrosCostos> CentrosCostos { get; set; }
        public DbSet<UnidadNegocios> UnidadNegocios { get; set; }
        public DbSet<PersonalNovedades> PersonalNovedades { get; set; }
        public DbSet<TipoNovedades> TipoNovedades { get; set; }
        public DbSet<Lineas> Lineas { get; set; }
        public DbSet<Ramales> Ramales { get; set; }
        public DbSet<TipoServicios> TipoServicios { get; set; }
        public DbSet<Cabeceras> Cabeceras { get; set; }
        public DbSet<PuntasDeLineas> PuntasDeLineas { get; set; }
        public DbSet<GruposLineas> GruposLineas { get; set; }
        public DbSet<ServiciosInspectores> ServiciosInspectores { get; set; }
        public DbSet<EntidadesEmpresas> EntidadesEmpresas { get; set; }
        public DbSet<EntidadesUnidadNegocios> EntidadesUnidadNegocios { get; set; }
    }
}
