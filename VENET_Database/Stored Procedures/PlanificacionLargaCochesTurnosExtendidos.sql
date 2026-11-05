CREATE PROCEDURE [dbo].PlanificacionLargaCochesTurnosExtendidos
    @Id_Planificacion INT,
	@Dia INT,
	@Id_Coche INT
	
AS
BEGIN

	SELECT pte.Id, pte.Codigo, l.Descripcion, pte.NroVuelta, c.Interno
		FROM PlanificacionLargaCochesTurnoExtendido pte
		INNER JOIN CodigosServicios cs ON pte.Id_CodigoServicio = cs.Id
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Coches c ON pte.Id_Coche = c.Id
	WHERE pte.Id_Planificacion = @Id_Planificacion
		  AND DAY(pte.Fecha) = @Dia
		  AND pte.Id_Coche = @Id_Coche
		  AND pte.UserDel IS NULL

END
