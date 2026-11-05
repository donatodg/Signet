CREATE PROCEDURE [dbo].[Importacion_Nexus]
	@FechaDesde DATETIME = '20150909' ,
	@FechaHasta DATETIME = '20150909' ,
	@Id_UnidadNegocio INT   = 3

AS
BEGIN

DECLARE @Id_UnidadNegocio2 INT = @Id_UnidadNegocio
 
	IF @Id_UnidadNegocio = 3
		SET @Id_UnidadNegocio2 = 23  
	
	SELECT 
		CONVERT(VARCHAR, pd.Fecha, 103) + ';' + 
		CONVERT(VARCHAR, pe.LaboralLegajo) + ';' + 
		'T;' + 
		l.DescripcionCorta + ';' +
		CONVERT(VARCHAR, ds.NroServicio) + ';' + 
		CONVERT(VARCHAR, ds.Turno) + ';' + 
		CONVERT(VARCHAR, pd.Fecha, 103) + ' ' + CONVERT(VARCHAR(5), ds.HoraCitacion, 108)  + ';' + 
		CASE WHEN ds.HoraFinalizacion > ds.HoraCitacion THEN CONVERT(VARCHAR, pd.Fecha, 103) ELSE CONVERT(VARCHAR, DATEADD(d, 1, pd.Fecha), 103) END + ' ' + CONVERT(VARCHAR(5) ,ds.HoraFinalizacion, 108) + 
		';'
	FROM PlanificacionDetalles pd 
		INNER JOIN Planificacion p ON p.Id = pd.Id_Planificacion
		INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
		INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		INNER JOIN Diagramas d on ds.Id_Diagrama = d.Id
		INNER JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l on r.Id_Linea = l.Id
	WHERE pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
		  p.FechaDel IS NULL AND
	      pd.Id_Servicio > 0 AND
	      (p.Id_UnidadNegocio = @Id_UnidadNegocio OR p.Id_UnidadNegocio = @Id_UnidadNegocio2)
	UNION
	SELECT 
		CONVERT(VARCHAR, pd.Fecha, 103) + ';' + 
		CONVERT(VARCHAR, pe.LaboralLegajo) + ';' + 
		CASE WHEN tn.ALaOrden = 1 THEN 'T' 
			 WHEN TN.Id = 72 THEN 'ENFE'
			 WHEN tn.Id = 73 THEN 'VLAB'
			 WHEN tn.Id = 74 THEN 'T'
			 WHEN tn.Id = 75 THEN 'F'
			 WHEN tn.Id = 77 THEN 'T'
			 WHEN tn.Id = 78 THEN 'F'
			 WHEN tn.Id = 79 THEN 'T'
			 WHEN tn.Id = 13 THEN 'T'
		ELSE CONVERT(VARCHAR, tn.Descripcion) END + ';' + 
		+ CASE WHEN tn.ALaOrden = 1 THEN '1' WHEN TN.Id = 13 THEN '1' ELSE '' END + ';' + --l.Descripcion + ';' +
		+ CASE WHEN tn.ALaOrden = 1 THEN '1' WHEN TN.Id = 13 THEN '1' ELSE '' END + ';' + --convert(varchar,df.NroServicio) + ';' + 
		+ CASE WHEN tn.ALaOrden = 1 THEN '1' WHEN TN.Id = 13 THEN '1' ELSE '' END + ';' + --convert(varchar,df.Turno) + ';' + 
		+ CASE WHEN tn.ALaOrden = 1 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '00:00'
			   WHEN tn.Id = 13 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '00:00'
			   WHEN tn.Id = 74 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '00:00'
			   WHEN tn.Id = 77 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '00:00'
			   WHEN tn.Id = 79 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '00:00'
			   ELSE '' END + ';'  --convert(varchar,df.Fecha,103) + ' ' + convert(varchar(5),ds.HoraCitacion,108) + ';' + 
		+ CASE WHEN tn.ALaOrden = 1 THEN CONVERT(VARCHAR, pd.Fecha, 103)  + ' ' + '08:00'
			   WHEN tn.Id = 13 THEN CONVERT(VARCHAR, pd.Fecha, 103) + ' ' + '08:00'
			   WHEN tn.Id = 74 THEN CONVERT(VARCHAR, pd.Fecha, 103) + ' ' + '08:00'
			   WHEN tn.Id = 77 THEN CONVERT(VARCHAR, pd.Fecha, 103) + ' ' + '08:00'
			   WHEN tn.Id = 79 THEN CONVERT(VARCHAR, pd.Fecha, 103) + ' ' + '08:00' 
			   ELSE '' END + ';'  --case when ds.HoraFinalizacion > ds.HoraCitacion then  convert(varchar,df.Fecha,103) else convert(varchar,df.Fecha + 1 ,103) end + ' ' + convert(varchar(5),ds.HoraFinalizacion,108) 
		FROM PlanificacionDetalles pd 
			INNER JOIN Planificacion p ON p.Id = pd.Id_Planificacion
			INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
			INNER JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		WHERE pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
			  p.FechaDel IS NULL AND
			  tn.Id <> 71 AND
			  tn.Id <> 76 AND
			  (p.Id_UnidadNegocio = @Id_UnidadNegocio OR p.Id_UnidadNegocio = @Id_UnidadNegocio2)
 
END