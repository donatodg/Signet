CREATE PROCEDURE [dbo].[PlanificacionRotacion]
	@Id_Planificacion INT = 654
	 
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @IdTipoServicio INT
	DECLARE @IdUN INT
	DECLARE @Desde DATE
	DECLARE @Desde2 DATE
	DECLARE @Hasta DATE
	DECLARE @Fecha DATE
	DECLARE @TipoDia INT  
	DECLARE @ListCochesDuplicado NVARCHAR(MAX) = ''
	DECLARE @ListCochesHabil NVARCHAR(MAX) = ''
	DECLARE @ListCochesSabado NVARCHAR(MAX) = ''
	DECLARE @ListCochesFeriado NVARCHAR(MAX) = ''
	DECLARE @ListCochesSabadoUltimo NVARCHAR(MAX) = ''
	DECLARE @IdDiagrama INT
	DECLARE @ContHabil INT = 0
	DECLARE @ContSabado INT = 0 
	DECLARE @ContFeriado INT = 0
	DECLARE @RotaHabil INT 
	DECLARE @RotaSabado INT 
	DECLARE @RotaFeriado INT 
	DECLARE @CantServicios INT = 0
	DECLARE @CantServiciosF INT = 0
	DECLARE @CountServicios INT = 0
	DECLARE @IdServicio INT = 0
	DECLARE @IdPlanificacionAnterior INT = 0
	DECLARE @IdCocheAnteriorHabil INT = 0
	DECLARE @IdCocheAnteriorSabado INT = 0
	DECLARE @IdCocheAnteriorFeriado INT = 0
	DECLARE @CantRotacionUN INT = 0
	DECLARE @i INT = 0
	DECLARE @ListCoches NVARCHAR(MAX) = ''
	DECLARE @FechaH DATE
	DECLARE @FechaS DATE
	DECLARE @FechaF DATE
	
	
	--BORRA LOS SERVICIOS ACTUALES
	UPDATE PlanificacionDetallesCoches SET Id_Servicio = 0 WHERE Id_Planificacion = @Id_Planificacion
 	
 	--BORRA HISTORIAL
 	DELETE PlanificacionHistorial WHERE Id_Planificacion = @Id_Planificacion
 	
 	--MARCA LOS SERVICIOS FIJOS
	EXEC PlanificacionRotacionServicioFijo @Id_Planificacion
 	
 	--CARGA VARIABLES
 	SELECT @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta, @IdUN = Id_UnidadNegocio
 		FROM Planificacion 
 			WHERE Id = @Id_Planificacion

	--SETEO DE DIAS DE ROTACION
	SELECT @RotaHabil = RotaHabil, @RotaSabado = RotaSabado, @RotaFeriado = RotaFeriado
		FROM UnidadNegocios_Configuracion 
			WHERE Id_UnidadNegocio = @IdUN
	
	--BUSCA ULTIMA PLANIFICACION CONFIRMADA PARA ROTACION
	SELECT @IdPlanificacionAnterior =  MAX(Id)
		FROM Planificacion  
			WHERE Id_UnidadNegocio = @IdUN AND 
				  FechaHasta < @Desde AND 
				  UserDel IS NULL AND 
				  FechaConfirmacion IS NOT NULL
			
	--POR CADA TIPO DE SERVICIO
	DECLARE curTipoServicio CURSOR FOR
		SELECT DISTINCT(Id_TipoServicio)
			FROM PlanificacionDetallesCoches 
				WHERE Id_Planificacion = @Id_Planificacion 
			
	OPEN curTipoServicio
	FETCH NEXT FROM curTipoServicio INTO @IdTipoServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @ListCochesDuplicado = ''
		SET @ListCochesHabil = ''
		SET @ListCochesSabado = ''
		SET @ListCochesFeriado = ''
		
		SET @ContHabil = 0
		SET @ContSabado = 0
		SET @ContFeriado = 0
		SET @CantServicios = 0
		SET @CantServiciosF = 0
		
		SELECT @CantRotacionUN = CantidadRotacion FROM TipoServicios WHERE Id = @IdTipoServicio
		
		SELECT @ListCochesHabil = COALESCE(@ListCochesHabil + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.HabilServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		BEGIN TRY
 			SET @ListCochesHabil = LEFT(@ListCochesHabil, LEN(@ListCochesHabil) - 1)
 		END TRY
		BEGIN CATCH
		END CATCH
		
 		SELECT @ListCochesSabado = COALESCE(@ListCochesSabado + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.SabadoServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		BEGIN TRY 
 			SET @ListCochesSabado = LEFT(@ListCochesSabado, LEN(@ListCochesSabado) - 1)
 		END TRY
		BEGIN CATCH
		END CATCH
		
 		SELECT @ListCochesFeriado = COALESCE(@ListCochesFeriado + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.FeriadoServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		BEGIN TRY
 			SET @ListCochesFeriado = LEFT(@ListCochesFeriado, LEN(@ListCochesFeriado) - 1)
		END TRY
		BEGIN CATCH
		END CATCH
		
		--SELECCIONAR DE LA ULTIMA PLANIFICACION
		--HABILES
		--******************************************
		SELECT @FechaH = Fecha 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 1
		
		IF @FechaH IS NOT NULL
			EXEC PlanificacionHistorial_Actualizar @IdTipoServicio, @IdPlanificacionAnterior, @FechaH
 
		SELECT @IdCocheAnteriorHabil = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 1
		
		print 'coche anterior'
		print @IdCocheAnteriorHabil	
				  
		--SABADOS
		--******************************************
		SELECT @FechaS = Fecha 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 2
		
		IF @FechaS IS NOT NULL
			EXEC PlanificacionHistorial_Actualizar @IdTipoServicio, @IdPlanificacionAnterior, @FechaS
			
			SELECT @IdCocheAnteriorSabado = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 2
					  
		--FERIADOS
		--******************************************
		SELECT @FechaF = Fecha 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 4
		
		IF @FechaF IS NOT NULL
			EXEC PlanificacionHistorial_Actualizar @IdTipoServicio, @IdPlanificacionAnterior, @FechaF
			
		SELECT @IdCocheAnteriorFeriado = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @IdPlanificacionAnterior AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 4
					  	  
		--ACOMODAR LISTA SEGUN ULTIMO ID COCHE
		IF @IdCocheAnteriorHabil > 0
			BEGIN TRY
				SET @ListCoches = 'c' + REPLACE(@ListCochesHabil,',',',c') + ','
				SET @ListCochesHabil = REPLACE(REPLACE(SUBSTRING(@ListCoches, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorHabil) + ',', @ListCoches), LEN(@ListCoches)) + ',' + SUBSTRING(@ListCoches, 0, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorHabil) + ',', @ListCoches) -1),',,',','),'c','')
				IF SUBSTRING(@ListCochesHabil, LEN(@ListCochesHabil), LEN(@ListCochesHabil)) = ','
					SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, 0, LEN(@ListCochesHabil))
			END TRY
			BEGIN CATCH
			END CATCH
		IF @IdCocheAnteriorSabado > 0
			BEGIN TRY
				SET @ListCoches = 'c' + REPLACE(@ListCochesSabado,',',',c') + ','
				SET @ListCochesSabado = REPLACE(REPLACE(SUBSTRING(@ListCoches, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorSabado) + ',', @ListCoches), LEN(@ListCoches)) + ',' + SUBSTRING(@ListCoches, 0, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorSabado) + ',', @ListCoches) -1),',,',','),'c','')
				IF SUBSTRING(@ListCochesSabado, LEN(@ListCochesSabado), LEN(@ListCochesSabado)) = ','
					SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, 0, LEN(@ListCochesSabado))
			END TRY
			BEGIN CATCH
			END CATCH
		IF @IdCocheAnteriorFeriado > 0
			BEGIN TRY
				SET @ListCoches = 'c' + REPLACE(@ListCochesFeriado,',',',c') + ','
				SET @ListCochesFeriado = REPLACE(REPLACE(SUBSTRING(@ListCoches, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorFeriado) + ',', @ListCoches), LEN(@ListCoches)) + ',' + SUBSTRING(@ListCoches, 0, CHARINDEX('c' + CONVERT(VARCHAR, @IdCocheAnteriorFeriado) + ',', @ListCoches) -1),',,',','),'c','')
				IF SUBSTRING(@ListCochesFeriado, LEN(@ListCochesFeriado), LEN(@ListCochesFeriado)) = ','
					SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, 0, LEN(@ListCochesFeriado))
			END TRY
			BEGIN CATCH
			END CATCH
			
		--POR CADA FECHA
		SET @Desde = @Desde2
		WHILE @Desde <= @Hasta
		BEGIN
			SET @Fecha = @Desde
			
			SELECT @IdDiagrama = Id_Diagrama 
 				FROM PlanificacionDetallesCoches 
 					WHERE Id_Planificacion = @Id_Planificacion AND
 						  Id_TipoServicio = @IdTipoServicio AND
 						  Fecha = @Fecha 
 							
			SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
						   FROM Feriado WHERE Fecha = @Fecha), 1)
			IF @TipoDia = 1
			BEGIN
				IF (DATEPART(dw, @Fecha) = 1) --Domingo
					SET @TipoDia = 3
				IF (DATEPART(dw, @Fecha) = 7) --Sabado
					SET @TipoDia = 2
			END
						
			IF @TipoDia = 1 
			BEGIN
				SET @FechaH = @Fecha
				
				IF @ContHabil >= @RotaHabil
				BEGIN
					SET @i = 0
					WHILE @i < @CantRotacionUN BEGIN
						SET @i = @i + 1
						SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
					END
					SET @ContHabil = 0
				END
				SET @ListCochesDuplicado = @ListCochesHabil
				SET @ContHabil = @ContHabil + 1
				
			END
			
			IF @TipoDia = 2 --OR @TipoDia = 3 
			BEGIN
				SET @FechaS = @Fecha
				
				--SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
				--		FROM Diagramas_Servicios 
				--			WHERE Id_Diagrama = @IdDiagrama
							
				IF @ContSabado >= @RotaSabado
				BEGIN
					--SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					--SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					SET @CountServicios = 0
					
					WHILE @CountServicios < @CantServicios
					BEGIN	
						SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
						
						SET @CountServicios = @CountServicios + 1
					END
					
					SET @ContSabado = 0
				END
				SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
								  UserDel IS NULL
							
				SET @ContSabado = @ContSabado + 1
				SET @ListCochesDuplicado = @ListCochesSabado
			END
			
			IF @TipoDia = 3
			BEGIN
				SET @CountServicios = 0
					
				WHILE @CountServicios < @CantServicios
				BEGIN	
					SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					
					SET @CountServicios = @CountServicios + 1
				END
				
				SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
							      UserDel IS NULL
							
				SET @ContSabado = @ContSabado + 1	
				SET @ListCochesDuplicado = @ListCochesSabado
				
				IF @RotaHabil = 5
					SET @ContHabil = 5

			END
			
			IF @TipoDia = 4 
			BEGIN
				SET @FechaF = @Fecha
				
				--SUMA UN DIA PARA CUANDO EL FERIADO ES DIA DE SEMANA
				IF ((DATEPART(dw, @Fecha) <> 1) OR (DATEPART(dw, @Fecha) <> 7))
					SET @ContHabil = @ContHabil + 1
				
				SET @CountServicios = 0
					
				WHILE @CountServicios  < @CantServiciosF
				BEGIN	
					SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
					
					SET @CountServicios = @CountServicios + 1
				END
				
				SELECT @CantServiciosF = COUNT(DISTINCT(NroServicio))
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
							      UserDel IS NULL
							
				SET @ContFeriado = @ContFeriado + 1	
				SET @ListCochesDuplicado = @ListCochesFeriado
				---	
				--IF @ContFeriado >= @RotaFeriado
				--BEGIN
				--	SET @i = 0
				--	WHILE @i < @CantRotacionUN BEGIN
				--		SET @i = @i + 1
				--		SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
				--	END
				--	SET @ContFeriado = 0
				--END
				--SET @ListCochesDuplicado = @ListCochesFeriado
				--SET @ContFeriado = @ContFeriado + 1
				--
			END
			
			DECLARE curServicios CURSOR FOR
 			--	SELECT Min(ID) Id 
				--	FROM Diagramas_Servicios 
				--		WHERE Id_Diagrama = @IdDiagrama AND
				--			  UserDel IS NULL
				--GROUP BY NroServicio
				--HAVING NroServicio NOT IN (SELECT ds.NroServicio 
				--						   FROM PlanificacionDetallesCoches pdc 
				--						   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
				--						   WHERE Id_Planificacion = @Id_Planificacion AND
				--								 ds.Id_Diagrama = @IdDiagrama AND 
				--								 Fecha = @Fecha AND
				--								 ds.UserDel IS NULL)
				SELECT  Id 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama AND
							  UserDel IS NULL AND
				              NroServicio NOT IN (SELECT ds.NroServicio 
												  FROM PlanificacionDetallesCoches pdc 
												  INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
												  WHERE Id_Planificacion = @Id_Planificacion AND
														 ds.Id_Diagrama = @IdDiagrama AND 
														 Fecha = @Fecha AND
														 ds.UserDel IS NULL)
				 ORDER BY NroServicio, Turno

			OPEN curServicios
			FETCH NEXT FROM curServicios INTO @IdServicio  
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				UPDATE PlanificacionDetallesCoches 
					SET Id_Servicio = @IdServicio 
				WHERE Id_Planificacion = @Id_Planificacion AND
					  Id_Coche = SUBSTRING(@ListCochesDuplicado, 0,  CHARINDEX(',', @ListCochesDuplicado)) AND 
					  Fecha = @Fecha
				
				SET @ListCochesDuplicado = SUBSTRING(@ListCochesDuplicado, CHARINDEX(',', @ListCochesDuplicado) + 1 , LEN(@ListCochesDuplicado)) + ',' + SUBSTRING(@ListCochesDuplicado, 0,  CHARINDEX(',', @ListCochesDuplicado))
				 
				FETCH NEXT FROM curServicios INTO @IdServicio
			END
			
			CLOSE curServicios 
			DEALLOCATE curServicios
			
			SET @Desde = DATEADD(d, 1, @Desde)
			
			IF @TipoDia = 2 OR @TipoDia = 3
				SET @ListCochesSabadoUltimo = @ListCochesDuplicado
				
		END
		
		SET @i = 0
	    WHILE @i < @CantRotacionUN BEGIN
			SET @i = @i + 1
			SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
		END
		
		 
		
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 1, SUBSTRING(@ListCochesHabil, 0, CHARINDEX(',', @ListCochesHabil)), @FechaH)
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 2, SUBSTRING(@ListCochesSabadoUltimo, 0, CHARINDEX(',', @ListCochesSabadoUltimo)), @FechaS)
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 4, SUBSTRING(@ListCochesFeriado, 0, CHARINDEX(',', @ListCochesFeriado)), @FechaF)
		
		FETCH NEXT FROM curTipoServicio INTO @IdTipoServicio
	END
		
	CLOSE curTipoServicio 
	DEALLOCATE curTipoServicio
	
END