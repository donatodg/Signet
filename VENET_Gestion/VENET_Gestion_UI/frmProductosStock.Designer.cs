namespace VENET_Gestion_UI
{
    partial class frmProductosStock
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
            System.Windows.Forms.Label id_ProductoLabel;
            System.Windows.Forms.Label id_DepositoLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosStock_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIngresos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEgresos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_IvaAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockMaximo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockInicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_DepositoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.productosStock_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnActualizaStock = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_ProductoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.FiltroBusquedaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            id_ProductoLabel = new System.Windows.Forms.Label();
            id_DepositoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosStock_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosStock_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ProductoLabel
            // 
            id_ProductoLabel.AutoSize = true;
            id_ProductoLabel.Location = new System.Drawing.Point(230, 8);
            id_ProductoLabel.Name = "id_ProductoLabel";
            id_ProductoLabel.Size = new System.Drawing.Size(54, 13);
            id_ProductoLabel.TabIndex = 30;
            id_ProductoLabel.Text = "Producto:";
            // 
            // id_DepositoLabel
            // 
            id_DepositoLabel.AutoSize = true;
            id_DepositoLabel.Location = new System.Drawing.Point(12, 8);
            id_DepositoLabel.Name = "id_DepositoLabel";
            id_DepositoLabel.Size = new System.Drawing.Size(53, 13);
            id_DepositoLabel.TabIndex = 31;
            id_DepositoLabel.Text = "Depósito:";
            // 
            // colStock
            // 
            this.colStock.FieldName = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.OptionsColumn.ReadOnly = true;
            this.colStock.Visible = true;
            this.colStock.VisibleIndex = 3;
            this.colStock.Width = 69;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosStock_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 54);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 382);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosStock_SearchResultBindingSource
            // 
            this.productosStock_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosStockManager.SearchResult);
            this.productosStock_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosStock_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEspecie,
            this.colIngresos,
            this.colEgresos,
            this.colStock,
            this.colCodigo,
            this.colCodigoFabrica,
            this.colDescripcion,
            this.colId_IvaAlicuota,
            this.colId_Categoria,
            this.colId_UnidadVenta,
            this.colCodigoBarras,
            this.colId_Especie,
            this.colImporte,
            this.colImporteCosto,
            this.colStockMinimo,
            this.colStockMaximo,
            this.colObservaciones,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colStockInicial,
            this.colImporteStock});
            gridFormatRule1.Column = this.colStock;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[Stock] < [StockMinimo]";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Column = this.colStock;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.Yellow;
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Expression = "[Stock] > [StockMaximo]";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colIngresos
            // 
            this.colIngresos.DisplayFormat.FormatString = "#,##0";
            this.colIngresos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIngresos.FieldName = "Ingresos";
            this.colIngresos.Name = "colIngresos";
            this.colIngresos.Visible = true;
            this.colIngresos.VisibleIndex = 1;
            this.colIngresos.Width = 83;
            // 
            // colEgresos
            // 
            this.colEgresos.DisplayFormat.FormatString = "#,##0";
            this.colEgresos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEgresos.FieldName = "Egresos";
            this.colEgresos.Name = "colEgresos";
            this.colEgresos.Visible = true;
            this.colEgresos.VisibleIndex = 2;
            this.colEgresos.Width = 72;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "Código Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Descripcion", "{0}")});
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 323;
            // 
            // colId_IvaAlicuota
            // 
            this.colId_IvaAlicuota.FieldName = "Id_IvaAlicuota";
            this.colId_IvaAlicuota.Name = "colId_IvaAlicuota";
            // 
            // colId_Categoria
            // 
            this.colId_Categoria.FieldName = "Id_Categoria";
            this.colId_Categoria.Name = "colId_Categoria";
            // 
            // colId_UnidadVenta
            // 
            this.colId_UnidadVenta.FieldName = "Id_UnidadVenta";
            this.colId_UnidadVenta.Name = "colId_UnidadVenta";
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.Caption = "Código Barras";
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            this.colImporteCosto.Visible = true;
            this.colImporteCosto.VisibleIndex = 6;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.Caption = "Stock Mínimo";
            this.colStockMinimo.FieldName = "StockMinimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.Visible = true;
            this.colStockMinimo.VisibleIndex = 4;
            this.colStockMinimo.Width = 86;
            // 
            // colStockMaximo
            // 
            this.colStockMaximo.Caption = "Stock Máximo";
            this.colStockMaximo.FieldName = "StockMaximo";
            this.colStockMaximo.Name = "colStockMaximo";
            this.colStockMaximo.Visible = true;
            this.colStockMaximo.VisibleIndex = 5;
            this.colStockMaximo.Width = 83;
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
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
            // colStockInicial
            // 
            this.colStockInicial.Caption = "Stock Inicial";
            this.colStockInicial.DisplayFormat.FormatString = "#,##0";
            this.colStockInicial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockInicial.FieldName = "StockInicial";
            this.colStockInicial.Name = "colStockInicial";
            // 
            // colImporteStock
            // 
            this.colImporteStock.Caption = "Importe Stock";
            this.colImporteStock.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteStock.FieldName = "ImporteStock";
            this.colImporteStock.Name = "colImporteStock";
            this.colImporteStock.OptionsColumn.AllowEdit = false;
            this.colImporteStock.OptionsColumn.ReadOnly = true;
            this.colImporteStock.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteStock", "{0:n2}")});
            this.colImporteStock.Visible = true;
            this.colImporteStock.VisibleIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_DepositoLabel);
            this.panelControl1.Controls.Add(this.id_DepositoLookUpEdit);
            this.panelControl1.Controls.Add(id_ProductoLabel);
            this.panelControl1.Controls.Add(this.id_ProductoLookUpEdit);
            this.panelControl1.Controls.Add(this.FiltroBusquedaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 30);
            this.panelControl1.TabIndex = 1;
            // 
            // id_DepositoLookUpEdit
            // 
            this.id_DepositoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosStock_ParametrosBusquedasBindingSource, "Id_Deposito", true));
            this.id_DepositoLookUpEdit.Location = new System.Drawing.Point(71, 5);
            this.id_DepositoLookUpEdit.MenuManager = this.barManager1;
            this.id_DepositoLookUpEdit.Name = "id_DepositoLookUpEdit";
            this.id_DepositoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_DepositoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.id_DepositoLookUpEdit.Properties.NullText = "";
            this.id_DepositoLookUpEdit.Properties.ShowHeader = false;
            this.id_DepositoLookUpEdit.Size = new System.Drawing.Size(153, 20);
            this.id_DepositoLookUpEdit.TabIndex = 32;
            this.id_DepositoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // productosStock_ParametrosBusquedasBindingSource
            // 
            this.productosStock_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosStockManager.ParametrosBusquedas);
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
            this.btnActualizaStock});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 3;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaStock)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnActualizaStock
            // 
            this.btnActualizaStock.Caption = "Actualizar Stock";
            this.btnActualizaStock.Id = 4;
            this.btnActualizaStock.Name = "btnActualizaStock";
            this.btnActualizaStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaStock_ItemClick);
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
            // id_ProductoLookUpEdit
            // 
            this.id_ProductoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosStock_ParametrosBusquedasBindingSource, "Id_Producto", true));
            this.id_ProductoLookUpEdit.Location = new System.Drawing.Point(396, 5);
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
            this.id_ProductoLookUpEdit.Size = new System.Drawing.Size(182, 20);
            this.id_ProductoLookUpEdit.TabIndex = 31;
            this.id_ProductoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // FiltroBusquedaLookUpEdit
            // 
            this.FiltroBusquedaLookUpEdit.EnterMoveNextControl = true;
            this.FiltroBusquedaLookUpEdit.Location = new System.Drawing.Point(290, 5);
            this.FiltroBusquedaLookUpEdit.MenuManager = this.barManager1;
            this.FiltroBusquedaLookUpEdit.Name = "FiltroBusquedaLookUpEdit";
            this.FiltroBusquedaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FiltroBusquedaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name28")});
            this.FiltroBusquedaLookUpEdit.Properties.NullText = "";
            this.FiltroBusquedaLookUpEdit.Properties.ShowHeader = false;
            this.FiltroBusquedaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.FiltroBusquedaLookUpEdit.TabIndex = 30;
            this.FiltroBusquedaLookUpEdit.EditValueChanged += new System.EventHandler(this.FiltroBusquedaLookUpEdit_EditValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmProductosStock
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
            this.MinimumSize = new System.Drawing.Size(695, 221);
            this.Name = "frmProductosStock";
            this.Text = "Stock de Productos";
            this.Load += new System.EventHandler(this.frmProductosStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosStock_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosStock_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource productosStock_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colIngresos;
        private DevExpress.XtraGrid.Columns.GridColumn colEgresos;
        private DevExpress.XtraGrid.Columns.GridColumn colStock;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_IvaAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMinimo;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMaximo;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.LookUpEdit id_ProductoLookUpEdit;
        private System.Windows.Forms.BindingSource productosStock_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit FiltroBusquedaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_DepositoLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colStockInicial;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnActualizaStock;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteStock;
    }
}