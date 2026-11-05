CREATE PROCEDURE [dbo].[PlanillaViaje]
			@Id_Diagrama INT = 512,
			@Fecha DATETIME = '20150401',
			@NroServicio INT = 5,
			@Turno INT = 1,
			@IdaVuelta VARCHAR(1) = 'i'

AS
BEGIN

	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	SELECT @Columnas =  COALESCE(@Columnas + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = @IdaVuelta) AS DSC
	ORDER BY Numero

	SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	
	IF (SELECT ts.BoletoEnPlanilla 
		FROM Diagramas d INNER JOIN TipoServicios ts on d.Id_TipoServicio = ts.Id 
		WHERE d.Id = @Id_Diagrama) = 0
	BEGIN	 
		SET @SQLString = N'
			SELECT *, Inspector = '' ''
				FROM
				(SELECT dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = '''  + @IdaVuelta  + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR DescripcionCorta IN (' + @columnas + ')
				) AS PivotTable'
	END
	ELSE
	BEGIN
		SET @SQLString = N'
			SELECT *, Inspector = '' ''
				FROM
				(SELECT dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN ''      -B:                      '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2) + '' -B:                      '') END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = '''  + @IdaVuelta  + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR DescripcionCorta IN (' + @columnas + ')
				) AS PivotTable'
		END	
		
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END
