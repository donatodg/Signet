CREATE TABLE [dbo].[ListaPagosDetalle] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Id_ListaPago] INT             NOT NULL,
    [Id_Entidad]   INT             NOT NULL,
    [Importe]      DECIMAL (18, 2) NOT NULL,
    [Descripcion]  VARCHAR (100)   NULL,
    [Id_OP]        INT             NULL,
    [FechaAdd]     DATETIME        NOT NULL,
    [FechaMod]     DATETIME        NULL,
    [FechaDel]     DATETIME        NULL,
    [UserAdd]      INT             NOT NULL,
    [UserMod]      INT             NULL,
    [UserDel]      INT             NULL,
    CONSTRAINT [PK_ListaPagosDetalle] PRIMARY KEY CLUSTERED ([Id] ASC)
);

