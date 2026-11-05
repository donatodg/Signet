CREATE TABLE [dbo].[TipoIva] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
    [Abreviatura] VARCHAR (5)  NOT NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_TipoIva] PRIMARY KEY CLUSTERED ([Id] ASC)
);

