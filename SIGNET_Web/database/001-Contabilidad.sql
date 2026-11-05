-- Ejecutar manualmente en la base de SIGNET, con respaldo previo.
-- No modifica ni contabiliza documentos existentes.
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID('dbo.ContabilidadConfiguraciones','U') IS NULL
CREATE TABLE dbo.ContabilidadConfiguraciones (
    Empresa int NOT NULL REFERENCES dbo.Empresas(Id),
    Version int NOT NULL CHECK(Version>0),
    Datos nvarchar(max) NOT NULL,
    Usuario int NOT NULL,
    Fecha datetime2 NOT NULL,
    CONSTRAINT PK_ContabilidadConfiguraciones PRIMARY KEY(Empresa,Version)
);
IF OBJECT_ID('dbo.ContabilidadLotes','U') IS NULL
BEGIN
    CREATE TABLE dbo.ContabilidadLotes (
        Id int IDENTITY NOT NULL PRIMARY KEY,
        Empresa int NOT NULL REFERENCES dbo.Empresas(Id),
        Operatoria int NOT NULL,
        Documento int NOT NULL CHECK(Documento>0),
        Fecha datetime NOT NULL,
        ReversionDe int NULL REFERENCES dbo.ContabilidadLotes(Id),
        Datos nvarchar(max) NOT NULL
    );
    CREATE UNIQUE INDEX UX_ContabilidadOrigen ON dbo.ContabilidadLotes(Empresa,Operatoria,Documento) WHERE ReversionDe IS NULL;
    CREATE UNIQUE INDEX UX_ContabilidadReversion ON dbo.ContabilidadLotes(ReversionDe) WHERE ReversionDe IS NOT NULL;
    CREATE INDEX IX_ContabilidadDiario ON dbo.ContabilidadLotes(Empresa,Fecha);
END;
IF OBJECT_ID('dbo.ContabilidadAsientos','U') IS NULL
CREATE TABLE dbo.ContabilidadAsientos (
    Lote int NOT NULL REFERENCES dbo.ContabilidadLotes(Id),
    Asiento int NOT NULL REFERENCES dbo.Asientos(Id),
    CONSTRAINT PK_ContabilidadAsientos PRIMARY KEY(Asiento)
);
-- Registrar objetos, sin asignar permisos a ningun grupo.
INSERT dbo.SeguridadObjetos(Modulo,Formulario,Permiso)
SELECT 9,v.Formulario,v.Permiso
FROM (VALUES
    ('ContabilidadConfiguracion','Ingresar'),('ContabilidadConfiguracion','Buscar'),('ContabilidadConfiguracion','Modificar'),
    ('ContabilidadRegistracion','Ingresar'),('ContabilidadRegistracion','Buscar'),('ContabilidadRegistracion','Agregar'),
    ('ContabilidadDiario','Ingresar'),('ContabilidadDiario','Buscar'),('ContabilidadDiario','Eliminar')
) v(Formulario,Permiso)
WHERE NOT EXISTS(SELECT 1 FROM dbo.SeguridadObjetos s WHERE s.Modulo=9 AND s.Formulario=v.Formulario AND s.Permiso=v.Permiso);
COMMIT;
