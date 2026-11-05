CREATE TABLE [dbo].[Coches] (
    [Id]                  INT         IDENTITY (1, 1) NOT NULL,
    [Id_Empresa]          INT         NOT NULL,
    [Id_UnidadNegocio]    INT         NULL,
    [Id_TipoServicio]     INT         NULL,
    [Interno]             INT         NOT NULL,
    [Dominio]             VARCHAR (7) NOT NULL,
    [HabilServicioFijo]   INT         CONSTRAINT [DF_Coches_HabilServicioFijo] DEFAULT ((0)) NOT NULL,
    [SabadoServicioFijo]  INT         CONSTRAINT [DF_Coches_SabadoServicioFijo] DEFAULT ((0)) NOT NULL,
    [DomingoServicioFijo] INT         CONSTRAINT [DF_Coches_DomingoServicioFijo] DEFAULT ((0)) NOT NULL,
    [FeriadoServicioFijo] INT         CONSTRAINT [DF_Coches_FeriadoServicioFijo] DEFAULT ((0)) NOT NULL,
    [Marcado]             BIT         CONSTRAINT [DF_Coches_Marcado] DEFAULT ((0)) NULL,
    [FechaAdd]            DATETIME    NOT NULL,
    [FechaMod]            DATETIME    NULL,
    [FechaDel]            DATETIME    NULL,
    [UserAdd]             INT         NOT NULL,
    [UserMod]             INT         NULL,
    [UserDel]             INT         NULL,
    CONSTRAINT [PK_Coches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Coches_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]),
    CONSTRAINT [FK_Coches_UnidadNegocios] FOREIGN KEY ([Id_UnidadNegocio]) REFERENCES [dbo].[UnidadNegocios] ([Id])
);


GO
create TRIGGER [dbo].[ActualizaFlota]
   ON  dbo.Coches
   AFTER  INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	exec ActualizaInternosEnFlota null
END
