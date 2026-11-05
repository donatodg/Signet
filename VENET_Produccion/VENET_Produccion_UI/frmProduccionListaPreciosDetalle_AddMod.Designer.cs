namespace VENET_Produccion_UI
{
    partial class frmProduccionListaPreciosDetalle_AddMod
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
            System.Windows.Forms.Label costoComposicionLabel;
            System.Windows.Forms.Label costoTareasLabel;
            System.Windows.Forms.Label utilidadLabel;
            System.Windows.Forms.Label totalLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.totalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.produccionListaPreciosDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.costoTareasTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.costoComposicionTextEdit = new DevExpress.XtraEditors.TextEdit();
            costoComposicionLabel = new System.Windows.Forms.Label();
            costoTareasLabel = new System.Windows.Forms.Label();
            utilidadLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costoTareasTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costoComposicionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // costoComposicionLabel
            // 
            costoComposicionLabel.AutoSize = true;
            costoComposicionLabel.Location = new System.Drawing.Point(17, 15);
            costoComposicionLabel.Name = "costoComposicionLabel";
            costoComposicionLabel.Size = new System.Drawing.Size(101, 13);
            costoComposicionLabel.TabIndex = 0;
            costoComposicionLabel.Text = "Costo Composición:";
            // 
            // costoTareasLabel
            // 
            costoTareasLabel.AutoSize = true;
            costoTareasLabel.Location = new System.Drawing.Point(43, 41);
            costoTareasLabel.Name = "costoTareasLabel";
            costoTareasLabel.Size = new System.Drawing.Size(75, 13);
            costoTareasLabel.TabIndex = 2;
            costoTareasLabel.Text = "Costo Tareas:";
            // 
            // utilidadLabel
            // 
            utilidadLabel.AutoSize = true;
            utilidadLabel.Location = new System.Drawing.Point(72, 67);
            utilidadLabel.Name = "utilidadLabel";
            utilidadLabel.Size = new System.Drawing.Size(46, 13);
            utilidadLabel.TabIndex = 4;
            utilidadLabel.Text = "Utilidad:";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new System.Drawing.Point(83, 93);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(35, 13);
            totalLabel.TabIndex = 6;
            totalLabel.Text = "Total:";
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
            this.btnAceptar.Glyph = global::VENET_Produccion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(348, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 165);
            this.barDockControlBottom.Size = new System.Drawing.Size(348, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 141);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(348, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 141);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnRecalcular);
            this.groupControl1.Controls.Add(totalLabel);
            this.groupControl1.Controls.Add(this.totalTextEdit);
            this.groupControl1.Controls.Add(utilidadLabel);
            this.groupControl1.Controls.Add(this.utilidadTextEdit);
            this.groupControl1.Controls.Add(costoTareasLabel);
            this.groupControl1.Controls.Add(this.costoTareasTextEdit);
            this.groupControl1.Controls.Add(costoComposicionLabel);
            this.groupControl1.Controls.Add(this.costoComposicionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(324, 125);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Location = new System.Drawing.Point(230, 62);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(75, 23);
            this.btnRecalcular.TabIndex = 4;
            this.btnRecalcular.Text = "Recalcular";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // totalTextEdit
            // 
            this.totalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosDetalleManagerBindingSource, "Lista.Total", true));
            this.totalTextEdit.Location = new System.Drawing.Point(124, 90);
            this.totalTextEdit.MenuManager = this.barManager1;
            this.totalTextEdit.Name = "totalTextEdit";
            this.totalTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.totalTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.totalTextEdit.Properties.EditFormat.FormatString = "n2";
            this.totalTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.totalTextEdit.Properties.Mask.EditMask = "n2";
            this.totalTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.totalTextEdit.Size = new System.Drawing.Size(100, 20);
            this.totalTextEdit.TabIndex = 3;
            // 
            // produccionListaPreciosDetalleManagerBindingSource
            // 
            this.produccionListaPreciosDetalleManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionListaPreciosDetalleManager);
            // 
            // utilidadTextEdit
            // 
            this.utilidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosDetalleManagerBindingSource, "Lista.Utilidad", true));
            this.utilidadTextEdit.EnterMoveNextControl = true;
            this.utilidadTextEdit.Location = new System.Drawing.Point(124, 64);
            this.utilidadTextEdit.MenuManager = this.barManager1;
            this.utilidadTextEdit.Name = "utilidadTextEdit";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.EditFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.Mask.EditMask = "n2";
            this.utilidadTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.utilidadTextEdit.Size = new System.Drawing.Size(100, 20);
            this.utilidadTextEdit.TabIndex = 2;
            // 
            // costoTareasTextEdit
            // 
            this.costoTareasTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosDetalleManagerBindingSource, "Lista.CostoTareas", true));
            this.costoTareasTextEdit.Enabled = false;
            this.costoTareasTextEdit.EnterMoveNextControl = true;
            this.costoTareasTextEdit.Location = new System.Drawing.Point(124, 38);
            this.costoTareasTextEdit.MenuManager = this.barManager1;
            this.costoTareasTextEdit.Name = "costoTareasTextEdit";
            this.costoTareasTextEdit.Properties.Mask.EditMask = "n2";
            this.costoTareasTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.costoTareasTextEdit.Size = new System.Drawing.Size(100, 20);
            this.costoTareasTextEdit.TabIndex = 1;
            // 
            // costoComposicionTextEdit
            // 
            this.costoComposicionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosDetalleManagerBindingSource, "Lista.CostoComposicion", true));
            this.costoComposicionTextEdit.Enabled = false;
            this.costoComposicionTextEdit.EnterMoveNextControl = true;
            this.costoComposicionTextEdit.Location = new System.Drawing.Point(124, 12);
            this.costoComposicionTextEdit.MenuManager = this.barManager1;
            this.costoComposicionTextEdit.Name = "costoComposicionTextEdit";
            this.costoComposicionTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.costoComposicionTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.costoComposicionTextEdit.Properties.EditFormat.FormatString = "n2";
            this.costoComposicionTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.costoComposicionTextEdit.Properties.Mask.EditMask = "n2";
            this.costoComposicionTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.costoComposicionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.costoComposicionTextEdit.TabIndex = 0;
            // 
            // frmProduccionListaPreciosDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 165);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 204);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 204);
            this.Name = "frmProduccionListaPreciosDetalle_AddMod";
            this.Text = "Modificar Lista de Precios";
            this.Load += new System.EventHandler(this.frmProduccionListaPreciosDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costoTareasTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costoComposicionTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private System.Windows.Forms.Button btnRecalcular;
        private DevExpress.XtraEditors.TextEdit totalTextEdit;
        private System.Windows.Forms.BindingSource produccionListaPreciosDetalleManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit utilidadTextEdit;
        private DevExpress.XtraEditors.TextEdit costoTareasTextEdit;
        private DevExpress.XtraEditors.TextEdit costoComposicionTextEdit;
    }
}