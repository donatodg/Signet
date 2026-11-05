CREATE TABLE [dbo].[Localidad] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Id_Provincia] INT           NOT NULL,
    [Localidad]    VARCHAR (100) NOT NULL,
    [CodPostal]    INT           NOT NULL,
    [Clearing]     INT           NOT NULL,
    [FechaAdd]     DATETIME      NOT NULL,
    [FechaMod]     DATETIME      NULL,
    [FechaDel]     DATETIME      NULL,
    [UserAdd]      INT           NOT NULL,
    [UserMod]      INT           NULL,
    [UserDel]      INT           NULL,
    CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY ([Id_Provincia]) REFERENCES [dbo].[Provincia] ([Id])
);

