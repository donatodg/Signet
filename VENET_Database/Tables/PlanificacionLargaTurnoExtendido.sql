CREATE TABLE [dbo].[PlanificacionLargaTurnoExtendido] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion]       INT          NOT NULL,
    [Id_CodigoServicioTodos] BIGINT       NOT NULL,
    [Id_Personal]            INT          NOT NULL,
    [Id_Coche]               INT          NOT NULL,
    [Fecha]                  DATETIME     NOT NULL,
    [Id_CodigoServicio]      INT          NOT NULL,
    [Codigo]                 VARCHAR (50) NOT NULL,
    [NroVuelta]              INT          NOT NULL,
    [FechaAdd]               DATETIME     NOT NULL,
    [FechaMod]               DATETIME     NULL,
    [FechaDel]               DATETIME     NULL,
    [UserAdd]                INT          NOT NULL,
    [UserMod]                INT          NULL,
    [UserDel]                INT          NULL,
    CONSTRAINT [PK_PlanificacionLargaTurnoExtendido] PRIMARY KEY CLUSTERED ([Id] ASC)
);

