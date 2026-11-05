namespace VENET_Gestion_UI
{
    partial class frmComprobantesVentasDetalleMultiple_Add
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobanteVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Especie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ProductoCompuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colImporteUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colImporteUnitarioDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteUnitarioConIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteConDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_AlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlicuotaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteIVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteSinIVa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.btnAceptar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
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
            this.btnAceptar.Id = 1;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 412);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.gridControl1.Size = new System.Drawing.Size(730, 408);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // comprobantesVentasDetalleMultipleManager_SearchResultBindingSource
            // 
            this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.ComprobantesVentasDetalleMultipleManager.SearchResult);
            this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLinea,
            this.colVariante,
            this.colMedida,
            this.colCodigo,
            this.colId_ComprobanteVenta,
            this.colId_Especie,
            this.colCotizacion,
            this.colId_Producto,
            this.colId_ProductoCompuesto,
            this.colDescripcion,
            this.colCantidad,
            this.colImporteUnitario,
            this.colPorcDescuento,
            this.colImporteUnitarioDescuento,
            this.colImporteUnitarioConIva,
            this.colImporteConDescuento,
            this.colId_AlicuotaIva,
            this.colAlicuotaIva,
            this.colImporteIVA,
            this.colImporte,
            this.colComprobanteVenta,
            this.colEspecie,
            this.colImporteSinIVa,
            this.colBorrado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel,
            this.colSeleccionado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            // 
            // colLinea
            // 
            this.colLinea.Caption = "Línea";
            this.colLinea.FieldName = "Linea";
            this.colLinea.Name = "colLinea";
            this.colLinea.OptionsColumn.AllowEdit = false;
            this.colLinea.OptionsColumn.ReadOnly = true;
            this.colLinea.Visible = true;
            this.colLinea.VisibleIndex = 1;
            // 
            // colVariante
            // 
            this.colVariante.FieldName = "Variante";
            this.colVariante.Name = "colVariante";
            this.colVariante.OptionsColumn.AllowEdit = false;
            this.colVariante.OptionsColumn.ReadOnly = true;
            this.colVariante.Visible = true;
            this.colVariante.VisibleIndex = 2;
            // 
            // colMedida
            // 
            this.colMedida.FieldName = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.OptionsColumn.AllowEdit = false;
            this.colMedida.OptionsColumn.ReadOnly = true;
            this.colMedida.Visible = true;
            this.colMedida.VisibleIndex = 3;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.AllowEdit = false;
            this.colCodigo.OptionsColumn.ReadOnly = true;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 4;
            // 
            // colId_ComprobanteVenta
            // 
            this.colId_ComprobanteVenta.FieldName = "Id_ComprobanteVenta";
            this.colId_ComprobanteVenta.Name = "colId_ComprobanteVenta";
            this.colId_ComprobanteVenta.OptionsColumn.AllowEdit = false;
            this.colId_ComprobanteVenta.OptionsColumn.ReadOnly = true;
            // 
            // colId_Especie
            // 
            this.colId_Especie.FieldName = "Id_Especie";
            this.colId_Especie.Name = "colId_Especie";
            this.colId_Especie.OptionsColumn.AllowEdit = false;
            this.colId_Especie.OptionsColumn.ReadOnly = true;
            // 
            // colCotizacion
            // 
            this.colCotizacion.Caption = "Cotización";
            this.colCotizacion.DisplayFormat.FormatString = "#,##0.00";
            this.colCotizacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCotizacion.FieldName = "Cotizacion";
            this.colCotizacion.Name = "colCotizacion";
            this.colCotizacion.OptionsColumn.AllowEdit = false;
            this.colCotizacion.OptionsColumn.ReadOnly = true;
            // 
            // colId_Producto
            // 
            this.colId_Producto.FieldName = "Id_Producto";
            this.colId_Producto.Name = "colId_Producto";
            this.colId_Producto.OptionsColumn.AllowEdit = false;
            this.colId_Producto.OptionsColumn.ReadOnly = true;
            // 
            // colId_ProductoCompuesto
            // 
            this.colId_ProductoCompuesto.FieldName = "Id_ProductoCompuesto";
            this.colId_ProductoCompuesto.Name = "colId_ProductoCompuesto";
            this.colId_ProductoCompuesto.OptionsColumn.AllowEdit = false;
            this.colId_ProductoCompuesto.OptionsColumn.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 6;
            // 
            // colCantidad
            // 
            this.colCantidad.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colCantidad.DisplayFormat.FormatString = "#,##0.00";
            this.colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Cantidad", "", "Cantidad")});
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 5;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "#,##0.00";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "#,##0.00";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Mask.EditMask = "n2";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            this.repositoryItemSpinEdit1.Leave += new System.EventHandler(this.repositoryItemSpinEdit1_Leave);
            // 
            // colImporteUnitario
            // 
            this.colImporteUnitario.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitario.FieldName = "ImporteUnitario";
            this.colImporteUnitario.Name = "colImporteUnitario";
            this.colImporteUnitario.OptionsColumn.AllowEdit = false;
            this.colImporteUnitario.OptionsColumn.ReadOnly = true;
            this.colImporteUnitario.Visible = true;
            this.colImporteUnitario.VisibleIndex = 7;
            // 
            // colPorcDescuento
            // 
            this.colPorcDescuento.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colPorcDescuento.DisplayFormat.FormatString = "#,##0.00";
            this.colPorcDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPorcDescuento.FieldName = "PorcDescuento";
            this.colPorcDescuento.Name = "colPorcDescuento";
            this.colPorcDescuento.Visible = true;
            this.colPorcDescuento.VisibleIndex = 8;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.DisplayFormat.FormatString = "#,##0.00";
            this.repositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.EditFormat.FormatString = "#,##0.00";
            this.repositoryItemSpinEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.Mask.EditMask = "n2";
            this.repositoryItemSpinEdit2.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.repositoryItemSpinEdit2.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            this.repositoryItemSpinEdit2.Leave += new System.EventHandler(this.repositoryItemSpinEdit2_Leave);
            // 
            // colImporteUnitarioDescuento
            // 
            this.colImporteUnitarioDescuento.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitarioDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitarioDescuento.FieldName = "ImporteUnitarioDescuento";
            this.colImporteUnitarioDescuento.Name = "colImporteUnitarioDescuento";
            this.colImporteUnitarioDescuento.OptionsColumn.AllowEdit = false;
            this.colImporteUnitarioDescuento.OptionsColumn.ReadOnly = true;
            // 
            // colImporteUnitarioConIva
            // 
            this.colImporteUnitarioConIva.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteUnitarioConIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteUnitarioConIva.FieldName = "ImporteUnitarioConIva";
            this.colImporteUnitarioConIva.Name = "colImporteUnitarioConIva";
            this.colImporteUnitarioConIva.OptionsColumn.AllowEdit = false;
            this.colImporteUnitarioConIva.OptionsColumn.ReadOnly = true;
            // 
            // colImporteConDescuento
            // 
            this.colImporteConDescuento.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteConDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteConDescuento.FieldName = "ImporteConDescuento";
            this.colImporteConDescuento.Name = "colImporteConDescuento";
            this.colImporteConDescuento.OptionsColumn.AllowEdit = false;
            this.colImporteConDescuento.OptionsColumn.ReadOnly = true;
            this.colImporteConDescuento.Visible = true;
            this.colImporteConDescuento.VisibleIndex = 9;
            // 
            // colId_AlicuotaIva
            // 
            this.colId_AlicuotaIva.FieldName = "Id_AlicuotaIva";
            this.colId_AlicuotaIva.Name = "colId_AlicuotaIva";
            this.colId_AlicuotaIva.OptionsColumn.AllowEdit = false;
            this.colId_AlicuotaIva.OptionsColumn.ReadOnly = true;
            // 
            // colAlicuotaIva
            // 
            this.colAlicuotaIva.Caption = "Alícuota Iva";
            this.colAlicuotaIva.FieldName = "AlicuotaIva";
            this.colAlicuotaIva.Name = "colAlicuotaIva";
            this.colAlicuotaIva.OptionsColumn.AllowEdit = false;
            this.colAlicuotaIva.OptionsColumn.ReadOnly = true;
            this.colAlicuotaIva.Visible = true;
            this.colAlicuotaIva.VisibleIndex = 10;
            // 
            // colImporteIVA
            // 
            this.colImporteIVA.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteIVA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteIVA.FieldName = "ImporteIVA";
            this.colImporteIVA.Name = "colImporteIVA";
            this.colImporteIVA.OptionsColumn.AllowEdit = false;
            this.colImporteIVA.OptionsColumn.ReadOnly = true;
            this.colImporteIVA.Visible = true;
            this.colImporteIVA.VisibleIndex = 11;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Importe", "{0:n2}", "Importe")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 12;
            // 
            // colComprobanteVenta
            // 
            this.colComprobanteVenta.FieldName = "ComprobanteVenta";
            this.colComprobanteVenta.Name = "colComprobanteVenta";
            this.colComprobanteVenta.OptionsColumn.AllowEdit = false;
            this.colComprobanteVenta.OptionsColumn.ReadOnly = true;
            // 
            // colEspecie
            // 
            this.colEspecie.FieldName = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.OptionsColumn.AllowEdit = false;
            this.colEspecie.OptionsColumn.ReadOnly = true;
            // 
            // colImporteSinIVa
            // 
            this.colImporteSinIVa.DisplayFormat.FormatString = "#,##0.00";
            this.colImporteSinIVa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteSinIVa.FieldName = "ImporteSinIVa";
            this.colImporteSinIVa.Name = "colImporteSinIVa";
            this.colImporteSinIVa.OptionsColumn.AllowEdit = false;
            this.colImporteSinIVa.OptionsColumn.ReadOnly = true;
            // 
            // colBorrado
            // 
            this.colBorrado.FieldName = "Borrado";
            this.colBorrado.Name = "colBorrado";
            this.colBorrado.OptionsColumn.AllowEdit = false;
            this.colBorrado.OptionsColumn.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
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
            // colFechaDel
            // 
            this.colFechaDel.FieldName = "FechaDel";
            this.colFechaDel.Name = "colFechaDel";
            this.colFechaDel.OptionsColumn.AllowEdit = false;
            this.colFechaDel.OptionsColumn.ReadOnly = true;
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
            // colUserDel
            // 
            this.colUserDel.FieldName = "UserDel";
            this.colUserDel.Name = "colUserDel";
            this.colUserDel.OptionsColumn.AllowEdit = false;
            this.colUserDel.OptionsColumn.ReadOnly = true;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.Caption = "Seleccionado";
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            // 
            // frmComprobantesVentasDetalleMultiple_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(385, 260);
            this.Name = "frmComprobantesVentasDetalleMultiple_Add";
            this.Text = "Asignación masiva de productos";
            this.Load += new System.EventHandler(this.frmComprobantesVentasDetalleMultiple_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprobantesVentasDetalleMultipleManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource comprobantesVentasDetalleMultipleManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colVariante;
        private DevExpress.XtraGrid.Columns.GridColumn colMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Especie;
        private DevExpress.XtraGrid.Columns.GridColumn colCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Producto;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ProductoCompuesto;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitarioDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteUnitarioConIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteConDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_AlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuotaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteIVA;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecie;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteSinIVa;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
    }
}