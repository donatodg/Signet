namespace VENET_Gestion_UI
{
    partial class frmProductos
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
            this.productosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.btnListaPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnctualizaPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizacionCostos = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaCostoCompra = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaExcelVenta = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaExcelCosto = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnImagenes = new DevExpress.XtraBars.BarButtonItem();
            this.btnComposicion = new DevExpress.XtraBars.BarButtonItem();
            this.btnComposicionTodos = new DevExpress.XtraBars.BarButtonItem();
            this.btnStock = new DevExpress.XtraBars.BarButtonItem();
            this.btnMovimientos = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductosSinVentas = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistorialPrecios = new DevExpress.XtraBars.BarButtonItem();
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
            this.productosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_IvaAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockMaximo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGanancia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaActualizacionCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEquivalencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecieOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_EspecieOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_EspecieCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_UnidadStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            codigoFabricaLabel = new System.Windows.Forms.Label();
            codigoBarrasLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoFabricaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.codigoBarrasTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosManager_ParametrosBusquedasBindingSource, "CodigoBarras", true));
            this.codigoBarrasTextEdit.EnterMoveNextControl = true;
            this.codigoBarrasTextEdit.Location = new System.Drawing.Point(401, 32);
            this.codigoBarrasTextEdit.MenuManager = this.barManager1;
            this.codigoBarrasTextEdit.Name = "codigoBarrasTextEdit";
            this.codigoBarrasTextEdit.Properties.MaxLength = 100;
            this.codigoBarrasTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoBarrasTextEdit.TabIndex = 9;
            this.codigoBarrasTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // productosManager_ParametrosBusquedasBindingSource
            // 
            this.productosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosManager.ParametrosBusquedas);
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
            this.btnResultado,
            this.barSubItem2,
            this.btnHistorialPrecios,
            this.btnStock,
            this.btnMovimientos,
            this.btnListaPrecios,
            this.btnProductosSinVentas,
            this.barSubItem3,
            this.btnctualizaPrecios,
            this.btnComposicion,
            this.btnActualizacionCostos,
            this.btnComposicionTodos,
            this.btnActualizaCostoCompra,
            this.btnImagenes,
            this.btnActualizaExcelVenta,
            this.btnActualizaExcelCosto,
            this.btnGenerarExcel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 22;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Id = 1;
            this.btnAgregar.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Id = 2;
            this.btnModificar.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 3;
            this.btnEliminar.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Id = 4;
            this.barSubItem1.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnListaPrecios, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Caption = "Lista de Precios";
            this.btnListaPrecios.Id = 10;
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListaPrecios_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Operaciones";
            this.barSubItem3.Id = 12;
            this.barSubItem3.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnctualizaPrecios),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnActualizacionCostos, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaCostoCompra),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaExcelVenta, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaExcelCosto)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnctualizaPrecios
            // 
            this.btnctualizaPrecios.Caption = "Actualización Masiva de Precio Venta";
            this.btnctualizaPrecios.Id = 13;
            this.btnctualizaPrecios.Name = "btnctualizaPrecios";
            this.btnctualizaPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnctualizaPrecios_ItemClick);
            // 
            // btnActualizacionCostos
            // 
            this.btnActualizacionCostos.Caption = "Actualizacion Masiva de Costos";
            this.btnActualizacionCostos.Id = 15;
            this.btnActualizacionCostos.Name = "btnActualizacionCostos";
            this.btnActualizacionCostos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizacionCostos_ItemClick);
            // 
            // btnActualizaCostoCompra
            // 
            this.btnActualizaCostoCompra.Caption = "Actualización Masiva de Costo Compra";
            this.btnActualizaCostoCompra.Id = 17;
            this.btnActualizaCostoCompra.Name = "btnActualizaCostoCompra";
            this.btnActualizaCostoCompra.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaCostoCompra_ItemClick);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Caption = "Generar Excel Modelo";
            this.btnGenerarExcel.Id = 21;
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerarExcel_ItemClick);
            // 
            // btnActualizaExcelVenta
            // 
            this.btnActualizaExcelVenta.Caption = "Actualización Precio de Venta desde Excel";
            this.btnActualizaExcelVenta.Id = 19;
            this.btnActualizaExcelVenta.Name = "btnActualizaExcelVenta";
            this.btnActualizaExcelVenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaExcelVenta_ItemClick);
            // 
            // btnActualizaExcelCosto
            // 
            this.btnActualizaExcelCosto.Caption = "Actualización Precio de Costo desde Excel";
            this.btnActualizaExcelCosto.Id = 20;
            this.btnActualizaExcelCosto.Name = "btnActualizaExcelCosto";
            this.btnActualizaExcelCosto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaExcelCosto_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Id = 6;
            this.barSubItem2.ImageOptions.Image = global::VENET_Gestion_UI.Properties.Resources.info_16x16;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImagenes),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnComposicion, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnComposicionTodos, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStock, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMovimientos, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProductosSinVentas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHistorialPrecios, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnImagenes
            // 
            this.btnImagenes.Caption = "Imagenes";
            this.btnImagenes.Id = 18;
            this.btnImagenes.Name = "btnImagenes";
            this.btnImagenes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImagenes_ItemClick);
            // 
            // btnComposicion
            // 
            this.btnComposicion.Caption = "Composición del Producto ";
            this.btnComposicion.Id = 14;
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComposicion_ItemClick);
            // 
            // btnComposicionTodos
            // 
            this.btnComposicionTodos.Caption = "Composición de Todos los Productos";
            this.btnComposicionTodos.Id = 16;
            this.btnComposicionTodos.Name = "btnComposicionTodos";
            this.btnComposicionTodos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComposicionTodos_ItemClick);
            // 
            // btnStock
            // 
            this.btnStock.Caption = "Stock";
            this.btnStock.Id = 8;
            this.btnStock.Name = "btnStock";
            this.btnStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStock_ItemClick);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Caption = "Movimientos por Productos";
            this.btnMovimientos.Id = 9;
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMovimientos_ItemClick);
            // 
            // btnProductosSinVentas
            // 
            this.btnProductosSinVentas.Caption = "Productos sin Ventas";
            this.btnProductosSinVentas.Id = 11;
            this.btnProductosSinVentas.Name = "btnProductosSinVentas";
            this.btnProductosSinVentas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductosSinVentas_ItemClick);
            // 
            // btnHistorialPrecios
            // 
            this.btnHistorialPrecios.Caption = "Historial de Precios";
            this.btnHistorialPrecios.Id = 7;
            this.btnHistorialPrecios.Name = "btnHistorialPrecios";
            this.btnHistorialPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistorialPrecios_ItemClick);
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
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(734, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 439);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
            // 
            // codigoFabricaTextEdit
            // 
            this.codigoFabricaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosManager_ParametrosBusquedasBindingSource, "CodigoFabrica", true));
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
            this.codigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosManager_ParametrosBusquedasBindingSource, "Codigo", true));
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
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosManager_ParametrosBusquedasBindingSource, "Descripcion", true));
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
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosManager_ParametrosBusquedasBindingSource, "Id", true));
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
            this.gridControl1.DataSource = this.productosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 84);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 355);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // productosManager_SearchResultBindingSource
            // 
            this.productosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosManager.SearchResult);
            this.productosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAlicuota,
            this.colCategoria,
            this.colUnidadVenta,
            this.colCodigo,
            this.colCodigoFabrica,
            this.colDescripcion,
            this.colId_IvaAlicuota,
            this.colId_Categoria,
            this.colId_UnidadVenta,
            this.colCodigoBarras,
            this.colStockMinimo,
            this.colStockMaximo,
            this.colObservaciones,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colImporte,
            this.colId_Especie,
            this.colEspecie,
            this.colImporteCosto,
            this.colGanancia,
            this.colId_Categoria2,
            this.colCategoria2,
            this.colFechaActualizacionCosto,
            this.colUnidadCompra,
            this.colId_UnidadCompra,
            this.colEquivalencia,
            this.colImporteOriginal,
            this.colEspecieOriginal,
            this.colId_EspecieOriginal,
            this.colId_EspecieCosto,
            this.colId_UnidadStock,
            this.colUnidadStock});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colAlicuota
            // 
            this.colAlicuota.FieldName = "Alicuota";
            this.colAlicuota.Name = "colAlicuota";
            this.colAlicuota.Visible = true;
            this.colAlicuota.VisibleIndex = 4;
            this.colAlicuota.Width = 44;
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoría";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 6;
            this.colCategoria.Width = 67;
            // 
            // colUnidadVenta
            // 
            this.colUnidadVenta.FieldName = "UnidadVenta";
            this.colUnidadVenta.Name = "colUnidadVenta";
            this.colUnidadVenta.Visible = true;
            this.colUnidadVenta.VisibleIndex = 7;
            this.colUnidadVenta.Width = 58;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 1;
            this.colCodigo.Width = 57;
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "C.Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            this.colCodigoFabrica.Visible = true;
            this.colCodigoFabrica.VisibleIndex = 2;
            this.colCodigoFabrica.Width = 52;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            this.colDescripcion.Width = 159;
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
            // colStockMinimo
            // 
            this.colStockMinimo.Caption = "S. Mínimo";
            this.colStockMinimo.FieldName = "StockMinimo";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.Visible = true;
            this.colStockMinimo.VisibleIndex = 8;
            this.colStockMinimo.Width = 60;
            // 
            // colStockMaximo
            // 
            this.colStockMaximo.Caption = "S. Máximo";
            this.colStockMaximo.FieldName = "StockMaximo";
            this.colStockMaximo.Name = "colStockMaximo";
            this.colStockMaximo.Visible = true;
            this.colStockMaximo.VisibleIndex = 9;
            this.colStockMaximo.Width = 60;
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
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 41;
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
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 59;
            // 
            // colId_Especie
            // 
            this.colId_Especie.Caption = "Id_Especie";
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colEspecie
            // 
            this.colEspecie.Caption = "Especie";
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.Caption = "Importe Costo";
            this.colImporteCosto.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            // 
            // colGanancia
            // 
            this.colGanancia.Caption = "Ganancia";
            this.colGanancia.FieldName = "Ganacia";
            this.colGanancia.Name = "colGanancia";
            this.colGanancia.Visible = true;
            this.colGanancia.VisibleIndex = 10;
            this.colGanancia.Width = 59;
            // 
            // colId_Categoria2
            // 
            this.colId_Categoria2.Caption = "Id_Categoria2";
            this.colId_Categoria2.FieldName = "Id_Categoria2";
            this.colId_Categoria2.Name = "colId_Categoria2";
            // 
            // colCategoria2
            // 
            this.colCategoria2.Caption = "Categoria2";
            this.colCategoria2.FieldName = "Categoria2";
            this.colCategoria2.Name = "colCategoria2";
            // 
            // colFechaActualizacionCosto
            // 
            this.colFechaActualizacionCosto.Caption = "Actualización Costo";
            this.colFechaActualizacionCosto.DisplayFormat.FormatString = "g";
            this.colFechaActualizacionCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaActualizacionCosto.FieldName = "FechaActualizacionCosto";
            this.colFechaActualizacionCosto.Name = "colFechaActualizacionCosto";
            // 
            // colUnidadCompra
            // 
            this.colUnidadCompra.Caption = "Unidad Compra";
            this.colUnidadCompra.FieldName = "UnidadCompra";
            this.colUnidadCompra.Name = "colUnidadCompra";
            // 
            // colId_UnidadCompra
            // 
            this.colId_UnidadCompra.Caption = "Id_Unidad Compra";
            this.colId_UnidadCompra.FieldName = "Id_UnidadCompra";
            this.colId_UnidadCompra.Name = "colId_UnidadCompra";
            // 
            // colEquivalencia
            // 
            this.colEquivalencia.Caption = "Equivalencia";
            this.colEquivalencia.FieldName = "Equivalencia";
            this.colEquivalencia.Name = "colEquivalencia";
            // 
            // colImporteOriginal
            // 
            this.colImporteOriginal.Caption = "Importe Original";
            this.colImporteOriginal.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteOriginal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteOriginal.FieldName = "ImporteOriginal";
            this.colImporteOriginal.Name = "colImporteOriginal";
            // 
            // colEspecieOriginal
            // 
            this.colEspecieOriginal.Caption = "Especie Original";
            this.colEspecieOriginal.FieldName = "EspecieOriginal";
            this.colEspecieOriginal.Name = "colEspecieOriginal";
            // 
            // colId_EspecieOriginal
            // 
            this.colId_EspecieOriginal.Caption = "Id_EspecieOriginal";
            this.colId_EspecieOriginal.FieldName = "Id_EspecieOriginal";
            this.colId_EspecieOriginal.Name = "colId_EspecieOriginal";
            // 
            // colId_EspecieCosto
            // 
            this.colId_EspecieCosto.Caption = "Id_EspecieCosto";
            this.colId_EspecieCosto.FieldName = "Id_EspecieCosto";
            this.colId_EspecieCosto.Name = "colId_EspecieCosto";
            this.colId_EspecieCosto.OptionsColumn.AllowEdit = false;
            // 
            // colId_UnidadStock
            // 
            this.colId_UnidadStock.Caption = "Id_UnidadStock";
            this.colId_UnidadStock.FieldName = "Id_UnidadStock";
            this.colId_UnidadStock.Name = "colId_UnidadStock";
            this.colId_UnidadStock.OptionsColumn.AllowEdit = false;
            // 
            // colUnidadStock
            // 
            this.colUnidadStock.Caption = "Unidad Stock";
            this.colUnidadStock.FieldName = "UnidadStock";
            this.colUnidadStock.Name = "colUnidadStock";
            this.colUnidadStock.OptionsColumn.AllowEdit = false;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(125, 276);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(292, 154);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupCount = 1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Alicuota";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 44;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Categoría";
            this.gridColumn2.FieldName = "Categoria";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "UnidadVenta";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 58;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Código";
            this.gridColumn4.FieldName = "Codigo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 57;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "C.Fábrica";
            this.gridColumn5.FieldName = "CodigoFabrica";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 52;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Producto";
            this.gridColumn6.FieldName = "Descripcion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 159;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "Id_IvaAlicuota";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "Id_Categoria";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "Id_UnidadVenta";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Código Barras";
            this.gridColumn10.FieldName = "CodigoBarras";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "S. Mínimo";
            this.gridColumn11.FieldName = "StockMinimo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "S. Máximo";
            this.gridColumn12.FieldName = "StockMaximo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 60;
            // 
            // gridColumn13
            // 
            this.gridColumn13.FieldName = "Observaciones";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn14
            // 
            this.gridColumn14.FieldName = "Id";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 41;
            // 
            // gridColumn15
            // 
            this.gridColumn15.FieldName = "FechaAdd";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // gridColumn16
            // 
            this.gridColumn16.FieldName = "FechaMod";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn17
            // 
            this.gridColumn17.FieldName = "UserAdd";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn18
            // 
            this.gridColumn18.FieldName = "UserMod";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Importe";
            this.gridColumn19.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "Importe";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 59;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Id_Especie";
            this.gridColumn20.FieldName = "Id_Especie";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Especie";
            this.gridColumn21.FieldName = "Especie";
            this.gridColumn21.Name = "gridColumn21";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Importe Costo";
            this.gridColumn22.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "ImporteCosto";
            this.gridColumn22.Name = "gridColumn22";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Ganancia";
            this.gridColumn23.FieldName = "Ganacia";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 59;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Id_Categoria2";
            this.gridColumn24.FieldName = "Id_Categoria2";
            this.gridColumn24.Name = "gridColumn24";
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Categoria2";
            this.gridColumn25.FieldName = "Categoria2";
            this.gridColumn25.Name = "gridColumn25";
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MinimumSize = new System.Drawing.Size(613, 245);
            this.Name = "frmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigoBarrasTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoFabricaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private System.Windows.Forms.BindingSource productosManager_ParametrosBusquedasBindingSource;
        private System.Windows.Forms.BindingSource productosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_IvaAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMinimo;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMaximo;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.TextEdit codigoBarrasTextEdit;
        private DevExpress.XtraEditors.TextEdit codigoFabricaTextEdit;
        private DevExpress.XtraEditors.TextEdit codigoTextEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colGanancia;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnHistorialPrecios;
        private DevExpress.XtraBars.BarButtonItem btnStock;
        private DevExpress.XtraBars.BarButtonItem btnMovimientos;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria2;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria2;
        private DevExpress.XtraBars.BarButtonItem btnListaPrecios;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraBars.BarButtonItem btnProductosSinVentas;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnctualizaPrecios;
        private DevExpress.XtraBars.BarButtonItem btnComposicion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaActualizacionCosto;
        private DevExpress.XtraBars.BarButtonItem btnActualizacionCostos;
        private DevExpress.XtraBars.BarButtonItem btnComposicionTodos;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colEquivalencia;
        private DevExpress.XtraBars.BarButtonItem btnActualizaCostoCompra;
        private DevExpress.XtraBars.BarButtonItem btnImagenes;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecieOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EspecieOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EspecieCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_UnidadStock;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadStock;
        private DevExpress.XtraBars.BarButtonItem btnActualizaExcelVenta;
        private DevExpress.XtraBars.BarButtonItem btnActualizaExcelCosto;
        private DevExpress.XtraBars.BarButtonItem btnGenerarExcel;
    }
}