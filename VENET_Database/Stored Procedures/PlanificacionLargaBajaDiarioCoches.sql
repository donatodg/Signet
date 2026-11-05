CREATE PROCEDURE [dbo].[PlanificacionLargaBajaDiarioCoches]
	@IdPlanificacion INT,
	@IdTipoServicio INT,
	@Fecha DATE,
	@IdUser INT  
AS
BEGIN

	--*****************************
	-- CORECCION DE VUELTAS
	--*****************************

	--AGREGAR
	 INSERT INTO CodigosServiciosFechas (Fecha,Id_Planificacion,Id_CodigoServicioVuelta,Id_Coche,Id_Personal1,Id_Personal2,Id_Personal3,Id_Estado,Comentario,Dia,FechaAdd,UserAdd)
	 SELECT @Fecha, @IdPlanificacion, csv.id, 0, 0, 0, 0, 1, '', 1, GETDATE(), 1
	 FROM PlanificacionLargaServicios pls
	 INNER JOIN CodigosServiciosVueltas csv on pls.Id_CodigoServicio = csv.Id_CodigoServicio
	 WHERE pls.id_planificacion = @IdPlanificacion 
	       AND pls.Fecha = @Fecha
	       AND pls.UserDel IS NULL
	       AND csv.UserDel IS NULL
	       AND csv.Id NOT IN (SELECT Id_CodigoServicioVuelta
							  FROM CodigosServiciosFechas
							  WHERE Fecha = @Fecha
							  AND Id_Planificacion = @IdPlanificacion
							  AND UserDel IS NULL)

	--BORRAR
	UPDATE CodigosServiciosFechas SET FechaDel = GETDATE(), UserDel = 1
	WHERE Id IN
	(SELECT csv.id
	 FROM PlanificacionLargaServicios pls
	 INNER JOIN CodigosServiciosVueltas csv ON pls.Id_CodigoServicio = csv.Id_CodigoServicio
	 WHERE pls.id_planificacion = @IdPlanificacion
	 AND pls.fecha = @Fecha
	 AND pls.UserDel IS NULL
	 AND csv.UserDel IS NOT NULL
	 AND csv.id IN (SELECT Id_CodigoServicioVuelta
					FROM CodigosServiciosFechas
					WHERE Fecha = @Fecha
					AND Id_Planificacion = @IdPlanificacion
					AND userdel IS NULL))
	--*****************************

	IF @IdTipoServicio = 0
		UPDATE CodigosServiciosFechas
		SET Id_Coche = NULL, UserMod = @IdUser, FechaMod = GETDATE()
		WHERE Id_Planificacion = @IdPlanificacion AND 
			  Fecha = @Fecha
	ELSE
		UPDATE CodigosServiciosFechas
		SET Id_Coche = NULL, UserMod = @IdUser, FechaMod = GETDATE()
		WHERE Id_Planificacion = @IdPlanificacion AND 
			  Fecha = @Fecha AND
			  Id_CodigoServicioVuelta IN (SELECT csv.Id 
										  FROM CodigosServiciosVueltas csv 
										  INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
										  WHERE cs.Id_TipoServicio = @IdTipoServicio AND
												cs.UserDel IS NULL AND
												csv.UserDel IS NULL)
	
	
	UPDATE CodigosServiciosFechas  
	SET Id_Coche = t.Id_Coche, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT pld.Id_Coche, Ids = csf.Id
	FROM PlanificacionLargaDetallesCoches pld 
	INNER JOIN CodigosServicios cs ON pld.Id_CodigoServicio = cs.Id
	INNER JOIN CodigosServiciosTodos cst ON cs.Id = cst.Id_CodigoServicio
	INNER JOIN CodigosServiciosVueltas csv ON cst.Id_CodigoServicio = csv.Id_CodigoServicio
	INNER JOIN CodigosServiciosFechas csf ON csv.Id = csf.Id_CodigoServicioVuelta
	WHERE pld.Id_Planificacion = @IdPlanificacion AND 
		  csf.Id_Planificacion = @IdPlanificacion AND 
		  pld.fecha = @Fecha AND 
		  csf.Fecha = @Fecha AND
		  (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0)) AS t
	WHERE Id = t.Ids

	-- TURNOS EXTENDIDOS
	UPDATE CodigosServiciosFechas
	SET Id_Coche = t.Id_Coche, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT Id_csf = csf.Id, plte.Id_Coche
	 FROM PlanificacionLargaCochesTurnoExtendido plte
	 INNER JOIN CodigosServiciosVueltas csv ON plte.Id_CodigoServicio = csv.Id_CodigoServicio AND plte.NroVuelta = csv.NroVuelta
	 INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	 INNER JOIN CodigosServiciosFechas csf ON csf.Id_CodigoServicioVuelta = csv.Id AND csf.Id_Planificacion = plte.Id_Planificacion AND plte.Fecha = csf.Fecha
	 WHERE plte.Id_Planificacion = @IdPlanificacion
	   AND plte.Fecha = @Fecha
	   AND plte.UserDel IS NULL
	   AND (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0)) AS t
	WHERE Id = t.Id_csf
	
	 
 END
