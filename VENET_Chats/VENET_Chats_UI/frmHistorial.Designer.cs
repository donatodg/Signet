namespace VENET_Chats_UI
{
    partial class frmHistorial
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
            this.listBoxControlMensajes = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlMensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControlMensajes
            // 
            this.listBoxControlMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxControlMensajes.HorizontalScrollbar = true;
            this.listBoxControlMensajes.IncrementalSearch = true;
            this.listBoxControlMensajes.ItemAutoHeight = true;
            this.listBoxControlMensajes.Location = new System.Drawing.Point(12, 12);
            this.listBoxControlMensajes.Name = "listBoxControlMensajes";
            this.listBoxControlMensajes.Size = new System.Drawing.Size(517, 350);
            this.listBoxControlMensajes.TabIndex = 1;
            this.listBoxControlMensajes.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.listBoxControlMensajes_DrawItem);
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 374);
            this.Controls.Add(this.listBoxControlMensajes);
            this.LookAndFeel.SkinName = "";
            this.Name = "frmHistorial";
            this.Text = "frmHistorial";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlMensajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControlMensajes;
    }
}