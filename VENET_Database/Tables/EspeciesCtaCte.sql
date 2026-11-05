CREATE TABLE [dbo].[EspeciesCtaCte] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Id_Caja]            INT             NULL,
    [Id_CentroCosto]     INT             NOT NULL,
    [Fecha]              DATE            NOT NULL,
    [Id_TipoComprobante] INT             NOT NULL,
    [Id_Comprobante]     INT             NOT NULL,
    [Concepto]           VARCHAR (100)   NOT NULL,
    [Debito]             DECIMAL (18, 2) NOT NULL,
    [Credito]            DECIMAL (18, 2) NOT NULL,
    [FechaAdd]           DATETIME        NOT NULL,
    [FechaMod]           DATETIME        NULL,
    [FechaDel]           DATETIME        NULL,
    [UserAdd]            INT             NOT NULL,
    [UserMod]            INT             NULL,
    [UserDel]            INT             NULL,
    CONSTRAINT [PK_Especies_CtaCte] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EspeciesCtaCte_Cajas] FOREIGN KEY ([Id_Caja]) REFERENCES [dbo].[Cajas] ([Id]),
    CONSTRAINT [FK_EspeciesCtaCte_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id]),
    CONSTRAINT [FK_EspeciesCtaCte_TipoComprobante] FOREIGN KEY ([Id_TipoComprobante]) REFERENCES [dbo].[TipoComprobante] ([Id])
);

