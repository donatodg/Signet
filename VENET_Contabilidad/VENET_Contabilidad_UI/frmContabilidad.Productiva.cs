using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VENET_Common;
using VENET_Comun;
using VENET_Contabilidad_BL;
using VENET_DataEntity;

namespace VENET_Contabilidad_UI
{
    public sealed partial class frmContabilidad
    {
        private bool productivaEditada;
        private readonly List<Action> limpiarProductiva = new List<Action>();
        private void LimpiarProductiva()
        {
            foreach (var limpiar in limpiarProductiva) limpiar();
            productivaEditada = false;
        }
        private List<int> SucursalesAutorizadas => Sistema.Sucursales.Select(s => s.Id_Sucursal).Distinct().ToList();
        private static void ExigirRevisionProductiva()
        {
            if (!(Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ContabilidadBandeja", Enums.Accion.Ingresar)
                && Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ContabilidadBandeja", Enums.Accion.Buscar))
                && !(Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ContabilidadAprobacion", Enums.Accion.Ingresar)
                && Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ContabilidadAprobacion", Enums.Accion.Modificar)))
                throw new ValidationException("Sin permiso para revisar la bandeja.");
        }
        private string PedirMotivo(string titulo)
        {
            using (var f = new Form { Text = titulo, Width = 650, Height = 160 })
            {
                var barra = Barra();
                var texto = new TextBox { Width = 450, MaxLength = 500 };
                barra.Controls.Add(new Label { Text = "Motivo (5 a 500 caracteres)", AutoSize = true });
                barra.Controls.Add(texto);
                barra.Controls.Add(new Button { Text = "Aceptar", DialogResult = DialogResult.OK });
                f.Controls.Add(barra);
                if (f.ShowDialog(this) != DialogResult.OK) return null;
                if (texto.Text.Trim().Length < 5) throw new ValidationException("Indique un motivo significativo.");
                return texto.Text.Trim();
            }
        }
        private void ValidarOrigenProductivo(OperatoriaContable op, int id)
        {
            ExigirOrigen(op);
            var h = ContabilidadService.Complementario(op) ? servicio.CabeceraDocumento(Empresa, op, id) :
                OrigenGestion.Obtener(op == OperatoriaContable.CostoVentaAutomatico ? OperatoriaContable.Venta : op, id);
            if (h.Empresa != Empresa || !SucursalesAutorizadas.Contains(h.Sucursal))
                throw new ValidationException("Origen fuera de sus sucursales o empresas.");
            if (op == OperatoriaContable.TransferenciaFondos)
                using (var db = new GestionContext())
                    if (h.Partidas.Any(p => !db.Cajas.Any(c => c.Id == p.Caja && SucursalesAutorizadas.Contains(c.Id_Sucursal))))
                        throw new ValidationException("Caja de destino fuera de sus sucursales.");
        }
        private void ConfigurarProductiva()
        {
            foreach (var t in new[] { typeof(List<PoliticaContable>), typeof(List<ClasificacionCuenta>), typeof(List<VinculoCaja>) })
                TypeDescriptor.AddAttributes(t, new EditorAttribute(typeof(CollectionEditor), typeof(UITypeEditor)));
            BandejaProductiva();
            var pagina = Pagina("Politicas operativas");
            var propiedades = new PropertyGrid { Dock = DockStyle.Fill };
            propiedades.PropertyValueChanged += (s, e) => productivaEditada = true;
            pagina.Controls.Add(propiedades);
            var barra = Barra();
            barra.Controls.Add(new Label { Text = "Manual / Propuesto / Automatico. Desde y Version son controlados por el servidor; no alcanzan documentos historicos.", AutoSize = true });
            barra.Controls.Add(Boton("Leer politicas", () =>
            {
                Exigir("ContabilidadAutomatizacion", Enums.Accion.Buscar);
                propiedades.SelectedObject = servicio.Operativa(Empresa);
            }));
            barra.Controls.Add(Boton("Usuarios autorizados para automatico", () =>
            {
                Exigir("ContabilidadAutomatizacion", Enums.Accion.Buscar);
                Mostrar("Usuarios contables autorizados", servicio.UsuariosAutomaticos(Usuario));
            }));
            barra.Controls.Add(Boton("Guardar politicas", () =>
            {
                Exigir("ContabilidadAutomatizacion", Enums.Accion.Modificar);
                var o = propiedades.SelectedObject as OperativaContable ?? throw new ValidationException("Lea primero.");
                if (o.Empresa != Empresa) throw new ValidationException("Recargue la empresa seleccionada.");
                var motivo = PedirMotivo("Autorizar politicas futuras");
                if (motivo == null || !Confirmar("Automatico registra futuros comprobantes sin revision humana individual. Autorizar?")) return;
                propiedades.SelectedObject = servicio.GuardarOperativa(o, Usuario, motivo);
                productivaEditada = false;
                Sistema.Mensaje("Politicas guardadas y auditadas.");
            }));
            barra.Controls.Add(Boton("Procesar cola ahora", () =>
            {
                Exigir("ContabilidadAutomatizacion", Enums.Accion.Modificar);
                Sistema.Mensaje(servicio.ProcesarCola(Empresa) + " eventos procesados. Verifique resultados en Bandeja.");
            }));
            pagina.Controls.Add(barra);
            PeriodosProductivos();
            InformesProductivos();
            limpiarProductiva.Add(() => propiedades.SelectedObject = null);
        }
        private void BandejaProductiva()
        {
            var pagina = Pagina("Bandeja y aprobaciones");
            var pendientes = Grilla();
            pendientes.MultiSelect = true; pendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var revisados = Grilla();
            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, Height = 600, SplitterDistance = 280 };
            split.Panel1.Controls.Add(pendientes); split.Panel2.Controls.Add(revisados); pagina.Controls.Add(split);
            List<RevisionLote> seleccion = null;
            pendientes.SelectionChanged += (s, e) => { seleccion = null; revisados.DataSource = null; };
            var inicio = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) };
            var fin = new DateTimePicker { Format = DateTimePickerFormat.Short };
            Action consultar = () =>
            {
                ExigirRevisionProductiva();
                pendientes.DataSource = servicio.Bandeja(Empresa, inicio.Value.Date, fin.Value.Date, SucursalesAutorizadas);
                seleccion = null; revisados.DataSource = null;
            };
            inicio.ValueChanged += (s, e) => { pendientes.DataSource = null; };
            fin.ValueChanged += (s, e) => { pendientes.DataSource = null; };
            limpiarProductiva.Add(() => pendientes.DataSource = null);
            var barra = Barra(); barra.Controls.Add(inicio); barra.Controls.Add(fin);
            barra.Controls.Add(Boton("Consultar pendientes", consultar));
            barra.Controls.Add(Boton("Descubrir historicos", () =>
            {
                Exigir("ContabilidadBandeja", Enums.Accion.Agregar);
                if (!Confirmar("Descubrir documentos del periodo? No captura costos antiguos ni los automatiza.")) return;
                servicio.SincronizarBandeja(Empresa, inicio.Value.Date, fin.Value.Date, Usuario, SucursalesAutorizadas); consultar();
            }));
            barra.Controls.Add(Boton("Revisar seleccion (hasta 50)", () =>
            {
                ExigirRevisionProductiva();
                seleccion = null; revisados.DataSource = null;
                var pedidos = pendientes.SelectedRows.Cast<DataGridViewRow>().Select(r => (PendienteContable)r.DataBoundItem).ToList();
                if (pedidos.Any(p => p.Anulado || p.Lote.HasValue)) throw new ValidationException("Seleccione pendientes vigentes sin registrar.");
                foreach (var p in pedidos) ValidarOrigenProductivo(p.Operatoria, p.Documento);
                seleccion = servicio.RevisarLote(Empresa, pedidos.Select(p => new RevisionLote { Operatoria = p.Operatoria, Documento = p.Documento }).ToList());
                revisados.DataSource = seleccion.SelectMany(r => r.Simulacion == null ? new[] { new { r.Documento, r.Operatoria, Plantilla = "", Cuenta = 0, Debe = 0m, Haber = 0m, Detalle = r.Error } } :
                    r.Simulacion.Asientos.SelectMany(a => a.Renglones.Select(l => new { r.Documento, r.Operatoria, a.Plantilla, l.Cuenta, l.Debe, l.Haber, Detalle = l.Resolucion }))).ToList();
            }));
            barra.Controls.Add(Boton("Aprobar documento seleccionado", () =>
            {
                Exigir("ContabilidadAprobacion", Enums.Accion.Modificar);
                var p = pendientes.CurrentRow?.DataBoundItem as PendienteContable ?? throw new ValidationException("Seleccione un origen revisado.");
                var r = seleccion?.SingleOrDefault(x => x.Documento == p.Documento && x.Operatoria == p.Operatoria);
                if (r?.Simulacion == null) throw new ValidationException("Revise primero ese documento.");
                ValidarOrigenProductivo(r.Operatoria, r.Documento);
                var motivo = PedirMotivo("Aprobacion independiente #" + p.Documento); if (motivo == null) return;
                servicio.Aprobar(Empresa, r.Operatoria, r.Documento, r.Simulacion.Firma, motivo, Usuario);
                Sistema.Mensaje("Revision aprobada.");
            }));
            barra.Controls.Add(Boton("Registrar lote revisado", () =>
            {
                Exigir("ContabilidadBandeja", Enums.Accion.Agregar);
                if (seleccion == null) throw new ValidationException("Revise primero.");
                foreach (var r in seleccion) ValidarOrigenProductivo(r.Operatoria, r.Documento);
                if (!Confirmar("Registrar toda la seleccion? Si algun origen falla, no se registra ninguno.")) return;
                var lotes = servicio.RegistrarLote(Empresa, seleccion, Usuario); consultar();
                Sistema.Mensaje("Lotes registrados: " + string.Join(", ", lotes.Select(r => r.Id)));
            }));
            barra.Controls.Add(Boton("Reintentar seleccionado", () =>
            {
                Exigir("ContabilidadBandeja", Enums.Accion.Agregar);
                var p = pendientes.CurrentRow?.DataBoundItem as PendienteContable ?? throw new ValidationException("Seleccione un pendiente.");
                servicio.Reintentar(Empresa, p.Id, Usuario, SucursalesAutorizadas); consultar();
            }));
            barra.Controls.Add(Boton("Ver captura historica de venta", () =>
            {
                ExigirRevisionProductiva();
                var p = pendientes.CurrentRow?.DataBoundItem as PendienteContable ?? throw new ValidationException("Seleccione una venta.");
                if (p.Operatoria != OperatoriaContable.Venta && p.Operatoria != OperatoriaContable.CostoVentaAutomatico) throw new ValidationException("Seleccione una venta o su costo automatico.");
                ValidarOrigenProductivo(p.Operatoria, p.Documento);
                Mostrar("Costo estandar vigente al confirmar (no reconstruido)", servicio.Costos(Empresa, p.Documento));
            }));
            pagina.Controls.Add(barra);
        }
        private void PeriodosProductivos()
        {
            var pagina = Pagina("Periodos y auditoria"); var grid = Grilla(); pagina.Controls.Add(grid);
            var mes = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "yyyy-MM", ShowUpDown = true };
            var barra = Barra(); barra.Controls.Add(mes);
            barra.Controls.Add(Boton("Consultar bloqueos", () => { Exigir("ContabilidadPeriodos", Enums.Accion.Buscar); grid.DataSource = servicio.Periodos(Empresa); }));
            foreach (var cerrar in new[] { true, false })
                barra.Controls.Add(Boton(cerrar ? "Bloquear mes" : "Reabrir mes excepcionalmente", () =>
                {
                    var motivo = PedirMotivo(cerrar ? "Bloquear mes" : "Reapertura excepcional"); if (motivo == null) return;
                    servicio.CambiarPeriodo(Empresa, new DateTime(mes.Value.Year, mes.Value.Month, 1), cerrar, motivo, Usuario);
                    grid.DataSource = servicio.Periodos(Empresa);
                }));
            barra.Controls.Add(Boton("Auditoria", () =>
            {
                Exigir("ContabilidadPeriodos", Enums.Accion.Buscar);
                grid.DataSource = servicio.Auditoria(Empresa).Select(d => new { Usuario = d["Usuario"], Fecha = d["Fecha"], Accion = d["Accion"], Referencia = d["Referencia"], Motivo = d["Motivo"] }).ToList();
            }));
            pagina.Controls.Add(barra); limpiarProductiva.Add(() => grid.DataSource = null);
        }
        public sealed class ClasificacionEditable
        {
            public List<ClasificacionCuenta> Cuentas { get; set; }
            public List<VinculoCaja> Cajas { get; set; }
        }
        private void InformesProductivos()
        {
            var pagina = Pagina("Conciliacion e informes"); var grid = Grilla(); pagina.Controls.Add(grid);
            var tipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            tipo.Items.AddRange(new object[] { "Gestion", "Cajas y bancos", "Balance clasificado", "Sumas y saldos" }); tipo.SelectedIndex = 0;
            var moneda = Combo(); moneda.DataSource = Sistema.Especies.ToList();
            var inicio = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = new DateTime(DateTime.Today.Year, 1, 1) };
            var fin = new DateTimePicker { Format = DateTimePickerFormat.Short };
            Func<IEnumerable> datos = () =>
            {
                Exigir("ContabilidadConciliacion", Enums.Accion.Buscar);
                var m = ((KeyNamePair)moneda.SelectedItem).Key;
                switch (tipo.SelectedIndex)
                {
                    case 0: return servicio.ConciliarDocumentos(Empresa, inicio.Value.Date, fin.Value.Date, SucursalesAutorizadas);
                    case 1: return servicio.ConciliarCajas(Empresa, m, inicio.Value.Date, fin.Value.Date, SucursalesAutorizadas);
                    case 2: return servicio.InformeBalance(Empresa, m, inicio.Value.Date, fin.Value.Date);
                    default: return servicio.Saldos(Empresa, m, inicio.Value.Date, fin.Value.Date);
                }
            };
            var barra = Barra(); barra.Controls.Add(tipo); barra.Controls.Add(moneda); barra.Controls.Add(inicio); barra.Controls.Add(fin);
            barra.Controls.Add(Boton("Conciliar", () => grid.DataSource = datos()));
            foreach (var formato in new[] { "pdf", "xlsx" })
                barra.Controls.Add(Boton("Exportar " + formato.ToUpperInvariant(), () =>
                {
                    Exigir("ContabilidadConciliacion", Enums.Accion.Imprimir);
                    using (var f = new SaveFileDialog { Filter = formato.ToUpperInvariant() + "|*." + formato, FileName = "Contabilidad." + formato, OverwritePrompt = true })
                        if (f.ShowDialog(this) == DialogResult.OK) File.WriteAllBytes(f.FileName, InformeContable.Exportar("SIGNET - " + tipo.Text + " - Empresa " + Empresa +
                            " - " + inicio.Value.ToString("yyyy-MM-dd") + " / " + fin.Value.ToString("yyyy-MM-dd"), datos(), formato));
                }));
            pagina.Controls.Add(barra);
            limpiarProductiva.Add(() => grid.DataSource = null);
            var clasificar = Pagina("Clasificacion y vinculos"); var editor = new PropertyGrid { Dock = DockStyle.Fill }; clasificar.Controls.Add(editor);
            editor.PropertyValueChanged += (s, e) => productivaEditada = true;
            var acciones = Barra();
            acciones.Controls.Add(Boton("Leer clasificacion y cajas", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar);
                editor.SelectedObject = new ClasificacionEditable { Cuentas = servicio.Clasificaciones(Empresa), Cajas = servicio.CajasContables(Empresa) };
            }));
            acciones.Controls.Add(Boton("Guardar clasificacion", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Modificar);
                var c = editor.SelectedObject as ClasificacionEditable ?? throw new ValidationException("Lea primero.");
                var motivo = PedirMotivo("Clasificacion y cajas"); if (motivo == null) return;
                servicio.GuardarClasificaciones(Empresa, c.Cuentas, c.Cajas, motivo, Usuario);
                productivaEditada = false;
                Sistema.Mensaje("Clasificacion y cajas guardadas y auditadas.");
            }));
            acciones.Controls.Add(Boton("IDs y nombres de cajas", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar);
                using (var db = new GestionContext()) Mostrar("Cajas y bancos", db.Cajas.Where(c => c.UserDel == null && SucursalesAutorizadas.Contains(c.Id_Sucursal))
                    .Select(c => new { c.Id, c.Descripcion, c.Id_Especie, c.Id_Sucursal }).ToList());
            }));
            clasificar.Controls.Add(acciones); limpiarProductiva.Add(() => editor.SelectedObject = null);
        }
    }
}
