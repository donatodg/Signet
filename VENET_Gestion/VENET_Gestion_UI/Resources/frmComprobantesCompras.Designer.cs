namespace VENET_Gestion_UI
{
    partial class frmComprobantesCompras
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
            System.Windows.Forms.Label puntoVentaLabel;
            System.Windows.Forms.Label letraLabel;
            System.Windows.Forms.Label nroComprobanteLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label fecha_Liquidacion_HastaLabel;
            System.Windows.Forms.Label fecha_Liquidacion_DesdeLabel;
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label anuladoLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label fecha_HastaLabel;
            System.Windows.Forms.Label fecha_DesdeLabel;
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnGeneraOP = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.comprobantesComprasManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro_Costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte_Pesos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_FormaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercepcionIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtrosImpuestos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetenciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercepcionIIBB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaLiquidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.puntoVentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.comprobantesComprasManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.letraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroComprobanteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fecha_Liquidacion_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_Liquidacion_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.anuladoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            puntoVentaLabel = new System.Windows.Forms.Label();
            letraLabel = new System.Windows.Forms.Label();
            nroComprobanteLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            fecha_Liquidacion_HastaLabel = new System.Windows.Forms.Label();
            fecha_Liquidacion_DesdeLabel = new System.Windows.Forms.Label();
            conceptoLabel = new System.Windows.Forms.Label();
            anuladoLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // puntoVentaLabel
            // 
            puntoVentaLabel.AutoSize = true;
            puntoVentaLabel.Location = new System.Drawing.Point(202, 52);
            puntoVentaLabel.Name = "puntoVentaLabel";
            puntoVentaLabel.Size = new System.Drawing.Size(70, 13);
            puntoVentaLabel.TabIndex = 18;
            puntoVentaLabel.Text = "Punto Venta:";
            // 
            // letraLabel
            // 
            letraLabel.AutoSize = true;
            letraLabel.Location = new System.Drawing.Point(51, 52);
            letraLabel.Name = "letraLabel";
            letraLabel.Size = new System.Drawing.Size(36, 13);
            letraLabel.TabIndex = 16;
            letraLabel.Text = "Letra:";
            // 
            // nroComprobanteLabel
            // 
            nroComprobanteLabel.AutoSize = true;
            nroComprobanteLabel.Location = new System.Drawing.Point(393, 52);
            nroComprobanteLabel.Name = "nroComprobanteLabel";
            nroComprobanteLabel.Size = new System.Drawing.Size(62, 13);
            nroComprobanteLabel.TabIndex = 2;
            nroComprobanteLabel.Text = "Nro Comp.:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(404, 26);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 14;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(40, 104);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 13;
            label1.Text = "Entidad:";
            // 
            // fecha_Liquidacion_HastaLabel
            // 
            fecha_Liquidacion_HastaLabel.AutoSize = true;
            fecha_Liquidacion_HastaLabel.Location = new System.Drawing.Point(213, 78);
            fecha_Liquidacion_HastaLabel.Name = "fecha_Liquidacion_HastaLabel";
            fecha_Liquidacion_HastaLabel.Size = new System.Drawing.Size(59, 13);
            fecha_Liquidacion_HastaLabel.TabIndex = 8;
            fecha_Liquidacion_HastaLabel.Text = "Liq. Hasta:";
            // 
            // fecha_Liquidacion_DesdeLabel
            // 
            fecha_Liquidacion_DesdeLabel.AutoSize = true;
            fecha_Liquidacion_DesdeLabel.Location = new System.Drawing.Point(26, 78);
            fecha_Liquidacion_DesdeLabel.Name = "fecha_Liquidacion_DesdeLabel";
            fecha_Liquidacion_DesdeLabel.Size = new System.Drawing.Size(61, 13);
            fecha_Liquidacion_DesdeLabel.TabIndex = 6;
            fecha_Liquidacion_DesdeLabel.Text = "Liq. Desde:";
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(211, 26);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(61, 13);
            conceptoLabel.TabIndex = 4;
            conceptoLabel.Text = "Observac.:";
            // 
            // anuladoLabel
            // 
            anuladoLabel.AutoSize = true;
            anuladoLabel.Location = new System.Drawing.Point(405, 78);
            anuladoLabel.Name = "anuladoLabel";
            anuladoLabel.Size = new System.Drawing.Size(50, 13);
            anuladoLabel.TabIndex = 2;
            anuladoLabel.Text = "Anulado:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(66, 26);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(384, 9);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 6;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(199, 9);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 4;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(11, 9);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            id_TipoComprobanteLabel.TabIndex = 4;
            id_TipoComprobanteLabel.Text = "Comprobante:";
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
            this.barSubItem2,
            this.btnResultado,
            this.btnConfirmar,
            this.btnAnular,
            this.barStaticItemFooter,
            this.btnGeneraOP});
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
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 4;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGeneraOP, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Caption = "Confirmar";
            this.btnConfirmar.Id = 6;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Id = 7;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
            // 
            // btnGeneraOP
            // 
            this.btnGeneraOP.Caption = "Generar OP";
            this.btnGeneraOP.Id = 9;
            this.btnGeneraOP.Name = "btnGeneraOP";
            this.btnGeneraOP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGeneraOP_ItemClick);
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
            this.barStaticItemFooter.Id = 8;
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
            // gridControl1
            // 
            this.gridControl1.DataSource = this.comprobantesComprasManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 186);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 250);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // comprobantesComprasManager_SearchResultBindingSource
            // 
            this.comprobantesComprasManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesComprasManager.SearchResult);
            this.comprobantesComprasManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.comprobantesComprasManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSucursal,
            this.colComprobante,
            this.colNombre_Entidad,
            this.colCentro_Costo,
            this.colImporte_Pesos,
            this.colImporte,
            this.colId_Sucursal,
            this.colId_CentroCosto,
            this.colId_TipoComprobante,
            this.colLetra,
            this.colPuntoVenta,
            this.colNroComprobante,
            this.colId_TipoEntidad,
            this.colId_Entidad,
            this.colId_FormaPago,
            this.colFecha,
            this.colFechaEntrega,
            this.colFechaVto,
            this.colObservaciones,
            this.colPercepcionIva,
            this.colOtrosImpuestos,
            this.colRetenciones,
            this.colPercepcionIIBB,
            this.colFechaLiquidacion,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Format0";
            formatConditionRuleExpression3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression3.Appearance.ForeColor = System.Drawing.Color.Gray;
            formatConditionRuleExpression3.Appearance.Options.UseFont = true;
            formatConditionRuleExpression3.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression3.Expression = "[FechaAnulacion] <> ?";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Format1";
            formatConditionRuleExpression4.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression4.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression4.Expression = "[FechaLiquidacion] = ?";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 1;
            this.colSucursal.Width = 165;
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 2;
            this.colComprobante.Width = 165;
            // 
            // colNombre_Entidad
            // 
            this.colNombre_Entidad.Caption = "Entidad";
            this.colNombre_Entidad.FieldName = "Nombre_Entidad";
            this.colNombre_Entidad.Name = "colNombre_Entidad";
            this.colNombre_Entidad.Visible = true;
            this.colNombre_Entidad.VisibleIndex = 3;
            this.colNombre_Entidad.Width = 377;
            // 
            // colCentro_Costo
            // 
            this.colCentro_Costo.Caption = "Centro Costo";
            this.colCentro_Costo.FieldName = "Centro_Costo";
            this.colCentro_Costo.Name = "colCentro_Costo";
            // 
            // colImporte_Pesos
            // 
            this.colImporte_Pesos.Caption = "Importe Pesos";
            this.colImporte_Pesos.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte_Pesos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte_Pesos.FieldName = "Importe_Pesos";
            this.colImporte_Pesos.Name = "colImporte_Pesos";
            this.colImporte_Pesos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe_Pesos", "{0:N2}")});
            this.colImporte_Pesos.Visible = true;
            this.colImporte_Pesos.VisibleIndex = 5;
            this.colImporte_Pesos.Width = 91;
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
            this.colImporte.VisibleIndex = 4;
            this.colImporte.Width = 95;
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
            // colLetra
            // 
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            // 
            // colPuntoVenta
            // 
            this.colPuntoVenta.FieldName = "PuntoVenta";
            this.colPuntoVenta.Name = "colPuntoVenta";
            // 
            // colNroComprobante
            // 
            this.colNroComprobante.FieldName = "NroComprobante";
            this.colNroComprobante.Name = "colNroComprobante";
            // 
            // colId_TipoEntidad
            // 
            this.colId_TipoEntidad.FieldName = "Id_TipoEntidad";
            this.colId_TipoEntidad.Name = "colId_TipoEntidad";
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            // 
            // colId_FormaPago
            // 
            this.colId_FormaPago.FieldName = "Id_FormaPago";
            this.colId_FormaPago.Name = "colId_FormaPago";
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 87;
            // 
            // colFechaEntrega
            // 
            this.colFechaEntrega.Caption = "F.Recepcion";
            this.colFechaEntrega.FieldName = "FechaRecepcion";
            this.colFechaEntrega.Name = "colFechaEntrega";
            // 
            // colFechaVto
            // 
            this.colFechaVto.FieldName = "FechaVto";
            this.colFechaVto.Name = "colFechaVto";
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // colPercepcionIva
            // 
            this.colPercepcionIva.Caption = "Percepción Iva";
            this.colPercepcionIva.FieldName = "PercepcionIva";
            this.colPercepcionIva.Name = "colPercepcionIva";
            // 
            // colOtrosImpuestos
            // 
            this.colOtrosImpuestos.FieldName = "OtrosImpuestos";
            this.colOtrosImpuestos.Name = "colOtrosImpuestos";
            // 
            // colRetenciones
            // 
            this.colRetenciones.Caption = "Percepciones";
            this.colRetenciones.FieldName = "PercepcionGanancias";
            this.colRetenciones.Name = "colRetenciones";
            // 
            // colPercepcionIIBB
            // 
            this.colPercepcionIIBB.FieldName = "PercepcionIIBB";
            this.colPercepcionIIBB.Name = "colPercepcionIIBB";
            // 
            // colFechaLiquidacion
            // 
            this.colFechaLiquidacion.Caption = "F. Liquidación";
            this.colFechaLiquidacion.FieldName = "FechaLiquidacion";
            this.colFechaLiquidacion.Name = "colFechaLiquidacion";
            this.colFechaLiquidacion.Width = 98;
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.Caption = "F. Anulación";
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
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
            // gcBusquedaAvanzada
            // 
            this.gcBusquedaAvanzada.Controls.Add(puntoVentaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.puntoVentaTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(letraLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.letraTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(nroComprobanteLabel);
            this.gcBusquedaAvanzada.Controls.Add(id_SucursalLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.nroComprobanteTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(this.id_SucursalLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(label1);
            this.gcBusquedaAvanzada.Controls.Add(this.tipoEntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(this.id_EntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_HastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_HastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_DesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_DesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(conceptoLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.conceptoTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(anuladoLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.anuladoCheckEdit);
            this.gcBusquedaAvanzada.Controls.Add(idLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.idTextEdit);
            this.gcBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 57);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 129);
            this.gcBusquedaAvanzada.TabIndex = 5;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // puntoVentaTextEdit
            // 
            this.puntoVentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "PuntoVenta", true));
            this.puntoVentaTextEdit.EnterMoveNextControl = true;
            this.puntoVentaTextEdit.Location = new System.Drawing.Point(278, 49);
            this.puntoVentaTextEdit.MenuManager = this.barManager1;
            this.puntoVentaTextEdit.Name = "puntoVentaTextEdit";
            this.puntoVentaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.puntoVentaTextEdit.TabIndex = 4;
            this.puntoVentaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // comprobantesComprasManager_ParametrosBusquedasBindingSource
            // 
            this.comprobantesComprasManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesComprasManager.ParametrosBusquedas);
            // 
            // letraTextEdit
            // 
            this.letraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Letra", true));
            this.letraTextEdit.EnterMoveNextControl = true;
            this.letraTextEdit.Location = new System.Drawing.Point(93, 49);
            this.letraTextEdit.MenuManager = this.barManager1;
            this.letraTextEdit.Name = "letraTextEdit";
            this.letraTextEdit.Size = new System.Drawing.Size(100, 20);
            this.letraTextEdit.TabIndex = 3;
            this.letraTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroComprobanteTextEdit
            // 
            this.nroComprobanteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "NroComprobante", true));
            this.nroComprobanteTextEdit.EnterMoveNextControl = true;
            this.nroComprobanteTextEdit.Location = new System.Drawing.Point(461, 49);
            this.nroComprobanteTextEdit.MenuManager = this.barManager1;
            this.nroComprobanteTextEdit.Name = "nroComprobanteTextEdit";
            this.nroComprobanteTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroComprobanteTextEdit.TabIndex = 5;
            this.nroComprobanteTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(461, 23);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 2;
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "TipoEntidad", true));
            this.tipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(93, 101);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name18")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 9;
            this.tipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.tipoEntidadLookUpEdit_EditValueChanged);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(202, 101);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name19")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(359, 20);
            this.id_EntidadLookUpEdit.TabIndex = 10;
            // 
            // fecha_Liquidacion_HastaDateEdit
            // 
            this.fecha_Liquidacion_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Hasta", true));
            this.fecha_Liquidacion_HastaDateEdit.EditValue = null;
            this.fecha_Liquidacion_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_Liquidacion_HastaDateEdit.Location = new System.Drawing.Point(278, 75);
            this.fecha_Liquidacion_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_HastaDateEdit.Name = "fecha_Liquidacion_HastaDateEdit";
            this.fecha_Liquidacion_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_HastaDateEdit.TabIndex = 7;
            // 
            // fecha_Liquidacion_DesdeDateEdit
            // 
            this.fecha_Liquidacion_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Desde", true));
            this.fecha_Liquidacion_DesdeDateEdit.EditValue = null;
            this.fecha_Liquidacion_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_Liquidacion_DesdeDateEdit.Location = new System.Drawing.Point(93, 75);
            this.fecha_Liquidacion_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_DesdeDateEdit.Name = "fecha_Liquidacion_DesdeDateEdit";
            this.fecha_Liquidacion_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_DesdeDateEdit.TabIndex = 6;
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(278, 23);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.conceptoTextEdit.TabIndex = 1;
            this.conceptoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // anuladoCheckEdit
            // 
            this.anuladoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Anulado", true));
            this.anuladoCheckEdit.EnterMoveNextControl = true;
            this.anuladoCheckEdit.Location = new System.Drawing.Point(461, 75);
            this.anuladoCheckEdit.MenuManager = this.barManager1;
            this.anuladoCheckEdit.Name = "anuladoCheckEdit";
            this.anuladoCheckEdit.Properties.Caption = "";
            this.anuladoCheckEdit.Size = new System.Drawing.Size(34, 19);
            this.anuladoCheckEdit.TabIndex = 8;
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(93, 23);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 0;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fecha_HastaLabel);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Controls.Add(this.fecha_DesdeDateEdit);
            this.panelControl1.Controls.Add(id_TipoComprobanteLabel);
            this.panelControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 4;
            // 
            // btnAvanzada
            // 
            this.btnAvanzada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvanzada.Image = global::VENET_Gestion_UI.Properties.Resources.filter_16x16;
            this.btnAvanzada.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAvanzada.Location = new System.Drawing.Point(625, 3);
            this.btnAvanzada.Name = "btnAvanzada";
            this.btnAvanzada.Size = new System.Drawing.Size(23, 23);
            this.btnAvanzada.TabIndex = 5;
            this.btnAvanzada.CheckedChanged += new System.EventHandler(this.btnAvanzada_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(461, 6);
            this.fecha_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_HastaDateEdit.Name = "fecha_HastaDateEdit";
            this.fecha_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_HastaDateEdit.TabIndex = 2;
            // 
            // fecha_DesdeDateEdit
            // 
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(278, 6);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 1;
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManager_ParametrosBusquedasBindingSource, "Id_TipoComprobante", true));
            this.id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(93, 6);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name17")});
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 0;
            // 
            // frmComprobantesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gcBusquedaAvanzada);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(692, 288);
            this.Name = "frmComprobantesCompras";
            this.Text = "Comprobantes de Compras";
            this.Load += new System.EventHandler(this.frmComprobantesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro_Costo;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte_Pesos;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colNroComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_FormaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVto;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colPercepcionIva;
        private DevExpress.XtraGrid.Columns.GridColumn colOtrosImpuestos;
        private DevExpress.XtraGrid.Columns.GridColumn colRetenciones;
        private DevExpress.XtraGrid.Columns.GridColumn colPercepcionIIBB;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaLiquidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.GroupControl gcBusquedaAvanzada;
        private DevExpress.XtraEditors.TextEdit puntoVentaTextEdit;
        private DevExpress.XtraEditors.TextEdit letraTextEdit;
        private DevExpress.XtraEditors.TextEdit nroComprobanteTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private DevExpress.XtraEditors.CheckEdit anuladoCheckEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private System.Windows.Forms.BindingSource comprobantesComprasManager_SearchResultBindingSource;
        private System.Windows.Forms.BindingSource comprobantesComprasManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarButtonItem btnGeneraOP;
    }
}