CREATE PROCEDURE [dbo].[PlanificacionLanzamientoGeneral2]
	@IdPlanificacion INT = 229,
	@Fecha DATE = '20150607'
 
AS
BEGIN

	SELECT * FROM (SELECT 
		Interno = CONVERT(VARCHAR(MAX), c.Interno),
		Novedad = CASE WHEN pd.Id_NovedadCoche = 0 THEN ISNULL(' Línea: ' + l.DescripcionCorta, ' Sin Línea') ELSE n.DescripcionLarga END
			FROM PlanificacionDetallesCoches PD 
			INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
			INNER JOIN Coches c ON pd.Id_Coche = c.Id
			LEFT JOIN TipoNovedadesCoches n ON pd.Id_NovedadCoche = n.Id
			LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
			LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
			LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				WHERE pd.Id_Planificacion = @IdPlanificacion AND
					  pd.Fecha = @Fecha AND 
					  Id_Servicio = 0 AND
					  Interno < 99900) AS T
	ORDER BY Novedad
	
END