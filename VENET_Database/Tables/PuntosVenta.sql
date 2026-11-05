CREATE TABLE [dbo].[PuntosVenta] (
    [Id]          INT         IDENTITY (1, 1) NOT NULL,
    [Id_Sucursal] INT         NOT NULL,
    [PuntoVenta]  VARCHAR (4) NOT NULL,
    [FechaAdd]    DATETIME    NOT NULL,
    [FechaMod]    DATETIME    NULL,
    [FechaDel]    DATETIME    NULL,
    [UserAdd]     INT         NOT NULL,
    [UserMod]     INT         NULL,
    [UserDel]     INT         NULL,
    CONSTRAINT [PK_PuntosVenta] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PuntosVenta_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

