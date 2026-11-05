namespace VENET_Produccion_UI
{
    partial class frmProduccionManoDeObra_AddMod
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
            System.Windows.Forms.Label descripcionCortaLabel;
            System.Windows.Forms.Label precioHoraLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.precioHoraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.produccionManoDeObraManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionCortaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            descripcionCortaLabel = new System.Windows.Forms.Label();
            precioHoraLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioHoraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManoDeObraManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(16, 11);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // descripcionCortaLabel
            // 
            descripcionCortaLabel.AutoSize = true;
            descripcionCortaLabel.Location = new System.Drawing.Point(13, 37);
            descripcionCortaLabel.Name = "descripcionCortaLabel";
            descripcionCortaLabel.Size = new System.Drawing.Size(68, 13);
            descripcionCortaLabel.TabIndex = 2;
            descripcionCortaLabel.Text = "Desc. Corta:";
            // 
            // precioHoraLabel
            // 
            precioHoraLabel.AutoSize = true;
            precioHoraLabel.Location = new System.Drawing.Point(15, 63);
            precioHoraLabel.Name = "precioHoraLabel";
            precioHoraLabel.Size = new System.Drawing.Size(66, 13);
            precioHoraLabel.TabIndex = 4;
            precioHoraLabel.Text = "Precio Hora:";
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
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Produccion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(343, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 130);
            this.barDockControlBottom.Size = new System.Drawing.Size(343, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 106);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(343, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 106);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(precioHoraLabel);
            this.groupControl1.Controls.Add(this.precioHoraTextEdit);
            this.groupControl1.Controls.Add(descripcionCortaLabel);
            this.groupControl1.Controls.Add(this.descripcionCortaTextEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(319, 92);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // precioHoraTextEdit
            // 
            this.precioHoraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManoDeObraManagerBindingSource, "ManoDeObra.PrecioHora", true));
            this.precioHoraTextEdit.Location = new System.Drawing.Point(87, 60);
            this.precioHoraTextEdit.MenuManager = this.barManager1;
            this.precioHoraTextEdit.Name = "precioHoraTextEdit";
            this.precioHoraTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.precioHoraTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.precioHoraTextEdit.Properties.EditFormat.FormatString = "n2";
            this.precioHoraTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.precioHoraTextEdit.Properties.Mask.EditMask = "n2";
            this.precioHoraTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.precioHoraTextEdit.Size = new System.Drawing.Size(100, 20);
            this.precioHoraTextEdit.TabIndex = 2;
            this.precioHoraTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.precioHoraTextEdit_KeyPress);
            // 
            // produccionManoDeObraManagerBindingSource
            // 
            this.produccionManoDeObraManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionManoDeObraManager);
            // 
            // descripcionCortaTextEdit
            // 
            this.descripcionCortaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManoDeObraManagerBindingSource, "ManoDeObra.DescripcionCorta", true));
            this.descripcionCortaTextEdit.EnterMoveNextControl = true;
            this.descripcionCortaTextEdit.Location = new System.Drawing.Point(87, 34);
            this.descripcionCortaTextEdit.MenuManager = this.barManager1;
            this.descripcionCortaTextEdit.Name = "descripcionCortaTextEdit";
            this.descripcionCortaTextEdit.Properties.MaxLength = 5;
            this.descripcionCortaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionCortaTextEdit.TabIndex = 1;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManoDeObraManagerBindingSource, "ManoDeObra.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(87, 8);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(215, 20);
            this.descripcionTextEdit.TabIndex = 0;
            // 
            // frmProduccionManoDeObra_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 130);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(359, 169);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(359, 169);
            this.Name = "frmProduccionManoDeObra_AddMod";
            this.Text = "Alta/Modificación Mano De Obra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionManoDeObra_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmManoDeObra_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioHoraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManoDeObraManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.TextEdit precioHoraTextEdit;
        private System.Windows.Forms.BindingSource produccionManoDeObraManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionCortaTextEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
    }
}