namespace VENET_Tesoreria_UI
{
    partial class frmChequeDescuento_AddMod
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
            System.Windows.Forms.Label id_ProvFinancieroLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequeDescuento_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.boletasDepositosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_ProvFinancieroCuentaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.chequeDescuentoManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_ChequeDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChequeDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroCheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            id_ProvFinancieroLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancieroCuentaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // id_ProvFinancieroLabel
            // 
            id_ProvFinancieroLabel.AutoSize = true;
            id_ProvFinancieroLabel.Location = new System.Drawing.Point(15, 68);
            id_ProvFinancieroLabel.Name = "id_ProvFinancieroLabel";
            id_ProvFinancieroLabel.Size = new System.Drawing.Size(89, 13);
            id_ProvFinancieroLabel.TabIndex = 39;
            id_ProvFinancieroLabel.Text = "Prov. Financiero:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(38, 94);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 41;
            descripcionLabel.Text = "Descripción:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(64, 16);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 42;
            fechaLabel.Text = "Fecha:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(16, 42);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(90, 13);
            id_CentroCostoLabel.TabIndex = 42;
            id_CentroCostoLabel.Text = "Centro de Costo:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(586, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 447);
            this.barDockControlBottom.Size = new System.Drawing.Size(586, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(586, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(this.id_ProvFinancieroCuentaLookUpEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(id_ProvFinancieroLabel);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(562, 407);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.boletasDepositosManagerBindingSource, "Boleta.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(110, 39);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre2")});
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(314, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 43;
            // 
            // boletasDepositosManagerBindingSource
            // 
            this.boletasDepositosManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.BoletasDepositosManager);
            // 
            // id_ProvFinancieroCuentaLookUpEdit
            // 
            this.id_ProvFinancieroCuentaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManagerBindingSource, "Descuento.Id_ProvFinancieroCuenta", true));
            this.id_ProvFinancieroCuentaLookUpEdit.Location = new System.Drawing.Point(110, 65);
            this.id_ProvFinancieroCuentaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvFinancieroCuentaLookUpEdit.Name = "id_ProvFinancieroCuentaLookUpEdit";
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre3")});
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.NullText = "";
            this.id_ProvFinancieroCuentaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvFinancieroCuentaLookUpEdit.Size = new System.Drawing.Size(314, 20);
            this.id_ProvFinancieroCuentaLookUpEdit.TabIndex = 1;
            this.id_ProvFinancieroCuentaLookUpEdit.EditValueChanged += new System.EventHandler(this.id_ProvFinancieroCuentaLookUpEdit_EditValueChanged);
            // 
            // chequeDescuentoManagerBindingSource
            // 
            this.chequeDescuentoManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ChequeDescuentoManager);
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManagerBindingSource, "Descuento.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.Location = new System.Drawing.Point(110, 13);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.chequeDescuentoManagerBindingSource, "Descuento.Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(109, 91);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(315, 20);
            this.descripcionTextEdit.TabIndex = 2;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Location = new System.Drawing.Point(14, 120);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(536, 272);
            this.groupControl2.TabIndex = 4;
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
            this.gridControl1.Size = new System.Drawing.Size(532, 218);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.ChequesDescuentoDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_ChequeDescuento,
            this.colId_Documento,
            this.colChequeDescuento,
            this.colBanco,
            this.colSucursal,
            this.colNroCheque,
            this.colNroCuenta,
            this.colImporte,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", this.colImporte, "{0:N2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colId, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colId_ChequeDescuento
            // 
            this.colId_ChequeDescuento.FieldName = "Id_ChequeDescuento";
            this.colId_ChequeDescuento.Name = "colId_ChequeDescuento";
            // 
            // colId_Documento
            // 
            this.colId_Documento.FieldName = "Id_Documento";
            this.colId_Documento.Name = "colId_Documento";
            // 
            // colChequeDescuento
            // 
            this.colChequeDescuento.FieldName = "ChequeDescuento";
            this.colChequeDescuento.Name = "colChequeDescuento";
            // 
            // colBanco
            // 
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 0;
            this.colBanco.Width = 178;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 1;
            this.colSucursal.Width = 51;
            // 
            // colNroCheque
            // 
            this.colNroCheque.FieldName = "NroCheque";
            this.colNroCheque.Name = "colNroCheque";
            this.colNroCheque.Visible = true;
            this.colNroCheque.VisibleIndex = 2;
            this.colNroCheque.Width = 82;
            // 
            // colNroCuenta
            // 
            this.colNroCuenta.FieldName = "NroCuenta";
            this.colNroCuenta.Name = "colNroCuenta";
            this.colNroCuenta.Visible = true;
            this.colNroCuenta.VisibleIndex = 3;
            this.colNroCuenta.Width = 100;
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 4;
            this.colImporte.Width = 92;
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnAgregar);
            this.panelControl2.Controls.Add(this.btnEliminar);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 238);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(532, 32);
            this.panelControl2.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(8, 5);
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
            this.btnEliminar.Location = new System.Drawing.Point(89, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "    Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmChequeDescuento_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 447);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChequeDescuento_AddMod";
            this.Text = "Alta/Modificación de Descuento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChequeDescuento_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmChequeDescuento_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boletasDepositosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvFinancieroCuentaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDescuentoManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private System.Windows.Forms.Button btnAgregar;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private System.Windows.Forms.BindingSource chequeDescuentoManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_ProvFinancieroCuentaLookUpEdit;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ChequeDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Documento;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colNroCheque;
        private DevExpress.XtraGrid.Columns.GridColumn colNroCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private System.Windows.Forms.BindingSource boletasDepositosManagerBindingSource;
    }
}