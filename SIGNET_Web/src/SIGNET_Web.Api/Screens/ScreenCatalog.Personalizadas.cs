using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Screens.Acciones;
using VENET_Common;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens
{
    /// <summary>
    /// Pantallas de escritorio sin Manager con Buscar/Save reutilizable por reflexión (frmInicioTurnos, frmCierreTurno,
    /// frmControlGestion). Se publican como "proceso" con lógica propia que sigue invocando al BL original.
    /// </summary>
    public partial class ScreenCatalog
    {

        private void RegistrarPersonalizadas()
        {
            var hoy = DateTime.Today;
            Personalizada("ControlGestion", "Control de Gestión", "Gestión", 2, Enums.Modulos.Gestion, "ControlGestion", "Buscar",
                new List<FieldSchema>
                {
                    Campo.Fecha("FechaDesde", "Fecha Desde", true, hoy.AddMonths(-3)),
                    Campo.Fecha("FechaHasta", "Fecha Hasta", true, hoy)
                }, ControlGestion, () => "Controles de consistencia: comprobantes con IVA en 0, recibos/OP/compras sin liquidar, cheques vencidos, diferencias de descuentos, saldos iniciales y electrónicos en otro depósito.");
        }

        private void Personalizada(string key, string titulo, string area, int orden, Enums.Modulos modulo, string formulario, string boton,
            List<FieldSchema> parametros, Func<JObject, AccionResultado> ejecutar, Func<string> descripcion, bool informe = false)
        {
            _screens[key] = new ScreenDescriptor
            {
                Key = key, Titulo = titulo, Area = area, AreaOrden = orden, Modulo = modulo, Formulario = formulario,
                Assembly = "SIGNET_Web", Tipo = "proceso", Parametros = parametros, Columnas = new List<FieldSchema>(),
                CamposEdicion = new List<FieldSchema>(), Personalizado = ejecutar, DescripcionDinamica = descripcion,
                TextoBoton = boton, Informe = informe, LibreAcceso = true
            };
        }

        // ---------- Control de Gestión (ControlGestionManager) ----------

        private static readonly string[] TitulosControl =
        {
            "Comprobantes con IVA en 0", "Recibos sin liquidar", "OP sin liquidar", "Compras sin liquidar", "Cheques vencidos",
            "Clientes Diferencias en Descuentos Configurados", "Modificación de Saldos Iniciales", "Electrónicos en otro depósito"
        };

        private static AccionResultado ControlGestion(JObject v)
        {
            var par = new VENET_Gestion_BL.ControlGestionManager.ParametrosBusquedas
            {
                FechaDesde = v?["FechaDesde"]?.ToObject<DateTime?>() ?? DateTime.Today.AddMonths(-3),
                FechaHasta = v?["FechaHasta"]?.ToObject<DateTime?>() ?? DateTime.Today
            };
            if (par.FechaDesde > par.FechaHasta) throw new ValidationException("La fecha desde no puede ser mayor a la fecha hasta.");
            var ds = VENET_Gestion_BL.ControlGestionManager.Buscar(par);
            var tablas = new List<TablaResultado>();
            var i = 0;
            foreach (DataTable dt in ds.Tables)
            {
                var t = TablaResultado.Desde(dt, i < TitulosControl.Length ? TitulosControl[i] : dt.TableName);
                t.Resumen = "Se han encontrado " + dt.Rows.Count + " registros.";
                tablas.Add(t);
                i++;
            }
            var total = tablas.Sum(t => t.Filas.Count);
            return new AccionResultado { Mensaje = total == 0 ? "No se encontraron inconsistencias." : "Se encontraron " + total + " registros a revisar.", Tablas = tablas };
        }
    }
}
