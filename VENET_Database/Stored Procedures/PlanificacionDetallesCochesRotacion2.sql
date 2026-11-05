CREATE PROCEDURE [dbo].[PlanificacionDetallesCochesRotacion2]
	@Id_Planificacion INT = 53 
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @IdCoche INT
	DECLARE @IdTipoDia INT
	DECLARE @IdPDC INT
	DECLARE @NroServicio INT
	
	DECLARE @HDiasRota INT
	DECLARE @HServicioFijo INT
	DECLARE @HUltimoServicio INT
	DECLARE @SDiasRota INT
	DECLARE @SServicioFijo INT
	DECLARE @SUltimoServicio INT
	DECLARE @DDiasRota INT
	DECLARE @DServicioFijo INT
	DECLARE @DUltimoServicio INT
	DECLARE @FDiasRota INT
	DECLARE @FServicioFijo INT
	DECLARE @FUltimoServicio INT
	
	DECLARE @HCant INT = 0
	DECLARE @SCant INT = 0
	DECLARE @DCant INT = 0
	DECLARE @FCant INT = 0
	
	DECLARE @IdTipoServicio INT
	DECLARE @IdDiagrama INT
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @UserAdd INT 
	 
	DECLARE cur CURSOR FOR
		SELECT Id,HabilDiasRotacion,HabilUltimoServicio,HabilServicioFijo,
			   SabadoDiasRotacion,SabadoUltimoServicio,SabadoServicioFijo,
			   DomingoDiasRotacion,DomingoUltimoServicio,DomingoServicioFijo,
			   FeriadoDiasRotacion,FeriadoUltimoServicio,FeriadoServicioFijo
			FROM Coches 
				WHERE Id IN (SELECT Id_Coche 
							 FROM PlanificacionDetallesCoches 
							 WHERE Id_Planificacion = @Id_Planificacion)

	OPEN cur
	FETCH NEXT FROM cur INTO @IdCoche,@HDiasRota,@HUltimoServicio,@HServicioFijo,@SDiasRota,@SUltimoServicio,@SServicioFijo,@DDiasRota,@DUltimoServicio,@DServicioFijo,@FDiasRota,@FUltimoServicio,@FServicioFijo

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		SELECT @Desde = FechaDesde, @Hasta = FechaHasta, @UserAdd = UserAdd
			FROM Planificacion
				WHERE Id = @Id_Planificacion
		
		WHILE @Desde <= @Hasta
		BEGIN
			SELECT @IdTipoDia = Id_TipoDia, @IdPDC = Id
				FROM Diagramas 
					WHERE Id IN (SELECT Id FROM PlanificacionDetallesCoches WHERE Fecha = @Desde AND Id_Coche = @IdCoche)
			
			
			
			--logica para obtener el servicio q le corresponde
			IF @IdTipoDia = 1
			BEGIN
				SET @HCant = @HCant + 1
				SET @HUltimoServicio = @HServicioFijo
			END	
			
			
			IF @IdTipoDia = 1 AND @HServicioFijo > 0
			BEGIN
				SET @NroServicio = @HServicioFijo
				SET @HUltimoServicio = @HServicioFijo
			END	
			
			IF @IdTipoDia = 2 AND @SServicioFijo > 0
			BEGIN
				SET @NroServicio = @SServicioFijo
				SET @SUltimoServicio = @SServicioFijo
			END	
			
			IF @IdTipoDia = 3 AND @DServicioFijo > 0
			BEGIN
				SET @NroServicio = @DServicioFijo
				SET @DUltimoServicio = @DServicioFijo
			END	
			
			IF @IdTipoDia = 4 AND @FServicioFijo > 0
			BEGIN
				SET @NroServicio = @FServicioFijo
				SET @FUltimoServicio = @FServicioFijo
			END	
				
			
			--UPDATE PlanificacionDetallesCoches SET NroServicio = @NroServicio WHERE Id = @IdPDC
			
			UPDATE Coches 
				SET HabilUltimoServicio = @HUltimoServicio, SabadoUltimoServicio = @SUltimoServicio, DomingoUltimoServicio = @DUltimoServicio, FeriadoUltimoServicio = @FUltimoServicio
					WHERE Id = @IdCoche
			 
			SET @Desde = DATEADD(d, 1, @Desde) 
		
		END
		
		FETCH NEXT FROM cur INTO @IdCoche,@HDiasRota,@HUltimoServicio,@HServicioFijo,@SDiasRota,@SUltimoServicio,@SServicioFijo,@DDiasRota,@DUltimoServicio,@DServicioFijo,@FDiasRota,@FUltimoServicio,@FServicioFijo
		
	END
			
	CLOSE cur 
	DEALLOCATE cur

END
 
 
