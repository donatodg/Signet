CREATE TABLE [dbo].[Ramales] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_Linea]    INT          NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_RAMALES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ramales_Lineas] FOREIGN KEY ([Id_Linea]) REFERENCES [dbo].[Lineas] ([Id])
);

