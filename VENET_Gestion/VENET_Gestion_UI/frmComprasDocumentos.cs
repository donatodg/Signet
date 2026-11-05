using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VENET_Common;
using VENET_Gestion_BL;

namespace VENET_Gestion_UI
{
    public sealed class frmComprasDocumentos : Form
    {
        private readonly ComprasDocumentosService servicio = new ComprasDocumentosService();
        private readonly FlowLayoutPanel herramientas = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = true };
        private readonly FlowLayoutPanel acciones = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
        private readonly ComboBox sucursal = new ComboBox { Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cargas = new ComboBox { Width = 450, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TableLayoutPanel campos = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2 };
        private readonly DataGridView items = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false, AllowUserToAddRows = false, AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells, MultiSelect = false };
        private readonly PictureBox imagen = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.DimGray };
        private readonly TextBox resultado = new TextBox { Dock = DockStyle.Bottom, Multiline = true, ReadOnly = true, Height = 115, ScrollBars = ScrollBars.Vertical };
        private readonly CheckBox revisado = new CheckBox { Text = "Revise el original, tipo, proveedor, productos, unidades, impuestos y totales.", AutoSize = true };
        private readonly ErrorProvider errores = new ErrorProvider();
        private readonly Button cancelar = new Button { Text = "Cancelar lectura", AutoSize = true, Enabled = false };
        private readonly SplitContainer contenido = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 400, Width = 1200 };
        private readonly Label estado = new Label { Dock = DockStyle.Top, AutoSize = true };
        private readonly Label paginaTexto = new Label { AutoSize = true };
        private OpcionesComprasDocumento opciones;
        private ImportacionCompra actual;
        private RevisionCompraDocumento revision;
        private ResultadoRevisionCompra validacion;
        private List<byte[]> paginas = new List<byte[]>();
        private readonly HashSet<Control> invalidos = new HashSet<Control>();
        private CancellationTokenSource lectura;
        private int pagina;
        private bool ocupado, cambiando, cambios;
        private Guid claveCarga = Guid.NewGuid();
        private List<ArchivoCompra> archivosSeleccionados;
        private readonly Dictionary<int, string> nombresProductos = new Dictionary<int, string>();

        public frmComprasDocumentos()
        {
            ComprasDocumentosService.ExigirPermiso();
            Text = "Compras desde foto / PDF - revision obligatoria";
            Width = 1400; Height = 900; MinimumSize = new Size(900, 600); StartPosition = FormStartPosition.CenterParent;
            errores.ContainerControl = this;
            items.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
            herramientas.Controls.Add(new Label { Text = "Sucursal de carga:", AutoSize = true }); herramientas.Controls.Add(sucursal);
            Boton(herramientas, "Elegir archivos", ElegirArchivos);
            Boton(herramientas, "Guardar originales / reintentar", async () =>
            {
                if (archivosSeleccionados == null) throw new InvalidOperationException("Seleccione archivos primero.");
                if (!Descartar()) return;
                await Abrir(servicio.Cargar(claveCarga, Valor(sucursal), archivosSeleccionados)); ActualizarLista();
            });
            herramientas.Controls.Add(cargas);
            Boton(herramientas, "Actualizar cargas", () => { ActualizarLista(); return Task.CompletedTask; });
            Boton(herramientas, "Abrir carga", async () =>
            {
                if (cargas.SelectedItem is CargaOpcion c && Descartar()) await Abrir(servicio.Obtener(c.Id));
            });
            Boton(herramientas, "Leer / releer con modelo local", async () =>
            {
                if (actual == null || actual.Compra.HasValue) throw new InvalidOperationException("Abra una carga no guardada.");
                if (!opciones.Configurado) throw new InvalidOperationException("Configure SIGNET_COMPRAS_VISION_MODELO y el servidor local de vision.");
                if ((cambios || actual.Lectura != null) && !Confirmar("Releer reemplaza la propuesta y correcciones actuales. Los originales se conservan. ¿Continuar?")) return;
                lectura = new CancellationTokenSource(); cancelar.Enabled = true;
                try { await Abrir(await servicio.AnalizarAsync(actual.Id, actual.Version, lectura.Token)); ActualizarLista(); }
                finally { cancelar.Enabled = false; lectura.Dispose(); lectura = null; }
            });
            Boton(herramientas, "Descargar originales", GuardarOriginales);
            cancelar.Click += (s, e) => lectura?.Cancel();
            var pie = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
            pie.Controls.Add(cancelar);
            pie.Controls.Add(new Label { Text = "JPEG / PNG / PDF: maximo 6 archivos/paginas, 12 MB. Decimales con punto. Lectura local; no confirma ni paga.", AutoSize = true });
            var navegacion = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
            Boton(navegacion, "Anterior", () => { pagina = Math.Max(0, pagina - 1); MostrarPagina(); return Task.CompletedTask; });
            navegacion.Controls.Add(paginaTexto);
            Boton(navegacion, "Siguiente", () => { pagina = Math.Min(paginas.Count - 1, pagina + 1); MostrarPagina(); return Task.CompletedTask; });
            contenido.Panel1.Controls.Add(imagen); contenido.Panel1.Controls.Add(navegacion);
            var cabecera = new Panel { Dock = DockStyle.Top, Height = 270, AutoScroll = true };
            cabecera.Controls.Add(campos);
            contenido.Panel2.Controls.Add(items); contenido.Panel2.Controls.Add(cabecera);
            Boton(acciones, "Agregar item faltante", () =>
            {
                ComprobarEdicion(); if (revision.Documento.Items.Count >= 200) throw new InvalidOperationException("Maximo 200 items.");
                revision.Documento.Items.Add(new ItemCompraLeido()); Cambiar(); EnlazarItems(); return Task.CompletedTask;
            });
            Boton(acciones, "Quitar item", () =>
            {
                ComprobarEdicion();
                if (items.CurrentRow?.DataBoundItem is ItemCompraLeido p && Confirmar("¿Quitar este item?")) { revision.Documento.Items.Remove(p); Cambiar(); EnlazarItems(); }
                return Task.CompletedTask;
            });
            Boton(acciones, "Elegir producto del item", ElegirProducto);
            acciones.Controls.Add(revisado);
            revisado.CheckedChanged += (s, e) => { if (!cambiando && revision != null) { revision.Revisado = revisado.Checked; validacion = null; cambios = true; } };
            Boton(acciones, "Guardar correcciones", () =>
            {
                ComprobarEdicion(); var r = servicio.GuardarRevision(revision); actual = r; revision.Version = r.Version;
                validacion = null; cambios = false; ActualizarLista(); resultado.Text = "Correcciones guardadas. No se genero una compra."; return Task.CompletedTask;
            });
            Boton(acciones, "Validar borrador", () =>
            {
                ComprobarEdicion(); validacion = null; validacion = servicio.Revisar(revision);
                resultado.Text = "Total recalculado: " + validacion.Total.ToString("N2") + Environment.NewLine
                    + string.Join(Environment.NewLine, validacion.Errores.Concat(validacion.Advertencias)); return Task.CompletedTask;
            });
            Boton(acciones, "Crear compra PENDIENTE", async () =>
            {
                ComprobarEdicion();
                if (validacion == null || validacion.Errores.Count > 0 || validacion.Firma == null) throw new InvalidOperationException("Valide el borrador sin errores antes de guardar.");
                if (!Confirmar("¿Crear compra PENDIENTE? No confirma, no mueve stock, no paga ni genera asientos.")) return;
                var r = servicio.GuardarCompra(revision, validacion.Firma); cambios = false;
                await Abrir(servicio.Obtener(revision.Id)); ActualizarLista();
                resultado.Text = "Compra #" + r.Compra + " creada PENDIENTE. Confirme desde Comprobantes de compras por el circuito habitual.";
            });
            PrepararColumnas();
            items.CellValueChanged += (s, e) => { if (!cambiando) Cambiar(); };
            items.CellFormatting += (s, e) =>
            {
                if (items.Columns[e.ColumnIndex].DataPropertyName == "Producto" && e.Value is int id)
                { e.Value = nombresProductos.TryGetValue(id, out var nombre) ? nombre : "No disponible #" + id; e.FormattingApplied = true; }
            };
            items.DataError += (s, e) => { e.ThrowException = false; resultado.Text = "Valor invalido en el item. Corrijalo antes de validar o guardar."; };
            items.CellEndEdit += (s, e) => items.Rows[e.RowIndex].ErrorText = "";
            items.CellValidating += (s, e) =>
            {
                if (items.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn c && c.ValueType == typeof(decimal?))
                {
                    var texto = Convert.ToString(e.FormattedValue); decimal numero;
                    if (!string.IsNullOrEmpty(texto) && !decimal.TryParse(texto, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out numero))
                    { e.Cancel = true; items.Rows[e.RowIndex].ErrorText = "Ingrese un numero valido con punto decimal, sin separadores de miles."; }
                }
            };
            Controls.Add(contenido); Controls.Add(resultado); Controls.Add(acciones); Controls.Add(estado); Controls.Add(herramientas); Controls.Add(pie);
            Shown += async (s, e) => await Ejecutar(() =>
            {
                opciones = servicio.Opciones(); Poblar(sucursal, opciones.Sucursales, 0);
                if (opciones.Sucursales.Count == 1) sucursal.SelectedIndex = 0;
                ActualizarLista(); estado.Text = opciones.Configurado ? "Lector local: " + opciones.Modelo : "Sin modelo local configurado. Puede guardar originales y retomar despues.";
                return Task.CompletedTask;
            });
            FormClosing += (s, e) => { if (ocupado || !Descartar()) e.Cancel = true; };
            FormClosed += (s, e) => { imagen.Image?.Dispose(); errores.Dispose(); };
        }
        private void Boton(FlowLayoutPanel panel, string texto, Func<Task> accion)
        {
            var b = new Button { Text = texto, AutoSize = true };
            b.Click += async (s, e) => await Ejecutar(accion); panel.Controls.Add(b);
        }
        private async Task Ejecutar(Func<Task> accion)
        {
            if (ocupado) return;
            ocupado = true; herramientas.Enabled = acciones.Enabled = contenido.Enabled = false; UseWaitCursor = true;
            try { await accion(); }
            catch (Exception ex) { Sistema.Mensaje(ex.Message); resultado.Text = ex.Message; }
            finally { ocupado = false; herramientas.Enabled = acciones.Enabled = contenido.Enabled = true; UseWaitCursor = false; }
        }
        private bool Confirmar(string texto) => MessageBox.Show(this, texto, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        private bool Descartar() => !cambios || Confirmar("Hay correcciones sin guardar. ¿Descartarlas?");
        private static int Valor(ComboBox c) => c.SelectedValue is int n ? n : 0;
        private static void Poblar(ComboBox c, List<KeyNamePair> lista, int valor)
        { c.DisplayMember = "Name"; c.ValueMember = "Key"; c.DataSource = lista.ToList(); c.SelectedValue = valor; if (valor == 0) c.SelectedIndex = -1; }
        private sealed class CargaOpcion { public Guid Id { get; set; } public string Texto { get; set; } public override string ToString() => Texto; }
        private void ActualizarLista()
        {
            cargas.DataSource = servicio.Listar().Select(c => new CargaOpcion { Id = c.Id, Texto = c.Fecha.ToLocalTime().ToString("g") + " - " + string.Join(", ", c.Archivos) + " - " + c.Estado + (c.Compra.HasValue ? " #" + c.Compra : "") }).ToList();
        }
        private Task ElegirArchivos()
        {
            using (var dialogo = new OpenFileDialog { Filter = "Factura (JPEG, PNG, PDF)|*.jpg;*.jpeg;*.png;*.pdf", Multiselect = true })
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK) return Task.CompletedTask;
                if (dialogo.FileNames.Length > 6 || dialogo.FileNames.Sum(p => new FileInfo(p).Length) > ComprasDocumentosLector.MaxBytes)
                    throw new InvalidOperationException("Maximo 6 archivos y 12 MB.");
                archivosSeleccionados = dialogo.FileNames.Select(p => new ArchivoCompra { Nombre = Path.GetFileName(p), Base64 = Convert.ToBase64String(File.ReadAllBytes(p)) }).ToList();
                claveCarga = Guid.NewGuid(); resultado.Text = "Seleccionados: " + string.Join(", ", archivosSeleccionados.Select(a => a.Nombre)) + ". Pulse Guardar originales.";
            }
            return Task.CompletedTask;
        }
        private Task GuardarOriginales()
        {
            if (actual == null) throw new InvalidOperationException("Abra una carga.");
            for (int i = 0; i < actual.Archivos.Count; i++)
                using (var dialogo = new SaveFileDialog { FileName = actual.Archivos[i], Filter = "Original|*.*", OverwritePrompt = true })
                    if (dialogo.ShowDialog(this) == DialogResult.OK) File.WriteAllBytes(dialogo.FileName, servicio.Original(actual.Id, i).Datos);
            return Task.CompletedTask;
        }
        private Task Abrir(ImportacionCompra carga)
        {
            actual = carga; revision = null; validacion = null; cambios = false; invalidos.Clear(); errores.Clear();
            paginas = servicio.Vista(carga.Id); pagina = 0; MostrarPagina();
            if (carga.Lectura != null || carga.Revision != null) revision = servicio.Proponer(carga.Id);
            cambiando = true;
            try { ConstruirCampos(); EnlazarItems(); revisado.Checked = revision?.Revisado ?? false; }
            finally { cambiando = false; }
            estado.Text = carga.Estado + " - version " + carga.Version + (carga.Compra.HasValue ? " - Compra pendiente #" + carga.Compra : "");
            resultado.Text = carga.Error ?? "Originales conservados. La lectura no verifica autenticidad fiscal ni CAE/QR.";
            return Task.CompletedTask;
        }
        private void MostrarPagina()
        {
            var anterior = imagen.Image; imagen.Image = null; anterior?.Dispose();
            if (paginas.Count == 0) { paginaTexto.Text = "Sin paginas"; return; }
            using (var s = new MemoryStream(paginas[pagina])) using (var img = Image.FromStream(s)) imagen.Image = new Bitmap(img);
            paginaTexto.Text = (pagina + 1) + " / " + paginas.Count;
        }
        private void Cambiar()
        {
            if (cambiando || revision == null) return;
            validacion = null; cambios = true; revision.Revisado = false; revisado.Checked = false;
        }
        private void ComprobarEdicion()
        {
            if (revision == null || actual.Compra.HasValue) throw new InvalidOperationException("Abra una propuesta no guardada.");
            if (!items.EndEdit() || invalidos.Count > 0 || items.Rows.Cast<DataGridViewRow>().Any(r => !string.IsNullOrEmpty(r.ErrorText)) || !ValidateChildren())
                throw new InvalidOperationException("Corrija los campos invalidos antes de continuar.");
        }
        private void Campo(string titulo, Control c)
        {
            var n = campos.RowCount++; campos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            campos.Controls.Add(new Label { Text = titulo, AutoSize = true, Margin = new Padding(3, 7, 3, 3) }, 0, n);
            c.Width = 380; campos.Controls.Add(c, 1, n);
        }
        private void Texto(string titulo, string valor, Action<string> cambiar)
        {
            var c = new TextBox { Text = valor ?? "", MaxLength = 4000 };
            c.TextChanged += (s, e) => { cambiar(c.Text); Cambiar(); }; Campo(titulo, c);
        }
        private void Numero(string titulo, decimal? valor, Action<decimal?> cambiar)
        {
            var c = new TextBox { Text = valor?.ToString("0.############################", CultureInfo.InvariantCulture) ?? "" };
            c.TextChanged += (s, e) =>
            {
                Cambiar(); decimal n;
                if (c.Text.Length == 0) { cambiar(null); invalidos.Remove(c); errores.SetError(c, ""); }
                else if (decimal.TryParse(c.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out n))
                { cambiar(n); invalidos.Remove(c); errores.SetError(c, ""); }
                else { invalidos.Add(c); errores.SetError(c, "Use punto decimal, sin separadores de miles."); }
            }; Campo(titulo, c);
        }
        private void Fecha(string titulo, DateTime? valor, Action<DateTime?> cambiar)
        {
            var valida = valor.HasValue && valor.Value.Date >= DateTimePicker.MinimumDateTime && valor.Value.Date <= DateTimePicker.MaximumDateTime;
            var c = new DateTimePicker { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Value = valida ? valor.Value.Date : DateTime.Today, Checked = valida };
            c.ValueChanged += (s, e) => { cambiar(c.Checked ? c.Value.Date : (DateTime?)null); Cambiar(); }; Campo(titulo, c);
        }
        private void Elegir(string titulo, List<KeyNamePair> lista, int valor, Action<int> cambiar)
        {
            var c = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList }; Poblar(c, lista, valor);
            c.SelectedValueChanged += (s, e) => { cambiar(Valor(c)); Cambiar(); }; Campo(titulo, c);
        }
        private void ConstruirCampos()
        {
            foreach (Control c in campos.Controls.Cast<Control>().ToArray()) c.Dispose();
            campos.Controls.Clear(); campos.RowCount = 0; campos.RowStyles.Clear();
            if (revision == null) return;
            var r = revision; var d = r.Documento;
            campos.Enabled = items.Enabled = !actual.Compra.HasValue;
            Elegir("Proveedor", opciones.Proveedores, r.Proveedor, v =>
            {
                r.Proveedor = v; foreach (var p in d.Items) { p.Producto = null; p.RecordarEquivalencia = false; }
                EnlazarItems();
            });
            Elegir("Tipo de comprobante (revisar signo)", opciones.Tipos, r.TipoComprobante, v => r.TipoComprobante = v);
            Elegir("Deposito", opciones.Depositos, r.Deposito, v => r.Deposito = v);
            Elegir("Centro de costo", opciones.Centros, r.CentroCosto, v => r.CentroCosto = v);
            Elegir("Forma de pago", opciones.Formas, r.FormaPago, v => r.FormaPago = v);
            Elegir("Moneda del sistema", opciones.Monedas, r.Moneda, v => r.Moneda = v);
            Numero("Cotizacion revisada", r.Cotizacion == 0 ? (decimal?)null : r.Cotizacion, v => r.Cotizacion = v ?? 0);
            Texto("Proveedor leido", d.Proveedor, v => d.Proveedor = v); Texto("CUIT del original", d.Cuit, v => d.Cuit = v);
            Texto("Tipo leido", d.Tipo, v => d.Tipo = v); Texto("Letra", d.Letra, v => d.Letra = v);
            Texto("Punto de venta", d.PuntoVenta, v => d.PuntoVenta = v); Texto("Numero", d.Numero, v => d.Numero = v);
            Texto("Moneda leida (ISO)", d.Moneda, v => d.Moneda = v);
            Fecha("Fecha factura", d.Fecha, v => d.Fecha = v);
            Fecha("Recepcion", r.Recepcion, v => r.Recepcion = v ?? DateTime.MinValue);
            Fecha("Vencimiento", r.Vencimiento, v => r.Vencimiento = v ?? DateTime.MinValue);
            Numero("Total de la factura", d.Total, v => d.Total = v); Numero("Neto leido (opcional)", d.Neto, v => d.Neto = v);
            Numero("IVA leido (opcional)", d.Iva, v => d.Iva = v); Numero("No gravado", d.NoGravado, v => d.NoGravado = v);
            Numero("Otros impuestos", d.OtrosImpuestos, v => d.OtrosImpuestos = v);
            Numero("Percepcion IVA", d.PercepcionIva, v => d.PercepcionIva = v); Numero("Percepcion IIBB", d.PercepcionIibb, v => d.PercepcionIibb = v);
            Numero("Percepcion Ganancias", d.PercepcionGanancias, v => d.PercepcionGanancias = v); Numero("ITC", d.Itc, v => d.Itc = v);
            Numero("Percepcion IIBB Capital", d.PercepcionIibbCapital, v => d.PercepcionIibbCapital = v);
            Numero("Descuento de cabecera", d.Descuento, v => d.Descuento = v);
            Campo("Advertencias del lector", new TextBox { Multiline = true, ReadOnly = true, Height = 70, Text = string.Join(Environment.NewLine, d.Advertencias) });
        }
        private void PrepararColumnas()
        {
            var columnas = new[] { "Codigo", "Descripcion", "Unidad", "Producto", "Cantidad", "CantidadStock", "PrecioNeto", "Descuento", "Iva", "Total" };
            var titulos = new[] { "Codigo proveedor", "Descripcion original", "Unidad leida", "Producto (usar Elegir)", "Cantidad", "Cantidad stock", "Precio NETO sin IVA", "Dto %", "IVA %", "Total leido" };
            for (int i = 0; i < columnas.Length; i++)
                items.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = columnas[i],
                    HeaderText = titulos[i],
                    ReadOnly = columnas[i] == "Producto",
                    ValueType = i >= 4 ? typeof(decimal?) : null
                });
            var tipoTotal = new DataGridViewComboBoxColumn { DataPropertyName = "TipoTotal", HeaderText = "Total impreso: Neto / ConIva" };
            tipoTotal.Items.AddRange("Neto", "ConIva"); items.Columns.Add(tipoTotal);
            items.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "RecordarEquivalencia", HeaderText = "Recordar codigo proveedor" });
        }
        private void EnlazarItems()
        {
            var previo = cambiando; cambiando = true;
            try
            {
                nombresProductos.Clear();
                if (revision != null)
                    foreach (var p in servicio.ProductosPorId(revision.Documento.Items.Where(i => i.Producto.HasValue).Select(i => i.Producto.Value).Distinct().ToList()))
                        nombresProductos[p.Key] = p.Name;
                items.DataSource = revision == null ? null : new BindingList<ItemCompraLeido>(revision.Documento.Items);
            }
            finally { cambiando = previo; }
        }
        private Task ElegirProducto()
        {
            ComprobarEdicion();
            if (!(items.CurrentRow?.DataBoundItem is ItemCompraLeido p)) throw new InvalidOperationException("Seleccione un item.");
            using (var dialogo = new Form { Text = "Buscar producto activo por codigo, barras o descripcion", Width = 700, Height = 420, StartPosition = FormStartPosition.CenterParent })
            {
                var entrada = new TextBox { Dock = DockStyle.Top, MaxLength = 100 };
                var lista = new ListBox { Dock = DockStyle.Fill, DisplayMember = "Name", ValueMember = "Key" };
                var botones = new FlowLayoutPanel { Dock = DockStyle.Bottom, AutoSize = true };
                var buscar = new Button { Text = "Buscar", AutoSize = true };
                buscar.Click += (s, e) => { try { lista.DataSource = servicio.Productos(entrada.Text); lista.SelectedIndex = -1; } catch (Exception ex) { Sistema.Mensaje(ex.Message); } };
                var elegir = new Button { Text = "Asignar producto", AutoSize = true };
                elegir.Click += (s, e) => { if (lista.SelectedItem is KeyNamePair) dialogo.DialogResult = DialogResult.OK; };
                botones.Controls.Add(buscar); botones.Controls.Add(elegir); dialogo.Controls.Add(lista); dialogo.Controls.Add(entrada); dialogo.Controls.Add(botones);
                if (dialogo.ShowDialog(this) == DialogResult.OK && lista.SelectedItem is KeyNamePair seleccionado)
                {
                    p.Producto = seleccionado.Key; p.CantidadStock = null; p.RecordarEquivalencia = false;
                    Cambiar(); EnlazarItems(); resultado.Text = "Producto seleccionado: " + seleccionado.Name + ". Revise la cantidad de stock/conversion.";
                }
            }
            return Task.CompletedTask;
        }
    }
}
