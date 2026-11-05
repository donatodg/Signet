using System;
using System.Data.SqlClient;
using System.IO;

internal static class IntegracionSql
{
    public static int Ejecutar(string[] args)
    {
        var servidor = args.Length > 1 ? args[1] : @"(localdb)\MSSQLLocalDB";
        var host = servidor.Split('\\')[0];
        if (host != "." && !host.Equals("localhost", StringComparison.OrdinalIgnoreCase)
            && !host.Equals("(local)", StringComparison.OrdinalIgnoreCase) && !host.Equals("(localdb)", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Solo SQL local, en una base temporal nueva; nunca una base existente.");
        var nombre = "SIGNET_ComprasDocumentos_Test_" + Guid.NewGuid().ToString("N");
        var cadena = new SqlConnectionStringBuilder { DataSource = servidor, InitialCatalog = "master", IntegratedSecurity = true, ConnectTimeout = 5, Pooling = false };
        using (var master = new SqlConnection(cadena.ConnectionString))
        {
            master.Open(); Ejecutar(master, "CREATE DATABASE [" + nombre + "]");
            try
            {
                cadena.InitialCatalog = nombre;
                using (var db = new SqlConnection(cadena.ConnectionString))
                {
                    db.Open();
                    Ejecutar(db, @"CREATE TABLE Sucursales(Id int PRIMARY KEY); INSERT Sucursales VALUES(1);
                        CREATE TABLE ComprobantesCompras(Id int PRIMARY KEY); INSERT ComprobantesCompras VALUES(10);
                        CREATE TABLE Productos(Id int PRIMARY KEY); INSERT Productos VALUES(3);
                        CREATE TABLE Proveedores(Id int PRIMARY KEY); INSERT Proveedores VALUES(2);");
#if NATIVE
                    var archivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\..\database\004-ComprasDocumentos.sql"));
#else
                    var archivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\database\004-ComprasDocumentos.sql"));
#endif
                    var script = File.ReadAllText(archivo); Ejecutar(db, script); Ejecutar(db, script);
                    var id = Guid.NewGuid().ToString();
                    Ejecutar(db, "INSERT ComprasDocumentos(Id,Usuario,Sucursal,Estado) VALUES('" + id + "',1,1,'Cargado')");
                    Ejecutar(db, "INSERT ComprasDocumentosArchivos VALUES('" + id + "',0,N'prueba.png','image/png','" + new string('a', 64) + "',0x1234)");
                    Ejecutar(db, "INSERT ComprasDocumentosAuditoria(Documento,Usuario,Accion) VALUES('" + id + "',1,N'Prueba')");
                    Rechaza(db, "UPDATE ComprasDocumentosArchivos SET Nombre=N'otro.png'");
                    Rechaza(db, "DELETE ComprasDocumentosArchivos");
                    Rechaza(db, "UPDATE ComprasDocumentosAuditoria SET Accion=N'otra'");
                    Rechaza(db, "DELETE ComprasDocumentosAuditoria");
                    using (var tx = db.BeginTransaction())
                    {
                        Ejecutar(db, "UPDATE ComprasDocumentos SET Compra=10,Estado='Guardado',Version=Version+1 WHERE Id='" + id + "'", tx);
                        Ejecutar(db, "INSERT ComprasDocumentosEquivalencias VALUES(2,N'ABC',3,1,SYSUTCDATETIME())", tx);
                        tx.Rollback();
                    }
                    Afirmar(Escalar(db, "SELECT COUNT(*) FROM ComprasDocumentos WHERE Compra IS NOT NULL") == 0, "Rollback de enlace");
                    Afirmar(Escalar(db, "SELECT COUNT(*) FROM ComprasDocumentosEquivalencias") == 0, "Rollback de equivalencia");
                    Ejecutar(db, "UPDATE ComprasDocumentos SET Compra=10,Estado='Guardado' WHERE Id='" + id + "'");
                    Rechaza(db, "INSERT ComprasDocumentos(Id,Usuario,Sucursal,Estado,Compra) VALUES(NEWID(),1,1,'Guardado',10)");
                    Rechaza(db, "INSERT ComprasDocumentosEquivalencias VALUES(2,N'ABC',999,1,SYSUTCDATETIME())");
                    Console.WriteLine("PASS SQL documental: migracion repetible, originales/auditoria inmutables, rollback, FK y una importacion por compra. No sustituye ensayo del BL completo en copia.");
                }
            }
            finally { Ejecutar(master, "DROP DATABASE [" + nombre + "]"); }
        }
        return 0;
    }
    private static void Afirmar(bool b, string texto) { if (!b) throw new Exception(texto); }
    private static void Ejecutar(SqlConnection db, string sql, SqlTransaction tx = null)
    { using (var c = new SqlCommand(sql, db, tx)) c.ExecuteNonQuery(); }
    private static int Escalar(SqlConnection db, string sql)
    { using (var c = new SqlCommand(sql, db)) return Convert.ToInt32(c.ExecuteScalar()); }
    private static void Rechaza(SqlConnection db, string sql)
    { try { Ejecutar(db, sql); } catch (SqlException) { return; } throw new Exception("SQL debio rechazar: " + sql); }
}
