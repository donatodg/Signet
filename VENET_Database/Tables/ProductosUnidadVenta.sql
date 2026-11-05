CREATE TABLE [dbo].[ProductosUnidadVenta] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_ProductosUnidadVenta] PRIMARY KEY CLUSTERED ([Id] ASC)
);

