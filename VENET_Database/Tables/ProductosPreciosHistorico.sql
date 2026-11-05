CREATE TABLE [dbo].[ProductosPreciosHistorico] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Id_Producto]  INT             NOT NULL,
    [Importe]      DECIMAL (18, 2) NOT NULL,
    [ImporteCosto] DECIMAL (18, 2) NOT NULL,
    [FechaAdd]     DATETIME        NOT NULL,
    [FechaMod]     DATETIME        NULL,
    [FechaDel]     DATETIME        NULL,
    [UserAdd]      INT             NOT NULL,
    [UserMod]      INT             NULL,
    [UserDel]      INT             NULL,
    CONSTRAINT [PK_ProductosPreciosHistorico] PRIMARY KEY CLUSTERED ([Id] ASC)
);

