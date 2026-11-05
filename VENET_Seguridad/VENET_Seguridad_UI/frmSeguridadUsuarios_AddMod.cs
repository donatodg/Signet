namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuarios_AddMod : MultiForm, IDisposable
    {
        private SeguridadUsuariosManager manager;
      
        public frmSeguridadUsuarios_AddMod(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosManager(o);
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEliminar.Visible = pictureBoxFoto.Image != null;
            ToolStripMenuItemPegar.Visible = Clipboard.ContainsImage();
            contextMenuStripFoto.Show(pictureBoxFoto, new Point(0, contextMenuStripFoto.Height));
        }

        private void frmSeguridadUsuarios_AddMod_Load(object sender, EventArgs e)
        {
            seguridadUsuariosManagerBindingSource.DataSource = manager;

            id_GrupoLookUpEdit.Properties.DataSource = manager.Grupos;
            id_GrupoLookUpEdit.Properties.DisplayMember = "Name";
            id_GrupoLookUpEdit.Properties.ValueMember = "Key";

            if (manager.Usuario.Foto != null)
                using (MemoryStream stream = new MemoryStream(manager.Usuario.Foto))
                {
                    pictureBoxFoto.Image = new Bitmap(stream);
                    labelfotosize.Text = (stream.Length / 1024).ToString("N2") + " Kb";
                }
        }

        private void ToolStripMenuItemEliminar_Click(object sender, EventArgs e)
        {
            pictureBoxFoto.Image = Properties.Resources.customer_32x32;
            manager.Usuario.Foto = null;
            labelfotosize.Text = null;
        }

        private void pictureBoxFoto_SetImage(Image img)
        {
            Image bmp = default(Image);
            decimal escala = default(decimal);
            int h = 0;
            int w = 0;
            int x = 0;
            int y = 0;

            h = pictureBoxFoto.Height;
            w = pictureBoxFoto.Width;
            bmp = new Bitmap(w, h);
            escala = Convert.ToDecimal(img.Height) / Convert.ToDecimal(img.Width);

            if (escala > 1)
            {
                h = Convert.ToInt32(h * escala);
                y = 75 - Convert.ToInt32(h / 2);
            }
            else
            {
                w = Convert.ToInt32(w / escala);
                x = 75 - Convert.ToInt32(w / 2);
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, x, y, w, h);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                labelfotosize.Text = (ms.Length / 1024).ToString("N2") + " Kb";
                manager.Usuario.Foto = ms.ToArray();
                pictureBoxFoto.Image = Image.FromStream(ms);
            }

        }

        private void ToolStripMenuItemSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Multiselect = false;
            f.Filter = "Image Files (*.bmp,*.jpg,*.png)|*.bmp;*.jpg;*.png";
            if (f.ShowDialog(this) == DialogResult.OK)
                pictureBoxFoto_SetImage(Image.FromFile(f.FileName));
        }

        private void ToolStripMenuItemPegar_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
                pictureBoxFoto_SetImage(Clipboard.GetImage());
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmSeguridadUsuarios_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

    }
}
