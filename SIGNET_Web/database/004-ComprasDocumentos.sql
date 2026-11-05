-- Ejecutar manualmente en copia primero. No envia archivos, no confirma compras ni concede permisos.
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.ComprasDocumentos',N'U') IS NULL
BEGIN
 CREATE TABLE dbo.ComprasDocumentos(
  Id uniqueidentifier NOT NULL PRIMARY KEY, Usuario int NOT NULL, Sucursal int NOT NULL REFERENCES dbo.Sucursales(Id),
  Version int NOT NULL DEFAULT 1, Fecha datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
  Estado varchar(20) NOT NULL, Error nvarchar(500) NULL, Lectura nvarchar(max) NULL, Revision nvarchar(max) NULL,
  Compra int NULL REFERENCES dbo.ComprobantesCompras(Id), Firma varchar(64) NULL,
  CONSTRAINT CK_ComprasDocumentos_Estado CHECK(Estado IN('Cargado','Leido','Error','Guardado')));
 CREATE UNIQUE INDEX UX_ComprasDocumentos_Compra ON dbo.ComprasDocumentos(Compra) WHERE Compra IS NOT NULL;
 CREATE INDEX IX_ComprasDocumentos_Usuario ON dbo.ComprasDocumentos(Usuario,Fecha DESC);
 CREATE TABLE dbo.ComprasDocumentosArchivos(
  Documento uniqueidentifier NOT NULL REFERENCES dbo.ComprasDocumentos(Id), Orden int NOT NULL,
  Nombre nvarchar(180) NOT NULL, Mime varchar(30) NOT NULL, Hash varchar(64) NOT NULL, Datos varbinary(max) NOT NULL,
  CONSTRAINT PK_ComprasDocumentosArchivos PRIMARY KEY(Documento,Orden));
 CREATE TABLE dbo.ComprasDocumentosEquivalencias(
  Proveedor int NOT NULL REFERENCES dbo.Proveedores(Id), Codigo nvarchar(150) COLLATE Latin1_General_100_BIN2 NOT NULL,
  Producto int NOT NULL REFERENCES dbo.Productos(Id), Usuario int NOT NULL, Fecha datetime2 NOT NULL,
  CONSTRAINT PK_ComprasDocumentosEquivalencias PRIMARY KEY(Proveedor,Codigo));
 CREATE TABLE dbo.ComprasDocumentosAuditoria(
  Id bigint IDENTITY PRIMARY KEY, Documento uniqueidentifier NOT NULL REFERENCES dbo.ComprasDocumentos(Id),
  Usuario int NOT NULL, Fecha datetime2 NOT NULL DEFAULT SYSUTCDATETIME(), Accion nvarchar(60) NOT NULL, Datos nvarchar(max) NULL);
END;
EXEC(N'CREATE OR ALTER TRIGGER dbo.TR_ComprasDocumentosArchivos_Inmutables
 ON dbo.ComprasDocumentosArchivos AFTER UPDATE,DELETE AS
 BEGIN SET NOCOUNT ON; THROW 51000, ''Los originales documentales son inmutables.'', 1; END;');
EXEC(N'CREATE OR ALTER TRIGGER dbo.TR_ComprasDocumentosAuditoria_Inmutable
 ON dbo.ComprasDocumentosAuditoria AFTER UPDATE,DELETE AS
 BEGIN SET NOCOUNT ON; THROW 51000, ''La auditoria documental es de solo agregado.'', 1; END;');
COMMIT;
