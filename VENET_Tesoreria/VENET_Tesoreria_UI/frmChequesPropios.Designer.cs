namespace VENET_Tesoreria_UI
{
    partial class frmChequesPropios
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
            System.Windows.Forms.Label nroChequeLabel;
            System.Windows.Forms.Label emisionDesdeLabel;
            System.Windows.Forms.Label emisionHastaLabel;
            System.Windows.Forms.Label pagoDesdeLabel;
            System.Windows.Forms.Label pagoHastaLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label depositadoDesdeLabel;
            System.Windows.Forms.Label depositadoHastaLabel;
            System.Windows.Forms.Label rechazadoDesdeLabel;
            System.Windows.Forms.Label rechazadoHastaLabel;
            System.Windows.Forms.Label aLaOrdenLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label id_ProvFinancierosCuentaLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.chequePropiosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProvFinancierosCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroCheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_OrdenPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALaOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDepositado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaRechazado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoRechazo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteRechazo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Descuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnDepositar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRechazar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnularDeposito = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnularRechazo = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnOP = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_ProvFinancierosCuentaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.chequePropiosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.estadoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nroChequeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.aLaOrdenCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.rechazadoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.rechazadoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositadoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositadoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.pagoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.pagoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.emisionHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.emisionDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            nroChequeLabel = new System.Windows.Forms.Label();
            emisionDesdeLabel = new System.Windows.Forms.Label();
            emisionHastaLabel = new System.Windows.Forms.Label();
            pagoDesdeLabel = new System.Windows.Forms.Label();
            pagoHastaLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            depositadoDesdeLabel = new System.Windows.Forms.Label();
            depositadoHastaLabel = new System.Windows.Forms.Label();
            rechazadoDesdeLabel = new System.Windows.Forms.Label();
            rechazadoHastaLabel = new System.Windows.Forms.Label();
            aLaOrdenLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            id_ProvFinancierosCuentaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequePropiosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancierosCuentaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequePropiosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroChequeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLaOrdenCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionDesdeDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nroChequeLabel
            // 
            nroChequeLabel.AutoSize = true;
            nroChequeLabel.Location = new System.Drawing.Point(449, 9);
            nroChequeLabel.Name = "nroChequeLabel";
            nroChequeLabel.Size = new System.Drawing.Size(68, 13);
            nroChequeLabel.TabIndex = 7;
            nroChequeLabel.Text = "Nro Cheque:";
            // 
            // emisionDesdeLabel
            // 
            emisionDesdeLabel.AutoSize = true;
            emisionDesdeLabel.Location = new System.Drawing.Point(24, 53);
            emisionDesdeLabel.Name = "emisionDesdeLabel";
            emisionDesdeLabel.Size = new System.Drawing.Size(79, 13);
            emisionDesdeLabel.TabIndex = 4;
            emisionDesdeLabel.Text = "Emisión Desde:";
            // 
            // emisionHastaLabel
            // 
            emisionHastaLabel.AutoSize = true;
            emisionHastaLabel.Location = new System.Drawing.Point(218, 53);
            emisionHastaLabel.Name = "emisionHastaLabel";
            emisionHastaLabel.Size = new System.Drawing.Size(39, 13);
            emisionHastaLabel.TabIndex = 6;
            emisionHastaLabel.Text = "Hasta:";
            // 
            // pagoDesdeLabel
            // 
            pagoDesdeLabel.AutoSize = true;
            pagoDesdeLabel.Location = new System.Drawing.Point(35, 79);
            pagoDesdeLabel.Name = "pagoDesdeLabel";
            pagoDesdeLabel.Size = new System.Drawing.Size(68, 13);
            pagoDesdeLabel.TabIndex = 8;
            pagoDesdeLabel.Text = "Pago Desde:";
            // 
            // pagoHastaLabel
            // 
            pagoHastaLabel.AutoSize = true;
            pagoHastaLabel.Location = new System.Drawing.Point(218, 79);
            pagoHastaLabel.Name = "pagoHastaLabel";
            pagoHastaLabel.Size = new System.Drawing.Size(39, 13);
            pagoHastaLabel.TabIndex = 10;
            pagoHastaLabel.Text = "Hasta:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(418, 27);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 12;
            importeLabel.Text = "Importe:";
            // 
            // depositadoDesdeLabel
            // 
            depositadoDesdeLabel.AutoSize = true;
            depositadoDesdeLabel.Location = new System.Drawing.Point(5, 105);
            depositadoDesdeLabel.Name = "depositadoDesdeLabel";
            depositadoDesdeLabel.Size = new System.Drawing.Size(98, 13);
            depositadoDesdeLabel.TabIndex = 16;
            depositadoDesdeLabel.Text = "Depositado Desde:";
            // 
            // depositadoHastaLabel
            // 
            depositadoHastaLabel.AutoSize = true;
            depositadoHastaLabel.Location = new System.Drawing.Point(218, 105);
            depositadoHastaLabel.Name = "depositadoHastaLabel";
            depositadoHastaLabel.Size = new System.Drawing.Size(39, 13);
            depositadoHastaLabel.TabIndex = 18;
            depositadoHastaLabel.Text = "Hasta:";
            // 
            // rechazadoDesdeLabel
            // 
            rechazadoDesdeLabel.AutoSize = true;
            rechazadoDesdeLabel.Location = new System.Drawing.Point(372, 79);
            rechazadoDesdeLabel.Name = "rechazadoDesdeLabel";
            rechazadoDesdeLabel.Size = new System.Drawing.Size(97, 13);
            rechazadoDesdeLabel.TabIndex = 32;
            rechazadoDesdeLabel.Text = "Rechazado Desde:";
            // 
            // rechazadoHastaLabel
            // 
            rechazadoHastaLabel.AutoSize = true;
            rechazadoHastaLabel.Location = new System.Drawing.Point(581, 79);
            rechazadoHastaLabel.Name = "rechazadoHastaLabel";
            rechazadoHastaLabel.Size = new System.Drawing.Size(39, 13);
            rechazadoHastaLabel.TabIndex = 34;
            rechazadoHastaLabel.Text = "Hasta:";
            // 
            // aLaOrdenLabel
            // 
            aLaOrdenLabel.AutoSize = true;
            aLaOrdenLabel.Location = new System.Drawing.Point(407, 53);
            aLaOrdenLabel.Name = "aLaOrdenLabel";
            aLaOrdenLabel.Size = new System.Drawing.Size(62, 13);
            aLaOrdenLabel.TabIndex = 36;
            aLaOrdenLabel.Text = "A la Orden:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(52, 27);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 37;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new System.Drawing.Point(5, 9);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(44, 13);
            estadoLabel.TabIndex = 39;
            estadoLabel.Text = "Estado:";
            // 
            // id_ProvFinancierosCuentaLabel
            // 
            id_ProvFinancierosCuentaLabel.AutoSize = true;
            id_ProvFinancierosCuentaLabel.Location = new System.Drawing.Point(155, 9);
            id_ProvFinancierosCuentaLabel.Name = "id_ProvFinancierosCuentaLabel";
            id_ProvFinancierosCuentaLabel.Size = new System.Drawing.Size(85, 13);
            id_ProvFinancierosCuentaLabel.TabIndex = 40;
            id_ProvFinancierosCuentaLabel.Text = "Prov Financiero:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.chequePropiosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 189);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 247);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // chequePropiosManager_SearchResultBindingSource
            // 
            this.chequePropiosManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequePropiosManager.SearchResult);
            this.chequePropiosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.chequePropiosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSuc,
            this.colEmpresa,
            this.colEspecie,
            this.colDias,
            this.colDestino,
            this.colId_ProvFinancierosCuenta,
            this.colNroCheque,
            this.colFechaEmision,
            this.colFechaPago,
            this.colId_Especie,
            this.colImporte,
            this.colId_OrdenPago,
            this.colALaOrden,
            this.colFechaDepositado,
            this.colFechaRechazado,
            this.colMotivoRechazo,
            this.colImporteRechazo,
            this.colFechaDescuento,
            this.colId_Descuento,
            this.colBanco,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[Dias] >= 1 And [Dias] <= 30";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Blue;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[Dias] == 0";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "[Dias] > 30";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colSuc
            // 
            this.colSuc.FieldName = "Suc";
            this.colSuc.Name = "colSuc";
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colDias
            // 
            this.colDias.FieldName = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.OptionsColumn.ReadOnly = true;
            this.colDias.Visible = true;
            this.colDias.VisibleIndex = 0;
            // 
            // colDestino
            // 
            this.colDestino.FieldName = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.Visible = true;
            this.colDestino.VisibleIndex = 5;
            // 
            // colId_ProvFinancierosCuenta
            // 
            this.colId_ProvFinancierosCuenta.FieldName = "Id_ProvFinancierosCuenta";
            this.colId_ProvFinancierosCuenta.Name = "colId_ProvFinancierosCuenta";
            // 
            // colNroCheque
            // 
            this.colNroCheque.FieldName = "NroCheque";
            this.colNroCheque.Name = "colNroCheque";
            this.colNroCheque.Visible = true;
            this.colNroCheque.VisibleIndex = 1;
            // 
            // colFechaEmision
            // 
            this.colFechaEmision.Caption = "Fecha Emisión";
            this.colFechaEmision.FieldName = "FechaEmision";
            this.colFechaEmision.Name = "colFechaEmision";
            this.colFechaEmision.Visible = true;
            this.colFechaEmision.VisibleIndex = 2;
            // 
            // colFechaPago
            // 
            this.colFechaPago.FieldName = "FechaPago";
            this.colFechaPago.Name = "colFechaPago";
            this.colFechaPago.Visible = true;
            this.colFechaPago.VisibleIndex = 3;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 4;
            // 
            // colId_OrdenPago
            // 
            this.colId_OrdenPago.FieldName = "Id_OrdenPago";
            this.colId_OrdenPago.Name = "colId_OrdenPago";
            // 
            // colALaOrden
            // 
            this.colALaOrden.FieldName = "ALaOrden";
            this.colALaOrden.Name = "colALaOrden";
            // 
            // colFechaDepositado
            // 
            this.colFechaDepositado.FieldName = "FechaDepositado";
            this.colFechaDepositado.Name = "colFechaDepositado";
            // 
            // colFechaRechazado
            // 
            this.colFechaRechazado.FieldName = "FechaRechazado";
            this.colFechaRechazado.Name = "colFechaRechazado";
            // 
            // colMotivoRechazo
            // 
            this.colMotivoRechazo.FieldName = "MotivoRechazo";
            this.colMotivoRechazo.Name = "colMotivoRechazo";
            // 
            // colImporteRechazo
            // 
            this.colImporteRechazo.FieldName = "ImporteRechazo";
            this.colImporteRechazo.Name = "colImporteRechazo";
            // 
            // colFechaDescuento
            // 
            this.colFechaDescuento.FieldName = "FechaDescuento";
            this.colFechaDescuento.Name = "colFechaDescuento";
            // 
            // colId_Descuento
            // 
            this.colId_Descuento.FieldName = "Id_Descuento";
            this.colId_Descuento.Name = "colId_Descuento";
            // 
            // colBanco
            // 
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
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
            this.barSubItem2,
            this.btnDepositar,
            this.btnRechazar,
            this.btnAnularDeposito,
            this.btnAnularRechazo,
            this.barStaticItemFooter,
            this.barSubItem3,
            this.btnOP});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.btnResultado.Id = 4;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 5;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDepositar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRechazar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnularDeposito, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnularRechazo)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnDepositar
            // 
            this.btnDepositar.Caption = "Depositar";
            this.btnDepositar.Id = 6;
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepositar_ItemClick);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Caption = "Rechazar";
            this.btnRechazar.Id = 7;
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRechazar_ItemClick);
            // 
            // btnAnularDeposito
            // 
            this.btnAnularDeposito.Caption = "Anular Depósito";
            this.btnAnularDeposito.Id = 8;
            this.btnAnularDeposito.Name = "btnAnularDeposito";
            this.btnAnularDeposito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnularDeposito_ItemClick);
            // 
            // btnAnularRechazo
            // 
            this.btnAnularRechazo.Caption = "Anular Rechazo";
            this.btnAnularRechazo.Id = 9;
            this.btnAnularRechazo.Name = "btnAnularRechazo";
            this.btnAnularRechazo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnularRechazo_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Ver";
            this.barSubItem3.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem3.Id = 11;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOP, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnOP
            // 
            this.btnOP.Caption = "Orden de Pago";
            this.btnOP.Id = 16;
            this.btnOP.Name = "btnOP";
            this.btnOP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOP_ItemClick);
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
            this.barStaticItemFooter.Id = 10;
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
            this.panelControl1.Controls.Add(this.id_ProvFinancierosCuentaLookUpEdit);
            this.panelControl1.Controls.Add(id_ProvFinancierosCuentaLabel);
            this.panelControl1.Controls.Add(estadoLabel);
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Controls.Add(this.estadoLookUpEdit);
            this.panelControl1.Controls.Add(nroChequeLabel);
            this.panelControl1.Controls.Add(this.nroChequeTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 34);
            this.panelControl1.TabIndex = 0;
            // 
            // id_ProvFinancierosCuentaLookUpEdit
            // 
            this.id_ProvFinancierosCuentaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "Id_ProvFinancierosCuenta", true));
            this.id_ProvFinancierosCuentaLookUpEdit.Location = new System.Drawing.Point(246, 6);
            this.id_ProvFinancierosCuentaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvFinancierosCuentaLookUpEdit.Name = "id_ProvFinancierosCuentaLookUpEdit";
            this.id_ProvFinancierosCuentaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_ProvFinancierosCuentaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_ProvFinancierosCuentaLookUpEdit.Properties.NullText = "";
            this.id_ProvFinancierosCuentaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvFinancierosCuentaLookUpEdit.Size = new System.Drawing.Size(188, 20);
            this.id_ProvFinancierosCuentaLookUpEdit.TabIndex = 41;
            // 
            // chequePropiosManager_ParametrosBusquedasBindingSource
            // 
            this.chequePropiosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequePropiosManager.ParametrosBusquedas);
            // 
            // btnAvanzada
            // 
            this.btnAvanzada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvanzada.Image = global::VENET_Tesoreria_UI.Properties.Resources.filter_16x16;
            this.btnAvanzada.Location = new System.Drawing.Point(624, 4);
            this.btnAvanzada.Name = "btnAvanzada";
            this.btnAvanzada.Size = new System.Drawing.Size(23, 23);
            this.btnAvanzada.TabIndex = 11;
            this.btnAvanzada.CheckedChanged += new System.EventHandler(this.btnAvanzada_CheckedChanged);
            // 
            // estadoLookUpEdit
            // 
            this.estadoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "Estado", true));
            this.estadoLookUpEdit.Location = new System.Drawing.Point(49, 6);
            this.estadoLookUpEdit.MenuManager = this.barManager1;
            this.estadoLookUpEdit.Name = "estadoLookUpEdit";
            this.estadoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.estadoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Nombre2")});
            this.estadoLookUpEdit.Properties.NullText = "";
            this.estadoLookUpEdit.Properties.ShowHeader = false;
            this.estadoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.estadoLookUpEdit.TabIndex = 40;
            // 
            // nroChequeTextEdit
            // 
            this.nroChequeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "NroCheque", true));
            this.nroChequeTextEdit.EditValue = "";
            this.nroChequeTextEdit.EnterMoveNextControl = true;
            this.nroChequeTextEdit.Location = new System.Drawing.Point(518, 6);
            this.nroChequeTextEdit.MenuManager = this.barManager1;
            this.nroChequeTextEdit.Name = "nroChequeTextEdit";
            this.nroChequeTextEdit.Properties.MaxLength = 8;
            this.nroChequeTextEdit.Size = new System.Drawing.Size(54, 20);
            this.nroChequeTextEdit.TabIndex = 3;
            this.nroChequeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(651, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcBusquedaAvanzada
            // 
            this.gcBusquedaAvanzada.Controls.Add(id_SucursalLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.id_SucursalLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(aLaOrdenLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.aLaOrdenCheckEdit);
            this.gcBusquedaAvanzada.Controls.Add(rechazadoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.rechazadoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(rechazadoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.rechazadoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositadoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositadoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositadoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositadoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(importeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.importeTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(pagoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.pagoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(pagoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.pagoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(emisionHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.emisionHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(emisionDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.emisionDesdeDateEdit);
            this.gcBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 58);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 131);
            this.gcBusquedaAvanzada.TabIndex = 2;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(106, 24);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(254, 20);
            this.id_SucursalLookUpEdit.TabIndex = 0;
            this.id_SucursalLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_SucursalLookUpEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // aLaOrdenCheckEdit
            // 
            this.aLaOrdenCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "ALaOrden", true));
            this.aLaOrdenCheckEdit.EnterMoveNextControl = true;
            this.aLaOrdenCheckEdit.Location = new System.Drawing.Point(470, 50);
            this.aLaOrdenCheckEdit.MenuManager = this.barManager1;
            this.aLaOrdenCheckEdit.Name = "aLaOrdenCheckEdit";
            this.aLaOrdenCheckEdit.Properties.Caption = "";
            this.aLaOrdenCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.aLaOrdenCheckEdit.TabIndex = 5;
            // 
            // rechazadoHastaDateEdit
            // 
            this.rechazadoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "RechazadoHasta", true));
            this.rechazadoHastaDateEdit.EditValue = null;
            this.rechazadoHastaDateEdit.EnterMoveNextControl = true;
            this.rechazadoHastaDateEdit.Location = new System.Drawing.Point(623, 76);
            this.rechazadoHastaDateEdit.MenuManager = this.barManager1;
            this.rechazadoHastaDateEdit.Name = "rechazadoHastaDateEdit";
            this.rechazadoHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rechazadoHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rechazadoHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.rechazadoHastaDateEdit.TabIndex = 10;
            this.rechazadoHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // rechazadoDesdeDateEdit
            // 
            this.rechazadoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "RechazadoDesde", true));
            this.rechazadoDesdeDateEdit.EditValue = null;
            this.rechazadoDesdeDateEdit.EnterMoveNextControl = true;
            this.rechazadoDesdeDateEdit.Location = new System.Drawing.Point(472, 76);
            this.rechazadoDesdeDateEdit.MenuManager = this.barManager1;
            this.rechazadoDesdeDateEdit.Name = "rechazadoDesdeDateEdit";
            this.rechazadoDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rechazadoDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rechazadoDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.rechazadoDesdeDateEdit.TabIndex = 9;
            this.rechazadoDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // depositadoHastaDateEdit
            // 
            this.depositadoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "DepositadoHasta", true));
            this.depositadoHastaDateEdit.EditValue = null;
            this.depositadoHastaDateEdit.EnterMoveNextControl = true;
            this.depositadoHastaDateEdit.Location = new System.Drawing.Point(260, 102);
            this.depositadoHastaDateEdit.MenuManager = this.barManager1;
            this.depositadoHastaDateEdit.Name = "depositadoHastaDateEdit";
            this.depositadoHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositadoHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositadoHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.depositadoHastaDateEdit.TabIndex = 16;
            this.depositadoHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // depositadoDesdeDateEdit
            // 
            this.depositadoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "DepositadoDesde", true));
            this.depositadoDesdeDateEdit.EditValue = null;
            this.depositadoDesdeDateEdit.EnterMoveNextControl = true;
            this.depositadoDesdeDateEdit.Location = new System.Drawing.Point(106, 102);
            this.depositadoDesdeDateEdit.MenuManager = this.barManager1;
            this.depositadoDesdeDateEdit.Name = "depositadoDesdeDateEdit";
            this.depositadoDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositadoDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositadoDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.depositadoDesdeDateEdit.TabIndex = 15;
            this.depositadoDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(470, 24);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n2";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(102, 20);
            this.importeTextEdit.TabIndex = 2;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // pagoHastaDateEdit
            // 
            this.pagoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "PagoHasta", true));
            this.pagoHastaDateEdit.EditValue = null;
            this.pagoHastaDateEdit.EnterMoveNextControl = true;
            this.pagoHastaDateEdit.Location = new System.Drawing.Point(260, 76);
            this.pagoHastaDateEdit.MenuManager = this.barManager1;
            this.pagoHastaDateEdit.Name = "pagoHastaDateEdit";
            this.pagoHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pagoHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pagoHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.pagoHastaDateEdit.TabIndex = 8;
            this.pagoHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // pagoDesdeDateEdit
            // 
            this.pagoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "PagoDesde", true));
            this.pagoDesdeDateEdit.EditValue = null;
            this.pagoDesdeDateEdit.EnterMoveNextControl = true;
            this.pagoDesdeDateEdit.Location = new System.Drawing.Point(106, 76);
            this.pagoDesdeDateEdit.MenuManager = this.barManager1;
            this.pagoDesdeDateEdit.Name = "pagoDesdeDateEdit";
            this.pagoDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pagoDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pagoDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.pagoDesdeDateEdit.TabIndex = 7;
            this.pagoDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // emisionHastaDateEdit
            // 
            this.emisionHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "EmisionHasta", true));
            this.emisionHastaDateEdit.EditValue = null;
            this.emisionHastaDateEdit.EnterMoveNextControl = true;
            this.emisionHastaDateEdit.Location = new System.Drawing.Point(260, 50);
            this.emisionHastaDateEdit.MenuManager = this.barManager1;
            this.emisionHastaDateEdit.Name = "emisionHastaDateEdit";
            this.emisionHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.emisionHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.emisionHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.emisionHastaDateEdit.TabIndex = 4;
            this.emisionHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // emisionDesdeDateEdit
            // 
            this.emisionDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequePropiosManager_ParametrosBusquedasBindingSource, "EmisionDesde", true));
            this.emisionDesdeDateEdit.EditValue = null;
            this.emisionDesdeDateEdit.EnterMoveNextControl = true;
            this.emisionDesdeDateEdit.Location = new System.Drawing.Point(106, 50);
            this.emisionDesdeDateEdit.MenuManager = this.barManager1;
            this.emisionDesdeDateEdit.Name = "emisionDesdeDateEdit";
            this.emisionDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.emisionDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.emisionDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.emisionDesdeDateEdit.TabIndex = 3;
            this.emisionDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmChequesPropios
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
            this.MinimumSize = new System.Drawing.Size(750, 219);
            this.Name = "frmChequesPropios";
            this.Text = "Cheques Propios";
            this.Load += new System.EventHandler(this.frmChequePropios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequePropiosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancierosCuentaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequePropiosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroChequeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLaOrdenCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisionDesdeDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnDepositar;
        private DevExpress.XtraBars.BarButtonItem btnRechazar;
        private DevExpress.XtraBars.BarButtonItem btnAnularDeposito;
        private DevExpress.XtraBars.BarButtonItem btnAnularRechazo;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl gcBusquedaAvanzada;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.TextEdit nroChequeTextEdit;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private DevExpress.XtraEditors.DateEdit depositadoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit depositadoDesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.DateEdit pagoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit pagoDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit emisionHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit emisionDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit rechazadoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit rechazadoDesdeDateEdit;
        private DevExpress.XtraEditors.CheckEdit aLaOrdenCheckEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraEditors.LookUpEdit estadoLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnOP;
        private System.Windows.Forms.BindingSource chequePropiosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSuc;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colDias;
        private DevExpress.XtraGrid.Columns.GridColumn colDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProvFinancierosCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colNroCheque;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_OrdenPago;
        private DevExpress.XtraGrid.Columns.GridColumn colALaOrden;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDepositado;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaRechazado;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoRechazo;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteRechazo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Descuento;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private System.Windows.Forms.BindingSource chequePropiosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_ProvFinancierosCuentaLookUpEdit;
    }
}