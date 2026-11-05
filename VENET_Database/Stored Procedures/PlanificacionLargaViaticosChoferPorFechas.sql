CREATE PROCEDURE [dbo].[PlanificacionLargaViaticosChoferPorFechas]
	@Id_Planificacion INT = 5,
	@FechaDesde DATETIME = '20151101',
	@FechaHasta DATETIME = '20151130',
	@IdPersonal INT = 0
	
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT
		Fecha = pld.Fecha,
		Legajo = p.LaboralLegajo,
		Personal = p.Apellido + ', ' + p.Nombre,
		Codigo = ISNULL(cs.Codigo, ''),
		Descripcion = ISNULL(cs.Descripcion, t.DescripcionLarga),
		Id_CodigoServicio = ISNULL(cs.Id, 0),
		Viatico = ISNULL(tv.Descripcion, ''),
		Cantidad = ISNULL(csv.Cantidad, 0),
		Importe = ISNULL(tvp.Importe, 0),
		Total = ISNULL(csv.Cantidad * tvp.Importe, 0),
		Id_Planificacion = pld.Id_Planificacion,
		Id_TipoServicio = pld.Id_TipoServicio,
		Id_Personal = p.Id,
		Linea = ISNULL(l.Descripcion, ''),
		Cabecera = ISNULL(c.Descripcion, '')
	FROM PlanificacionLargaDetalles pld
	LEFT JOIN TipoNovedades t ON pld.Id_Novedad = t.Id
	LEFT JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	LEFT JOIN CodigosServicios cs ON cst.Id_CodigoServicio = cs.Id
	LEFT JOIN CodigosServiciosViaticos csv ON cs.Id = csv.Id_CodigoServicio
	LEFT JOIN TipoViaticos tv ON csv.Id_TipoViatico = tv.Id
	INNER JOIN Personal p ON pld.Id_Personal = p.Id
	LEFT JOIN TipoViaticosPrecios tvp ON tv.Id = tvp.Id_TipoViatico AND pld.Fecha BETWEEN tvp.VigenciaDesde AND tvp.VigenciaHasta
	LEFT JOIN Cabeceras c ON p.LaboralId_Cabecera = c.Id
	LEFT JOIN Lineas l ON c.Id_Linea = l.Id
	WHERE p.Id_Jerarquia = 1 AND
		  pld.Id_Planificacion = @Id_Planificacion AND
		  pld.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
		  (p.Id = @IdPersonal OR @IdPersonal = 0) AND
	      pld.UserDel IS NULL
 
 END