CREATE TABLE [dbo].[Transferencias] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Id_Caja_Origen]     INT             NOT NULL,
    [Id_Caja_Destino]    INT             NOT NULL,
    [Id_CentroCosto]     INT             NOT NULL,
    [Cotizacion_Origen]  DECIMAL (18, 4) NOT NULL,
    [Cotizacion_Destino] DECIMAL (18, 4) NOT NULL,
    [Descripcion]        VARCHAR (50)    NOT NULL,
    [Importe]            DECIMAL (18, 2) NOT NULL,
    [FechaAdd]           DATETIME        NOT NULL,
    [FechaMod]           DATETIME        NULL,
    [FechaDel]           DATETIME        NULL,
    [UserAdd]            INT             NOT NULL,
    [UserMod]            INT             NULL,
    [UserDel]            INT             NULL,
    CONSTRAINT [PK_Transferencias] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transferencias_Cajas] FOREIGN KEY ([Id_Caja_Origen]) REFERENCES [dbo].[Cajas] ([Id]),
    CONSTRAINT [FK_Transferencias_Cajas1] FOREIGN KEY ([Id_Caja_Destino]) REFERENCES [dbo].[Cajas] ([Id]),
    CONSTRAINT [FK_Transferencias_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id])
);

