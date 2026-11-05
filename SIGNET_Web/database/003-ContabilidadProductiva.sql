-- Opt-in. No contabiliza ni valua documentos historicos al instalar.
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.ContabilidadDocumentos', N'U') IS NULL
    THROW 50000, 'Instale primero las migraciones 001 y 002.', 1;
IF OBJECT_ID(N'dbo.ContabilidadOperativa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ContabilidadOperativa(
        Empresa int NOT NULL PRIMARY KEY REFERENCES dbo.Empresas(Id),
        Activa bit NOT NULL, Moneda int NOT NULL, CapturarCosto bit NOT NULL,
        DobleControl bit NOT NULL, Version int NOT NULL, Usuario int NOT NULL, Fecha datetime2 NOT NULL);
    CREATE TABLE dbo.ContabilidadPoliticas(
        Empresa int NOT NULL REFERENCES dbo.ContabilidadOperativa(Empresa),
        Operatoria int NOT NULL, Modo int NOT NULL CHECK(Modo BETWEEN 1 AND 3),
        UsuarioAutomatico int NULL, Desde datetime2 NOT NULL,
        CONSTRAINT PK_ContabilidadPoliticas PRIMARY KEY(Empresa,Operatoria));
    CREATE TABLE dbo.ContabilidadCola(
        Id int IDENTITY PRIMARY KEY, Empresa int NOT NULL REFERENCES dbo.Empresas(Id),
        Operatoria int NOT NULL, Documento int NOT NULL, Sucursal int NOT NULL, UsuarioOrigen int NULL,
        FechaOrigen datetime NOT NULL, Creado datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
        Estado int NOT NULL DEFAULT 1, Intentos int NOT NULL DEFAULT 0,
        ProximoIntento datetime2 NOT NULL DEFAULT SYSUTCDATETIME(), Error nvarchar(2000) NULL,
        Firma varchar(64) NULL, Simulacion nvarchar(max) NULL, Lote int NULL,
        CONSTRAINT UQ_ContabilidadCola_Origen UNIQUE(Empresa,Operatoria,Documento));
    CREATE INDEX IX_ContabilidadCola_Proceso ON dbo.ContabilidadCola(Empresa,Estado,ProximoIntento,Id);
    CREATE TABLE dbo.ContabilidadCostos(
        Venta int NOT NULL, Detalle int NOT NULL, Empresa int NOT NULL, MonedaBase int NOT NULL,
        Producto int NULL, Categoria int NULL, MonedaCosto int NULL,
        Cantidad decimal(28,8) NOT NULL, CantidadStock decimal(28,8) NULL,
        CostoUnitario decimal(28,8) NULL, Cotizacion decimal(28,8) NULL, CostoTotal decimal(28,2) NULL,
        Fecha datetime2 NOT NULL, Usuario int NULL, Error nvarchar(500) NULL,
        CONSTRAINT PK_ContabilidadCostos PRIMARY KEY(Venta,Detalle));
    CREATE TABLE dbo.ContabilidadAprobaciones(
        Empresa int NOT NULL, Operatoria int NOT NULL, Documento int NOT NULL,
        Firma varchar(64) NOT NULL, Usuario int NOT NULL, Fecha datetime2 NOT NULL,
        CONSTRAINT PK_ContabilidadAprobaciones PRIMARY KEY(Empresa,Operatoria,Documento));
    CREATE TABLE dbo.ContabilidadPeriodos(
        Empresa int NOT NULL REFERENCES dbo.Empresas(Id), Mes date NOT NULL,
        Cerrado bit NOT NULL, Usuario int NOT NULL, Fecha datetime2 NOT NULL, Motivo nvarchar(500) NOT NULL,
        CONSTRAINT PK_ContabilidadPeriodos PRIMARY KEY(Empresa,Mes));
    CREATE TABLE dbo.ContabilidadAuditoria(
        Id bigint IDENTITY PRIMARY KEY, Empresa int NOT NULL, Usuario int NOT NULL,
        Fecha datetime2 NOT NULL DEFAULT SYSUTCDATETIME(), Accion nvarchar(80) NOT NULL,
        Referencia nvarchar(100) NOT NULL, Motivo nvarchar(500) NOT NULL, Datos nvarchar(max) NULL);
    CREATE TABLE dbo.ContabilidadClasificacion(
        Empresa int NOT NULL REFERENCES dbo.Empresas(Id), Cuenta int NOT NULL REFERENCES dbo.CuentasContables(Id),
        Clase int NOT NULL CHECK(Clase BETWEEN 1 AND 5), Rubro nvarchar(100) NOT NULL,
        CONSTRAINT PK_ContabilidadClasificacion PRIMARY KEY(Empresa,Cuenta));
    CREATE TABLE dbo.ContabilidadCajas(
        Empresa int NOT NULL REFERENCES dbo.Empresas(Id), Caja int NOT NULL REFERENCES dbo.Cajas(Id),
        Cuenta int NOT NULL REFERENCES dbo.CuentasContables(Id),
        CONSTRAINT PK_ContabilidadCajas PRIMARY KEY(Empresa,Caja));
