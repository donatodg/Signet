CREATE TABLE [dbo].[Rendiciones] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Id_Caja]           INT             NOT NULL,
    [Id_Personal]       INT             NOT NULL,
    [Id_CentroCosto]    INT             NOT NULL,
    [Fecha]             DATE            NOT NULL,
    [Ids_Vales]         VARCHAR (50)    NOT NULL,
    [ImporteVale]       DECIMAL (18, 2) NULL,
    [Devolucion]        DECIMAL (18, 2) NOT NULL,
    [Diferencia]        DECIMAL (18, 2) NOT NULL,
    [FechaConfirmacion] DATETIME        NULL,
    [FechaAnulacion]    DATETIME        NULL,
    [MotivoAnulacion]   VARCHAR (300)   NULL,
    [FechaAdd]          DATETIME        NOT NULL,
    [FechaMod]          DATETIME        NULL,
    [FechaDel]          DATETIME        NULL,
    [UserAdd]           INT             NOT NULL,
    [UserMod]           INT             NULL,
    [UserDel]           INT             NULL,
    CONSTRAINT [PK_Rendiciones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rendiciones_CentrosCostos] FOREIGN KEY ([Id_CentroCosto]) REFERENCES [dbo].[CentrosCostos] ([Id]),
    CONSTRAINT [FK_Rendiciones_Personal] FOREIGN KEY ([Id_Personal]) REFERENCES [dbo].[Personal] ([Id])
);

