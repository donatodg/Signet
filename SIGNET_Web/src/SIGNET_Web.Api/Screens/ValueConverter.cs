using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace SIGNET_Web.Api.Screens
{
    public static class ValueConverter
    {
        public static object ToJson(object v)
        {
            switch (v)
            {
                case null: return null;
                case Enum e: return Convert.ToInt64(e);
                case byte[] _: return null;
                case TimeSpan ts: return ts.ToString("c");
                case Guid g: return g.ToString();
                case char c: return c.ToString();
                default: return v;
            }
        }

        public static Dictionary<string, object> ToDictionary(object o, IEnumerable<PropertyInfo> props, Func<PropertyInfo, bool> incluir = null)
        {
            var d = new Dictionary<string, object>();
            foreach (var p in props)
            {
                if (incluir != null && !incluir(p)) continue;
                object v;
                try { v = p.GetValue(o); } catch (Exception) { v = null; }
                d[p.Name] = ToJson(v);
            }
            return d;
        }

        public static object FromJson(JToken token, Type type)
        {
            var u = Nullable.GetUnderlyingType(type);
            bool nullable = !type.IsValueType || u != null;
            var target = u ?? type;

            if (token == null || token.Type == JTokenType.Null || token.Type == JTokenType.Undefined
                || (token.Type == JTokenType.String && string.IsNullOrWhiteSpace((string)token) && target != typeof(string)))
                return nullable ? null : Activator.CreateInstance(type);

            if (target == typeof(string)) return token.Type == JTokenType.String ? (string)token : token.ToString();
            if (target.IsEnum)
            {
                if (token.Type == JTokenType.String && !long.TryParse((string)token, out _)) return Enum.Parse(target, (string)token, true);
                return Enum.ToObject(target, Convert.ToInt64(token.ToObject<object>(), CultureInfo.InvariantCulture));
            }
            if (target == typeof(DateTime))
            {
                if (token.Type == JTokenType.Date) return token.ToObject<DateTime>();
                var s = (string)token;
                if (DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)) return d;
                return DateTime.Parse(s, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }
            if (target == typeof(TimeSpan)) return TimeSpan.Parse((string)token, CultureInfo.InvariantCulture);
            if (target == typeof(Guid)) return Guid.Parse((string)token);
            if (target == typeof(bool) && token.Type == JTokenType.String) return bool.Parse((string)token);
            if (target.IsPrimitive || target == typeof(decimal))
            {
                if (token.Type == JTokenType.String)
                    return Convert.ChangeType(decimal.Parse(((string)token).Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture), target, CultureInfo.InvariantCulture);
                return Convert.ChangeType(token.ToObject<object>(), target, CultureInfo.InvariantCulture);
            }
            return token.ToObject(type);
        }
    }
}
