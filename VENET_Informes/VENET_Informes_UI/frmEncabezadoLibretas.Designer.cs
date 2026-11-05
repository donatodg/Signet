namespace VENET_Informes_UI
{
    partial class frmEncabezadoLibretas
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
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label desdeLabel;
            System.Windows.Forms.Label hastaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnImprime = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarCheckItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.hastaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.encabezadoLibretasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.desdeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            desdeLabel = new System.Windows.Forms.Label();
            hastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hastaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encabezadoLibretasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desdeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(14, 11);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 0;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // desdeLabel
            // 
            desdeLabel.AutoSize = true;
            desdeLabel.Location = new System.Drawing.Point(25, 37);
            desdeLabel.Name = "desdeLabel";
            desdeLabel.Size = new System.Drawing.Size(41, 13);
            desdeLabel.TabIndex = 2;
            desdeLabel.Text = "Desde:";
            // 
            // hastaLabel
            // 
            hastaLabel.AutoSize = true;
            hastaLabel.Location = new System.Drawing.Point(27, 63);
            hastaLabel.Name = "hastaLabel";
            hastaLabel.Size = new System.Drawing.Size(39, 13);
            hastaLabel.TabIndex = 4;
            hastaLabel.Text = "Hasta:";
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
            this.btnImprimir,
            this.btnSalir,
            this.btnImprime});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprime, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnImprime
            // 
            this.btnImprime.Caption = "Imprmir";
            this.btnImprime.Glyph = global::VENET_Informes_UI.Properties.Resources.print_16x16;
            this.btnImprime.Id = 3;
            this.btnImprime.Name = "btnImprime";
            this.btnImprime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprime_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(353, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 129);
            this.barDockControlBottom.Size = new System.Drawing.Size(353, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 105);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(353, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 105);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Id = 4;
            this.btnImprimir.Name = "btnImprimir";
            // 
            // btnSalir
            // 
            this.btnSalir.Id = 5;
            this.btnSalir.Name = "btnSalir";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(hastaLabel);
            this.groupControl1.Controls.Add(this.hastaTextEdit);
            this.groupControl1.Controls.Add(desdeLabel);
            this.groupControl1.Controls.Add(this.desdeTextEdit);
            this.groupControl1.Controls.Add(id_EmpresaLabel);
            this.groupControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(329, 89);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // hastaTextEdit
            // 
            this.hastaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.encabezadoLibretasManagerBindingSource, "Hasta", true));
            this.hastaTextEdit.EnterMoveNextControl = true;
            this.hastaTextEdit.Location = new System.Drawing.Point(72, 60);
            this.hastaTextEdit.MenuManager = this.barManager1;
            this.hastaTextEdit.Name = "hastaTextEdit";
            this.hastaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.hastaTextEdit.TabIndex = 5;
            // 
            // encabezadoLibretasManagerBindingSource
            // 
            this.encabezadoLibretasManagerBindingSource.DataSource = typeof(VENET_Informes_BL.EncabezadoLibretasManager);
            // 
            // desdeTextEdit
            // 
            this.desdeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.encabezadoLibretasManagerBindingSource, "Desde", true));
            this.desdeTextEdit.EnterMoveNextControl = true;
            this.desdeTextEdit.Location = new System.Drawing.Point(72, 34);
            this.desdeTextEdit.MenuManager = this.barManager1;
            this.desdeTextEdit.Name = "desdeTextEdit";
            this.desdeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.desdeTextEdit.TabIndex = 3;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.encabezadoLibretasManagerBindingSource, "id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(72, 8);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(241, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 1;
            // 
            // frmEncabezadoLibretas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 129);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 168);
            this.MinimizeBox = false;
            this.Name = "frmEncabezadoLibretas";
            this.Text = "Impresión de Encabezado de Libretas";
            this.Load += new System.EventHandler(this.frmEncabezadoLibretas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hastaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encabezadoLibretasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desdeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarCheckItem btnSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource encabezadoLibretasManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit hastaTextEdit;
        private DevExpress.XtraEditors.TextEdit desdeTextEdit;
        private DevExpress.XtraBars.BarButtonItem btnImprime;
    }
}