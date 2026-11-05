namespace VENET_Tesoreria_UI
{
    partial class frmListaPagos
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label fecha_DesdeLabel;
            System.Windows.Forms.Label fecha_HastaLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label anuladoLabel;
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.listaPagosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro_Costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSentido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaConfirmacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.anuladoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.listaPagosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeLista = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnGeneraOP = new DevExpress.XtraBars.BarButtonItem();
            this.btnGeneraExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            idLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            anuladoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(37, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(170, 9);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 2;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(355, 9);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 4;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(7, 35);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 6;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // anuladoLabel
            // 
            anuladoLabel.AutoSize = true;
            anuladoLabel.Location = new System.Drawing.Point(193, 35);
            anuladoLabel.Name = "anuladoLabel";
            anuladoLabel.Size = new System.Drawing.Size(50, 13);
            anuladoLabel.TabIndex = 8;
            anuladoLabel.Text = "Anulado:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.listaPagosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 353);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // listaPagosManager_SearchResultBindingSource
            // 
            this.listaPagosManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ListaPagosManager.SearchResult);
            this.listaPagosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.listaPagosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSucursal,
            this.colCentro_Costo,
            this.colImporte,
            this.colId_Sucursal,
            this.colId_CentroCosto,
            this.colNumero,
            this.colFecha,
            this.colId_TipoEntidad,
            this.colId_Especie,
            this.colSentido,
            this.colDescripcion,
            this.colFechaConfirmacion,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colDetalle,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[FechaConfirmacion] = ?";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Gray;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "[FechaAnulacion] <> ?";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 3;
            this.colSucursal.Width = 118;
            // 
            // colCentro_Costo
            // 
            this.colCentro_Costo.Caption = "Centro Costo";
            this.colCentro_Costo.FieldName = "Centro_Costo";
            this.colCentro_Costo.Name = "colCentro_Costo";
            this.colCentro_Costo.Visible = true;
            this.colCentro_Costo.VisibleIndex = 4;
            this.colCentro_Costo.Width = 124;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 101;
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
            // colNumero
            // 
            this.colNumero.Caption = "Número";
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 1;
            this.colNumero.Width = 71;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 67;
            // 
            // colId_TipoEntidad
            // 
            this.colId_TipoEntidad.FieldName = "Id_TipoEntidad";
            this.colId_TipoEntidad.Name = "colId_TipoEntidad";
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            // 
            // colSentido
            // 
            this.colSentido.FieldName = "Sentido";
            this.colSentido.Name = "colSentido";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 142;
            // 
            // colFechaConfirmacion
            // 
            this.colFechaConfirmacion.Caption = "F. Confirmación";
            this.colFechaConfirmacion.FieldName = "FechaConfirmacion";
            this.colFechaConfirmacion.Name = "colFechaConfirmacion";
            this.colFechaConfirmacion.Visible = true;
            this.colFechaConfirmacion.VisibleIndex = 6;
            this.colFechaConfirmacion.Width = 93;
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
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(anuladoLabel);
            this.panelControl1.Controls.Add(this.anuladoCheckEdit);
            this.panelControl1.Controls.Add(id_SucursalLabel);
            this.panelControl1.Controls.Add(this.id_SucursalLookUpEdit);
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
            this.panelControl1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // anuladoCheckEdit
            // 
            this.anuladoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManager_ParametrosBusquedasBindingSource, "Anulado", true));
            this.anuladoCheckEdit.EnterMoveNextControl = true;
            this.anuladoCheckEdit.Location = new System.Drawing.Point(249, 32);
            this.anuladoCheckEdit.MenuManager = this.barManager1;
            this.anuladoCheckEdit.Name = "anuladoCheckEdit";
            this.anuladoCheckEdit.Properties.Caption = "";
            this.anuladoCheckEdit.Size = new System.Drawing.Size(75, 19);
            this.anuladoCheckEdit.TabIndex = 9;
            // 
            // listaPagosManager_ParametrosBusquedasBindingSource
            // 
            this.listaPagosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ListaPagosManager.ParametrosBusquedas);
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
            this.btnGeneraExcel,
            this.btnGeneraOP,
            this.btnImprimeLista});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeLista),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnImprimeLista
            // 
            this.btnImprimeLista.Caption = "Listado Detallado";
            this.btnImprimeLista.Id = 11;
            this.btnImprimeLista.Name = "btnImprimeLista";
            this.btnImprimeLista.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeLista_ItemClick);
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
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGeneraOP, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGeneraExcel, true)});
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
            // btnGeneraOP
            // 
            this.btnGeneraOP.Caption = "Generar Ordenes de Pagos";
            this.btnGeneraOP.Id = 10;
            this.btnGeneraOP.Name = "btnGeneraOP";
            this.btnGeneraOP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGeneraOP_ItemClick);
            // 
            // btnGeneraExcel
            // 
            this.btnGeneraExcel.Caption = "Generar Modelo Excel Importación";
            this.btnGeneraExcel.Id = 9;
            this.btnGeneraExcel.Name = "btnGeneraExcel";
            this.btnGeneraExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGeneraExcel_ItemClick);
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
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(64, 32);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Name29")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.ShowHeader = false;
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 7;
            this.id_SucursalLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(432, 6);
            this.fecha_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_HastaDateEdit.Name = "fecha_HastaDateEdit";
            this.fecha_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_HastaDateEdit.TabIndex = 5;
            // 
            // fecha_DesdeDateEdit
            // 
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(249, 6);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 3;
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(64, 6);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 1;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmListaPagos
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
            this.MinimumSize = new System.Drawing.Size(561, 236);
            this.Name = "frmListaPagos";
            this.Text = "Listas de Pagos";
            this.Load += new System.EventHandler(this.frmListaPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anuladoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private System.Windows.Forms.BindingSource listaPagosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.CheckEdit anuladoCheckEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private System.Windows.Forms.BindingSource listaPagosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro_Costo;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colSentido;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaConfirmacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnGeneraExcel;
        private DevExpress.XtraBars.BarButtonItem btnGeneraOP;
        private DevExpress.XtraBars.BarButtonItem btnImprimeLista;
    }
}