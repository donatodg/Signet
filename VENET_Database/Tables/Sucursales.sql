CREATE TABLE [dbo].[Sucursales] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Id_Empresa]     INT          NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    [Sigla]          VARCHAR (5)  NULL,
    [Numero]         INT          NULL,
    [Fecha_Apertura] DATETIME     NULL,
    [Fecha_Cierre]   DATETIME     NULL,
    [DomicilioCalle] VARCHAR (50) NULL,
    [DomicilioNro]   VARCHAR (10) NULL,
    [DomicilioPiso]  VARCHAR (5)  NULL,
    [DomicilioDpto]  VARCHAR (5)  NULL,
    [CodPos]         INT          NULL,
    [FechaAdd]       DATETIME     NOT NULL,
    [FechaMod]       DATETIME     NULL,
    [FechaDel]       DATETIME     NULL,
    [UserAdd]        INT          NOT NULL,
    [UserMod]        INT          NULL,
    [UserDel]        INT          NULL,
    CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sucursales_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id])
);

