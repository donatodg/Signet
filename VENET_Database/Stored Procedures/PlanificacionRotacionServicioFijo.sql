CREATE PROCEDURE [dbo].[PlanificacionRotacionServicioFijo]
	@Id_Planificacion INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SET DATEFIRST 7; 
	
	DECLARE @TipoDia INT = 0
	DECLARE @Fecha DATE
	DECLARE @IdCoche INT
	DECLARE @Servicio INT
	DECLARE @IdServicio INT
	DECLARE @IdDiagrama INT
	
		
	DECLARE curFechas CURSOR FOR
		SELECT DISTINCT(Fecha) Fecha
			FROM PlanificacionDetallesCoches 
				WHERE Id_Planificacion = @Id_Planificacion  
		ORDER BY Fecha
	OPEN curFechas
	FETCH NEXT FROM curFechas INTO @Fecha 

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
						   FROM Feriado WHERE Fecha = @Fecha), 1)
		IF @TipoDia = 1
		BEGIN
			IF (DATEPART(dw, @Fecha) = 1) --Domingo
				SET @TipoDia = 3
			IF (DATEPART(dw, @Fecha) = 7) --Sabado
				SET @TipoDia = 2
		END
			
		--PEDIR LOS COCHES PARA SERVICIO FIJO HABILES
		IF @TipoDia = 1 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.HabilServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.HabilServicioFijo > 0 AND Fecha = @Fecha AND pdc.Id_Planificacion = @Id_Planificacion
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND UserDel IS NULL
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.UserDel IS NULL AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 2 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.SabadoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.SabadoServicioFijo > 0 AND Fecha = @Fecha AND pdc.Id_Planificacion = @Id_Planificacion
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND UserDel IS NULL
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.UserDel IS NULL AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 3 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.DomingoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.DomingoServicioFijo > 0 AND Fecha = @Fecha AND pdc.Id_Planificacion = @Id_Planificacion
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND UserDel IS NULL
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.UserDel IS NULL AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 4 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.FeriadoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE FeriadoServicioFijo > 0 AND Fecha = @Fecha AND pdc.Id_Planificacion = @Id_Planificacion
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND UserDel IS NULL
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.UserDel IS NULL AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		
		FETCH NEXT FROM curFechas INTO @Fecha
	END

	CLOSE curFechas
	DEALLOCATE curFechas

END
