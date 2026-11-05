CREATE TABLE [dbo].[Cabeceras] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Id_Linea]    INT           NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [BackColor]   VARCHAR (50)  NOT NULL,
    [ForeColor]   VARCHAR (50)  NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_Cabeceras] PRIMARY KEY CLUSTERED ([Id] ASC)
);

