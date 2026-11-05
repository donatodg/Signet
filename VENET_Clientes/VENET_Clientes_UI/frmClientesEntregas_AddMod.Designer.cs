namespace VENET_Clientes_UI
{
    partial class frmClientesEntregas_AddMod
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
            System.Windows.Forms.Label direccionLabel;
            System.Windows.Forms.Label telefonoLabel;
            System.Windows.Forms.Label emailLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.clientesEntregasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.direccionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.telefonoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.emailTextEdit = new DevExpress.XtraEditors.TextEdit();
            nombreLabel = new System.Windows.Forms.Label();
            direccionLabel = new System.Windows.Forms.Label();
            telefonoLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesEntregasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(338, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 160);
            this.barDockControlBottom.Size = new System.Drawing.Size(338, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(338, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 136);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(emailLabel);
            this.groupControl1.Controls.Add(this.emailTextEdit);
            this.groupControl1.Controls.Add(telefonoLabel);
            this.groupControl1.Controls.Add(this.telefonoTextEdit);
            this.groupControl1.Controls.Add(direccionLabel);
            this.groupControl1.Controls.Add(this.direccionTextEdit);
            this.groupControl1.Controls.Add(nombreLabel);
            this.groupControl1.Controls.Add(this.nombreTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(314, 120);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // clientesEntregasManagerBindingSource
            // 
            this.clientesEntregasManagerBindingSource.DataSource = typeof(VENET_Clientes_BL.ClientesEntregasManager);
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(19, 14);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesEntregasManagerBindingSource, "Entrega.Nombre", true));
            this.nombreTextEdit.Location = new System.Drawing.Point(73, 11);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(223, 20);
            this.nombreTextEdit.TabIndex = 1;
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Location = new System.Drawing.Point(13, 40);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new System.Drawing.Size(54, 13);
            direccionLabel.TabIndex = 2;
            direccionLabel.Text = "Dirección:";
            // 
            // direccionTextEdit
            // 
            this.direccionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesEntregasManagerBindingSource, "Entrega.Direccion", true));
            this.direccionTextEdit.Location = new System.Drawing.Point(73, 37);
            this.direccionTextEdit.MenuManager = this.barManager1;
            this.direccionTextEdit.Name = "direccionTextEdit";
            this.direccionTextEdit.Size = new System.Drawing.Size(223, 20);
            this.direccionTextEdit.TabIndex = 3;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new System.Drawing.Point(14, 66);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(53, 13);
            telefonoLabel.TabIndex = 4;
            telefonoLabel.Text = "Teléfono:";
            // 
            // telefonoTextEdit
            // 
            this.telefonoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesEntregasManagerBindingSource, "Entrega.Telefono", true));
            this.telefonoTextEdit.Location = new System.Drawing.Point(73, 63);
            this.telefonoTextEdit.MenuManager = this.barManager1;
            this.telefonoTextEdit.Name = "telefonoTextEdit";
            this.telefonoTextEdit.Size = new System.Drawing.Size(223, 20);
            this.telefonoTextEdit.TabIndex = 5;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(32, 92);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
            // 
            // emailTextEdit
            // 
            this.emailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesEntregasManagerBindingSource, "Entrega.Email", true));
            this.emailTextEdit.Location = new System.Drawing.Point(73, 89);
            this.emailTextEdit.MenuManager = this.barManager1;
            this.emailTextEdit.Name = "emailTextEdit";
            this.emailTextEdit.Size = new System.Drawing.Size(223, 20);
            this.emailTextEdit.TabIndex = 7;
            // 
            // frmClientesEntregas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 160);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 199);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 199);
            this.Name = "frmClientesEntregas_AddMod";
            this.Text = "Alta/Modificación de Descuentos";
            this.Load += new System.EventHandler(this.frmClientesDescuentos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesEntregasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).EndInit();
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
        private System.Windows.Forms.BindingSource clientesEntregasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit telefonoTextEdit;
        private DevExpress.XtraEditors.TextEdit direccionTextEdit;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
    }
}