CREATE PROCEDURE [dbo].[ReporteVueltasPorPlanificacion]
	@Id_Planificacion INT = 598, 
	@FechaDesde DATETIME = '20160218',
	@FechaHasta DATETIME = '20160218'

AS
BEGIN
	SELECT  
		Fecha,
		Linea,
		Ramal,
		Servicio,
		Diagrama,
		Id_Diagrama = Id_Diagrama,
		Servicios = COUNT(DISTINCT NroServicio),
		Turnos = COUNT(DISTINCT Turno),
		MediasVueltas = COUNT(DISTINCT NroVuelta) / 2
	FROM
		(SELECT  
			Fecha,
			Linea = l.Descripcion,
			Ramal = r.Descripcion,
			Servicio = ts.Descripcion,
			Diagrama = d.Descripcion,
			Id_Diagrama = dd.Id_Diagrama, 
			NroServicio,
			Turno = CONVERT(VARCHAR, NroServicio) + CONVERT(VARCHAR, Turno),
			NroVuelta =  CONVERT(VARCHAR, NroServicio) + CONVERT(VARCHAR, Turno) + CONVERT(VARCHAR, NroVuelta) + CONVERT(VARCHAR, s.IdaVuelta)
		FROM PlanificacionServicios ps
		INNER JOIN Diagramas d ON ps.Id_Diagrama = d.Id
		INNER JOIN Diagramas_Detalle dd ON d.id = dd.id_diagrama
		INNER JOIN TipoServicios ts ON ps.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
	    INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
		WHERE ps.Id_Planificacion = @Id_Planificacion
			 AND dd.UserDel IS NULL
			 AND ps.Fecha BETWEEN  @FechaDesde AND @FechaHasta
		GROUP BY d.Descripcion, dd.Id_Diagrama, dd.NroServicio, dd.Turno, dd.NroVuelta, Fecha, l.Descripcion, r.Descripcion, ts.Descripcion, s.IdaVuelta) AS t 
		GROUP BY Id_Diagrama, Diagrama, Fecha, Linea, Ramal, Servicio
	ORDER BY Fecha, Servicio

END
