namespace VENET_Tesoreria_UI
{
    partial class frmBoletasDepositos
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            System.Windows.Forms.Label id_ProvFinancieroCuentaLabel;
            System.Windows.Forms.Label nroLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.boletasDepositosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource();
            this.nroTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_ProvFinancieroCuentaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.boletasDepositosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaConfirmacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            id_ProvFinancieroCuentaLabel = new System.Windows.Forms.Label();
            nroLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancieroCuentaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(366, 36);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(170, 10);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(54, 13);
            fechaDesdeLabel.TabIndex = 5;
            fechaDesdeLabel.Text = "F. Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(335, 10);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(52, 13);
            fechaHastaLabel.TabIndex = 7;
            fechaHastaLabel.Text = "F. Hasta:";
            // 
            // id_ProvFinancieroCuentaLabel
            // 
            id_ProvFinancieroCuentaLabel.AutoSize = true;
            id_ProvFinancieroCuentaLabel.Location = new System.Drawing.Point(12, 36);
            id_ProvFinancieroCuentaLabel.Name = "id_ProvFinancieroCuentaLabel";
            id_ProvFinancieroCuentaLabel.Size = new System.Drawing.Size(46, 13);
            id_ProvFinancieroCuentaLabel.TabIndex = 9;
            id_ProvFinancieroCuentaLabel.Text = "Cuenta:";
            // 
            // nroLabel
            // 
            nroLabel.AutoSize = true;
            nroLabel.Location = new System.Drawing.Point(195, 36);
            nroLabel.Name = "nroLabel";
            nroLabel.Size = new System.Drawing.Size(28, 13);
            nroLabel.TabIndex = 11;
            nroLabel.Text = "Nro:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(7, 10);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 12;
            id_SucursalLabel.Text = "Sucursal:";
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
            this.btnConfirmar,
            this.btnAnular,
            this.barButtonItem3});
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
            this.bar2.FloatLocation = new System.Drawing.Point(707, 330);
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
            this.btnAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 4;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem2.Id = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAnular, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Caption = "Confirmar";
            this.btnConfirmar.Id = 8;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Id = 9;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
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
            this.barStaticItemFooter.Id = 6;
            this.barStaticItemFooter.Name = "barStaticItemFooter";
            this.barStaticItemFooter.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(766, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 436);
            this.barDockControlBottom.Size = new System.Drawing.Size(766, 25);
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
            this.barDockControlRight.Location = new System.Drawing.Point(766, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 412);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Eliminar";
            this.barButtonItem3.Id = 10;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_SucursalLabel);
            this.panelControl1.Controls.Add(this.id_SucursalLookUpEdit);
            this.panelControl1.Controls.Add(nroLabel);
            this.panelControl1.Controls.Add(this.nroTextEdit);
            this.panelControl1.Controls.Add(id_ProvFinancieroCuentaLabel);
            this.panelControl1.Controls.Add(this.id_ProvFinancieroCuentaLookUpEdit);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(766, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(64, 7);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 0;
            // 
            // boletasDepositosManager_ParametrosBusquedasBindingSource
            // 
            this.boletasDepositosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.BoletasDepositosManager.ParametrosBusquedas);
            // 
            // nroTextEdit
            // 
            this.nroTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "Nro", true));
            this.nroTextEdit.Location = new System.Drawing.Point(229, 33);
            this.nroTextEdit.MenuManager = this.barManager1;
            this.nroTextEdit.Name = "nroTextEdit";
            this.nroTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroTextEdit.TabIndex = 4;
            // 
            // id_ProvFinancieroCuentaLookUpEdit
            // 
            this.id_ProvFinancieroCuentaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "Id_ProvFinancieroCuenta", true));
            this.id_ProvFinancieroCuentaLookUpEdit.Location = new System.Drawing.Point(64, 33);
            this.id_ProvFinancieroCuentaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvFinancieroCuentaLookUpEdit.Name = "id_ProvFinancieroCuentaLookUpEdit";
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre9")});
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.NullText = "";
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvFinancieroCuentaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_ProvFinancieroCuentaLookUpEdit.TabIndex = 3;
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(391, 7);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 2;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(229, 7);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 1;
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.Location = new System.Drawing.Point(391, 33);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 5;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(679, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // boletasDepositosManager_SearchResultBindingSource
            // 
            this.boletasDepositosManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.BoletasDepositosManager.SearchResult);
            this.boletasDepositosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.boletasDepositosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.boletasDepositosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(766, 353);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEntidad,
            this.colId,
            this.colId_Entidad,
            this.colId_CentroCosto,
            this.colNro,
            this.colNroCuenta,
            this.colFecha,
            this.colImporte,
            this.colDescripcion,
            this.colFechaConfirmacion,
            this.colFechaAnulacion,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colMotivoAnulacion});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FechaConfirmacion] ==  ?";
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Gray;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[FechaAnulacion] != ?";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colEntidad
            // 
            this.colEntidad.FieldName = "Entidad";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.OptionsColumn.AllowEdit = false;
            this.colEntidad.OptionsColumn.ReadOnly = true;
            this.colEntidad.Visible = true;
            this.colEntidad.VisibleIndex = 3;
            this.colEntidad.Width = 93;
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
            this.colId.Width = 61;
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            this.colId_Entidad.OptionsColumn.AllowEdit = false;
            this.colId_Entidad.OptionsColumn.ReadOnly = true;
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            this.colId_CentroCosto.OptionsColumn.AllowEdit = false;
            this.colId_CentroCosto.OptionsColumn.ReadOnly = true;
            // 
            // colNro
            // 
            this.colNro.FieldName = "Nro";
            this.colNro.Name = "colNro";
            this.colNro.OptionsColumn.AllowEdit = false;
            this.colNro.OptionsColumn.ReadOnly = true;
            this.colNro.Visible = true;
            this.colNro.VisibleIndex = 2;
            this.colNro.Width = 73;
            // 
            // colNroCuenta
            // 
            this.colNroCuenta.FieldName = "Cuenta";
            this.colNroCuenta.Name = "colNroCuenta";
            this.colNroCuenta.OptionsColumn.AllowEdit = false;
            this.colNroCuenta.OptionsColumn.ReadOnly = true;
            this.colNroCuenta.Visible = true;
            this.colNroCuenta.VisibleIndex = 4;
            this.colNroCuenta.Width = 83;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 65;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 89;
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
            this.colDescripcion.Width = 111;
            // 
            // colFechaConfirmacion
            // 
            this.colFechaConfirmacion.Caption = "F. Confirmación";
            this.colFechaConfirmacion.FieldName = "FechaConfirmacion";
            this.colFechaConfirmacion.Name = "colFechaConfirmacion";
            this.colFechaConfirmacion.OptionsColumn.AllowEdit = false;
            this.colFechaConfirmacion.OptionsColumn.ReadOnly = true;
            this.colFechaConfirmacion.Visible = true;
            this.colFechaConfirmacion.VisibleIndex = 7;
            this.colFechaConfirmacion.Width = 103;
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.Caption = "F. Anulación";
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            this.colFechaAnulacion.OptionsColumn.AllowEdit = false;
            this.colFechaAnulacion.OptionsColumn.ReadOnly = true;
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
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // frmBoletasDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(748, 198);
            this.Name = "frmBoletasDepositos";
            this.Text = "Boletas de Depósitos";
            this.Load += new System.EventHandler(this.frmBoletasDepositos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancieroCuentaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource boletasDepositosManager_SearchResultBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private System.Windows.Forms.BindingSource boletasDepositosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colNro;
        private DevExpress.XtraGrid.Columns.GridColumn colNroCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaConfirmacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.LookUpEdit id_ProvFinancieroCuentaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit nroTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
    }
}