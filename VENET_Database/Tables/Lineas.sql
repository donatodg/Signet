CREATE TABLE [dbo].[Lineas] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Id_Empresa]          INT           NOT NULL,
    [Id_UnidadNegocio]    INT           NOT NULL,
    [Descripcion]         VARCHAR (50)  NOT NULL,
    [DescripcionCorta]    VARCHAR (5)   NOT NULL,
    [Provincia]           VARCHAR (50)  NULL,
    [Municipio]           VARCHAR (100) NULL,
    [TipoServicio]        VARCHAR (50)  NULL,
    [MediaLargaDistancia] BIT           NULL,
    [FechaAdd]            DATETIME      NOT NULL,
    [FechaMod]            DATETIME      NULL,
    [FechaDel]            DATETIME      NULL,
    [UserAdd]             INT           NOT NULL,
    [UserMod]             INT           NULL,
    [UserDel]             INT           NULL,
    CONSTRAINT [PK_Lineas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lineas_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_Lineas_UnidadNegocios] FOREIGN KEY ([Id_UnidadNegocio]) REFERENCES [dbo].[UnidadNegocios] ([Id])
);

