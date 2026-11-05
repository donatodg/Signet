CREATE TABLE [dbo].[PlanificacionDetallesCoches] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT      NOT NULL,
    [Id_Coche]         INT      NOT NULL,
    [Fecha]            DATE     NOT NULL,
    [Id_TipoServicio]  INT      NOT NULL,
    [Id_Diagrama]      INT      NOT NULL,
    [Id_Servicio]      INT      NOT NULL,
    [Id_NovedadCoche]  INT      CONSTRAINT [DF_PlanificacionDetallesCoches_Id_NovedadCoche] DEFAULT ((0)) NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_PlanificacionDetallesCoches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionDetallesCoches_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [PlanificacionDetallesCoches]
    ON [dbo].[PlanificacionDetallesCoches]([Id_Planificacion] ASC, [Id_Coche] ASC, [Fecha] ASC, [Id_Diagrama] ASC, [Id_Servicio] ASC);

