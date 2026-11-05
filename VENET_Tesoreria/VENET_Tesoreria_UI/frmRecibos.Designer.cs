namespace VENET_Tesoreria_UI
{
    partial class frmRecibos
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
            System.Windows.Forms.Label fecha_Liquidacion_DesdeLabel;
            System.Windows.Forms.Label fecha_Liquidacion_HastaLabel;
            System.Windows.Forms.Label letraLabel;
            System.Windows.Forms.Label puntoVentaLabel;
            System.Windows.Forms.Label nroComprobanteLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label anuladoLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.recibosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Liquidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie_Mov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha_Anulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad_Mov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte_Pesos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteSinAplicar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.recibosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeRecibo = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnAsignaCmp = new DevExpress.XtraBars.BarButtonItem();
            this.btnDesasignaCmp = new DevExpress.XtraBars.BarButtonItem();
            this.btnPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnMail = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnVerCtaCte = new DevExpress.XtraBars.BarButtonItem();
            this.btnReporteCompleto = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.anuladoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nroComprobanteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.puntoVentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.letraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fecha_Liquidacion_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_Liquidacion_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnPercepciones = new DevExpress.XtraBars.BarButtonItem();
            idLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            conceptoLabel = new System.Windows.Forms.Label();
            fecha_Liquidacion_DesdeLabel = new System.Windows.Forms.Label();
            fecha_Liquidacion_HastaLabel = new System.Windows.Forms.Label();
            letraLabel = new System.Windows.Forms.Label();
            puntoVentaLabel = new System.Windows.Forms.Label();
            nroComprobanteLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            anuladoLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(55, 105);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 2;
            idLabel.Text = "Id:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(187, 9);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 4;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(377, 9);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 6;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(19, 27);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 0;
            conceptoLabel.Text = "Concepto:";
            // 
            // fecha_Liquidacion_DesdeLabel
            // 
            fecha_Liquidacion_DesdeLabel.AutoSize = true;
            fecha_Liquidacion_DesdeLabel.Location = new System.Drawing.Point(202, 27);
            fecha_Liquidacion_DesdeLabel.Name = "fecha_Liquidacion_DesdeLabel";
            fecha_Liquidacion_DesdeLabel.Size = new System.Drawing.Size(128, 13);
            fecha_Liquidacion_DesdeLabel.TabIndex = 2;
            fecha_Liquidacion_DesdeLabel.Text = "Fecha Liquidación Desde:";
            // 
            // fecha_Liquidacion_HastaLabel
            // 
            fecha_Liquidacion_HastaLabel.AutoSize = true;
            fecha_Liquidacion_HastaLabel.Location = new System.Drawing.Point(449, 27);
            fecha_Liquidacion_HastaLabel.Name = "fecha_Liquidacion_HastaLabel";
            fecha_Liquidacion_HastaLabel.Size = new System.Drawing.Size(126, 13);
            fecha_Liquidacion_HastaLabel.TabIndex = 4;
            fecha_Liquidacion_HastaLabel.Text = "Fecha Liquidación Hasta:";
            // 
            // letraLabel
            // 
            letraLabel.AutoSize = true;
            letraLabel.Location = new System.Drawing.Point(41, 53);
            letraLabel.Name = "letraLabel";
            letraLabel.Size = new System.Drawing.Size(36, 13);
            letraLabel.TabIndex = 8;
            letraLabel.Text = "Letra:";
            // 
            // puntoVentaLabel
            // 
            puntoVentaLabel.AutoSize = true;
            puntoVentaLabel.Location = new System.Drawing.Point(264, 53);
            puntoVentaLabel.Name = "puntoVentaLabel";
            puntoVentaLabel.Size = new System.Drawing.Size(70, 13);
            puntoVentaLabel.TabIndex = 10;
            puntoVentaLabel.Text = "Punto Venta:";
            // 
            // nroComprobanteLabel
            // 
            nroComprobanteLabel.AutoSize = true;
            nroComprobanteLabel.Location = new System.Drawing.Point(484, 53);
            nroComprobanteLabel.Name = "nroComprobanteLabel";
            nroComprobanteLabel.Size = new System.Drawing.Size(96, 13);
            nroComprobanteLabel.TabIndex = 12;
            nroComprobanteLabel.Text = "Nro Comprobante:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 79);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 15;
            label1.Text = "Entidad:";
            // 
            // anuladoLabel
            // 
            anuladoLabel.AutoSize = true;
            anuladoLabel.Location = new System.Drawing.Point(526, 80);
            anuladoLabel.Name = "anuladoLabel";
            anuladoLabel.Size = new System.Drawing.Size(50, 13);
            anuladoLabel.TabIndex = 16;
            anuladoLabel.Text = "Anulado:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(12, 9);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 6;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.recibosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 189);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 250);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // recibosManager_SearchResultBindingSource
            // 
            this.recibosManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RecibosManager.SearchResult);
            this.recibosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.recibosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre_Entidad,
            this.colId,
            this.colId_Sucursal,
            this.colTipoEntidad,
            this.colId_Entidad,
            this.colFecha,
            this.colConcepto,
            this.colLetra,
            this.colNroComprobante,
            this.colFecha_Liquidacion,
            this.colId_Especie_Mov,
            this.colFecha_Anulacion,
            this.colId_Entidad_Mov,
            this.colObservaciones,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colCentroCosto,
            this.colImporte,
            this.colSucursal,
            this.colMotivoAnulacion,
            this.colImporte_Pesos,
            this.colImporteSinAplicar});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[Fecha_Liquidacion] == ?";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Gray;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "[Fecha_Anulacion] != ?";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colNombre_Entidad
            // 
            this.colNombre_Entidad.Caption = "Nombre";
            this.colNombre_Entidad.FieldName = "Nombre_Entidad";
            this.colNombre_Entidad.Name = "colNombre_Entidad";
            this.colNombre_Entidad.OptionsColumn.AllowEdit = false;
            this.colNombre_Entidad.OptionsColumn.ReadOnly = true;
            this.colNombre_Entidad.Visible = true;
            this.colNombre_Entidad.VisibleIndex = 3;
            this.colNombre_Entidad.Width = 97;
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
            this.colId.Width = 73;
            // 
            // colId_Sucursal
            // 
            this.colId_Sucursal.Caption = "Id_Sucursal";
            this.colId_Sucursal.FieldName = "Id_Sucursal";
            this.colId_Sucursal.Name = "colId_Sucursal";
            this.colId_Sucursal.OptionsColumn.AllowEdit = false;
            this.colId_Sucursal.OptionsColumn.ReadOnly = true;
            // 
            // colTipoEntidad
            // 
            this.colTipoEntidad.FieldName = "TipoEntidad";
            this.colTipoEntidad.Name = "colTipoEntidad";
            this.colTipoEntidad.OptionsColumn.AllowEdit = false;
            this.colTipoEntidad.OptionsColumn.ReadOnly = true;
            this.colTipoEntidad.Visible = true;
            this.colTipoEntidad.VisibleIndex = 2;
            this.colTipoEntidad.Width = 88;
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.Caption = "Id Entidad";
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            this.colId_Entidad.OptionsColumn.AllowEdit = false;
            this.colId_Entidad.OptionsColumn.ReadOnly = true;
            this.colId_Entidad.Width = 88;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 86;
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.OptionsColumn.ReadOnly = true;
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 4;
            this.colConcepto.Width = 86;
            // 
            // colLetra
            // 
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            this.colLetra.OptionsColumn.AllowEdit = false;
            this.colLetra.OptionsColumn.ReadOnly = true;
            this.colLetra.Width = 33;
            // 
            // colNroComprobante
            // 
            this.colNroComprobante.FieldName = "Comprobante";
            this.colNroComprobante.Name = "colNroComprobante";
            this.colNroComprobante.OptionsColumn.AllowEdit = false;
            this.colNroComprobante.OptionsColumn.ReadOnly = true;
            this.colNroComprobante.Visible = true;
            this.colNroComprobante.VisibleIndex = 5;
            this.colNroComprobante.Width = 101;
            // 
            // colFecha_Liquidacion
            // 
            this.colFecha_Liquidacion.Caption = "F.Liquidación";
            this.colFecha_Liquidacion.FieldName = "Fecha_Liquidacion";
            this.colFecha_Liquidacion.Name = "colFecha_Liquidacion";
            this.colFecha_Liquidacion.OptionsColumn.AllowEdit = false;
            this.colFecha_Liquidacion.OptionsColumn.ReadOnly = true;
            this.colFecha_Liquidacion.Visible = true;
            this.colFecha_Liquidacion.VisibleIndex = 6;
            this.colFecha_Liquidacion.Width = 101;
            // 
            // colId_Especie_Mov
            // 
            this.colId_Especie_Mov.FieldName = "Id_Especie_Mov";
            this.colId_Especie_Mov.Name = "colId_Especie_Mov";
            this.colId_Especie_Mov.OptionsColumn.AllowEdit = false;
            this.colId_Especie_Mov.OptionsColumn.ReadOnly = true;
            this.colId_Especie_Mov.Width = 101;
            // 
            // colFecha_Anulacion
            // 
            this.colFecha_Anulacion.Caption = "F.Anulación";
            this.colFecha_Anulacion.FieldName = "Fecha_Anulacion";
            this.colFecha_Anulacion.Name = "colFecha_Anulacion";
            this.colFecha_Anulacion.OptionsColumn.AllowEdit = false;
            this.colFecha_Anulacion.OptionsColumn.ReadOnly = true;
            // 
            // colId_Entidad_Mov
            // 
            this.colId_Entidad_Mov.FieldName = "Id_Entidad_Mov";
            this.colId_Entidad_Mov.Name = "colId_Entidad_Mov";
            this.colId_Entidad_Mov.OptionsColumn.AllowEdit = false;
            this.colId_Entidad_Mov.OptionsColumn.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.OptionsColumn.ReadOnly = true;
            this.colObservaciones.Width = 119;
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
            // colCentroCosto
            // 
            this.colCentroCosto.Caption = "Centro Costo";
            this.colCentroCosto.FieldName = "Centro_Costo";
            this.colCentroCosto.Name = "colCentroCosto";
            this.colCentroCosto.OptionsColumn.AllowEdit = false;
            this.colCentroCosto.OptionsColumn.ReadOnly = true;
            this.colCentroCosto.Visible = true;
            this.colCentroCosto.VisibleIndex = 7;
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
            // colSucursal
            // 
            this.colSucursal.Caption = "Sucursal";
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.OptionsColumn.AllowEdit = false;
            this.colSucursal.OptionsColumn.ReadOnly = true;
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
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
            // 
            // colImporteSinAplicar
            // 
            this.colImporteSinAplicar.Caption = "Importe Sin Aplicar";
            this.colImporteSinAplicar.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteSinAplicar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteSinAplicar.FieldName = "ImporteSinAplicar";
            this.colImporteSinAplicar.Name = "colImporteSinAplicar";
            this.colImporteSinAplicar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteSinAplicar", "{0:N2}")});
            this.colImporteSinAplicar.Visible = true;
            this.colImporteSinAplicar.VisibleIndex = 9;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_SucursalLabel);
            this.panelControl1.Controls.Add(this.id_SucursalLookUpEdit);
            this.panelControl1.Controls.Add(fecha_HastaLabel);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Controls.Add(this.fecha_DesdeDateEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(65, 6);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.PopupWidth = 500;
            this.id_SucursalLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(116, 20);
            this.id_SucursalLookUpEdit.TabIndex = 0;
            // 
            // recibosManager_ParametrosBusquedasBindingSource
            // 
            this.recibosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RecibosManager.ParametrosBusquedas);
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
            this.barStaticItemFooter,
            this.barSubItem2,
            this.btnConfirmar,
            this.btnAnular,
            this.btnImprimeRecibo,
            this.btnAsignaCmp,
            this.btnDesasignaCmp,
            this.barSubItem3,
            this.btnVerCtaCte,
            this.btnReporteCompleto,
            this.btnMail,
            this.btnPDF,
            this.btnPercepciones});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
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
            this.btnAgregar.Id = 0;
            this.btnAgregar.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Id = 1;
            this.btnModificar.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 2;
            this.btnEliminar.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.ImageOptions.LargeImage = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_32x32;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Id = 3;
            this.barSubItem1.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeRecibo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnImprimeRecibo
            // 
            this.btnImprimeRecibo.Caption = "Recibo";
            this.btnImprimeRecibo.Id = 9;
            this.btnImprimeRecibo.Name = "btnImprimeRecibo";
            this.btnImprimeRecibo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeRecibo_ItemClick);
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
            this.barSubItem2.Id = 6;
            this.barSubItem2.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.ImageOptions.LargeImage = global::VENET_Tesoreria_UI.Properties.Resources.properties_32x32;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAsignaCmp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDesasignaCmp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPDF, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMail, true)});
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
            // btnAsignaCmp
            // 
            this.btnAsignaCmp.Caption = "Asignar Comprobantes";
            this.btnAsignaCmp.Id = 10;
            this.btnAsignaCmp.Name = "btnAsignaCmp";
            this.btnAsignaCmp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAsignaCmp_ItemClick);
            // 
            // btnDesasignaCmp
            // 
            this.btnDesasignaCmp.Caption = "Desasignar Comprobantes";
            this.btnDesasignaCmp.Id = 11;
            this.btnDesasignaCmp.Name = "btnDesasignaCmp";
            this.btnDesasignaCmp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDesasignaCmp_ItemClick);
            // 
            // btnPDF
            // 
            this.btnPDF.Caption = "Generar PDF";
            this.btnPDF.Id = 16;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPDF_ItemClick);
            // 
            // btnMail
            // 
            this.btnMail.Caption = "Enviar por Email";
            this.btnMail.Id = 15;
            this.btnMail.Name = "btnMail";
            this.btnMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMail_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Ver";
            this.barSubItem3.Id = 12;
            this.barSubItem3.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVerCtaCte),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPercepciones, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReporteCompleto, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnVerCtaCte
            // 
            this.btnVerCtaCte.Caption = "Cuenta Corriente de la Entidad";
            this.btnVerCtaCte.Id = 13;
            this.btnVerCtaCte.Name = "btnVerCtaCte";
            this.btnVerCtaCte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerCtaCte_ItemClick);
            // 
            // btnReporteCompleto
            // 
            this.btnReporteCompleto.Caption = "Reporte Completo";
            this.btnReporteCompleto.Id = 14;
            this.btnReporteCompleto.Name = "btnReporteCompleto";
            this.btnReporteCompleto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReporteCompleto_ItemClick);
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
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(734, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 439);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(454, 6);
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
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(267, 6);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAvanzada
            // 
            this.btnAvanzada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvanzada.ImageOptions.Image = global::VENET_Tesoreria_UI.Properties.Resources.filter_16x16;
            this.btnAvanzada.Location = new System.Drawing.Point(618, 4);
            this.btnAvanzada.Name = "btnAvanzada";
            this.btnAvanzada.Size = new System.Drawing.Size(23, 23);
            this.btnAvanzada.TabIndex = 3;
            this.btnAvanzada.CheckedChanged += new System.EventHandler(this.btnAvanzada_CheckedChanged);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(81, 102);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 9;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // gcBusquedaAvanzada
            // 
            this.gcBusquedaAvanzada.Controls.Add(this.id_EntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(anuladoLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.anuladoCheckEdit);
            this.gcBusquedaAvanzada.Controls.Add(this.tipoEntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(idLabel);
            this.gcBusquedaAvanzada.Controls.Add(label1);
            this.gcBusquedaAvanzada.Controls.Add(this.idTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(nroComprobanteLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.nroComprobanteTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(puntoVentaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.puntoVentaTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(letraLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.letraTextEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_HastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_HastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_Liquidacion_DesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_Liquidacion_DesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(conceptoLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.conceptoTextEdit);
            this.gcBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 57);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 132);
            this.gcBusquedaAvanzada.TabIndex = 1;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(187, 76);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(252, 20);
            this.id_EntidadLookUpEdit.TabIndex = 7;
            // 
            // anuladoCheckEdit
            // 
            this.anuladoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Anulado", true));
            this.anuladoCheckEdit.EnterMoveNextControl = true;
            this.anuladoCheckEdit.Location = new System.Drawing.Point(581, 77);
            this.anuladoCheckEdit.MenuManager = this.barManager1;
            this.anuladoCheckEdit.Name = "anuladoCheckEdit";
            this.anuladoCheckEdit.Properties.Caption = "";
            this.anuladoCheckEdit.Size = new System.Drawing.Size(30, 20);
            this.anuladoCheckEdit.TabIndex = 8;
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "TipoEntidad", true));
            this.tipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(81, 76);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Valor")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 6;
            this.tipoEntidadLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.tipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.tipoEntidadLookUpEdit_EditValueChanged);
            // 
            // nroComprobanteTextEdit
            // 
            this.nroComprobanteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "NroComprobante", true));
            this.nroComprobanteTextEdit.EnterMoveNextControl = true;
            this.nroComprobanteTextEdit.Location = new System.Drawing.Point(583, 50);
            this.nroComprobanteTextEdit.MenuManager = this.barManager1;
            this.nroComprobanteTextEdit.Name = "nroComprobanteTextEdit";
            this.nroComprobanteTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroComprobanteTextEdit.TabIndex = 5;
            this.nroComprobanteTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // puntoVentaTextEdit
            // 
            this.puntoVentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "PuntoVenta", true));
            this.puntoVentaTextEdit.EnterMoveNextControl = true;
            this.puntoVentaTextEdit.Location = new System.Drawing.Point(339, 50);
            this.puntoVentaTextEdit.MenuManager = this.barManager1;
            this.puntoVentaTextEdit.Name = "puntoVentaTextEdit";
            this.puntoVentaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.puntoVentaTextEdit.TabIndex = 4;
            this.puntoVentaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // letraTextEdit
            // 
            this.letraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Letra", true));
            this.letraTextEdit.EnterMoveNextControl = true;
            this.letraTextEdit.Location = new System.Drawing.Point(81, 50);
            this.letraTextEdit.MenuManager = this.barManager1;
            this.letraTextEdit.Name = "letraTextEdit";
            this.letraTextEdit.Size = new System.Drawing.Size(100, 20);
            this.letraTextEdit.TabIndex = 3;
            // 
            // fecha_Liquidacion_HastaDateEdit
            // 
            this.fecha_Liquidacion_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Hasta", true));
            this.fecha_Liquidacion_HastaDateEdit.EditValue = null;
            this.fecha_Liquidacion_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_Liquidacion_HastaDateEdit.Location = new System.Drawing.Point(583, 24);
            this.fecha_Liquidacion_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_HastaDateEdit.Name = "fecha_Liquidacion_HastaDateEdit";
            this.fecha_Liquidacion_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_HastaDateEdit.TabIndex = 2;
            // 
            // fecha_Liquidacion_DesdeDateEdit
            // 
            this.fecha_Liquidacion_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Fecha_Liquidacion_Desde", true));
            this.fecha_Liquidacion_DesdeDateEdit.EditValue = null;
            this.fecha_Liquidacion_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_Liquidacion_DesdeDateEdit.Location = new System.Drawing.Point(339, 24);
            this.fecha_Liquidacion_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_Liquidacion_DesdeDateEdit.Name = "fecha_Liquidacion_DesdeDateEdit";
            this.fecha_Liquidacion_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_Liquidacion_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_Liquidacion_DesdeDateEdit.TabIndex = 1;
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.recibosManager_ParametrosBusquedasBindingSource, "Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(81, 24);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.conceptoTextEdit.TabIndex = 0;
            // 
            // btnPercepciones
            // 
            this.btnPercepciones.Caption = "Percepciones";
            this.btnPercepciones.Id = 17;
            this.btnPercepciones.Name = "btnPercepciones";
            this.btnPercepciones.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPercepciones_ItemClick);
            // 
            // frmRecibos
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
            this.MinimumSize = new System.Drawing.Size(716, 297);
            this.Name = "frmRecibos";
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.frmRecibos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroComprobanteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_Liquidacion_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gcBusquedaAvanzada;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.BindingSource recibosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colNroComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Liquidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie_Mov;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha_Anulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad_Mov;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private System.Windows.Forms.BindingSource recibosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit nroComprobanteTextEdit;
        private DevExpress.XtraEditors.TextEdit puntoVentaTextEdit;
        private DevExpress.XtraEditors.TextEdit letraTextEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_Liquidacion_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.CheckEdit anuladoCheckEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnImprimeRecibo;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte_Pesos;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnAsignaCmp;
        private DevExpress.XtraBars.BarButtonItem btnDesasignaCmp;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteSinAplicar;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnVerCtaCte;
        private DevExpress.XtraBars.BarButtonItem btnReporteCompleto;
        private DevExpress.XtraBars.BarButtonItem btnMail;
        private DevExpress.XtraBars.BarButtonItem btnPDF;
        private DevExpress.XtraBars.BarButtonItem btnPercepciones;
    }
}