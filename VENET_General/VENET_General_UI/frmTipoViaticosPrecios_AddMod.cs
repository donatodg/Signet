namespace VENET_General_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTipoViaticosPrecios_AddMod : MultiForm, IDisposable
    {
        private TipoViaticosPreciosManager manager;
        public TipoViaticosPrecios Precios;
        List<TipoViaticosPrecios> ListDetalles;

        public frmTipoViaticosPrecios_AddMod(TipoViaticosPrecios o, List<TipoViaticosPrecios> DetalleList)
        {
            InitializeComponent();
            Precios = o;
            manager = new TipoViaticosPreciosManager(o);
            ListDetalles = DetalleList;
        }

        private void frmTipoViaticosPrecios_AddMod_Load(object sender, EventArgs e)
        {
            tipoViaticosPreciosManagerBindingSource.DataSource = manager;
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

                if (Precios.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe válido.");
                    return;
                }

                if (Precios.VigenciaDesde > Precios.VigenciaHasta)
                {
                    Sistema.Mensaje("Debe ingresar un rango de fechas válido.");
                    return;
                }

                if (!manager.ValidaVigencia(ListDetalles))
                {
                    Sistema.Mensaje("Las fechas ingresadas se superponen con otro período de vigencia.");
                    return;
                }

                Precios.FechaAdd = Sistema.ObtenerFechaHora();
                Precios.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Precios.VigenciaDesde = manager.Precio.VigenciaDesde;
                Precios.VigenciaHasta = manager.Precio.VigenciaHasta;

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

        private void frmTipoViaticosPrecios_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
