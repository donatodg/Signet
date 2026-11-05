namespace VENET_Gestion_UI
{
    partial class frmProductosListasPreciosDetalle
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label label1;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnSeleccionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportarPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.porcentajeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosActualizaListasPreciosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNuevoPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_IvaAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria2 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colId_EspecieOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Productos_ListasPrecios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecieOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNuevoPrecio_Original = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            idLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosActualizaListasPreciosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(16, 10);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(63, 13);
            idLabel.TabIndex = 11;
            idLabel.Text = "Porcentaje:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(191, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 13);
            label1.TabIndex = 14;
            label1.Text = "Importe Fijo:";
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
            this.btnAceptar,
            this.barStaticItemFooter,
            this.barSubItem1,
            this.btnSeleccionar,
            this.btnImportarPrecios,
            this.barSubItem2,
            this.btnResultado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 2;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSeleccionar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportarPrecios, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Caption = "Seleccionar Items";
            this.btnSeleccionar.Id = 3;
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSeleccionar_ItemClick);
            // 
            // btnImportarPrecios
            // 
            this.btnImportarPrecios.Caption = "Importar Precios de Productos";
            this.btnImportarPrecios.Id = 4;
            this.btnImportarPrecios.Name = "btnImportarPrecios";
            this.btnImportarPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportarPrecios_ItemClick);
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
            this.barStaticItemFooter.Id = 1;
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
            this.panelControl1.Controls.Add(this.importeTextEdit);
            this.panelControl1.Controls.Add(label1);
            this.panelControl1.Controls.Add(this.btnCalcular);
            this.panelControl1.Controls.Add(this.porcentajeTextEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 4;
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(260, 5);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.EditFormat.FormatString = "n";
            this.importeTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 15;
            this.importeTextEdit.EditValueChanged += new System.EventHandler(this.importeTextEdit_EditValueChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Location = new System.Drawing.Point(647, 5);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 13;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // porcentajeTextEdit
            // 
            this.porcentajeTextEdit.EnterMoveNextControl = true;
            this.porcentajeTextEdit.Location = new System.Drawing.Point(85, 6);
            this.porcentajeTextEdit.MenuManager = this.barManager1;
            this.porcentajeTextEdit.Name = "porcentajeTextEdit";
            this.porcentajeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.porcentajeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.porcentajeTextEdit.Properties.EditFormat.FormatString = "n";
            this.porcentajeTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.porcentajeTextEdit.Properties.Mask.EditMask = "n";
            this.porcentajeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.porcentajeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.porcentajeTextEdit.TabIndex = 12;
            this.porcentajeTextEdit.EditValueChanged += new System.EventHandler(this.porcentajeTextEdit_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosActualizaListasPreciosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridControl1.Size = new System.Drawing.Size(734, 379);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosActualizaListasPreciosManager_SearchResultBindingSource
            // 
            this.productosActualizaListasPreciosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosActualizaListasPreciosManager.SearchResult);
            this.productosActualizaListasPreciosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosActualizaListasPreciosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAlicuota,
            this.colCategoria,
            this.colCategoria2,
            this.colUnidadVenta,
            this.colEspecie,
            this.colSeleccionado,
            this.colNuevoPrecio,
            this.colCodigo,
            this.colCodigoFabrica,
            this.colDescripcion,
            this.colId_IvaAlicuota,
            this.colId_Categoria,
            this.colId_Categoria2,
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
            this.colId_EspecieOriginal,
            this.colImporteOriginal,
            this.colId_Productos_ListasPrecios,
            this.colEspecieOriginal,
            this.colNuevoPrecio_Original});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colAlicuota
            // 
            this.colAlicuota.FieldName = "Alicuota";
            this.colAlicuota.Name = "colAlicuota";
            this.colAlicuota.OptionsColumn.AllowEdit = false;
            this.colAlicuota.OptionsColumn.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.OptionsColumn.AllowEdit = false;
            this.colCategoria.OptionsColumn.ReadOnly = true;
            this.colCategoria.Width = 96;
            // 
            // colCategoria2
            // 
            this.colCategoria2.FieldName = "Categoria2";
            this.colCategoria2.Name = "colCategoria2";
            this.colCategoria2.OptionsColumn.AllowEdit = false;
            this.colCategoria2.OptionsColumn.ReadOnly = true;
            // 
            // colUnidadVenta
            // 
            this.colUnidadVenta.FieldName = "UnidadVenta";
            this.colUnidadVenta.Name = "colUnidadVenta";
            this.colUnidadVenta.OptionsColumn.AllowEdit = false;
            this.colUnidadVenta.OptionsColumn.ReadOnly = true;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.OptionsColumn.AllowEdit = false;
            this.colEspecie.OptionsColumn.ReadOnly = true;
            this.colEspecie.Visible = true;
            this.colEspecie.VisibleIndex = 2;
            this.colEspecie.Width = 85;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Seleccionado", "{0}")});
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            this.colSeleccionado.Width = 73;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            // 
            // colNuevoPrecio
            // 
            this.colNuevoPrecio.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colNuevoPrecio.AppearanceCell.Options.UseBackColor = true;
            this.colNuevoPrecio.ColumnEdit = this.repositoryItemTextEdit1;
            this.colNuevoPrecio.FieldName = "NuevoPrecio";
            this.colNuevoPrecio.Name = "colNuevoPrecio";
            this.colNuevoPrecio.Visible = true;
            this.colNuevoPrecio.VisibleIndex = 4;
            this.colNuevoPrecio.Width = 105;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemTextEdit1_EditValueChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.AllowEdit = false;
            this.colCodigo.OptionsColumn.ReadOnly = true;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 1;
            this.colCodigo.Width = 108;
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "Código Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            this.colCodigoFabrica.OptionsColumn.AllowEdit = false;
            this.colCodigoFabrica.OptionsColumn.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Width = 101;
            // 
            // colId_IvaAlicuota
            // 
            this.colId_IvaAlicuota.FieldName = "Id_IvaAlicuota";
            this.colId_IvaAlicuota.Name = "colId_IvaAlicuota";
            this.colId_IvaAlicuota.OptionsColumn.AllowEdit = false;
            this.colId_IvaAlicuota.OptionsColumn.ReadOnly = true;
            // 
            // colId_Categoria
            // 
            this.colId_Categoria.FieldName = "Id_Categoria";
            this.colId_Categoria.Name = "colId_Categoria";
            this.colId_Categoria.OptionsColumn.AllowEdit = false;
            this.colId_Categoria.OptionsColumn.ReadOnly = true;
            // 
            // colId_Categoria2
            // 
            this.colId_Categoria2.FieldName = "Id_Categoria2";
            this.colId_Categoria2.Name = "colId_Categoria2";
            this.colId_Categoria2.OptionsColumn.AllowEdit = false;
            this.colId_Categoria2.OptionsColumn.ReadOnly = true;
            // 
            // colId_UnidadVenta
            // 
            this.colId_UnidadVenta.FieldName = "Id_UnidadVenta";
            this.colId_UnidadVenta.Name = "colId_UnidadVenta";
            this.colId_UnidadVenta.OptionsColumn.AllowEdit = false;
            this.colId_UnidadVenta.OptionsColumn.ReadOnly = true;
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.OptionsColumn.AllowEdit = false;
            this.colCodigoBarras.OptionsColumn.ReadOnly = true;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            this.colId_Especie.OptionsColumn.AllowEdit = false;
            this.colId_Especie.OptionsColumn.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 3;
            this.colImporte.Width = 89;
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            this.colImporteCosto.OptionsColumn.AllowEdit = false;
            this.colImporteCosto.OptionsColumn.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.Caption = "Stock Mínimo";
            this.colStockMinimo.FieldName = "StockMinimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.OptionsColumn.AllowEdit = false;
            this.colStockMinimo.OptionsColumn.ReadOnly = true;
            // 
            // colStockMaximo
            // 
            this.colStockMaximo.Caption = "Stock Máximo";
            this.colStockMaximo.FieldName = "StockMaximo";
            this.colStockMaximo.Name = "colStockMaximo";
            this.colStockMaximo.OptionsColumn.AllowEdit = false;
            this.colStockMaximo.OptionsColumn.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.OptionsColumn.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colFechaAdd
            // 
            this.colFechaAdd.FieldName = "FechaAdd";
            this.colFechaAdd.Name = "colFechaAdd";
            this.colFechaAdd.OptionsColumn.AllowEdit = false;
            this.colFechaAdd.OptionsColumn.ReadOnly = true;
            // 
            // colFechaMod
            // 
            this.colFechaMod.FieldName = "FechaMod";
            this.colFechaMod.Name = "colFechaMod";
            this.colFechaMod.OptionsColumn.AllowEdit = false;
            this.colFechaMod.OptionsColumn.ReadOnly = true;
            // 
            // colUserAdd
            // 
            this.colUserAdd.FieldName = "UserAdd";
            this.colUserAdd.Name = "colUserAdd";
            this.colUserAdd.OptionsColumn.AllowEdit = false;
            this.colUserAdd.OptionsColumn.ReadOnly = true;
            // 
            // colUserMod
            // 
            this.colUserMod.FieldName = "UserMod";
            this.colUserMod.Name = "colUserMod";
            this.colUserMod.OptionsColumn.AllowEdit = false;
            this.colUserMod.OptionsColumn.ReadOnly = true;
            // 
            // colId_EspecieOriginal
            // 
            this.colId_EspecieOriginal.Caption = "Id_EspecieOriginal";
            this.colId_EspecieOriginal.FieldName = "Id_EspecieOriginal";
            this.colId_EspecieOriginal.Name = "colId_EspecieOriginal";
            this.colId_EspecieOriginal.OptionsColumn.AllowEdit = false;
            this.colId_EspecieOriginal.OptionsColumn.ReadOnly = true;
            // 
            // colImporteOriginal
            // 
            this.colImporteOriginal.Caption = "Importe Orig.";
            this.colImporteOriginal.FieldName = "ImporteOriginal";
            this.colImporteOriginal.Name = "colImporteOriginal";
            this.colImporteOriginal.OptionsColumn.AllowEdit = false;
            this.colImporteOriginal.OptionsColumn.ReadOnly = true;
            this.colImporteOriginal.Visible = true;
            this.colImporteOriginal.VisibleIndex = 6;
            this.colImporteOriginal.Width = 74;
            // 
            // colId_Productos_ListasPrecios
            // 
            this.colId_Productos_ListasPrecios.Caption = "Id_Productos_ListasPrecios";
            this.colId_Productos_ListasPrecios.FieldName = "Id_Productos_ListasPrecios";
            this.colId_Productos_ListasPrecios.Name = "colId_Productos_ListasPrecios";
            this.colId_Productos_ListasPrecios.OptionsColumn.AllowEdit = false;
            this.colId_Productos_ListasPrecios.OptionsColumn.ReadOnly = true;
            // 
            // colEspecieOriginal
            // 
            this.colEspecieOriginal.Caption = "Especie Orig.";
            this.colEspecieOriginal.FieldName = "EspecieOriginal";
            this.colEspecieOriginal.Name = "colEspecieOriginal";
            this.colEspecieOriginal.OptionsColumn.AllowEdit = false;
            this.colEspecieOriginal.OptionsColumn.ReadOnly = true;
            this.colEspecieOriginal.Visible = true;
            this.colEspecieOriginal.VisibleIndex = 5;
            this.colEspecieOriginal.Width = 89;
            // 
            // colNuevoPrecio_Original
            // 
            this.colNuevoPrecio_Original.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colNuevoPrecio_Original.AppearanceCell.Options.UseBackColor = true;
            this.colNuevoPrecio_Original.Caption = "Nuevo Precio Orig.";
            this.colNuevoPrecio_Original.ColumnEdit = this.repositoryItemTextEdit2;
            this.colNuevoPrecio_Original.FieldName = "NuevoPrecio_Original";
            this.colNuevoPrecio_Original.Name = "colNuevoPrecio_Original";
            this.colNuevoPrecio_Original.Visible = true;
            this.colNuevoPrecio_Original.VisibleIndex = 7;
            this.colNuevoPrecio_Original.Width = 93;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "n";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "n";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "n";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 5;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 6;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // frmProductosListasPreciosDetalle
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
            this.MinimumSize = new System.Drawing.Size(483, 245);
            this.Name = "frmProductosListasPreciosDetalle";
            this.Text = "Actualización Lista de Precios";
            this.Load += new System.EventHandler(this.frmProductosActualizaPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosActualizaListasPreciosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private System.Windows.Forms.Button btnCalcular;
        private DevExpress.XtraEditors.TextEdit porcentajeTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria2;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colNuevoPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_IvaAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria2;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnSeleccionar;
        private System.Windows.Forms.BindingSource productosActualizaListasPreciosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EspecieOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Productos_ListasPrecios;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecieOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colNuevoPrecio_Original;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem btnImportarPrecios;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
    }
}