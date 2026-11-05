CREATE TABLE [dbo].[Nomina] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Id_Empresa]      INT           NOT NULL,
    [Legajo]          INT           NOT NULL,
    [Apellido]        VARCHAR (50)  NOT NULL,
    [Nombre]          VARCHAR (50)  NOT NULL,
    [Id_Linea]        INT           NOT NULL,
    [Id_TipoDoc]      INT           NOT NULL,
    [NroDoc]          INT           NOT NULL,
    [Cuit]            VARCHAR (13)  NULL,
    [Domicilio_Calle] VARCHAR (50)  NULL,
    [Domicilio_Nro]   VARCHAR (10)  NULL,
    [Domicilio_Piso]  VARCHAR (3)   NULL,
    [Domicilio_Dpto]  VARCHAR (3)   NULL,
    [Id_Localidad]    INT           NULL,
    [FechaIngreso]    SMALLDATETIME NOT NULL,
    [FechaEgreso]     SMALLDATETIME NULL,
    [MotivoEgreso]    VARCHAR (200) NULL,
    CONSTRAINT [PK_NOMINA] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Nomina_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_Nomina_TipoDoc] FOREIGN KEY ([Id_TipoDoc]) REFERENCES [dbo].[TipoDoc] ([Id])
);

