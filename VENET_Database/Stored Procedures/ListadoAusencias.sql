
CREATE PROCEDURE [dbo].[ListadoAusencias]
	@Id_UN VARCHAR(100) = '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25',
	@FechaDesde DATETIME = '20150609',
	@FechaHasta DATETIME = '20150609',
	@Legajo Int = 0
	
AS
BEGIN
	DECLARE @SQLString NVARCHAR(MAX) = ''
		
	SET	@SQLString = N'
		SELECT 	Fecha = fecha,
				Legajo = legajo,
				Nombre = nombres,
				Tipo = tipo,
				Detalle = detalle,
				Id = [newID],
				UN = u.Descripcion,
				Categoria = j.Descripcion,
				Id_Personal = p.Id
			FROM [192.168.1.3].[SistAusencias].[dbo].[ListadoAusencias] l
			INNER JOIN Personal p ON l.legajo = p.LaboralLegajo
			INNER JOIN UnidadNegocios u ON p.LaboralId_UnidadNegocio = u.Id
			INNER JOIN PersonalJerarquias j ON p.Id_Jerarquia = j.id
				WHERE p.LaboralId_UnidadNegocio IN (' + @Id_UN + ') AND
					  (l.legajo = ' + CONVERT(VARCHAR, @Legajo) + ' OR ' + CONVERT(VARCHAR, @Legajo) + ' = 0) AND
					  l.fecha between ''' + RTRIM(CONVERT(CHAR, @FechaDesde, 111)) + ''' AND ''' + RTRIM(CONVERT(CHAR, @FechaHasta, 111)) + '''' 
print @SQLString
	--EXECUTE sp_executesql @SQLString
END
