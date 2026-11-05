CREATE TABLE [dbo].[Seguridad_Objetos] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Formulario]  VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [Accion]      INT           NOT NULL,
    CONSTRAINT [PK_Seguridad_Objetos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

