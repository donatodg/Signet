CREATE TABLE [dbo].[PlanificacionDetallesConfirmado] (
    [Id]               INT          NOT NULL,
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
    CONSTRAINT [PK_PlanificacionDetallesConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionDetallesConfirmado_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);

