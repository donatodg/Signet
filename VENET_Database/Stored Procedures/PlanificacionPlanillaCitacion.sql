CREATE PROCEDURE [dbo].[PlanificacionPlanillaCitacion]
	@Fecha DATE = '20150501',
	@IdPlanificacion INT = 168,
	@IdTipoServicio INT = 62

AS
BEGIN

SELECT Fecha, Linea, Servicio,  
	   Coche1 = CASE WHEN MAX(Coche1) = 0 THEN '' ELSE CONVERT(VARCHAR, MAX(Coche1)) END, Legajo1 = MAX(Legajo1), Personal1 = MAX(Personal1), Citacion1 = MAX(Citacion1), Deje1 = MAX(Deje1), LugarTome1 = MAX(LugarTome1), ServicioTome1 = MAX(ServicioTome1), ServicioDeje1 = MAX(ServicioDeje1), 
	   Coche2 = CASE WHEN MAX(Coche2) = 0 THEN '' ELSE CONVERT(VARCHAR, MAX(Coche2)) END, Legajo2 = MAX(Legajo2), Personal2 = MAX(Personal2), Citacion2 = MAX(Citacion2), Deje2 = MAX(Deje2), LugarTome2 = MAX(LugarTome2), ServicioTome2 = MAX(ServicioTome2), ServicioDeje2 = MAX(ServicioDeje2), 
	   Coche3 = CASE WHEN MAX(Coche3) = 0 THEN '' ELSE CONVERT(VARCHAR, MAX(Coche3)) END, Legajo3 = MAX(Legajo3), Personal3 = MAX(Personal3), Citacion3 = MAX(Citacion3), Deje3 = MAX(Deje3), LugarTome3 = MAX(LugarTome3), ServicioTome3 = MAX(ServicioTome3), ServicioDeje3 = MAX(ServicioDeje3)
