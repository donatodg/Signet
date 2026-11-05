
CREATE PROCEDURE [dbo].[PlanificacionMensualCoches] 
	@Id_Planificacion INT = 170

AS
BEGIN
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @ColumnasC NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	DECLARE @Desde date
	DECLARE @Hasta date
	DECLARE @Desde2 date

	SELECT @Desde = FechaDesde,@Desde2 = FechaDesde, @Hasta = FechaHasta FROM Planificacion WHERE Id = @Id_Planificacion
	 
	WHILE @Desde2 <= @Hasta
	BEGIN
		SELECT @Columnas = COALESCE(@Columnas + '[' + CAST(day(@Desde2) AS VARCHAR(2)) + '],', '')
		SELECT @ColumnasC =  COALESCE(@ColumnasC + '[C' + CAST(DAY(@Desde2) AS VARCHAR(2)) + '],', '')
		
		SET @Desde2 = DATEADD(d, 1, @Desde2)
	END
		 
	SET @Columnas = LEFT(@Columnas, LEN(@Columnas) - 1)
	SET @ColumnasC = LEFT(@ColumnasC, LEN(@ColumnasC) - 1)
 
	SET	@SQLString = N'
		SELECT PivotTable.*,' + @ColumnasC + ' 
			FROM
			(SELECT Novedad = CASE WHEN ISNULL(pd.id_NovedadCoche, 0) > 0 THEN (SELECT Descripcion FROM TipoNovedadesCoches WHERE Id = pd.id_NovedadCoche)
								   WHEN ISNULL(ds.NroServicio, 0) = 0 THEN ''' + ''' ELSE CONVERT(VARCHAR,ds.NroServicio) + ''' + '-' + ''' + (SELECT l1.DescripcionCorta FROM Diagramas_Servicios ds1
																																				INNER JOIN Diagramas d1 ON ds1.Id_Diagrama = d1.Id
																																				INNER JOIN TipoServicios ts1 ON d1.Id_TipoServicio = ts1.Id
																																				INNER JOIN Ramales r1 ON ts1.Id_Ramal = r1.Id
																																				INNER JOIN Lineas l1 ON r1.Id_Linea = l1.Id
																																				WHERE ds1.Id = ds.Id) 
			 END, Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion, pd.Id_Coche , Dia =  convert(varchar,DAY(pd.Fecha)), c.Interno, pd.Id_TipoServicio
				FROM PlanificacionDetallesCoches pd 
				LEFT JOIN Diagramas_Servicios ds on pd.Id_Servicio = ds.Id
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
					WHERE pd.Id_Planificacion = ' + CONVERT(VARCHAR,@Id_Planificacion) + ' 
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnas + ') 
				) AS PivotTable
		INNER JOIN 
		(SELECT * 
			FROM
			(SELECT Novedad = CASE WHEN pc.UserDel IS NULL THEN ISNULL(pc.Id, 0) ELSE 0 END, Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion,
					pd.Id_Coche, Dia = + ''' + 'C' + ''' + convert(varchar,DAY(pd.Fecha)), 
					c.Interno, pd.Id_TipoServicio
				FROM PlanificacionDetallesCoches pd 
				LEFT JOIN PlanificacionCochesComentarios pc ON pd.Id = pc.Id_PlanificacionDetalleCoche
				LEFT JOIN TipoComentarios tc ON pc.Id_TipoComentario = tc.Id
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
					WHERE pd.Id_Planificacion = ' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @ColumnasC + ') 
				) AS PivotTable) AS T1 ON T1.Interno = PivotTable.Interno
		ORDER BY Linea DESC, Interno DESC'
 
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END