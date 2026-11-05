CREATE TABLE [dbo].[CodigosServiciosVueltas] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Id_CodigoServicio] INT             NOT NULL,
    [NroVuelta]         INT             NOT NULL,
    [KmsProductivos]    DECIMAL (18, 2) NOT NULL,
    [KmsImproductivos]  DECIMAL (18, 2) NOT NULL,
    [HoraCitacion]      DATETIME        NOT NULL,
    [HoraFinalizacion]  DATETIME        NOT NULL,
    [Sentido]           VARCHAR (1)     NOT NULL,
    [Comentario]        VARCHAR (50)    NULL,
    [FechaAdd]          DATETIME        NOT NULL,
    [FechaMod]          DATETIME        NULL,
    [FechaDel]          DATETIME        NULL,
    [UserAdd]           INT             NOT NULL,
    [UserMod]           INT             NULL,
    [UserDel]           INT             NULL,
    CONSTRAINT [PK_CodigosServiciosVueltas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CodigosServiciosVueltas_CodigosServicios] FOREIGN KEY ([Id_CodigoServicio]) REFERENCES [dbo].[CodigosServicios] ([Id])
);

