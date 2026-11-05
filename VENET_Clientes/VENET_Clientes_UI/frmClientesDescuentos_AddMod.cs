namespace VENET_Clientes_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Clientes_BL;

    public partial class frmClientesDescuentos_AddMod : MultiForm, IDisposable
    {
        private ClientesDescuentosManager manager;
        public ClientesDescuentos Descuento;

        public frmClientesDescuentos_AddMod(ClientesDescuentos o)
        {
            InitializeComponent();
            Descuento = o;
            manager = new ClientesDescuentosManager(o);
        }

        private void frmClientesDescuentos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                clientesDescuentosManagerBindingSource.DataSource = manager;

                id_Categoria2LookUpEdit.Properties.DataSource = manager.Categorias;
                id_Categoria2LookUpEdit.Properties.DisplayMember = "Name";
                id_Categoria2LookUpEdit.Properties.ValueMember = "Key";

                //if (id_Categoria2LookUpEdit.ItemIndex == -1)
                //    id_Categoria2LookUpEdit.ItemIndex = 0;
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

                if (Descuento.Descuento <= 0 || Descuento.Descuento > 100)
                {
                    Sistema.Mensaje("Debe indicar un descuento válido.");
                    return;
                }
                Descuento.Categoria = id_Categoria2LookUpEdit.Text;
                Descuento.FechaAdd = Sistema.ObtenerFechaHora();
                Descuento.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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

        private void id_Categoria2LookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
        }
    }
}
