namespace VENET_Personal_UI
{
    partial class frmPersonalNovedadesAddMod
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
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label id_TipoNovedadLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label idPersonalLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.idPersonalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.personalNovedadesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.observacionesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoNovedadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            fechaLabel = new System.Windows.Forms.Label();
            id_TipoNovedadLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            idPersonalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPersonalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalNovedadesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoNovedadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(31, 17);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(73, 13);
            fechaLabel.TabIndex = 0;
            fechaLabel.Text = "Fecha Desde:";
            // 
            // id_TipoNovedadLabel
            // 
            id_TipoNovedadLabel.AutoSize = true;
            id_TipoNovedadLabel.Location = new System.Drawing.Point(25, 69);
            id_TipoNovedadLabel.Name = "id_TipoNovedadLabel";
            id_TipoNovedadLabel.Size = new System.Drawing.Size(77, 13);
            id_TipoNovedadLabel.TabIndex = 5;
            id_TipoNovedadLabel.Text = "Tipo Novedad:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(22, 95);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 7;
            observacionesLabel.Text = "Observaciones:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(215, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 10;
            label1.Text = "Hasta:";
            // 
            // idPersonalLabel
            // 
            idPersonalLabel.AutoSize = true;
            idPersonalLabel.Location = new System.Drawing.Point(50, 43);
            idPersonalLabel.Name = "idPersonalLabel";
            idPersonalLabel.Size = new System.Drawing.Size(52, 13);
            idPersonalLabel.TabIndex = 11;
            idPersonalLabel.Text = "Personal:";
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
            this.btnAceptar.Glyph = global::VENET_Personal_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(596, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 171);
            this.barDockControlBottom.Size = new System.Drawing.Size(596, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 147);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(596, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 147);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(idPersonalLabel);
            this.groupControl1.Controls.Add(this.idPersonalLookUpEdit);
            this.groupControl1.Controls.Add(label1);
            this.groupControl1.Controls.Add(this.fechaHastaDateEdit);
            this.groupControl1.Controls.Add(observacionesLabel);
            this.groupControl1.Controls.Add(this.observacionesTextEdit);
            this.groupControl1.Controls.Add(id_TipoNovedadLabel);
            this.groupControl1.Controls.Add(this.id_TipoNovedadLookUpEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(572, 132);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // idPersonalLookUpEdit
            // 
            this.idPersonalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalNovedadesManagerBindingSource, "Novedad.Id_Personal", true));
            this.idPersonalLookUpEdit.EnterMoveNextControl = true;
            this.idPersonalLookUpEdit.Location = new System.Drawing.Point(109, 40);
            this.idPersonalLookUpEdit.MenuManager = this.barManager1;
            this.idPersonalLookUpEdit.Name = "idPersonalLookUpEdit";
            this.idPersonalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idPersonalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Legajo", "Legajo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.idPersonalLookUpEdit.Properties.DisplayMember = "Name";
            this.idPersonalLookUpEdit.Properties.NullText = "";
            this.idPersonalLookUpEdit.Properties.ValueMember = "Key";
            this.idPersonalLookUpEdit.Size = new System.Drawing.Size(441, 20);
            this.idPersonalLookUpEdit.TabIndex = 2;
            // 
            // personalNovedadesManagerBindingSource
            // 
            this.personalNovedadesManagerBindingSource.DataSource = typeof(VENET_Personal_BL.PersonalNovedadesManager);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.EnterMoveNextControl = true;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(260, 14);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 1;
            // 
            // observacionesTextEdit
            // 
            this.observacionesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalNovedadesManagerBindingSource, "Novedad.Observaciones", true));
            this.observacionesTextEdit.EnterMoveNextControl = true;
            this.observacionesTextEdit.Location = new System.Drawing.Point(109, 92);
            this.observacionesTextEdit.MenuManager = this.barManager1;
            this.observacionesTextEdit.Name = "observacionesTextEdit";
            this.observacionesTextEdit.Size = new System.Drawing.Size(441, 20);
            this.observacionesTextEdit.TabIndex = 4;
            this.observacionesTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_TipoNovedadLookUpEdit
            // 
            this.id_TipoNovedadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalNovedadesManagerBindingSource, "Novedad.Id_TipoNovedad", true));
            this.id_TipoNovedadLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoNovedadLookUpEdit.Location = new System.Drawing.Point(109, 66);
            this.id_TipoNovedadLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoNovedadLookUpEdit.Name = "id_TipoNovedadLookUpEdit";
            this.id_TipoNovedadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoNovedadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_TipoNovedadLookUpEdit.Properties.NullText = "";
            this.id_TipoNovedadLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoNovedadLookUpEdit.Size = new System.Drawing.Size(202, 20);
            this.id_TipoNovedadLookUpEdit.TabIndex = 3;
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalNovedadesManagerBindingSource, "Novedad.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(109, 14);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // frmPersonalNovedadesAddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(596, 171);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(612, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 210);
            this.Name = "frmPersonalNovedadesAddMod";

            this.Text = "Alta/Modificación de Novedades de Personal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPersonalNovedadesAddMod_FormClosed);
            this.Load += new System.EventHandler(this.frmPersonalNovedadesAddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPersonalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalNovedadesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoNovedadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit observacionesTextEdit;
        private System.Windows.Forms.BindingSource personalNovedadesManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_TipoNovedadLookUpEdit;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private DevExpress.XtraEditors.LookUpEdit idPersonalLookUpEdit;
    }
}