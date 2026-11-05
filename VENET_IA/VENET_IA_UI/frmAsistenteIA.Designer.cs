namespace VENET_IA_UI
{
    partial class frmAsistenteIA
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblUso = new System.Windows.Forms.Label();
            this.chkVerSql = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbConversacion = new System.Windows.Forms.RichTextBox();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.flpSugerencias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.lblUso);
            this.pnlSuperior.Controls.Add(this.chkVerSql);
            this.pnlSuperior.Controls.Add(this.btnExportar);
            this.pnlSuperior.Controls.Add(this.btnNueva);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlSuperior.Size = new System.Drawing.Size(944, 40);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblUso
            // 
            this.lblUso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUso.ForeColor = System.Drawing.Color.DimGray;
            this.lblUso.Location = new System.Drawing.Point(8, 6);
            this.lblUso.Name = "lblUso";
            this.lblUso.Size = new System.Drawing.Size(553, 28);
            this.lblUso.TabIndex = 0;
            this.lblUso.Text = "Cargando configuración...";
            this.lblUso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkVerSql
            // 
            this.chkVerSql.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkVerSql.Location = new System.Drawing.Point(561, 6);
            this.chkVerSql.Name = "chkVerSql";
            this.chkVerSql.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.chkVerSql.Size = new System.Drawing.Size(95, 28);
            this.chkVerSql.TabIndex = 1;
            this.chkVerSql.Text = "Ver SQL";
            this.chkVerSql.UseVisualStyleBackColor = true;
            this.chkVerSql.CheckedChanged += new System.EventHandler(this.chkVerSql_CheckedChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(656, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 28);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNueva.Location = new System.Drawing.Point(776, 6);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(160, 28);
            this.btnNueva.TabIndex = 3;
            this.btnNueva.Text = "Nueva conversación";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbConversacion);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvResultado);
            this.splitContainer1.Panel2.Controls.Add(this.txtSql);
            this.splitContainer1.Panel2.Controls.Add(this.lblResultado);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.splitContainer1.Size = new System.Drawing.Size(944, 497);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // rtbConversacion
            // 
            this.rtbConversacion.BackColor = System.Drawing.Color.White;
            this.rtbConversacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbConversacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConversacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbConversacion.Location = new System.Drawing.Point(8, 0);
            this.rtbConversacion.Name = "rtbConversacion";
            this.rtbConversacion.ReadOnly = true;
            this.rtbConversacion.Size = new System.Drawing.Size(928, 290);
            this.rtbConversacion.TabIndex = 0;
            this.rtbConversacion.TabStop = false;
            this.rtbConversacion.Text = "";
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvResultado.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultado.Location = new System.Drawing.Point(8, 24);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultado.Size = new System.Drawing.Size(928, 107);
            this.dgvResultado.TabIndex = 1;
            // 
            // txtSql
            // 
            this.txtSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSql.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtSql.Location = new System.Drawing.Point(8, 131);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ReadOnly = true;
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(928, 70);
            this.txtSql.TabIndex = 2;
            this.txtSql.TabStop = false;
            this.txtSql.Visible = false;
            this.txtSql.WordWrap = false;
            // 
            // lblResultado
            // 
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(8, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(928, 24);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "Datos de la última consulta";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.txtPregunta);
            this.pnlInferior.Controls.Add(this.pnlBotones);
            this.pnlInferior.Controls.Add(this.flpSugerencias);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 537);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
            this.pnlInferior.Size = new System.Drawing.Size(944, 112);
            this.pnlInferior.TabIndex = 2;
            // 
            // txtPregunta
            // 
            this.txtPregunta.AcceptsReturn = true;
            this.txtPregunta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPregunta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPregunta.Location = new System.Drawing.Point(8, 36);
            this.txtPregunta.MaxLength = 2000;
            this.txtPregunta.Multiline = true;
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPregunta.Size = new System.Drawing.Size(816, 68);
            this.txtPregunta.TabIndex = 0;
            this.txtPregunta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPregunta_KeyDown);
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnEnviar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotones.Location = new System.Drawing.Point(824, 36);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlBotones.Size = new System.Drawing.Size(112, 68);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCancelar.Location = new System.Drawing.Point(8, 36);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnEnviar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(8, 0);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(104, 36);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // flpSugerencias
            // 
            this.flpSugerencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpSugerencias.Location = new System.Drawing.Point(8, 4);
            this.flpSugerencias.Name = "flpSugerencias";
            this.flpSugerencias.Size = new System.Drawing.Size(928, 32);
            this.flpSugerencias.TabIndex = 2;
            this.flpSugerencias.WrapContents = false;
            // 
            // frmAsistenteIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 649);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmAsistenteIA";
            this.Text = "Asistente de Datos (IA)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAsistenteIA_FormClosing);
            this.Load += new System.EventHandler(this.frmAsistenteIA_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblUso;
        private System.Windows.Forms.CheckBox chkVerSql;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbConversacion;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.FlowLayoutPanel flpSugerencias;
    }
}
