CREATE TABLE [dbo].[ProvFinancierosCuentas] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [Id_ProvFinanciero]  INT          NOT NULL,
    [Id_EntidadBancaria] INT          NOT NULL,
    [Id_Especie]         INT          NOT NULL,
    [NroSucursal]        INT          NOT NULL,
    [NroCuenta]          BIGINT       NOT NULL,
    [CBU]                VARCHAR (22) NOT NULL,
    [FechaAdd]           DATETIME     NOT NULL,
    [FechaMod]           DATETIME     NULL,
    [FechaDel]           DATETIME     NULL,
    [UserAdd]            INT          NOT NULL,
    [UserMod]            INT          NULL,
    [UserDel]            INT          NULL,
    CONSTRAINT [PK_ProvFinancieros_Cuentas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProvFinancierosCuentas_EntidadesBancarias] FOREIGN KEY ([Id_EntidadBancaria]) REFERENCES [dbo].[EntidadesBancarias] ([Codigo]),
    CONSTRAINT [FK_ProvFinancierosCuentas_ProvFinancieros] FOREIGN KEY ([Id_ProvFinanciero]) REFERENCES [dbo].[ProvFinancieros] ([Id])
);

