CREATE PROCEDURE [dbo].[ReporteCochesPorFechasFlota]
	@FechaDesde DATE  = '20160214',
	@FechaHasta DATE  = '20160214',
	@IdUN INT = 0,
	@IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	IF (@IdUN = 3 OR @IdUN = 23)
		SELECT DISTINCT(c.Interno), c.Dominio, UnidadNegocio = u.Descripcion
		   FROM PlanificacionDetallesCoches pdc
		   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
		   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		   WHERE pdc.UserDel IS NULL
			 AND p.UserDel IS NULL
			 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
			 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
			 AND (p.Id_UnidadNegocio = 3 OR p.Id_UnidadNegocio = 23)
			 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	
	IF (@IdUN = 29 OR @IdUN = 5 OR @IdUN = 26)
		SELECT DISTINCT(c.Interno), c.Dominio, UnidadNegocio = u.Descripcion
			FROM Coches c
			INNER JOIN UnidadNegocios u ON c.Id_UnidadNegocio = u.Id
			WHERE c.Id_UnidadNegocio = @IdUN
			 AND c.UserDel IS NULL 

	IF (@IdUN <> 3 AND @IdUN <> 23 AND @IdUN <> 29 AND @IdUN <> 5 AND @IdUN <> 26 AND @IdUN <> 0)
		SELECT DISTINCT(c.Interno), c.Dominio, UnidadNegocio = u.Descripcion
		   FROM PlanificacionDetallesCoches pdc
		   INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
		   INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		   INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		   WHERE pdc.UserDel IS NULL
			 AND p.UserDel IS NULL
			 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
			 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
			 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0)	
			 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))  
	
	IF (@IdUN = 0)
		SELECT DISTINCT(c.Interno), c.Dominio, UnidadNegocio = u.Descripcion
		   FROM Coches c  
		   INNER JOIN UnidadNegocios u ON c.Id_UnidadNegocio = u.Id
		   WHERE C.UserDel IS NULL
			 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1942,1272,1273,1274,1275,1276,1277,1278)
			 AND (@IdUser = 0 OR c.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))  
	
END