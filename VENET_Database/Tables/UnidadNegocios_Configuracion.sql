CREATE TABLE [dbo].[UnidadNegocios_Configuracion] (
    [Id_UnidadNegocio] INT NOT NULL,
    [RotaHabil]        INT NOT NULL,
    [RotaSabado]       INT NOT NULL,
    [RotaFeriado]      INT NOT NULL,
    CONSTRAINT [PK_UnidadNegocios_Configuracion] PRIMARY KEY CLUSTERED ([Id_UnidadNegocio] ASC)
);

