CREATE TABLE [dbo].[CodigosServiciosFechas] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]                   SMALLDATETIME  NOT NULL,
    [Id_Planificacion]        INT            NOT NULL,
    [Id_CodigoServicioVuelta] INT            NOT NULL,
    [Id_Coche]                INT            NULL,
    [Id_Personal1]            INT            NULL,
    [Id_Personal2]            INT            NULL,
    [Id_Personal3]            INT            NULL,
    [Id_Estado]               INT            NULL,
    [Comentario]              NVARCHAR (500) NOT NULL,
    [Dia]                     INT            NOT NULL,
    [FechaAdd]                DATETIME       NOT NULL,
    [FechaMod]                DATETIME       NULL,
    [FechaDel]                DATETIME       NULL,
    [UserAdd]                 INT            NOT NULL,
    [UserMod]                 INT            NULL,
    [UserDel]                 INT            NULL,
    CONSTRAINT [PK_CodigosServiciosFechas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

