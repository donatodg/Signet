namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class ErsaContext : DbContext, IDisposable
    {

        //static ErsaContext()
        //{
        //    Database.SetInitializer<ErsaContext>(null);
        //}

        public ErsaContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"])
        {
            Database.SetInitializer<ErsaContext>(null);
            // Configuration.AutoDetectChangesEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false;

            // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 1800;
        }

        public ErsaContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public ErsaContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Lineas> Lineas { get; set; }
        public DbSet<Ramales> Ramales { get; set; }
        public DbSet<Secciones> Secciones { get; set; }
        public DbSet<TipoServicios> TipoServicios { get; set; }
        public DbSet<TipoDia> TipoDia { get; set; }
        public DbSet<Diagramas> Diagramas { get; set; }
        public DbSet<DiagramasDetalle> DiagramasDetalle { get; set; }
        public DbSet<DiagramasFecha> DiagramasFecha { get; set; }
        public DbSet<DiagramasServicios> DiagramasServicios { get; set; }
        public DbSet<Coches> Coches { get; set; }
        public DbSet<CochesPublicidad> CochePublicidad { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<PersonalNovedades> PersonalNovedades { get; set; }
        public DbSet<Feriados> Feriados { get; set; }
        public DbSet<CochesPersonal> CochesPersonal { get; set; }
        public DbSet<Planificacion> Planificacion { get; set; }
        public DbSet<PlanificacionServicios> PlanificacionServicios { get; set; }
        public DbSet<PlanificacionDetalles> PlanificacionDetalles { get; set; }
        public DbSet<PlanificacionDetallesCoches> PlanificacionDetallesCoches { get; set; }
        public DbSet<UnidadNegocios> UnidadesNegocios { get; set; }
        public DbSet<TipoNovedades> TipoNovedades { get; set; }
        public DbSet<TipoNovedadesCoches> TipoNovedadesCoches { get; set; }
        public DbSet<TipoComentarios> TipoComentarios { get; set; }
        public DbSet<PlanificacionComentarios> PlanificacionComentarios { get; set; }
        public DbSet<PlanificacionDiaCerrado> PlanificacionDiaCerrado { get; set; }
        public DbSet<PlanificacionTurnoExtendido> PlanificacionTurnoExtendido { get; set; }
        public DbSet<PlanificacionCochesComentarios> PlanificacionCochesComentarios { get; set; }
        public DbSet<CodigosServicios> CodigosServicios { get; set; }
        public DbSet<CodigosServiciosViaticos> CodigosServiciosViaticos { get; set; }
        public DbSet<CodigosServiciosVueltas> CodigosServiciosVueltas { get; set; }
        public DbSet<CodigosServiciosVueltasDetalle> CodigosServiciosVueltasDetalle { get; set; }
        public DbSet<Jurisdicciones> Jurisdicciones { get; set; }
        public DbSet<TipoViaticos> TipoViaticos { get; set; }
        public DbSet<PlanificacionLarga> PlanificacionLarga { get; set; }
        public DbSet<PlanificacionLargaServicios> PlanificacionLargaServicios { get; set; }
        public DbSet<PlanificacionLargaDetalles> PlanificacionLargaDetalles { get; set; }
        public DbSet<PlanificacionLargaDetallesConfirmado> PlanificacionLargaDetallesConfirmado { get; set; }
        public DbSet<CodigosServiciosEventuales> CodigosServiciosEventuales { get; set; }
        public DbSet<PlanificacionLargaComentarios> PlanificacionLargaComentarios { get; set; }
        public DbSet<CodigosServiciosTodos> CodigosServiciosTodos { get; set; }
        public DbSet<CodigosServiciosFechas> CodigosServiciosFechas { get; set; }
        public DbSet<CodigosServiciosEstados> CodigosServiciosEstados { get; set; }
        public DbSet<PlanificacionLargaDiaCerrado> PlanificacionLargaDiaCerrado { get; set; }
        public DbSet<PlanificacionLargaDetallesCoches> PlanificacionLargaDetallesCoches { get; set; }
        public DbSet<PlanificacionLargaCochesComentarios> PlanificacionLargaCochesComentarios { get; set; }
        public DbSet<Cabeceras> Cabeceras { get; set; }
        public DbSet<ViajesEspeciales> ViajesEspeciales { get; set; }
        public DbSet<ViajesEspecialesDetalle> ViajesEspecialesDetalle { get; set; }
        public DbSet<ViajesEspecialesVales> ViajesEspecialesVales { get; set; }
        public DbSet<ViajesEspecialesComentarios> ViajesEspecialesComentarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ClientesContactos> ClientesContactos { get; set; }
        public DbSet<TipoDoc> TipoDoc { get; set; }
        public DbSet<TipoCodigoServicio> TipoCodigoServicio { get; set; }
        public DbSet<PlanificacionLargaTurnoExtendido> PlanificacionLargaTurnoExtendido { get; set; }
        public DbSet<PlanificacionLargaCochesTurnoExtendido> PlanificacionLargaCochesTurnoExtendido { get; set; }
        public DbSet<PlanillasViajes> PlanillasViajes { get; set; }
        public DbSet<PlanillasViajesDetalle> PlanillasViajesDetalle { get; set; }
        public DbSet<PlanillasViajesKms> PlanillasViajesKms { get; set; }
        public DbSet<EntidadesEmpresas> EntidadesEmpresas { get; set; }
        public DbSet<EntidadesUnidadNegocios> EntidadesUnidadNegocios { get; set; }
        public DbSet<PlanificacionComentariosDiario> PlanificacionComentariosDiario { get; set; }
        public DbSet<PuntasDeLineas> PuntasDeLineas { get; set; }
        public DbSet<ServiciosInspectores> ServiciosInspectores { get; set; }
        public DbSet<PlanificacionDetallesInspectores> PlanificacionDetallesInspectores { get; set; }
        public DbSet<PlanificacionServiciosInspectores> PlanificacionServiciosInspectores { get; set; }
        public DbSet<UnidadNegocios_Configuracion> UnidadNegocios_Configuracion { get; set; }
        public DbSet<PuntosdePaso> PuntosdePaso { get; set; }
        public DbSet<RutasWeb> RutasWeb { get; set; }
        public DbSet<GruposLineas> GruposLineas { get; set; }
        public DbSet<FrancosCompensatorios> FrancosCompensatorios { get; set; }
        public DbSet<PlanificacionComentariosInspectores> PlanificacionComentariosInspectores { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
    }
}
