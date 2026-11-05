namespace VENET_Produccion_UI
{
    partial class frmProduccionTareas_AddMod
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label descripcionCortaLabel;
            System.Windows.Forms.Label horasLabel;
            System.Windows.Forms.Label unidadesLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.unidadesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.produccionTareasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.horasTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.descripcionCortaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            descripcionCortaLabel = new System.Windows.Forms.Label();
            horasLabel = new System.Windows.Forms.Label();
            unidadesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionTareasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horasTimeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(35, 14);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // descripcionCortaLabel
            // 
            descripcionCortaLabel.AutoSize = true;
            descripcionCortaLabel.Location = new System.Drawing.Point(32, 40);
            descripcionCortaLabel.Name = "descripcionCortaLabel";
            descripcionCortaLabel.Size = new System.Drawing.Size(68, 13);
            descripcionCortaLabel.TabIndex = 2;
            descripcionCortaLabel.Text = "Desc. Corta:";
            // 
            // horasLabel
            // 
            horasLabel.AutoSize = true;
            horasLabel.Location = new System.Drawing.Point(61, 92);
            horasLabel.Name = "horasLabel";
            horasLabel.Size = new System.Drawing.Size(39, 13);
            horasLabel.TabIndex = 8;
            horasLabel.Text = "Horas:";
            // 
            // unidadesLabel
            // 
            unidadesLabel.AutoSize = true;
            unidadesLabel.Location = new System.Drawing.Point(45, 66);
            unidadesLabel.Name = "unidadesLabel";
            unidadesLabel.Size = new System.Drawing.Size(55, 13);
            unidadesLabel.TabIndex = 8;
            unidadesLabel.Text = "Unidades:";
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
            this.btnAgregar});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Aceptar";
            this.btnAgregar.Glyph = global::VENET_Produccion_UI.Properties.Resources.save_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.LargeGlyph = global::VENET_Produccion_UI.Properties.Resources.save_32x32;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(394, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 159);
            this.barDockControlBottom.Size = new System.Drawing.Size(394, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 135);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(394, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 135);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(unidadesLabel);
            this.groupControl1.Controls.Add(this.unidadesTextEdit);
            this.groupControl1.Controls.Add(horasLabel);
            this.groupControl1.Controls.Add(descripcionCortaLabel);
            this.groupControl1.Controls.Add(this.horasTimeEdit);
            this.groupControl1.Controls.Add(this.descripcionCortaTextEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(370, 121);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // unidadesTextEdit
            // 
            this.unidadesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionTareasManagerBindingSource, "Tarea.Unidades", true));
            this.unidadesTextEdit.EnterMoveNextControl = true;
            this.unidadesTextEdit.Location = new System.Drawing.Point(106, 63);
            this.unidadesTextEdit.MenuManager = this.barManager1;
            this.unidadesTextEdit.Name = "unidadesTextEdit";
            this.unidadesTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.unidadesTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.unidadesTextEdit.Properties.EditFormat.FormatString = "n2";
            this.unidadesTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.unidadesTextEdit.Properties.Mask.EditMask = "n2";
            this.unidadesTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.unidadesTextEdit.Size = new System.Drawing.Size(100, 20);
            this.unidadesTextEdit.TabIndex = 2;
            this.unidadesTextEdit.EditValueChanged += new System.EventHandler(this.unidadesTextEdit_EditValueChanged);
            // 
            // produccionTareasManagerBindingSource
            // 
            this.produccionTareasManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionTareasManager);
            // 
            // horasTimeEdit
            // 
            this.horasTimeEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionTareasManagerBindingSource, "Tarea.Horas", true));
            this.horasTimeEdit.EditValue = new System.DateTime(2019, 4, 29, 0, 0, 0, 0);
            this.horasTimeEdit.Location = new System.Drawing.Point(106, 89);
            this.horasTimeEdit.MenuManager = this.barManager1;
            this.horasTimeEdit.Name = "horasTimeEdit";
            this.horasTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.horasTimeEdit.Properties.DisplayFormat.FormatString = "t";
            this.horasTimeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.horasTimeEdit.Properties.EditFormat.FormatString = "t";
            this.horasTimeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.horasTimeEdit.Properties.Mask.EditMask = "t";
            this.horasTimeEdit.Size = new System.Drawing.Size(100, 20);
            this.horasTimeEdit.TabIndex = 3;
            this.horasTimeEdit.EditValueChanged += new System.EventHandler(this.horasTimeEdit_EditValueChanged);
            this.horasTimeEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.horasTimeEdit_KeyPress);
            // 
            // descripcionCortaTextEdit
            // 
            this.descripcionCortaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionTareasManagerBindingSource, "Tarea.DescripcionCorta", true));
            this.descripcionCortaTextEdit.EnterMoveNextControl = true;
            this.descripcionCortaTextEdit.Location = new System.Drawing.Point(106, 37);
            this.descripcionCortaTextEdit.MenuManager = this.barManager1;
            this.descripcionCortaTextEdit.Name = "descripcionCortaTextEdit";
            this.descripcionCortaTextEdit.Properties.MaxLength = 5;
            this.descripcionCortaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionCortaTextEdit.TabIndex = 1;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionTareasManagerBindingSource, "Tarea.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(106, 11);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(250, 20);
            this.descripcionTextEdit.TabIndex = 0;
            // 
            // frmProduccionTareas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(394, 159);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 198);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 198);
            this.Name = "frmProduccionTareas_AddMod";
            this.Text = "Alta/Modificación de Tareas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionTareas_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionTareas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionTareasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horasTimeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private System.Windows.Forms.BindingSource produccionTareasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionCortaTextEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.TimeEdit horasTimeEdit;
        private DevExpress.XtraEditors.TextEdit unidadesTextEdit;
    }
}