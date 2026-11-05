CREATE TABLE [dbo].[SeguridadUsuariosCajas] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario] INT      NOT NULL,
    [Id_Caja]    INT      NOT NULL,
    [FechaAdd]   DATETIME NOT NULL,
    [FechaMod]   DATETIME NULL,
    [FechaDel]   DATETIME NULL,
    [UserAdd]    INT      NOT NULL,
    [UserMod]    INT      NULL,
    [UserDel]    INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosCajas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosCajas_Cajas] FOREIGN KEY ([Id_Caja]) REFERENCES [dbo].[Cajas] ([Id]),
    CONSTRAINT [FK_SeguridadUsuariosCajas_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);

