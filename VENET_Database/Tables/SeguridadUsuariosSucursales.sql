CREATE TABLE [dbo].[SeguridadUsuariosSucursales] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]  INT      NOT NULL,
    [Id_Sucursal] INT      NOT NULL,
    [FechaAdd]    DATETIME NOT NULL,
    [FechaMod]    DATETIME NULL,
    [FechaDel]    DATETIME NULL,
    [UserAdd]     INT      NOT NULL,
    [UserMod]     INT      NULL,
    [UserDel]     INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosSucursales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosSucursales_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id]),
    CONSTRAINT [FK_SeguridadUsuariosSucursales_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

