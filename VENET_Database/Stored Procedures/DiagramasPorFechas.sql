CREATE PROCEDURE [dbo].[DiagramasPorFechas] 
	@Id_TipoServicio INT,
	@FechaDesde DATETIME,
	@FechaHasta DATETIME
AS
BEGIN
	 
SELECT DISTINCT(df.Fecha),
	   Dia = DATENAME(dw, df.Fecha),
	   df.Id_Diagrama, 
	   Diagrama = Min(d.Descripcion),
	   Tipo_Dia = MIN(t.Descripcion)   
	FROM Diagramas_Fecha df
	 	INNER JOIN Diagramas d on d.Id = df.Id_Diagrama
		INNER JOIN TipoDia t on d.Id_TipoDia = t.Id
			WHERE d.Id_TipoServicio = @Id_TipoServicio
				  AND df.Fecha BETWEEN @FechaDesde AND @FechaHasta
				  AND df.UserDel IS NULL
	GROUP BY df.Fecha, df.Id_Diagrama
	ORDER BY df.Fecha
END
