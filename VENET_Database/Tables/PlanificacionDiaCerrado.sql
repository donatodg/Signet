CREATE TABLE [dbo].[PlanificacionDiaCerrado] (
    [Id_UnidadNegocio] INT      NOT NULL,
    [Fecha]            DATETIME NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [UserAdd]          INT      NOT NULL,
    CONSTRAINT [PK_PlanificacionDiaCerrado] PRIMARY KEY CLUSTERED ([Id_UnidadNegocio] ASC, [Fecha] ASC)
);

