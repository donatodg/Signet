namespace VENET_General_UI
{
    partial class frmTalonariosComprobantesDetalle_AddMod
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
            System.Windows.Forms.Label nroActualLabel;
            System.Windows.Forms.Label nroDesdeLabel;
            System.Windows.Forms.Label nroHastaLabel;
            System.Windows.Forms.Label fechaVencimientoLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fechaVencimientoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.talonariosComprobantesDetalleManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.nroHastaSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.nroDesdeSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.nroActualSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            nroActualLabel = new System.Windows.Forms.Label();
            nroDesdeLabel = new System.Windows.Forms.Label();
            nroHastaLabel = new System.Windows.Forms.Label();
            fechaVencimientoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVencimientoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVencimientoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroHastaSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroDesdeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroActualSpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nroActualLabel
            // 
            nroActualLabel.AutoSize = true;
            nroActualLabel.Location = new System.Drawing.Point(41, 67);
            nroActualLabel.Name = "nroActualLabel";
            nroActualLabel.Size = new System.Drawing.Size(61, 13);
            nroActualLabel.TabIndex = 0;
            nroActualLabel.Text = "Nro Actual:";
            // 
            // nroDesdeLabel
            // 
            nroDesdeLabel.AutoSize = true;
            nroDesdeLabel.Location = new System.Drawing.Point(40, 15);
            nroDesdeLabel.Name = "nroDesdeLabel";
            nroDesdeLabel.Size = new System.Drawing.Size(61, 13);
            nroDesdeLabel.TabIndex = 2;
            nroDesdeLabel.Text = "Nro Desde:";
            // 
            // nroHastaLabel
            // 
            nroHastaLabel.AutoSize = true;
            nroHastaLabel.Location = new System.Drawing.Point(43, 41);
            nroHastaLabel.Name = "nroHastaLabel";
            nroHastaLabel.Size = new System.Drawing.Size(59, 13);
            nroHastaLabel.TabIndex = 4;
            nroHastaLabel.Text = "Nro Hasta:";
            // 
            // fechaVencimientoLabel
            // 
            fechaVencimientoLabel.AutoSize = true;
            fechaVencimientoLabel.Location = new System.Drawing.Point(33, 93);
            fechaVencimientoLabel.Name = "fechaVencimientoLabel";
            fechaVencimientoLabel.Size = new System.Drawing.Size(68, 13);
            fechaVencimientoLabel.TabIndex = 6;
            fechaVencimientoLabel.Text = "Vencimiento:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(fechaVencimientoLabel);
            this.groupControl1.Controls.Add(this.fechaVencimientoDateEdit);
            this.groupControl1.Controls.Add(nroHastaLabel);
            this.groupControl1.Controls.Add(this.nroHastaSpinEdit);
            this.groupControl1.Controls.Add(nroDesdeLabel);
            this.groupControl1.Controls.Add(this.nroDesdeSpinEdit);
            this.groupControl1.Controls.Add(nroActualLabel);
            this.groupControl1.Controls.Add(this.nroActualSpinEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(256, 128);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // fechaVencimientoDateEdit
            // 
            this.fechaVencimientoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesDetalleManagerBindingSource, "TalonarioDetalle.FechaVencimiento", true));
            this.fechaVencimientoDateEdit.EditValue = null;
            this.fechaVencimientoDateEdit.Location = new System.Drawing.Point(107, 90);
            this.fechaVencimientoDateEdit.MenuManager = this.barManager1;
            this.fechaVencimientoDateEdit.Name = "fechaVencimientoDateEdit";
            this.fechaVencimientoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaVencimientoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaVencimientoDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaVencimientoDateEdit.TabIndex = 3;
            // 
            // talonariosComprobantesDetalleManagerBindingSource
            // 
            this.talonariosComprobantesDetalleManagerBindingSource.DataSource = typeof(VENET_General_BL.TalonariosComprobantesDetalleManager);
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
            this.barDockControlTop.Size = new System.Drawing.Size(280, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 168);
            this.barDockControlBottom.Size = new System.Drawing.Size(280, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 144);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(280, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 144);
            // 
            // nroHastaSpinEdit
            // 
            this.nroHastaSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesDetalleManagerBindingSource, "TalonarioDetalle.NroHasta", true));
            this.nroHastaSpinEdit.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nroHastaSpinEdit.Location = new System.Drawing.Point(107, 38);
            this.nroHastaSpinEdit.MenuManager = this.barManager1;
            this.nroHastaSpinEdit.Name = "nroHastaSpinEdit";
            this.nroHastaSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nroHastaSpinEdit.Properties.MaxLength = 9;
            this.nroHastaSpinEdit.Properties.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nroHastaSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nroHastaSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.nroHastaSpinEdit.TabIndex = 1;
            // 
            // nroDesdeSpinEdit
            // 
            this.nroDesdeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesDetalleManagerBindingSource, "TalonarioDetalle.NroDesde", true));
            this.nroDesdeSpinEdit.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nroDesdeSpinEdit.Location = new System.Drawing.Point(107, 12);
            this.nroDesdeSpinEdit.MenuManager = this.barManager1;
            this.nroDesdeSpinEdit.Name = "nroDesdeSpinEdit";
            this.nroDesdeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nroDesdeSpinEdit.Properties.MaxLength = 8;
            this.nroDesdeSpinEdit.Properties.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nroDesdeSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nroDesdeSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.nroDesdeSpinEdit.TabIndex = 0;
            // 
            // nroActualSpinEdit
            // 
            this.nroActualSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesDetalleManagerBindingSource, "TalonarioDetalle.NroActual", true));
            this.nroActualSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nroActualSpinEdit.Location = new System.Drawing.Point(107, 64);
            this.nroActualSpinEdit.MenuManager = this.barManager1;
            this.nroActualSpinEdit.Name = "nroActualSpinEdit";
            this.nroActualSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nroActualSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nroActualSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.nroActualSpinEdit.TabIndex = 2;
            // 
            // frmTalonariosComprobantesDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 168);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 207);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 207);
            this.Name = "frmTalonariosComprobantesDetalle_AddMod";
            this.Text = "Alta/Modificación de Talonarios";
            this.Load += new System.EventHandler(this.frmTalonariosComprobantesDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVencimientoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVencimientoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroHastaSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroDesdeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroActualSpinEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit fechaVencimientoDateEdit;
        private System.Windows.Forms.BindingSource talonariosComprobantesDetalleManagerBindingSource;
        private DevExpress.XtraEditors.SpinEdit nroHastaSpinEdit;
        private DevExpress.XtraEditors.SpinEdit nroDesdeSpinEdit;
        private DevExpress.XtraEditors.SpinEdit nroActualSpinEdit;
    }
}