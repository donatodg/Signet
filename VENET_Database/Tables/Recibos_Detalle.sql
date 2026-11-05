CREATE TABLE [dbo].[Recibos_Detalle] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Id_Recibo]    INT             NOT NULL,
    [Id_Especie]   INT             NOT NULL,
    [Cotizacion]   DECIMAL (18, 4) NOT NULL,
    [Importe]      DECIMAL (18, 2) NOT NULL,
    [Detalle]      VARCHAR (100)   NOT NULL,
    [Id_Documento] INT             NULL,
    [FechaAdd]     DATETIME        NOT NULL,
    [FechaMod]     DATETIME        NULL,
    [FechaDel]     DATETIME        NULL,
    [UserAdd]      INT             NOT NULL,
    [UserMod]      INT             NULL,
    [UserDel]      INT             NULL,
    CONSTRAINT [PK_Recibos_Detalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Recibos_Detalle_Especies] FOREIGN KEY ([Id_Especie]) REFERENCES [dbo].[Especies] ([Id]),
    CONSTRAINT [FK_Recibos_Detalle_Recibos] FOREIGN KEY ([Id_Recibo]) REFERENCES [dbo].[Recibos] ([Id])
);

