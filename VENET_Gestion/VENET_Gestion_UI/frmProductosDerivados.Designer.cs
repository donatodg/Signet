namespace VENET_Gestion_UI
{
    partial class frmProductosDerivados
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label codigoFabricaLabel;
            System.Windows.Forms.Label codigoBarrasLabel;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.codigoBarrasTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.productosDerivadosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.codigoFabricaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosDerivadosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            codigoFabricaLabel = new System.Windows.Forms.Label();
            codigoBarrasLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosDerivadosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoFabricaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosDerivadosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(29, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(162, 9);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 2;
            descripcionLabel.Text = "Descripción:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(6, 35);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 4;
            codigoLabel.Text = "Código:";
            // 
            // codigoFabricaLabel
            // 
            codigoFabricaLabel.AutoSize = true;
            codigoFabricaLabel.Location = new System.Drawing.Point(167, 35);
            codigoFabricaLabel.Name = "codigoFabricaLabel";
            codigoFabricaLabel.Size = new System.Drawing.Size(60, 13);
            codigoFabricaLabel.TabIndex = 6;
            codigoFabricaLabel.Text = "C. Fábrica:";
            // 
            // codigoBarrasLabel
            // 
            codigoBarrasLabel.AutoSize = true;
            codigoBarrasLabel.Location = new System.Drawing.Point(339, 35);
            codigoBarrasLabel.Name = "codigoBarrasLabel";
            codigoBarrasLabel.Size = new System.Drawing.Size(56, 13);
            codigoBarrasLabel.TabIndex = 8;
            codigoBarrasLabel.Text = "C. Barras:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(codigoBarrasLabel);
            this.panelControl1.Controls.Add(this.codigoBarrasTextEdit);
            this.panelControl1.Controls.Add(codigoFabricaLabel);
            this.panelControl1.Controls.Add(this.codigoFabricaTextEdit);
            this.panelControl1.Controls.Add(codigoLabel);
            this.panelControl1.Controls.Add(this.codigoTextEdit);
            this.panelControl1.Controls.Add(descripcionLabel);
            this.panelControl1.Controls.Add(this.descripcionTextEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 60);
            this.panelControl1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // codigoBarrasTextEdit
            // 
            this.codigoBarrasTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosDerivadosManager_ParametrosBusquedasBindingSource, "CodigoBarras", true));
            this.codigoBarrasTextEdit.EnterMoveNextControl = true;
            this.codigoBarrasTextEdit.Location = new System.Drawing.Point(401, 32);
            this.codigoBarrasTextEdit.MenuManager = this.barManager1;
            this.codigoBarrasTextEdit.Name = "codigoBarrasTextEdit";
            this.codigoBarrasTextEdit.Properties.MaxLength = 100;
            this.codigoBarrasTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoBarrasTextEdit.TabIndex = 9;
            this.codigoBarrasTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // productosDerivadosManager_ParametrosBusquedasBindingSource
            // 
            this.productosDerivadosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosDerivadosManager.ParametrosBusquedas);
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
            this.barStaticItemFooter,
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.btnResultado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Gestion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Gestion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 2;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Gestion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 3;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 4;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
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
            this.barStaticItemFooter.Id = 0;
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
            // codigoFabricaTextEdit
            // 
            this.codigoFabricaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosDerivadosManager_ParametrosBusquedasBindingSource, "CodigoFabrica", true));
            this.codigoFabricaTextEdit.EnterMoveNextControl = true;
            this.codigoFabricaTextEdit.Location = new System.Drawing.Point(233, 32);
            this.codigoFabricaTextEdit.MenuManager = this.barManager1;
            this.codigoFabricaTextEdit.Name = "codigoFabricaTextEdit";
            this.codigoFabricaTextEdit.Properties.MaxLength = 100;
            this.codigoFabricaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoFabricaTextEdit.TabIndex = 7;
            this.codigoFabricaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // codigoTextEdit
            // 
            this.codigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosDerivadosManager_ParametrosBusquedasBindingSource, "Codigo", true));
            this.codigoTextEdit.EnterMoveNextControl = true;
            this.codigoTextEdit.Location = new System.Drawing.Point(56, 32);
            this.codigoTextEdit.MenuManager = this.barManager1;
            this.codigoTextEdit.Name = "codigoTextEdit";
            this.codigoTextEdit.Properties.MaxLength = 100;
            this.codigoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoTextEdit.TabIndex = 5;
            this.codigoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosDerivadosManager_ParametrosBusquedasBindingSource, "Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(233, 6);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 500;
            this.descripcionTextEdit.Size = new System.Drawing.Size(268, 20);
            this.descripcionTextEdit.TabIndex = 3;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosDerivadosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(56, 6);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 1;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosDerivadosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 84);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 352);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // productosDerivadosManager_SearchResultBindingSource
            // 
            this.productosDerivadosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosDerivadosManager.SearchResult);
            this.productosDerivadosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategoria,
            this.colUnidadVenta,
            this.colProducto,
            this.colCodigo,
            this.colCodigoFabrica,
            this.colDescripcion,
            this.colId_Producto,
            this.colId_Categoria,
            this.colId_UnidadVenta,
            this.colCantidad,
            this.colCodigoBarras,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoría";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 4;
            this.colCategoria.Width = 140;
            // 
            // colUnidadVenta
            // 
            this.colUnidadVenta.FieldName = "UnidadVenta";
            this.colUnidadVenta.Name = "colUnidadVenta";
            this.colUnidadVenta.Visible = true;
            this.colUnidadVenta.VisibleIndex = 5;
            this.colUnidadVenta.Width = 140;
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 6;
            this.colProducto.Width = 140;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 2;
            this.colCodigo.Width = 140;
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "Código Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            this.colCodigoFabrica.Visible = true;
            this.colCodigoFabrica.VisibleIndex = 3;
            this.colCodigoFabrica.Width = 140;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 140;
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
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
            // colCantidad
            // 
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 7;
            this.colCantidad.Width = 151;
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.Caption = "Código Barras";
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 87;
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
            // frmProductosDerivados
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
            this.MinimumSize = new System.Drawing.Size(613, 245);
            this.Name = "frmProductosDerivados";
            this.Text = "Productos Derivados";
            this.Load += new System.EventHandler(this.frmProductosDerivados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosDerivadosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoFabricaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosDerivadosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.TextEdit codigoBarrasTextEdit;
        private DevExpress.XtraEditors.TextEdit codigoFabricaTextEdit;
        private DevExpress.XtraEditors.TextEdit codigoTextEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource productosDerivadosManager_ParametrosBusquedasBindingSource;
        private System.Windows.Forms.BindingSource productosDerivadosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
    }
}