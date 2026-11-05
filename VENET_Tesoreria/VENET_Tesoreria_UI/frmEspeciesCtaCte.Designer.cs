namespace VENET_Tesoreria_UI
{
    partial class frmEspeciesCtaCte
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
            System.Windows.Forms.Label fecha_DesdeLabel;
            System.Windows.Forms.Label fecha_HastaLabel;
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label Id_TipoComprobanteLabel;
            System.Windows.Forms.Label id_CajaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspeciesCtaCte));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItemAgregar = new DevExpress.XtraBars.BarSubItem();
            this.btnMovimiento = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecibo = new DevExpress.XtraBars.BarButtonItem();
            this.btnOP = new DevExpress.XtraBars.BarButtonItem();
            this.btnVale = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeposito = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransferencia = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.btnVerComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.btnReporteSaldos = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_CajaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.especiesCtaCteManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.especiesCtaCteManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternoSistema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarjeta = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            conceptoLabel = new System.Windows.Forms.Label();
            Id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            id_CajaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(28, 36);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(159, 10);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 4;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(345, 10);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 6;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(177, 36);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 8;
            conceptoLabel.Text = "Concepto:";
            // 
            // Id_TipoComprobanteLabel
            // 
            Id_TipoComprobanteLabel.AutoSize = true;
            Id_TipoComprobanteLabel.Location = new System.Drawing.Point(343, 36);
            Id_TipoComprobanteLabel.Name = "Id_TipoComprobanteLabel";
            Id_TipoComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            Id_TipoComprobanteLabel.TabIndex = 10;
            Id_TipoComprobanteLabel.Text = "Comprobante:";
            // 
            // id_CajaLabel
            // 
            id_CajaLabel.AutoSize = true;
            id_CajaLabel.Location = new System.Drawing.Point(14, 10);
            id_CajaLabel.Name = "id_CajaLabel";
            id_CajaLabel.Size = new System.Drawing.Size(33, 13);
            id_CajaLabel.TabIndex = 11;
            id_CajaLabel.Text = "Caja:";
            // 
            // colSaldo
            // 
            this.colSaldo.DisplayFormat.FormatString = "#,##0.00";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowEdit = false;
            this.colSaldo.OptionsColumn.ReadOnly = true;
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 5;
            this.colSaldo.Width = 101;
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
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
            this.barStaticItemFooter,
            this.barSubItemAgregar,
            this.btnRecibo,
            this.btnVale,
            this.btnMovimiento,
            this.btnDeposito,
            this.btnTransferencia,
            this.barSubItem3,
            this.barSubItem4,
            this.barSubItem5,
            this.btnVerComprobante,
            this.btnOP,
            this.btnImprimeComprobante,
            this.btnReporteSaldos});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 19;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItemAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem5, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // barSubItemAgregar
            // 
            this.barSubItemAgregar.Caption = "Agregar";
            this.barSubItemAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.barSubItemAgregar.Id = 6;
            this.barSubItemAgregar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMovimiento),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRecibo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOP, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVale, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeposito, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTransferencia, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barSubItemAgregar.Name = "barSubItemAgregar";
            this.barSubItemAgregar.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItemAgregar_ItemDoubleClick);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Caption = "Movimiento";
            this.btnMovimiento.Id = 9;
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMovimiento_ItemClick);
            // 
            // btnRecibo
            // 
            this.btnRecibo.Caption = "Recibo";
            this.btnRecibo.Id = 7;
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
            // btnVale
            // 
            this.btnVale.Caption = "Vale";
            this.btnVale.Id = 8;
            this.btnVale.Name = "btnVale";
            this.btnVale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVale_ItemClick);
            // 
            // btnDeposito
            // 
            this.btnDeposito.Caption = "Depósito";
            this.btnDeposito.Id = 10;
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeposito_ItemClick);
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.Caption = "Transferencia";
            this.btnTransferencia.Id = 11;
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransferencia_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnModificar.Glyph")));
            this.btnModificar.Id = 1;
            this.btnModificar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModificar.LargeGlyph")));
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Glyph")));
            this.btnEliminar.Id = 2;
            this.btnEliminar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.LargeGlyph")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 3;
            this.barSubItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.LargeGlyph")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeComprobante),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnImprimeComprobante
            // 
            this.btnImprimeComprobante.Caption = "Comprobante";
            this.btnImprimeComprobante.Id = 17;
            this.btnImprimeComprobante.Name = "btnImprimeComprobante";
            this.btnImprimeComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeComprobante_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 4;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Ver";
            this.barSubItem5.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem5.Id = 14;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVerComprobante),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReporteSaldos, true)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // btnVerComprobante
            // 
            this.btnVerComprobante.Caption = "Comprobante";
            this.btnVerComprobante.Id = 15;
            this.btnVerComprobante.Name = "btnVerComprobante";
            this.btnVerComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerComprobante_ItemClick);
            // 
            // btnReporteSaldos
            // 
            this.btnReporteSaldos.Caption = "Reporte de Saldos de Cta Cte";
            this.btnReporteSaldos.Id = 18;
            this.btnReporteSaldos.Name = "btnReporteSaldos";
            this.btnReporteSaldos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReporteSaldos_ItemClick);
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
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
            this.btnAgregar.Id = 0;
            this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
            this.btnAgregar.Name = "btnAgregar";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "barSubItem3";
            this.barSubItem3.Id = 12;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "barSubItem4";
            this.barSubItem4.Id = 13;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_CajaLabel);
            this.panelControl1.Controls.Add(this.id_CajaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(Id_TipoComprobanteLabel);
            this.panelControl1.Controls.Add(this.Id_TipoComprobanteLookUpEdit);
            this.panelControl1.Controls.Add(conceptoLabel);
            this.panelControl1.Controls.Add(this.conceptoTextEdit);
            this.panelControl1.Controls.Add(fecha_HastaLabel);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Controls.Add(this.fecha_DesdeDateEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // id_CajaLookUpEdit
            // 
            this.id_CajaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "Id_Caja", true));
            this.id_CajaLookUpEdit.EnterMoveNextControl = true;
            this.id_CajaLookUpEdit.Location = new System.Drawing.Point(53, 7);
            this.id_CajaLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaLookUpEdit.Name = "id_CajaLookUpEdit";
            this.id_CajaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CajaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaLookUpEdit.Properties.NullText = "";
            this.id_CajaLookUpEdit.Properties.PopupWidth = 500;
            this.id_CajaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_CajaLookUpEdit.TabIndex = 12;
            // 
            // especiesCtaCteManager_ParametrosBusquedasBindingSource
            // 
            this.especiesCtaCteManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EspeciesCtaCteManager.ParametrosBusquedas);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Id_TipoComprobanteLookUpEdit
            // 
            this.Id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "Id_TipoComprobante", true));
            this.Id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.Id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(422, 33);
            this.Id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.Id_TipoComprobanteLookUpEdit.Name = "Id_TipoComprobanteLookUpEdit";
            this.Id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.Id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.Id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.Id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.Id_TipoComprobanteLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.Id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(156, 20);
            this.Id_TipoComprobanteLookUpEdit.TabIndex = 5;
            this.Id_TipoComprobanteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(239, 33);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Properties.MaxLength = 50;
            this.conceptoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.conceptoTextEdit.TabIndex = 4;
            this.conceptoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(422, 7);
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
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(239, 7);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 1;
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(53, 33);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 3;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.especiesCtaCteManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 353);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick_1);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // especiesCtaCteManager_SearchResultBindingSource
            // 
            this.especiesCtaCteManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EspeciesCtaCteManager.SearchResult);
            this.especiesCtaCteManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.especiesCtaCteManager_SearchResultBindingSource_ListChanged_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEspecie,
            this.colMovimiento,
            this.colId,
            this.colFecha,
            this.colId_Especie,
            this.colId_TipoComprobante,
            this.colConcepto,
            this.colDebito,
            this.colCredito,
            this.colSaldo,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colId_CentroCosto,
            this.colCentroCosto,
            this.colInternoSistema,
            this.colTarjeta});
            gridFormatRule1.Column = this.colSaldo;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = "0";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[Tarjeta] = True";
            gridFormatRule2.Rule = formatConditionRuleExpression1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", this.colDebito, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", this.colCredito, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.OptionsColumn.AllowEdit = false;
            this.colEspecie.OptionsColumn.ReadOnly = true;
            // 
            // colMovimiento
            // 
            this.colMovimiento.FieldName = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.OptionsColumn.AllowEdit = false;
            this.colMovimiento.OptionsColumn.ReadOnly = true;
            this.colMovimiento.Visible = true;
            this.colMovimiento.VisibleIndex = 1;
            this.colMovimiento.Width = 114;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Width = 58;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 66;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            this.colId_Especie.OptionsColumn.AllowEdit = false;
            this.colId_Especie.OptionsColumn.ReadOnly = true;
            // 
            // colId_TipoComprobante
            // 
            this.colId_TipoComprobante.FieldName = "Id_TipoComprobante";
            this.colId_TipoComprobante.Name = "colId_TipoComprobante";
            this.colId_TipoComprobante.OptionsColumn.AllowEdit = false;
            this.colId_TipoComprobante.OptionsColumn.ReadOnly = true;
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.OptionsColumn.ReadOnly = true;
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 2;
            this.colConcepto.Width = 158;
            // 
            // colDebito
            // 
            this.colDebito.Caption = "Ingreso";
            this.colDebito.DisplayFormat.FormatString = "#,##0.00";
            this.colDebito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebito.FieldName = "Debito";
            this.colDebito.Name = "colDebito";
            this.colDebito.OptionsColumn.AllowEdit = false;
            this.colDebito.OptionsColumn.ReadOnly = true;
            this.colDebito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", "{0:N2}")});
            this.colDebito.Visible = true;
            this.colDebito.VisibleIndex = 3;
            this.colDebito.Width = 115;
            // 
            // colCredito
            // 
            this.colCredito.Caption = "Egreso";
            this.colCredito.DisplayFormat.FormatString = "#,##0.00";
            this.colCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCredito.FieldName = "Credito";
            this.colCredito.Name = "colCredito";
            this.colCredito.OptionsColumn.AllowEdit = false;
            this.colCredito.OptionsColumn.ReadOnly = true;
            this.colCredito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", "{0:N2}")});
            this.colCredito.Visible = true;
            this.colCredito.VisibleIndex = 4;
            this.colCredito.Width = 104;
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
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.Caption = "Id_CentroCosto";
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            this.colId_CentroCosto.OptionsColumn.AllowEdit = false;
            this.colId_CentroCosto.OptionsColumn.ReadOnly = true;
            // 
            // colCentroCosto
            // 
            this.colCentroCosto.Caption = "Centro Costo";
            this.colCentroCosto.FieldName = "CentroCosto";
            this.colCentroCosto.Name = "colCentroCosto";
            this.colCentroCosto.OptionsColumn.AllowEdit = false;
            this.colCentroCosto.OptionsColumn.ReadOnly = true;
            // 
            // colInternoSistema
            // 
            this.colInternoSistema.Caption = "Interno Sistema";
            this.colInternoSistema.FieldName = "InternoSistema";
            this.colInternoSistema.Name = "colInternoSistema";
            this.colInternoSistema.OptionsColumn.AllowEdit = false;
            this.colInternoSistema.OptionsColumn.ReadOnly = true;
            // 
            // colTarjeta
            // 
            this.colTarjeta.Caption = "Tarjeta";
            this.colTarjeta.FieldName = "Tarjeta";
            this.colTarjeta.Name = "colTarjeta";
            // 
            // frmEspeciesCtaCte
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
            this.MinimumSize = new System.Drawing.Size(680, 243);
            this.Name = "frmEspeciesCtaCte";
            this.Text = "Cuenta Corriente de Especies";
            this.Load += new System.EventHandler(this.frmEspeciesCtaCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_TipoComprobanteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colCredito;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.LookUpEdit Id_TipoComprobanteLookUpEdit;
        private System.Windows.Forms.BindingSource especiesCtaCteManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource especiesCtaCteManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarSubItem barSubItemAgregar;
        private DevExpress.XtraBars.BarButtonItem btnRecibo;
        private DevExpress.XtraBars.BarButtonItem btnVale;
        private DevExpress.XtraBars.BarButtonItem btnMovimiento;
        private DevExpress.XtraBars.BarButtonItem btnDeposito;
        private DevExpress.XtraBars.BarButtonItem btnTransferencia;
        private DevExpress.XtraEditors.LookUpEdit id_CajaLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarButtonItem btnVerComprobante;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colInternoSistema;
        private DevExpress.XtraBars.BarButtonItem btnOP;
        private DevExpress.XtraBars.BarButtonItem btnImprimeComprobante;
        private DevExpress.XtraBars.BarButtonItem btnReporteSaldos;
        private DevExpress.XtraGrid.Columns.GridColumn colTarjeta;
    }
}