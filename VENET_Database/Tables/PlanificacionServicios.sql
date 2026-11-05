CREATE TABLE [dbo].[PlanificacionServicios] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion]  INT      NOT NULL,
    [Id_TipoServicio]   INT      NOT NULL,
    [Id_Diagrama]       INT      NOT NULL,
    [Fecha]             DATE     NOT NULL,
    [CantidadServicios] INT      NOT NULL,
    [FechaAdd]          DATETIME NOT NULL,
    [FechaMod]          DATETIME NULL,
    [FechaDel]          DATETIME NULL,
    [UserAdd]           INT      NOT NULL,
    [UserMod]           INT      NULL,
    [UserDel]           INT      NULL,
    CONSTRAINT [PK_Planificacion_Fechas_Diagrama] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionServicios_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [PlanificacionServicios]
    ON [dbo].[PlanificacionServicios]([Id_Planificacion] ASC, [Id_TipoServicio] ASC, [Id_Diagrama] ASC, [Fecha] ASC);

