CREATE PROCEDURE [dbo].[AsignaServicio]
	@IdPlanificacion INT = 12,
	@Fecha DATE = '20141228',
	@IdCoche INT = 44,
	@IdPersonal INT = 1,
	@Turno INT = 2
AS
BEGIN

	DECLARE @IdDiagrama INT = 0
	DECLARE @NroServicio INT = 0
	 
	SELECT @IdDiagrama = ds.Id_Diagrama, @NroServicio = ds.NroServicio 
		FROM PlanificacionDetallesCoches pdc 
		INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id
			WHERE pdc.Id_Planificacion = @IdPlanificacion AND 
				  pdc.Fecha = @Fecha AND 
				  pdc.Id_Coche = @IdCoche AND
				  ds.UserDel IS NULL

	DECLARE @IdServicio INT = 0
	DECLARE @Novedad VARCHAR(5) = ''

	SELECT @IdServicio = Id, @Novedad = Codigo
		FROM Diagramas_Servicios 
			WHERE Id_Diagrama = @IdDiagrama AND
				  NroServicio = @NroServicio AND
				  Turno = @Turno AND
				  UserDel IS NULL AND
				  Id NOT IN (SELECT Id_Servicio 
							 FROM PlanificacionDetalles
							 WHERE Id_Planificacion = @IdPlanificacion AND 
								   Fecha = @Fecha AND 
								   Id_Servicio > 0) 

	UPDATE PlanificacionDetalles
		SET Novedad = @Novedad, Id_Novedad = 0, Id_Servicio = @IdServicio
			WHERE Id_Planificacion = @IdPlanificacion AND 
			      Fecha = @Fecha AND
			      Id_Coche = @IdCoche AND 
				  Id_Personal = @IdPersonal 
 
END