CREATE TABLE [dbo].[PlanificacionLargaDiaCerrado] (
    [Id_UnidadNegocio] INT      NOT NULL,
    [Fecha]            DATETIME NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [UserAdd]          INT      NOT NULL,
    CONSTRAINT [PK_PlanificacionLargaDiaCerrado] PRIMARY KEY CLUSTERED ([Id_UnidadNegocio] ASC, [Fecha] ASC)
);

