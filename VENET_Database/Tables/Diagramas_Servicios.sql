CREATE TABLE [dbo].[Diagramas_Servicios] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [NroServicio]      INT             NOT NULL,
    [Id_Diagrama]      INT             NOT NULL,
    [Turno]            INT             NOT NULL,
    [HoraCitacion]     DATETIME        NOT NULL,
    [HoraFinalizacion] DATETIME        NOT NULL,
    [Horas]            AS              (case when [HoraFinalizacion]<[HoraCitacion] then dateadd(minute,datediff(minute,'2001-01-01 00:00',[HoraFinalizacion])+datediff(minute,[HoraCitacion],'2001-02-01 00:00'),'19000101') else [HoraFinalizacion]-[HoraCitacion] end),
    [Kms]              DECIMAL (18, 2) CONSTRAINT [DF_Diagramas_Servicios_Kms] DEFAULT ((0)) NOT NULL,
    [Codigo]           VARCHAR (10)    NOT NULL,
    [Comentario]       VARCHAR (50)    CONSTRAINT [DF_Diagramas_Servicios_Comentario] DEFAULT ('') NOT NULL,
    [FechaAdd]         DATETIME        NOT NULL,
    [FechaMod]         DATETIME        NULL,
    [FechaDel]         DATETIME        NULL,
    [UserAdd]          INT             NOT NULL,
    [UserMod]          INT             NULL,
    [UserDel]          INT             NULL,
    CONSTRAINT [PK_Diagramas_Servicios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diagramas_Servicios_Diagramas] FOREIGN KEY ([Id_Diagrama]) REFERENCES [dbo].[Diagramas] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [Diagramas_Servicios]
    ON [dbo].[Diagramas_Servicios]([NroServicio] ASC, [Id_Diagrama] ASC, [Turno] ASC);

