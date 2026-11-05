CREATE PROCEDURE [dbo].[PlanillaVertical]
			@IdDiagrama INT = 464
AS
BEGIN
	
	SET NOCOUNT OFF;
 	
 	DECLARE @ColumnasIda NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''
	DECLARE @ColumnasIdaSelect NVARCHAR(MAX) = ''
	DECLARE @PrimerColumnaIda NVARCHAR(MAX) = ''
	DECLARE @PrimerColumnaVuelta NVARCHAR(MAX) = ''
	DECLARE @UltimaColumnaVuelta NVARCHAR(MAX) = ''
	DECLARE @ColumnasVuelta NVARCHAR(MAX) = ''
	DECLARE @ColumnasVueltasSelect NVARCHAR(MAX) = ''
	Declare @Id INT
	Declare @Id1 INT
	Declare @Id2 INT
	Declare @Hora1 NVarchar(MAX)
	Declare @Hora2 NVarchar(MAX)
	DECLARE @ParmDefinition nvarchar(MAX)
	DECLARE @retval int;  
	DECLARE @retvalHora nvarchar(500) 
	
	BEGIN TRY
		DELETE Vertical
 		DROP TABLE T1
		DROP TABLE T2
	END TRY	
	BEGIN CATCH
	END CATCH
	
	SELECT @ColumnasIda = COALESCE(@ColumnasIda + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', ''),
		   @ColumnasIdaSelect = COALESCE(@ColumnasIdaSelect + 'T.[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @IdDiagrama and UserDel Is NULL) AND IdaVuelta = 'I') AS DSC
	ORDER BY Numero
	
	SET @ColumnasIdaSelect = LEFT(@ColumnasIdaSelect, LEN(@ColumnasIdaSelect) -1)
	SET @ColumnasIda = LEFT(@ColumnasIda, LEN(@ColumnasIda) -1)
   
	SET @SQLString = N'
		SELECT * INTO T1 
			FROM
			(SELECT Id = CONVERT(VARCHAR,dd.NroServicio) + CONVERT(VARCHAR,dd.Turno) + CONVERT(VARCHAR,dd.NroVuelta),
				    dd.NroServicio, dd.Turno, dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
				FROM Diagramas d
					INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
					INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
						WHERE
							d.Id = ' + CONVERT(VARCHAR, @IdDiagrama) + '
							AND s.IdaVuelta = ''I''
							AND s.UserDel IS NUll
							AND dd.UserDel IS NUll
			 ) AS SourceTable
			PIVOT
			(
				MIN(Hora)
				FOR DescripcionCorta IN (' + @ColumnasIda + ')
			) AS PivotTable'
  
  	EXECUTE sp_executesql @SQLString
	
	SELECT @PrimerColumnaIda = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T1' AND ORDINAL_POSITION = '5'
	
	SELECT @ColumnasVuelta = COALESCE(@ColumnasVuelta + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', ''),
		   @ColumnasVueltasSelect = COALESCE(@ColumnasVueltasSelect + 'TT.[' + CAST(DescripcionCorta as VARCHAR(20)) + ' ],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @IdDiagrama and UserDel Is NULL) AND IdaVuelta = 'V') AS DSC
	ORDER BY Numero

	SET @ColumnasVuelta = LEFT(@ColumnasVuelta, LEN(@ColumnasVuelta) -1)
	SET @ColumnasVueltasSelect = LEFT(@ColumnasVueltasSelect, LEN(@ColumnasVueltasSelect) -1)
 	
 	SET @SQLString = N'
		SELECT * INTO T2 
			FROM
			(SELECT Id = CONVERT(VARCHAR,dd.NroServicio) + CONVERT(VARCHAR,dd.Turno) + CONVERT(VARCHAR,dd.NroVuelta), 
				    dd.NroServicio, dd.Turno, dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
				FROM Diagramas d
					INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
					INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
						WHERE
							d.Id = ' + CONVERT(VARCHAR, @IdDiagrama) + '
							AND s.IdaVuelta = ''V''
							AND s.UserDel IS NUll
							AND dd.UserDel IS NUll
			 ) AS SourceTable
			PIVOT
			(
				MIN(Hora)
				FOR DescripcionCorta IN (' + @ColumnasVuelta + ')
			) AS PivotTable'
		 
	EXECUTE sp_executesql @SQLString
	
	SELECT @PrimerColumnaVuelta = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T2' AND ORDINAL_POSITION = '5'
							   
	DECLARE @CantCol Varchar(3)
	SELECT @CantCol = COUNT(*) FROM information_schema.columns WHERE table_name = 'T2' 
			  		   
	SELECT @UltimaColumnaVuelta = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T2' AND ORDINAL_POSITION = @CantCol

	DECLARE cur CURSOR FOR	
		SELECT Id FROM T1
	OPEN cur
	FETCH NEXT FROM cur INTO @Id 
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T1 WHERE ' + @PrimerColumnaIda + ' = (SELECT MIN(' + @PrimerColumnaIda + ') FROM T1 WHERE ' + @PrimerColumnaIda + ' <> '' ' + ''' AND Id NOT IN (SELECT Value FROM Vertical)) AND Id NOT IN (SELECT Value FROM Vertical)'
		SET @ParmDefinition = N'@retvalOUT int OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id1 OUTPUT  
	
		IF @Id1 IS NULL
		BEGIN
			SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T1 WHERE Id NOT IN (SELECT Value FROM Vertical)'
			SET @ParmDefinition = N'@retvalOUT int OUTPUT';
			EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id1 OUTPUT  
		END
		
		SELECT @SQLString = N'SELECT @retvalHoraOUT = T1.' + @PrimerColumnaIda + ' FROM T1 WHERE Id = ' + CONVERT(VARCHAR,@Id1)  
		SET @ParmDefinition = N'@retvalHoraOUT NVarchar(MAX) OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalHoraOUT = @Hora1 OUTPUT  
		   
		
		SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T2 WHERE ' + @PrimerColumnaVuelta + ' = (SELECT MIN(' + @PrimerColumnaVuelta + ') FROM T2 WHERE ' + @PrimerColumnaVuelta + ' <> '' ' + '''AND Id NOT IN (SELECT Value FROM Vertical)) AND Id NOT IN (SELECT Value FROM Vertical)'
		SET @ParmDefinition = N'@retvalOUT int OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id2 OUTPUT  
	
		IF @Id2 IS NULL
		BEGIN
			SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T2 WHERE Id NOT IN (SELECT Value FROM Vertical)'
			SET @ParmDefinition = N'@retvalOUT int OUTPUT';
			EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id2 OUTPUT  
		END
		
		SELECT @SQLString = N'SELECT @retvalHoraOUT = T2.' + @PrimerColumnaVuelta + ' FROM T2 WHERE Id = ' + CONVERT(VARCHAR,@Id2)
		SET @ParmDefinition = N'@retvalHoraOUT NVarchar(MAX) OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalHoraOUT = @Hora2 OUTPUT  
		 
		IF @Id1 <> @Id2
			IF @Hora1 < @Hora2
			BEGIN
				INSERT INTO Vertical VALUES (@Id1)
			END
			ELSE
			BEGIN
				INSERT INTO Vertical VALUES (@Id2)
			END
		ELSE
			BEGIN
				IF @Id1 is not null 
				 INSERT INTO Vertical VALUES (@Id1)
			END
		 
	FETCH NEXT FROM cur INTO @Id 
	END

	CLOSE cur 
	DEALLOCATE cur  
		
	SET @SQLString = N'
		 SELECT 
			Servicio = ISNULL(T.NroServicio, TT.NroServicio),
			Turno = ISNULL(T.Turno, TT.Turno),
			Vuelta = ISNULL(T.NroVuelta, TT.NroVuelta), ' +
			@ColumnasIdaSelect + ', ' +
			'[//] = ''//'' ,' +
			@ColumnasVueltasSelect + ', 
			[T.Vuelta] = RTRIM(CONVERT(VARCHAR(5),(CASE WHEN RTRIM(LTRIM(T.' + @PrimerColumnaIda + ')) = '''' THEN '''' 
											 	   WHEN RTRIM(LTRIM(TT.' + @UltimaColumnaVuelta + ')) = '''' THEN '''' 
												   WHEN CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ') > CONVERT(DATETIME, T.' + @PrimerColumnaIda + ') 
												   THEN CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ') - CONVERT(DATETIME, T.' + @PrimerColumnaIda + ')
												   ELSE 
												   DATEADD(DD, 1,  CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ')) - CONVERT(DATETIME, T.' + @PrimerColumnaIda + ')
												   END),114))
			FROM T1 T
			FULL JOIN T2 TT ON T.Id = TT.ID 
			FULL JOIN Vertical T3  ON T3.Value = T.ID
		ORDER BY T3.ordering'
		 
		
	print @SQLString
	EXECUTE sp_executesql @SQLString
		
END