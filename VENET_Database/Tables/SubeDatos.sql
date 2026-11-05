CREATE TABLE [dbo].[SubeDatos] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [IdEmpresa]        BIGINT         NOT NULL,
    [IdLinea]          BIGINT         NOT NULL,
    [IdRamal]          BIGINT         NOT NULL,
    [Interno]          BIGINT         NOT NULL,
    [Boleto]           BIGINT         NOT NULL,
    [Fecha]            DATETIME       NOT NULL,
    [CardSerialNumber] BIGINT         NOT NULL,
    [OperationCode]    INT            NOT NULL,
    [Tarifa]           DECIMAL (6, 2) NOT NULL,
    [Descuento]        DECIMAL (6, 2) NOT NULL,
    [TarifaCobrada]    DECIMAL (6, 2) NOT NULL,
    [IdArchivo]        BIGINT         NOT NULL,
    [Sync]             BIT            NULL,
    CONSTRAINT [PK_SubeDatos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

