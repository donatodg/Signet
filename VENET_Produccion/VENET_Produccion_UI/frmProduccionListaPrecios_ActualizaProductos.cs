namespace VENET_Produccion_UI
{
    using System;
    using VENET_Common;

    public partial class frmProduccionListaPrecios_ActualizaProductos : MultiForm
    {
        public decimal Valor { get; set; }

        public frmProduccionListaPrecios_ActualizaProductos()
        {
            InitializeComponent();
        }

        private void frmProduccionListaPrecios_ActualizaProductos_Load(object sender, EventArgs e)
        {
            txtValor.EditValue = 0;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Valor = Convert.ToDecimal(txtValor.EditValue);

            if (Valor < 0)
            {
                Sistema.Mensaje("Debe ingresar un importe mayor o igual a cero.");
                return;
            }

            if (Valor == 0)
                Valor = 1;
            else
                Valor = Valor / 100 + 1;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
