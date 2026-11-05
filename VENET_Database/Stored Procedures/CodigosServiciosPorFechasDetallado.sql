CREATE PROCEDURE [dbo].[CodigosServiciosPorFechasDetallado]
	 @FechaDesde DATETIME = '20160101',
	 @FechaHasta DATETIME = '20160103',
	 @Sentido VARCHAR = 'I',
	 @IdUser INT = 1,
	 @IdEmpresa INT = 12,
	 @IdLinea INT = 147, 
	 @IdRamal INT = 218,
	 @IdTipoServicio INT = NULL

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
		Interno = c.Interno,
		Dominio = c.Dominio,
		Legajo1 = p1.LaboralLegajo,
		Chofer1 = p1.Apellido + ', ' + p1.Nombre,
		Legajo2 = p2.LaboralLegajo,
		Chofer2 = p2.Apellido + ', ' + p2.Nombre,
		Legajo3 = p3.LaboralLegajo,
		Auxiliar = p3.Apellido + ', ' + p3.Nombre
	FROM CodigosServiciosFechas csf
		INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
		INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
		INNER JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
		LEFT JOIN Coches c ON csf.Id_coche = c.Id
		LEFT JOIN Personal p1 ON csf.Id_Personal1 = p1.Id
		LEFT JOIN Personal p2 ON csf.Id_Personal2 = p2.Id
		LEFT JOIN Personal p3 ON csf.Id_Personal3 = p3.Id
	WHERE csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND csf.Userdel IS NULL
		AND csv.Userdel IS NULL
		AND cs.Userdel IS NULL
		AND csf.Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND (@Sentido IS NULL or csv.Sentido = @Sentido)
		AND (@IdEmpresa IS NULL OR e.Id = @IdEmpresa)
		AND (@IdLinea IS NULL OR l.Id = @IdLinea)
		AND (@IdRamal IS NULL OR r.Id = @IdRamal)
		AND (@IdTipoServicio IS NULL OR ts.Id = @IdTipoServicio)
		AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
		AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		AND csv.NroVuelta = 1
	ORDER BY e.Nombre, csf.Fecha, Inicio

END