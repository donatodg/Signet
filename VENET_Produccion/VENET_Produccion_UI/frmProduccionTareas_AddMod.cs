namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionTareas_AddMod : MultiForm
    {
        private ProduccionTareasManager manager;
        bool Modifica = false;

        public frmProduccionTareas_AddMod(Produccion_Tareas o)
        {
            InitializeComponent();
            manager = new ProduccionTareasManager(o);
        }

        private void frmProduccionTareas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                Modifica = true;

                produccionTareasManagerBindingSource.DataSource = manager;

                Modifica = false;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmProduccionTareas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }


        private void horasTimeEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

        private void unidadesTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();
                if (!Modifica)
                {
                    Modifica = true;
                    manager.Tarea.Unidades = Convert.ToDecimal(unidadesTextEdit.Text);
                    int Minutos = Convert.ToInt32(manager.Tarea.Unidades * 60);
                    DateTime t = new DateTime(2001, 01, 01);
                    t = t.AddMinutes(Minutos);

                    manager.Tarea.Horas = t;
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
                    manager.Tarea.Horas = Convert.ToDateTime(horasTimeEdit.EditValue);
                    int Minutos = (manager.Tarea.Horas.Hour * 60) + (manager.Tarea.Horas.Minute);
                    manager.Tarea.Unidades = Convert.ToDecimal(Minutos / Convert.ToDecimal(60));
                    unidadesTextEdit.EditValue = manager.Tarea.Unidades;

                    Modifica = false;
                }
            }
            catch (Exception) { }
        }

    }
}
