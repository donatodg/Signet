CREATE TABLE [dbo].[ProvFinancieros] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (100) NOT NULL,
    [Domicilio]    VARCHAR (100) NULL,
    [Id_CodPostal] INT           NOT NULL,
    [Cuit]         VARCHAR (13)  NULL,
    [Id_TipoIva]   INT           CONSTRAINT [DF_ProvFinancieros_Id_TipoIva] DEFAULT ((3)) NOT NULL,
    [FechaAdd]     DATETIME      NOT NULL,
    [FechaMod]     DATETIME      NULL,
    [FechaDel]     DATETIME      NULL,
    [UserAdd]      INT           NOT NULL,
    [UserMod]      INT           NULL,
    [UserDel]      INT           NULL,
    CONSTRAINT [PK_ProvFinancieros] PRIMARY KEY CLUSTERED ([Id] ASC)
);

