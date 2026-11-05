CREATE PROCEDURE [dbo].[DuplicaDiagrama]
		@Diagrama_Ant INT,
		@Diagrama_Nuevo INT
AS
BEGIN
	 
	INSERT INTO Diagramas_Detalle
	SELECT @Diagrama_Nuevo,NroServicio,Turno,Id_Seccion,NroVuelta,Hora,Marcada,Comentario,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel
	FROM Diagramas_Detalle WHERE Id_Diagrama = @Diagrama_Ant
 
	INSERT INTO Diagramas_Servicios
	SELECT NroServicio,@Diagrama_Nuevo,Turno,HoraCitacion,HoraFinalizacion,Kms,Codigo,Comentario,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel
	FROM Diagramas_Servicios WHERE Id_Diagrama = @Diagrama_Ant

END