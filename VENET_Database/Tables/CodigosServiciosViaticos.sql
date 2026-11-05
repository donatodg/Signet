CREATE TABLE [dbo].[CodigosServiciosViaticos] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [Id_CodigoServicio] INT      NOT NULL,
    [Id_TipoViatico]    INT      NOT NULL,
    [Cantidad]          INT      NOT NULL,
    [FechaAdd]          DATETIME NOT NULL,
    [FechaMod]          DATETIME NULL,
    [FechaDel]          DATETIME NULL,
    [UserAdd]           INT      NOT NULL,
    [UserMod]           INT      NULL,
    [UserDel]           INT      NULL,
    CONSTRAINT [PK_CodigosServiciosViaticos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CodigosServiciosViaticos_CodigosServicios] FOREIGN KEY ([Id_CodigoServicio]) REFERENCES [dbo].[CodigosServicios] ([Id]),
    CONSTRAINT [FK_CodigosServiciosViaticos_TipoViaticos] FOREIGN KEY ([Id_TipoViatico]) REFERENCES [dbo].[TipoViaticos] ([Id])
);

