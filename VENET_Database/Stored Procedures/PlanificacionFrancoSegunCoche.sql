CREATE PROCEDURE [dbo].[PlanificacionFrancoSegunCoche]
	@IdPlanificacion INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Fecha DATE 
	DECLARE @IdCoche INT 
	DECLARE @IdPersonal INT  
	DECLARE @Turno INT  
	
	--INICIALIZA TODO
	UPDATE PlanificacionDetalles
		SET Id_Servicio = 0, Novedad = '', Id_Novedad = 0
	WHERE Id_Planificacion = @IdPlanificacion

	--TRASPASA NOVEDADES
	EXEC PlanificacionNovedades @IdPlanificacion, 1
	
	--PASA FRANCOS EXCLUYENDO FRANCOS FIJOS
	UPDATE PlanificacionDetalles
		SET Id_Servicio = 0, Novedad = 'F', Id_Novedad = 1
	FROM PlanificacionDetallesCoches pdc
		INNER JOIN PlanificacionDetalles pd ON pdc.Id_Planificacion = pd.Id_Planificacion AND pdc.Id_Coche = pd.Id_Coche AND pdc.Fecha = pd.Fecha
		INNER JOIN Personal p ON pd.Id_Personal = p.Id 
	WHERE pdc.Id_Planificacion = @IdPlanificacion AND 
		  pdc.Id_Servicio = 0 AND
		  pd.Id_Novedad = 0 AND
		  p.LaboralFrancoDias = 0 AND
		  (pd.Id_Novedad IS NULL OR pd.Id_Novedad = 0)
	
	DECLARE curNov CURSOR FOR
		SELECT Fecha, Id_Personal
			FROM PlanificacionDetalles
				WHERE Id_Planificacion = @IdPlanificacion AND
					  Id_Novedad = 1
	OPEN curNov
	
	FETCH NEXT FROM curNov INTO @Fecha, @IdPersonal

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (SELECT ISNULL(COUNT(Id),0) FROM PersonalNovedades WHERE Fecha = @Fecha AND Id_Personal = @IdPersonal AND UserDel IS NULL) = 0
			INSERT INTO PersonalNovedades (Fecha,Id_Personal,Id_TipoNovedad,Observaciones,FechaAdd,UserAdd)
				VALUES (@Fecha, @IdPersonal, 1, 'Franco Coche', GETDATE(), 1)
		
		FETCH NEXT FROM curNov INTO @Fecha, @IdPersonal
	END
		 
	CLOSE curNov 
	DEALLOCATE curNov
		  
	--PASAR FRANCOS FIJOS CADA X DIAS
	EXEC PlanificacionFrancoFijo @IdPlanificacion
		  
	--ASIGNA SERVICIOS FIJOS
	DECLARE curFijos CURSOR FOR
		SELECT Fecha, Id_Coche, Id_Personal, LaboralTurnoFijo
			FROM PlanificacionDetalles pd
			INNER JOIN Personal p ON pd.Id_Personal = p.Id
				WHERE pd.Id_Planificacion = @IdPlanificacion AND
					  pd.Id_Novedad = 0 AND
					  p.LaboralTurnoFijo < 4

	OPEN curFijos
		FETCH NEXT FROM curFijos INTO @Fecha, @IdCoche, @IdPersonal, @Turno 

		WHILE @@FETCH_STATUS = 0
		BEGIN

			EXEC AsignaServicio @IdPlanificacion, @Fecha, @IdCoche, @IdPersonal, @Turno
			
			FETCH NEXT FROM curFijos INTO @Fecha, @IdCoche, @IdPersonal, @Turno 
		END
			
	CLOSE curFijos 
	DEALLOCATE curFijos
		 
	
	
	--ROTACION DE CHOFERES
	EXEC PlanificacionRotacionChoferes @IdPlanificacion
END
