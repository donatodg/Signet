CREATE TABLE [dbo].[PersonalNovedades] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]          DATE           NOT NULL,
    [Id_Personal]    INT            NOT NULL,
    [Id_TipoNovedad] INT            NOT NULL,
    [Observaciones]  VARCHAR (8000) CONSTRAINT [DF_PersonalNovedades_Observaciones] DEFAULT ('') NULL,
    [FechaAdd]       DATETIME       NOT NULL,
    [FechaMod]       DATETIME       NULL,
    [FechaDel]       DATETIME       NULL,
    [UserAdd]        INT            NOT NULL,
    [UserMod]        INT            NULL,
    [UserDel]        INT            NULL,
    CONSTRAINT [PK_PersonalNovedades] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonalNovedades_Personal] FOREIGN KEY ([Id_Personal]) REFERENCES [dbo].[Personal] ([Id]),
    CONSTRAINT [FK_PersonalNovedades_TipoNovedades] FOREIGN KEY ([Id_TipoNovedad]) REFERENCES [dbo].[TipoNovedades] ([Id])
);

