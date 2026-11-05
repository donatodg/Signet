using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using VENET_Common;
using VENET_Comun;
using VENET_Contabilidad_BL;
using VENET_DataEntity;

namespace VENET_Contabilidad_UI
{
    public sealed partial class frmContabilidad : DevExpress.XtraEditors.XtraForm
    {
        private readonly ContabilidadService servicio = new ContabilidadService();
        private readonly ComboBox empresas = Combo();
        private readonly TabControl tabs = new TabControl { Dock = DockStyle.Fill };
        private readonly PropertyGrid editor = new PropertyGrid { Dock = DockStyle.Fill };
        private readonly PropertyGrid documento = new PropertyGrid { Dock = DockStyle.Fill };
        private readonly DataGridView revision = Grilla();
        private readonly DataGridView libros = Grilla();
        private readonly ComboBox operatoria = Combo();
        private readonly NumericUpDown origen = new NumericUpDown { Minimum = 1, Maximum = int.MaxValue, Width = 100 };
        private readonly DateTimePicker desde = new DateTimePicker { Format = DateTimePickerFormat.Short };
        private readonly DateTimePicker hasta = new DateTimePicker { Format = DateTimePickerFormat.Short };
        private readonly ComboBox monedas = Combo();
        private readonly ComboBox cuentas = Combo();
        private readonly NumericUpDown ejercicio = new NumericUpDown { Minimum = 1, Maximum = int.MaxValue };
        private readonly ComboBox sucursales = Combo();
        private readonly DateTimePicker fecha = new DateTimePicker { Format = DateTimePickerFormat.Short };
        private readonly Button registrar;
        private ConfiguracionContable configuracion;
        private SimulacionContable simulacion;
        private int Empresa => (empresas.SelectedItem as KeyNamePair)?.Key ?? 0;
        private int Usuario => Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

