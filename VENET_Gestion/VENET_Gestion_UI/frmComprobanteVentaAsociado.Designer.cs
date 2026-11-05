namespace VENET_Gestion_UI
{
    partial class frmComprobanteVentaAsociado
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
            System.Windows.Forms.Label id_ComprobanteVenta_AsociadoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.comprobanteVentaAsociadoManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_ComprobanteVenta_AsociadoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_ComprobanteVenta_AsociadoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobanteVentaAsociadoManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ComprobanteVenta_AsociadoLabel
            // 
            id_ComprobanteVenta_AsociadoLabel.AutoSize = true;
            id_ComprobanteVenta_AsociadoLabel.Location = new System.Drawing.Point(14, 14);
            id_ComprobanteVenta_AsociadoLabel.Name = "id_ComprobanteVenta_AsociadoLabel";
            id_ComprobanteVenta_AsociadoLabel.Size = new System.Drawing.Size(76, 13);
            id_ComprobanteVenta_AsociadoLabel.TabIndex = 0;
            id_ComprobanteVenta_AsociadoLabel.Text = "Comprobante:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(397, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 82);
            this.barDockControlBottom.Size = new System.Drawing.Size(397, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 58);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(397, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 58);
            // 
            // comprobanteVentaAsociadoManagerBindingSource
            // 
            this.comprobanteVentaAsociadoManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobanteVentaAsociadoManager);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_ComprobanteVenta_AsociadoLabel);
            this.groupControl1.Controls.Add(this.id_ComprobanteVenta_AsociadoLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(373, 44);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_ComprobanteVenta_AsociadoLookUpEdit
            // 
            this.id_ComprobanteVenta_AsociadoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobanteVentaAsociadoManagerBindingSource, "Comprobante.Id_ComprobanteVenta_Asociado", true));
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Location = new System.Drawing.Point(96, 11);
            this.id_ComprobanteVenta_AsociadoLookUpEdit.MenuManager = this.barManager1;
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Name = "id_ComprobanteVenta_AsociadoLookUpEdit";
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.NullText = "";
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.ShowFooter = false;
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.ShowHeader = false;
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_ComprobanteVenta_AsociadoLookUpEdit_Properties_ButtonPressed);
            this.id_ComprobanteVenta_AsociadoLookUpEdit.Size = new System.Drawing.Size(260, 20);
            this.id_ComprobanteVenta_AsociadoLookUpEdit.TabIndex = 1;
            // 
            // frmComprobanteVentaAsociado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(397, 82);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(413, 121);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(413, 121);
            this.Name = "frmComprobanteVentaAsociado";
            this.Text = "Seleccione Comprobante";
            this.Load += new System.EventHandler(this.frmCotizacionesComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobanteVentaAsociadoManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ComprobanteVenta_AsociadoLookUpEdit.Properties)).EndInit();
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
        private System.Windows.Forms.BindingSource comprobanteVentaAsociadoManagerBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit id_ComprobanteVenta_AsociadoLookUpEdit;
    }
}