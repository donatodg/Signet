CREATE TABLE [dbo].[ViajesEspecialesComentarios] (
    [Id_UnidadNegocio] INT            NOT NULL,
    [Observaciones]    VARCHAR (8000) NOT NULL,
    CONSTRAINT [PK_ViajesEspecialesComentarios] PRIMARY KEY CLUSTERED ([Id_UnidadNegocio] ASC)
);

