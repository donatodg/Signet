namespace VENET_Tesoreria_UI
{
    partial class frmRendiciones
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
            System.Windows.Forms.Label id_CajaLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.rendicionesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentro_Costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Vale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteVale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevolucion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaConfirmacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Caja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_CajaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.rendicionesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeRendicion = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnReporteConceptos = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnEMail = new DevExpress.XtraBars.BarButtonItem();
            idLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            id_CajaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            idLabel.Location = new System.Drawing.Point(146, 8);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(276, 8);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 2;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(459, 8);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(71, 13);
            fecha_HastaLabel.TabIndex = 4;
            fecha_HastaLabel.Text = "Fecha Hasta:";
            // 
            // id_CajaLabel
            // 
            id_CajaLabel.AutoSize = true;
            id_CajaLabel.Location = new System.Drawing.Point(5, 8);
            id_CajaLabel.Name = "id_CajaLabel";
            id_CajaLabel.Size = new System.Drawing.Size(33, 13);
            id_CajaLabel.TabIndex = 7;
            id_CajaLabel.Text = "Caja:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.rendicionesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 55);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 381);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // rendicionesManager_SearchResultBindingSource
            // 
            this.rendicionesManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RendicionesManager.SearchResult);
            this.rendicionesManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.rendicionesManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre_Entidad,
            this.colCentro_Costo,
            this.colId,
            this.colId_Personal,
            this.colId_CentroCosto,
            this.colFecha,
            this.colId_Vale,
            this.colImporteVale,
            this.colDevolucion,
            this.colDiferencia,
            this.colFechaConfirmacion,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colId_Caja,
            this.colCaja});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FechaConfirmacion] == ?";
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Gray;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[FechaAnulacion] != ?";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colNombre_Entidad
            // 
            this.colNombre_Entidad.Caption = "Personal";
            this.colNombre_Entidad.FieldName = "Nombre_Entidad";
            this.colNombre_Entidad.Name = "colNombre_Entidad";
            this.colNombre_Entidad.OptionsColumn.AllowEdit = false;
            this.colNombre_Entidad.OptionsColumn.ReadOnly = true;
            this.colNombre_Entidad.Visible = true;
            this.colNombre_Entidad.VisibleIndex = 3;
            this.colNombre_Entidad.Width = 108;
            // 
            // colCentro_Costo
            // 
            this.colCentro_Costo.FieldName = "Centro_Costo";
            this.colCentro_Costo.Name = "colCentro_Costo";
            this.colCentro_Costo.OptionsColumn.AllowEdit = false;
            this.colCentro_Costo.OptionsColumn.ReadOnly = true;
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
            this.colId.Width = 55;
            // 
            // colId_Personal
            // 
            this.colId_Personal.FieldName = "Id_Personal";
            this.colId_Personal.Name = "colId_Personal";
            this.colId_Personal.OptionsColumn.AllowEdit = false;
            this.colId_Personal.OptionsColumn.ReadOnly = true;
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            this.colId_CentroCosto.OptionsColumn.AllowEdit = false;
            this.colId_CentroCosto.OptionsColumn.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 73;
            // 
            // colId_Vale
            // 
            this.colId_Vale.Caption = "Nro Vale";
            this.colId_Vale.FieldName = "Ids_Vales";
            this.colId_Vale.Name = "colId_Vale";
            this.colId_Vale.OptionsColumn.AllowEdit = false;
            this.colId_Vale.OptionsColumn.ReadOnly = true;
            this.colId_Vale.Visible = true;
            this.colId_Vale.VisibleIndex = 4;
            this.colId_Vale.Width = 53;
            // 
            // colImporteVale
            // 
            this.colImporteVale.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteVale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteVale.FieldName = "ImporteVale";
            this.colImporteVale.Name = "colImporteVale";
            this.colImporteVale.OptionsColumn.AllowEdit = false;
            this.colImporteVale.OptionsColumn.ReadOnly = true;
            this.colImporteVale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteVale", "{0:N2}")});
            this.colImporteVale.Visible = true;
            this.colImporteVale.VisibleIndex = 5;
            this.colImporteVale.Width = 83;
            // 
            // colDevolucion
            // 
            this.colDevolucion.Caption = "Devolución";
            this.colDevolucion.DisplayFormat.FormatString = "#,##0.00";
            this.colDevolucion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDevolucion.FieldName = "Devolucion";
            this.colDevolucion.Name = "colDevolucion";
            this.colDevolucion.OptionsColumn.AllowEdit = false;
            this.colDevolucion.OptionsColumn.ReadOnly = true;
            this.colDevolucion.Visible = true;
            this.colDevolucion.VisibleIndex = 6;
            this.colDevolucion.Width = 83;
            // 
            // colDiferencia
            // 
            this.colDiferencia.DisplayFormat.FormatString = "#,##0.00";
            this.colDiferencia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiferencia.FieldName = "Diferencia";
            this.colDiferencia.Name = "colDiferencia";
            this.colDiferencia.OptionsColumn.AllowEdit = false;
            this.colDiferencia.OptionsColumn.ReadOnly = true;
            this.colDiferencia.Visible = true;
            this.colDiferencia.VisibleIndex = 7;
            this.colDiferencia.Width = 83;
            // 
            // colFechaConfirmacion
            // 
            this.colFechaConfirmacion.Caption = "F.Confirmación";
            this.colFechaConfirmacion.FieldName = "FechaConfirmacion";
            this.colFechaConfirmacion.Name = "colFechaConfirmacion";
            this.colFechaConfirmacion.OptionsColumn.AllowEdit = false;
            this.colFechaConfirmacion.OptionsColumn.ReadOnly = true;
            this.colFechaConfirmacion.Visible = true;
            this.colFechaConfirmacion.VisibleIndex = 8;
            this.colFechaConfirmacion.Width = 101;
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
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.Caption = "F.Anulación";
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            this.colFechaAnulacion.OptionsColumn.AllowEdit = false;
            this.colFechaAnulacion.OptionsColumn.ReadOnly = true;
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // colId_Caja
            // 
            this.colId_Caja.Caption = "Id_Caja";
            this.colId_Caja.FieldName = "Id_Caja";
            this.colId_Caja.Name = "colId_Caja";
            // 
            // colCaja
            // 
            this.colCaja.Caption = "Caja";
            this.colCaja.FieldName = "Caja";
            this.colCaja.Name = "colCaja";
            this.colCaja.Visible = true;
            this.colCaja.VisibleIndex = 1;
            this.colCaja.Width = 77;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_CajaLabel);
            this.panelControl1.Controls.Add(this.id_CajaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fecha_HastaLabel);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Controls.Add(this.fecha_DesdeDateEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 31);
            this.panelControl1.TabIndex = 1;
            // 
            // id_CajaLookUpEdit
            // 
            this.id_CajaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManager_ParametrosBusquedasBindingSource, "Id_Caja", true));
            this.id_CajaLookUpEdit.Location = new System.Drawing.Point(40, 5);
            this.id_CajaLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaLookUpEdit.Name = "id_CajaLookUpEdit";
            this.id_CajaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_CajaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaLookUpEdit.Properties.NullText = "";
            this.id_CajaLookUpEdit.Properties.PopupWidth = 500;
            this.id_CajaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_CajaLookUpEdit.TabIndex = 8;
            this.id_CajaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // rendicionesManager_ParametrosBusquedasBindingSource
            // 
            this.rendicionesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RendicionesManager.ParametrosBusquedas);
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
            this.barSubItem3,
            this.btnReporteConceptos,
            this.btnImprimeRendicion,
            this.btnEMail});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 13;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(552, 318);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 4;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeRendicion),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnImprimeRendicion
            // 
            this.btnImprimeRendicion.Caption = "Rendición de Vales";
            this.btnImprimeRendicion.Id = 11;
            this.btnImprimeRendicion.Name = "btnImprimeRendicion";
            this.btnImprimeRendicion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeRendicion_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEMail, true)});
            this.barSubItem1.Name = "barSubItem1";
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
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Ver";
            this.barSubItem3.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem3.Id = 9;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReporteConceptos)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnReporteConceptos
            // 
            this.btnReporteConceptos.Caption = "Reporte por Concepto";
            this.btnReporteConceptos.Id = 10;
            this.btnReporteConceptos.Name = "btnReporteConceptos";
            this.btnReporteConceptos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReporteConceptos_ItemClick);
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
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(651, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(536, 5);
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
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(351, 5);
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
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.Location = new System.Drawing.Point(167, 5);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 1;
            // 
            // btnEMail
            // 
            this.btnEMail.Caption = "Enviar por EMail";
            this.btnEMail.Id = 12;
            this.btnEMail.Name = "btnEMail";
            this.btnEMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEMail_ItemClick);
            // 
            // frmRendiciones
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
            this.MinimumSize = new System.Drawing.Size(739, 222);
            this.Name = "frmRendiciones";
            this.Text = "Rendiciones";
            this.Load += new System.EventHandler(this.frmRendicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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
        private System.Windows.Forms.BindingSource rendicionesManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCentro_Costo;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Vale;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteVale;
        private DevExpress.XtraGrid.Columns.GridColumn colDevolucion;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaConfirmacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private System.Windows.Forms.BindingSource rendicionesManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnReporteConceptos;
        private DevExpress.XtraBars.BarButtonItem btnImprimeRendicion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Caja;
        private DevExpress.XtraGrid.Columns.GridColumn colCaja;
        private DevExpress.XtraEditors.LookUpEdit id_CajaLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnEMail;
    }
}