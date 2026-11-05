CREATE PROCEDURE [dbo].[ReporteCochesPorFechasCabecera]
	@FechaDesde DATE  = '20160107',
	@FechaHasta DATE  = '20160107',
	@IdUN INT = 0,
	@IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	DECLARE @TotalCoches INT
	DECLARE @CochesPlanificadosUtilizados INT
	DECLARE @CochesPlanificadosNoUtilizados INT
	DECLARE @Ejecutados INT
	DECLARE @Taller INT

	--***************************************************************************
	-- @TotalCoches
	--***************************************************************************
	IF (@IdUN = 3 OR @IdUN = 23)
		SET	@TotalCoches = (SELECT COUNT(DISTINCT(pdc.Id_Coche))
						   FROM PlanificacionDetallesCoches pdc
						   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
						   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
						   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
						   WHERE pdc.UserDel IS NULL
							 AND p.UserDel IS NULL
							 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
							 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
							 AND (p.Id_UnidadNegocio = 3 OR p.Id_UnidadNegocio = 23)
							 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))) 

	IF (@IdUN <> 3 AND @IdUN <> 23 AND @IdUN <> 29 AND @IdUN <> 5 AND @IdUN <> 26 AND @IdUN <>0)
		SET	@TotalCoches = (SELECT COUNT(DISTINCT(pdc.Id_Coche))
						   FROM PlanificacionDetallesCoches pdc
						   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
						   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
						   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
						   WHERE pdc.UserDel IS NULL
							 AND p.UserDel IS NULL
							 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
							 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
							 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0)	
							 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))) 

	IF (@IdUN = 29 OR @IdUN = 5 OR @IdUN = 26)
		SET	@TotalCoches = (SELECT COUNT(DISTINCT(c.Id))
						   FROM Coches c
						   WHERE c.Id_UnidadNegocio = @IdUN
							 AND c.UserDel IS NULL)
	IF (@IdUN = 0)
		SET	@TotalCoches = (SELECT COUNT(DISTINCT(c.Id))
						    FROM Coches c
						    INNER JOIN UnidadNegocios u ON c.Id_UnidadNegocio = u.Id
							WHERE c.UserDel IS NULL
							  AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278))
	 
	--***************************************************************************
	-- @CochesPlanificadosUtilizados
	--***************************************************************************
	SET	@CochesPlanificadosUtilizados = (SELECT COUNT(*) FROM
										 (SELECT DISTINCT(internoPlanificado), fecha
										 FROM [ErsaGeneral_WebTrafico].[dbo].[registros] r
										 WHERE r.Fecha BETWEEN @FechaDesde AND @FechaHasta
										  AND (r.IdUnidad = @IdUN OR @IdUN = 0)
										  AND r.InternoPlanificado > 0
										  AND (@IdUser = 0 OR r.IdUnidad IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
										 GROUP BY internoPlanificado, fecha) AS T) 
	
	--***************************************************************************
	-- @CochesPlanificadosNoUtilizados
	--***************************************************************************
	IF (@IdUN = 29 OR @IdUN = 5 OR @IdUN = 26 OR @IdUN = 0)
		SET	@CochesPlanificadosNoUtilizados = (@TotalCoches * (DATEDIFF(D, @FechaDesde, @FechaHasta) + 1)) - @CochesPlanificadosUtilizados
	ELSE 
		SET	@CochesPlanificadosNoUtilizados = (SELECT COUNT((pdc.Id_Coche))
											   FROM PlanificacionDetallesCoches pdc
											   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
											   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
											   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
											   WHERE pdc.UserDel IS NULL
												 AND p.UserDel IS NULL
												 AND pdc.Id_Servicio = 0
												 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
												 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
												 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0))
	
	--***************************************************************************
	-- @Ejecutados
	--***************************************************************************
	SET @Ejecutados = (SELECT COUNT(*) FROM
					 (SELECT DISTINCT(internoEjecutado)
					  FROM [ErsaGeneral_WebTrafico].[dbo].[registros] r
					  WHERE r.Fecha BETWEEN @FechaDesde AND @FechaHasta
					   AND (r.IdUnidad = @IdUN OR @IdUN = 0)
					   AND (@IdUser = 0 OR r.IdUnidad IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
					   AND r.internoEjecutado > 0
					  GROUP BY internoEjecutado, fecha) AS T) 
	
	--***************************************************************************
	-- @Taller
	--***************************************************************************
	SET @Taller = (SELECT COUNT(pcc.Id_PlanificacionDetalleCoche)
					   FROM PlanificacionDetallesCoches pdc  
					   INNER JOIN PlanificacionCochesComentarios pcc ON pdc.Id = pcc.Id_PlanificacionDetalleCoche
					   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
					   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
					   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
					   WHERE pdc.UserDel IS NULL
						 AND p.UserDel IS NULL
						 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
						 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
						 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0)
						 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
						 AND pcc.UserDel IS NULL) 
		--CochesPlanificadosNoUtilizados = (SELECT COUNT((pdc.Id_Coche))
		--							      FROM PlanificacionDetallesCoches pdc
		--							      INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
		--							      INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		--								  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		--							      WHERE pdc.UserDel IS NULL
		--							    	 AND p.UserDel IS NULL
		--							    	 AND pdc.Id_Servicio =  0
		--									 AND c.Id not in (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1272,1273,1274,1275,1276,1277,1278)
		--							    	 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
		--							    	 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0))
	 
	--***************************************************************************
	-- TOTALES
	--***************************************************************************
	SELECT TotalCoches = @TotalCoches, 
		   CochesPlanificadosUtilizados = @CochesPlanificadosUtilizados,
		   Ejecutados = @Ejecutados, 
		   Taller = @Taller, 
		   CochesPlanificadosNoUtilizados = @CochesPlanificadosNoUtilizados
		    
END