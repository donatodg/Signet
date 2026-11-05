namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmEntidadesEmpresas_AddMod : MultiForm, IDisposable
    {
        private EntidadesEmpresasManager manager;

        public frmEntidadesEmpresas_AddMod(Enums.TipoEntidad TipoEntidad, int Id_Entidad)
        {
            InitializeComponent();
            manager = new EntidadesEmpresasManager(TipoEntidad, Id_Entidad);
        }

        private void EntidadesEmpresas_AddMod_Load(object sender, EventArgs e)
        {
            entidadesEmpresasManagerBindingSource.DataSource = manager;
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
                    manager.Save(((KeyNamePair)gridLookUpEdit1View.GetRow(Id)).Key);

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

        private void EntidadesEmpresas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
