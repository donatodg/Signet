CREATE PROCEDURE [dbo].[PlanificacionDetallesCochesDiaria2]
	@Id_Planificacion INT,
	@Fecha DATETIME,
	@Id_TipoServicio INT,
	@Id_Diagrama INT,
	@UserMod INT
	 
AS
BEGIN

	UPDATE PlanificacionDetalles 
		SET Id_Servicio = 0, Novedad = '', FechaMod = GETDATE(), UserMod = @UserMod
			WHERE Id_Planificacion = @Id_Planificacion AND 
			      Fecha = @Fecha AND
			      Id_Servicio IN (SELECT Id FROM Diagramas_Servicios WHERE Id_Diagrama = (SELECT TOP 1 Id_Diagrama FROM PlanificacionDetallesCoches 
									WHERE Id_Planificacion = @Id_Planificacion AND Fecha = @Fecha AND Id_TipoServicio = @Id_TipoServicio))
 
	UPDATE PlanificacionDetallesCoches 
		SET Id_Servicio = 0, FechaMod = GETDATE(), UserMod = @UserMod
			WHERE Id_Planificacion = @Id_Planificacion AND 
				  Fecha = @Fecha AND 
				  Id_Servicio IN (SELECT Id FROM Diagramas_Servicios WHERE Id_Diagrama = (SELECT TOP 1 Id_Diagrama FROM PlanificacionDetallesCoches 
									WHERE Id_Planificacion = @Id_Planificacion AND Fecha = @Fecha AND Id_TipoServicio = @Id_TipoServicio))
 
	UPDATE PlanificacionDetallesCoches 
		SET Id_Diagrama = @Id_Diagrama 
			WHERE Id_Planificacion = @Id_Planificacion AND Id_TipoServicio = @Id_TipoServicio AND Fecha = @Fecha
	
END