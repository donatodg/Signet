CREATE PROCEDURE [dbo].[PlanificacionPlanillaCitacionObservaciones]
	@Fecha DATE,
	@IdPlanificacion INT,
	@IdTipoServicio INT

AS
BEGIN
 
 SELECT  
	Legajo = p.LaboralLegajo,
	Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
	Servicio = ISNULL(tn.DescripcionLarga, '')
	FROM PlanificacionDetalles pd
	LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
	LEFT JOIN Coches c ON pd.Id_Coche = c.Id
	INNER JOIN Personal p ON pd.Id_Personal = p.Id
		WHERE pd.Id_Planificacion = @IdPlanificacion AND
			  pd.Fecha = @Fecha AND
			  pd.UserDel IS NULL AND
			  ds.Turno IS NULL AND
			  pd.Id_TipoServicio = @IdTipoServicio AND
			  pd.Id_Novedad > 0
	ORDER BY tn.DescripcionLarga
		
END
