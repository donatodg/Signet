namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmPuntosVentas_AddMod : MultiForm, IDisposable
    {
        private PuntosVentaManager manager;

        public frmPuntosVentas_AddMod(PuntosVentas o)
        {
            InitializeComponent();
            manager = new PuntosVentaManager(o);
        }

        private void frmPuntosVentas_AddMod_Load(object sender, EventArgs e)
        {
            puntosVentaManagerBindingSource.DataSource = manager;

            id_SucursalLookUpEdit.Properties.DataSource = manager.Sucursales;
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";
            id_SucursalLookUpEdit.Properties.ValueMember = "Id";
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
                //manager.PuntoVenta.Id_Empresa = Convert.ToInt32(this.id_EmpresaLookUpEdit.EditValue);
                manager.PuntoVenta.PuntoVenta = (puntoVentaTextEdit.EditValue.ToString()).PadLeft(4, '0').ToString();
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmPuntosVentas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
