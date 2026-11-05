namespace VENET_Contabilidad_UI
{
    partial class frmAsientos_AddMod
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
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label id_EspecieLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label numeroLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientos_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.numeroTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.asientosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_Asiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CuentaContable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            fechaLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            id_EspecieLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(33, 37);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 0;
            fechaLabel.Text = "Fecha:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(21, 11);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 2;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // id_EspecieLabel
            // 
            id_EspecieLabel.AutoSize = true;
            id_EspecieLabel.Location = new System.Drawing.Point(269, 11);
            id_EspecieLabel.Name = "id_EspecieLabel";
            id_EspecieLabel.Size = new System.Drawing.Size(47, 13);
            id_EspecieLabel.TabIndex = 4;
            id_EspecieLabel.Text = "Especie:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(8, 63);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 6;
            descripcionLabel.Text = "Descripción:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(268, 37);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(48, 13);
            numeroLabel.TabIndex = 27;
            numeroLabel.Text = "Número:";
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
            this.btnGuardar});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuardar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Aceptar";
            this.btnGuardar.Id = 0;
            this.btnGuardar.Glyph = global::VENET_Contabilidad_UI.Properties.Resources.save_16x16;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
           // this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(643, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 426);
            //this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(643, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            //this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 402);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(643, 24);
            //this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 402);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(numeroLabel);
            this.groupControl1.Controls.Add(this.numeroTextEdit);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(id_EspecieLabel);
            this.groupControl1.Controls.Add(this.id_EspecieLookUpEdit);
            this.groupControl1.Controls.Add(id_EmpresaLabel);
            this.groupControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(619, 388);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // numeroTextEdit
            // 
            this.numeroTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosManagerBindingSource, "Asiento.Numero", true));
            this.numeroTextEdit.EnterMoveNextControl = true;
            this.numeroTextEdit.Location = new System.Drawing.Point(322, 34);
            this.numeroTextEdit.MenuManager = this.barManager1;
            this.numeroTextEdit.Name = "numeroTextEdit";
            this.numeroTextEdit.Size = new System.Drawing.Size(100, 20);
            this.numeroTextEdit.TabIndex = 3;
            // 
            // asientosManagerBindingSource
            // 
            this.asientosManagerBindingSource.DataSource = typeof(VENET_Contabilidad_BL.AsientosManager);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Location = new System.Drawing.Point(5, 86);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(606, 297);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Detalle";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.detalleBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(602, 243);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.AsientosDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_Asiento,
            this.colOrden,
            this.colId_CuentaContable,
            this.colDebe,
            this.colHaber,
            this.colAsiento,
            this.colBorrado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colCuenta});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.Importe", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteCosto", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteIVA", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.ImporteUnitario", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Detalle.Cantidad", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId_Asiento
            // 
            this.colId_Asiento.FieldName = "Id_Asiento";
            this.colId_Asiento.Name = "colId_Asiento";
            // 
            // colOrden
            // 
            this.colOrden.FieldName = "Orden";
            this.colOrden.Name = "colOrden";
            this.colOrden.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Orden", "{0}")});
            this.colOrden.Visible = true;
            this.colOrden.VisibleIndex = 0;
            this.colOrden.Width = 40;
            // 
            // colId_CuentaContable
            // 
            this.colId_CuentaContable.FieldName = "Id_CuentaContable";
            this.colId_CuentaContable.Name = "colId_CuentaContable";
            // 
            // colDebe
            // 
            this.colDebe.DisplayFormat.FormatString = "#,##0.00";
            this.colDebe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebe.FieldName = "Debe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debe", "{0:N2}")});
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 2;
            this.colDebe.Width = 121;
            // 
            // colHaber
            // 
            this.colHaber.DisplayFormat.FormatString = "#,##0.00";
            this.colHaber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHaber.FieldName = "Haber";
            this.colHaber.Name = "colHaber";
            this.colHaber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Haber", "{0:N2}")});
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 3;
            this.colHaber.Width = 128;
            // 
            // colAsiento
            // 
            this.colAsiento.FieldName = "Asiento";
            this.colAsiento.Name = "colAsiento";
            // 
            // colBorrado
            // 
            this.colBorrado.FieldName = "Borrado";
            this.colBorrado.Name = "colBorrado";
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
            // colCuenta
            // 
            this.colCuenta.Caption = "Cuenta";
            this.colCuenta.FieldName = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 1;
            this.colCuenta.Width = 299;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 263);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(602, 32);
            this.panelControl1.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::VENET_Contabilidad_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(9, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "    Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(168, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "    Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(88, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosManagerBindingSource, "Asiento.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(79, 60);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(532, 20);
            this.descripcionTextEdit.TabIndex = 4;
            // 
            // id_EspecieLookUpEdit
            // 
            this.id_EspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosManagerBindingSource, "Asiento.Id_Especie", true));
            this.id_EspecieLookUpEdit.EnterMoveNextControl = true;
            this.id_EspecieLookUpEdit.Location = new System.Drawing.Point(322, 8);
            this.id_EspecieLookUpEdit.MenuManager = this.barManager1;
            this.id_EspecieLookUpEdit.Name = "id_EspecieLookUpEdit";
            this.id_EspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_EspecieLookUpEdit.Properties.NullText = "";
            this.id_EspecieLookUpEdit.Properties.ShowHeader = false;
            this.id_EspecieLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_EspecieLookUpEdit.TabIndex = 1;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosManagerBindingSource, "Asiento.Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(79, 8);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre2")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(184, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosManagerBindingSource, "Asiento.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(79, 34);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 2;
            this.fechaDateEdit.EditValueChanged += new System.EventHandler(this.fechaDateEdit_EditValueChanged);
            // 
            // frmAsientos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 426);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(659, 465);
            this.Name = "frmAsientos_AddMod";
            this.Text = "Alta/Modificación de Asientos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAsientos_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmAsientos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource asientosManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_EspecieLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Asiento;
        private DevExpress.XtraGrid.Columns.GridColumn colOrden;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CuentaContable;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraGrid.Columns.GridColumn colAsiento;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraEditors.TextEdit numeroTextEdit;
    }
}