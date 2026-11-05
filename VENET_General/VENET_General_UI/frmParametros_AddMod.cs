namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Registrator;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmParametros_AddMod : MultiForm, IDisposable
    {
        private ParametrosManager manager;

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
                if ((Keys)m.WParam == Keys.Enter) { Guardar(); }
            if ((Keys)m.WParam == Keys.Escape) { Close(); }
            return base.ProcessKeyPreview(ref m);
        }

        public frmParametros_AddMod(Parametros o)
        {
            InitializeComponent();
            manager = new ParametrosManager(o);
        }

        private void frmParametros_AddMod_Load(object sender, EventArgs e)
        {
            parametrosManagerBindingSource.DataSource = manager;

            valorTextEdit.EditValue = manager.Parametro.Valor;

            if (manager.Parametro.TipoDato == Enums.TipoDato.Bit)
                ConvertEditorType("CheckEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Decimal)
                ConvertEditorType("CalcEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Entero)
                ConvertEditorType("SpinEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Texto)
                ConvertEditorType("TextEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Fecha)
                ConvertEditorType("DateEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Combo)
                ConvertEditorType("LookUpEdit", valorTextEdit, manager.Parametro.Valor);
            if (manager.Parametro.TipoDato == Enums.TipoDato.Password)
                ConvertEditorType("Password", valorTextEdit, manager.Parametro.Valor);
        }

        private void ConvertEditorType(string editorTypeName, BaseEdit sourceEditor, object value)
        {
            try
            {
                EditorClassInfo info;
                if (editorTypeName == "Password")
                    info = EditorRegistrationInfo.Default.Editors["TextEdit"];
                else
                    info = EditorRegistrationInfo.Default.Editors[editorTypeName];

                if (info == null) return;
                BaseEdit edit = info.CreateEditor();
                edit.Location = sourceEditor.Location;
                edit.Size = sourceEditor.Size;
                edit.Parent = sourceEditor.Parent;
                edit.Properties.Assign(sourceEditor.Properties);

                edit.EditValue = value;

                if (editorTypeName == "Password")
                {
                    ((TextEdit)(edit)).Properties.PasswordChar = '*';
                }

                if (info.ToString() == "DateEdit")
                {
                    //edit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //edit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //edit.Properties.EditFormat.FormatString = "d";
                    ((DateEdit)(edit)).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    ((DateEdit)(edit)).Properties.Mask.EditMask = "d";
                    ((DateEdit)(edit)).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    ((DateEdit)(edit)).Properties.DisplayFormat.FormatString = "d";
                    ((DateEdit)(edit)).Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    ((DateEdit)(edit)).Properties.EditFormat.FormatString = "d";
                    ((DateEdit)(edit)).EditValue = Convert.ToDateTime(value);
                }

                if (info.ToString() == "SpinEdit")
                {
                    //edit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //edit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //edit.Properties.EditFormat.FormatString = "d";
                    ((SpinEdit)(edit)).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    ((SpinEdit)(edit)).Properties.Mask.EditMask = "d";

                }
                if (info.ToString() == "CalcEdit")
                {
                    //edit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //edit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //edit.Properties.EditFormat.FormatString = "n";
                    ((CalcEdit)(edit)).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    ((CalcEdit)(edit)).Properties.Mask.EditMask = "n";
                }
                if (info.ToString() == "CheckEdit")
                {
                    ((CheckEdit)(edit)).Checked = Convert.ToBoolean(value);
                }

                if (info.ToString() == "LookUpEdit")
                {
                    //((LookUpEdit)(edit)).Properties.DataSource = value.ToString().Split('|');
                    //// Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));  

                    //((LookUpEdit)(edit)).Properties.DisplayMember = "Value";
                    //((LookUpEdit)(edit)).Properties.ValueMember = "Key";
                }

                sourceEditor.Dispose();
                sourceEditor = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmParametros_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
                manager.Parametro.Valor = valorTextEdit.EditValue.ToString();
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

        private void valorTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager.Parametro.TipoDato == Enums.TipoDato.Bit)
                {
                    valorTextEdit.EditValue = ((CheckEdit)(sender)).Checked;
                    ((CheckEdit)(sender)).Text = "";
                }
                if (manager.Parametro.TipoDato == Enums.TipoDato.Decimal)
                    valorTextEdit.EditValue = ((CalcEdit)(sender)).Text;
                if (manager.Parametro.TipoDato == Enums.TipoDato.Entero)
                    valorTextEdit.EditValue = ((SpinEdit)(sender)).Text;
                if (manager.Parametro.TipoDato == Enums.TipoDato.Texto)
                    valorTextEdit.EditValue = ((TextEdit)(sender)).Text;
                if (manager.Parametro.TipoDato == Enums.TipoDato.Fecha)
                    valorTextEdit.EditValue = ((DateEdit)(sender)).Text;
                if (manager.Parametro.TipoDato == Enums.TipoDato.Password)
                    valorTextEdit.EditValue = ((TextEdit)(sender)).Text;

            }
            catch (Exception) { }
        }


    }
}
