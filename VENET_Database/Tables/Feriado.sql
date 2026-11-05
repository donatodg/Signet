CREATE TABLE [dbo].[Feriado] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]       SMALLDATETIME NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_Feriados] PRIMARY KEY CLUSTERED ([Id] ASC)
);

