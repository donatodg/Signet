CREATE TABLE [dbo].[ViajesEspecialesVales] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [Id_Personal]            INT             NOT NULL,
    [Importe]                DECIMAL (18, 2) NOT NULL,
    [Descripcion]            VARCHAR (100)   NOT NULL,
    [Observaciones]          VARCHAR (800)   NULL,
    [FechaAnulacion]         DATETIME        NULL,
    [MotivoAnulacion]        VARCHAR (300)   NULL,
    [FechaRendicion]         DATETIME        NULL,
    [ImporteComprobantes]    DECIMAL (18, 2) NULL,
    [ImporteDevuelto]        DECIMAL (18, 2) NULL,
    [ObservacionesRendicion] VARCHAR (800)   NULL,
    [FechaAdd]               DATETIME        NOT NULL,
    [FechaMod]               DATETIME        NULL,
    [FechaDel]               DATETIME        NULL,
    [UserAdd]                INT             NOT NULL,
    [UserMod]                INT             NULL,
    [UserDel]                INT             NULL,
    CONSTRAINT [PK_ViajesEspecialesVales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ViajesEspecialesVales_Personal] FOREIGN KEY ([Id_Personal]) REFERENCES [dbo].[Personal] ([Id])
);

