CREATE PROCEDURE [dbo].[PlanificacionDetallesCochesDiaria]
	@Id_Planificacion INT 
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @IdCoche INT
	DECLARE @IdTipoServicio INT
	DECLARE @IdDiagrama INT
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @IdUN INT 
	DECLARE @UserAdd INT 
	 
	DECLARE cur CURSOR FOR
		SELECT Id, Id_TipoServicio 
			FROM COCHES 
				WHERE Id IN (SELECT Id_Coche 
								FROM PlanificacionDetalles
									WHERE Id_Planificacion  = @Id_Planificacion)

	OPEN cur
	FETCH NEXT FROM cur INTO @IdCoche, @IdTipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		SELECT @Desde = FechaDesde, @Hasta = FechaHasta, @UserAdd = UserAdd, @IdUN = Id_UnidadNegocio
			FROM Planificacion
				WHERE Id = @Id_Planificacion
		
		WHILE @Desde <= @Hasta
		BEGIN
			SET @IdDiagrama = 0
			
			SELECT @IdDiagrama = Id_Diagrama
				FROM PlanificacionServicios 
					WHERE Id_Planificacion = @Id_Planificacion AND
						  Id_TipoServicio = @IdTipoServicio AND 
						  Fecha = @Desde
			
			UPDATE PlanificacionDetallesCoches 
				SET Id_TipoServicio = @IdTipoServicio, Id_Diagrama = @IdDiagrama, Id_Servicio = 0
					WHERE Id_Planificacion = @Id_Planificacion AND Id_Coche = @IdCoche AND Fecha = @Desde
			
			IF @@rowcount = 0
			BEGIN
				INSERT INTO PlanificacionDetallesCoches (Id_Planificacion,Id_Coche,Fecha,Id_TipoServicio,Id_Diagrama,Id_Servicio,FechaAdd,UserAdd) 
					VALUES (@Id_Planificacion, @IdCoche, @Desde, @IdTipoServicio, @IdDiagrama, 0, GETDATE(), @UserAdd)
			END
				 
			SET @Desde = DATEADD(d, 1, @Desde) 
		
		END
		
		FETCH NEXT FROM cur INTO @IdCoche, @IdTipoServicio
	END
			
	CLOSE cur 
	DEALLOCATE cur
	
	DECLARE curSinLinea CURSOR FOR
		SELECT Id FROM Coches WHERE Id_UnidadNegocio = @IdUN AND UserDel IS NULL AND ID NOT IN (SELECT Id_Coche FROM PlanificacionDetallesCoches WHERE Id_Planificacion = @Id_Planificacion)

	OPEN curSinLinea
	FETCH NEXT FROM curSinLinea INTO @IdCoche

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		SELECT @Desde = FechaDesde, @Hasta = FechaHasta, @UserAdd = UserAdd
			FROM Planificacion
				WHERE Id = @Id_Planificacion
		WHILE @Desde <= @Hasta
		BEGIN
		
			INSERT INTO PlanificacionDetallesCoches (Id_Planificacion,Id_Coche,Fecha,Id_TipoServicio,Id_Diagrama,Id_Servicio,FechaAdd,UserAdd) 
					VALUES (@Id_Planificacion, @IdCoche, @Desde, 0, 0, 0, GETDATE(), @UserAdd)
			 
			SET @Desde = DATEADD(d, 1, @Desde) 
		
		END
		FETCH NEXT FROM curSinLinea INTO @IdCoche 
	END
			
	CLOSE curSinLinea 
	DEALLOCATE curSinLinea

END