using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens
{
    public enum OrigenEntrada { Ctor, CtorObj, Buscar, BuscarObj, Prop, Save }

    /// <summary>Un dato que el usuario completa y que se traslada al Manager (argumento de constructor, de Buscar/Save o propiedad).</summary>
    public class Entrada
    {
        public FieldSchema Campo { get; set; }
        public OrigenEntrada Origen { get; set; }
        public int Indice { get; set; }
        public PropertyInfo Prop { get; set; }
        /// <summary>Propiedad del Manager que contiene el objeto con Prop (null = el propio Manager).</summary>
        public PropertyInfo Contenedor { get; set; }
        /// <summary>El valor es una entidad referenciada solo por su Id (ej. SeguridadUsuarios).</summary>
        public Type Entidad { get; set; }
        public Type Tipo { get; set; }
    }

    /// <summary>Pantallas que no siguen la convención estática Buscar(ParametrosBusquedas): informes, listas de detalle de un padre y procesos.</summary>
    public class AuxDef
    {
        public ConstructorInfo Ctor { get; set; }
        public MethodInfo Buscar { get; set; }
        public PropertyInfo ResultadoProp { get; set; }
        public FieldInfo ResultadoCampo { get; set; }
        public PropertyInfo ResultadoContenedor { get; set; }
        public bool Estatico { get; set; }
        /// <summary>Grillas editables (ej. actualización masiva de precios): propiedad bool de selección, propiedades editables y clave de la fila.</summary>
        public string Selector { get; set; }
        public List<string> Editables { get; set; } = new List<string>();
        public string Clave { get; set; } = "Id";
        public object LeerResultado(object mgr) => ResultadoContenedor != null ? ResultadoProp.GetValue(ResultadoContenedor.GetValue(mgr)) : ResultadoProp != null ? ResultadoProp.GetValue(mgr) : ResultadoCampo?.GetValue(mgr);
        public Type ResultType { get; set; }
        public MethodInfo EliminarMetodo { get; set; }
        public Type EliminarTipo { get; set; }
        public List<Entrada> Entradas { get; set; } = new List<Entrada>();
        public Dictionary<string, Type> LookupsEntidad { get; set; } = new Dictionary<string, Type>();
        public List<PropertyInfo> LookupsParametros { get; set; } = new List<PropertyInfo>();
        public Type ParametrosType { get; set; }
        public bool PuedeBuscar => Buscar != null || ResultadoProp != null || ResultadoCampo != null;
    }

    public partial class ScreenCatalog
    {
        private static readonly string[] NombresResultado = { "Resultado", "ListResult", "Cotizaciones", "Lista", "ListaProductos" };

        private static bool EsEntidadRef(Type t) =>
            t.IsClass && t != typeof(string) && t.GetProperty("Id") != null && t.GetConstructor(Type.EmptyTypes) != null;

        private static bool EsObjetoParametros(Type t) =>
            t.IsClass && t != typeof(string) && !typeof(IEnumerable).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null
            && t.GetProperty("Id") == null && PropiedadesEscalares(t).Any(p => p.CanWrite);

        private static bool ParametroSoportado(Type t) => EsEscalar(t) || EsEntidadRef(t) || EsObjetoParametros(t);

        private FieldSchema CampoDeParametro(string name, Type type, bool tieneDefault, object def)
        {
            var u = Nullable.GetUnderlyingType(type) ?? type;
            var f = new FieldSchema
            {
                Name = name,
                Label = SepararPalabras(Regex.Replace(name, "^_?Id_?(?=[A-Z])", "")),
                Type = Tipo(u),
                Nullable = !type.IsValueType || Nullable.GetUnderlyingType(type) != null,
                Required = type.IsValueType && Nullable.GetUnderlyingType(type) == null && u != typeof(bool),
                Sensitive = Sensible.IsMatch(name),
                Default = tieneDefault ? ValueConverter.ToJson(def) : null
            };
            if (u.IsEnum)
                f.Options = Enum.GetValues(u).Cast<Enum>().Select(e => new LookupItem { Key = Convert.ToInt64(e), Name = Enums.GetDescription(e) }).ToList();
            return f;
        }

        /// <summary>Agrega a la lista los campos de los argumentos de un método o constructor.</summary>
        private bool AgregarArgumentos(AuxDef a, ParameterInfo[] ps, OrigenEntrada simple, OrigenEntrada objeto)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                var p = ps[i];
                var t = p.ParameterType;
                if (!ParametroSoportado(t)) { if (p.IsOptional) continue; return false; }
                if (EsEscalar(t))
                    a.Entradas.Add(new Entrada { Campo = CampoDeParametro(p.Name, t, p.HasDefaultValue, p.DefaultValue), Origen = simple, Indice = i, Tipo = t });
                else if (EsEntidadRef(t))
                {
                    a.LookupsEntidad[t.Name] = t;
                    a.Entradas.Add(new Entrada
                    {
                        Campo = new FieldSchema { Name = "Id_" + t.Name, Label = SepararPalabras(t.Name), Type = "int", Required = true, Lookup = "Entidad." + t.Name },
                        Origen = simple, Indice = i, Entidad = t, Tipo = t
                    });
                }
                else
                {
                    a.ParametrosType = t;
                    foreach (var f in Campos(t, paraFormulario: false, esParametro: true))
                        a.Entradas.Add(new Entrada { Campo = f, Origen = objeto, Indice = i, Prop = t.GetProperty(f.Name), Tipo = t });
                }
            }
            return true;
        }

        /// <summary>Elige el constructor "simple" con menos parámetros (escalares, entidades por Id u objetos de parámetros).</summary>
        private ConstructorInfo ElegirCtor(Type t) =>
            t.GetConstructors().Where(c => c.GetParameters().All(p => ParametroSoportado(p.ParameterType)))
                .OrderBy(c => c.GetParameters().Length).FirstOrDefault();

        /// <summary>Parámetros Id_Xxx de pantallas auxiliares que no tienen lista propia: se llenan con los registros de la pantalla Xxx.</summary>
        private void AsignarLookupsPantallas()
        {
            var porNombre = _screens.Values.Where(s => s.Tipo == "normal" && s.Buscar != null).GroupBy(s => Normalizar(s.Key)).ToDictionary(g => g.Key, g => g.First().Key);
            foreach (var d in _screens.Values.Where(s => s.Aux != null && s.Tipo != "normal"))
                foreach (var c in d.Parametros.Concat(d.ParametrosGuardar).Where(c => c.Lookup == null && c.Type == "int" && Regex.IsMatch(c.Name, "^_?Id_?[A-Z]")))
                {
                    var x = Regex.Replace(c.Name, "^_?Id_?", "");
                    var pref = Regex.Match(d.Key, "^[A-Z][a-z]+").Value;
                    var x2 = Regex.Replace(x, "(Origen|Destino)$", "");
                    if (porNombre.TryGetValue(Normalizar(pref + x), out var k) || porNombre.TryGetValue(Normalizar(x), out k)
                        || porNombre.TryGetValue(Normalizar(pref + x2), out k) || porNombre.TryGetValue(Normalizar(x2), out k)) c.Lookup = "Pantalla." + k;
                }
        }

        private static void AsignarLookupsAux(ScreenDescriptor d)
        {
            var a = d.Aux;
            if (a == null) return;
            foreach (var c in d.Parametros.Where(c => c.Lookup == null && c.Type == "int" && Regex.IsMatch(c.Name, "^Id_?[A-Z]")))
            {
                var x = Normalizar(Regex.Replace(c.Name, "^Id_?", ""));
                var l = a.LookupsParametros.FirstOrDefault(p => Normalizar(p.Name) == x);
                if (l != null) c.Lookup = "Param." + l.Name;
            }
        }

        private static Type ColeccionElemento(Type t) =>
            t.IsGenericType && typeof(IEnumerable).IsAssignableFrom(t) ? t.GetGenericArguments()[0] : null;

        /// <summary>Informes y listas dependientes de un padre cuyo Buscar es de instancia (o que dejan el resultado en una propiedad).</summary>
        private AuxDef DetectarConsulta(Type t)
        {
            var a = new AuxDef { Ctor = ElegirCtor(t) };
            if (a.Ctor == null && t.GetConstructors().Length > 0) return null;

            var props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            a.Buscar = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault(m =>
                m.Name == "Buscar" && !m.ContainsGenericParameters && m.GetParameters().All(p => ParametroSoportado(p.ParameterType) || p.IsOptional)
                && (typeof(IEnumerable).IsAssignableFrom(m.ReturnType) && m.ReturnType != typeof(string) || m.ReturnType == typeof(void)));
            if (a.Buscar != null && a.Buscar.ReturnType != typeof(void))
                a.ResultType = ElementType(a.Buscar.ReturnType);
            else
            {
                var rp = props.Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && ColeccionElemento(p.PropertyType) is Type e
                                          && (Array.IndexOf(NombresResultado, p.Name) >= 0 || e.Name == "SearchResult"))
                    .OrderBy(p => Array.IndexOf(NombresResultado, p.Name) < 0 ? 99 : Array.IndexOf(NombresResultado, p.Name)).FirstOrDefault();
                if (rp != null)
                {
                    a.ResultadoProp = rp;
                    a.ResultType = ColeccionElemento(rp.PropertyType);
                }
                else
                {
                    var rf = t.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(f => ColeccionElemento(f.FieldType) is Type e
                                          && (Array.IndexOf(NombresResultado, f.Name) >= 0 || e.Name == "SearchResult")).FirstOrDefault();
                    if (rf == null) return null;
                    a.ResultadoCampo = rf;
                    a.ResultType = ColeccionElemento(rf.FieldType);
                }
            }
            if (a.Buscar == null && a.ResultadoProp == null && a.ResultadoCampo == null) return null;
            if (a.Buscar != null && a.Buscar.IsStatic) { a.Estatico = true; a.Ctor = null; }
            if (a.Ctor == null && a.Buscar == null) return null;

            if (a.Ctor != null && !AgregarArgumentos(a, a.Ctor.GetParameters(), OrigenEntrada.Ctor, OrigenEntrada.CtorObj)) return null;
            if (a.Buscar != null && !AgregarArgumentos(a, a.Buscar.GetParameters(), OrigenEntrada.Buscar, OrigenEntrada.BuscarObj)) return null;

            // Parámetros como propiedad del Manager (ej. SucursalesManager.Parametros)
            var pp = props.FirstOrDefault(p => p.Name == "Parametros" && p.CanRead && EsObjetoParametros(p.PropertyType));
            if (pp != null && a.ParametrosType == null)
            {
                a.ParametrosType = pp.PropertyType;
                foreach (var f in Campos(pp.PropertyType, paraFormulario: false, esParametro: true))
                    a.Entradas.Add(new Entrada { Campo = f, Origen = OrigenEntrada.Prop, Prop = pp.PropertyType.GetProperty(f.Name), Contenedor = pp, Tipo = pp.PropertyType });
            }

            // Combos definidos como listas dentro del objeto de parámetros (ej. ParametrosBusquedas.Productos)
            if (a.ParametrosType != null)
                a.LookupsParametros = a.ParametrosType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && ColeccionElemento(p.PropertyType) is Type e && LookupItem.Soporta(e)).ToList();

            var sel = a.ResultType == null ? null : new[] { "Seleccionado", "Selected" }.FirstOrDefault(n => a.ResultType.GetProperty(n)?.PropertyType == typeof(bool));
            if (sel != null)
            {
                a.Selector = sel;
                a.Editables = a.ResultType.GetProperties().Where(x => x.CanWrite && x.Name.StartsWith("Nuevo") && EsEscalar(x.PropertyType)).Select(x => x.Name).ToList();
                a.Clave = a.ResultType.GetProperty("Id_Objeto") != null ? "Id_Objeto" : "Id";
            }

            // Nombres de campo repetidos: queda el primero
            a.Entradas = a.Entradas.GroupBy(e => e.Campo.Name).Select(g => g.First()).ToList();
            return a;
        }

        /// <summary>Procesos sin grilla: un formulario de datos y un Save (ej. cambio de clave, copiar medidas).</summary>
        private AuxDef DetectarProceso(Type t, MethodInfo save)
        {
            var ctor = save.IsStatic ? null : ElegirCtor(t);
            if (!save.IsStatic && ctor == null && t.GetConstructors().Length > 0) return null;
            var a = new AuxDef { Ctor = ctor, Estatico = save.IsStatic };
            if (ctor != null && !AgregarArgumentos(a, ctor.GetParameters(), OrigenEntrada.Ctor, OrigenEntrada.CtorObj)) return null;
            if (ctor != null && ctor.GetParameters().Any(p => EsEntidadRef(p.ParameterType))) return null;

            var props = save.IsStatic ? new List<PropertyInfo>() : t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(p => p.CanRead && p.GetSetMethod() != null && p.GetIndexParameters().Length == 0).ToList();
            foreach (var p in props.Where(p => EsEscalar(p.PropertyType)))
                a.Entradas.Add(new Entrada { Campo = CampoDeParametro(p.Name, p.PropertyType, false, null), Origen = OrigenEntrada.Prop, Prop = p, Tipo = p.PropertyType });
            foreach (var c in props.Where(p => EsObjetoParametros(p.PropertyType)))
            {
                // Objetos con colecciones (ej. vales a seleccionar) necesitan una grilla propia: no se pueden completar con un formulario
                var lista = c.PropertyType.GetProperties().FirstOrDefault(p => ColeccionElemento(p.PropertyType) is Type el && el.GetProperty("Seleccionado")?.PropertyType == typeof(bool));
                if (lista != null && save.GetParameters().Length == 0)
                {
                    a.ResultadoContenedor = c; a.ResultadoProp = lista;
                    a.ResultType = ColeccionElemento(lista.PropertyType);
                    a.Selector = "Seleccionado"; a.Clave = "Id";
                }
                else if (c.PropertyType.GetProperties().Any(p => ColeccionElemento(p.PropertyType) != null && p.PropertyType != typeof(string))) return null;
                foreach (var f in Campos(c.PropertyType, paraFormulario: false, esParametro: true))
                    a.Entradas.Add(new Entrada { Campo = f, Origen = OrigenEntrada.Prop, Prop = c.PropertyType.GetProperty(f.Name), Contenedor = c, Tipo = c.PropertyType });
            }
            var sp = save.GetParameters();
            for (int i = 0; i < sp.Length; i++)
                a.Entradas.Add(new Entrada { Campo = CampoDeParametro(sp[i].Name, sp[i].ParameterType, sp[i].HasDefaultValue, sp[i].DefaultValue), Origen = OrigenEntrada.Save, Indice = i, Tipo = sp[i].ParameterType });
            a.Entradas = a.Entradas.GroupBy(e => e.Campo.Name).Select(g => g.First()).ToList();
            return a.Entradas.Count == 0 ? null : a;
        }

        /// <summary>Procesos que no se llaman Save (ej. ActualizarUtilidadMasivo, ActualizarStock): método público de acción con parámetros simples.</summary>
        private static MethodInfo BuscarMetodoAccion(Type t) =>
            t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName && Regex.IsMatch(m.Name, "^(Actualizar|Procesar|Ejecutar|Generar)") && !m.ContainsGenericParameters
                            && m.GetParameters().All(p => EsEscalar(p.ParameterType)))
                .OrderBy(m => m.GetParameters().Length).FirstOrDefault();

        private void CompletarEliminarHijo(ScreenDescriptor d, Type t)
        {
            var m = t.GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(x =>
                x.Name == "Eliminar" && x.GetParameters().Length == 1 && EsEntidadRef(x.GetParameters()[0].ParameterType));
            if (m == null) return;
            d.Aux.EliminarMetodo = m;
            d.Aux.EliminarTipo = m.GetParameters()[0].ParameterType;
        }
    }
}
