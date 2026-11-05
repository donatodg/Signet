namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosPuntosVentas_AddMod : MultiForm, IDisposable
    {
        private SeguridadUsuariosPuntosVentasManager manager;

        public frmSeguridadUsuariosPuntosVentas_AddMod(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosPuntosVentasManager(o);
        }

        private void frmSeguridadUsuariosPuntosVentas_AddMod_Load(object sender, EventArgs e)
        {
            seguridadUsuariosPuntosVentasManagerBindingSource.DataSource = manager;
        }

        private void frmSeguridadUsuariosPuntosVentas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
                foreach (int Id in gridLookUpEdit1View.GetSelectedRows())
                    manager.Save(((SeguridadUsuariosPuntosVentasManager.Combo)gridLookUpEdit1View.GetRow(Id)).Id);

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
