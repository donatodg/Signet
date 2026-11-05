namespace VENET_Gestion_UI
{
    partial class frmProductosMovimientos
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
            System.Windows.Forms.Label fechaHastaLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label id_ProductoLabel;
            System.Windows.Forms.Label id_DepositoLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosMovimientosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_DepositoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.productosMovimientosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.FiltroBusquedaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_ProductoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.colCantidadStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            fechaHastaLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            id_ProductoLabel = new System.Windows.Forms.Label();
            id_DepositoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosMovimientosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosMovimientosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(195, 33);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(71, 13);
            fechaHastaLabel.TabIndex = 34;
            fechaHastaLabel.Text = "Fecha Hasta:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(10, 33);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 32;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // id_ProductoLabel
            // 
            id_ProductoLabel.AutoSize = true;
            id_ProductoLabel.Location = new System.Drawing.Point(212, 7);
            id_ProductoLabel.Name = "id_ProductoLabel";
            id_ProductoLabel.Size = new System.Drawing.Size(54, 13);
            id_ProductoLabel.TabIndex = 30;
            id_ProductoLabel.Text = "Producto:";
            // 
            // id_DepositoLabel
            // 
            id_DepositoLabel.AutoSize = true;
            id_DepositoLabel.Location = new System.Drawing.Point(30, 7);
            id_DepositoLabel.Name = "id_DepositoLabel";
            id_DepositoLabel.Size = new System.Drawing.Size(53, 13);
            id_DepositoLabel.TabIndex = 37;
            id_DepositoLabel.Text = "Depósito:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosMovimientosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 79);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 357);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosMovimientosManager_SearchResultBindingSource
            // 
            this.productosMovimientosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosMovimientosManager.SearchResult);
            this.productosMovimientosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosMovimientosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colEntidad,
            this.colNombre,
            this.colTipo,
            this.colId_Comprobante,
            this.colId_Especie,
            this.colEspecie,
            this.colCotizacion,
            this.colDescripcion,
            this.colCantidad,
            this.colPorcDescuento,
            this.colImporteUnitario,
            this.colId_AlicuotaIva,
            this.colAlicuotaIva,
            this.colImporteIva,
            this.colImporte,
            this.colCodigo,
            this.colCodigoBarras,
            this.colCodigoFabrica,
            this.colComprobante,
            this.colCantidadStock,
            this.colId_Categoria,
            this.colCategoria});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategoria, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "{0}")});
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 62;
            // 
            // colEntidad
            // 
            this.colEntidad.FieldName = "Entidad";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.Visible = true;
            this.colEntidad.VisibleIndex = 2;
            this.colEntidad.Width = 71;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 3;
            this.colNombre.Width = 87;
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 1;
            this.colTipo.Width = 60;
            // 
            // colId_Comprobante
            // 
            this.colId_Comprobante.FieldName = "Id_Comprobante";
            this.colId_Comprobante.Name = "colId_Comprobante";
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colCotizacion
            // 
            this.colCotizacion.Caption = "Cotización";
            this.colCotizacion.FieldName = "Cotizacion";
            this.colCotizacion.Name = "colCotizacion";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 4;
            this.colDescripcion.Width = 121;
            // 
            // colCantidad
            // 
            this.colCantidad.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:n2}")});
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 5;
            // 
            // colPorcDescuento
            // 
            this.colPorcDescuento.DisplayFormat.FormatString = "#,##0";
            this.colPorcDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPorcDescuento.FieldName = "PorcDescuento";
            this.colPorcDescuento.Name = "colPorcDescuento";
            this.colPorcDescuento.Visible = true;
            this.colPorcDescuento.VisibleIndex = 6;
            this.colPorcDescuento.Width = 77;
            // 
            // colImporteUnitario
            // 
            this.colImporteUnitario.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitario.FieldName = "ImporteUnitario";
            this.colImporteUnitario.Name = "colImporteUnitario";
            this.colImporteUnitario.Visible = true;
            this.colImporteUnitario.VisibleIndex = 7;
            this.colImporteUnitario.Width = 65;
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
            // 
            // colImporteIva
            // 
            this.colImporteIva.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteIva.FieldName = "ImporteIva";
            this.colImporteIva.Name = "colImporteIva";
            this.colImporteIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:n2}")});
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:n2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 8;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.Caption = "Código Barras";
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "Código Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_DepositoLabel);
            this.panelControl1.Controls.Add(this.id_DepositoLookUpEdit);
            this.panelControl1.Controls.Add(this.FiltroBusquedaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(id_ProductoLabel);
            this.panelControl1.Controls.Add(this.id_ProductoLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 55);
            this.panelControl1.TabIndex = 1;
            // 
            // id_DepositoLookUpEdit
            // 
            this.id_DepositoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosMovimientosManager_ParametrosBusquedasBindingSource, "Id_Deposito", true));
            this.id_DepositoLookUpEdit.EnterMoveNextControl = true;
            this.id_DepositoLookUpEdit.Location = new System.Drawing.Point(89, 4);
            this.id_DepositoLookUpEdit.MenuManager = this.barManager1;
            this.id_DepositoLookUpEdit.Name = "id_DepositoLookUpEdit";
            this.id_DepositoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_DepositoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3")});
            this.id_DepositoLookUpEdit.Properties.NullText = "";
            this.id_DepositoLookUpEdit.Properties.ShowHeader = false;
            this.id_DepositoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_DepositoLookUpEdit.TabIndex = 0;
            // 
            // productosMovimientosManager_ParametrosBusquedasBindingSource
            // 
            this.productosMovimientosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosMovimientosManager.ParametrosBusquedas);
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
            this.barStaticItemFooter,
            this.barSubItem2,
            this.btnComprobante});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Gestion_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 3;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComprobante)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnComprobante
            // 
            this.btnComprobante.Caption = "Comprobante";
            this.btnComprobante.Id = 4;
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComprobante_ItemClick);
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
            // FiltroBusquedaLookUpEdit
            // 
            this.FiltroBusquedaLookUpEdit.EnterMoveNextControl = true;
            this.FiltroBusquedaLookUpEdit.Location = new System.Drawing.Point(272, 4);
            this.FiltroBusquedaLookUpEdit.MenuManager = this.barManager1;
            this.FiltroBusquedaLookUpEdit.Name = "FiltroBusquedaLookUpEdit";
            this.FiltroBusquedaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FiltroBusquedaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name28")});
            this.FiltroBusquedaLookUpEdit.Properties.NullText = "";
            this.FiltroBusquedaLookUpEdit.Properties.ShowHeader = false;
            this.FiltroBusquedaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.FiltroBusquedaLookUpEdit.TabIndex = 1;
            this.FiltroBusquedaLookUpEdit.EditValueChanged += new System.EventHandler(this.FiltroBusquedaLookUpEdit_EditValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosMovimientosManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(272, 30);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 4;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosMovimientosManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(89, 30);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 3;
            // 
            // id_ProductoLookUpEdit
            // 
            this.id_ProductoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosMovimientosManager_ParametrosBusquedasBindingSource, "Id_Producto", true));
            this.id_ProductoLookUpEdit.Location = new System.Drawing.Point(373, 4);
            this.id_ProductoLookUpEdit.MenuManager = this.barManager1;
            this.id_ProductoLookUpEdit.Name = "id_ProductoLookUpEdit";
            this.id_ProductoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ProductoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripción"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodigoFabrica", "C.Fábrica"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodigoBarras", "C.Barras")});
            this.id_ProductoLookUpEdit.Properties.NullText = "[Todos]";
            this.id_ProductoLookUpEdit.Properties.PopupWidth = 500;
            this.id_ProductoLookUpEdit.Size = new System.Drawing.Size(133, 20);
            this.id_ProductoLookUpEdit.TabIndex = 2;
            this.id_ProductoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // colCantidadStock
            // 
            this.colCantidadStock.Caption = "Cantidad Stock";
            this.colCantidadStock.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidadStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidadStock.FieldName = "CantidadStock";
            this.colCantidadStock.Name = "colCantidadStock";
            this.colCantidadStock.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantidadStock", "{0:n2}")});
            // 
            // colId_Categoria
            // 
            this.colId_Categoria.Caption = "Id_Categoria";
            this.colId_Categoria.FieldName = "Id_Categoria";
            this.colId_Categoria.Name = "colId_Categoria";
            this.colId_Categoria.OptionsColumn.AllowEdit = false;
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoría";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 9;
            // 
            // frmProductosMovimientos
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
            this.MinimumSize = new System.Drawing.Size(536, 235);
            this.Name = "frmProductosMovimientos";
            this.Text = "Movimientos de Productos";
            this.Load += new System.EventHandler(this.frmProductosMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosMovimientosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosMovimientosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private System.Windows.Forms.BindingSource productosMovimientosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraEditors.LookUpEdit FiltroBusquedaLookUpEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource productosMovimientosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_ProductoLookUpEdit;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraEditors.LookUpEdit id_DepositoLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadStock;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
    }
}