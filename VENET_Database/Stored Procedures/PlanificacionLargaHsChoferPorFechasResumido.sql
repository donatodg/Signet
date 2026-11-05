CREATE PROCEDURE [dbo].[PlanificacionLargaHsChoferPorFechasResumido]
	@Id_Planificacion INT = 22,
	@FechaDesde DATETIME = '20160101',
	@FechaHasta DATETIME = '20160131',
	@IdPersonal INT = 5638,
	@Id_UnidadNegocio INT = 0
	
AS
BEGIN

--	SET NOCOUNT ON;
	
	SELECT 
		Id_Personal,
		Legajo, 
		Personal, 
		Linea, 
		Cabecera,
		Hs100 =  DATEADD([MINUTE], SUM(Hs100), '19000101'),
		Hs50 = DATEADD([MINUTE], SUM(Hs50), '19000101'),
		HsPlus = DATEADD([MINUTE], SUM(HsPlus), '19000101'),
		HsSimple = DATEADD([MINUTE], SUM(HsSimple), '19000101'),
		HsTomeDeje = DATEADD([MINUTE], SUM(HsTomeDeje), '19000101'),
		Francos = SUM(Francos) 
	FROM 
		(SELECT 
			Id_Personal,
			Legajo, 
			Personal, 
			Linea, 
			Cabecera,
			Hs100 = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, Hs100), 0), Hs100),
			Hs50 = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, Hs50), 0), Hs50),
			HsPlus = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, HsPlus), 0), HsPlus),
			HsSimple = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, HsSimple), 0), HsSimple),
			HsTomeDeje = DATEDIFF(MINUTE, DATEADD(DAY, DATEDIFF(DAY, 0, HsTomeDeje), 0), HsTomeDeje),
			Francos = SUM(Francos) 
		FROM 
			(
			SELECT Id_Personal = p.Id,
				   Fecha = pld.Fecha,
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
				   Linea = ISNULL(l.Descripcion, ''),
				   Cabecera = ISNULL(c.Descripcion, ''),
				   Francos = CASE WHEN pld.Id_Novedad = 1 THEN 1 WHEN pld.Id_Novedad = 3 THEN 1 ELSE 0 END
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
			) AS t
		GROUP BY Id_Personal, Fecha, Legajo, Personal, Linea, Cabecera, Hs100, Hs50, HsPlus, HsSimple, HsTomeDeje 
	) AS t2
	GROUP BY Id_Personal, Legajo, Personal, Linea, Cabecera 
	ORDER BY Linea, Cabecera, Legajo

END