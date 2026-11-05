namespace VENET_Seguridad_UI
{
    partial class frmSeguridadGruposObjetos
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
            this.seguridadGruposObjetosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormulario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPermiso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnMarcar = new DevExpress.XtraBars.BarButtonItem();
            this.btnDesmarcar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnGruposAsignados = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadGruposObjetosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.seguridadGruposObjetosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(734, 437);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // seguridadGruposObjetosManager_SearchResultBindingSource
            // 
            this.seguridadGruposObjetosManager_SearchResultBindingSource.DataSource = typeof(VENET_Seguridad_BL.SeguridadGruposObjetosManager.SearchResult);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colId,
            this.colModulo,
            this.colFormulario,
            this.colPermiso});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModulo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFormulario, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPermiso, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSelected
            // 
            this.colSelected.Caption = "Seleccionado";
            this.colSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSelected.FieldName = "Selected";
            this.colSelected.MaxWidth = 76;
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 0;
            this.colSelected.Width = 76;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Width = 83;
            // 
            // colModulo
            // 
            this.colModulo.Caption = "Módulo";
            this.colModulo.FieldName = "Modulo";
            this.colModulo.Name = "colModulo";
            this.colModulo.OptionsColumn.AllowEdit = false;
            this.colModulo.OptionsColumn.ReadOnly = true;
            this.colModulo.Visible = true;
            this.colModulo.VisibleIndex = 1;
            this.colModulo.Width = 161;
            // 
            // colFormulario
            // 
            this.colFormulario.FieldName = "Formulario";
            this.colFormulario.Name = "colFormulario";
            this.colFormulario.OptionsColumn.AllowEdit = false;
            this.colFormulario.OptionsColumn.ReadOnly = true;
            this.colFormulario.Visible = true;
            this.colFormulario.VisibleIndex = 1;
            this.colFormulario.Width = 308;
            // 
            // colPermiso
            // 
            this.colPermiso.FieldName = "Permiso";
            this.colPermiso.Name = "colPermiso";
            this.colPermiso.OptionsColumn.AllowEdit = false;
            this.colPermiso.OptionsColumn.ReadOnly = true;
            this.colPermiso.Visible = true;
            this.colPermiso.VisibleIndex = 1;
            this.colPermiso.Width = 329;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
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
            this.barSubItem1,
            this.btnMarcar,
            this.btnDesmarcar,
            this.btnGuardar,
            this.barSubItem2,
            this.btnGruposAsignados});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
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
            this.bar2.Text = "Menú principal";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Seguridad_UI.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 1;
            this.barSubItem1.LargeGlyph = global::VENET_Seguridad_UI.Properties.Resources.properties_32x32;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMarcar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDesmarcar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardar, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnMarcar
            // 
            this.btnMarcar.Caption = "Marcar Módulo Completo";
            this.btnMarcar.Id = 2;
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMarcar_ItemClick);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Caption = "Desmarcar Módulo Completo";
            this.btnDesmarcar.Id = 3;
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDesmarcar_ItemClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 4;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Seguridad_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 5;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGruposAsignados)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnGruposAsignados
            // 
            this.btnGruposAsignados.Caption = "Grupos Asignados";
            this.btnGruposAsignados.Id = 6;
            this.btnGruposAsignados.Name = "btnGruposAsignados";
            this.btnGruposAsignados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGruposAsignados_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // frmSeguridadGruposObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmSeguridadGruposObjetos";

            this.Text = "frmSeguridadGruposObjetos";
            this.Load += new System.EventHandler(this.frmSeguridadGruposObjetos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seguridadGruposObjetosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colModulo;
        private DevExpress.XtraGrid.Columns.GridColumn colFormulario;
        private DevExpress.XtraGrid.Columns.GridColumn colPermiso;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnMarcar;
        private DevExpress.XtraBars.BarButtonItem btnDesmarcar;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private System.Windows.Forms.BindingSource seguridadGruposObjetosManager_SearchResultBindingSource;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnGruposAsignados;
    }
}