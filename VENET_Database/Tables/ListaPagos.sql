CREATE TABLE [dbo].[ListaPagos] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Id_Sucursal]       INT           NOT NULL,
    [Id_CentroCosto]    INT           NOT NULL,
    [Numero]            INT           NOT NULL,
    [Fecha]             DATE          NOT NULL,
    [Id_TipoEntidad]    INT           NOT NULL,
    [Id_Especie]        INT           NOT NULL,
    [Sentido]           INT           NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [FechaConfirmacion] DATETIME      NULL,
    [FechaAnulacion]    DATETIME      NULL,
    [MotivoAnulacion]   VARCHAR (300) NULL,
    [GeneroOP]          INT           NULL,
    [FechaAdd]          DATETIME      NOT NULL,
    [FechaMod]          DATETIME      NULL,
    [FechaDel]          DATETIME      NULL,
    [UserAdd]           INT           NOT NULL,
    [UserMod]           INT           NULL,
    [UserDel]           INT           NULL,
    CONSTRAINT [PK_ListaPagos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

