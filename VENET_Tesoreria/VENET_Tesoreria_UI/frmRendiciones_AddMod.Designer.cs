namespace VENET_Tesoreria_UI
{
    partial class frmRendiciones_AddMod
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
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.Windows.Forms.Label id_PersonalLabel;
            System.Windows.Forms.Label id_ValeLabel;
            System.Windows.Forms.Label importeValeLabel;
            System.Windows.Forms.Label devolucionLabel;
            System.Windows.Forms.Label diferenciaLabel;
            System.Windows.Forms.Label id_CajaLabel;
            this.rendicionesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAgregarVales = new System.Windows.Forms.Button();
            this.id_CajaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.idPersonalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Rendicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRendicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.diferenciaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.devolucionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.importeValeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_ValeTextEdit = new DevExpress.XtraEditors.TextEdit();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            id_PersonalLabel = new System.Windows.Forms.Label();
            id_ValeLabel = new System.Windows.Forms.Label();
            importeValeLabel = new System.Windows.Forms.Label();
            devolucionLabel = new System.Windows.Forms.Label();
            diferenciaLabel = new System.Windows.Forms.Label();
            id_CajaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPersonalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diferenciaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devolucionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeValeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ValeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(6, 35);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(75, 13);
            id_CentroCostoLabel.TabIndex = 1;
            id_CentroCostoLabel.Text = "Centro Costo:";
            // 
            // id_PersonalLabel
            // 
            id_PersonalLabel.AutoSize = true;
            id_PersonalLabel.Location = new System.Drawing.Point(30, 61);
            id_PersonalLabel.Name = "id_PersonalLabel";
            id_PersonalLabel.Size = new System.Drawing.Size(52, 13);
            id_PersonalLabel.TabIndex = 2;
            id_PersonalLabel.Text = "Personal:";
            // 
            // id_ValeLabel
            // 
            id_ValeLabel.AutoSize = true;
            id_ValeLabel.Location = new System.Drawing.Point(50, 87);
            id_ValeLabel.Name = "id_ValeLabel";
            id_ValeLabel.Size = new System.Drawing.Size(31, 13);
            id_ValeLabel.TabIndex = 4;
            id_ValeLabel.Text = "Vale:";
            // 
            // importeValeLabel
            // 
            importeValeLabel.AutoSize = true;
            importeValeLabel.Location = new System.Drawing.Point(33, 113);
            importeValeLabel.Name = "importeValeLabel";
            importeValeLabel.Size = new System.Drawing.Size(49, 13);
            importeValeLabel.TabIndex = 6;
            importeValeLabel.Text = "Importe:";
            // 
            // devolucionLabel
            // 
            devolucionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            devolucionLabel.AutoSize = true;
            devolucionLabel.Location = new System.Drawing.Point(355, 335);
            devolucionLabel.Name = "devolucionLabel";
            devolucionLabel.Size = new System.Drawing.Size(63, 13);
            devolucionLabel.TabIndex = 8;
            devolucionLabel.Text = "Devolución:";
            // 
            // diferenciaLabel
            // 
            diferenciaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            diferenciaLabel.AutoSize = true;
            diferenciaLabel.Location = new System.Drawing.Point(361, 361);
            diferenciaLabel.Name = "diferenciaLabel";
            diferenciaLabel.Size = new System.Drawing.Size(59, 13);
            diferenciaLabel.TabIndex = 10;
            diferenciaLabel.Text = "Diferencia:";
            // 
            // id_CajaLabel
            // 
            id_CajaLabel.AutoSize = true;
            id_CajaLabel.Location = new System.Drawing.Point(49, 9);
            id_CajaLabel.Name = "id_CajaLabel";
            id_CajaLabel.Size = new System.Drawing.Size(33, 13);
            id_CajaLabel.TabIndex = 15;
            id_CajaLabel.Text = "Caja:";
            // 
            // rendicionesManagerBindingSource
            // 
            this.rendicionesManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.RendicionesManager);
            this.rendicionesManagerBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.rendicionesManagerBindingSource_BindingComplete);
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(86, 32);
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(330, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnAgregarVales);
            this.groupControl1.Controls.Add(id_CajaLabel);
            this.groupControl1.Controls.Add(this.id_CajaLookUpEdit);
            this.groupControl1.Controls.Add(this.idPersonalLookUpEdit);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(diferenciaLabel);
            this.groupControl1.Controls.Add(this.diferenciaTextEdit);
            this.groupControl1.Controls.Add(devolucionLabel);
            this.groupControl1.Controls.Add(this.devolucionTextEdit);
            this.groupControl1.Controls.Add(importeValeLabel);
            this.groupControl1.Controls.Add(this.importeValeTextEdit);
            this.groupControl1.Controls.Add(id_ValeLabel);
            this.groupControl1.Controls.Add(this.id_ValeTextEdit);
            this.groupControl1.Controls.Add(id_PersonalLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(532, 385);
            this.groupControl1.TabIndex = 0;
            // 
            // btnAgregarVales
            // 
            this.btnAgregarVales.Image = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregarVales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarVales.Location = new System.Drawing.Point(341, 82);
            this.btnAgregarVales.Name = "btnAgregarVales";
            this.btnAgregarVales.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarVales.TabIndex = 17;
            this.btnAgregarVales.Text = "   Agregar";
            this.btnAgregarVales.Click += new System.EventHandler(this.btnAgregarVales_Click);
            // 
            // id_CajaLookUpEdit
            // 
            this.id_CajaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Id_Caja", true));
            this.id_CajaLookUpEdit.Location = new System.Drawing.Point(86, 6);
            this.id_CajaLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaLookUpEdit.Name = "id_CajaLookUpEdit";
            this.id_CajaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CajaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaLookUpEdit.Properties.NullText = "";
            this.id_CajaLookUpEdit.Size = new System.Drawing.Size(330, 20);
            this.id_CajaLookUpEdit.TabIndex = 16;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAceptar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(556, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 425);
            this.barDockControlBottom.Size = new System.Drawing.Size(556, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 401);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(556, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 401);
            // 
            // idPersonalLookUpEdit
            // 
            this.idPersonalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Id_Personal", true));
            this.idPersonalLookUpEdit.Location = new System.Drawing.Point(86, 58);
            this.idPersonalLookUpEdit.MenuManager = this.barManager1;
            this.idPersonalLookUpEdit.Name = "idPersonalLookUpEdit";
            this.idPersonalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idPersonalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Legajo", 7, "Legajo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.idPersonalLookUpEdit.Properties.NullText = "";
            this.idPersonalLookUpEdit.Size = new System.Drawing.Size(330, 20);
            this.idPersonalLookUpEdit.TabIndex = 15;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Location = new System.Drawing.Point(5, 136);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(522, 190);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Detalle";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.detalleBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(518, 139);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.RendicionesDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colId_Rendicion,
            this.colId_Cuenta,
            this.colImporte,
            this.colRendicion,
            this.colCuenta});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colId_Rendicion
            // 
            this.colId_Rendicion.FieldName = "Id_Rendicion";
            this.colId_Rendicion.Name = "colId_Rendicion";
            this.colId_Rendicion.OptionsColumn.AllowEdit = false;
            this.colId_Rendicion.OptionsColumn.ReadOnly = true;
            // 
            // colId_Cuenta
            // 
            this.colId_Cuenta.FieldName = "Id_Cuenta";
            this.colId_Cuenta.Name = "colId_Cuenta";
            this.colId_Cuenta.OptionsColumn.AllowEdit = false;
            this.colId_Cuenta.OptionsColumn.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 1;
            this.colImporte.Width = 357;
            // 
            // colRendicion
            // 
            this.colRendicion.FieldName = "Rendicion";
            this.colRendicion.Name = "colRendicion";
            this.colRendicion.OptionsColumn.AllowEdit = false;
            this.colRendicion.OptionsColumn.ReadOnly = true;
            // 
            // colCuenta
            // 
            this.colCuenta.Caption = "Cuenta";
            this.colCuenta.FieldName = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.OptionsColumn.AllowEdit = false;
            this.colCuenta.OptionsColumn.ReadOnly = true;
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 0;
            this.colCuenta.Width = 687;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 159);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(518, 29);
            this.panelControl1.TabIndex = 13;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(167, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "    Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(86, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(5, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "   Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // diferenciaTextEdit
            // 
            this.diferenciaTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diferenciaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Diferencia", true));
            this.diferenciaTextEdit.Enabled = false;
            this.diferenciaTextEdit.Location = new System.Drawing.Point(425, 358);
            this.diferenciaTextEdit.Name = "diferenciaTextEdit";
            this.diferenciaTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.diferenciaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.diferenciaTextEdit.Properties.Mask.EditMask = "n";
            this.diferenciaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.diferenciaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.diferenciaTextEdit.TabIndex = 11;
            this.diferenciaTextEdit.TabStop = false;
            // 
            // devolucionTextEdit
            // 
            this.devolucionTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.devolucionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Devolucion", true));
            this.devolucionTextEdit.EnterMoveNextControl = true;
            this.devolucionTextEdit.Location = new System.Drawing.Point(425, 332);
            this.devolucionTextEdit.Name = "devolucionTextEdit";
            this.devolucionTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.devolucionTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.devolucionTextEdit.Properties.Mask.EditMask = "n";
            this.devolucionTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.devolucionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.devolucionTextEdit.TabIndex = 4;
            this.devolucionTextEdit.EditValueChanged += new System.EventHandler(this.devolucionTextEdit_EditValueChanged);
            // 
            // importeValeTextEdit
            // 
            this.importeValeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.ImporteVale", true));
            this.importeValeTextEdit.Enabled = false;
            this.importeValeTextEdit.Location = new System.Drawing.Point(86, 110);
            this.importeValeTextEdit.Name = "importeValeTextEdit";
            this.importeValeTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.importeValeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeValeTextEdit.Properties.Mask.EditMask = "n";
            this.importeValeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeValeTextEdit.Size = new System.Drawing.Size(96, 20);
            this.importeValeTextEdit.TabIndex = 7;
            this.importeValeTextEdit.TabStop = false;
            this.importeValeTextEdit.EditValueChanged += new System.EventHandler(this.importeValeTextEdit_EditValueChanged);
            // 
            // id_ValeTextEdit
            // 
            this.id_ValeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rendicionesManagerBindingSource, "Rendicion.Ids_Vales", true));
            this.id_ValeTextEdit.Enabled = false;
            this.id_ValeTextEdit.EnterMoveNextControl = true;
            this.id_ValeTextEdit.Location = new System.Drawing.Point(85, 84);
            this.id_ValeTextEdit.Name = "id_ValeTextEdit";
            this.id_ValeTextEdit.Size = new System.Drawing.Size(250, 20);
            this.id_ValeTextEdit.TabIndex = 2;
            this.id_ValeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmRendiciones_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(556, 425);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(572, 464);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(572, 464);
            this.Name = "frmRendiciones_AddMod";
            this.Text = "Alta/Modificación  de Rendiciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRendiciones_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmRendiciones_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rendicionesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPersonalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diferenciaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devolucionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeValeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ValeTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource rendicionesManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Rendicion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colRendicion;
        private DevExpress.XtraEditors.TextEdit diferenciaTextEdit;
        private DevExpress.XtraEditors.TextEdit devolucionTextEdit;
        private DevExpress.XtraEditors.TextEdit importeValeTextEdit;
        private DevExpress.XtraEditors.TextEdit id_ValeTextEdit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraEditors.LookUpEdit idPersonalLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CajaLookUpEdit;
        private System.Windows.Forms.Button btnAgregarVales;
    }
}