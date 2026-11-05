namespace VENET_Tesoreria_UI
{
    partial class frmOrdenesPagoDetallePF_AddMod
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
            System.Windows.Forms.Label id_EntidadLabel;
            System.Windows.Forms.Label idEspecieLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label detalleLabel;
            System.Windows.Forms.Label id_TipoEntidadLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_TipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.ordenesPagoDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.detalleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.idEspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EntidadLabel = new System.Windows.Forms.Label();
            idEspecieLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            detalleLabel = new System.Windows.Forms.Label();
            id_TipoEntidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesPagoDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EntidadLabel
            // 
            id_EntidadLabel.AutoSize = true;
            id_EntidadLabel.Location = new System.Drawing.Point(31, 38);
            id_EntidadLabel.Name = "id_EntidadLabel";
            id_EntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_EntidadLabel.TabIndex = 0;
            id_EntidadLabel.Text = "Entidad:";
            // 
            // idEspecieLabel
            // 
            idEspecieLabel.AutoSize = true;
            idEspecieLabel.Location = new System.Drawing.Point(31, 64);
            idEspecieLabel.Name = "idEspecieLabel";
            idEspecieLabel.Size = new System.Drawing.Size(47, 13);
            idEspecieLabel.TabIndex = 2;
            idEspecieLabel.Text = "Especie:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(29, 90);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 4;
            importeLabel.Text = "Importe:";
            // 
            // detalleLabel
            // 
            detalleLabel.AutoSize = true;
            detalleLabel.Location = new System.Drawing.Point(34, 116);
            detalleLabel.Name = "detalleLabel";
            detalleLabel.Size = new System.Drawing.Size(44, 13);
            detalleLabel.TabIndex = 6;
            detalleLabel.Text = "Detalle:";
            // 
            // id_TipoEntidadLabel
            // 
            id_TipoEntidadLabel.AutoSize = true;
            id_TipoEntidadLabel.Location = new System.Drawing.Point(8, 12);
            id_TipoEntidadLabel.Name = "id_TipoEntidadLabel";
            id_TipoEntidadLabel.Size = new System.Drawing.Size(70, 13);
            id_TipoEntidadLabel.TabIndex = 8;
            id_TipoEntidadLabel.Text = "Tipo Entidad:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_TipoEntidadLabel);
            this.groupControl1.Controls.Add(this.id_TipoEntidadLookUpEdit);
            this.groupControl1.Controls.Add(detalleLabel);
            this.groupControl1.Controls.Add(this.detalleTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Controls.Add(idEspecieLabel);
            this.groupControl1.Controls.Add(this.idEspecieLookUpEdit);
            this.groupControl1.Controls.Add(id_EntidadLabel);
            this.groupControl1.Controls.Add(this.id_EntidadLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(376, 145);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_TipoEntidadLookUpEdit
            // 
            this.id_TipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ordenesPagoDetalleManagerBindingSource, "OPDetalle.Id_TipoEntidad", true));
            this.id_TipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoEntidadLookUpEdit.Location = new System.Drawing.Point(84, 9);
            this.id_TipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoEntidadLookUpEdit.Name = "id_TipoEntidadLookUpEdit";
            this.id_TipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name1")});
            this.id_TipoEntidadLookUpEdit.Properties.NullText = "";
            this.id_TipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoEntidadLookUpEdit.Size = new System.Drawing.Size(153, 20);
            this.id_TipoEntidadLookUpEdit.TabIndex = 9;
            this.id_TipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_TipoEntidadLookUpEdit_EditValueChanged);
            // 
            // ordenesPagoDetalleManagerBindingSource
            // 
            this.ordenesPagoDetalleManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.OrdenesPagoDetalleManager);
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
            this.btnAceptar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(400, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 183);
            this.barDockControlBottom.Size = new System.Drawing.Size(400, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(400, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 159);
            // 
            // detalleTextEdit
            // 
            this.detalleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ordenesPagoDetalleManagerBindingSource, "OPDetalle.Detalle", true));
            this.detalleTextEdit.EnterMoveNextControl = true;
            this.detalleTextEdit.Location = new System.Drawing.Point(84, 113);
            this.detalleTextEdit.MenuManager = this.barManager1;
            this.detalleTextEdit.Name = "detalleTextEdit";
            this.detalleTextEdit.Size = new System.Drawing.Size(278, 20);
            this.detalleTextEdit.TabIndex = 7;
            this.detalleTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.detalleTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detalleTextEdit_KeyPress);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ordenesPagoDetalleManagerBindingSource, "OPDetalle.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(84, 87);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 5;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // idEspecieLookUpEdit
            // 
            this.idEspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ordenesPagoDetalleManagerBindingSource, "IdEspecie", true));
            this.idEspecieLookUpEdit.EnterMoveNextControl = true;
            this.idEspecieLookUpEdit.Location = new System.Drawing.Point(84, 61);
            this.idEspecieLookUpEdit.MenuManager = this.barManager1;
            this.idEspecieLookUpEdit.Name = "idEspecieLookUpEdit";
            this.idEspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idEspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.idEspecieLookUpEdit.Properties.NullText = "";
            this.idEspecieLookUpEdit.Properties.ShowHeader = false;
            this.idEspecieLookUpEdit.Size = new System.Drawing.Size(153, 20);
            this.idEspecieLookUpEdit.TabIndex = 3;
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ordenesPagoDetalleManagerBindingSource, "OPDetalle.Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(84, 35);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_EntidadLookUpEdit.TabIndex = 1;
            this.id_EntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_EntidadLookUpEdit_EditValueChanged);
            // 
            // frmOrdenesPagoDetallePF_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 183);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 222);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 222);
            this.Name = "frmOrdenesPagoDetallePF_AddMod";
            this.Text = "Alta/Modificación de Detalle";
            this.Load += new System.EventHandler(this.frmOrdenesPagoDetallePF_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesPagoDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LookUpEdit idEspecieLookUpEdit;
        private System.Windows.Forms.BindingSource ordenesPagoDetalleManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.TextEdit detalleTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoEntidadLookUpEdit;
    }
}