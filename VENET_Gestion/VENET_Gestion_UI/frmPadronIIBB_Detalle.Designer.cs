namespace VENET_Gestion_UI
{
    partial class frmPadronIIBB_Detalle
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.padronIIBB_DetalleManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_PadronIIBB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegimen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPublicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVigenciaDesde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVigenciaHasta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoContribuyente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltaBaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCambioAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlicuota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.padronIIBB_DetalleManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.padronIIBB_DetalleManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 412);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // padronIIBB_DetalleManager_SearchResultBindingSource
            // 
            this.padronIIBB_DetalleManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.PadronIIBB_DetalleManager.SearchResult);
            this.padronIIBB_DetalleManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.padronIIBB_DetalleManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_PadronIIBB,
            this.colRegimen,
            this.colFechaPublicacion,
            this.colVigenciaDesde,
            this.colVigenciaHasta,
            this.colCuit,
            this.colTipoContribuyente,
            this.colAltaBaja,
            this.colCambioAlicuota,
            this.colAlicuota,
            this.colNroGrupo,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colId_PadronIIBB
            // 
            this.colId_PadronIIBB.FieldName = "Id_PadronIIBB";
            this.colId_PadronIIBB.Name = "colId_PadronIIBB";
            // 
            // colRegimen
            // 
            this.colRegimen.FieldName = "Regimen";
            this.colRegimen.Name = "colRegimen";
            this.colRegimen.Visible = true;
            this.colRegimen.VisibleIndex = 0;
            // 
            // colFechaPublicacion
            // 
            this.colFechaPublicacion.FieldName = "FechaPublicacion";
            this.colFechaPublicacion.Name = "colFechaPublicacion";
            this.colFechaPublicacion.Visible = true;
            this.colFechaPublicacion.VisibleIndex = 1;
            // 
            // colVigenciaDesde
            // 
            this.colVigenciaDesde.FieldName = "VigenciaDesde";
            this.colVigenciaDesde.Name = "colVigenciaDesde";
            this.colVigenciaDesde.Visible = true;
            this.colVigenciaDesde.VisibleIndex = 2;
            // 
            // colVigenciaHasta
            // 
            this.colVigenciaHasta.FieldName = "VigenciaHasta";
            this.colVigenciaHasta.Name = "colVigenciaHasta";
            this.colVigenciaHasta.Visible = true;
            this.colVigenciaHasta.VisibleIndex = 3;
            // 
            // colCuit
            // 
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 4;
            // 
            // colTipoContribuyente
            // 
            this.colTipoContribuyente.FieldName = "TipoContribuyente";
            this.colTipoContribuyente.Name = "colTipoContribuyente";
            this.colTipoContribuyente.Visible = true;
            this.colTipoContribuyente.VisibleIndex = 5;
            // 
            // colAltaBaja
            // 
            this.colAltaBaja.FieldName = "AltaBaja";
            this.colAltaBaja.Name = "colAltaBaja";
            this.colAltaBaja.Visible = true;
            this.colAltaBaja.VisibleIndex = 6;
            // 
            // colCambioAlicuota
            // 
            this.colCambioAlicuota.FieldName = "CambioAlicuota";
            this.colCambioAlicuota.Name = "colCambioAlicuota";
            this.colCambioAlicuota.Visible = true;
            this.colCambioAlicuota.VisibleIndex = 7;
            // 
            // colAlicuota
            // 
            this.colAlicuota.FieldName = "Alicuota";
            this.colAlicuota.Name = "colAlicuota";
            this.colAlicuota.Visible = true;
            this.colAlicuota.VisibleIndex = 8;
            // 
            // colNroGrupo
            // 
            this.colNroGrupo.FieldName = "NroGrupo";
            this.colNroGrupo.Name = "colNroGrupo";
            this.colNroGrupo.Visible = true;
            this.colNroGrupo.VisibleIndex = 9;
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
            // frmPadronIIBB_Detalle
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
            this.MinimumSize = new System.Drawing.Size(419, 201);
            this.Name = "frmPadronIIBB_Detalle";
            this.Text = "Detalle del Padrón IIBB";
            this.Load += new System.EventHandler(this.frmPadronIIBB_Detalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.padronIIBB_DetalleManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource padronIIBB_DetalleManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_PadronIIBB;
        private DevExpress.XtraGrid.Columns.GridColumn colRegimen;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPublicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colVigenciaDesde;
        private DevExpress.XtraGrid.Columns.GridColumn colVigenciaHasta;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoContribuyente;
        private DevExpress.XtraGrid.Columns.GridColumn colAltaBaja;
        private DevExpress.XtraGrid.Columns.GridColumn colCambioAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colAlicuota;
        private DevExpress.XtraGrid.Columns.GridColumn colNroGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
    }
}