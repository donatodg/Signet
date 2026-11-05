namespace VENET_ProvFinancieros_UI
{
    partial class frmProvFinancieros
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
            System.Windows.Forms.Label nombreLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ProvFinancierosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodPostal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CodPostal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ProvFinancierosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnCuentas = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmpresasAsignadas = new DevExpress.XtraBars.BarButtonItem();
            this.btnUNAsignadas = new DevExpress.XtraBars.BarButtonItem();
            this.btnImpuestos = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvFinancierosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvFinancierosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(11, 11);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 4;
            idLabel.Text = "Id:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(145, 11);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 5;
            nombreLabel.Text = "Nombre:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.ProvFinancierosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 58);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 378);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // ProvFinancierosManager_SearchResultBindingSource
            // 
            this.ProvFinancierosManager_SearchResultBindingSource.DataSource = typeof(VENET_ProvFinancieros_BL.ProvFinancierosManager.SearchResult);
            this.ProvFinancierosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.ProvFinancierosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodPostal,
            this.colLocalidad,
            this.colTipoIva,
            this.colNombre,
            this.colDomicilio,
            this.colId_CodPostal,
            this.colCuit,
            this.colId_TipoIva,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colEmail});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colCodPostal
            // 
            this.colCodPostal.FieldName = "CodPostal";
            this.colCodPostal.Name = "colCodPostal";
            // 
            // colLocalidad
            // 
            this.colLocalidad.FieldName = "Localidad";
            this.colLocalidad.Name = "colLocalidad";
            this.colLocalidad.Visible = true;
            this.colLocalidad.VisibleIndex = 3;
            this.colLocalidad.Width = 132;
            // 
            // colTipoIva
            // 
            this.colTipoIva.FieldName = "TipoIva";
            this.colTipoIva.Name = "colTipoIva";
            this.colTipoIva.Visible = true;
            this.colTipoIva.VisibleIndex = 4;
            this.colTipoIva.Width = 102;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            this.colNombre.Width = 167;
            // 
            // colDomicilio
            // 
            this.colDomicilio.FieldName = "Domicilio";
            this.colDomicilio.Name = "colDomicilio";
            this.colDomicilio.Visible = true;
            this.colDomicilio.VisibleIndex = 2;
            this.colDomicilio.Width = 138;
            // 
            // colId_CodPostal
            // 
            this.colId_CodPostal.FieldName = "Id_CodPostal";
            this.colId_CodPostal.Name = "colId_CodPostal";
            // 
            // colCuit
            // 
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 5;
            this.colCuit.Width = 92;
            // 
            // colId_TipoIva
            // 
            this.colId_TipoIva.FieldName = "Id_TipoIva";
            this.colId_TipoIva.Name = "colId_TipoIva";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 62;
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
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(nombreLabel);
            this.panelControl1.Controls.Add(this.nombreTextEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 34);
            this.panelControl1.TabIndex = 1;
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProvFinancierosManager_ParametrosBusquedasBindingSource, "Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(198, 8);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(174, 20);
            this.nombreTextEdit.TabIndex = 6;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // ProvFinancierosManager_ParametrosBusquedasBindingSource
            // 
            this.ProvFinancierosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_ProvFinancieros_BL.ProvFinancierosManager.ParametrosBusquedas);
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
            this.btnCuentas,
            this.btnEmpresasAsignadas,
            this.btnImpuestos,
            this.btnUNAsignadas});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(650, 320);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_ProvFinancieros_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_ProvFinancieros_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_ProvFinancieros_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_ProvFinancieros_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_ProvFinancieros_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCuentas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEmpresasAsignadas, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUNAsignadas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImpuestos, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnCuentas
            // 
            this.btnCuentas.Caption = "Cuentas";
            this.btnCuentas.Id = 7;
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCuentas_ItemClick);
            // 
            // btnEmpresasAsignadas
            // 
            this.btnEmpresasAsignadas.Caption = "Empresas Asignadas";
            this.btnEmpresasAsignadas.Id = 8;
            this.btnEmpresasAsignadas.Name = "btnEmpresasAsignadas";
            this.btnEmpresasAsignadas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmpresasAsignadas_ItemClick);
            // 
            // btnUNAsignadas
            // 
            this.btnUNAsignadas.Caption = "Unidades Negocios Asignadas";
            this.btnUNAsignadas.Id = 10;
            this.btnUNAsignadas.Name = "btnUNAsignadas";
            this.btnUNAsignadas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUNAsignadas_ItemClick);
            // 
            // btnImpuestos
            // 
            this.btnImpuestos.Caption = "Impuestos";
            this.btnImpuestos.Id = 9;
            this.btnImpuestos.Name = "btnImpuestos";
            this.btnImpuestos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImpuestos_ItemClick);
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
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProvFinancierosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(36, 8);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 5;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmProvFinancieros
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
            this.MinimumSize = new System.Drawing.Size(486, 219);
            this.Name = "frmProvFinancieros";
            this.Text = "Proveedores Financieros";
            this.Load += new System.EventHandler(this.frmProvFinancieros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvFinancierosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvFinancierosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource ProvFinancierosManager_SearchResultBindingSource;
        private System.Windows.Forms.BindingSource ProvFinancierosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnCuentas;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPostal;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidad;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoIva;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CodPostal;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoIva;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarButtonItem btnEmpresasAsignadas;
        private DevExpress.XtraBars.BarButtonItem btnImpuestos;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraBars.BarButtonItem btnUNAsignadas;
    }
}