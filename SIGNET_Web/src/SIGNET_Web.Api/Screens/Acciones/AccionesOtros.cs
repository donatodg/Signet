using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using SIGNET_Web.Api.Screens;
using VENET_Comun;
using VENET_Common;
using VENET_General_BL;
using VENET_Personal_BL;
using VENET_Produccion_BL;
using VENET_Seguridad_BL;
using VENET_DataEntity;

namespace SIGNET_Web.Api.Screens.Acciones
{
    public class AccionesOtros : IAccionesModulo
    {
        private static readonly CultureInfo Ar = new CultureInfo("es-AR");

        public void Registrar(AccionesRegistro r)
        {
            RegistrarGeneral(r);
            RegistrarPersonal(r);
            RegistrarProduccion(r);
            RegistrarSeguridad(r);
        }

        private static AccionDef Def(string key, string menu, string titulo, Enums.Modulos modulo, string formulario, string descripcion, Seleccion seleccion = Seleccion.Una)
        {
            return new AccionDef
            {
                Key = key,
                Menu = menu,
                Titulo = titulo,
                Modulo = modulo,
                Formulario = formulario,
                Descripcion = descripcion,
                Seleccion = seleccion
            };
        }

        private static void RegistrarGeneral(AccionesRegistro r)
        {
            r.Agregar("Parametros", Def("grabar-todos-parametros", "Operaciones", "Grabar todos los Parámetros", Enums.Modulos.General, "Parametros", "Grabar Todos los Parámetros", Seleccion.Ninguna).With(a =>
            {
                a.Ejecutar = _ =>
                {
                    foreach (Parametro.Param p in Enum.GetValues(typeof(Parametro.Param))) Parametro.ObtenerValor(p);
                    Parametro.Reload();
                    return AccionResultado.Ok("Parámetros actualizados.", false);
                };
            }));
        }

        private static void RegistrarPersonal(AccionesRegistro r)
        {
            r.Agregar("Personal", Def("cambio-empresa", "Operaciones", "Cambio de Empresa", Enums.Modulos.Personal, "Personal", "Cambio de Empresa").With(a =>
            {
                a.CamposDinamicos = ctx =>
                {
                    var actual = new PersonalManager(new Personal { Id = ctx.Id }).Personal.Id_Empresa;
                    return new List<FieldSchema> { Campo.Opciones("empresa", "Empresa", Sistema.Empresas.Select(e => new LookupItem { Key = e.Key, Name = e.Name }), true, actual) };
                };
                a.Ejecutar = ctx =>
                {
                    var m = new PersonalManager(new Personal { Id = ctx.Id });
                    m.Personal.Id_Empresa = ctx.Valor<int>("empresa");
                    m.Save();
                    return AccionResultado.Ok("Empresa actualizada.");
                };
            }));
            r.Agregar("Personal", Def("actualizar-legajos-sisorg", "Operaciones", "Actualizar Legajos desde Sisorg", Enums.Modulos.Personal, "Personal", "Actualizar Legajos Personal desde Sisorg", Seleccion.Ninguna).With(a =>
            {
                a.Confirmacion = "¿Desea actualizar los legajos del personal desde Sisorg?";
                a.Ejecutar = _ =>
                {
                    ValidarSisorg();
                    VENET_Personal_Sisorg.WebServicesSisorg.ActualizarIdsEmpleados();
                    return AccionResultado.Ok("Legajos actualizados desde Sisorg.");
                };
            }));
            r.Agregar("Personal", Def("importar-personal-sisorg", "Operaciones", "Importar Personal a Sisorg", Enums.Modulos.Personal, "Personal", "Importar Personal a Sisorg", Seleccion.Ninguna).With(a =>
            {
                a.CamposDinamicos = _ =>
                {
                    ValidarSisorg();
                    var pendientes = VENET_Personal_Sisorg.WebServicesSisorg.BuscarPendientes();
                    if (pendientes.Count == 0) throw new ValidationException("No hay personal pendiente de importar a Sisorg.");
                    return new List<FieldSchema> { Campo.Multi("legajos", "Personal pendiente", pendientes.Select(x => new LookupItem { Key = x.legajo, Name = x.legajo + " - " + x.apellido + ", " + x.nombre })) };
                };
                a.Ejecutar = ctx =>
                {
                    ValidarSisorg();
                    var legajos = ctx.Enteros("legajos");
                    var sel = VENET_Personal_Sisorg.WebServicesSisorg.BuscarPendientes().Where(x => legajos.Contains(x.legajo)).ToList();
                    foreach (var x in sel) VENET_Personal_Sisorg.WebServicesSisorg.InsertPersonal(x);
                    return AccionResultado.Ok("Se enviaron " + sel.Count + " legajo/s a Sisorg.");
                };
            }));
            r.Agregar("Personal", ImportarExcelPersonal("importar-excel-configuracion", "Importar Excel Seteo Masivo", "Importar Excel con Configuración", PersonalManager.ImportarExcel));
            r.Agregar("Personal", Def("modelo-excel-configuracion", "Operaciones", "Generar Excel Importación Modelo", Enums.Modulos.Personal, "Personal", "Generar Plantilla Excel con Configuración", Seleccion.Ninguna).With(a =>
            {
                a.Ejecutar = _ => AccionResultadoArchivo("modelo-configuracion-personal.csv", "Legajo,Turno,Día Semana Rotación,Cant. Días Rotación,Franco cada x días\r\n");
            }));
            r.Agregar("Personal", ImportarExcelPersonal("importar-excel-vencimientos", "Importar Excel Seteo Masivo Licencias", "Importar Excel con Configuración Vencimientos", PersonalManager.ImportarExcelVencimientos));
            r.Agregar("Personal", Def("modelo-excel-vencimientos", "Operaciones", "Generar Excel Importación Modelo Licencias", Enums.Modulos.Personal, "Personal", "Generar Plantilla Excel con Configuración Vencimientos", Seleccion.Ninguna).With(a =>
            {
                a.Ejecutar = _ => AccionResultadoArchivo("modelo-vencimientos-personal.csv", "Legajo,Fecha Vencimiento,Número,Fecha Emisión,Fecha Vencimiento CNRT,Número CNRT,Fecha Emisión CNRT,Fecha Vencimiento Adicional,Número Adicional,Fecha Emisión Adicional,Fecha Vencimiento Adicional 2,Número Adicional 2,Fecha Emisión Adicional 2\r\n");
            }));
        }

