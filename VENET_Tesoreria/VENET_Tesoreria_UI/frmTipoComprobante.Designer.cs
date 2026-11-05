namespace VENET_Tesoreria_UI
{
    partial class frmTipoComprobante
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
            System.Windows.Forms.Label descripcionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoComprobante));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnTalonarios = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tipoComprobantesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tipoComprobanteManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcionCorta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternoSistema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoCompProcesa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoCompAnula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMueveStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_MovimientoCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_MovimientoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeneraDeuda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestaStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilizaImpuestos = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComprobantesManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComprobanteManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(17, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(153, 9);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 2;
            descripcionLabel.Text = "Descripción:";
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
            this.btnTalonarios});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
            this.btnAgregar.Id = 0;
            this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
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
            this.barStaticItemFooter.Id = 6;
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTalonarios)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnTalonarios
            // 
            this.btnTalonarios.Id = 9;
            this.btnTalonarios.Name = "btnTalonarios";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAceptar);
            this.panelControl1.Controls.Add(descripcionLabel);
            this.panelControl1.Controls.Add(this.descripcionTextEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 33);
            this.panelControl1.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(654, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Buscar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoComprobantesManager_ParametrosBusquedasBindingSource, "Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(225, 6);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(216, 20);
            this.descripcionTextEdit.TabIndex = 3;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // tipoComprobantesManager_ParametrosBusquedasBindingSource
            // 
            this.tipoComprobantesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.TipoComprobanteManager.ParametrosBusquedas);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoComprobantesManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.Location = new System.Drawing.Point(42, 6);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 1;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tipoComprobanteManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 379);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // tipoComprobanteManager_SearchResultBindingSource
            // 
            this.tipoComprobanteManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.TipoComprobanteManager.SearchResult);
            this.tipoComprobanteManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.tipoComprobanteManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colDescripcionCorta,
            this.colId_Area,
            this.colInternoSistema,
            this.colOrden,
            this.colId_TipoCompProcesa,
            this.colId_TipoCompAnula,
            this.colMueveStock,
            this.colId_MovimientoCaja,
            this.colId_MovimientoEntidad,
            this.colGeneraDeuda,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel,
            this.colRestaStock,
            this.colUtilizaImpuestos});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colId_Area, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 470;
            // 
            // colDescripcionCorta
            // 
            this.colDescripcionCorta.Caption = "Descripción Corta";
            this.colDescripcionCorta.FieldName = "DescripcionCorta";
            this.colDescripcionCorta.Name = "colDescripcionCorta";
            this.colDescripcionCorta.Visible = true;
            this.colDescripcionCorta.VisibleIndex = 2;
            this.colDescripcionCorta.Width = 154;
            // 
            // colId_Area
            // 
            this.colId_Area.Caption = "Area";
            this.colId_Area.FieldName = "Id_Area";
            this.colId_Area.Name = "colId_Area";
            this.colId_Area.Visible = true;
            this.colId_Area.VisibleIndex = 3;
            // 
            // colInternoSistema
            // 
            this.colInternoSistema.FieldName = "InternoSistema";
            this.colInternoSistema.Name = "colInternoSistema";
            // 
            // colOrden
            // 
            this.colOrden.FieldName = "Orden";
            this.colOrden.Name = "colOrden";
            // 
            // colId_TipoCompProcesa
            // 
            this.colId_TipoCompProcesa.FieldName = "Id_TipoCompProcesa";
            this.colId_TipoCompProcesa.Name = "colId_TipoCompProcesa";
            // 
            // colId_TipoCompAnula
            // 
            this.colId_TipoCompAnula.FieldName = "Id_TipoCompAnula";
            this.colId_TipoCompAnula.Name = "colId_TipoCompAnula";
            // 
            // colMueveStock
            // 
            this.colMueveStock.Caption = "Incrementa Stock";
            this.colMueveStock.FieldName = "MueveStock";
            this.colMueveStock.Name = "colMueveStock";
            // 
            // colId_MovimientoCaja
            // 
            this.colId_MovimientoCaja.FieldName = "Id_MovimientoCaja";
            this.colId_MovimientoCaja.Name = "colId_MovimientoCaja";
            // 
            // colId_MovimientoEntidad
            // 
            this.colId_MovimientoEntidad.FieldName = "Id_MovimientoEntidad";
            this.colId_MovimientoEntidad.Name = "colId_MovimientoEntidad";
            // 
            // colGeneraDeuda
            // 
            this.colGeneraDeuda.FieldName = "GeneraDeuda";
            this.colGeneraDeuda.Name = "colGeneraDeuda";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 72;
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
            // colFechaDel
            // 
            this.colFechaDel.FieldName = "FechaDel";
            this.colFechaDel.Name = "colFechaDel";
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
            // colUserDel
            // 
            this.colUserDel.FieldName = "UserDel";
            this.colUserDel.Name = "colUserDel";
            // 
            // colRestaStock
            // 
            this.colRestaStock.Caption = "Decrementa Stock";
            this.colRestaStock.FieldName = "RestaStock";
            this.colRestaStock.Name = "colRestaStock";
            // 
            // colUtilizaImpuestos
            // 
            this.colUtilizaImpuestos.Caption = "Utiliza Impuestos";
            this.colUtilizaImpuestos.FieldName = "UtilizaImpuestos";
            this.colUtilizaImpuestos.Name = "colUtilizaImpuestos";
            // 
            // frmTipoComprobante
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
            this.MinimumSize = new System.Drawing.Size(544, 227);
            this.Name = "frmTipoComprobante";
            this.Text = "Tipos de Comprobantes";
            this.Load += new System.EventHandler(this.frmTipoMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComprobantesManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComprobanteManager_SearchResultBindingSource)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnAceptar;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource tipoComprobantesManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnTalonarios;
        private System.Windows.Forms.BindingSource tipoComprobanteManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionCorta;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Area;
        private DevExpress.XtraGrid.Columns.GridColumn colInternoSistema;
        private DevExpress.XtraGrid.Columns.GridColumn colOrden;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoCompProcesa;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoCompAnula;
        private DevExpress.XtraGrid.Columns.GridColumn colMueveStock;
        private DevExpress.XtraGrid.Columns.GridColumn colId_MovimientoCaja;
        private DevExpress.XtraGrid.Columns.GridColumn colId_MovimientoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colGeneraDeuda;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private DevExpress.XtraGrid.Columns.GridColumn colRestaStock;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilizaImpuestos;
    }
}