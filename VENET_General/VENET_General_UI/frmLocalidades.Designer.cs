namespace VENET_General_UI
{
    partial class frmLocalidades
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
            System.Windows.Forms.Label codPosLabel;
            System.Windows.Forms.Label localidadLabel;
            System.Windows.Forms.Label id_ProvinciaLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.localidadesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Provincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodPostal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_ProvinciaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.localidadesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
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
            this.localidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codPosTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            codPosLabel = new System.Windows.Forms.Label();
            localidadLabel = new System.Windows.Forms.Label();
            id_ProvinciaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPosTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // codPosLabel
            // 
            codPosLabel.AutoSize = true;
            codPosLabel.Location = new System.Drawing.Point(13, 11);
            codPosLabel.Name = "codPosLabel";
            codPosLabel.Size = new System.Drawing.Size(62, 13);
            codPosLabel.TabIndex = 1;
            codPosLabel.Text = "Cod Postal:";
            // 
            // localidadLabel
            // 
            localidadLabel.AutoSize = true;
            localidadLabel.Location = new System.Drawing.Point(189, 11);
            localidadLabel.Name = "localidadLabel";
            localidadLabel.Size = new System.Drawing.Size(55, 13);
            localidadLabel.TabIndex = 3;
            localidadLabel.Text = "Localidad:";
            // 
            // id_ProvinciaLabel
            // 
            id_ProvinciaLabel.AutoSize = true;
            id_ProvinciaLabel.Location = new System.Drawing.Point(400, 11);
            id_ProvinciaLabel.Name = "id_ProvinciaLabel";
            id_ProvinciaLabel.Size = new System.Drawing.Size(54, 13);
            id_ProvinciaLabel.TabIndex = 5;
            id_ProvinciaLabel.Text = "Provincia:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.localidadesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 377);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // localidadesManager_SearchResultBindingSource
            // 
            this.localidadesManager_SearchResultBindingSource.DataSource = typeof(VENET_General_BL.LocalidadesManager.SearchResult);
            this.localidadesManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.localidadesManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProvincia,
            this.colId_Provincia,
            this.colLocalidad,
            this.colCodPostal,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colClearing});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colProvincia
            // 
            this.colProvincia.FieldName = "Provincia";
            this.colProvincia.Name = "colProvincia";
            this.colProvincia.OptionsColumn.AllowEdit = false;
            this.colProvincia.OptionsColumn.ReadOnly = true;
            this.colProvincia.Visible = true;
            this.colProvincia.VisibleIndex = 3;
            this.colProvincia.Width = 240;
            // 
            // colId_Provincia
            // 
            this.colId_Provincia.FieldName = "Id_Provincia";
            this.colId_Provincia.Name = "colId_Provincia";
            this.colId_Provincia.OptionsColumn.AllowEdit = false;
            this.colId_Provincia.OptionsColumn.ReadOnly = true;
            this.colId_Provincia.Width = 227;
            // 
            // colLocalidad
            // 
            this.colLocalidad.FieldName = "Localidad";
            this.colLocalidad.Name = "colLocalidad";
            this.colLocalidad.OptionsColumn.AllowEdit = false;
            this.colLocalidad.OptionsColumn.ReadOnly = true;
            this.colLocalidad.Visible = true;
            this.colLocalidad.VisibleIndex = 2;
            this.colLocalidad.Width = 409;
            // 
            // colCodPostal
            // 
            this.colCodPostal.FieldName = "CodPostal";
            this.colCodPostal.Name = "colCodPostal";
            this.colCodPostal.OptionsColumn.AllowEdit = false;
            this.colCodPostal.OptionsColumn.ReadOnly = true;
            this.colCodPostal.Visible = true;
            this.colCodPostal.VisibleIndex = 1;
            this.colCodPostal.Width = 125;
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
            this.colId.Width = 82;
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
            // colClearing
            // 
            this.colClearing.Caption = "Clearing";
            this.colClearing.FieldName = "Clearing";
            this.colClearing.Name = "colClearing";
            this.colClearing.OptionsColumn.AllowEdit = false;
            this.colClearing.OptionsColumn.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_ProvinciaLabel);
            this.panelControl1.Controls.Add(this.id_ProvinciaLookUpEdit);
            this.panelControl1.Controls.Add(localidadLabel);
            this.panelControl1.Controls.Add(this.localidadTextEdit);
            this.panelControl1.Controls.Add(codPosLabel);
            this.panelControl1.Controls.Add(this.codPosTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 35);
            this.panelControl1.TabIndex = 1;
            // 
            // id_ProvinciaLookUpEdit
            // 
            this.id_ProvinciaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManager_ParametrosBusquedasBindingSource, "Id_Provincia", true));
            this.id_ProvinciaLookUpEdit.EnterMoveNextControl = true;
            this.id_ProvinciaLookUpEdit.Location = new System.Drawing.Point(460, 8);
            this.id_ProvinciaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvinciaLookUpEdit.Name = "id_ProvinciaLookUpEdit";
            this.id_ProvinciaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ProvinciaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre13")});
            this.id_ProvinciaLookUpEdit.Properties.NullText = "";
            this.id_ProvinciaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvinciaLookUpEdit.Size = new System.Drawing.Size(139, 20);
            this.id_ProvinciaLookUpEdit.TabIndex = 6;
            this.id_ProvinciaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // localidadesManager_ParametrosBusquedasBindingSource
            // 
            this.localidadesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_General_BL.LocalidadesManager.ParametrosBusquedas);
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
            this.barStaticItemFooter});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
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
            this.btnAgregar.Glyph = global::VENET_General_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_General_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_General_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_General_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la búsqueda";
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
            // localidadTextEdit
            // 
            this.localidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManager_ParametrosBusquedasBindingSource, "Localidad", true));
            this.localidadTextEdit.EnterMoveNextControl = true;
            this.localidadTextEdit.Location = new System.Drawing.Point(251, 8);
            this.localidadTextEdit.MenuManager = this.barManager1;
            this.localidadTextEdit.Name = "localidadTextEdit";
            this.localidadTextEdit.Size = new System.Drawing.Size(138, 20);
            this.localidadTextEdit.TabIndex = 4;
            this.localidadTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // codPosTextEdit
            // 
            this.codPosTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManager_ParametrosBusquedasBindingSource, "CodPos", true));
            this.codPosTextEdit.EnterMoveNextControl = true;
            this.codPosTextEdit.Location = new System.Drawing.Point(80, 8);
            this.codPosTextEdit.MenuManager = this.barManager1;
            this.codPosTextEdit.Name = "codPosTextEdit";
            this.codPosTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codPosTextEdit.TabIndex = 2;
            this.codPosTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
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
            // frmLocalidades
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
            this.MinimumSize = new System.Drawing.Size(714, 234);
            this.Name = "frmLocalidades";
            this.Text = "Localidades";
            this.Load += new System.EventHandler(this.frmLocalidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPosTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource localidadesManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Provincia;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPostal;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit id_ProvinciaLookUpEdit;
        private System.Windows.Forms.BindingSource localidadesManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit localidadTextEdit;
        private DevExpress.XtraEditors.TextEdit codPosTextEdit;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn colClearing;
    }
}