        public frmContabilidad()
        {
            Text = "Contabilidad parametrizable"; Width = 1150; Height = 800;
            foreach (var tipo in new[] { typeof(List<PlantillaContable>), typeof(List<ReglaContable>), typeof(List<AsignacionCuenta>), typeof(List<PartidaOrigen>) })
                TypeDescriptor.AddAttributes(tipo, new EditorAttribute(typeof(CollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(List<DimensionCuenta>), new EditorAttribute(typeof(PrioridadesEditor), typeof(UITypeEditor)));
            foreach (var tipo in new[] { typeof(HechoContable), typeof(PlantillaContable), typeof(ReglaContable), typeof(AsignacionCuenta), typeof(PartidaOrigen) })
                TypeDescriptor.AddAttributes(tipo, new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            var cabecera = Barra();
            cabecera.Controls.Add(new Label { Text = "Empresa", AutoSize = true });
            empresas.DataSource = Sistema.Empresas.ToList(); cabecera.Controls.Add(empresas);
            var seleccionEmpresa = empresas.SelectedIndex;
            empresas.SelectedIndexChanged += (s, e) =>
            {
                if (empresas.SelectedIndex == seleccionEmpresa) return;
                if ((configuracion != null || documento.SelectedObject != null || productivaEditada) && !Confirmar("Cambiar empresa y descartar cambios sin guardar?"))
                {
                    empresas.SelectedIndex = seleccionEmpresa; return;
                }
                seleccionEmpresa = empresas.SelectedIndex;
                configuracion = null; editor.SelectedObject = null; documento.SelectedObject = null; libros.DataSource = null; Invalidar();
                LimpiarProductiva();
            };
            Controls.Add(tabs); Controls.Add(cabecera);
            var parametros = Pagina("Parametrizacion");
            parametros.Controls.Add(editor);
            var acciones = Barra();
            acciones.Controls.Add(Boton("Leer configuracion", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar);
                configuracion = servicio.Configuracion(Empresa); editor.SelectedObject = configuracion; Invalidar();
            }));
            acciones.Controls.Add(Boton("Guardar nueva version", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Modificar);
                if (configuracion == null) throw new ValidationException("Lea primero la configuracion.");
                if (!Confirmar("Guardar una nueva version?")) return;
                configuracion = servicio.GuardarConfiguracion(configuracion, Usuario); editor.SelectedObject = configuracion; Invalidar();
            }));
            acciones.Controls.Add(Boton("Ver IDs y nombres de cuentas", () =>
            {
                Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar);
                using (var db = new GestionContext()) Mostrar("Cuentas contables", db.CuentasContables.Where(c => c.UserDel == null).ToList()
                    .Select(c => new { c.Id, Codigo = c.Titulo + "." + c.Capitulo + "." + c.Rubro + "." + c.Cuenta + "." + c.Subcuenta, c.Descripcion }).ToList());
            }));
            parametros.Controls.Add(acciones);
            editor.PropertyValueChanged += (s, e) => Invalidar();
            var registracion = Pagina("Simular y registrar");
            registracion.Controls.Add(revision);
            var registroBar = Barra();
            operatoria.DataSource = Enum.GetValues(typeof(OperatoriaContable)); registroBar.Controls.Add(operatoria);
            registroBar.Controls.Add(new Label { Text = "ID documento", AutoSize = true }); registroBar.Controls.Add(origen);
            operatoria.SelectedIndexChanged += (s, e) => Invalidar(); origen.ValueChanged += (s, e) => Invalidar();
            registroBar.Controls.Add(Boton("Simular", () =>
            {
                Exigir("ContabilidadRegistracion", Enums.Accion.Buscar);
                Invalidar();
                var op = (OperatoriaContable)operatoria.SelectedItem;
                ExigirOrigen(op);
                var hecho = ContabilidadService.Complementario(op) ? servicio.CabeceraDocumento(Empresa, op, (int)origen.Value) :
                    OrigenGestion.Obtener(op == OperatoriaContable.CostoVentaAutomatico ? OperatoriaContable.Venta : op, (int)origen.Value);
                if (hecho.Empresa != Empresa || !Sistema.Sucursales.Any(x => x.Id_Sucursal == hecho.Sucursal))
                    throw new ValidationException("Documento fuera de sus empresas o sucursales.");
                if (op == OperatoriaContable.TransferenciaFondos)
                    using (var db = new GestionContext())
                        foreach (var p in hecho.Partidas)
                            if (!Sistema.Sucursales.Any(s => db.Cajas.Any(c => c.Id == p.Caja && c.Id_Sucursal == s.Id_Sucursal)))
                                throw new ValidationException("Caja en una sucursal no habilitada.");
                simulacion = servicio.Simular(Empresa, op, (int)origen.Value);
                revision.DataSource = simulacion.Asientos.SelectMany(a => a.Renglones.Select(r => new { a.Plantilla, r.Cuenta, r.Debe, r.Haber, r.Origen, r.Resolucion })).ToList();
                registrar.Enabled = true;
            }));
            registrar = Boton("Registrar revision", () =>
            {
                Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
                if (simulacion == null) throw new ValidationException("Simule primero.");
                ExigirOrigen(simulacion.Hecho.Operatoria);
                if (!Confirmar("Registrar todos los asientos revisados? El cierre bloquea el ejercicio.")) return;
                var r = servicio.Registrar(Empresa, simulacion.Hecho.Operatoria, simulacion.Hecho.Documento, simulacion.Firma, Usuario);
                Invalidar(); Sistema.Mensaje("Lote #" + r.Id + ". Asientos: " + string.Join(", ", r.Asientos));
            }); registrar.Enabled = false;
            registroBar.Controls.Add(registrar); registracion.Controls.Add(registroBar);
            registroBar.Controls.Add(Boton("Aprobar revision independiente", () =>
            {
                Exigir("ContabilidadAprobacion", Enums.Accion.Modificar);
                if (simulacion == null) throw new ValidationException("Simule y revise antes de aprobar.");
                var motivo = PedirMotivo("Aprobacion independiente");
                if (motivo == null) return;
                servicio.Aprobar(Empresa, simulacion.Hecho.Operatoria, simulacion.Hecho.Documento, simulacion.Firma, motivo, Usuario);
                Sistema.Mensaje("Revision aprobada. El motor exigira esta misma firma al registrar.");
            }));
            var complementarios = Pagina("Documentos complementarios");
            complementarios.Controls.Add(documento);
            var docBar = Barra();
            docBar.Controls.Add(Boton("Nuevo documento", () =>
            {
                Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
                documento.SelectedObject = new DocumentoContable
                {
                    Clave = Guid.NewGuid(),
                    Hecho = new HechoContable
                    {
                        Empresa = Empresa,
                        Operatoria = OperatoriaContable.CostoVenta,
                        Fecha = DateTime.Today
                    }
                };
            }));
            docBar.Controls.Add(Boton("Aprobar con respaldo", () =>
            {
                Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
                var d = documento.SelectedObject as DocumentoContable ?? throw new ValidationException("Cree un documento.");
                if (d.Hecho.Empresa != Empresa || !Sistema.Sucursales.Any(s => s.Id_Sucursal == d.Hecho.Sucursal))
                    throw new ValidationException("Empresa o sucursal no habilitada.");
                if (!Confirmar("Aprobar importes locales y respaldo? No genera movimientos de stock ni liquida sueldos.")) return;
                var guardado = servicio.CrearDocumento(d, Usuario);
                documento.SelectedObject = null;
                operatoria.SelectedItem = guardado.Hecho.Operatoria; origen.Value = guardado.Id;
                Sistema.Mensaje("Documento #" + guardado.Id + " aprobado. Simule y revise antes de registrar.");
            }));
            docBar.Controls.Add(Boton("Listar documentos de la operatoria", () =>
            {
                Exigir("ContabilidadRegistracion", Enums.Accion.Buscar);
                var op = (OperatoriaContable)operatoria.SelectedItem;
                Mostrar("Documentos complementarios", servicio.Documentos(Empresa, op, "").Where(d => Sistema.Sucursales.Any(s => s.Id_Sucursal == d.Hecho.Sucursal))
                    .Select(d => new { d.Id, d.Hecho.Descripcion, d.Respaldo, d.Usuario, d.Creado }).ToList());
            }));
            complementarios.Controls.Add(docBar);
            var cierre = Pagina("Apertura y cierre");
            var cierreBar = Barra();
            cierreBar.Controls.Add(new Label { Text = "Ejercicio origen (ID)", AutoSize = true }); cierreBar.Controls.Add(ejercicio);
            sucursales.DataSource = Sistema.Sucursales.Select(s => new KeyNamePair { Key = s.Id_Sucursal, Name = s.Sucursal }).ToList();
            cierreBar.Controls.Add(sucursales); cierreBar.Controls.Add(fecha);
            foreach (var op in new[] { OperatoriaContable.Apertura, OperatoriaContable.Cierre })
                cierreBar.Controls.Add(Boton("Preparar " + op, () =>
                {
                    Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
                    if (!Confirmar("Preparar desde saldos? No registra hasta revisar en Simular y registrar.")) return;
                    var d = servicio.PrepararEjercicio(Empresa, (int)ejercicio.Value, op, ((KeyNamePair)sucursales.SelectedItem).Key, fecha.Value.Date, Guid.NewGuid(), Usuario);
                    operatoria.SelectedItem = op; origen.Value = d.Id;
                    Sistema.Mensaje("Documento #" + d.Id + " preparado. Revise sus asientos antes de registrar.");
                }));
            cierre.Controls.Add(new Label { Dock = DockStyle.Fill, Text = "Cierre: fecha final de un ejercicio abierto; bloquea el ejercicio al registrar.\r\nApertura: primer dia del nuevo ejercicio, desde un origen cerrado.\r\nConfigurar Saldos / SaldoDeudor y SaldoAcreedor / CuentaOrigen. Realizar antes los ajustes de resultados definidos por el contador." });
            cierre.Controls.Add(cierreBar);
            var libro = Pagina("Mayor, saldos y diario");
            libro.Controls.Add(libros);
            var libroBar = Barra();
            monedas.DataSource = Sistema.Especies.Select(e => new KeyNamePair { Key = e.Key, Name = e.Name }).ToList();
            cuentas.Items.Add(new KeyNamePair { Key = 0, Name = "Sumas y saldos" }); cuentas.SelectedIndex = 0;
            libroBar.Controls.Add(monedas); libroBar.Controls.Add(cuentas); libroBar.Controls.Add(desde); libroBar.Controls.Add(hasta);
            libroBar.Controls.Add(Boton("Cargar cuentas", () =>
            {
                Exigir("ContabilidadDiario", Enums.Accion.Buscar);
                using (var db = new GestionContext())
                {
                    cuentas.Items.Clear(); cuentas.Items.Add(new KeyNamePair { Key = 0, Name = "Sumas y saldos" });
                    foreach (var c in db.CuentasContables.Where(c => c.UserDel == null).ToList()) cuentas.Items.Add(new KeyNamePair { Key = c.Id, Name = c.Descripcion });
                    cuentas.SelectedIndex = 0;
                }
            }));
            libroBar.Controls.Add(Boton("Consultar", () =>
            {
                Exigir("ContabilidadDiario", Enums.Accion.Buscar);
                var cuenta = ((KeyNamePair)cuentas.SelectedItem).Key; var moneda = ((KeyNamePair)monedas.SelectedItem).Key;
                if (cuenta == 0) libros.DataSource = servicio.Saldos(Empresa, moneda, desde.Value.Date, hasta.Value.Date);
                else
                {
                    var mayor = servicio.Mayor(Empresa, moneda, cuenta, desde.Value.Date, hasta.Value.Date);
                    libros.DataSource = mayor.Movimientos;
                }
            }));
            libroBar.Controls.Add(Boton("Diario", () =>
            {
                Exigir("ContabilidadDiario", Enums.Accion.Buscar);
                libros.DataSource = servicio.Diario(Empresa, desde.Value.Date, hasta.Value.Date);
            }));
            libroBar.Controls.Add(Boton("Revertir lote seleccionado", () =>
            {
                Exigir("ContabilidadDiario", Enums.Accion.Eliminar);
                var lote = libros.CurrentRow?.DataBoundItem as RegistroContable ?? throw new ValidationException("Consulte Diario y seleccione un lote.");
                using (var dialogo = new Form { Text = "Reversion del lote #" + lote.Id, Width = 600, Height = 180 })
                {
                    var campos = Barra();
                    var fechaReversion = new DateTimePicker { Format = DateTimePickerFormat.Short };
                    var motivo = new TextBox { Width = 350, MaxLength = 200 };
                    var aceptar = new Button { Text = "Confirmar", DialogResult = DialogResult.OK };
                    campos.Controls.Add(fechaReversion); campos.Controls.Add(new Label { Text = "Motivo", AutoSize = true });
                    campos.Controls.Add(motivo); campos.Controls.Add(aceptar); dialogo.Controls.Add(campos);
                    if (dialogo.ShowDialog(this) != DialogResult.OK || !Confirmar("Generar el contraasiento? El original se conserva.")) return;
                    var r = servicio.Revertir(Empresa, lote.Id, fechaReversion.Value.Date, motivo.Text, Usuario);
                    Sistema.Mensaje("Reversion #" + r.Id + " registrada.");
                }
            }));
            libro.Controls.Add(libroBar);
            ConfigurarProductiva();
            FormClosing += (s, e) => { if ((configuracion != null || documento.SelectedObject != null || productivaEditada) && !Confirmar("Cerrar y descartar cambios sin guardar?")) e.Cancel = true; };
        }
        private static ComboBox Combo() => new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Name", Width = 180 };
        private static DataGridView Grilla() => new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells, AllowUserToAddRows = false };
        private static FlowLayoutPanel Barra() => new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(6), WrapContents = true };
        private TabPage Pagina(string texto) { var p = new TabPage(texto); tabs.TabPages.Add(p); return p; }
        private Button Boton(string texto, Action accion)
        {
            var boton = new Button { Text = texto, AutoSize = true };
            boton.Click += (s, e) =>
            {
                boton.Enabled = false;
                try { accion(); }
                catch (ValidationException ex) { Sistema.Mensaje(ex.Message); }
                catch (Exception ex) { Sistema.MensajeError(ex); }
                finally { boton.Enabled = boton != registrar || simulacion != null; }
            };
            return boton;
        }
        private void Invalidar() { simulacion = null; revision.DataSource = null; if (registrar != null) registrar.Enabled = false; }
        private static bool Confirmar(string texto) => MessageBox.Show(texto, "Contabilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        private static void Exigir(string pantalla, Enums.Accion accion)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, pantalla, Enums.Accion.Ingresar) || !Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, pantalla, accion))
                throw new ValidationException("Sin permiso para " + pantalla + ".");
        }
        private static void ExigirOrigen(OperatoriaContable op)
        {
            if (op == OperatoriaContable.CostoVentaAutomatico) op = OperatoriaContable.Venta;
            if (ContabilidadService.Complementario(op)) return;
            var modulo = op == OperatoriaContable.Venta || op == OperatoriaContable.Compra ? Enums.Modulos.Gestion : Enums.Modulos.Tesoreria;
            var pantalla = op == OperatoriaContable.Venta ? "ComprobantesVentas" : op == OperatoriaContable.Compra ? "ComprobantesCompras"
                : op == OperatoriaContable.Cobranza ? "Recibos" : op == OperatoriaContable.Pago ? "OrdenesPago" : "Transferencias";
            if (!Seguridad.ObtenerPermiso(modulo, pantalla, Enums.Accion.Ingresar) || !Seguridad.ObtenerPermiso(modulo, pantalla, Enums.Accion.Buscar))
                throw new ValidationException("Sin permiso sobre el documento de origen.");
        }
        private void Mostrar(string titulo, object filas)
        {
            using (var f = new Form { Text = titulo, Width = 1000, Height = 600 })
            {
                var g = Grilla(); g.DataSource = filas; f.Controls.Add(g); f.ShowDialog(this);
            }
        }
    }
    public sealed class PrioridadesEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.Modal;
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (var f = new Form { Text = "Prioridades de resolucion", Width = 500, Height = 450 })
            {
                var lista = new ListBox { Dock = DockStyle.Fill };
                foreach (var d in (List<DimensionCuenta>)value) lista.Items.Add(d);
                var barra = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
                var opciones = new ComboBox { DataSource = Enum.GetValues(typeof(DimensionCuenta)), DropDownStyle = ComboBoxStyle.DropDownList };
                barra.Controls.Add(opciones);
                var agregar = new Button { Text = "Agregar" }; agregar.Click += (s, e) => { if (!lista.Items.Contains(opciones.SelectedItem)) lista.Items.Add(opciones.SelectedItem); }; barra.Controls.Add(agregar);
                var quitar = new Button { Text = "Quitar" }; quitar.Click += (s, e) => { if (lista.SelectedIndex >= 0) lista.Items.RemoveAt(lista.SelectedIndex); }; barra.Controls.Add(quitar);
                var subir = new Button { Text = "Subir" }; subir.Click += (s, e) => { var i = lista.SelectedIndex; if (i > 0) { var item = lista.Items[i]; lista.Items.RemoveAt(i); lista.Items.Insert(i - 1, item); lista.SelectedIndex = i - 1; } }; barra.Controls.Add(subir);
                var aceptar = new Button { Text = "Aceptar", DialogResult = DialogResult.OK }; barra.Controls.Add(aceptar);
                f.Controls.Add(lista); f.Controls.Add(barra);
                return f.ShowDialog() == DialogResult.OK ? lista.Items.Cast<DimensionCuenta>().ToList() : value;
            }
        }
    }
}
