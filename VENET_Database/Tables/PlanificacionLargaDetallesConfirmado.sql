CREATE TABLE [dbo].[PlanificacionLargaDetallesConfirmado] (
    [Id]                     INT          NOT NULL,
    [Id_Planificacion]       INT          NOT NULL,
    [Id_Personal]            INT          NOT NULL,
    [Id_TipoServicio]        INT          NOT NULL,
    [Fecha]                  DATE         NOT NULL,
    [Novedad]                VARCHAR (15) NULL,
    [Id_CodigoServicioTodos] BIGINT       NULL,
    [Id_Novedad]             INT          NULL,
    [FechaAdd]               DATETIME     NOT NULL,
    [FechaMod]               DATETIME     NULL,
    [FechaDel]               DATETIME     NULL,
    [UserAdd]                INT          NOT NULL,
    [UserMod]                INT          NULL,
    [UserDel]                INT          NULL
);

