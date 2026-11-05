CREATE TABLE [dbo].[SeguridadUsuarioCajaDefault] (
    [Id_Usuario] INT NOT NULL,
    [Id_Caja]    INT NOT NULL,
    CONSTRAINT [PK_SeguridadUsuarioCajaDefault] PRIMARY KEY CLUSTERED ([Id_Usuario] ASC, [Id_Caja] ASC),
    CONSTRAINT [FK_SeguridadUsuarioCajaDefault_Cajas] FOREIGN KEY ([Id_Caja]) REFERENCES [dbo].[Cajas] ([Id])
);

