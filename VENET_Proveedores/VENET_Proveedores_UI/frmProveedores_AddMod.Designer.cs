namespace VENET_Proveedores_UI
{
    partial class frmProveedores_AddMod
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
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label id_TipoIvaLabel;
            System.Windows.Forms.Label domicilioLabel;
            System.Windows.Forms.Label id_CodPostalLabel;
            System.Windows.Forms.Label cuitLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label id_ListaPrecioLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ProveedoresManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnGeneraCUIT = new System.Windows.Forms.Button();
            this.empresaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.emailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cuitTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_CodPostalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.domicilioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoIvaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_ListaPrecioLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            nombreLabel = new System.Windows.Forms.Label();
            id_TipoIvaLabel = new System.Windows.Forms.Label();
            domicilioLabel = new System.Windows.Forms.Label();
            id_CodPostalLabel = new System.Windows.Forms.Label();
            cuitLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            id_ListaPrecioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuitTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CodPostalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domicilioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ListaPrecioLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(22, 15);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Nombre:";
            // 
            // id_TipoIvaLabel
            // 
            id_TipoIvaLabel.AutoSize = true;
            id_TipoIvaLabel.Location = new System.Drawing.Point(43, 145);
            id_TipoIvaLabel.Name = "id_TipoIvaLabel";
            id_TipoIvaLabel.Size = new System.Drawing.Size(27, 13);
            id_TipoIvaLabel.TabIndex = 5;
            id_TipoIvaLabel.Text = "Iva:";
            // 
            // domicilioLabel
            // 
            domicilioLabel.AutoSize = true;
            domicilioLabel.Location = new System.Drawing.Point(19, 67);
            domicilioLabel.Name = "domicilioLabel";
            domicilioLabel.Size = new System.Drawing.Size(51, 13);
            domicilioLabel.TabIndex = 6;
            domicilioLabel.Text = "Domicilio:";
            // 
            // id_CodPostalLabel
            // 
            id_CodPostalLabel.AutoSize = true;
            id_CodPostalLabel.Location = new System.Drawing.Point(8, 93);
            id_CodPostalLabel.Name = "id_CodPostalLabel";
            id_CodPostalLabel.Size = new System.Drawing.Size(62, 13);
            id_CodPostalLabel.TabIndex = 7;
            id_CodPostalLabel.Text = "Cod Postal:";
            // 
            // cuitLabel
            // 
            cuitLabel.AutoSize = true;
            cuitLabel.Location = new System.Drawing.Point(40, 119);
            cuitLabel.Name = "cuitLabel";
            cuitLabel.Size = new System.Drawing.Size(30, 13);
            cuitLabel.TabIndex = 8;
            cuitLabel.Text = "Cuit:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(35, 171);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Email:";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new System.Drawing.Point(18, 41);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(52, 13);
            empresaLabel.TabIndex = 12;
            empresaLabel.Text = "Empresa:";
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
            this.btnAceptar.Glyph = global::VENET_Proveedores_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(399, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 275);
            this.barDockControlBottom.Size = new System.Drawing.Size(399, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 251);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(399, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 251);
            // 
            // ProveedoresManagerBindingSource
            // 
            this.ProveedoresManagerBindingSource.DataSource = typeof(VENET_Proveedores_BL.ProveedoresManager);
            this.ProveedoresManagerBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.ProveedoresManagerBindingSource_BindingComplete);
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(76, 12);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Properties.MaxLength = 100;
            this.nombreTextEdit.Size = new System.Drawing.Size(278, 20);
            this.nombreTextEdit.TabIndex = 0;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(id_ListaPrecioLabel);
            this.groupControl1.Controls.Add(this.id_ListaPrecioLookUpEdit);
            this.groupControl1.Controls.Add(this.btnGeneraCUIT);
            this.groupControl1.Controls.Add(empresaLabel);
            this.groupControl1.Controls.Add(this.empresaTextEdit);
            this.groupControl1.Controls.Add(emailLabel);
            this.groupControl1.Controls.Add(this.emailTextEdit);
            this.groupControl1.Controls.Add(cuitLabel);
            this.groupControl1.Controls.Add(this.cuitTextEdit);
            this.groupControl1.Controls.Add(id_CodPostalLabel);
            this.groupControl1.Controls.Add(this.id_CodPostalLookUpEdit);
            this.groupControl1.Controls.Add(domicilioLabel);
            this.groupControl1.Controls.Add(this.domicilioTextEdit);
            this.groupControl1.Controls.Add(id_TipoIvaLabel);
            this.groupControl1.Controls.Add(this.id_TipoIvaLookUpEdit);
            this.groupControl1.Controls.Add(this.nombreTextEdit);
            this.groupControl1.Controls.Add(nombreLabel);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(375, 233);
            this.groupControl1.TabIndex = 0;
            // 
            // btnGeneraCUIT
            // 
            this.btnGeneraCUIT.Location = new System.Drawing.Point(182, 116);
            this.btnGeneraCUIT.Name = "btnGeneraCUIT";
            this.btnGeneraCUIT.Size = new System.Drawing.Size(42, 20);
            this.btnGeneraCUIT.TabIndex = 5;
            this.btnGeneraCUIT.Text = "CUIT";
            this.btnGeneraCUIT.UseVisualStyleBackColor = true;
            this.btnGeneraCUIT.Click += new System.EventHandler(this.btnGeneraCUIT_Click);
            // 
            // empresaTextEdit
            // 
            this.empresaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Empresa", true));
            this.empresaTextEdit.EnterMoveNextControl = true;
            this.empresaTextEdit.Location = new System.Drawing.Point(76, 38);
            this.empresaTextEdit.MenuManager = this.barManager1;
            this.empresaTextEdit.Name = "empresaTextEdit";
            this.empresaTextEdit.Properties.MaxLength = 100;
            this.empresaTextEdit.Size = new System.Drawing.Size(278, 20);
            this.empresaTextEdit.TabIndex = 1;
            // 
            // emailTextEdit
            // 
            this.emailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Email", true));
            this.emailTextEdit.EnterMoveNextControl = true;
            this.emailTextEdit.Location = new System.Drawing.Point(76, 168);
            this.emailTextEdit.MenuManager = this.barManager1;
            this.emailTextEdit.Name = "emailTextEdit";
            this.emailTextEdit.Size = new System.Drawing.Size(278, 20);
            this.emailTextEdit.TabIndex = 7;
            // 
            // cuitTextEdit
            // 
            this.cuitTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Cuit", true));
            this.cuitTextEdit.EnterMoveNextControl = true;
            this.cuitTextEdit.Location = new System.Drawing.Point(76, 116);
            this.cuitTextEdit.MenuManager = this.barManager1;
            this.cuitTextEdit.Name = "cuitTextEdit";
            this.cuitTextEdit.Properties.Mask.EditMask = "00-00000000-0";
            this.cuitTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.cuitTextEdit.Size = new System.Drawing.Size(100, 20);
            this.cuitTextEdit.TabIndex = 4;
            // 
            // id_CodPostalLookUpEdit
            // 
            this.id_CodPostalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Id_CodPostal", true));
            this.id_CodPostalLookUpEdit.EnterMoveNextControl = true;
            this.id_CodPostalLookUpEdit.Location = new System.Drawing.Point(76, 90);
            this.id_CodPostalLookUpEdit.MenuManager = this.barManager1;
            this.id_CodPostalLookUpEdit.Name = "id_CodPostalLookUpEdit";
            this.id_CodPostalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CodPostalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodPostal", "Cod.Postal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Localidad", "Localidad"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Provincia", "Provincia")});
            this.id_CodPostalLookUpEdit.Properties.NullText = "";
            this.id_CodPostalLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_CodPostalLookUpEdit.TabIndex = 3;
            // 
            // domicilioTextEdit
            // 
            this.domicilioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Domicilio", true));
            this.domicilioTextEdit.EnterMoveNextControl = true;
            this.domicilioTextEdit.Location = new System.Drawing.Point(76, 64);
            this.domicilioTextEdit.MenuManager = this.barManager1;
            this.domicilioTextEdit.Name = "domicilioTextEdit";
            this.domicilioTextEdit.Properties.MaxLength = 100;
            this.domicilioTextEdit.Size = new System.Drawing.Size(278, 20);
            this.domicilioTextEdit.TabIndex = 2;
            // 
            // id_TipoIvaLookUpEdit
            // 
            this.id_TipoIvaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Id_TipoIva", true));
            this.id_TipoIvaLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoIvaLookUpEdit.Location = new System.Drawing.Point(76, 142);
            this.id_TipoIvaLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoIvaLookUpEdit.Name = "id_TipoIvaLookUpEdit";
            this.id_TipoIvaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoIvaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3")});
            this.id_TipoIvaLookUpEdit.Properties.NullText = "";
            this.id_TipoIvaLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoIvaLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_TipoIvaLookUpEdit.TabIndex = 6;
            // 
            // id_ListaPrecioLabel
            // 
            id_ListaPrecioLabel.AutoSize = true;
            id_ListaPrecioLabel.Location = new System.Drawing.Point(5, 197);
            id_ListaPrecioLabel.Name = "id_ListaPrecioLabel";
            id_ListaPrecioLabel.Size = new System.Drawing.Size(65, 13);
            id_ListaPrecioLabel.TabIndex = 45;
            id_ListaPrecioLabel.Text = "Lista Precio:";
            // 
            // id_ListaPrecioLookUpEdit
            // 
            this.id_ListaPrecioLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProveedoresManagerBindingSource, "Proveedores.Id_ListaPrecio", true));
            this.id_ListaPrecioLookUpEdit.EnterMoveNextControl = true;
            this.id_ListaPrecioLookUpEdit.Location = new System.Drawing.Point(76, 194);
            this.id_ListaPrecioLookUpEdit.MenuManager = this.barManager1;
            this.id_ListaPrecioLookUpEdit.Name = "id_ListaPrecioLookUpEdit";
            this.id_ListaPrecioLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ListaPrecioLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name5")});
            this.id_ListaPrecioLookUpEdit.Properties.NullText = "";
            this.id_ListaPrecioLookUpEdit.Properties.ShowHeader = false;
            this.id_ListaPrecioLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_ListaPrecioLookUpEdit.TabIndex = 8;
            this.id_ListaPrecioLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_ListaPrecioLookUpEdit_ButtonPressed);
            // 
            // frmProveedores_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(399, 275);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 314);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 314);
            this.Name = "frmProveedores_AddMod";
            this.Text = "Alta/Modificación de Proveedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProveedores_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmProveedores_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuitTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CodPostalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domicilioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ListaPrecioLookUpEdit.Properties)).EndInit();
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
        private System.Windows.Forms.BindingSource ProveedoresManagerBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoIvaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit cuitTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CodPostalLookUpEdit;
        private DevExpress.XtraEditors.TextEdit domicilioTextEdit;
        private DevExpress.XtraEditors.TextEdit emailTextEdit;
        private DevExpress.XtraEditors.TextEdit empresaTextEdit;
        private System.Windows.Forms.Button btnGeneraCUIT;
        private DevExpress.XtraEditors.LookUpEdit id_ListaPrecioLookUpEdit;
    }
}