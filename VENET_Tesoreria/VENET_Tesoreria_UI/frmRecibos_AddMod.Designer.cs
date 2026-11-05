namespace VENET_Tesoreria_UI
{
    partial class frmRecibos_AddMod
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
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label letraLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label id_TipoEntidadLabel;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibos_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnEfectivo = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheque = new DevExpress.XtraBars.BarButtonItem();
            this.btnCtaCte = new DevExpress.XtraBars.BarButtonItem();
            this.btnTarjetaDebito = new DevExpress.XtraBars.BarButtonItem();
            this.btnTarjetaCredito = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.recibosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Recibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregar = new DevExpress.XtraEditors.DropDownButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.tpComprobantes = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.comprobantesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_OrdenPago1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobantesCompras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteAdeudado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFechas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnEliminaCmp = new System.Windows.Forms.Button();
            this.btnAgregaCmp = new System.Windows.Forms.Button();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.observacionesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroComprobanteSpinEdit = new DevExpress.XtraEditors.TextEdit();
            this.letraTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnPercepcion = new DevExpress.XtraBars.BarButtonItem();
            conceptoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            letraLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            id_TipoEntidadLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tpComprobantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(29, 114);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 0;
            conceptoLabel.Text = "Concepto:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(46, 10);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha:";
            // 
            // letraLabel
            // 
            letraLabel.AutoSize = true;
            letraLabel.Location = new System.Drawing.Point(10, 88);
            letraLabel.Name = "letraLabel";
            letraLabel.Size = new System.Drawing.Size(76, 13);
            letraLabel.TabIndex = 28;
            letraLabel.Text = "Comprobante:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(4, 140);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 32;
            observacionesLabel.Text = "Observaciones:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(278, 36);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(75, 13);
            id_CentroCostoLabel.TabIndex = 38;
            id_CentroCostoLabel.Text = "Centro Costo:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(35, 36);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 38;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // id_TipoEntidadLabel
            // 
            id_TipoEntidadLabel.AutoSize = true;
            id_TipoEntidadLabel.Location = new System.Drawing.Point(39, 62);
            id_TipoEntidadLabel.Name = "id_TipoEntidadLabel";
            id_TipoEntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_TipoEntidadLabel.TabIndex = 40;
            id_TipoEntidadLabel.Text = "Entidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 166);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 13);
            label2.TabIndex = 44;
            label2.Text = "Importe Total:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAceptar,
            this.btnEfectivo,
            this.btnCheque,
            this.btnCtaCte,
            this.btnTarjetaDebito,
            this.btnTarjetaCredito,
            this.btnPercepcion});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Id = 0;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(536, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 482);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(536, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 458);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(536, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 458);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Caption = "Efectivo";
            this.btnEfectivo.Id = 1;
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEfectivo_ItemClick);
            // 
            // btnCheque
            // 
            this.btnCheque.Caption = "Cheque";
            this.btnCheque.Id = 2;
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheque_ItemClick);
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.Caption = "Cta.Cte.";
            this.btnCtaCte.Id = 3;
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCtaCte_ItemClick);
            // 
            // btnTarjetaDebito
            // 
            this.btnTarjetaDebito.Caption = "Tarjeta Débito";
            this.btnTarjetaDebito.Id = 4;
            this.btnTarjetaDebito.Name = "btnTarjetaDebito";
            this.btnTarjetaDebito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarjetaDebito_ItemClick);
            // 
            // btnTarjetaCredito
            // 
            this.btnTarjetaCredito.Caption = "Tarjeta Crédito";
            this.btnTarjetaCredito.Id = 5;
            this.btnTarjetaCredito.Name = "btnTarjetaCredito";
            this.btnTarjetaCredito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTarjetaCredito_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEfectivo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCheque),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTarjetaDebito),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTarjetaCredito),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCtaCte),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPercepcion)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(label2);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Controls.Add(this.xtraTabControl1);
            this.groupControl1.Controls.Add(id_TipoEntidadLabel);
            this.groupControl1.Controls.Add(this.id_EntidadLookUpEdit);
            this.groupControl1.Controls.Add(id_SucursalLabel);
            this.groupControl1.Controls.Add(this.id_SucursalLookUpEdit);
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(this.tipoEntidadLookUpEdit);
            this.groupControl1.Controls.Add(conceptoLabel);
            this.groupControl1.Controls.Add(this.conceptoTextEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Controls.Add(letraLabel);
            this.groupControl1.Controls.Add(observacionesLabel);
            this.groupControl1.Controls.Add(this.observacionesTextEdit);
            this.groupControl1.Controls.Add(this.nroComprobanteSpinEdit);
            this.groupControl1.Controls.Add(this.letraTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(512, 440);
            this.groupControl1.TabIndex = 0;
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Importe", true));
            this.importeTextEdit.Enabled = false;
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(92, 163);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.importeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 9;
            // 
            // recibosManagerBindingSource
            // 
            this.recibosManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RecibosManager);
            this.recibosManagerBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.recibosManagerBindingSource_BindingComplete);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 189);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpGeneral;
            this.xtraTabControl1.Size = new System.Drawing.Size(502, 246);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpGeneral,
            this.tpComprobantes});
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.gridControl1);
            this.tpGeneral.Controls.Add(this.panelControl1);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(500, 221);
            this.tpGeneral.Text = "Detalle";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.detalleBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(500, 189);
            this.gridControl1.TabIndex = 38;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.RecibosDetalle);
            this.detalleBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.detalleBindingSource_BindingComplete);
            this.detalleBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.detalleBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colId_Recibo,
            this.colId_Especie,
            this.colCotizacion,
            this.colImporte,
            this.colId_Documento,
            this.colEspecie,
            this.colDetalle,
            this.colTipoMovimiento,
            this.colEntidad});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", this.colImporte, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colId_Recibo
            // 
            this.colId_Recibo.FieldName = "Id_Recibo";
            this.colId_Recibo.Name = "colId_Recibo";
            this.colId_Recibo.OptionsColumn.AllowEdit = false;
            this.colId_Recibo.OptionsColumn.ReadOnly = true;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            this.colId_Especie.OptionsColumn.AllowEdit = false;
            this.colId_Especie.OptionsColumn.ReadOnly = true;
            // 
            // colCotizacion
            // 
            this.colCotizacion.DisplayFormat.FormatString = "#,##0.00";
            this.colCotizacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCotizacion.FieldName = "Cotizacion";
            this.colCotizacion.Name = "colCotizacion";
            this.colCotizacion.OptionsColumn.AllowEdit = false;
            this.colCotizacion.OptionsColumn.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 3;
            this.colImporte.Width = 131;
            // 
            // colId_Documento
            // 
            this.colId_Documento.FieldName = "Id_Documento";
            this.colId_Documento.Name = "colId_Documento";
            this.colId_Documento.OptionsColumn.AllowEdit = false;
            this.colId_Documento.OptionsColumn.ReadOnly = true;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.OptionsColumn.AllowEdit = false;
            this.colEspecie.OptionsColumn.ReadOnly = true;
            this.colEspecie.Visible = true;
            this.colEspecie.VisibleIndex = 1;
            this.colEspecie.Width = 66;
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.OptionsColumn.AllowEdit = false;
            this.colDetalle.OptionsColumn.ReadOnly = true;
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 2;
            this.colDetalle.Width = 224;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.Caption = "Tipo Mov.";
            this.colTipoMovimiento.FieldName = "TipoMovimiento";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.OptionsColumn.AllowEdit = false;
            this.colTipoMovimiento.OptionsColumn.ReadOnly = true;
            this.colTipoMovimiento.Visible = true;
            this.colTipoMovimiento.VisibleIndex = 0;
            this.colTipoMovimiento.Width = 57;
            // 
            // colEntidad
            // 
            this.colEntidad.Caption = "Entidad";
            this.colEntidad.FieldName = "NombreEntidad";
            this.colEntidad.Name = "colEntidad";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 189);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(500, 32);
            this.panelControl1.TabIndex = 39;
            // 
            // btnAgregar
            // 
            this.btnAgregar.DropDownControl = this.popupMenu1;
            this.btnAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.ImageOptions.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(9, 6);
            this.btnAgregar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAgregar.MenuManager = this.barManager1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(180, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "    Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(99, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // tpComprobantes
            // 
            this.tpComprobantes.Controls.Add(this.gridControl3);
            this.tpComprobantes.Controls.Add(this.panelControl2);
            this.tpComprobantes.Name = "tpComprobantes";
            this.tpComprobantes.Size = new System.Drawing.Size(500, 221);
            this.tpComprobantes.Text = "Comprobantes";
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.comprobantesBindingSource;
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.MenuManager = this.barManager1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(500, 189);
            this.gridControl3.TabIndex = 40;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // comprobantesBindingSource
            // 
            this.comprobantesBindingSource.DataSource = typeof(VENET_DataEntity.RecibosComprobantes);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_OrdenPago1,
            this.colId_ComprobantesCompras,
            this.colImporteAdeudado,
            this.colImportePago,
            this.colComprobante,
            this.colBorrado1,
            this.colId2,
            this.colFechaAdd1,
            this.colFechaMod1,
            this.colUserAdd1,
            this.colUserMod1,
            this.ColFechas,
            this.colImporte3});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colId_OrdenPago1
            // 
            this.colId_OrdenPago1.FieldName = "Id_OrdenPago";
            this.colId_OrdenPago1.Name = "colId_OrdenPago1";
            this.colId_OrdenPago1.OptionsColumn.AllowEdit = false;
            this.colId_OrdenPago1.OptionsColumn.ReadOnly = true;
            // 
            // colId_ComprobantesCompras
            // 
            this.colId_ComprobantesCompras.FieldName = "Id_ComprobantesCompras";
            this.colId_ComprobantesCompras.Name = "colId_ComprobantesCompras";
            this.colId_ComprobantesCompras.OptionsColumn.AllowEdit = false;
            this.colId_ComprobantesCompras.OptionsColumn.ReadOnly = true;
            // 
            // colImporteAdeudado
            // 
            this.colImporteAdeudado.DisplayFormat.FormatString = "n";
            this.colImporteAdeudado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteAdeudado.FieldName = "ImporteAdeudado";
            this.colImporteAdeudado.Name = "colImporteAdeudado";
            this.colImporteAdeudado.OptionsColumn.AllowEdit = false;
            this.colImporteAdeudado.OptionsColumn.ReadOnly = true;
            this.colImporteAdeudado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteAdeudado", "{0:N2}")});
            this.colImporteAdeudado.Visible = true;
            this.colImporteAdeudado.VisibleIndex = 3;
            this.colImporteAdeudado.Width = 102;
            // 
            // colImportePago
            // 
            this.colImportePago.DisplayFormat.FormatString = "n";
            this.colImportePago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportePago.FieldName = "ImportePago";
            this.colImportePago.Name = "colImportePago";
            this.colImportePago.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImportePago", "{0:N2}")});
            this.colImportePago.Visible = true;
            this.colImportePago.VisibleIndex = 4;
            this.colImportePago.Width = 114;
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.AllowEdit = false;
            this.colComprobante.OptionsColumn.ReadOnly = true;
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 1;
            this.colComprobante.Width = 107;
            // 
            // colBorrado1
            // 
            this.colBorrado1.FieldName = "Borrado";
            this.colBorrado1.Name = "colBorrado1";
            this.colBorrado1.OptionsColumn.AllowEdit = false;
            this.colBorrado1.OptionsColumn.ReadOnly = true;
            // 
            // colId2
            // 
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            this.colId2.OptionsColumn.AllowEdit = false;
            this.colId2.OptionsColumn.ReadOnly = true;
            // 
            // colFechaAdd1
            // 
            this.colFechaAdd1.FieldName = "FechaAdd";
            this.colFechaAdd1.Name = "colFechaAdd1";
            this.colFechaAdd1.OptionsColumn.AllowEdit = false;
            this.colFechaAdd1.OptionsColumn.ReadOnly = true;
            // 
            // colFechaMod1
            // 
            this.colFechaMod1.FieldName = "FechaMod";
            this.colFechaMod1.Name = "colFechaMod1";
            this.colFechaMod1.OptionsColumn.AllowEdit = false;
            this.colFechaMod1.OptionsColumn.ReadOnly = true;
            // 
            // colUserAdd1
            // 
            this.colUserAdd1.FieldName = "UserAdd";
            this.colUserAdd1.Name = "colUserAdd1";
            this.colUserAdd1.OptionsColumn.AllowEdit = false;
            this.colUserAdd1.OptionsColumn.ReadOnly = true;
            // 
            // colUserMod1
            // 
            this.colUserMod1.FieldName = "UserMod";
            this.colUserMod1.Name = "colUserMod1";
            this.colUserMod1.OptionsColumn.AllowEdit = false;
            this.colUserMod1.OptionsColumn.ReadOnly = true;
            // 
            // ColFechas
            // 
            this.ColFechas.Caption = "Fecha";
            this.ColFechas.FieldName = "Fecha";
            this.ColFechas.Name = "ColFechas";
            this.ColFechas.Visible = true;
            this.ColFechas.VisibleIndex = 0;
            this.ColFechas.Width = 64;
            // 
            // colImporte3
            // 
            this.colImporte3.Caption = "Importe";
            this.colImporte3.DisplayFormat.FormatString = "n";
            this.colImporte3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte3.FieldName = "Importe";
            this.colImporte3.Name = "colImporte3";
            this.colImporte3.OptionsColumn.AllowEdit = false;
            this.colImporte3.OptionsColumn.ReadOnly = true;
            this.colImporte3.Visible = true;
            this.colImporte3.VisibleIndex = 2;
            this.colImporte3.Width = 91;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnEliminaCmp);
            this.panelControl2.Controls.Add(this.btnAgregaCmp);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 189);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(500, 32);
            this.panelControl2.TabIndex = 41;
            // 
            // btnEliminaCmp
            // 
            this.btnEliminaCmp.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaCmp.Image")));
            this.btnEliminaCmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminaCmp.Location = new System.Drawing.Point(86, 6);
            this.btnEliminaCmp.Name = "btnEliminaCmp";
            this.btnEliminaCmp.Size = new System.Drawing.Size(75, 23);
            this.btnEliminaCmp.TabIndex = 2;
            this.btnEliminaCmp.Text = "    Eliminar";
            this.btnEliminaCmp.Click += new System.EventHandler(this.btnEliminaCmp_Click);
            // 
            // btnAgregaCmp
            // 
            this.btnAgregaCmp.Image = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregaCmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregaCmp.Location = new System.Drawing.Point(5, 6);
            this.btnAgregaCmp.Name = "btnAgregaCmp";
            this.btnAgregaCmp.Size = new System.Drawing.Size(75, 23);
            this.btnAgregaCmp.TabIndex = 1;
            this.btnAgregaCmp.Text = "     Agregar";
            this.btnAgregaCmp.Click += new System.EventHandler(this.btnAgregaCmp_Click);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(188, 59);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(310, 20);
            this.id_EntidadLookUpEdit.TabIndex = 4;
            this.id_EntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_EntidadLookUpEdit_EditValueChanged);
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(92, 33);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.PopupWidth = 406;
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(143, 20);
            this.id_SucursalLookUpEdit.TabIndex = 1;
            this.id_SucursalLookUpEdit.TextChanged += new System.EventHandler(this.id_SucursalLookUpEdit_TextChanged);
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(355, 33);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(143, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 2;
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.TipoEntidad", true));
            this.tipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(92, 59);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Valor")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(90, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 3;
            this.tipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.tipoEntidadLookUpEdit_EditValueChanged);
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(92, 111);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Size = new System.Drawing.Size(406, 20);
            this.conceptoTextEdit.TabIndex = 7;
            this.conceptoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(92, 7);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(143, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // observacionesTextEdit
            // 
            this.observacionesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Observaciones", true));
            this.observacionesTextEdit.EnterMoveNextControl = true;
            this.observacionesTextEdit.Location = new System.Drawing.Point(92, 137);
            this.observacionesTextEdit.MenuManager = this.barManager1;
            this.observacionesTextEdit.Name = "observacionesTextEdit";
            this.observacionesTextEdit.Size = new System.Drawing.Size(406, 20);
            this.observacionesTextEdit.TabIndex = 8;
            this.observacionesTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroComprobanteSpinEdit
            // 
            this.nroComprobanteSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.NroComprobante", true));
            this.nroComprobanteSpinEdit.EditValue = "";
            this.nroComprobanteSpinEdit.EnterMoveNextControl = true;
            this.nroComprobanteSpinEdit.Location = new System.Drawing.Point(162, 85);
            this.nroComprobanteSpinEdit.MenuManager = this.barManager1;
            this.nroComprobanteSpinEdit.Name = "nroComprobanteSpinEdit";
            this.nroComprobanteSpinEdit.Properties.DisplayFormat.FormatString = "00000000";
            this.nroComprobanteSpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.nroComprobanteSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.nroComprobanteSpinEdit.Properties.Mask.EditMask = "\\d{0,8}";
            this.nroComprobanteSpinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.nroComprobanteSpinEdit.Size = new System.Drawing.Size(73, 20);
            this.nroComprobanteSpinEdit.TabIndex = 6;
            this.nroComprobanteSpinEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // letraTextEdit
            // 
            this.letraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManagerBindingSource, "Recibo.Id_TalonariosComprobantes", true));
            this.letraTextEdit.EnterMoveNextControl = true;
            this.letraTextEdit.Location = new System.Drawing.Point(92, 85);
            this.letraTextEdit.MenuManager = this.barManager1;
            this.letraTextEdit.Name = "letraTextEdit";
            this.letraTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.letraTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.letraTextEdit.Properties.DisplayMember = "Name";
            this.letraTextEdit.Properties.MaxLength = 1;
            this.letraTextEdit.Properties.NullText = "";
            this.letraTextEdit.Properties.ShowHeader = false;
            this.letraTextEdit.Properties.ValueMember = "Key";
            this.letraTextEdit.Size = new System.Drawing.Size(64, 20);
            this.letraTextEdit.TabIndex = 5;
            // 
            // btnPercepcion
            // 
            this.btnPercepcion.Caption = "Percepción";
            this.btnPercepcion.Id = 6;
            this.btnPercepcion.Name = "btnPercepcion";
            this.btnPercepcion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPercepcion_ItemClick);
            // 
            // frmRecibos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(536, 482);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(552, 521);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(538, 514);
            this.Name = "frmRecibos_AddMod";
            this.Text = "Alta/Modificación de Recibos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecibos_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmRecibos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tpComprobantes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private System.Windows.Forms.BindingSource recibosManagerBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.TextEdit observacionesTextEdit;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.TextEdit nroComprobanteSpinEdit;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit letraTextEdit;
        private DevExpress.XtraBars.BarButtonItem btnEfectivo;
        private DevExpress.XtraBars.BarButtonItem btnCheque;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnCtaCte;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Recibo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Documento;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DropDownButton btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private DevExpress.XtraTab.XtraTabPage tpComprobantes;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colId_OrdenPago1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobantesCompras;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteAdeudado;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePago;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado1;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod1;
        private DevExpress.XtraGrid.Columns.GridColumn ColFechas;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnEliminaCmp;
        private System.Windows.Forms.Button btnAgregaCmp;
        private System.Windows.Forms.BindingSource comprobantesBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnTarjetaDebito;
        private DevExpress.XtraBars.BarButtonItem btnTarjetaCredito;
        private DevExpress.XtraBars.BarButtonItem btnPercepcion;
    }
}