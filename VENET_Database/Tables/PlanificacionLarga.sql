CREATE TABLE [dbo].[PlanificacionLarga] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Id_UnidadNegocio]  INT           NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [FechaDesde]        DATE          NOT NULL,
    [FechaHasta]        DATE          NOT NULL,
    [FechaConfirmacion] DATETIME      NULL,
    [FechaAdd]          DATETIME      NOT NULL,
    [FechaMod]          DATETIME      NULL,
    [FechaDel]          DATETIME      NULL,
    [UserAdd]           INT           NOT NULL,
    [UserMod]           INT           NULL,
    [UserDel]           INT           NULL,
    CONSTRAINT [PK_PlanificacionLarga] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE TRIGGER [dbo].[PlanificacionLargaFechas]
   ON  [dbo].[PlanificacionLarga] 
   AFTER INSERT
AS 
BEGIN
	SET DATEFIRST 7; 
	SET NOCOUNT ON;

	DECLARE @TipoDia INT = 1 --Habil
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @Desde2 DATE
	DECLARE @Id_UnidadNegocio INT
	DECLARE @Id_TipoServicio INT = 1
	DECLARE @Id_TipoServicioPersonal INT  
	DECLARE @Id INT = 0
	DECLARE @UserAdd INT 
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @FechaNovedad DATE
	DECLARE @IdNovedad INT
	DECLARE @IdPersonal INT
	DECLARE @Novedad Varchar(5)
	DECLARE @FechaAdd DATETIME = GETDATE()
	
	--ASIGNA SERVICIOS
	---------------------------------------------------	
	SELECT @Id = Id, @Id_UnidadNegocio = Id_UnidadNegocio, @UserAdd = UserAdd, @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta FROM inserted
	
	SELECT @Columnas =  COALESCE(@Columnas + CAST(Id AS VARCHAR(12)) + ',', '') FROM
						(SELECT ts.Id 
						 FROM TipoServicios ts 
						 INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
						 INNER JOIN Lineas l ON r.Id_Linea = l.Id 
						 INNER JOIN UnidadNegocios c ON l.Id_UnidadNegocio = c.Id
						 WHERE c.Id = @Id_UnidadNegocio
							   AND l.MediaLargaDistancia = 1
							   AND c.UserDel IS NULL
							   AND r.UserDel IS NULL
							   AND l.UserDel IS NULL
							   AND ts.UserDel IS NULL) AS t
	
	WHILE LEN(@Columnas) > 0
	BEGIN
		
		SELECT @Id_TipoServicio = SUBSTRING(@Columnas, 1, CHARINDEX(',', @Columnas,0) - 1)
		
		WHILE @Desde2 <= @Hasta AND @Id_TipoServicio > 0
		BEGIN
		 
			SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 8 ELSE DATEPART(dw, @Desde2) END
								   FROM Feriado WHERE Fecha = @Desde2), DATEPART(dw, @Desde2))
			
			IF @TipoDia = 1 --DOMINGO
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Domingo = 1
			END
			
			IF @TipoDia = 2 --LUNES
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Lunes = 1
			END	 
			
			IF @TipoDia = 3 --MARTES
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Martes = 1
			END	 
		
			IF @TipoDia = 4 --MIERCOLES
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Miercoles = 1
			END	 
			
			IF @TipoDia = 5 --JUEVES
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Jueves = 1
			END	 
			
			IF @TipoDia = 6 --VIERNES
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Viernes = 1
			END	
			 
			IF @TipoDia = 7 --SABADO
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Sabado = 1
			END	 
			
			IF @TipoDia = 8 --FERIADO
			BEGIN
				INSERT INTO PlanificacionLargaServicios (Id_Planificacion, Id_TipoServicio, Id_CodigoServicio, Fecha, CantidadServicios, FechaAdd, UserAdd) 
					SELECT @Id, @Id_TipoServicio, Id, @Desde2, CantidadChoferes + Auxiliar, @FechaAdd, @UserAdd
						FROM CodigosServicios 
							WHERE @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta 
							  AND UserDel IS NULL 
							  AND Id_TipoServicio = @Id_TipoServicio
							  AND Feriado = 1
			END	 
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
		
		SET @Columnas = RTRIM(LTRIM(SUBSTRING(@Columnas, CHARINDEX (',',@Columnas,0) + 1 , 500)))
		
		SET @Desde2 = @Desde
	END
	---------------------------------------------------	
	
	--CHOFERES Y AUXILIARES
	---------------------------------------------------	
	DECLARE Choferes_cur CURSOR FOR
		SELECT  Id, ISNULL(LaboralId_TipoServicio, 0)
			FROM Personal 
				WHERE LaboralId_UnidadNegocio = @Id_UnidadNegocio AND
					  (Id_Jerarquia = 1 OR Id_Jerarquia = 5) AND
					  UserDel IS NULL
	OPEN Choferes_cur

	FETCH NEXT FROM Choferes_cur INTO @IdPersonal, @Id_TipoServicioPersonal

	WHILE @@FETCH_STATUS = 0
	BEGIN
				
		SET @Desde2 = @Desde
		WHILE @Desde2 <= @Hasta
		BEGIN
			 
			INSERT INTO PlanificacionLargaDetalles (Id_Planificacion,Id_Personal,Id_TipoServicio,Fecha,Novedad,FechaAdd,UserAdd)
				VALUES (@Id, @IdPersonal, @Id_TipoServicioPersonal, @Desde2, '', @FechaAdd, @UserAdd)
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	
		FETCH NEXT FROM Choferes_cur INTO @IdPersonal, @Id_TipoServicioPersonal 
	END 
	
	CLOSE Choferes_cur 
	DEALLOCATE Choferes_cur 
	---------------------------------------------------	
	
	--PASAJE DE NOVEDADES
	---------------------------------------------------	
	UPDATE PlanificacionLargaDetalles
		SET Novedad = t.Descripcion, Id_Novedad = t.Id 
	FROM  
		(SELECT p.Fecha, p.Id_Personal, n.Descripcion, n.Id 
			FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
			INNER JOIN Personal pe ON p.Id_Personal = pe.Id AND pe.LaboralId_UnidadNegocio = @Id_UnidadNegocio
				WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
					  p.UserDel IS NULL) AS T
		INNER JOIN PlanificacionLargaDetalles q ON q.Fecha = t.Fecha AND
 				   Id_Planificacion = @Id AND 
				   q.Id_Personal = t.Id_Personal

	--DECLARE Nov_cur CURSOR FOR
	--	SELECT p.Fecha, p.Id_Personal, n.Descripcion, n.Id 
	--		FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
	--		INNER JOIN Personal pe ON p.Id_Personal = pe.Id AND pe.LaboralId_UnidadNegocio = @Id_UnidadNegocio
	--			WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
	--				  p.UserDel IS NULL
		
	--OPEN Nov_cur

	--FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdNovedad

	--WHILE @@FETCH_STATUS = 0
	--BEGIN
	--	UPDATE PlanificacionLargaDetalles 
	--		SET Novedad = @Novedad, Id_Novedad = @IdNovedad
	--			WHERE Id_Planificacion = @Id AND 
	--				  Fecha = @FechaNovedad AND
	--				  Id_Personal = @IdPersonal
	
	--	FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdNovedad
	--END
	
	--CLOSE Nov_cur 
	--DEALLOCATE Nov_cur 
	---------------------------------------------------	
	
	--CREACION DE SERVICIOS POR FECHAS
	---------------------------------------------------	
	DECLARE @Id_CodigoServicioVuelta INT
	DECLARE @Fecha DATETIME
	DECLARE @Dia INT
	--DECLARE @CantDia INT
	--DECLARE @I INT 

	DECLARE Nov_Serv CURSOR FOR
		SELECT  Id_CodigoServicioVuelta = csv.Id, 
				Fecha, 
				Dia = (SELECT MIN(Dia) 
					   FROM CodigosServiciosVueltasDetalle  
				       WHERE Id_CodigoServicioVuelta = csv.Id 
					   GROUP BY Id_CodigoServicioVuelta) 
				--CantDia = (SELECT COUNT(DISTINCT(Dia))
				--		   FROM CodigosServiciosVueltasDetalle  
				--           WHERE Id_CodigoServicioVuelta = csv.Id 
				--	       GROUP BY Id_CodigoServicioVuelta)
		FROM PlanificacionLargaServicios pls
		INNER JOIN CodigosServiciosVueltas csv on pls.Id_CodigoServicio = csv.Id_CodigoServicio
			WHERE pls.Id_Planificacion = @Id AND
				  pls.UserDel IS NULL AND
				  csv.UserDel IS NULL
		
	OPEN Nov_Serv

	FETCH NEXT FROM Nov_Serv INTO @Id_CodigoServicioVuelta, @Fecha, @Dia--, @CantDia

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--SET @I = 1
		
		--WHILE (@I <= @Dia)
		--BEGIN
		INSERT INTO CodigosServiciosFechas (Fecha,Id_Planificacion,Id_CodigoServicioVuelta,Id_Coche,Id_Personal1,Id_Personal2,Id_Personal3,Id_Estado,Comentario,Dia,FechaAdd,UserAdd) 
			VALUES (@Fecha, @Id, @Id_CodigoServicioVuelta, 0, 0, 0, 0, 1, '', @Dia, @FechaAdd, @UserAdd)
		
		--	SET @I = @I + 1
		--END
		
		FETCH NEXT FROM Nov_Serv INTO @Id_CodigoServicioVuelta, @Fecha, @Dia--, @CantDia
	END
	
	CLOSE Nov_Serv 
	DEALLOCATE Nov_Serv 
	---------------------------------------------------

	-- PLANIFICACION DE COCHES
	---------------------------------------------------
	SET @Desde2 = @Desde
	WHILE @Desde2 <= @Hasta
	BEGIN
		 
		INSERT INTO PlanificacionLargaDetallesCoches (Id_Planificacion, Id_Coche, Fecha, Id_TipoServicio, Id_CodigoServicio, Id_NovedadCoche, FechaAdd, UserAdd)
			SELECT @Id, Id, @Desde2, ISNULL(Id_TipoServicio, 0), 0, 0, @FechaAdd, @UserAdd
			FROM Coches
			WHERE UserDel IS NULL
			  AND Id_UnidadNegocio = @Id_UnidadNegocio
		
		SET @Desde2 = DATEADD(d, 1, @Desde2)
	END
	---------------------------------------------------

END
