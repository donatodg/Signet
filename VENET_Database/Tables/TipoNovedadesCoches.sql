CREATE TABLE [dbo].[TipoNovedadesCoches] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (5)   NOT NULL,
    [DescripcionLarga] VARCHAR (100) NOT NULL,
    [FechaAdd]         DATETIME      NOT NULL,
    [FechaMod]         DATETIME      NULL,
    [FechaDel]         DATETIME      NULL,
    [UserAdd]          INT           NOT NULL,
    [UserMod]          INT           NULL,
    [UserDel]          INT           NULL,
    CONSTRAINT [PK_TipoNovedadesCoches] PRIMARY KEY CLUSTERED ([Id] ASC)
);

