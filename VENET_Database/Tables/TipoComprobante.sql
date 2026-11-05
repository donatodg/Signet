CREATE TABLE [dbo].[TipoComprobante] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]          VARCHAR (50) NOT NULL,
    [DescripcionCorta]     VARCHAR (4)  NULL,
    [Id_Area]              INT          NOT NULL,
    [Orden]                INT          NOT NULL,
    [InternoSistema]       BIT          CONSTRAINT [DF_TipoComprobante_InternoSistema] DEFAULT ((0)) NOT NULL,
    [Id_TipoCompProcesa]   INT          NULL,
    [Id_TipoCompAnula]     INT          NULL,
    [MueveStock]           BIT          NOT NULL,
    [Id_MovimientoCaja]    INT          NULL,
    [Id_MovimientoEntidad] INT          NULL,
    [FechaAdd]             DATETIME     NOT NULL,
    [FechaMod]             DATETIME     NULL,
    [FechaDel]             DATETIME     NULL,
    [UserAdd]              INT          NOT NULL,
    [UserMod]              INT          NULL,
    [UserDel]              INT          NULL,
    CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

