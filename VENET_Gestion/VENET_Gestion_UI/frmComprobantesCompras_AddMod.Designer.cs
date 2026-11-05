namespace VENET_Gestion_UI
{
    partial class frmComprobantesCompras_AddMod
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
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label fechaVtoLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label fechaEntregaLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label id_FormaPagoLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.Windows.Forms.Label id_EntidadLabel;
            System.Windows.Forms.Label retencionesLabel;
            System.Windows.Forms.Label percepcionIvaLabel;
            System.Windows.Forms.Label percepcionIIBBLabel;
            System.Windows.Forms.Label otrosImpuestosLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label puntoVentaLabel;
            System.Windows.Forms.Label nroComprobanteLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label descuentoLabel;
            System.Windows.Forms.Label id_DepositoLabel;
            System.Windows.Forms.Label iTCLabel;
            System.Windows.Forms.Label impuestoNoGravadoLabel;
            System.Windows.Forms.Label percepcionIIBBCapitalLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprobantesCompras_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.id_DepositoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.comprobantesComprasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nroComprobanteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.puntoVentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.letraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaVtoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.observacionesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaEntregaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_FormaPagoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.percepcionIIBBCapitalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.impuestoNoGravadoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.iTCTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descuentoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.retencionesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.percepcionIvaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.percepcionIIBBTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.otrosImpuestosTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_ComprobanteVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteIVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            fechaLabel = new System.Windows.Forms.Label();
            fechaVtoLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            fechaEntregaLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            id_FormaPagoLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            id_EntidadLabel = new System.Windows.Forms.Label();
            retencionesLabel = new System.Windows.Forms.Label();
            percepcionIvaLabel = new System.Windows.Forms.Label();
            percepcionIIBBLabel = new System.Windows.Forms.Label();
            otrosImpuestosLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            puntoVentaLabel = new System.Windows.Forms.Label();
            nroComprobanteLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            descuentoLabel = new System.Windows.Forms.Label();
            id_DepositoLabel = new System.Windows.Forms.Label();
            iTCLabel = new System.Windows.Forms.Label();
            impuestoNoGravadoLabel = new System.Windows.Forms.Label();
            percepcionIIBBCapitalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVtoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVtoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntregaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntregaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_FormaPagoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIIBBCapitalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impuestoNoGravadoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTCTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retencionesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIvaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIIBBTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otrosImpuestosTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(48, 10);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 0;
            fechaLabel.Text = "Fecha:";
            // 
            // fechaVtoLabel
            // 
            fechaVtoLabel.AutoSize = true;
            fechaVtoLabel.Location = new System.Drawing.Point(483, 10);
            fechaVtoLabel.Name = "fechaVtoLabel";
            fechaVtoLabel.Size = new System.Drawing.Size(59, 13);
            fechaVtoLabel.TabIndex = 22;
            fechaVtoLabel.Text = "Fecha Vto:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(6, 114);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 24;
            observacionesLabel.Text = "Observaciones:";
            // 
            // fechaEntregaLabel
            // 
            fechaEntregaLabel.AutoSize = true;
            fechaEntregaLabel.Location = new System.Drawing.Point(248, 10);
            fechaEntregaLabel.Name = "fechaEntregaLabel";
            fechaEntregaLabel.Size = new System.Drawing.Size(92, 13);
            fechaEntregaLabel.TabIndex = 20;
            fechaEntregaLabel.Text = "Fecha Recepción:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(37, 36);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 2;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // id_FormaPagoLabel
            // 
            id_FormaPagoLabel.AutoSize = true;
            id_FormaPagoLabel.Location = new System.Drawing.Point(272, 88);
            id_FormaPagoLabel.Name = "id_FormaPagoLabel";
            id_FormaPagoLabel.Size = new System.Drawing.Size(68, 13);
            id_FormaPagoLabel.TabIndex = 16;
            id_FormaPagoLabel.Text = "Forma Pago:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(265, 36);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(75, 13);
            id_CentroCostoLabel.TabIndex = 4;
            id_CentroCostoLabel.Text = "Centro Costo:";
            // 
            // id_EntidadLabel
            // 
            id_EntidadLabel.AutoSize = true;
            id_EntidadLabel.Location = new System.Drawing.Point(41, 62);
            id_EntidadLabel.Name = "id_EntidadLabel";
            id_EntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_EntidadLabel.TabIndex = 12;
            id_EntidadLabel.Text = "Entidad:";
            // 
            // retencionesLabel
            // 
            retencionesLabel.AutoSize = true;
            retencionesLabel.Location = new System.Drawing.Point(245, 62);
            retencionesLabel.Name = "retencionesLabel";
            retencionesLabel.Size = new System.Drawing.Size(88, 13);
            retencionesLabel.TabIndex = 6;
            retencionesLabel.Text = "Perc. Ganancias:";
            // 
            // percepcionIvaLabel
            // 
            percepcionIvaLabel.AutoSize = true;
            percepcionIvaLabel.Location = new System.Drawing.Point(20, 62);
            percepcionIvaLabel.Name = "percepcionIvaLabel";
            percepcionIvaLabel.Size = new System.Drawing.Size(82, 13);
            percepcionIvaLabel.TabIndex = 4;
            percepcionIvaLabel.Text = "Percepcion Iva:";
            // 
            // percepcionIIBBLabel
            // 
            percepcionIIBBLabel.AutoSize = true;
            percepcionIIBBLabel.Location = new System.Drawing.Point(16, 36);
            percepcionIIBBLabel.Name = "percepcionIIBBLabel";
            percepcionIIBBLabel.Size = new System.Drawing.Size(86, 13);
            percepcionIIBBLabel.TabIndex = 2;
            percepcionIIBBLabel.Text = "Percepcion IIBB:";
            // 
            // otrosImpuestosLabel
            // 
            otrosImpuestosLabel.AutoSize = true;
            otrosImpuestosLabel.Location = new System.Drawing.Point(11, 88);
            otrosImpuestosLabel.Name = "otrosImpuestosLabel";
            otrosImpuestosLabel.Size = new System.Drawing.Size(91, 13);
            otrosImpuestosLabel.TabIndex = 0;
            otrosImpuestosLabel.Text = "Otros Impuestos:";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(525, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 5;
            label1.Text = "TOTAL:";
            // 
            // puntoVentaLabel
            // 
            puntoVentaLabel.AutoSize = true;
            puntoVentaLabel.Location = new System.Drawing.Point(12, 88);
            puntoVentaLabel.Name = "puntoVentaLabel";
            puntoVentaLabel.Size = new System.Drawing.Size(76, 13);
            puntoVentaLabel.TabIndex = 25;
            puntoVentaLabel.Text = "Comprobante:";
            // 
            // nroComprobanteLabel
            // 
            nroComprobanteLabel.AutoSize = true;
            nroComprobanteLabel.Location = new System.Drawing.Point(163, 88);
            nroComprobanteLabel.Name = "nroComprobanteLabel";
            nroComprobanteLabel.Size = new System.Drawing.Size(11, 13);
            nroComprobanteLabel.TabIndex = 10;
            nroComprobanteLabel.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(116, 88);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(11, 13);
            label2.TabIndex = 8;
            label2.Text = "-";
            // 
            // descuentoLabel
            // 
            descuentoLabel.AutoSize = true;
            descuentoLabel.Location = new System.Drawing.Point(40, 114);
            descuentoLabel.Name = "descuentoLabel";
            descuentoLabel.Size = new System.Drawing.Size(60, 13);
            descuentoLabel.TabIndex = 8;
            descuentoLabel.Text = "Redondeo:";
            // 
            // id_DepositoLabel
            // 
            id_DepositoLabel.AutoSize = true;
            id_DepositoLabel.Location = new System.Drawing.Point(489, 36);
            id_DepositoLabel.Name = "id_DepositoLabel";
            id_DepositoLabel.Size = new System.Drawing.Size(53, 13);
            id_DepositoLabel.TabIndex = 25;
            id_DepositoLabel.Text = "Depósito:";
            // 
            // iTCLabel
            // 
            iTCLabel.AutoSize = true;
            iTCLabel.Location = new System.Drawing.Point(305, 10);
            iTCLabel.Name = "iTCLabel";
            iTCLabel.Size = new System.Drawing.Size(28, 13);
            iTCLabel.TabIndex = 10;
            iTCLabel.Text = "ITC:";
            // 
            // impuestoNoGravadoLabel
            // 
            impuestoNoGravadoLabel.AutoSize = true;
            impuestoNoGravadoLabel.Location = new System.Drawing.Point(9, 10);
            impuestoNoGravadoLabel.Name = "impuestoNoGravadoLabel";
            impuestoNoGravadoLabel.Size = new System.Drawing.Size(93, 13);
            impuestoNoGravadoLabel.TabIndex = 12;
            impuestoNoGravadoLabel.Text = "Imp. No Gravado:";
            // 
            // percepcionIIBBCapitalLabel
            // 
            percepcionIIBBCapitalLabel.AutoSize = true;
            percepcionIIBBCapitalLabel.Location = new System.Drawing.Point(238, 36);
            percepcionIIBBCapitalLabel.Name = "percepcionIIBBCapitalLabel";
            percepcionIIBBCapitalLabel.Size = new System.Drawing.Size(95, 13);
            percepcionIIBBCapitalLabel.TabIndex = 14;
            percepcionIIBBCapitalLabel.Text = "Perc. IIBB Capital:";
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
            this.btnAceptar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.tabControl1);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(710, 423);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(10, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 165);
            this.tabControl1.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.AutoScroll = true;
            this.tpGeneral.Controls.Add(id_DepositoLabel);
            this.tpGeneral.Controls.Add(this.id_DepositoLookUpEdit);
            this.tpGeneral.Controls.Add(label2);
            this.tpGeneral.Controls.Add(nroComprobanteLabel);
            this.tpGeneral.Controls.Add(this.nroComprobanteTextEdit);
            this.tpGeneral.Controls.Add(puntoVentaLabel);
            this.tpGeneral.Controls.Add(this.puntoVentaTextEdit);
            this.tpGeneral.Controls.Add(this.letraTextEdit);
            this.tpGeneral.Controls.Add(fechaLabel);
            this.tpGeneral.Controls.Add(this.fechaDateEdit);
            this.tpGeneral.Controls.Add(fechaVtoLabel);
            this.tpGeneral.Controls.Add(observacionesLabel);
            this.tpGeneral.Controls.Add(this.fechaVtoDateEdit);
            this.tpGeneral.Controls.Add(this.id_SucursalLookUpEdit);
            this.tpGeneral.Controls.Add(fechaEntregaLabel);
            this.tpGeneral.Controls.Add(this.observacionesTextEdit);
            this.tpGeneral.Controls.Add(this.fechaEntregaDateEdit);
            this.tpGeneral.Controls.Add(id_SucursalLabel);
            this.tpGeneral.Controls.Add(id_FormaPagoLabel);
            this.tpGeneral.Controls.Add(this.id_FormaPagoLookUpEdit);
            this.tpGeneral.Controls.Add(this.id_TipoEntidadLookUpEdit);
            this.tpGeneral.Controls.Add(this.id_EntidadLookUpEdit);
            this.tpGeneral.Controls.Add(id_CentroCostoLabel);
            this.tpGeneral.Controls.Add(id_EntidadLabel);
            this.tpGeneral.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(678, 139);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // id_DepositoLookUpEdit
            // 
            this.id_DepositoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_Deposito", true));
            this.id_DepositoLookUpEdit.EnterMoveNextControl = true;
            this.id_DepositoLookUpEdit.Location = new System.Drawing.Point(548, 33);
            this.id_DepositoLookUpEdit.MenuManager = this.barManager1;
            this.id_DepositoLookUpEdit.Name = "id_DepositoLookUpEdit";
            this.id_DepositoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_DepositoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name7")});
            this.id_DepositoLookUpEdit.Properties.NullText = "";
            this.id_DepositoLookUpEdit.Properties.ShowHeader = false;
            this.id_DepositoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_DepositoLookUpEdit.TabIndex = 5;
            // 
            // comprobantesComprasManagerBindingSource
            // 
            this.comprobantesComprasManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesComprasManager);
            // 
            // nroComprobanteTextEdit
            // 
            this.nroComprobanteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.NroComprobante", true));
            this.nroComprobanteTextEdit.EditValue = "";
            this.nroComprobanteTextEdit.EnterMoveNextControl = true;
            this.nroComprobanteTextEdit.Location = new System.Drawing.Point(176, 85);
            this.nroComprobanteTextEdit.MenuManager = this.barManager1;
            this.nroComprobanteTextEdit.Name = "nroComprobanteTextEdit";
            this.nroComprobanteTextEdit.Properties.DisplayFormat.FormatString = "00000000";
            this.nroComprobanteTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.nroComprobanteTextEdit.Properties.Mask.EditMask = "00000000";
            this.nroComprobanteTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.nroComprobanteTextEdit.Properties.MaxLength = 8;
            this.nroComprobanteTextEdit.Size = new System.Drawing.Size(63, 20);
            this.nroComprobanteTextEdit.TabIndex = 10;
            this.nroComprobanteTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // puntoVentaTextEdit
            // 
            this.puntoVentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.PuntoVenta", true));
            this.puntoVentaTextEdit.EditValue = "";
            this.puntoVentaTextEdit.EnterMoveNextControl = true;
            this.puntoVentaTextEdit.Location = new System.Drawing.Point(129, 85);
            this.puntoVentaTextEdit.MenuManager = this.barManager1;
            this.puntoVentaTextEdit.Name = "puntoVentaTextEdit";
            this.puntoVentaTextEdit.Properties.DisplayFormat.FormatString = "0000";
            this.puntoVentaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.puntoVentaTextEdit.Properties.Mask.EditMask = "0000";
            this.puntoVentaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.puntoVentaTextEdit.Properties.MaxLength = 4;
            this.puntoVentaTextEdit.Size = new System.Drawing.Size(32, 20);
            this.puntoVentaTextEdit.TabIndex = 9;
            this.puntoVentaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // letraTextEdit
            // 
            this.letraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Letra", true));
            this.letraTextEdit.EditValue = "";
            this.letraTextEdit.EnterMoveNextControl = true;
            this.letraTextEdit.Location = new System.Drawing.Point(94, 85);
            this.letraTextEdit.MenuManager = this.barManager1;
            this.letraTextEdit.Name = "letraTextEdit";
            this.letraTextEdit.Properties.Mask.EditMask = "\\p{Lu}+";
            this.letraTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.letraTextEdit.Properties.MaxLength = 1;
            this.letraTextEdit.Size = new System.Drawing.Size(20, 20);
            this.letraTextEdit.TabIndex = 8;
            this.letraTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(94, 7);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // fechaVtoDateEdit
            // 
            this.fechaVtoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.FechaVto", true));
            this.fechaVtoDateEdit.EditValue = null;
            this.fechaVtoDateEdit.EnterMoveNextControl = true;
            this.fechaVtoDateEdit.Location = new System.Drawing.Point(548, 7);
            this.fechaVtoDateEdit.MenuManager = this.barManager1;
            this.fechaVtoDateEdit.Name = "fechaVtoDateEdit";
            this.fechaVtoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaVtoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaVtoDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaVtoDateEdit.TabIndex = 2;
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(94, 33);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Name1")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.ShowHeader = false;
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 3;
            this.id_SucursalLookUpEdit.TextChanged += new System.EventHandler(this.id_SucursalLookUpEdit_TextChanged);
            // 
            // observacionesTextEdit
            // 
            this.observacionesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Observaciones", true));
            this.observacionesTextEdit.EnterMoveNextControl = true;
            this.observacionesTextEdit.Location = new System.Drawing.Point(94, 111);
            this.observacionesTextEdit.MenuManager = this.barManager1;
            this.observacionesTextEdit.Name = "observacionesTextEdit";
            this.observacionesTextEdit.Size = new System.Drawing.Size(578, 20);
            this.observacionesTextEdit.TabIndex = 12;
            this.observacionesTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fechaEntregaDateEdit
            // 
            this.fechaEntregaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.FechaRecepcion", true));
            this.fechaEntregaDateEdit.EditValue = null;
            this.fechaEntregaDateEdit.EnterMoveNextControl = true;
            this.fechaEntregaDateEdit.Location = new System.Drawing.Point(346, 7);
            this.fechaEntregaDateEdit.MenuManager = this.barManager1;
            this.fechaEntregaDateEdit.Name = "fechaEntregaDateEdit";
            this.fechaEntregaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaEntregaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaEntregaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaEntregaDateEdit.TabIndex = 1;
            // 
            // id_FormaPagoLookUpEdit
            // 
            this.id_FormaPagoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_FormaPago", true));
            this.id_FormaPagoLookUpEdit.EnterMoveNextControl = true;
            this.id_FormaPagoLookUpEdit.Location = new System.Drawing.Point(346, 85);
            this.id_FormaPagoLookUpEdit.MenuManager = this.barManager1;
            this.id_FormaPagoLookUpEdit.Name = "id_FormaPagoLookUpEdit";
            this.id_FormaPagoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_FormaPagoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name10")});
            this.id_FormaPagoLookUpEdit.Properties.NullText = "";
            this.id_FormaPagoLookUpEdit.Properties.ShowHeader = false;
            this.id_FormaPagoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_FormaPagoLookUpEdit.TabIndex = 11;
            // 
            // id_TipoEntidadLookUpEdit
            // 
            this.id_TipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_TipoEntidad", true));
            this.id_TipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoEntidadLookUpEdit.Location = new System.Drawing.Point(94, 59);
            this.id_TipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoEntidadLookUpEdit.Name = "id_TipoEntidadLookUpEdit";
            this.id_TipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name5")});
            this.id_TipoEntidadLookUpEdit.Properties.NullText = "";
            this.id_TipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoEntidadLookUpEdit.TabIndex = 6;
            this.id_TipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_TipoEntidadLookUpEdit_EditValueChanged);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(200, 59);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(246, 20);
            this.id_EntidadLookUpEdit.TabIndex = 7;
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(346, 33);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(percepcionIIBBCapitalLabel);
            this.tabPage1.Controls.Add(this.percepcionIIBBCapitalTextEdit);
            this.tabPage1.Controls.Add(impuestoNoGravadoLabel);
            this.tabPage1.Controls.Add(this.impuestoNoGravadoTextEdit);
            this.tabPage1.Controls.Add(iTCLabel);
            this.tabPage1.Controls.Add(this.iTCTextEdit);
            this.tabPage1.Controls.Add(descuentoLabel);
            this.tabPage1.Controls.Add(this.descuentoTextEdit);
            this.tabPage1.Controls.Add(retencionesLabel);
            this.tabPage1.Controls.Add(this.retencionesTextEdit);
            this.tabPage1.Controls.Add(percepcionIvaLabel);
            this.tabPage1.Controls.Add(this.percepcionIvaTextEdit);
            this.tabPage1.Controls.Add(percepcionIIBBLabel);
            this.tabPage1.Controls.Add(this.percepcionIIBBTextEdit);
            this.tabPage1.Controls.Add(otrosImpuestosLabel);
            this.tabPage1.Controls.Add(this.otrosImpuestosTextEdit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 139);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Impuestos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // percepcionIIBBCapitalTextEdit
            // 
            this.percepcionIIBBCapitalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.PercepcionIIBBCapital", true));
            this.percepcionIIBBCapitalTextEdit.EnterMoveNextControl = true;
            this.percepcionIIBBCapitalTextEdit.Location = new System.Drawing.Point(339, 33);
            this.percepcionIIBBCapitalTextEdit.MenuManager = this.barManager1;
            this.percepcionIIBBCapitalTextEdit.Name = "percepcionIIBBCapitalTextEdit";
            this.percepcionIIBBCapitalTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.percepcionIIBBCapitalTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.percepcionIIBBCapitalTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.percepcionIIBBCapitalTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.percepcionIIBBCapitalTextEdit.Properties.Mask.EditMask = "n";
            this.percepcionIIBBCapitalTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.percepcionIIBBCapitalTextEdit.Size = new System.Drawing.Size(100, 20);
            this.percepcionIIBBCapitalTextEdit.TabIndex = 3;
            this.percepcionIIBBCapitalTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.percepcionIIBBCapitalTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.percepcionIIBBCapitalTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // impuestoNoGravadoTextEdit
            // 
            this.impuestoNoGravadoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.ImpuestoNoGravado", true));
            this.impuestoNoGravadoTextEdit.EnterMoveNextControl = true;
            this.impuestoNoGravadoTextEdit.Location = new System.Drawing.Point(108, 7);
            this.impuestoNoGravadoTextEdit.MenuManager = this.barManager1;
            this.impuestoNoGravadoTextEdit.Name = "impuestoNoGravadoTextEdit";
            this.impuestoNoGravadoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.impuestoNoGravadoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.impuestoNoGravadoTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.impuestoNoGravadoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.impuestoNoGravadoTextEdit.Properties.Mask.EditMask = "n";
            this.impuestoNoGravadoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.impuestoNoGravadoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.impuestoNoGravadoTextEdit.TabIndex = 0;
            this.impuestoNoGravadoTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.impuestoNoGravadoTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.impuestoNoGravadoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // iTCTextEdit
            // 
            this.iTCTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.ITC", true));
            this.iTCTextEdit.EnterMoveNextControl = true;
            this.iTCTextEdit.Location = new System.Drawing.Point(339, 7);
            this.iTCTextEdit.MenuManager = this.barManager1;
            this.iTCTextEdit.Name = "iTCTextEdit";
            this.iTCTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.iTCTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iTCTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.iTCTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iTCTextEdit.Properties.Mask.EditMask = "n";
            this.iTCTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iTCTextEdit.Size = new System.Drawing.Size(100, 20);
            this.iTCTextEdit.TabIndex = 1;
            this.iTCTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.iTCTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.iTCTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // descuentoTextEdit
            // 
            this.descuentoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.Descuento", true));
            this.descuentoTextEdit.EnterMoveNextControl = true;
            this.descuentoTextEdit.Location = new System.Drawing.Point(108, 111);
            this.descuentoTextEdit.MenuManager = this.barManager1;
            this.descuentoTextEdit.Name = "descuentoTextEdit";
            this.descuentoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.descuentoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.descuentoTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.descuentoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.descuentoTextEdit.Properties.Mask.EditMask = "n";
            this.descuentoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.descuentoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descuentoTextEdit.TabIndex = 7;
            this.descuentoTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.descuentoTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.descuentoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // retencionesTextEdit
            // 
            this.retencionesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.PercepcionGanancias", true));
            this.retencionesTextEdit.EnterMoveNextControl = true;
            this.retencionesTextEdit.Location = new System.Drawing.Point(339, 59);
            this.retencionesTextEdit.MenuManager = this.barManager1;
            this.retencionesTextEdit.Name = "retencionesTextEdit";
            this.retencionesTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.retencionesTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.retencionesTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.retencionesTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.retencionesTextEdit.Properties.Mask.EditMask = "n";
            this.retencionesTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.retencionesTextEdit.Size = new System.Drawing.Size(100, 20);
            this.retencionesTextEdit.TabIndex = 5;
            this.retencionesTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.retencionesTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.retencionesTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // percepcionIvaTextEdit
            // 
            this.percepcionIvaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.PercepcionIva", true));
            this.percepcionIvaTextEdit.EnterMoveNextControl = true;
            this.percepcionIvaTextEdit.Location = new System.Drawing.Point(108, 59);
            this.percepcionIvaTextEdit.MenuManager = this.barManager1;
            this.percepcionIvaTextEdit.Name = "percepcionIvaTextEdit";
            this.percepcionIvaTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.percepcionIvaTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.percepcionIvaTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.percepcionIvaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.percepcionIvaTextEdit.Properties.Mask.EditMask = "n";
            this.percepcionIvaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.percepcionIvaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.percepcionIvaTextEdit.TabIndex = 4;
            this.percepcionIvaTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.percepcionIvaTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.percepcionIvaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // percepcionIIBBTextEdit
            // 
            this.percepcionIIBBTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.PercepcionIIBB", true));
            this.percepcionIIBBTextEdit.EnterMoveNextControl = true;
            this.percepcionIIBBTextEdit.Location = new System.Drawing.Point(108, 33);
            this.percepcionIIBBTextEdit.MenuManager = this.barManager1;
            this.percepcionIIBBTextEdit.Name = "percepcionIIBBTextEdit";
            this.percepcionIIBBTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.percepcionIIBBTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.percepcionIIBBTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.percepcionIIBBTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.percepcionIIBBTextEdit.Properties.Mask.EditMask = "n";
            this.percepcionIIBBTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.percepcionIIBBTextEdit.Size = new System.Drawing.Size(100, 20);
            this.percepcionIIBBTextEdit.TabIndex = 2;
            this.percepcionIIBBTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.percepcionIIBBTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.percepcionIIBBTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // otrosImpuestosTextEdit
            // 
            this.otrosImpuestosTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comprobantesComprasManagerBindingSource, "Comprobante.OtrosImpuestos", true));
            this.otrosImpuestosTextEdit.EnterMoveNextControl = true;
            this.otrosImpuestosTextEdit.Location = new System.Drawing.Point(108, 85);
            this.otrosImpuestosTextEdit.MenuManager = this.barManager1;
            this.otrosImpuestosTextEdit.Name = "otrosImpuestosTextEdit";
            this.otrosImpuestosTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.otrosImpuestosTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.otrosImpuestosTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.otrosImpuestosTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.otrosImpuestosTextEdit.Properties.Mask.EditMask = "n";
            this.otrosImpuestosTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.otrosImpuestosTextEdit.Size = new System.Drawing.Size(100, 20);
            this.otrosImpuestosTextEdit.TabIndex = 6;
            this.otrosImpuestosTextEdit.EditValueChanged += new System.EventHandler(this.TextEdit_EditValueChanged);
            this.otrosImpuestosTextEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TextEdit_EditValueChanging);
            this.otrosImpuestosTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Location = new System.Drawing.Point(10, 172);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(686, 246);
            this.groupControl2.TabIndex = 26;
            this.groupControl2.Text = "Detalle";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.detalleBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(682, 192);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.ComprobantesComprasDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_ComprobanteVenta,
            this.colId_Especie,
            this.colId_Producto,
            this.colDescripcion,
            this.colCantidad,
            this.colImporteCosto,
            this.colImporteUnitario,
            this.colPorcDescuento,
            this.colId_AlicuotaIva,
            this.colImporteIVA,
            this.colImporte,
            this.colComprobanteVenta,
            this.colEspecie,
            this.colBorrado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colCantidadStock});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.Importe", this.colImporte, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteCosto", this.colImporteCosto, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteIVA", this.colImporteIVA, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteUnitario", this.colImporteUnitario, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.Cantidad", this.colCantidad, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId_ComprobanteVenta
            // 
            this.colId_ComprobanteVenta.FieldName = "Id_ComprobanteVenta";
            this.colId_ComprobanteVenta.Name = "colId_ComprobanteVenta";
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 100;
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
            this.colCantidad.VisibleIndex = 0;
            this.colCantidad.Width = 52;
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
            // colImporteUnitario
            // 
            this.colImporteUnitario.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitario.FieldName = "ImporteUnitario";
            this.colImporteUnitario.Name = "colImporteUnitario";
            this.colImporteUnitario.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteUnitario", "{0:N2}")});
            this.colImporteUnitario.Visible = true;
            this.colImporteUnitario.VisibleIndex = 2;
            this.colImporteUnitario.Width = 100;
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
            this.colPorcDescuento.VisibleIndex = 3;
            this.colPorcDescuento.Width = 100;
            // 
            // colId_AlicuotaIva
            // 
            this.colId_AlicuotaIva.FieldName = "Id_AlicuotaIva";
            this.colId_AlicuotaIva.Name = "colId_AlicuotaIva";
            // 
            // colImporteIVA
            // 
            this.colImporteIVA.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteIVA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteIVA.FieldName = "ImporteIVA";
            this.colImporteIVA.Name = "colImporteIVA";
            this.colImporteIVA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIVA", "{0:N2}")});
            this.colImporteIVA.Visible = true;
            this.colImporteIVA.VisibleIndex = 4;
            this.colImporteIVA.Width = 100;
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
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 100;
            // 
            // colComprobanteVenta
            // 
            this.colComprobanteVenta.FieldName = "ComprobanteVenta";
            this.colComprobanteVenta.Name = "colComprobanteVenta";
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.Visible = true;
            this.colEspecie.VisibleIndex = 6;
            this.colEspecie.Width = 112;
            // 
            // colBorrado
            // 
            this.colBorrado.FieldName = "Borrado";
            this.colBorrado.Name = "colBorrado";
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
            // colCantidadStock
            // 
            this.colCantidadStock.Caption = "Cantidad Stock";
            this.colCantidadStock.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidadStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidadStock.FieldName = "CantidadStock";
            this.colCantidadStock.Name = "colCantidadStock";
            this.colCantidadStock.OptionsColumn.AllowEdit = false;
            this.colCantidadStock.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantidadStock", "{0:N2}")});
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtTotal);
            this.panelControl1.Controls.Add(label1);
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 212);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(682, 32);
            this.panelControl1.TabIndex = 37;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(574, 6);
            this.txtTotal.MenuManager = this.barManager1;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::VENET_Gestion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(9, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "    Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(168, 6);
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
            this.btnModificar.Location = new System.Drawing.Point(88, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // frmComprobantesCompras_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmComprobantesCompras_AddMod";
            this.Text = "Alta/Modificación de Comprobantes de Compras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComprobantesCompras_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmComprobantesCompras_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_DepositoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesComprasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVtoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaVtoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.observacionesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntregaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntregaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_FormaPagoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIIBBCapitalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impuestoNoGravadoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTCTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retencionesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIvaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percepcionIIBBTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otrosImpuestosTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaVtoDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraEditors.TextEdit observacionesTextEdit;
        private DevExpress.XtraEditors.DateEdit fechaEntregaDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_FormaPagoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.TextEdit retencionesTextEdit;
        private DevExpress.XtraEditors.TextEdit percepcionIvaTextEdit;
        private DevExpress.XtraEditors.TextEdit percepcionIIBBTextEdit;
        private DevExpress.XtraEditors.TextEdit otrosImpuestosTextEdit;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteIVA;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private DevExpress.XtraEditors.TextEdit nroComprobanteTextEdit;
        private System.Windows.Forms.BindingSource comprobantesComprasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit puntoVentaTextEdit;
        private DevExpress.XtraEditors.TextEdit letraTextEdit;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraEditors.TextEdit descuentoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_DepositoLookUpEdit;
        private DevExpress.XtraEditors.TextEdit percepcionIIBBCapitalTextEdit;
        private DevExpress.XtraEditors.TextEdit impuestoNoGravadoTextEdit;
        private DevExpress.XtraEditors.TextEdit iTCTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadStock;
    }
}