CREATE PROCEDURE [dbo].[PlanificacionUnificadaPorDia]
	 @Fecha DATETIME,
	 @IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	SELECT 
		Fecha = fecha,
		Id_UnidadNegocio = idUnidad,
		UnidadNegocio = unidadNegocio,
		Empresa = empresa,
		Linea = linea,
		Servicio = servicio,
		Turno = turno,
		Inicio = lugarInicio,
		Destino = destino,
		Interno = internoPlanificado,
		Legajo = legajoPlanificado,
		Personal = nombrePlanificado,
		HoraInicio = LEFT(inicioPlanificado, 5),
		HoraFin = LEFT(finPlanificado, 5),
		MediasVueltas = cantMediaVuelta
	FROM (SELECT
			fecha = CONVERT(DATE, pd.Fecha), 
			idUnidad = CASE WHEN u.Id = 23 THEN 3 
						    WHEN u.Id = 16 THEN 6
						    ELSE u.Id END,
			unidadNegocio = CASE WHEN u.Id = 23 THEN 'Buses Urbanos Corrientes'
							     WHEN U.Id = 3 THEN 'Buses Urbanos Corrientes'
							     WHEN U.Id = 16 THEN 'Buses Urbanos Resistencia'
							     ELSE u.Descripcion END,
			empresa = e.Nombre,
			linea = l.descripcion,
			servicio =  ds.NroServicio,
			turno = ds.Turno,
			lugarInicio = CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + ISNULL
			                  ((SELECT TOP (1) s.Descripcion
			                      FROM Diagramas_Detalle AS d INNER JOIN
			                           Secciones AS s ON d.Id_Seccion = s.Id
			                      WHERE (d.NroServicio = ds.NroServicio) AND (d.Id_Diagrama = ds.Id_Diagrama) AND (d.UserDel IS NULL) AND (d.Hora > '20010101 00:00') AND (d.Turno = ds.Turno)
			                      ORDER BY d.Turno, d.NroVuelta, s.Numero), ''),
			destino = ISNULL((SELECT TOP 1 s.Descripcion
				 			FROM Diagramas_Detalle d
				 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
				 			WHERE d.NroServicio = ds.NroServicio AND 
								  d.Id_Diagrama = ds.Id_Diagrama AND
					 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = ds.Turno AND UserDel IS NULL) AND
								  d.Turno = ds.Turno AND
					 			  d.UserDel IS NULL AND
								  Hora > '20010101 00:00'
				 			ORDER BY IdaVuelta desc,Numero desc), ''),
			internoPlanificado = ISNULL((SELECT ISNULL(c.Interno,'0') 
									FROM PlanificacionDetallesCoches pdc 
									INNER JOIN Coches c on pdc.Id_Coche = c.Id
										WHERE Id_Planificacion = pl.Id AND 
											  Fecha = @Fecha AND 
											  Id_Servicio = (SELECT TOP 1 a.ID 
								  							 FROM Diagramas_Servicios a  
															 INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
															 WHERE b.Id = ds.Id AND
															       a.UserDel IS NULL AND
															       b.UserDel IS NULL
															 ORDER BY a.Turno)), 0),
			legajoPlanificado = p.Laborallegajo,
			nombrePlanificado = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
			original = NULL,
			inicioPlanificado = ISNULL(CONVERT(TIME, ds.HoraCitacion), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
			finPlanificado = ISNULL(CONVERT(TIME, ds.HoraFinalizacion), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
			pendiente = 1,
			estado = 'P',
			cantMediaVuelta = (SELECT COUNT(DISTINCT(NroVuelta)) FROM Diagramas_Detalle WHERE Id_Diagrama = d.Id AND NroServicio = ds.NroServicio AND Turno = ds.Turno AND UserDel IS NULL),
			viajeesp = 0
		   FROM PlanificacionDetalles pd
			INNER JOIN Planificacion pl ON pd.Id_Planificacion = pl.Id
			LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
			LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
			LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
			LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
			LEFT join Lineas l ON r.Id_Linea = l.Id
			LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
			LEFT JOIN Coches c ON pd.Id_Coche = c.Id
			INNER JOIN Personal p ON pd.Id_Personal = p.Id
			INNER JOIN Empresas e ON l.Id_Empresa = e.Id
			INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
				WHERE pl.UserDel IS NULL AND
					  pd.Fecha = @Fecha AND
					  pd.UserDel IS NULL AND
					  ds.UserDel IS NULL  
					  AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
					  AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	UNION  
		SELECT
			fecha = CONVERT(DATE, @Fecha), 
			idUnidad = CASE WHEN u.Id = 23 THEN 3
							WHEN u.Id = 16 THEN 6
							ELSE u.Id END,
			unidadNegocio = CASE WHEN u.Id = 23 THEN 'Buses Urbanos Corrientes'
								 WHEN U.Id = 3 THEN 'Buses Urbanos Corrientes'
								 WHEN U.Id = 16 THEN 'Buses Urbanos Resistencia'
								 ELSE u.Descripcion END,
			empresa = e.Nombre,
			linea = l.descripcion,
			servicio =  ds.NroServicio,
			turno = ds.Turno,
			lugarInicio = CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + ISNULL
							  ((SELECT TOP (1) s.Descripcion
								  FROM Diagramas_Detalle AS d INNER JOIN
									   Secciones AS s ON d.Id_Seccion = s.Id
								  WHERE (d.NroServicio = ds.NroServicio) AND (d.Id_Diagrama = ds.Id_Diagrama) AND (d.UserDel IS NULL) AND (d.Hora > '20010101 00:00') AND (d.Turno = ds.Turno)
								  ORDER BY d.Turno, d.NroVuelta, s.Numero), ''),
			destino = ISNULL((SELECT TOP 1 s.Descripcion
			 				FROM Diagramas_Detalle d
			 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 				WHERE d.NroServicio = ds.NroServicio AND 
								  d.Id_Diagrama = ds.Id_Diagrama AND
				 				  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = ds.Turno AND UserDel IS NULL) AND
								  d.Turno = ds.Turno AND
				 				  d.UserDel IS NULL AND
								  Hora > '20010101 00:00'
			 				ORDER BY IdaVuelta desc,Numero desc), ''),
			internoPlanificado = 0,
			legajoPlanificado = 0,
			nombrePlanificado = '',
			original = NULL,
			inicioPlanificado = ISNULL(CONVERT(TIME, ds.HoraCitacion), ''),
			finPlanificado = ISNULL(CONVERT(TIME, ds.HoraFinalizacion), ''),
			pendiente = 1,
			estado = 'P',
			cantMediaVuelta = (SELECT COUNT(DISTINCT(NroVuelta)) FROM Diagramas_Detalle WHERE Id_Diagrama = d.Id AND NroServicio = ds.NroServicio AND Turno = ds.Turno AND UserDel IS NULL),
			viajeesp = 0
		 FROM Diagramas_Servicios ds
		  INNER JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		  INNER JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		  INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		  INNER JOIN Lineas l ON r.Id_Linea = l.Id
		  INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
		  INNER JOIN Empresas e ON l.Id_Empresa = e.Id
		 WHERE
			l.Id_UnidadNegocio <> 16 and
			  d.Id IN (SELECT ps.Id_Diagrama FROM PlanificacionServicios ps INNER JOIN Planificacion p ON ps.Id_Planificacion = p.Id WHERE @Fecha BETWEEN p.FechaDesde AND p.FechaHasta AND p.UserDel IS NULL AND ps.Fecha = @Fecha)
			  AND d.UserDel IS NULL
			  AND ds.UserDel IS NULL
			  AND ds.Id NOT IN (SELECT ds.Id
								 FROM PlanificacionDetalles pd
									INNER JOIN Planificacion pl ON pd.Id_Planificacion = pl.Id
									LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
									LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
									LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
									LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
									LEFT join Lineas l ON r.Id_Linea = l.Id
									LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
									LEFT JOIN Coches c ON pd.Id_Coche = c.Id
									INNER JOIN Personal p ON pd.Id_Personal = p.Id
									INNER JOIN Empresas e ON l.Id_Empresa = e.Id
									INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
										WHERE pl.UserDel IS NULL AND
											  pd.Fecha = @Fecha AND
											  pd.UserDel IS NULL AND
											  ds.UserDel IS NULL )
				 AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
				 AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	 UNION  
		SELECT 
			fecha = CONVERT(DATE, csf.Fecha), 
			idUnidad = pl.Id_UnidadNegocio,
			unidadNegocio = u.Descripcion,
			empresa = e.Nombre,
			linea = cs.Descripcion, --CASE WHEN pl.Id_UnidadNegocio = 26 THEN cs.Descripcion ELSE l.descripcion END,
			servicio = (SELECT TOP 1 REPLACE(LEFT(CONVERT(VARCHAR, csvd.Hora, 108), 5), ':','') 
						FROM CodigosServiciosVueltasDetalle csvd 
						WHERE csvd.Id_CodigoServicioVuelta = csv.Id
						AND csvd.UserDel IS NULL
						ORDER BY Dia ASC, Hora ASC),
			turno =  CASE WHEN DATEPART(HH, cs.HoraCitacion) > 11 THEN 2 ELSE 1 END,
			lugarInicio =  ISNULL((SELECT TOP (1) s.Descripcion
								   FROM CodigosServiciosVueltasDetalle csvd
								   INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
								   WHERE (csvd.Id_CodigoServicioVuelta = csv.Id AND csvd.UserDel IS NULL)
								   ORDER BY csvd.Dia, csvd.Hora), ''),
			destino = ISNULL((SELECT TOP (1) s.Descripcion
							  FROM CodigosServiciosVueltasDetalle csvd
							  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
							  WHERE (csvd.Id_CodigoServicioVuelta = csv.Id AND csvd.UserDel IS NULL)
							  ORDER BY csvd.Dia DESC, csvd.Hora DESC), ''),
			internoPlanificado = ISNULL(c.Interno, 0),
			legajoPlanificado = ISNULL(p1.Laborallegajo, 0),
			nombrePlanificado = LTRIM(RTRIM(p1.Apellido)) + ', ' + LTRIM(RTRIM(p1.Nombre)),
			original = NULL,
			inicioPlanificado = ISNULL(CONVERT(TIME, cs.HoraCitacion), ''),
			finPlanificado = ISNULL(CONVERT(TIME, cs.HoraFinalizacion), ''),
			pendiente = 1,
			estado = 'P',
			cantMediaVuelta = (SELECT COUNT(DISTINCT(csv.NroVuelta))
							  FROM CodigosServiciosVueltas  csv						   
							  WHERE csv.Id_CodigoServicio = cs.Id AND csv.UserDel IS NULL),
			viajeesp = 0
			--agregado = 1,
			--reemplazo = CASE WHEN p2.id IS NULL THEN 0 ELSE 1 END,
			--legajoEjecutado = CASE WHEN p2.id IS NULL THEN NULL ELSE p2.Laborallegajo END,
			--nombreEjecutado = CASE WHEN p2.id IS NULL THEN NULL ELSE LTRIM(RTRIM(p2.Apellido)) + ', ' + LTRIM(RTRIM(p2.Nombre)) END
		FROM CodigosServiciosFechas csf
			INNER JOIN PlanificacionLarga pl ON csf.Id_Planificacion = pl.Id
			INNER JOIN UnidadNegocios u ON pl.Id_UnidadNegocio = u.Id
			INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
			INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
			INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
			INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
			INNER JOIN Lineas l ON r.Id_Linea = l.Id
			INNER JOIN Empresas e ON l.Id_Empresa = e.Id
			LEFT JOIN Coches c ON csf.Id_Coche = c.Id
			LEFT JOIN Personal p1 ON csf.Id_Personal1 = p1.Id
			LEFT JOIN Personal p2 ON csf.Id_Personal2 = p2.Id
		WHERE csf.Fecha =  @Fecha
			AND pl.UserDel IS NULL
			AND csf.UserDel IS NULL
			AND csv.UserDel IS NULL
			AND csv.NroVuelta = 1
		    AND (@IdUser = 0  OR e.Id IN (SELECT Id_Empresa FROM SeguridadUsuariosEmpresas WHERE Id_Usuario = @IdUser))
		    AND (@IdUser = 0  OR l.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
	 )AS T
END