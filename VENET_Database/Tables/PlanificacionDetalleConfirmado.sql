CREATE TABLE [dbo].[PlanificacionDetalleConfirmado] (
    [Id]               INT NOT NULL,
    [Id_Planificacion] INT NOT NULL,
    [Id_Personal]      INT NOT NULL,
    [Id_Coche]         INT NOT NULL,
    [Id_Linea]         INT NOT NULL,
    [Turno]            INT NOT NULL,
    [Id_Titularidad]   INT NOT NULL,
    CONSTRAINT [PK_PlanificacionDetalleConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC)
);

