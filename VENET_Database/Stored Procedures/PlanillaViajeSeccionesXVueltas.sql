
create PROCEDURE [dbo].[PlanillaViajeSeccionesXVueltas]
	@Id_Diagrama INT = 256,  
	@Fecha DATETIME = '20150403',
	@NroServicio INT = 3,
	@Turno INT = 2 
	
AS
BEGIN

	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @ColumnasV NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

 	SELECT @Columnas =  COALESCE(@Columnas + CAST(DescripcionCorta as VARCHAR(20)) + ';', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'I') AS DSC
	ORDER BY Numero

	SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	
	SELECT @ColumnasV =  COALESCE(@ColumnasV + CAST(DescripcionCorta as VARCHAR(20)) + ';', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = 'V') AS DSC
	ORDER BY Numero

	SET @ColumnasV = LEFT(@ColumnasV,LEN(@ColumnasV)-1)

	Select @Columnas
	Select @ColumnasV
END
 