END;
INSERT dbo.SeguridadObjetos(Modulo,Formulario,Permiso)
SELECT 9,v.Formulario,v.Permiso FROM (VALUES
 ('ContabilidadBandeja','Ingresar'),('ContabilidadBandeja','Buscar'),('ContabilidadBandeja','Agregar'),
 ('ContabilidadAprobacion','Ingresar'),('ContabilidadAprobacion','Modificar'),
 ('ContabilidadAutomatizacion','Ingresar'),('ContabilidadAutomatizacion','Buscar'),('ContabilidadAutomatizacion','Modificar'),
 ('ContabilidadPeriodos','Ingresar'),('ContabilidadPeriodos','Buscar'),('ContabilidadPeriodos','Modificar'),('ContabilidadPeriodos','Reabrir'),
 ('ContabilidadConciliacion','Ingresar'),('ContabilidadConciliacion','Buscar'),('ContabilidadConciliacion','Imprimir')
) v(Formulario,Permiso)
WHERE NOT EXISTS(SELECT 1 FROM dbo.SeguridadObjetos s WHERE s.Modulo=9 AND s.Formulario=v.Formulario AND s.Permiso=v.Permiso);
GO
IF TYPE_ID(N'dbo.ContabilidadIds') IS NULL EXEC(N'CREATE TYPE dbo.ContabilidadIds AS TABLE(Id int PRIMARY KEY)');
GO
IF OBJECT_ID(N'dbo.ContabilidadOrigenes',N'V') IS NULL EXEC(N'CREATE VIEW dbo.ContabilidadOrigenes AS SELECT 1 AS Id');
GO
ALTER VIEW dbo.ContabilidadOrigenes AS
SELECT s.Id_Empresa Empresa,1 Operatoria,c.Id Documento,c.Id_Sucursal Sucursal,COALESCE(c.UserMod,c.UserAdd) Usuario,
 c.FechaLiquidacion Fecha,c.FechaAnulacion Anulacion,c.UserDel Baja,c.NroComprobante Descripcion,c.ImportePesos Importe
FROM dbo.ComprobantesVentas c JOIN dbo.Sucursales s ON s.Id=c.Id_Sucursal
WHERE c.FechaLiquidacion IS NOT NULL AND c.Id_TipoEntidad=1
UNION ALL
SELECT s.Id_Empresa,2,c.Id,c.Id_Sucursal,COALESCE(c.UserMod,c.UserAdd),c.FechaLiquidacion,c.FechaAnulacion,c.UserDel,c.NroComprobante,c.ImportePesos
FROM dbo.ComprobantesCompras c JOIN dbo.Sucursales s ON s.Id=c.Id_Sucursal
WHERE c.FechaLiquidacion IS NOT NULL AND c.Id_TipoEntidad=2
UNION ALL
SELECT s.Id_Empresa,3,c.Id,c.Id_Sucursal,COALESCE(c.UserMod,c.UserAdd),c.Fecha_Liquidacion,c.Fecha_Anulacion,c.UserDel,c.Concepto,
 CASE WHEN EXISTS(SELECT 1 FROM dbo.RecibosDetalle d WHERE d.Id_Recibo=c.Id AND d.UserDel IS NULL AND d.Cotizacion<=0)
 THEN NULL ELSE (SELECT SUM(d.Importe*d.Cotizacion) FROM dbo.RecibosDetalle d WHERE d.Id_Recibo=c.Id AND d.UserDel IS NULL) END
