CREATE TABLE [dbo].[CodigosServiciosEstados] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [PagaHoras]   BIT          NOT NULL,
    [SumaKms]     BIT          NOT NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_CodigosServiciosEstados] PRIMARY KEY CLUSTERED ([Id] ASC)
);

