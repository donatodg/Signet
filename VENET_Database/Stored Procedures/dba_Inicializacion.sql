CREATE PROCEDURE [dbo].[dba_Inicializacion] 
	 
AS
BEGIN
	Delete CentrosCostos
	Delete Clientes
	Delete Cuentas
	Delete Especies
	Delete EspeciesCtaCte
	Delete Proveedores
	Delete Recibos_Detalle
	Delete Recibos
	Delete Rendiciones
	Delete Rendiciones_Detalle
	Delete Tarifas
	Delete Turnos
	Delete Vales
	Delete dbo.Coches
	Delete dbo.Coches_Publicidad
	Delete dbo.Tarifas
	Delete dbo.Cuadros
	Delete dbo.Diagramas_Servicios
	Delete dbo.Diagramas_Fecha
	Delete dbo.Diagramas_Detalle
	Delete dbo.Diagramas
	Delete dbo.EstadosCiviles
	delete dbo.Feriados
	Delete dbo.Secciones
	Delete dbo.TipoServicios
	Delete dbo.Ramales
	Delete dbo.Lineas
	Delete dbo.Sucursales
	Delete dbo.Parametros
	Delete dbo.Provincia
	Delete dbo.PuntosdePaso
	Delete dbo.PuntosVenta
	Delete dbo.TipoComprobante
	Delete dbo.TipoDia
	Delete dbo.TipoDoc
	Delete dbo.PersonalTipos
	Delete dbo.PersonalJerarquias
	Delete dbo.Personal 
	Delete dbo.Empresas
	Delete dbo.Seguridad_Grupos_Objetos
	Delete dbo.Seguridad_Grupos
	Delete dbo.Seguridad_Objetos
	Delete dbo.Seguridad_Usuarios_Empresas
	Delete dbo.Seguridad_Usuarios
	Delete dbo.usuarios
	 	
	DBCC CHECKIDENT (CentrosCostos, RESEED,0)
	DBCC CHECKIDENT (Clientes, RESEED,0)
	DBCC CHECKIDENT (Coches, RESEED,0)
	DBCC CHECKIDENT (Coches_Publicidad, RESEED,0)
	DBCC CHECKIDENT (Cuadros, RESEED,0)
	DBCC CHECKIDENT (Cuentas, RESEED,0)
	DBCC CHECKIDENT (Diagramas, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Detalle, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Fecha, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Servicios, RESEED,0)
	DBCC CHECKIDENT (Empresas, RESEED,0)
	DBCC CHECKIDENT (Especies, RESEED,0)
	DBCC CHECKIDENT (EspeciesCtaCte, RESEED,0)
	DBCC CHECKIDENT (EstadosCiviles, RESEED,0)
	DBCC CHECKIDENT (Feriados, RESEED,0)
	DBCC CHECKIDENT (Lineas, RESEED,0)
	--DBCC CHECKIDENT (Parametros, RESEED,0)
	DBCC CHECKIDENT (Personal, RESEED,0)
	DBCC CHECKIDENT (PersonalJerarquias, RESEED,0)
	DBCC CHECKIDENT (PersonalTipos, RESEED,0)
	DBCC CHECKIDENT (Proveedores, RESEED,0)
	DBCC CHECKIDENT (Provincia, RESEED,0)
	DBCC CHECKIDENT (PuntosdePaso, RESEED,0)
	DBCC CHECKIDENT (PuntosVenta, RESEED,0)
	DBCC CHECKIDENT (Ramales, RESEED,0)
	DBCC CHECKIDENT (Recibos, RESEED,0)
	DBCC CHECKIDENT (Recibos_Detalle, RESEED,0)
	DBCC CHECKIDENT (Rendiciones, RESEED,0)
	DBCC CHECKIDENT (Rendiciones_Detalle, RESEED,0)
	DBCC CHECKIDENT (Secciones, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Grupos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Grupos_Objetos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Objetos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Usuarios, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Usuarios_Empresas, RESEED,0)
	DBCC CHECKIDENT (Sucursales, RESEED,0)
	DBCC CHECKIDENT (Tarifas, RESEED,0)
	DBCC CHECKIDENT (TipoDia, RESEED,0)
	DBCC CHECKIDENT (TipoDoc, RESEED,0)
	DBCC CHECKIDENT (TipoComprobante, RESEED,0)
	DBCC CHECKIDENT (TipoServicios, RESEED,0)
	DBCC CHECKIDENT (Turnos, RESEED,0)
	--DBCC CHECKIDENT (usuarios, RESEED,0)
	DBCC CHECKIDENT (Vales, RESEED,0)
	
 
	Insert Into CentrosCostos (Descripcion, FechaAdd, UserAdd) Values ('Default', GETDATE(), 0)
 
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Viaticos', GETDATE(), 0)
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Peajes', GETDATE(), 0)
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Combustibles', GETDATE(), 0)
	
	Insert Into EstadosCiviles (Descripcion) Values ('Soltero')
	Insert Into EstadosCiviles (Descripcion) Values ('Casado')
	Insert Into EstadosCiviles (Descripcion) Values ('Separado')
	Insert Into EstadosCiviles (Descripcion) Values ('Viudo')
	Insert Into EstadosCiviles (Descripcion) Values ('Concubinato')
	
	Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('ERSA URBANO S.A.','30-70778883-2', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('EMPRESA DE TRANSPORTES FLUVIALES DEL LITORAL S.A.','30-54660726-3', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('C.O. SOCIEDAD ANONIMA','30-70883486-2', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('EL TIGRE S.A.T.I.C.A.F','33-56197051-9', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('MATYSUD S.A.','33-70814131-9', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('TRANSPORTE SAN LORENZO SA','30-70843643-3', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('TRANSPORTE MARIANO MORENO S.R.L.','33-54637496-9', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('ERSA CHACO S.A.','30-71004921-8', GETDATE(), 0)
    Insert Into Empresas (Nombre, Cuit, FechaAdd, UserAdd) Values ('MICROOMNIBUS SAAVEDRA SATACI','30-54634060-7', GETDATE(), 0)

    Insert Into Especies (Descripcion, Sigla, Cotizacion, FechaAdd, UserAdd) Values ('Pesos','Pes', '1', GETDATE(), 0)

	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L120','L120','SANTIAGO DEL ESTERO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L110','L110','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L112A','L112A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L114A','L114A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L114B','L114B','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116A','L116A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116B','L116B','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116C','L116C','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L119','L119','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L120','L120','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L1','L1','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L15','L15','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L3','L3','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L9','L9','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'906','906','JN','JN', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (3,'108AB','108AB','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (3,'L108C','L108C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (4,'L103A','L103A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (4,'L103B','L103B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102A','L102A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102B','L102B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102C','L102C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L106A','L106A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L106B','L106B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCTCP','LCTCP','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCTR1','LCTR1','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCZMC','LCZMC','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104A','L104A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104B','L104B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104C','L104C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104D','L104D','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105A','L105A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105B','L105B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105C','L105C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L109','L109','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNAMG','PNAMG','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNATB','PNATB','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNAVL','PNAVL','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'1','1','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'10','10','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'1121','1121','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'15','15','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'22','22','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'5','5','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'6','6','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'12','12','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'14','14','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'2','2','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'20','20','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'3','3','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'4','4','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'7','7','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'8','8','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'9','9','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L101','L101','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106A','L106A','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106B','L106B','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106C','L106C','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L104','L104','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (9,'19','19','JN','JN', GETDATE(), 0)

	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Habil', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Sabado', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Domingo', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Feriados', GETDATE(), 0)
	
	Insert Into PersonalTipos (Descripcion, FechaAdd, UserAdd) Values ('Interno', GETDATE(), 0)
	Insert Into PersonalTipos (Descripcion, FechaAdd, UserAdd) Values ('Contratado', GETDATE(), 0)

	Insert Into PersonalJerarquias (Descripcion, FechaAdd, UserAdd) Values ('Conductor', GETDATE(), 0)

	Insert Into Provincia (Descripcion, Abreviatura) Values ('Buenos Aires','BA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Catamarca','CT')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Chaco','CC')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Chubut','CH')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Córdoba','CD')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Corrientes','CR')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Entre Ríos','BA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Formosa','FO')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Jujuy','JY')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('La Pampa','LP')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('La Rioja','LR')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Mendoza','MZ')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Misiones','MN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Neuquén','NQN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Río Negro','RN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Salta','SA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('San Juan','SJ')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('San Luis','SL')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santa Cruz','SC')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santa Fe','SF')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santiago del Estero','SE')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Tierra del Fuego, Antártida e Islas del Atlántico Sur','TF')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Tucumán','TM')
	
	Insert Into Sucursales (Descripcion, Id_Empresa, FechaAdd, UserAdd) Values ('Default', 1, GETDATE(), 0)
	
	Insert Into TipoDoc (Descripcion) Values ('DNI')
	Insert Into TipoDoc (Descripcion) Values ('CI')
	Insert Into TipoDoc (Descripcion) Values ('LE')
	Insert Into TipoDoc (Descripcion) Values ('LC')
	Insert Into TipoDoc (Descripcion) Values ('PAS')
	
	Insert Into TipoComprobante (Descripcion) Values ('Default')
	Insert Into TipoComprobante (Descripcion) Values ('Recibos')
	Insert Into TipoComprobante (Descripcion) Values ('Vales')
	Insert Into TipoComprobante (Descripcion) Values ('Rendiciones')
	
	Insert Into usuarios Values (1,'Admin','1234Ersa',1,0)
	Insert Into usuarios Values (2,'3','3',1,0)
	
END
