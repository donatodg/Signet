CREATE PROCEDURE [dbo].[PlanificacionReportePlanillon]
	@IdTipoServicio INT = 58,
	@Fecha DATETIME = '20151005'

AS
BEGIN

	DECLARE @IdDiagrama INT 
	DECLARE @IdPlanificacion INT 

	--busco que diagrama tiene asigando en esa fecha esa linea
	SELECT @IdDiagrama = ps.Id_Diagrama, @IdPlanificacion = p.Id
		FROM PlanificacionServicios ps INNER JOIN Planificacion p ON ps.Id_Planificacion = p.Id
			WHERE ps.Id_TipoServicio = @IdTipoServicio AND 
				  ps.Fecha = @Fecha AND 
				  p.UserDel IS NULL

	--SERVICIOS, TURNO, VUELTA SALIDA, LLEGUE
	SELECT 
		T1.NroServicio, 
		Interno = ISNULL(T2.Interno, 0),
		T1.Turno,
		T1.NroVuelta,
		T1.ServicioTome,
		T1.ServicioDeje,
		Personal = CASE WHEN T3.LaboralLegajo IS NULL THEN CONVERT(VARCHAR, T1.Turno) + '-A CONFIRMAR' ELSE CONVERT(VARCHAR,T3.LaboralLegajo) + '-' + t3.Apellido + ', ' + T3.Nombre END,
		Comentario,
		MV
	FROM 
		(SELECT 
			dd.NroServicio,
			dd.Turno, 
			NroVuelta,
			Comentario = MIN(dd.Comentario), 
			MV = ISNULL((SELECT TOP 1 d.Id
			 				FROM Diagramas_Detalle d
			 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 				WHERE d.NroServicio = dd.NroServicio AND 
				 				  d.Id_Diagrama = @IdDiagrama AND
				 				  d.Turno = dd.Turno AND
				 				  d.UserDel IS NULL AND
				 				  d.NroVuelta = dd.NroVuelta AND
								  s.IdaVuelta = 'I' AND
								  Hora > '20010101 00:00'), 0),
			ServicioTome = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 				FROM Diagramas_Detalle d
			 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 				WHERE d.NroServicio = dd.NroServicio AND 
				 				  d.Id_Diagrama = @IdDiagrama AND
				 				  d.Turno = dd.Turno AND
				 				  d.UserDel IS NULL AND
				 				  d.NroVuelta = dd.NroVuelta AND
								  s.IdaVuelta = 'I' AND
								  Hora > '20010101 00:00'
			 				ORDER BY Turno, NroVuelta, Numero), (SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 													 FROM Diagramas_Detalle d
			 													 INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 													 WHERE d.NroServicio = dd.NroServicio AND 
				 											   		   d.Id_Diagrama = @IdDiagrama AND
				 													   d.Turno = dd.Turno AND
				 													   d.UserDel IS NULL AND
				 													   d.NroVuelta = dd.NroVuelta AND
																	   s.IdaVuelta = 'V' AND
																	   Hora > '20010101 00:00'
			 													ORDER BY Turno, NroVuelta, Numero)),
			ServicioDeje = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 				FROM Diagramas_Detalle d
			 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 				WHERE d.NroServicio = dd.NroServicio AND 
				 				  d.Id_Diagrama = @IdDiagrama AND
				 				  d.Turno = dd.Turno AND
				 				  d.UserDel IS NULL AND
				 				  d.NroVuelta = dd.NroVuelta AND
								  s.IdaVuelta = 'V' AND
								  Hora > '20010101 00:00'
			 				ORDER BY Turno, NroVuelta desc, Numero desc), (SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 																FROM Diagramas_Detalle d
			 																INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 																WHERE d.NroServicio = dd.NroServicio AND 
				 																  d.Id_Diagrama = @IdDiagrama AND
				 																  d.Turno = dd.Turno AND
				 																  d.UserDel IS NULL AND
				 																  d.NroVuelta = dd.NroVuelta AND
																				  s.IdaVuelta = 'I' AND
																				  Hora > '20010101 00:00'
			 																ORDER BY Turno, NroVuelta desc, Numero desc))
		FROM Diagramas_Detalle dd
		INNER JOIN Diagramas_Servicios ds ON dd.Id_Diagrama = ds.Id_Diagrama AND dd.NroServicio = ds.NroServicio AND dd.Turno = dd.Turno
			WHERE dd.Id_Diagrama = @IdDiagrama AND
				  dd.UserDel IS NULL AND
				  ds.UserDel IS NULL
		GROUP BY dd.NroServicio, dd.Turno, dd.NroVuelta) T1

	LEFT JOIN (	 
		SELECT ds.NroServicio, c.Interno 
		FROM Diagramas_Servicios ds 
		INNER JOIN PlanificacionDetallesCoches pdc ON pdc.Id_Servicio = ds.Id
		INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		WHERE pdc.Id_Planificacion = @IdPlanificacion AND 
		 	  pdc.Fecha = @Fecha AND 
		 	  --(pdc.Id_Diagrama = @IdDiagrama AND 
		 	  pdc.Id_Servicio IN (SELECT Id FROM Diagramas_Servicios WHERE Id_Diagrama = @IdDiagrama AND UserDel IS NULL) AND
		 	  ds.UserDel IS NULL
		) AS T2 ON T1.NroServicio = T2.NroServicio

	LEFT JOIN (
		SELECT ds.Turno, 
			   ds.NroServicio, 
			   p.LaboralLegajo, 
			   p.Apellido, 
			   p.Nombre 
		FROM PlanificacionDetalles pd 
		INNER JOIN Personal p on pd.Id_Personal = p.Id
		INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		WHERE Id_Planificacion = @IdPlanificacion AND 
			  --Id_TipoServicio = @IdTipoServicio AND 
			  Id_Diagrama = @IdDiagrama AND 
		 	  ds.UserDel IS NULL AND
			  Fecha = @Fecha
		) AS T3 ON T3.NroServicio = T1.NroServicio AND T3.Turno = T1.Turno

	ORDER BY T1.NroServicio, T1.NroVuelta

END