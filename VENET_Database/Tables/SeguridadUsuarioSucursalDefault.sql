CREATE TABLE [dbo].[SeguridadUsuarioSucursalDefault] (
    [Id_Usuario]  INT NOT NULL,
    [Id_Sucursal] INT NOT NULL,
    CONSTRAINT [PK_SeguridadUsuarioSucursalDefault] PRIMARY KEY CLUSTERED ([Id_Usuario] ASC, [Id_Sucursal] ASC),
    CONSTRAINT [FK_SeguridadUsuarioSucursalDefault_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id]),
    CONSTRAINT [FK_SeguridadUsuarioSucursalDefault_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

