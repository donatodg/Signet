namespace VENET_Seguridad_UI
{
    partial class frmSeguridadUsuarios
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
            System.Windows.Forms.Label usuarioLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label activoLabel;
            System.Windows.Forms.Label apellidoLabel;
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.seguridadUsuariosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Grupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.apellidoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.seguridadUsuariosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnRestablecer = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnEmpresas = new DevExpress.XtraBars.BarButtonItem();
            this.btnSucursales = new DevExpress.XtraBars.BarButtonItem();
            this.btnCajas = new DevExpress.XtraBars.BarButtonItem();
            this.btnPuntosVentas = new DevExpress.XtraBars.BarButtonItem();
            this.btnUN = new DevExpress.XtraBars.BarButtonItem();
            this.btnCentrosCostos = new DevExpress.XtraBars.BarButtonItem();
            this.btnDepositos = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsuariosActivos = new DevExpress.XtraBars.BarButtonItem();
            this.btnReporteLog = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.activoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.usuarioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.colLegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            usuarioLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            activoLabel = new System.Windows.Forms.Label();
            apellidoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apellidoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(6, 11);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Location = new System.Drawing.Point(129, 11);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new System.Drawing.Size(47, 13);
            usuarioLabel.TabIndex = 3;
            usuarioLabel.Text = "Usuario:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(281, 11);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 5;
            nombreLabel.Text = "Nombre:";
            // 
            // activoLabel
            // 
            activoLabel.AutoSize = true;
            activoLabel.Location = new System.Drawing.Point(586, 11);
            activoLabel.Name = "activoLabel";
            activoLabel.Size = new System.Drawing.Size(41, 13);
            activoLabel.TabIndex = 7;
            activoLabel.Text = "Activo:";
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new System.Drawing.Point(434, 11);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new System.Drawing.Size(48, 13);
            apellidoLabel.TabIndex = 9;
            apellidoLabel.Text = "Apellido:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(649, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.seguridadUsuariosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 58);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 378);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // seguridadUsuariosManager_SearchResultBindingSource
            // 
            this.seguridadUsuariosManager_SearchResultBindingSource.DataSource = typeof(VENET_Seguridad_BL.SeguridadUsuariosManager.SearchResult);
            this.seguridadUsuariosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.seguridadUsuariosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGrupo,
            this.colId_Grupo,
            this.colUsername,
            this.colApellido,
            this.colNombre,
            this.colActivo,
            this.colEmail,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colLegajo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colGrupo
            // 
            this.colGrupo.FieldName = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.OptionsColumn.AllowEdit = false;
            this.colGrupo.OptionsColumn.ReadOnly = true;
            this.colGrupo.Visible = true;
            this.colGrupo.VisibleIndex = 5;
            this.colGrupo.Width = 137;
            // 
            // colId_Grupo
            // 
            this.colId_Grupo.FieldName = "Id_Grupo";
            this.colId_Grupo.Name = "colId_Grupo";
            this.colId_Grupo.OptionsColumn.AllowEdit = false;
            this.colId_Grupo.OptionsColumn.ReadOnly = true;
            // 
            // colUsername
            // 
            this.colUsername.Caption = "Usuario";
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.OptionsColumn.AllowEdit = false;
            this.colUsername.OptionsColumn.ReadOnly = true;
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 1;
            this.colUsername.Width = 126;
            // 
            // colApellido
            // 
            this.colApellido.FieldName = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.OptionsColumn.AllowEdit = false;
            this.colApellido.OptionsColumn.ReadOnly = true;
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 2;
            this.colApellido.Width = 107;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 3;
            this.colNombre.Width = 104;
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.OptionsColumn.AllowEdit = false;
            this.colActivo.OptionsColumn.ReadOnly = true;
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 6;
            this.colActivo.Width = 41;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.OptionsColumn.ReadOnly = true;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 135;
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
            this.colId.Width = 66;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(apellidoLabel);
            this.panelControl1.Controls.Add(this.apellidoTextEdit);
            this.panelControl1.Controls.Add(activoLabel);
            this.panelControl1.Controls.Add(this.activoCheckEdit);
            this.panelControl1.Controls.Add(nombreLabel);
            this.panelControl1.Controls.Add(this.nombreTextEdit);
            this.panelControl1.Controls.Add(usuarioLabel);
            this.panelControl1.Controls.Add(this.usuarioTextEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 34);
            this.panelControl1.TabIndex = 2;
            // 
            // apellidoTextEdit
            // 
            this.apellidoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosManager_ParametrosBusquedasBindingSource, "Apellido", true));
            this.apellidoTextEdit.EnterMoveNextControl = true;
            this.apellidoTextEdit.Location = new System.Drawing.Point(482, 8);
            this.apellidoTextEdit.MenuManager = this.barManager1;
            this.apellidoTextEdit.Name = "apellidoTextEdit";
            this.apellidoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.apellidoTextEdit.TabIndex = 10;
            this.apellidoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // seguridadUsuariosManager_ParametrosBusquedasBindingSource
            // 
            this.seguridadUsuariosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Seguridad_BL.SeguridadUsuariosManager.ParametrosBusquedas);
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
            this.btnEmpresas,
            this.barSubItem2,
            this.btnResultado,
            this.barStaticItemFooter,
            this.btnCentrosCostos,
            this.btnCajas,
            this.btnPuntosVentas,
            this.btnUN,
            this.btnSucursales,
            this.barSubItem3,
            this.btnRestablecer,
            this.btnDepositos,
            this.btnUsuariosActivos,
            this.btnReporteLog});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 20;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Seguridad_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.addfile_32x32;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Seguridad_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.loadfrom_32x32;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Seguridad_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.deletelist_32x32;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_Seguridad_UI.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 5;
            this.barSubItem2.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.print_32x32;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 6;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Operaciones";
            this.barSubItem3.Glyph = global::VENET_Seguridad_UI.Properties.Resources.properties_16x16;
            this.barSubItem3.Id = 15;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestablecer)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Caption = "Restablecer Visualización";
            this.btnRestablecer.Id = 16;
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestablecer_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Ver";
            this.barSubItem1.Glyph = global::VENET_Seguridad_UI.Properties.Resources.info_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.info_32x32;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEmpresas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSucursales),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCajas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPuntosVentas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUN),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCentrosCostos),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDepositos),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUsuariosActivos, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReporteLog)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.Caption = "Empresas Asignadas";
            this.btnEmpresas.Id = 4;
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmpresas_ItemClick);
            // 
            // btnSucursales
            // 
            this.btnSucursales.Caption = "Sucursales Asignadas";
            this.btnSucursales.Id = 14;
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSucursales_ItemClick);
            // 
            // btnCajas
            // 
            this.btnCajas.Caption = "Cajas Asignadas";
            this.btnCajas.Id = 11;
            this.btnCajas.Name = "btnCajas";
            this.btnCajas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCajas_ItemClick);
            // 
            // btnPuntosVentas
            // 
            this.btnPuntosVentas.Caption = "Puntos de Ventas Asignados";
            this.btnPuntosVentas.Id = 12;
            this.btnPuntosVentas.Name = "btnPuntosVentas";
            this.btnPuntosVentas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPuntosVentas_ItemClick);
            // 
            // btnUN
            // 
            this.btnUN.Caption = "Unidades de Negocio Asignadas";
            this.btnUN.Id = 13;
            this.btnUN.Name = "btnUN";
            this.btnUN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUN_ItemClick);
            // 
            // btnCentrosCostos
            // 
            this.btnCentrosCostos.Caption = "Centros de Costos Asignados";
            this.btnCentrosCostos.Id = 10;
            this.btnCentrosCostos.Name = "btnCentrosCostos";
            this.btnCentrosCostos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCentrosCostos_ItemClick);
            // 
            // btnDepositos
            // 
            this.btnDepositos.Caption = "Depósitos Asignados";
            this.btnDepositos.Id = 17;
            this.btnDepositos.Name = "btnDepositos";
            this.btnDepositos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepositos_ItemClick);
            // 
            // btnUsuariosActivos
            // 
            this.btnUsuariosActivos.Caption = "Reporte de Usuarios Activos";
            this.btnUsuariosActivos.Id = 18;
            this.btnUsuariosActivos.Name = "btnUsuariosActivos";
            this.btnUsuariosActivos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsuariosActivos_ItemClick);
            // 
            // btnReporteLog
            // 
            this.btnReporteLog.Caption = "Reporte de Log";
            this.btnReporteLog.Id = 19;
            this.btnReporteLog.Name = "btnReporteLog";
            this.btnReporteLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReporteLog_ItemClick);
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
            this.barStaticItemFooter.Id = 8;
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
            // activoCheckEdit
            // 
            this.activoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosManager_ParametrosBusquedasBindingSource, "Activo", true));
            this.activoCheckEdit.EditValue = true;
            this.activoCheckEdit.EnterMoveNextControl = true;
            this.activoCheckEdit.Location = new System.Drawing.Point(626, 8);
            this.activoCheckEdit.MenuManager = this.barManager1;
            this.activoCheckEdit.Name = "activoCheckEdit";
            this.activoCheckEdit.Properties.Caption = "";
            this.activoCheckEdit.Size = new System.Drawing.Size(24, 19);
            this.activoCheckEdit.TabIndex = 8;
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosManager_ParametrosBusquedasBindingSource, "Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(329, 8);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nombreTextEdit.TabIndex = 6;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // usuarioTextEdit
            // 
            this.usuarioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosManager_ParametrosBusquedasBindingSource, "Usuario", true));
            this.usuarioTextEdit.EnterMoveNextControl = true;
            this.usuarioTextEdit.Location = new System.Drawing.Point(176, 8);
            this.usuarioTextEdit.MenuManager = this.barManager1;
            this.usuarioTextEdit.Name = "usuarioTextEdit";
            this.usuarioTextEdit.Size = new System.Drawing.Size(100, 20);
            this.usuarioTextEdit.TabIndex = 4;
            this.usuarioTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seguridadUsuariosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(27, 8);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 2;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // colLegajo
            // 
            this.colLegajo.Caption = "Legajo";
            this.colLegajo.FieldName = "Legajo";
            this.colLegajo.Name = "colLegajo";
            // 
            // frmSeguridadUsuarios
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
            this.MinimumSize = new System.Drawing.Size(750, 216);
            this.Name = "frmSeguridadUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmSeguridadUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apellidoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadUsuariosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnEmpresas;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraEditors.TextEdit apellidoTextEdit;
        private System.Windows.Forms.BindingSource seguridadUsuariosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.CheckEdit activoCheckEdit;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.TextEdit usuarioTextEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource seguridadUsuariosManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Grupo;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarButtonItem btnCentrosCostos;
        private DevExpress.XtraBars.BarButtonItem btnCajas;
        private DevExpress.XtraBars.BarButtonItem btnPuntosVentas;
        private DevExpress.XtraBars.BarButtonItem btnUN;
        private DevExpress.XtraBars.BarButtonItem btnSucursales;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnRestablecer;
        private DevExpress.XtraBars.BarButtonItem btnDepositos;
        private DevExpress.XtraBars.BarButtonItem btnUsuariosActivos;
        private DevExpress.XtraBars.BarButtonItem btnReporteLog;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajo;
    }
}