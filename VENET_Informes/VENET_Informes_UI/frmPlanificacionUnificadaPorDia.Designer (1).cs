namespace VENET_Informes_UI
{
    partial class frmPlanificacionUnificadaPorDia
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
            System.Windows.Forms.Label fechaLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.planificacionUnificadaPorDiaManager_ReporteBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadNegocio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadNegocio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoraInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMediasVueltas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            fechaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionUnificadaPorDiaManager_ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(16, 9);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 0;
            fechaLabel.Text = "Fecha:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.planificacionUnificadaPorDiaManager_ReporteBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 379);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // planificacionUnificadaPorDiaManager_ReporteBindingSource
            // 
            this.planificacionUnificadaPorDiaManager_ReporteBindingSource.DataSource = typeof(VENET_Informes_BL.PlanificacionUnificadaPorDiaManager.Reporte);
            this.planificacionUnificadaPorDiaManager_ReporteBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.planificacionUnificadaPorDiaManager_ReporteBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colId_UnidadNegocio,
            this.colUnidadNegocio,
            this.colEmpresa,
            this.colLinea,
            this.colServicio,
            this.colTurno,
            this.colInicio,
            this.colDestino,
            this.colInterno,
            this.colLegajo,
            this.colPersonal,
            this.colHoraInicio,
            this.colHoraFin,
            this.colMediasVueltas});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUnidadNegocio, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colId_UnidadNegocio
            // 
            this.colId_UnidadNegocio.FieldName = "Id_UnidadNegocio";
            this.colId_UnidadNegocio.Name = "colId_UnidadNegocio";
            // 
            // colUnidadNegocio
            // 
            this.colUnidadNegocio.FieldName = "UnidadNegocio";
            this.colUnidadNegocio.Name = "colUnidadNegocio";
            this.colUnidadNegocio.Visible = true;
            this.colUnidadNegocio.VisibleIndex = 0;
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            // 
            // colLinea
            // 
            this.colLinea.FieldName = "Linea";
            this.colLinea.Name = "colLinea";
            this.colLinea.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Linea", "{0}")});
            this.colLinea.Visible = true;
            this.colLinea.VisibleIndex = 0;
            this.colLinea.Width = 82;
            // 
            // colServicio
            // 
            this.colServicio.FieldName = "Servicio";
            this.colServicio.Name = "colServicio";
            this.colServicio.Visible = true;
            this.colServicio.VisibleIndex = 1;
            this.colServicio.Width = 52;
            // 
            // colTurno
            // 
            this.colTurno.FieldName = "Turno";
            this.colTurno.Name = "colTurno";
            this.colTurno.Visible = true;
            this.colTurno.VisibleIndex = 2;
            this.colTurno.Width = 53;
            // 
            // colInicio
            // 
            this.colInicio.FieldName = "Inicio";
            this.colInicio.Name = "colInicio";
            this.colInicio.Visible = true;
            this.colInicio.VisibleIndex = 3;
            this.colInicio.Width = 87;
            // 
            // colDestino
            // 
            this.colDestino.FieldName = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.Visible = true;
            this.colDestino.VisibleIndex = 4;
            this.colDestino.Width = 87;
            // 
            // colInterno
            // 
            this.colInterno.FieldName = "Interno";
            this.colInterno.Name = "colInterno";
            this.colInterno.Visible = true;
            this.colInterno.VisibleIndex = 5;
            this.colInterno.Width = 50;
            // 
            // colLegajo
            // 
            this.colLegajo.FieldName = "Legajo";
            this.colLegajo.Name = "colLegajo";
            this.colLegajo.Visible = true;
            this.colLegajo.VisibleIndex = 6;
            this.colLegajo.Width = 93;
            // 
            // colPersonal
            // 
            this.colPersonal.FieldName = "Personal";
            this.colPersonal.Name = "colPersonal";
            this.colPersonal.Visible = true;
            this.colPersonal.VisibleIndex = 7;
            this.colPersonal.Width = 205;
            // 
            // colHoraInicio
            // 
            this.colHoraInicio.DisplayFormat.FormatString = "HH:mm";
            this.colHoraInicio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHoraInicio.FieldName = "HoraInicio";
            this.colHoraInicio.Name = "colHoraInicio";
            this.colHoraInicio.Visible = true;
            this.colHoraInicio.VisibleIndex = 8;
            this.colHoraInicio.Width = 120;
            // 
            // colHoraFin
            // 
            this.colHoraFin.DisplayFormat.FormatString = "HH:mm";
            this.colHoraFin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHoraFin.FieldName = "HoraFin";
            this.colHoraFin.Name = "colHoraFin";
            this.colHoraFin.Visible = true;
            this.colHoraFin.VisibleIndex = 9;
            this.colHoraFin.Width = 120;
            // 
            // colMediasVueltas
            // 
            this.colMediasVueltas.FieldName = "MediasVueltas";
            this.colMediasVueltas.Name = "colMediasVueltas";
            this.colMediasVueltas.Visible = true;
            this.colMediasVueltas.VisibleIndex = 10;
            this.colMediasVueltas.Width = 129;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.btnResultado,
            this.barStaticItemFooter});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
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
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFooter)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItemFooter
            // 
            this.barStaticItemFooter.Id = 2;
            this.barStaticItemFooter.Name = "barStaticItemFooter";
            this.barStaticItemFooter.TextAlignment = System.Drawing.StringAlignment.Near;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 436);
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 412);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 412);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fechaLabel);
            this.panelControl1.Controls.Add(this.fechaDateEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource, "Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.Location = new System.Drawing.Point(62, 6);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 1;
            // 
            // planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource
            // 
            this.planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Informes_BL.PlanificacionUnificadaPorDiaManager.ParametrosBusquedas);
            // 
            // frmPlanificacionUnificadaPorDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(382, 281);
            this.Name = "frmPlanificacionUnificadaPorDia";
            this.Text = "Reporte de Planificación Unificada Por Día";
            this.Load += new System.EventHandler(this.frmPlanificacionUnificadaPorDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionUnificadaPorDiaManager_ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private System.Windows.Forms.BindingSource planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadNegocio;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadNegocio;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colServicio;
        private DevExpress.XtraGrid.Columns.GridColumn colTurno;
        private DevExpress.XtraGrid.Columns.GridColumn colInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colInterno;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajo;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonal;
        private DevExpress.XtraGrid.Columns.GridColumn colHoraInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colHoraFin;
        private DevExpress.XtraGrid.Columns.GridColumn colMediasVueltas;
        private System.Windows.Forms.BindingSource planificacionUnificadaPorDiaManager_ReporteBindingSource;
    }
}