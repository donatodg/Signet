CREATE TABLE [dbo].[EstadosCiviles] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_EstadosCiviles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

