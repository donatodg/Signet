CREATE PROCEDURE [dbo].[CodigosServiciosConViaticos]
	@Id_Empresa INT = NULL,
	@Id_Linea INT = NULL,
	@Id_Ramal INT = NULL,
	@Id_TipoServicio INT = NULL

AS
BEGIN
	
	SELECT  
		Empresa = e.Nombre,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Codigo = cs.codigo,
		Descripcion = cs.descripcion,
		Citacion = CONVERT(VARCHAR, cs.horacitacion, 108),
		Finalizacion = CONVERT(VARCHAR, cs.horaFinalizacion, 108),
		ViaticosCantidad = (SELECT COUNT(*) FROM CodigosServiciosViaticos WHERE UserDel IS NULL AND Id_CodigoServicio = cs.id) ,
		Viaticos= (SELECT ISNULL(STUFF((SELECT CAST(', ' AS VARCHAR(MAX)) +  tv.Descripcion 
										FROM CodigosServiciosViaticos csv
										INNER JOIN TipoViaticos tv ON csv.Id_TipoViatico = tv.Id
										WHERE csv.UserDel IS NULL AND csv.Id_CodigoServicio = cs.id
										FOR XML PATH('')), 1, 1, ''), '')),
		Choferes = cs.CantidadChoferes,
		AplicaDias = SUBSTRING((SELECT CASE WHEN Lunes = 1 THEN ', Lunes' ELSE '' END + 
									   CASE WHEN Martes = 1 THEN ', Martes' ELSE '' END + 
									   CASE WHEN Miercoles = 1 THEN ', Miercoles' ELSE '' END + 
									   CASE WHEN Jueves = 1 THEN ', Jueves' ELSE '' END + 
									   CASE WHEN Viernes = 1 THEN ', Viernes' ELSE '' END + 
									   CASE WHEN Sabado = 1 THEN ', Sabado' ELSE '' END + 
									   CASE WHEN Domingo = 1 THEN ', Domingo' ELSE '' END + 
									   CASE WHEN Feriado = 1 THEN ', Feriado' ELSE '' END
								  FROM CodigosServicios	
								  WHERE UserDel IS NULL AND Id = cs.Id), 3, 100),
		--Lunes,
		--Martes,
		--Miercoles,
		--Jueves,
		--Viernes,
		--Sabado,
		--Domingo,
		--Feriado,
		Id_UnidadNegocio = l.Id_UnidadNegocio
	FROM codigosservicios cs
	INNER JOIN TipoServicios ts ON cs.id_tiposervicio = ts.id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN Lineas l ON r.Id_Linea = l.Id
	INNER JOIN Empresas e ON l.Id_Empresa = e.Id
	WHERE cs.UserDel IS NULL
		  AND (e.Id = @Id_Empresa OR @Id_Empresa IS NULL)
		  AND (l.Id = @Id_Linea OR @Id_Linea IS NULL)
		  AND (r.Id = @Id_Ramal OR @Id_Ramal IS NULL)
		  AND (ts.Id = @Id_TipoServicio OR @Id_TipoServicio IS NULL)

END