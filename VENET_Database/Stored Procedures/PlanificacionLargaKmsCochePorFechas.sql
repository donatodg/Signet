 
CREATE PROCEDURE [dbo].[PlanificacionLargaKmsCochePorFechas]
	--@Id_Planificacion INT = 19,
	@Id_UnidadNegocio INT,
	@FechaDesde DATETIME = '20150101',
	@FechaHasta DATETIME = '20190101',
	@IdCoche INT = 0
	
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT Id_CodigoServicio = cs.Id, 
		   Fecha = csf.Fecha,
		   cs.Codigo, 
		   cs.Descripcion, 
		   Id_Vuelta = csv.Id,
		   Estado_Servicio = cse.Descripcion,
		   Id_Coche = c.Id,
		   Interno = c.Interno,
		   Dominio = c.Dominio,
		   KmsProductivos = csv.KmsProductivos,
		   KmsImproductivos = csv.KmsImproductivos,
		   csv.NroVuelta,
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
		   csv.Sentido 
	FROM CodigosServiciosFechas csf
	INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
	INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
	INNER JOIN CodigosServiciosEstados cse ON csf.Id_Estado = cse.Id
	INNER JOIN Coches c ON csf.Id_Coche = c.Id
	WHERE (csf.Fecha between @FechaDesde AND @FechaHasta) AND 
		  c.Id_UnidadNegocio = @Id_UnidadNegocio AND
		  csf.UserDel IS NULL AND 
		  cse.SumaKms = 1	AND 
		  (c.Id = @IdCoche OR @IdCoche = 0) 
	ORDER BY csf.Fecha

 END