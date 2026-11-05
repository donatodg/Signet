CREATE TABLE [dbo].[PlanificacionLargaDetallesCoches] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion]  INT      NOT NULL,
    [Id_Coche]          INT      NOT NULL,
    [Fecha]             DATE     NOT NULL,
    [Id_TipoServicio]   INT      NOT NULL,
    [Id_CodigoServicio] INT      NOT NULL,
    [Id_NovedadCoche]   INT      CONSTRAINT [DF_PlanificacionLargaDetallesCoches_Id_NovedadCoche] DEFAULT ((0)) NOT NULL,
    [FechaAdd]          DATETIME NOT NULL,
    [FechaMod]          DATETIME NULL,
    [FechaDel]          DATETIME NULL,
    [UserAdd]           INT      NOT NULL,
    [UserMod]           INT      NULL,
    [UserDel]           INT      NULL,
    CONSTRAINT [PK_PlanificacionLargaDetallesCoches] PRIMARY KEY CLUSTERED ([Id] ASC)
);

