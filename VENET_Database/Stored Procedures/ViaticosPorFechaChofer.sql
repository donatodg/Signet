CREATE PROCEDURE [dbo].[ViaticosPorFechaChofer]
	@Id_Planificacion INT = 5

AS
BEGIN

	SELECT
		Cabecera = '',
		Empresa = e.Nombre,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Id_Empresa = e.Id,
		Id_Linea = l.Id,
		Id_Ramal = r.Id,
		Id_TipoServicio = ts.Id,
		Id_Planificacion = pld.Id_Planificacion,
		Id_Personal = p.Id,
		Personal = p.Apellido + ', ' + p.Nombre,
		Legajo = p.LaboralLegajo,
		Fecha = pld.Fecha,
		Id_Servicio = cs.Id,
		Codigo = cs.Codigo,
		Servicio = cs.Descripcion,
		CantViaticos = COUNT(tvp.Id),
		Viaticos= (SELECT ISNULL(STUFF((SELECT CAST(', ' AS VARCHAR(MAX)) +  tv.Descripcion 
										FROM CodigosServiciosViaticos csv
										INNER JOIN TipoViaticos tv ON csv.Id_TipoViatico = tv.Id
										WHERE csv.UserDel IS NULL AND csv.Id_CodigoServicio = cs.id
										FOR XML PATH('')), 1, 1, ''), '')),
		Total = SUM(tvp.Importe)
	FROM PlanificacionLargaDetalles pld 
	INNER JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	INNER JOIN CodigosServicios cs ON cst.Id_CodigoServicio = cs.Id
	INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN lineas l ON r.Id_Linea = l.Id
	INNER JOIN Empresas e ON l.Id_Empresa = e.Id
	INNER JOIN Personal p ON pld.Id_Personal = p.Id
	INNER JOIN CodigosServiciosViaticos csv ON cs.Id = csv.Id_CodigoServicio
	INNER JOIN TipoViaticos tv ON csv.Id_TipoViatico = tv.Id
	INNER JOIN TipoViaticosPrecios tvp ON tv.Id	= tvp.Id_TipoViatico AND pld.Fecha BETWEEN tvp.VigenciaDesde AND tvp.VigenciaHasta
	WHERE pld.Id_Planificacion = @Id_Planificacion
		  AND pld.UserDel IS NULL
		  AND cs.UserDel IS NULL
		  AND csv.UserDel IS NULL
		  AND tv.UserDel IS NULL
		  AND tvp.UserDel IS NULL
	GROUP BY e.Nombre, l.Descripcion, r.Descripcion, ts.Descripcion, e.Id, l.Id, r.Id, ts.Id, pld.Id_Planificacion,  p.Id, p.Apellido, p.Nombre, p.LaboralLegajo, pld.Fecha, cs.Id, cs.Codigo, cs.Descripcion  
 
 END