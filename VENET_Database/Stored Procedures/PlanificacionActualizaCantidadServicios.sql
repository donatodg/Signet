CREATE PROCEDURE [dbo].PlanificacionActualizaCantidadServicios
	@Id_Planificacion INT = 379
AS
BEGIN

	DECLARE @Id INT
	DECLARE @Id_Diagrama INT
	DECLARE @Cantidad INT

	DECLARE cur CURSOR FOR
		SELECT Id, Id_Diagrama, CantidadServicios
		FROM PlanificacionServicios
		WHERE Id_Planificacion = @Id_Planificacion
	OPEN cur

	FETCH NEXT FROM cur INTO @Id, @Id_Diagrama, @Cantidad

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
	 	UPDATE PlanificacionServicios 
	 		SET CantidadServicios = (SELECT COUNT(Id) FROM Diagramas_Servicios WHERE Id_Diagrama = @Id_Diagrama AND UserDel IS NULL) 
	 	WHERE Id = @Id
	 	
	FETCH NEXT FROM cur INTO @Id, @Id_Diagrama, @Cantidad
	END 
	
	CLOSE cur 
	DEALLOCATE cur 

END