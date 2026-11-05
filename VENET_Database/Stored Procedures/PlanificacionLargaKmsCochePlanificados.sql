CREATE PROCEDURE [dbo].PlanificacionLargaKmsCochePlanificados
	@Id_Planificacion INT = 19,
	@FechaDesde DATETIME = '20150101',
	@FechaHasta DATETIME = '20190101' 
	
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		Fecha = pls.Fecha,
		Id_CodigoServicio = cs.Id,
		Codigo = cs.Codigo,
		Descripcion = cs.Descripcion,
		Id_Vuelta = csv.Id,
		KmsProductivos = csv.KmsProductivos,
		KmsImproductivos = csv.KmsImproductivos,
		NroVuelta = csv.NroVuelta,
		Origen = (SELECT TOP 1 s.Descripcion
 				  FROM CodigosServiciosVueltasDetalle csvd
				  INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				  WHERE csvd.Id_CodigoServicioVuelta = csv.Id
				  ORDER BY Dia, Hora),
		Destino = (SELECT TOP 1 s.Descripcion
				   FROM CodigosServiciosVueltasDetalle csvd
				   INNER JOIN Secciones s ON csvd.Id_Seccion = s.Id
				   WHERE csvd.Id_CodigoServicioVuelta = csv.Id
				   ORDER BY Dia desc, Hora desc),
		Sentido = csv.Sentido,
		Linea = l.Descripcion,
		Ramal = r.Descripcion,
		Tipo_Servicio = ts.Descripcion
	FROM PlanificacionLargaServicios pls
		INNER JOIN CodigosServicios cs ON pls.Id_CodigoServicio = cs.Id
		INNER JOIN CodigosServiciosVueltas csv ON cs.Id = csv.Id_CodigoServicio
		INNER JOIN TipoServicios ts ON cs.Id_TipoServicio = ts.Id
		INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
		INNER JOIN Lineas l ON r.Id_Linea = l.Id
	WHERE Id_Planificacion = @Id_Planificacion AND
		 pls.UserDel IS NULL AND
		 cs.UserDel IS NULL AND
		 csv.UserDel IS NULL  
	ORDER BY Fecha

 END