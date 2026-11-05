CREATE PROCEDURE [dbo].[PlanificacionLanzamientoGeneral]
	@IdPlanificacion INT = 229,
	@Fecha DATE = '20150616'
 
AS
BEGIN

	SELECT 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche = (SELECT c.Interno 
						FROM PlanificacionDetallesCoches pdc 
						INNER JOIN Coches c ON pdc.Id_Coche = c.Id 
						WHERE pdc.Id_Planificacion = @IdPlanificacion
							  AND pdc.Fecha = @Fecha
							  AND pdc.Id_Servicio = ds.Id),
		Hora = LEFT(CONVERT(VARCHAR,ds.HoraCitacion, 114), 5)
	FROM Diagramas_Servicios ds	
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	WHERE ds.Id_Diagrama in (SELECT Id_Diagrama from PlanificacionServicios WHERE Id_Planificacion = @IdPlanificacion AND Fecha = @Fecha AND UserDel IS NULL)
		  AND ds.Turno = 1
		  AND ds.UserDel IS NULL 
	ORDER BY Linea, Hora
	--SELECT
	--	Linea = ISNULL(l.DescripcionCorta, ''),
	--	Servicio = ds.NroServicio,
	--	Coche = ISNULL(c.Interno, ''),
	--	Hora = LEFT(CONVERT(VARCHAR,ds.HoraCitacion, 114), 5)
	--		FROM PlanificacionDetallesCoches pd
	--		INNER JOIN Diagramas_Servicios ds ON pd.id_servicio = ds.id
	-- 		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	--		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	--		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	--		LEFT join Lineas l ON r.Id_Linea = l.Id
	--		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
	--			WHERE pd.Id_Planificacion = @IdPlanificacion AND
	--				  pd.Fecha = @Fecha AND
	--				  pd.UserDel IS NULL AND
	--				  ds.UserDel IS NULL AND
	--				  l.DescripcionCorta IS NOT NULL AND
	--				  ds.Turno = 1
	--ORDER BY Linea, Hora
END
