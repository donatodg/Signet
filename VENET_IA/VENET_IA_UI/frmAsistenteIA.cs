using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VENET_Common;
using VENET_IA_BL;

namespace VENET_IA_UI
{
    /// <summary>
    /// Asistente de datos: el usuario pregunta en lenguaje natural y la IA responde con datos consultados en la base.
    /// Configuración en Parámetros del sistema (IA_*). Acceso con el permiso Sistema / AsistenteIA / Ingresar.
    /// </summary>
    public partial class frmAsistenteIA : MultiForm
    {
        private static readonly string[] Sugerencias =
        {
            "Los 5 productos más vendidos el último mes",
            "Los 10 clientes con más facturación este año",
            "Ventas totales por mes de este año",
            "¿Cuántos clientes nuevos hubo este mes?"
        };

        private static readonly Color ColorUsuario = Color.FromArgb(37, 99, 235);
        private static readonly Color ColorAsistente = Color.FromArgb(124, 58, 237);
        private static readonly Color ColorError = Color.FromArgb(185, 28, 28);

        private readonly List<AsistenteIAMensaje> _historial = new List<AsistenteIAMensaje>();
        private AsistenteIAResultado _resultado;
        private List<string> _consultas = new List<string>();
        private CancellationTokenSource _cts;
        private AsistenteIAVentaBorrador _venta;
        private readonly Button _btnVenta = new Button { Text = "Revisar venta", Dock = DockStyle.Right, Width = 120, Enabled = false };

        public frmAsistenteIA()
        {
            InitializeComponent();
            pnlSuperior.Controls.Add(_btnVenta);
            _btnVenta.BringToFront();
            _btnVenta.Click += AbrirVenta;
            Icon = AsistenteIAIconos.Icono();
            foreach (var s in Sugerencias)
            {
                var l = new LinkLabel { Text = s, AutoSize = true, Margin = new Padding(0, 6, 16, 0), LinkBehavior = LinkBehavior.HoverUnderline, LinkColor = ColorAsistente };
                l.LinkClicked += (o, e) => { if (_cts == null) { txtPregunta.Text = ((LinkLabel)o).Text; Enviar(); } };
                flpSugerencias.Controls.Add(l);
            }
        }

        private async void frmAsistenteIA_Load(object sender, EventArgs e)
        {
            MostrarBienvenida();
            try
            {
                var estado = await Task.Run(() =>
                {
                    var c = AsistenteIAConfiguracion.Cargar();
                    return new { c.Configurado, c.LimiteTokensMes, Tokens = c.TokensDelMes() };
                });
                if (IsDisposed) return;
                MostrarUso(estado.Tokens, estado.LimiteTokensMes);
                if (!estado.Configurado)
                    Agregar("El asistente no está configurado: falta cargar la clave de API en el parámetro del sistema IA_ApiKey (Configuración > Parámetros).", ColorError);
            }
            catch (Exception ex)
            {
                if (!IsDisposed) lblUso.Text = ex is AsistenteIAException ? ex.Message : "No se pudo leer la configuración del asistente.";
            }
            txtPregunta.Focus();
        }

