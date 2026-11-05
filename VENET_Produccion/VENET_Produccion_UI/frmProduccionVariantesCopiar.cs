namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionVariantesCopiar : MultiForm
    {
        private ProduccionVariantesManager manager;

        public frmProduccionVariantesCopiar(Produccion_Variantes o)
        {
            InitializeComponent();
            manager = new ProduccionVariantesManager(o);
        }

        private void frmProduccionVariantesCopiar_Load(object sender, EventArgs e)
        {
            try
            {
                produccionVariantesManagerBindingSource.DataSource = manager;
                Text = "Copiado de Tareas - Origen: " + manager.Variante.Descripcion;
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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();

                if (Sistema.MensajeSiNo("Se copiarán las tareas de la variante a las variantes seleccionadas.", "¿Copiar tareas de variante " + manager.Variante.Descripcion + " a las variantes seleccionadas?"))
                {
                    foreach (int Id in gridLookUpEdit1View.GetSelectedRows())
                        manager.Save(((KeyName2Pair)gridLookUpEdit1View.GetRow(Id)).Key);
                }
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
    }

}
