CREATE PROCEDURE [dbo].[DiagramasMarcadosPorFechas]
	@IdPlanificacion INT

AS
BEGIN
 
SELECT COUNT(DISTINCT(ds.Id)), ds.Id_Diagrama, ps.Fecha
	FROM Diagramas_Servicios ds 
	INNER JOIN Diagramas_Detalle dd ON ds.Id_Diagrama = dd.Id_Diagrama AND ds.NroServicio = dd.NroServicio AND ds.Turno = dd.Turno
	INNER JOIN PlanificacionServicios ps ON ps.Id_Diagrama = ps.Id_Diagrama AND Id_Planificacion = @IdPlanificacion
WHERE ds.Id_Diagrama IN (SELECT Id_Diagrama FROM PlanificacionServicios WHERE Id_Planificacion = @IdPlanificacion) AND dd.Marcada = 1
GROUP BY ds.Id_Diagrama, ps.Fecha

END