FROM dbo.Recibos c JOIN dbo.Sucursales s ON s.Id=c.Id_Sucursal
WHERE c.Fecha_Liquidacion IS NOT NULL AND c.TipoEntidad=1
UNION ALL
SELECT s.Id_Empresa,4,c.Id,c.Id_Sucursal,COALESCE(c.UserMod,c.UserAdd),c.Fecha_Liquidacion,c.Fecha_Anulacion,c.UserDel,c.Concepto,
 CASE WHEN EXISTS(SELECT 1 FROM dbo.OrdenesPagoDetalle d WHERE d.Id_OrdenPago=c.Id AND d.UserDel IS NULL AND d.Cotizacion<=0)
 THEN NULL ELSE (SELECT SUM(d.Importe*d.Cotizacion) FROM dbo.OrdenesPagoDetalle d WHERE d.Id_OrdenPago=c.Id AND d.UserDel IS NULL)
   + COALESCE((SELECT SUM(i.Importe) FROM dbo.OrdenesPagoImpuestos i WHERE i.Id_OrdenPago=c.Id AND i.UserDel IS NULL),0) END
FROM dbo.OrdenesPago c JOIN dbo.Sucursales s ON s.Id=c.Id_Sucursal
WHERE c.Fecha_Liquidacion IS NOT NULL AND c.TipoEntidad=2
UNION ALL
SELECT s.Id_Empresa,7,t.Id,c.Id_Sucursal,t.UserAdd,t.FechaAdd,NULL,t.UserDel,t.Descripcion,t.Importe*t.Cotizacion_Origen
FROM dbo.Transferencias t JOIN dbo.Cajas c ON c.Id=t.Id_Caja_Origen JOIN dbo.Sucursales s ON s.Id=c.Id_Sucursal;
GO
IF OBJECT_ID(N'dbo.ContabilidadEncolar',N'P') IS NULL EXEC(N'CREATE PROCEDURE dbo.ContabilidadEncolar AS RETURN');
GO
ALTER PROCEDURE dbo.ContabilidadEncolar @operatoria int, @ids dbo.ContabilidadIds READONLY AS
BEGIN
 SET NOCOUNT ON;
 INSERT dbo.ContabilidadCola(Empresa,Operatoria,Documento,Sucursal,UsuarioOrigen,FechaOrigen)
 SELECT o.Empresa,o.Operatoria,o.Documento,o.Sucursal,o.Usuario,o.Fecha
 FROM dbo.ContabilidadOrigenes o JOIN @ids ids ON ids.Id=o.Documento
 JOIN dbo.ContabilidadOperativa a ON a.Empresa=o.Empresa AND a.Activa=1
 JOIN dbo.ContabilidadPoliticas p ON p.Empresa=o.Empresa AND p.Operatoria=o.Operatoria
 WHERE o.Operatoria=@operatoria AND o.Fecha>=p.Desde AND o.Anulacion IS NULL AND o.Baja IS NULL
 AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadCola q WITH(UPDLOCK,HOLDLOCK)
    WHERE q.Empresa=o.Empresa AND q.Operatoria=o.Operatoria AND q.Documento=o.Documento);
