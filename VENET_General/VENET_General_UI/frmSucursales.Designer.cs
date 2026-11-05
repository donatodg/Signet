namespace VENET_General_UI
{
    partial class frmSucursales
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
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label descripcionLabel;
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSigla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Apertura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Cierre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioPiso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioDpto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnPuntosVentas = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sucursalesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sucursalesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            idLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesManager_ParametrosBusquedasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(11, 10);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(334, 10);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 3;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(148, 10);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 5;
            descripcionLabel.Text = "Descripción:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sucursalesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 379);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpresa,
            this.colId_Empresa,
            this.colDescripcion,
            this.colSigla,
            this.colNumero,
            this.colFecha_Apertura,
            this.colFecha_Cierre,
            this.colDomicilioCalle,
            this.colDomicilioNro,
            this.colDomicilioPiso,
            this.colDomicilioDpto,
            this.colCodPos,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colLocalidad});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 1;
            this.colEmpresa.Width = 124;
            // 
            // colId_Empresa
            // 
            this.colId_Empresa.FieldName = "Id_Empresa";
            this.colId_Empresa.Name = "colId_Empresa";
            this.colId_Empresa.OptionsColumn.AllowEdit = false;
            this.colId_Empresa.OptionsColumn.ReadOnly = true;
            this.colId_Empresa.Width = 65;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 155;
            // 
            // colSigla
            // 
            this.colSigla.FieldName = "Sigla";
            this.colSigla.Name = "colSigla";
            this.colSigla.OptionsColumn.AllowEdit = false;
            this.colSigla.OptionsColumn.ReadOnly = true;
            this.colSigla.Visible = true;
            this.colSigla.VisibleIndex = 3;
            this.colSigla.Width = 53;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.OptionsColumn.ReadOnly = true;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 5;
            this.colNumero.Width = 55;
            // 
            // colFecha_Apertura
            // 
            this.colFecha_Apertura.FieldName = "Fecha_Apertura";
            this.colFecha_Apertura.Name = "colFecha_Apertura";
            this.colFecha_Apertura.OptionsColumn.AllowEdit = false;
            this.colFecha_Apertura.OptionsColumn.ReadOnly = true;
            this.colFecha_Apertura.Width = 61;
            // 
            // colFecha_Cierre
            // 
            this.colFecha_Cierre.FieldName = "Fecha_Cierre";
            this.colFecha_Cierre.Name = "colFecha_Cierre";
            this.colFecha_Cierre.OptionsColumn.AllowEdit = false;
            this.colFecha_Cierre.OptionsColumn.ReadOnly = true;
            this.colFecha_Cierre.Width = 61;
            // 
            // colDomicilioCalle
            // 
            this.colDomicilioCalle.Caption = "Calle";
            this.colDomicilioCalle.FieldName = "DomicilioCalle";
            this.colDomicilioCalle.Name = "colDomicilioCalle";
            this.colDomicilioCalle.OptionsColumn.AllowEdit = false;
            this.colDomicilioCalle.OptionsColumn.ReadOnly = true;
            this.colDomicilioCalle.Visible = true;
            this.colDomicilioCalle.VisibleIndex = 4;
            this.colDomicilioCalle.Width = 100;
            // 
            // colDomicilioNro
            // 
            this.colDomicilioNro.Caption = "Nro";
            this.colDomicilioNro.FieldName = "DomicilioNro";
            this.colDomicilioNro.Name = "colDomicilioNro";
            this.colDomicilioNro.OptionsColumn.AllowEdit = false;
            this.colDomicilioNro.OptionsColumn.ReadOnly = true;
            this.colDomicilioNro.Visible = true;
            this.colDomicilioNro.VisibleIndex = 6;
            this.colDomicilioNro.Width = 45;
            // 
            // colDomicilioPiso
            // 
            this.colDomicilioPiso.Caption = "Piso";
            this.colDomicilioPiso.FieldName = "DomicilioPiso";
            this.colDomicilioPiso.Name = "colDomicilioPiso";
            this.colDomicilioPiso.OptionsColumn.AllowEdit = false;
            this.colDomicilioPiso.OptionsColumn.ReadOnly = true;
            this.colDomicilioPiso.Visible = true;
            this.colDomicilioPiso.VisibleIndex = 7;
            this.colDomicilioPiso.Width = 49;
            // 
            // colDomicilioDpto
            // 
            this.colDomicilioDpto.Caption = "Dpto";
            this.colDomicilioDpto.FieldName = "DomicilioDpto";
            this.colDomicilioDpto.Name = "colDomicilioDpto";
            this.colDomicilioDpto.OptionsColumn.AllowEdit = false;
            this.colDomicilioDpto.OptionsColumn.ReadOnly = true;
            this.colDomicilioDpto.Visible = true;
            this.colDomicilioDpto.VisibleIndex = 8;
            this.colDomicilioDpto.Width = 56;
            // 
            // colCodPos
            // 
            this.colCodPos.Caption = "Cod. Postal";
            this.colCodPos.FieldName = "CodPos";
            this.colCodPos.Name = "colCodPos";
            this.colCodPos.OptionsColumn.AllowEdit = false;
            this.colCodPos.OptionsColumn.ReadOnly = true;
            this.colCodPos.Visible = true;
            this.colCodPos.VisibleIndex = 9;
            this.colCodPos.Width = 67;
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
            this.colId.Width = 62;
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
            // colLocalidad
            // 
            this.colLocalidad.Caption = "Localidad";
            this.colLocalidad.FieldName = "Localidad";
            this.colLocalidad.Name = "colLocalidad";
            this.colLocalidad.OptionsColumn.AllowEdit = false;
            this.colLocalidad.OptionsColumn.ReadOnly = true;
            this.colLocalidad.Visible = true;
            this.colLocalidad.VisibleIndex = 10;
            this.colLocalidad.Width = 87;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(descripcionLabel);
            this.panelControl1.Controls.Add(this.descripcionTextEdit);
            this.panelControl1.Controls.Add(id_EmpresaLabel);
            this.panelControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 2;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sucursalesManager_ParametrosBusquedasBindingSource, "Parametros.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(219, 7);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionTextEdit.TabIndex = 6;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
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
            this.btnImprimir,
            this.btnResultado,
            this.barSubItem1,
            this.btnPuntosVentas});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprimir, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnAgregar.Id = 1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_General_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 2;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_General_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 3;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Glyph = global::VENET_General_UI.Properties.Resources.print_16x16;
            this.btnImprimir.Id = 4;
            this.btnImprimir.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.btnImprimir.Name = "btnImprimir";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Ver";
            this.barSubItem1.Glyph = global::VENET_General_UI.Properties.Resources.info_16x16;
            this.barSubItem1.Id = 6;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPuntosVentas)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnPuntosVentas
            // 
            this.btnPuntosVentas.Caption = "Puntos de Ventas";
            this.btnPuntosVentas.Id = 7;
            this.btnPuntosVentas.Name = "btnPuntosVentas";
            this.btnPuntosVentas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPuntosVentas_ItemClick);
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
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sucursalesManager_ParametrosBusquedasBindingSource, "Parametros.Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(392, 7);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre2")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(147, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 4;
            this.id_EmpresaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sucursalesManager_ParametrosBusquedasBindingSource, "Parametros.Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(38, 7);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 2;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // sucursalesManager_SearchResultBindingSource
            // 
            this.sucursalesManager_SearchResultBindingSource.DataSource = typeof(VENET_General_BL.SucursalesManager.SearchResult);
            // 
            // sucursalesManager_ParametrosBusquedasBindingSource
            // 
            this.sucursalesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_General_BL.SucursalesManager);
            this.sucursalesManager_ParametrosBusquedasBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.sucursalesManager_SearchResultBindingSource_ListChanged);
            // 
            // frmSucursales
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
            this.MinimumSize = new System.Drawing.Size(642, 500);
            this.Name = "frmSucursales";
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.frmSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesManager_ParametrosBusquedasBindingSource)).EndInit();
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
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colSigla;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Apertura;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Cierre;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioNro;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioPiso;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioDpto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPos;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnPuntosVentas;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidad;
        private System.Windows.Forms.BindingSource sucursalesManager_SearchResultBindingSource;
        private System.Windows.Forms.BindingSource sucursalesManager_ParametrosBusquedasBindingSource;
    }
}