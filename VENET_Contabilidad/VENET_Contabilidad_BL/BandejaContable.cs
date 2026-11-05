using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public sealed partial class ContabilidadService
    {
        private static System.Data.Common.DbDataReader LeerConSucursales(System.Data.Common.DbCommand cmd, List<int> sucursales)
        {
            AgregarSucursales(cmd, sucursales);
            return cmd.ExecuteReader();
        }
        private static void AgregarSucursales(System.Data.Common.DbCommand cmd, List<int> sucursales)
        {
            if (sucursales == null || sucursales.Count > 1000 || sucursales.Any(s => s <= 0))
                throw new ValidationException("Sucursales autorizadas invalidas.");
            var ids = new DataTable(); ids.Columns.Add("Id", typeof(int));
            foreach (var id in sucursales.Distinct()) ids.Rows.Add(id);
            cmd.Parameters.Add(new SqlParameter("@sucursales", SqlDbType.Structured) { TypeName = "dbo.ContabilidadIds", Value = ids });
        }
        public List<PendienteContable> Bandeja(int empresa, DateTime desde, DateTime hasta, List<int> sucursales)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            {
                ExigirInstalacionProductiva(db);
                using (var cmd = Comando(db, null, @"SELECT TOP(501) q.Id,q.Operatoria,q.Documento,q.Sucursal,q.UsuarioOrigen,q.FechaOrigen,
                    q.Estado,q.Intentos,q.Error,q.Firma,COALESCE(q.Lote,l.Id),o.Anulacion,o.Baja,COALESCE(o.Descripcion,d.Descripcion),
                    CASE WHEN a.Firma=q.Firma THEN 1 ELSE 0 END
                    FROM dbo.ContabilidadCola q
                    LEFT JOIN dbo.ContabilidadOrigenes o ON o.Empresa=q.Empresa AND o.Operatoria=CASE WHEN q.Operatoria=13 THEN 1 ELSE q.Operatoria END AND o.Documento=q.Documento
                    LEFT JOIN dbo.ContabilidadLotes l ON l.Empresa=q.Empresa AND l.Operatoria=q.Operatoria AND l.Documento=q.Documento AND l.ReversionDe IS NULL
                    LEFT JOIN dbo.ContabilidadAprobaciones a ON a.Empresa=q.Empresa AND a.Operatoria=q.Operatoria AND a.Documento=q.Documento
                    LEFT JOIN dbo.ContabilidadDocumentos d ON d.Empresa=q.Empresa AND d.Operatoria=q.Operatoria AND d.Id=q.Documento
                    WHERE q.Empresa=@empresa AND q.Sucursal IN(SELECT Id FROM @sucursales) AND q.FechaOrigen>=@desde AND q.FechaOrigen<@hasta ORDER BY q.Id DESC",
                    ("empresa", empresa), ("desde", desde.Date), ("hasta", hasta.Date.AddDays(1))))
                using (var r = LeerConSucursales(cmd, sucursales))
                {
                    var result = new List<PendienteContable>();
                    while (r.Read()) result.Add(new PendienteContable
                    {
                        Id = r.GetInt32(0),
                        Empresa = empresa,
                        Operatoria = (OperatoriaContable)r.GetInt32(1),
                        Documento = r.GetInt32(2),
                        Sucursal = r.GetInt32(3),
                        UsuarioOrigen = r.IsDBNull(4) ? (int?)null : r.GetInt32(4),
                        Fecha = r.GetDateTime(5),
                        Estado = (EstadoCola)r.GetInt32(6),
                        Intentos = r.GetInt32(7),
                        Error = r.IsDBNull(8) ? null : r.GetString(8),
                        Firma = r.IsDBNull(9) ? null : r.GetString(9),
                        Lote = r.IsDBNull(10) ? (int?)null : r.GetInt32(10),
                        Anulado = !r.IsDBNull(11) || !r.IsDBNull(12),
                        Descripcion = r.IsDBNull(13) ? null : r.GetString(13),
                        Aprobado = r.GetInt32(14) == 1
                    });
                    if (result.Count > 500) throw new ValidationException("Mas de 500 pendientes. Reduzca el periodo.");
                    return result;
                }
            }
        }
        public int SincronizarBandeja(int empresa, DateTime desde, DateTime hasta, int usuario, List<int> sucursales)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa);
                ExigirUsuario(db, tx, usuario, "ContabilidadBandeja", "Agregar");
                using (var cmd = Comando(db, tx, @"SELECT COUNT(*) FROM dbo.ContabilidadOrigenes o WHERE o.Empresa=@empresa AND o.Sucursal IN(SELECT Id FROM @sucursales) AND o.Fecha>=@desde AND o.Fecha<@hasta
                    AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadCola q WHERE q.Empresa=o.Empresa AND q.Operatoria=o.Operatoria AND q.Documento=o.Documento)",
                    ("empresa", empresa), ("desde", desde.Date), ("hasta", hasta.Date.AddDays(1))))
                {
                    AgregarSucursales(cmd, sucursales);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 500) throw new ValidationException("Mas de 500 origenes nuevos; reduzca el periodo.");
                }
                // Solo descubre origenes: no valua ni automatiza retroactivamente.
                int cantidad;
                using (var cmd = Comando(db, tx, @"INSERT dbo.ContabilidadCola(Empresa,Operatoria,Documento,Sucursal,UsuarioOrigen,FechaOrigen)
                    SELECT o.Empresa,o.Operatoria,o.Documento,o.Sucursal,o.Usuario,o.Fecha FROM dbo.ContabilidadOrigenes o
                    WHERE o.Empresa=@empresa AND o.Sucursal IN(SELECT Id FROM @sucursales) AND o.Fecha>=@desde AND o.Fecha<@hasta
                    AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadCola q WHERE q.Empresa=o.Empresa AND q.Operatoria=o.Operatoria AND q.Documento=o.Documento)",
                    ("empresa", empresa), ("desde", desde.Date), ("hasta", hasta.Date.AddDays(1))))
                { AgregarSucursales(cmd, sucursales); cantidad = cmd.ExecuteNonQuery(); }
                Auditar(db, tx, empresa, usuario, "Descubrir pendientes", desde.ToString("yyyy-MM-dd"), "Descubrimiento manual sin contabilizacion retroactiva", new { hasta, cantidad });
                tx.Commit(); return cantidad;
            }
        }
        public List<RevisionLote> RevisarLote(int empresa, List<RevisionLote> solicitudes)
        {
            ValidarSeleccion(solicitudes);
            var result = new List<RevisionLote>();
            foreach (var s in solicitudes)
            {
                var r = new RevisionLote { Operatoria = s.Operatoria, Documento = s.Documento };
                try { r.Simulacion = Simular(empresa, s.Operatoria, s.Documento); }
                catch (ValidationException e) { r.Error = e.Message; }
                result.Add(r);
            }
            return result;
        }
        public static void ValidarSeleccion(List<RevisionLote> filas)
        {
            if (filas == null || filas.Count == 0 || filas.Count > 50 || filas.Any(f => f == null || f.Documento <= 0
                || !Enum.IsDefined(typeof(OperatoriaContable), f.Operatoria))
                || filas.GroupBy(f => new { f.Operatoria, f.Documento }).Any(g => g.Count() > 1))
                throw new ValidationException("Seleccione entre 1 y 50 documentos distintos.");
        }
        public List<RegistroContable> RegistrarLote(int empresa, List<RevisionLote> solicitudes, int usuario)
        {
            ValidarSeleccion(solicitudes);
            if (solicitudes.Any(s => s.Simulacion == null || string.IsNullOrWhiteSpace(s.Simulacion.Firma)))
                throw new ValidationException("Revise todos los documentos antes de registrar.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa);
                ExigirUsuario(db, tx, usuario, "ContabilidadBandeja", "Agregar");
                var result = new List<RegistroContable>();
                foreach (var s in solicitudes.OrderBy(s => s.Operatoria).ThenBy(s => s.Documento))
                {
                    var r = RegistrarDentro(db, tx, empresa, s.Operatoria, s.Documento, s.Simulacion.Firma, usuario, false);
                    result.Add(r); MarcarRegistrado(db, tx, r);
                }
                Auditar(db, tx, empresa, usuario, "Registrar lote revisado", result.Count + " documentos", "Revision explicita de documentos", result.Select(r => r.Id));
                tx.Commit(); return result;
            }
        }
        private static int? CreadorOrigen(GestionContext db, DbContextTransaction tx, int empresa, OperatoriaContable op, int documento)
        {
            if (Complementario(op))
            {
                using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadDocumentos WHERE Empresa=@empresa AND Operatoria=@op AND Id=@doc",
                    ("empresa", empresa), ("op", (int)op), ("doc", documento)))
                {
                    var json = cmd.ExecuteScalar() as string;
                    return json == null ? (int?)null : JsonConvert.DeserializeObject<DocumentoContable>(json).Usuario;
                }
            }
            using (var cmd = Comando(db, tx, @"SELECT Usuario FROM dbo.ContabilidadOrigenes WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc",
                ("empresa", empresa), ("op", op == OperatoriaContable.CostoVentaAutomatico ? 1 : (int)op), ("doc", documento)))
            {
                var valor = cmd.ExecuteScalar(); return valor == null || valor == DBNull.Value ? (int?)null : Convert.ToInt32(valor);
            }
        }
        public static void ValidarSeparacion(int? creador, int aprobador)
        {
            if (!creador.HasValue || creador <= 0 || aprobador <= 0 || creador == aprobador)
                throw new ValidationException("La aprobacion requiere otro usuario distinto del responsable del origen.");
        }
        public void Aprobar(int empresa, OperatoriaContable op, int documento, string firma, string motivo, int usuario)
        {
            ValidarMotivo(motivo);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa);
                ExigirUsuario(db, tx, usuario, "ContabilidadAprobacion", "Modificar");
                ValidarSeparacion(CreadorOrigen(db, tx, empresa, op, documento), usuario);
                var config = LeerConfiguracion(db, tx, empresa) ?? throw new ValidationException("Falta configuracion.");
                var h = ObtenerHecho(db, tx, empresa, op, documento, config.MonedaBase);
                Ejercicio(db, empresa, h.Fecha);
                var sim = MotorContable.Simular(config, h, Cuentas(db));
                if (sim.Firma != firma) throw new ValidationException("La revision cambio. Simule de nuevo antes de aprobar.");
                Ejecutar(db, tx, @"DELETE dbo.ContabilidadAprobaciones WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc;
                    INSERT dbo.ContabilidadAprobaciones VALUES(@empresa,@op,@doc,@firma,@usuario,SYSUTCDATETIME())",
                    ("empresa", empresa), ("op", (int)op), ("doc", documento), ("firma", firma), ("usuario", usuario));
                Auditar(db, tx, empresa, usuario, "Aprobar simulacion", op + ":" + documento, motivo, new { firma });
                Ejecutar(db, tx, "UPDATE dbo.ContabilidadCola SET Firma=@firma,Simulacion=@sim WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc AND Lote IS NULL",
                    ("firma", firma), ("sim", JsonConvert.SerializeObject(sim)), ("empresa", empresa), ("op", (int)op), ("doc", documento));
                tx.Commit();
            }
        }
        private static void VerificarAprobacion(GestionContext db, DbContextTransaction tx, SimulacionContable sim, int usuario, bool automatico)
        {
            if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadOperativa','U') IS NULL THEN 0 ELSE 1 END").Single() == 0) return;
            var operativa = LeerOperativa(db, tx, sim.Hecho.Empresa);
            if (automatico)
            {
                ValidarSeparacion(CreadorOrigen(db, tx, sim.Hecho.Empresa, sim.Hecho.Operatoria, sim.Hecho.Documento), usuario);
                ExigirUsuario(db, tx, usuario, "ContabilidadAutomatizacion", "Modificar");
                Auditar(db, tx, sim.Hecho.Empresa, usuario, "Aprobacion automatica autorizada", sim.Hecho.Operatoria + ":" + sim.Hecho.Documento,
                    "Politica automatica previamente autorizada; motor tipado y balance validado", new { sim.Firma });
                return;
            }
            if (!operativa.DobleControl && !Complementario(sim.Hecho.Operatoria)) return;
            using (var cmd = Comando(db, tx, "SELECT Firma,Usuario FROM dbo.ContabilidadAprobaciones WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc",
                ("empresa", sim.Hecho.Empresa), ("op", (int)sim.Hecho.Operatoria), ("doc", sim.Hecho.Documento)))
            using (var r = cmd.ExecuteReader())
            {
                if (!r.Read() || r.GetString(0) != sim.Firma) throw new ValidationException("Falta aprobacion independiente de esta revision.");
                var aprobador = r.GetInt32(1);
                r.Close();
                ValidarSeparacion(CreadorOrigen(db, tx, sim.Hecho.Empresa, sim.Hecho.Operatoria, sim.Hecho.Documento), aprobador);
                ExigirUsuario(db, tx, aprobador, "ContabilidadAprobacion", "Modificar");
            }
        }
        private static void MarcarRegistrado(GestionContext db, DbContextTransaction tx, RegistroContable r)
        {
            Ejecutar(db, tx, "UPDATE dbo.ContabilidadCola SET Estado=3,Lote=@lote,Error=NULL WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc",
                ("lote", r.Id), ("empresa", r.Empresa), ("op", (int)r.Operatoria), ("doc", r.Documento));
        }
        public void Reintentar(int empresa, int id, int usuario, List<int> sucursales)
        {
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa); ExigirUsuario(db, tx, usuario, "ContabilidadBandeja", "Agregar");
                using (var cmd = Comando(db, tx, @"UPDATE dbo.ContabilidadCola SET Estado=1,Intentos=0,ProximoIntento=SYSUTCDATETIME(),Error=NULL,Firma=NULL,Simulacion=NULL
                    WHERE Empresa=@empresa AND Id=@id AND Lote IS NULL AND Sucursal IN(SELECT Id FROM @sucursales)
                    AND NOT EXISTS(SELECT 1 FROM dbo.ContabilidadLotes l WHERE l.Empresa=@empresa AND l.Operatoria=ContabilidadCola.Operatoria AND l.Documento=ContabilidadCola.Documento AND l.ReversionDe IS NULL)",
                    ("empresa", empresa), ("id", id)))
                {
                    AgregarSucursales(cmd, sucursales);
                    if (cmd.ExecuteNonQuery() != 1) throw new ValidationException("Pendiente inexistente, ya registrado o fuera de las sucursales habilitadas.");
                }
                Auditar(db, tx, empresa, usuario, "Reintentar cola", id.ToString(), "Reintento solicitado explicitamente", null);
                tx.Commit();
            }
        }
        public static TimeSpan DemoraReintento(int intento) => TimeSpan.FromSeconds(Math.Min(3600, 30 * Math.Pow(2, Math.Max(0, Math.Min(intento - 1, 7)))));
        public int ProcesarCola(int empresa, int maximo = 20)
        {
            if (maximo < 1 || maximo > 50) throw new ValidationException("Proceso limitado a 50 documentos.");
            int procesados = 0;
            for (var i = 0; i < maximo; i++)
            {
                int id = 0, intento = 0;
                OperatoriaContable op = 0;
                int documento = 0;
                try
                {
                    using (var db = Abrir())
                    using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
                    {
                        ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa);
                        var o = LeerOperativa(db, tx, empresa);
                        if (!o.Activa) return procesados;
                        ValidarOperativa(o);
                        using (var cmd = Comando(db, tx, @"SELECT TOP(1) q.Id,q.Operatoria,q.Documento,q.Intentos FROM dbo.ContabilidadCola q
                            JOIN dbo.ContabilidadPoliticas p ON p.Empresa=q.Empresa AND p.Operatoria=q.Operatoria
                            WHERE q.Empresa=@empresa AND q.Estado IN(1,4) AND q.Intentos<8 AND q.ProximoIntento<=SYSUTCDATETIME()
                            AND p.Modo<>1 AND q.FechaOrigen>=p.Desde ORDER BY q.Id", ("empresa", empresa)))
                        using (var r = cmd.ExecuteReader())
                            if (r.Read()) { id = r.GetInt32(0); op = (OperatoriaContable)r.GetInt32(1); documento = r.GetInt32(2); intento = r.GetInt32(3) + 1; }
                        if (id == 0) return procesados;
                        var existente = LeerRegistro(db, tx, empresa, op, documento);
                        if (existente != null) { MarcarRegistrado(db, tx, existente); tx.Commit(); procesados++; continue; }
                        using (var cmd = Comando(db, tx, @"SELECT COUNT(*) FROM dbo.ContabilidadOrigenes
                            WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc AND (Anulacion IS NOT NULL OR Baja IS NOT NULL)",
                            ("empresa", empresa), ("op", op == OperatoriaContable.CostoVentaAutomatico ? 1 : (int)op), ("doc", documento)))
                            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
                            {
                                Ejecutar(db, tx, "UPDATE dbo.ContabilidadCola SET Estado=5,Error=N'Origen anulado: no se contabiliza' WHERE Id=@id", ("id", id));
                                tx.Commit(); procesados++; continue;
                            }
                        var politica = o.Politicas.Single(p => p.Operatoria == op);
                        var config = LeerConfiguracion(db, tx, empresa) ?? throw new ValidationException("Falta configuracion contable.");
                        BloquearOrigen(db, tx, op == OperatoriaContable.CostoVentaAutomatico ? OperatoriaContable.Venta : op, documento);
                        var h = ObtenerHecho(db, tx, empresa, op, documento, config.MonedaBase);
                        Ejercicio(db, empresa, h.Fecha);
                        var sim = MotorContable.Simular(config, h, Cuentas(db));
                        if (politica.Modo == ModoContable.Automatico)
                        {
                            var r = RegistrarDentro(db, tx, empresa, op, documento, sim.Firma, politica.UsuarioAutomatico.Value, true);
                            MarcarRegistrado(db, tx, r);
                        }
                        else Ejecutar(db, tx, "UPDATE dbo.ContabilidadCola SET Estado=2,Intentos=@intento,Firma=@firma,Simulacion=@sim,Error=NULL WHERE Id=@id",
                            ("intento", intento), ("firma", sim.Firma), ("sim", JsonConvert.SerializeObject(sim)), ("id", id));
                        tx.Commit(); procesados++;
                    }
                }
                catch (ValidationException e) when (id > 0) { ErrorCola(empresa, id, intento, e.Message); procesados++; }
                catch (SqlException e) when (id > 0) { ErrorCola(empresa, id, intento, "Error SQL " + e.Number + ". Revisar registro del servidor y reintentar."); procesados++; }
            }
            return procesados;
        }
        private static void ErrorCola(int empresa, int id, int intento, string error)
        {
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, empresa);
                Ejecutar(db, tx, "UPDATE dbo.ContabilidadCola SET Estado=4,Intentos=@intento,Error=@error,ProximoIntento=@proximo WHERE Empresa=@empresa AND Id=@id AND Estado IN(1,4) AND Lote IS NULL",
                    ("empresa", empresa), ("id", id), ("intento", intento), ("error", error.Substring(0, Math.Min(error.Length, 2000))),
                    ("proximo", DateTime.UtcNow.Add(DemoraReintento(intento))));
                tx.Commit();
            }
        }
    }
}
