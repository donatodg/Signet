CREATE PROCEDURE [dbo].[PlanificacionPlanillaCitacionConLargada]
	@Fecha DATE,
	@IdPlanificacion INT,
	@IdTipoServicio INT

AS
BEGIN


DECLARE @IdDiagrama INT 

--busco que diagrama tiene asigando en esa fecha esa linea
SELECT @IdDiagrama = ps.Id_Diagrama
	FROM PlanificacionServicios ps INNER JOIN Planificacion p ON ps.Id_Planificacion = p.Id
		WHERE ps.Id_TipoServicio = @IdTipoServicio AND 
			  ps.Fecha = @Fecha AND 
			  p.UserDel IS NULL
			  
SELECT Fecha, Linea, Servicio, Turno = Turno,
	   Coche = Max(Coche), Legajo = MAX(Legajo), Personal = MAX(Personal), Citacion = MAX(Citacion),Deje = MAX(Deje), ServicioTome = MAX(ServicioTome), ServicioDeje = MAX(ServicioDeje), LugarTome = MAX(LugarTome)
FROM
( 
	SELECT
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio =  ds.NroServicio ,
		Coche = (SELECT ISNULL(c.Interno,'') 
					FROM PlanificacionDetallesCoches pdc 
					INNER JOIN Coches c on pdc.Id_Coche = c.Id
						WHERE Id_Planificacion = @IdPlanificacion AND 
					          Fecha = @Fecha AND 
					          Id_Servicio = (SELECT TOP 1 a.ID 
							  			     FROM Diagramas_Servicios a  
										     INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
										     WHERE b.Id = ds.Id AND a.UserDel IS NULL AND b.UserDel IS NULL
											 ORDER BY a.Turno)),
		Legajo = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		LugarTome = CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + 
				    ISNULL((SELECT TOP 1 S.Descripcion
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00' And 
							  d.Turno = ds.Turno
							  --d.Id_Seccion = (select min(Id_Seccion) from Diagramas_Detalle 	WHERE  NroServicio = ds.NroServicio AND 
				 			 -- d.Id_Diagrama = ds.Id_Diagrama AND d.Turno = ds.Turno and
				 			 -- d.UserDel IS NULL AND
							  --Hora > '20010101 00:00')
							  
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioTome = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioDeje = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta desc, Numero desc), ''),
		Turno = CASE WHEN ds.Turno = 1 THEN '1 - MAÑANA' ELSE CASE WHEN ds.Turno = 2 THEN '2 - TARDE' ELSE '3 - NOCHE' END END
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
				  ts.Id = @IdTipoServicio
	 ) as t
GROUP BY Servicio, Fecha, Linea, Turno

UNION

SELECT 
	Fecha = CONVERT(VARCHAR, @Fecha, 103), 
	Linea = ISNULL(l.DescripcionCorta, ''),
	Servicio =  ds.NroServicio ,
	Turno = CONVERT(varchar, CASE WHEN ds.Turno = 1 THEN '1 - MAÑANA' ELSE CASE WHEN ds.Turno = 2 THEN '2 - TARDE' ELSE '3 - NOCHE' END END),
	Coche = (SELECT ISNULL(c.Interno,'') 
				FROM PlanificacionDetallesCoches pdc 
				INNER JOIN Coches c on pdc.Id_Coche = c.Id
					WHERE Id_Planificacion = @IdPlanificacion AND 
						  Fecha = @Fecha AND 
						  Id_Servicio = (SELECT TOP 1 a.ID 
					  					 FROM Diagramas_Servicios a  
										 INNER JOIN Diagramas_Servicios b ON a.Id_Diagrama = b.Id_Diagrama AND a.NroServicio = b.NroServicio
										 WHERE b.Id = ds.Id AND a.UserDel IS NULL AND b.UserDel IS NULL
										 ORDER BY a.Turno)),
	Legajo = '', -- CONVERT(VARCHAR, p.LaboralLegajo),
	Personal = 'A CUBRIR', -- LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
	Citacion =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5),''), 
	Deje =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5),''),  
	ServicioTome = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
	 				FROM Diagramas_Detalle d
	 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
	 				WHERE d.NroServicio = ds.NroServicio AND 
		 				  d.Id_Diagrama = ds.Id_Diagrama AND
		 				  d.UserDel IS NULL AND
						  Hora > '20010101 00:00'
	 				ORDER BY Turno, NroVuelta, Numero), ''),
	ServicioDeje = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
	 				FROM Diagramas_Detalle d
	 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
	 				WHERE d.NroServicio = ds.NroServicio AND 
						  d.Id_Diagrama = ds.Id_Diagrama AND
		 				  d.UserDel IS NULL AND
						  Hora > '20010101 00:00'
	 				ORDER BY Turno, NroVuelta desc, Numero desc), ''),
	LugarTome = CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + 
				ISNULL((SELECT TOP 1 S.Descripcion
	 				FROM Diagramas_Detalle d
	 				INNER JOIN Secciones s ON d.Id_Seccion = s.Id
	 				WHERE d.NroServicio = ds.NroServicio AND 
		 				  d.Id_Diagrama = ds.Id_Diagrama AND
		 				  d.UserDel IS NULL AND
						  Hora > '20010101 00:00' And 
						  d.Turno = ds.Turno
						  --d.Id_Seccion = (select min(Id_Seccion) from Diagramas_Detalle 	WHERE  NroServicio = ds.NroServicio AND 
		 				 -- d.Id_Diagrama = ds.Id_Diagrama AND d.Turno = ds.Turno and
		 				 -- d.UserDel IS NULL AND
						  --Hora > '20010101 00:00')
						  
	 				ORDER BY Turno, NroVuelta, Numero), '')
FROM Diagramas_Servicios ds 
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN Lineas l ON r.Id_Linea = l.Id
WHERE ds.Id not in (select ds.Id	
					FROM PlanificacionDetalles pd 
					LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
					LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
					LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
					WHERE pd.Id_Planificacion = @IdPlanificacion AND
							  pd.Fecha = @Fecha AND
							  pd.UserDel IS NULL AND
							  ds.UserDel IS NULL AND
							  ts.Id = @IdTipoServicio)
AND ts.Id = @IdTipoServicio
AND d.Id = @IdDiagrama
AND ds.UserDel IS NULL  

END