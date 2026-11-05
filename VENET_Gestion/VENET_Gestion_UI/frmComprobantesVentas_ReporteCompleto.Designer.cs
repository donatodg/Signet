namespace VENET_Gestion_UI
{
    partial class frmComprobantesVentas_ReporteCompleto
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
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            System.Windows.Forms.Label soloGeneraDeudaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.soloGeneraDeudaCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDeposito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Deposito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TalonariosComprobantes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_FormaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_EntidadDomicilioEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntregado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaImpreso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercepcionIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtrosImpuestos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetenciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercepcionIIBB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaLiquidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAFIPCAE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultadoCAE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVtoCAE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacionesCAE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventosCAE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobanteVenta_Procesado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobanteVenta_Anulado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePesos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuitEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            soloGeneraDeudaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soloGeneraDeudaCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(32, 9);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 0;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(259, 9);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(65, 13);
            id_TipoComprobanteLabel.TabIndex = 2;
            id_TipoComprobanteLabel.Text = "Tipo Comp.:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(11, 35);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 4;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(285, 35);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(39, 13);
            fechaHastaLabel.TabIndex = 6;
            fechaHastaLabel.Text = "Hasta:";
            // 
            // soloGeneraDeudaLabel
            // 
            soloGeneraDeudaLabel.AutoSize = true;
            soloGeneraDeudaLabel.Location = new System.Drawing.Point(499, 9);
            soloGeneraDeudaLabel.Name = "soloGeneraDeudaLabel";
            soloGeneraDeudaLabel.Size = new System.Drawing.Size(103, 13);
            soloGeneraDeudaLabel.TabIndex = 9;
            soloGeneraDeudaLabel.Text = "Solo Genera Deuda:";
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
            this.barSubItem1,
            this.btnResultado});
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
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 2;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(soloGeneraDeudaLabel);
            this.panelControl1.Controls.Add(this.soloGeneraDeudaCheckEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(id_TipoComprobanteLabel);
            this.panelControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.panelControl1.Controls.Add(id_EmpresaLabel);
            this.panelControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 58);
            this.panelControl1.TabIndex = 4;
            // 
            // soloGeneraDeudaCheckEdit
            // 
            this.soloGeneraDeudaCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource, "SoloGeneraDeuda", true));
            this.soloGeneraDeudaCheckEdit.Location = new System.Drawing.Point(608, 6);
            this.soloGeneraDeudaCheckEdit.MenuManager = this.barManager1;
            this.soloGeneraDeudaCheckEdit.Name = "soloGeneraDeudaCheckEdit";
            this.soloGeneraDeudaCheckEdit.Properties.Caption = "";
            this.soloGeneraDeudaCheckEdit.Size = new System.Drawing.Size(21, 19);
            this.soloGeneraDeudaCheckEdit.TabIndex = 10;
            this.soloGeneraDeudaCheckEdit.CheckStateChanged += new System.EventHandler(this.soloGeneraDeudaCheckEdit_CheckStateChanged);
            // 
            // comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource
            // 
            this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesVentas_ReporteCompletoManager.ParametrosBusquedas);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.EnterMoveNextControl = true;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(330, 32);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 3;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.EnterMoveNextControl = true;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(90, 32);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 2;
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource, "Id_TipoComprobante", true));
            this.id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(330, 6);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(163, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 1;
            this.id_TipoComprobanteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_TipoComprobanteLookUpEdit_ButtonPressed);
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource, "Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(90, 6);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_TipoComprobanteLookUpEdit_ButtonPressed);
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(163, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 82);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 354);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource
            // 
            this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesVentas_ReporteCompletoManager.SearchResult);
            this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDeposito,
            this.colSucursal,
            this.colCentroCosto,
            this.colTipoComprobante,
            this.colNombreEntidad,
            this.colVendedor,
            this.colFormaPago,
            this.colEspecie,
            this.colCotizacion,
            this.colId_Producto,
            this.colProducto,
            this.colCategoria,
            this.colCantidad,
            this.colImporteCosto,
            this.colPorcDescuento,
            this.colImporteUnitario,
            this.colId_AlicuotaIva,
            this.colAlicuotaIva,
            this.colImporteIva,
            this.colImporteProducto,
            this.colCodigo,
            this.colCodigoBarras,
            this.colCodigoFabrica,
            this.colId_Deposito,
            this.colId_Sucursal,
            this.colId_CentroCosto,
            this.colId_TipoComprobante,
            this.colId_TalonariosComprobantes,
            this.colLetra,
            this.colPuntoVenta,
            this.colNroComprobante,
            this.colId_TipoEntidad,
            this.colId_Entidad,
            this.colId_Vendedor,
            this.colId_FormaPago,
            this.colId_EntidadDomicilioEntrega,
            this.colFecha,
            this.colFechaEntrega,
            this.colFechaEntregado,
            this.colFechaVto,
            this.colFechaImpreso,
            this.colObservaciones,
            this.colPercepcionIva,
            this.colOtrosImpuestos,
            this.colRetenciones,
            this.colPercepcionIIBB,
            this.colFechaLiquidacion,
            this.colAFIPCAE,
            this.colResultadoCAE,
            this.colFechaVtoCAE,
            this.colObservacionesCAE,
            this.colEventosCAE,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colId_ComprobanteVenta_Procesado,
            this.colId_ComprobanteVenta_Anulado,
            this.colImporte,
            this.colImportePesos,
            this.colDetalle,
            this.colComprobante,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel,
            this.colCuitEntidad,
            this.colCantidadStock,
            this.colEmpresa});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", this.colCantidad, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", this.colImporte, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteCosto", this.colImporteCosto, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", this.colImporteIva, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteCosto", this.colImporteCosto, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImportePesos", this.colImportePesos, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteUnitario", this.colImporteUnitario, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OtrosImpuestos", this.colOtrosImpuestos, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PercepcionIIBB", this.colPercepcionIIBB, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PercepcionIva", this.colPercepcionIva, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorcDescuento", this.colPorcDescuento, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retenciones", this.colRetenciones, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteProducto", this.colImporteProducto, "{0:N2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colDeposito
            // 
            this.colDeposito.FieldName = "Deposito";
            this.colDeposito.Name = "colDeposito";
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            // 
            // colCentroCosto
            // 
            this.colCentroCosto.FieldName = "CentroCosto";
            this.colCentroCosto.Name = "colCentroCosto";
            // 
            // colTipoComprobante
            // 
            this.colTipoComprobante.FieldName = "TipoComprobante";
            this.colTipoComprobante.Name = "colTipoComprobante";
            this.colTipoComprobante.Visible = true;
            this.colTipoComprobante.VisibleIndex = 1;
            // 
            // colNombreEntidad
            // 
            this.colNombreEntidad.FieldName = "NombreEntidad";
            this.colNombreEntidad.Name = "colNombreEntidad";
            this.colNombreEntidad.Visible = true;
            this.colNombreEntidad.VisibleIndex = 6;
            // 
            // colVendedor
            // 
            this.colVendedor.FieldName = "Vendedor";
            this.colVendedor.Name = "colVendedor";
            // 
            // colFormaPago
            // 
            this.colFormaPago.FieldName = "FormaPago";
            this.colFormaPago.Name = "colFormaPago";
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colCotizacion
            // 
            this.colCotizacion.FieldName = "Cotizacion";
            this.colCotizacion.Name = "colCotizacion";
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
            this.colProducto.VisibleIndex = 9;
            // 
            // colCategoria
            // 
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            // 
            // colCantidad
            // 
            this.colCantidad.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N2}")});
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 8;
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            this.colImporteCosto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteCosto", "{0:N2}")});
            // 
            // colPorcDescuento
            // 
            this.colPorcDescuento.DisplayFormat.FormatString = "#,##0.00";
            this.colPorcDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPorcDescuento.FieldName = "PorcDescuento";
            this.colPorcDescuento.Name = "colPorcDescuento";
            this.colPorcDescuento.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorcDescuento", "{0:N2}")});
            this.colPorcDescuento.Visible = true;
            this.colPorcDescuento.VisibleIndex = 11;
            // 
            // colImporteUnitario
            // 
            this.colImporteUnitario.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitario.FieldName = "ImporteUnitario";
            this.colImporteUnitario.Name = "colImporteUnitario";
            this.colImporteUnitario.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteUnitario", "{0:N2}")});
            this.colImporteUnitario.Visible = true;
            this.colImporteUnitario.VisibleIndex = 10;
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
            this.colAlicuotaIva.VisibleIndex = 12;
            // 
            // colImporteIva
            // 
            this.colImporteIva.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteIva.FieldName = "ImporteIva";
            this.colImporteIva.Name = "colImporteIva";
            this.colImporteIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:N2}")});
            this.colImporteIva.Visible = true;
            this.colImporteIva.VisibleIndex = 13;
            // 
            // colImporteProducto
            // 
            this.colImporteProducto.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteProducto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteProducto.FieldName = "ImporteProducto";
            this.colImporteProducto.Name = "colImporteProducto";
            this.colImporteProducto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteProducto", "{0:N2}")});
            this.colImporteProducto.Visible = true;
            this.colImporteProducto.VisibleIndex = 18;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            // 
            // colId_Deposito
            // 
            this.colId_Deposito.FieldName = "Id_Deposito";
            this.colId_Deposito.Name = "colId_Deposito";
            // 
            // colId_Sucursal
            // 
            this.colId_Sucursal.FieldName = "Id_Sucursal";
            this.colId_Sucursal.Name = "colId_Sucursal";
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            // 
            // colId_TipoComprobante
            // 
            this.colId_TipoComprobante.FieldName = "Id_TipoComprobante";
            this.colId_TipoComprobante.Name = "colId_TipoComprobante";
            // 
            // colId_TalonariosComprobantes
            // 
            this.colId_TalonariosComprobantes.FieldName = "Id_TalonariosComprobantes";
            this.colId_TalonariosComprobantes.Name = "colId_TalonariosComprobantes";
            // 
            // colLetra
            // 
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            this.colLetra.Visible = true;
            this.colLetra.VisibleIndex = 2;
            // 
            // colPuntoVenta
            // 
            this.colPuntoVenta.FieldName = "PuntoVenta";
            this.colPuntoVenta.Name = "colPuntoVenta";
            this.colPuntoVenta.Visible = true;
            this.colPuntoVenta.VisibleIndex = 3;
            // 
            // colNroComprobante
            // 
            this.colNroComprobante.FieldName = "NroComprobante";
            this.colNroComprobante.Name = "colNroComprobante";
            this.colNroComprobante.Visible = true;
            this.colNroComprobante.VisibleIndex = 4;
            // 
            // colId_TipoEntidad
            // 
            this.colId_TipoEntidad.FieldName = "Id_TipoEntidad";
            this.colId_TipoEntidad.Name = "colId_TipoEntidad";
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.Caption = "Entidad";
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            // 
            // colId_Vendedor
            // 
            this.colId_Vendedor.FieldName = "Id_Vendedor";
            this.colId_Vendedor.Name = "colId_Vendedor";
            // 
            // colId_FormaPago
            // 
            this.colId_FormaPago.FieldName = "Id_FormaPago";
            this.colId_FormaPago.Name = "colId_FormaPago";
            // 
            // colId_EntidadDomicilioEntrega
            // 
            this.colId_EntidadDomicilioEntrega.FieldName = "Id_EntidadDomicilioEntrega";
            this.colId_EntidadDomicilioEntrega.Name = "colId_EntidadDomicilioEntrega";
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "{0}")});
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colFechaEntrega
            // 
            this.colFechaEntrega.FieldName = "FechaEntrega";
            this.colFechaEntrega.Name = "colFechaEntrega";
            // 
            // colFechaEntregado
            // 
            this.colFechaEntregado.FieldName = "FechaEntregado";
            this.colFechaEntregado.Name = "colFechaEntregado";
            // 
            // colFechaVto
            // 
            this.colFechaVto.FieldName = "FechaVto";
            this.colFechaVto.Name = "colFechaVto";
            // 
            // colFechaImpreso
            // 
            this.colFechaImpreso.FieldName = "FechaImpreso";
            this.colFechaImpreso.Name = "colFechaImpreso";
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // colPercepcionIva
            // 
            this.colPercepcionIva.DisplayFormat.FormatString = "#,##0.00";
            this.colPercepcionIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercepcionIva.FieldName = "PercepcionIva";
            this.colPercepcionIva.Name = "colPercepcionIva";
            this.colPercepcionIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PercepcionIva", "{0:N2}")});
            this.colPercepcionIva.Visible = true;
            this.colPercepcionIva.VisibleIndex = 14;
            // 
            // colOtrosImpuestos
            // 
            this.colOtrosImpuestos.DisplayFormat.FormatString = "#,##0.00";
            this.colOtrosImpuestos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtrosImpuestos.FieldName = "OtrosImpuestos";
            this.colOtrosImpuestos.Name = "colOtrosImpuestos";
            this.colOtrosImpuestos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OtrosImpuestos", "{0:N2}")});
            this.colOtrosImpuestos.Visible = true;
            this.colOtrosImpuestos.VisibleIndex = 15;
            // 
            // colRetenciones
            // 
            this.colRetenciones.Caption = "Percepciones";
            this.colRetenciones.DisplayFormat.FormatString = "#,##0.00";
            this.colRetenciones.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRetenciones.FieldName = "Retenciones";
            this.colRetenciones.Name = "colRetenciones";
            this.colRetenciones.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retenciones", "{0:N2}")});
            this.colRetenciones.Visible = true;
            this.colRetenciones.VisibleIndex = 16;
            // 
            // colPercepcionIIBB
            // 
            this.colPercepcionIIBB.DisplayFormat.FormatString = "#,##0.00";
            this.colPercepcionIIBB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercepcionIIBB.FieldName = "PercepcionIIBB";
            this.colPercepcionIIBB.Name = "colPercepcionIIBB";
            this.colPercepcionIIBB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PercepcionIIBB", "{0:N2}")});
            this.colPercepcionIIBB.Visible = true;
            this.colPercepcionIIBB.VisibleIndex = 17;
            // 
            // colFechaLiquidacion
            // 
            this.colFechaLiquidacion.FieldName = "FechaLiquidacion";
            this.colFechaLiquidacion.Name = "colFechaLiquidacion";
            // 
            // colAFIPCAE
            // 
            this.colAFIPCAE.FieldName = "AFIPCAE";
            this.colAFIPCAE.Name = "colAFIPCAE";
            // 
            // colResultadoCAE
            // 
            this.colResultadoCAE.FieldName = "ResultadoCAE";
            this.colResultadoCAE.Name = "colResultadoCAE";
            // 
            // colFechaVtoCAE
            // 
            this.colFechaVtoCAE.FieldName = "FechaVtoCAE";
            this.colFechaVtoCAE.Name = "colFechaVtoCAE";
            // 
            // colObservacionesCAE
            // 
            this.colObservacionesCAE.FieldName = "ObservacionesCAE";
            this.colObservacionesCAE.Name = "colObservacionesCAE";
            // 
            // colEventosCAE
            // 
            this.colEventosCAE.FieldName = "EventosCAE";
            this.colEventosCAE.Name = "colEventosCAE";
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // colId_ComprobanteVenta_Procesado
            // 
            this.colId_ComprobanteVenta_Procesado.FieldName = "Id_ComprobanteVenta_Procesado";
            this.colId_ComprobanteVenta_Procesado.Name = "colId_ComprobanteVenta_Procesado";
            // 
            // colId_ComprobanteVenta_Anulado
            // 
            this.colId_ComprobanteVenta_Anulado.FieldName = "Id_ComprobanteVenta_Anulado";
            this.colId_ComprobanteVenta_Anulado.Name = "colId_ComprobanteVenta_Anulado";
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 7;
            // 
            // colImportePesos
            // 
            this.colImportePesos.DisplayFormat.FormatString = "#,##0.00";
            this.colImportePesos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportePesos.FieldName = "ImportePesos";
            this.colImportePesos.Name = "colImportePesos";
            this.colImportePesos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImportePesos", "{0:N2}")});
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.ReadOnly = true;
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
            // colFechaDel
            // 
            this.colFechaDel.FieldName = "FechaDel";
            this.colFechaDel.Name = "colFechaDel";
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
            // colUserDel
            // 
            this.colUserDel.FieldName = "UserDel";
            this.colUserDel.Name = "colUserDel";
            // 
            // colCuitEntidad
            // 
            this.colCuitEntidad.Caption = "Cuit Entidad";
            this.colCuitEntidad.FieldName = "CuitEntidad";
            this.colCuitEntidad.Name = "colCuitEntidad";
            this.colCuitEntidad.Visible = true;
            this.colCuitEntidad.VisibleIndex = 5;
            // 
            // colCantidadStock
            // 
            this.colCantidadStock.Caption = "Cant. Stock";
            this.colCantidadStock.FieldName = "CantidadStock";
            this.colCantidadStock.Name = "colCantidadStock";
            this.colCantidadStock.OptionsColumn.AllowEdit = false;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            // 
            // frmComprobantesVentas_ReporteCompleto
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
            this.MinimumSize = new System.Drawing.Size(654, 270);
            this.Name = "frmComprobantesVentas_ReporteCompleto";
            this.Text = "Reporte Completo de Comprobantes de Ventas";
            this.Load += new System.EventHandler(this.frmComprobantesVentas_ReporteCompleto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soloGeneraDeudaCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource comprobantesVentas_ReporteCompletoManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeposito;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colVendedor;
        private DevExpress.XtraGrid.Columns.GridColumn colFormaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Deposito;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TalonariosComprobantes;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colNroComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn colId_FormaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EntidadDomicilioEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntregado;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVto;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaImpreso;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colPercepcionIva;
        private DevExpress.XtraGrid.Columns.GridColumn colOtrosImpuestos;
        private DevExpress.XtraGrid.Columns.GridColumn colRetenciones;
        private DevExpress.XtraGrid.Columns.GridColumn colPercepcionIIBB;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaLiquidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colAFIPCAE;
        private DevExpress.XtraGrid.Columns.GridColumn colResultadoCAE;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVtoCAE;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacionesCAE;
        private DevExpress.XtraGrid.Columns.GridColumn colEventosCAE;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteVenta_Procesado;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteVenta_Anulado;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePesos;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource comprobantesVentas_ReporteCompletoManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.CheckEdit soloGeneraDeudaCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCuitEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadStock;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
    }
}