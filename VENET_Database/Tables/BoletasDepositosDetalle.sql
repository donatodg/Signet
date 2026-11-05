CREATE TABLE [dbo].[BoletasDepositosDetalle] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Id_BoletaDeposito] INT             NOT NULL,
    [Id_Documento]      INT             NOT NULL,
    [Importe]           DECIMAL (18, 2) NULL,
    [FechaAdd]          DATETIME        NOT NULL,
    [FechaMod]          DATETIME        NULL,
    [FechaDel]          DATETIME        NULL,
    [UserAdd]           INT             NOT NULL,
    [UserMod]           INT             NULL,
    [UserDel]           INT             NULL,
    CONSTRAINT [PK_BoletasDepositosDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BoletasDepositosDetalle_BoletasDepositos] FOREIGN KEY ([Id_BoletaDeposito]) REFERENCES [dbo].[BoletasDepositos] ([Id])
);

