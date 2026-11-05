CREATE TABLE [dbo].[SubeProcesados] (
    [Id]                 BIGINT        IDENTITY (1, 1) NOT NULL,
    [NombreArchivo]      VARCHAR (100) NOT NULL,
    [EmpresaIntegradora] VARCHAR (3)   NOT NULL,
    [IdEmpresa]          BIGINT        NOT NULL,
    [IdConcentrador]     BIGINT        NOT NULL,
    [Interno]            BIGINT        NOT NULL,
    [NumeroSerie]        BIGINT        NOT NULL,
    [Secuencia]          BIGINT        NOT NULL,
    [FechaHora]          DATETIME      NOT NULL,
    [Version]            VARCHAR (5)   NOT NULL,
    [FechaProcesado]     DATETIME      NOT NULL,
    CONSTRAINT [PK_SubeProcesados] PRIMARY KEY CLUSTERED ([Id] ASC)
);

