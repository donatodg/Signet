CREATE PROCEDURE [dbo].[ProductosMovimientos]
	@Id_Producto INT = 0,
	@FechaDesde DATETIME = '20150101',
	@FechaHasta DATETIME = '20160606'
	
AS
BEGIN

	SELECT * FROM
	(SELECT 
		Fecha = cc.FechaLiquidacion,
		Entidad = CASE WHEN Id_TipoEntidad = 1 THEN 'Cliente'
					   WHEN Id_TipoEntidad = 2 THEN 'Proveedor'
					   WHEN Id_TipoEntidad = 3 THEN 'Prov.Financiero'
					   WHEN Id_TipoEntidad = 4 THEN 'Personal' END,
		Nombre = CASE WHEN Id_TipoEntidad = 1 THEN (SELECT Nombre FROM Clientes WHERE Id = cc.Id_Entidad)
					  WHEN Id_TipoEntidad = 2 THEN (SELECT Nombre FROM Proveedores WHERE Id = cc.Id_Entidad)  
					  WHEN Id_TipoEntidad = 3 THEN (SELECT Nombre FROM ProvFinancieros WHERE Id = cc.Id_Entidad) 
					  WHEN Id_TipoEntidad = 4 THEN (SELECT Apellido + ', ' + Nombre FROM Personal WHERE Id = cc.Id_Entidad) END,
		Tipo = 'Compra',
		Comprobante = tc.Descripcion,
		Id_Comprobante = cc.Id,
		ccd.Id_Especie,
		Especie = e.Descripcion,
		ccd.Cotizacion,
		ccd.Descripcion,
		ccd.Cantidad,
		ccd.PorcDescuento,
		ccd.ImporteUnitario,
		ccd.Id_AlicuotaIva,
		ccd.AlicuotaIva,
		ccd.ImporteIVA,
		ccd.Importe,
		p.Codigo,
		p.CodigoBarras,
		p.CodigoFabrica
		FROM Productos p
		INNER JOIN Especies e ON p.Id_Especie = e.Id
		INNER JOIN IvaAlicuotas i ON p.Id_IvaAlicuota = i.Id
		INNER JOIN ComprobantesComprasDetalle ccd ON p.Id = ccd.Id_Producto
		INNER JOIN ComprobantesCompras cc ON ccd.Id_ComprobanteCompra = cc.Id
		INNER JOIN TipoComprobante tc ON cc.Id_TipoComprobante = tc.Id
		WHERE (p.Id = @Id_Producto OR @Id_Producto = 0)
			  AND cc.FechaLiquidacion BETWEEN @FechaDesde AND @FechaHasta
			  AND cc.FechaLiquidacion IS NOT NULL
			  AND ccd.Id_Producto > 0
			  AND cc.UserDel IS NULL
			  AND ccd.UserDel IS NULL
			  AND p.UserDel IS NULL

	UNION
	
	SELECT 
		Fecha = cc.FechaLiquidacion,
		Entidad = CASE WHEN Id_TipoEntidad = 1 THEN 'Cliente'
					   WHEN Id_TipoEntidad = 2 THEN 'Proveedor'
					   WHEN Id_TipoEntidad = 3 THEN 'Prov.Financiero'
					   WHEN Id_TipoEntidad = 4 THEN 'Personal' END,
		Nombre = CASE WHEN Id_TipoEntidad = 1 THEN (SELECT Nombre FROM Clientes WHERE Id = cc.Id_Entidad)
					  WHEN Id_TipoEntidad = 2 THEN (SELECT Nombre FROM Proveedores WHERE Id = cc.Id_Entidad)  
					  WHEN Id_TipoEntidad = 3 THEN (SELECT Nombre FROM ProvFinancieros WHERE Id = cc.Id_Entidad) 
					  WHEN Id_TipoEntidad = 4 THEN (SELECT Apellido + ', ' + Nombre FROM Personal WHERE Id = cc.Id_Entidad) END,
		Tipo = 'Venta',
		Comprobante = tc.Descripcion,
		Id_Comprobante = cc.Id,
		ccd.Id_Especie,
		Especie = e.Descripcion,
		ccd.Cotizacion,
		ccd.Descripcion,
		ccd.Cantidad,
		ccd.PorcDescuento,
		ccd.ImporteUnitario,
		ccd.Id_AlicuotaIva,
		ccd.AlicuotaIva,
		ccd.ImporteIVA,
		ccd.Importe,
		p.Codigo,
		p.CodigoBarras,
		p.CodigoFabrica
		FROM Productos p
		INNER JOIN Especies e ON p.Id_Especie = e.Id
		INNER JOIN IvaAlicuotas i ON p.Id_IvaAlicuota = i.Id
		INNER JOIN ComprobantesVentasDetalle ccd ON p.Id = ccd.Id_Producto
		INNER JOIN ComprobantesVentas cc ON ccd.Id_ComprobanteVenta = cc.Id
		INNER JOIN TipoComprobante tc ON cc.Id_TipoComprobante = tc.Id
		WHERE (p.Id = @Id_Producto OR @Id_Producto = 0)
			  AND cc.FechaLiquidacion BETWEEN @FechaDesde AND @FechaHasta
			  AND cc.FechaLiquidacion IS NOT NULL
			  AND ccd.Id_Producto > 0
			  AND cc.UserDel IS NULL
			  AND ccd.UserDel IS NULL
			  AND p.UserDel IS NULL) AS T
	ORDER BY FECHA

END

 