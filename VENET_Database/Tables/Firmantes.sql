CREATE TABLE [dbo].[Firmantes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]   VARCHAR (100) NOT NULL,
    [Cuit]     VARCHAR (13)  NOT NULL,
    [FechaAdd] DATETIME      NOT NULL,
    [FechaMod] DATETIME      NULL,
    [FechaDel] DATETIME      NULL,
    [UserAdd]  INT           NOT NULL,
    [UserMod]  INT           NULL,
    [UserDel]  INT           NULL,
    CONSTRAINT [PK_Firmantes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

