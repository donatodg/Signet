CREATE TABLE [dbo].[ChequesDescuento] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Id_Sucursal]             INT           NOT NULL,
    [Id_ProvFinancieroCuenta] INT           NOT NULL,
    [Id_CentroCosto]          INT           NOT NULL,
    [Fecha]                   DATETIME      NOT NULL,
    [Descripcion]             VARCHAR (50)  NOT NULL,
    [FechaLiquidacion]        DATETIME      NULL,
    [FechaAnulacion]          DATETIME      NULL,
    [MotivoAnulacion]         VARCHAR (300) NULL,
    [FechaAdd]                DATETIME      NOT NULL,
    [FechaMod]                DATETIME      NULL,
    [FechaDel]                DATETIME      NULL,
    [UserAdd]                 INT           NOT NULL,
    [UserMod]                 INT           NULL,
    [UserDel]                 INT           NULL,
    CONSTRAINT [PK_DescuentoCheques] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChequesDescuento_ProvFinancierosCuentas] FOREIGN KEY ([Id_ProvFinancieroCuenta]) REFERENCES [dbo].[ProvFinancierosCuentas] ([Id]),
    CONSTRAINT [FK_ChequesDescuento_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

