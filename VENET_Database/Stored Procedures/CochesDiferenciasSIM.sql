CREATE PROCEDURE [dbo].CochesDiferenciasSIM
	@IdUsuario INT
AS
BEGIN

	SELECT Interno, Dominio
	FROM Coches c
	--WHERE c.UserDel IS NULL
	--  AND c.Marcado = 0
	--  AND c.Id_UnidadNegocio IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUsuario)
	--  AND RTRIM(LTRIM(Dominio)) NOT IN (SELECT RTRIM(LTRIM(Dominio)) FROM [192.168.1.226].[ErsaGeneral].[dbo].[unidades])

END

