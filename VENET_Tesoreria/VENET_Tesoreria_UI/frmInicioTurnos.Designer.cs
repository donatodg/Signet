namespace VENET_Tesoreria_UI
{
    partial class frmInicioTurnos
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label usernameLabel;
            System.Windows.Forms.Label fechaInicioLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fechaInicioLabel1 = new System.Windows.Forms.Label();
            this.inicioTurnoManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.usernameLabel1 = new System.Windows.Forms.Label();
            this.idLabel1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            fechaInicioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioTurnoManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(62, 34);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(39, 13);
            idLabel.TabIndex = 2;
            idLabel.Text = "Turno:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(54, 11);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(47, 13);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Usuario:";
            // 
            // fechaInicioLabel
            // 
            fechaInicioLabel.AutoSize = true;
            fechaInicioLabel.Location = new System.Drawing.Point(32, 57);
            fechaInicioLabel.Name = "fechaInicioLabel";
            fechaInicioLabel.Size = new System.Drawing.Size(68, 13);
            fechaInicioLabel.TabIndex = 4;
            fechaInicioLabel.Text = "Fecha Inicio:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(fechaInicioLabel);
            this.groupControl1.Controls.Add(this.fechaInicioLabel1);
            this.groupControl1.Controls.Add(usernameLabel);
            this.groupControl1.Controls.Add(this.usernameLabel1);
            this.groupControl1.Controls.Add(idLabel);
            this.groupControl1.Controls.Add(this.idLabel1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(318, 89);
            this.groupControl1.TabIndex = 4;
            // 
            // fechaInicioLabel1
            // 
            this.fechaInicioLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inicioTurnoManagerBindingSource, "Turno.FechaInicio", true));
            this.fechaInicioLabel1.Location = new System.Drawing.Point(106, 57);
            this.fechaInicioLabel1.Name = "fechaInicioLabel1";
            this.fechaInicioLabel1.Size = new System.Drawing.Size(161, 23);
            this.fechaInicioLabel1.TabIndex = 5;
            this.fechaInicioLabel1.Text = "label1";
            // 
            // inicioTurnoManagerBindingSource
            // 
            this.inicioTurnoManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.InicioTurnoManager);
            // 
            // usernameLabel1
            // 
            this.usernameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inicioTurnoManagerBindingSource, "Username", true));
            this.usernameLabel1.Location = new System.Drawing.Point(106, 11);
            this.usernameLabel1.Name = "usernameLabel1";
            this.usernameLabel1.Size = new System.Drawing.Size(161, 23);
            this.usernameLabel1.TabIndex = 4;
            this.usernameLabel1.Text = "label1";
            // 
            // idLabel1
            // 
            this.idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inicioTurnoManagerBindingSource, "NroTurno", true));
            this.idLabel1.Location = new System.Drawing.Point(106, 34);
            this.idLabel1.Name = "idLabel1";
            this.idLabel1.Size = new System.Drawing.Size(161, 23);
            this.idLabel1.TabIndex = 3;
            this.idLabel1.Text = "label1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSalir);
            this.panelControl1.Controls.Add(this.btnAceptar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 116);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(342, 40);
            this.panelControl1.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(255, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(174, 8);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Iniciar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmInicioTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 156);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 195);
            this.Name = "frmInicioTurnos";
            this.ShowIcon = false;

            this.Text = "Inicio de Turno";
            this.Load += new System.EventHandler(this.frmInicioTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioTurnoManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource inicioTurnoManagerBindingSource;
        private System.Windows.Forms.Label fechaInicioLabel1;
        private System.Windows.Forms.Label usernameLabel1;
        private System.Windows.Forms.Label idLabel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
    }
}