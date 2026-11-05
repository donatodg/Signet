using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens
{
    /// <summary>Ejecuta las operaciones de los Managers originales aplicando los mismos permisos que el escritorio.</summary>
    public partial class ScreenService
    {
        private readonly ScreenCatalog _catalog;
        private readonly SignetOptions _options;

        public ScreenService(ScreenCatalog catalog, IOptions<SignetOptions> options)
        {
            _catalog = catalog;
            _options = options.Value;
        }

        public void ExigirPermiso(ScreenDescriptor d, Enums.Accion accion)
        {
            if (!Seguridad.ObtenerPermiso(d.Modulo, d.Formulario, accion))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(accion, d.Formulario));
        }

        public object Menu()
        {
            return _catalog.All
                .Where(d => d.Visible && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Ingresar))
                .GroupBy(d => new { d.Area, d.AreaOrden })
                .OrderBy(g => g.Key.AreaOrden)
                .Select(g => new
                {
                    area = g.Key.Area,
                    pantallas = g.OrderBy(d => d.Titulo).Select(d => new { key = d.Key, titulo = d.Titulo }).ToList()
                })
                .ToList();
        }

        public HashSet<string> PantallasHabilitadas()
        {
            return new HashSet<string>(
                _catalog.All.Where(d => d.Visible && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Ingresar)).Select(d => d.Key),
                StringComparer.OrdinalIgnoreCase);
        }

        public object Esquema(string key, Func<ScreenDescriptor, object> acciones = null)
        {
            var d = _catalog.Get(key);
            ExigirPermiso(d, Enums.Accion.Ingresar);
            var listaAcciones = acciones?.Invoke(d);
            return new
            {
                key = d.Key,
                titulo = d.Titulo,
                area = d.Area,
                tipo = d.Tipo,
                formulario = d.Formulario,
                modulo = d.Modulo.ToString(),
                parametros = d.Parametros,
                columnas = d.Columnas,
                camposEdicion = d.CamposEdicion,
                parametrosGuardar = d.ParametrosGuardar,
                detalles = d.Detalles,
                colecciones = d.Colecciones,
                edicion = d.Tipo == "edicion" ? new { selector = d.Aux.Selector, editables = d.Aux.Editables, clave = d.Aux.Clave } : null,
                acciones = listaAcciones,
                textoBoton = d.TextoBoton,
                informe = d.Informe,
                descripcion = DescripcionPantalla(d),
                lookups = d.LookupProperties.Select(p => p.Name).Concat(d.LookupFuentes.Keys).Concat(d.Parametros.Concat(d.ParametrosGuardar).Where(c => c.Lookup != null && c.Lookup.StartsWith("Pantalla.")).Select(c => c.Lookup)).Concat(d.Aux == null ? new string[0] : d.Aux.LookupsEntidad.Keys.Select(k => "Entidad." + k).Concat(d.Aux.LookupsParametros.Select(x => "Param." + x.Name))).ToList(),
                permisos = new
                {
                    buscar = d.PuedeBuscar && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Buscar),
                    agregar = (d.PuedeEditar || d.PuedeAgregarHijo) && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Agregar),
                    modificar = (d.PuedeEditar || d.PuedeGuardarGrilla) && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Modificar),
                    eliminar = (d.PuedeEliminar || d.PuedeEliminarHijo) && Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Eliminar),
                }
            };
        }

        public object Buscar(string key, JObject parametros)
        {
            var d = _catalog.Get(key);
            if (!d.PuedeBuscar) throw new ApiException(400, "La pantalla no permite búsquedas.");
            ExigirPermiso(d, Enums.Accion.Buscar);
            if (d.Aux != null && d.Buscar == null) return BuscarAux(d, parametros);

            var p = Activator.CreateInstance(d.ParametrosType);
            Aplicar(p, d.ParametrosType, parametros, d.Parametros.Select(x => x.Name));

            var args = new object[d.Buscar.GetParameters().Length];
            args[0] = p;
            for (int i = 1; i < args.Length; i++) args[i] = Type.Missing;

            var result = (IEnumerable)Invocar(() => d.Buscar.Invoke(null, BindingFlags.OptionalParamBinding, null, args, null));
            var props = ScreenCatalog.PropiedadesEscalares(d.ResultType).Where(x => d.Columnas.Any(c => c.Name == x.Name)).ToList();

            var filas = new List<Dictionary<string, object>>();
            bool truncado = false;
            if (result != null)
                foreach (var o in result)
                {
                    if (filas.Count >= _options.MaxFilasBusqueda) { truncado = true; break; }
                    filas.Add(ValueConverter.ToDictionary(o, props));
                }
            return new { filas, truncado };
        }

        /// <summary>
        /// Busca una fila puntual con el Buscar del Manager (filtrando por Id si el parámetro existe y sin rangos de fecha),
        /// para validar el estado del registro igual que el escritorio (que lee la fila de la grilla).
        /// </summary>
        public object BuscarFila(ScreenDescriptor d, int id)
        {
            if (!d.PuedeBuscar || d.Buscar == null) return null;
            var p = Activator.CreateInstance(d.ParametrosType);
            foreach (var prop in d.ParametrosType.GetProperties().Where(x => x.CanWrite))
            {
                if (prop.Name == "Id" && (prop.PropertyType == typeof(int?) || prop.PropertyType == typeof(int))) prop.SetValue(p, id);
                else if (prop.PropertyType == typeof(DateTime?)) prop.SetValue(p, null);
            }
            var args = new object[d.Buscar.GetParameters().Length];
            args[0] = p;
            for (int i = 1; i < args.Length; i++) args[i] = Type.Missing;
            var result = (IEnumerable)Invocar(() => d.Buscar.Invoke(null, BindingFlags.OptionalParamBinding, null, args, null));
            var idProp = d.ResultType.GetProperty("Id");
            if (result == null || idProp == null) return null;
            foreach (var o in result)
                if (o != null && Convert.ToInt32(idProp.GetValue(o)) == id) return o;
            return null;
        }

        public object Lookups(string key, string[] nombres = null)
        {
            var d = _catalog.Get(key);
            ExigirPermiso(d, Enums.Accion.Ingresar);
            if (d.Aux != null && d.Ctor == null) return LookupsAux(d, new JObject(), nombres);
            var manager = d.Ctor == null ? null : CrearManager(d, 0);
            try { return LeerLookups(d, manager, nombres); }
            finally { (manager as IDisposable)?.Dispose(); }
        }

        public object Obtener(string key, int id)
        {
            var d = _catalog.Get(key);
            if (!d.PuedeEditar) throw new ApiException(400, "La pantalla no permite ver registros.");
            ExigirPermiso(d, id == 0 ? Enums.Accion.Agregar : Enums.Accion.Ingresar);

            var manager = CrearManager(d, id);
            try
            {
                var entidad = d.EntityProperty.GetValue(manager);
                if (id > 0 && (entidad == null || (int)d.IdProperty.GetValue(entidad) != id))
                    throw new ApiException(404, "No se encontró el registro.");
                var campos = new HashSet<string>(d.CamposEdicion.Where(c => !c.Sensitive).Select(c => c.Name));
                var datos = ValueConverter.ToDictionary(entidad, ScreenCatalog.PropiedadesEscalares(d.EntityType), p => p.Name == "Id" || campos.Contains(p.Name));
                if (string.Equals(d.Key, "Parametros", StringComparison.OrdinalIgnoreCase)
                    && Equals(entidad.GetType().GetProperty("TipoDato")?.GetValue(entidad), Enums.TipoDato.Password))
                    datos["Valor"] = "";
                var lookups = LeerLookups(d, manager, null);
                var detalles = new Dictionary<string, object>();
                foreach (var c in d.Colecciones)
                {
                    var props = ScreenCatalog.PropiedadesEscalares(c.ItemType).Where(x => x.Name == "Id" || c.Campos.Any(f => f.Name == x.Name)).ToList();
                    var items = c.Property.GetValue(entidad) as IEnumerable;
                    detalles[c.Name] = items == null ? new List<Dictionary<string, object>>()
                        : items.Cast<object>().Where(o => o != null && !EstaBorrado(o))
                               .Select(o => ValueConverter.ToDictionary(o, props)).ToList();
                    foreach (var kv in LookupsDeColeccion(c, entidad, datos, null)) lookups[kv.Key] = kv.Value;
                }
                return new { datos, lookups, detalles };
            }
            finally { (manager as IDisposable)?.Dispose(); }
        }

        public object Guardar(string key, int id, JObject valores, JObject opciones = null, JObject detalles = null)
        {
            var d = _catalog.Get(key);
            if (!d.PuedeEditar) throw new ApiException(400, "La pantalla no permite guardar.");
            ExigirPermiso(d, id == 0 ? Enums.Accion.Agregar : Enums.Accion.Modificar);

            var manager = CrearManager(d, id);
            try
            {
                var entidad = d.EntityProperty.GetValue(manager);
                if (id > 0 && (int)d.IdProperty.GetValue(entidad) != id)
                    throw new ApiException(404, "No se encontró el registro.");

                // Campos sensibles (ej. Clave) vacíos = conservar el valor actual
                var conservarPasswordParametro = string.Equals(d.Key, "Parametros", StringComparison.OrdinalIgnoreCase)
                    && Convert.ToInt32(valores?["TipoDato"] ?? 0) == (int)Enums.TipoDato.Password
                    && string.IsNullOrEmpty(Convert.ToString(valores?["Valor"]));
                var editables = d.CamposEdicion
                    .Where(c => !(c.Sensitive && string.IsNullOrEmpty((string)valores?[c.Name]))
                                && !(conservarPasswordParametro && c.Name == "Valor"))
                    .Select(c => c.Name);
                Aplicar(entidad, d.EntityType, valores, editables);
                AplicarDetalles(d, entidad, detalles);

                var saveArgs = d.Save.GetParameters().Select(p =>
                {
                    var tok = opciones?[p.Name];
                    if ((tok == null || tok.Type == JTokenType.Null) && p.HasDefaultValue) return p.DefaultValue;
                    try { return ValueConverter.FromJson(tok, p.ParameterType); }
                    catch (Exception) { throw new ApiException(400, "Valor inválido para '" + ScreenCatalog.SepararPalabras(p.Name) + "'."); }
                }).ToArray();
                Invocar(() => d.Save.Invoke(manager, saveArgs));
                return new { id = (int)d.IdProperty.GetValue(entidad) };
            }
            finally { (manager as IDisposable)?.Dispose(); }
        }

        private static bool EstaBorrado(object o)
        {
            var p = o.GetType().GetProperty("Borrado");
            return p != null && p.PropertyType == typeof(bool) && (bool)p.GetValue(o);
        }

        private static void AplicarDetalles(ScreenDescriptor d, object entidad, JObject detalles)
        {
            if (detalles == null) return;
            var usuario = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrentUserId"]);
            var ahora = Sistema.ObtenerFechaHora();
            foreach (var c in d.Colecciones)
            {
                if (!detalles.TryGetValue(c.Name, StringComparison.Ordinal, out var tok) || !(tok is JArray filas)) continue;
                var coleccion = c.Property.GetValue(entidad);
                if (coleccion == null)
                {
                    coleccion = Activator.CreateInstance(typeof(List<>).MakeGenericType(c.ItemType));
                    c.Property.SetValue(entidad, coleccion);
                }
                var existentes = ((IEnumerable)coleccion).Cast<object>().ToList();
                var idProp = c.ItemType.GetProperty("Id");
                var borrado = c.ItemType.GetProperty("Borrado");
                var nombres = c.Campos.Select(x => x.Name).ToList();
                var conservar = new HashSet<int>();

                foreach (var fila in filas.OfType<JObject>())
                {
                    var fid = fila["Id"] == null || fila["Id"].Type == JTokenType.Null ? 0 : (int)fila["Id"];
                    object item = fid > 0 ? existentes.FirstOrDefault(o => (int)idProp.GetValue(o) == fid) : null;
                    if (fid > 0 && item == null) throw new ApiException(400, "El renglón #" + fid + " de " + c.Label + " ya no existe. Vuelva a abrir el registro.");
                    var nuevo = item == null;
                    if (nuevo) item = Activator.CreateInstance(c.ItemType);
                    Aplicar(item, c.ItemType, fila, nombres);
                    if (nuevo)
                    {
                        Fijar(item, "FechaAdd", ahora); Fijar(item, "UserAdd", usuario);
                        coleccion.GetType().GetMethod("Add").Invoke(coleccion, new[] { item });
                    }
                    else
                    {
                        conservar.Add(fid);
                        Fijar(item, "FechaMod", ahora); Fijar(item, "UserMod", usuario);
                    }
                    if (borrado != null && borrado.CanWrite) borrado.SetValue(item, false);
                }

                if (c.PuedeQuitar)
                    foreach (var o in existentes)
                        if (!conservar.Contains((int)idProp.GetValue(o))) borrado.SetValue(o, true);
            }
        }

        private static void Fijar(object o, string prop, object valor)
        {
            var p = o.GetType().GetProperty(prop);
            if (p == null || !p.CanWrite) return;
            p.SetValue(o, ValueConverter.FromJson(JToken.FromObject(valor), p.PropertyType));
        }

        /// <summary>Instancia el Manager del renglón (si existe) con los datos de la cabecera para que aplique sus reglas.</summary>
        private static object CrearManagerColeccion(ColeccionDef c, object item, JObject cabecera)
        {
            if (c.ManagerCtor == null) return null;
            var args = c.ManagerCtor.GetParameters().Select((p, i) =>
            {
                if (i == 0) return item;
                var alias = new[] { p.Name, p.Name == "Id_Cliente" || p.Name == "Id_Proveedor" ? "Id_Entidad" : null, p.Name.Replace("Utiliza_", "Utiliza") };
                foreach (var n in alias.Where(x => x != null))
                    if (cabecera != null && cabecera.TryGetValue(n, StringComparison.OrdinalIgnoreCase, out var tok) && tok.Type != JTokenType.Null)
                    {
                        try { return ValueConverter.FromJson(tok, p.ParameterType); } catch (Exception) { }
                    }
                return p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null;
            }).ToArray();
            return Invocar(() => c.ManagerCtor.Invoke(args));
        }

        private static Dictionary<string, List<LookupItem>> LookupsDeColeccion(ColeccionDef c, object entidad, IDictionary<string, object> cabecera, JObject cab)
        {
            var r = new Dictionary<string, List<LookupItem>>();
            if (c.ManagerCtor == null || c.LookupProperties.Count == 0) return r;
            var item = Activator.CreateInstance(c.ItemType);
            var jc = cab ?? JObject.FromObject(cabecera ?? new Dictionary<string, object>());
            var mgr = CrearManagerColeccion(c, item, jc);
            try
            {
                foreach (var p in c.LookupProperties)
                {
                    try
                    {
                        var list = p.GetValue(mgr) as IEnumerable;
                        r[c.Name + "." + p.Name] = list == null ? new List<LookupItem>() : list.Cast<object>().Where(o => o != null).Select(LookupItem.From).ToList();
                    }
                    catch (Exception) { r[c.Name + "." + p.Name] = new List<LookupItem>(); }
                }
            }
            finally { (mgr as IDisposable)?.Dispose(); }
            return r;
        }

        /// <summary>Lookups que dependen de la cabecera (ej. Letra según sucursal y tipo de comprobante, entidades según tipo de entidad).</summary>
        public object LookupsDependientes(string key, int id, JObject valores)
        {
            var d = _catalog.Get(key);
            ExigirPermiso(d, id == 0 && d.Aux == null ? Enums.Accion.Agregar : Enums.Accion.Ingresar);
            if (d.Aux != null && d.Ctor == null) return new { lookups = LookupsAux(d, valores), valores = (object)null };
            if (d.Ctor == null) return new { lookups = new Dictionary<string, List<LookupItem>>(), valores = (object)null };
            var manager = CrearManager(d, id);
            try
            {
                var entidad = d.EntityProperty.GetValue(manager);
                Aplicar(entidad, d.EntityType, valores, d.CamposEdicion.Select(x => x.Name));
                var lookups = LeerLookups(d, manager, null);
                var valoresDependientes = new Dictionary<string, object>();
                if (string.Equals(d.Key, "ComprobantesVentas", StringComparison.OrdinalIgnoreCase))
                    CompletarDependenciasComprobanteVentas(manager, entidad, lookups, valoresDependientes);
                return new { lookups, valores = valoresDependientes };
            }
            finally { (manager as IDisposable)?.Dispose(); }
        }

        private static void CompletarDependenciasComprobanteVentas(object manager, object entidad, Dictionary<string, List<LookupItem>> lookups, Dictionary<string, object> valores)
        {
            int idEntidad = Convert.ToInt32(entidad.GetType().GetProperty("Id_Entidad").GetValue(entidad) ?? 0);
            if (idEntidad <= 0) return;
            int sucursal = Convert.ToInt32(entidad.GetType().GetProperty("Id_Sucursal").GetValue(entidad));
            int comprobante = Convert.ToInt32(entidad.GetType().GetProperty("Id_TipoComprobante").GetValue(entidad));
            var tipoEntidad = (Enums.TipoEntidad)Convert.ToInt32(entidad.GetType().GetProperty("Id_TipoEntidad").GetValue(entidad));
            var talonarios = Sistema.ObtenerTalonario(sucursal, comprobante, tipoEntidad, idEntidad);
            lookups["Talonarios"] = talonarios.Select(LookupItem.From).ToList();
            var seleccionado = talonarios.FirstOrDefault();
            if (seleccionado != null)
            {
                valores["Id_TalonariosComprobantes"] = seleccionado.Key;
                valores["Id_Deposito"] = seleccionado.Key2;
                var separador = seleccionado.Name?.IndexOf('-') ?? -1;
                if (separador >= 0)
                {
                    valores["Letra"] = seleccionado.Name.Substring(0, separador);
                    valores["PuntoVenta"] = seleccionado.Name.Substring(separador + 1);
                }
            }
            var formaPago = manager.GetType().GetProperty("FormaPagocliente")?.GetValue(manager);
            if (formaPago != null) valores["Id_FormaPago"] = formaPago;
        }

        /// <summary>Corre las reglas del Manager del renglón (precio, IVA, especie...) al elegir un valor o al agregar un renglón nuevo.</summary>
        public object AutocompletarRenglon(string key, string coleccion, JObject fila, string campo, JObject cabecera)
        {
            var d = _catalog.Get(key);
            if (!Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Agregar) && !Seguridad.TienePermiso(d.Modulo, d.Formulario, Enums.Accion.Modificar)) ExigirPermiso(d, Enums.Accion.Ingresar);
            var c = d.Colecciones.FirstOrDefault(x => string.Equals(x.Name, coleccion, StringComparison.OrdinalIgnoreCase))
                    ?? throw new ApiException(404, "Detalle inexistente: " + coleccion);
            var item = Activator.CreateInstance(c.ItemType);
            Aplicar(item, c.ItemType, fila, c.Campos.Select(x => x.Name));
            var idTok = fila?["Id"];
            if (idTok != null && idTok.Type != JTokenType.Null) c.ItemType.GetProperty("Id").SetValue(item, (int)idTok);

            PropertyInfo pc = null; object valor = null;
            if (!string.IsNullOrEmpty(campo))
            {
                pc = c.ItemType.GetProperty(campo);
                if (pc != null && pc.CanWrite)
                {
                    valor = pc.GetValue(item);
                    pc.SetValue(item, pc.PropertyType.IsValueType && Nullable.GetUnderlyingType(pc.PropertyType) == null ? Activator.CreateInstance(pc.PropertyType) : null);
                }
            }
            var mgr = CrearManagerColeccion(c, item, cabecera);
            try
            {
                if (pc != null && pc.CanWrite) pc.SetValue(item, valor);
            }
            finally { (mgr as IDisposable)?.Dispose(); }
            var props = ScreenCatalog.PropiedadesEscalares(c.ItemType).Where(x => x.Name == "Id" || c.Campos.Any(f => f.Name == x.Name)).ToList();
            return ValueConverter.ToDictionary(item, props);
        }

        public void Eliminar(string key, int id)
        {
            var d = _catalog.Get(key);
            if (d.PuedeEliminarHijo) { EliminarHijo(d, id); return; }
            if (!d.PuedeEliminar) throw new ApiException(400, "La pantalla no permite eliminar.");
            ExigirPermiso(d, Enums.Accion.Eliminar);
            var entidad = Activator.CreateInstance(d.EntityType);
            d.IdProperty.SetValue(entidad, id);
            Invocar(() => d.Eliminar.Invoke(null, new[] { entidad }));
        }

        private object CrearManager(ScreenDescriptor d, int id)
        {
            var entidad = Activator.CreateInstance(d.EntityType);
            d.IdProperty.SetValue(entidad, id);
            var parametros = d.Ctor.GetParameters();
            if (parametros.Length == 1) return Invocar(() => d.Ctor.Invoke(new[] { entidad }));
            if (d.ManagerType.Name == "TalonariosComprobantesManager")
            {
                var empresas = Sistema.Empresas;
                if (empresas.Count == 0) throw new ApiException(400, "El usuario no tiene empresas asignadas para editar talonarios.");
                var fila = id > 0 ? BuscarFila(d, id) : null;
                var nombreEmpresa = fila?.GetType().GetProperty("Empresa")?.GetValue(fila)?.ToString();
                var empresa = empresas.FirstOrDefault(e => string.Equals(e.Name, nombreEmpresa, StringComparison.OrdinalIgnoreCase));
                return Invocar(() => d.Ctor.Invoke(new object[] { entidad, Convert.ToInt32((empresa ?? empresas[0]).Key) }));
            }
            throw new ApiException(400, "No se puede crear el administrador de la pantalla.");
        }

        private static List<LookupItem> LeerFuenteEstatica(string src)
        {
            if (src.StartsWith("Enums."))
            {
                var t = typeof(Enums).GetNestedType(src.Substring(6));
                return Enum.GetValues(t).Cast<Enum>().Select(e => new LookupItem { Key = Convert.ToInt64(e), Name = Enums.GetDescription(e) }).ToList();
            }
            var list = typeof(Sistema).GetProperty(src.Substring(8), BindingFlags.Public | BindingFlags.Static).GetValue(null) as IEnumerable;
            return list == null ? new List<LookupItem>() : list.Cast<object>().Where(o => o != null).Select(LookupItem.From).ToList();
        }

        private static Dictionary<string, List<LookupItem>> LeerLookups(ScreenDescriptor d, object manager, string[] nombres)
        {
            var r = new Dictionary<string, List<LookupItem>>();
            foreach (var f in d.LookupFuentes)
            {
                if (nombres != null && nombres.Length > 0 && !nombres.Contains(f.Key, StringComparer.OrdinalIgnoreCase)) continue;
                try { r[f.Key] = LeerFuenteEstatica(f.Value); }
                catch (Exception) { r[f.Key] = new List<LookupItem>(); }
            }
            foreach (var p in manager == null ? new List<PropertyInfo>() : d.LookupProperties)
            {
                if (nombres != null && nombres.Length > 0 && !nombres.Contains(p.Name, StringComparer.OrdinalIgnoreCase)) continue;
                try
                {
                    var list = p.GetValue(manager) as IEnumerable;
                    r[p.Name] = list == null ? new List<LookupItem>() : list.Cast<object>().Where(o => o != null).Select(LookupItem.From).ToList();
                }
                catch (Exception)
                {
                    r[p.Name] = new List<LookupItem>();
                }
            }
            return r;
        }

        private static void Aplicar(object target, Type type, JObject valores, IEnumerable<string> permitidos)
        {
            if (valores == null) return;
            foreach (var name in permitidos)
            {
                if (!valores.TryGetValue(name, StringComparison.Ordinal, out var token)) continue;
                var p = type.GetProperty(name);
                if (p == null || !p.CanWrite) continue;
                object v;
                try { v = ValueConverter.FromJson(token, p.PropertyType); }
                catch (Exception) { throw new ApiException(400, "Valor inválido para el campo '" + ScreenCatalog.SepararPalabras(name) + "'."); }
                p.SetValue(target, v);
            }
        }

        private static object Invocar(Func<object> f)
        {
            try { return f(); }
            catch (TargetInvocationException tie) when (tie.InnerException != null)
            {
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(tie.InnerException).Throw();
                throw;
            }
        }
    }
}
