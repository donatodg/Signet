CREATE PROCEDURE [dbo].[PlanificacionMensual]  
	@Id_Planificacion INT

AS
BEGIN
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @ColumnasDT NVARCHAR(MAX) = ''
	DECLARE @ColumnasC NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @Desde2 DATE

	SELECT @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta FROM Planificacion WHERE Id = @Id_Planificacion
	 
	WHILE @Desde2 <= @Hasta
	BEGIN
		SELECT @Columnas =  COALESCE(@Columnas + '[' + CAST(DAY(@Desde2) AS VARCHAR(2)) + '],', '')
		SELECT @ColumnasDT =  COALESCE(@ColumnasDT + '[DN' + CAST(DAY(@Desde2) AS VARCHAR(2)) + '],', '')
		SELECT @ColumnasC =  COALESCE(@ColumnasC + '[C' + CAST(DAY(@Desde2) AS VARCHAR(2)) + '],', '')
		
		SET @Desde2 = DATEADD(d, 1, @Desde2)
	END
		 
	SET @Columnas = LEFT(@Columnas, LEN(@Columnas) -1)
	SET @ColumnasDT = LEFT(@ColumnasDT, LEN(@ColumnasDT) -1)
	SET @ColumnasC = LEFT(@ColumnasC, LEN(@ColumnasC) -1)

	SET	@SQLString = N'
		SELECT PivotTable.*,' + @ColumnasDT + ',' + @ColumnasC + ' 
			FROM
			(SELECT Novedad = CASE WHEN l2.DescripcionCorta IS NULL THEN pd.Novedad ELSE pd.Novedad + ''' + '-' + ''' + l2.DescripcionCorta END, 
					Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion, Id_TipoServicio = ts.Id, pd.Id_Coche, pd.Id_Personal, Dia = DAY(pd.Fecha), 
					Legajo = CONVERT(VARCHAR, pe.LaboralLegajo) + ''' + ' - ' + ''' + pe.Apellido + ''' +  ', ' + ''' +  pe.Nombre, 
					c.Interno
				FROM PlanificacionDetalles pd
				LEFT JOIN PlanificacionComentarios pc ON pd.Id_Planificacion = pc.Id_PlanificacionDetalle
				LEFT JOIN TipoComentarios tc ON pc.Id_TipoComentario = tc.Id
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
				left join Diagramas_Servicios ds on pd.Id_Servicio = ds.Id
				left join Diagramas d on ds.Id_Diagrama = d.Id
				left join TipoServicios ts2 on d.Id_TipoServicio = ts2.Id
				left join Ramales r2 on ts2.Id_Ramal = r2.Id
				left join Lineas l2 on r2.Id_Linea = l2.Id
				INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnas + ') 
				) AS PivotTable 
		INNER JOIN 
		(SELECT * 
			FROM
			(SELECT Novedad = ISNULL(pd.Id_Novedad, 0), Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion,
					Id_Linea = l.Id, pd.Id_Coche, pd.Id_Personal, Dia = ''' + 'DN' + ''' + convert(varchar,DAY(pd.Fecha)), 
					Legajo = CONVERT(VARCHAR, pe.LaboralLegajo) + ''' + ' - ' + ''' + pe.Apellido + ''' +  ', ' + ''' +  pe.Nombre, 
					c.Interno
				FROM PlanificacionDetalles pd 
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
				INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnasDT + ') 
				) AS PivotTable ) AS T ON T.Legajo = PivotTable.Legajo 
		INNER JOIN 
		(SELECT * 
			FROM
			(SELECT Novedad = CASE WHEN pc.UserDel IS NULL THEN ISNULL(pc.Id, 0) ELSE 0 END, Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion,
					Id_Linea = l.Id, pd.Id_Coche, pd.Id_Personal, Dia = ''' + 'C' + ''' + convert(varchar,DAY(pd.Fecha)), 
					Legajo = CONVERT(VARCHAR, pe.LaboralLegajo) + ''' + ' - ' + ''' + pe.Apellido + ''' +  ', ' + ''' +  pe.Nombre, 
					c.Interno
				FROM PlanificacionDetalles pd 
				LEFT JOIN PlanificacionComentarios pc ON pd.Id = pc.Id_PlanificacionDetalle
				LEFT JOIN TipoComentarios tc ON pc.Id_TipoComentario = tc.Id
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
				INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnasC + ') 
				) AS PivotTable ) AS T1 ON T1.Legajo = PivotTable.Legajo 			

		ORDER BY T.Linea DESC, T.Interno'
 
	 
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END
