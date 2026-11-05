CREATE TABLE [dbo].[Seguridad_Grupos] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [EsAdministrador] BIT          NOT NULL,
    [FechaAdd]        DATETIME     NOT NULL,
    [FechaMod]        DATETIME     NULL,
    [FechaDel]        DATETIME     NULL,
    [UserAdd]         INT          NOT NULL,
    [UserMod]         INT          NULL,
    [UserDel]         INT          NULL,
    CONSTRAINT [PK_Seguridad_Grupos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

