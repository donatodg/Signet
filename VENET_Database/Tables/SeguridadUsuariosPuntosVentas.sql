CREATE TABLE [dbo].[SeguridadUsuariosPuntosVentas] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]    INT      NOT NULL,
    [Id_PuntoVenta] INT      NOT NULL,
    [FechaAdd]      DATETIME NOT NULL,
    [FechaMod]      DATETIME NULL,
    [FechaDel]      DATETIME NULL,
    [UserAdd]       INT      NOT NULL,
    [UserMod]       INT      NULL,
    [UserDel]       INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosPuntosVentas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosPuntosVentas_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);

