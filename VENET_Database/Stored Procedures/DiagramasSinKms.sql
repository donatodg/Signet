create PROCEDURE DiagramasSinKms
	@IdUsuario INT
AS
BEGIN

	SELECT DISTINCT(d.Id) as Id_Diagrama, 
		   Diagrama = d.Descripcion,
		   Linea = l.Descripcion,
		   Ramal = r.Descripcion
	FROM Diagramas d
	INNER JOIN Diagramas_Servicios ds ON d.Id = ds.Id_Diagrama
	INNER JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN Lineas l ON r.Id_Linea = l.Id
	INNER JOIN SeguridadUsuariosUnidadNegocios un ON l.Id_UnidadNegocio = un.Id_UnidadNegocio
	WHERE d.UserDel IS NULL
	  AND ds.UserDel IS NULL
  	  AND ts.UserDel IS NULL
	  AND r.UserDel IS NULL
	  AND l.UserDel IS NULL
	  AND ds.Kms = 0
	  AND GETDATE() BETWEEN d.VigenciaDesde AND d.VigenciaHasta
	  AND un.Id_Usuario = @IdUsuario

END

