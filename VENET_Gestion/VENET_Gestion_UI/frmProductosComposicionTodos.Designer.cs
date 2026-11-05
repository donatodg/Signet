namespace VENET_Gestion_UI
{
    partial class frmProductosComposicionTodos
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
            System.Windows.Forms.Label id_ProductoLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.FiltroBusquedaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_ProductoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.productosComposicionTodosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosComposicionTodosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoProductoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoComposicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualizacionCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProductoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProductoComposicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            id_ProductoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosComposicionTodosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosComposicionTodosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ProductoLabel
            // 
            id_ProductoLabel.AutoSize = true;
            id_ProductoLabel.Location = new System.Drawing.Point(12, 11);
            id_ProductoLabel.Name = "id_ProductoLabel";
            id_ProductoLabel.Size = new System.Drawing.Size(54, 13);
            id_ProductoLabel.TabIndex = 30;
            id_ProductoLabel.Text = "Producto:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FiltroBusquedaLookUpEdit);
            this.panel1.Controls.Add(id_ProductoLabel);
            this.panel1.Controls.Add(this.id_ProductoLookUpEdit);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 36);
            this.panel1.TabIndex = 0;
            // 
            // FiltroBusquedaLookUpEdit
            // 
            this.FiltroBusquedaLookUpEdit.EnterMoveNextControl = true;
            this.FiltroBusquedaLookUpEdit.Location = new System.Drawing.Point(67, 8);
            this.FiltroBusquedaLookUpEdit.MenuManager = this.barManager1;
            this.FiltroBusquedaLookUpEdit.Name = "FiltroBusquedaLookUpEdit";
            this.FiltroBusquedaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FiltroBusquedaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name28")});
            this.FiltroBusquedaLookUpEdit.Properties.NullText = "";
            this.FiltroBusquedaLookUpEdit.Properties.ShowHeader = false;
            this.FiltroBusquedaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.FiltroBusquedaLookUpEdit.TabIndex = 32;
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
            this.btnResultado,
            this.barStaticItemFooter});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.btnResultado.Id = 1;
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
            this.barStaticItemFooter.Id = 2;
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
            // id_ProductoLookUpEdit
            // 
            this.id_ProductoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productosComposicionTodosManager_ParametrosBusquedasBindingSource, "Id_ProductoFinal", true));
            this.id_ProductoLookUpEdit.Location = new System.Drawing.Point(168, 8);
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
            this.id_ProductoLookUpEdit.TabIndex = 31;
            this.id_ProductoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // productosComposicionTodosManager_ParametrosBusquedasBindingSource
            // 
            this.productosComposicionTodosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosComposicionTodosManager.ParametrosBusquedas);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosComposicionTodosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 376);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosComposicionTodosManager_SearchResultBindingSource
            // 
            this.productosComposicionTodosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosComposicionTodosManager.SearchResult);
            this.productosComposicionTodosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.productosComposicionTodosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductoFinal,
            this.colCodigoProductoFinal,
            this.colProductoComposicion,
            this.colCodigoProducto,
            this.colCosto,
            this.colActualizacionCosto,
            this.colId_ProductoFinal,
            this.colId_ProductoComposicion,
            this.colCantidad,
            this.colObservaciones,
            this.colTotalCosto,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", this.colCantidad, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Costo", this.colCosto, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Costo", this.colTotalCosto, "{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProductoFinal, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colProductoFinal
            // 
            this.colProductoFinal.FieldName = "ProductoFinal";
            this.colProductoFinal.Name = "colProductoFinal";
            this.colProductoFinal.Visible = true;
            this.colProductoFinal.VisibleIndex = 0;
            // 
            // colCodigoProductoFinal
            // 
            this.colCodigoProductoFinal.Caption = "Código Producto Final";
            this.colCodigoProductoFinal.FieldName = "CodigoProductoFinal";
            this.colCodigoProductoFinal.Name = "colCodigoProductoFinal";
            this.colCodigoProductoFinal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CodigoProductoFinal", "{0}")});
            this.colCodigoProductoFinal.Visible = true;
            this.colCodigoProductoFinal.VisibleIndex = 0;
            // 
            // colProductoComposicion
            // 
            this.colProductoComposicion.FieldName = "ProductoComposicion";
            this.colProductoComposicion.Name = "colProductoComposicion";
            this.colProductoComposicion.Visible = true;
            this.colProductoComposicion.VisibleIndex = 1;
            // 
            // colCodigoProducto
            // 
            this.colCodigoProducto.Caption = "Código Producto";
            this.colCodigoProducto.FieldName = "CodigoProducto";
            this.colCodigoProducto.Name = "colCodigoProducto";
            this.colCodigoProducto.Visible = true;
            this.colCodigoProducto.VisibleIndex = 2;
            // 
            // colCosto
            // 
            this.colCosto.DisplayFormat.FormatString = "n2";
            this.colCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.FieldName = "Costo";
            this.colCosto.Name = "colCosto";
            this.colCosto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Costo", "{0:n2}")});
            this.colCosto.Visible = true;
            this.colCosto.VisibleIndex = 4;
            // 
            // colActualizacionCosto
            // 
            this.colActualizacionCosto.Caption = "Actualización Costo";
            this.colActualizacionCosto.FieldName = "ActualizacionCosto";
            this.colActualizacionCosto.Name = "colActualizacionCosto";
            this.colActualizacionCosto.Visible = true;
            this.colActualizacionCosto.VisibleIndex = 5;
            // 
            // colId_ProductoFinal
            // 
            this.colId_ProductoFinal.FieldName = "Id_ProductoFinal";
            this.colId_ProductoFinal.Name = "colId_ProductoFinal";
            // 
            // colId_ProductoComposicion
            // 
            this.colId_ProductoComposicion.FieldName = "Id_ProductoComposicion";
            this.colId_ProductoComposicion.Name = "colId_ProductoComposicion";
            // 
            // colCantidad
            // 
            this.colCantidad.DisplayFormat.FormatString = "n2";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:n2}")});
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 3;
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // colTotalCosto
            // 
            this.colTotalCosto.DisplayFormat.FormatString = "n2";
            this.colTotalCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalCosto.FieldName = "Total_Costo";
            this.colTotalCosto.Name = "colTotalCosto";
            this.colTotalCosto.OptionsColumn.ReadOnly = true;
            this.colTotalCosto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Costo", "{0:n2}")});
            this.colTotalCosto.Visible = true;
            this.colTotalCosto.VisibleIndex = 6;
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
            // frmProductosComposicionTodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmProductosComposicionTodos";
            this.Text = "Composición de Productos";
            this.Load += new System.EventHandler(this.frmProductosComposicionTodos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroBusquedaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProductoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosComposicionTodosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosComposicionTodosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.BindingSource productosComposicionTodosManager_ParametrosBusquedasBindingSource;
        private System.Windows.Forms.BindingSource productosComposicionTodosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoProductoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoComposicion;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colActualizacionCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProductoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProductoComposicion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.LookUpEdit FiltroBusquedaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_ProductoLookUpEdit;
    }
}