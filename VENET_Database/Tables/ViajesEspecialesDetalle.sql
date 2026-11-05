CREATE TABLE [dbo].[ViajesEspecialesDetalle] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Id_ViajeEspecial]      INT            NOT NULL,
    [Id_Coche]              INT            NULL,
    [Id_Personal1]          INT            NULL,
    [Id_Personal2]          INT            NULL,
    [FueraLinea]            BIT            NULL,
    [CobraViaticoPersonal1] BIT            NOT NULL,
    [CobraViaticoPersonal2] BIT            NOT NULL,
    [Observaciones]         VARCHAR (8000) NULL,
    [Id_Vale]               INT            NULL,
    [FechaPagoPersonal1]    DATETIME       NULL,
    [FechaPagoPersonal2]    DATETIME       NULL,
    [FechaAdd]              DATETIME       NOT NULL,
    [FechaMod]              DATETIME       NULL,
    [FechaDel]              DATETIME       NULL,
    [UserAdd]               INT            NOT NULL,
    [UserMod]               INT            NULL,
    [UserDel]               INT            NULL,
    CONSTRAINT [PK_ViajesEspeciales_Detalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ViajesEspeciales_Detalle_ViajesEspeciales] FOREIGN KEY ([Id_ViajeEspecial]) REFERENCES [dbo].[ViajesEspeciales] ([Id]),
    CONSTRAINT [FK_ViajesEspecialesDetalle_ViajesEspecialesVales] FOREIGN KEY ([Id_Vale]) REFERENCES [dbo].[ViajesEspecialesVales] ([Id])
);