END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_Venta',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_Venta ON dbo.ComprobantesVentas AFTER INSERT,UPDATE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_Venta ON dbo.ComprobantesVentas AFTER INSERT,UPDATE AS
BEGIN
 SET NOCOUNT ON;
 -- Valuacion estandar vigente al confirmar, nunca reconstruccion de documentos anteriores.
 INSERT dbo.ContabilidadCostos(Venta,Detalle,Empresa,MonedaBase,Producto,Categoria,MonedaCosto,Cantidad,CantidadStock,CostoUnitario,Cotizacion,CostoTotal,Fecha,Usuario,Error)
 SELECT i.Id,d.Id,s.Id_Empresa,a.Moneda,d.Id_Producto,p.Id_Categoria,p.Id_EspecieCosto,d.Cantidad,d.CantidadStock,
 p.ImporteCosto,e.Cotizacion,
 CASE WHEN p.ImporteCosto>=0 AND e.Cotizacion>0 THEN ROUND(p.ImporteCosto*e.Cotizacion*d.Cantidad,2) END,
 i.FechaLiquidacion,COALESCE(i.UserMod,i.UserAdd),
 CASE WHEN p.Id IS NULL THEN N'Producto no disponible'
      WHEN p.Id_EspecieCosto IS NULL OR e.Cotizacion IS NULL OR e.Cotizacion<=0 THEN N'Moneda/cotizacion de costo no valida'
      WHEN p.ImporteCosto<0 THEN N'Costo negativo' END
 FROM inserted i LEFT JOIN deleted old ON old.Id=i.Id
 JOIN dbo.Sucursales s ON s.Id=i.Id_Sucursal
 JOIN dbo.ContabilidadOperativa a ON a.Empresa=s.Id_Empresa AND a.Activa=1 AND a.CapturarCosto=1
 JOIN dbo.ComprobantesVentasDetalle d ON d.Id_ComprobanteVenta=i.Id AND d.UserDel IS NULL
 LEFT JOIN dbo.Productos p ON p.Id=d.Id_Producto AND p.UserDel IS NULL
 LEFT JOIN dbo.Especies e ON e.Id=p.Id_EspecieCosto AND e.UserDel IS NULL
 WHERE i.FechaLiquidacion IS NOT NULL AND old.FechaLiquidacion IS NULL AND i.FechaAnulacion IS NULL AND i.UserDel IS NULL
 AND i.Id_TipoEntidad=1
 AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadCostos x WHERE x.Venta=i.Id AND x.Detalle=d.Id);
 DECLARE @ids dbo.ContabilidadIds; INSERT @ids SELECT Id FROM inserted;
 EXEC dbo.ContabilidadEncolar 1,@ids;
 INSERT dbo.ContabilidadCola(Empresa,Operatoria,Documento,Sucursal,UsuarioOrigen,FechaOrigen)
 SELECT o.Empresa,13,o.Documento,o.Sucursal,o.Usuario,o.Fecha FROM dbo.ContabilidadOrigenes o
 JOIN inserted i ON i.Id=o.Documento AND o.Operatoria=1
 JOIN dbo.ContabilidadOperativa a ON a.Empresa=o.Empresa AND a.Activa=1 AND a.CapturarCosto=1
 JOIN dbo.ContabilidadPoliticas p ON p.Empresa=o.Empresa AND p.Operatoria=13 AND o.Fecha>=p.Desde
 WHERE o.Anulacion IS NULL AND o.Baja IS NULL AND EXISTS(SELECT 1 FROM dbo.ContabilidadCostos x WHERE x.Venta=o.Documento)
 AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadCola q WITH(UPDLOCK,HOLDLOCK) WHERE q.Empresa=o.Empresa AND q.Operatoria=13 AND q.Documento=o.Documento);
