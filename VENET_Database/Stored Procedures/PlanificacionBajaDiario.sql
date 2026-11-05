CREATE PROCEDURE [dbo].[PlanificacionBajaDiario]
	@IdPlanificacion INT,
	@Fecha DATE,
	@IdUser INT  
AS
BEGIN
 
	DECLARE @IdCoche INT = 0
	DECLARE @IdServicio INT = 0
	DECLARE @IdPersonal INT = 0
	
	UPDATE Diagramas_Fecha
		SET FechaDel = GETDATE(), UserDel = @IdUser
			WHERE Fecha = @Fecha AND
				  Id_Diagrama IN (SELECT Id_Diagrama FROM PlanificacionServicios WHERE Id_Planificacion = @IdPlanificacion)
  
	INSERT INTO Diagramas_Fecha (Fecha,Id_Diagrama,NroServicio,Turno,Id_Coche,Id_Personal,FechaAdd,UserAdd)
		(SELECT @Fecha, ps.Id_Diagrama, ds.NroServicio, ds.Turno, 0, 0, GETDATE(), @IdUser 
			FROM PlanificacionServicios ps
			INNER JOIN Diagramas_Servicios ds ON ps.Id_Diagrama = ds.Id_Diagrama
				WHERE ps.Id_Planificacion = @IdPlanificacion AND
					  ps.Fecha = @Fecha)
	
	DECLARE cur CURSOR FOR
		SELECT Interno, Id_Servicio 
			FROM PlanificacionDetallesCoches p 
			INNER JOIN Coches c on p.Id_Coche = c.Id
				WHERE p.Id_Planificacion = @IdPlanificacion AND
					  p.Fecha = @Fecha AND
					  p.Id_Servicio > 0 AND
				      p.UserDel IS NULL	

	OPEN cur
	FETCH NEXT FROM cur INTO @IdCoche, @IdServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE Diagramas_Fecha 
			SET Id_Coche = @IdCoche
				WHERE Id_Diagrama IN (SELECT Id_Diagrama FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      NroServicio IN (SELECT NroServicio FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Fecha = @Fecha AND
				      UserDel IS NULL
				      
		FETCH NEXT FROM cur INTO @IdCoche, @IdServicio 
	
	END
	CLOSE cur 
	DEALLOCATE cur	
 
	DECLARE cur2 CURSOR FOR
		SELECT Id_Personal, Id_Servicio 
			FROM PlanificacionDetalles
				WHERE Id_Planificacion = @IdPlanificacion AND
					  Fecha = @Fecha AND 
					  Id_Servicio > 0 AND
				      UserDel IS NULL	

	OPEN cur2
	FETCH NEXT FROM cur2 INTO @IdPersonal, @IdServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE Diagramas_Fecha 
			SET Id_Personal = (SELECT ISNULL(LaboralLegajo, 0) from Personal WHERE Id = @IdPersonal)
				WHERE Id_Diagrama IN (SELECT Id_Diagrama FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      NroServicio IN (SELECT NroServicio FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Turno IN (SELECT Turno FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Fecha = @Fecha AND
				      UserDel IS NULL	
				      		      
		FETCH NEXT FROM cur2 INTO @IdPersonal, @IdServicio 
	
	END
	CLOSE cur2
	DEALLOCATE cur2
  
END
