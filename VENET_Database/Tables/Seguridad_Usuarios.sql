CREATE TABLE [dbo].[Seguridad_Usuarios] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Id_Grupo]      INT          NOT NULL,
    [Username]      VARCHAR (50) NOT NULL,
    [Apellido]      VARCHAR (50) NOT NULL,
    [Nombre]        VARCHAR (50) NOT NULL,
    [Clave]         VARCHAR (50) NOT NULL,
    [Activo]        BIT          NOT NULL,
    [Email]         VARCHAR (50) NULL,
    [Id_Sucursal]   INT          CONSTRAINT [DF_Seguridad_Usuarios_Id_Sucursal] DEFAULT ((0)) NULL,
    [Id_PuntoVenta] INT          NULL,
    [FechaAdd]      DATETIME     NOT NULL,
    [FechaMod]      DATETIME     NULL,
    [FechaDel]      DATETIME     NULL,
    [UserAdd]       INT          NOT NULL,
    [UserMod]       INT          NULL,
    [UserDel]       INT          NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seguridad_Usuarios_Seguridad_Grupos] FOREIGN KEY ([Id_Grupo]) REFERENCES [dbo].[Seguridad_Grupos] ([Id])
);

