namespace VENET_Tesoreria_UI
{
    partial class frmVales
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
            System.Windows.Forms.Label fechaDesdeLabel;
            System.Windows.Forms.Label fechaHastaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label id_CajaLabel;
            System.Windows.Forms.Label estadoLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeVale = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnRendir = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransferir = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnModeloExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnRendicion = new DevExpress.XtraBars.BarButtonItem();
            this.btnCtaCte = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.estadoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.valesManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_PersonalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lnkPersonal = new System.Windows.Forms.LinkLabel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_CajaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.valesManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaRendicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Personal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaConfirmacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Rendicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Caja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegajo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_CentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEmail = new DevExpress.XtraBars.BarButtonItem();
            idLabel = new System.Windows.Forms.Label();
            fechaDesdeLabel = new System.Windows.Forms.Label();
            fechaHastaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            id_CajaLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_PersonalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(9, 35);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(32, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Nro.:";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new System.Drawing.Point(147, 9);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new System.Drawing.Size(73, 13);
            fechaDesdeLabel.TabIndex = 2;
            fechaDesdeLabel.Text = "Fecha Desde:";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new System.Drawing.Point(326, 9);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new System.Drawing.Size(71, 13);
            fechaHastaLabel.TabIndex = 4;
            fechaHastaLabel.Text = "Fecha Hasta:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(331, 35);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 8;
            descripcionLabel.Text = "Descripción:";
            // 
            // id_CajaLabel
            // 
            id_CajaLabel.AutoSize = true;
            id_CajaLabel.Location = new System.Drawing.Point(8, 9);
            id_CajaLabel.Name = "id_CajaLabel";
            id_CajaLabel.Size = new System.Drawing.Size(33, 13);
            id_CajaLabel.TabIndex = 11;
            id_CajaLabel.Text = "Caja:";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new System.Drawing.Point(502, 9);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(44, 13);
            estadoLabel.TabIndex = 14;
            estadoLabel.Text = "Estado:";
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
            this.btnAgregar,
            this.btnModificar,
            this.btnEliminar,
            this.barSubItem1,
            this.btnConfirmar,
            this.barSubItem2,
            this.btnResultado,
            this.btnAnular,
            this.btnRendir,
            this.btnImprimeVale,
            this.barSubItem3,
            this.btnRendicion,
            this.btnTransferir,
            this.btnModeloExcel,
            this.btnImportarExcel,
            this.btnCtaCte,
            this.btnEmail});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 19;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 1;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 2;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.deletelist2_16x16;
            this.btnEliminar.Id = 3;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 6;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeVale),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResultado, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnImprimeVale
            // 
            this.btnImprimeVale.Caption = "Vale";
            this.btnImprimeVale.Id = 11;
            this.btnImprimeVale.Name = "btnImprimeVale";
            this.btnImprimeVale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeVale_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 7;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Operaciones";
            this.barSubItem1.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.properties_16x16;
            this.barSubItem1.Id = 4;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRendir, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTransferir, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEmail, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportarExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnModeloExcel)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Caption = "Confirmar";
            this.btnConfirmar.Id = 5;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Id = 9;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
            // 
            // btnRendir
            // 
            this.btnRendir.Caption = "Rendir";
            this.btnRendir.Id = 10;
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRendir_ItemClick);
            // 
            // btnTransferir
            // 
            this.btnTransferir.Caption = "Transferir Vales";
            this.btnTransferir.Id = 14;
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransferir_ItemClick);
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.Caption = "Importar Excel con Vales";
            this.btnImportarExcel.Id = 16;
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportarExcel_ItemClick);
            // 
            // btnModeloExcel
            // 
            this.btnModeloExcel.Caption = "Generar Modelo Excel Importación";
            this.btnModeloExcel.Id = 15;
            this.btnModeloExcel.Name = "btnModeloExcel";
            this.btnModeloExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModeloExcel_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Ver";
            this.barSubItem3.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.info_16x16;
            this.barSubItem3.Id = 12;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRendicion),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCtaCte, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnRendicion
            // 
            this.btnRendicion.Caption = "Rendición de Vale";
            this.btnRendicion.Id = 13;
            this.btnRendicion.Name = "btnRendicion";
            this.btnRendicion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRendicion_ItemClick);
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.Caption = "Cuenta Corriente de la Entidad";
            this.btnCtaCte.Id = 17;
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCtaCte_ItemClick);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(estadoLabel);
            this.panelControl1.Controls.Add(this.estadoLookUpEdit);
            this.panelControl1.Controls.Add(this.id_PersonalLookUpEdit);
            this.panelControl1.Controls.Add(id_CajaLabel);
            this.panelControl1.Controls.Add(this.lnkPersonal);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(descripcionLabel);
            this.panelControl1.Controls.Add(this.descripcionTextEdit);
            this.panelControl1.Controls.Add(fechaHastaLabel);
            this.panelControl1.Controls.Add(this.fechaHastaDateEdit);
            this.panelControl1.Controls.Add(fechaDesdeLabel);
            this.panelControl1.Controls.Add(this.fechaDesdeDateEdit);
            this.panelControl1.Controls.Add(idLabel);
            this.panelControl1.Controls.Add(this.idTextEdit);
            this.panelControl1.Controls.Add(this.id_CajaLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // estadoLookUpEdit
            // 
            this.estadoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "Estado", true));
            this.estadoLookUpEdit.Location = new System.Drawing.Point(548, 6);
            this.estadoLookUpEdit.MenuManager = this.barManager1;
            this.estadoLookUpEdit.Name = "estadoLookUpEdit";
            this.estadoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.estadoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name3")});
            this.estadoLookUpEdit.Properties.NullText = "";
            this.estadoLookUpEdit.Properties.ShowHeader = false;
            this.estadoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.estadoLookUpEdit.TabIndex = 15;
            // 
            // valesManager_ParametrosBusquedasBindingSource
            // 
            this.valesManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ValesManager.ParametrosBusquedas);
            // 
            // id_PersonalLookUpEdit
            // 
            this.id_PersonalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "Id_Personal", true));
            this.id_PersonalLookUpEdit.Location = new System.Drawing.Point(222, 33);
            this.id_PersonalLookUpEdit.MenuManager = this.barManager1;
            this.id_PersonalLookUpEdit.Name = "id_PersonalLookUpEdit";
            this.id_PersonalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_PersonalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Legajo", 5, "Legajo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.id_PersonalLookUpEdit.Properties.NullText = "";
            this.id_PersonalLookUpEdit.Properties.PopupWidth = 250;
            this.id_PersonalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_PersonalLookUpEdit.TabIndex = 14;
            this.id_PersonalLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // lnkPersonal
            // 
            this.lnkPersonal.AutoSize = true;
            this.lnkPersonal.Location = new System.Drawing.Point(168, 35);
            this.lnkPersonal.Name = "lnkPersonal";
            this.lnkPersonal.Size = new System.Drawing.Size(52, 13);
            this.lnkPersonal.TabIndex = 11;
            this.lnkPersonal.TabStop = true;
            this.lnkPersonal.Text = "Personal:";
            this.lnkPersonal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPersonal_LinkClicked);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(654, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(398, 32);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionTextEdit.TabIndex = 5;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fechaHastaDateEdit
            // 
            this.fechaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "FechaHasta", true));
            this.fechaHastaDateEdit.EditValue = null;
            this.fechaHastaDateEdit.Location = new System.Drawing.Point(399, 6);
            this.fechaHastaDateEdit.MenuManager = this.barManager1;
            this.fechaHastaDateEdit.Name = "fechaHastaDateEdit";
            this.fechaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaHastaDateEdit.TabIndex = 2;
            // 
            // fechaDesdeDateEdit
            // 
            this.fechaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "FechaDesde", true));
            this.fechaDesdeDateEdit.EditValue = null;
            this.fechaDesdeDateEdit.Location = new System.Drawing.Point(222, 6);
            this.fechaDesdeDateEdit.MenuManager = this.barManager1;
            this.fechaDesdeDateEdit.Name = "fechaDesdeDateEdit";
            this.fechaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDesdeDateEdit.TabIndex = 1;
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "Numero", true));
            this.idTextEdit.Location = new System.Drawing.Point(43, 32);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 3;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_CajaLookUpEdit
            // 
            this.id_CajaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManager_ParametrosBusquedasBindingSource, "Id_Caja", true));
            this.id_CajaLookUpEdit.EnterMoveNextControl = true;
            this.id_CajaLookUpEdit.Location = new System.Drawing.Point(43, 6);
            this.id_CajaLookUpEdit.MenuManager = this.barManager1;
            this.id_CajaLookUpEdit.Name = "id_CajaLookUpEdit";
            this.id_CajaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_CajaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caja", "Caja"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Especie", "Especie"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa")});
            this.id_CajaLookUpEdit.Properties.NullText = "";
            this.id_CajaLookUpEdit.Properties.PopupWidth = 500;
            this.id_CajaLookUpEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_CajaLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_CajaLookUpEdit.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.valesManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 353);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick_1);
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // valesManager_SearchResultBindingSource
            // 
            this.valesManager_SearchResultBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ValesManager.SearchResult);
            this.valesManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.valesManager_SearchResultBindingSource_ListChanged_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonal,
            this.colFechaRendicion,
            this.colId,
            this.colFecha,
            this.colId_Personal,
            this.colImporte,
            this.colDescripcion,
            this.colFechaConfirmacion,
            this.colId_Rendicion,
            this.colFechaAdd,
            this.colFechaMod,
            this.colFechaDel,
            this.colUserAdd,
            this.colUserMod,
            this.colUserDel,
            this.colCaja,
            this.colId_Caja,
            this.colLegajo,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colId_CentroCosto,
            this.colCentroCosto,
            this.colNumero});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[Id_Rendicion] > 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression2.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression2.Expression = "[FechaConfirmacion] == ?";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleExpression3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression3.Appearance.ForeColor = System.Drawing.Color.Gray;
            formatConditionRuleExpression3.Appearance.Options.UseFont = true;
            formatConditionRuleExpression3.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression3.Expression = "[FechaAnulacion] != ?";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colPersonal
            // 
            this.colPersonal.FieldName = "Personal";
            this.colPersonal.Name = "colPersonal";
            this.colPersonal.OptionsColumn.AllowEdit = false;
            this.colPersonal.OptionsColumn.ReadOnly = true;
            this.colPersonal.Visible = true;
            this.colPersonal.VisibleIndex = 2;
            this.colPersonal.Width = 118;
            // 
            // colFechaRendicion
            // 
            this.colFechaRendicion.Caption = "F. Rendición";
            this.colFechaRendicion.FieldName = "FechaRendicion";
            this.colFechaRendicion.Name = "colFechaRendicion";
            this.colFechaRendicion.OptionsColumn.AllowEdit = false;
            this.colFechaRendicion.OptionsColumn.ReadOnly = true;
            this.colFechaRendicion.Visible = true;
            this.colFechaRendicion.VisibleIndex = 6;
            this.colFechaRendicion.Width = 109;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.colId.Width = 56;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 63;
            // 
            // colId_Personal
            // 
            this.colId_Personal.FieldName = "Id_Personal";
            this.colId_Personal.Name = "colId_Personal";
            this.colId_Personal.OptionsColumn.AllowEdit = false;
            this.colId_Personal.OptionsColumn.ReadOnly = true;
            this.colId_Personal.Width = 69;
            // 
            // colImporte
            // 
            this.colImporte.DisplayFormat.FormatString = "#,##0.00";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 4;
            this.colImporte.Width = 88;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            this.colDescripcion.Width = 195;
            // 
            // colFechaConfirmacion
            // 
            this.colFechaConfirmacion.Caption = "F. Confirmación";
            this.colFechaConfirmacion.FieldName = "FechaConfirmacion";
            this.colFechaConfirmacion.Name = "colFechaConfirmacion";
            this.colFechaConfirmacion.OptionsColumn.AllowEdit = false;
            this.colFechaConfirmacion.OptionsColumn.ReadOnly = true;
            this.colFechaConfirmacion.Visible = true;
            this.colFechaConfirmacion.VisibleIndex = 5;
            this.colFechaConfirmacion.Width = 95;
            // 
            // colId_Rendicion
            // 
            this.colId_Rendicion.FieldName = "Id_Rendicion";
            this.colId_Rendicion.Name = "colId_Rendicion";
            this.colId_Rendicion.OptionsColumn.AllowEdit = false;
            this.colId_Rendicion.OptionsColumn.ReadOnly = true;
            this.colId_Rendicion.Width = 69;
            // 
            // colFechaAdd
            // 
            this.colFechaAdd.FieldName = "FechaAdd";
            this.colFechaAdd.Name = "colFechaAdd";
            this.colFechaAdd.OptionsColumn.AllowEdit = false;
            this.colFechaAdd.OptionsColumn.ReadOnly = true;
            this.colFechaAdd.Width = 69;
            // 
            // colFechaMod
            // 
            this.colFechaMod.FieldName = "FechaMod";
            this.colFechaMod.Name = "colFechaMod";
            this.colFechaMod.OptionsColumn.AllowEdit = false;
            this.colFechaMod.OptionsColumn.ReadOnly = true;
            this.colFechaMod.Width = 69;
            // 
            // colFechaDel
            // 
            this.colFechaDel.FieldName = "FechaDel";
            this.colFechaDel.Name = "colFechaDel";
            this.colFechaDel.OptionsColumn.AllowEdit = false;
            this.colFechaDel.OptionsColumn.ReadOnly = true;
            this.colFechaDel.Width = 69;
            // 
            // colUserAdd
            // 
            this.colUserAdd.FieldName = "UserAdd";
            this.colUserAdd.Name = "colUserAdd";
            this.colUserAdd.OptionsColumn.AllowEdit = false;
            this.colUserAdd.OptionsColumn.ReadOnly = true;
            this.colUserAdd.Width = 69;
            // 
            // colUserMod
            // 
            this.colUserMod.FieldName = "UserMod";
            this.colUserMod.Name = "colUserMod";
            this.colUserMod.OptionsColumn.AllowEdit = false;
            this.colUserMod.OptionsColumn.ReadOnly = true;
            this.colUserMod.Width = 69;
            // 
            // colUserDel
            // 
            this.colUserDel.FieldName = "UserDel";
            this.colUserDel.Name = "colUserDel";
            this.colUserDel.OptionsColumn.AllowEdit = false;
            this.colUserDel.OptionsColumn.ReadOnly = true;
            this.colUserDel.Width = 82;
            // 
            // colCaja
            // 
            this.colCaja.Caption = "Caja";
            this.colCaja.FieldName = "Caja";
            this.colCaja.Name = "colCaja";
            this.colCaja.OptionsColumn.AllowEdit = false;
            this.colCaja.OptionsColumn.ReadOnly = true;
            // 
            // colId_Caja
            // 
            this.colId_Caja.Caption = "Id_Caja";
            this.colId_Caja.FieldName = "Id_Caja";
            this.colId_Caja.Name = "colId_Caja";
            this.colId_Caja.OptionsColumn.AllowEdit = false;
            this.colId_Caja.OptionsColumn.ReadOnly = true;
            // 
            // colLegajo
            // 
            this.colLegajo.Caption = "Legajo";
            this.colLegajo.FieldName = "Legajo";
            this.colLegajo.Name = "colLegajo";
            this.colLegajo.OptionsColumn.AllowEdit = false;
            this.colLegajo.OptionsColumn.ReadOnly = true;
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.Caption = "F. Anulación";
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.Caption = "Motivo Anulación";
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // colId_CentroCosto
            // 
            this.colId_CentroCosto.Caption = "Id_CentroCosto";
            this.colId_CentroCosto.FieldName = "Id_CentroCosto";
            this.colId_CentroCosto.Name = "colId_CentroCosto";
            // 
            // colCentroCosto
            // 
            this.colCentroCosto.Caption = "Centro de Costo";
            this.colCentroCosto.FieldName = "CentroCosto";
            this.colCentroCosto.Name = "colCentroCosto";
            // 
            // colNumero
            // 
            this.colNumero.Caption = "Número";
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            this.colNumero.Width = 48;
            // 
            // btnEmail
            // 
            this.btnEmail.Caption = "Enviar por EMail";
            this.btnEmail.Id = 18;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmail_ItemClick);
            // 
            // frmVales
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
            this.MinimumSize = new System.Drawing.Size(750, 242);
            this.Name = "frmVales";
            this.Text = "Vales";
            this.Load += new System.EventHandler(this.frmVales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_PersonalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CajaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnRendir;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource valesManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.DateEdit fechaHastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaDesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource valesManager_SearchResultBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonal;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaRendicion;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Personal;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaConfirmacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Rendicion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDel;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDel;
        private System.Windows.Forms.LinkLabel lnkPersonal;
        private DevExpress.XtraBars.BarButtonItem btnImprimeVale;
        private DevExpress.XtraEditors.LookUpEdit id_CajaLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCaja;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Caja;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnRendicion;
        private DevExpress.XtraEditors.LookUpEdit id_PersonalLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colLegajo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_CentroCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCosto;
        private DevExpress.XtraEditors.LookUpEdit estadoLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraBars.BarButtonItem btnTransferir;
        private DevExpress.XtraBars.BarButtonItem btnModeloExcel;
        private DevExpress.XtraBars.BarButtonItem btnImportarExcel;
        private DevExpress.XtraBars.BarButtonItem btnCtaCte;
        private DevExpress.XtraBars.BarButtonItem btnEmail;
    }
}