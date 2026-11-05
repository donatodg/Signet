CREATE PROCEDURE [dbo].[PlanificacionLargaDiagramaServicios]
	@FechaDesde DATE = '20151220',
	@FechaHasta DATE = '20151223',
	@IdPersonal INT = 5623,
	@IdPlanificacion INT = 11
AS
BEGIN

	SELECT Legajo = p.LaboralLegajo,
		   Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		   Fecha = CONVERT(VARCHAR, Fecha, 103), 
		   Turno = ISNULL(CONVERT(VARCHAR, cs.Codigo), ''), 
		   Citacion =  ISNULL(LEFT(CONVERT(VARCHAR, cs.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		   Servicio = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, csvd1.Hora, 114), 5)
					  FROM CodigosServicios cs1
				      INNER JOIN CodigosServiciosVueltas csv1 ON cs1.Id = csv1.Id_CodigoServicio
					  INNER JOIN CodigosServiciosVueltasDetalle csvd1 ON csv1.Id = csvd1.Id_CodigoServicioVuelta
					  WHERE cs1.Id = cs.Id
						    AND cs1.UserDel IS NULL
							AND csv1.UserDel IS NULL
							AND csvd1.UserDel IS NULL
					  ORDER BY NroVuelta ASC, Dia ASC, Hora ASC), ''),
		   Finalizacion = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, csvd1.Hora, 114), 5)
						  FROM CodigosServicios cs1
						  INNER JOIN CodigosServiciosVueltas csv1 ON cs1.Id = csv1.Id_CodigoServicio
						  INNER JOIN CodigosServiciosVueltasDetalle csvd1 ON csv1.Id = csvd1.Id_CodigoServicioVuelta
						  WHERE cs1.Id = cs.Id
							    AND cs1.UserDel IS NULL
								AND csv1.UserDel IS NULL
								AND csvd1.UserDel IS NULL
						  ORDER BY NroVuelta DESC, Dia DESC, Hora DESC), ''),
			Linea = ISNULL(CONVERT(VARCHAR, l.DescripcionCorta),  ISNULL(tn.DescripcionLarga, '')),
			Lugar = CASE WHEN tn.ALaOrden = '1' THEN '' ELSE
					--CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + 
					--ISNULL((SELECT TOP 1 s.Descripcion
					--  FROM CodigosServicios cs1
				 --     INNER JOIN CodigosServiciosVueltas csv1 ON cs1.Id = csv1.Id_CodigoServicio
					--  INNER JOIN CodigosServiciosVueltasDetalle csvd1 ON csv1.Id = csvd1.Id_CodigoServicioVuelta
					--  INNER JOIN Secciones s ON s.Id = csvd1.Id_Seccion
					--  WHERE cs1.Id = cs.Id
					--  ORDER BY Dia ASC, Hora ASC), '') 
					 cs.Descripcion
					  END,
			Comentario = cs.Comentario
	FROM PlanificacionLargaDetalles pld
	LEFT JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	LEFT JOIN CodigosServicios cs ON cst.Id_CodigoServicio = cs.Id
	LEFT JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	LEFT JOIN TipoNovedades tn ON pld.Id_Novedad = tn.Id
	INNER JOIN Personal p ON pld.Id_Personal = p.Id
		WHERE pld.Id_Planificacion = @IdPlanificacion AND
			  pld.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
			  cs.UserDel IS NULL AND
			  pld.UserDel IS NULL AND
			  ts.UserDel IS NULL AND
			  tn.UserDel IS NULL AND
			  r.UserDel IS NULL AND
			  l.UserDel IS NULL AND
			  p.UserDel IS NULL AND
			  pld.Id_Personal = @IdPersonal
	ORDER BY pld.Fecha

END