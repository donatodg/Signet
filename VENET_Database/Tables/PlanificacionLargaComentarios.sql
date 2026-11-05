CREATE TABLE [dbo].[PlanificacionLargaComentarios] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [Id_PlanificacionLargaDetalle] INT           NOT NULL,
    [Id_TipoComentario]            INT           NOT NULL,
    [Comentario]                   VARCHAR (500) NOT NULL,
    [FechaAdd]                     DATETIME      NOT NULL,
    [FechaMod]                     DATETIME      NULL,
    [FechaDel]                     DATETIME      NULL,
    [UserAdd]                      INT           NOT NULL,
    [UserMod]                      INT           NULL,
    [UserDel]                      INT           NULL,
    CONSTRAINT [PK_PlanificacionLargaComentarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

