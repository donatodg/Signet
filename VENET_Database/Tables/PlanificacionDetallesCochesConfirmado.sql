CREATE TABLE [dbo].[PlanificacionDetallesCochesConfirmado] (
    [Id]               INT      NOT NULL,
    [Id_Planificacion] INT      NOT NULL,
    [Id_Coche]         INT      NOT NULL,
    [Fecha]            DATE     NOT NULL,
    [Id_TipoServicio]  INT      NOT NULL,
    [Id_Diagrama]      INT      NOT NULL,
    [Id_Servicio]      INT      NOT NULL,
    [Id_NovedadCoche]  INT      CONSTRAINT [DF_PlanificacionDetallesCochesConfirmado_Id_NovedadCoche] DEFAULT ((0)) NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_PlanificacionDetallesCochesConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionDetallesCochesConfirmado_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);

