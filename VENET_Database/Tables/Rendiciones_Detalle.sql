CREATE TABLE [dbo].[Rendiciones_Detalle] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Id_Rendicion] INT             NOT NULL,
    [Id_Cuenta]    INT             NOT NULL,
    [Importe]      DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Rendiciones_Detalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rendiciones_Detalle_Cuentas] FOREIGN KEY ([Id_Cuenta]) REFERENCES [dbo].[Cuentas] ([Id]),
    CONSTRAINT [FK_Rendiciones_Detalle_Rendiciones] FOREIGN KEY ([Id_Rendicion]) REFERENCES [dbo].[Rendiciones] ([Id])
);

