CREATE TABLE [dbo].[Coches_Publicidad] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_Coche]    INT          NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Empezo]      DATETIME     NOT NULL,
    [Finalizo]    DATETIME     NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_Coches_Publicidad] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Coches_Publicidad_Coches] FOREIGN KEY ([Id_Coche]) REFERENCES [dbo].[Coches] ([Id])
);

