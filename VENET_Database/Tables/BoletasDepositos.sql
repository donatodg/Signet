CREATE TABLE [dbo].[BoletasDepositos] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Id_Sucursal]             INT           NOT NULL,
    [Id_ProvFinancieroCuenta] INT           NOT NULL,
    [Id_CentroCosto]          INT           NOT NULL,
    [Nro]                     INT           NOT NULL,
    [Fecha]                   DATETIME      NOT NULL,
    [Descripcion]             VARCHAR (100) NOT NULL,
    [FechaConfirmacion]       DATETIME      NULL,
    [FechaAnulacion]          DATETIME      NULL,
    [MotivoAnulacion]         VARCHAR (300) NULL,
    [FechaAdd]                DATETIME      NOT NULL,
    [FechaMod]                DATETIME      NULL,
    [FechaDel]                DATETIME      NULL,
    [UserAdd]                 INT           NOT NULL,
    [UserMod]                 INT           NULL,
    [UserDel]                 INT           NULL,
    CONSTRAINT [PK_BoletasDepositos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BoletasDepositos_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id]),
    CONSTRAINT [FK_BoletasDepositos_ProvFinancierosCuentas] FOREIGN KEY ([Id_ProvFinancieroCuenta]) REFERENCES [dbo].[ProvFinancierosCuentas] ([Id]),
    CONSTRAINT [FK_BoletasDepositos_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

