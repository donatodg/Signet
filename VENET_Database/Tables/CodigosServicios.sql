CREATE TABLE [dbo].[CodigosServicios] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [Id_TipoServicio]       INT          NOT NULL,
    [Id_TipoCodigoServicio] INT          NOT NULL,
    [Codigo]                VARCHAR (5)  NOT NULL,
    [Descripcion]           VARCHAR (50) NOT NULL,
    [Comentario]            VARCHAR (50) NULL,
    [VigenciaDesde]         DATETIME     NOT NULL,
    [VigenciaHasta]         DATETIME     NULL,
    [HsPorVuelta]           BIT          NOT NULL,
    [HoraCitacion]          DATETIME     NOT NULL,
    [HoraFinalizacion]      DATETIME     NOT NULL,
    [CantidadChoferes]      INT          NOT NULL,
    [Auxiliar]              BIT          NOT NULL,
    [Id_Jurisdiccion]       INT          NOT NULL,
    [Lunes]                 BIT          NOT NULL,
    [Martes]                BIT          NOT NULL,
    [Miercoles]             BIT          NOT NULL,
    [Jueves]                BIT          NOT NULL,
    [Viernes]               BIT          NOT NULL,
    [Sabado]                BIT          NOT NULL,
    [Domingo]               BIT          NOT NULL,
    [Feriado]               BIT          NOT NULL,
    [HsTomeDeje]            DATETIME     NOT NULL,
    [HsSimple]              DATETIME     NOT NULL,
    [Hs50]                  DATETIME     NOT NULL,
    [Hs100]                 DATETIME     NOT NULL,
    [HsPlus]                DATETIME     NOT NULL,
    [HsTomeDeje1]           DATETIME     NOT NULL,
    [HsSimple1]             DATETIME     NOT NULL,
    [Hs501]                 DATETIME     NOT NULL,
    [Hs1001]                DATETIME     NOT NULL,
    [HsPlus1]               DATETIME     NOT NULL,
    [FechaAdd]              DATETIME     NOT NULL,
    [FechaMod]              DATETIME     NULL,
    [FechaDel]              DATETIME     NULL,
    [UserAdd]               INT          NOT NULL,
    [UserMod]               INT          NULL,
    [UserDel]               INT          NULL,
    CONSTRAINT [PK_CodigosServicios] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CodigosServicios_Jurisdicciones] FOREIGN KEY ([Id_Jurisdiccion]) REFERENCES [dbo].[Jurisdicciones] ([Id]),
    CONSTRAINT [FK_CodigosServicios_TipoServicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id])
);


GO
CREATE TRIGGER [dbo].[CreaCodigosServicios] 
   ON  dbo.CodigosServicios
   AFTER INSERT,DELETE,UPDATE 
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @Id INT
	DECLARE @Ids INT
	DECLARE @Codigo Varchar(5)
	DECLARE @Cantidad INT
	DECLARE @Auxiliar INT
	DECLARE @I INT = 1
	
	SELECT @Id = Id, @Codigo = Codigo, @Cantidad = CantidadChoferes, @Auxiliar = Auxiliar FROM inserted

    DELETE CodigosServiciosTodos WHERE Id_CodigoServicio = @Id
    
    IF @Auxiliar = 1
		INSERT INTO CodigosServiciosTodos (Id, Id_CodigoServicio, Codigo) VALUES (@Id + 900000000, @Id, @Codigo + '/A')
	
	SET @Ids = @Id 
	
	WHILE (@I <= @Cantidad)
    BEGIN
		SET @Ids = @Ids + 100000000
		INSERT INTO CodigosServiciosTodos (Id, Id_CodigoServicio, Codigo) VALUES (@Ids, @Id, @Codigo + '/' + CONVERT(VARCHAR,@I))
        SET @I = @I + 1
    END
    
END
