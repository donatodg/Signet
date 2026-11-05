CREATE TABLE [dbo].[EntidadesCtaCte] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Id_TipoEntidad]     INT             NOT NULL,
    [Id_Entidad]         INT             NOT NULL,
    [Id_Especie]         INT             NOT NULL,
    [Id_CentroCosto]     INT             NOT NULL,
    [Fecha]              DATE            NOT NULL,
    [Id_TipoComprobante] INT             NOT NULL,
    [Id_Comprobante]     INT             NOT NULL,
    [Concepto]           VARCHAR (300)   NOT NULL,
    [Debito]             DECIMAL (18, 2) NOT NULL,
    [Credito]            DECIMAL (18, 2) NOT NULL,
    [FechaAdd]           DATETIME        NOT NULL,
    [FechaMod]           DATETIME        NULL,
    [FechaDel]           DATETIME        NULL,
    [UserAdd]            INT             NOT NULL,
    [UserMod]            INT             NULL,
    [UserDel]            INT             NULL,
    CONSTRAINT [PK_EntidadesCtaCte] PRIMARY KEY CLUSTERED ([Id] ASC)
);

