namespace VENET_Produccion_UI
{
    partial class frmProduccionListaPreciosDetalle
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
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnActualizarUtilidad = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnListaPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.produccionListaPreciosDetalleManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_Linea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ListaPrecios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Variante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Medida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostoComposicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostoTareas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAjuste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosDetalleManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.btnListaPrecios,
            this.barSubItem2,
            this.btnActualizarUtilidad});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Produccion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Produccion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Produccion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
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
            this.barSubItem2.Glyph = global::VENET_Produccion_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizarUtilidad)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnActualizarUtilidad
            // 
            this.btnActualizarUtilidad.Caption = "Actualizar Utilidad por Variante";
            this.btnActualizarUtilidad.Id = 7;
            this.btnActualizarUtilidad.Name = "btnActualizarUtilidad";
            this.btnActualizarUtilidad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizarUtilidad_ItemClick);
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
            // btnListaPrecios
            // 
            this.btnListaPrecios.Caption = "Lista de Precios";
            this.btnListaPrecios.Id = 5;
            this.btnListaPrecios.Name = "btnListaPrecios";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.produccionListaPreciosDetalleManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 412);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // produccionListaPreciosDetalleManager_SearchResultBindingSource
            // 
            this.produccionListaPreciosDetalleManager_SearchResultBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionListaPreciosDetalleManager.SearchResult);
            this.produccionListaPreciosDetalleManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.produccionListaPreciosDetalleManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_Linea,
            this.colLinea,
            this.colVariante,
            this.colMedida,
            this.colProducto,
            this.colCodigo,
            this.colId_ListaPrecios,
            this.colId_Variante,
            this.colId_Medida,
            this.colCostoComposicion,
            this.colCostoTareas,
            this.colUtilidad,
            this.colAjuste,
            this.colTotal,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colId_Linea
            // 
            this.colId_Linea.FieldName = "Id_Linea";
            this.colId_Linea.Name = "colId_Linea";
            // 
            // colLinea
            // 
            this.colLinea.Caption = "Línea";
            this.colLinea.FieldName = "Linea";
            this.colLinea.Name = "colLinea";
            // 
            // colVariante
            // 
            this.colVariante.FieldName = "Variante";
            this.colVariante.Name = "colVariante";
            // 
            // colMedida
            // 
            this.colMedida.FieldName = "Medida";
            this.colMedida.Name = "colMedida";
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 1;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colId_ListaPrecios
            // 
            this.colId_ListaPrecios.FieldName = "Id_ListaPrecios";
            this.colId_ListaPrecios.Name = "colId_ListaPrecios";
            // 
            // colId_Variante
            // 
            this.colId_Variante.FieldName = "Id_Variante";
            this.colId_Variante.Name = "colId_Variante";
            // 
            // colId_Medida
            // 
            this.colId_Medida.FieldName = "Id_Medida";
            this.colId_Medida.Name = "colId_Medida";
            // 
            // colCostoComposicion
            // 
            this.colCostoComposicion.Caption = "Costo Composición";
            this.colCostoComposicion.DisplayFormat.FormatString = "n2";
            this.colCostoComposicion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostoComposicion.FieldName = "CostoComposicion";
            this.colCostoComposicion.Name = "colCostoComposicion";
            this.colCostoComposicion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostoComposicion", "{0:N2}")});
            this.colCostoComposicion.Visible = true;
            this.colCostoComposicion.VisibleIndex = 2;
            // 
            // colCostoTareas
            // 
            this.colCostoTareas.DisplayFormat.FormatString = "n2";
            this.colCostoTareas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostoTareas.FieldName = "CostoTareas";
            this.colCostoTareas.Name = "colCostoTareas";
            this.colCostoTareas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostoTareas", "{0:N2}")});
            this.colCostoTareas.Visible = true;
            this.colCostoTareas.VisibleIndex = 3;
            // 
            // colUtilidad
            // 
            this.colUtilidad.DisplayFormat.FormatString = "n2";
            this.colUtilidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUtilidad.FieldName = "Utilidad";
            this.colUtilidad.Name = "colUtilidad";
            this.colUtilidad.Visible = true;
            this.colUtilidad.VisibleIndex = 4;
            // 
            // colAjuste
            // 
            this.colAjuste.DisplayFormat.FormatString = "n2";
            this.colAjuste.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAjuste.FieldName = "Ajuste";
            this.colAjuste.Name = "colAjuste";
            this.colAjuste.Visible = true;
            this.colAjuste.VisibleIndex = 5;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 6;
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
            // frmProduccionListaPreciosDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(510, 242);
            this.Name = "frmProduccionListaPreciosDetalle";
            this.Text = "Detalle de Lista de Precios";
            this.Load += new System.EventHandler(this.ProduccionListaPreciosDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosDetalleManager_SearchResultBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnListaPrecios;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource produccionListaPreciosDetalleManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Linea;
        private DevExpress.XtraGrid.Columns.GridColumn colLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colVariante;
        private DevExpress.XtraGrid.Columns.GridColumn colMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ListaPrecios;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Variante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Medida;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoComposicion;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoTareas;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilidad;
        private DevExpress.XtraGrid.Columns.GridColumn colAjuste;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnActualizarUtilidad;
    }
}