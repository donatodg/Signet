namespace VENET_General_UI
{
    partial class frmTalonariosComprobantes
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
            System.Windows.Forms.Label id_ComprobanteLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.talonariosComprobantesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_PuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpresora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCopias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElectronico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AFIP_Comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.talonariosComprobantesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.id_ComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_ComprobanteLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ComprobanteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ComprobanteLabel
            // 
            id_ComprobanteLabel.AutoSize = true;
            id_ComprobanteLabel.Location = new System.Drawing.Point(274, 9);
            id_ComprobanteLabel.Name = "id_ComprobanteLabel";
            id_ComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            id_ComprobanteLabel.TabIndex = 0;
            id_ComprobanteLabel.Text = "Comprobante:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(12, 9);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 8;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.talonariosComprobantesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 379);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // talonariosComprobantesManager_SearchResultBindingSource
            // 
            this.talonariosComprobantesManager_SearchResultBindingSource.DataSource = typeof(VENET_General_BL.TalonariosComprobantesManager.SearchResult);
            this.talonariosComprobantesManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.talonariosComprobantesManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPuntoVenta,
            this.colEmpresa,
            this.colComprobante,
            this.colTipoComprobante,
            this.colId_Empresa,
            this.colId_Comprobante,
            this.colLetra,
            this.colId_PuntoVenta,
            this.colImpresora,
            this.colCopias,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colSucursal,
            this.colNroCodigo,
            this.colReporte,
            this.colElectronico,
            this.colId_AFIP_Comprobante});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colPuntoVenta
            // 
            this.colPuntoVenta.FieldName = "PuntoVenta";
            this.colPuntoVenta.Name = "colPuntoVenta";
            this.colPuntoVenta.OptionsColumn.AllowEdit = false;
            this.colPuntoVenta.OptionsColumn.ReadOnly = true;
            this.colPuntoVenta.Visible = true;
            this.colPuntoVenta.VisibleIndex = 2;
            this.colPuntoVenta.Width = 98;
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.AllowEdit = false;
            this.colComprobante.OptionsColumn.ReadOnly = true;
            this.colComprobante.Width = 114;
            // 
            // colTipoComprobante
            // 
            this.colTipoComprobante.FieldName = "TipoComprobante";
            this.colTipoComprobante.Name = "colTipoComprobante";
            this.colTipoComprobante.OptionsColumn.AllowEdit = false;
            this.colTipoComprobante.OptionsColumn.ReadOnly = true;
            this.colTipoComprobante.Visible = true;
            this.colTipoComprobante.VisibleIndex = 1;
            this.colTipoComprobante.Width = 135;
            // 
            // colId_Empresa
            // 
            this.colId_Empresa.FieldName = "Id_Empresa";
            this.colId_Empresa.Name = "colId_Empresa";
            this.colId_Empresa.OptionsColumn.AllowEdit = false;
            this.colId_Empresa.OptionsColumn.ReadOnly = true;
            // 
            // colId_Comprobante
            // 
            this.colId_Comprobante.FieldName = "Id_Comprobante";
            this.colId_Comprobante.Name = "colId_Comprobante";
            this.colId_Comprobante.OptionsColumn.AllowEdit = false;
            this.colId_Comprobante.OptionsColumn.ReadOnly = true;
            // 
            // colLetra
            // 
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            this.colLetra.OptionsColumn.AllowEdit = false;
            this.colLetra.OptionsColumn.ReadOnly = true;
            this.colLetra.Visible = true;
            this.colLetra.VisibleIndex = 3;
            this.colLetra.Width = 39;
            // 
            // colId_PuntoVenta
            // 
            this.colId_PuntoVenta.FieldName = "Id_PuntoVenta";
            this.colId_PuntoVenta.Name = "colId_PuntoVenta";
            this.colId_PuntoVenta.OptionsColumn.AllowEdit = false;
            this.colId_PuntoVenta.OptionsColumn.ReadOnly = true;
            // 
            // colImpresora
            // 
            this.colImpresora.FieldName = "Impresora";
            this.colImpresora.Name = "colImpresora";
            this.colImpresora.OptionsColumn.AllowEdit = false;
            this.colImpresora.OptionsColumn.ReadOnly = true;
            this.colImpresora.Visible = true;
            this.colImpresora.VisibleIndex = 4;
            this.colImpresora.Width = 212;
            // 
            // colCopias
            // 
            this.colCopias.FieldName = "Copias";
            this.colCopias.Name = "colCopias";
            this.colCopias.OptionsColumn.AllowEdit = false;
            this.colCopias.OptionsColumn.ReadOnly = true;
            this.colCopias.Visible = true;
            this.colCopias.VisibleIndex = 5;
            this.colCopias.Width = 92;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 48;
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
            // colSucursal
            // 
            this.colSucursal.Caption = "Sucursal";
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.OptionsColumn.AllowEdit = false;
            this.colSucursal.OptionsColumn.ReadOnly = true;
            // 
            // colNroCodigo
            // 
            this.colNroCodigo.Caption = "Nro Código";
            this.colNroCodigo.FieldName = "NroCodigo";
            this.colNroCodigo.Name = "colNroCodigo";
            // 
            // colReporte
            // 
            this.colReporte.Caption = "Reporte";
            this.colReporte.FieldName = "Reporte";
            this.colReporte.Name = "colReporte";
            // 
            // colElectronico
            // 
            this.colElectronico.Caption = "Electrónico";
            this.colElectronico.FieldName = "Electronico";
            this.colElectronico.Name = "colElectronico";
            // 
            // colId_AFIP_Comprobante
            // 
            this.colId_AFIP_Comprobante.Caption = "Id_AFIP_Comprobante";
            this.colId_AFIP_Comprobante.FieldName = "Id_AFIP_Comprobante";
            this.colId_AFIP_Comprobante.Name = "colId_AFIP_Comprobante";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_EmpresaLabel);
            this.panelControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(id_ComprobanteLabel);
            this.panelControl1.Controls.Add(this.id_ComprobanteLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 1;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesManager_ParametrosBusquedasBindingSource, "Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(70, 6);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(198, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // talonariosComprobantesManager_ParametrosBusquedasBindingSource
            // 
            this.talonariosComprobantesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_General_BL.TalonariosComprobantesManager.ParametrosBusquedas);
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
            this.barStaticItemFooter});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
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
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_General_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_General_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_General_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_General_UI.Properties.Resources.print_16x16;
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
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFooter)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // barStaticItemFooter
            // 
            this.barStaticItemFooter.Id = 5;
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
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // id_ComprobanteLookUpEdit
            // 
            this.id_ComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.talonariosComprobantesManager_ParametrosBusquedasBindingSource, "Id_Comprobante", true));
            this.id_ComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.id_ComprobanteLookUpEdit.Location = new System.Drawing.Point(353, 6);
            this.id_ComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_ComprobanteLookUpEdit.Name = "id_ComprobanteLookUpEdit";
            this.id_ComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_ComprobanteLookUpEdit.Properties.NullText = "";
            this.id_ComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_ComprobanteLookUpEdit.Size = new System.Drawing.Size(144, 20);
            this.id_ComprobanteLookUpEdit.TabIndex = 1;
            this.id_ComprobanteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // frmTalonariosComprobantes
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
            this.MinimumSize = new System.Drawing.Size(657, 192);
            this.Name = "frmTalonariosComprobantes";
            this.Text = "Talonarios de Comprobantes";
            this.Load += new System.EventHandler(this.frmTalonariosComprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.talonariosComprobantesManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ComprobanteLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource talonariosComprobantesManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_ComprobanteLookUpEdit;
        private System.Windows.Forms.BindingSource talonariosComprobantesManager_SearchResultBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colId_PuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colImpresora;
        private DevExpress.XtraGrid.Columns.GridColumn colCopias;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colNroCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colReporte;
        private DevExpress.XtraGrid.Columns.GridColumn colElectronico;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AFIP_Comprobante;
    }
}