namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTalonariosComprobantesDetalle_AddMod : MultiForm, IDisposable
    {
        private TalonariosComprobantesDetalleManager manager;
        public TalonariosComprobantesDetalle TalonarioDetalle;

        public frmTalonariosComprobantesDetalle_AddMod(TalonariosComprobantesDetalle o)
        {
            InitializeComponent();

            if (o.FechaVencimiento == DateTime.MinValue)
                o.FechaVencimiento = Sistema.ObtenerFechaHora().AddYears(1);

            TalonarioDetalle = o;
            manager = new TalonariosComprobantesDetalleManager(o);
        }

        private void frmTalonariosComprobantesDetalle_AddMod_Load(object sender, EventArgs e)
        {
            talonariosComprobantesDetalleManagerBindingSource.DataSource = manager;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Talonarios_ModificarNroActual)))
                nroActualSpinEdit.Enabled = false;
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

                TalonarioDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                TalonarioDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                TalonarioDetalle.FechaVencimiento = manager.TalonarioDetalle.FechaVencimiento;
                TalonarioDetalle.NroActual = manager.TalonarioDetalle.NroActual;
                TalonarioDetalle.NroDesde = manager.TalonarioDetalle.NroDesde;
                TalonarioDetalle.NroHasta = manager.TalonarioDetalle.NroHasta;

                if (TalonarioDetalle.NroDesde == 0 || TalonarioDetalle.NroHasta == 0)
                    throw new ValidationException("Debe ingresar el número desde/hasta.");

                if (TalonarioDetalle.NroDesde >= TalonarioDetalle.NroHasta)
                    throw new ValidationException("Verifique los números desde y hasta.");

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
    }
}
