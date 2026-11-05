 create FUNCTION [dbo].[ValidarCBUdigito] 
( 
-- Add the parameters for the function here 
@block VARCHAR(100) 
) 
RETURNS TINYINT 
AS 
BEGIN 
DECLARE @subblock VARCHAR(100) 
DECLARE @posicion INTEGER 
DECLARE @digito CHAR(1) 
DECLARE @Pond CHAR(4) 
DECLARE @largo	INTEGER 
DECLARE @suma	INTEGER 

SELECT @suma	= 0 
SELECT @largo	= LEN ( @block ) 
SELECT @digito	= SUBSTRING ( @block , @largo , 1 ) 
SELECT @subblock	= SUBSTRING ( @block , 1 , @largo - 1 ) 
SELECT @Pond	= '9713' 
SELECT @posicion	= 1 

WHILE @posicion <= @largo - 1 
BEGIN 
SELECT @suma = @suma + CONVERT( INTEGER , SUBSTRING ( @subblock , @largo - @posicion , 1 )) * CONVERT( INTEGER , SUBSTRING ( @pond ,CASE (@posicion % 4) WHEN 1 THEN 4 WHEN 2 THEN 3 WHEN 3 THEN 2 WHEN 0 THEN 1 END , 1 ) ) 
SELECT @posicion = @posicion + 1 
END 


if @digito = RIGHT ( convert( varchar, 10 - ( @suma % 10 )) , 1 ) 
RETURN 1 

RETURN 0 
END