CREATE TABLE [dbo].[Tarifas] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Id_Cuadro] INT             NOT NULL,
    [X]         INT             NOT NULL,
    [Y]         INT             NOT NULL,
    [Tarifa]    DECIMAL (18, 2) NOT NULL,
    [FechaAdd]  DATETIME        NOT NULL,
    [FechaMod]  DATETIME        NULL,
    [FechaDel]  DATETIME        NULL,
    [UserAdd]   INT             NOT NULL,
    [UserMod]   INT             NULL,
    [UserDel]   INT             NULL,
    CONSTRAINT [PK_TARIFAS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tarifas_Cuadros] FOREIGN KEY ([Id_Cuadro]) REFERENCES [dbo].[Cuadros] ([Id])
);

