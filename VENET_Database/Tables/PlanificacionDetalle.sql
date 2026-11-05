CREATE TABLE [dbo].[PlanificacionDetalle] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT NOT NULL,
    [Id_Personal]      INT NOT NULL,
    [Id_Coche]         INT NOT NULL,
    [Id_Linea]         INT NOT NULL,
    [Turno]            INT NOT NULL,
    [Id_Titularidad]   INT NOT NULL,
    CONSTRAINT [PK_Planificacion_Detalle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Planificacion_Detalle_Planificacion] FOREIGN KEY ([Id_Planificacion]) REFERENCES [dbo].[Planificacion] ([Id])
);

