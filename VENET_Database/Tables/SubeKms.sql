CREATE TABLE [dbo].[SubeKms] (
    [Id]             BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdArchivo]      BIGINT          NOT NULL,
    [Fecha]          DATETIME        NOT NULL,
    [IdEmpresa]      BIGINT          NOT NULL,
    [IdLinea]        BIGINT          NOT NULL,
    [IdRamal]        BIGINT          NOT NULL,
    [Interno]        BIGINT          NOT NULL,
    [TipoEvento]     BIGINT          NOT NULL,
    [TipoMovimiento] BIGINT          NOT NULL,
    [Metros]         DECIMAL (18, 2) NULL,
    [Kms]            DECIMAL (18, 2) NULL,
    [Velocidad]      DECIMAL (18, 2) NULL,
    [Latitud]        DECIMAL (18, 8) NULL,
    [Longitud]       DECIMAL (18, 8) NULL,
    [Point]          AS              ([geometry]::Point([latitud],[longitud],(0))),
    [Sync]           BIT             NULL,
    CONSTRAINT [PK_SubeKms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