FROM
( 
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = (SELECT ISNULL(c.Interno, '')
				  FROM PlanificacionDetallesCoches pdc 
				  INNER JOIN Coches c on pdc.Id_Coche = c.Id
				  WHERE Id_Planificacion = @IdPlanificacion AND 
				        Fecha = @Fecha AND 
				        Id_Servicio = (SELECT TOP 1 a.ID 
								       FROM Diagramas_Servicios a  
								       INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
								       WHERE b.Id = ds.Id AND a.UserDel IS NULL AND b.UserDel IS NULL
				 				       ORDER BY a.Turno)),
		Legajo1 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal1 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion1 = ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje1 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		LugarTome1 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
				 			  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta,Numero), ''),
		ServicioTome1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
				 			  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioDeje1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
							  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), ''),
		Coche2 = '', Legajo2 = '', Personal2 = '', Citacion2 = '', Deje2 = '', LugarTome2 = '', ServicioTome2 = '', ServicioDeje2 = '',
		Coche3 = '', Legajo3 = '', Personal3 = '', Citacion3 = '', Deje3 = '', LugarTome3 = '', ServicioTome3 = '', ServicioDeje3 = ''
		FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.UserDel IS NULL AND
				  ds.Turno = 1 AND
				  ts.Id = @IdTipoServicio
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, @Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = '',
		Legajo1 = '',
		Personal1 = 'A CONFIRMAR',
		Citacion1 = ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5),''),
		Deje1 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), ''),
		LugarTome1 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
				 			  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioTome1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
				 			  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioDeje1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 1 AND UserDel IS NULL) AND
							  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), ''),
		Coche2 = '', Legajo2 = '', Personal2 = '', Citacion2 = '', Deje2 = '', LugarTome2 = '', ServicioTome2 = '', ServicioDeje2 = '',
		Coche3 = '', Legajo3 = '', Personal3 = '', Citacion3 = '', Deje3 = '', LugarTome3 = '', ServicioTome3 = '', ServicioDeje3 = ''
	 FROM Diagramas_Servicios ds 
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		WHERE ds.id NOT IN(SELECT Id_Servicio
					       FROM Planificaciondetalles pd  
						   WHERE pd.Id_Planificacion = @IdPlanificacion AND pd.Fecha = @Fecha AND Id_TipoServicio = @IdTipoServicio) AND
			  ds.Turno = 1 AND
			  ts.Id = @IdTipoServicio AND
			  ds.Id_Diagrama = (SELECT Id_Diagrama 
								FROM PlanificacionServicios 
								WHERE Id_Planificacion = @IdPlanificacion AND Id_TipoServicio = @IdTipoServicio AND Fecha = @Fecha)
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = '', Legajo1 = '', Personal1 = '', Citacion1 = '', Deje1 = '', LugarTome1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = (SELECT ISNULL(c.Interno, '') 
				  FROM PlanificacionDetallesCoches pdc 
				  INNER JOIN Coches c on pdc.Id_Coche = c.Id
				  WHERE Id_Planificacion = @IdPlanificacion AND 
				        Fecha = @Fecha AND 
				        Id_Servicio = (SELECT TOP 1 a.ID 
									   FROM Diagramas_Servicios a  
									   INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
									   WHERE b.Id = ds.Id AND a.UserDel IS NULL AND b.UserDel IS NULL 
									   ORDER BY a.Turno)),
		Legajo2 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal2 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion2 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje2 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		LugarTome2 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
				 			  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioTome2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
				 			  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioDeje2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND 
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
							  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), ''),
		Coche3 = '', Legajo3 = '', Personal3 = '', Citacion3 = '', Deje3 = '', LugarTome3 = '', ServicioTome3 = '', ServicioDeje3 = ''
		FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT JOIN Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.UserDel IS NULL AND
				  ds.Turno = 2 AND
				  ts.Id = @IdTipoServicio 
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, @Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = '', Legajo1 = '', Personal1 = '', Citacion1 = '', Deje1 = '', LugarTome1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = '',
		Legajo2 = '',
		Personal2 = 'A CONFIRMAR',
		Citacion2 = ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5),''),
		Deje2 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), ''),
		LugarTome2 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
				 			  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioTome2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
				 			  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioDeje2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 2 AND UserDel IS NULL) AND
							  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), ''),
		Coche3 = '', Legajo3 = '', Personal3 = '', Citacion3 = '', Deje3 = '', LugarTome3 = '', ServicioTome3 = '', ServicioDeje3 = ''
	FROM Diagramas_Servicios ds 
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		WHERE ds.id NOT IN(SELECT Id_Servicio
					       FROM Planificaciondetalles pd  
						   WHERE pd.Id_Planificacion = @IdPlanificacion AND pd.Fecha = @Fecha AND Id_TipoServicio = @IdTipoServicio) AND
			  ds.Turno = 2 AND
			  ts.Id = @IdTipoServicio AND
			  ds.Id_Diagrama = (SELECT Id_Diagrama 
								FROM PlanificacionServicios 
								WHERE Id_Planificacion = @IdPlanificacion AND Id_TipoServicio = @IdTipoServicio AND Fecha = @Fecha)
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = '', Legajo1 = '', Personal1 = '', Citacion1 = '', Deje1 = '', LugarTome1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = '', Legajo2 = '', Personal2 = '', Citacion2 = '', Deje2 = '', LugarTome2 = '', ServicioTome2 = '', ServicioDeje2 = '', 
		Coche3 = (SELECT ISNULL(c.Interno, '')
				  FROM PlanificacionDetallesCoches pdc 
				  INNER JOIN Coches c on pdc.Id_Coche = c.Id
				  WHERE Id_Planificacion = @IdPlanificacion AND 
				        Fecha = @Fecha AND 
				        Id_Servicio = (SELECT TOP 1 a.ID 
									   FROM Diagramas_Servicios a  
									   INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
									   WHERE b.Id = ds.Id AND a.UserDel IS NULL AND b.UserDel IS NULL 
									   ORDER BY a.Turno)),
		Legajo3 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal3 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion3 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje3 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		LugarTome3 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
				 			  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioTome3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND 
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
				 			  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioDeje3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
							  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), '')
			FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.UserDel IS NULL AND
				  ds.Turno = 3 AND
				  ts.Id = @IdTipoServicio
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, @Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = ds.NroServicio,
		Coche1 = '', Legajo1 = '', Personal1 = '', Citacion1 = '', Deje1 = '', LugarTome1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = '', Legajo2 = '', Personal2 = '', Citacion2 = '', Deje2 = '', LugarTome2 = '', ServicioTome2 = '', ServicioDeje2 = '',
		Coche3 = '',
		Legajo3 = '',
		Personal3 = 'A CONFIRMAR',
		Citacion3 = ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5),''),
		Deje3 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), ''),
		LugarTome3 = ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
				 			  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioTome3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MIN(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
				 			  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta, Numero), ''),
		ServicioDeje3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.NroVuelta = (SELECT MAX(NroVuelta) from Diagramas_Detalle where NroServicio = ds.NroServicio AND Id_Diagrama = ds.Id_Diagrama AND Hora > '20010101 00:00' AND Turno = 3 AND UserDel IS NULL) AND
							  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY IdaVuelta desc,Numero desc), '')
	FROM Diagramas_Servicios ds 
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
		WHERE ds.id NOT IN(SELECT Id_Servicio
					       FROM Planificaciondetalles pd  
						   WHERE pd.Id_Planificacion = @IdPlanificacion AND pd.Fecha = @Fecha AND Id_TipoServicio = @IdTipoServicio) AND
			  ds.Turno = 3 AND
			  ts.Id = @IdTipoServicio AND
			  ds.Id_Diagrama = (SELECT Id_Diagrama 
								FROM PlanificacionServicios 
								WHERE Id_Planificacion = @IdPlanificacion AND Id_TipoServicio = @IdTipoServicio AND Fecha = @Fecha)
	) AS T
GROUP BY Servicio, Fecha, Linea

END