END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_Compra',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_Compra ON dbo.ComprobantesCompras AFTER INSERT,UPDATE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_Compra ON dbo.ComprobantesCompras AFTER INSERT,UPDATE AS
BEGIN SET NOCOUNT ON; DECLARE @ids dbo.ContabilidadIds; INSERT @ids SELECT Id FROM inserted; EXEC dbo.ContabilidadEncolar 2,@ids; END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_Recibo',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_Recibo ON dbo.Recibos AFTER INSERT,UPDATE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_Recibo ON dbo.Recibos AFTER INSERT,UPDATE AS
BEGIN SET NOCOUNT ON; DECLARE @ids dbo.ContabilidadIds; INSERT @ids SELECT Id FROM inserted; EXEC dbo.ContabilidadEncolar 3,@ids; END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_Pago',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_Pago ON dbo.OrdenesPago AFTER INSERT,UPDATE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_Pago ON dbo.OrdenesPago AFTER INSERT,UPDATE AS
BEGIN SET NOCOUNT ON; DECLARE @ids dbo.ContabilidadIds; INSERT @ids SELECT Id FROM inserted; EXEC dbo.ContabilidadEncolar 4,@ids; END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_Transferencia',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_Transferencia ON dbo.Transferencias AFTER INSERT,UPDATE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_Transferencia ON dbo.Transferencias AFTER INSERT,UPDATE AS
BEGIN SET NOCOUNT ON; DECLARE @ids dbo.ContabilidadIds; INSERT @ids SELECT Id FROM inserted; EXEC dbo.ContabilidadEncolar 7,@ids; END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_CostosInmutables',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_CostosInmutables ON dbo.ContabilidadCostos AFTER UPDATE,DELETE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_CostosInmutables ON dbo.ContabilidadCostos AFTER UPDATE,DELETE AS
BEGIN
 SET NOCOUNT ON;
 IF EXISTS(SELECT 1 FROM deleted) THROW 50001,'La captura contable de costos es inmutable; registre una valuacion complementaria.',1;
END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_AuditoriaInmutable',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_AuditoriaInmutable ON dbo.ContabilidadAuditoria AFTER UPDATE,DELETE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_AuditoriaInmutable ON dbo.ContabilidadAuditoria AFTER UPDATE,DELETE AS
BEGIN
 SET NOCOUNT ON;
 IF EXISTS(SELECT 1 FROM deleted) THROW 50002,'La auditoria contable es inmutable.',1;
END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_MesAsiento',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_MesAsiento ON dbo.Asientos AFTER INSERT,UPDATE,DELETE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_MesAsiento ON dbo.Asientos AFTER INSERT,UPDATE,DELETE AS
BEGIN
 SET NOCOUNT ON;
 IF EXISTS(SELECT 1 FROM (SELECT Id_Empresa,Fecha FROM inserted UNION SELECT Id_Empresa,Fecha FROM deleted) a
   JOIN dbo.ContabilidadPeriodos p ON p.Empresa=a.Id_Empresa AND p.Mes=DATEFROMPARTS(YEAR(a.Fecha),MONTH(a.Fecha),1) WHERE p.Cerrado=1)
   THROW 50003,'El mes del asiento esta bloqueado; requiere reapertura autorizada.',1;
END;
GO
IF OBJECT_ID(N'dbo.TR_Contabilidad_MesDetalle',N'TR') IS NULL EXEC(N'CREATE TRIGGER dbo.TR_Contabilidad_MesDetalle ON dbo.AsientosDetalle AFTER INSERT,UPDATE,DELETE AS RETURN');
GO
ALTER TRIGGER dbo.TR_Contabilidad_MesDetalle ON dbo.AsientosDetalle AFTER INSERT,UPDATE,DELETE AS
BEGIN
 SET NOCOUNT ON;
 IF EXISTS(SELECT 1 FROM (SELECT Id_Asiento FROM inserted UNION SELECT Id_Asiento FROM deleted) d
   JOIN dbo.Asientos a ON a.Id=d.Id_Asiento
   JOIN dbo.ContabilidadPeriodos p ON p.Empresa=a.Id_Empresa AND p.Mes=DATEFROMPARTS(YEAR(a.Fecha),MONTH(a.Fecha),1) WHERE p.Cerrado=1)
   THROW 50003,'El mes del detalle contable esta bloqueado; requiere reapertura autorizada.',1;
END;
GO
COMMIT;
