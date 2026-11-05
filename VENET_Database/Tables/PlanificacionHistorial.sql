CREATE TABLE [dbo].[PlanificacionHistorial] (
    [Id_Planificacion] INT  NOT NULL,
    [Id_TipoServicio]  INT  NOT NULL,
    [Tipo_Dia]         INT  NOT NULL,
    [Id_Coche]         INT  NOT NULL,
    [Fecha]            DATE NULL,
    CONSTRAINT [FK_PlanificacionHistorial_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);

