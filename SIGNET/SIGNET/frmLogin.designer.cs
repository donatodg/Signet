namespace SitNET
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
            System.Windows.Forms.Label claveLabel;
            System.Windows.Forms.Label usernameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
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
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(40, 150);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 35;
            label1.Text = "Empresa:";
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.BackColor = System.Drawing.Color.White;
            claveLabel.Location = new System.Drawing.Point(54, 122);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new System.Drawing.Size(38, 13);
            claveLabel.TabIndex = 34;
            claveLabel.Text = "Clave:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = System.Drawing.Color.White;
            usernameLabel.Location = new System.Drawing.Point(45, 94);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(47, 13);
            usernameLabel.TabIndex = 33;
            usernameLabel.Text = "Usuario:";
            // 
            // lnkWeb
            // 
            this.lnkWeb.BackColor = System.Drawing.Color.Transparent;
            this.lnkWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkWeb.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkWeb.LinkColor = System.Drawing.Color.White;
            this.lnkWeb.Location = new System.Drawing.Point(4, 332);
            this.lnkWeb.Name = "lnkWeb";
            this.lnkWeb.Size = new System.Drawing.Size(283, 17);
            this.lnkWeb.TabIndex = 38;
            this.lnkWeb.Text = "ersaurbano.com";
            this.lnkWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWeb_LinkClicked);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.Color.White;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.Location = new System.Drawing.Point(97, 253);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMensaje.Size = new System.Drawing.Size(121, 14);
            this.txtMensaje.TabIndex = 37;
            this.txtMensaje.TabStop = false;
            this.txtMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConfig
            // 
            this.btnConfig.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Appearance.Image")));
            this.btnConfig.Appearance.Options.UseImage = true;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnConfig.Location = new System.Drawing.Point(224, 147);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(20, 20);
            this.btnConfig.TabIndex = 36;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(97, 224);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(97, 175);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(121, 43);
            this.btnAceptar.TabIndex = 31;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.EnterMoveNextControl = true;
            this.usernameTextBox.Location = new System.Drawing.Point(97, 91);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(121, 20);
            this.usernameTextBox.TabIndex = 28;
            this.usernameTextBox.Enter += new System.EventHandler(this.usernameTextBox_Enter);
            this.usernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameTextBox_KeyPress);
            // 
            // claveTextBox
            // 
            this.claveTextBox.EnterMoveNextControl = true;
            this.claveTextBox.Location = new System.Drawing.Point(97, 119);
            this.claveTextBox.Name = "claveTextBox";
            this.claveTextBox.Properties.PasswordChar = '*';
            this.claveTextBox.Size = new System.Drawing.Size(121, 20);
            this.claveTextBox.TabIndex = 29;
            this.claveTextBox.Enter += new System.EventHandler(this.claveTextBox_Enter);
            this.claveTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.claveTextBox_KeyPress);
            // 
            // comboBoxBases
            // 
            this.comboBoxBases.EnterMoveNextControl = true;
            this.comboBoxBases.Location = new System.Drawing.Point(97, 147);
            this.comboBoxBases.Name = "comboBoxBases";
            this.comboBoxBases.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxBases.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Empresas")});
            this.comboBoxBases.Properties.NullText = "";
            this.comboBoxBases.Properties.PopupSizeable = false;
            this.comboBoxBases.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBases.TabIndex = 30;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Times New Roman", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(186, 32);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(101, 19);
            this.lblVersion.TabIndex = 40;
            this.lblVersion.Text = "Versión 1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(18, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(269, 23);
            this.lblNombre.TabIndex = 39;
            this.lblNombre.Text = "Sistema Integral de Tesorerías";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmLogin
            // 
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::SitNET.Properties.Resources.Login;
            this.ClientSize = new System.Drawing.Size(295, 358);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
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