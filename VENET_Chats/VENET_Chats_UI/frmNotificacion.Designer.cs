namespace VENET_Chats_UI
{
    partial class frmNotificacion
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnVer = new System.Windows.Forms.Button();
            this.lblNotificacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnVer);
            this.groupControl1.Controls.Add(this.lblNotificacion);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(308, 95);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(222, 64);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 1;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // lblNotificacion
            // 
            this.lblNotificacion.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNotificacion.Location = new System.Drawing.Point(13, 12);
            this.lblNotificacion.Name = "lblNotificacion";
            this.lblNotificacion.Size = new System.Drawing.Size(284, 49);
            this.lblNotificacion.TabIndex = 0;
            this.lblNotificacion.Text = "Ha recibido un mensaje nuevo de xxxxxxx, xxxxxxxx xxxxxxx";
            // 
            // frmNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 119);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(348, 158);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 158);
            this.Name = "frmNotificacion";
            this.Text = "Nueva Notificación";
            this.Load += new System.EventHandler(this.frmNotificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lblNotificacion;
    }
}