CREATE TABLE [dbo].[TalonariosComprobantesDetalle] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Id_TalonarioComprobante] INT           NOT NULL,
    [NroDesde]                INT           NOT NULL,
    [NroHasta]                INT           NOT NULL,
    [NroActual]               INT           NOT NULL,
    [FechaVencimiento]        SMALLDATETIME NOT NULL,
    [FechaAdd]                DATETIME      NOT NULL,
    [FechaMod]                DATETIME      NULL,
    [FechaDel]                DATETIME      NULL,
    [UserAdd]                 INT           NOT NULL,
    [UserMod]                 INT           NULL,
    [UserDel]                 INT           NULL,
    CONSTRAINT [PK_TalonariosComprobantesDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TalonariosComprobantesDetalle_TalonariosComprobantes] FOREIGN KEY ([Id_TalonarioComprobante]) REFERENCES [dbo].[TalonariosComprobantes] ([Id])
);

