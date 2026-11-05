namespace VENET_Contabilidad_UI
{
    partial class frmTipoAsientosDetalle_AddMod
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
            System.Windows.Forms.Label cuentaContableLabel;
            System.Windows.Forms.Label id_CuentaContableLabel;
            System.Windows.Forms.Label debeLabel;
            System.Windows.Forms.Label id_CuentaImporteLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_CuentaImporteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoAsientosDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.debeCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.id_CuentaContableLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.cuentaContableCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            cuentaContableLabel = new System.Windows.Forms.Label();
            id_CuentaContableLabel = new System.Windows.Forms.Label();
            debeLabel = new System.Windows.Forms.Label();
            id_CuentaImporteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaImporteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoAsientosDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debeCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaContableLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaContableCheckEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cuentaContableLabel
            // 
            cuentaContableLabel.AutoSize = true;
            cuentaContableLabel.Location = new System.Drawing.Point(9, 40);
            cuentaContableLabel.Name = "cuentaContableLabel";
            cuentaContableLabel.Size = new System.Drawing.Size(113, 13);
            cuentaContableLabel.TabIndex = 0;
            cuentaContableLabel.Text = "Usa Cuenta Contable:";
            // 
            // id_CuentaContableLabel
            // 
            id_CuentaContableLabel.AutoSize = true;
            id_CuentaContableLabel.Location = new System.Drawing.Point(30, 65);
            id_CuentaContableLabel.Name = "id_CuentaContableLabel";
            id_CuentaContableLabel.Size = new System.Drawing.Size(92, 13);
            id_CuentaContableLabel.TabIndex = 2;
            id_CuentaContableLabel.Text = "Cuenta Contable:";
            // 
            // debeLabel
            // 
            debeLabel.AutoSize = true;
            debeLabel.Location = new System.Drawing.Point(86, 91);
            debeLabel.Name = "debeLabel";
            debeLabel.Size = new System.Drawing.Size(36, 13);
            debeLabel.TabIndex = 4;
            debeLabel.Text = "Debe:";
            // 
            // id_CuentaImporteLabel
            // 
            id_CuentaImporteLabel.AutoSize = true;
            id_CuentaImporteLabel.Location = new System.Drawing.Point(35, 14);
            id_CuentaImporteLabel.Name = "id_CuentaImporteLabel";
            id_CuentaImporteLabel.Size = new System.Drawing.Size(87, 13);
            id_CuentaImporteLabel.TabIndex = 6;
            id_CuentaImporteLabel.Text = "Cuenta Importe:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(437, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 153);
            this.barDockControlBottom.Size = new System.Drawing.Size(437, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 129);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(437, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 129);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_CuentaImporteLabel);
            this.groupControl1.Controls.Add(this.id_CuentaImporteLookUpEdit);
            this.groupControl1.Controls.Add(debeLabel);
            this.groupControl1.Controls.Add(this.debeCheckEdit);
            this.groupControl1.Controls.Add(id_CuentaContableLabel);
            this.groupControl1.Controls.Add(this.id_CuentaContableLookUpEdit);
            this.groupControl1.Controls.Add(cuentaContableLabel);
            this.groupControl1.Controls.Add(this.cuentaContableCheckEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(413, 115);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_CuentaImporteLookUpEdit
            // 
            this.id_CuentaImporteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoAsientosDetalleManagerBindingSource, "Detalle.Id_CuentaImporte", true));
            this.id_CuentaImporteLookUpEdit.EnterMoveNextControl = true;
            this.id_CuentaImporteLookUpEdit.Location = new System.Drawing.Point(128, 11);
            this.id_CuentaImporteLookUpEdit.MenuManager = this.barManager1;
            this.id_CuentaImporteLookUpEdit.Name = "id_CuentaImporteLookUpEdit";
            this.id_CuentaImporteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CuentaImporteLookUpEdit.Properties.NullText = "";
            this.id_CuentaImporteLookUpEdit.Size = new System.Drawing.Size(269, 20);
            this.id_CuentaImporteLookUpEdit.TabIndex = 0;
            // 
            // tipoAsientosDetalleManagerBindingSource
            // 
            this.tipoAsientosDetalleManagerBindingSource.DataSource = typeof(VENET_Contabilidad_BL.TipoAsientosDetalleManager);
            // 
            // debeCheckEdit
            // 
            this.debeCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoAsientosDetalleManagerBindingSource, "Detalle.Debe", true));
            this.debeCheckEdit.EnterMoveNextControl = true;
            this.debeCheckEdit.Location = new System.Drawing.Point(128, 88);
            this.debeCheckEdit.MenuManager = this.barManager1;
            this.debeCheckEdit.Name = "debeCheckEdit";
            this.debeCheckEdit.Properties.Caption = "";
            this.debeCheckEdit.Size = new System.Drawing.Size(21, 19);
            this.debeCheckEdit.TabIndex = 3;
            // 
            // id_CuentaContableLookUpEdit
            // 
            this.id_CuentaContableLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoAsientosDetalleManagerBindingSource, "Detalle.Id_CuentaContable", true));
            this.id_CuentaContableLookUpEdit.EnterMoveNextControl = true;
            this.id_CuentaContableLookUpEdit.Location = new System.Drawing.Point(128, 62);
            this.id_CuentaContableLookUpEdit.MenuManager = this.barManager1;
            this.id_CuentaContableLookUpEdit.Name = "id_CuentaContableLookUpEdit";
            this.id_CuentaContableLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CuentaContableLookUpEdit.Properties.NullText = "";
            this.id_CuentaContableLookUpEdit.Size = new System.Drawing.Size(269, 20);
            this.id_CuentaContableLookUpEdit.TabIndex = 2;
            // 
            // cuentaContableCheckEdit
            // 
            this.cuentaContableCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoAsientosDetalleManagerBindingSource, "Detalle.CuentaContable", true));
            this.cuentaContableCheckEdit.EnterMoveNextControl = true;
            this.cuentaContableCheckEdit.Location = new System.Drawing.Point(128, 37);
            this.cuentaContableCheckEdit.MenuManager = this.barManager1;
            this.cuentaContableCheckEdit.Name = "cuentaContableCheckEdit";
            this.cuentaContableCheckEdit.Properties.Caption = "";
            this.cuentaContableCheckEdit.Size = new System.Drawing.Size(21, 19);
            this.cuentaContableCheckEdit.TabIndex = 1;
            // 
            // frmTipoAsientosDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 153);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 192);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 192);
            this.Name = "frmTipoAsientosDetalle_AddMod";
            this.Text = "Detalle de Tipos de Asientos";
            this.Load += new System.EventHandler(this.frmTipoAsientosDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaImporteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoAsientosDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debeCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaContableLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaContableCheckEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit id_CuentaImporteLookUpEdit;
        private System.Windows.Forms.BindingSource tipoAsientosDetalleManagerBindingSource;
        private DevExpress.XtraEditors.CheckEdit debeCheckEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CuentaContableLookUpEdit;
        private DevExpress.XtraEditors.CheckEdit cuentaContableCheckEdit;
    }
}