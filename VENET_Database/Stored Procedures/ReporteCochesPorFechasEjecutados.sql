CREATE PROCEDURE [dbo].[ReporteCochesPorFechasEjecutados]
	@FechaDesde DATE  = '20160201',
	@FechaHasta DATE  = '20160201',
	@IdUN INT = 6,
	@IdUser INT = 0

AS
BEGIN

	IF (SELECT g.EsAdministrador FROM SeguridadUsuarios s INNER JOIN SeguridadGrupos g ON s.Id_Grupo = g.Id WHERE s.Id = @IdUser) = 1
		SET @IdUser = 0 

	SELECT Fecha, Unidad_Negocio = unidadNegocio, Linea, Servicio, Turno, Lugar_Inicio = lugarInicio, Interno_Planificado = internoPlanificado, Legajo_Planificado = legajoPlanificado, Nombre = nombrePlanificado, Inicio = inicioPlanificado, Fin = finPlanificado, Interno_Ejecutado = internoEjecutado, Inicio_Real = InicioReal, Fin_Real = finReal, Legajo_Ejecuta = legajoEjecutado, Nombre_Ejecuta = nombreEjecutado, Observaciones
		FROM [ErsaGeneral_WebTrafico].[dbo].[registros] r
		WHERE r.Fecha BETWEEN @FechaDesde AND @FechaHasta
		 AND (r.IdUnidad = @IdUN OR @IdUN = 0)
		 AND (@IdUser = 0 OR r.IdUnidad IN (SELECT Id_UnidadNegocio FROM SeguridadUsuariosUnidadNegocios WHERE Id_Usuario = @IdUser))
		 AND r.internoEjecutado > 0
END