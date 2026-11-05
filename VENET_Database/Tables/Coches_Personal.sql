CREATE TABLE [dbo].[Coches_Personal] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [Id_Coche]       INT      NOT NULL,
    [Id_Personal]    INT      NOT NULL,
    [Id_Titularidad] INT      NOT NULL,
    [FechaAdd]       DATETIME NOT NULL,
    [FechaMod]       DATETIME NULL,
    [FechaDel]       DATETIME NULL,
    [UserAdd]        INT      NOT NULL,
    [UserMod]        INT      NULL,
    [UserDel]        INT      NULL,
    CONSTRAINT [PK_Coches_Personal] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Coches_Personal_Coches] FOREIGN KEY ([Id_Coche]) REFERENCES [dbo].[Coches] ([Id]),
    CONSTRAINT [FK_Coches_Personal_Personal] FOREIGN KEY ([Id_Personal]) REFERENCES [dbo].[Personal] ([Id])
);

