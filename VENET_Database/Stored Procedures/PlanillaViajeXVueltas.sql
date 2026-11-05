CREATE PROCEDURE [dbo].[PlanillaViajeXVueltas]
	@Id_Diagrama INT = 464,
	@Fecha DATETIME = '04/05/2015',
	@NroServicio INT = 3,
	@Turno INT = 1 
	
AS
BEGIN

	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @ColumnasV NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	SELECT @Columnas =  COALESCE(@Columnas + '[' + CAST(Numero as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'I') AS DSC
	ORDER BY Numero

	SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	
	SELECT @ColumnasV =  COALESCE(@ColumnasV + '[' + CAST(Numero as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'V') AS DSC
	ORDER BY Numero

	SET @ColumnasV = LEFT(@ColumnasV,LEN(@ColumnasV)-1)
	 
	SET @SQLString = N'
			SELECT 
				 Comentario = ISNULL(A.Comentario, ISNULL(B.Comentario, '' '')),
				 NroVuelta = CASE WHEN A.NroVuelta IS NULL THEN B.NroVuelta ELSE A.NroVuelta END, ' + REPLACE(@Columnas,'[','A.[') + '
				, CASE WHEN B.NroVuelta IS NULL THEN A.NroVuelta ELSE B.NroVuelta END, ' + REPLACE(@ColumnasV,'[','B.[') + '
			FROM 
			(SELECT *
				FROM
				(SELECT dd.Comentario, dd.NroVuelta, s.Numero, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = ''' + 'I' + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR Numero IN (' + @Columnas + ')  
				) AS PivotTable 
			) AS A FULL JOIN 	
			(SELECT * 
				FROM
				(SELECT Comentario = ISNULL(Comentario, '' ''), dd.NroVuelta, s.Numero, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = '''  + 'V'  + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR Numero IN (' + @ColumnasV + ')
				) AS PivotTable
			) B ON A.NroVuelta = B.NroVuelta 
			ORDER BY NroVuelta'
	
	PRINT @SQLString 
 	EXECUTE sp_executesql @SQLString
 	
 --	SET @Columnas = ''
 --	SET @ColumnasV = ''
 	
 --	SELECT @Columnas =  COALESCE(@Columnas + CAST(DescripcionCorta as VARCHAR(20)) + ';', '')
	--	FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'I') AS DSC
	--ORDER BY Numero

	--SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	
	--SELECT @ColumnasV =  COALESCE(@ColumnasV + CAST(DescripcionCorta as VARCHAR(20)) + ';', '')
	--	FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'V') AS DSC
	--ORDER BY Numero

	--SET @ColumnasV = LEFT(@ColumnasV,LEN(@ColumnasV)-1)

	----Select @Columnas
	----Select @ColumnasV
END