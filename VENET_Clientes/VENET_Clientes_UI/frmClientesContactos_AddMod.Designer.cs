namespace VENET_Clientes_UI
{
    partial class frmClientesContactos_AddMod
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
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label telefono1Label;
            System.Windows.Forms.Label telefono2Label;
            System.Windows.Forms.Label emailLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.emailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.clientesContactosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telefono2TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.telefono1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            nombreLabel = new System.Windows.Forms.Label();
            telefono1Label = new System.Windows.Forms.Label();
            telefono2Label = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesContactosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefono2TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefono1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(20, 12);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            // 
            // telefono1Label
            // 
            telefono1Label.AutoSize = true;
            telefono1Label.Location = new System.Drawing.Point(9, 38);
            telefono1Label.Name = "telefono1Label";
            telefono1Label.Size = new System.Drawing.Size(59, 13);
            telefono1Label.TabIndex = 2;
            telefono1Label.Text = "Telefono1:";
            // 
            // telefono2Label
            // 
            telefono2Label.AutoSize = true;
            telefono2Label.Location = new System.Drawing.Point(9, 64);
            telefono2Label.Name = "telefono2Label";
            telefono2Label.Size = new System.Drawing.Size(59, 13);
            telefono2Label.TabIndex = 4;
            telefono2Label.Text = "Telefono2:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(32, 90);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
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
            this.btnAceptar.Glyph = global::VENET_Clientes_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(385, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 160);
            this.barDockControlBottom.Size = new System.Drawing.Size(385, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 136);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(385, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 136);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(emailLabel);
            this.groupControl1.Controls.Add(this.emailTextEdit);
            this.groupControl1.Controls.Add(telefono2Label);
            this.groupControl1.Controls.Add(this.telefono2TextEdit);
            this.groupControl1.Controls.Add(telefono1Label);
            this.groupControl1.Controls.Add(this.telefono1TextEdit);
            this.groupControl1.Controls.Add(nombreLabel);
            this.groupControl1.Controls.Add(this.nombreTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(361, 120);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // emailTextEdit
            // 
            this.emailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesContactosManagerBindingSource, "Contacto.Email", true));
            this.emailTextEdit.EnterMoveNextControl = true;
            this.emailTextEdit.Location = new System.Drawing.Point(73, 87);
            this.emailTextEdit.MenuManager = this.barManager1;
            this.emailTextEdit.Name = "emailTextEdit";
            this.emailTextEdit.Properties.MaxLength = 50;
            this.emailTextEdit.Size = new System.Drawing.Size(184, 20);
            this.emailTextEdit.TabIndex = 7;
            this.emailTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // clientesContactosManagerBindingSource
            // 
            this.clientesContactosManagerBindingSource.DataSource = typeof(VENET_Clientes_BL.ClientesContactosManager);
            // 
            // telefono2TextEdit
            // 
            this.telefono2TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesContactosManagerBindingSource, "Contacto.Telefono2", true));
            this.telefono2TextEdit.EnterMoveNextControl = true;
            this.telefono2TextEdit.Location = new System.Drawing.Point(73, 61);
            this.telefono2TextEdit.MenuManager = this.barManager1;
            this.telefono2TextEdit.Name = "telefono2TextEdit";
            this.telefono2TextEdit.Properties.MaxLength = 50;
            this.telefono2TextEdit.Size = new System.Drawing.Size(184, 20);
            this.telefono2TextEdit.TabIndex = 5;
            this.telefono2TextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // telefono1TextEdit
            // 
            this.telefono1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesContactosManagerBindingSource, "Contacto.Telefono1", true));
            this.telefono1TextEdit.EnterMoveNextControl = true;
            this.telefono1TextEdit.Location = new System.Drawing.Point(73, 35);
            this.telefono1TextEdit.MenuManager = this.barManager1;
            this.telefono1TextEdit.Name = "telefono1TextEdit";
            this.telefono1TextEdit.Properties.MaxLength = 50;
            this.telefono1TextEdit.Size = new System.Drawing.Size(184, 20);
            this.telefono1TextEdit.TabIndex = 3;
            this.telefono1TextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesContactosManagerBindingSource, "Contacto.Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(73, 9);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Properties.MaxLength = 200;
            this.nombreTextEdit.Size = new System.Drawing.Size(276, 20);
            this.nombreTextEdit.TabIndex = 1;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmClientesContactos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 160);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 199);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 199);
            this.Name = "frmClientesContactos_AddMod";
            this.Text = "Alta/Modificación de Contactos";
            this.Load += new System.EventHandler(this.frmClientesContactos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesContactosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefono2TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefono1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit emailTextEdit;
        private System.Windows.Forms.BindingSource clientesContactosManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit telefono2TextEdit;
        private DevExpress.XtraEditors.TextEdit telefono1TextEdit;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
    }
}