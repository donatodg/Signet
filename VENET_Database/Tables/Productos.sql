CREATE TABLE [dbo].[Productos] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Codigo]         VARCHAR (100)   NOT NULL,
    [CodigoFabrica]  VARCHAR (100)   NULL,
    [Descripcion]    VARCHAR (500)   NOT NULL,
    [Id_IvaAlicuota] INT             NOT NULL,
    [Id_Categoria]   INT             NOT NULL,
    [Id_UnidadVenta] INT             NOT NULL,
    [CodigoBarras]   VARCHAR (100)   NULL,
    [Id_Especie]     INT             NOT NULL,
    [Importe]        DECIMAL (18, 2) NOT NULL,
    [ImporteCosto]   DECIMAL (18, 2) NOT NULL,
    [StockMinimo]    INT             CONSTRAINT [DF_Productos_Stock_Minimo] DEFAULT ((0)) NOT NULL,
    [StockMaximo]    INT             CONSTRAINT [DF_Productos_Stock_Maximo] DEFAULT ((0)) NOT NULL,
    [Observaciones]  VARCHAR (8000)  NULL,
    [FechaAdd]       DATETIME        NOT NULL,
    [FechaMod]       DATETIME        NULL,
    [FechaDel]       DATETIME        NULL,
    [UserAdd]        INT             NOT NULL,
    [UserMod]        INT             NULL,
    [UserDel]        INT             NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Productos_IvaAlicuotas] FOREIGN KEY ([Id_IvaAlicuota]) REFERENCES [dbo].[IvaAlicuotas] ([Id]),
    CONSTRAINT [FK_Productos_ProductosCategorias] FOREIGN KEY ([Id_Categoria]) REFERENCES [dbo].[ProductosCategorias] ([Id]),
    CONSTRAINT [FK_Productos_ProductosUnidadVenta] FOREIGN KEY ([Id_UnidadVenta]) REFERENCES [dbo].[ProductosUnidadVenta] ([Id])
);


GO
CREATE TRIGGER dbo.ProductosHistoricos ON Productos
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	
	DECLARE @Id INT,
			@ImporteAnt DECIMAL(18,2),
			@ImporteCostoAnt DECIMAL(18,2),
			@ImporteNuevo DECIMAL(18,2),
			@ImporteCostoNuevo DECIMAL(18,2),
			@Fecha DATETIME,
			@User INT
		
	SELECT @ImporteAnt = Importe, @ImporteCostoAnt = ImporteCosto FROM deleted

	SELECT @Id = Id, @ImporteNuevo = Importe, @ImporteCostoNuevo = ImporteCosto, @Fecha = FechaMod, @User = UserMod FROM inserted

	IF @ImporteAnt <> @ImporteNuevo OR @ImporteCostoAnt <> @ImporteCostoNuevo
	BEGIN
		IF @User IS NULL
			SELECT @Fecha = FechaAdd, @User = UserAdd FROM inserted
		
		INSERT INTO ProductosPreciosHistorico (Id_Producto, Importe, ImporteCosto, FechaAdd, UserAdd)
			VALUES (@Id, @ImporteNuevo, @ImporteCostoNuevo, @Fecha, @User)
	END		

END