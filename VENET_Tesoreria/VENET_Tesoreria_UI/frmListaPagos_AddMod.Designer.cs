namespace VENET_Tesoreria_UI
{
    partial class frmListaPagos_AddMod
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
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label id_EspecieLabel;
            System.Windows.Forms.Label tipoEntidadLabel;
            System.Windows.Forms.Label sentidoLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPagos_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnItemPago = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportar = new DevExpress.XtraBars.BarButtonItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.listaPagosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sentidoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_ListaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregar = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            fechaLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            id_SucursalLabel = new System.Windows.Forms.Label();
            id_EspecieLabel = new System.Windows.Forms.Label();
            tipoEntidadLabel = new System.Windows.Forms.Label();
            sentidoLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentidoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(60, 12);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 8;
            fechaLabel.Text = "Fecha:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(12, 38);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(90, 13);
            id_CentroCostoLabel.TabIndex = 9;
            id_CentroCostoLabel.Text = "Centro de Costo:";
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(49, 64);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(51, 13);
            id_SucursalLabel.TabIndex = 10;
            id_SucursalLabel.Text = "Sucursal:";
            // 
            // id_EspecieLabel
            // 
            id_EspecieLabel.AutoSize = true;
            id_EspecieLabel.Location = new System.Drawing.Point(53, 90);
            id_EspecieLabel.Name = "id_EspecieLabel";
            id_EspecieLabel.Size = new System.Drawing.Size(47, 13);
            id_EspecieLabel.TabIndex = 11;
            id_EspecieLabel.Text = "Especie:";
            // 
            // tipoEntidadLabel
            // 
            tipoEntidadLabel.AutoSize = true;
            tipoEntidadLabel.Location = new System.Drawing.Point(30, 116);
            tipoEntidadLabel.Name = "tipoEntidadLabel";
            tipoEntidadLabel.Size = new System.Drawing.Size(70, 13);
            tipoEntidadLabel.TabIndex = 12;
            tipoEntidadLabel.Text = "Tipo Entidad:";
            // 
            // sentidoLabel
            // 
            sentidoLabel.AutoSize = true;
            sentidoLabel.Location = new System.Drawing.Point(53, 142);
            sentidoLabel.Name = "sentidoLabel";
            sentidoLabel.Size = new System.Drawing.Size(47, 13);
            sentidoLabel.TabIndex = 13;
            sentidoLabel.Text = "Sentido:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(35, 168);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 14;
            descripcionLabel.Text = "Descripción:";
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
            this.btnAceptar,
            this.btnItemPago,
            this.btnImportar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(503, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 463);
            this.barDockControlBottom.Size = new System.Drawing.Size(503, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 439);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(503, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 439);
            // 
            // btnItemPago
            // 
            this.btnItemPago.Caption = "Item de Pago";
            this.btnItemPago.Id = 1;
            this.btnItemPago.Name = "btnItemPago";
            this.btnItemPago.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemPago_ItemClick);
            // 
            // btnImportar
            // 
            this.btnImportar.Caption = "Importar Excel con Pagos";
            this.btnImportar.Id = 2;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportar_ItemClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(sentidoLabel);
            this.groupControl1.Controls.Add(this.sentidoLookUpEdit);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(tipoEntidadLabel);
            this.groupControl1.Controls.Add(this.tipoEntidadLookUpEdit);
            this.groupControl1.Controls.Add(id_EspecieLabel);
            this.groupControl1.Controls.Add(this.id_EspecieLookUpEdit);
            this.groupControl1.Controls.Add(id_SucursalLabel);
            this.groupControl1.Controls.Add(this.id_SucursalLookUpEdit);
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(479, 425);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(106, 165);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 100;
            this.descripcionTextEdit.Size = new System.Drawing.Size(366, 20);
            this.descripcionTextEdit.TabIndex = 6;
            // 
            // listaPagosManagerBindingSource
            // 
            this.listaPagosManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ListaPagosManager);
            // 
            // sentidoLookUpEdit
            // 
            this.sentidoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Sentido", true));
            this.sentidoLookUpEdit.EnterMoveNextControl = true;
            this.sentidoLookUpEdit.Location = new System.Drawing.Point(106, 139);
            this.sentidoLookUpEdit.MenuManager = this.barManager1;
            this.sentidoLookUpEdit.Name = "sentidoLookUpEdit";
            this.sentidoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sentidoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name30")});
            this.sentidoLookUpEdit.Properties.NullText = "";
            this.sentidoLookUpEdit.Properties.ShowHeader = false;
            this.sentidoLookUpEdit.Size = new System.Drawing.Size(192, 20);
            this.sentidoLookUpEdit.TabIndex = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Location = new System.Drawing.Point(5, 191);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(469, 229);
            this.groupControl2.TabIndex = 7;
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
            this.gridControl1.Size = new System.Drawing.Size(465, 175);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // detalleBindingSource
            // 
            this.detalleBindingSource.DataSource = typeof(VENET_DataEntity.ListaPagosDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_ListaPago,
            this.colId_Entidad,
            this.colImporte,
            this.colDescripcion,
            this.colListaPago,
            this.colBorrado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel,
            this.colEntidad});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId_ListaPago
            // 
            this.colId_ListaPago.FieldName = "Id_ListaPago";
            this.colId_ListaPago.Name = "colId_ListaPago";
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
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
            this.colImporte.VisibleIndex = 2;
            this.colImporte.Width = 248;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 458;
            // 
            // colListaPago
            // 
            this.colListaPago.FieldName = "ListaPago";
            this.colListaPago.Name = "colListaPago";
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
            // colFechaDel
            // 
            this.colFechaDel.FieldName = "FechaDel";
            this.colFechaDel.Name = "colFechaDel";
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
            // colUserDel
            // 
            this.colUserDel.FieldName = "UserDel";
            this.colUserDel.Name = "colUserDel";
            // 
            // colEntidad
            // 
            this.colEntidad.Caption = "Entidad";
            this.colEntidad.FieldName = "Entidad";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.Visible = true;
            this.colEntidad.VisibleIndex = 0;
            this.colEntidad.Width = 356;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 195);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(465, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.DropDownControl = this.popupMenu1;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(9, 6);
            this.btnAgregar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAgregar.MenuManager = this.barManager1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemPago),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportar)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(180, 6);
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
            this.btnModificar.Location = new System.Drawing.Point(99, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Id_TipoEntidad", true));
            this.tipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(106, 113);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name28")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(192, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 4;
            // 
            // id_EspecieLookUpEdit
            // 
            this.id_EspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Id_Especie", true));
            this.id_EspecieLookUpEdit.EnterMoveNextControl = true;
            this.id_EspecieLookUpEdit.Location = new System.Drawing.Point(106, 87);
            this.id_EspecieLookUpEdit.MenuManager = this.barManager1;
            this.id_EspecieLookUpEdit.Name = "id_EspecieLookUpEdit";
            this.id_EspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name23")});
            this.id_EspecieLookUpEdit.Properties.NullText = "";
            this.id_EspecieLookUpEdit.Properties.ShowHeader = false;
            this.id_EspecieLookUpEdit.Size = new System.Drawing.Size(192, 20);
            this.id_EspecieLookUpEdit.TabIndex = 3;
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(106, 61);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Name20")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Properties.ShowHeader = false;
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(192, 20);
            this.id_SucursalLookUpEdit.TabIndex = 2;
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(106, 35);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name17")});
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(192, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 1;
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.listaPagosManagerBindingSource, "Lista.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(106, 9);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // frmListaPagos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 463);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(519, 423);
            this.Name = "frmListaPagos_AddMod";
            this.Text = "Alta/Modificación de Lista de Pagos";
            this.Load += new System.EventHandler(this.frmListaPagos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentidoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private System.Windows.Forms.BindingSource listaPagosManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_EspecieLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource detalleBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ListaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colListaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DropDownButton btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnItemPago;
        private DevExpress.XtraBars.BarButtonItem btnImportar;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit sentidoLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
    }
}