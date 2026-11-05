using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace VENET_Contabilidad_BL
{
    public static class MotorContable
    {
        public static void ValidarConfiguracion(ConfiguracionContable c)
        {
            if (c == null || c.Empresa <= 0 || c.MonedaBase <= 0 || c.Plantillas == null || c.Asignaciones == null)
                throw new ValidationException("Configuracion contable incompleta.");
            if (c.Plantillas.Count > 200 || c.Asignaciones.Count > 20000)
                throw new ValidationException("La configuracion excede el limite de plantillas o asignaciones.");
            if (c.Plantillas.Any(p => p == null || string.IsNullOrWhiteSpace(p.Codigo) || p.Codigo.Length > 40
                || string.IsNullOrWhiteSpace(p.Nombre) || p.Nombre.Length > 200
                || !Enum.IsDefined(typeof(OperatoriaContable), p.Operatoria)
                || p.Desde.Year < 1753 || p.Hasta < p.Desde || p.Sucursal <= 0 || p.TipoComprobante <= 0
                || p.Reglas == null || p.Reglas.Count < 2 || p.Reglas.Count > 100))
                throw new ValidationException("Revise codigo, nombre, vigencia, filtros y reglas de las plantillas.");
            if (c.Plantillas.GroupBy(p => p.Codigo, StringComparer.OrdinalIgnoreCase).Any(g => g.Count() > 1))
                throw new ValidationException("El codigo de plantilla debe ser unico dentro de cada version.");
            foreach (var p in c.Plantillas)
            {
                if ((p.Operatoria == OperatoriaContable.Venta || p.Operatoria == OperatoriaContable.Compra
                    || p.Operatoria == OperatoriaContable.CostoVentaAutomatico) && !p.TipoComprobante.HasValue)
                    throw new ValidationException("Ventas, compras y costo automatico requieren un tipo de comprobante explicito; configure notas de credito con Invertir.");
                if (!p.Reglas.Any(r => r != null && r.Lado == LadoContable.Debe)
                    || !p.Reglas.Any(r => r != null && r.Lado == LadoContable.Haber))
                    throw new ValidationException("Cada plantilla necesita reglas de Debe y Haber.");
                foreach (var r in p.Reglas)
                {
                    if (r == null || !Enum.IsDefined(typeof(OrigenContable), r.Origen)
                        || !Enum.IsDefined(typeof(MagnitudContable), r.Magnitud) || !Enum.IsDefined(typeof(LadoContable), r.Lado)
                        || r.Factor <= 0 || r.Factor > 100 || r.Producto <= 0 || r.Categoria <= 0 || r.Impuesto <= 0 || r.FormaPago <= 0
                        || r.Concepto <= 0 || r.Caja <= 0)
                        throw new ValidationException("Regla contable invalida.");
                    if (r.CuentaFija.HasValue)
                    {
                        if (r.CuentaFija <= 0 || !string.IsNullOrEmpty(r.Rol) || r.Prioridad == null || r.Prioridad.Count != 0)
                            throw new ValidationException("Use una cuenta fija o un rol con prioridades, no ambos.");
                    }
                    else if (string.IsNullOrWhiteSpace(r.Rol) || r.Rol.Length > 60 || r.Prioridad == null || r.Prioridad.Count == 0
                        || r.Prioridad.Distinct().Count() != r.Prioridad.Count || r.Prioridad.Any(d => !Enum.IsDefined(typeof(DimensionCuenta), d)))
                        throw new ValidationException("Indique un rol y un orden de resolucion de cuentas valido.");
                    if (r.Magnitud == MagnitudContable.Costo && r.Origen != OrigenContable.Productos)
                        throw new ValidationException("El costo se obtiene exclusivamente de partidas de producto.");
                    if ((r.Magnitud == MagnitudContable.SaldoDeudor || r.Magnitud == MagnitudContable.SaldoAcreedor
                        || r.Prioridad.Contains(DimensionCuenta.CuentaOrigen)) && r.Origen != OrigenContable.Saldos)
                        throw new ValidationException("Saldos y CuentaOrigen requieren el origen Saldos.");
                }
            }
            if (c.Asignaciones.Any(a => a == null || string.IsNullOrWhiteSpace(a.Rol) || a.Rol.Length > 60
                || !Enum.IsDefined(typeof(DimensionCuenta), a.Dimension) || a.Referencia <= 0 || a.Cuenta <= 0
                || a.Dimension == DimensionCuenta.Empresa && a.Referencia != c.Empresa))
                throw new ValidationException("Asignacion de cuenta invalida.");
            if (c.Asignaciones.GroupBy(a => new { Rol = a.Rol.ToUpperInvariant(), a.Dimension, a.Referencia }).Any(g => g.Count() > 1))
                throw new ValidationException("Hay asignaciones duplicadas para el mismo rol y dimension.");
        }

        public static SimulacionContable Simular(ConfiguracionContable config, HechoContable hecho, ISet<int> cuentasImputables)
        {
            ValidarConfiguracion(config);
            if (hecho == null || hecho.Empresa != config.Empresa || hecho.Documento <= 0 || hecho.Fecha.Year < 1753
                || hecho.Partidas == null || !Enum.IsDefined(typeof(OperatoriaContable), hecho.Operatoria))
                throw new ValidationException("El hecho contable no es valido para esta empresa.");
            var plantillas = config.Plantillas.Where(p => p.Operatoria == hecho.Operatoria && p.Desde.Date <= hecho.Fecha.Date
                && (!p.Hasta.HasValue || p.Hasta.Value.Date >= hecho.Fecha.Date)
                && (!p.TipoComprobante.HasValue || p.TipoComprobante == hecho.TipoComprobante)
                && (!p.Sucursal.HasValue || p.Sucursal == hecho.Sucursal)).OrderBy(p => p.Codigo, StringComparer.Ordinal).ToList();
            if (plantillas.Count == 0) throw new ValidationException("No hay plantillas vigentes para esta operatoria y documento.");
            var asientos = new List<AsientoPropuesto>();
            foreach (var p in plantillas)
            {
                var asiento = new AsientoPropuesto { Plantilla = p.Codigo, Descripcion = p.Nombre };
                for (int i = 0; i < p.Reglas.Count; i++)
                {
                    var regla = p.Reglas[i];
                    var partidas = regla.Origen == OrigenContable.Cabecera
                        ? new[] { new PartidaOrigen { Origen = OrigenContable.Cabecera, Referencia = "Cabecera", Total = hecho.Total,
                            Neto = hecho.Neto, Iva = hecho.Iva, Importe = hecho.Total, FormaPago = hecho.FormaPago } }
                        : hecho.Partidas.Where(d => d.Origen == regla.Origen);
                    foreach (var d in partidas.Where(d => (!regla.Producto.HasValue || regla.Producto == d.Producto)
                        && (!regla.Categoria.HasValue || regla.Categoria == d.Categoria)
                        && (!regla.Impuesto.HasValue || regla.Impuesto == d.Impuesto)
                        && (!regla.Concepto.HasValue || regla.Concepto == d.Concepto)
                        && (!regla.Caja.HasValue || regla.Caja == d.Caja)
                        && (!regla.FormaPago.HasValue || regla.FormaPago == (d.FormaPago ?? hecho.FormaPago))))
                    {
                        decimal valor;
                        switch (regla.Magnitud)
                        {
                            case MagnitudContable.Total: valor = d.Total; break;
                            case MagnitudContable.Neto: valor = d.Neto; break;
                            case MagnitudContable.Iva: valor = d.Iva; break;
                            case MagnitudContable.Importe: valor = d.Importe; break;
                            case MagnitudContable.Costo: valor = d.Costo ?? throw new ValidationException("No hay costo historico para " + d.Referencia + "."); break;
                            case MagnitudContable.SaldoDeudor: valor = d.SaldoDeudor; break;
                            case MagnitudContable.SaldoAcreedor: valor = d.SaldoAcreedor; break;
                            default: throw new ValidationException("Magnitud no soportada.");
                        }
                        valor = Math.Round(checked(valor * regla.Factor), 2, MidpointRounding.AwayFromZero);
                        if (p.Invertir) valor = -valor;
                        if (Math.Abs(valor) > 2147483647m) throw new ValidationException("El importe excede el limite del asiento.");
                        if (valor == 0) continue;
                        var resolucion = "Cuenta fija";
                        int? cuenta = regla.CuentaFija;
                        if (!cuenta.HasValue)
                            foreach (var dimension in regla.Prioridad)
                            {
                                int? referencia;
                                switch (dimension)
                                {
                                    case DimensionCuenta.Empresa: referencia = hecho.Empresa; break;
                                    case DimensionCuenta.Producto: referencia = d.Producto; break;
                                    case DimensionCuenta.Categoria: referencia = d.Categoria; break;
                                    case DimensionCuenta.Cliente: referencia = hecho.Cliente; break;
                                    case DimensionCuenta.Proveedor: referencia = hecho.Proveedor; break;
                                    case DimensionCuenta.FormaPago: referencia = d.FormaPago ?? hecho.FormaPago; break;
                                    case DimensionCuenta.Impuesto: referencia = d.Impuesto; break;
                                    case DimensionCuenta.Especie: referencia = d.Especie; break;
                                    case DimensionCuenta.MedioTesoreria: referencia = (int?)d.Medio; break;
                                    case DimensionCuenta.Componente: referencia = (int?)d.Componente; break;
                                    case DimensionCuenta.Caja: referencia = d.Caja; break;
                                    case DimensionCuenta.Personal: referencia = d.Personal; break;
                                    case DimensionCuenta.Concepto: referencia = d.Concepto; break;
                                    case DimensionCuenta.CuentaOrigen:
                                        cuenta = d.CuentaOrigen;
                                        resolucion = "Cuenta del saldo historico";
                                        referencia = null;
                                        break;
                                    default: throw new ValidationException("Dimension no soportada.");
                                }
                                if (cuenta.HasValue) break;
                                if (!referencia.HasValue) continue;
                                var asignacion = config.Asignaciones.SingleOrDefault(a => string.Equals(a.Rol, regla.Rol, StringComparison.OrdinalIgnoreCase)
                                    && a.Dimension == dimension && a.Referencia == referencia);
                                if (asignacion == null) continue;
                                cuenta = asignacion.Cuenta;
                                resolucion = regla.Rol + ": " + dimension + " #" + referencia;
                                break;
                            }
                        if (!cuenta.HasValue)
                            throw new ValidationException("Falta cuenta para rol " + regla.Rol + ", plantilla " + p.Codigo + ", origen " + d.Referencia + ".");
                        if (!cuentasImputables.Contains(cuenta.Value))
                            throw new ValidationException("La cuenta #" + cuenta + " no existe, esta dada de baja o no es imputable.");
                        var debe = regla.Lado == LadoContable.Debe;
                        if (valor < 0) debe = !debe;
                        asiento.Renglones.Add(new RenglonContable
                        {
                            Cuenta = cuenta.Value,
                            Debe = debe ? Math.Abs(valor) : 0,
                            Haber = debe ? 0 : Math.Abs(valor),
                            Regla = i + 1,
                            Origen = d.Referencia,
                            Resolucion = resolucion
                        });
                    }
                }
                if (asiento.Renglones.Count == 0) throw new ValidationException("La plantilla " + p.Codigo + " no genero movimientos.");
                asiento.Debe = asiento.Renglones.Sum(r => r.Debe);
                asiento.Haber = asiento.Renglones.Sum(r => r.Haber);
                if (asiento.Debe != asiento.Haber)
                    throw new ValidationException("La plantilla " + p.Codigo + " no balancea. Debe " + asiento.Debe + ", Haber " + asiento.Haber + ". No se registra ningun asiento.");
                asientos.Add(asiento);
            }
            var result = new SimulacionContable { Version = config.Version, Hecho = hecho, Asientos = asientos };
            result.Firma = Firma(result);
            return result;
        }

        public static string Hash(string value)
        {
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
        }
        public static string Firma(object value) => Hash(JsonConvert.SerializeObject(value,
            new JsonSerializerSettings { Converters = { new DecimalCanonico() } }));
        private sealed class DecimalCanonico : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(decimal) || t == typeof(decimal?);
            public override bool CanRead => false;
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value == null) writer.WriteNull();
                else writer.WriteRawValue(((decimal)value).ToString("G29", CultureInfo.InvariantCulture));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
                throw new NotSupportedException();
        }
    }
}
