namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionListaPreciosDetalle_AddMod : MultiForm
    {
        private ProduccionListaPreciosDetalleManager manager;

        public frmProduccionListaPreciosDetalle_AddMod(Produccion_ListaPreciosDetalle o)
        {
            InitializeComponent();
            manager = new ProduccionListaPreciosDetalleManager(o);
        }

        private void frmProduccionListaPreciosDetalle_AddMod_Load(object sender, EventArgs e)
        {
            produccionListaPreciosDetalleManagerBindingSource.DataSource = manager;
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
                Sistema.MensajeError(ex);
            }
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();

                manager.Lista.Total = ((manager.Lista.CostoComposicion + manager.Lista.CostoTareas) * manager.Lista.Utilidad /100) + (manager.Lista.CostoComposicion + manager.Lista.CostoTareas);
                totalTextEdit.EditValue = manager.Lista.Total;
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
    }
}
