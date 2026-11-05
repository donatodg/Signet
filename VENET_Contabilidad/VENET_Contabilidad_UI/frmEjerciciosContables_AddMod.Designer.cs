namespace VENET_Contabilidad_UI
{
    partial class frmEjerciciosContables_AddMod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label vigenciaDesdeLabel;
            System.Windows.Forms.Label vigenciaHastaLabel;
            System.Windows.Forms.Label cerradoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ejerciciosContablesManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.vigenciaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.vigenciaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.cerradoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            vigenciaDesdeLabel = new System.Windows.Forms.Label();
            vigenciaHastaLabel = new System.Windows.Forms.Label();
            cerradoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ejerciciosContablesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerradoCheckEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAceptar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Contabilidad_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(373, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 183);
            this.barDockControlBottom.Size = new System.Drawing.Size(373, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 159);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(373, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 159);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(cerradoLabel);
            this.groupControl1.Controls.Add(this.cerradoCheckEdit);
            this.groupControl1.Controls.Add(vigenciaHastaLabel);
            this.groupControl1.Controls.Add(this.vigenciaHastaDateEdit);
            this.groupControl1.Controls.Add(vigenciaDesdeLabel);
            this.groupControl1.Controls.Add(this.vigenciaDesdeDateEdit);
            this.groupControl1.Controls.Add(id_EmpresaLabel);
            this.groupControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(349, 145);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // ejerciciosContablesManagerBindingSource
            // 
            this.ejerciciosContablesManagerBindingSource.DataSource = typeof(VENET_Contabilidad_BL.EjerciciosContablesManager);
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(27, 40);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ejerciciosContablesManagerBindingSource, "Ejercicio.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(98, 37);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(236, 20);
            this.descripcionTextEdit.TabIndex = 1;
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(40, 14);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 2;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ejerciciosContablesManagerBindingSource, "Ejercicio.Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(98, 11);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(236, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // vigenciaDesdeLabel
            // 
            vigenciaDesdeLabel.AutoSize = true;
            vigenciaDesdeLabel.Location = new System.Drawing.Point(9, 66);
            vigenciaDesdeLabel.Name = "vigenciaDesdeLabel";
            vigenciaDesdeLabel.Size = new System.Drawing.Size(83, 13);
            vigenciaDesdeLabel.TabIndex = 4;
            vigenciaDesdeLabel.Text = "Vigencia Desde:";
            // 
            // vigenciaDesdeDateEdit
            // 
            this.vigenciaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ejerciciosContablesManagerBindingSource, "Ejercicio.VigenciaDesde", true));
            this.vigenciaDesdeDateEdit.EditValue = null;
            this.vigenciaDesdeDateEdit.EnterMoveNextControl = true;
            this.vigenciaDesdeDateEdit.Location = new System.Drawing.Point(98, 63);
            this.vigenciaDesdeDateEdit.MenuManager = this.barManager1;
            this.vigenciaDesdeDateEdit.Name = "vigenciaDesdeDateEdit";
            this.vigenciaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenciaDesdeDateEdit.TabIndex = 2;
            // 
            // vigenciaHastaLabel
            // 
            vigenciaHastaLabel.AutoSize = true;
            vigenciaHastaLabel.Location = new System.Drawing.Point(11, 92);
            vigenciaHastaLabel.Name = "vigenciaHastaLabel";
            vigenciaHastaLabel.Size = new System.Drawing.Size(81, 13);
            vigenciaHastaLabel.TabIndex = 6;
            vigenciaHastaLabel.Text = "Vigencia Hasta:";
            // 
            // vigenciaHastaDateEdit
            // 
            this.vigenciaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ejerciciosContablesManagerBindingSource, "Ejercicio.VigenciaHasta", true));
            this.vigenciaHastaDateEdit.EditValue = null;
            this.vigenciaHastaDateEdit.EnterMoveNextControl = true;
            this.vigenciaHastaDateEdit.Location = new System.Drawing.Point(98, 89);
            this.vigenciaHastaDateEdit.MenuManager = this.barManager1;
            this.vigenciaHastaDateEdit.Name = "vigenciaHastaDateEdit";
            this.vigenciaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenciaHastaDateEdit.TabIndex = 3;
            // 
            // cerradoLabel
            // 
            cerradoLabel.AutoSize = true;
            cerradoLabel.Location = new System.Drawing.Point(42, 118);
            cerradoLabel.Name = "cerradoLabel";
            cerradoLabel.Size = new System.Drawing.Size(50, 13);
            cerradoLabel.TabIndex = 8;
            cerradoLabel.Text = "Cerrado:";
            // 
            // cerradoCheckEdit
            // 
            this.cerradoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ejerciciosContablesManagerBindingSource, "Ejercicio.Cerrado", true));
            this.cerradoCheckEdit.EnterMoveNextControl = true;
            this.cerradoCheckEdit.Location = new System.Drawing.Point(98, 115);
            this.cerradoCheckEdit.MenuManager = this.barManager1;
            this.cerradoCheckEdit.Name = "cerradoCheckEdit";
            this.cerradoCheckEdit.Properties.Caption = "";
            this.cerradoCheckEdit.Size = new System.Drawing.Size(33, 19);
            this.cerradoCheckEdit.TabIndex = 4;
            // 
            // frmEjerciciosContables_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 183);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEjerciciosContables_AddMod";
            this.Text = "Alta/Modificación de Ejercicios Contables";
            this.Load += new System.EventHandler(this.frmEjerciciosContables_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ejerciciosContablesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerradoCheckEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit cerradoCheckEdit;
        private System.Windows.Forms.BindingSource ejerciciosContablesManagerBindingSource;
        private DevExpress.XtraEditors.DateEdit vigenciaHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit vigenciaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
    }
}