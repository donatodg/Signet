namespace VENET_Tesoreria_UI
{
    partial class frmReciboDetallePercep_AddMod
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
            System.Windows.Forms.Label detalleLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label idEspecieLabel;
            System.Windows.Forms.Label id_TipoPercepcionLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_TipoPercepcionLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.reciboDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.idEspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.especiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            detalleLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            idEspecieLabel = new System.Windows.Forms.Label();
            id_TipoPercepcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoPercepcionLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // detalleLabel
            // 
            detalleLabel.AutoSize = true;
            detalleLabel.Location = new System.Drawing.Point(34, 89);
            detalleLabel.Name = "detalleLabel";
            detalleLabel.Size = new System.Drawing.Size(44, 13);
            detalleLabel.TabIndex = 6;
            detalleLabel.Text = "Detalle:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(29, 63);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 4;
            importeLabel.Text = "Importe:";
            // 
            // idEspecieLabel
            // 
            idEspecieLabel.AutoSize = true;
            idEspecieLabel.Location = new System.Drawing.Point(31, 37);
            idEspecieLabel.Name = "idEspecieLabel";
            idEspecieLabel.Size = new System.Drawing.Size(47, 13);
            idEspecieLabel.TabIndex = 2;
            idEspecieLabel.Text = "Especie:";
            // 
            // id_TipoPercepcionLabel
            // 
            id_TipoPercepcionLabel.AutoSize = true;
            id_TipoPercepcionLabel.Location = new System.Drawing.Point(15, 11);
            id_TipoPercepcionLabel.Name = "id_TipoPercepcionLabel";
            id_TipoPercepcionLabel.Size = new System.Drawing.Size(63, 13);
            id_TipoPercepcionLabel.TabIndex = 9;
            id_TipoPercepcionLabel.Text = "Percepción:";
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
            this.barManager1.MaxItemId = 2;
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
            this.btnAceptar.Id = 1;
            this.btnAceptar.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(401, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 158);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(401, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 134);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(401, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 134);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_TipoPercepcionLabel);
            this.groupControl1.Controls.Add(this.id_TipoPercepcionLookUpEdit);
            this.groupControl1.Controls.Add(detalleLabel);
            this.groupControl1.Controls.Add(this.detalleTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Controls.Add(idEspecieLabel);
            this.groupControl1.Controls.Add(this.idEspecieLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(377, 121);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_TipoPercepcionLookUpEdit
            // 
            this.id_TipoPercepcionLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "ReciboDetalle.Id_TipoPercepcion", true));
            this.id_TipoPercepcionLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoPercepcionLookUpEdit.Location = new System.Drawing.Point(84, 8);
            this.id_TipoPercepcionLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoPercepcionLookUpEdit.Name = "id_TipoPercepcionLookUpEdit";
            this.id_TipoPercepcionLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoPercepcionLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_TipoPercepcionLookUpEdit.Properties.NullText = "";
            this.id_TipoPercepcionLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoPercepcionLookUpEdit.Size = new System.Drawing.Size(153, 20);
            this.id_TipoPercepcionLookUpEdit.TabIndex = 0;
            // 
            // reciboDetalleManagerBindingSource
            // 
            this.reciboDetalleManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ReciboDetalleManager);
            // 
            // detalleTextEdit
            // 
            this.detalleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "ReciboDetalle.Detalle", true));
            this.detalleTextEdit.EnterMoveNextControl = true;
            this.detalleTextEdit.Location = new System.Drawing.Point(84, 86);
            this.detalleTextEdit.MenuManager = this.barManager1;
            this.detalleTextEdit.Name = "detalleTextEdit";
            this.detalleTextEdit.Size = new System.Drawing.Size(278, 20);
            this.detalleTextEdit.TabIndex = 3;
            this.detalleTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.detalleTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detalleTextEdit_KeyPress);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "ReciboDetalle.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(84, 60);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.importeTextEdit.Properties.MaskSettings.Set("mask", "n");
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 2;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // idEspecieLookUpEdit
            // 
            this.idEspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "IdEspecie", true));
            this.idEspecieLookUpEdit.EnterMoveNextControl = true;
            this.idEspecieLookUpEdit.Location = new System.Drawing.Point(84, 34);
            this.idEspecieLookUpEdit.MenuManager = this.barManager1;
            this.idEspecieLookUpEdit.Name = "idEspecieLookUpEdit";
            this.idEspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idEspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.idEspecieLookUpEdit.Properties.NullText = "";
            this.idEspecieLookUpEdit.Properties.ShowHeader = false;
            this.idEspecieLookUpEdit.Size = new System.Drawing.Size(153, 20);
            this.idEspecieLookUpEdit.TabIndex = 1;
            // 
            // especiesBindingSource
            // 
            this.especiesBindingSource.DataMember = "Especies";
            this.especiesBindingSource.DataSource = this.reciboDetalleManagerBindingSource;
            // 
            // frmReciboDetallePercep_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(401, 158);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(403, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(403, 190);
            this.Name = "frmReciboDetallePercep_AddMod";
            this.Text = "Alta/Modificación de Detalle";
            this.Load += new System.EventHandler(this.frmReciboDetallePF_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoPercepcionLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraEditors.TextEdit detalleTextEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit idEspecieLookUpEdit;
        private System.Windows.Forms.BindingSource reciboDetalleManagerBindingSource;
        private System.Windows.Forms.BindingSource especiesBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_TipoPercepcionLookUpEdit;
    }
}