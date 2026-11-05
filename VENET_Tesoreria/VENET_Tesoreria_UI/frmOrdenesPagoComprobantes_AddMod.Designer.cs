namespace VENET_Tesoreria_UI
{
    partial class frmOrdenesPagoComprobantes_AddMod
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ordenesPagoComprobantesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId_OrdenPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobantesCompras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteAdeudado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colOrdenPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesPagoComprobantesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.ordenesPagoComprobantesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(734, 412);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ordenesPagoComprobantesManager_SearchResultBindingSource
            // 
            this.ordenesPagoComprobantesManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.OrdenesPagoComprobantesManager.SearchResult);
            this.ordenesPagoComprobantesManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.ordenesPagoComprobantesManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado,
            this.colId_OrdenPago,
            this.colId_ComprobantesCompras,
            this.colTotalOP,
            this.colImporteAdeudado,
            this.colImportePago,
            this.colOrdenPago,
            this.colComprobante,
            this.colBorrado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colFecha,
            this.colImporte});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            this.colSeleccionado.Width = 73;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colId_OrdenPago
            // 
            this.colId_OrdenPago.FieldName = "Id_OrdenPago";
            this.colId_OrdenPago.Name = "colId_OrdenPago";
            this.colId_OrdenPago.OptionsColumn.AllowEdit = false;
            this.colId_OrdenPago.OptionsColumn.ReadOnly = true;
            // 
            // colId_ComprobantesCompras
            // 
            this.colId_ComprobantesCompras.FieldName = "Id_ComprobantesCompras";
            this.colId_ComprobantesCompras.Name = "colId_ComprobantesCompras";
            this.colId_ComprobantesCompras.OptionsColumn.AllowEdit = false;
            this.colId_ComprobantesCompras.OptionsColumn.ReadOnly = true;
            // 
            // colTotalOP
            // 
            this.colTotalOP.DisplayFormat.FormatString = "n";
            this.colTotalOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalOP.FieldName = "TotalOP";
            this.colTotalOP.Name = "colTotalOP";
            this.colTotalOP.OptionsColumn.AllowEdit = false;
            this.colTotalOP.OptionsColumn.ReadOnly = true;
            // 
            // colImporteAdeudado
            // 
            this.colImporteAdeudado.DisplayFormat.FormatString = "n";
            this.colImporteAdeudado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteAdeudado.FieldName = "ImporteAdeudado";
            this.colImporteAdeudado.Name = "colImporteAdeudado";
            this.colImporteAdeudado.OptionsColumn.AllowEdit = false;
            this.colImporteAdeudado.OptionsColumn.ReadOnly = true;
            this.colImporteAdeudado.Visible = true;
            this.colImporteAdeudado.VisibleIndex = 4;
            this.colImporteAdeudado.Width = 143;
            // 
            // colImportePago
            // 
            this.colImportePago.ColumnEdit = this.repositoryItemTextEdit1;
            this.colImportePago.DisplayFormat.FormatString = "n";
            this.colImportePago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportePago.FieldName = "ImportePago";
            this.colImportePago.Name = "colImportePago";
            this.colImportePago.Visible = true;
            this.colImportePago.VisibleIndex = 5;
            this.colImportePago.Width = 124;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colOrdenPago
            // 
            this.colOrdenPago.FieldName = "OrdenPago";
            this.colOrdenPago.Name = "colOrdenPago";
            this.colOrdenPago.OptionsColumn.AllowEdit = false;
            this.colOrdenPago.OptionsColumn.ReadOnly = true;
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.AllowEdit = false;
            this.colComprobante.OptionsColumn.ReadOnly = true;
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 2;
            this.colComprobante.Width = 169;
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
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "n";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 3;
            this.colImporte.Width = 140;
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
            this.btnAceptar,
            this.barSubItem1,
            this.btnResultado,
            this.barStaticItemFooter,
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 1;
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
            this.barStaticItemFooter.Id = 3;
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
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // frmOrdenesPagoComprobantes_AddMod
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
            this.MinimumSize = new System.Drawing.Size(262, 199);
            this.Name = "frmOrdenesPagoComprobantes_AddMod";
            this.Text = "Comprobantes Pendientes";
            this.Load += new System.EventHandler(this.frmOrdenesPagoComprobantes_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesPagoComprobantesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.BindingSource ordenesPagoComprobantesManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colId_OrdenPago;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobantesCompras;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalOP;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteAdeudado;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePago;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdenPago;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
    }
}