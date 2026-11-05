CREATE TABLE [dbo].[Planificacion] (
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
    CONSTRAINT [PK_Planificacion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Planificacion_UnidadNegocios] FOREIGN KEY ([Id_UnidadNegocio]) REFERENCES [dbo].[UnidadNegocios] ([Id])
);


GO
CREATE TRIGGER [dbo].[PlanificacionFechasDiagrama]
   ON  [dbo].[Planificacion] 
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
	DECLARE @Id_Diagrama INT = 0
	DECLARE @Id INT = 0
	DECLARE @UserAdd INT 
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @Cant INT
	DECLARE @FechaNovedad DATE
	DECLARE @IdPersonal INT
	DECLARE @IdCoche INT
	DECLARE @Novedad Varchar(5)
	DECLARE @IdPlanificacionDetalle INT
	
	--ASIGNA DIAGRAMA
	---------------------------------------------------	
	SELECT @Id = Id, @Id_UnidadNegocio = Id_UnidadNegocio, @UserAdd = UserAdd, @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta FROM inserted
	
	SELECT @Columnas =  COALESCE(@Columnas + CAST(Id AS VARCHAR(12)) + ',', '') FROM
						(SELECT ts.Id 
						 FROM TipoServicios ts 
						 INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
						 INNER JOIN Lineas l ON r.Id_Linea = l.Id 
						 INNER JOIN UnidadNegocios c ON l.Id_UnidadNegocio = c.Id
						 WHERE c.Id = @Id_UnidadNegocio
							   AND c.UserDel IS NULL
							   AND r.UserDel IS NULL
							   AND l.UserDel IS NULL
							   AND ts.UserDel IS NULL
							   AND (l.MediaLargaDistancia IS NULL OR l.MediaLargaDistancia = 0)) AS t
	
	WHILE LEN(@Columnas) > 0
	BEGIN
		
		SELECT @Id_TipoServicio = SUBSTRING(@Columnas, 1, CHARINDEX(',',@Columnas,0) - 1)
		
		WHILE @Desde2 <= @Hasta AND @Id_TipoServicio > 0
		BEGIN
		 
			SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
								   FROM Feriado WHERE Fecha = @Desde2),1)
			IF @TipoDia = 1
			BEGIN
				IF (DATEPART(dw,@Desde2) = 1) --Domingo
					SET @TipoDia = 3
				IF (DATEPART(dw,@Desde2) = 7) --Sabado
					SET @TipoDia = 2
			END
				
			SET @Id_Diagrama = ISNULL((SELECT Top 1 Id
									   FROM Diagramas 
									   WHERE Id_TipoDia = @TipoDia 
								 			 AND Id_TipoServicio = @Id_TipoServicio 
											 AND @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta
											 And UserDel IS NULL
									   ORDER BY Id DESC),0) 
			
			SELECT @Cant = COUNT(Id) FROM Diagramas_Servicios WHERE Id_Diagrama = @Id_Diagrama AND UserDel IS NULL
			
			INSERT INTO PlanificacionServicios (Id_Planificacion, Id_TipoServicio, Id_Diagrama, Fecha, CantidadServicios, FechaAdd, UserAdd) 
				Values (@Id, @Id_TipoServicio, @Id_Diagrama, @Desde2, @Cant, GETDATE(), @UserAdd)
			 
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
		
		SET @Columnas = RTRIM(LTRIM(SUBSTRING(@Columnas, CHARINDEX (',',@Columnas,0) + 1 ,500)))
		
		SET @Desde2 = @Desde
	END
	---------------------------------------------------	
	
	--GRABA TITULARES DE COCHES
	---------------------------------------------------	
	DECLARE Titulares_cur CURSOR FOR
		SELECT cp.Id_Personal, c.Id coche, c.Id_TipoServicio
			FROM Coches c 
			INNER JOIN Coches_Personal cp ON c.Id = cp.Id_Coche
			INNER JOIN Personal pe on cp.Id_Personal = pe.Id
			WHERE pe.Id_Jerarquia = 1 AND
				  c.UserDel IS NULL AND
				  pe.UserDel IS NULL AND
				  cp.UserDel IS NULL AND
				  c.Id_TipoServicio in (SELECT ts.Id 
						 FROM TipoServicios ts 
						 INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
						 INNER JOIN Lineas l ON r.Id_Linea = l.Id 
						 INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
						 WHERE u.Id = @Id_UnidadNegocio
							   AND u.UserDel IS NULL
							   AND r.UserDel IS NULL
							   AND l.UserDel IS NULL
							   AND ts.UserDel IS NULL
							   AND (l.MediaLargaDistancia IS NULL OR l.MediaLargaDistancia = 0)) 
	OPEN Titulares_cur

	FETCH NEXT FROM Titulares_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
				
		SET @Desde2 = @Desde
		WHILE @Desde2 <= @Hasta
		BEGIN
			 
			INSERT INTO PlanificacionDetalles (Id_Planificacion,Id_Personal,Id_Coche,Id_TipoServicio,Fecha,Novedad,FechaAdd,UserAdd)
				VALUES (@Id, @IdPersonal, @IdCoche, @Id_TipoServicio, @Desde2, '', GETDATE(), @UserAdd)
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	
		FETCH NEXT FROM Titulares_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio
	END 
	
	CLOSE Titulares_cur 
	DEALLOCATE Titulares_cur 
	---------------------------------------------------	
		 
	--SUPLENTES
	---------------------------------------------------	
	DECLARE Suplentes_cur CURSOR FOR
		SELECT  Id, 0, 0
			FROM Personal 
				WHERE LaboralId_UnidadNegocio = @Id_UnidadNegocio AND
					  Id_Jerarquia = 1 AND
					  Id NOT IN (SELECT DISTINCT(Id_Personal) FROM PlanificacionDetalles WHERE Id_Planificacion = @Id) AND
					  UserDel IS NULL
	OPEN Suplentes_cur

	FETCH NEXT FROM Suplentes_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
				
		SET @Desde2 = @Desde
		WHILE @Desde2 <= @Hasta
		BEGIN
			 
			INSERT INTO PlanificacionDetalles (Id_Planificacion,Id_Personal,Id_Coche,Id_TipoServicio,Fecha, Novedad,FechaAdd,UserAdd)
				VALUES (@Id, @IdPersonal, @IdCoche, @Id_TipoServicio, @Desde2, '', GETDATE(), @UserAdd)
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	
		FETCH NEXT FROM Suplentes_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio
	END 
	
	CLOSE Suplentes_cur 
	DEALLOCATE Suplentes_cur 
	---------------------------------------------------	
	
	--PASAJE DE NOVEDADES
	---------------------------------------------------	
	UPDATE PlanificacionDetalles
		SET Novedad = t.Descripcion, Id_Novedad = t.Id 
	FROM  
		(SELECT p.Fecha, p.Id_Personal, n.Descripcion, n.Id 
			FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
			INNER JOIN Personal pe ON p.Id_Personal = pe.Id AND pe.LaboralId_UnidadNegocio = @Id_UnidadNegocio
				WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
					  p.UserDel IS NULL) AS T
		INNER JOIN PlanificacionDetalles q ON q.Fecha = t.Fecha AND
 				   Id_Planificacion = @Id AND 
				   q.Id_Personal = t.Id_Personal

	--DECLARE Nov_cur CURSOR FOR
	--	SELECT p.Fecha, p.Id_Personal, n.Descripcion 
	--		FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
	--		INNER JOIN Personal pe ON p.Id_Personal = pe.Id AND pe.LaboralId_UnidadNegocio = @Id_UnidadNegocio
	--			WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
	--				  P.UserDel IS NULL
		
	--OPEN Nov_cur

	--FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad

	--WHILE @@FETCH_STATUS = 0
	--BEGIN
	--	UPDATE PlanificacionDetalles SET Novedad = @Novedad
	--		WHERE Id_Planificacion = @Id AND 
	--			  Fecha = @FechaNovedad AND
	--			  Id_Personal = @IdPersonal
	
	--	FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad
	--END
	
	--CLOSE Nov_cur 
	--DEALLOCATE Nov_cur 
	---------------------------------------------------	
	
	--INICIALIZA PLANIFICACIONDETALLESCOCHES
	---------------------------------------------------	
	EXEC PlanificacionDetallesCochesDiaria @Id
	---------------------------------------------------	
	
END