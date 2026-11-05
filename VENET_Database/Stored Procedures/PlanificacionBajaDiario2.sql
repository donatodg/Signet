CREATE PROCEDURE [dbo].[PlanificacionBajaDiario2]
	@IdPlanificacion INT = 8,
	@Fecha DATE = '20141028',
	@IdUser INT = 1
AS
BEGIN

	DECLARE @IdDiagrama INT
	DECLARE @NroServicio INT
	DECLARE @Turno INT
	DECLARE @IdCoche INT
	
	DECLARE @IdCocheAnt INT
	DECLARE @IdChofer INT
	DECLARE @ChoferesAnt VARCHAR(50)
	DECLARE @Interno INT
	
	DELETE Diagramas_Fecha WHERE Fecha = @Fecha AND Id_Diagrama IN (SELECT DISTINCT(Id_Diagrama) FROM PlanificacionServiciosCoches WHERE Fecha = @Fecha AND Id_Planificacion = @IdPlanificacion)
	
	DECLARE cur CURSOR FOR
		SELECT psc.Id_Diagrama, ds.NroServicio, ds.Turno, ISNULL(psc.Id_Coche,0)
			FROM PlanificacionServiciosCoches psc 
			INNER JOIN Diagramas_Servicios ds ON psc.Id_Diagrama = ds.Id_Diagrama AND psc.NroServicio = ds.NroServicio
				WHERE psc.Id_Planificacion = @IdPlanificacion AND 
					PSC.Fecha = @Fecha AND
					ds.UserDel IS NULL
	OPEN cur
	
	FETCH NEXT FROM cur INTO @IdDiagrama, @NroServicio, @Turno, @IdCoche
	
	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @IdChofer = 0
			
			IF @IdCoche = 0
			BEGIN
				SET @IdCocheAnt = 0
				SET @ChoferesAnt = ''
				SET @Interno = 0
			END
			ELSE
			BEGIN 
				IF @IdCoche <> @IdCocheAnt
				BEGIN
					SET @IdCocheAnt = @IdCoche 
					SET @ChoferesAnt = ''
					SELECT @Interno = Interno FROM Coches WHERE Id = @IdCoche
				END
				
				IF @Turno <> 2
				BEGIN
					SET @IdChofer = (SELECT TOP(1) ISNULL(Id_Personal ,0)
										FROM PlanificacionDetalle 
											WHERE Id_Coche = @IdCoche AND
												  Id NOT IN (SELECT Id_Planificacion_Detalle
								 					 		 FROM PlanificacionDetalleFechas 
															 WHERE Fecha = @Fecha) AND
												  Id_Personal NOT IN (@ChoferesAnt) OR
												  Id IN (SELECT Id_Planificacion_Detalle
								 						 FROM PlanificacionDetalleFechas 
														 WHERE Fecha = @Fecha AND
															   Novedad = CONVERT(VARCHAR,@Interno)))
				
				END
				ELSE
				BEGIN
					SET @IdChofer = (SELECT TOP(1) ISNULL(Id_Personal ,0)
										FROM PlanificacionDetalle 
											WHERE Id_Coche = @IdCoche AND
												  Id IN (SELECT Id_Planificacion_Detalle
								 					 	 FROM PlanificacionDetalleFechas 
														 WHERE Fecha = @Fecha AND
															   Novedad = 'T') AND
												  Id_Personal NOT IN (@ChoferesAnt) OR
												  Id IN (SELECT Id_Planificacion_Detalle
								 						 FROM PlanificacionDetalleFechas 
														 WHERE Fecha = @Fecha AND
															   Novedad = 'T' + CONVERT(VARCHAR,@Interno)))
					
				END 
				
				SET @IdCocheAnt = @IdCoche 
								
				IF @IdChofer <> 0
					IF @ChoferesAnt = ''
						SET @ChoferesAnt =  CONVERT(VARCHAR,@IdChofer)
					ELSE
						SET @ChoferesAnt = CONVERT(VARCHAR,@ChoferesAnt) + ',' + CONVERT(VARCHAR,@IdChofer)
							
			END 
			
			--SET @IdChofer = ISNULL(@IdChofer,0)
			SELECT @IdChofer = ISNULL(LaboralLegajo,0) FROM Personal WHERE Id = @IdChofer 
			
			INSERT INTO Diagramas_Fecha (Fecha,Id_Diagrama,NroServicio,Turno,Id_Coche,Id_Personal,FechaAdd,UserAdd)
				VALUES (@Fecha, @IdDiagrama, @NroServicio, @Turno, @Interno, @IdChofer, GETDATE(), @IdUser)
				
			FETCH NEXT FROM cur INTO @IdDiagrama, @NroServicio, @Turno, @IdCoche
		END
		
	CLOSE cur 
	DEALLOCATE cur 
END
