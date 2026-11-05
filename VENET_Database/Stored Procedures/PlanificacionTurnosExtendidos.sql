CREATE PROCEDURE [dbo].[PlanificacionTurnosExtendidos]
	@Id_Planificacion INT = 111,
	@Dia INT = 26,
	@Id_Personal INT = 1083
	
AS
BEGIN

	SELECT pte.Id, ds.Codigo, l.Descripcion, pte.NroVuelta, c.Interno
		FROM PlanificacionTurnoExtendido pte
		INNER JOIN Diagramas d ON pte.Id_Diagrama = d.Id
		INNER JOIN Diagramas_Servicios ds ON d.Id = ds.Id_Diagrama AND pte.NroServicio = ds.NroServicio AND pte.Turno = ds.Turno
		INNER JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Coches c ON pte.Id_Coche = c.Id
	WHERE pte.Id_Planificacion = @Id_Planificacion
		  AND DAY(pte.Fecha) = @Dia
		  AND pte.Id_Personal = @Id_Personal
		  AND pte.UserDel IS NULL

END
