CREATE TABLE [dbo].[Provincia] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [Abreviatura] VARCHAR (3)   NULL,
    CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED ([Id] ASC)
);

