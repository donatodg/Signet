namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmEntidadesImpuestosAlicuotas_AddMod : MultiForm, IDisposable
    {
        private EntidadesImpuestosAlicuotasManager manager;

        public frmEntidadesImpuestosAlicuotas_AddMod(EntidadesImpuestoAlicuotas o)
        {
            InitializeComponent();
            manager = new EntidadesImpuestosAlicuotasManager(o);
        }

        private void frmEntidadesImpuestosAlicuotas_AddMod_Load(object sender, EventArgs e)
        {
            entidadesImpuestosAlicuotasManagerBindingSource.DataSource = manager;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void frmEntidadesImpuestosAlicuotas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager = null;
        }

        private void Guardar()
        {
            try
            {
                Validate();

                foreach (int Id in gridLookUpEdit1View.GetSelectedRows())
                    manager.Save(((EntidadesImpuestosAlicuotasManager.Combo)gridLookUpEdit1View.GetRow(Id)).Id);

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
