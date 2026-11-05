namespace VENET_Tesoreria_UI
{
    partial class frmEntidadesCtaCte
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
            System.Windows.Forms.Label id_TipoEntidadLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label id_EspecieLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItemAgregar = new DevExpress.XtraBars.BarSubItem();
            this.btnMovimiento = new DevExpress.XtraBars.BarButtonItem();
            this.btnOP = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecibo = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.btnEnviarCtaCteMail = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnComentario = new DevExpress.XtraBars.BarButtonItem();
            this.btnComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.btnCtasCtesConSaldo = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gregar = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_EspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.entidadesCtaCteManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.entidadesCtaCteManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternoSistema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_Comentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            id_TipoEntidadLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            conceptoLabel = new System.Windows.Forms.Label();
            id_EspecieLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesCtaCteManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesCtaCteManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_TipoEntidadLabel
            // 
            id_TipoEntidadLabel.AutoSize = true;
            id_TipoEntidadLabel.Location = new System.Drawing.Point(12, 9);
            id_TipoEntidadLabel.Name = "id_TipoEntidadLabel";
            id_TipoEntidadLabel.Size = new System.Drawing.Size(47, 13);
            id_TipoEntidadLabel.TabIndex = 0;
            id_TipoEntidadLabel.Text = "Entidad:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(5, 35);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(54, 13);
            fechaDesdeLabel.TabIndex = 4;
            fechaDesdeLabel.Text = "F. Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(169, 35);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(39, 13);
            fechaHastaLabel.TabIndex = 6;
            fechaHastaLabel.Text = "Hasta:";
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(310, 35);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            id_TipoComprobanteLabel.TabIndex = 10;
            id_TipoComprobanteLabel.Text = "Comprobante:";
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(490, 9);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 12;
            conceptoLabel.Text = "Concepto:";
            // 
            // id_EspecieLabel
            // 
            id_EspecieLabel.AutoSize = true;
            id_EspecieLabel.Location = new System.Drawing.Point(335, 9);
            id_EspecieLabel.Name = "id_EspecieLabel";
            id_EspecieLabel.Size = new System.Drawing.Size(47, 13);
            id_EspecieLabel.TabIndex = 14;
            id_EspecieLabel.Text = "Especie:";
            // 
            // colSaldo
            // 
            this.colSaldo.DisplayFormat.FormatString = "#,##0.00";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 5;
            this.colSaldo.Width = 116;
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
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.btnResultado,
            this.barSubItem2,
            this.btnComprobante,
            this.gregar,
            this.barSubItemAgregar,
            this.btnMovimiento,
            this.barButtonItem1,
            this.btnRecibo,
            this.btnOP,
            this.btnImprimeComprobante,
            this.btnCtasCtesConSaldo,
            this.barSubItem4,
            this.btnEnviarCtaCteMail,
            this.btnComentario});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 21;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // barSubItemAgregar
            // 
            this.barSubItemAgregar.Caption = "Agregar";
            this.barSubItemAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.barSubItemAgregar.Id = 9;
            this.barSubItemAgregar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnMovimiento, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOP, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRecibo, true)});
            this.barSubItemAgregar.Name = "barSubItemAgregar";
            this.barSubItemAgregar.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItemAgregar_ItemDoubleClick);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Caption = "Movimiento";
            this.btnMovimiento.Id = 10;
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMovimiento_ItemClick);
            // 
            // btnOP
            // 
            this.btnOP.Caption = "Orden de Pago";
            this.btnOP.Id = 13;
            this.btnOP.Name = "btnOP";
            this.btnOP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOP_ItemClick);
            // 
            // btnRecibo
            // 
            this.btnRecibo.Caption = "Recibo";
            this.btnRecibo.Id = 12;
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecibo_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 2;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.Id = 3;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 4;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeComprobante),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnImprimeComprobante
            // 
            this.btnImprimeComprobante.Caption = "Comprobante";
            this.btnImprimeComprobante.Id = 14;
            this.btnImprimeComprobante.Name = "btnImprimeComprobante";
            this.btnImprimeComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeComprobante_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Operaciones";
            this.barSubItem4.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem4.Id = 17;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEnviarCtaCteMail)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // btnEnviarCtaCteMail
            // 
            this.btnEnviarCtaCteMail.Caption = "Enviar Cta Cte por Mail";
            this.btnEnviarCtaCteMail.Id = 19;
            this.btnEnviarCtaCteMail.Name = "btnEnviarCtaCteMail";
            this.btnEnviarCtaCteMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEnviarCtaCteMail_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComentario),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComprobante, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCtasCtesConSaldo, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnComentario
            // 
            this.btnComentario.Caption = "Comentario";
            this.btnComentario.Id = 20;
            this.btnComentario.Name = "btnComentario";
            this.btnComentario.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComentario_ItemClick);
            // 
            // btnComprobante
            // 
            this.btnComprobante.Caption = "Comprobante";
            this.btnComprobante.Id = 7;
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComprobante_ItemClick);
            // 
            // btnCtasCtesConSaldo
            // 
            this.btnCtasCtesConSaldo.Caption = "Ctas Ctes con Saldos";
            this.btnCtasCtesConSaldo.Id = 15;
            this.btnCtasCtesConSaldo.Name = "btnCtasCtesConSaldo";
            this.btnCtasCtesConSaldo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCtasCtesConSaldo_ItemClick);
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
            // gregar
            // 
            this.gregar.Caption = "barSubItem4";
            this.gregar.Id = 8;
            this.gregar.Name = "gregar";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_EspecieLabel);
            this.panelControl1.Controls.Add(this.id_EspecieLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(conceptoLabel);
            this.panelControl1.Controls.Add(this.conceptoTextEdit);
            this.panelControl1.Controls.Add(id_TipoComprobanteLabel);
            this.panelControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(this.id_EntidadLookUpEdit);
            this.panelControl1.Controls.Add(id_TipoEntidadLabel);
            this.panelControl1.Controls.Add(this.id_TipoEntidadLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 57);
            this.panelControl1.TabIndex = 4;
            // 
            // id_EspecieLookUpEdit
            // 
            this.id_EspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "Id_Especie", true));
            this.id_EspecieLookUpEdit.EnterMoveNextControl = true;
            this.id_EspecieLookUpEdit.Location = new System.Drawing.Point(386, 6);
            this.id_EspecieLookUpEdit.MenuManager = this.barManager1;
            this.id_EspecieLookUpEdit.Name = "id_EspecieLookUpEdit";
            this.id_EspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre5")});
            this.id_EspecieLookUpEdit.Properties.NullText = "";
            this.id_EspecieLookUpEdit.Properties.ShowHeader = false;
            this.id_EspecieLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_EspecieLookUpEdit.TabIndex = 2;
            // 
            // entidadesCtaCteManager_ParametrosBusquedasBindingSource
            // 
            this.entidadesCtaCteManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EntidadesCtaCteManager.ParametrosBusquedas);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(547, 6);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Properties.MaxLength = 200;
            this.conceptoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.conceptoTextEdit.TabIndex = 3;
            this.conceptoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "Id_TipoComprobante", true));
            this.id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(386, 32);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre3")});
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 6;
            this.id_TipoComprobanteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.EnterMoveNextControl = true;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(208, 32);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 5;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.EnterMoveNextControl = true;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(59, 32);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 4;
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(165, 6);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(143, 20);
            this.id_EntidadLookUpEdit.TabIndex = 1;
            this.id_EntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_EntidadLookUpEdit_EditValueChanged);
            // 
            // id_TipoEntidadLookUpEdit
            // 
            this.id_TipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.entidadesCtaCteManager_ParametrosBusquedasBindingSource, "Id_TipoEntidad", true));
            this.id_TipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoEntidadLookUpEdit.Location = new System.Drawing.Point(59, 6);
            this.id_TipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoEntidadLookUpEdit.Name = "id_TipoEntidadLookUpEdit";
            this.id_TipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Nombre4")});
            this.id_TipoEntidadLookUpEdit.Properties.NullText = "";
            this.id_TipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoEntidadLookUpEdit.TabIndex = 0;
            this.id_TipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.id_TipoEntidadLookUpEdit_EditValueChanged_1);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.entidadesCtaCteManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 81);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 355);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // entidadesCtaCteManager_SearchResultBindingSource
            // 
            this.entidadesCtaCteManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EntidadesCtaCteManager.SearchResult);
            this.entidadesCtaCteManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.entidadesCtaCteManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTipoEntidad,
            this.colNombreEntidad,
            this.colEspecie,
            this.colMovimiento,
            this.colSaldo,
            this.colCentroCosto,
            this.colInternoSistema,
            this.colId_TipoEntidad,
            this.colId_Entidad,
            this.colId_Especie,
            this.colId_CentroCosto,
            this.colFecha,
            this.colId_TipoComprobante,
            this.colId_Comprobante,
            this.colConcepto,
            this.colDebito,
            this.colCredito,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.Id_Comentario,
            this.Color});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Verde";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.Lime;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[Color] = \'Verde\'";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Amarillo";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.Yellow;
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Expression = "[Color] = \'Amarillo\'";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Rojo";
            formatConditionRuleExpression3.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            formatConditionRuleExpression3.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression3.Expression = "[Color] = \'Rojo\'";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Azul";
            formatConditionRuleExpression4.Appearance.BackColor = System.Drawing.Color.LightBlue;
            formatConditionRuleExpression4.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression4.Expression = "[Color] = \'Azul\'";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colTipoEntidad
            // 
            this.colTipoEntidad.FieldName = "TipoEntidad";
            this.colTipoEntidad.Name = "colTipoEntidad";
            // 
            // colNombreEntidad
            // 
            this.colNombreEntidad.FieldName = "NombreEntidad";
            this.colNombreEntidad.Name = "colNombreEntidad";
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colMovimiento
            // 
            this.colMovimiento.FieldName = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Visible = true;
            this.colMovimiento.VisibleIndex = 1;
            this.colMovimiento.Width = 127;
            // 
            // colCentroCosto
            // 
            this.colCentroCosto.FieldName = "CentroCosto";
            this.colCentroCosto.Name = "colCentroCosto";
            // 
            // colInternoSistema
            // 
            this.colInternoSistema.FieldName = "InternoSistema";
            this.colInternoSistema.Name = "colInternoSistema";
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
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 74;
            // 
            // colId_TipoComprobante
            // 
            this.colId_TipoComprobante.FieldName = "Id_TipoComprobante";
            this.colId_TipoComprobante.Name = "colId_TipoComprobante";
            // 
            // colId_Comprobante
            // 
            this.colId_Comprobante.FieldName = "Id_Comprobante";
            this.colId_Comprobante.Name = "colId_Comprobante";
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 2;
            this.colConcepto.Width = 198;
            // 
            // colDebito
            // 
            this.colDebito.Caption = "Debe";
            this.colDebito.DisplayFormat.FormatString = "#,##0.00";
            this.colDebito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebito.FieldName = "Debito";
            this.colDebito.Name = "colDebito";
            this.colDebito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", "{0:N2}")});
            this.colDebito.Visible = true;
            this.colDebito.VisibleIndex = 3;
            this.colDebito.Width = 98;
            // 
            // colCredito
            // 
            this.colCredito.Caption = "Haber";
            this.colCredito.DisplayFormat.FormatString = "#,##0.00";
            this.colCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCredito.FieldName = "Credito";
            this.colCredito.Name = "colCredito";
            this.colCredito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", "{0:N2}")});
            this.colCredito.Visible = true;
            this.colCredito.VisibleIndex = 4;
            this.colCredito.Width = 103;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "Id", "MAX={0}")});
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
            // Id_Comentario
            // 
            this.Id_Comentario.Caption = "Id_Comentario";
            this.Id_Comentario.FieldName = "Id_Comentario";
            this.Id_Comentario.Name = "Id_Comentario";
            // 
            // Color
            // 
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Agregar";
            this.barSubItem3.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.barSubItem3.Id = 6;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // frmEntidadesCtaCte
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
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmEntidadesCtaCte";
            this.Text = "Cuenta Corriente de Entidades";
            this.Load += new System.EventHandler(this.frmEntidadesCtaCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesCtaCteManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesCtaCteManager_SearchResultBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private System.Windows.Forms.BindingSource entidadesCtaCteManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_TipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private System.Windows.Forms.BindingSource entidadesCtaCteManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colInternoSistema;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.LookUpEdit id_EspecieLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnComprobante;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem gregar;
        private DevExpress.XtraBars.BarSubItem barSubItemAgregar;
        private DevExpress.XtraBars.BarButtonItem btnMovimiento;
        private DevExpress.XtraBars.BarButtonItem btnOP;
        private DevExpress.XtraBars.BarButtonItem btnRecibo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnImprimeComprobante;
        private DevExpress.XtraBars.BarButtonItem btnCtasCtesConSaldo;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem btnEnviarCtaCteMail;
        private DevExpress.XtraBars.BarButtonItem btnComentario;
        private DevExpress.XtraGrid.Columns.GridColumn Id_Comentario;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
    }
}