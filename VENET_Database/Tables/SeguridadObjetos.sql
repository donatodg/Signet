CREATE TABLE [dbo].[SeguridadObjetos] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Modulo]     INT           NOT NULL,
    [Formulario] VARCHAR (50)  NOT NULL,
    [Permiso]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Seguridad_Objetos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

