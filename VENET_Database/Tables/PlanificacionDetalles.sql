CREATE TABLE [dbo].[PlanificacionDetalles] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT          NOT NULL,
    [Id_Personal]      INT          NOT NULL,
    [Id_Coche]         INT          NOT NULL,
    [Id_TipoServicio]  INT          NOT NULL,
    [Fecha]            DATE         NOT NULL,
    [Novedad]          VARCHAR (15) NULL,
    [Id_Servicio]      INT          NULL,
    [Id_Novedad]       INT          NULL,
    [FechaAdd]         DATETIME     NOT NULL,
    [FechaMod]         DATETIME     NULL,
    [FechaDel]         DATETIME     NULL,
    [UserAdd]          INT          NOT NULL,
    [UserMod]          INT          NULL,
    [UserDel]          INT          NULL,
    CONSTRAINT [PK_PlanificacionDetalles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionDetalles_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [PlanificacionDetalles]
    ON [dbo].[PlanificacionDetalles]([Id_Planificacion] ASC, [Id_Personal] ASC, [Id_Coche] ASC, [Fecha] ASC);

