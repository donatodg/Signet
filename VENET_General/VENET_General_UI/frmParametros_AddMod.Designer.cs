namespace VENET_General_UI
{
    partial class frmParametros_AddMod
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
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label valorLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.valorTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.parametrosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            nombreLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            valorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametrosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(32, 19);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 3;
            nombreLabel.Text = "Nombre:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(13, 45);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripción:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new System.Drawing.Point(45, 112);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(35, 13);
            valorLabel.TabIndex = 5;
            valorLabel.Text = "Valor:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(valorLabel);
            this.groupControl1.Controls.Add(this.valorTextEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(nombreLabel);
            this.groupControl1.Controls.Add(this.nombreTextEdit);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(404, 139);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
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
            this.btnAceptar.Glyph = global::VENET_General_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(428, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 179);
            this.barDockControlBottom.Size = new System.Drawing.Size(428, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 155);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(428, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 155);
            // 
            // valorTextEdit
            // 
            this.valorTextEdit.Location = new System.Drawing.Point(85, 109);
            this.valorTextEdit.MenuManager = this.barManager1;
            this.valorTextEdit.Name = "valorTextEdit";
            this.valorTextEdit.Size = new System.Drawing.Size(297, 20);
            this.valorTextEdit.TabIndex = 0;
            this.valorTextEdit.EditValueChanged += new System.EventHandler(this.valorTextEdit_EditValueChanged);
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.parametrosManagerBindingSource, "Parametro.Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(85, 16);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.nombreTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.nombreTextEdit.Properties.ReadOnly = true;
            this.nombreTextEdit.Size = new System.Drawing.Size(297, 20);
            this.nombreTextEdit.TabIndex = 1;
            this.nombreTextEdit.TabStop = false;
            // 
            // parametrosManagerBindingSource
            // 
            this.parametrosManagerBindingSource.DataSource = typeof(VENET_General_BL.ParametrosManager);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.parametrosManagerBindingSource, "Parametro.Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(85, 42);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.descripcionTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.descripcionTextEdit.Properties.ReadOnly = true;
            this.descripcionTextEdit.Size = new System.Drawing.Size(297, 61);
            this.descripcionTextEdit.TabIndex = 2;
            this.descripcionTextEdit.TabStop = false;
            // 
            // frmParametros_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 179);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(444, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 218);
            this.Name = "frmParametros_AddMod";
            this.Text = "Alta/Modificación de Parametros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParametros_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmParametros_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametrosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraEditors.TextEdit valorTextEdit;
        private System.Windows.Forms.BindingSource parametrosManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.MemoEdit descripcionTextEdit;
    }
}