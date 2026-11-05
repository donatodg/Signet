namespace VENET_Common
{
    partial class frmMensaje 
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lnkDetalleError = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(193, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(70, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(195, 46);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(503, 88);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 11F);
            this.btnAceptar.Location = new System.Drawing.Point(595, 134);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lnkDetalleError
            // 
            this.lnkDetalleError.AutoSize = true;
            this.lnkDetalleError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDetalleError.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkDetalleError.Location = new System.Drawing.Point(198, 138);
            this.lnkDetalleError.Name = "lnkDetalleError";
            this.lnkDetalleError.Size = new System.Drawing.Size(137, 17);
            this.lnkDetalleError.TabIndex = 3;
            this.lnkDetalleError.TabStop = true;
            this.lnkDetalleError.Text = "Ver Detalle del Error";
            this.lnkDetalleError.Visible = false;
            this.lnkDetalleError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalleError_LinkClicked);
            // 
            // frmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(901, 179);
            this.Controls.Add(this.lnkDetalleError);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMensaje";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMensaje";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Label lblMensaje;
        public System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.LinkLabel lnkDetalleError;

    }
}