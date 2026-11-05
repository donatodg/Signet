CREATE PROCEDURE [dbo].[CochesPorServicioPorFecha]
	 @FechaDesde DATE  = '20160101',
	 @FechaHasta DATE  = '20160131',
	 @IdUN INT = 0
 
 AS
 BEGIN

	DECLARE @SQLString NVARCHAR(MAX) = ''
	DECLARE @Desde2 DATE
	DECLARE @Columnas NVARCHAR(MAX) = ''

	SET @Desde2 = @FechaDesde

	WHILE @Desde2 <= @FechaHasta
	BEGIN
		SELECT @Columnas =  COALESCE(@Columnas + '[' + CONVERT(VARCHAR(10), @Desde2, 103)   + '],', '')
		SET @Desde2 = DATEADD(d, 1, @Desde2)
	END

	SET @Columnas = LEFT(@Columnas, LEN(@Columnas) -1)

	SET	@SQLString = N'
		SELECT * FROM (
		SELECT UN = u.Descripcion, c.Interno, c.Dominio, pdc.Fecha, Servicio = ISNULL(CASE WHEN pdc.Id_Servicio IS NULL THEN ' + '''  ''' + ' ELSE l.DescripcionCorta + ' + '''-' + ''' + CONVERT(VARCHAR, ds.NroServicio) END, ' + ''' ''' + ')
		FROM PlanificacionDetallesCoches pdc
		INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		INNER JOIN Planificacion p ON pdc.Id_Planificacion = p.Id
		LEFT JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id 
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT JOIN Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		WHERE c.UserDel IS NULL
		AND pdc.UserDel IS NULL
		AND p.UserDel IS NULL
		AND pdc.Fecha BETWEEN ''' + CONVERT(VARCHAR(10), @FechaDesde, 103) + ''' AND ''' +  CONVERT(VARCHAR(10), @FechaHasta, 103) + '''
		AND (p.Id_UnidadNegocio = ' + CONVERT(VARCHAR, @IdUN) + ' OR ' + CONVERT(VARCHAR, @IdUN) + ' = 0)
		--) AS t
		-- PIVOT
		--	(
		--		MAX(Servicio)
		--		FOR Fecha IN (' + @Columnas + ') 
		--	) AS PivotTable 
		UNION
		--SELECT * FROM (
		SELECT UN = u.Descripcion, c.Interno, c.Dominio, pdc.Fecha, Servicio = ISNULL(CASE WHEN pdc.Id_CodigoServicioVuelta IS NULL THEN ' + '''  ''' + ' ELSE l.DescripcionCorta + ' + '''-' + ''' + CONVERT(VARCHAR, cs.codigo) END, ' + ''' ''' + ')
		FROM CodigosServiciosFechas pdc
		INNER JOIN Coches c ON pdc.Id_Coche = c.Id
		INNER JOIN Planificacionlarga p ON pdc.Id_Planificacion = p.Id
		INNER JOIN CodigosServiciosVueltas csv ON pdc.Id_CodigoServicioVuelta = csv.Id
		Inner join CodigosServicios cs on csv.id_Codigoservicio = cs.id
		LEFT JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id 
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT JOIN Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN Empresas e ON l.Id_Empresa = e.Id
		INNER JOIN UnidadNegocios u ON p.Id_UnidadNegocio = u.Id
		WHERE c.UserDel IS NULL
		AND pdc.UserDel IS NULL
		AND p.UserDel IS NULL
		AND pdc.Fecha BETWEEN ''' + CONVERT(VARCHAR(10), @FechaDesde, 103) + ''' AND ''' + CONVERT(VARCHAR(10), @FechaHasta, 103) + '''
		AND (p.Id_UnidadNegocio = ' + CONVERT(VARCHAR, @IdUN) + ' OR ' + CONVERT(VARCHAR, @IdUN) + ' = 0)
		) AS t
		 PIVOT
			(
				MAX(Servicio)
				FOR Fecha IN (' + @Columnas + ') 
			) AS PivotTable 
		
		ORDER BY UN, Interno'
		
		
		 print @sqlstring			
		--EXECUTE sp_executesql @SQLString

 END