CREATE TABLE [dbo].[OrdenesPagoDetalle] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Id_OrdenPago]       INT             NOT NULL,
    [Id_Especie]         INT             NOT NULL,
    [Cotizacion]         DECIMAL (18, 4) NOT NULL,
    [Importe]            DECIMAL (18, 2) NOT NULL,
    [Detalle]            VARCHAR (100)   NOT NULL,
    [Id_Documento]       INT             NULL,
    [Id_DocumentoPropio] INT             NULL,
    [Id_TipoEntidad]     INT             NULL,
    [Id_Entidad]         INT             NULL,
    [FechaAdd]           DATETIME        NOT NULL,
    [FechaMod]           DATETIME        NULL,
    [FechaDel]           DATETIME        NULL,
    [UserAdd]            INT             NULL,
    [UserMod]            INT             NULL,
    [UserDel]            INT             NULL,
    CONSTRAINT [PK_OrdenesPagoDetalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrdenesPagoDetalle_OrdenesPago] FOREIGN KEY ([Id_OrdenPago]) REFERENCES [dbo].[OrdenesPago] ([Id])
);

