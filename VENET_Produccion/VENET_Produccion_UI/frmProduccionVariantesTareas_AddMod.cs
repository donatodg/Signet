namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionVariantesTareas_AddMod : MultiForm
    {
        private ProduccionVariantesTareasManager manager;
        private bool LoadForm = true;
        bool Modifica = false;

        public frmProduccionVariantesTareas_AddMod(Produccion_VariantesTareas o)
        {
            InitializeComponent();
            manager = new ProduccionVariantesTareasManager(o);
        }

        private void frmProduccionVariantesTareas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                Modifica = true;

                id_TareaLookUpEdit.Properties.DataSource = manager.Tareas;
                id_TareaLookUpEdit.Properties.DisplayMember = "Descripcion";
                id_TareaLookUpEdit.Properties.ValueMember = "Id";

                id_ManoObraLookUpEdit.Properties.DataSource = manager.ManoObras;
                id_ManoObraLookUpEdit.Properties.DisplayMember = "Name";
                id_ManoObraLookUpEdit.Properties.ValueMember = "Key";

                //if (id_ManoObraLookUpEdit.ItemIndex < 0) id_ManoObraLookUpEdit.ItemIndex = 0;

                produccionVariantesTareasManagerBindingSource.DataSource = manager;

                LoadForm = false;
                Modifica = false;
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
                if (gridView1.GetSelectedRows().GetLength(0) < 1)
                    Errores = "No ha seleccionado ninguna medida. \n\r";

                if (manager.VarianteTareas.Horas.Hour == 0 && manager.VarianteTareas.Horas.Minute == 0)
                    Errores += "No ha ingresado horas.";

                if (Errores != "")
                {
                    Sistema.Mensaje(Errores);
                    return;
                }

                foreach (int Id_Medida in gridView1.GetSelectedRows())
                    manager.Save(((KeyNamePair)gridView1.GetRow(Id_Medida)).Key);

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

        private void frmProduccionVariantesTareas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void gridLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int cant = gridView1.GetSelectedRows().GetLength(0);
            if (cant == 1)
                lblSeleccionados.Text = "1 item seleccionado";
            else
                lblSeleccionados.Text = string.Format("{0} items seleccionados", cant);
        }

        private void id_TareaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!LoadForm)
            {
                Validate();
                if (Convert.ToInt32(id_TareaLookUpEdit.EditValue) > 0)
                {
                    Modifica = true;

                    manager.VarianteTareas.Horas = ((ProduccionVariantesTareasManager.TareasList)id_TareaLookUpEdit.GetSelectedDataRow()).Horas;
                    horasTimeEdit.EditValue = manager.VarianteTareas.Horas;

                    manager.VarianteTareas.Unidades = ((ProduccionVariantesTareasManager.TareasList)id_TareaLookUpEdit.GetSelectedDataRow()).Unidades;
                    unidadesTextEdit.EditValue = manager.VarianteTareas.Unidades;

                    Modifica = false;
                }
            }
        }

        private void unidadesTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();
                if (!Modifica)
                {
                    Modifica = true;

                    manager.VarianteTareas.Unidades = Convert.ToDecimal(unidadesTextEdit.Text);
                    int Minutos = Convert.ToInt32(manager.VarianteTareas.Unidades * 60);
                    DateTime t = new DateTime(2001, 01, 01);
                    t = t.AddMinutes(Minutos);

                    manager.VarianteTareas.Horas = t;
                    horasTimeEdit.EditValue = t;

                    Modifica = false;
                }
            }
            catch (Exception) { }
        }

        private void horasTimeEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();
                if (!Modifica)
                {
                    Modifica = true;

                    manager.VarianteTareas.Horas = Convert.ToDateTime(horasTimeEdit.EditValue);
                    int Minutos = (manager.VarianteTareas.Horas.Hour * 60) + (manager.VarianteTareas.Horas.Minute);
                    manager.VarianteTareas.Unidades = Convert.ToDecimal(Minutos / Convert.ToDecimal(60));
                    unidadesTextEdit.EditValue = manager.VarianteTareas.Unidades;

                    Modifica = false;
                }
            }
            catch (Exception) { }
        }

    }
}
