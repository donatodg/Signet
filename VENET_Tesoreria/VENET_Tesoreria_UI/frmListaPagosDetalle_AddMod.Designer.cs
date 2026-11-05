namespace VENET_Tesoreria_UI
{
    partial class frmListaPagosDetalle_AddMod
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
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPagosDetalle_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.listaPagosDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EntidadLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EntidadLabel
            // 
            id_EntidadLabel.AutoSize = true;
            id_EntidadLabel.Location = new System.Drawing.Point(29, 14);
            id_EntidadLabel.Name = "id_EntidadLabel";
            id_EntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_EntidadLabel.TabIndex = 0;
            id_EntidadLabel.Text = "Entidad:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(27, 40);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 2;
            importeLabel.Text = "Importe:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(10, 66);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripción:";
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
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Glyph")));
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(423, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 139);
            this.barDockControlBottom.Size = new System.Drawing.Size(423, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 115);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(423, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 115);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Controls.Add(id_EntidadLabel);
            this.groupControl1.Controls.Add(this.id_EntidadLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(399, 97);
            this.groupControl1.TabIndex = 0;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosDetalleManagerBindingSource, "ListaDetalle.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(81, 63);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 100;
            this.descripcionTextEdit.Size = new System.Drawing.Size(302, 20);
            this.descripcionTextEdit.TabIndex = 2;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // listaPagosDetalleManagerBindingSource
            // 
            this.listaPagosDetalleManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ListaPagosDetalleManager);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosDetalleManagerBindingSource, "ListaDetalle.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(82, 37);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 1;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosDetalleManagerBindingSource, "ListaDetalle.Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(82, 11);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key2", 7, "Id/Legajo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(301, 20);
            this.id_EntidadLookUpEdit.TabIndex = 0;
            // 
            // frmListaPagosDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 139);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 178);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 178);
            this.Name = "frmListaPagosDetalle_AddMod";
            this.Text = "Alta/Modificación de Detalle";
            this.Load += new System.EventHandler(this.frmReciboDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource listaPagosDetalleManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
    }
}