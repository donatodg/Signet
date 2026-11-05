namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_General_BL;

    public partial class frmComentarios : MultiForm, IDisposable
    {
        private ComentariosManager manager;
        public int Id;

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape) { Close(); }
                if ((Keys)m.WParam == Keys.Enter) { Guardar(); }
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmComentarios(string Tabla, int Id_Tabla)
        {
            InitializeComponent();
            manager = new ComentariosManager(Tabla, Id_Tabla);
        }

        private void frmComentarios_Load(object sender, EventArgs e)
        {

            comentariosManagerBindingSource.DataSource = manager;

            id_ColorLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.Colores));
            id_ColorLookUpEdit.Properties.DisplayMember = "Value";
            id_ColorLookUpEdit.Properties.ValueMember = "Key";

            if (manager.Comentario.Color == Enums.Colores.Azul.ToString())
                id_ColorLookUpEdit.ItemIndex = 4;
            if (manager.Comentario.Color == Enums.Colores.Rojo.ToString())
                id_ColorLookUpEdit.ItemIndex = 3;
            if (manager.Comentario.Color == Enums.Colores.Amarillo.ToString())
                id_ColorLookUpEdit.ItemIndex = 2;
            if (manager.Comentario.Color == Enums.Colores.Verde.ToString())
                id_ColorLookUpEdit.ItemIndex = 1;
            if (manager.Comentario.Color == Enums.Colores.Ninguno.ToString())
                id_ColorLookUpEdit.ItemIndex = 0;
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

                manager.Comentario.Color = id_ColorLookUpEdit.Text;
                //  manager.Comentario.Descripcion = descripcionTextEdit.Text;
                manager.Save();
                Id = manager.Comentario.Id;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
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

        private void frmComentarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void colorLookUpEdit_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
                id_ColorLookUpEdit.Text = "";
            }
        }
    }
}
