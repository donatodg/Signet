CREATE TABLE [dbo].[Seguridad_Grupos_Objetos] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Id_Grupo]  INT      NOT NULL,
    [Id_Objeto] INT      NOT NULL,
    [FechaAdd]  DATETIME NOT NULL,
    [FechaMod]  DATETIME NULL,
    [FechaDel]  DATETIME NULL,
    [UserAdd]   INT      NOT NULL,
    [UserMod]   INT      NULL,
    [UserDel]   INT      NULL,
    CONSTRAINT [PK_Seguridad_Grupos_Objetos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_Grupos_Objetos_Seguridad_Grupos] FOREIGN KEY ([Id_Grupo]) REFERENCES [dbo].[Seguridad_Grupos] ([Id]),
    CONSTRAINT [FK_Seguridad_Grupos_Objetos_Seguridad_Objetos] FOREIGN KEY ([Id_Objeto]) REFERENCES [dbo].[Seguridad_Objetos] ([Id])
);