        private static void ValidarSisorg()
        {
            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Personal_VerImportacionSisorg)))
                throw new ValidationException("La integración con Sisorg no está habilitada (parámetro Personal_VerImportacionSisorg).");
        }

        private static AccionDef ImportarExcelPersonal(string key, string titulo, string permiso, Action<string> importar) =>
            Def(key, "Operaciones", titulo, Enums.Modulos.Personal, "Personal", permiso, Seleccion.Ninguna).With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Archivo("archivo") };
                a.Confirmacion = "¿Desea importar la configuración del archivo?";
                a.Ejecutar = ctx =>
                {
                    ctx.ConArchivo("archivo", ruta => { importar(ruta); return true; });
                    return AccionResultado.Ok("Archivo importado.");
                };
            });

        private static void RegistrarProduccion(AccionesRegistro r)
        {
            r.Navegar("Produccion", "Operaciones", "copiar-medida-otras-medidas", "Copiar Medida en Otras Medidas", "ProduccionCopiar");
            r.Navegar("Produccion", "Operaciones", "copiar-variantes-segun-medida", "Copiar Variantes Según Medida", "ProduccionCopiarVariante");

            r.Agregar("ProduccionListaPrecios", Def("lista-precios", "Imprimir", "Lista de Precios", Enums.Modulos.Produccion, "ProduccionListaPrecios", "Lista de Precios").With(a =>
            {
                a.Ejecutar = ctx =>
                {
                    var lista = ProduccionListaPreciosManager.Buscar(new ProduccionListaPreciosManager.ParametrosBusquedas { Id = ctx.Id }).SingleOrDefault();
                    if (lista == null) throw new ValidationException("No se encontró la lista de precios seleccionada.");
                    var detalle = ProduccionListaPreciosDetalleManager.Buscar(new ProduccionListaPreciosDetalleManager.ParametrosBusquedas { Id_ListaPrecios = ctx.Id });
                    var doc = new HtmlDocumento("Lista de Precios")
                        .Horizontal()
                        .Titulo("Lista de Precios")
                        .Datos(("Empresa", lista.Empresa), ("Lista", lista.Descripcion), ("Vigencia desde", lista.VigenteDesde), ("Vigencia hasta", lista.VigenteHasta));
                    doc.Tabla(detalle, ("Código", x => x.Codigo), ("Línea", x => x.Linea), ("Variante", x => x.Variante), ("Medida", x => x.Medida), ("Costo composición", x => x.CostoComposicion), ("Costo tareas", x => x.CostoTareas), ("Utilidad %", x => x.Utilidad), ("Precio", x => x.Total));
                    return AccionResultado.Documento(doc);
                };
            }));

            r.Agregar("ProduccionListaPrecios", Def("generar-excel-precios", "Operaciones", "Generar Excel de Precios", Enums.Modulos.Produccion, "ProduccionListaPrecios", "Generar Excel de Lista de Precios").With(a =>
            {
                a.Ejecutar = ctx =>
                {
                    var lista = ProduccionListaPreciosManager.Buscar(new ProduccionListaPreciosManager.ParametrosBusquedas { Id = ctx.Id }).SingleOrDefault();
                    if (lista == null) throw new ValidationException("No se encontró la lista de precios seleccionada.");
                    var detalle = ProduccionListaPreciosDetalleManager.Buscar(new ProduccionListaPreciosDetalleManager.ParametrosBusquedas { Id_ListaPrecios = ctx.Id });
                    var csv = CsvFila("Código", "Línea", "Variante", "Medida", "Costo composición", "Costo tareas", "Utilidad", "Precio") + "\r\n";
                    csv += string.Join("\r\n", detalle.Select(x => CsvFila(x.Codigo, x.Linea, x.Variante, x.Medida, x.CostoComposicion, x.CostoTareas, x.Utilidad, x.Total)));
                    return AccionResultadoArchivo("precios-" + ctx.Id + ".csv", csv);
                };
            }));

            r.Agregar("ProduccionListaPrecios", Def("actualizar-utilidad-variante", "Operaciones", "Actualizar Utilidad Por Variante", Enums.Modulos.Produccion, "ProduccionListaPrecios", "Actualizar Utilidad por Variante").With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Decimal("utilidad", "Utilidad (%)") };
                a.Ejecutar = ctx =>
                {
                    using (var manager = new ProduccionActualizarUtilidadManager(ctx.Id))
                    {
                        manager.Utilidad = ctx.Valor<decimal>("utilidad");
                        manager.ActualizarUtilidadMasivo();
                    }
                    return AccionResultado.Ok("Utilidad actualizada.");
                };
            }));

            r.Agregar("ProduccionListaPrecios", Def("actualizar-precios-productos", "Operaciones", "Actualizar Precios de Productos", Enums.Modulos.Produccion, "ProduccionListaPrecios", "Actualizar Precios de Productos").With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Decimal("porcentaje", "Porcentaje adicional", true, 0) };
                a.Ejecutar = ctx =>
                {
                    var valor = ctx.Valor<decimal>("porcentaje");
                    if (valor < 0) throw new System.ComponentModel.DataAnnotations.ValidationException("Debe ingresar un importe mayor o igual a cero.");
                    valor = valor == 0 ? 1 : valor / 100 + 1;
                    ProduccionListaPreciosManager.ActualizarPreciosProductos(ctx.Id, valor);
                    return AccionResultado.Ok("Precios de productos actualizados.");
                };
            }));

            r.Agregar("ProduccionVariantes", Def("modificar-utilidad-linea", "Operaciones", "Modificar Utilidad por Línea", Enums.Modulos.Produccion, "ProduccionVariantes", "Modificar Utilidad").With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Decimal("utilidad", "Utilidad (%)") };
                a.CamposDinamicos = _ =>
                {
                    using (var manager = new ProduccionVariantesActualizarUtilidadManager())
                        return new List<FieldSchema> { Campo.Entidades("id_linea", "Línea", manager.Lineas.Cast<object>()).AppendRequired() , Campo.Decimal("utilidad", "Utilidad (%)") };
                };
                a.Ejecutar = ctx =>
                {
                    using (var manager = new ProduccionVariantesActualizarUtilidadManager())
                    {
                        manager.Id_Linea = ctx.Valor<int>("id_linea");
                        manager.Utilidad = ctx.Valor<decimal>("utilidad");
                        manager.ActualizarUtilidadMasivo();
                    }
                    return AccionResultado.Ok("Utilidad actualizada para la línea.");
                };
            }));

            r.Agregar("ProduccionVariantes", Def("reporte-completo", "Imprimir", "Reporte Completo de Tareas", Enums.Modulos.Produccion, "ProduccionVariantes", "Reporte Completo", Seleccion.Ninguna).With(a =>
            {
                a.Accion = Enums.Accion.Ver;
                a.Ejecutar = _ =>
                {
                    var filas = ProduccionVariantesManager.BuscarCompleto();
                    var tabla = TablaResultado.Desde(filas, "Variantes - Tareas (completo)",
                        ("Linea", "Línea", x => x.Linea), ("Variante", "Variante", x => x.Variante), ("Tarea", "Tarea", x => x.Tarea),
                        ("ManoObra", "Mano de Obra", x => x.ManoObra), ("PrecioHora", "Precio Hora", x => x.PrecioHora), ("Costo", "Costo", x => x.Costo));
                    return new AccionResultado { Tablas = new List<TablaResultado> { tabla }, Refrescar = false };
                };
            }));

            r.Agregar("ProduccionListaPreciosDetalle", Def("actualizar-utilidad-variante", "Operaciones", "Actualizar Utilidad por Variante", Enums.Modulos.Produccion, "ProduccionListaPreciosDetalle", "Actualizar Utilidad por Variante").With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Decimal("utilidad", "Utilidad (%)") };
                a.Ejecutar = ctx =>
                {
                    var fila = ctx.Fila<ProduccionListaPreciosDetalleManager.SearchResult>(ctx.Id);
                    if (fila == null) throw new ValidationException("No se encontró el detalle seleccionado.");
                    using (var manager = new ProduccionActualizarUtilidadManager(fila.Id_ListaPrecios))
                    {
                        manager.Id_Variante = fila.Id_Variante;
                        manager.Utilidad = ctx.Valor<decimal>("utilidad");
                        manager.ActualizarUtilidadMasivo();
                    }
                    return AccionResultado.Ok("Utilidad actualizada para la variante.");
                };
            }));
        }

        private static void RegistrarSeguridad(AccionesRegistro r)
        {
            r.Agregar("SeguridadGruposObjetos", Def("grupos-asignados", "Operaciones", "Ver Grupos Asignados", Enums.Modulos.Seguridad, "SeguridadGrupos", "Ver Grupos Asignados").With(a =>
            {
                a.Accion = Enums.Accion.Ver;
                a.Ejecutar = ctx =>
                {
                    var filas = SeguridadObjetoGrupoManager.Buscar(ctx.Id);
                    return new AccionResultado { Tablas = new List<TablaResultado> { TablaResultado.Desde(filas, "Grupos asignados", ("Id", "Id", x => x.Id), ("Descripcion", "Grupo", x => x.Descripcion)) } };
                };
            }));
            r.Agregar("SeguridadGrupos", Def("duplicar-grupo", "Operaciones", "Duplicar Grupo", Enums.Modulos.Seguridad, "SeguridadGrupos", "Duplicar Grupos").With(a =>
            {
                a.Campos = new List<FieldSchema> { Campo.Texto("descripcion", "Nombre del nuevo grupo", true, 100) };
                a.Ejecutar = ctx =>
                {
                    var grupo = new SeguridadGrupos { Descripcion = ctx.Texto("descripcion"), EsAdministrador = false };
                    using (var manager = new SeguridadGruposManager(grupo)) manager.Save();
                    SeguridadGruposManager.Duplicar(ctx.Id, grupo.Id);
                    return AccionResultado.Ok("Grupo duplicado.");
                };
            }));
            r.Agregar("SeguridadUsuarios", Def("restablecer-visualizacion", "Operaciones", "Restablecer Visualización", Enums.Modulos.Seguridad, "SeguridadUsuarios", "Restablecer Visualización").With(a =>
            {
                a.Ejecutar = ctx =>
                {
                    SeguridadUsuariosManager.Restablecer(ctx.Id);
                    return AccionResultado.Ok("Debe cerrar el sistema y volverlo a abrir para que los cambios tengan efectos.", false);
                };
            }));
        }

        private static AccionResultado AccionResultadoArchivo(string nombre, string contenido) => new AccionResultado
        {
            Archivo = ArchivoResultado.Csv(nombre, contenido),
            Refrescar = false
        };

        private static string CsvFila(params object[] valores) => string.Join(",", valores.Select(v => CsvValor(v)));

        private static string CsvValor(object value)
        {
            var texto = value == null ? "" : Convert.ToString(value, Ar) ?? "";
            return "\"" + texto.Replace("\"", "\"\"") + "\"";
        }
    }

    internal static class AccionesFieldExtensions
    {
        public static AccionDef With(this AccionDef def, Action<AccionDef> configurar)
        {
            configurar(def);
            return def;
        }

        public static FieldSchema AppendRequired(this FieldSchema field)
        {
            field.Required = true;
            field.Nullable = false;
            return field;
        }
    }
}

