namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmEjerciciosContables_AddMod : MultiForm
    {
        private EjerciciosContablesManager manager;

        public frmEjerciciosContables_AddMod(EjerciciosContables o)
        {
            InitializeComponent();
            manager = new EjerciciosContablesManager(o);
        }

        private void frmEjerciciosContables_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                ejerciciosContablesManagerBindingSource.DataSource = manager;

                if (manager.Ejercicio.Id == 0)
                {
                    manager.Ejercicio.VigenciaHasta = manager.Ejercicio.VigenciaDesde = Sistema.ObtenerFecha();  
                    vigenciaHastaDateEdit.EditValue = vigenciaDesdeDateEdit.EditValue = Sistema.ObtenerFecha();
                }
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
    }
}
