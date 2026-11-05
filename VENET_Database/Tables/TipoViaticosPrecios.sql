CREATE TABLE [dbo].[TipoViaticosPrecios] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Id_TipoViatico] INT             NOT NULL,
    [Importe]        DECIMAL (18, 2) NOT NULL,
    [VigenciaDesde]  DATE            NOT NULL,
    [VigenciaHasta]  DATE            NOT NULL,
    [FechaAdd]       DATETIME        NOT NULL,
    [FechaMod]       DATETIME        NULL,
    [FechaDel]       DATETIME        NULL,
    [UserAdd]        INT             NOT NULL,
    [UserMod]        INT             NULL,
    [UserDel]        INT             NULL,
    CONSTRAINT [PK_TipoViaticosPrecios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

