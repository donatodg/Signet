CREATE TABLE [dbo].[Parametros] (
    [Nombre]      VARCHAR (100) NOT NULL,
    [Valor]       VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (500) NOT NULL,
    [TipoDato]    INT           NOT NULL,
    [Modulo]      INT           NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [UserMod]     INT           NULL,
    CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED ([Nombre] ASC)
);

