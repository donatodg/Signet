namespace VENET_Tesoreria_UI
{
    partial class frmValesTransferencia
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
            System.Windows.Forms.Label id_CajaOrigenLabel;
            System.Windows.Forms.Label id_CajaDestinoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_CajaDestinoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.valesTransferenciaManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_CajaOrigenLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.valesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripción = new DevExpress.XtraGrid.Columns.GridColumn();
            id_CajaOrigenLabel = new System.Windows.Forms.Label();
            id_CajaDestinoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaDestinoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesTransferenciaManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaOrigenLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // id_CajaOrigenLabel
            // 
            id_CajaOrigenLabel.AutoSize = true;
            id_CajaOrigenLabel.Location = new System.Drawing.Point(19, 13);
            id_CajaOrigenLabel.Name = "id_CajaOrigenLabel";
            id_CajaOrigenLabel.Size = new System.Drawing.Size(68, 13);
            id_CajaOrigenLabel.TabIndex = 1;
            id_CajaOrigenLabel.Text = "Caja Origen:";
            // 
            // id_CajaDestinoLabel
            // 
            id_CajaDestinoLabel.AutoSize = true;
            id_CajaDestinoLabel.Location = new System.Drawing.Point(15, 39);
            id_CajaDestinoLabel.Name = "id_CajaDestinoLabel";
            id_CajaDestinoLabel.Size = new System.Drawing.Size(72, 13);
            id_CajaDestinoLabel.TabIndex = 3;
            id_CajaDestinoLabel.Text = "Caja Destino:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(484, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 416);
            this.barDockControlBottom.Size = new System.Drawing.Size(484, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(484, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_CajaDestinoLabel);
            this.groupControl1.Controls.Add(this.id_CajaDestinoLookUpEdit);
            this.groupControl1.Controls.Add(id_CajaOrigenLabel);
            this.groupControl1.Controls.Add(this.id_CajaOrigenLookUpEdit);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(460, 378);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_CajaDestinoLookUpEdit
            // 
            this.id_CajaDestinoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesTransferenciaManagerBindingSource, "ValeTrans.Id_CajaDestino", true));
            this.id_CajaDestinoLookUpEdit.Location = new System.Drawing.Point(87, 36);
            this.id_CajaDestinoLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaDestinoLookUpEdit.Name = "id_CajaDestinoLookUpEdit";
            this.id_CajaDestinoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CajaDestinoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaDestinoLookUpEdit.Properties.NullText = "";
            this.id_CajaDestinoLookUpEdit.Size = new System.Drawing.Size(357, 20);
            this.id_CajaDestinoLookUpEdit.TabIndex = 4;
            // 
            // valesTransferenciaManagerBindingSource
            // 
            this.valesTransferenciaManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ValesTransferenciaManager);
            // 
            // id_CajaOrigenLookUpEdit
            // 
            this.id_CajaOrigenLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesTransferenciaManagerBindingSource, "ValeTrans.Id_CajaOrigen", true));
            this.id_CajaOrigenLookUpEdit.Location = new System.Drawing.Point(87, 10);
            this.id_CajaOrigenLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaOrigenLookUpEdit.Name = "id_CajaOrigenLookUpEdit";
            this.id_CajaOrigenLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CajaOrigenLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaOrigenLookUpEdit.Properties.NullText = "";
            this.id_CajaOrigenLookUpEdit.Size = new System.Drawing.Size(357, 20);
            this.id_CajaOrigenLookUpEdit.TabIndex = 2;
            this.id_CajaOrigenLookUpEdit.EditValueChanged += new System.EventHandler(this.id_CajaOrigenLookUpEdit_EditValueChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(14, 62);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(430, 299);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Vales";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.valesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(426, 277);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // valesBindingSource
            // 
            this.valesBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ListaVales);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado,
            this.colId,
            this.colNumero,
            this.colFecha,
            this.colId_Personal,
            this.colPersonal,
            this.colLegajo,
            this.colDescripción});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.VisibleIndex = 0;
            this.colSeleccionado.Width = 43;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.ReadOnly = true;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 1;
            this.colNumero.Width = 72;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 72;
            // 
            // colId_Personal
            // 
            this.colId_Personal.FieldName = "Id_Personal";
            this.colId_Personal.Name = "colId_Personal";
            this.colId_Personal.OptionsColumn.ReadOnly = true;
            // 
            // colPersonal
            // 
            this.colPersonal.FieldName = "Personal";
            this.colPersonal.Name = "colPersonal";
            this.colPersonal.OptionsColumn.ReadOnly = true;
            this.colPersonal.Visible = true;
            this.colPersonal.VisibleIndex = 4;
            this.colPersonal.Width = 72;
            // 
            // colLegajo
            // 
            this.colLegajo.FieldName = "Legajo";
            this.colLegajo.Name = "colLegajo";
            this.colLegajo.OptionsColumn.ReadOnly = true;
            this.colLegajo.Visible = true;
            this.colLegajo.VisibleIndex = 3;
            this.colLegajo.Width = 72;
            // 
            // colDescripción
            // 
            this.colDescripción.FieldName = "Descripción";
            this.colDescripción.Name = "colDescripción";
            this.colDescripción.OptionsColumn.ReadOnly = true;
            this.colDescripción.Visible = true;
            this.colDescripción.VisibleIndex = 5;
            this.colDescripción.Width = 77;
            // 
            // frmValesTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 416);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.Name = "frmValesTransferencia";
            this.Text = "Transferencia de Vales";
            this.Load += new System.EventHandler(this.frmValesTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaDestinoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesTransferenciaManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaOrigenLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit id_CajaDestinoLookUpEdit;
        private System.Windows.Forms.BindingSource valesTransferenciaManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_CajaOrigenLookUpEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource valesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonal;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripción;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}