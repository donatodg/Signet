SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.ContabilidadLotes', N'U') IS NULL
    THROW 50000, 'Ejecute primero 001-Contabilidad.sql.', 1;
IF OBJECT_ID(N'dbo.ContabilidadDocumentos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ContabilidadDocumentos
    (
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Empresa int NOT NULL REFERENCES dbo.Empresas(Id),
        Operatoria int NOT NULL,
        Clave uniqueidentifier NOT NULL,
        Descripcion nvarchar(300) NOT NULL,
        EjercicioOrigen int NULL REFERENCES dbo.EjerciciosContables(Id),
        Datos nvarchar(max) NOT NULL,
        CONSTRAINT UQ_ContabilidadDocumentos_Clave UNIQUE(Empresa, Clave)
    );
    CREATE INDEX IX_ContabilidadDocumentos_Origen ON dbo.ContabilidadDocumentos(Empresa, Operatoria, EjercicioOrigen);
END;
COMMIT;
