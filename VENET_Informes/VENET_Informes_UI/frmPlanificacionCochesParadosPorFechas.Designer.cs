namespace VENET_Informes_UI
{
    partial class frmPlanificacionCochesParadosPorFechas
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
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
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_UnidadNegocioLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_UnidadNegocioLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_UnidadNegocioLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_UnidadNegocioLabel
            // 
            id_UnidadNegocioLabel.AutoSize = true;
            id_UnidadNegocioLabel.Location = new System.Drawing.Point(12, 11);
            id_UnidadNegocioLabel.Name = "id_UnidadNegocioLabel";
            id_UnidadNegocioLabel.Size = new System.Drawing.Size(85, 13);
            id_UnidadNegocioLabel.TabIndex = 1;
            id_UnidadNegocioLabel.Text = "Unidad Negocio:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(209, 11);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 3;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(394, 11);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(71, 13);
            fechaHastaLabel.TabIndex = 5;
            fechaHastaLabel.Text = "Fecha Hasta:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 377);
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
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
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
            this.panelControl1.Size = new System.Drawing.Size(734, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(471, 8);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 6;
            // 
            // planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource
            // 
            this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Informes_BL.PlanificacionCochesParadosPorFechasManager.ParametrosBusquedas);
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
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(288, 8);
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
            this.id_UnidadNegocioLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource, "Id_UnidadNegocio", true));
            this.id_UnidadNegocioLookUpEdit.Location = new System.Drawing.Point(103, 8);
            this.id_UnidadNegocioLookUpEdit.MenuManager = this.barManager1;
            this.id_UnidadNegocioLookUpEdit.Name = "id_UnidadNegocioLookUpEdit";
            this.id_UnidadNegocioLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_UnidadNegocioLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_UnidadNegocioLookUpEdit.Properties.NullText = "";
            this.id_UnidadNegocioLookUpEdit.Properties.ShowHeader = false;
            this.id_UnidadNegocioLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_UnidadNegocioLookUpEdit.TabIndex = 2;
            // 
            // frmPlanificacionCochesParadosPorFechas
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
            this.Name = "frmPlanificacionCochesParadosPorFechas";
            this.Text = "Reporte de Coches Sin Servicios por Fechas";
            this.Load += new System.EventHandler(this.frmPlanificacionCochesParadosPorFechas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_UnidadNegocioLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
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
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_UnidadNegocioLookUpEdit;
    }
}