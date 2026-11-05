CREATE TABLE [dbo].[SeguridadUsuariosCentrosCostos] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]     INT      NOT NULL,
    [Id_CentroCosto] INT      NOT NULL,
    [FechaAdd]       DATETIME NOT NULL,
    [FechaMod]       DATETIME NULL,
    [FechaDel]       DATETIME NULL,
    [UserAdd]        INT      NOT NULL,
    [UserMod]        INT      NULL,
    [UserDel]        INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosCentrosCostos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosCentrosCostos_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id]),
    CONSTRAINT [FK_SeguridadUsuariosCentrosCostos_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);

