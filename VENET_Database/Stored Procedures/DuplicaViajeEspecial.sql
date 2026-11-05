CREATE PROCEDURE [dbo].[DuplicaViajeEspecial]
	@IdViajeEspecial INT

AS
BEGIN

	DECLARE @Id INT
	DECLARE @Numero INT

	SET @Numero = (SELECT MAX(Numero) + 1 FROM ViajesEspeciales WHERE Id_UnidadNegocio = (SELECT Id_UnidadNegocio FROM ViajesEspeciales WHERE Id = @IdViajeEspecial))

	INSERT INTO ViajesEspeciales
	SELECT Id_UnidadNegocio,@Numero,FechaSolicitado,Id_Cliente,Origen,Destino,FechaInicio,FechaFin,CantPasajeros,CantCoches,KmsEstimados,KmsVacios,KmsReales,EsperaRegreso,ImporteViaje,ImporteViaticoPorChofer,ImporteViaticoARendir,Id_PersonalAutoriza,Observaciones,Contacto,FechaPago,FechaCerrado,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel FROM ViajesEspeciales WHERE Id = @IdViajeEspecial

	SELECT @Id = @@IDENTITY

	INSERT INTO ViajesEspecialesDetalle
	SELECT @Id,Id_Coche,Id_Personal1,Id_Personal2,FueraLinea,CobraViaticoPersonal1,CobraViaticoPersonal2,Observaciones,Id_Vale,FechaPagoPersonal1,FechaPagoPersonal2,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel FROM ViajesEspecialesDetalle WHERE Id_ViajeEspecial = @IdViajeEspecial

	SELECT @Numero
END