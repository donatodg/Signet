CREATE TABLE [dbo].[Efisat_Distancia] (
    [Identificador]  VARCHAR (50)    NULL,
    [Interno]        INT             NOT NULL,
    [Patente]        VARCHAR (50)    NOT NULL,
    [CodigoEquipo]   VARCHAR (50)    NOT NULL,
    [Empresa]        VARCHAR (50)    NOT NULL,
    [Linea]          VARCHAR (50)    NULL,
    [Bandera]        VARCHAR (50)    NULL,
    [Servicio]       VARCHAR (50)    NULL,
    [FechaHoraSale]  DATETIME        NOT NULL,
    [FechaHoraLlega] DATETIME        NULL,
    [Kms]            DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Efisat_Distancia] PRIMARY KEY CLUSTERED ([Interno] ASC, [FechaHoraSale] ASC)
);

