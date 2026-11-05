namespace VENET_Gestion_UI
{
    partial class frmProductosHistorialPrecios
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
            System.Windows.Forms.Label id_ProductoLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosHistorialPreciosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.FiltroBusquedaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.id_ProductoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_ProductoLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosHistorialPreciosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ProductoLabel
            // 
            id_ProductoLabel.AutoSize = true;
            id_ProductoLabel.Location = new System.Drawing.Point(8, 8);
            id_ProductoLabel.Name = "id_ProductoLabel";
            id_ProductoLabel.Size = new System.Drawing.Size(54, 13);
            id_ProductoLabel.TabIndex = 0;
            id_ProductoLabel.Text = "Producto:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(299, 8);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 2;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(474, 8);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(71, 13);
            fechaHastaLabel.TabIndex = 4;
            fechaHastaLabel.Text = "Fecha Hasta:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosHistorialPreciosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 54);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 382);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosHistorialPreciosManager_SearchResultBindingSource
            // 
            this.productosHistorialPreciosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosHistorialPreciosManager.SearchResult);
            this.productosHistorialPreciosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosHistorialPreciosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colCodigo,
            this.colCodigoFabrica,
            this.colCodigoBarras,
            this.colEspecie,
            this.colDescripcion,
            this.colId_Producto,
            this.colImporte,
            this.colImporteCosto,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "{0}")});
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 77;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 1;
            this.colCodigo.Width = 102;
            // 
            // colCodigoFabrica
            // 
            this.colCodigoFabrica.Caption = "Código Fábrica";
            this.colCodigoFabrica.FieldName = "CodigoFabrica";
            this.colCodigoFabrica.Name = "colCodigoFabrica";
            this.colCodigoFabrica.Visible = true;
            this.colCodigoFabrica.VisibleIndex = 2;
            this.colCodigoFabrica.Width = 102;
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.Caption = "Código Barras";
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.Visible = true;
            this.colCodigoBarras.VisibleIndex = 3;
            this.colCodigoBarras.Width = 102;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 4;
            this.colDescripcion.Width = 130;
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 85;
            // 
            // colImporteCosto
            // 
            this.colImporteCosto.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteCosto.FieldName = "ImporteCosto";
            this.colImporteCosto.Name = "colImporteCosto";
            this.colImporteCosto.Visible = true;
            this.colImporteCosto.VisibleIndex = 6;
            this.colImporteCosto.Width = 95;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.FiltroBusquedaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(id_ProductoLabel);
            this.panelControl1.Controls.Add(this.id_ProductoLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 30);
            this.panelControl1.TabIndex = 1;
            // 
            // FiltroBusquedaLookUpEdit
            // 
            this.FiltroBusquedaLookUpEdit.EnterMoveNextControl = true;
            this.FiltroBusquedaLookUpEdit.Location = new System.Drawing.Point(63, 5);
            this.FiltroBusquedaLookUpEdit.MenuManager = this.barManager1;
            this.FiltroBusquedaLookUpEdit.Name = "FiltroBusquedaLookUpEdit";
            this.FiltroBusquedaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FiltroBusquedaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name28")});
            this.FiltroBusquedaLookUpEdit.Properties.NullText = "";
            this.FiltroBusquedaLookUpEdit.Properties.ShowHeader = false;
            this.FiltroBusquedaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.FiltroBusquedaLookUpEdit.TabIndex = 29;
            this.FiltroBusquedaLookUpEdit.EditValueChanged += new System.EventHandler(this.FiltroBusquedaLookUpEdit_EditValueChanged);
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
            this.barSubItem1,
            this.barStaticItemFooter,
            this.btnResultado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 2;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
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
            this.barStaticItemFooter.Id = 1;
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
            this.btnBuscar.Location = new System.Drawing.Point(654, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(545, 5);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 5;
            // 
            // productosHistorialPreciosManager_ParametrosBusquedasBindingSource
            // 
            this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosHistorialPreciosManager.ParametrosBusquedas);
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(372, 5);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 3;
            // 
            // id_ProductoLookUpEdit
            // 
            this.id_ProductoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource, "Id_Producto", true));
            this.id_ProductoLookUpEdit.Location = new System.Drawing.Point(164, 5);
            this.id_ProductoLookUpEdit.MenuManager = this.barManager1;
            this.id_ProductoLookUpEdit.Name = "id_ProductoLookUpEdit";
            this.id_ProductoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ProductoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripción"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodigoFabrica", "C.Fábrica"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodigoBarras", "C.Barras")});
            this.id_ProductoLookUpEdit.Properties.NullText = "[Todos]";
            this.id_ProductoLookUpEdit.Properties.PopupWidth = 500;
            this.id_ProductoLookUpEdit.Size = new System.Drawing.Size(133, 20);
            this.id_ProductoLookUpEdit.TabIndex = 1;
            this.id_ProductoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // frmProductosHistorialPrecios
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
            this.MinimumSize = new System.Drawing.Size(750, 226);
            this.Name = "frmProductosHistorialPrecios";
            this.Text = "Historial de Precios";
            this.Load += new System.EventHandler(this.frmProductosHistorialPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosHistorialPreciosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosHistorialPreciosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.BindingSource productosHistorialPreciosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource productosHistorialPreciosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit id_ProductoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit FiltroBusquedaLookUpEdit;
    }
}