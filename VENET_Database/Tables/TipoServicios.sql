CREATE TABLE [dbo].[TipoServicios] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Id_Ramal]          INT          NOT NULL,
    [Descripcion]       VARCHAR (50) NOT NULL,
    [AsientosNumerados] BIT          NOT NULL,
    [BoletoEnPlanilla]  BIT          CONSTRAINT [DF_TipoServicios_BoletoEnPlanilla] DEFAULT ((0)) NULL,
    [PlanillaCNRT]      BIT          CONSTRAINT [DF_TipoServicios_PlanillaCNRT_1] DEFAULT ((0)) NULL,
    [CantidadRotacion]  INT          CONSTRAINT [DF_TipoServicios_CantidadRotacion] DEFAULT ((2)) NOT NULL,
    [FechaAdd]          DATETIME     NOT NULL,
    [FechaMod]          DATETIME     NULL,
    [FechaDel]          DATETIME     NULL,
    [UserAdd]           INT          NOT NULL,
    [UserMod]           INT          NULL,
    [UserDel]           INT          NULL,
    CONSTRAINT [PK_SERVICIOS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Servicios_Ramales] FOREIGN KEY ([Id_Ramal]) REFERENCES [dbo].[Ramales] ([Id])
);

