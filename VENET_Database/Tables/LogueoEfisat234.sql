CREATE TABLE [dbo].[LogueoEfisat234] (
    [Legajo]          INT           NOT NULL,
    [Entra]           DATETIME      NOT NULL,
    [NombreyApellido] VARCHAR (100) NOT NULL,
    [Sale]            DATETIME      NOT NULL,
    [Linea]           VARCHAR (50)  NOT NULL,
    [Bandera]         VARCHAR (100) NULL,
    [Servicio]        VARCHAR (50)  NOT NULL,
    [Vehiculo]        VARCHAR (50)  NOT NULL,
    [Patente]         VARCHAR (50)  NOT NULL,
    [UnidadNegocio]   VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_LogueoEfisat234] PRIMARY KEY CLUSTERED ([Legajo] ASC, [Entra] ASC)
);

