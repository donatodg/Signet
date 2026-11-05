namespace VENET_Personal_Sisorg
{
    partial class frmWebServicesSisorg
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.webServicesSisorg_resultInsertBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colparametros_ope = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colemail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colapellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldocNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldocTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgremioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltelMovil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colempleador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJerarquia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnInsert = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServicesSisorg_resultInsertBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.webServicesSisorg_resultInsertBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(734, 412);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // webServicesSisorg_resultInsertBindingSource
            // 
            this.webServicesSisorg_resultInsertBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.webServicesSisorg_resultInsertBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado,
            this.colparametros_ope,
            this.colid,
            this.collegajo,
            this.colcategoria,
            this.colemail,
            this.colapellido,
            this.colnombre,
            this.colestado,
            this.coldocNro,
            this.coldocTipo,
            this.colbus,
            this.colgremioID,
            this.coltel,
            this.coltelMovil,
            this.colempleador,
            this.colEmpresa,
            this.colJerarquia});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            this.colSeleccionado.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colparametros_ope
            // 
            this.colparametros_ope.FieldName = "parametros_ope";
            this.colparametros_ope.Name = "colparametros_ope";
            this.colparametros_ope.OptionsColumn.AllowEdit = false;
            this.colparametros_ope.OptionsColumn.ReadOnly = true;
            this.colparametros_ope.Width = 41;
            // 
            // colid
            // 
            this.colid.Caption = "Id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.AllowEdit = false;
            this.colid.OptionsColumn.ReadOnly = true;
            this.colid.Width = 41;
            // 
            // collegajo
            // 
            this.collegajo.Caption = "Legajo";
            this.collegajo.FieldName = "legajo";
            this.collegajo.Name = "collegajo";
            this.collegajo.OptionsColumn.AllowEdit = false;
            this.collegajo.OptionsColumn.ReadOnly = true;
            this.collegajo.Visible = true;
            this.collegajo.VisibleIndex = 1;
            this.collegajo.Width = 63;
            // 
            // colcategoria
            // 
            this.colcategoria.Caption = "Categoría";
            this.colcategoria.FieldName = "categoria";
            this.colcategoria.Name = "colcategoria";
            this.colcategoria.OptionsColumn.AllowEdit = false;
            this.colcategoria.OptionsColumn.ReadOnly = true;
            this.colcategoria.Width = 41;
            // 
            // colemail
            // 
            this.colemail.Caption = "Email";
            this.colemail.FieldName = "email";
            this.colemail.Name = "colemail";
            this.colemail.OptionsColumn.AllowEdit = false;
            this.colemail.OptionsColumn.ReadOnly = true;
            this.colemail.Width = 41;
            // 
            // colapellido
            // 
            this.colapellido.Caption = "Apellido";
            this.colapellido.FieldName = "apellido";
            this.colapellido.Name = "colapellido";
            this.colapellido.OptionsColumn.AllowEdit = false;
            this.colapellido.OptionsColumn.ReadOnly = true;
            this.colapellido.Visible = true;
            this.colapellido.VisibleIndex = 2;
            this.colapellido.Width = 90;
            // 
            // colnombre
            // 
            this.colnombre.Caption = "Nombre";
            this.colnombre.FieldName = "nombre";
            this.colnombre.Name = "colnombre";
            this.colnombre.OptionsColumn.AllowEdit = false;
            this.colnombre.OptionsColumn.ReadOnly = true;
            this.colnombre.Visible = true;
            this.colnombre.VisibleIndex = 3;
            this.colnombre.Width = 99;
            // 
            // colestado
            // 
            this.colestado.Caption = "Estado";
            this.colestado.FieldName = "estado";
            this.colestado.Name = "colestado";
            this.colestado.OptionsColumn.AllowEdit = false;
            this.colestado.OptionsColumn.ReadOnly = true;
            this.colestado.Width = 41;
            // 
            // coldocNro
            // 
            this.coldocNro.Caption = "Nro. Doc.";
            this.coldocNro.FieldName = "docNro";
            this.coldocNro.Name = "coldocNro";
            this.coldocNro.OptionsColumn.AllowEdit = false;
            this.coldocNro.OptionsColumn.ReadOnly = true;
            this.coldocNro.Visible = true;
            this.coldocNro.VisibleIndex = 5;
            this.coldocNro.Width = 74;
            // 
            // coldocTipo
            // 
            this.coldocTipo.Caption = "Tipo Doc.";
            this.coldocTipo.FieldName = "docTipo";
            this.coldocTipo.Name = "coldocTipo";
            this.coldocTipo.OptionsColumn.AllowEdit = false;
            this.coldocTipo.OptionsColumn.ReadOnly = true;
            this.coldocTipo.Width = 41;
            // 
            // colbus
            // 
            this.colbus.Caption = "Bus";
            this.colbus.FieldName = "bus";
            this.colbus.Name = "colbus";
            this.colbus.OptionsColumn.AllowEdit = false;
            this.colbus.OptionsColumn.ReadOnly = true;
            this.colbus.Width = 41;
            // 
            // colgremioID
            // 
            this.colgremioID.Caption = "Gremio Id";
            this.colgremioID.FieldName = "gremioID";
            this.colgremioID.Name = "colgremioID";
            this.colgremioID.OptionsColumn.AllowEdit = false;
            this.colgremioID.OptionsColumn.ReadOnly = true;
            this.colgremioID.Width = 41;
            // 
            // coltel
            // 
            this.coltel.Caption = "Telefono";
            this.coltel.FieldName = "tel";
            this.coltel.Name = "coltel";
            this.coltel.OptionsColumn.AllowEdit = false;
            this.coltel.OptionsColumn.ReadOnly = true;
            this.coltel.Visible = true;
            this.coltel.VisibleIndex = 6;
            this.coltel.Width = 78;
            // 
            // coltelMovil
            // 
            this.coltelMovil.Caption = "Tel Movil";
            this.coltelMovil.FieldName = "telMovil";
            this.coltelMovil.Name = "coltelMovil";
            this.coltelMovil.OptionsColumn.AllowEdit = false;
            this.coltelMovil.OptionsColumn.ReadOnly = true;
            this.coltelMovil.Width = 41;
            // 
            // colempleador
            // 
            this.colempleador.Caption = "Empleador";
            this.colempleador.FieldName = "empleador";
            this.colempleador.Name = "colempleador";
            this.colempleador.OptionsColumn.AllowEdit = false;
            this.colempleador.OptionsColumn.ReadOnly = true;
            this.colempleador.Width = 67;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 7;
            this.colEmpresa.Width = 152;
            // 
            // colJerarquia
            // 
            this.colJerarquia.Caption = "Jerarquía";
            this.colJerarquia.FieldName = "Jerarquia";
            this.colJerarquia.Name = "colJerarquia";
            this.colJerarquia.OptionsColumn.AllowEdit = false;
            this.colJerarquia.OptionsColumn.ReadOnly = true;
            this.colJerarquia.Visible = true;
            this.colJerarquia.VisibleIndex = 4;
            this.colJerarquia.Width = 80;
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
            this.barSubItem1,
            this.btnInsert,
            this.btnSalir,
            this.barSubItem2,
            this.btnResultado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Personal_Sisorg.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 1;
            this.barSubItem1.LargeGlyph = global::VENET_Personal_Sisorg.Properties.Resources.properties_32x32;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInsert),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnInsert
            // 
            this.btnInsert.Caption = "Insertar Personal Seleccionado";
            this.btnInsert.Id = 2;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 3;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_Personal_Sisorg.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 4;
            this.barSubItem2.LargeGlyph = global::VENET_Personal_Sisorg.Properties.Resources.print_32x32;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 5;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
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
            // frmWebServicesSisorg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.Name = "frmWebServicesSisorg";
            this.Text = "Traspaso Personal a Sisorg";
            this.Load += new System.EventHandler(this.frmWebServicesSisorg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServicesSisorg_resultInsertBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnInsert;
        private DevExpress.XtraBars.BarButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource webServicesSisorg_resultInsertBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colparametros_ope;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn collegajo;
        private DevExpress.XtraGrid.Columns.GridColumn colcategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colemail;
        private DevExpress.XtraGrid.Columns.GridColumn colapellido;
        private DevExpress.XtraGrid.Columns.GridColumn colnombre;
        private DevExpress.XtraGrid.Columns.GridColumn colestado;
        private DevExpress.XtraGrid.Columns.GridColumn coldocNro;
        private DevExpress.XtraGrid.Columns.GridColumn coldocTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colbus;
        private DevExpress.XtraGrid.Columns.GridColumn colgremioID;
        private DevExpress.XtraGrid.Columns.GridColumn coltel;
        private DevExpress.XtraGrid.Columns.GridColumn coltelMovil;
        private DevExpress.XtraGrid.Columns.GridColumn colempleador;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colJerarquia;
    }
}