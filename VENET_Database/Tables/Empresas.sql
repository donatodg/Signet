CREATE TABLE [dbo].[Empresas] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (50)  NOT NULL,
    [Fantasia]          VARCHAR (50)  NULL,
    [Direccion]         VARCHAR (100) NULL,
    [Id_CodPostal]      INT           NULL,
    [Id_TipoIva]        INT           NOT NULL,
    [Cuit]              VARCHAR (13)  NULL,
    [IngresosBrutos]    VARCHAR (50)  NULL,
    [InicioActividades] DATETIME      NULL,
    [FechaAdd]          DATETIME      NOT NULL,
    [FechaMod]          DATETIME      NULL,
    [FechaDel]          DATETIME      NULL,
    [UserAdd]           INT           NOT NULL,
    [UserMod]           INT           NULL,
    [UserDel]           INT           NULL,
    CONSTRAINT [PK_EMPRESAS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

