using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal static class IntegracionSql
{
    public static int Ejecutar(string[] args)
    {
        var servidor = args.Length > 1 ? args[1] : @"(localdb)\MSSQLLocalDB";
        var host = servidor.Split('\\')[0];
        if (host != "." && !host.Equals("localhost", StringComparison.OrdinalIgnoreCase)
            && !host.Equals("(local)", StringComparison.OrdinalIgnoreCase) && !host.Equals("(localdb)", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Solo se admite SQL local; nunca una base existente ni un servidor productivo.");
        var nombre = "SIGNET_Contabilidad_Test_" + Guid.NewGuid().ToString("N");
        var cadena = new SqlConnectionStringBuilder
        {
            DataSource = servidor,
            InitialCatalog = "master",
            IntegratedSecurity = true,
            ConnectTimeout = 5,
            Pooling = false
        }.ConnectionString;
        using (var master = new SqlConnection(cadena))
        {
            master.Open();
            Ejecutar(master, "CREATE DATABASE [" + nombre + "]");
            try
            {
                var test = new SqlConnectionStringBuilder(cadena) { InitialCatalog = nombre }.ConnectionString;
                using (var db = new SqlConnection(test))
                {
                    db.Open();
                    Ejecutar(db, @"CREATE TABLE Empresas(Id int PRIMARY KEY); INSERT Empresas VALUES(1);
                        CREATE TABLE EjerciciosContables(Id int PRIMARY KEY);
                        CREATE TABLE Asientos(Id int PRIMARY KEY,Id_Empresa int NOT NULL DEFAULT 1,Fecha datetime NOT NULL DEFAULT GETDATE());
                        CREATE TABLE AsientosDetalle(Id int PRIMARY KEY,Id_Asiento int);
                        CREATE TABLE Sucursales(Id int PRIMARY KEY,Id_Empresa int); INSERT Sucursales VALUES(1,1),(2,1);
                        CREATE TABLE CuentasContables(Id int PRIMARY KEY); INSERT CuentasContables VALUES(10),(20);
                        CREATE TABLE Cajas(Id int PRIMARY KEY,Id_Sucursal int); INSERT Cajas VALUES(1,1);
                        CREATE TABLE Especies(Id int PRIMARY KEY,UserDel int NULL,Cotizacion decimal(28,8)); INSERT Especies VALUES(1,NULL,1),(2,NULL,100);
                        CREATE TABLE Productos(Id int PRIMARY KEY,Id_Categoria int,Id_EspecieCosto int NULL,ImporteCosto decimal(28,8),UserDel int NULL);
                        INSERT Productos VALUES(1,7,2,3,NULL),(2,7,NULL,3,NULL);
                        CREATE TABLE ComprobantesVentas(Id int PRIMARY KEY,Id_Sucursal int,UserMod int NULL,UserAdd int NULL,UserDel int NULL,
                          FechaLiquidacion datetime NULL,FechaAnulacion datetime NULL,NroComprobante nvarchar(100),ImportePesos decimal(28,2),Id_TipoEntidad int);
                        CREATE TABLE ComprobantesCompras(Id int PRIMARY KEY,Id_Sucursal int,UserMod int NULL,UserAdd int NULL,UserDel int NULL,
                          FechaLiquidacion datetime NULL,FechaAnulacion datetime NULL,NroComprobante nvarchar(100),ImportePesos decimal(28,2),Id_TipoEntidad int);
                        CREATE TABLE ComprobantesVentasDetalle(Id int PRIMARY KEY,Id_ComprobanteVenta int,Id_Producto int,Cantidad decimal(28,8),CantidadStock decimal(28,8),UserDel int NULL);
                        CREATE TABLE Recibos(Id int PRIMARY KEY,Id_Sucursal int,UserMod int NULL,UserAdd int NULL,UserDel int NULL,
                          Fecha_Liquidacion datetime NULL,Fecha_Anulacion datetime NULL,Concepto nvarchar(100),Importe decimal(28,2),TipoEntidad int);
                        CREATE TABLE OrdenesPago(Id int PRIMARY KEY,Id_Sucursal int,UserMod int NULL,UserAdd int NULL,UserDel int NULL,
                          Fecha_Liquidacion datetime NULL,Fecha_Anulacion datetime NULL,Concepto nvarchar(100),Importe decimal(28,2),TipoEntidad int);
                        CREATE TABLE RecibosDetalle(Id int PRIMARY KEY,Id_Recibo int,Importe decimal(28,2),Cotizacion decimal(28,8),UserDel int NULL);
                        CREATE TABLE OrdenesPagoDetalle(Id int PRIMARY KEY,Id_OrdenPago int,Importe decimal(28,2),Cotizacion decimal(28,8),UserDel int NULL);
                        CREATE TABLE OrdenesPagoImpuestos(Id int PRIMARY KEY,Id_OrdenPago int,Importe decimal(28,2),UserDel int NULL);
                        CREATE TABLE Transferencias(Id int PRIMARY KEY,Id_Caja_Origen int,UserAdd int NULL,FechaAdd datetime,UserDel int NULL,
                          Descripcion nvarchar(100),Importe decimal(28,2),Cotizacion_Origen decimal(28,8));
                        CREATE TABLE SeguridadObjetos(Id int IDENTITY PRIMARY KEY,Modulo int,Formulario nvarchar(100),Permiso nvarchar(100));");
                    var scripts = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\database"));
                    foreach (var script in new[] { "001-Contabilidad.sql", "002-Contabilidad.sql", "003-ContabilidadProductiva.sql" })
                    {
                        var sql = File.ReadAllText(Path.Combine(scripts, script));
                        EjecutarScript(db, sql); EjecutarScript(db, sql);
                    }
                    Ejecutar(db, "INSERT Asientos(Id) VALUES(1),(2),(3),(4)");
                    ProbarProductiva(db);
                    using (var tx = db.BeginTransaction())
                    {
                        Ejecutar(db, @"INSERT ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,Datos) VALUES(1,10,8,GETDATE(),N'{}');
                            INSERT ContabilidadAsientos SELECT SCOPE_IDENTITY(),1;", tx);
                        tx.Rollback();
                    }
                    if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadLotes") != 0 || Escalar(db, "SELECT COUNT(*) FROM ContabilidadAsientos") != 0)
                        throw new Exception("Rollback parcial del lote.");
                    Ejecutar(db, @"INSERT ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,Datos) VALUES(1,10,8,GETDATE(),N'{}');
                        INSERT ContabilidadAsientos SELECT Id,1 FROM ContabilidadLotes;
                        INSERT ContabilidadAsientos SELECT Id,2 FROM ContabilidadLotes;");
                    DebeRechazar(db, "INSERT ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,Datos) VALUES(1,10,8,GETDATE(),N'{}')");
                    Ejecutar(db, @"INSERT ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,ReversionDe,Datos)
                        SELECT 1,10,8,GETDATE(),Id,N'{}' FROM ContabilidadLotes WHERE ReversionDe IS NULL;");
                    DebeRechazar(db, @"INSERT ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,ReversionDe,Datos)
                        SELECT 1,10,8,GETDATE(),Id,N'{}' FROM ContabilidadLotes WHERE ReversionDe IS NULL;");
                    var clave = Guid.NewGuid();
                    Ejecutar(db, "INSERT ContabilidadDocumentos(Empresa,Operatoria,Clave,Descripcion,Datos) VALUES(1,10,'" + clave + "',N'Prueba',N'{}')");
                    DebeRechazar(db, "INSERT ContabilidadDocumentos(Empresa,Operatoria,Clave,Descripcion,Datos) VALUES(1,10,'" + clave + "',N'Prueba',N'{}')");
                    using (var tx = db.BeginTransaction())
                    {
                        var sqlLock = "DECLARE @r int; EXEC @r=sys.sp_getapplock @Resource='SIGNET:Contabilidad:1',@LockMode='Exclusive',@LockOwner='Transaction',@LockTimeout=0; SELECT @r;";
                        if (Escalar(db, sqlLock, tx) < 0) throw new Exception("No adquirio bloqueo.");
                        var otro = Task.Run(() =>
                        {
                            using (var conexion = new SqlConnection(test))
                            {
                                conexion.Open();
                                using (var t = conexion.BeginTransaction()) return Escalar(conexion, sqlLock, t);
                            }
                        }).GetAwaiter().GetResult();
                        if (otro >= 0) throw new Exception("Dos conexiones adquirieron el mismo bloqueo exclusivo.");
                        tx.Rollback();
                    }
                    Console.WriteLine("PASS SQL: migraciones repetibles, rollback de lote/enlaces, unicidad de origen/reversion/documento y bloqueo entre conexiones.");
                }
            }
            finally { Ejecutar(master, "DROP DATABASE [" + nombre + "]"); }
        }
        return 0;
    }
    private static void Ejecutar(SqlConnection db, string sql, SqlTransaction tx = null)
    { using (var cmd = new SqlCommand(sql, db, tx)) cmd.ExecuteNonQuery(); }
    private static void EjecutarScript(SqlConnection db, string sql)
    {
        foreach (var lote in Regex.Split(sql, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
            if (!string.IsNullOrWhiteSpace(lote)) Ejecutar(db, lote);
    }
    private static void ProbarProductiva(SqlConnection db)
    {
        Ejecutar(db, @"INSERT ContabilidadOperativa VALUES(1,0,1,1,1,1,2,SYSUTCDATETIME());
            INSERT ContabilidadPoliticas VALUES(1,1,1,NULL,'2000-01-01'),(1,13,2,NULL,'2000-01-01');
            INSERT ComprobantesVentas VALUES(1,1,NULL,1,NULL,NULL,NULL,N'Factura 1',121,1),(2,1,NULL,1,NULL,NULL,NULL,N'Factura 2',121,1);
            INSERT ComprobantesVentasDetalle VALUES(1,1,1,2,2,NULL),(2,2,2,2,2,NULL);
            UPDATE ComprobantesVentas SET FechaLiquidacion=GETDATE() WHERE Id=1;");
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCola") != 0 || Escalar(db, "SELECT COUNT(*) FROM ContabilidadCostos") != 0)
            throw new Exception("Integracion inactiva escribe cola o costos.");
        Ejecutar(db, "UPDATE ContabilidadOperativa SET Activa=1; UPDATE ComprobantesVentas SET FechaLiquidacion=NULL WHERE Id=1;");
        using (var tx = db.BeginTransaction())
        {
            Ejecutar(db, "UPDATE ComprobantesVentas SET FechaLiquidacion=GETDATE() WHERE Id=1", tx);
            if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCola", tx) != 2) throw new Exception("No encola venta y costo atomicos.");
            tx.Rollback();
        }
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCostos") != 0) throw new Exception("Snapshot sobrevivio al rollback del origen.");
        Ejecutar(db, "UPDATE ComprobantesVentas SET FechaLiquidacion=GETDATE() WHERE Id=1; UPDATE ComprobantesVentas SET UserMod=1 WHERE Id=1;");
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCola WHERE Documento=1") != 2 ||
            Escalar(db, "SELECT COUNT(*) FROM ContabilidadCostos WHERE CostoTotal=600 AND MonedaCosto=2 AND Cotizacion=100 AND Cantidad=2") != 1)
            throw new Exception("Costo no coincide con cantidad y cotizacion capturadas; cola no idempotente.");
        Ejecutar(db, "UPDATE Productos SET ImporteCosto=99 WHERE Id=1;");
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCostos WHERE CostoTotal=600") != 1) throw new Exception("Cambio de costo revalua la historia.");
        Ejecutar(db, "UPDATE ComprobantesVentas SET FechaLiquidacion=GETDATE() WHERE Id=2;");
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadCostos WHERE Venta=2 AND CostoTotal IS NULL AND Error IS NOT NULL") != 1)
            throw new Exception("Costo sin moneda fue inventado.");
        DebeRechazarRegla(db, "UPDATE ContabilidadCostos SET CostoTotal=0 WHERE Venta=1", 50001);
        Ejecutar(db, "INSERT ContabilidadAuditoria(Empresa,Usuario,Accion,Referencia,Motivo) VALUES(1,2,N'Prueba',N'1',N'Prueba SQL');");
        DebeRechazarRegla(db, "DELETE ContabilidadAuditoria", 50002);
        Ejecutar(db, "INSERT ContabilidadPeriodos VALUES(1,'2026-05-01',1,2,SYSUTCDATETIME(),N'Cierre SQL');");
        DebeRechazarRegla(db, "INSERT Asientos(Id,Fecha) VALUES(5,'2026-05-02')", 50003);
        Ejecutar(db, "INSERT Asientos(Id,Fecha) VALUES(5,'2026-04-02'); INSERT AsientosDetalle VALUES(1,5);");
        DebeRechazarRegla(db, "UPDATE Asientos SET Fecha='2026-05-02' WHERE Id=5", 50003);
        Ejecutar(db, "INSERT ContabilidadPeriodos VALUES(1,'2026-04-01',1,2,SYSUTCDATETIME(),N'Cierre SQL');");
        DebeRechazarRegla(db, "DELETE AsientosDetalle WHERE Id=1", 50003);
        Ejecutar(db, "UPDATE ContabilidadPeriodos SET Cerrado=0 WHERE Mes='2026-04-01'; DELETE AsientosDetalle WHERE Id=1; DELETE Asientos WHERE Id=5;");
        Ejecutar(db, @"INSERT Recibos VALUES(1,1,NULL,1,NULL,GETDATE(),NULL,N'Recibo moneda extranjera',2,1);
            INSERT RecibosDetalle VALUES(1,1,2,100,NULL);
            INSERT OrdenesPago VALUES(1,1,NULL,1,NULL,GETDATE(),NULL,N'Pago moneda extranjera',2,2);
            INSERT OrdenesPagoDetalle VALUES(1,1,2,100,NULL); INSERT OrdenesPagoImpuestos VALUES(1,1,10,NULL);");
        if (Escalar(db, "SELECT COUNT(*) FROM ContabilidadOrigenes WHERE Operatoria=3 AND Importe=200") != 1 ||
            Escalar(db, "SELECT COUNT(*) FROM ContabilidadOrigenes WHERE Operatoria=4 AND Importe=210") != 1)
            throw new Exception("Conciliacion usa importe de cabecera sin cotizacion historica/retenciones.");
        Console.WriteLine("PASS SQL productiva: tres migraciones repetibles, opt-in, outbox/snapshot atomicos, idempotencia, costos inmutables, error sin moneda, auditoria y bloqueo mensual SQL.");
    }
    private static void DebeRechazarRegla(SqlConnection db, string sql, int numero)
    {
        try { Ejecutar(db, sql); }
        catch (SqlException e) when (e.Number == numero) { return; }
        throw new Exception("SQL no aplico la regla " + numero);
    }
    private static int Escalar(SqlConnection db, string sql, SqlTransaction tx = null)
    { using (var cmd = new SqlCommand(sql, db, tx)) return Convert.ToInt32(cmd.ExecuteScalar()); }
    private static void DebeRechazar(SqlConnection db, string sql)
    {
        try { Ejecutar(db, sql); }
        catch (SqlException e) when (e.Number == 2601 || e.Number == 2627) { return; }
        throw new Exception("SQL acepto un duplicado.");
    }
}