        private void frmAsistenteIA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null) _cts.Cancel();
        }

        private void MostrarBienvenida()
        {
            rtbConversacion.Clear();
            Agregar("Asistente", ColorAsistente, FontStyle.Bold);
            Agregar("Consultame datos o pedime preparar una venta indicando cliente, productos y cantidades. Te muestro un borrador y podes abrir el formulario para revisarlo y guardarlo manualmente. El chat no guarda, factura en AFIP ni cobra.", null);
        }

        private void MostrarUso(long tokens, long limite)
        {
            lblUso.Text = limite > 0
                ? "Uso del mes: " + AsistenteIAManager.FormatearNumero(tokens) + " de " + AsistenteIAManager.FormatearNumero(limite) + " tokens (" + Math.Min(100, tokens * 100 / limite) + "%)"
                : "Uso del mes: " + AsistenteIAManager.FormatearNumero(tokens) + " tokens (sin tope)";
            lblUso.ForeColor = limite > 0 && tokens >= limite * 9 / 10 ? ColorError : Color.DimGray;
        }

        private void txtPregunta_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter envía; Shift+Enter agrega una línea.
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                Enviar();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_cts != null) _cts.Cancel();
        }

        private async void Enviar()
        {
            var pregunta = txtPregunta.Text.Trim();
            if (pregunta.Length == 0 || _cts != null) return;

            txtPregunta.Clear();
            Agregar("Vos", ColorUsuario, FontStyle.Bold);
            Agregar(pregunta, null);
            int inicioPensando = rtbConversacion.TextLength;
            Agregar("Consultando la base de datos...", Color.Gray, FontStyle.Italic);
            int largoPensando = rtbConversacion.TextLength - inicioPensando;

            Ocupado(true);
            _cts = new CancellationTokenSource();
            var historial = _historial.ToList();
            try
            {
                var token = _cts.Token;
                var r = await Task.Run(() =>
                {
                    var m = new AsistenteIAManager(AsistenteIAConfiguracion.Cargar()) { Empresa = Empresa() };
                    return m.PreguntarAsync(historial, pregunta, token, _venta == null ? null : _venta.Solicitud);
                }, token);
                if (IsDisposed) return;

                QuitarPensando(inicioPensando, largoPensando);
                _historial.Add(new AsistenteIAMensaje { Rol = AsistenteIAMensaje.RolUsuario, Texto = pregunta });
                _historial.Add(new AsistenteIAMensaje { Rol = AsistenteIAMensaje.RolAsistente, Texto = r.Respuesta });
                Agregar("Asistente", ColorAsistente, FontStyle.Bold);
                Agregar(r.Respuesta, null);
                Agregar("(" + AsistenteIAManager.FormatearNumero(r.TokensPregunta) + " tokens)", Color.Gray, FontStyle.Italic, 8F);
                MostrarResultado(r.Resultado, r.Consultas);
                MostrarUso(r.TokensMes, r.LimiteMes);
                if (r.Venta != null)
                {
                    _venta = r.Venta;
                    Agregar("VENTA SIN GUARDAR: " + r.Venta.Cliente + " | " + r.Venta.Sucursal + " | " + r.Venta.TipoComprobante
                        + " | " + r.Venta.FormaPago, ColorAsistente, FontStyle.Bold);
                    foreach (var linea in r.Venta.Lineas)
                        Agregar(linea.Producto + ": " + linea.Cantidad + " x " + linea.PrecioUnitario.ToString("N2")
                            + " " + linea.Moneda + " | Desc. " + linea.Descuento + "% | IVA " + linea.Iva.ToString("N2")
                            + " | Total " + linea.Total.ToString("N2"), null);
                    Agregar("Total en pesos: " + r.Venta.Total.ToString("N2"), null, FontStyle.Bold);
                    foreach (var advertencia in r.Venta.Advertencias) Agregar(advertencia, Color.Gray);
                    _btnVenta.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                QuitarPensando(inicioPensando, largoPensando);
                string mensaje;
                if (ex is OperationCanceledException) mensaje = "Consulta cancelada.";
                else if (ex is AsistenteIAException) mensaje = ex.Message;
                else mensaje = "Ocurrió un error inesperado: " + ex.Message;
                Agregar(mensaje, ColorError);
                if (!(ex is OperationCanceledException) && !(ex is AsistenteIAException)) Sistema.MensajeError(ex);
            }
            finally
            {
                if (_cts != null) _cts.Dispose();
                _cts = null;
                if (!IsDisposed)
                {
                    Ocupado(false);
                    txtPregunta.Focus();
                }
            }
        }

        private static string Empresa()
        {
            return System.Configuration.ConfigurationManager.AppSettings["CurrentEmpresa"];
        }

        private void Ocupado(bool ocupado)
        {
            if (ocupado) _btnVenta.Enabled = false;
            btnEnviar.Enabled = !ocupado;
            btnEnviar.Text = ocupado ? "Pensando..." : "Enviar";
            btnCancelar.Visible = ocupado;
            btnNueva.Enabled = !ocupado;
            flpSugerencias.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            txtPregunta.UseWaitCursor = false;
        }

        private void QuitarPensando(int inicio, int largo)
        {
            if (largo <= 0 || inicio + largo > rtbConversacion.TextLength) return;
            rtbConversacion.ReadOnly = false;
            rtbConversacion.Select(inicio, largo);
            rtbConversacion.SelectedText = "";
            rtbConversacion.ReadOnly = true;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            _venta = null;
            _btnVenta.Enabled = false;
            _historial.Clear();
            MostrarResultado(null, new List<string>());
            MostrarBienvenida();
            txtPregunta.Focus();
        }

        private async void AbrirVenta(object sender, EventArgs e)
        {
            if (_venta == null || _cts != null) return;
            Ocupado(true);
            _cts = new CancellationTokenSource();
            try
            {
                var solicitud = _venta.Solicitud;
                var actualizado = await Task.Run(() => new AsistenteIAVentas().Preparar(solicitud), _cts.Token);
                _cts.Token.ThrowIfCancellationRequested();
                if (IsDisposed) return;
                Agregar("Se actualizaron precios y permisos. Revise el total en el formulario antes de guardar.", Color.Gray);
                // Gestion_UI ya referencia IA_UI; cargar el formulario como hace Sistema.AbrirForm evita una referencia circular.
                var tipo = Assembly.Load("VENET_Gestion_UI").GetType("VENET_Gestion_UI.frmComprobantesVentas_AddMod", true);
                using (var formulario = (Form)Activator.CreateInstance(tipo, new object[] { actualizado.Comprobante, actualizado.TipoComprobante, true }))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        _venta = null;
                        Agregar("Venta guardada desde el formulario. No se emitio en AFIP ni se realizo un cobro desde el chat.", ColorAsistente);
                    }
                    else _btnVenta.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                var causa = (ex as TargetInvocationException)?.InnerException ?? ex;
                if (causa is OperationCanceledException) Agregar("Apertura cancelada. No se guardo ninguna venta.", Color.Gray);
                else
                {
                    Agregar(causa.Message, ColorError);
                    if (!(causa is AsistenteIAException) && !(causa is System.ComponentModel.DataAnnotations.ValidationException))
                        Sistema.MensajeError(causa);
                }
            }
            finally
            {
                if (_cts != null) _cts.Dispose();
                _cts = null;
                if (!IsDisposed) Ocupado(false);
            }
        }

        private void chkVerSql_CheckedChanged(object sender, EventArgs e)
        {
            txtSql.Visible = chkVerSql.Checked;
        }

        #region Conversación (texto con **negrita** y viñetas)

        private void Agregar(string texto, Color? color, FontStyle estilo = FontStyle.Regular, float tamaño = 10F)
        {
            var rtb = rtbConversacion;
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            var lineas = (texto ?? "").Replace("\r\n", "\n").Split('\n');
            foreach (var original in lineas)
            {
                var linea = original;
                bool viñeta = Regex.IsMatch(linea, @"^\s*[-*•]\s+");
                if (viñeta) linea = "  •  " + Regex.Replace(linea, @"^\s*[-*•]\s+", "");
                linea = Regex.Replace(linea, @"^#{1,6}\s+", "");

                // Alterna texto normal / negrita según los **.
                var partes = linea.Split(new[] { "**" }, StringSplitOptions.None);
                for (int i = 0; i < partes.Length; i++)
                {
                    if (partes[i].Length == 0) continue;
                    rtb.SelectionFont = new Font("Segoe UI", tamaño, i % 2 == 1 ? estilo | FontStyle.Bold : estilo);
                    rtb.SelectionColor = color ?? Color.FromArgb(31, 41, 55);
                    rtb.AppendText(partes[i]);
                }
                rtb.AppendText(Environment.NewLine);
            }
            if (estilo == FontStyle.Regular || color == ColorError) rtb.AppendText(Environment.NewLine);
            rtb.SelectionStart = rtb.TextLength;
            rtb.ScrollToCaret();
        }

        #endregion

        #region Resultado

        private void MostrarResultado(AsistenteIAResultado r, List<string> consultas)
        {
            _resultado = r;
            _consultas = consultas ?? new List<string>();
            txtSql.Text = string.Join(Environment.NewLine + Environment.NewLine, _consultas.Select(s => s.Replace("\r\n", "\n").Replace("\n", Environment.NewLine)));
            dgvResultado.DataSource = null;
            btnExportar.Enabled = r != null && r.Columnas.Count > 0;

            if (r == null || r.Columnas.Count == 0)
            {
                lblResultado.Text = "Datos de la última consulta";
                return;
            }

            var dt = new DataTable();
            for (int c = 0; c < r.Columnas.Count; c++)
            {
                var tipo = r.Filas.Select(f => f[c]).FirstOrDefault(v => v != null);
                var nombre = r.Columnas[c];
                while (dt.Columns.Contains(nombre)) nombre += "_";
                dt.Columns.Add(nombre, tipo != null ? tipo.GetType() : typeof(string));
            }
            foreach (var f in r.Filas)
                dt.Rows.Add(f.Select(v => v ?? (object)DBNull.Value).ToArray());
            dgvResultado.DataSource = dt;

            foreach (DataGridViewColumn col in dgvResultado.Columns)
            {
                var t = dt.Columns[col.Index].DataType;
                if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(byte))
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                else if (t == typeof(DateTime))
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            lblResultado.Text = "Datos de la última consulta: " + r.Filas.Count + (r.Filas.Count == 1 ? " fila" : " filas") + (r.Truncado ? " (se muestran las primeras " + r.Filas.Count + ")" : "");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_resultado == null) return;
            using (var d = new SaveFileDialog { Filter = "CSV (separado por ;)|*.csv", FileName = "asistente-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".csv" })
            {
                if (d.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(string.Join(";", _resultado.Columnas.Select(Csv)));
                    foreach (var f in _resultado.Filas)
                        sb.AppendLine(string.Join(";", f.Select(v => Csv(Formatear(v)))));
                    File.WriteAllText(d.FileName, sb.ToString(), new UTF8Encoding(true));
                }
                catch (Exception ex)
                {
                    Sistema.MensajeError(ex);
                }
            }
        }

        private static string Formatear(object v)
        {
            if (v == null) return "";
            if (v is DateTime) return ((DateTime)v).ToString(((DateTime)v).TimeOfDay == TimeSpan.Zero ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm");
            var f = v as IFormattable;
            return f != null ? f.ToString(null, CultureInfo.CurrentCulture) : v.ToString();
        }

        private static string Csv(string s)
        {
            s = s ?? "";
            return s.IndexOfAny(new[] { ';', '"', '\n', '\r' }) >= 0 ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;
        }

        #endregion
    }
}
