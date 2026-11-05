CREATE PROCEDURE [dbo].[RotacionCochesServicios]
	@Id_Planificacion INT = 53
AS
BEGIN
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @Desde2 DATE
	DECLARE @IdCoche INT
	DECLARE @Turno INT
	
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
	
	DECLARE @TipoDia INT
	DECLARE @IdDiagrama INT
	
	DECLARE @CantH INT = 0
	DECLARE @CantS INT = 0
	DECLARE @CantD INT = 0
	DECLARE @CantF INT = 0
	
	SELECT @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta FROM Planificacion WHERE Id = @Id_Planificacion

	DECLARE CocheChoferCur CURSOR FOR
		 SELECT Id_Coche--, Turno 
		 FROM PlanificacionDetalles WHERE Id_Planificacion = @Id_Planificacion AND Id_Coche > 0
	
	OPEN CocheChoferCur 
	
	FETCH NEXT FROM CocheChoferCur INTO @IdCoche, @Turno
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @HDiasRota = HabilDiasRotacion, @HServicioFijo = HabilServicioFijo, @HUltimoServicio = HabilUltimoServicio,
			   @SDiasRota = SabadoDiasRotacion, @SServicioFijo = SabadoServicioFijo, @SUltimoServicio = SabadoUltimoServicio,
			   @DDiasRota = DomingoDiasRotacion, @DServicioFijo = DomingoServicioFijo, @DUltimoServicio = DomingoUltimoServicio,
			   @FDiasRota = FeriadoDiasRotacion, @FServicioFijo = FeriadoServicioFijo, @FUltimoServicio = FeriadoUltimoServicio
			FROM Coches WHERE Id = @IdCoche
		
		BEGIN
			WHILE @Desde2 <= @Hasta
			BEGIN	
				--Obtengo el tipo de dia y el Id_Diagrama
				SELECT @TipoDia = d.Id_TipoDia, @IdDiagrama = d.Id 
					FROM Coches c
					INNER JOIN PlanificacionServicios s on c.Id_TipoServicio = s.Id_TipoServicio and Id_Planificacion = @Id_Planificacion
					INNER JOIN Diagramas d on s.Id_Diagrama = d.Id
						WHERE c.Id = @IdCoche
							AND s.Fecha = @Desde2
				
				IF @TipoDia = 1
				BEGIN
					IF @HDiasRota = 0 AND @HServicioFijo > 0
						SET @HUltimoServicio = @HServicioFijo 
					
					IF @HDiasRota between 1 AND 29 
						IF @HDiasRota = @CantH
							SET @HUltimoServicio = @HUltimoServicio + 1 
						
					SELECT @HUltimoServicio = ISNULL(Id, 0)
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
								NroServicio = @HUltimoServicio AND
								Turno = @Turno AND
								UserDel IS NULL
					
					UPDATE Coches SET HabilUltimoServicio = @HUltimoServicio WHERE Id = @IdCoche
					UPDATE PlanificacionDetalles SET Id_Servicio = @HUltimoServicio WHERE Id_Coche = @IdCoche AND Fecha = @Desde2  
				END
			
				SET @Desde2 = DATEADD(d,1,@Desde2)
			END 
			
			SET @Desde2 = @Desde
			
			FETCH NEXT FROM CocheChoferCur INTO @IdCoche, @Turno
		 
		END
	END
	
	CLOSE CocheChoferCur
	DEALLOCATE CocheChoferCur
END