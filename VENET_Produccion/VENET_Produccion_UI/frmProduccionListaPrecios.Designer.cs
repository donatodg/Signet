namespace VENET_Produccion_UI
{
    partial class frmProduccionListaPrecios
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label añoDesdeLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnListaPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnGenerarExcelPrecios = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaUtilidad = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaProductos = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnDetalle = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.produccionListaPreciosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.añoDesdeTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.produccionListaPreciosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVigente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVigenteDesde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVigenteHasta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUtilidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnUso = new DevExpress.XtraGrid.Columns.GridColumn();
            descripcionLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            añoDesdeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoDesdeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(208, 9);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 2;
            descripcionLabel.Text = "Descripción:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(12, 9);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 3;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // añoDesdeLabel
            // 
            añoDesdeLabel.AutoSize = true;
            añoDesdeLabel.Location = new System.Drawing.Point(385, 9);
            añoDesdeLabel.Name = "añoDesdeLabel";
            añoDesdeLabel.Size = new System.Drawing.Size(63, 13);
            añoDesdeLabel.TabIndex = 5;
            añoDesdeLabel.Text = "Año Desde:";
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
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.barSubItem2,
            this.btnDetalle,
            this.btnResultado,
            this.btnListaPrecios,
            this.barSubItem3,
            this.btnGenerarExcelPrecios,
            this.btnActualizaUtilidad,
            this.barButtonItem1,
            this.btnActualizaProductos});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Produccion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 2;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Produccion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 3;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Produccion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 4;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Produccion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 5;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnListaPrecios, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnListaPrecios
            // 
            this.btnListaPrecios.Caption = "Lista de Precios";
            this.btnListaPrecios.Id = 9;
            this.btnListaPrecios.Name = "btnListaPrecios";
            this.btnListaPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListaPrecios_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 8;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Operaciones";
            this.barSubItem3.Glyph = global::VENET_Produccion_UI.Properties.Resources.properties_16x16;
            this.barSubItem3.Id = 10;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarExcelPrecios),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaUtilidad, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaProductos, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnGenerarExcelPrecios
            // 
            this.btnGenerarExcelPrecios.Caption = "Generar Excel de Precios";
            this.btnGenerarExcelPrecios.Id = 11;
            this.btnGenerarExcelPrecios.Name = "btnGenerarExcelPrecios";
            this.btnGenerarExcelPrecios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerarExcelPrecios_ItemClick);
            // 
            // btnActualizaUtilidad
            // 
            this.btnActualizaUtilidad.Caption = "Actualizar Utilidad Por Variante";
            this.btnActualizaUtilidad.Id = 12;
            this.btnActualizaUtilidad.Name = "btnActualizaUtilidad";
            this.btnActualizaUtilidad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaUtilidad_ItemClick);
            // 
            // btnActualizaProductos
            // 
            this.btnActualizaProductos.Caption = "Actualizar Precios de Productos";
            this.btnActualizaProductos.Id = 14;
            this.btnActualizaProductos.Name = "btnActualizaProductos";
            this.btnActualizaProductos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaProductos_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Produccion_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetalle)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Caption = "Detalle";
            this.btnDetalle.Id = 7;
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetalle_ItemClick);
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(añoDesdeLabel);
            this.panelControl1.Controls.Add(id_EmpresaLabel);
            this.panelControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(descripcionLabel);
            this.panelControl1.Controls.Add(this.descripcionTextEdit);
            this.panelControl1.Controls.Add(this.añoDesdeTextEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManager_ParametrosBusquedasBindingSource, "Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(70, 6);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name7")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(132, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // produccionListaPreciosManager_ParametrosBusquedasBindingSource
            // 
            this.produccionListaPreciosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionListaPreciosManager.ParametrosBusquedas);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManager_ParametrosBusquedasBindingSource, "Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(279, 6);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionTextEdit.TabIndex = 1;
            // 
            // añoDesdeTextEdit
            // 
            this.añoDesdeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionListaPreciosManager_ParametrosBusquedasBindingSource, "AñoDesde", true));
            this.añoDesdeTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.añoDesdeTextEdit.Location = new System.Drawing.Point(454, 6);
            this.añoDesdeTextEdit.MenuManager = this.barManager1;
            this.añoDesdeTextEdit.Name = "añoDesdeTextEdit";
            this.añoDesdeTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.añoDesdeTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.añoDesdeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.añoDesdeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.añoDesdeTextEdit.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.produccionListaPreciosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 380);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // produccionListaPreciosManager_SearchResultBindingSource
            // 
            this.produccionListaPreciosManager_SearchResultBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionListaPreciosManager.SearchResult);
            this.produccionListaPreciosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.produccionListaPreciosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVigente,
            this.colDescripcion,
            this.colVigenteDesde,
            this.colVigenteHasta,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colEmpresa,
            this.colId_Empresa,
            this.colUtilidad,
            this.colEnUso});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[Vigente] = True";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colVigente
            // 
            this.colVigente.FieldName = "Vigente";
            this.colVigente.Name = "colVigente";
            this.colVigente.OptionsColumn.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 179;
            // 
            // colVigenteDesde
            // 
            this.colVigenteDesde.FieldName = "VigenteDesde";
            this.colVigenteDesde.Name = "colVigenteDesde";
            this.colVigenteDesde.Visible = true;
            this.colVigenteDesde.VisibleIndex = 2;
            this.colVigenteDesde.Width = 179;
            // 
            // colVigenteHasta
            // 
            this.colVigenteHasta.FieldName = "VigenteHasta";
            this.colVigenteHasta.Name = "colVigenteHasta";
            this.colVigenteHasta.Visible = true;
            this.colVigenteHasta.VisibleIndex = 3;
            this.colVigenteHasta.Width = 156;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 109;
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
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            // 
            // colId_Empresa
            // 
            this.colId_Empresa.Caption = "Id_Empresa";
            this.colId_Empresa.FieldName = "Id_Empresa";
            this.colId_Empresa.Name = "colId_Empresa";
            // 
            // colUtilidad
            // 
            this.colUtilidad.Caption = "Utilidad";
            this.colUtilidad.FieldName = "Utilidad";
            this.colUtilidad.Name = "colUtilidad";
            this.colUtilidad.Visible = true;
            this.colUtilidad.VisibleIndex = 4;
            this.colUtilidad.Width = 101;
            // 
            // colEnUso
            // 
            this.colEnUso.Caption = "En Uso";
            this.colEnUso.FieldName = "EnUso";
            this.colEnUso.Name = "colEnUso";
            this.colEnUso.Visible = true;
            this.colEnUso.VisibleIndex = 5;
            // 
            // frmProduccionListaPrecios
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
            this.MinimumSize = new System.Drawing.Size(668, 259);
            this.Name = "frmProduccionListaPrecios";
            this.Text = "Lista de Precios";
            this.Load += new System.EventHandler(this.frmProduccionListaPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoDesdeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionListaPreciosManager_SearchResultBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnDetalle;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource produccionListaPreciosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colVigente;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colVigenteDesde;
        private DevExpress.XtraGrid.Columns.GridColumn colVigenteHasta;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource produccionListaPreciosManager_ParametrosBusquedasBindingSource;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarButtonItem btnListaPrecios;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn colUtilidad;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnGenerarExcelPrecios;
        private DevExpress.XtraBars.BarButtonItem btnActualizaUtilidad;
        private DevExpress.XtraBars.BarButtonItem btnActualizaProductos;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SpinEdit añoDesdeTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEnUso;
    }
}