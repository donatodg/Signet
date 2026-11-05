CREATE TABLE [dbo].[FirmantesCuentas] (
    [CodigoBarra] VARCHAR (29) NOT NULL,
    [Id_Firmante] INT          NOT NULL,
    CONSTRAINT [PK_FirmantesCuentas] PRIMARY KEY CLUSTERED ([CodigoBarra] ASC),
    CONSTRAINT [FK_FirmantesCuentas_Firmantes] FOREIGN KEY ([Id_Firmante]) REFERENCES [dbo].[Firmantes] ([Id])
);

