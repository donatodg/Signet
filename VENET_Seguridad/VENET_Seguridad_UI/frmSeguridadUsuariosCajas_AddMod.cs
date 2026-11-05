namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosCajas_AddMod : MultiForm, IDisposable
    {
        private SeguridadUsuariosCajasManager manager;

        public frmSeguridadUsuariosCajas_AddMod(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosCajasManager(o);
        }

        private void frmSeguridadUsuariosCajas_AddMod_Load(object sender, EventArgs e)
        {
            seguridadUsuariosCajasManagerBindingSource.DataSource = manager;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void frmSeguridadUsuariosCajas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
        private void Guardar()
        {
            try
            {
                Validate();
                foreach (int Id in gridLookUpEdit1View.GetSelectedRows())
                    manager.Save(((Sistema.CajasList)gridLookUpEdit1View.GetRow(Id)).Id_Caja);

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

        private void gridLookUpEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            int cant = gridLookUpEdit1View.GetSelectedRows().GetLength(0);
            if (cant == 1)
                lblSeleccionados.Text = "1 item seleccionado";
            else
                lblSeleccionados.Text = string.Format("{0} items seleccionados", cant);
        }
    }
}
