CREATE TABLE [dbo].[ChequesDescuentoDetalle] (
    [Id]                 INT      IDENTITY (1, 1) NOT NULL,
    [Id_ChequeDescuento] INT      NOT NULL,
    [Id_Documento]       INT      NOT NULL,
    [FechaAdd]           DATETIME NOT NULL,
    [FechaMod]           DATETIME NULL,
    [FechaDel]           DATETIME NULL,
    [UserAdd]            INT      NOT NULL,
    [UserMod]            INT      NULL,
    [UserDel]            INT      NULL,
    CONSTRAINT [PK_ChequesDescuentoDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChequesDescuentoDetalle_ChequesDescuento] FOREIGN KEY ([Id_ChequeDescuento]) REFERENCES [dbo].[ChequesDescuento] ([Id]),
    CONSTRAINT [FK_ChequesDescuentoDetalle_ChequesTerceros] FOREIGN KEY ([Id_Documento]) REFERENCES [dbo].[ChequesTerceros] ([Id])
);

