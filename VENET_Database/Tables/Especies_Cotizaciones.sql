CREATE TABLE [dbo].[Especies_Cotizaciones] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Id_Especie] INT             NOT NULL,
    [Cotizacion] DECIMAL (18, 4) NOT NULL,
    [FechaAdd]   DATETIME        NOT NULL,
    [FechaMod]   DATETIME        NULL,
    [FechaDel]   DATETIME        NULL,
    [UserAdd]    INT             NOT NULL,
    [UserMod]    INT             NULL,
    [UserDel]    INT             NULL,
    CONSTRAINT [PK_Especies_Cotizaciones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Especies_Cotizaciones_Especies] FOREIGN KEY ([Id_Especie]) REFERENCES [dbo].[Especies] ([Id])
);

