CREATE TABLE [dbo].[PlanificacionTurnoExtendido] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT      NOT NULL,
    [Id_Servicio]      INT      NOT NULL,
    [Id_Personal]      INT      NOT NULL,
    [Id_Coche]         INT      NOT NULL,
    [Fecha]            DATETIME NOT NULL,
    [Id_Diagrama]      INT      NOT NULL,
    [NroServicio]      INT      NOT NULL,
    [Turno]            INT      NOT NULL,
    [NroVuelta]        INT      NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_PlanificacionTurnoExtendido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionTurnoExtendido_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);

