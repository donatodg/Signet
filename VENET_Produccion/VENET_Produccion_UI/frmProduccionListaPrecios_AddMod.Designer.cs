namespace VENET_Produccion_UI
{
    partial class frmProduccionListaPrecios_AddMod
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
            System.Windows.Forms.Label vigenteDesdeLabel;
            System.Windows.Forms.Label vigenteHastaLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label utilidadLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.produccionListaPreciosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vigenteHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.vigenteDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.utilidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            vigenteDesdeLabel = new System.Windows.Forms.Label();
            vigenteHastaLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            utilidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(29, 39);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // vigenteDesdeLabel
            // 
            vigenteDesdeLabel.AutoSize = true;
            vigenteDesdeLabel.Location = new System.Drawing.Point(14, 91);
            vigenteDesdeLabel.Name = "vigenteDesdeLabel";
            vigenteDesdeLabel.Size = new System.Drawing.Size(80, 13);
            vigenteDesdeLabel.TabIndex = 2;
            vigenteDesdeLabel.Text = "Vigente Desde:";
            // 
            // vigenteHastaLabel
            // 
            vigenteHastaLabel.AutoSize = true;
            vigenteHastaLabel.Location = new System.Drawing.Point(16, 117);
            vigenteHastaLabel.Name = "vigenteHastaLabel";
            vigenteHastaLabel.Size = new System.Drawing.Size(78, 13);
            vigenteHastaLabel.TabIndex = 4;
            vigenteHastaLabel.Text = "Vigente Hasta:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(42, 13);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 6;
            id_EmpresaLabel.Text = "Empresa:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(371, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 183);
            this.barDockControlBottom.Size = new System.Drawing.Size(371, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(371, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 159);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(utilidadLabel);
            this.groupControl1.Controls.Add(this.utilidadTextEdit);
            this.groupControl1.Controls.Add(id_EmpresaLabel);
            this.groupControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.groupControl1.Controls.Add(vigenteHastaLabel);
            this.groupControl1.Controls.Add(this.vigenteHastaDateEdit);
            this.groupControl1.Controls.Add(vigenteDesdeLabel);
            this.groupControl1.Controls.Add(this.vigenteDesdeDateEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(347, 145);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManagerBindingSource, "Lista.Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(100, 10);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name8")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(226, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // produccionListaPreciosManagerBindingSource
            // 
            this.produccionListaPreciosManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionListaPreciosManager);
            // 
            // vigenteHastaDateEdit
            // 
            this.vigenteHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManagerBindingSource, "Lista.VigenteHasta", true));
            this.vigenteHastaDateEdit.EditValue = null;
            this.vigenteHastaDateEdit.Location = new System.Drawing.Point(100, 114);
            this.vigenteHastaDateEdit.MenuManager = this.barManager1;
            this.vigenteHastaDateEdit.Name = "vigenteHastaDateEdit";
            this.vigenteHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenteHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenteHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenteHastaDateEdit.TabIndex = 4;
            this.vigenteHastaDateEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vigenteHastaDateEdit_KeyPress);
            // 
            // vigenteDesdeDateEdit
            // 
            this.vigenteDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManagerBindingSource, "Lista.VigenteDesde", true));
            this.vigenteDesdeDateEdit.EditValue = null;
            this.vigenteDesdeDateEdit.EnterMoveNextControl = true;
            this.vigenteDesdeDateEdit.Location = new System.Drawing.Point(100, 88);
            this.vigenteDesdeDateEdit.MenuManager = this.barManager1;
            this.vigenteDesdeDateEdit.Name = "vigenteDesdeDateEdit";
            this.vigenteDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenteDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenteDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenteDesdeDateEdit.TabIndex = 3;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManagerBindingSource, "Lista.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(100, 36);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 100;
            this.descripcionTextEdit.Size = new System.Drawing.Size(226, 20);
            this.descripcionTextEdit.TabIndex = 1;
            // 
            // utilidadLabel
            // 
            utilidadLabel.AutoSize = true;
            utilidadLabel.Location = new System.Drawing.Point(48, 65);
            utilidadLabel.Name = "utilidadLabel";
            utilidadLabel.Size = new System.Drawing.Size(46, 13);
            utilidadLabel.TabIndex = 8;
            utilidadLabel.Text = "Utilidad:";
            // 
            // utilidadTextEdit
            // 
            this.utilidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManagerBindingSource, "Lista.Utilidad", true));
            this.utilidadTextEdit.EnterMoveNextControl = true;
            this.utilidadTextEdit.Location = new System.Drawing.Point(100, 62);
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
            // frmProduccionListaPrecios_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 183);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(387, 222);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(387, 222);
            this.Name = "frmProduccionListaPrecios_AddMod";
            this.Text = "Alta/Modificación de Lista de Precios";
            this.Load += new System.EventHandler(this.frmProduccionListaPrecios_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenteDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit vigenteHastaDateEdit;
        private System.Windows.Forms.BindingSource produccionListaPreciosManagerBindingSource;
        private DevExpress.XtraEditors.DateEdit vigenteDesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit utilidadTextEdit;
    }
}