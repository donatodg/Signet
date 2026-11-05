using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens
{
    /// <summary>Pantallas auxiliares: informes, listas dependientes de un padre, altas y procesos.</summary>
    public partial class ScreenService
    {
        private static object Valor(JObject v, Entrada e)
        {
            var tok = v?[e.Campo.Name];
            if (tok == null || tok.Type == JTokenType.Null || (tok.Type == JTokenType.String && (string)tok == "" && e.Tipo != typeof(string)))
            {
                if (e.Campo.Default != null) return ValueConverter.FromJson(JToken.FromObject(e.Campo.Default), e.Tipo);
                return e.Tipo.IsValueType && Nullable.GetUnderlyingType(e.Tipo) == null ? Activator.CreateInstance(e.Tipo) : null;
            }
            try { return ValueConverter.FromJson(tok, e.Tipo); }
            catch (Exception) { throw new ApiException(400, "Valor inválido para '" + e.Campo.Label + "'."); }
        }

        private static object[] ArgumentosAux(AuxDef a, ParameterInfo[] ps, OrigenEntrada simple, OrigenEntrada objeto, JObject v)
        {
            var args = new object[ps.Length];
            for (int i = 0; i < ps.Length; i++)
            {
                var es = a.Entradas.Where(e => e.Indice == i && (e.Origen == simple || e.Origen == objeto)).ToList();
                if (es.Count == 0) { args[i] = ps[i].HasDefaultValue ? ps[i].DefaultValue : Type.Missing; if (args[i] == null && ps[i].ParameterType.IsValueType) args[i] = Activator.CreateInstance(ps[i].ParameterType); continue; }
                var first = es[0];
                if (first.Origen == objeto)
                {
                    var o = Activator.CreateInstance(ps[i].ParameterType);
                    foreach (var e in es) if (e.Prop != null && e.Prop.CanWrite) e.Prop.SetValue(o, Valor(v, e));
                    args[i] = o;
                }
                else if (first.Entidad != null)
                {
                    var o = Activator.CreateInstance(first.Entidad);
                    var id = Valor(v, new Entrada { Campo = first.Campo, Tipo = typeof(int) });
                    first.Entidad.GetProperty("Id").SetValue(o, id);
                    args[i] = o;
                }
                else args[i] = Valor(v, first);
            }
            return args;
        }

        private static object CrearManagerAux(ScreenDescriptor d, JObject v)
        {
            var a = d.Aux;
            if (a.Estatico) return null;
            object mgr = a.Ctor != null
                ? Invocar(() => a.Ctor.Invoke(ArgumentosAux(a, a.Ctor.GetParameters(), OrigenEntrada.Ctor, OrigenEntrada.CtorObj, v)))
                : Activator.CreateInstance(d.ManagerType);
            foreach (var e in a.Entradas.Where(e => e.Origen == OrigenEntrada.Prop))
            {
                object destino = mgr;
                if (e.Contenedor != null)
                {
                    destino = e.Contenedor.GetValue(mgr);
                    if (destino == null)
                    {
                        destino = Activator.CreateInstance(e.Contenedor.PropertyType);
                        if (e.Contenedor.CanWrite) e.Contenedor.SetValue(mgr, destino);
                    }
                }
                if (e.Prop != null && e.Prop.CanWrite) e.Prop.SetValue(destino, Valor(v, e));
            }
            return mgr;
        }

        private static IEnumerable LeerResultadoAux(ScreenDescriptor d, object mgr, JObject parametros)
        {
            var a = d.Aux;
            if (a.Buscar == null) return a.LeerResultado(mgr) as IEnumerable;
            var args = ArgumentosAux(a, a.Buscar.GetParameters(), OrigenEntrada.Buscar, OrigenEntrada.BuscarObj, parametros);
            var r = Invocar(() => a.Buscar.Invoke(a.Estatico ? null : mgr, BindingFlags.OptionalParamBinding, null, args, null));
            return a.Buscar.ReturnType == typeof(void) ? a.LeerResultado(mgr) as IEnumerable : r as IEnumerable;
        }

        /// <summary>Grillas editables: recarga la lista con el Manager, aplica las marcas/valores del usuario y ejecuta su Save().</summary>
        public object GuardarEdicion(string key, JObject alcance, JArray filas)
        {
            var d = _catalog.Get(key);
            if (!d.PuedeGuardarGrilla) throw new ApiException(400, "La pantalla no permite guardar.");
            ExigirPermiso(d, Enums.Accion.Modificar);
            var a = d.Aux;
            var mgr = CrearManagerAux(d, alcance);
            try
            {
                var lista = LeerResultadoAux(d, mgr, alcance);
                var clave = d.ResultType.GetProperty(a.Clave);
                var sel = d.ResultType.GetProperty(a.Selector);
                var porClave = new Dictionary<string, object>();
                if (lista != null) foreach (var o in lista) if (o != null) porClave[Convert.ToString(clave.GetValue(o))] = o;
                int marcados = 0;
                foreach (var f in (filas ?? new JArray()).OfType<JObject>())
                {
                    if (!porClave.TryGetValue(Convert.ToString((string)f["k"]), out var item)) continue;
                    var on = f["sel"] != null && f["sel"].Type == JTokenType.Boolean && (bool)f["sel"];
                    sel.SetValue(item, on);
                    if (on) marcados++;
                    foreach (var n in a.Editables)
                        if (f.TryGetValue(n, StringComparison.Ordinal, out var tok) && tok.Type != JTokenType.Null)
                        {
                            var pr = d.ResultType.GetProperty(n);
                            try { pr.SetValue(item, ValueConverter.FromJson(tok, pr.PropertyType)); }
                            catch (Exception) { throw new ApiException(400, "Valor inválido para '" + ScreenCatalog.SepararPalabras(n) + "'."); }
                        }
                }
                var r = Invocar(() => d.Save.Invoke(mgr, new object[0]));
                var n2 = r is int i ? i : marcados;
                return new { ok = true, mensaje = "Se guardaron los cambios (" + n2 + " registro(s))." };
            }
            finally { (mgr as IDisposable)?.Dispose(); }
        }

        private object BuscarAux(ScreenDescriptor d, JObject parametros)
        {
            var a = d.Aux;
            var mgr = CrearManagerAux(d, parametros);
            try
            {
                IEnumerable result;
                result = LeerResultadoAux(d, mgr, parametros);

                var props = ScreenCatalog.PropiedadesEscalares(d.ResultType).Where(x => d.Columnas.Any(c => c.Name == x.Name)).ToList();
                var filas = new List<Dictionary<string, object>>();
                bool truncado = false;
                if (result != null)
                    foreach (var o in result)
                    {
                        if (o == null) continue;
                        if (filas.Count >= _options.MaxFilasBusqueda) { truncado = true; break; }
                        filas.Add(ValueConverter.ToDictionary(o, props));
                    }
                return new { filas, truncado };
            }
            finally { (mgr as IDisposable)?.Dispose(); }
        }

        private List<LookupItem> ListaDePadre(Type entidad) =>
            ListaDePantalla(_catalog.All.FirstOrDefault(x => x.Tipo == "normal" && x.Buscar != null && x.ParametrosType != null && (x.EntityType == entidad || x.ResultType == entidad)));

        private List<LookupItem> ListaDePantalla(ScreenDescriptor padre)
        {
            if (padre == null) return new List<LookupItem>();
            try
            {
                var p = Activator.CreateInstance(padre.ParametrosType);
                var args = new object[padre.Buscar.GetParameters().Length];
                args[0] = p;
                for (int i = 1; i < args.Length; i++) args[i] = Type.Missing;
                var res = (IEnumerable)Invocar(() => padre.Buscar.Invoke(null, BindingFlags.OptionalParamBinding, null, args, null));
                return res == null ? new List<LookupItem>() : res.Cast<object>().Where(o => o != null).Take(5000).Select(LookupItem.From).ToList();
            }
            catch (Exception) { return new List<LookupItem>(); }
        }

        private Dictionary<string, List<LookupItem>> LookupsAux(ScreenDescriptor d, JObject valores, string[] nombres = null)
        {
            var r = new Dictionary<string, List<LookupItem>>();
            var a = d.Aux;
            if (a == null) return r;
            foreach (var kv in a.LookupsEntidad) r["Entidad." + kv.Key] = ListaDePadre(kv.Value);
            foreach (var c in d.Parametros.Concat(d.ParametrosGuardar).Where(c => c.Lookup != null && c.Lookup.StartsWith("Pantalla.")))
                r[c.Lookup] = ListaDePantalla(_catalog.All.FirstOrDefault(x => x.Key == c.Lookup.Substring(9)));

            if (a.ParametrosType != null && a.LookupsParametros.Count > 0)
                try
                {
                    var p = Activator.CreateInstance(a.ParametrosType);
                    foreach (var lp in a.LookupsParametros)
                    {
                        var l = lp.GetValue(p) as IEnumerable;
                        r["Param." + lp.Name] = l == null ? new List<LookupItem>() : l.Cast<object>().Where(o => o != null).Select(LookupItem.From).ToList();
                    }
                }
                catch (Exception) { }

            object mgr = null;
            try
            {
                if (d.LookupProperties.Count > 0 || d.LookupFuentes.Count > 0)
                {
                    try { mgr = CrearManagerAux(d, valores ?? new JObject()); } catch (Exception) { mgr = null; }
                    foreach (var kv in LeerLookups(d, mgr, nombres)) r[kv.Key] = kv.Value;
                }
            }
            finally { (mgr as IDisposable)?.Dispose(); }
            return r;
        }

        public object LookupsDependientesAux(string key, JObject valores)
        {
            var d = _catalog.Get(key);
            ExigirPermiso(d, Enums.Accion.Ingresar);
            return LookupsAux(d, valores);
        }

        public object AgregarHijo(string key, JObject alcance, JObject opciones)
        {
            var d = _catalog.Get(key);
            if (!d.PuedeAgregarHijo) throw new ApiException(400, "La pantalla no permite agregar registros.");
            ExigirPermiso(d, Enums.Accion.Agregar);
            var mgr = CrearManagerAux(d, alcance);
            try
            {
                var args = d.Save.GetParameters().Select(p =>
                {
                    var tok = opciones?[p.Name];
                    if ((tok == null || tok.Type == JTokenType.Null) && p.HasDefaultValue) return p.DefaultValue;
                    try { return ValueConverter.FromJson(tok, p.ParameterType); }
                    catch (Exception) { throw new ApiException(400, "Valor inválido para '" + ScreenCatalog.SepararPalabras(p.Name) + "'."); }
                }).ToArray();
                Invocar(() => d.Save.Invoke(mgr, args));
                return new { ok = true };
            }
            finally { (mgr as IDisposable)?.Dispose(); }
        }

        public void EliminarHijo(ScreenDescriptor d, int id)
        {
            ExigirPermiso(d, Enums.Accion.Eliminar);
            var entidad = Activator.CreateInstance(d.Aux.EliminarTipo);
            d.Aux.EliminarTipo.GetProperty("Id").SetValue(entidad, id);
            Invocar(() => d.Aux.EliminarMetodo.Invoke(null, new[] { entidad }));
        }

        public object Procesar(string key, JObject valores)
        {
            var d = _catalog.Get(key);
            if (d.Tipo != "proceso") throw new ApiException(400, "La pantalla no es un proceso.");
            ExigirPermiso(d, Enums.Accion.Ingresar);
            if (d.Personalizado != null)
            {
                var pr = (Acciones.AccionResultado)Invocar(() => d.Personalizado(valores ?? new JObject()));
                return new { ok = true, mensaje = pr.Mensaje, html = pr.Html, pdf = pr.Pdf, archivo = pr.Archivo, tablas = pr.Tablas, navegar = pr.Navegar };
            }
            var mgr = CrearManagerAux(d, valores);
            try
            {
                var ps = d.Save.GetParameters();
                var args = new object[ps.Length];
                for (int i = 0; i < ps.Length; i++)
                {
                    var e = d.Aux.Entradas.FirstOrDefault(x => x.Origen == OrigenEntrada.Save && x.Indice == i);
                    args[i] = e != null ? Valor(valores, e) : (ps[i].HasDefaultValue ? ps[i].DefaultValue : null);
                }
                var r = Invocar(() => d.Save.Invoke(d.Save.IsStatic ? null : mgr, args));
                var msg = r as string;
                if (string.IsNullOrWhiteSpace(msg)) msg = "Proceso ejecutado correctamente." + (r != null && !(r is string) ? " Resultado: " + Convert.ToString(r, System.Globalization.CultureInfo.CurrentCulture) : "");
                return new { ok = true, mensaje = msg };
            }
            finally { (mgr as IDisposable)?.Dispose(); }
        }
    
        private static string DescripcionPantalla(ScreenDescriptor d)
        {
            if (d.DescripcionDinamica == null) return null;
            try { return d.DescripcionDinamica(); }
            catch (Exception ex) { return "No se pudo obtener el estado: " + (ex.InnerException ?? ex).Message; }
        }
    }
}