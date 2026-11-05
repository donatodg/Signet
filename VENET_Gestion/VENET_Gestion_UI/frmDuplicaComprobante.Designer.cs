namespace VENET_Gestion_UI
{
    partial class frmDuplicaComprobante
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
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            System.Windows.Forms.Label id_EntidadLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            id_EntidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(7, 39);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            id_TipoComprobanteLabel.TabIndex = 5;
            id_TipoComprobanteLabel.Text = "Comprobante:";
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
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(428, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 104);
            this.barDockControlBottom.Size = new System.Drawing.Size(428, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 80);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(428, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 80);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.id_TipoEntidadLookUpEdit);
            this.groupControl1.Controls.Add(this.id_EntidadLookUpEdit);
            this.groupControl1.Controls.Add(id_EntidadLabel);
            this.groupControl1.Controls.Add(id_TipoComprobanteLabel);
            this.groupControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(404, 66);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(89, 36);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(207, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 2;
            this.id_TipoComprobanteLookUpEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_TipoComprobanteLookUpEdit_KeyPress);
            // 
            // id_TipoEntidadLookUpEdit
            // 
            this.id_TipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoEntidadLookUpEdit.Location = new System.Drawing.Point(89, 10);
            this.id_TipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoEntidadLookUpEdit.Name = "id_TipoEntidadLookUpEdit";
            this.id_TipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name5")});
            this.id_TipoEntidadLookUpEdit.Properties.NullText = "";
            this.id_TipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoEntidadLookUpEdit.TabIndex = 0;
            this.id_TipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_TipoEntidadLookUpEdit_EditValueChanged);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(195, 10);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(193, 20);
            this.id_EntidadLookUpEdit.TabIndex = 1;
            // 
            // id_EntidadLabel
            // 
            id_EntidadLabel.AutoSize = true;
            id_EntidadLabel.Location = new System.Drawing.Point(36, 13);
            id_EntidadLabel.Name = "id_EntidadLabel";
            id_EntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_EntidadLabel.TabIndex = 15;
            id_EntidadLabel.Text = "Entidad:";
            // 
            // frmDuplicaComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 104);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuplicaComprobante";
            this.Text = "Seleccione Comprobante";
            this.Load += new System.EventHandler(this.frmCotizacionesComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
    }
}