namespace VENET_Seguridad_UI
{
    partial class frmSeguridadGrupos_AddMod
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label esAdministradorLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.esAdministradorCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.seguridadGruposManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            esAdministradorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.esAdministradorCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadGruposManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(36, 16);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // esAdministradorLabel
            // 
            esAdministradorLabel.AutoSize = true;
            esAdministradorLabel.Location = new System.Drawing.Point(15, 42);
            esAdministradorLabel.Name = "esAdministradorLabel";
            esAdministradorLabel.Size = new System.Drawing.Size(91, 13);
            esAdministradorLabel.TabIndex = 2;
            esAdministradorLabel.Text = "Es Administrador:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(367, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 110);
            this.barDockControlBottom.Size = new System.Drawing.Size(367, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 86);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(367, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 86);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(esAdministradorLabel);
            this.groupControl1.Controls.Add(this.esAdministradorCheckEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(343, 70);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // esAdministradorCheckEdit
            // 
            this.esAdministradorCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadGruposManagerBindingSource, "Grupo.EsAdministrador", true));
            this.esAdministradorCheckEdit.EnterMoveNextControl = true;
            this.esAdministradorCheckEdit.Location = new System.Drawing.Point(109, 39);
            this.esAdministradorCheckEdit.MenuManager = this.barManager1;
            this.esAdministradorCheckEdit.Name = "esAdministradorCheckEdit";
            this.esAdministradorCheckEdit.Properties.Caption = "";
            this.esAdministradorCheckEdit.Size = new System.Drawing.Size(24, 19);
            this.esAdministradorCheckEdit.TabIndex = 3;
            // 
            // seguridadGruposManagerBindingSource
            // 
            this.seguridadGruposManagerBindingSource.DataSource = typeof(VENET_Seguridad_BL.SeguridadGruposManager);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadGruposManagerBindingSource, "Grupo.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(108, 13);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(221, 20);
            this.descripcionTextEdit.TabIndex = 1;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmSeguridadGrupos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 110);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(383, 149);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(383, 149);
            this.Name = "frmSeguridadGrupos_AddMod";
            this.Text = "Alta/Modificación de Grupos de Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeguridadGrupos_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmSeguridadGrupos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.esAdministradorCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadGruposManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit esAdministradorCheckEdit;
        private System.Windows.Forms.BindingSource seguridadGruposManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
    }
}