namespace VENET_Gestion_UI
{
    partial class frmPedidos
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label fecha_DesdeLabel;
            System.Windows.Forms.Label fecha_HastaLabel;
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label fechaEntrega_DesdeLabel;
            System.Windows.Forms.Label fechaEntrega_HastaLabel;
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
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnComprobante = new DevExpress.XtraBars.BarButtonItem();
            this.btnResultado = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnConfirmar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnEntregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnularEntrega = new DevExpress.XtraBars.BarButtonItem();
            this.btnDescuentos = new DevExpress.XtraBars.BarButtonItem();
            this.btnGeneraCompVenta = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerarVentaParcial = new DevExpress.XtraBars.BarButtonItem();
            this.btnGeneraPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnviarMail = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.btnEstado = new DevExpress.XtraBars.BarButtonItem();
            this.btnCtaCteEntidad = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.pedidosManager_ParametrosBusquedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_SucursalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.pedidosManager_SearchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TalonariosComprobantes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_TipoEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Entidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntregado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaLiquidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoAnulacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_ComprobanteGenerado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntregado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBusquedaAvanzada = new DevExpress.XtraEditors.GroupControl();
            this.fecha_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fecha_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.tipoEntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_EntidadLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaEntrega_HastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fechaEntrega_DesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAvanzada = new DevExpress.XtraEditors.CheckButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.estadoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            fecha_DesdeLabel = new System.Windows.Forms.Label();
            fecha_HastaLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            fechaEntrega_DesdeLabel = new System.Windows.Forms.Label();
            fechaEntrega_HastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosManager_ParametrosBusquedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosManager_SearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).BeginInit();
            this.gcBusquedaAvanzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_HastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_HastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_DesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_DesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(198, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 14;
            label1.Text = "Sucursal:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(40, 78);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 13;
            label2.Text = "Entidad:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(44, 26);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(43, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Pedido:";
            // 
            // fecha_DesdeLabel
            // 
            fecha_DesdeLabel.AutoSize = true;
            fecha_DesdeLabel.Location = new System.Drawing.Point(14, 52);
            fecha_DesdeLabel.Name = "fecha_DesdeLabel";
            fecha_DesdeLabel.Size = new System.Drawing.Size(73, 13);
            fecha_DesdeLabel.TabIndex = 2;
            fecha_DesdeLabel.Text = "Fecha Desde:";
            // 
            // fecha_HastaLabel
            // 
            fecha_HastaLabel.AutoSize = true;
            fecha_HastaLabel.Location = new System.Drawing.Point(210, 52);
            fecha_HastaLabel.Name = "fecha_HastaLabel";
            fecha_HastaLabel.Size = new System.Drawing.Size(39, 13);
            fecha_HastaLabel.TabIndex = 4;
            fecha_HastaLabel.Text = "Hasta:";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new System.Drawing.Point(12, 9);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(44, 13);
            estadoLabel.TabIndex = 0;
            estadoLabel.Text = "Estado:";
            // 
            // fechaEntrega_DesdeLabel
            // 
            fechaEntrega_DesdeLabel.AutoSize = true;
            fechaEntrega_DesdeLabel.Location = new System.Drawing.Point(176, 9);
            fechaEntrega_DesdeLabel.Name = "fechaEntrega_DesdeLabel";
            fechaEntrega_DesdeLabel.Size = new System.Drawing.Size(82, 13);
            fechaEntrega_DesdeLabel.TabIndex = 14;
            fechaEntrega_DesdeLabel.Text = "Entrega Desde:";
            // 
            // fechaEntrega_HastaLabel
            // 
            fechaEntrega_HastaLabel.AutoSize = true;
            fechaEntrega_HastaLabel.Location = new System.Drawing.Point(381, 9);
            fechaEntrega_HastaLabel.Name = "fechaEntrega_HastaLabel";
            fechaEntrega_HastaLabel.Size = new System.Drawing.Size(39, 13);
            fechaEntrega_HastaLabel.TabIndex = 15;
            fechaEntrega_HastaLabel.Text = "Hasta:";
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
            this.btnComprobante,
            this.barSubItem2,
            this.barButtonItem1,
            this.barSubItem3,
            this.btnConfirmar,
            this.btnAnular,
            this.barSubItem4,
            this.btnCtaCteEntidad,
            this.btnGeneraCompVenta,
            this.btnGeneraPDF,
            this.btnEnviarMail,
            this.btnEntregar,
            this.btnEstado,
            this.btnAnularEntrega,
            this.btnDescuentos,
            this.btnGenerarVentaParcial});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 26;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_Gestion_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.Glyph = global::VENET_Gestion_UI.Properties.Resources.loadfrom_16x16;
            this.btnModificar.Id = 1;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModificar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_Gestion_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 2;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Imprimir";
            this.barSubItem1.Glyph = global::VENET_Gestion_UI.Properties.Resources.print_16x16;
            this.barSubItem1.Id = 3;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComprobante),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnResultado, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnComprobante
            // 
            this.btnComprobante.Caption = "Comprobante";
            this.btnComprobante.Id = 6;
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComprobante_ItemClick);
            // 
            // btnResultado
            // 
            this.btnResultado.Caption = "Resultado de la Búsqueda";
            this.btnResultado.Id = 4;
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResultado_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Operaciones";
            this.barSubItem3.Glyph = global::VENET_Gestion_UI.Properties.Resources.properties_16x16;
            this.barSubItem3.Id = 10;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConfirmar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEntregar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnularEntrega),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDescuentos, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGeneraCompVenta, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarVentaParcial),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGeneraPDF, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEnviarMail)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Caption = "Confirmar";
            this.btnConfirmar.Id = 11;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Id = 12;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Caption = "Entregar Pedido";
            this.btnEntregar.Id = 21;
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEntregar_ItemClick);
            // 
            // btnAnularEntrega
            // 
            this.btnAnularEntrega.Caption = "Anular Entrega Pedido";
            this.btnAnularEntrega.Id = 23;
            this.btnAnularEntrega.Name = "btnAnularEntrega";
            this.btnAnularEntrega.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnularEntrega_ItemClick);
            // 
            // btnDescuentos
            // 
            this.btnDescuentos.Caption = "Cargar Descuentos";
            this.btnDescuentos.Id = 24;
            this.btnDescuentos.Name = "btnDescuentos";
            this.btnDescuentos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDescuentos_ItemClick);
            // 
            // btnGeneraCompVenta
            // 
            this.btnGeneraCompVenta.Caption = "Generar Comprobante Venta";
            this.btnGeneraCompVenta.Id = 15;
            this.btnGeneraCompVenta.Name = "btnGeneraCompVenta";
            this.btnGeneraCompVenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGeneraCompVenta_ItemClick);
            // 
            // btnGenerarVentaParcial
            // 
            this.btnGenerarVentaParcial.Caption = "Generar Comprobante Venta Parcial";
            this.btnGenerarVentaParcial.Id = 25;
            this.btnGenerarVentaParcial.Name = "btnGenerarVentaParcial";
            this.btnGenerarVentaParcial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfirmarParcial_ItemClick);
            // 
            // btnGeneraPDF
            // 
            this.btnGeneraPDF.Caption = "Generar PDF";
            this.btnGeneraPDF.Id = 16;
            this.btnGeneraPDF.Name = "btnGeneraPDF";
            this.btnGeneraPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGeneraPDF_ItemClick);
            // 
            // btnEnviarMail
            // 
            this.btnEnviarMail.Caption = "Enviar por Mail";
            this.btnEnviarMail.Id = 17;
            this.btnEnviarMail.Name = "btnEnviarMail";
            this.btnEnviarMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEnviarMail_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Ver";
            this.barSubItem4.Glyph = global::VENET_Gestion_UI.Properties.Resources.info_16x16;
            this.barSubItem4.Id = 13;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEstado, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCtaCteEntidad, true)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // btnEstado
            // 
            this.btnEstado.Caption = "Estado del Pedido";
            this.btnEstado.Id = 22;
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEstado_ItemClick);
            // 
            // btnCtaCteEntidad
            // 
            this.btnCtaCteEntidad.Caption = "Cuenta Corriente de la Entidad";
            this.btnCtaCteEntidad.Id = 14;
            this.btnCtaCteEntidad.Name = "btnCtaCteEntidad";
            this.btnCtaCteEntidad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCtaCteEntidad_ItemClick);
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Operaciones";
            this.barSubItem2.Id = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // pedidosManager_ParametrosBusquedasBindingSource
            // 
            this.pedidosManager_ParametrosBusquedasBindingSource.DataSource = typeof(VENET_Gestion_BL.PedidosManager.ParametrosBusquedas);
            // 
            // id_SucursalLookUpEdit
            // 
            this.id_SucursalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Id_Sucursal", true));
            this.id_SucursalLookUpEdit.EnterMoveNextControl = true;
            this.id_SucursalLookUpEdit.Location = new System.Drawing.Point(255, 23);
            this.id_SucursalLookUpEdit.MenuManager = this.barManager1;
            this.id_SucursalLookUpEdit.Name = "id_SucursalLookUpEdit";
            this.id_SucursalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_SucursalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Empresa", "Empresa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sucursal", "Sucursal")});
            this.id_SucursalLookUpEdit.Properties.NullText = "";
            this.id_SucursalLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.id_SucursalLookUpEdit.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.pedidosManager_SearchResultBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 161);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 275);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // pedidosManager_SearchResultBindingSource
            // 
            this.pedidosManager_SearchResultBindingSource.DataSource = typeof(VENET_Gestion_BL.PedidosManager.SearchResult);
            this.pedidosManager_SearchResultBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.pedidosManager_SearchResultBindingSource_ListChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSucursal,
            this.colNombre_Entidad,
            this.colDias,
            this.colId_Sucursal,
            this.colId_TalonariosComprobantes,
            this.colLetra,
            this.colPuntoVenta,
            this.colNroComprobante,
            this.colId_TipoEntidad,
            this.colId_Entidad,
            this.colId_Vendedor,
            this.colFecha,
            this.colFechaEntrega,
            this.colObservaciones,
            this.colFechaEntregado,
            this.colFechaLiquidacion,
            this.colFechaAnulacion,
            this.colMotivoAnulacion,
            this.colId_ComprobanteGenerado,
            this.colDetalle,
            this.colComprobante,
            this.colAvance,
            this.colEntregado,
            this.colId,
            this.colFechaAdd,
            this.colFechaMod,
            this.colUserAdd,
            this.colUserMod});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[FechaLiquidacion] = ?";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[FechaAnulacion] <> ?";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleExpression3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            formatConditionRuleExpression3.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression3.Expression = "[Id_ComprobanteGenerado] = ? And [FechaAnulacion] = ? And [FechaLiquidacion] <> ?" +
    "";
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
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            // 
            // colNombre_Entidad
            // 
            this.colNombre_Entidad.Caption = "Entidad";
            this.colNombre_Entidad.FieldName = "Nombre_Entidad";
            this.colNombre_Entidad.Name = "colNombre_Entidad";
            this.colNombre_Entidad.Visible = true;
            this.colNombre_Entidad.VisibleIndex = 0;
            this.colNombre_Entidad.Width = 89;
            // 
            // colDias
            // 
            this.colDias.FieldName = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.OptionsColumn.ReadOnly = true;
            this.colDias.Visible = true;
            this.colDias.VisibleIndex = 6;
            this.colDias.Width = 83;
            // 
            // colId_Sucursal
            // 
            this.colId_Sucursal.FieldName = "Id_Sucursal";
            this.colId_Sucursal.Name = "colId_Sucursal";
            // 
            // colId_TalonariosComprobantes
            // 
            this.colId_TalonariosComprobantes.FieldName = "Id_TalonariosComprobantes";
            this.colId_TalonariosComprobantes.Name = "colId_TalonariosComprobantes";
            // 
            // colLetra
            // 
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            // 
            // colPuntoVenta
            // 
            this.colPuntoVenta.FieldName = "PuntoVenta";
            this.colPuntoVenta.Name = "colPuntoVenta";
            // 
            // colNroComprobante
            // 
            this.colNroComprobante.FieldName = "NroComprobante";
            this.colNroComprobante.Name = "colNroComprobante";
            this.colNroComprobante.Visible = true;
            this.colNroComprobante.VisibleIndex = 1;
            this.colNroComprobante.Width = 121;
            // 
            // colId_TipoEntidad
            // 
            this.colId_TipoEntidad.FieldName = "Id_TipoEntidad";
            this.colId_TipoEntidad.Name = "colId_TipoEntidad";
            // 
            // colId_Entidad
            // 
            this.colId_Entidad.FieldName = "Id_Entidad";
            this.colId_Entidad.Name = "colId_Entidad";
            // 
            // colId_Vendedor
            // 
            this.colId_Vendedor.FieldName = "Id_Vendedor";
            this.colId_Vendedor.Name = "colId_Vendedor";
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colFechaEntrega
            // 
            this.colFechaEntrega.FieldName = "FechaEntrega";
            this.colFechaEntrega.Name = "colFechaEntrega";
            this.colFechaEntrega.Visible = true;
            this.colFechaEntrega.VisibleIndex = 3;
            this.colFechaEntrega.Width = 83;
            // 
            // colObservaciones
            // 
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // colFechaEntregado
            // 
            this.colFechaEntregado.FieldName = "FechaEntregado";
            this.colFechaEntregado.Name = "colFechaEntregado";
            this.colFechaEntregado.Visible = true;
            this.colFechaEntregado.VisibleIndex = 4;
            this.colFechaEntregado.Width = 83;
            // 
            // colFechaLiquidacion
            // 
            this.colFechaLiquidacion.FieldName = "FechaLiquidacion";
            this.colFechaLiquidacion.Name = "colFechaLiquidacion";
            this.colFechaLiquidacion.Visible = true;
            this.colFechaLiquidacion.VisibleIndex = 2;
            this.colFechaLiquidacion.Width = 83;
            // 
            // colFechaAnulacion
            // 
            this.colFechaAnulacion.FieldName = "FechaAnulacion";
            this.colFechaAnulacion.Name = "colFechaAnulacion";
            // 
            // colMotivoAnulacion
            // 
            this.colMotivoAnulacion.FieldName = "MotivoAnulacion";
            this.colMotivoAnulacion.Name = "colMotivoAnulacion";
            // 
            // colId_ComprobanteGenerado
            // 
            this.colId_ComprobanteGenerado.FieldName = "Id_ComprobanteGenerado";
            this.colId_ComprobanteGenerado.Name = "colId_ComprobanteGenerado";
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.ReadOnly = true;
            // 
            // colAvance
            // 
            this.colAvance.FieldName = "Avance";
            this.colAvance.Name = "colAvance";
            this.colAvance.OptionsColumn.ReadOnly = true;
            this.colAvance.Visible = true;
            this.colAvance.VisibleIndex = 5;
            this.colAvance.Width = 83;
            // 
            // colEntregado
            // 
            this.colEntregado.FieldName = "Entregado";
            this.colEntregado.Name = "colEntregado";
            this.colEntregado.OptionsColumn.ReadOnly = true;
            this.colEntregado.Width = 91;
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
            // gcBusquedaAvanzada
            // 
            this.gcBusquedaAvanzada.Controls.Add(fecha_HastaLabel);
            this.gcBusquedaAvanzada.Controls.Add(label1);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_HastaDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(fecha_DesdeLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.id_SucursalLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(this.fecha_DesdeDateEdit);
            this.gcBusquedaAvanzada.Controls.Add(label2);
            this.gcBusquedaAvanzada.Controls.Add(this.tipoEntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(this.id_EntidadLookUpEdit);
            this.gcBusquedaAvanzada.Controls.Add(idLabel);
            this.gcBusquedaAvanzada.Controls.Add(this.idTextEdit);
            this.gcBusquedaAvanzada.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBusquedaAvanzada.Location = new System.Drawing.Point(0, 56);
            this.gcBusquedaAvanzada.Name = "gcBusquedaAvanzada";
            this.gcBusquedaAvanzada.Size = new System.Drawing.Size(734, 105);
            this.gcBusquedaAvanzada.TabIndex = 1;
            this.gcBusquedaAvanzada.Text = "Búsqueda Avanzada";
            // 
            // fecha_HastaDateEdit
            // 
            this.fecha_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Fecha_Hasta", true));
            this.fecha_HastaDateEdit.EditValue = null;
            this.fecha_HastaDateEdit.EnterMoveNextControl = true;
            this.fecha_HastaDateEdit.Location = new System.Drawing.Point(255, 49);
            this.fecha_HastaDateEdit.MenuManager = this.barManager1;
            this.fecha_HastaDateEdit.Name = "fecha_HastaDateEdit";
            this.fecha_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.fecha_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_HastaDateEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedFecha);
            this.fecha_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_HastaDateEdit.TabIndex = 3;
            // 
            // fecha_DesdeDateEdit
            // 
            this.fecha_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Fecha_Desde", true));
            this.fecha_DesdeDateEdit.EditValue = null;
            this.fecha_DesdeDateEdit.EnterMoveNextControl = true;
            this.fecha_DesdeDateEdit.Location = new System.Drawing.Point(93, 49);
            this.fecha_DesdeDateEdit.MenuManager = this.barManager1;
            this.fecha_DesdeDateEdit.Name = "fecha_DesdeDateEdit";
            this.fecha_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha_DesdeDateEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedFecha);
            this.fecha_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fecha_DesdeDateEdit.TabIndex = 2;
            // 
            // tipoEntidadLookUpEdit
            // 
            this.tipoEntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "TipoEntidad", true));
            this.tipoEntidadLookUpEdit.EnterMoveNextControl = true;
            this.tipoEntidadLookUpEdit.Location = new System.Drawing.Point(93, 75);
            this.tipoEntidadLookUpEdit.MenuManager = this.barManager1;
            this.tipoEntidadLookUpEdit.Name = "tipoEntidadLookUpEdit";
            this.tipoEntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.tipoEntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name18")});
            this.tipoEntidadLookUpEdit.Properties.NullText = "";
            this.tipoEntidadLookUpEdit.Properties.ShowHeader = false;
            this.tipoEntidadLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.tipoEntidadLookUpEdit.TabIndex = 4;
            this.tipoEntidadLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedEntidad);
            this.tipoEntidadLookUpEdit.EditValueChanged += new System.EventHandler(this.tipoEntidadLookUpEdit_EditValueChanged);
            // 
            // id_EntidadLookUpEdit
            // 
            this.id_EntidadLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Id_Entidad", true));
            this.id_EntidadLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadLookUpEdit.Location = new System.Drawing.Point(202, 75);
            this.id_EntidadLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadLookUpEdit.Name = "id_EntidadLookUpEdit";
            this.id_EntidadLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_EntidadLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name19")});
            this.id_EntidadLookUpEdit.Properties.NullText = "";
            this.id_EntidadLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadLookUpEdit.Size = new System.Drawing.Size(359, 20);
            this.id_EntidadLookUpEdit.TabIndex = 5;
            this.id_EntidadLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedEntidad);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Id_Pedido", true));
            this.idTextEdit.EnterMoveNextControl = true;
            this.idTextEdit.Location = new System.Drawing.Point(93, 23);
            this.idTextEdit.MenuManager = this.barManager1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(100, 20);
            this.idTextEdit.TabIndex = 0;
            this.idTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // fechaEntrega_HastaDateEdit
            // 
            this.fechaEntrega_HastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "FechaEntrega_Hasta", true));
            this.fechaEntrega_HastaDateEdit.EditValue = null;
            this.fechaEntrega_HastaDateEdit.EnterMoveNextControl = true;
            this.fechaEntrega_HastaDateEdit.Location = new System.Drawing.Point(426, 6);
            this.fechaEntrega_HastaDateEdit.MenuManager = this.barManager1;
            this.fechaEntrega_HastaDateEdit.Name = "fechaEntrega_HastaDateEdit";
            this.fechaEntrega_HastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.fechaEntrega_HastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaEntrega_HastaDateEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedFecha);
            this.fechaEntrega_HastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaEntrega_HastaDateEdit.TabIndex = 2;
            // 
            // fechaEntrega_DesdeDateEdit
            // 
            this.fechaEntrega_DesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "FechaEntrega_Desde", true));
            this.fechaEntrega_DesdeDateEdit.EditValue = null;
            this.fechaEntrega_DesdeDateEdit.EnterMoveNextControl = true;
            this.fechaEntrega_DesdeDateEdit.Location = new System.Drawing.Point(264, 6);
            this.fechaEntrega_DesdeDateEdit.MenuManager = this.barManager1;
            this.fechaEntrega_DesdeDateEdit.Name = "fechaEntrega_DesdeDateEdit";
            this.fechaEntrega_DesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.fechaEntrega_DesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaEntrega_DesdeDateEdit.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressedFecha);
            this.fechaEntrega_DesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaEntrega_DesdeDateEdit.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(647, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAvanzada
            // 
            this.btnAvanzada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvanzada.Image = global::VENET_Gestion_UI.Properties.Resources.filter_16x16;
            this.btnAvanzada.Location = new System.Drawing.Point(618, 4);
            this.btnAvanzada.Name = "btnAvanzada";
            this.btnAvanzada.Size = new System.Drawing.Size(23, 23);
            this.btnAvanzada.TabIndex = 3;
            this.btnAvanzada.CheckedChanged += new System.EventHandler(this.btnAvanzada_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(fechaEntrega_HastaLabel);
            this.panelControl1.Controls.Add(estadoLabel);
            this.panelControl1.Controls.Add(this.fechaEntrega_HastaDateEdit);
            this.panelControl1.Controls.Add(this.estadoLookUpEdit);
            this.panelControl1.Controls.Add(fechaEntrega_DesdeLabel);
            this.panelControl1.Controls.Add(this.fechaEntrega_DesdeDateEdit);
            this.panelControl1.Controls.Add(this.btnAvanzada);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(734, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // estadoLookUpEdit
            // 
            this.estadoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pedidosManager_ParametrosBusquedasBindingSource, "Estado", true));
            this.estadoLookUpEdit.EnterMoveNextControl = true;
            this.estadoLookUpEdit.Location = new System.Drawing.Point(62, 6);
            this.estadoLookUpEdit.MenuManager = this.barManager1;
            this.estadoLookUpEdit.Name = "estadoLookUpEdit";
            this.estadoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.estadoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name1")});
            this.estadoLookUpEdit.Properties.NullText = "";
            this.estadoLookUpEdit.Properties.ShowHeader = false;
            this.estadoLookUpEdit.Size = new System.Drawing.Size(108, 20);
            this.estadoLookUpEdit.TabIndex = 0;
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gcBusquedaAvanzada);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(649, 313);
            this.Name = "frmPedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosManager_ParametrosBusquedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_SucursalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosManager_SearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBusquedaAvanzada)).EndInit();
            this.gcBusquedaAvanzada.ResumeLayout(false);
            this.gcBusquedaAvanzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoEntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_HastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_HastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_DesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaEntrega_DesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadoLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnResultado;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private System.Windows.Forms.BindingSource pedidosManager_ParametrosBusquedasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_SucursalLookUpEdit;
        private System.Windows.Forms.BindingSource pedidosManager_SearchResultBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnComprobante;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnConfirmar;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem btnCtaCteEntidad;
        private DevExpress.XtraBars.BarButtonItem btnGeneraCompVenta;
        private DevExpress.XtraBars.BarButtonItem btnGeneraPDF;
        private DevExpress.XtraBars.BarButtonItem btnEnviarMail;
        private DevExpress.XtraEditors.GroupControl gcBusquedaAvanzada;
        private DevExpress.XtraEditors.LookUpEdit tipoEntidadLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadLookUpEdit;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckButton btnAvanzada;
        private System.Windows.Forms.Button btnBuscar;
        private DevExpress.XtraEditors.DateEdit fecha_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fecha_DesdeDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaEntrega_HastaDateEdit;
        private DevExpress.XtraEditors.DateEdit fechaEntrega_DesdeDateEdit;
        private DevExpress.XtraEditors.LookUpEdit estadoLookUpEdit;
        private DevExpress.XtraBars.BarButtonItem btnEntregar;
        private DevExpress.XtraBars.BarButtonItem btnEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colDias;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TalonariosComprobantes;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colNroComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colId_TipoEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Entidad;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntregado;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaLiquidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoAnulacion;
        private DevExpress.XtraGrid.Columns.GridColumn colId_ComprobanteGenerado;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colAvance;
        private DevExpress.XtraGrid.Columns.GridColumn colEntregado;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMod;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colUserMod;
        private DevExpress.XtraBars.BarButtonItem btnAnularEntrega;
        private DevExpress.XtraBars.BarButtonItem btnDescuentos;
        private DevExpress.XtraBars.BarButtonItem btnGenerarVentaParcial;
    }
}