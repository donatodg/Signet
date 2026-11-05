CREATE TABLE [dbo].[Novedades] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Id_TipoNovedad] VARCHAR (5)   NOT NULL,
    [Fecha]          DATE          NOT NULL,
    [Descripcion]    VARCHAR (500) NOT NULL,
    [FechaAdd]       DATETIME      NOT NULL,
    [FechaMod]       DATETIME      NULL,
    [FechaDel]       DATETIME      NULL,
    [UserAdd]        INT           NOT NULL,
    [UserMod]        INT           NULL,
    [UserDel]        INT           NULL,
    CONSTRAINT [PK_Novedades] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Novedades_TipoNovedades] FOREIGN KEY ([Id_TipoNovedad]) REFERENCES [dbo].[TipoNovedades] ([Id])
);

