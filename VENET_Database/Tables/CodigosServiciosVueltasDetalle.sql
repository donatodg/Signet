CREATE TABLE [dbo].[CodigosServiciosVueltasDetalle] (
    [Id]                      INT      IDENTITY (1, 1) NOT NULL,
    [Id_CodigoServicioVuelta] INT      NOT NULL,
    [Id_Seccion]              INT      NOT NULL,
    [Hora]                    DATETIME NOT NULL,
    [Dia]                     INT      NOT NULL,
    [FechaAdd]                DATETIME NOT NULL,
    [FechaMod]                DATETIME NULL,
    [FechaDel]                DATETIME NULL,
    [UserAdd]                 INT      NOT NULL,
    [UserMod]                 INT      NULL,
    [UserDel]                 INT      NULL,
    CONSTRAINT [PK_CodigosServiciosVueltasDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CodigosServiciosVueltasDetalle_CodigosServiciosVueltas] FOREIGN KEY ([Id_CodigoServicioVuelta]) REFERENCES [dbo].[CodigosServiciosVueltas] ([Id]),
    CONSTRAINT [FK_CodigosServiciosVueltasDetalle_Secciones] FOREIGN KEY ([Id_Seccion]) REFERENCES [dbo].[Secciones] ([Id])
);

