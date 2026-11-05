CREATE TABLE [dbo].[Seguridad_Usuarios_Empresas] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario] INT      NOT NULL,
    [Id_Empresa] INT      NOT NULL,
    [FechaAdd]   DATETIME NOT NULL,
    [FechaMod]   DATETIME NULL,
    [FechaDel]   DATETIME NULL,
    [UserAdd]    INT      NOT NULL,
    [UserMod]    INT      NULL,
    [UserDel]    INT      NULL,
    CONSTRAINT [PK_Seguridad_Usuarios_Empresas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_Usuarios_Empresas_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_Seguridad_Usuarios_Empresas_Seguridad_Usuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[Seguridad_Usuarios] ([Id])
);

