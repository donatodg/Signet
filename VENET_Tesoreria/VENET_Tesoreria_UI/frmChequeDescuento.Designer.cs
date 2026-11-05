namespace VENET_Tesoreria_UI
{
    partial class frmChequeDescuento
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
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label fecha_DesdeLabel;
            System.Windows.Forms.Label fecha_HastaLabel;
            System.Windows.Forms.Label fecha_Liquidacion_DesdeLabel;
            System.Windows.Forms.Label fecha_Liquidacion_HastaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label anuladoLabel;
            System.Windows.Forms.Label idLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.chequeDescuentoManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProvFinanciero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCBU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProvFinancieroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaLiquidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.chequeDescuentoManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.anuladoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fecha_Liquidacion_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_Liquidacion_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            id_SucursalLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            fecha_Liquidacion_DesdeLabel = new System.Windows.Forms.Label();
            fecha_Liquidacion_HastaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            anuladoLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(13, 11);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 10;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(182, 11);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 11;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(375, 11);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 12;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // fecha_Liquidacion_DesdeLabel
            // 
            fecha_Liquidacion_DesdeLabel.AutoSize = true;
            fecha_Liquidacion_DesdeLabel.Location = new System.Drawing.Point(12, 27);
            fecha_Liquidacion_DesdeLabel.Name = "fecha_Liquidacion_DesdeLabel";
            fecha_Liquidacion_DesdeLabel.Size = new System.Drawing.Size(109, 13);
            fecha_Liquidacion_DesdeLabel.TabIndex = 0;
            fecha_Liquidacion_DesdeLabel.Text = "F. Liquidación Desde:";
            // 
            // fecha_Liquidacion_HastaLabel
            // 
            fecha_Liquidacion_HastaLabel.AutoSize = true;
            fecha_Liquidacion_HastaLabel.Location = new System.Drawing.Point(237, 27);
            fecha_Liquidacion_HastaLabel.Name = "fecha_Liquidacion_HastaLabel";
            fecha_Liquidacion_HastaLabel.Size = new System.Drawing.Size(39, 13);
            fecha_Liquidacion_HastaLabel.TabIndex = 2;
            fecha_Liquidacion_HastaLabel.Text = "Hasta:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(55, 53);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripción:";
            // 
            // anuladoLabel
            // 
            anuladoLabel.AutoSize = true;
            anuladoLabel.Location = new System.Drawing.Point(397, 53);
            anuladoLabel.Name = "anuladoLabel";
            anuladoLabel.Size = new System.Drawing.Size(50, 13);
            anuladoLabel.TabIndex = 6;
            anuladoLabel.Text = "Anulado:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(256, 53);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 8;
            idLabel.Text = "Id:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.chequeDescuentoManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 136);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 300);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // chequeDescuentoManager_SearchResultBindingSource
            // 
            this.chequeDescuentoManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequeDescuentoManager.SearchResult);
            this.chequeDescuentoManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.chequeDescuentoManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProvFinanciero,
            this.colCBU,
            this.colSucursal,
            this.colImporte,
            this.colId_Sucursal,
            this.colId_ProvFinancieroCuenta,
            this.colFecha,
            this.colDescripcion,
            this.colFechaLiquidacion,
            this.colFechaAnulacion,
            this.colDetalle,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colMotivoAnulacion,
            this.colId_CentroCosto,
            this.colCentroCosto});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Gray;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FechaAnulacion] != ?";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[FechaLiquidacion] == ?";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colProvFinanciero
            // 
            this.colProvFinanciero.FieldName = "ProvFinanciero";
            this.colProvFinanciero.Name = "colProvFinanciero";
            this.colProvFinanciero.Visible = true;
            this.colProvFinanciero.VisibleIndex = 3;
            this.colProvFinanciero.Width = 113;
            // 
            // colCBU
            // 
            this.colCBU.FieldName = "CBU";
            this.colCBU.Name = "colCBU";
            this.colCBU.Visible = true;
            this.colCBU.VisibleIndex = 4;
            this.colCBU.Width = 77;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 5;
            this.colSucursal.Width = 77;
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
            this.colImporte.VisibleIndex = 6;
            this.colImporte.Width = 77;
            // 
            // colId_Sucursal
            // 
            this.colId_Sucursal.FieldName = "Id_Sucursal";
            this.colId_Sucursal.Name = "colId_Sucursal";
            this.colId_Sucursal.Width = 63;
            // 
            // colId_ProvFinancieroCuenta
            // 
            this.colId_ProvFinancieroCuenta.FieldName = "Id_ProvFinancieroCuenta";
            this.colId_ProvFinancieroCuenta.Name = "colId_ProvFinancieroCuenta";
            this.colId_ProvFinancieroCuenta.Width = 63;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 70;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 77;
            // 
            // colFechaLiquidacion
            // 
            this.colFechaLiquidacion.Caption = "F.Liquidación";
            this.colFechaLiquidacion.FieldName = "FechaLiquidacion";
            this.colFechaLiquidacion.Name = "colFechaLiquidacion";
            this.colFechaLiquidacion.Visible = true;
            this.colFechaLiquidacion.VisibleIndex = 7;
            this.colFechaLiquidacion.Width = 85;
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.Caption = "F.Anulación";
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            this.colFechaAnulacion.Visible = true;
            this.colFechaAnulacion.VisibleIndex = 8;
            this.colFechaAnulacion.Width = 87;
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.Width = 63;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 50;
            // 
            // colFechaAdd
            // 
            this.colFechaAdd.FieldName = "FechaAdd";
            this.colFechaAdd.Name = "colFechaAdd";
            this.colFechaAdd.Width = 63;
            // 
            // colFechaMod
            // 
            this.colFechaMod.FieldName = "FechaMod";
            this.colFechaMod.Name = "colFechaMod";
            this.colFechaMod.Width = 63;
            // 
            // colUserAdd
            // 
            this.colUserAdd.FieldName = "UserAdd";
            this.colUserAdd.Name = "colUserAdd";
            this.colUserAdd.Width = 63;
            // 
            // colUserMod
            // 
            this.colUserMod.FieldName = "UserMod";
            this.colUserMod.Name = "colUserMod";
            this.colUserMod.Width = 69;
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.Caption = "Id_CentroCosto";
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            // 
            // colCentroCosto
            // 
            this.colCentroCosto.Caption = "Centro de Costo";
            this.colCentroCosto.FieldName = "CentroCosto";
            this.colCentroCosto.Name = "colCentroCosto";
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
            this.barStaticItemFooter,
            this.btnResultado,
            this.btnConfirmar,
            this.btnAnular});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 6;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 4;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Caption = "Confirmar";
            this.btnConfirmar.Id = 7;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Id = 8;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(fecha_HastaLabel);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Controls.Add(this.fecha_DesdeDateEdit);
            this.panelControl1.Controls.Add(id_SucursalLabel);
            this.panelControl1.Controls.Add(this.id_SucursalLookUpEdit);
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 5;
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(452, 8);
            this.fecha_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_HastaDateEdit.Name = "fecha_HastaDateEdit";
            this.fecha_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_HastaDateEdit.TabIndex = 13;
            // 
            // chequeDescuentoManager_ParametrosBusquedasBindingSource
            // 
            this.chequeDescuentoManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequeDescuentoManager.ParametrosBusquedas);
            // 
            // fecha_DesdeDateEdit
            // 
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(262, 8);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 12;
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(70, 8);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.PopupWidth = 185;
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 11;
            // 
            // btnAvanzada
            // 
            this.btnAvanzada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvanzada.Image = global::VENET_Tesoreria_UI.Properties.Resources.filter_16x16;
            this.btnAvanzada.Location = new System.Drawing.Point(625, 6);
            this.btnAvanzada.Name = "btnAvanzada";
            this.btnAvanzada.Size = new System.Drawing.Size(23, 23);
            this.btnAvanzada.TabIndex = 10;
            this.btnAvanzada.CheckedChanged += new System.EventHandler(this.btnAvanzada_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcBusquedaAvanzada
            // 
            this.gcBusquedaAvanzada.Controls.Add(idLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.idTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(anuladoLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.anuladoCheckEdit);
            this.gcBusquedaAvanzada.Controls.Add(descripcionLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.descripcionTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_HastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_HastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_DesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_DesdeDateEdit);
            this.gcBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 57);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 79);
            this.gcBusquedaAvanzada.TabIndex = 10;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.Location = new System.Drawing.Point(281, 50);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 9;
            // 
            // anuladoCheckEdit
            // 
            this.anuladoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Anulado", true));
            this.anuladoCheckEdit.Location = new System.Drawing.Point(452, 50);
            this.anuladoCheckEdit.MenuManager = this.barManager1;
            this.anuladoCheckEdit.Name = "anuladoCheckEdit";
            this.anuladoCheckEdit.Properties.Caption = "";
            this.anuladoCheckEdit.Size = new System.Drawing.Size(43, 19);
            this.anuladoCheckEdit.TabIndex = 7;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(127, 50);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionTextEdit.TabIndex = 5;
            // 
            // fecha_Liquidacion_HastaDateEdit
            // 
            this.fecha_Liquidacion_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Hasta", true));
            this.fecha_Liquidacion_HastaDateEdit.EditValue = null;
            this.fecha_Liquidacion_HastaDateEdit.Location = new System.Drawing.Point(281, 24);
            this.fecha_Liquidacion_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_HastaDateEdit.Name = "fecha_Liquidacion_HastaDateEdit";
            this.fecha_Liquidacion_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_HastaDateEdit.TabIndex = 3;
            // 
            // fecha_Liquidacion_DesdeDateEdit
            // 
            this.fecha_Liquidacion_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Desde", true));
            this.fecha_Liquidacion_DesdeDateEdit.EditValue = null;
            this.fecha_Liquidacion_DesdeDateEdit.Location = new System.Drawing.Point(127, 24);
            this.fecha_Liquidacion_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_DesdeDateEdit.Name = "fecha_Liquidacion_DesdeDateEdit";
            this.fecha_Liquidacion_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_DesdeDateEdit.TabIndex = 1;
            // 
            // frmChequeDescuento
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
            this.MinimumSize = new System.Drawing.Size(691, 278);
            this.Name = "frmChequeDescuento";
            this.Text = "Descuento de Cheques";
            this.Load += new System.EventHandler(this.frmChequeDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.GroupControl gcBusquedaAvanzada;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource chequeDescuentoManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.CheckEdit anuladoCheckEdit;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_DesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private System.Windows.Forms.BindingSource chequeDescuentoManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProvFinanciero;
        private DevExpress.XtraGrid.Columns.GridColumn colCBU;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProvFinancieroCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaLiquidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
    }
}