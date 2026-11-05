CREATE PROCEDURE [dbo].[PlanificacionLargaNovedadesDiarias]
	@Id_Planificacion INT = 0,
	@FechaDesde DATETIME = '20150612',
	@FechaHasta DATETIME = '20190612',
	@Legajo INT = 0
	
AS
BEGIN

	SELECT
		Fecha = pd.Fecha,
		Legajo = p.LaboralLegajo,
		Personal = p.Apellido + ', ' + p.Nombre, 
		Antiguedad = CONVERT(VARCHAR, DATEDIFF(YEAR, p.FechaAlta, GETDATE())) + ' años, ' + CONVERT(VARCHAR, DATEDIFF(MONTH, p.FechaAlta, GETDATE())%12) + ' meses',
		Linea = ISNULL(l.Descripcion, 'Sin Linea'), 
		Novedad = CASE WHEN tn.ALaOrden = 1 THEN 'A la Orden' ELSE ISNULL(tn.DescripcionLarga, 'Sin Servicio/Novedad Asignado/a') END,
		Id_UnidadNegocio = pl.Id_UnidadNegocio,
		UnidadNegocio = u.Descripcion
	FROM PlanificacionLargaDetalles pd
	INNER JOIN PlanificacionLarga pl ON pd.Id_Planificacion = pl.Id
	INNER JOIN UnidadNegocios u ON pl.Id_UnidadNegocio = u. Id
	INNER JOIN Personal p ON pd.Id_Personal = p.Id
	LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id 
	LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT JOIN Lineas l ON r.Id_Linea = l.Id
		WHERE (pd.Id_Planificacion = @Id_Planificacion OR @Id_Planificacion = 0) AND
			  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
			  (pd.Id_CodigoServicioTodos = 0 OR pd.Id_Novedad > 0) AND
			  (p.LaboralLegajo = @Legajo OR @Legajo = 0) AND
			  pl.userdel is null

END