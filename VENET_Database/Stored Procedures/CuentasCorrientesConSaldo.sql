CREATE PROCEDURE CuentasCorrientesConSaldo
	@Id_TipoEntidad INT = 0
AS
BEGIN

	SELECT * 
	FROM(
		SELECT Tipo_Entidad = CASE WHEN ecc.Id_TipoEntidad = 1 THEN 'Clientes'
						 		   WHEN ecc.Id_TipoEntidad = 2 THEN 'Proveedores'
						 		   WHEN ecc.Id_TipoEntidad = 3 THEN 'Prov. Financieros'
						 		   WHEN ecc.Id_TipoEntidad = 4 THEN 'Personal'
							  END,
			   ecc.Id_Entidad,
			   Entidad = CASE WHEN ecc.Id_TipoEntidad = 1 THEN (SELECT Nombre FROM Clientes WHERE Id = ecc.Id_Entidad)
							  WHEN ecc.Id_TipoEntidad = 2 THEN (SELECT Nombre FROM Proveedores WHERE Id = ecc.Id_Entidad) 
							  WHEN ecc.Id_TipoEntidad = 3 THEN (SELECT Nombre FROM ProvFinancieros WHERE Id = ecc.Id_Entidad) 
							  WHEN ecc.Id_TipoEntidad = 4 THEN (SELECT Apellido + ', ' + Nombre  FROM Personal WHERE Id = ecc.Id_Entidad) 
						 END,
			   ecc.Id_Especie, 
			   Especie = e.Descripcion, 
			   Saldo = SUM(Debito) - SUM(Credito)
		FROM EntidadesCtaCte ecc
		INNER JOIN Especies e ON ecc.Id_Especie = e.Id
		WHERE ecc.UserDel IS NULL
			  AND (ecc.Id_TipoEntidad = @Id_TipoEntidad OR @Id_TipoEntidad = 0)
		GROUP BY ecc.Id_TipoEntidad, ecc.Id_Entidad, ecc.Id_Especie, e.Descripcion
	) AS t
	WHERE Saldo <> 0

END  