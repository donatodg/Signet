 CREATE  PROCEDURE [dbo].[PlanificacionLargaConfirmar]
	@IdPlanificacion INT 
AS
BEGIN
	
	INSERT INTO PlanificacionLargaDetallesConfirmado 
		SELECT * 
			FROM PlanificacionLargaDetalles
				WHERE Id_Planificacion = @IdPlanificacion

END
