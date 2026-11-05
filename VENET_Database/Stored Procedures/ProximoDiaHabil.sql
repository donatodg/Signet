CREATE PROCEDURE[dbo].[ProximoDiaHabil]
	@Fecha DATETIME, 
	@Dias INT 

AS  
BEGIN 
	DECLARE @dFecha DATETIME = @Fecha
    DECLARE @intItem INT = 0
	
	IF (@Dias = 0 AND (dbo.IsDiaHabil(@dFecha)) = 1)
		SET @dFecha = @Fecha
	ELSE
		BEGIN
		IF @Dias = 0
			SET @Dias = 1
			
		WHILE @intItem < @Dias
			BEGIN
				SET @dFecha = DATEADD(DD, 1, @dFecha)
				
				WHILE (SELECT dbo.IsDiaHabil(@dFecha)) = 0
					BEGIN
						SET @dFecha = DateAdd(DD, 1, @dFecha)
					END
				SET @intItem = @intItem + 1
			END
		END
	
	SELECT @dFecha
END

