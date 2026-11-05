namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionLineasMedidas_AddMod : MultiForm
    {
        private ProduccionLineasMedidasManager manager;

        public frmProduccionLineasMedidas_AddMod(Produccion_Lineas o)
        {
            InitializeComponent();
            manager = new ProduccionLineasMedidasManager(o);
        }

        private void frmProduccionLineasMedidas_AddMod_Load(object sender, EventArgs e)
        {
            produccionLineasMedidasManagerBindingSource.DataSource = manager;
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

                if (gridLookUpEdit1View.GetSelectedRows().GetLength(0) < 1)
                {
                    Sistema.Mensaje("No ha seleccionado ninguna medida.");
                    return;
                }

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

        private void gridLookUpEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            int cant = gridLookUpEdit1View.GetSelectedRows().GetLength(0);
            if (cant == 1)
                lblSeleccionados.Text = "1 item seleccionado";
            else
                lblSeleccionados.Text = string.Format("{0} items seleccionados", cant);
        }

        private void frmProduccionLineasMedidas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
