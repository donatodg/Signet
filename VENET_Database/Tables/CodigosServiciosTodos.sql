CREATE TABLE [dbo].[CodigosServiciosTodos] (
    [Id]                BIGINT      NOT NULL,
    [Id_CodigoServicio] INT         NOT NULL,
    [Codigo]            VARCHAR (7) NOT NULL,
    CONSTRAINT [PK_CodigosServiciosTodos] PRIMARY KEY CLUSTERED ([Id] ASC, [Id_CodigoServicio] ASC, [Codigo] ASC)
);

