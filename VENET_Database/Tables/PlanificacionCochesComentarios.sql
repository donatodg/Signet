CREATE TABLE [dbo].[PlanificacionCochesComentarios] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [Id_PlanificacionDetalleCoche] INT           NOT NULL,
    [Id_TipoComentario]            INT           NOT NULL,
    [Comentario]                   VARCHAR (500) NOT NULL,
    [FechaAdd]                     DATETIME      NOT NULL,
    [FechaMod]                     DATETIME      NULL,
    [FechaDel]                     DATETIME      NULL,
    [UserAdd]                      INT           NOT NULL,
    [UserMod]                      INT           NULL,
    [UserDel]                      INT           NULL,
    CONSTRAINT [PK_PlanificacionCochesComentarios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlanificacionCochesComentarios_PlanificacionDetallesCoches] FOREIGN KEY ([Id_PlanificacionDetalleCoche]) REFERENCES [dbo].[PlanificacionDetallesCoches] ([Id])
);

