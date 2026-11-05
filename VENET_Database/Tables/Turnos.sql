CREATE TABLE [dbo].[Turnos] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]  INT      NOT NULL,
    [FechaInicio] DATETIME NOT NULL,
    [FechaFin]    DATETIME NULL,
    [Controlado]  BIT      NULL,
    CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

