
CREATE PROCEDURE [dbo].[PlanificacionFrancoFijo]
	@Id_Planificacion INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Id INT
	DECLARE @Id_Personal INT 
	DECLARE @Fecha DATETIME
	DECLARE @Franco INT
	DECLARE @Id_Personal_ANT INT = 0
	DECLARE @CountFranco INT

	DECLARE curFijos CURSOR FOR
		SELECT pd.Id, Id_Personal, Fecha, LaboralFrancoDias
			FROM PlanificacionDetalles pd 
			INNER JOIN Personal p ON pd.Id_Personal = p.Id 
				WHERE pd.Id_Planificacion = @Id_Planificacion AND 
					  p.LaboralFrancoDias > 0  
		ORDER BY Id_Personal, Fecha

	OPEN curFijos
	FETCH NEXT FROM curFijos INTO @Id, @Id_Personal, @Fecha, @Franco

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		--BUSCAR ULTIMA NOVEDAD
		IF @Id_Personal <> @Id_Personal_ANT
		BEGIN
	
			SET @CountFranco = 0
			
			SELECT @CountFranco = DATEDIFF(d, MAX(FECHA), @Fecha) -1
				FROM PlanificacionDetalles pd INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
					WHERE p.FechaDel IS NULL AND
						  pd.Id_Personal = @Id_Personal AND 
						  p.Id < @Id_Planificacion AND
						  (pd.Id_Novedad = 1 OR pd.Id_Novedad = 3)
			
			IF @CountFranco < 0 or @CountFranco IS NULL
				SET @CountFranco = 0
			
			IF @CountFranco > @Franco
				SET @CountFranco = @Franco
			
			--IF @CountFranco > @Franco
			--	SET @CountFranco = 0
	
		 END
	
		IF @CountFranco = @Franco
		BEGIN
			UPDATE PlanificacionDetalles
				SET Id_Servicio = 0, Novedad = 'F', Id_Novedad = 1
			WHERE Id = @Id
			
			IF (SELECT ISNULL(COUNT(Id),0) FROM PersonalNovedades WHERE Fecha = @Fecha AND Id_Personal = @Id_Personal AND UserDel IS NULL) = 0
				INSERT INTO PersonalNovedades (Fecha,Id_Personal,Id_TipoNovedad,Observaciones,FechaAdd,UserAdd)
					VALUES (@Fecha, @Id_Personal, 1, 'Franco Coche', GETDATE(), 1)
			
			SET @CountFranco = 0
		END
		ELSE
			SET @CountFranco = @CountFranco + 1
	
		SET @Id_Personal_ANT = @Id_Personal
		
		FETCH NEXT FROM curFijos INTO @Id, @Id_Personal, @Fecha, @Franco
	END
			
	CLOSE curFijos 
	DEALLOCATE curFijos
 	 

END