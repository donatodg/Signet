using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VENET_Common;
using VENET_DataEntity;
using VENET_Tesoreria_BL;

namespace VENET_Tesoreria_UI
{
    public partial class frmTipoMovimientos_AddMod : Form
    {
        private TipoMovimientosManager manager;
        //public TipoMovimiento TipoMov;

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            if ((m.Msg == 256))
            {
                Keys key = ((Keys)(m.WParam));
                if ((key == Keys.Escape)) { this.Close(); }
                if ((key == Keys.Enter)) { Guardar(); }
            }
            return base.ProcessKeyPreview(ref m);
        }
        
        public frmTipoMovimientos_AddMod(TipoMovimiento o)
        {
            InitializeComponent();
            manager = new TipoMovimientosManager(o);
        }

        private void frmTipoMovimientos_AddMod_Load(object sender, EventArgs e)
        {
            tipoMovimientosManagerBindingSource.DataSource = manager;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }
        private void Guardar()
        {
            try
            {
                this.Validate();
                manager.Save();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Lineas");
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
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

        private void tipoMovimientosManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", e.Exception);
        }
    }
}
