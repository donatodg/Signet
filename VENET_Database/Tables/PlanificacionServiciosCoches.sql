CREATE TABLE [dbo].[PlanificacionServiciosCoches] (
    [Id]               INT  IDENTITY (1, 1) NOT NULL,
    [Fecha]            DATE NOT NULL,
    [Id_Planificacion] INT  NOT NULL,
    [Id_Diagrama]      INT  NOT NULL,
    [NroServicio]      INT  NOT NULL,
    [Id_Coche]         INT  NULL,
    CONSTRAINT [PK_PlanificacionServiciosCoches] PRIMARY KEY CLUSTERED ([Id] ASC)
);

