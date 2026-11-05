CREATE PROCEDURE ProductosStock
	@Id_Producto INT = 0
	
AS
BEGIN

	SELECT 
	p.*,
	Especie = e.Descripcion,
	Alicuota = i.Alicuota,
	Ingresos = (SELECT SUM(ccd.Cantidad)
				FROM ComprobantesComprasDetalle ccd
				INNER JOIN ComprobantesCompras cc ON ccd.Id_ComprobanteCompra = cc.Id
				INNER JOIN TipoComprobante tc ON cc.Id_TipoComprobante = tc.Id
				WHERE tc.MueveStock = 1
					AND ccd.Id_Producto = p.Id
					AND ccd.UserDel IS NULL   
					AND cc.UserDel IS NULL
					AND cc.FechaAnulacion IS NULL
					AND cc.FechaLiquidacion IS NOT NULL),
	Egresos = (SELECT SUM(cvd.Cantidad)
				FROM ComprobantesVentasDetalle cvd
				INNER JOIN ComprobantesVentas cv ON cvd.Id_ComprobanteVenta = cv.Id
				INNER JOIN TipoComprobante tc ON cv.Id_TipoComprobante = tc.Id
				WHERE tc.MueveStock = 1
					AND cvd.Id_Producto = p.Id
					AND cvd.UserDel IS NULL   
					AND cv.UserDel IS NULL
					AND cv.FechaAnulacion IS NULL
					AND cv.FechaLiquidacion IS NOT NULL)
	FROM Productos p
	INNER JOIN Especies e ON p.Id_Especie = e.Id
	INNER JOIN IvaAlicuotas i ON p.Id_IvaAlicuota = i.Id
	WHERE (p.Id = @Id_Producto OR @Id_Producto = 0)
		  AND p.UserDel IS NULL

END