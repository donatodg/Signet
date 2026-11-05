CREATE TABLE [dbo].[TipoMovimiento] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [FechaDel]    DATETIME     NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

