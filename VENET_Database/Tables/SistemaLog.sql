CREATE TABLE [dbo].[SistemaLog] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]     INT          NOT NULL,
    [Accion]         INT          NOT NULL,
    [Fecha]          DATETIME     NOT NULL,
    [Host]           VARCHAR (50) NOT NULL,
    [UserLocal]      VARCHAR (50) NOT NULL,
    [IPLocal]        VARCHAR (50) NOT NULL,
    [IPPublica]      VARCHAR (50) NOT NULL,
    [BaseDatos]      VARCHAR (50) NOT NULL,
    [VersionSistema] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SistemaLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SistemaLog_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1-Entra, 0-Sale', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SistemaLog', @level2type = N'COLUMN', @level2name = N'Accion';

