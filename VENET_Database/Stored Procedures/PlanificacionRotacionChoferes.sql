CREATE PROCEDURE [dbo].[PlanificacionRotacionChoferes]
	 @IdPlanificacion INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @IdPlanificacionAnterior INT
	DECLARE @IdUN INT
	DECLARE @IdPersonal INT
	DECLARE @IdCoche INT
	DECLARE @DiaRotacion INT	
	DECLARE @CantDiasRotacion INT
	DECLARE @FechaDesde DATE
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @IdTurnoFijo INT

	DECLARE @Turno INT = 0
	DECLARE @TurnoAnt INT
	DECLARE @IdPD INT = 0
	DECLARE @Count INT
	DECLARE @Flag INT 
	DECLARE @IdCocheAnt INT = 0
	DECLARE @IdPersonalAnt INT = 0
	DECLARE @FechaUltimoServicio DATE
	
	SET DATEFIRST 7; 

	--PERSONAL QUE ROTA
	DECLARE cur CURSOR FOR
		SELECT DISTINCT(pd.Id_Personal) Id_Personal, MAX(pa.Id_UnidadNegocio), MAX(pd.Id_Coche) Id_Coche, MAX(p.LaboralDiaRotacion) LaboralDiaRotacion, MAX(p.LaboralDiasRotacion) LaboralDiasRotacion, MAX(pa.FechaDesde) FechaDesde, MAX(pa.FechaHasta) FechaHasta, MAX(LaboralTurnoFijo) LaboralTurnoFijo
			FROM PlanificacionDetalles pd 
			INNER JOIN Planificacion pa ON pd.Id_Planificacion = pa.Id
			INNER JOIN Personal p ON pd.Id_Personal = p.Id
				WHERE pd.Id_Planificacion = @IdPlanificacion AND
					  p.LaboralTurnoFijo > 3  
		GROUP BY pd.Id_Personal
		ORDER BY Id_Coche, Id_Personal

	OPEN cur
	FETCH NEXT FROM cur INTO @IdPersonal, @IdUN, @IdCoche, @DiaRotacion, @CantDiasRotacion, @Desde, @Hasta, @IdTurnoFijo

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SET @FechaDesde = @Desde
		SET @Flag = 0
		  
		WHILE @Desde <= @Hasta
		BEGIN
		 	IF @IdCocheAnt = @IdCoche
			BEGIN
				SELECT @Turno = ISNULL(Turno, 0)
					FROM PlanificacionDetalles pd INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
						WHERE Id_Planificacion = @IdPlanificacion AND 
						      Fecha = @Desde AND
							  Id_Coche = @IdCoche AND 
					 		  Id_Personal = @IdPersonalAnt
				 
				IF @IdTurnoFijo = 4
					IF @Turno = 1
						SET @Turno = 2
					ELSE
					IF @Turno = 2
						SET @Turno = 1
					
				IF @IdTurnoFijo = 5
					IF @Turno = 1
						SET @Turno = 2
					ELSE
					IF @Turno = 2
						SET @Turno = 3
					ELSE
					IF @Turno = 3
						SET @Turno = 1
						
				IF @IdTurnoFijo = 6
					IF @Turno = 2
						SET @Turno = 3
					ELSE
					IF @Turno = 3
						SET @Turno = 2				
						 
				SET @Count = 0 
			END
			ELSE
			BEGIN
				IF @FechaDesde = @Desde
				BEGIN
					--BUSCA ULTIMA PLANIFICACION CONFIRMADA PARA ROTACION
					SELECT @IdPlanificacionAnterior = Id 
					FROM Planificacion  
						WHERE Id_UnidadNegocio = @IdUN AND 
							  FechaHasta < @Desde AND 
							  UserDel IS NULL AND 
							  FechaConfirmacion IS NOT NULL
					ORDER BY FechaDesde, Id
					
					SELECT @Turno = ISNULL(ds.Turno, 0), @FechaUltimoServicio = Fecha
						FROM PlanificacionDetalles pd
							INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
								WHERE pd.Id_Planificacion = @IdPlanificacionAnterior AND
									  pd.Id_Personal = @IdPersonal AND 
									  pd.Id_Servicio > 0 
					ORDER BY pd.Fecha ASC
					
					--/////////////////////////////////////
					-- AGREGADO
					--/////////////////////////////////////
					--IF DATEADD(D, 1, @FechaUltimoServicio) <> @FechaDesde
					--IF @DiaRotacion = DATEPART(dw, @FechaUltimoServicio)
					--	IF @IdTurnoFijo = 4
					--		IF @Turno = 1
					--			SET @Turno = 2
					--		ELSE
					--		IF @Turno = 2
					--			SET @Turno = 1
						
					--	IF @IdTurnoFijo = 5
					--		IF @Turno = 1
					--			SET @Turno = 2
					--		ELSE
					--		IF @Turno = 2
					--			SET @Turno = 3
					--		ELSE
					--		IF @Turno = 3
					--			SET @Turno = 1
					--/////////////////////////////////////
					
					SET @Count = 0
					
				END
				ELSE
				BEGIN
					--VER SI ROTA
					IF @CantDiasRotacion > 0
						IF @Flag = 0
						BEGIN
							IF @DiaRotacion = DATEPART(dw, @Desde)
							BEGIN
								IF @IdTurnoFijo = 4
								BEGIN
									IF @Turno = 1
										SET @Turno = 2
									ELSE
									IF @Turno = 2
										SET @Turno = 1
								END
						
								IF @IdTurnoFijo = 5
								BEGIN
									IF @Turno = 1
										SET @Turno = 2
									ELSE
									IF @Turno = 2
										SET @Turno = 3
									ELSE
									IF @Turno = 3
										SET @Turno = 1
								END
								
								IF @IdTurnoFijo = 6
								BEGIN
									IF @Turno = 2
										SET @Turno = 3
									ELSE
									IF @Turno = 3
										SET @Turno = 2		
								END
						
								SET @Count = 0
								SET @Flag = 1
							END	
						END
						ELSE
						IF @Count = @CantDiasRotacion
						BEGIN
							IF @IdTurnoFijo = 4
							BEGIN
								IF @Turno = 1
									SET @Turno = 2
								ELSE
								IF @Turno = 2
									SET @Turno = 1
							END
					
							IF @IdTurnoFijo = 5
							BEGIN
								IF @Turno = 1
									SET @Turno = 2
								ELSE
								IF @Turno = 2
									SET @Turno = 3
								ELSE
								IF @Turno = 3
									SET @Turno = 1
							END
									
							IF @IdTurnoFijo = 6
							BEGIN
								IF @Turno = 2
									SET @Turno = 3
								ELSE
								IF @Turno = 3
									SET @Turno = 2		
							END
												
							SET @Count = 0
						END
					ELSE
						SET @Turno = @TurnoAnt
				END
			END
			
			--/////////////////////////////////////////
			-- AGREGADO
			--/////////////////////////////////////////
			IF @Flag = 0
			BEGIN
				IF @DiaRotacion = DATEPART(dw, @Desde)
				BEGIN
					IF @IdTurnoFijo = 4
					BEGIN
						IF @Turno = 1
							SET @Turno = 2
						ELSE
						IF @Turno = 2
							SET @Turno = 1
					END
			
					IF @IdTurnoFijo = 5
					BEGIN
						IF @Turno = 1
							SET @Turno = 2
						ELSE
						IF @Turno = 2
							SET @Turno = 3
						ELSE
						IF @Turno = 3
							SET @Turno = 1
					END
					
					IF @IdTurnoFijo = 6
					BEGIN
						IF @Turno = 2
							SET @Turno = 3
						ELSE
						IF @Turno = 3
							SET @Turno = 2		
					END
			
					SET @Count = 0
					SET @Flag = 1
				END	
			END
			ELSE
			BEGIN
			--/////////////////////////////////////////
				IF @Turno = 0 AND @IdTurnoFijo < 6
					SET @Turno = 1
					
				IF @Turno = 0 AND @IdTurnoFijo = 6
					SET @Turno = 2
			--/////////////////////////////////////////
			END
			--/////////////////////////////////////////
				
			SET @TurnoAnt = @Turno
			
			--BUSCO QUE NO TENGA UNA NOVEDAD ASIGNADA	
		 	SELECT @IdPD = ISNULL(Id, 0)
				FROM PlanificacionDetalles 
					WHERE Id_Planificacion = @IdPlanificacion AND
						  Fecha = @Desde AND
						  Id_Personal = @IdPersonal AND
						  Id_Novedad = 0 AND
						  Id_Servicio = 0
						  
			--ASIGNAR SERVICIO
			IF @IdPD > 0
				EXEC AsignaServicio @IdPlanificacion, @Desde, @IdCoche, @IdPersonal, @Turno
			
			SET @Count = @Count + 1
			SET @IdPD = 0
			
			SET @Desde = DATEADD(d, 1, @Desde)
		END
		
		SET @IdCocheAnt = @IdCoche
		SET @IdPersonalAnt = @IdPersonal
		
		FETCH NEXT FROM cur INTO @IdPersonal, @IdUN, @IdCoche, @DiaRotacion, @CantDiasRotacion, @Desde, @Hasta, @IdTurnoFijo
	END
		
	CLOSE cur 
	DEALLOCATE cur
	
END