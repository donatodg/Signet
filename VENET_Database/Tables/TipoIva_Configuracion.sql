CREATE TABLE [dbo].[TipoIva_Configuracion] (
    [Id]                 INT         IDENTITY (1, 1) NOT NULL,
    [Id_TipoIvaOrigen]   INT         NOT NULL,
    [Id_TipoIvaDestino]  INT         NOT NULL,
    [Id_TipoComprobante] INT         NOT NULL,
    [Letra]              VARCHAR (1) NOT NULL,
    [FechaAdd]           DATETIME    NOT NULL,
    [FechaMod]           DATETIME    NULL,
    [FechaDel]           DATETIME    NULL,
    [UserAdd]            INT         NOT NULL,
    [UserMod]            INT         NULL,
    [UserDel]            INT         NULL,
    CONSTRAINT [PK_TipoIva_Configuracion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

