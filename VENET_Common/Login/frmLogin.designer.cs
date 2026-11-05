namespace VENET_Common
{
    partial class frmLogin
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            System.Windows.Forms.Label claveLabel;
            System.Windows.Forms.Label usernameLabel;
            this.lnkWeb = new System.Windows.Forms.LinkLabel();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnConfig = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.usernameTextBox = new DevExpress.XtraEditors.TextEdit();
            this.claveTextBox = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxBases = new DevExpress.XtraEditors.LookUpEdit();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            claveLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usernameTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claveTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBases.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.White;
            label1.Name = "label1";
            label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxEmpresa_MouseMove);
            label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // claveLabel
            // 
            resources.ApplyResources(claveLabel, "claveLabel");
            claveLabel.BackColor = System.Drawing.Color.White;
            claveLabel.Name = "claveLabel";
            claveLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            claveLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxClave_MouseMove);
            claveLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // usernameLabel
            // 
            resources.ApplyResources(usernameLabel, "usernameLabel");
            usernameLabel.BackColor = System.Drawing.Color.White;
            usernameLabel.Name = "usernameLabel";
            usernameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            usernameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxUsuario_MouseMove);
            usernameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // lnkWeb
            // 
            this.lnkWeb.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lnkWeb, "lnkWeb");
            this.lnkWeb.LinkColor = System.Drawing.Color.White;
            this.lnkWeb.Name = "lnkWeb";
            this.lnkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWeb_LinkClicked);
            this.lnkWeb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.lnkWeb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxWeb_MouseMove);
            this.lnkWeb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.Color.White;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtMensaje, "txtMensaje");
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.TabStop = false;
            // 
            // btnConfig
            // 
            this.btnConfig.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Appearance.Image")));
            this.btnConfig.Appearance.Options.UseImage = true;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            resources.ApplyResources(this.btnConfig, "btnConfig");
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnAceptar, "btnAceptar");
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.EnterMoveNextControl = true;
            resources.ApplyResources(this.usernameTextBox, "usernameTextBox");
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Enter += new System.EventHandler(this.usernameTextBox_Enter);
            this.usernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameTextBox_KeyPress);
            // 
            // claveTextBox
            // 
            this.claveTextBox.EnterMoveNextControl = true;
            resources.ApplyResources(this.claveTextBox, "claveTextBox");
            this.claveTextBox.Name = "claveTextBox";
            this.claveTextBox.Properties.PasswordChar = '*';
            this.claveTextBox.Enter += new System.EventHandler(this.claveTextBox_Enter);
            this.claveTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.claveTextBox_KeyPress);
            // 
            // comboBoxBases
            // 
            this.comboBoxBases.EnterMoveNextControl = true;
            resources.ApplyResources(this.comboBoxBases, "comboBoxBases");
            this.comboBoxBases.Name = "comboBoxBases";
            this.comboBoxBases.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("comboBoxBases.Properties.Buttons"))))});
            this.comboBoxBases.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("comboBoxBases.Properties.Columns"), resources.GetString("comboBoxBases.Properties.Columns1"))});
            this.comboBoxBases.Properties.NullText = resources.GetString("comboBoxBases.Properties.NullText");
            this.comboBoxBases.Properties.PopupSizeable = false;
            this.comboBoxBases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxBases_KeyPress);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.lblVersion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxVersion_MouseMove);
            this.lblVersion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblNombre, "lblNombre");
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.lblNombre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextboxNombre_MouseMove);
            this.lblNombre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            // 
            // frmLogin
            // 
            this.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("frmLogin.Appearance.BorderColor")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmLogin.Appearance.GradientMode")));
            this.Appearance.Options.UseBorderColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lnkWeb);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.claveTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(claveLabel);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(this.comboBoxBases);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.usernameTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claveTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBases.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkWeb;
        private System.Windows.Forms.TextBox txtMensaje;
        private DevExpress.XtraEditors.SimpleButton btnConfig;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit usernameTextBox;
        private DevExpress.XtraEditors.TextEdit claveTextBox;
        private DevExpress.XtraEditors.LookUpEdit comboBoxBases;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblNombre;
    }
}