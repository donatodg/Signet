CREATE FUNCTION [dbo].[GetProximoDiaHabil]
	(@Fecha DATETIME, 
	 @Dias INT)

RETURNS DATETIME 

AS  
BEGIN 
	DECLARE @dFecha DATETIME = @Fecha
    DECLARE @intItem INT = 1
	
	IF @Dias = 0 
		SET @Dias = 1  

	WHILE @intItem <= @Dias
		BEGIN
			SET @dFecha = DATEADD(DD, 1, @dFecha)
			
			WHILE (SELECT dbo.IsDiaHabil(@dFecha)) = 0
				BEGIN
					SET @dFecha = DateAdd(DD, 1, @dFecha)
				END
			SET @intItem = @intItem + 1
		END

	RETURN @dFecha
END

