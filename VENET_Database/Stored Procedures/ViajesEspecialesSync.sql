CREATE PROCEDURE [dbo].[ViajesEspecialesSync]
	@Id_UnidadNegocio INT = 6
AS
BEGIN

INSERT INTO ErsaGeneral_WebTrafico..registros
(
	   [fecha]
      ,[idUnidad]
      ,[unidadNegocio]
      ,[empresa]
      ,[linea]
      ,[servicio]
      ,[turno]
      ,[lugarInicio]
	  ,[destino]
      ,[internoPlanificado]
      ,[legajoPlanificado]
      ,[nombrePlanificado]
	  ,[original]
      ,[inicioPlanificado]
      ,[finPlanificado]
      ,[estado]
      ,[cantMediaVuelta]
	  ,[agregado]
	  ,[viajeesp]
	  ,[reemplazo]
	  ,[legajoEjecutado]
	  ,[nombreEjecutado]
	  ,[observaciones]
	  ,[observaciones2]
	  ,[autoriza]
	  ,[fueraLinea]
	  ,[viatico]
	  ,[solicitante]
)
(SELECT 
		fecha = CONVERT(DATE, ve.FechaInicio), 
		idUnidad = CASE WHEN u.Id = 23 THEN 3 WHEN u.Id = 27 THEN 3 ELSE u.Id END,
		unidadNegocio = CASE WHEN u.Id = 23 THEN 'Buses Urbanos Corrientes'
							 WHEN U.Id = 3 THEN 'Buses Urbanos Corrientes'
							 WHEN U.Id = 27 THEN 'Buses Urbanos Corrientes'
							 ELSE u.Descripcion END,
		empresa = NULL,
		linea = NULL,
		servicio = ve.Numero,
		turno = NULL,
		lugarInicio = CONVERT(VARCHAR(50), ve.Origen),
		destino = CONVERT(VARCHAR(50), ve.Destino),
		internoPlanificado = ISNULL((SELECT ISNULL(c.Interno,'0') 
									 FROM Coches c where ved.Id_Coche = c.Id), 0),
		legajoPlanificado = p1.Laborallegajo,
		nombrePlanificado = LTRIM(RTRIM(p1.Apellido)) + ', ' + LTRIM(RTRIM(p1.Nombre)),
		original = 1,
		inicioPlanificado = CONVERT(TIME, ve.FechaInicio),
		finPlanificado = CONVERT(TIME, ve.FechaFin),
		estado = 'P',
		cantMediaVuelta = NULL,
		agregado = 1,
		viajeesp =1, 
		reemplazo = CASE WHEN p2.id IS NULL THEN 0 ELSE 1 END,
		legajoEjecutado = CASE WHEN p2.id IS NULL THEN NULL ELSE p2.Laborallegajo END,
		nombreEjecutado = CASE WHEN p2.id IS NULL THEN NULL ELSE LTRIM(RTRIM(p2.Apellido)) + ', ' + LTRIM(RTRIM(p2.Nombre)) END,
		observaciones = CONVERT(VARCHAR(1000), ve.Contacto),
		observaciones2 = CONVERT(VARCHAR(1000), ve.Observaciones),
		autoriza =	CONVERT(VARCHAR(60), p3.Apellido + ', ' + p3.Nombre),
		fueraLinea = CASE WHEN ved.FueraLinea IS NULL THEN 'NO' WHEN  ved.FueraLinea = 1 THEN 'SI' ELSE 'NO' END,
		viatico = CASE WHEN ved.CobraViaticoPersonal1 IS NULL THEN 'NO' WHEN  ved.CobraViaticoPersonal1 = 1 THEN 'SI' ELSE 'NO' END,
		solicitante = CONVERT(VARCHAR(60), c.Nombre)
	FROM ViajesEspeciales ve
	INNER JOIN UnidadNegocios u ON ve.Id_UnidadNegocio = u.Id
	INNER JOIN ViajesEspecialesDetalle ved ON ve.Id = ved.Id_ViajeEspecial
	INNER JOIN Personal p1 ON ved.Id_Personal1 = p1.Id
	LEFT JOIN Personal p2 ON ved.Id_Personal2 = p2.Id
	INNER JOIN Personal p3 ON ve.Id_PersonalAutoriza = p3.Id
	INNER JOIN Clientes c ON ve.Id_Cliente = c.id
	--LEFT JOIN [ErsaGeneral_WebTrafico].[dbo].[Registros] r ON idUnidad = (CASE WHEN u.Id = 23 THEN 3 WHEN u.Id = 27 THEN 3 ELSE u.Id END)
	--													AND agregado = 1
	--													AND viajeesp = 1 
	--													AND servicio = ve.Numero
	--													AND CONVERT(DATE, r.fecha) = CONVERT(DATE, GETDATE()) 
	WHERE ve.UserDel IS NULL
		  AND ve.Id_UnidadNegocio = @Id_UnidadNegocio
		  AND CONVERT(DATE, ve.FechaInicio) = CONVERT(DATE, GETDATE()) 
		  AND r.id IS NULL
 )

END