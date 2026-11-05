CREATE TABLE [dbo].[PlanificacionLargaServicios] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion]  INT      NOT NULL,
    [Id_TipoServicio]   INT      NOT NULL,
    [Id_CodigoServicio] INT      NOT NULL,
    [Fecha]             DATE     NOT NULL,
    [CantidadServicios] INT      NOT NULL,
    [FechaAdd]          DATETIME NOT NULL,
    [FechaMod]          DATETIME NULL,
    [FechaDel]          DATETIME NULL,
    [UserAdd]           INT      NOT NULL,
    [UserMod]           INT      NULL,
    [UserDel]           INT      NULL,
    CONSTRAINT [PK_PlanificacionLargaServicios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

