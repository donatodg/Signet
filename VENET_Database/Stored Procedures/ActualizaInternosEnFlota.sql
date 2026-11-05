CREATE PROCEDURE ActualizaInternosEnFlota
	@Id INT = NULL

AS
BEGIN
PRINT 'DESCOMENTAR'
	--UPDATE [192.168.1.226].[ErsaGeneral].[dbo].[asignacion] 
	--SET [codigoUnidadOperativa] = t.UNO,
	--	[codigoEmpresaOperativa] = t.EO,
	--	[codRegionOperativa] = t.RO
	--FROM
	--	(SELECT c.Dominio,
	--			EO = CASE WHEN c.Id_Empresa > 13 THEN NULL ELSE c.Id_Empresa END,
	--			UNO = CASE WHEN c.Id_UnidadNegocio = 23 THEN 16 
	--					   WHEN c.Id_UnidadNegocio = 9 THEN 6 
	--					   WHEN c.Id_UnidadNegocio = 3 THEN 16 
	--					   WHEN c.Id_UnidadNegocio = 26 THEN 19 
	--					   WHEN c.Id_UnidadNegocio = 6 THEN 13
	--					   WHEN c.Id_UnidadNegocio = 21 THEN 15 
	--					   WHEN c.Id_UnidadNegocio = 7 THEN 11
	--					   WHEN c.Id_UnidadNegocio = 24 THEN 18 
	--					   WHEN c.Id_UnidadNegocio = 13 THEN 6
	--					   WHEN c.Id_UnidadNegocio = 5 THEN 14
	--					   WHEN c.Id_UnidadNegocio = 16 THEN 13 
	--					   WHEN c.Id_UnidadNegocio = 17 THEN 20 
	--					   WHEN c.Id_UnidadNegocio = 11 THEN 18 
	--					   WHEN c.Id_UnidadNegocio = 20 THEN 15
	--					   WHEN c.Id_UnidadNegocio = 8 THEN 10 
	--					   ELSE NULL END,
	--			RO  = CASE WHEN c.Id_UnidadNegocio = 23 THEN 0 
	--					   WHEN c.Id_UnidadNegocio = 9 THEN 1 
	--					   WHEN c.Id_UnidadNegocio = 3 THEN 0 
	--					   WHEN c.Id_UnidadNegocio = 26 THEN 2 
	--					   WHEN c.Id_UnidadNegocio = 6 THEN 0
	--					   WHEN c.Id_UnidadNegocio = 21 THEN 1 
	--					   WHEN c.Id_UnidadNegocio = 7 THEN 0
	--					   WHEN c.Id_UnidadNegocio = 24 THEN 2 
	--					   WHEN c.Id_UnidadNegocio = 13 THEN 1
	--					   WHEN c.Id_UnidadNegocio = 5 THEN 3
	--					   WHEN c.Id_UnidadNegocio = 16 THEN 0 
	--					   WHEN c.Id_UnidadNegocio = 17 THEN 1 
	--					   WHEN c.Id_UnidadNegocio = 11 THEN 2 
	--					   WHEN c.Id_UnidadNegocio = 20 THEN 1
	--					   WHEN c.Id_UnidadNegocio = 8 THEN 1 
	--					   ELSE NULL END 
	--	FROM Coches c
	--	INNER JOIN [192.168.1.226].[ErsaGeneral].[dbo].[asignacion] a ON c.Dominio = a.dominio AND c.Dominio <> 'AAA111'
	--	WHERE c.Id = @Id OR @Id IS NULL) AS t
	--INNER JOIN [192.168.1.226].[ErsaGeneral].[dbo].[asignacion] aa ON aa.Dominio = t.Dominio
	--WHERE aa.dominio = t.Dominio
	
END