using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens
{
    /// <summary>
    /// Descubre por reflexión los Managers de los proyectos *_BL originales y los expone como "pantallas".
    /// Convenciones del BL (iguales en todos los módulos):
    ///   new XManager(Entidad e)          -> carga la entidad (Id &gt; 0) o prepara una nueva
    ///   xManager.Save()                   -> valida y guarda
    ///   XManager.Buscar(ParametrosBusquedas) -> List&lt;SearchResult&gt;
    ///   XManager.Eliminar(Entidad e)      -> baja lógica
    ///   propiedades List&lt;KeyNamePair&gt;  -> combos (lookups)
    /// </summary>
    public partial class ScreenCatalog
    {
        public static readonly string[] BlAssemblies =
        {
            "VENET_General_BL", "VENET_Seguridad_BL", "VENET_Clientes_BL", "VENET_Proveedores_BL",
            "VENET_ProvFinancieros_BL", "VENET_Personal_BL", "VENET_Produccion_BL", "VENET_Tesoreria_BL", "VENET_Gestion_BL",
            "VENET_Contabilidad_BL"
        };

        private static readonly Dictionary<string, (string Area, Enums.Modulos Modulo, int Orden)> Areas = new Dictionary<string, (string, Enums.Modulos, int)>
        {
            ["VENET_General_BL"] = ("General", Enums.Modulos.General, 1),
            ["VENET_Gestion_BL"] = ("Gestión", Enums.Modulos.Gestion, 2),
            ["VENET_Contabilidad_BL"] = ("Contabilidad", Enums.Modulos.Gestion, 10),
            ["VENET_Tesoreria_BL"] = ("Tesorería", Enums.Modulos.Tesoreria, 3),
            ["VENET_Clientes_BL"] = ("Clientes", Enums.Modulos.Tesoreria, 4),
            ["VENET_Proveedores_BL"] = ("Proveedores", Enums.Modulos.Tesoreria, 5),
            ["VENET_ProvFinancieros_BL"] = ("Proveedores Financieros", Enums.Modulos.Tesoreria, 6),
            ["VENET_Personal_BL"] = ("Personal", Enums.Modulos.Personal, 7),
            ["VENET_Produccion_BL"] = ("Producción", Enums.Modulos.Produccion, 8),
            ["VENET_Seguridad_BL"] = ("Seguridad", Enums.Modulos.Seguridad, 9),
        };

        private static readonly HashSet<string> CamposAuditoria = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "FechaAdd", "FechaMod", "FechaDel", "UserAdd", "UserMod", "UserDel" };

        private static readonly Regex Sensible = new Regex("clave|password|contrase|^pass$|^pass\\d*$", RegexOptions.IgnoreCase);

        private readonly Dictionary<string, ScreenDescriptor> _screens = new Dictionary<string, ScreenDescriptor>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _ocultos;
        private readonly Dictionary<string, Dictionary<string, string>> _combos;

        public ScreenCatalog(IOptions<SignetOptions> options, ILogger<ScreenCatalog> logger)
        {
            var opt = options.Value;
            _ocultos = new HashSet<string>(opt.CamposOcultos ?? new List<string>(), StringComparer.OrdinalIgnoreCase);
            var permisos = CargarPermisos(logger);
            _combos = CargarCombos(logger);

            var pendientes = new List<(Type, string, string)>();
            foreach (var asmName in BlAssemblies)
            {
                Assembly asm;
                try { asm = Assembly.Load(asmName); }
                catch (Exception ex) { logger.LogWarning(ex, "No se pudo cargar {Asm}", asmName); continue; }

                Type[] types;
                try { types = asm.GetTypes(); }
                catch (ReflectionTypeLoadException rtle) { types = rtle.Types.Where(t => t != null).ToArray(); }

                foreach (var t in types.Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && !t.IsNested))
                {
                    var key = Regex.Replace(t.Name, "(Manager|Mananger)$", "");
                    if (key == t.Name) continue;
                    try
                    {
                        var formularios = opt.Formularios ?? new Dictionary<string, string>();
                        var multiples = BuscarMultiples(t);
                        if (multiples.Count > 1)
                        {
                            // Un Manager con varias consultas estáticas (ej. IVA: detalle, resumen, alícuotas) = una pantalla por consulta
                            foreach (var m in multiples)
                            {
                                var suf = m.Name == "BuscarIvaDetalle" ? "Detalle" : m.Name == "BuscarIva" ? "Resumen" : m.Name == "BuscarAlicuotaIva" ? "Alicuotas" : m.Name.Substring(6);
                                var md = Describir(t, key + "_" + suf, asmName, permisos, formularios, m, key, suf);
                                if (md != null && !_screens.ContainsKey(md.Key)) _screens[md.Key] = md;
                            }
                            continue;
                        }
                        var d = Describir(t, key, asmName, permisos, formularios);
                        if (d != null && !_screens.ContainsKey(d.Key)) _screens[d.Key] = d;
                        else if (d == null) { pendientes.Add((t, key, asmName)); logger.LogDebug("Manager sin Buscar estático: {Manager}", t.Name); }
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning(ex, "No se pudo describir {Manager}", t.FullName);
                    }
                }
            }

            // Segunda pasada: altas sin búsqueda y procesos (necesita conocer las pantallas ya descubiertas)
            foreach (var (t, key, asmName) in pendientes)
            {
                try
                {
                    var d = Describir(t, key, asmName, permisos, opt.Formularios ?? new Dictionary<string, string>(), sinBusqueda: true);
                    if (d != null && !_screens.ContainsKey(d.Key)) _screens[d.Key] = d;
                }
                catch (Exception ex) { logger.LogWarning(ex, "No se pudo describir {Manager}", t.FullName); }
            }
            AsignarLookupsPantallas();
            RegistrarPersonalizadas();
            logger.LogInformation("Pantallas descubiertas en el BL: {Count}", _screens.Count);
        }

        public IEnumerable<ScreenDescriptor> All => _screens.Values;

        public ScreenDescriptor Get(string key)
        {
            if (key != null && _screens.TryGetValue(key, out var d)) return d;
            throw new ApiException(404, "Pantalla inexistente: " + key);
        }

        private static Dictionary<string, string> CargarPermisos(ILogger logger)
        {
            try
            {
                var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "permissions.generated.json");
                if (File.Exists(file))
                    return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file));
            }
            catch (Exception ex) { logger.LogWarning(ex, "permissions.generated.json inválido"); }
            return new Dictionary<string, string>();
        }

        private static Dictionary<string, Dictionary<string, string>> CargarCombos(ILogger logger)
        {
            var r = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
            try
            {
                var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "combos.generated.json");
                if (File.Exists(file))
                    foreach (var kv in JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(file)))
                        r[kv.Key] = kv.Value;
            }
            catch (Exception ex) { logger.LogWarning(ex, "combos.generated.json inválido"); }
            return r;
        }

        /// <summary>
        /// Aplica el origen real de cada combo del formulario original (Sistema.X, Enums.X o lista del Manager),
        /// para que la web muestre el texto y no el Id.
        /// </summary>
        private void AplicarCombos(ScreenDescriptor d)
        {
            AplicarCombos(d, d.Key, new[] { d.CamposEdicion, d.Parametros, d.ParametrosGuardar }, d.LookupProperties, "");
        }

        private void AplicarCombos(ScreenDescriptor d, string formKey, IEnumerable<List<FieldSchema>> listas, List<PropertyInfo> lookupProps, string prefijo)
        {
            if (!_combos.TryGetValue(formKey, out var campos)) return;
            foreach (var lista in listas)
                foreach (var c in lista)
                {
                    if (c.Options != null || c.Type == "bool" || c.Type == "date" || c.Type == "time" || c.Type == "binary") continue;
                    if (!campos.TryGetValue(c.Name, out var src)) continue;
                    string nombre;
                    if (src.StartsWith("manager."))
                    {
                        nombre = src.Substring("manager.".Length);
                        if (!lookupProps.Any(p => p.Name == nombre)) continue;
                        nombre = prefijo + nombre;
                    }
                    else if (src.StartsWith("Sistema.") && typeof(Sistema).GetProperty(src.Substring(8), BindingFlags.Public | BindingFlags.Static) != null) { nombre = src; d.LookupFuentes[nombre] = src; }
                    else if (src.StartsWith("Enums.") && typeof(Enums).GetNestedType(src.Substring(6)) != null) { nombre = src; d.LookupFuentes[nombre] = src; }
                    else continue;
                    c.Lookup = nombre;
                }
        }

        private static readonly string[] SinColeccion = { "Seguridad" };

        /// <summary>Detalles de la entidad (renglones, impuestos, etc.) que se pueden editar junto con la cabecera.</summary>
        private void ConstruirColecciones(ScreenDescriptor d)
        {
            if (d.EntityType == null || d.Ctor == null) return;
            var asm = d.ManagerType.Assembly;
            foreach (var p in d.EntityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!p.PropertyType.IsGenericType || !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)) continue;
                if (p.GetCustomAttribute<NotMappedAttribute>() != null || !p.CanRead) continue;
                var item = p.PropertyType.GetGenericArguments()[0];
                if (!item.IsClass || item.GetProperty("Id") == null) continue;

                var c = new ColeccionDef { Name = p.Name, Label = SepararPalabras(p.Name), Property = p, ItemType = item };
                var fk = item.GetProperties().FirstOrDefault(x => x.PropertyType == d.EntityType)?.GetCustomAttribute<ForeignKeyAttribute>()?.Name;
                c.Campos = Campos(item, paraFormulario: true).Where(f => f.Name != fk).ToList();
                if (item.Name == "ComprobantesVentasDetalle")
                {
                    var cantidad = c.Campos.FirstOrDefault(f => f.Name == "CantidadStock");
                    if (cantidad != null) cantidad.VisibleWhen = "Visible_Cantidad_Stock";
                    var visibleStock = item.GetProperty("Visible_Cantidad_Stock");
                    if (visibleStock != null && !c.Campos.Any(f => f.Name == visibleStock.Name))
                        c.Campos.Add(new FieldSchema { Name = visibleStock.Name, Label = Etiqueta(visibleStock), Type = "bool", Hidden = true });
                }
                if (c.Campos.Count == 0) continue;
                c.PuedeQuitar = item.GetProperty("Borrado") != null;

                // Manager del renglón (ej. ComprobantesVentasDetalleManager): aporta listas, valores por defecto y reglas.
                var mt = asm.GetTypes().FirstOrDefault(x => x.IsClass && x.IsPublic && !x.IsAbstract && x.Name == item.Name + "Manager");
                if (mt != null)
                {
                    c.ManagerCtor = mt.GetConstructors().Where(k => k.GetParameters().Length > 0 && k.GetParameters()[0].ParameterType == item)
                        .OrderBy(k => k.GetParameters().Length).FirstOrDefault();
                    c.ManagerItemProp = mt.GetProperties().FirstOrDefault(x => x.PropertyType == item && x.CanRead);
                    if (c.ManagerCtor != null)
                        c.LookupProperties = mt.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(x => x.CanRead && x.GetIndexParameters().Length == 0 && x.PropertyType.IsGenericType
                                        && typeof(IEnumerable).IsAssignableFrom(x.PropertyType) && LookupItem.Soporta(x.PropertyType.GetGenericArguments()[0]))
                            .ToList();
                }
                var prefijo = c.Name + ".";
                var listaLookup = c.LookupProperties;
                if (listaLookup.Count > 0)
                {
                    foreach (var f in c.Campos.Where(f => f.Type == "int" && Regex.IsMatch(f.Name, "^Id_?[A-Z]")))
                    {
                        var x = Normalizar(Regex.Replace(f.Name, "^Id_?", ""));
                        var l = listaLookup.FirstOrDefault(q => Normalizar(q.Name) == x)
                                ?? listaLookup.FirstOrDefault(q => Normalizar(q.Name).StartsWith(x) || x.StartsWith(Normalizar(q.Name)));
                        if (l != null) f.Lookup = prefijo + l.Name;
                    }
                }
                AplicarCombos(d, item.Name, new[] { c.Campos }, listaLookup, prefijo);
                d.Colecciones.Add(c);
            }
        }
        private static string Normalizar(string s) =>
            Regex.Replace(Regex.Replace(s ?? "", "([a-z])(es|s)(?=[A-Z]|$)", "$1"), "[^A-Za-z0-9]", "").ToLowerInvariant();

        private static List<MethodInfo> BuscarMultiples(Type t) =>
            t.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name.StartsWith("Buscar") && !m.ContainsGenericParameters
                && m.GetParameters().Length >= 1 && m.GetParameters()[0].ParameterType.Name == "ParametrosBusquedas"
                && m.GetParameters().Skip(1).All(x => x.IsOptional) && typeof(IEnumerable).IsAssignableFrom(m.ReturnType)).ToList();

        private ScreenDescriptor Describir(Type t, string key, string asmName, Dictionary<string, string> permisos, Dictionary<string, string> formularios,
            MethodInfo buscarForzado = null, string formKey = null, string sufijoTitulo = null, bool sinBusqueda = false)
        {
            var d = new ScreenDescriptor { Key = key, ManagerType = t, Assembly = asmName };

            // Constructor (Entidad)
            d.Ctor = t.GetConstructors().FirstOrDefault(c =>
            {
                var p = c.GetParameters();
                var entidad = p.Length > 0 && p[0].ParameterType.IsClass && p[0].ParameterType != typeof(string)
                              && p[0].ParameterType.GetProperty("Id") != null && p[0].ParameterType.GetConstructor(Type.EmptyTypes) != null;
                return entidad && (p.Length == 1 || (t.Name == "TalonariosComprobantesManager" && p.Length == 2 && p[1].ParameterType == typeof(int)));
            });
            if (d.Ctor != null)
            {
                d.EntityType = d.Ctor.GetParameters()[0].ParameterType;
                d.EntityProperty = t.GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(p => p.PropertyType == d.EntityType && p.CanRead);
                d.IdProperty = d.EntityType.GetProperty("Id");
            }

            d.Save = t.GetMethod("Save", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null)
                     ?? t.GetMethods(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(m =>
                            m.Name == "Save" && !m.ContainsGenericParameters && m.GetParameters().All(p => EsEscalar(p.ParameterType)));
            if (d.Save != null)
                d.ParametrosGuardar = d.Save.GetParameters().Select(p =>
                {
                    var u = Nullable.GetUnderlyingType(p.ParameterType) ?? p.ParameterType;
                    var f = new FieldSchema
                    {
                        Name = p.Name,
                        Label = SepararPalabras(Regex.Replace(p.Name, "^Id_?(?=[A-Z])", "")),
                        Type = Tipo(u),
                        Nullable = !p.ParameterType.IsValueType || Nullable.GetUnderlyingType(p.ParameterType) != null,
                        Required = p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null && u != typeof(bool),
                        Default = p.HasDefaultValue ? ValueConverter.ToJson(p.DefaultValue) : null
                    };
                    if (u.IsEnum)
                        f.Options = Enum.GetValues(u).Cast<Enum>().Select(e => new LookupItem { Key = Convert.ToInt64(e), Name = Enums.GetDescription(e) }).ToList();
                    return f;
                }).ToList();

            d.Buscar = buscarForzado ?? t.GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(m =>
            {
                if (m.Name != "Buscar" || m.ContainsGenericParameters) return false;
                var p = m.GetParameters();
                return p.Length >= 1 && p[0].ParameterType.Name == "ParametrosBusquedas" && p.Skip(1).All(x => x.IsOptional)
                       && typeof(IEnumerable).IsAssignableFrom(m.ReturnType);
            });
            if (d.Buscar != null)
            {
                d.ParametrosType = d.Buscar.GetParameters()[0].ParameterType;
                d.ResultType = ElementType(d.Buscar.ReturnType);
            }

            if (d.EntityType != null)
                d.Eliminar = t.GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(m =>
                    m.Name == "Eliminar" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == d.EntityType);

            // Solo pantallas con búsqueda (las demás son sub-managers de detalle o procesos especiales)
            if (d.Buscar == null)
            {
                if (!sinBusqueda)
                {
                    d.Aux = DetectarConsulta(t);
                    if (d.Aux == null) return null;
                    var crud = d.Ctor != null && d.Save != null && d.EntityType != null && d.Aux.ResultType != null && d.EntityType.IsAssignableFrom(d.Aux.ResultType);
                    if (crud) d.Tipo = "normal";
                    else
                    {
                        d.Ctor = null; d.Eliminar = null;
                        d.Tipo = d.Aux.Selector != null && d.Save != null && d.Save.GetParameters().Length == 0 ? "edicion"
                            : d.Save != null && d.Save.GetParameters().Length > 0 ? "hijo" : "consulta";
                        if (d.Tipo == "hijo") CompletarEliminarHijo(d, t);
                    }
                    d.ResultType = d.Aux.ResultType;
                }
                else
                {
                    // Sin Buscar: alta de un registro nuevo (ej. Transferencias) o proceso con formulario y Save
                    if (t.GetMethods(BindingFlags.Public | BindingFlags.Instance).Any(m => m.Name.StartsWith("Buscar"))) return null;
                    if (d.Ctor != null && d.Save != null && d.EntityType != null)
                    {
                        if (_screens.Values.Any(s => s.EntityType == d.EntityType)) return null;
                        d.Tipo = "alta"; d.Aux = new AuxDef();
                    }
                    else
                    {
                        var accion = d.Save ?? BuscarMetodoAccion(t);
                        if (accion == null) return null;
                        d.Aux = DetectarProceso(t, accion);
                        if (d.Aux == null) return null;
                        d.Save = accion;
                        d.Tipo = d.Aux.Selector != null ? "edicion" : "proceso"; d.Ctor = null;
                        if (d.Aux.ResultType != null) d.ResultType = d.Aux.ResultType;
                    }
                }
            }
            if (d.Ctor == null || d.Save == null) d.Ctor = null;

            d.LookupProperties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && p != d.EntityProperty
                            && p.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                            && LookupItem.Soporta(p.PropertyType.GetGenericArguments()[0]))
                .ToList();

            // Seguridad: mismo Formulario/Módulo que usa el formulario WinForms original
            var area = Areas.TryGetValue(asmName, out var a) ? a : ("Otros", Enums.Modulos.General, 99);
            string form = formularios.TryGetValue(formKey ?? key, out var f) ? f : (formKey ?? key);
            if (!permisos.ContainsKey(form))
            {
                var n = Normalizar(form);
                var match = permisos.Keys.FirstOrDefault(k => Normalizar(k) == n);
                if (match != null) form = match;
            }
            d.Formulario = form;
            d.Modulo = permisos.TryGetValue(form, out var mod) && Enum.TryParse(mod, out Enums.Modulos me) ? me : area.Item2;
            d.Area = area.Item1;
            d.AreaOrden = area.Item3;
            d.Titulo = Titulo(formKey ?? key, area.Item1) + (sufijoTitulo != null ? " - " + sufijoTitulo : "");

            d.ResultadoEsEntidad = d.ResultType != null && d.EntityType != null && d.EntityType.IsAssignableFrom(d.ResultType);
            if (d.EntityType != null)
                d.Detalles = d.EntityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                                && p.PropertyType.GetGenericArguments()[0].GetProperty("Id") != null
                                && p.GetCustomAttribute<NotMappedAttribute>() == null)
                    .Select(p => SepararPalabras(p.Name))
                    .ToList();
            d.Parametros = d.Aux != null && d.Aux.Entradas.Count > 0 ? d.Aux.Entradas.Select(e => e.Campo).ToList()
                : d.ParametrosType != null ? Campos(d.ParametrosType, paraFormulario: false, esParametro: true) : new List<FieldSchema>();
            d.Columnas = d.ResultType != null ? Campos(d.ResultType, paraFormulario: false) : new List<FieldSchema>();
            d.CamposEdicion = d.EntityType != null ? Campos(d.EntityType, paraFormulario: true) : new List<FieldSchema>();
            if (string.Equals(key, "ComprobantesVentas", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var campo in d.Parametros)
                    campo.Advanced = campo.Name != "Id_TipoComprobante" && campo.Name != "Fecha_Desde" && campo.Name != "Fecha_Hasta";
                var talonario = d.CamposEdicion.FirstOrDefault(c => c.Name == "Id_TalonariosComprobantes");
                if (talonario != null) talonario.Lookup = "Talonarios";
            }

            AsignarLookups(d.CamposEdicion, d.LookupProperties);
            AsignarLookups(d.Parametros, d.LookupProperties);
            AsignarLookups(d.ParametrosGuardar, d.LookupProperties);
            if (d.Aux != null) AsignarLookupsAux(d);
            AplicarCombos(d);
            ConstruirColecciones(d);
            return d;
        }

        private static Type ElementType(Type enumerable)
        {
            if (enumerable.IsArray) return enumerable.GetElementType();
            var ie = enumerable.IsGenericType && enumerable.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                ? enumerable
                : enumerable.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            return ie?.GetGenericArguments()[0] ?? typeof(object);
        }

        private static string Titulo(string key, string area)
        {
            var areaKey = new string(area.Normalize(System.Text.NormalizationForm.FormD)
                .Where(ch => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) != System.Globalization.UnicodeCategory.NonSpacingMark && ch != ' ')
                .ToArray());
            var k = key;
            if (k.StartsWith(areaKey, StringComparison.OrdinalIgnoreCase) && k.Length > areaKey.Length) k = k.Substring(areaKey.Length);
            return SepararPalabras(k);
        }

        public static string SepararPalabras(string s)
        {
            s = s.Replace("_", " ");
            s = Regex.Replace(s, "(?<=[a-z0-9])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])", " ");
            return Regex.Replace(s, "\\s+", " ").Trim();
        }

        /// <summary>Propiedades escalares en orden: clase base primero (Id, ...), luego derivadas.</summary>
        public static List<PropertyInfo> PropiedadesEscalares(Type type)
        {
            var chain = new List<Type>();
            for (var x = type; x != null && x != typeof(object); x = x.BaseType) chain.Insert(0, x);
            var r = new List<PropertyInfo>();
            var seen = new HashSet<string>();
            foreach (var x in chain)
                foreach (var p in x.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    if (!p.CanRead || p.GetIndexParameters().Length > 0 || !EsEscalar(p.PropertyType)) continue;
                    if (!seen.Add(p.Name)) continue;
                    r.Add(type.GetProperty(p.Name) ?? p);
                }
            return r;
        }

        public static bool EsEscalar(Type t)
        {
            t = Nullable.GetUnderlyingType(t) ?? t;
            return t.IsPrimitive || t.IsEnum || t == typeof(string) || t == typeof(decimal) || t == typeof(DateTime)
                   || t == typeof(DateTimeOffset) || t == typeof(TimeSpan) || t == typeof(Guid) || t == typeof(byte[]);
        }

        private List<FieldSchema> Campos(Type type, bool paraFormulario, bool esParametro = false)
        {
            object defaults = null;
            if (esParametro) { try { defaults = Activator.CreateInstance(type); } catch (Exception) { } }

            var r = new List<FieldSchema>();
            foreach (var p in PropiedadesEscalares(type))
            {
                if (_ocultos.Contains(p.Name)) continue;
                var u = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                var f = new FieldSchema
                {
                    Name = p.Name,
                    Label = Etiqueta(p),
                    Type = Tipo(u),
                    Nullable = !p.PropertyType.IsValueType || Nullable.GetUnderlyingType(p.PropertyType) != null,
                    Sensitive = Sensible.IsMatch(p.Name),
                };
                if (u.IsEnum)
                    f.Options = Enum.GetValues(u).Cast<Enum>().Select(e => new LookupItem { Key = Convert.ToInt64(e), Name = Enums.GetDescription(e) }).ToList();

                var req = p.GetCustomAttribute<RequiredAttribute>();
                var range = p.GetCustomAttribute<RangeAttribute>();
                f.Required = req != null || (range != null && p.Name.StartsWith("Id_"));
                var sl = p.GetCustomAttribute<StringLengthAttribute>();
                var ml = p.GetCustomAttribute<MaxLengthAttribute>();
                f.MaxLength = sl?.MaximumLength ?? (ml != null && ml.Length > 0 ? ml.Length : (int?)null);

                if (paraFormulario)
                {
                    if (p.Name == "Id" || CamposAuditoria.Contains(p.Name) || f.Type == "binary" || !p.CanWrite) continue;
                    if (p.GetCustomAttribute<NotMappedAttribute>() != null) continue;
                }
                else if (!esParametro)
                {
                    if (f.Type == "binary" || f.Sensitive) continue;
                    f.Hidden = CamposAuditoria.Contains(p.Name) || (p.Name.StartsWith("Id_") && p.Name.Length > 3);
                }
                else if (!p.CanWrite) continue;

                if (defaults != null)
                {
                    try { f.Default = ValueConverter.ToJson(p.GetValue(defaults)); } catch (Exception) { }
                }
                r.Add(f);
            }
            return r;
        }

        private static string Etiqueta(PropertyInfo p)
        {
            var dn = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? p.GetCustomAttribute<DisplayAttribute>()?.GetName();
            if (!string.IsNullOrEmpty(dn)) return dn;
            var n = p.Name.StartsWith("Id_") && p.Name.Length > 3 ? p.Name.Substring(3) : p.Name;
            return SepararPalabras(n);
        }

        private static string Tipo(Type u)
        {
            if (u == typeof(string) || u == typeof(char) || u == typeof(Guid)) return "string";
            if (u == typeof(bool)) return "bool";
            if (u.IsEnum) return "enum";
            if (u == typeof(DateTime) || u == typeof(DateTimeOffset)) return "date";
            if (u == typeof(TimeSpan)) return "time";
            if (u == typeof(byte[])) return "binary";
            if (u == typeof(decimal) || u == typeof(double) || u == typeof(float)) return "decimal";
            return "int";
        }

        /// <summary>Asocia campos Id_Xxx con propiedades List&lt;KeyNamePair&gt; del Manager (ej. Id_Grupo -> Grupos).</summary>
        private static void AsignarLookups(List<FieldSchema> campos, List<PropertyInfo> lookups)
        {
            if (lookups.Count == 0) return;
            foreach (var c in campos.Where(c => c.Type == "int" && Regex.IsMatch(c.Name, "^Id_?[A-Z]")))
            {
                var x = Normalizar(Regex.Replace(c.Name, "^Id_?", ""));
                var l = lookups.FirstOrDefault(p => Normalizar(p.Name) == x)
                        ?? lookups.FirstOrDefault(p => Normalizar(p.Name).StartsWith(x) || x.StartsWith(Normalizar(p.Name)));
                if (l != null) c.Lookup = l.Name;
            }
        }
    }

    public class ScreenDescriptor
    {
        public string Key { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public int AreaOrden { get; set; }
        public string Assembly { get; set; }
        public string Formulario { get; set; }
        public Enums.Modulos Modulo { get; set; }

        [JsonIgnore] public Type ManagerType { get; set; }
        [JsonIgnore] public Type EntityType { get; set; }
        [JsonIgnore] public PropertyInfo EntityProperty { get; set; }
        [JsonIgnore] public PropertyInfo IdProperty { get; set; }
        [JsonIgnore] public ConstructorInfo Ctor { get; set; }
        [JsonIgnore] public MethodInfo Save { get; set; }
        [JsonIgnore] public MethodInfo Buscar { get; set; }
        [JsonIgnore] public MethodInfo Eliminar { get; set; }
        [JsonIgnore] public Type ParametrosType { get; set; }
        [JsonIgnore] public Type ResultType { get; set; }
        [JsonIgnore] public List<PropertyInfo> LookupProperties { get; set; } = new List<PropertyInfo>();
        /// <summary>Combos con origen estático: nombre (Sistema.X / Enums.X) -> origen.</summary>
        [JsonIgnore] public Dictionary<string, string> LookupFuentes { get; set; } = new Dictionary<string, string>();

        public List<FieldSchema> Parametros { get; set; }
        public List<FieldSchema> Columnas { get; set; }
        public List<FieldSchema> CamposEdicion { get; set; }
        public List<FieldSchema> ParametrosGuardar { get; set; } = new List<FieldSchema>();
        public bool ResultadoEsEntidad { get; set; }
        public List<string> Detalles { get; set; } = new List<string>();
        public List<ColeccionDef> Colecciones { get; set; } = new List<ColeccionDef>();

        public string Tipo { get; set; } = "normal";
        [JsonIgnore] public AuxDef Aux { get; set; }
        /// <summary>Proceso con lógica propia (pantallas sin Manager reutilizable por reflexión).</summary>
        [JsonIgnore] public Func<JObject, Acciones.AccionResultado> Personalizado { get; set; }
        [JsonIgnore] public Func<string> DescripcionDinamica { get; set; }
        /// <summary>El formulario de escritorio no valida permisos (se abre directo desde el menú).</summary>
        [JsonIgnore] public bool LibreAcceso { get; set; }
        public string TextoBoton { get; set; }
        public bool Informe { get; set; }
        public bool PuedeBuscar => Buscar != null || (Aux?.PuedeBuscar ?? false);
        public bool Visible => PuedeBuscar || Tipo == "proceso" || Tipo == "alta";
        public bool PuedeGuardarGrilla => Tipo == "edicion" && Save != null;
        public bool PuedeAgregarHijo => Tipo == "hijo" && Save != null && ParametrosGuardar.Count > 0;
        public bool PuedeEliminarHijo => Tipo == "hijo" && Aux?.EliminarMetodo != null && ResultType?.GetProperty("Id") != null;
        public bool PuedeEditar => (ResultadoEsEntidad || Tipo == "alta") && Ctor != null && Save != null && EntityProperty != null && IdProperty != null;
        public bool PuedeEliminar => ResultadoEsEntidad && Eliminar != null && IdProperty != null;
    }

    public class ColeccionDef
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public bool PuedeQuitar { get; set; }
        public List<FieldSchema> Campos { get; set; }
        public List<string> Lookups => LookupProperties.Select(p => Name + "." + p.Name).ToList();

        [JsonIgnore] public PropertyInfo Property { get; set; }
        [JsonIgnore] public Type ItemType { get; set; }
        [JsonIgnore] public ConstructorInfo ManagerCtor { get; set; }
        [JsonIgnore] public PropertyInfo ManagerItemProp { get; set; }
        [JsonIgnore] public List<PropertyInfo> LookupProperties { get; set; } = new List<PropertyInfo>();
    }

    public class FieldSchema
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public bool Required { get; set; }
        public int? MaxLength { get; set; }
        public bool Hidden { get; set; }
        public bool Sensitive { get; set; }
        public bool Advanced { get; set; }
        public string VisibleWhen { get; set; }
        public string Lookup { get; set; }
        public object Default { get; set; }
        public List<LookupItem> Options { get; set; }
    }

    public class LookupItem
    {
        public object Key { get; set; }
        public string Name { get; set; }

        private static readonly string[] KeyProps = { "Key", "Id", "Id_Sucursal", "Id_Caja" };
        private static readonly string[] NameProps = { "Name", "Nombre", "Descripcion", "Name1", "RazonSocial", "Sucursal", "Caja" };

        public static bool Soporta(Type t) =>
            t.IsClass && t != typeof(string) && KeyProps.Any(k => t.GetProperty(k) != null);

        public static LookupItem From(object o)
        {
            var t = o.GetType();
            var k = KeyProps.Select(n => t.GetProperty(n)).FirstOrDefault(p => p != null)?.GetValue(o);
            var nameProp = NameProps.Select(n => t.GetProperty(n)).FirstOrDefault(p => p != null);
            string name = nameProp?.GetValue(o)?.ToString();
            var legajo = t.GetProperty("Legajo")?.GetValue(o);
            if (legajo != null && name != null) name = legajo + " - " + name;
            return new LookupItem { Key = k, Name = name ?? Convert.ToString(k) };
        }
    }
}
