 CREATE  PROCEDURE [dbo].[PlanificacionConfirmar]
	@IdPlanificacion INT 
AS
BEGIN
	
	INSERT INTO PlanificacionDetallesConfirmado 
		SELECT * 
			FROM PlanificacionDetalles
				WHERE Id_Planificacion = @IdPlanificacion

	INSERT INTO PlanificacionDetallesCochesConfirmado
		SELECT *
			FROM PlanificacionDetallesCoches
				WHERE Id_Planificacion = @IdPlanificacion
			
END
