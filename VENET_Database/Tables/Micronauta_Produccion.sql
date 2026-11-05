CREATE TABLE [dbo].[Micronauta_Produccion] (
    [Fecha]       DATETIME        NOT NULL,
    [Coche]       VARCHAR (50)    NOT NULL,
    [Comprobante] INT             NOT NULL,
    [Destino]     VARCHAR (50)    NOT NULL,
    [Dominio]     VARCHAR (50)    NULL,
    [Efectivo]    DECIMAL (18, 2) NOT NULL,
    [Empresa]     VARCHAR (50)    NULL,
    [Linea]       VARCHAR (50)    NOT NULL,
    [Origen]      VARCHAR (50)    NOT NULL,
    [Pax]         INT             NOT NULL,
    [Servicio]    VARCHAR (50)    NOT NULL,
    [Tarjeta]     DECIMAL (18, 2) NOT NULL,
    [Total]       DECIMAL (18, 2) NOT NULL,
    [Sync]        BIT             NULL,
    CONSTRAINT [PK_Micronauta_Produccion] PRIMARY KEY CLUSTERED ([Fecha] ASC, [Coche] ASC, [Comprobante] ASC, [Destino] ASC, [Linea] ASC, [Origen] ASC, [Servicio] ASC)
);

