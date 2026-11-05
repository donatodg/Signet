CREATE TABLE [dbo].[TipoViaticosHistorial] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Id_TipoViatico] INT             NOT NULL,
    [Importe]        DECIMAL (18, 2) NOT NULL,
    [FechaAdd]       DATETIME        NOT NULL,
    [FechaMod]       DATETIME        NULL,
    [FechaDel]       DATETIME        NULL,
    [UserAdd]        INT             NOT NULL,
    [UserMod]        INT             NULL,
    [UserDel]        INT             NULL,
    CONSTRAINT [PK_TipoViaticosHistorial] PRIMARY KEY CLUSTERED ([Id] ASC)
);

