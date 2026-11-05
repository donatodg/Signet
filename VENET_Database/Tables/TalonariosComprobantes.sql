CREATE TABLE [dbo].[TalonariosComprobantes] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Id_Comprobante] INT           NOT NULL,
    [Letra]          VARCHAR (1)   NOT NULL,
    [NroCodigo]      VARCHAR (3)   NULL,
    [Id_PuntoVenta]  INT           NOT NULL,
    [Electronico]    BIT           NOT NULL,
    [Impresora]      VARCHAR (100) NULL,
    [Copias]         INT           NULL,
    [FechaAdd]       DATETIME      NOT NULL,
    [FechaMod]       DATETIME      NULL,
    [FechaDel]       DATETIME      NULL,
    [UserAdd]        INT           NOT NULL,
    [UserMod]        INT           NULL,
    [UserDel]        INT           NULL,
    CONSTRAINT [PK_TalonariosComprobantes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TalonariosComprobantes_PuntosVenta] FOREIGN KEY ([Id_PuntoVenta]) REFERENCES [dbo].[PuntosVenta] ([Id]),
    CONSTRAINT [FK_TalonariosComprobantes_TipoComprobante] FOREIGN KEY ([Id_Comprobante]) REFERENCES [dbo].[TipoComprobante] ([Id])
);

