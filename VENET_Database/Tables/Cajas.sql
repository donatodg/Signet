CREATE TABLE [dbo].[Cajas] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_Sucursal] INT          NOT NULL,
    [Id_Especie]  INT          NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_Cajas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cajas_Especies] FOREIGN KEY ([Id_Especie]) REFERENCES [dbo].[Especies] ([Id]),
    CONSTRAINT [FK_Cajas_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id])
);

