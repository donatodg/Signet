CREATE TABLE [dbo].[PlanificacionDetalleFechasConfirmado] (
    [Id]                       INT         NOT NULL,
    [Id_Planificacion_Detalle] INT         NOT NULL,
    [Novedad]                  VARCHAR (5) NOT NULL,
    [Fecha]                    DATE        NOT NULL,
    [FechaAdd]                 DATETIME    NOT NULL,
    [FechaMod]                 DATETIME    NULL,
    [FechaDel]                 DATETIME    NULL,
    [UserAdd]                  INT         NOT NULL,
    [UserMod]                  INT         NULL,
    [UserDel]                  INT         NULL,
    CONSTRAINT [PK_PlanificacionDetalleFechasConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC)
);

