CREATE PROCEDURE [dbo].[PlanificacionDiagramaServicios]
	@FechaDesde DATE = '20150501',
	@FechaHasta DATE = '20150531',
	@IdPersonal INT = 4045,
	@IdPlanificacion INT = 190
AS
BEGIN

	SELECT Legajo = p.LaboralLegajo,
		   Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		   Fecha = CONVERT(VARCHAR, Fecha, 103), 
		   Servicios = ISNULL(CONVERT(VARCHAR, ds.NroServicio), ISNULL(tn.DescripcionLarga, '')),
		   Turno = ISNULL(CONVERT(VARCHAR,ds.Turno), ''), 
		   Citacion =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		   Servicio = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
					   FROM Diagramas_Detalle d
					   INNER JOIN Secciones s ON d.Id_Seccion = s.Id
					   WHERE d.NroServicio = ds.NroServicio AND 
							 d.Id_Diagrama = ds.Id_Diagrama AND
							 d.Hora > '20010101 00:00' AND
							 d.Turno = ds.Turno AND
							 d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = ds.Turno AND UserDel IS NULL) AND
							 d.UserDel IS NULL AND
							 s.UserDel IS NULL
					   ORDER BY IdaVuelta,Numero), ''),
			Linea = ISNULL(l.DescripcionCorta, ''),
			Lugar = CASE WHEN tn.ALaOrden = '1' THEN 'BASE' ELSE
					CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + 
					ISNULL((SELECT TOP 1 s.Descripcion
					 FROM Diagramas_Detalle d
					 INNER JOIN Secciones s ON d.Id_Seccion = s.Id
					 WHERE d.NroServicio = ds.NroServicio AND 
						   d.Id_Diagrama = ds.Id_Diagrama AND
						   d.Hora > '20010101 00:00' AND
						   d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = ds.Turno AND UserDel IS NULL) AND
						   d.Turno = ds.Turno AND
						   d.UserDel IS NULL AND
						   s.UserDel IS NULL
					 ORDER BY IdaVuelta,Numero), '') END
	FROM PlanificacionDetalles pd
	LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
	INNER JOIN Personal p ON pd.Id_Personal = p.Id
		WHERE pd.Id_Planificacion = @IdPlanificacion AND
			  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
			  ds.UserDel IS NULL AND
			  pd.UserDel IS NULL AND
			  ds.UserDel IS NULL AND
			  ts.UserDel IS NULL AND
			  tn.UserDel IS NULL AND
			  r.UserDel IS NULL AND
			  l.UserDel IS NULL AND
			  p.UserDel IS NULL AND
			  pd.Id_Personal = @IdPersonal
	ORDER BY pd.Fecha

END
