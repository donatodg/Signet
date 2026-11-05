CREATE PROCEDURE [dbo].[CodigosServiciosPorFechas] 
	@Id_TipoServicio INT,
	@Fecha DATETIME
AS
BEGIN

	SELECT 
		Dia = csf.Dia,
		Codigo = cs.Codigo,
		Fecha = csf.Fecha,
		csf.FechaAdd,
		csf.FechaMod,
		csf.UserAdd,
		csf.UserMod,
		csf.Id,
		csf.Id_Coche,
		Id_CodigoServicio = cs.Id,
		Id_CodigoServicioVuelta = csf.Id_CodigoServicioVuelta,
		csf.Id_Planificacion,
		csf.Id_Personal1,
		csf.Id_Personal2,
		csf.Id_Personal3,
		csf.Id_Estado,
		Servicio = cs.Descripcion,
		Sentido = csv.Sentido,
		csv.NroVuelta,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		TipoServicio = ts.Descripcion,
		Comentario = csf.Comentario,
		Salida = (SELECT TOP 1 csvd.Hora 
				 FROM CodigosServiciosVueltasDetalle csvd 
				 WHERE csvd.Id_CodigoServicioVuelta = csv.Id 
				 ORDER BY csvd.dia ASC, csvd.Hora ASC),
		Origen = (SELECT TOP 1 s.Descripcion
				 FROM CodigosServiciosVueltasDetalle csvd 
				 INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				 WHERE csvd.Id_CodigoServicioVuelta = csv.Id 
				 ORDER BY csvd.Dia ASC, csvd.Hora ASC),
		Llegada = (SELECT TOP 1 csvd.Hora 
				  FROM CodigosServiciosVueltasDetalle csvd 
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id 
				  ORDER BY csvd.Dia DESC, csvd.Hora DESC),
		Destino = (SELECT TOP 1 s.Descripcion 
				  FROM CodigosServiciosVueltasDetalle csvd 
				  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id 
				  ORDER BY csvd.Dia DESC, csvd.Hora DESC) 
	FROM CodigosServiciosFechas csf
	INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
	INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
	INNER JOIN Lineas l ON r.Id_Linea = l.Id
	WHERE cs.Id_TipoServicio = @Id_TipoServicio AND
		  csf.Fecha = @Fecha AND
		  csf.UserDel IS NULL AND
		  csv.UserDel IS NULL

END