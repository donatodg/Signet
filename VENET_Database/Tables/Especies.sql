CREATE TABLE [dbo].[Especies] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50)    NOT NULL,
    [Sigla]       VARCHAR (3)     NOT NULL,
    [Cotizacion]  DECIMAL (18, 4) NOT NULL,
    [FechaAdd]    DATETIME        NOT NULL,
    [FechaMod]    DATETIME        NULL,
    [FechaDel]    DATETIME        NULL,
    [UserAdd]     INT             NOT NULL,
    [UserMod]     INT             NULL,
    [UserDel]     INT             NULL,
    CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

