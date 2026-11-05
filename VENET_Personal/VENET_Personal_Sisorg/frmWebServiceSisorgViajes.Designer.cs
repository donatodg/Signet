namespace VENET_Personal_Sisorg
{
    partial class frmWebServiceSisorgViajes
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
            System.Windows.Forms.Label fecha_DesdeLabel;
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.webServicesSisorg_resultViajesBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colViajeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoViaje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminalOrigenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminalDestinoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminalOrigenNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminalDestinoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidadOrigenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidadDestinoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidadOrigenNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidadDestinoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicioCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoriaNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoriaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLongitudRecorrido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPartida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaArribo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSentido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLongitudTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CodigoServicioVuelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Coche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajoPersonal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajoPersonal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajoPersonal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnProcesar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.colResultado = new DevExpress.XtraGrid.Columns.GridColumn();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServicesSisorg_resultViajesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(12, 10);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(40, 13);
            fecha_DesdeLabel.TabIndex = 5;
            fecha_DesdeLabel.Text = "Fecha:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(58, 7);
            this.fecha_HastaDateEdit.Name = "fecha_HastaDateEdit";
            this.fecha_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_HastaDateEdit.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.webServicesSisorg_resultViajesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(734, 412);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // webServicesSisorg_resultViajesBindingSource
            // 
            this.webServicesSisorg_resultViajesBindingSource.DataSource = typeof(VENET_Personal_Sisorg.WebServicesSisorg.resultViajes);
            this.webServicesSisorg_resultViajesBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.webServicesSisorg_resultViajesBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionado,
            this.colViajeID,
            this.colTipoViaje,
            this.colTerminalOrigenID,
            this.colTerminalDestinoID,
            this.colTerminalOrigenNombre,
            this.colTerminalDestinoNombre,
            this.colLocalidadOrigenID,
            this.colLocalidadDestinoID,
            this.colLocalidadOrigenNombre,
            this.colLocalidadDestinoNombre,
            this.colEmpresaID,
            this.colEmpresaCodigo,
            this.colServicioID,
            this.colServicioCodigo,
            this.colCategoriaNombre,
            this.colCategoriaID,
            this.colTipoLinea,
            this.colLongitudRecorrido,
            this.colFechaPartida,
            this.colFechaArribo,
            this.colSentido,
            this.colLongitudTotal,
            this.colId_CodigoServicioVuelta,
            this.colId_Coche,
            this.colId_Personal1,
            this.colId_Personal2,
            this.colId_Personal3,
            this.colInterno,
            this.colLegajoPersonal1,
            this.colLegajoPersonal2,
            this.colLegajoPersonal3,
            this.colResultado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.MaxWidth = 80;
            this.colSeleccionado.MinWidth = 80;
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
            // colViajeID
            // 
            this.colViajeID.FieldName = "ViajeID";
            this.colViajeID.Name = "colViajeID";
            this.colViajeID.OptionsColumn.AllowEdit = false;
            this.colViajeID.OptionsColumn.ReadOnly = true;
            this.colViajeID.Width = 20;
            // 
            // colTipoViaje
            // 
            this.colTipoViaje.FieldName = "TipoViaje";
            this.colTipoViaje.Name = "colTipoViaje";
            this.colTipoViaje.OptionsColumn.AllowEdit = false;
            this.colTipoViaje.OptionsColumn.ReadOnly = true;
            this.colTipoViaje.Width = 20;
            // 
            // colTerminalOrigenID
            // 
            this.colTerminalOrigenID.FieldName = "TerminalOrigenID";
            this.colTerminalOrigenID.Name = "colTerminalOrigenID";
            this.colTerminalOrigenID.OptionsColumn.AllowEdit = false;
            this.colTerminalOrigenID.OptionsColumn.ReadOnly = true;
            this.colTerminalOrigenID.Width = 20;
            // 
            // colTerminalDestinoID
            // 
            this.colTerminalDestinoID.FieldName = "TerminalDestinoID";
            this.colTerminalDestinoID.Name = "colTerminalDestinoID";
            this.colTerminalDestinoID.OptionsColumn.AllowEdit = false;
            this.colTerminalDestinoID.OptionsColumn.ReadOnly = true;
            this.colTerminalDestinoID.Width = 20;
            // 
            // colTerminalOrigenNombre
            // 
            this.colTerminalOrigenNombre.FieldName = "TerminalOrigenNombre";
            this.colTerminalOrigenNombre.Name = "colTerminalOrigenNombre";
            this.colTerminalOrigenNombre.OptionsColumn.AllowEdit = false;
            this.colTerminalOrigenNombre.OptionsColumn.ReadOnly = true;
            this.colTerminalOrigenNombre.Visible = true;
            this.colTerminalOrigenNombre.VisibleIndex = 2;
            this.colTerminalOrigenNombre.Width = 67;
            // 
            // colTerminalDestinoNombre
            // 
            this.colTerminalDestinoNombre.FieldName = "TerminalDestinoNombre";
            this.colTerminalDestinoNombre.Name = "colTerminalDestinoNombre";
            this.colTerminalDestinoNombre.OptionsColumn.AllowEdit = false;
            this.colTerminalDestinoNombre.OptionsColumn.ReadOnly = true;
            this.colTerminalDestinoNombre.Visible = true;
            this.colTerminalDestinoNombre.VisibleIndex = 3;
            this.colTerminalDestinoNombre.Width = 67;
            // 
            // colLocalidadOrigenID
            // 
            this.colLocalidadOrigenID.FieldName = "LocalidadOrigenID";
            this.colLocalidadOrigenID.Name = "colLocalidadOrigenID";
            this.colLocalidadOrigenID.OptionsColumn.AllowEdit = false;
            this.colLocalidadOrigenID.OptionsColumn.ReadOnly = true;
            this.colLocalidadOrigenID.Width = 20;
            // 
            // colLocalidadDestinoID
            // 
            this.colLocalidadDestinoID.FieldName = "LocalidadDestinoID";
            this.colLocalidadDestinoID.Name = "colLocalidadDestinoID";
            this.colLocalidadDestinoID.OptionsColumn.AllowEdit = false;
            this.colLocalidadDestinoID.OptionsColumn.ReadOnly = true;
            this.colLocalidadDestinoID.Width = 20;
            // 
            // colLocalidadOrigenNombre
            // 
            this.colLocalidadOrigenNombre.FieldName = "LocalidadOrigenNombre";
            this.colLocalidadOrigenNombre.Name = "colLocalidadOrigenNombre";
            this.colLocalidadOrigenNombre.OptionsColumn.AllowEdit = false;
            this.colLocalidadOrigenNombre.OptionsColumn.ReadOnly = true;
            this.colLocalidadOrigenNombre.Width = 20;
            // 
            // colLocalidadDestinoNombre
            // 
            this.colLocalidadDestinoNombre.FieldName = "LocalidadDestinoNombre";
            this.colLocalidadDestinoNombre.Name = "colLocalidadDestinoNombre";
            this.colLocalidadDestinoNombre.OptionsColumn.AllowEdit = false;
            this.colLocalidadDestinoNombre.OptionsColumn.ReadOnly = true;
            this.colLocalidadDestinoNombre.Width = 20;
            // 
            // colEmpresaID
            // 
            this.colEmpresaID.FieldName = "EmpresaID";
            this.colEmpresaID.Name = "colEmpresaID";
            this.colEmpresaID.OptionsColumn.AllowEdit = false;
            this.colEmpresaID.OptionsColumn.ReadOnly = true;
            this.colEmpresaID.Width = 20;
            // 
            // colEmpresaCodigo
            // 
            this.colEmpresaCodigo.FieldName = "EmpresaCodigo";
            this.colEmpresaCodigo.Name = "colEmpresaCodigo";
            this.colEmpresaCodigo.OptionsColumn.AllowEdit = false;
            this.colEmpresaCodigo.OptionsColumn.ReadOnly = true;
            this.colEmpresaCodigo.Visible = true;
            this.colEmpresaCodigo.VisibleIndex = 4;
            this.colEmpresaCodigo.Width = 67;
            // 
            // colServicioID
            // 
            this.colServicioID.FieldName = "ServicioID";
            this.colServicioID.Name = "colServicioID";
            this.colServicioID.OptionsColumn.AllowEdit = false;
            this.colServicioID.OptionsColumn.ReadOnly = true;
            this.colServicioID.Width = 20;
            // 
            // colServicioCodigo
            // 
            this.colServicioCodigo.FieldName = "ServicioCodigo";
            this.colServicioCodigo.Name = "colServicioCodigo";
            this.colServicioCodigo.OptionsColumn.AllowEdit = false;
            this.colServicioCodigo.OptionsColumn.ReadOnly = true;
            this.colServicioCodigo.Visible = true;
            this.colServicioCodigo.VisibleIndex = 1;
            this.colServicioCodigo.Width = 67;
            // 
            // colCategoriaNombre
            // 
            this.colCategoriaNombre.FieldName = "CategoriaNombre";
            this.colCategoriaNombre.Name = "colCategoriaNombre";
            this.colCategoriaNombre.OptionsColumn.AllowEdit = false;
            this.colCategoriaNombre.OptionsColumn.ReadOnly = true;
            this.colCategoriaNombre.Visible = true;
            this.colCategoriaNombre.VisibleIndex = 5;
            this.colCategoriaNombre.Width = 67;
            // 
            // colCategoriaID
            // 
            this.colCategoriaID.FieldName = "CategoriaID";
            this.colCategoriaID.Name = "colCategoriaID";
            this.colCategoriaID.OptionsColumn.AllowEdit = false;
            this.colCategoriaID.OptionsColumn.ReadOnly = true;
            this.colCategoriaID.Width = 20;
            // 
            // colTipoLinea
            // 
            this.colTipoLinea.FieldName = "TipoLinea";
            this.colTipoLinea.Name = "colTipoLinea";
            this.colTipoLinea.OptionsColumn.AllowEdit = false;
            this.colTipoLinea.OptionsColumn.ReadOnly = true;
            this.colTipoLinea.Width = 20;
            // 
            // colLongitudRecorrido
            // 
            this.colLongitudRecorrido.FieldName = "LongitudRecorrido";
            this.colLongitudRecorrido.Name = "colLongitudRecorrido";
            this.colLongitudRecorrido.OptionsColumn.AllowEdit = false;
            this.colLongitudRecorrido.OptionsColumn.ReadOnly = true;
            this.colLongitudRecorrido.Width = 20;
            // 
            // colFechaPartida
            // 
            this.colFechaPartida.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colFechaPartida.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaPartida.FieldName = "FechaPartida";
            this.colFechaPartida.Name = "colFechaPartida";
            this.colFechaPartida.OptionsColumn.AllowEdit = false;
            this.colFechaPartida.OptionsColumn.ReadOnly = true;
            this.colFechaPartida.Visible = true;
            this.colFechaPartida.VisibleIndex = 6;
            this.colFechaPartida.Width = 67;
            // 
            // colFechaArribo
            // 
            this.colFechaArribo.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colFechaArribo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaArribo.FieldName = "FechaArribo";
            this.colFechaArribo.Name = "colFechaArribo";
            this.colFechaArribo.OptionsColumn.AllowEdit = false;
            this.colFechaArribo.OptionsColumn.ReadOnly = true;
            this.colFechaArribo.Width = 64;
            // 
            // colSentido
            // 
            this.colSentido.FieldName = "Sentido";
            this.colSentido.Name = "colSentido";
            this.colSentido.OptionsColumn.AllowEdit = false;
            this.colSentido.OptionsColumn.ReadOnly = true;
            this.colSentido.Width = 64;
            // 
            // colLongitudTotal
            // 
            this.colLongitudTotal.FieldName = "LongitudTotal";
            this.colLongitudTotal.Name = "colLongitudTotal";
            this.colLongitudTotal.OptionsColumn.AllowEdit = false;
            this.colLongitudTotal.OptionsColumn.ReadOnly = true;
            this.colLongitudTotal.Width = 20;
            // 
            // colId_CodigoServicioVuelta
            // 
            this.colId_CodigoServicioVuelta.FieldName = "Id_CodigoServicioVuelta";
            this.colId_CodigoServicioVuelta.Name = "colId_CodigoServicioVuelta";
            this.colId_CodigoServicioVuelta.OptionsColumn.AllowEdit = false;
            this.colId_CodigoServicioVuelta.OptionsColumn.ReadOnly = true;
            this.colId_CodigoServicioVuelta.Width = 20;
            // 
            // colId_Coche
            // 
            this.colId_Coche.FieldName = "Id_Coche";
            this.colId_Coche.Name = "colId_Coche";
            this.colId_Coche.OptionsColumn.AllowEdit = false;
            this.colId_Coche.OptionsColumn.ReadOnly = true;
            this.colId_Coche.Width = 20;
            // 
            // colId_Personal1
            // 
            this.colId_Personal1.FieldName = "Id_Personal1";
            this.colId_Personal1.Name = "colId_Personal1";
            this.colId_Personal1.OptionsColumn.AllowEdit = false;
            this.colId_Personal1.OptionsColumn.ReadOnly = true;
            this.colId_Personal1.Width = 20;
            // 
            // colId_Personal2
            // 
            this.colId_Personal2.FieldName = "Id_Personal2";
            this.colId_Personal2.Name = "colId_Personal2";
            this.colId_Personal2.OptionsColumn.AllowEdit = false;
            this.colId_Personal2.OptionsColumn.ReadOnly = true;
            this.colId_Personal2.Width = 20;
            // 
            // colId_Personal3
            // 
            this.colId_Personal3.FieldName = "Id_Personal3";
            this.colId_Personal3.Name = "colId_Personal3";
            this.colId_Personal3.OptionsColumn.AllowEdit = false;
            this.colId_Personal3.OptionsColumn.ReadOnly = true;
            this.colId_Personal3.Width = 20;
            // 
            // colInterno
            // 
            this.colInterno.FieldName = "Interno";
            this.colInterno.Name = "colInterno";
            this.colInterno.OptionsColumn.AllowEdit = false;
            this.colInterno.OptionsColumn.ReadOnly = true;
            this.colInterno.Visible = true;
            this.colInterno.VisibleIndex = 7;
            this.colInterno.Width = 67;
            // 
            // colLegajoPersonal1
            // 
            this.colLegajoPersonal1.FieldName = "LegajoPersonal1";
            this.colLegajoPersonal1.Name = "colLegajoPersonal1";
            this.colLegajoPersonal1.OptionsColumn.AllowEdit = false;
            this.colLegajoPersonal1.OptionsColumn.ReadOnly = true;
            this.colLegajoPersonal1.Visible = true;
            this.colLegajoPersonal1.VisibleIndex = 8;
            this.colLegajoPersonal1.Width = 115;
            // 
            // colLegajoPersonal2
            // 
            this.colLegajoPersonal2.FieldName = "LegajoPersonal2";
            this.colLegajoPersonal2.Name = "colLegajoPersonal2";
            this.colLegajoPersonal2.OptionsColumn.AllowEdit = false;
            this.colLegajoPersonal2.OptionsColumn.ReadOnly = true;
            this.colLegajoPersonal2.Visible = true;
            this.colLegajoPersonal2.VisibleIndex = 9;
            this.colLegajoPersonal2.Width = 126;
            // 
            // colLegajoPersonal3
            // 
            this.colLegajoPersonal3.FieldName = "LegajoPersonal3";
            this.colLegajoPersonal3.Name = "colLegajoPersonal3";
            this.colLegajoPersonal3.OptionsColumn.AllowEdit = false;
            this.colLegajoPersonal3.OptionsColumn.ReadOnly = true;
            this.colLegajoPersonal3.Visible = true;
            this.colLegajoPersonal3.VisibleIndex = 10;
            this.colLegajoPersonal3.Width = 149;
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
            this.barButtonItem1,
            this.barSubItem1,
            this.barSubItem2,
            this.btnResultado,
            this.barStaticItemFooter,
            this.btnProcesar,
            this.btnSalir});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
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
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProcesar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Caption = "Procesar";
            this.btnProcesar.Id = 5;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcesar_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 6;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Impirmir";
            this.barSubItem2.Glyph = global::VENET_Personal_Sisorg.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 2;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 3;
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
            this.barStaticItemFooter.Id = 4;
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Aceptar";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(this.fecha_HastaDateEdit);
            this.panelControl1.Controls.Add(fecha_DesdeLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 36);
            this.panelControl1.TabIndex = 11;
            // 
            // colResultado
            // 
            this.colResultado.Caption = "Resultado";
            this.colResultado.FieldName = "Resultado";
            this.colResultado.Name = "colResultado";
            this.colResultado.Visible = true;
            this.colResultado.VisibleIndex = 11;
            this.colResultado.Width = 139;
            // 
            // frmWebServiceSisorgViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.Name = "frmWebServiceSisorgViajes";
            this.Text = "Enturnamiento de Viajes en Sisorg";
            this.Load += new System.EventHandler(this.frmWebServiceSisorgViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServicesSisorg_resultViajesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource webServicesSisorg_resultViajesBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colViajeID;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoViaje;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalOrigenID;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalDestinoID;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalOrigenNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalDestinoNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidadOrigenID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidadDestinoID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidadOrigenNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidadDestinoNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colServicioID;
        private DevExpress.XtraGrid.Columns.GridColumn colServicioCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoriaNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoriaID;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colLongitudRecorrido;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPartida;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaArribo;
        private DevExpress.XtraGrid.Columns.GridColumn colSentido;
        private DevExpress.XtraGrid.Columns.GridColumn colLongitudTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CodigoServicioVuelta;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Coche;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal2;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal3;
        private DevExpress.XtraGrid.Columns.GridColumn colInterno;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajoPersonal1;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajoPersonal2;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajoPersonal3;
        private DevExpress.XtraBars.BarButtonItem btnProcesar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem btnSalir;
        private DevExpress.XtraGrid.Columns.GridColumn colResultado;
    }
}