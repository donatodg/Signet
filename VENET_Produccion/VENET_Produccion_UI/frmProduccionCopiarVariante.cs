namespace VENET_Produccion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Produccion_BL;

    public partial class frmProduccionCopiarVariante : MultiForm
    {
        private ProduccionCopiarVarianteManager manager;

        public frmProduccionCopiarVariante()
        {
            InitializeComponent();
            manager = new ProduccionCopiarVarianteManager();
        }

        private void frmProduccionCopiar_Load(object sender, EventArgs e)
        {
            try
            {
                produccionCopiarManagerBindingSource.DataSource = manager;

                id_LineaLookUpEdit.Properties.DataSource = manager.Lineas;
                id_LineaLookUpEdit.Properties.DisplayMember = "Name";
                id_LineaLookUpEdit.Properties.ValueMember = "Key";

                id_Linea_DestinoLookUpEdit.Properties.DataSource = manager.Lineas;
                id_Linea_DestinoLookUpEdit.Properties.DisplayMember = "Name";
                id_Linea_DestinoLookUpEdit.Properties.ValueMember = "Key";

                id_VarianteLookUpEdit.Properties.DisplayMember = "Name";
                id_VarianteLookUpEdit.Properties.ValueMember = "Key";

                id_Variante_DestinoLookUpEdit.Properties.DisplayMember = "Name";
                id_Variante_DestinoLookUpEdit.Properties.ValueMember = "Key";

                //id_MedidaLookUpEdit.Properties.DisplayMember = "Name";
                //id_MedidaLookUpEdit.Properties.ValueMember = "Key";

                copiarLookUpEdit.Properties.DataSource = new List<string>() { "Todo", "Composición", "Tareas" };
                copiarLookUpEdit.ItemIndex = 0;

                id_LineaLookUpEdit.EditValue = manager.Id_Linea = manager.Lineas.ElementAt(0).Key;
                id_Linea_DestinoLookUpEdit.EditValue = manager.Id_Linea = manager.Lineas.ElementAt(0).Key;

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

                string Errores = "";
                if (manager.Id_Variante == manager.Id_Variante_Destino)
                    Errores = "El origen es el mismo que el destino";
                else
                {
                    if (manager.Id_Linea == null) Errores = "No ha seleccionado ninguna línea. \n\r";
                    if (manager.Id_Variante == null) Errores += "No ha seleccionado ninguna variante. \n\r";
                    if (gridView1.GetSelectedRows().GetLength(0) < 1) Errores += "No ha seleccionado ninguna medida. \n\r";
                    //if (manager.Id_Medida == null) Errores += "No ha seleccionado ninguna medida. \n\r";

                    if (manager.Id_Linea_Destino == null) Errores = "No ha seleccionado ninguna línea destino. \n\r";
                    if (manager.Id_Variante_Destino == null) Errores += "No ha seleccionado ninguna variante destino.";
                }

                if (Errores != "")
                {
                    Sistema.Mensaje(Errores);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Copiando Variantes.");

                foreach (int Id in gridView1.GetSelectedRows())
                    manager.Save(copiarLookUpEdit.ItemIndex, ((KeyNamePair)gridView1.GetRow(Id)).Key);

                SplashScreenManager.CloseForm(false);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void frmProduccionCopiar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void id_LineaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager != null && id_LineaLookUpEdit.ItemIndex != -1)
                {
                    manager.Id_Linea = (int)id_LineaLookUpEdit.EditValue;
                    id_VarianteLookUpEdit.Properties.DataSource = manager.Variantes;
                    id_VarianteLookUpEdit.EditValue = manager.Id_Variante = manager.Variantes.ElementAt(0).Key;
                }
            }
            catch (ValidationException exv)
            {
                id_VarianteLookUpEdit.Properties.DataSource = null;
                //id_MedidaLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void id_VarianteLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager != null && id_VarianteLookUpEdit.ItemIndex != -1)
                {
                    manager.Id_Variante = (int)id_VarianteLookUpEdit.EditValue;

                    produccionCopiarManagerBindingSource.ResetBindings(false);
                    //medidasDestinoBindingSource.ResetBindings(false);
                    //Validate();

                    //id_MedidaLookUpEdit.Properties.DataSource = manager.Medidas;
                    //id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.ElementAt(0).Key;
                }
            }
            catch (ValidationException exv)
            {
                //id_MedidaLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void id_Linea_DestinoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager != null && id_Linea_DestinoLookUpEdit.ItemIndex != -1)
                {
                    manager.Id_Linea_Destino = (int)id_Linea_DestinoLookUpEdit.EditValue;
                    id_Variante_DestinoLookUpEdit.Properties.DataSource = manager.Variantes_Destino;
                    id_Variante_DestinoLookUpEdit.EditValue = manager.Id_Variante_Destino = manager.Variantes_Destino.ElementAt(0).Key;
                }
            }
            catch (ValidationException exv)
            {
                id_Variante_DestinoLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void id_Variante_DestinoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Validate();
        }

        private void gridLookUpEdit2_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            int cant = gridView1.GetSelectedRows().GetLength(0);
            if (cant == 1)
                lblSeleccionadosO.Text = "1 item seleccionado";
            else
                lblSeleccionadosO.Text = string.Format("{0} items seleccionados", cant);
        }

    }
}
