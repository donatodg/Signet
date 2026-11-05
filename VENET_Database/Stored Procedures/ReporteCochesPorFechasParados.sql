CREATE PROCEDURE [dbo].[ReporteCochesPorFechasParados]
	@FechaDesde DATE  = '20160107',
	@FechaHasta DATE  = '20160107',
	@IdUN INT = 0,
	@IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	Create Table #Tmp
	(
		Fecha DATETIME,
		Interno INT,
		Dominio VARCHAR(10),
		UnidadNegocio VARCHAR(50)
	)

	DECLARE @Desde2 DATE


	IF (@IdUN <> 29 AND @IdUN <> 5 AND @IdUN <> 26 AND @IdUN <> 0)
		INSERT INTO #Tmp
		SELECT Fecha, c.Interno, c.Dominio, UnidadNegocio = u.Descripcion
			FROM PlanificacionDetallesCoches pdc
			INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
			INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
			INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			WHERE pdc.UserDel IS NULL
	  		 AND p.UserDel IS NULL
	  		 AND pdc.Id_Servicio =  0
	  		 AND c.Id not in (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
	  		 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
	  		 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0)

	 
	IF (@IdUN = 29 OR @IdUN = 5 OR @IdUN = 26)
	BEGIN
 		SET @Desde2 = @FechaDesde

		WHILE @Desde2 <= @FechaHasta
		BEGIN
			
			INSERT INTO #Tmp
			SELECT @Desde2, c.Interno, c.Dominio, UnidadNegocio = u.Descripcion
			FROM Coches c 
			INNER JOIN UnidadNegocios u ON c.Id_UnidadNegocio = u.Id
			LEFT JOIN (SELECT DISTINCT(internoPlanificado) as Interno
								   FROM [ErsaGeneral_WebTrafico].[dbo].[registros] r
								   WHERE r.Fecha = @Desde2
								    AND (r.IdUnidad = @IdUN OR @IdUN = 0)
								    AND r.InternoPlanificado > 0
								    GROUP BY internoPlanificado, fecha) AS t ON c.interno = t.Interno
			WHERE (c.Id_UnidadNegocio = @IdUN OR @IdUN = 0)
			  AND (@IdUser = 0 OR c.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	  		  AND c.Id not in (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
			  AND t.Interno IS NULL
		
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	END

	IF (@IdUN = 0)
	BEGIN
		SET @Desde2 = @FechaDesde

		WHILE @Desde2 <= @FechaHasta
		BEGIN
			
			INSERT INTO #Tmp
			SELECT @Desde2, c.Interno, c.Dominio, UnidadNegocio = u.Descripcion
			FROM Coches c 
			INNER JOIN UnidadNegocios u ON c.Id_UnidadNegocio = u.Id
			LEFT JOIN (SELECT DISTINCT(internoPlanificado) as Interno
								   FROM [ErsaGeneral_WebTrafico].[dbo].[registros] r
								   WHERE r.Fecha = @Desde2
								    AND r.InternoPlanificado > 0
								   GROUP BY internoPlanificado, fecha) AS t ON c.interno = t.Interno
			WHERE (c.Id_UnidadNegocio = @IdUN OR @IdUN = 0)
			  AND (@IdUser = 0 OR c.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	  		  AND c.Id not in (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
			  AND t.Interno IS NULL
		
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	END


	SELECT * FROM #Tmp  
END

 