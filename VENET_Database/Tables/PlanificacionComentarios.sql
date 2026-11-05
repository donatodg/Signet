CREATE TABLE [dbo].[PlanificacionComentarios] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Id_PlanificacionDetalle] INT           NOT NULL,
    [Id_TipoComentario]       INT           NOT NULL,
    [Comentario]              VARCHAR (500) NOT NULL,
    [FechaAdd]                DATETIME      NOT NULL,
    [FechaMod]                DATETIME      NULL,
    [FechaDel]                DATETIME      NULL,
    [UserAdd]                 INT           NOT NULL,
    [UserMod]                 INT           NULL,
    [UserDel]                 INT           NULL,
    CONSTRAINT [PK_PlanificacionComentarios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionComentarios_PlanificacionDetalles] FOREIGN KEY ([Id_PlanificacionDetalle]) REFERENCES [dbo].[PlanificacionDetalles] ([Id]),
    CONSTRAINT [FK_PlanificacionComentarios_TipoComentarios] FOREIGN KEY ([Id_TipoComentario]) REFERENCES [dbo].[TipoComentarios] ([Id])
);

