CREATE FUNCTION [dbo].[IsDiaHabil](@Fecha DATETIME)
RETURNS BIT AS  

BEGIN 
	DECLARE @Return BIT
	DECLARE @intDayOfWeek INT

	SET @intDayOfWeek = DATEPART(DW,@Fecha)
	SET @Return = 1
	    
	-- Sabado o Domingo
	IF (@intDayOfWeek = 6 OR @intDayOfWeek = 7) 
		SET @Return = 0
	ELSE
		BEGIN
			IF EXISTS (SELECT * FROM Feriado WHERE Fecha = @Fecha)
				SET @Return = 0
		END

	RETURN @Return
END


