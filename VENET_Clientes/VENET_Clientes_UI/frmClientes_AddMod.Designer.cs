namespace VENET_Clientes_UI
{
    partial class frmClientes_AddMod
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
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label id_TipoIvaLabel;
            System.Windows.Forms.Label domicilioLabel;
            System.Windows.Forms.Label id_CodPostalLabel;
            System.Windows.Forms.Label cuitLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label id_ListaPrecioLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes_AddMod));
            System.Windows.Forms.Label id_FormaPagoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cuitTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.clientesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_CodPostalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.domicilioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoIvaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contactosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.id_ListaPrecioLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.btnGeneraCUIT = new System.Windows.Forms.Button();
            this.empresaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.emailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tpContactos = new DevExpress.XtraTab.XtraTabPage();
            this.tpDescuentos = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.descuentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_Cliente1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Categoria2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregarD = new System.Windows.Forms.Button();
            this.btnEliminarD = new System.Windows.Forms.Button();
            this.btnModificarD = new System.Windows.Forms.Button();
            this.tpEntrega = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.entregasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_Cliente2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorrado2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnAgregarE = new System.Windows.Forms.Button();
            this.btnEliminarE = new System.Windows.Forms.Button();
            this.btnModificarE = new System.Windows.Forms.Button();
            this.alicuotasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_FormaPagoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            nombreLabel = new System.Windows.Forms.Label();
            id_TipoIvaLabel = new System.Windows.Forms.Label();
            domicilioLabel = new System.Windows.Forms.Label();
            id_CodPostalLabel = new System.Windows.Forms.Label();
            cuitLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            id_ListaPrecioLabel = new System.Windows.Forms.Label();
            id_FormaPagoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuitTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CodPostalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domicilioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ListaPrecioLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).BeginInit();
            this.tpContactos.SuspendLayout();
            this.tpDescuentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tpEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entregasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alicuotasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_FormaPagoLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(30, 16);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            // 
            // id_TipoIvaLabel
            // 
            id_TipoIvaLabel.AutoSize = true;
            id_TipoIvaLabel.Location = new System.Drawing.Point(51, 146);
            id_TipoIvaLabel.Name = "id_TipoIvaLabel";
            id_TipoIvaLabel.Size = new System.Drawing.Size(27, 13);
            id_TipoIvaLabel.TabIndex = 39;
            id_TipoIvaLabel.Text = "Iva:";
            // 
            // domicilioLabel
            // 
            domicilioLabel.AutoSize = true;
            domicilioLabel.Location = new System.Drawing.Point(27, 68);
            domicilioLabel.Name = "domicilioLabel";
            domicilioLabel.Size = new System.Drawing.Size(51, 13);
            domicilioLabel.TabIndex = 40;
            domicilioLabel.Text = "Domicilio:";
            // 
            // id_CodPostalLabel
            // 
            id_CodPostalLabel.AutoSize = true;
            id_CodPostalLabel.Location = new System.Drawing.Point(16, 94);
            id_CodPostalLabel.Name = "id_CodPostalLabel";
            id_CodPostalLabel.Size = new System.Drawing.Size(62, 13);
            id_CodPostalLabel.TabIndex = 41;
            id_CodPostalLabel.Text = "Cod Postal:";
            // 
            // cuitLabel
            // 
            cuitLabel.AutoSize = true;
            cuitLabel.Location = new System.Drawing.Point(48, 120);
            cuitLabel.Name = "cuitLabel";
            cuitLabel.Size = new System.Drawing.Size(30, 13);
            cuitLabel.TabIndex = 42;
            cuitLabel.Text = "Cuit:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(43, 172);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 42;
            emailLabel.Text = "Email:";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new System.Drawing.Point(26, 42);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(52, 13);
            empresaLabel.TabIndex = 43;
            empresaLabel.Text = "Empresa:";
            // 
            // id_ListaPrecioLabel
            // 
            id_ListaPrecioLabel.AutoSize = true;
            id_ListaPrecioLabel.Location = new System.Drawing.Point(13, 198);
            id_ListaPrecioLabel.Name = "id_ListaPrecioLabel";
            id_ListaPrecioLabel.Size = new System.Drawing.Size(65, 13);
            id_ListaPrecioLabel.TabIndex = 44;
            id_ListaPrecioLabel.Text = "Lista Precio:";
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
            this.btnAceptar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Glyph")));
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(412, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 337);
            this.barDockControlBottom.Size = new System.Drawing.Size(412, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 313);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(412, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 313);
            // 
            // cuitTextEdit
            // 
            this.cuitTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Cuit", true));
            this.cuitTextEdit.EnterMoveNextControl = true;
            this.cuitTextEdit.Location = new System.Drawing.Point(84, 117);
            this.cuitTextEdit.MenuManager = this.barManager1;
            this.cuitTextEdit.Name = "cuitTextEdit";
            this.cuitTextEdit.Properties.Mask.EditMask = "00-00000000-0";
            this.cuitTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.cuitTextEdit.Size = new System.Drawing.Size(100, 20);
            this.cuitTextEdit.TabIndex = 4;
            // 
            // clientesManagerBindingSource
            // 
            this.clientesManagerBindingSource.DataSource = typeof(VENET_Clientes_BL.ClientesManager);
            // 
            // id_CodPostalLookUpEdit
            // 
            this.id_CodPostalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Id_CodPostal", true));
            this.id_CodPostalLookUpEdit.EnterMoveNextControl = true;
            this.id_CodPostalLookUpEdit.Location = new System.Drawing.Point(84, 91);
            this.id_CodPostalLookUpEdit.MenuManager = this.barManager1;
            this.id_CodPostalLookUpEdit.Name = "id_CodPostalLookUpEdit";
            this.id_CodPostalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CodPostalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodPostal", "Cod.Postal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Localidad", "Localidad"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Provincia", "Provincia")});
            this.id_CodPostalLookUpEdit.Properties.NullText = "";
            this.id_CodPostalLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_CodPostalLookUpEdit.TabIndex = 3;
            // 
            // domicilioTextEdit
            // 
            this.domicilioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Domicilio", true));
            this.domicilioTextEdit.EnterMoveNextControl = true;
            this.domicilioTextEdit.Location = new System.Drawing.Point(84, 65);
            this.domicilioTextEdit.MenuManager = this.barManager1;
            this.domicilioTextEdit.Name = "domicilioTextEdit";
            this.domicilioTextEdit.Properties.MaxLength = 100;
            this.domicilioTextEdit.Size = new System.Drawing.Size(278, 20);
            this.domicilioTextEdit.TabIndex = 2;
            // 
            // id_TipoIvaLookUpEdit
            // 
            this.id_TipoIvaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Id_TipoIva", true));
            this.id_TipoIvaLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoIvaLookUpEdit.Location = new System.Drawing.Point(84, 143);
            this.id_TipoIvaLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoIvaLookUpEdit.Name = "id_TipoIvaLookUpEdit";
            this.id_TipoIvaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoIvaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_TipoIvaLookUpEdit.Properties.NullText = "";
            this.id_TipoIvaLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoIvaLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_TipoIvaLookUpEdit.TabIndex = 6;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(374, 257);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Contactos";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.contactosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(370, 221);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contactosBindingSource
            // 
            this.contactosBindingSource.DataSource = typeof(VENET_DataEntity.ClientesContactos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_Cliente,
            this.colNombre,
            this.colTelefono1,
            this.colTelefono2,
            this.colEmail,
            this.colCliente,
            this.colBorrado,
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colId_Cliente
            // 
            this.colId_Cliente.FieldName = "Id_Cliente";
            this.colId_Cliente.Name = "colId_Cliente";
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            // 
            // colTelefono1
            // 
            this.colTelefono1.FieldName = "Telefono1";
            this.colTelefono1.Name = "colTelefono1";
            this.colTelefono1.Visible = true;
            this.colTelefono1.VisibleIndex = 1;
            // 
            // colTelefono2
            // 
            this.colTelefono2.FieldName = "Telefono2";
            this.colTelefono2.Name = "colTelefono2";
            this.colTelefono2.Visible = true;
            this.colTelefono2.VisibleIndex = 2;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 3;
            // 
            // colCliente
            // 
            this.colCliente.FieldName = "Cliente";
            this.colCliente.Name = "colCliente";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAgregar);
            this.panelControl1.Controls.Add(this.btnEliminar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 223);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(370, 32);
            this.panelControl1.TabIndex = 39;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(9, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "    Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(171, 6);
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
            this.btnModificar.Location = new System.Drawing.Point(90, 6);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "     Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Nombre", true));
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(84, 13);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Properties.MaxLength = 100;
            this.nombreTextEdit.Size = new System.Drawing.Size(278, 20);
            this.nombreTextEdit.TabIndex = 0;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpGeneral;
            this.xtraTabControl1.Size = new System.Drawing.Size(380, 285);
            this.xtraTabControl1.TabIndex = 43;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpGeneral,
            this.tpContactos,
            this.tpDescuentos,
            this.tpEntrega});
            // 
            // tpGeneral
            // 
            this.tpGeneral.AutoScroll = true;
            this.tpGeneral.Controls.Add(id_FormaPagoLabel);
            this.tpGeneral.Controls.Add(this.id_FormaPagoLookUpEdit);
            this.tpGeneral.Controls.Add(id_ListaPrecioLabel);
            this.tpGeneral.Controls.Add(this.id_ListaPrecioLookUpEdit);
            this.tpGeneral.Controls.Add(this.btnGeneraCUIT);
            this.tpGeneral.Controls.Add(empresaLabel);
            this.tpGeneral.Controls.Add(this.empresaTextEdit);
            this.tpGeneral.Controls.Add(emailLabel);
            this.tpGeneral.Controls.Add(this.emailTextEdit);
            this.tpGeneral.Controls.Add(nombreLabel);
            this.tpGeneral.Controls.Add(cuitLabel);
            this.tpGeneral.Controls.Add(this.nombreTextEdit);
            this.tpGeneral.Controls.Add(this.cuitTextEdit);
            this.tpGeneral.Controls.Add(this.id_TipoIvaLookUpEdit);
            this.tpGeneral.Controls.Add(id_CodPostalLabel);
            this.tpGeneral.Controls.Add(id_TipoIvaLabel);
            this.tpGeneral.Controls.Add(this.id_CodPostalLookUpEdit);
            this.tpGeneral.Controls.Add(this.domicilioTextEdit);
            this.tpGeneral.Controls.Add(domicilioLabel);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(374, 257);
            this.tpGeneral.Text = "General";
            // 
            // id_ListaPrecioLookUpEdit
            // 
            this.id_ListaPrecioLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Id_ListaPrecio", true));
            this.id_ListaPrecioLookUpEdit.Location = new System.Drawing.Point(84, 195);
            this.id_ListaPrecioLookUpEdit.MenuManager = this.barManager1;
            this.id_ListaPrecioLookUpEdit.Name = "id_ListaPrecioLookUpEdit";
            this.id_ListaPrecioLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ListaPrecioLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.id_ListaPrecioLookUpEdit.Properties.NullText = "";
            this.id_ListaPrecioLookUpEdit.Properties.ShowHeader = false;
            this.id_ListaPrecioLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_ListaPrecioLookUpEdit.TabIndex = 8;
            this.id_ListaPrecioLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_ListaPrecioLookUpEdit_ButtonPressed);
            // 
            // btnGeneraCUIT
            // 
            this.btnGeneraCUIT.Location = new System.Drawing.Point(190, 117);
            this.btnGeneraCUIT.Name = "btnGeneraCUIT";
            this.btnGeneraCUIT.Size = new System.Drawing.Size(42, 20);
            this.btnGeneraCUIT.TabIndex = 5;
            this.btnGeneraCUIT.Text = "CUIT";
            this.btnGeneraCUIT.UseVisualStyleBackColor = true;
            this.btnGeneraCUIT.Click += new System.EventHandler(this.btnGeneraCUIT_Click);
            // 
            // empresaTextEdit
            // 
            this.empresaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Empresa", true));
            this.empresaTextEdit.EnterMoveNextControl = true;
            this.empresaTextEdit.Location = new System.Drawing.Point(84, 39);
            this.empresaTextEdit.MenuManager = this.barManager1;
            this.empresaTextEdit.Name = "empresaTextEdit";
            this.empresaTextEdit.Size = new System.Drawing.Size(278, 20);
            this.empresaTextEdit.TabIndex = 1;
            // 
            // emailTextEdit
            // 
            this.emailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Email", true));
            this.emailTextEdit.EnterMoveNextControl = true;
            this.emailTextEdit.Location = new System.Drawing.Point(84, 169);
            this.emailTextEdit.MenuManager = this.barManager1;
            this.emailTextEdit.Name = "emailTextEdit";
            this.emailTextEdit.Size = new System.Drawing.Size(278, 20);
            this.emailTextEdit.TabIndex = 7;
            // 
            // tpContactos
            // 
            this.tpContactos.Controls.Add(this.groupControl2);
            this.tpContactos.Name = "tpContactos";
            this.tpContactos.Size = new System.Drawing.Size(374, 257);
            this.tpContactos.Text = "Contactos";
            // 
            // tpDescuentos
            // 
            this.tpDescuentos.Controls.Add(this.groupControl3);
            this.tpDescuentos.Name = "tpDescuentos";
            this.tpDescuentos.Size = new System.Drawing.Size(374, 257);
            this.tpDescuentos.Text = "Descuentos";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Controls.Add(this.panelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(374, 257);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Contactos";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.descuentosBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(370, 221);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // descuentosBindingSource
            // 
            this.descuentosBindingSource.DataSource = typeof(VENET_DataEntity.ClientesDescuentos);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_Cliente1,
            this.colId_Categoria2,
            this.colDescuento,
            this.colCliente1,
            this.colBorrado1,
            this.colCategoria,
            this.colId1,
            this.colFechaAdd1,
            this.colFechaMod1,
            this.colUserAdd1,
            this.colUserMod1});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // colId_Cliente1
            // 
            this.colId_Cliente1.FieldName = "Id_Cliente";
            this.colId_Cliente1.Name = "colId_Cliente1";
            // 
            // colId_Categoria2
            // 
            this.colId_Categoria2.FieldName = "Id_Categoria2";
            this.colId_Categoria2.Name = "colId_Categoria2";
            // 
            // colDescuento
            // 
            this.colDescuento.DisplayFormat.FormatString = "n";
            this.colDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDescuento.FieldName = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.Visible = true;
            this.colDescuento.VisibleIndex = 1;
            this.colDescuento.Width = 138;
            // 
            // colCliente1
            // 
            this.colCliente1.FieldName = "Cliente";
            this.colCliente1.Name = "colCliente1";
            // 
            // colBorrado1
            // 
            this.colBorrado1.FieldName = "Borrado";
            this.colBorrado1.Name = "colBorrado1";
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoría";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 0;
            this.colCategoria.Width = 214;
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            // 
            // colFechaAdd1
            // 
            this.colFechaAdd1.FieldName = "FechaAdd";
            this.colFechaAdd1.Name = "colFechaAdd1";
            // 
            // colFechaMod1
            // 
            this.colFechaMod1.FieldName = "FechaMod";
            this.colFechaMod1.Name = "colFechaMod1";
            // 
            // colUserAdd1
            // 
            this.colUserAdd1.FieldName = "UserAdd";
            this.colUserAdd1.Name = "colUserAdd1";
            // 
            // colUserMod1
            // 
            this.colUserMod1.FieldName = "UserMod";
            this.colUserMod1.Name = "colUserMod1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnAgregarD);
            this.panelControl2.Controls.Add(this.btnEliminarD);
            this.panelControl2.Controls.Add(this.btnModificarD);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 223);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(370, 32);
            this.panelControl2.TabIndex = 39;
            // 
            // btnAgregarD
            // 
            this.btnAgregarD.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarD.Image")));
            this.btnAgregarD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarD.Location = new System.Drawing.Point(9, 6);
            this.btnAgregarD.Name = "btnAgregarD";
            this.btnAgregarD.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarD.TabIndex = 3;
            this.btnAgregarD.Text = "    Agregar";
            this.btnAgregarD.Click += new System.EventHandler(this.btnAgregarD_Click);
            // 
            // btnEliminarD
            // 
            this.btnEliminarD.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarD.Image")));
            this.btnEliminarD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarD.Location = new System.Drawing.Point(171, 6);
            this.btnEliminarD.Name = "btnEliminarD";
            this.btnEliminarD.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarD.TabIndex = 2;
            this.btnEliminarD.Text = "    Eliminar";
            this.btnEliminarD.Click += new System.EventHandler(this.btnEliminarD_Click);
            // 
            // btnModificarD
            // 
            this.btnModificarD.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarD.Image")));
            this.btnModificarD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarD.Location = new System.Drawing.Point(90, 6);
            this.btnModificarD.Name = "btnModificarD";
            this.btnModificarD.Size = new System.Drawing.Size(75, 23);
            this.btnModificarD.TabIndex = 1;
            this.btnModificarD.Text = "     Modificar";
            this.btnModificarD.Click += new System.EventHandler(this.btnModificarD_Click);
            // 
            // tpEntrega
            // 
            this.tpEntrega.Controls.Add(this.gridControl3);
            this.tpEntrega.Controls.Add(this.panelControl3);
            this.tpEntrega.Name = "tpEntrega";
            this.tpEntrega.Size = new System.Drawing.Size(374, 257);
            this.tpEntrega.Text = "Domicilio Entrega";
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.entregasBindingSource;
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.MenuManager = this.barManager1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(374, 225);
            this.gridControl3.TabIndex = 40;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // entregasBindingSource
            // 
            this.entregasBindingSource.DataSource = typeof(VENET_DataEntity.ClientesEntregas);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_Cliente2,
            this.colNombre1,
            this.colDireccion,
            this.colTelefono,
            this.colEmail1,
            this.colCliente2,
            this.colBorrado2,
            this.colId2,
            this.colFechaAdd2,
            this.colFechaMod2,
            this.colUserAdd2,
            this.colUserMod2});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colId_Cliente2
            // 
            this.colId_Cliente2.FieldName = "Id_Cliente";
            this.colId_Cliente2.Name = "colId_Cliente2";
            // 
            // colNombre1
            // 
            this.colNombre1.FieldName = "Nombre";
            this.colNombre1.Name = "colNombre1";
            this.colNombre1.Visible = true;
            this.colNombre1.VisibleIndex = 0;
            // 
            // colDireccion
            // 
            this.colDireccion.Caption = "Dirección";
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 1;
            // 
            // colTelefono
            // 
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 2;
            // 
            // colEmail1
            // 
            this.colEmail1.FieldName = "Email";
            this.colEmail1.Name = "colEmail1";
            this.colEmail1.Visible = true;
            this.colEmail1.VisibleIndex = 3;
            // 
            // colCliente2
            // 
            this.colCliente2.FieldName = "Cliente";
            this.colCliente2.Name = "colCliente2";
            // 
            // colBorrado2
            // 
            this.colBorrado2.FieldName = "Borrado";
            this.colBorrado2.Name = "colBorrado2";
            // 
            // colId2
            // 
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            // 
            // colFechaAdd2
            // 
            this.colFechaAdd2.FieldName = "FechaAdd";
            this.colFechaAdd2.Name = "colFechaAdd2";
            // 
            // colFechaMod2
            // 
            this.colFechaMod2.FieldName = "FechaMod";
            this.colFechaMod2.Name = "colFechaMod2";
            // 
            // colUserAdd2
            // 
            this.colUserAdd2.FieldName = "UserAdd";
            this.colUserAdd2.Name = "colUserAdd2";
            // 
            // colUserMod2
            // 
            this.colUserMod2.FieldName = "UserMod";
            this.colUserMod2.Name = "colUserMod2";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAgregarE);
            this.panelControl3.Controls.Add(this.btnEliminarE);
            this.panelControl3.Controls.Add(this.btnModificarE);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 225);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(374, 32);
            this.panelControl3.TabIndex = 41;
            // 
            // btnAgregarE
            // 
            this.btnAgregarE.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarE.Image")));
            this.btnAgregarE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarE.Location = new System.Drawing.Point(9, 6);
            this.btnAgregarE.Name = "btnAgregarE";
            this.btnAgregarE.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarE.TabIndex = 3;
            this.btnAgregarE.Text = "    Agregar";
            this.btnAgregarE.Click += new System.EventHandler(this.btnAgregarE_Click);
            // 
            // btnEliminarE
            // 
            this.btnEliminarE.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarE.Image")));
            this.btnEliminarE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarE.Location = new System.Drawing.Point(171, 6);
            this.btnEliminarE.Name = "btnEliminarE";
            this.btnEliminarE.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarE.TabIndex = 2;
            this.btnEliminarE.Text = "    Eliminar";
            this.btnEliminarE.Click += new System.EventHandler(this.btnEliminarE_Click);
            // 
            // btnModificarE
            // 
            this.btnModificarE.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarE.Image")));
            this.btnModificarE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarE.Location = new System.Drawing.Point(90, 6);
            this.btnModificarE.Name = "btnModificarE";
            this.btnModificarE.Size = new System.Drawing.Size(75, 23);
            this.btnModificarE.TabIndex = 1;
            this.btnModificarE.Text = "     Modificar";
            this.btnModificarE.Click += new System.EventHandler(this.btnModificarE_Click);
            // 
            // alicuotasBindingSource
            // 
            this.alicuotasBindingSource.DataSource = typeof(VENET_DataEntity.EntidadesImpuestoAlicuotas);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.xtraTabControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(388, 295);
            this.groupControl1.TabIndex = 0;
            // 
            // id_FormaPagoLabel
            // 
            id_FormaPagoLabel.AutoSize = true;
            id_FormaPagoLabel.Location = new System.Drawing.Point(10, 224);
            id_FormaPagoLabel.Name = "id_FormaPagoLabel";
            id_FormaPagoLabel.Size = new System.Drawing.Size(68, 13);
            id_FormaPagoLabel.TabIndex = 45;
            id_FormaPagoLabel.Text = "Forma Pago:";
            // 
            // id_FormaPagoLookUpEdit
            // 
            this.id_FormaPagoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesManagerBindingSource, "Cliente.Id_FormaPago", true));
            this.id_FormaPagoLookUpEdit.Location = new System.Drawing.Point(84, 221);
            this.id_FormaPagoLookUpEdit.MenuManager = this.barManager1;
            this.id_FormaPagoLookUpEdit.Name = "id_FormaPagoLookUpEdit";
            this.id_FormaPagoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_FormaPagoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_FormaPagoLookUpEdit.Properties.NullText = "";
            this.id_FormaPagoLookUpEdit.Properties.ShowHeader = false;
            this.id_FormaPagoLookUpEdit.Size = new System.Drawing.Size(278, 20);
            this.id_FormaPagoLookUpEdit.TabIndex = 9;
            this.id_FormaPagoLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_ListaPrecioLookUpEdit_ButtonPressed);
            // 
            // frmClientes_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(412, 337);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(428, 376);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(428, 376);
            this.Name = "frmClientes_AddMod";
            this.Text = "Alta/Modificación de Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClientes_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmClientes_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuitTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CodPostalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domicilioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ListaPrecioLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailTextEdit.Properties)).EndInit();
            this.tpContactos.ResumeLayout(false);
            this.tpDescuentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tpEntrega.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entregasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alicuotasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id_FormaPagoLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private System.Windows.Forms.BindingSource clientesManagerBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource contactosBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono1;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono2;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private DevExpress.XtraEditors.LookUpEdit id_TipoIvaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit cuitTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CodPostalLookUpEdit;
        private DevExpress.XtraEditors.TextEdit domicilioTextEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpContactos;
        private System.Windows.Forms.BindingSource alicuotasBindingSource;
        private DevExpress.XtraEditors.TextEdit emailTextEdit;
        private DevExpress.XtraEditors.TextEdit empresaTextEdit;
        private DevExpress.XtraTab.XtraTabPage tpDescuentos;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnAgregarD;
        private System.Windows.Forms.Button btnEliminarD;
        private System.Windows.Forms.Button btnModificarD;
        private System.Windows.Forms.BindingSource descuentosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Cliente1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Categoria2;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente1;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado1;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod1;
        private DevExpress.XtraTab.XtraTabPage tpEntrega;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private System.Windows.Forms.BindingSource entregasBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Cliente2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre1;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail1;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente2;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrado2;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd2;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Button btnAgregarE;
        private System.Windows.Forms.Button btnEliminarE;
        private System.Windows.Forms.Button btnModificarE;
        private System.Windows.Forms.Button btnGeneraCUIT;
        private DevExpress.XtraEditors.LookUpEdit id_ListaPrecioLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_FormaPagoLookUpEdit;
    }
}