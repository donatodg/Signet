create PROCEDURE [dbo].[PlanificacionHistorial_Actualizar]
	@Id_TipoServicio INT,
	@Id_Planificacion INT,
	@Fecha DATETIME

AS
BEGIN

	DECLARE @Id_Coche INT

	SET @Id_Coche = (SELECT TOP 1 c.Id   
					 FROM PlanificacionDetallesCoches pdc 
					 INNER JOIN Coches c ON pdc.Id_Coche = c.Id
					 WHERE Id_Planificacion = @Id_Planificacion
						  AND Fecha = @Fecha 
						  AND pdc.Id_TipoServicio = @Id_TipoServicio
						  AND Id_Servicio = 0 
						  AND Interno < (SELECT TOP 1 c.Interno FROM PlanificacionDetallesCoches pdc INNER JOIN Coches c ON pdc.Id_Coche = c.Id WHERE pdc.Id_Planificacion = @Id_Planificacion AND pdc.Fecha = @Fecha AND pdc.Id_TipoServicio = @Id_TipoServicio AND pdc.Id_Servicio > 0 ORDER BY pdc.Id_Servicio DESC)
					 ORDER BY c.Interno DESC)
	 
	 IF @Id_Coche IS NOT NULL
		UPDATE PlanificacionHistorial 
		SET Id_Coche = @Id_Coche 
		WHERE Id_Planificacion = @Id_Planificacion	
			  AND Id_TipoServicio = @Id_TipoServicio
			  AND Fecha = @Fecha 
	 
 END
 