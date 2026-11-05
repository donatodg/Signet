CREATE TABLE [dbo].[EntidadesBancarias] (
    [Codigo]      INT           NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    CONSTRAINT [PK_EntidadesBancarias] PRIMARY KEY CLUSTERED ([Codigo] ASC)
);

