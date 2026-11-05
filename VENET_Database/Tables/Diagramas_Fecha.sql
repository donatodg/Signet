CREATE TABLE [dbo].[Diagramas_Fecha] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]       SMALLDATETIME NOT NULL,
    [Id_Diagrama] INT           NOT NULL,
    [NroServicio] INT           NOT NULL,
    [Turno]       INT           NOT NULL,
    [Id_Coche]    INT           NOT NULL,
    [Id_Personal] INT           NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_Diagramas_Fecha] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diagrama_Fecha_Diagramas] FOREIGN KEY ([Id_Diagrama]) REFERENCES [dbo].[Diagramas] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [Diagramas_Fecha]
    ON [dbo].[Diagramas_Fecha]([Fecha] ASC, [Id_Diagrama] ASC, [NroServicio] ASC, [Turno] ASC);

