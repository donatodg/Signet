CREATE TABLE [dbo].[TipoNovedades] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (5)   NOT NULL,
    [DescripcionLarga] VARCHAR (100) NOT NULL,
    [RRHH]             BIT           CONSTRAINT [DF_TipoNovedades_RRHH] DEFAULT ((0)) NULL,
    [ALaOrden]         BIT           CONSTRAINT [DF_TipoNovedades_ALaOrden] DEFAULT ((0)) NULL,
    [FechaAdd]         DATETIME      NOT NULL,
    [FechaMod]         DATETIME      NULL,
    [FechaDel]         DATETIME      NULL,
    [UserAdd]          INT           NOT NULL,
    [UserMod]          INT           NULL,
    [UserDel]          INT           NULL,
    CONSTRAINT [PK_TipoNovedades] PRIMARY KEY CLUSTERED ([Id] ASC)
);

