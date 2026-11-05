namespace VENET_Informes_UI
{
    partial class frmReporteCochesComparativo
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
            System.Windows.Forms.Label id_UnidadNegocioLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_UnidadNegocioLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnTaller = new System.Windows.Forms.Button();
            this.btnEjecutados = new System.Windows.Forms.Button();
            this.btnParados = new System.Windows.Forms.Button();
            this.btnPlanificados = new System.Windows.Forms.Button();
            this.btnFlota = new System.Windows.Forms.Button();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTitulo = new DevExpress.XtraEditors.LabelControl();
            id_UnidadNegocioLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_UnidadNegocioLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_UnidadNegocioLabel
            // 
            id_UnidadNegocioLabel.AutoSize = true;
            id_UnidadNegocioLabel.Location = new System.Drawing.Point(12, 10);
            id_UnidadNegocioLabel.Name = "id_UnidadNegocioLabel";
            id_UnidadNegocioLabel.Size = new System.Drawing.Size(85, 13);
            id_UnidadNegocioLabel.TabIndex = 1;
            id_UnidadNegocioLabel.Text = "Unidad Negocio:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(287, 10);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 3;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(472, 10);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(71, 13);
            fechaHastaLabel.TabIndex = 5;
            fechaHastaLabel.Text = "Fecha Hasta:";
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
            this.barSubItem1,
            this.btnResultado});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Informes_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 1;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(734, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(id_UnidadNegocioLabel);
            this.panelControl1.Controls.Add(this.id_UnidadNegocioLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 5;
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(544, 7);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 6;
            // 
            // reporteCochesComparativoManager_ParametrosBusquedasBindingSource
            // 
            this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Informes_BL.ReporteCochesComparativoManager.ParametrosBusquedas);
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(362, 7);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 4;
            // 
            // id_UnidadNegocioLookUpEdit
            // 
            this.id_UnidadNegocioLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource, "Id_UnidadNegocio", true));
            this.id_UnidadNegocioLookUpEdit.Location = new System.Drawing.Point(98, 7);
            this.id_UnidadNegocioLookUpEdit.MenuManager = this.barManager1;
            this.id_UnidadNegocioLookUpEdit.Name = "id_UnidadNegocioLookUpEdit";
            this.id_UnidadNegocioLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_UnidadNegocioLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_UnidadNegocioLookUpEdit.Properties.NullText = "";
            this.id_UnidadNegocioLookUpEdit.Properties.ShowHeader = false;
            this.id_UnidadNegocioLookUpEdit.Size = new System.Drawing.Size(183, 20);
            this.id_UnidadNegocioLookUpEdit.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnTaller);
            this.panelControl2.Controls.Add(this.btnEjecutados);
            this.panelControl2.Controls.Add(this.btnParados);
            this.panelControl2.Controls.Add(this.btnPlanificados);
            this.panelControl2.Controls.Add(this.btnFlota);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 57);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(194, 404);
            this.panelControl2.TabIndex = 6;
            // 
            // btnTaller
            // 
            this.btnTaller.BackColor = System.Drawing.Color.White;
            this.btnTaller.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaller.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnTaller.ForeColor = System.Drawing.Color.Black;
            this.btnTaller.Location = new System.Drawing.Point(12, 312);
            this.btnTaller.Name = "btnTaller";
            this.btnTaller.Size = new System.Drawing.Size(170, 70);
            this.btnTaller.TabIndex = 4;
            this.btnTaller.Text = "Taller\r\n";
            this.btnTaller.UseVisualStyleBackColor = false;
            this.btnTaller.Click += new System.EventHandler(this.btnTaller_Click);
            // 
            // btnEjecutados
            // 
            this.btnEjecutados.BackColor = System.Drawing.Color.White;
            this.btnEjecutados.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnEjecutados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutados.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnEjecutados.ForeColor = System.Drawing.Color.Black;
            this.btnEjecutados.Location = new System.Drawing.Point(12, 236);
            this.btnEjecutados.Name = "btnEjecutados";
            this.btnEjecutados.Size = new System.Drawing.Size(170, 70);
            this.btnEjecutados.TabIndex = 3;
            this.btnEjecutados.Text = "Ejecutados\r\n";
            this.btnEjecutados.UseVisualStyleBackColor = false;
            this.btnEjecutados.Click += new System.EventHandler(this.btnEjecutados_Click);
            // 
            // btnParados
            // 
            this.btnParados.BackColor = System.Drawing.Color.White;
            this.btnParados.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnParados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParados.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnParados.ForeColor = System.Drawing.Color.Black;
            this.btnParados.Location = new System.Drawing.Point(12, 160);
            this.btnParados.Name = "btnParados";
            this.btnParados.Size = new System.Drawing.Size(170, 70);
            this.btnParados.TabIndex = 2;
            this.btnParados.Text = "Parados\r\n";
            this.btnParados.UseVisualStyleBackColor = false;
            this.btnParados.Click += new System.EventHandler(this.btnParados_Click);
            // 
            // btnPlanificados
            // 
            this.btnPlanificados.BackColor = System.Drawing.Color.White;
            this.btnPlanificados.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlanificados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanificados.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnPlanificados.ForeColor = System.Drawing.Color.Black;
            this.btnPlanificados.Location = new System.Drawing.Point(12, 84);
            this.btnPlanificados.Name = "btnPlanificados";
            this.btnPlanificados.Size = new System.Drawing.Size(170, 70);
            this.btnPlanificados.TabIndex = 1;
            this.btnPlanificados.Text = "Planificados\r\n";
            this.btnPlanificados.UseVisualStyleBackColor = false;
            this.btnPlanificados.Click += new System.EventHandler(this.btnPlanificados_Click);
            // 
            // btnFlota
            // 
            this.btnFlota.BackColor = System.Drawing.Color.MediumBlue;
            this.btnFlota.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnFlota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlota.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnFlota.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFlota.Location = new System.Drawing.Point(12, 8);
            this.btnFlota.Name = "btnFlota";
            this.btnFlota.Size = new System.Drawing.Size(170, 70);
            this.btnFlota.TabIndex = 0;
            this.btnFlota.Text = "Flota\r\n";
            this.btnFlota.UseVisualStyleBackColor = false;
            this.btnFlota.Click += new System.EventHandler(this.btnFlota_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Controls.Add(this.lblTitulo);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(194, 57);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(540, 404);
            this.panelControl3.TabIndex = 7;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(540, 366);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Underline);
            this.lblTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitulo.Location = new System.Drawing.Point(6, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(529, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Flota Total";
            // 
            // frmReporteCochesComparativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmReporteCochesComparativo";
            this.Text = "Reporte de Coches Comparativo";
            this.Load += new System.EventHandler(this.frmReporteCochesComparativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteCochesComparativoManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_UnidadNegocioLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnTaller;
        private System.Windows.Forms.Button btnEjecutados;
        private System.Windows.Forms.Button btnParados;
        private System.Windows.Forms.Button btnPlanificados;
        private System.Windows.Forms.Button btnFlota;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource reporteCochesComparativoManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_UnidadNegocioLookUpEdit;
    }
}