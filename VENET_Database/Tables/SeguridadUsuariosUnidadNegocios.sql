CREATE TABLE [dbo].[SeguridadUsuariosUnidadNegocios] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]       INT      NOT NULL,
    [Id_UnidadNegocio] INT      NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosUnidadNegocios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosUnidadNegocios_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id]),
    CONSTRAINT [FK_SeguridadUsuariosUnidadNegocios_UnidadNegocios] FOREIGN KEY ([Id_UnidadNegocio]) REFERENCES [dbo].[UnidadNegocios] ([Id])
);

