CREATE TABLE [dbo].[SeguridadUsuarioCentrosCostoDefault] (
    [Id_Usuario]     INT NOT NULL,
    [Id_CentroCosto] INT NOT NULL,
    CONSTRAINT [PK_SeguridadUsuarioCentrosCostoDefault] PRIMARY KEY CLUSTERED ([Id_Usuario] ASC, [Id_CentroCosto] ASC),
    CONSTRAINT [FK_SeguridadUsuarioCentrosCostoDefault_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id]),
    CONSTRAINT [FK_SeguridadUsuarioCentrosCostoDefault_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);

