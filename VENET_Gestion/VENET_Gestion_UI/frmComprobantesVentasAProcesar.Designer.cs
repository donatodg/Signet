namespace VENET_Gestion_UI
{
    partial class frmComprobantesVentasAProcesar
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
            System.Windows.Forms.Label tipoEntidadLabel;
            System.Windows.Forms.Label pendientesLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnProcesarPendientes = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerar = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pendientesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.comprobantesVentasAProcesarManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteIVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobanteVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            tipoEntidadLabel = new System.Windows.Forms.Label();
            pendientesLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendientesCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasAProcesarManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoEntidadLabel
            // 
            tipoEntidadLabel.AutoSize = true;
            tipoEntidadLabel.Location = new System.Drawing.Point(13, 9);
            tipoEntidadLabel.Name = "tipoEntidadLabel";
            tipoEntidadLabel.Size = new System.Drawing.Size(70, 13);
            tipoEntidadLabel.TabIndex = 0;
            tipoEntidadLabel.Text = "Tipo Entidad:";
            // 
            // pendientesLabel
            // 
            pendientesLabel.AutoSize = true;
            pendientesLabel.Location = new System.Drawing.Point(256, 9);
            pendientesLabel.Name = "pendientesLabel";
            pendientesLabel.Size = new System.Drawing.Size(64, 13);
            pendientesLabel.TabIndex = 2;
            pendientesLabel.Text = "Pendientes:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(356, 9);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 5;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(pendientesLabel);
            this.panelControl1.Controls.Add(this.pendientesCheckEdit);
            this.panelControl1.Controls.Add(tipoEntidadLabel);
            this.panelControl1.Controls.Add(this.tipoEntidadLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(435, 6);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 6;
            // 
            // comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource
            // 
            this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesVentasAProcesarManager.ParametrosBusquedas);
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
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.btnResultado,
            this.barSubItem2,
            this.btnProcesarPendientes,
            this.barStaticItemFooter,
            this.btnGenerar,
            this.btnImportar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Gestion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Gestion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Gestion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 4;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 5;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProcesarPendientes),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerar)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnProcesarPendientes
            // 
            this.btnProcesarPendientes.Caption = "Procesar Pendientes";
            this.btnProcesarPendientes.Id = 6;
            this.btnProcesarPendientes.Name = "btnProcesarPendientes";
            this.btnProcesarPendientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcesarPendientes_ItemClick);
            // 
            // btnImportar
            // 
            this.btnImportar.Caption = "Importar Excel";
            this.btnImportar.Id = 9;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportar_ItemClick);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Caption = "Generar Excel Modelo";
            this.btnGenerar.Id = 8;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerar_ItemClick);
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
            this.barStaticItemFooter.Id = 7;
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
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pendientesCheckEdit
            // 
            this.pendientesCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource, "Pendientes", true));
            this.pendientesCheckEdit.Location = new System.Drawing.Point(326, 6);
            this.pendientesCheckEdit.MenuManager = this.barManager1;
            this.pendientesCheckEdit.Name = "pendientesCheckEdit";
            this.pendientesCheckEdit.Properties.Caption = "";
            this.pendientesCheckEdit.Size = new System.Drawing.Size(24, 19);
            this.pendientesCheckEdit.TabIndex = 3;
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource, "TipoEntidad", true));
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(89, 6);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name1")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(161, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.comprobantesVentasAProcesarManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 380);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // comprobantesVentasAProcesarManager_SearchResultBindingSource
            // 
            this.comprobantesVentasAProcesarManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesVentasAProcesarManager.SearchResult);
            this.comprobantesVentasAProcesarManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.comprobantesVentasAProcesarManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre_Entidad,
            this.colId_TipoEntidad,
            this.colId_Entidad,
            this.colFecha,
            this.colId_Producto,
            this.colDescripcion,
            this.colCantidad,
            this.colId_Especie,
            this.colImporteCosto,
            this.colImporteUnitario,
            this.colPorcDescuento,
            this.colId_AlicuotaIva,
            this.colAlicuotaIva,
            this.colImporteIVA,
            this.colImporte,
            this.colId_ComprobanteVenta,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[Id_ComprobanteVenta] = ?";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colNombre_Entidad
            // 
            this.colNombre_Entidad.Caption = "Entidad";
            this.colNombre_Entidad.FieldName = "Nombre_Entidad";
            this.colNombre_Entidad.Name = "colNombre_Entidad";
            this.colNombre_Entidad.Visible = true;
            this.colNombre_Entidad.VisibleIndex = 2;
            this.colNombre_Entidad.Width = 80;
            // 
            // colId_TipoEntidad
            // 
            this.colId_TipoEntidad.Caption = "Tipo Entidad";
            this.colId_TipoEntidad.FieldName = "Id_TipoEntidad";
            this.colId_TipoEntidad.Name = "colId_TipoEntidad";
            this.colId_TipoEntidad.Visible = true;
            this.colId_TipoEntidad.VisibleIndex = 1;
            this.colId_TipoEntidad.Width = 80;
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "{0}")});
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 69;
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            this.colDescripcion.Width = 80;
            // 
            // colCantidad
            // 
            this.colCantidad.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 4;
            this.colCantidad.Width = 80;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            // 
            // colImporteUnitario
            // 
            this.colImporteUnitario.FieldName = "ImporteUnitario";
            this.colImporteUnitario.Name = "colImporteUnitario";
            this.colImporteUnitario.Visible = true;
            this.colImporteUnitario.VisibleIndex = 5;
            this.colImporteUnitario.Width = 80;
            // 
            // colPorcDescuento
            // 
            this.colPorcDescuento.FieldName = "PorcDescuento";
            this.colPorcDescuento.Name = "colPorcDescuento";
            // 
            // colId_AlicuotaIva
            // 
            this.colId_AlicuotaIva.FieldName = "Id_AlicuotaIva";
            this.colId_AlicuotaIva.Name = "colId_AlicuotaIva";
            // 
            // colAlicuotaIva
            // 
            this.colAlicuotaIva.FieldName = "AlicuotaIva";
            this.colAlicuotaIva.Name = "colAlicuotaIva";
            this.colAlicuotaIva.Visible = true;
            this.colAlicuotaIva.VisibleIndex = 6;
            this.colAlicuotaIva.Width = 80;
            // 
            // colImporteIVA
            // 
            this.colImporteIVA.FieldName = "ImporteIVA";
            this.colImporteIVA.Name = "colImporteIVA";
            this.colImporteIVA.Visible = true;
            this.colImporteIVA.VisibleIndex = 7;
            this.colImporteIVA.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 8;
            this.colImporte.Width = 87;
            // 
            // colId_ComprobanteVenta
            // 
            this.colId_ComprobanteVenta.FieldName = "Id_ComprobanteVenta";
            this.colId_ComprobanteVenta.Name = "colId_ComprobanteVenta";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFechaAdd
            // 
            this.colFechaAdd.FieldName = "FechaAdd";
            this.colFechaAdd.Name = "colFechaAdd";
            // 
            // colFechaMod
            // 
            this.colFechaMod.FieldName = "FechaMod";
            this.colFechaMod.Name = "colFechaMod";
            // 
            // colUserAdd
            // 
            this.colUserAdd.FieldName = "UserAdd";
            this.colUserAdd.Name = "colUserAdd";
            // 
            // colUserMod
            // 
            this.colUserMod.FieldName = "UserMod";
            this.colUserMod.Name = "colUserMod";
            // 
            // frmComprobantesVentasAProcesar
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
            this.MinimumSize = new System.Drawing.Size(654, 212);
            this.Name = "frmComprobantesVentasAProcesar";
            this.Text = "Pendientes a Procesar";
            this.Load += new System.EventHandler(this.frmComprobantesVentasAProcesar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendientesCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasAProcesarManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit pendientesCheckEdit;
        private System.Windows.Forms.BindingSource comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnProcesarPendientes;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource comprobantesVentasAProcesarManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteIVA;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraBars.BarButtonItem btnImportar;
        private DevExpress.XtraBars.BarButtonItem btnGenerar;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
    }
}