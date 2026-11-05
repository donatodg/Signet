CREATE PROCEDURE [dbo].[PlanificacionLargaBajaDiario]
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
	 INSERT INTO CodigosServiciosFechas(Fecha,Id_Planificacion,Id_CodigoServicioVuelta,Id_Coche,Id_Personal1,Id_Personal2,Id_Personal3,Id_Estado,Comentario,Dia,FechaAdd,UserAdd)
	 SELECT @Fecha, @IdPlanificacion, csv.id, 0, 0, 0, 0, 1, '', 1, GETDATE(), 1
	 FROM PlanificacionLargaServicios pls
	 INNER JOIN codigosserviciosvueltas csv on pls.Id_CodigoServicio = csv.Id_CodigoServicio
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
	 INNER JOIN codigosserviciosvueltas csv ON pls.Id_CodigoServicio = csv.Id_CodigoServicio
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
		SET Id_Personal1 = NULL, Id_Personal2 = NULL, Id_Personal3 = NULL, UserMod = @IdUser, FechaMod = GETDATE()
		WHERE Id_Planificacion = @IdPlanificacion AND 
			  Fecha = @Fecha
	ELSE
		UPDATE CodigosServiciosFechas
		SET Id_Personal1 = NULL, Id_Personal2 = NULL, Id_Personal3 = NULL, UserMod = @IdUser, FechaMod = GETDATE()
		WHERE Id_Planificacion = @IdPlanificacion AND 
			  Fecha = @Fecha AND
			  Id_CodigoServicioVuelta IN (SELECT csv.Id 
										  FROM CodigosServiciosVueltas csv 
										  INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
										  WHERE cs.Id_TipoServicio = @IdTipoServicio AND
												cs.UserDel IS NULL AND
												csv.UserDel IS NULL)
	
	UPDATE CodigosServiciosFechas  
	SET Id_Personal1 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT pld.Id_Personal, Ids = csf.Id
	FROM PlanificacionLargaDetalles pld 
	INNER JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	INNER JOIN CodigosServiciosVueltas csv ON cst.Id_CodigoServicio = csv.Id_CodigoServicio
	INNER JOIN CodigosServiciosFechas csf ON csv.Id = csf.Id_CodigoServicioVuelta
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	WHERE pld.Id_Planificacion = @IdPlanificacion AND 
		  csf.Id_Planificacion = @IdPlanificacion AND 
		  pld.fecha = @Fecha AND 
		  csf.Fecha = @Fecha AND
		  (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) AND
		  Id_CodigoServicioTodos LIKE '1%') as t
	WHERE Id = t.Ids

	UPDATE CodigosServiciosFechas  
	SET Id_Personal2 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT pld.Id_Personal, Ids = csf.Id
	FROM PlanificacionLargaDetalles pld 
	INNER JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	INNER JOIN CodigosServiciosVueltas csv ON cst.Id_CodigoServicio = csv.Id_CodigoServicio
	INNER JOIN CodigosServiciosFechas csf ON csv.Id = csf.Id_CodigoServicioVuelta
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	WHERE pld.Id_Planificacion = @IdPlanificacion AND 
		  csf.Id_Planificacion = @IdPlanificacion AND 
		  pld.fecha = @Fecha AND 
		  csf.Fecha = @Fecha AND
		  (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) AND
		  Id_CodigoServicioTodos LIKE '2%') as t
	WHERE Id = t.Ids

	UPDATE CodigosServiciosFechas 
	SET Id_Personal3 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT pld.Id_Personal, Ids = csf.Id
	FROM PlanificacionLargaDetalles pld 
	INNER JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
	INNER JOIN CodigosServiciosVueltas csv ON cst.Id_CodigoServicio = csv.Id_CodigoServicio
	INNER JOIN CodigosServiciosFechas csf ON csv.Id = csf.Id_CodigoServicioVuelta
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	WHERE pld.Id_Planificacion = @IdPlanificacion AND 
		  csf.Id_Planificacion = @IdPlanificacion AND 
		  pld.fecha = @Fecha AND 
		  csf.Fecha = @Fecha AND
		  (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) AND
		  Id_CodigoServicioTodos LIKE '9%') as t
	WHERE Id = t.Ids

	-- TURNOS EXTENDIDOS
	UPDATE CodigosServiciosFechas
	SET Id_Coche = t.Id_Coche, Id_Personal1 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT Id_csf = csf.Id, plte.Id_Coche, plte.Id_Personal 
	 FROM PlanificacionLargaTurnoExtendido plte
	 INNER JOIN CodigosServiciosVueltas csv ON plte.Id_CodigoServicio = csv.Id_CodigoServicio AND plte.NroVuelta = csv.NroVuelta
	 INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	 INNER JOIN CodigosServiciosFechas csf ON csf.Id_CodigoServicioVuelta = csv.Id AND csf.Id_Planificacion = plte.Id_Planificacion AND plte.Fecha = csf.Fecha
	 WHERE plte.Id_Planificacion = @IdPlanificacion
	   AND plte.Fecha = @Fecha
	   AND plte.UserDel IS NULL
	   AND (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) 
		AND Id_CodigoServicioTodos LIKE '1%') AS t
	WHERE Id = t.Id_csf
	
	UPDATE CodigosServiciosFechas
	SET Id_Coche = t.Id_Coche, Id_Personal2 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT Id_csf = csf.Id, plte.Id_Coche, plte.Id_Personal 
	 FROM PlanificacionLargaTurnoExtendido plte
	 INNER JOIN CodigosServiciosVueltas csv ON plte.Id_CodigoServicio = csv.Id_CodigoServicio AND plte.NroVuelta = csv.NroVuelta
	 INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	 INNER JOIN CodigosServiciosFechas csf ON csf.Id_CodigoServicioVuelta = csv.Id AND csf.Id_Planificacion = plte.Id_Planificacion AND plte.Fecha = csf.Fecha
	 WHERE plte.Id_Planificacion = @IdPlanificacion
	   AND plte.Fecha = @Fecha
	   AND plte.UserDel IS NULL
	   AND (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) 
		AND Id_CodigoServicioTodos LIKE '2%') AS t
	WHERE Id = t.Id_csf
	
	UPDATE CodigosServiciosFechas
	SET Id_Coche = t.Id_Coche, Id_Personal3 = t.Id_Personal, UserMod = @IdUser, FechaMod = GETDATE()
	FROM
	(SELECT Id_csf = csf.Id, plte.Id_Coche, plte.Id_Personal 
	 FROM PlanificacionLargaTurnoExtendido plte
	 INNER JOIN CodigosServiciosVueltas csv ON plte.Id_CodigoServicio = csv.Id_CodigoServicio AND plte.NroVuelta = csv.NroVuelta
	 INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	 INNER JOIN CodigosServiciosFechas csf ON csf.Id_CodigoServicioVuelta = csv.Id AND csf.Id_Planificacion = plte.Id_Planificacion AND plte.Fecha = csf.Fecha
	 WHERE plte.Id_Planificacion = @IdPlanificacion
	   AND plte.Fecha = @Fecha
	   AND plte.UserDel IS NULL
	   AND (cs.Id_TipoServicio = @IdTipoServicio OR @IdTipoServicio = 0) 
		AND Id_CodigoServicioTodos LIKE '9%') AS t
	WHERE Id = t.Id_csf
  
END