namespace VENET_Produccion_UI
{
    partial class frmProduccion
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
            System.Windows.Forms.Label id_MedidaLabel;
            System.Windows.Forms.Label id_VarianteLabel;
            System.Windows.Forms.Label id_LineaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnCopiarMedidas = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopiarVariantePorMedida = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAgregarComp = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregarTarea = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_LineaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.produccionManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_VarianteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_MedidaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.produccionManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedidaAncho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedidaAlto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Linea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Variante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Medida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnchos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncidencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostoActualizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperacionAltos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltosAjuste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperacionAnchos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnchosAjuste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProductoDerivado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoDerivado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadProdDerivado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpComposicion = new DevExpress.XtraTab.XtraTabPage();
            this.xtpTareas = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.produccionManager_SearchResultTareasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVariante1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManoObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Variante1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Medida1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Tarea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ManoObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedida1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidades = new DevExpress.XtraGrid.Columns.GridColumn();
            id_MedidaLabel = new System.Windows.Forms.Label();
            id_VarianteLabel = new System.Windows.Forms.Label();
            id_LineaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_MedidaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpComposicion.SuspendLayout();
            this.xtpTareas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_SearchResultTareasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // id_MedidaLabel
            // 
            id_MedidaLabel.AutoSize = true;
            id_MedidaLabel.Location = new System.Drawing.Point(424, 10);
            id_MedidaLabel.Name = "id_MedidaLabel";
            id_MedidaLabel.Size = new System.Drawing.Size(45, 13);
            id_MedidaLabel.TabIndex = 6;
            id_MedidaLabel.Text = "Medida:";
            // 
            // id_VarianteLabel
            // 
            id_VarianteLabel.AutoSize = true;
            id_VarianteLabel.Location = new System.Drawing.Point(211, 10);
            id_VarianteLabel.Name = "id_VarianteLabel";
            id_VarianteLabel.Size = new System.Drawing.Size(51, 13);
            id_VarianteLabel.TabIndex = 7;
            id_VarianteLabel.Text = "Variante:";
            // 
            // id_LineaLabel
            // 
            id_LineaLabel.AutoSize = true;
            id_LineaLabel.Location = new System.Drawing.Point(13, 10);
            id_LineaLabel.Name = "id_LineaLabel";
            id_LineaLabel.Size = new System.Drawing.Size(36, 13);
            id_LineaLabel.TabIndex = 8;
            id_LineaLabel.Text = "Línea:";
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
            this.btnCopiarMedidas,
            this.btnAgregarComp,
            this.btnAgregarTarea,
            this.btnCopiarVariantePorMedida});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
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
            this.btnAgregar.Glyph = global::VENET_Produccion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Produccion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 2;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Produccion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 3;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Produccion_UI.Properties.Resources.print_16x16;
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Produccion_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopiarMedidas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopiarVariantePorMedida, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnCopiarMedidas
            // 
            this.btnCopiarMedidas.Caption = "Copiar Medida en Otras Medidas";
            this.btnCopiarMedidas.Id = 7;
            this.btnCopiarMedidas.Name = "btnCopiarMedidas";
            this.btnCopiarMedidas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopiarMedidas_ItemClick);
            // 
            // btnCopiarVariantePorMedida
            // 
            this.btnCopiarVariantePorMedida.Caption = "Copiar Variantes Según Medida";
            this.btnCopiarVariantePorMedida.Id = 14;
            this.btnCopiarVariantePorMedida.Name = "btnCopiarVariantePorMedida";
            this.btnCopiarVariantePorMedida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopiarVariantePorMedida_ItemClick);
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
            // btnAgregarComp
            // 
            this.btnAgregarComp.Caption = "Composición";
            this.btnAgregarComp.Id = 10;
            this.btnAgregarComp.Name = "btnAgregarComp";
            // 
            // btnAgregarTarea
            // 
            this.btnAgregarTarea.Caption = "Tarea";
            this.btnAgregarTarea.Id = 13;
            this.btnAgregarTarea.Name = "btnAgregarTarea";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_LineaLabel);
            this.panelControl1.Controls.Add(this.id_LineaLookUpEdit);
            this.panelControl1.Controls.Add(id_VarianteLabel);
            this.panelControl1.Controls.Add(this.id_VarianteLookUpEdit);
            this.panelControl1.Controls.Add(id_MedidaLabel);
            this.panelControl1.Controls.Add(this.id_MedidaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 32);
            this.panelControl1.TabIndex = 4;
            // 
            // id_LineaLookUpEdit
            // 
            this.id_LineaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManager_ParametrosBusquedasBindingSource, "Id_Linea", true));
            this.id_LineaLookUpEdit.EnterMoveNextControl = true;
            this.id_LineaLookUpEdit.Location = new System.Drawing.Point(55, 7);
            this.id_LineaLookUpEdit.MenuManager = this.barManager1;
            this.id_LineaLookUpEdit.Name = "id_LineaLookUpEdit";
            this.id_LineaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_LineaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Línea"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", 10, "Empresa")});
            this.id_LineaLookUpEdit.Properties.NullText = "";
            this.id_LineaLookUpEdit.Properties.PopupWidth = 620;
            this.id_LineaLookUpEdit.Size = new System.Drawing.Size(150, 20);
            this.id_LineaLookUpEdit.TabIndex = 0;
            this.id_LineaLookUpEdit.EditValueChanged += new System.EventHandler(this.id_LineaLookUpEdit_EditValueChanged);
            // 
            // produccionManager_ParametrosBusquedasBindingSource
            // 
            this.produccionManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionManager.ParametrosBusquedas);
            // 
            // id_VarianteLookUpEdit
            // 
            this.id_VarianteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManager_ParametrosBusquedasBindingSource, "Id_Variante", true));
            this.id_VarianteLookUpEdit.EnterMoveNextControl = true;
            this.id_VarianteLookUpEdit.Location = new System.Drawing.Point(268, 7);
            this.id_VarianteLookUpEdit.MenuManager = this.barManager1;
            this.id_VarianteLookUpEdit.Name = "id_VarianteLookUpEdit";
            this.id_VarianteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_VarianteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Variante")});
            this.id_VarianteLookUpEdit.Properties.NullText = "";
            this.id_VarianteLookUpEdit.Properties.ShowHeader = false;
            this.id_VarianteLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_VarianteLookUpEdit.Size = new System.Drawing.Size(150, 20);
            this.id_VarianteLookUpEdit.TabIndex = 1;
            this.id_VarianteLookUpEdit.EditValueChanged += new System.EventHandler(this.id_VarianteLookUpEdit_EditValueChanged);
            // 
            // id_MedidaLookUpEdit
            // 
            this.id_MedidaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionManager_ParametrosBusquedasBindingSource, "Id_Medida", true));
            this.id_MedidaLookUpEdit.EnterMoveNextControl = true;
            this.id_MedidaLookUpEdit.Location = new System.Drawing.Point(475, 7);
            this.id_MedidaLookUpEdit.MenuManager = this.barManager1;
            this.id_MedidaLookUpEdit.Name = "id_MedidaLookUpEdit";
            this.id_MedidaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_MedidaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_MedidaLookUpEdit.Properties.NullText = "";
            this.id_MedidaLookUpEdit.Properties.ShowHeader = false;
            this.id_MedidaLookUpEdit.Size = new System.Drawing.Size(150, 20);
            this.id_MedidaLookUpEdit.TabIndex = 2;
            this.id_MedidaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.produccionManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(728, 352);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // produccionManager_SearchResultBindingSource
            // 
            this.produccionManager_SearchResultBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionManager.SearchResult);
            this.produccionManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.produccionManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLinea,
            this.colVariante,
            this.colMedida,
            this.colMedidaAncho,
            this.colMedidaAlto,
            this.colImporteCosto,
            this.colTotal,
            this.colId_Linea,
            this.colId_Variante,
            this.colId_Medida,
            this.colId_Producto,
            this.colProducto,
            this.colCantidad,
            this.colAltos,
            this.colAnchos,
            this.colOperacion,
            this.colIncidencia,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colCostoActualizacion,
            this.colCategoria,
            this.colOperacionAltos,
            this.colAltosAjuste,
            this.colOperacionAnchos,
            this.colAnchosAjuste,
            this.colProductoFinal,
            this.colId_ProductoDerivado,
            this.colProductoDerivado,
            this.colCantidadProdDerivado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", this.colTotal, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Producto", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMedida, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colLinea
            // 
            this.colLinea.FieldName = "Linea";
            this.colLinea.Name = "colLinea";
            // 
            // colVariante
            // 
            this.colVariante.FieldName = "Variante";
            this.colVariante.Name = "colVariante";
            // 
            // colMedida
            // 
            this.colMedida.FieldName = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.Visible = true;
            this.colMedida.VisibleIndex = 2;
            // 
            // colMedidaAncho
            // 
            this.colMedidaAncho.DisplayFormat.FormatString = "N2";
            this.colMedidaAncho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMedidaAncho.FieldName = "MedidaAncho";
            this.colMedidaAncho.Name = "colMedidaAncho";
            // 
            // colMedidaAlto
            // 
            this.colMedidaAlto.Caption = "Medida Alto";
            this.colMedidaAlto.DisplayFormat.FormatString = "N2";
            this.colMedidaAlto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMedidaAlto.FieldName = "MedidaAlto";
            this.colMedidaAlto.Name = "colMedidaAlto";
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.DisplayFormat.FormatString = "N2";
            this.colImporteCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            this.colImporteCosto.Visible = true;
            this.colImporteCosto.VisibleIndex = 7;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "N2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 8;
            // 
            // colId_Linea
            // 
            this.colId_Linea.FieldName = "Id_Linea";
            this.colId_Linea.Name = "colId_Linea";
            // 
            // colId_Variante
            // 
            this.colId_Variante.FieldName = "Id_Variante";
            this.colId_Variante.Name = "colId_Variante";
            // 
            // colId_Medida
            // 
            this.colId_Medida.FieldName = "Id_Medida";
            this.colId_Medida.Name = "colId_Medida";
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 0;
            // 
            // colCantidad
            // 
            this.colCantidad.DisplayFormat.FormatString = "N2";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            // 
            // colAltos
            // 
            this.colAltos.Caption = "Altos";
            this.colAltos.DisplayFormat.FormatString = "N2";
            this.colAltos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAltos.FieldName = "Altos";
            this.colAltos.Name = "colAltos";
            this.colAltos.Visible = true;
            this.colAltos.VisibleIndex = 3;
            // 
            // colAnchos
            // 
            this.colAnchos.DisplayFormat.FormatString = "N2";
            this.colAnchos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAnchos.FieldName = "Anchos";
            this.colAnchos.Name = "colAnchos";
            this.colAnchos.Visible = true;
            this.colAnchos.VisibleIndex = 5;
            // 
            // colOperacion
            // 
            this.colOperacion.Caption = "Operación";
            this.colOperacion.FieldName = "Operacion";
            this.colOperacion.Name = "colOperacion";
            this.colOperacion.Visible = true;
            this.colOperacion.VisibleIndex = 4;
            // 
            // colIncidencia
            // 
            this.colIncidencia.DisplayFormat.FormatString = "N2";
            this.colIncidencia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncidencia.FieldName = "Incidencia";
            this.colIncidencia.Name = "colIncidencia";
            this.colIncidencia.Visible = true;
            this.colIncidencia.VisibleIndex = 6;
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
            // colCostoActualizacion
            // 
            this.colCostoActualizacion.Caption = "Costo Actualización";
            this.colCostoActualizacion.FieldName = "CostoActualizacion";
            this.colCostoActualizacion.Name = "colCostoActualizacion";
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoría";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            // 
            // colOperacionAltos
            // 
            this.colOperacionAltos.Caption = "Operación Altos";
            this.colOperacionAltos.FieldName = "OperacionAltos";
            this.colOperacionAltos.Name = "colOperacionAltos";
            // 
            // colAltosAjuste
            // 
            this.colAltosAjuste.Caption = "Altos Ajuste";
            this.colAltosAjuste.FieldName = "AltosAjuste";
            this.colAltosAjuste.Name = "colAltosAjuste";
            // 
            // colOperacionAnchos
            // 
            this.colOperacionAnchos.Caption = "Operación Anchos";
            this.colOperacionAnchos.FieldName = "OperacionAnchos";
            this.colOperacionAnchos.Name = "colOperacionAnchos";
            // 
            // colAnchosAjuste
            // 
            this.colAnchosAjuste.Caption = "Anchos Ajuste";
            this.colAnchosAjuste.FieldName = "AnchosAjuste";
            this.colAnchosAjuste.Name = "colAnchosAjuste";
            // 
            // colProductoFinal
            // 
            this.colProductoFinal.Caption = "Producto Final";
            this.colProductoFinal.FieldName = "ProductoFinal";
            this.colProductoFinal.Name = "colProductoFinal";
            this.colProductoFinal.Visible = true;
            this.colProductoFinal.VisibleIndex = 9;
            // 
            // colId_ProductoDerivado
            // 
            this.colId_ProductoDerivado.Caption = "Id_ProductoDerivado";
            this.colId_ProductoDerivado.FieldName = "Id_ProductoDerivado";
            this.colId_ProductoDerivado.Name = "colId_ProductoDerivado";
            // 
            // colProductoDerivado
            // 
            this.colProductoDerivado.Caption = "Prod. Derivado";
            this.colProductoDerivado.FieldName = "ProductoDerivado";
            this.colProductoDerivado.Name = "colProductoDerivado";
            this.colProductoDerivado.Visible = true;
            this.colProductoDerivado.VisibleIndex = 1;
            // 
            // colCantidadProdDerivado
            // 
            this.colCantidadProdDerivado.Caption = "Cant. P. Derivado";
            this.colCantidadProdDerivado.FieldName = "CantidadProdDerivado";
            this.colCantidadProdDerivado.Name = "colCantidadProdDerivado";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 56);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpComposicion;
            this.xtraTabControl1.Size = new System.Drawing.Size(734, 380);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpComposicion,
            this.xtpTareas});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtpComposicion
            // 
            this.xtpComposicion.Controls.Add(this.gridControl1);
            this.xtpComposicion.Name = "xtpComposicion";
            this.xtpComposicion.Size = new System.Drawing.Size(728, 352);
            this.xtpComposicion.Text = "Composición";
            // 
            // xtpTareas
            // 
            this.xtpTareas.Controls.Add(this.gridControl2);
            this.xtpTareas.Name = "xtpTareas";
            this.xtpTareas.Size = new System.Drawing.Size(728, 352);
            this.xtpTareas.Text = "Tareas";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.produccionManager_SearchResultTareasBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(728, 352);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.DoubleClick += new System.EventHandler(this.gridControl2_DoubleClick);
            // 
            // produccionManager_SearchResultTareasBindingSource
            // 
            this.produccionManager_SearchResultTareasBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionManager.SearchResultTareas);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVariante1,
            this.colTarea,
            this.colManoObra,
            this.colPrecioHora,
            this.colCosto,
            this.colId_Variante1,
            this.colId_Medida1,
            this.colId_Tarea,
            this.colId_ManoObra,
            this.colCantidad1,
            this.colHoras,
            this.colId1,
            this.colFechaAdd1,
            this.colFechaMod1,
            this.colUserAdd1,
            this.colUserMod1,
            this.colMedida1,
            this.colUnidades});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupCount = 1;
            this.gridView2.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Costo", this.colCosto, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", this.colCantidad1, "{0:N2}")});
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMedida1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFechaAdd1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colVariante1
            // 
            this.colVariante1.FieldName = "Variante";
            this.colVariante1.Name = "colVariante1";
            // 
            // colTarea
            // 
            this.colTarea.FieldName = "Tarea";
            this.colTarea.Name = "colTarea";
            this.colTarea.Visible = true;
            this.colTarea.VisibleIndex = 0;
            // 
            // colManoObra
            // 
            this.colManoObra.FieldName = "ManoObra";
            this.colManoObra.Name = "colManoObra";
            // 
            // colPrecioHora
            // 
            this.colPrecioHora.DisplayFormat.FormatString = "n2";
            this.colPrecioHora.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioHora.FieldName = "PrecioHora";
            this.colPrecioHora.Name = "colPrecioHora";
            this.colPrecioHora.Visible = true;
            this.colPrecioHora.VisibleIndex = 1;
            // 
            // colCosto
            // 
            this.colCosto.DisplayFormat.FormatString = "n2";
            this.colCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.FieldName = "Costo";
            this.colCosto.Name = "colCosto";
            this.colCosto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Costo", "{0:n2}")});
            this.colCosto.Visible = true;
            this.colCosto.VisibleIndex = 5;
            // 
            // colId_Variante1
            // 
            this.colId_Variante1.FieldName = "Id_Variante";
            this.colId_Variante1.Name = "colId_Variante1";
            // 
            // colId_Medida1
            // 
            this.colId_Medida1.FieldName = "Id_Medida";
            this.colId_Medida1.Name = "colId_Medida1";
            // 
            // colId_Tarea
            // 
            this.colId_Tarea.FieldName = "Id_Tarea";
            this.colId_Tarea.Name = "colId_Tarea";
            // 
            // colId_ManoObra
            // 
            this.colId_ManoObra.FieldName = "Id_ManoObra";
            this.colId_ManoObra.Name = "colId_ManoObra";
            // 
            // colCantidad1
            // 
            this.colCantidad1.DisplayFormat.FormatString = "n2";
            this.colCantidad1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad1.FieldName = "Cantidad";
            this.colCantidad1.Name = "colCantidad1";
            this.colCantidad1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:n2}")});
            this.colCantidad1.Visible = true;
            this.colCantidad1.VisibleIndex = 2;
            // 
            // colHoras
            // 
            this.colHoras.DisplayFormat.FormatString = "t";
            this.colHoras.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHoras.FieldName = "Horas";
            this.colHoras.Name = "colHoras";
            this.colHoras.Visible = true;
            this.colHoras.VisibleIndex = 4;
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            // 
            // colFechaAdd1
            // 
            this.colFechaAdd1.FieldName = "FechaAdd";
            this.colFechaAdd1.Name = "colFechaAdd1";
            // 
            // colFechaMod1
            // 
            this.colFechaMod1.FieldName = "FechaMod";
            this.colFechaMod1.Name = "colFechaMod1";
            // 
            // colUserAdd1
            // 
            this.colUserAdd1.FieldName = "UserAdd";
            this.colUserAdd1.Name = "colUserAdd1";
            // 
            // colUserMod1
            // 
            this.colUserMod1.FieldName = "UserMod";
            this.colUserMod1.Name = "colUserMod1";
            // 
            // colMedida1
            // 
            this.colMedida1.Caption = "Medida";
            this.colMedida1.FieldName = "Medida";
            this.colMedida1.Name = "colMedida1";
            this.colMedida1.Visible = true;
            this.colMedida1.VisibleIndex = 5;
            // 
            // colUnidades
            // 
            this.colUnidades.Caption = "Unidades";
            this.colUnidades.FieldName = "Unidades";
            this.colUnidades.Name = "colUnidades";
            this.colUnidades.Visible = true;
            this.colUnidades.VisibleIndex = 3;
            // 
            // frmProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(541, 252);
            this.Name = "frmProduccion";
            this.Text = "Producción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccion_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_MedidaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpComposicion.ResumeLayout(false);
            this.xtpTareas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionManager_SearchResultTareasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource produccionManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colVariante;
        private DevExpress.XtraGrid.Columns.GridColumn colMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colMedidaAncho;
        private DevExpress.XtraGrid.Columns.GridColumn colMedidaAlto;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Linea;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Variante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Medida;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colAltos;
        private DevExpress.XtraGrid.Columns.GridColumn colAnchos;
        private DevExpress.XtraGrid.Columns.GridColumn colOperacion;
        private DevExpress.XtraGrid.Columns.GridColumn colIncidencia;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.LookUpEdit id_VarianteLookUpEdit;
        private System.Windows.Forms.BindingSource produccionManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_MedidaLookUpEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoActualizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraBars.BarButtonItem btnCopiarMedidas;
        private DevExpress.XtraGrid.Columns.GridColumn colOperacionAltos;
        private DevExpress.XtraGrid.Columns.GridColumn colAltosAjuste;
        private DevExpress.XtraGrid.Columns.GridColumn colOperacionAnchos;
        private DevExpress.XtraGrid.Columns.GridColumn colAnchosAjuste;
        private DevExpress.XtraEditors.LookUpEdit id_LineaLookUpEdit;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtpComposicion;
        private DevExpress.XtraTab.XtraTabPage xtpTareas;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarButtonItem btnAgregarComp;
        private DevExpress.XtraBars.BarButtonItem btnAgregarTarea;
        private System.Windows.Forms.BindingSource produccionManager_SearchResultTareasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colVariante1;
        private DevExpress.XtraGrid.Columns.GridColumn colTarea;
        private DevExpress.XtraGrid.Columns.GridColumn colManoObra;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioHora;
        private DevExpress.XtraGrid.Columns.GridColumn colCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Variante1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Medida1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Tarea;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ManoObra;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad1;
        private DevExpress.XtraGrid.Columns.GridColumn colHoras;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod1;
        private DevExpress.XtraGrid.Columns.GridColumn colMedida1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProductoDerivado;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoDerivado;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadProdDerivado;
        private DevExpress.XtraBars.BarButtonItem btnCopiarVariantePorMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidades;
    }
}