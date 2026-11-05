CREATE TABLE [dbo].[PuntosdePaso] (
    [Id]          INT               IDENTITY (1, 1) NOT NULL,
    [Id_Seccion]  INT               NOT NULL,
    [Descripcion] VARCHAR (50)      NOT NULL,
    [Numero]      INT               NOT NULL,
    [Kms]         DECIMAL (18, 2)   NULL,
    [Distancia]   DECIMAL (18, 2)   NULL,
    [GeoPoint]    [sys].[geography] NULL,
    [Parada]      BIT               NOT NULL,
    [FechaAdd]    DATETIME          NOT NULL,
    [FechaMod]    DATETIME          NULL,
    [FechaDel]    DATETIME          NULL,
    [UserAdd]     INT               NOT NULL,
    [UserMod]     INT               NULL,
    [UserDel]     INT               NULL,
    CONSTRAINT [PK_PuntosControl] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Paradas_Secciones] FOREIGN KEY ([Id_Seccion]) REFERENCES [dbo].[Secciones] ([Id])
);

