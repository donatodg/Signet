namespace VENET_Tesoreria_UI
{
    partial class frmChequeTerceros
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
            System.Windows.Forms.Label id_EntidadBancariaLabel;
            System.Windows.Forms.Label sucursalLabel;
            System.Windows.Forms.Label codPostalLabel;
            System.Windows.Forms.Label nroChequeLabel;
            System.Windows.Forms.Label nroCtaLabel;
            System.Windows.Forms.Label emisionDesdeLabel;
            System.Windows.Forms.Label emisionHastaLabel;
            System.Windows.Forms.Label pagoDesdeLabel;
            System.Windows.Forms.Label pagoHastaLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label id_FirmanteLabel;
            System.Windows.Forms.Label depositadoDesdeLabel;
            System.Windows.Forms.Label depositadoHastaLabel;
            System.Windows.Forms.Label acreditacionDesdeLabel;
            System.Windows.Forms.Label acreditacionHastaLabel;
            System.Windows.Forms.Label depositoDesdeLabel;
            System.Windows.Forms.Label depositoHastaLabel;
            System.Windows.Forms.Label acreditadoDesdeLabel;
            System.Windows.Forms.Label acreditadoHastaLabel;
            System.Windows.Forms.Label rechazadoDesdeLabel;
            System.Windows.Forms.Label rechazadoHastaLabel;
            System.Windows.Forms.Label aLaOrdenLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label estadoLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.chequeTercerosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_EntidadBancaria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod_Postal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNro_Cheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNro_Cta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Emision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Pago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Firmante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Recibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Deposito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Acreditacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALaOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Depositado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Acreditado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Rechazado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoRechazo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Descuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_OrdenPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnDepositar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRechazar = new DevExpress.XtraBars.BarButtonItem();
            this.btnDescuento = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnularDeposito = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnularRechazo = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnRecibo = new DevExpress.XtraBars.BarButtonItem();
            this.btnOP = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoletaDeposito = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoletaDescuento = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.estadoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.chequeTercerosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.nroCtaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroChequeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codPostalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sucursalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.id_EntidadBancariaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.aLaOrdenCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.rechazadoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.rechazadoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.acreditadoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.acreditadoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.acreditacionHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.acreditacionDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositadoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.depositadoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_FirmanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.pagoHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.pagoDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.emisionHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.emisionDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            id_EntidadBancariaLabel = new System.Windows.Forms.Label();
            sucursalLabel = new System.Windows.Forms.Label();
            codPostalLabel = new System.Windows.Forms.Label();
            nroChequeLabel = new System.Windows.Forms.Label();
            nroCtaLabel = new System.Windows.Forms.Label();
            emisionDesdeLabel = new System.Windows.Forms.Label();
            emisionHastaLabel = new System.Windows.Forms.Label();
            pagoDesdeLabel = new System.Windows.Forms.Label();
            pagoHastaLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            id_FirmanteLabel = new System.Windows.Forms.Label();
            depositadoDesdeLabel = new System.Windows.Forms.Label();
            depositadoHastaLabel = new System.Windows.Forms.Label();
            acreditacionDesdeLabel = new System.Windows.Forms.Label();
            acreditacionHastaLabel = new System.Windows.Forms.Label();
            depositoDesdeLabel = new System.Windows.Forms.Label();
            depositoHastaLabel = new System.Windows.Forms.Label();
            acreditadoDesdeLabel = new System.Windows.Forms.Label();
            acreditadoHastaLabel = new System.Windows.Forms.Label();
            rechazadoDesdeLabel = new System.Windows.Forms.Label();
            rechazadoHastaLabel = new System.Windows.Forms.Label();
            aLaOrdenLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeTercerosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeTercerosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCtaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroChequeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadBancariaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLaOrdenCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_FirmanteLookUpEdit.Properties)).BeginInit();
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
            // id_EntidadBancariaLabel
            // 
            id_EntidadBancariaLabel.AutoSize = true;
            id_EntidadBancariaLabel.Location = new System.Drawing.Point(580, 79);
            id_EntidadBancariaLabel.Name = "id_EntidadBancariaLabel";
            id_EntidadBancariaLabel.Size = new System.Drawing.Size(40, 13);
            id_EntidadBancariaLabel.TabIndex = 1;
            id_EntidadBancariaLabel.Text = "Banco:";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new System.Drawing.Point(155, 9);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new System.Drawing.Size(51, 13);
            sucursalLabel.TabIndex = 3;
            sucursalLabel.Text = "Sucursal:";
            // 
            // codPostalLabel
            // 
            codPostalLabel.AutoSize = true;
            codPostalLabel.Location = new System.Drawing.Point(252, 9);
            codPostalLabel.Name = "codPostalLabel";
            codPostalLabel.Size = new System.Drawing.Size(62, 13);
            codPostalLabel.TabIndex = 5;
            codPostalLabel.Text = "Cod Postal:";
            // 
            // nroChequeLabel
            // 
            nroChequeLabel.AutoSize = true;
            nroChequeLabel.Location = new System.Drawing.Point(362, 9);
            nroChequeLabel.Name = "nroChequeLabel";
            nroChequeLabel.Size = new System.Drawing.Size(68, 13);
            nroChequeLabel.TabIndex = 7;
            nroChequeLabel.Text = "Nro Cheque:";
            // 
            // nroCtaLabel
            // 
            nroCtaLabel.AutoSize = true;
            nroCtaLabel.Location = new System.Drawing.Point(491, 9);
            nroCtaLabel.Name = "nroCtaLabel";
            nroCtaLabel.Size = new System.Drawing.Size(48, 13);
            nroCtaLabel.TabIndex = 9;
            nroCtaLabel.Text = "Nro Cta:";
            // 
            // emisionDesdeLabel
            // 
            emisionDesdeLabel.AutoSize = true;
            emisionDesdeLabel.Location = new System.Drawing.Point(24, 79);
            emisionDesdeLabel.Name = "emisionDesdeLabel";
            emisionDesdeLabel.Size = new System.Drawing.Size(79, 13);
            emisionDesdeLabel.TabIndex = 4;
            emisionDesdeLabel.Text = "Emisión Desde:";
            // 
            // emisionHastaLabel
            // 
            emisionHastaLabel.AutoSize = true;
            emisionHastaLabel.Location = new System.Drawing.Point(218, 79);
            emisionHastaLabel.Name = "emisionHastaLabel";
            emisionHastaLabel.Size = new System.Drawing.Size(39, 13);
            emisionHastaLabel.TabIndex = 6;
            emisionHastaLabel.Text = "Hasta:";
            // 
            // pagoDesdeLabel
            // 
            pagoDesdeLabel.AutoSize = true;
            pagoDesdeLabel.Location = new System.Drawing.Point(35, 105);
            pagoDesdeLabel.Name = "pagoDesdeLabel";
            pagoDesdeLabel.Size = new System.Drawing.Size(68, 13);
            pagoDesdeLabel.TabIndex = 8;
            pagoDesdeLabel.Text = "Pago Desde:";
            // 
            // pagoHastaLabel
            // 
            pagoHastaLabel.AutoSize = true;
            pagoHastaLabel.Location = new System.Drawing.Point(218, 105);
            pagoHastaLabel.Name = "pagoHastaLabel";
            pagoHastaLabel.Size = new System.Drawing.Size(39, 13);
            pagoHastaLabel.TabIndex = 10;
            pagoHastaLabel.Text = "Hasta:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(418, 53);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 12;
            importeLabel.Text = "Importe:";
            // 
            // id_FirmanteLabel
            // 
            id_FirmanteLabel.AutoSize = true;
            id_FirmanteLabel.Location = new System.Drawing.Point(50, 53);
            id_FirmanteLabel.Name = "id_FirmanteLabel";
            id_FirmanteLabel.Size = new System.Drawing.Size(53, 13);
            id_FirmanteLabel.TabIndex = 14;
            id_FirmanteLabel.Text = "Firmante:";
            // 
            // depositadoDesdeLabel
            // 
            depositadoDesdeLabel.AutoSize = true;
            depositadoDesdeLabel.Location = new System.Drawing.Point(5, 157);
            depositadoDesdeLabel.Name = "depositadoDesdeLabel";
            depositadoDesdeLabel.Size = new System.Drawing.Size(98, 13);
            depositadoDesdeLabel.TabIndex = 16;
            depositadoDesdeLabel.Text = "Depositado Desde:";
            // 
            // depositadoHastaLabel
            // 
            depositadoHastaLabel.AutoSize = true;
            depositadoHastaLabel.Location = new System.Drawing.Point(218, 157);
            depositadoHastaLabel.Name = "depositadoHastaLabel";
            depositadoHastaLabel.Size = new System.Drawing.Size(39, 13);
            depositadoHastaLabel.TabIndex = 18;
            depositadoHastaLabel.Text = "Hasta:";
            // 
            // acreditacionDesdeLabel
            // 
            acreditacionDesdeLabel.AutoSize = true;
            acreditacionDesdeLabel.Location = new System.Drawing.Point(366, 131);
            acreditacionDesdeLabel.Name = "acreditacionDesdeLabel";
            acreditacionDesdeLabel.Size = new System.Drawing.Size(103, 13);
            acreditacionDesdeLabel.TabIndex = 20;
            acreditacionDesdeLabel.Text = "Acreditación Desde:";
            // 
            // acreditacionHastaLabel
            // 
            acreditacionHastaLabel.AutoSize = true;
            acreditacionHastaLabel.Location = new System.Drawing.Point(581, 131);
            acreditacionHastaLabel.Name = "acreditacionHastaLabel";
            acreditacionHastaLabel.Size = new System.Drawing.Size(39, 13);
            acreditacionHastaLabel.TabIndex = 22;
            acreditacionHastaLabel.Text = "Hasta:";
            // 
            // depositoDesdeLabel
            // 
            depositoDesdeLabel.AutoSize = true;
            depositoDesdeLabel.Location = new System.Drawing.Point(17, 131);
            depositoDesdeLabel.Name = "depositoDesdeLabel";
            depositoDesdeLabel.Size = new System.Drawing.Size(86, 13);
            depositoDesdeLabel.TabIndex = 24;
            depositoDesdeLabel.Text = "Depósito Desde:";
            // 
            // depositoHastaLabel
            // 
            depositoHastaLabel.AutoSize = true;
            depositoHastaLabel.Location = new System.Drawing.Point(218, 131);
            depositoHastaLabel.Name = "depositoHastaLabel";
            depositoHastaLabel.Size = new System.Drawing.Size(39, 13);
            depositoHastaLabel.TabIndex = 26;
            depositoHastaLabel.Text = "Hasta:";
            // 
            // acreditadoDesdeLabel
            // 
            acreditadoDesdeLabel.AutoSize = true;
            acreditadoDesdeLabel.Location = new System.Drawing.Point(373, 157);
            acreditadoDesdeLabel.Name = "acreditadoDesdeLabel";
            acreditadoDesdeLabel.Size = new System.Drawing.Size(96, 13);
            acreditadoDesdeLabel.TabIndex = 28;
            acreditadoDesdeLabel.Text = "Acreditado Desde:";
            // 
            // acreditadoHastaLabel
            // 
            acreditadoHastaLabel.AutoSize = true;
            acreditadoHastaLabel.Location = new System.Drawing.Point(581, 157);
            acreditadoHastaLabel.Name = "acreditadoHastaLabel";
            acreditadoHastaLabel.Size = new System.Drawing.Size(39, 13);
            acreditadoHastaLabel.TabIndex = 30;
            acreditadoHastaLabel.Text = "Hasta:";
            // 
            // rechazadoDesdeLabel
            // 
            rechazadoDesdeLabel.AutoSize = true;
            rechazadoDesdeLabel.Location = new System.Drawing.Point(372, 105);
            rechazadoDesdeLabel.Name = "rechazadoDesdeLabel";
            rechazadoDesdeLabel.Size = new System.Drawing.Size(97, 13);
            rechazadoDesdeLabel.TabIndex = 32;
            rechazadoDesdeLabel.Text = "Rechazado Desde:";
            // 
            // rechazadoHastaLabel
            // 
            rechazadoHastaLabel.AutoSize = true;
            rechazadoHastaLabel.Location = new System.Drawing.Point(581, 105);
            rechazadoHastaLabel.Name = "rechazadoHastaLabel";
            rechazadoHastaLabel.Size = new System.Drawing.Size(39, 13);
            rechazadoHastaLabel.TabIndex = 34;
            rechazadoHastaLabel.Text = "Hasta:";
            // 
            // aLaOrdenLabel
            // 
            aLaOrdenLabel.AutoSize = true;
            aLaOrdenLabel.Location = new System.Drawing.Point(407, 79);
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
            // gridControl1
            // 
            this.gridControl1.DataSource = this.chequeTercerosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 245);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 191);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // chequeTercerosManager_SearchResultBindingSource
            // 
            this.chequeTercerosManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequeTercerosManager.SearchResult);
            this.chequeTercerosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.chequeTercerosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBanco,
            this.colId_EntidadBancaria,
            this.colSucursal,
            this.colCod_Postal,
            this.colNro_Cheque,
            this.colNro_Cta,
            this.colFecha_Emision,
            this.colFecha_Pago,
            this.colImporte,
            this.colId_Firmante,
            this.colId_Recibo,
            this.colFecha_Deposito,
            this.colFecha_Acreditacion,
            this.colALaOrden,
            this.colFecha_Depositado,
            this.colFecha_Acreditado,
            this.colFecha_Rechazado,
            this.colMotivoRechazo,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colIdSucursal,
            this.colSuc,
            this.colEmpresa,
            this.colDias,
            this.colId_Descuento,
            this.colEspecie,
            this.colId_Especie,
            this.colOrigen,
            this.colDestino,
            this.colId_OrdenPago});
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
            // colBanco
            // 
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.OptionsColumn.AllowEdit = false;
            this.colBanco.OptionsColumn.ReadOnly = true;
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 2;
            // 
            // colId_EntidadBancaria
            // 
            this.colId_EntidadBancaria.FieldName = "Id_EntidadBancaria";
            this.colId_EntidadBancaria.Name = "colId_EntidadBancaria";
            this.colId_EntidadBancaria.OptionsColumn.AllowEdit = false;
            this.colId_EntidadBancaria.OptionsColumn.ReadOnly = true;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.OptionsColumn.AllowEdit = false;
            this.colSucursal.OptionsColumn.ReadOnly = true;
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 3;
            // 
            // colCod_Postal
            // 
            this.colCod_Postal.Caption = "Cod Postal";
            this.colCod_Postal.FieldName = "CodPostal";
            this.colCod_Postal.Name = "colCod_Postal";
            this.colCod_Postal.OptionsColumn.AllowEdit = false;
            this.colCod_Postal.OptionsColumn.ReadOnly = true;
            // 
            // colNro_Cheque
            // 
            this.colNro_Cheque.Caption = "Nro Cheque";
            this.colNro_Cheque.FieldName = "NroCheque";
            this.colNro_Cheque.Name = "colNro_Cheque";
            this.colNro_Cheque.OptionsColumn.AllowEdit = false;
            this.colNro_Cheque.OptionsColumn.ReadOnly = true;
            this.colNro_Cheque.Visible = true;
            this.colNro_Cheque.VisibleIndex = 4;
            // 
            // colNro_Cta
            // 
            this.colNro_Cta.Caption = "Nro Cta";
            this.colNro_Cta.FieldName = "NroCta";
            this.colNro_Cta.Name = "colNro_Cta";
            this.colNro_Cta.OptionsColumn.AllowEdit = false;
            this.colNro_Cta.OptionsColumn.ReadOnly = true;
            this.colNro_Cta.Visible = true;
            this.colNro_Cta.VisibleIndex = 5;
            // 
            // colFecha_Emision
            // 
            this.colFecha_Emision.Caption = "F.Emisión";
            this.colFecha_Emision.FieldName = "FechaEmision";
            this.colFecha_Emision.Name = "colFecha_Emision";
            this.colFecha_Emision.OptionsColumn.AllowEdit = false;
            this.colFecha_Emision.OptionsColumn.ReadOnly = true;
            this.colFecha_Emision.Visible = true;
            this.colFecha_Emision.VisibleIndex = 6;
            // 
            // colFecha_Pago
            // 
            this.colFecha_Pago.Caption = "F.Pago";
            this.colFecha_Pago.FieldName = "FechaPago";
            this.colFecha_Pago.Name = "colFecha_Pago";
            this.colFecha_Pago.OptionsColumn.AllowEdit = false;
            this.colFecha_Pago.OptionsColumn.ReadOnly = true;
            this.colFecha_Pago.Visible = true;
            this.colFecha_Pago.VisibleIndex = 7;
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
            this.colImporte.VisibleIndex = 8;
            // 
            // colId_Firmante
            // 
            this.colId_Firmante.FieldName = "Id_Firmante";
            this.colId_Firmante.Name = "colId_Firmante";
            this.colId_Firmante.OptionsColumn.AllowEdit = false;
            this.colId_Firmante.OptionsColumn.ReadOnly = true;
            // 
            // colId_Recibo
            // 
            this.colId_Recibo.FieldName = "Id_Recibo";
            this.colId_Recibo.Name = "colId_Recibo";
            this.colId_Recibo.OptionsColumn.AllowEdit = false;
            this.colId_Recibo.OptionsColumn.ReadOnly = true;
            // 
            // colFecha_Deposito
            // 
            this.colFecha_Deposito.Caption = "F.Depósito";
            this.colFecha_Deposito.FieldName = "FechaDeposito";
            this.colFecha_Deposito.Name = "colFecha_Deposito";
            this.colFecha_Deposito.OptionsColumn.AllowEdit = false;
            this.colFecha_Deposito.OptionsColumn.ReadOnly = true;
            this.colFecha_Deposito.Visible = true;
            this.colFecha_Deposito.VisibleIndex = 9;
            // 
            // colFecha_Acreditacion
            // 
            this.colFecha_Acreditacion.Caption = "F.Acreditación";
            this.colFecha_Acreditacion.FieldName = "FechaAcreditacion";
            this.colFecha_Acreditacion.Name = "colFecha_Acreditacion";
            this.colFecha_Acreditacion.OptionsColumn.AllowEdit = false;
            this.colFecha_Acreditacion.OptionsColumn.ReadOnly = true;
            this.colFecha_Acreditacion.Visible = true;
            this.colFecha_Acreditacion.VisibleIndex = 10;
            // 
            // colALaOrden
            // 
            this.colALaOrden.FieldName = "ALaOrden";
            this.colALaOrden.Name = "colALaOrden";
            this.colALaOrden.OptionsColumn.AllowEdit = false;
            this.colALaOrden.OptionsColumn.ReadOnly = true;
            // 
            // colFecha_Depositado
            // 
            this.colFecha_Depositado.Caption = "F.Depositado";
            this.colFecha_Depositado.FieldName = "FechaDepositado";
            this.colFecha_Depositado.Name = "colFecha_Depositado";
            this.colFecha_Depositado.OptionsColumn.AllowEdit = false;
            this.colFecha_Depositado.OptionsColumn.ReadOnly = true;
            // 
            // colFecha_Acreditado
            // 
            this.colFecha_Acreditado.Caption = "F.Acreditado";
            this.colFecha_Acreditado.FieldName = "FechaAcreditado";
            this.colFecha_Acreditado.Name = "colFecha_Acreditado";
            this.colFecha_Acreditado.OptionsColumn.AllowEdit = false;
            this.colFecha_Acreditado.OptionsColumn.ReadOnly = true;
            // 
            // colFecha_Rechazado
            // 
            this.colFecha_Rechazado.Caption = "F.Rechazado";
            this.colFecha_Rechazado.FieldName = "FechaRechazado";
            this.colFecha_Rechazado.Name = "colFecha_Rechazado";
            this.colFecha_Rechazado.OptionsColumn.AllowEdit = false;
            this.colFecha_Rechazado.OptionsColumn.ReadOnly = true;
            // 
            // colMotivoRechazo
            // 
            this.colMotivoRechazo.FieldName = "MotivoRechazo";
            this.colMotivoRechazo.Name = "colMotivoRechazo";
            this.colMotivoRechazo.OptionsColumn.AllowEdit = false;
            this.colMotivoRechazo.OptionsColumn.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
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
            // colIdSucursal
            // 
            this.colIdSucursal.Caption = "Id_Sucursal";
            this.colIdSucursal.FieldName = "Id_Sucursal";
            this.colIdSucursal.Name = "colIdSucursal";
            this.colIdSucursal.OptionsColumn.AllowEdit = false;
            this.colIdSucursal.OptionsColumn.ReadOnly = true;
            // 
            // colSuc
            // 
            this.colSuc.Caption = "Suc. Propia";
            this.colSuc.FieldName = "Suc";
            this.colSuc.Name = "colSuc";
            this.colSuc.OptionsColumn.AllowEdit = false;
            this.colSuc.OptionsColumn.ReadOnly = true;
            this.colSuc.Visible = true;
            this.colSuc.VisibleIndex = 1;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 0;
            // 
            // colDias
            // 
            this.colDias.Caption = "Dias";
            this.colDias.FieldName = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.OptionsColumn.AllowEdit = false;
            this.colDias.OptionsColumn.ReadOnly = true;
            this.colDias.Visible = true;
            this.colDias.VisibleIndex = 11;
            // 
            // colId_Descuento
            // 
            this.colId_Descuento.Caption = "Id_Descuento";
            this.colId_Descuento.FieldName = "Id_Descuento";
            this.colId_Descuento.Name = "colId_Descuento";
            this.colId_Descuento.OptionsColumn.AllowEdit = false;
            this.colId_Descuento.OptionsColumn.ReadOnly = true;
            // 
            // colEspecie
            // 
            this.colEspecie.Caption = "Especie";
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.OptionsColumn.AllowEdit = false;
            this.colEspecie.OptionsColumn.ReadOnly = true;
            // 
            // colId_Especie
            // 
            this.colId_Especie.Caption = "Id_Especie";
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            this.colId_Especie.OptionsColumn.AllowEdit = false;
            this.colId_Especie.OptionsColumn.ReadOnly = true;
            // 
            // colOrigen
            // 
            this.colOrigen.Caption = "Origen";
            this.colOrigen.FieldName = "Origen";
            this.colOrigen.Name = "colOrigen";
            // 
            // colDestino
            // 
            this.colDestino.Caption = "Destino";
            this.colDestino.FieldName = "Destino";
            this.colDestino.Name = "colDestino";
            // 
            // colId_OrdenPago
            // 
            this.colId_OrdenPago.Caption = "Id_OrdenPago";
            this.colId_OrdenPago.FieldName = "Id_OrdenPago";
            this.colId_OrdenPago.Name = "colId_OrdenPago";
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
            this.btnRecibo,
            this.btnBoletaDeposito,
            this.btnDescuento,
            this.btnBoletaDescuento,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDescuento, true),
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
            // btnDescuento
            // 
            this.btnDescuento.Caption = "Descontar";
            this.btnDescuento.Id = 14;
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDescuento_ItemClick);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRecibo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOP, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBoletaDeposito, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBoletaDescuento, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnRecibo
            // 
            this.btnRecibo.Caption = "Recibo";
            this.btnRecibo.Id = 12;
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecibo_ItemClick);
            // 
            // btnOP
            // 
            this.btnOP.Caption = "Orden de Pago";
            this.btnOP.Id = 16;
            this.btnOP.Name = "btnOP";
            this.btnOP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOP_ItemClick);
            // 
            // btnBoletaDeposito
            // 
            this.btnBoletaDeposito.Caption = "Boleta de Depósito";
            this.btnBoletaDeposito.Id = 13;
            this.btnBoletaDeposito.Name = "btnBoletaDeposito";
            this.btnBoletaDeposito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoletaDeposito_ItemClick);
            // 
            // btnBoletaDescuento
            // 
            this.btnBoletaDescuento.Caption = "Boleta de Descuento";
            this.btnBoletaDescuento.Id = 15;
            this.btnBoletaDescuento.Name = "btnBoletaDescuento";
            this.btnBoletaDescuento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoletaDescuento_ItemClick);
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
            this.panelControl1.Controls.Add(estadoLabel);
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Controls.Add(this.estadoLookUpEdit);
            this.panelControl1.Controls.Add(nroCtaLabel);
            this.panelControl1.Controls.Add(this.nroCtaTextEdit);
            this.panelControl1.Controls.Add(nroChequeLabel);
            this.panelControl1.Controls.Add(this.nroChequeTextEdit);
            this.panelControl1.Controls.Add(codPostalLabel);
            this.panelControl1.Controls.Add(this.codPostalTextEdit);
            this.panelControl1.Controls.Add(sucursalLabel);
            this.panelControl1.Controls.Add(this.sucursalTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 0;
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
            this.estadoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Estado", true));
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
            // chequeTercerosManager_ParametrosBusquedasBindingSource
            // 
            this.chequeTercerosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequeTercerosManager.ParametrosBusquedas);
            // 
            // nroCtaTextEdit
            // 
            this.nroCtaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "NroCta", true));
            this.nroCtaTextEdit.EditValue = "";
            this.nroCtaTextEdit.EnterMoveNextControl = true;
            this.nroCtaTextEdit.Location = new System.Drawing.Point(539, 6);
            this.nroCtaTextEdit.MenuManager = this.barManager1;
            this.nroCtaTextEdit.Name = "nroCtaTextEdit";
            this.nroCtaTextEdit.Properties.MaxLength = 11;
            this.nroCtaTextEdit.Size = new System.Drawing.Size(80, 20);
            this.nroCtaTextEdit.TabIndex = 4;
            this.nroCtaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroChequeTextEdit
            // 
            this.nroChequeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "NroCheque", true));
            this.nroChequeTextEdit.EditValue = "";
            this.nroChequeTextEdit.EnterMoveNextControl = true;
            this.nroChequeTextEdit.Location = new System.Drawing.Point(431, 6);
            this.nroChequeTextEdit.MenuManager = this.barManager1;
            this.nroChequeTextEdit.Name = "nroChequeTextEdit";
            this.nroChequeTextEdit.Properties.MaxLength = 8;
            this.nroChequeTextEdit.Size = new System.Drawing.Size(54, 20);
            this.nroChequeTextEdit.TabIndex = 3;
            this.nroChequeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // codPostalTextEdit
            // 
            this.codPostalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "CodPostal", true));
            this.codPostalTextEdit.EditValue = "";
            this.codPostalTextEdit.EnterMoveNextControl = true;
            this.codPostalTextEdit.Location = new System.Drawing.Point(315, 6);
            this.codPostalTextEdit.MenuManager = this.barManager1;
            this.codPostalTextEdit.Name = "codPostalTextEdit";
            this.codPostalTextEdit.Properties.MaxLength = 4;
            this.codPostalTextEdit.Size = new System.Drawing.Size(41, 20);
            this.codPostalTextEdit.TabIndex = 2;
            this.codPostalTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // sucursalTextEdit
            // 
            this.sucursalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Sucursal", true));
            this.sucursalTextEdit.EnterMoveNextControl = true;
            this.sucursalTextEdit.Location = new System.Drawing.Point(208, 6);
            this.sucursalTextEdit.MenuManager = this.barManager1;
            this.sucursalTextEdit.Name = "sucursalTextEdit";
            this.sucursalTextEdit.Properties.MaxLength = 3;
            this.sucursalTextEdit.Size = new System.Drawing.Size(38, 20);
            this.sucursalTextEdit.TabIndex = 1;
            this.sucursalTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
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
            // id_EntidadBancariaLookUpEdit
            // 
            this.id_EntidadBancariaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Id_EntidadBancaria", true));
            this.id_EntidadBancariaLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadBancariaLookUpEdit.Location = new System.Drawing.Point(623, 76);
            this.id_EntidadBancariaLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadBancariaLookUpEdit.Name = "id_EntidadBancariaLookUpEdit";
            this.id_EntidadBancariaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EntidadBancariaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Codigo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.id_EntidadBancariaLookUpEdit.Properties.NullText = "";
            this.id_EntidadBancariaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_EntidadBancariaLookUpEdit.TabIndex = 6;
            this.id_EntidadBancariaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
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
            this.gcBusquedaAvanzada.Controls.Add(this.id_EntidadBancariaLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(id_EntidadBancariaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.rechazadoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(acreditadoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.acreditadoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(acreditadoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.acreditadoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(acreditacionHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.acreditacionHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(acreditacionDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.acreditacionDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositadoHastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositadoHastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(depositadoDesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.depositadoDesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(id_FirmanteLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.id_FirmanteLookUpEdit);
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
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 57);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 188);
            this.gcBusquedaAvanzada.TabIndex = 2;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
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
            this.aLaOrdenCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "ALaOrden", true));
            this.aLaOrdenCheckEdit.EnterMoveNextControl = true;
            this.aLaOrdenCheckEdit.Location = new System.Drawing.Point(470, 76);
            this.aLaOrdenCheckEdit.MenuManager = this.barManager1;
            this.aLaOrdenCheckEdit.Name = "aLaOrdenCheckEdit";
            this.aLaOrdenCheckEdit.Properties.Caption = "";
            this.aLaOrdenCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.aLaOrdenCheckEdit.TabIndex = 5;
            // 
            // rechazadoHastaDateEdit
            // 
            this.rechazadoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "RechazadoHasta", true));
            this.rechazadoHastaDateEdit.EditValue = null;
            this.rechazadoHastaDateEdit.EnterMoveNextControl = true;
            this.rechazadoHastaDateEdit.Location = new System.Drawing.Point(623, 102);
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
            this.rechazadoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "RechazadoDesde", true));
            this.rechazadoDesdeDateEdit.EditValue = null;
            this.rechazadoDesdeDateEdit.EnterMoveNextControl = true;
            this.rechazadoDesdeDateEdit.Location = new System.Drawing.Point(472, 102);
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
            // acreditadoHastaDateEdit
            // 
            this.acreditadoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "AcreditadoHasta", true));
            this.acreditadoHastaDateEdit.EditValue = null;
            this.acreditadoHastaDateEdit.EnterMoveNextControl = true;
            this.acreditadoHastaDateEdit.Location = new System.Drawing.Point(623, 154);
            this.acreditadoHastaDateEdit.MenuManager = this.barManager1;
            this.acreditadoHastaDateEdit.Name = "acreditadoHastaDateEdit";
            this.acreditadoHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditadoHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditadoHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.acreditadoHastaDateEdit.TabIndex = 18;
            this.acreditadoHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // acreditadoDesdeDateEdit
            // 
            this.acreditadoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "AcreditadoDesde", true));
            this.acreditadoDesdeDateEdit.EditValue = null;
            this.acreditadoDesdeDateEdit.EnterMoveNextControl = true;
            this.acreditadoDesdeDateEdit.Location = new System.Drawing.Point(472, 154);
            this.acreditadoDesdeDateEdit.MenuManager = this.barManager1;
            this.acreditadoDesdeDateEdit.Name = "acreditadoDesdeDateEdit";
            this.acreditadoDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditadoDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditadoDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.acreditadoDesdeDateEdit.TabIndex = 17;
            this.acreditadoDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // depositoHastaDateEdit
            // 
            this.depositoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "DepositoHasta", true));
            this.depositoHastaDateEdit.EditValue = null;
            this.depositoHastaDateEdit.EnterMoveNextControl = true;
            this.depositoHastaDateEdit.Location = new System.Drawing.Point(260, 128);
            this.depositoHastaDateEdit.MenuManager = this.barManager1;
            this.depositoHastaDateEdit.Name = "depositoHastaDateEdit";
            this.depositoHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositoHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositoHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.depositoHastaDateEdit.TabIndex = 12;
            this.depositoHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // depositoDesdeDateEdit
            // 
            this.depositoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "DepositoDesde", true));
            this.depositoDesdeDateEdit.EditValue = null;
            this.depositoDesdeDateEdit.EnterMoveNextControl = true;
            this.depositoDesdeDateEdit.Location = new System.Drawing.Point(106, 128);
            this.depositoDesdeDateEdit.MenuManager = this.barManager1;
            this.depositoDesdeDateEdit.Name = "depositoDesdeDateEdit";
            this.depositoDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositoDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.depositoDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.depositoDesdeDateEdit.TabIndex = 11;
            this.depositoDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // acreditacionHastaDateEdit
            // 
            this.acreditacionHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "AcreditacionHasta", true));
            this.acreditacionHastaDateEdit.EditValue = null;
            this.acreditacionHastaDateEdit.EnterMoveNextControl = true;
            this.acreditacionHastaDateEdit.Location = new System.Drawing.Point(623, 128);
            this.acreditacionHastaDateEdit.MenuManager = this.barManager1;
            this.acreditacionHastaDateEdit.Name = "acreditacionHastaDateEdit";
            this.acreditacionHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditacionHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditacionHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.acreditacionHastaDateEdit.TabIndex = 14;
            this.acreditacionHastaDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // acreditacionDesdeDateEdit
            // 
            this.acreditacionDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "AcreditacionDesde", true));
            this.acreditacionDesdeDateEdit.EditValue = null;
            this.acreditacionDesdeDateEdit.EnterMoveNextControl = true;
            this.acreditacionDesdeDateEdit.Location = new System.Drawing.Point(472, 128);
            this.acreditacionDesdeDateEdit.MenuManager = this.barManager1;
            this.acreditacionDesdeDateEdit.Name = "acreditacionDesdeDateEdit";
            this.acreditacionDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditacionDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.acreditacionDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.acreditacionDesdeDateEdit.TabIndex = 13;
            this.acreditacionDesdeDateEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // depositadoHastaDateEdit
            // 
            this.depositadoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "DepositadoHasta", true));
            this.depositadoHastaDateEdit.EditValue = null;
            this.depositadoHastaDateEdit.EnterMoveNextControl = true;
            this.depositadoHastaDateEdit.Location = new System.Drawing.Point(260, 154);
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
            this.depositadoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "DepositadoDesde", true));
            this.depositadoDesdeDateEdit.EditValue = null;
            this.depositadoDesdeDateEdit.EnterMoveNextControl = true;
            this.depositadoDesdeDateEdit.Location = new System.Drawing.Point(106, 154);
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
            // id_FirmanteLookUpEdit
            // 
            this.id_FirmanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Id_Firmante", true));
            this.id_FirmanteLookUpEdit.EnterMoveNextControl = true;
            this.id_FirmanteLookUpEdit.Location = new System.Drawing.Point(106, 50);
            this.id_FirmanteLookUpEdit.MenuManager = this.barManager1;
            this.id_FirmanteLookUpEdit.Name = "id_FirmanteLookUpEdit";
            this.id_FirmanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_FirmanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cuit", "Cuit"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.id_FirmanteLookUpEdit.Properties.NullText = "";
            this.id_FirmanteLookUpEdit.Size = new System.Drawing.Size(254, 20);
            this.id_FirmanteLookUpEdit.TabIndex = 1;
            this.id_FirmanteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(470, 50);
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
            this.pagoHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "PagoHasta", true));
            this.pagoHastaDateEdit.EditValue = null;
            this.pagoHastaDateEdit.EnterMoveNextControl = true;
            this.pagoHastaDateEdit.Location = new System.Drawing.Point(260, 102);
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
            this.pagoDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "PagoDesde", true));
            this.pagoDesdeDateEdit.EditValue = null;
            this.pagoDesdeDateEdit.EnterMoveNextControl = true;
            this.pagoDesdeDateEdit.Location = new System.Drawing.Point(106, 102);
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
            this.emisionHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "EmisionHasta", true));
            this.emisionHastaDateEdit.EditValue = null;
            this.emisionHastaDateEdit.EnterMoveNextControl = true;
            this.emisionHastaDateEdit.Location = new System.Drawing.Point(260, 76);
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
            this.emisionDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeTercerosManager_ParametrosBusquedasBindingSource, "EmisionDesde", true));
            this.emisionDesdeDateEdit.EditValue = null;
            this.emisionDesdeDateEdit.EnterMoveNextControl = true;
            this.emisionDesdeDateEdit.Location = new System.Drawing.Point(106, 76);
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
            // frmChequeTerceros
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
            this.Name = "frmChequeTerceros";
            this.Text = "Cheques de Terceros";
            this.Load += new System.EventHandler(this.frmChequeTerceros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeTercerosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeTercerosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCtaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroChequeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadBancariaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLaOrdenCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechazadoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditadoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acreditacionDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositadoDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_FirmanteLookUpEdit.Properties)).EndInit();
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
        private System.Windows.Forms.BindingSource chequeTercerosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EntidadBancaria;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colCod_Postal;
        private DevExpress.XtraGrid.Columns.GridColumn colNro_Cheque;
        private DevExpress.XtraGrid.Columns.GridColumn colNro_Cta;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Emision;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Pago;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Firmante;
        //private DevExpress.XtraGrid.Columns.GridColumn colTipoEntidad;
        //private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Recibo;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Deposito;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Acreditacion;
        private DevExpress.XtraGrid.Columns.GridColumn colALaOrden;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Depositado;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Acreditado;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Rechazado;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoRechazo;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadBancariaLookUpEdit;
        private System.Windows.Forms.BindingSource chequeTercerosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit nroCtaTextEdit;
        private DevExpress.XtraEditors.TextEdit nroChequeTextEdit;
        private DevExpress.XtraEditors.TextEdit codPostalTextEdit;
        private DevExpress.XtraEditors.TextEdit sucursalTextEdit;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private DevExpress.XtraEditors.DateEdit depositadoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit depositadoDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_FirmanteLookUpEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.DateEdit pagoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit pagoDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit emisionHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit emisionDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit depositoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit depositoDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit acreditacionHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit acreditacionDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit rechazadoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit rechazadoDesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit acreditadoHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit acreditadoDesdeDateEdit;
        private DevExpress.XtraEditors.CheckEdit aLaOrdenCheckEdit;
        //private System.Windows.Forms.BindingSource entidadBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colSuc;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnRecibo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colDias;
        private DevExpress.XtraEditors.LookUpEdit estadoLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnBoletaDeposito;
        private DevExpress.XtraBars.BarButtonItem btnDescuento;
        private DevExpress.XtraBars.BarButtonItem btnBoletaDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Descuento;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colId_OrdenPago;
        private DevExpress.XtraBars.BarButtonItem btnOP;
    }
}