CREATE TABLE [dbo].[TipoDoc] (
    [Id]          INT         IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (3) NOT NULL,
    CONSTRAINT [PK_TipoDoc] PRIMARY KEY CLUSTERED ([Id] ASC)
);

