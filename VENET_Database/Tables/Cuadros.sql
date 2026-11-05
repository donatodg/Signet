CREATE TABLE [dbo].[Cuadros] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Id_TipoServicio] INT          NOT NULL,
    [ValidoDesde]     DATETIME     NOT NULL,
    [ValidoHasta]     DATETIME     NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [FechaAdd]        DATETIME     NOT NULL,
    [FechaMod]        DATETIME     NULL,
    [FechaDel]        DATETIME     NULL,
    [UserAdd]         INT          NOT NULL,
    [UserMod]         INT          NULL,
    [UserDel]         INT          NULL,
    CONSTRAINT [PK_CUADROS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cuadros_Servicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id])
);

