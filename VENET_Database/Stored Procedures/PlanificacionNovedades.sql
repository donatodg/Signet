CREATE PROCEDURE [dbo].[PlanificacionNovedades]
	@IdPlanificacion INT = 141,
	@BorraFrancoCoches INT = 0
AS
BEGIN

	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @FechaNovedad DATE
	DECLARE @IdPersonal INT
	DECLARE @IdPersonalNovedades INT
	DECLARE @IdNovedad INT
	DECLARE @Novedad Varchar(5)
	DECLARE @Observacion Varchar(100)
	DECLARE @Borrada INT = 0
	 	
	SELECT @Desde = FechaDesde, @Hasta = FechaHasta
		FROM Planificacion 
			WHERE Id = @IdPlanificacion
		
	DECLARE Nov_cur CURSOR FOR
		SELECT p.Fecha, p.Id_Personal, n.Descripcion, p.Id, ISNULL(p.UserDel, 0), p.Observaciones, p.Id_TipoNovedad
			FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
				WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
					  n.UserDel IS NULL AND
					  p.Id_Personal IN (SELECT DISTINCT(Id_Personal) FROM PlanificacionDetalles WHERE Id_Planificacion = @IdPlanificacion)
	OPEN Nov_cur

	FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdPersonalNovedades, @Borrada, @Observacion, @IdNovedad

	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @BorraFrancoCoches = 1 AND @Observacion = 'Franco Coche'
			BEGIN
				UPDATE PlanificacionDetalles 
					SET Novedad = '', Id_Servicio = 0, Id_Novedad = 0
						WHERE Fecha = @FechaNovedad AND Id_Personal = @IdPersonal AND Id_Planificacion = @IdPlanificacion
				UPDATE PersonalNovedades
					SET FechaDel = GETDATE(), UserDel = 1
						WHERE Id = @IdPersonalNovedades							
			END
			ELSE
			BEGIN
				IF @Borrada = 0
					UPDATE PlanificacionDetalles 
						SET Novedad = @Novedad, Id_Servicio = 0, Id_Novedad = @IdNovedad
							WHERE Fecha = @FechaNovedad AND Id_Personal = @IdPersonal  
				ELSE
					IF (SELECT TOP 1 Id_Novedad FROM PlanificacionDetalles WHERE Id_Planificacion = @IdPlanificacion AND Fecha = @FechaNovedad AND Id_Personal = @IdPersonal AND UserDel IS NULL) = @IdNovedad
						UPDATE PlanificacionDetalles 
							SET Novedad = '', Id_Servicio = 0, Id_Novedad = 0
								WHERE Fecha = @FechaNovedad AND Id_Personal = @IdPersonal 
			END
			
			FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdPersonalNovedades, @Borrada, @Observacion, @IdNovedad
		END 
		
	CLOSE Nov_cur 
	DEALLOCATE Nov_cur 
	
END