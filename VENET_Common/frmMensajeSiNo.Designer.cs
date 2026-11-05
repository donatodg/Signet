namespace VENET_Common
{
    partial class frmMensajeSiNo
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
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 18F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(193, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(70, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMensaje.Location = new System.Drawing.Point(195, 56);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(503, 78);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnSi
            // 
            this.btnSi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSi.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSi.Font = new System.Drawing.Font("Arial", 11F);
            this.btnSi.Location = new System.Drawing.Point(486, 137);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(103, 33);
            this.btnSi.TabIndex = 2;
            this.btnSi.Text = "Si";
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.BackColor = System.Drawing.Color.SlateBlue;
            this.btnNo.Font = new System.Drawing.Font("Arial", 11F);
            this.btnNo.Location = new System.Drawing.Point(595, 137);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(103, 33);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // frmMensajeSiNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(901, 179);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMensajeSiNo";
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
        public System.Windows.Forms.Button btnSi;
        public System.Windows.Forms.Button btnNo;

    }
}