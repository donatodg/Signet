CREATE PROCEDURE [dbo].[PlanificacionLargaHsChoferPorFechas]
	@Id_Planificacion INT = 22,
	@FechaDesde DATETIME = '20160101',
	@FechaHasta DATETIME = '20160101',
	@IdPersonal INT = 5606,
	@Planificado INT = 1,
	@Id_UnidadNegocio INT = 3
	
AS
BEGIN

	SET NOCOUNT ON;
	
	IF @Planificado = 1
		SELECT Id_CodigoServicio = ISNULL(cs.Id, 0),
			   Fecha = pld.Fecha,
			   Codigo = ISNULL(cs.Codigo, ''),
			   Descripcion = ISNULL(cs.Descripcion, t.DescripcionLarga),
			   Id_Personal = p.Id,
			   Legajo = p.laboralLegajo,
			   Personal = p.Apellido + ', ' + p.Nombre,
			   Hs100 = CASE WHEN f.Id IS NOT NULL AND (select MIN(csf.dia)
													   from CodigosServiciosFechas csf 
													   inner join CodigosServiciosVueltas csv on csf.Id_CodigoServicioVuelta = csv.Id
													   where csf.UserDel IS null
													   and csv.UserDel IS null
													   and csv.Id_CodigoServicio = cs.Id
													   and csf.Fecha = pld.Fecha) = 1 then cs.Hs100  
							WHEN f1.Id IS NOT NULL AND (select MAX(csf.dia)
													   from CodigosServiciosFechas csf 
													   inner join CodigosServiciosVueltas csv on csf.Id_CodigoServicioVuelta = csv.Id
													   where csf.UserDel IS null
													   and csv.UserDel IS null
													   and csv.Id_CodigoServicio = cs.Id
													   and csf.Fecha = pld.Fecha) = 2 then cs.Hs1001
													   else 0 end,
			   Hs50 = ISNULL(CASE WHEN f.Id IS NULL AND f1.Id IS NULL THEN cs.Hs50 + cs.Hs501
								  WHEN f.Id IS NULL AND f1.Id IS NOT NULL THEN cs.Hs50 
								  WHEN f.Id IS NOT NULL AND f1.Id IS  NULL THEN cs.Hs501
								  WHEN pld.Id_Novedad = 2 THEN 8				
								  WHEN pld.Id_Novedad >= 4 AND pld.Id_Novedad <= 6 THEN 8		
								  WHEN pld.Id_Novedad = 7 THEN 8		
								  WHEN pld.Id_Novedad >= 11 AND pld.Id_Novedad <= 68 THEN 8 
								  WHEN pld.Id_Novedad = 73 THEN 8   
								  WHEN pld.Id_Novedad = 77 THEN 8  
								  WHEN pld.Id_Novedad = 80 THEN 8
								  ELSE 0 END, 0),
			   HsPlus = ISNULL((cs.HsPlus + cs.HsPlus1), 0),
			   HsSimple = ISNULL(CASE WHEN f.Id IS NULL AND f1.Id IS NULL THEN cs.HsSimple + cs.HsSimple1
								      WHEN f.Id IS NULL AND f1.Id IS NOT NULL THEN cs.HsSimple 
								      WHEN f.Id IS NOT NULL AND f1.Id IS  NULL THEN cs.HsSimple1
								      WHEN pld.Id_Novedad = 2 THEN 8				
								      WHEN pld.Id_Novedad >= 4 AND pld.Id_Novedad <= 6 THEN 8		
								      WHEN pld.Id_Novedad = 7 THEN 8		
								      WHEN pld.Id_Novedad >= 11 AND pld.Id_Novedad <= 68 THEN 8 
								      WHEN pld.Id_Novedad = 73 THEN 8   
								      WHEN pld.Id_Novedad = 77 THEN 8  
								      WHEN pld.Id_Novedad = 80 THEN 8 ELSE 0 END, 0),
			   HsTomeDeje = ISNULL((cs.HsTomeDeje + cs.HsTomeDeje1), 0),
			   --HsTomeDeje = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, ISNULL((cs.HsTomeDeje + cs.HsTomeDeje1), 0)), 0), ISNULL((cs.HsTomeDeje + cs.HsTomeDeje1), 0)),
			   Linea = ISNULL(l.Descripcion, ''),
			   Cabecera = ISNULL(c.Descripcion, '')
		FROM PlanificacionLargaDetalles pld
		LEFT JOIN TipoNovedades t ON pld.Id_Novedad = t.Id
		LEFT JOIN CodigosServiciosTodos cst ON pld.Id_CodigoServicioTodos = cst.Id
		LEFT JOIN CodigosServicios cs ON cst.Id_CodigoServicio = cs.Id
		INNER JOIN Personal p ON p.Id = pld.Id_Personal 
		LEFT JOIN Cabeceras c ON p.LaboralId_Cabecera = c.Id
		LEFT JOIN Lineas l ON c.Id_Linea = l.Id
		LEFT JOIN Feriado f ON pld.Fecha = f.Fecha
		LEFT JOIN Feriado f1 ON DATEADD(D, 1, pld.Fecha) = f1.Fecha
		WHERE (pld.Fecha between @FechaDesde AND @FechaHasta) AND 
			  pld.Id_Planificacion = @Id_Planificacion AND
			  pld.UserDel IS NULL AND 
			  (p.Id = @IdPersonal OR @IdPersonal = 0) AND
			  p.Id_Jerarquia = 1
		  ORDER BY pld.Fecha
	
	ELSE
		SELECT Id_CodigoServicio = cs.Id, 
			   Fecha = csf.Fecha,
			   cs.Codigo, 
			   cs.Descripcion, 
			   Id_Vuelta = csv.Id,
			   Id_Personal = p.Id,
			   Legajo = p.laboralLegajo,
			   Personal = p.Apellido + ', ' + p.Nombre,
			   Estado_Servicio = cse.Descripcion,
			   Coche = ISNULL(CONVERT(VARCHAR, c.Interno), ''),
			   Hs100 = CASE WHEN f.Id IS NOT NULL AND csf.Dia = 1 THEN cs.Hs100 
							WHEN f1.Id IS NOT NULL AND csf.Dia = 2 THEN cs.Hs1001 
							ELSE 0 
							END,
			   Hs50 = CASE WHEN f.Id IS NOT NULL THEN 0
						   WHEN f1.Id IS NOT NULL THEN 0 
				      ELSE CASE WHEN csf.Dia = 1 THEN cs.Hs50 ELSE cs.Hs501 END END,
			   HsPlus = CASE WHEN csf.Dia = 1 THEN cs.HsPlus ELSE cs.HsPlus1 END,
			   HsSimple = CASE WHEN f.Id IS NOT NULL THEN 0
						       WHEN f1.Id IS NOT NULL THEN 0 
						  ELSE CASE WHEN csf.Dia = 1 THEN cs.HsSimple ELSE cs.HsSimple1 END END,
			   HsTomeDeje = CASE WHEN csf.Dia = 1 THEN cs.HsTomeDeje ELSE cs.HsTomeDeje1 END,
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
			   csv.Sentido,
			   Linea = ISNULL(l.Descripcion, ''),
			   Cabecera = ISNULL(ca.Descripcion, '')
		FROM CodigosServiciosFechas csf
		INNER JOIN CodigosServiciosVueltas csv ON csf.Id_CodigoServicioVuelta = csv.Id
		INNER JOIN CodigosServicios cs ON csv.Id_CodigoServicio = cs.Id
		INNER JOIN CodigosServiciosEstados cse ON csf.Id_Estado = cse.Id
		INNER JOIN Personal p ON p.Id = csf.Id_Personal1 or p.Id = csf.Id_Personal2
		LEFT JOIN Coches c ON csf.Id_Coche = c.Id
		LEFT JOIN Feriado f ON csf.Fecha = f.Fecha
		LEFT JOIN Feriado f1 ON DATEADD(D, 1, csf.Fecha) = f1.Fecha
		LEFT JOIN Cabeceras ca ON p.LaboralId_Cabecera = ca.Id
		LEFT JOIN Lineas l ON ca.Id_Linea = l.Id
		WHERE (csf.Fecha between @FechaDesde AND @FechaHasta) AND 
			  csf.UserDel IS NULL AND 
			  cse.PagaHoras = 1	AND 
			  (p.Id = @IdPersonal OR @IdPersonal = 0) AND
			  p.LaboralId_UnidadNegocio = @Id_UnidadNegocio AND
			  p.Id_Jerarquia = 1
			
		ORDER BY csf.Fecha

 END