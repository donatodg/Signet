CREATE TABLE [dbo].[Secciones] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Id_TipoServicio]  INT          NOT NULL,
    [IdaVuelta]        VARCHAR (1)  NOT NULL,
    [Numero]           INT          NOT NULL,
    [Descripcion]      VARCHAR (50) NOT NULL,
    [DescripcionCorta] VARCHAR (20) NOT NULL,
    [FechaAdd]         DATETIME     NOT NULL,
    [FechaMod]         DATETIME     NULL,
    [FechaDel]         DATETIME     NULL,
    [UserAdd]          INT          NOT NULL,
    [UserMod]          INT          NULL,
    [UserDel]          INT          NULL,
    CONSTRAINT [PK_SECCIONES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Secciones_TipoServicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id])
);

