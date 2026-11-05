CREATE PROCEDURE [dbo].[ServiciosPorFechas] 
	@Id_User INT = 1,
	@Id_TipoServicio INT = 62,
	@Id_Ramal INT = 69,
	@Id_Linea INT = 16,
	@Id_Empresa INT = 3,
	@FechaDesde DATETIME = '20150101',
	@FechaHasta DATETIME = '20160101'
AS
BEGIN
	
	If (SELECT g.EsAdministrador FROM SeguridadUsuarios u INNER JOIN SeguridadGrupos g ON u.Id_Grupo = g.Id WHERE u.Id = @Id_User) = 1
		SET @Id_User = 0

	SELECT DISTINCT(csf.Fecha),
		   Dia = DATENAME(dw, csf.Fecha),
	       CantidadServicios = COUNT(DISTINCT(csv.Id_CodigoServicio)),
		   Linea = l.Descripcion,
		   Ramal = r.Descripcion,
		   Servicio = ts.Descripcion,
		   Id_Linea,
		   Id_Ramal,
		   Id_TipoServicio
	FROM CodigosServiciosFechas csf
	INNER JOIN CodigosServiciosVueltas csv ON csf.id_codigoServicioVuelta = csv.Id
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN Lineas l ON r.Id_Linea = l.Id
	INNER JOIN SeguridadUsuariosUnidadNegocios s ON l.Id_UnidadNegocio = s.Id_UnidadNegocio
	WHERE (ts.Id = @Id_TipoServicio OR @Id_TipoServicio = 0) AND
		  (r.Id = @Id_Ramal OR @Id_Ramal = 0) AND
		  (l.Id = Id_Linea OR Id_Linea = 0) AND
		  (l.Id_Empresa = @Id_Empresa OR @Id_Empresa = 0) AND
		  (s.Id_Usuario = @Id_User OR @Id_User = 0) AND
		  csf.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
		  csf.UserDel IS NULL AND
		  csv.UserDel IS NULL AND
		  s.UserDel IS NULL 
	GROUP BY csf.Fecha,l.Descripcion, r.Descripcion, ts.Descripcion, Id_Linea, Id_Ramal, Id_TipoServicio
	ORDER BY csf.Fecha
END
