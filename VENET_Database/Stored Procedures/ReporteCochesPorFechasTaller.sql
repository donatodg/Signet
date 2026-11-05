create PROCEDURE ReporteCochesPorFechasTaller
	@FechaDesde DATE  = '20160211',
	@FechaHasta DATE  = '20160211',
	@IdUN INT = 0,
	@IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	SELECT Fecha, Interno, Dominio, Taller = Comentario, Unidad_Negocio = u.Descripcion 
		FROM PlanificacionDetallesCoches pdc  
		INNER JOIN PlanificacionCochesComentarios pcc ON pdc.Id = pcc.Id_PlanificacionDetalleCoche
		INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
		INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		WHERE pdc.UserDel IS NULL
		 AND p.UserDel IS NULL
		 AND c.Id NOT IN  (1091,1255,1256,1257,1258,1259,1260,1261,1262,1263,1264,1265,1266,1267,1268,1269,1270,1271,1937,1938,1939,1940,1941,1272,1273,1274,1275,1276,1277,1278)
		 AND pdc.Fecha BETWEEN @FechaDesde AND @FechaHasta
		 AND (p.Id_UnidadNegocio = @IdUN OR @IdUN = 0)
		 AND (@IdUser = 0 OR p.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		 AND pcc.UserDel IS NULL
END