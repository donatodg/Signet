namespace VENET_Seguridad_UI
{
    partial class frmSeguridadUsuariosCambioPassword
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
            System.Windows.Forms.Label passAnteriorLabel;
            System.Windows.Forms.Label passNuevaLabel;
            System.Windows.Forms.Label passNueva2Label;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.passNueva2TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.seguridadUsuariosCambioPasswordManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.passNuevaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.passAnteriorTextEdit = new DevExpress.XtraEditors.TextEdit();
            passAnteriorLabel = new System.Windows.Forms.Label();
            passNuevaLabel = new System.Windows.Forms.Label();
            passNueva2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passNueva2TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosCambioPasswordManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passNuevaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passAnteriorTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // passAnteriorLabel
            // 
            passAnteriorLabel.AutoSize = true;
            passAnteriorLabel.Location = new System.Drawing.Point(42, 15);
            passAnteriorLabel.Name = "passAnteriorLabel";
            passAnteriorLabel.Size = new System.Drawing.Size(80, 13);
            passAnteriorLabel.TabIndex = 0;
            passAnteriorLabel.Text = "Clave Anterior:";
            // 
            // passNuevaLabel
            // 
            passNuevaLabel.AutoSize = true;
            passNuevaLabel.Location = new System.Drawing.Point(50, 41);
            passNuevaLabel.Name = "passNuevaLabel";
            passNuevaLabel.Size = new System.Drawing.Size(72, 13);
            passNuevaLabel.TabIndex = 2;
            passNuevaLabel.Text = "Clave Nueva:";
            // 
            // passNueva2Label
            // 
            passNueva2Label.AutoSize = true;
            passNueva2Label.Location = new System.Drawing.Point(12, 67);
            passNueva2Label.Name = "passNueva2Label";
            passNueva2Label.Size = new System.Drawing.Size(106, 13);
            passNueva2Label.TabIndex = 4;
            passNueva2Label.Text = "Repita Clave Nueva:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(passNueva2Label);
            this.groupControl1.Controls.Add(this.passNueva2TextEdit);
            this.groupControl1.Controls.Add(passNuevaLabel);
            this.groupControl1.Controls.Add(this.passNuevaTextEdit);
            this.groupControl1.Controls.Add(passAnteriorLabel);
            this.groupControl1.Controls.Add(this.passAnteriorTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(312, 98);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // passNueva2TextEdit
            // 
            this.passNueva2TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosCambioPasswordManagerBindingSource, "CambioClave.PassNueva2", true));
            this.passNueva2TextEdit.EnterMoveNextControl = true;
            this.passNueva2TextEdit.Location = new System.Drawing.Point(124, 64);
            this.passNueva2TextEdit.MenuManager = this.barManager1;
            this.passNueva2TextEdit.Name = "passNueva2TextEdit";
            this.passNueva2TextEdit.Properties.PasswordChar = '*';
            this.passNueva2TextEdit.Size = new System.Drawing.Size(173, 20);
            this.passNueva2TextEdit.TabIndex = 5;
            // 
            // seguridadUsuariosCambioPasswordManagerBindingSource
            // 
            this.seguridadUsuariosCambioPasswordManagerBindingSource.DataSource = typeof(VENET_Seguridad_BL.SeguridadUsuariosCambioPasswordManager);
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
            this.btnAceptar.Glyph = global::VENET_Seguridad_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(336, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 138);
            this.barDockControlBottom.Size = new System.Drawing.Size(336, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 114);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(336, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 114);
            // 
            // passNuevaTextEdit
            // 
            this.passNuevaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosCambioPasswordManagerBindingSource, "CambioClave.PassNueva", true));
            this.passNuevaTextEdit.EnterMoveNextControl = true;
            this.passNuevaTextEdit.Location = new System.Drawing.Point(124, 38);
            this.passNuevaTextEdit.MenuManager = this.barManager1;
            this.passNuevaTextEdit.Name = "passNuevaTextEdit";
            this.passNuevaTextEdit.Properties.PasswordChar = '*';
            this.passNuevaTextEdit.Size = new System.Drawing.Size(173, 20);
            this.passNuevaTextEdit.TabIndex = 3;
            // 
            // passAnteriorTextEdit
            // 
            this.passAnteriorTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosCambioPasswordManagerBindingSource, "CambioClave.PassAnterior", true));
            this.passAnteriorTextEdit.EnterMoveNextControl = true;
            this.passAnteriorTextEdit.Location = new System.Drawing.Point(124, 12);
            this.passAnteriorTextEdit.MenuManager = this.barManager1;
            this.passAnteriorTextEdit.Name = "passAnteriorTextEdit";
            this.passAnteriorTextEdit.Properties.PasswordChar = '*';
            this.passAnteriorTextEdit.Size = new System.Drawing.Size(173, 20);
            this.passAnteriorTextEdit.TabIndex = 1;
            // 
            // frmSeguridadUsuariosCambioPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 138);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 177);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 177);
            this.Name = "frmSeguridadUsuariosCambioPassword";

            this.Text = "frmSeguridadUsuariosCambioPassword";
            this.Load += new System.EventHandler(this.frmSeguridadUsuariosCambioPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passNueva2TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosCambioPasswordManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passNuevaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passAnteriorTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit passNueva2TextEdit;
        private System.Windows.Forms.BindingSource seguridadUsuariosCambioPasswordManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit passNuevaTextEdit;
        private DevExpress.XtraEditors.TextEdit passAnteriorTextEdit;
    }
}