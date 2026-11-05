CREATE TABLE [dbo].[usuarios] (
    [idUsuario] INT        NOT NULL,
    [usuario]   NCHAR (15) NOT NULL,
    [password]  NCHAR (15) NOT NULL,
    [rol]       INT        NOT NULL,
    [session]   INT        NOT NULL
);

