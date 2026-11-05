namespace VENET_Personal_UI
{
    partial class frmPersonal
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label id_TipoDocLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label apellidoLabel;
            System.Windows.Forms.Label nroDocLabel;
            System.Windows.Forms.Label legajoLabel;
            System.Windows.Forms.Label id_EmpresaLabel;
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.personalManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTipoDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciaLaboral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadNegocio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJerarquia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellidoCasada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioPiso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilioDpto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Provincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCelular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAlta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaBaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaNacimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_EstadoCivil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Jerarquia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralLegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralCodPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_Provincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_UnidadNegocio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_TipoServicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_Cabecera = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralDiasRotacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralDiaRotacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralTurnoFijo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralFrancoDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralVencimientoCarnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralCarnetNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralEmisionCarnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralVencimientoCarnetCNRT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralCarnetNumeroCNRT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralEmisionCarnetCNRT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_PuntaDeLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralVencimientoCarnetAdicional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralCarnetNumeroAdicional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralEmisionCarnetAdicional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralId_GrupoLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupoLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.personalManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.MnuOperaciones = new DevExpress.XtraBars.BarSubItem();
            this.btnCambioEmpresa = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizaDesdeSisorg = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonalSisorg = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportarExcelLicencias = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerarExcelLicencias = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnDireccionMapa = new DevExpress.XtraBars.BarButtonItem();
            this.btnImpuestos = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.legajoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroDocTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.apellidoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoDocLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.colLaboralCarnetNumeroAdicional2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralEmisionCarnetAdicional2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaboralVencimientoCarnetAdicional2 = new DevExpress.XtraGrid.Columns.GridColumn();
            idLabel = new System.Windows.Forms.Label();
            id_TipoDocLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidoLabel = new System.Windows.Forms.Label();
            nroDocLabel = new System.Windows.Forms.Label();
            legajoLabel = new System.Windows.Forms.Label();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroDocTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apellidoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoDocLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(206, 8);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(21, 13);
            idLabel.TabIndex = 5;
            idLabel.Text = "Id:";
            // 
            // id_TipoDocLabel
            // 
            id_TipoDocLabel.AutoSize = true;
            id_TipoDocLabel.Location = new System.Drawing.Point(6, 34);
            id_TipoDocLabel.Name = "id_TipoDocLabel";
            id_TipoDocLabel.Size = new System.Drawing.Size(52, 13);
            id_TipoDocLabel.TabIndex = 6;
            id_TipoDocLabel.Text = "Tipo Doc:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(343, 8);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 7;
            nombreLabel.Text = "Nombre:";
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new System.Drawing.Point(509, 8);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new System.Drawing.Size(48, 13);
            apellidoLabel.TabIndex = 8;
            apellidoLabel.Text = "Apellido:";
            // 
            // nroDocLabel
            // 
            nroDocLabel.AutoSize = true;
            nroDocLabel.Location = new System.Drawing.Point(175, 34);
            nroDocLabel.Name = "nroDocLabel";
            nroDocLabel.Size = new System.Drawing.Size(49, 13);
            nroDocLabel.TabIndex = 9;
            nroDocLabel.Text = "Nro Doc:";
            // 
            // legajoLabel
            // 
            legajoLabel.AutoSize = true;
            legajoLabel.Location = new System.Drawing.Point(348, 34);
            legajoLabel.Name = "legajoLabel";
            legajoLabel.Size = new System.Drawing.Size(43, 13);
            legajoLabel.TabIndex = 11;
            legajoLabel.Text = "Legajo:";
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(9, 8);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 13;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.personalManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 84);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 352);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // personalManager_SearchResultBindingSource
            // 
            this.personalManager_SearchResultBindingSource.DataSource = typeof(VENET_Personal_BL.PersonalManager.SearchResult);
            this.personalManager_SearchResultBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.personalManager_SearchResultBindingSource_BindingComplete);
            this.personalManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.personalManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTipoDoc,
            this.colProvinciaLaboral,
            this.colEmpresa,
            this.colUnidadNegocio,
            this.colDomicilioProvincia,
            this.colJerarquia,
            this.colId_Empresa,
            this.colApellido,
            this.colNombre,
            this.colApellidoCasada,
            this.colDomicilioCalle,
            this.colDomicilioNro,
            this.colDomicilioPiso,
            this.colDomicilioDpto,
            this.colCodPos,
            this.colId_Provincia,
            this.colTelefono,
            this.colCelular,
            this.colFechaAlta,
            this.colFechaBaja,
            this.colFechaNacimiento,
            this.colObservaciones,
            this.colId_EstadoCivil,
            this.colId_TipoDoc,
            this.colNroDoc,
            this.colId_Tipo,
            this.colId_Jerarquia,
            this.colCuit,
            this.colId_TipoIva,
            this.colLaboralLegajo,
            this.colLaboralSucursal,
            this.colLaboralDomicilio,
            this.colLaboralCodPos,
            this.colLaboralTelefono,
            this.colLaboralId_Provincia,
            this.colLaboralId_UnidadNegocio,
            this.colLaboralId_TipoServicio,
            this.colLaboralId_Cabecera,
            this.colLaboralDiasRotacion,
            this.colLaboralDiaRotacion,
            this.colLaboralTurnoFijo,
            this.colLaboralFrancoDias,
            this.colLaboralVencimientoCarnet,
            this.colLaboralCarnetNumero,
            this.colLaboralEmisionCarnet,
            this.colLaboralVencimientoCarnetCNRT,
            this.colLaboralCarnetNumeroCNRT,
            this.colLaboralEmisionCarnetCNRT,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod,
            this.colEmail,
            this.colLaboralId_PuntaDeLinea,
            this.colLaboralVencimientoCarnetAdicional,
            this.colLaboralCarnetNumeroAdicional,
            this.colLaboralEmisionCarnetAdicional,
            this.colLaboralId_GrupoLinea,
            this.colGrupoLinea,
            this.colLaboralCarnetNumeroAdicional2,
            this.colLaboralEmisionCarnetAdicional2,
            this.colLaboralVencimientoCarnetAdicional2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colTipoDoc
            // 
            this.colTipoDoc.FieldName = "TipoDoc";
            this.colTipoDoc.Name = "colTipoDoc";
            this.colTipoDoc.Visible = true;
            this.colTipoDoc.VisibleIndex = 3;
            this.colTipoDoc.Width = 65;
            // 
            // colProvinciaLaboral
            // 
            this.colProvinciaLaboral.FieldName = "ProvinciaLaboral";
            this.colProvinciaLaboral.Name = "colProvinciaLaboral";
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 5;
            this.colEmpresa.Width = 107;
            // 
            // colUnidadNegocio
            // 
            this.colUnidadNegocio.FieldName = "UnidadNegocio";
            this.colUnidadNegocio.Name = "colUnidadNegocio";
            this.colUnidadNegocio.Visible = true;
            this.colUnidadNegocio.VisibleIndex = 6;
            this.colUnidadNegocio.Width = 129;
            // 
            // colDomicilioProvincia
            // 
            this.colDomicilioProvincia.FieldName = "DomicilioProvincia";
            this.colDomicilioProvincia.Name = "colDomicilioProvincia";
            // 
            // colJerarquia
            // 
            this.colJerarquia.Caption = "Jerarquía";
            this.colJerarquia.FieldName = "Jerarquia";
            this.colJerarquia.Name = "colJerarquia";
            // 
            // colId_Empresa
            // 
            this.colId_Empresa.FieldName = "Id_Empresa";
            this.colId_Empresa.Name = "colId_Empresa";
            // 
            // colApellido
            // 
            this.colApellido.FieldName = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 1;
            this.colApellido.Width = 115;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 2;
            this.colNombre.Width = 170;
            // 
            // colApellidoCasada
            // 
            this.colApellidoCasada.FieldName = "ApellidoCasada";
            this.colApellidoCasada.Name = "colApellidoCasada";
            // 
            // colDomicilioCalle
            // 
            this.colDomicilioCalle.FieldName = "DomicilioCalle";
            this.colDomicilioCalle.Name = "colDomicilioCalle";
            // 
            // colDomicilioNro
            // 
            this.colDomicilioNro.FieldName = "DomicilioNro";
            this.colDomicilioNro.Name = "colDomicilioNro";
            // 
            // colDomicilioPiso
            // 
            this.colDomicilioPiso.FieldName = "DomicilioPiso";
            this.colDomicilioPiso.Name = "colDomicilioPiso";
            // 
            // colDomicilioDpto
            // 
            this.colDomicilioDpto.FieldName = "DomicilioDpto";
            this.colDomicilioDpto.Name = "colDomicilioDpto";
            // 
            // colCodPos
            // 
            this.colCodPos.FieldName = "CodPos";
            this.colCodPos.Name = "colCodPos";
            // 
            // colId_Provincia
            // 
            this.colId_Provincia.FieldName = "Id_Provincia";
            this.colId_Provincia.Name = "colId_Provincia";
            // 
            // colTelefono
            // 
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            // 
            // colCelular
            // 
            this.colCelular.FieldName = "Celular";
            this.colCelular.Name = "colCelular";
            // 
            // colFechaAlta
            // 
            this.colFechaAlta.DisplayFormat.FormatString = "G";
            this.colFechaAlta.FieldName = "FechaAlta";
            this.colFechaAlta.Name = "colFechaAlta";
            // 
            // colFechaBaja
            // 
            this.colFechaBaja.DisplayFormat.FormatString = "G";
            this.colFechaBaja.FieldName = "FechaBaja";
            this.colFechaBaja.Name = "colFechaBaja";
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.DisplayFormat.FormatString = "G";
            this.colFechaNacimiento.FieldName = "FechaNacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // colId_EstadoCivil
            // 
            this.colId_EstadoCivil.FieldName = "Id_EstadoCivil";
            this.colId_EstadoCivil.Name = "colId_EstadoCivil";
            // 
            // colId_TipoDoc
            // 
            this.colId_TipoDoc.FieldName = "Id_TipoDoc";
            this.colId_TipoDoc.Name = "colId_TipoDoc";
            // 
            // colNroDoc
            // 
            this.colNroDoc.FieldName = "NroDoc";
            this.colNroDoc.Name = "colNroDoc";
            this.colNroDoc.Visible = true;
            this.colNroDoc.VisibleIndex = 4;
            this.colNroDoc.Width = 62;
            // 
            // colId_Tipo
            // 
            this.colId_Tipo.FieldName = "Id_Tipo";
            this.colId_Tipo.Name = "colId_Tipo";
            // 
            // colId_Jerarquia
            // 
            this.colId_Jerarquia.FieldName = "Id_Jerarquia";
            this.colId_Jerarquia.Name = "colId_Jerarquia";
            // 
            // colCuit
            // 
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            // 
            // colId_TipoIva
            // 
            this.colId_TipoIva.FieldName = "Id_TipoIva";
            this.colId_TipoIva.Name = "colId_TipoIva";
            // 
            // colLaboralLegajo
            // 
            this.colLaboralLegajo.Caption = "Legajo";
            this.colLaboralLegajo.FieldName = "LaboralLegajo";
            this.colLaboralLegajo.Name = "colLaboralLegajo";
            this.colLaboralLegajo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LaboralLegajo", "{0}")});
            this.colLaboralLegajo.Visible = true;
            this.colLaboralLegajo.VisibleIndex = 0;
            this.colLaboralLegajo.Width = 45;
            // 
            // colLaboralSucursal
            // 
            this.colLaboralSucursal.FieldName = "LaboralSucursal";
            this.colLaboralSucursal.Name = "colLaboralSucursal";
            // 
            // colLaboralDomicilio
            // 
            this.colLaboralDomicilio.FieldName = "LaboralDomicilio";
            this.colLaboralDomicilio.Name = "colLaboralDomicilio";
            // 
            // colLaboralCodPos
            // 
            this.colLaboralCodPos.FieldName = "LaboralCodPos";
            this.colLaboralCodPos.Name = "colLaboralCodPos";
            // 
            // colLaboralTelefono
            // 
            this.colLaboralTelefono.FieldName = "LaboralTelefono";
            this.colLaboralTelefono.Name = "colLaboralTelefono";
            // 
            // colLaboralId_Provincia
            // 
            this.colLaboralId_Provincia.FieldName = "LaboralId_Provincia";
            this.colLaboralId_Provincia.Name = "colLaboralId_Provincia";
            // 
            // colLaboralId_UnidadNegocio
            // 
            this.colLaboralId_UnidadNegocio.FieldName = "LaboralId_UnidadNegocio";
            this.colLaboralId_UnidadNegocio.Name = "colLaboralId_UnidadNegocio";
            // 
            // colLaboralId_TipoServicio
            // 
            this.colLaboralId_TipoServicio.FieldName = "LaboralId_TipoServicio";
            this.colLaboralId_TipoServicio.Name = "colLaboralId_TipoServicio";
            // 
            // colLaboralId_Cabecera
            // 
            this.colLaboralId_Cabecera.FieldName = "LaboralId_Cabecera";
            this.colLaboralId_Cabecera.Name = "colLaboralId_Cabecera";
            // 
            // colLaboralDiasRotacion
            // 
            this.colLaboralDiasRotacion.FieldName = "LaboralDiasRotacion";
            this.colLaboralDiasRotacion.Name = "colLaboralDiasRotacion";
            // 
            // colLaboralDiaRotacion
            // 
            this.colLaboralDiaRotacion.FieldName = "LaboralDiaRotacion";
            this.colLaboralDiaRotacion.Name = "colLaboralDiaRotacion";
            // 
            // colLaboralTurnoFijo
            // 
            this.colLaboralTurnoFijo.FieldName = "LaboralTurnoFijo";
            this.colLaboralTurnoFijo.Name = "colLaboralTurnoFijo";
            // 
            // colLaboralFrancoDias
            // 
            this.colLaboralFrancoDias.FieldName = "LaboralFrancoDias";
            this.colLaboralFrancoDias.Name = "colLaboralFrancoDias";
            // 
            // colLaboralVencimientoCarnet
            // 
            this.colLaboralVencimientoCarnet.FieldName = "LaboralVencimientoCarnet";
            this.colLaboralVencimientoCarnet.Name = "colLaboralVencimientoCarnet";
            // 
            // colLaboralCarnetNumero
            // 
            this.colLaboralCarnetNumero.FieldName = "LaboralCarnetNumero";
            this.colLaboralCarnetNumero.Name = "colLaboralCarnetNumero";
            // 
            // colLaboralEmisionCarnet
            // 
            this.colLaboralEmisionCarnet.FieldName = "LaboralEmisionCarnet";
            this.colLaboralEmisionCarnet.Name = "colLaboralEmisionCarnet";
            // 
            // colLaboralVencimientoCarnetCNRT
            // 
            this.colLaboralVencimientoCarnetCNRT.FieldName = "LaboralVencimientoCarnetCNRT";
            this.colLaboralVencimientoCarnetCNRT.Name = "colLaboralVencimientoCarnetCNRT";
            // 
            // colLaboralCarnetNumeroCNRT
            // 
            this.colLaboralCarnetNumeroCNRT.FieldName = "LaboralCarnetNumeroCNRT";
            this.colLaboralCarnetNumeroCNRT.Name = "colLaboralCarnetNumeroCNRT";
            // 
            // colLaboralEmisionCarnetCNRT
            // 
            this.colLaboralEmisionCarnetCNRT.FieldName = "LaboralEmisionCarnetCNRT";
            this.colLaboralEmisionCarnetCNRT.Name = "colLaboralEmisionCarnetCNRT";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFechaAdd
            // 
            this.colFechaAdd.DisplayFormat.FormatString = "G";
            this.colFechaAdd.FieldName = "FechaAdd";
            this.colFechaAdd.Name = "colFechaAdd";
            // 
            // colFechaMod
            // 
            this.colFechaMod.DisplayFormat.FormatString = "G";
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
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colLaboralId_PuntaDeLinea
            // 
            this.colLaboralId_PuntaDeLinea.Caption = "LaboralId_PuntaDeLinea";
            this.colLaboralId_PuntaDeLinea.FieldName = "LaboralId_PuntaDeLinea";
            this.colLaboralId_PuntaDeLinea.Name = "colLaboralId_PuntaDeLinea";
            // 
            // colLaboralVencimientoCarnetAdicional
            // 
            this.colLaboralVencimientoCarnetAdicional.FieldName = "LaboralVencimientoCarnetAdicional";
            this.colLaboralVencimientoCarnetAdicional.Name = "colLaboralVencimientoCarnetAdicional";
            // 
            // colLaboralCarnetNumeroAdicional
            // 
            this.colLaboralCarnetNumeroAdicional.FieldName = "LaboralCarnetNumeroAdicional";
            this.colLaboralCarnetNumeroAdicional.Name = "colLaboralCarnetNumeroAdicional";
            // 
            // colLaboralEmisionCarnetAdicional
            // 
            this.colLaboralEmisionCarnetAdicional.FieldName = "LaboralEmisionCarnetAdicional";
            this.colLaboralEmisionCarnetAdicional.Name = "colLaboralEmisionCarnetAdicional";
            // 
            // colLaboralId_GrupoLinea
            // 
            this.colLaboralId_GrupoLinea.Caption = "Laboral Id_GrupoLinea";
            this.colLaboralId_GrupoLinea.FieldName = "LaboralId_GrupoLinea";
            this.colLaboralId_GrupoLinea.Name = "colLaboralId_GrupoLinea";
            // 
            // colGrupoLinea
            // 
            this.colGrupoLinea.Caption = "Grupo Línea";
            this.colGrupoLinea.FieldName = "GrupoLinea";
            this.colGrupoLinea.Name = "colGrupoLinea";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(id_EmpresaLabel);
            this.panelControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.panelControl1.Controls.Add(legajoLabel);
            this.panelControl1.Controls.Add(this.legajoTextEdit);
            this.panelControl1.Controls.Add(nroDocLabel);
            this.panelControl1.Controls.Add(this.nroDocTextEdit);
            this.panelControl1.Controls.Add(apellidoLabel);
            this.panelControl1.Controls.Add(this.apellidoTextEdit);
            this.panelControl1.Controls.Add(nombreLabel);
            this.panelControl1.Controls.Add(this.nombreTextEdit);
            this.panelControl1.Controls.Add(id_TipoDocLabel);
            this.panelControl1.Controls.Add(this.id_TipoDocLookUpEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 60);
            this.panelControl1.TabIndex = 0;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Id_Empresa", true));
            this.id_EmpresaLookUpEdit.EnterMoveNextControl = true;
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(66, 5);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            this.id_EmpresaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // personalManager_ParametrosBusquedasBindingSource
            // 
            this.personalManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Personal_BL.PersonalManager.ParametrosBusquedas);
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
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.btnResultado,
            this.barStaticItemFooter,
            this.barSubItem2,
            this.btnDireccionMapa,
            this.MnuOperaciones,
            this.btnImportarExcel,
            this.btnGenerarExcel,
            this.btnImpuestos,
            this.btnCambioEmpresa,
            this.btnPersonalSisorg,
            this.btnActualizaDesdeSisorg,
            this.btnImportarExcelLicencias,
            this.btnGenerarExcelLicencias});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.MnuOperaciones, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Personal_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Personal_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Personal_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Personal_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 4;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // MnuOperaciones
            // 
            this.MnuOperaciones.Caption = "Operaciones";
            this.MnuOperaciones.Glyph = global::VENET_Personal_UI.Properties.Resources.properties_16x16;
            this.MnuOperaciones.Id = 8;
            this.MnuOperaciones.LargeGlyph = global::VENET_Personal_UI.Properties.Resources.properties_32x32;
            this.MnuOperaciones.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCambioEmpresa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizaDesdeSisorg, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPersonalSisorg),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportarExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportarExcelLicencias, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarExcelLicencias)});
            this.MnuOperaciones.Name = "MnuOperaciones";
            // 
            // btnCambioEmpresa
            // 
            this.btnCambioEmpresa.Caption = "Cambio de Empresa";
            this.btnCambioEmpresa.Id = 12;
            this.btnCambioEmpresa.Name = "btnCambioEmpresa";
            this.btnCambioEmpresa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCambioEmpresa_ItemClick);
            // 
            // btnActualizaDesdeSisorg
            // 
            this.btnActualizaDesdeSisorg.Caption = "Actualizar Legajos desde Sisorg";
            this.btnActualizaDesdeSisorg.Id = 14;
            this.btnActualizaDesdeSisorg.Name = "btnActualizaDesdeSisorg";
            this.btnActualizaDesdeSisorg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizaDesdeSisorg_ItemClick);
            // 
            // btnPersonalSisorg
            // 
            this.btnPersonalSisorg.Caption = "Importar Personal a Sisorg";
            this.btnPersonalSisorg.Id = 13;
            this.btnPersonalSisorg.Name = "btnPersonalSisorg";
            this.btnPersonalSisorg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonalSisorg_ItemClick);
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.Caption = "Importar Excel Seteo Masivo";
            this.btnImportarExcel.Id = 9;
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportarExcel_ItemClick);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Caption = "Generar Excel Importación Modelo";
            this.btnGenerarExcel.Id = 10;
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerarExcel_ItemClick);
            // 
            // btnImportarExcelLicencias
            // 
            this.btnImportarExcelLicencias.Caption = "Importar Excel Seteo Masivo Licencias";
            this.btnImportarExcelLicencias.Id = 15;
            this.btnImportarExcelLicencias.Name = "btnImportarExcelLicencias";
            this.btnImportarExcelLicencias.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportarExcelLicencias_ItemClick);
            // 
            // btnGenerarExcelLicencias
            // 
            this.btnGenerarExcelLicencias.Caption = "Generar Excel Importación Modelo Licencias";
            this.btnGenerarExcelLicencias.Id = 16;
            this.btnGenerarExcelLicencias.Name = "btnGenerarExcelLicencias";
            this.btnGenerarExcelLicencias.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerarExcelLicencias_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Ver";
            this.barSubItem2.Glyph = global::VENET_Personal_UI.Properties.Resources.info_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LargeGlyph = global::VENET_Personal_UI.Properties.Resources.info_32x32;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDireccionMapa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImpuestos, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnDireccionMapa
            // 
            this.btnDireccionMapa.Caption = "Dirección en mapa";
            this.btnDireccionMapa.Id = 7;
            this.btnDireccionMapa.Name = "btnDireccionMapa";
            this.btnDireccionMapa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDireccionMapa_ItemClick);
            // 
            // btnImpuestos
            // 
            this.btnImpuestos.Caption = "Impuestos";
            this.btnImpuestos.Id = 11;
            this.btnImpuestos.Name = "btnImpuestos";
            this.btnImpuestos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImpuestos_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFooter)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // barStaticItemFooter
            // 
            this.barStaticItemFooter.Id = 5;
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
            // legajoTextEdit
            // 
            this.legajoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Legajo", true));
            this.legajoTextEdit.EnterMoveNextControl = true;
            this.legajoTextEdit.Location = new System.Drawing.Point(396, 31);
            this.legajoTextEdit.MenuManager = this.barManager1;
            this.legajoTextEdit.Name = "legajoTextEdit";
            this.legajoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.legajoTextEdit.TabIndex = 6;
            this.legajoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroDocTextEdit
            // 
            this.nroDocTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "NroDoc", true));
            this.nroDocTextEdit.Location = new System.Drawing.Point(231, 31);
            this.nroDocTextEdit.MenuManager = this.barManager1;
            this.nroDocTextEdit.Name = "nroDocTextEdit";
            this.nroDocTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroDocTextEdit.TabIndex = 5;
            this.nroDocTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // apellidoTextEdit
            // 
            this.apellidoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Apellido", true));
            this.apellidoTextEdit.Location = new System.Drawing.Point(562, 5);
            this.apellidoTextEdit.MenuManager = this.barManager1;
            this.apellidoTextEdit.Name = "apellidoTextEdit";
            this.apellidoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.apellidoTextEdit.TabIndex = 3;
            this.apellidoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Nombre", true));
            this.nombreTextEdit.Location = new System.Drawing.Point(396, 5);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nombreTextEdit.TabIndex = 2;
            this.nombreTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_TipoDocLookUpEdit
            // 
            this.id_TipoDocLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Id_TipoDoc", true));
            this.id_TipoDocLookUpEdit.Location = new System.Drawing.Point(66, 31);
            this.id_TipoDocLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoDocLookUpEdit.Name = "id_TipoDocLookUpEdit";
            this.id_TipoDocLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_TipoDocLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_TipoDocLookUpEdit.Properties.NullText = "";
            this.id_TipoDocLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoDocLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_TipoDocLookUpEdit.TabIndex = 4;
            this.id_TipoDocLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_TipoDocLookUpEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.personalManager_ParametrosBusquedasBindingSource, "Id", true));
            this.idTextEdit.Location = new System.Drawing.Point(231, 5);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 1;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // colLaboralCarnetNumeroAdicional2
            // 
            this.colLaboralCarnetNumeroAdicional2.Caption = "LaboralCarnetNumeroAdicional2";
            this.colLaboralCarnetNumeroAdicional2.FieldName = "LaboralCarnetNumeroAdicional2";
            this.colLaboralCarnetNumeroAdicional2.Name = "colLaboralCarnetNumeroAdicional2";
            // 
            // colLaboralEmisionCarnetAdicional2
            // 
            this.colLaboralEmisionCarnetAdicional2.Caption = "LaboralEmisionCarnetAdicional2";
            this.colLaboralEmisionCarnetAdicional2.FieldName = "LaboralEmisionCarnetAdicional2";
            this.colLaboralEmisionCarnetAdicional2.Name = "colLaboralEmisionCarnetAdicional2";
            // 
            // colLaboralVencimientoCarnetAdicional2
            // 
            this.colLaboralVencimientoCarnetAdicional2.Caption = "LaboralVencimientoCarnetAdicional2";
            this.colLaboralVencimientoCarnetAdicional2.FieldName = "LaboralVencimientoCarnetAdicional2";
            this.colLaboralVencimientoCarnetAdicional2.Name = "colLaboralVencimientoCarnetAdicional2";
            // 
            // frmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(691, 248);
            this.Name = "frmPersonal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroDocTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apellidoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoDocLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource personalManager_SearchResultBindingSource;
        private DevExpress.XtraEditors.TextEdit nroDocTextEdit;
        private System.Windows.Forms.BindingSource personalManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.TextEdit apellidoTextEdit;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoDocLookUpEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.TextEdit legajoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnDireccionMapa;
        private DevExpress.XtraBars.BarSubItem MnuOperaciones;
        private DevExpress.XtraBars.BarButtonItem btnImportarExcel;
        private DevExpress.XtraBars.BarButtonItem btnGenerarExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciaLaboral;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadNegocio;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colJerarquia;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colApellidoCasada;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioNro;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioPiso;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilioDpto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPos;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Provincia;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colCelular;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAlta;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaBaja;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaNacimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colId_EstadoCivil;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colNroDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Tipo;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Jerarquia;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoIva;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralLegajo;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralCodPos;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_Provincia;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_UnidadNegocio;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_TipoServicio;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_Cabecera;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralDiasRotacion;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralDiaRotacion;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralTurnoFijo;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralFrancoDias;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralVencimientoCarnet;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralCarnetNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralEmisionCarnet;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralVencimientoCarnetCNRT;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralCarnetNumeroCNRT;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralEmisionCarnetCNRT;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarButtonItem btnImpuestos;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraBars.BarButtonItem btnCambioEmpresa;
        private DevExpress.XtraBars.BarButtonItem btnPersonalSisorg;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_PuntaDeLinea;
        private DevExpress.XtraBars.BarButtonItem btnActualizaDesdeSisorg;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralVencimientoCarnetAdicional;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralCarnetNumeroAdicional;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralEmisionCarnetAdicional;
        private DevExpress.XtraBars.BarButtonItem btnImportarExcelLicencias;
        private DevExpress.XtraBars.BarButtonItem btnGenerarExcelLicencias;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralId_GrupoLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralCarnetNumeroAdicional2;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralEmisionCarnetAdicional2;
        private DevExpress.XtraGrid.Columns.GridColumn colLaboralVencimientoCarnetAdicional2;
    }
}