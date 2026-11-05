CREATE TABLE [dbo].[SeguridadUsuariosConfiguracion] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]  INT           NOT NULL,
    [Id_Tile]     INT           NOT NULL,
    [Color1]      VARCHAR (100) NULL,
    [Color2]      VARCHAR (100) NULL,
    [ColorFuente] VARCHAR (100) NULL,
    [Visible]     BIT           CONSTRAINT [DF_SeguridadUsuariosConfiguracion_Visible] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_SeguridadUsusariosConfiguracion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeguridadUsuariosConfiguracion_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id])
);

