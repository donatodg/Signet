CREATE TABLE [dbo].[Diagramas_Detalle] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_Diagrama] INT          NOT NULL,
    [NroServicio] INT          NOT NULL,
    [Turno]       INT          NOT NULL,
    [Id_Seccion]  INT          NOT NULL,
    [NroVuelta]   INT          NOT NULL,
    [Hora]        DATETIME     NOT NULL,
    [Marcada]     BIT          CONSTRAINT [DF_Diagramas_Detalle_Marcada] DEFAULT ((0)) NOT NULL,
    [Comentario]  VARCHAR (50) CONSTRAINT [DF_Diagramas_Detalle_Comentario] DEFAULT ('') NOT NULL,
    [FechaAdd]    DATETIME     NOT NULL,
    [FechaMod]    DATETIME     NULL,
    [FechaDel]    DATETIME     NULL,
    [UserAdd]     INT          NOT NULL,
    [UserMod]     INT          NULL,
    [UserDel]     INT          NULL,
    CONSTRAINT [PK_Diagrama_Detalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diagrama_Detalle_Diagramas] FOREIGN KEY ([Id_Diagrama]) REFERENCES [dbo].[Diagramas] ([Id]),
    CONSTRAINT [FK_Diagrama_Detalle_Secciones] FOREIGN KEY ([Id_Seccion]) REFERENCES [dbo].[Secciones] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [Diagrama]
    ON [dbo].[Diagramas_Detalle]([Id_Diagrama] ASC, [NroServicio] ASC, [Turno] ASC);

