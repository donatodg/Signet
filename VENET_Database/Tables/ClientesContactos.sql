CREATE TABLE [dbo].[ClientesContactos] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Id_Cliente] INT           NOT NULL,
    [Nombre]     VARCHAR (200) NOT NULL,
    [Telefono1]  VARCHAR (50)  NULL,
    [Telefono2]  VARCHAR (50)  NULL,
    [Email]      VARCHAR (50)  NULL,
    [FechaAdd]   DATETIME      NOT NULL,
    [FechaMod]   DATETIME      NULL,
    [FechaDel]   DATETIME      NULL,
    [UserAdd]    INT           NOT NULL,
    [UserMod]    INT           NULL,
    [UserDel]    INT           NULL,
    CONSTRAINT [PK_ClientesContactos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientesContactos_Clientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id])
);

