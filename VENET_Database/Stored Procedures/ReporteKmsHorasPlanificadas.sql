 
CREATE PROCEDURE [dbo].[ReporteKmsHorasPlanificadas]
	@Planificado INT = 0,
	@IdUnidadNegocio INT = 0,
	@FechaDesde DATE = '20150320',
	@FechaHasta DATE = '20150321',
	@IdUser INT = 1
AS
BEGIN

	IF (SELECT g.EsAdministrador
		FROM SeguridadUsuarios u INNER JOIN SeguridadGrupos g ON u.Id_Grupo = g.Id
			WHERE u.Id = @IdUser) = 1

		IF @Planificado = 1
			SELECT n.Descripcion, pd.Fecha, Minutos = SUM(CASE WHEN ds.HoraFinalizacion < ds.HoraCitacion THEN (DATEDIFF(MINUTE, ds.HoraFinalizacion, ds.HoraCitacion)) ELSE (DATEDIFF(MINUTE, ds.HoraCitacion, ds.HoraFinalizacion)) END), Kms = SUM(ds.Kms)
				FROM PlanificacionDetallesConfirmado pd
				INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
				INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
				INNER JOIN Diagramas d ON ds.Id_Diagrama = d.Id
				INNER JOIN UnidadNegocios n ON p.Id_UnidadNegocio = n.Id
					WHERE (p.Id_UnidadNegocio = @IdUnidadNegocio OR @IdUnidadNegocio = 0) AND 
						  p.UserDel IS NULL AND
						  pd.Id_Servicio > 0 AND 
						  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta
			GROUP BY pd.Fecha, n.Descripcion
		ELSE
			SELECT n.Descripcion, pd.Fecha, Minutos = SUM(CASE WHEN ds.HoraFinalizacion < ds.HoraCitacion THEN (DATEDIFF(MINUTE, ds.HoraFinalizacion, ds.HoraCitacion)) ELSE (DATEDIFF(MINUTE, ds.HoraCitacion, ds.HoraFinalizacion)) END), Kms = SUM(ds.Kms)
				FROM PlanificacionDetalles pd
				INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
				INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
				INNER JOIN Diagramas d ON ds.Id_Diagrama = d.Id
				INNER JOIN UnidadNegocios n ON p.Id_UnidadNegocio = n.Id
					WHERE (p.Id_UnidadNegocio = @IdUnidadNegocio OR @IdUnidadNegocio = 0) AND 
						  p.UserDel IS NULL AND
						  pd.Id_Servicio > 0 AND 
						  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta
			GROUP BY pd.Fecha, n.Descripcion
	
	ELSE
		IF @Planificado = 1
			SELECT n.Descripcion, pd.Fecha, Minutos = SUM(CASE WHEN ds.HoraFinalizacion < ds.HoraCitacion THEN (DATEDIFF(MINUTE, ds.HoraFinalizacion, ds.HoraCitacion)) ELSE (DATEDIFF(MINUTE, ds.HoraCitacion, ds.HoraFinalizacion)) END), Kms = SUM(ds.Kms)
				FROM PlanificacionDetalles pd
				INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
				INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
				INNER JOIN Diagramas d ON ds.Id_Diagrama = d.Id
				INNER JOIN UnidadNegocios n ON p.Id_UnidadNegocio = n.Id
				INNER JOIN SeguridadUsuariosUnidadNegocios u ON n.Id = u.Id_UnidadNegocio
					WHERE (p.Id_UnidadNegocio = @IdUnidadNegocio OR @IdUnidadNegocio = 0) AND 
						  p.UserDel IS NULL AND
						  pd.Id_Servicio > 0 AND 
						  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
						  u.Id_Usuario = @IdUser
			GROUP BY pd.Fecha, n.Descripcion
		ELSE
			SELECT n.Descripcion, pd.Fecha, Minutos = SUM(CASE WHEN ds.HoraFinalizacion < ds.HoraCitacion THEN (DATEDIFF(MINUTE, ds.HoraFinalizacion, ds.HoraCitacion)) ELSE (DATEDIFF(MINUTE, ds.HoraCitacion, ds.HoraFinalizacion)) END), Kms = SUM(ds.Kms)
				FROM PlanificacionDetallesConfirmado pd
				INNER JOIN Planificacion p ON pd.Id_Planificacion = p.Id
				INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
				INNER JOIN Diagramas d ON ds.Id_Diagrama = d.Id
				INNER JOIN UnidadNegocios n ON p.Id_UnidadNegocio = n.Id
				INNER JOIN SeguridadUsuariosUnidadNegocios u ON n.Id = u.Id_UnidadNegocio
					WHERE (p.Id_UnidadNegocio = @IdUnidadNegocio OR @IdUnidadNegocio = 0) AND 
						  p.UserDel IS NULL AND
						  pd.Id_Servicio > 0 AND 
						  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
						  u.Id_Usuario = @IdUser
			GROUP BY pd.Fecha, n.Descripcion

END