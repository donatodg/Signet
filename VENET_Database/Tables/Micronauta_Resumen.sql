CREATE TABLE [dbo].[Micronauta_Resumen] (
    [Fecha]    DATETIME     NOT NULL,
    [Coche]    VARCHAR (50) NOT NULL,
    [Deje]     DATETIME     NOT NULL,
    [Dominio]  VARCHAR (50) NULL,
    [Empresa]  VARCHAR (50) NULL,
    [Equipo]   VARCHAR (50) NULL,
    [Kms]      VARCHAR (50) NOT NULL,
    [Legajo]   INT          NOT NULL,
    [Chofer]   VARCHAR (50) NULL,
    [Linea]    VARCHAR (50) NOT NULL,
    [Llega]    DATETIME     NOT NULL,
    [Sale]     DATETIME     NOT NULL,
    [Servicio] VARCHAR (50) NOT NULL,
    [Toma]     DATETIME     NOT NULL,
    [Perdida]  VARCHAR (50) NULL,
    [Sync]     BIT          NULL,
    CONSTRAINT [PK_Micronauta_Resumen] PRIMARY KEY CLUSTERED ([Fecha] ASC, [Coche] ASC, [Linea] ASC, [Llega] ASC, [Sale] ASC, [Servicio] ASC)
);

