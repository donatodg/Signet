namespace VENET_Gestion_UI
{
    partial class frmProductosListasPreciosImprimir
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.productosListasPreciosImprimirManager_ClientesMailSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosListasPreciosImprimirManager_CategoriasSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.SelecCategorias = new DevExpress.XtraBars.BarButtonItem();
            this.DesSelectCategorias = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.SelectClientes = new DevExpress.XtraBars.BarButtonItem();
            this.DesSelectClientes = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosListasPreciosImprimirManager_ClientesMailSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosListasPreciosImprimirManager_CategoriasSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.barSubItem1,
            this.SelecCategorias,
            this.DesSelectCategorias,
            this.barButtonItem3,
            this.SelectClientes,
            this.DesSelectClientes});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(423, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 402);
            this.barDockControlBottom.Size = new System.Drawing.Size(423, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 378);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(423, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 378);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(399, 364);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Location = new System.Drawing.Point(16, 150);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(369, 198);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Enviar por Email";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.productosListasPreciosImprimirManager_ClientesMailSelectBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 20);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(365, 176);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // productosListasPreciosImprimirManager_ClientesMailSelectBindingSource
            // 
            this.productosListasPreciosImprimirManager_ClientesMailSelectBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosListasPreciosImprimirManager.ClientesMailSelect);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado1,
            this.colId1,
            this.colNombre,
            this.colEmail});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colSeleccionado1
            // 
            this.colSeleccionado1.FieldName = "Seleccionado";
            this.colSeleccionado1.Name = "colSeleccionado1";
            this.colSeleccionado1.Visible = true;
            this.colSeleccionado1.VisibleIndex = 0;
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            this.colNombre.Width = 136;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 2;
            this.colEmail.Width = 137;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(16, 13);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(369, 127);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Categorías";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosListasPreciosImprimirManager_CategoriasSelectBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(365, 105);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosListasPreciosImprimirManager_CategoriasSelectBindingSource
            // 
            this.productosListasPreciosImprimirManager_CategoriasSelectBindingSource.DataSource = typeof(VENET_Gestion_BL.ProductosListasPreciosImprimirManager.CategoriasSelect);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado,
            this.colId,
            this.colDescripcion});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 273;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.SelecCategorias),
            new DevExpress.XtraBars.LinkPersistInfo(this.DesSelectCategorias),
            new DevExpress.XtraBars.LinkPersistInfo(this.SelectClientes, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.DesSelectClientes)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // SelecCategorias
            // 
            this.SelecCategorias.Caption = "Seleccionar Categorias";
            this.SelecCategorias.Id = 2;
            this.SelecCategorias.Name = "SelecCategorias";
            this.SelecCategorias.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SelecCategorias_ItemClick);
            // 
            // DesSelectCategorias
            // 
            this.DesSelectCategorias.Caption = "DesSeleccionar Categorías";
            this.DesSelectCategorias.Id = 3;
            this.DesSelectCategorias.Name = "DesSelectCategorias";
            this.DesSelectCategorias.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DesSelectCategorias_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // SelectClientes
            // 
            this.SelectClientes.Caption = "Seleccionar Clientes";
            this.SelectClientes.Id = 5;
            this.SelectClientes.Name = "SelectClientes";
            this.SelectClientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SelectClientes_ItemClick);
            // 
            // DesSelectClientes
            // 
            this.DesSelectClientes.Caption = "DesSeleccionar Clientes";
            this.DesSelectClientes.Id = 6;
            this.DesSelectClientes.Name = "DesSelectClientes";
            this.DesSelectClientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DesSelectClientes_ItemClick);
            // 
            // frmProductosListasPreciosImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 402);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 441);
            this.Name = "frmProductosListasPreciosImprimir";
            this.Text = "Listas de Precios";
            this.Load += new System.EventHandler(this.frmProductosListasPreciosImprimir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosListasPreciosImprimirManager_ClientesMailSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosListasPreciosImprimirManager_CategoriasSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource productosListasPreciosImprimirManager_ClientesMailSelectBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado1;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private System.Windows.Forms.BindingSource productosListasPreciosImprimirManager_CategoriasSelectBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem SelecCategorias;
        private DevExpress.XtraBars.BarButtonItem DesSelectCategorias;
        private DevExpress.XtraBars.BarButtonItem SelectClientes;
        private DevExpress.XtraBars.BarButtonItem DesSelectClientes;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}