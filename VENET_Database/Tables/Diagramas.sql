CREATE TABLE [dbo].[Diagramas] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Id_TipoServicio] INT           NOT NULL,
    [Id_TipoDia]      INT           NOT NULL,
    [Descripcion]     VARCHAR (100) NOT NULL,
    [VigenciaDesde]   DATETIME      NOT NULL,
    [VigenciaHasta]   DATETIME      NULL,
    [FechaAdd]        DATETIME      NOT NULL,
    [FechaMod]        DATETIME      NULL,
    [FechaDel]        DATETIME      NULL,
    [UserAdd]         INT           NOT NULL,
    [UserMod]         INT           NULL,
    [UserDel]         INT           NULL,
    CONSTRAINT [PK_Diagramas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diagramas_TipoDia] FOREIGN KEY ([Id_TipoDia]) REFERENCES [dbo].[TipoDia] ([Id]),
    CONSTRAINT [FK_Diagramas_TipoServicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id])
);

