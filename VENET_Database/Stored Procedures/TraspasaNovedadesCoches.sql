CREATE PROCEDURE [dbo].[TraspasaNovedadesCoches]
AS
BEGIN

	DECLARE @IdComentario INT
	DECLARE @IdTipoComentario INT
	DECLARE @IdPlanificacion INT
	DECLARE @Descripcion VARCHAR(MAX)
	DECLARE @Observaciones VARCHAR(MAX)
	DECLARE @Comentario VARCHAR(MAX)
	DECLARE @Interno INT  
	DECLARE @Fecha DATETIME  
	 
--	--DECLARE @UltimaFecha DATETIME = (SELECT Max(UltimaFechaTaller) FROM Sincronizacion)
--BEGIN TRY

--	EXEC  [192.168.1.226].[ErsaGeneral].[dbo].[getDisables_Traspaso] --@UltimaFecha
--	--SET @UltimaFecha = GETDATE();

--	DECLARE curInterno CURSOR FOR
--		SELECT Interno, Descripcion, Observaciones, Fecha 
--			FROM [192.168.1.226].[ErsaGeneral].[dbo].[tmpBus]
		
--		OPEN curInterno
--			FETCH NEXT FROM curInterno INTO @Interno, @Descripcion, @Observaciones, @Fecha

--			WHILE @@FETCH_STATUS = 0
--			BEGIN
--				SET @Descripcion = RTRIM(LTRIM(@Descripcion))
--				SET @Observaciones = RTRIM(LTRIM(@Observaciones))
				
--				SELECT @IdPlanificacion = MAX(pdc.id)
--					FROM PlanificacionDetallesCoches pdc
--					INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
--					INNER JOIN Coches c ON pdc.Id_Coche = c.Id
--						WHERE c.Interno = @Interno
--							  AND p.UserDel IS NULL
--							  AND Year(Fecha) = Year(GETDATE())
--							  AND Month(Fecha) = Month(GETDATE())
--							  AND Day(Fecha) = Day(GETDATE())
				
--				IF @IdPlanificacion IS NOT NULL
--				BEGIN
--				SET @IdComentario = NULL
--				SET @IdTipoComentario = NULL

--					SELECT @IdComentario = Id, @Comentario = Comentario, @IdTipoComentario = Id_TipoComentario
--						FROM PlanificacionCochesComentarios 
--							WHERE Id_PlanificacionDetalleCoche = @IdPlanificacion
								
--					IF @IdComentario IS NULL
--					BEGIN
--						INSERT INTO PlanificacionCochesComentarios (Id_PlanificacionDetalleCoche,Id_TipoComentario,Comentario,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel)
--							VALUES (@IdPlanificacion, 4, @Descripcion + ' - ' + @Observaciones, GETDATE(), NULL, NULL, 1, NULL, NULL)
--					END
--					ELSE
--					BEGIN
--						IF @IdTipoComentario <> 4
--							UPDATE PlanificacionCochesComentarios
--							SET Id_TipoComentario = 4,
--								Comentario = @Comentario + ' - ' + @Descripcion + ' - ' + @Observaciones,
--								UserMod = 99,
--								FechaMod = GETDATE()
--							WHERE Id = @IdComentario
--					END
--				END
				
--				FETCH NEXT FROM curInterno INTO @Interno, @Descripcion, @Observaciones, @Fecha
--			END		
				
--		CLOSE curInterno 
--		DEALLOCATE curInterno
--	--UPDATE Sincronizacion SET UltimaFechaTaller = @UltimaFecha
--END TRY
-- BEGIN CATCH
--     PRINT 'Se ha producido un error'
-- END CATCH 	 
END