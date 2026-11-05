CREATE PROCEDURE [dbo].[CodigosServiciosPorFechaPorChofer]
	 @FechaDesde DATETIME = '20151201',
	 @FechaHasta DATETIME = '20151231',
	 @IdUser INT = 1,
	 @IdEmpresa INT = NULL,
	 @IdLinea INT = NULL, 
	 @IdRamal INT = NULL,
	 @IdTipoServicio INT = NULL,
	 @IdPersonal INT = NULL
 
 AS
 BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0
 
	SELECT  
		Fecha = csf.Fecha,
		Id_UnidadNegocio = u.Id,
		UnidadNegocio = u.Descripcion,
		Empresa = e.Nombre,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Origen = (SELECT TOP 1 s.Descripcion
				  FROM CodigosServiciosVueltasDetalle csvd 
				  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Inicio = (SELECT TOP 1 csvd.Hora
				  FROM CodigosServiciosVueltasDetalle csvd 
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Destino = (SELECT TOP 1 s.Descripcion
				   FROM CodigosServiciosVueltasDetalle csvd 
				   INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
		 			 AND csvd.UserDel IS NULL
				   ORDER BY Dia DESC, Hora DESC),
		Fin = (SELECT TOP 1 csvd.Hora
			   FROM CodigosServiciosVueltasDetalle csvd 
			   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
	  			 AND csvd.UserDel IS NULL
			   ORDER BY Dia DESC, Hora DESC),
		Sentido = csv.Sentido,
		Codigo = cs.Codigo,
		Descripcion = cs.Descripcion,
		Citacion = cs.HoraCitacion,
		Finalizacion = cs.HoraFinalizacion,
		Id_TipoCodigoServicio = cs.Id_TipoCodigoServicio, 
		TipoCodigoServicio = tcs.Descripcion,
		CantidadChoferes = cs.CantidadChoferes, 
		Auxiliar = cs.Auxiliar,
		Interno = c.Interno,
		Dominio = c.Dominio,
		Legajo = p.LaboralLegajo,
		Chofer = p.Apellido + ', ' + p.Nombre,
		Id_Estado = csf.Id_Estado,
		Estado = cse.Descripcion,
		Comentario = csf.Comentario
	FROM CodigosServiciosFechas csf
		INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
		INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
		LEFT JOIN TipoCodigoServicio tcs ON cs.Id_TipoCodigoServicio = tcs.Id
		INNER JOIN CodigosServiciosEstados cse ON csf.Id_Estado = cse.Id
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
		LEFT JOIN Coches c ON csf.Id_coche = c.Id
		INNER JOIN Personal p ON csf.Id_Personal1 = p.Id
	WHERE csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND csf.Userdel IS NULL
		AND csv.Userdel IS NULL
		AND csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND (@IdPersonal IS NULL OR p.Id = @IdPersonal)
		AND (@IdEmpresa IS NULL OR e.Id = @IdEmpresa)
		AND (@IdLinea IS NULL OR l.Id = @IdLinea)
		AND (@IdRamal IS NULL OR r.Id = @IdRamal)
		AND (@IdTipoServicio IS NULL OR ts.Id = @IdTipoServicio)
		AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
		AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		AND csv.NroVuelta = 1

	UNION

	SELECT  
		Fecha = csf.Fecha,
		Id_UnidadNegocio = u.Id,
		UnidadNegocio = u.Descripcion,
		Empresa = e.Nombre,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Origen = (SELECT TOP 1 s.Descripcion
				  FROM CodigosServiciosVueltasDetalle csvd 
				  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Inicio = (SELECT TOP 1 csvd.Hora
				  FROM CodigosServiciosVueltasDetalle csvd 
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Destino = (SELECT TOP 1 s.Descripcion
				   FROM CodigosServiciosVueltasDetalle csvd 
				   INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
		 			 AND csvd.UserDel IS NULL
				   ORDER BY Dia DESC, Hora DESC),
		Fin = (SELECT TOP 1 csvd.Hora
			   FROM CodigosServiciosVueltasDetalle csvd 
			   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
	  			 AND csvd.UserDel IS NULL
			   ORDER BY Dia DESC, Hora DESC),
		Sentido = csv.Sentido,
		Codigo = cs.Codigo,
		Descripcion = cs.Descripcion,
		Citacion = cs.HoraCitacion,
		Finalizacion = cs.HoraFinalizacion,
		cs.Id_TipoCodigoServicio, 
		TipoCodigoServicio = tcs.Descripcion,
		CantidadChoferes = cs.CantidadChoferes, 
		Auxiliar = cs.Auxiliar,
		Interno = c.Interno,
		Dominio = c.Dominio,
		Legajo = p.LaboralLegajo,
		Chofer = p.Apellido + ', ' + p.Nombre,
		Id_Estado = csf.Id_Estado,
		Estado = cse.Descripcion,
		Comentario = csf.Comentario
	FROM CodigosServiciosFechas csf
		INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
		INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
		LEFT JOIN TipoCodigoServicio tcs ON cs.Id_TipoCodigoServicio = tcs.Id
		INNER JOIN CodigosServiciosEstados cse ON csf.Id_Estado = cse.Id
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
		LEFT JOIN Coches c ON csf.Id_coche = c.Id
		INNER JOIN Personal p ON csf.Id_Personal2 = p.Id
	WHERE csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND csf.Userdel IS NULL
		AND csv.Userdel IS NULL
		AND csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND (@IdPersonal IS NULL OR p.Id = @IdPersonal)
		AND (@IdEmpresa IS NULL OR e.Id = @IdEmpresa)
		AND (@IdLinea IS NULL OR l.Id = @IdLinea)
		AND (@IdRamal IS NULL OR r.Id = @IdRamal)
		AND (@IdTipoServicio IS NULL OR ts.Id = @IdTipoServicio)
		AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
		AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		AND csv.NroVuelta = 1
	
	UNION
	
	SELECT  
		Fecha = csf.Fecha,
		Id_UnidadNegocio = u.Id,
		UnidadNegocio = u.Descripcion,
		Empresa = e.Nombre,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Origen = (SELECT TOP 1 s.Descripcion
				  FROM CodigosServiciosVueltasDetalle csvd 
				  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Inicio = (SELECT TOP 1 csvd.Hora
				  FROM CodigosServiciosVueltasDetalle csvd 
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
					AND csvd.UserDel IS NULL
				  ORDER BY Dia ASC, Hora ASC),
		Destino = (SELECT TOP 1 s.Descripcion
				   FROM CodigosServiciosVueltasDetalle csvd 
				   INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
		 			 AND csvd.UserDel IS NULL
				   ORDER BY Dia DESC, Hora DESC),
		Fin = (SELECT TOP 1 csvd.Hora
			   FROM CodigosServiciosVueltasDetalle csvd 
			   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
	  			 AND csvd.UserDel IS NULL
			   ORDER BY Dia DESC, Hora DESC),
		Sentido = csv.Sentido,
		Codigo = cs.Codigo,
		Descripcion = cs.Descripcion,
		Citacion = cs.HoraCitacion,
		Finalizacion = cs.HoraFinalizacion,
		cs.Id_TipoCodigoServicio, 
		TipoCodigoServicio = tcs.Descripcion,
		CantidadChoferes = cs.CantidadChoferes, 
		Auxiliar = cs.Auxiliar,
		Interno = c.Interno,
		Dominio = c.Dominio,
		Legajo = p.LaboralLegajo,
		Chofer = p.Apellido + ', ' + p.Nombre,
		Id_Estado = csf.Id_Estado,
		Estado = cse.Descripcion,
		Comentario = csf.Comentario
	FROM CodigosServiciosFechas csf
		INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
		INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
		LEFT JOIN TipoCodigoServicio tcs ON cs.Id_TipoCodigoServicio = tcs.Id
		INNER JOIN CodigosServiciosEstados cse ON csf.Id_Estado = cse.Id
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
		LEFT JOIN Coches c ON csf.Id_coche = c.Id
		INNER JOIN Personal p ON csf.Id_Personal3 = p.Id
	WHERE csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND csf.Userdel IS NULL
		AND csv.Userdel IS NULL
		AND csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND (@IdPersonal IS NULL OR p.Id = @IdPersonal)
		AND (@IdEmpresa IS NULL OR e.Id = @IdEmpresa)
		AND (@IdLinea IS NULL OR l.Id = @IdLinea)
		AND (@IdRamal IS NULL OR r.Id = @IdRamal)
		AND (@IdTipoServicio IS NULL OR ts.Id = @IdTipoServicio)
		AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
		AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		AND csv.NroVuelta = 1 

 END