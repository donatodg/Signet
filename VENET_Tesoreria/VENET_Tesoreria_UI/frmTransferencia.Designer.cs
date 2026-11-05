namespace VENET_Tesoreria_UI
{
    partial class frmTransferencia
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
            System.Windows.Forms.Label idEspecieOrigenLabel;
            System.Windows.Forms.Label idEspecieDestinoLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label cotizacionEspecieOrigenLabel;
            System.Windows.Forms.Label cotizacionEspecieDestinoLabel;
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            System.Windows.Forms.Label debitoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnGuradar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.idEspecieDestinoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.transferenciasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cotizacionEspecieDestinoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.idEspecieOrigenLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.cotizacionEspecieOrigenTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.debitoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            idEspecieOrigenLabel = new System.Windows.Forms.Label();
            idEspecieDestinoLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            cotizacionEspecieOrigenLabel = new System.Windows.Forms.Label();
            cotizacionEspecieDestinoLabel = new System.Windows.Forms.Label();
            conceptoLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            debitoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieDestinoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionEspecieDestinoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieOrigenLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionEspecieOrigenTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debitoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // idEspecieOrigenLabel
            // 
            idEspecieOrigenLabel.AutoSize = true;
            idEspecieOrigenLabel.Location = new System.Drawing.Point(47, 27);
            idEspecieOrigenLabel.Name = "idEspecieOrigenLabel";
            idEspecieOrigenLabel.Size = new System.Drawing.Size(47, 13);
            idEspecieOrigenLabel.TabIndex = 0;
            idEspecieOrigenLabel.Text = "Especie:";
            // 
            // idEspecieDestinoLabel
            // 
            idEspecieDestinoLabel.AutoSize = true;
            idEspecieDestinoLabel.Location = new System.Drawing.Point(47, 27);
            idEspecieDestinoLabel.Name = "idEspecieDestinoLabel";
            idEspecieDestinoLabel.Size = new System.Drawing.Size(47, 13);
            idEspecieDestinoLabel.TabIndex = 2;
            idEspecieDestinoLabel.Text = "Especie:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(57, 158);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 4;
            importeLabel.Text = "Importe:";
            // 
            // cotizacionEspecieOrigenLabel
            // 
            cotizacionEspecieOrigenLabel.AutoSize = true;
            cotizacionEspecieOrigenLabel.Location = new System.Drawing.Point(36, 53);
            cotizacionEspecieOrigenLabel.Name = "cotizacionEspecieOrigenLabel";
            cotizacionEspecieOrigenLabel.Size = new System.Drawing.Size(60, 13);
            cotizacionEspecieOrigenLabel.TabIndex = 6;
            cotizacionEspecieOrigenLabel.Text = "Cotización:";
            // 
            // cotizacionEspecieDestinoLabel
            // 
            cotizacionEspecieDestinoLabel.AutoSize = true;
            cotizacionEspecieDestinoLabel.Location = new System.Drawing.Point(36, 53);
            cotizacionEspecieDestinoLabel.Name = "cotizacionEspecieDestinoLabel";
            cotizacionEspecieDestinoLabel.Size = new System.Drawing.Size(60, 13);
            cotizacionEspecieDestinoLabel.TabIndex = 8;
            cotizacionEspecieDestinoLabel.Text = "Cotización:";
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(46, 132);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 10;
            conceptoLabel.Text = "Concepto:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(31, 18);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(75, 13);
            id_CentroCostoLabel.TabIndex = 12;
            id_CentroCostoLabel.Text = "Centro Costo:";
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(306, 18);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(99, 13);
            id_TipoComprobanteLabel.TabIndex = 14;
            id_TipoComprobanteLabel.Text = "Tipo Comprobante:";
            // 
            // debitoLabel
            // 
            debitoLabel.AutoSize = true;
            debitoLabel.Location = new System.Drawing.Point(362, 158);
            debitoLabel.Name = "debitoLabel";
            debitoLabel.Size = new System.Drawing.Size(42, 13);
            debitoLabel.TabIndex = 16;
            debitoLabel.Text = "Debito:";
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
            this.btnGuradar});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuradar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnGuradar
            // 
            this.btnGuradar.Caption = "Aceptar";
            this.btnGuradar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnGuradar.Id = 0;
            this.btnGuradar.Name = "btnGuradar";
            this.btnGuradar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuradar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(632, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 235);
            this.barDockControlBottom.Size = new System.Drawing.Size(632, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 211);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(632, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 211);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(debitoLabel);
            this.groupControl1.Controls.Add(this.debitoTextEdit);
            this.groupControl1.Controls.Add(id_TipoComprobanteLabel);
            this.groupControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(conceptoLabel);
            this.groupControl1.Controls.Add(this.conceptoTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(608, 195);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.idEspecieDestinoLookUpEdit);
            this.groupControl3.Controls.Add(idEspecieDestinoLabel);
            this.groupControl3.Controls.Add(this.cotizacionEspecieDestinoTextEdit);
            this.groupControl3.Controls.Add(cotizacionEspecieDestinoLabel);
            this.groupControl3.Location = new System.Drawing.Point(308, 41);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(295, 82);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "Destino";
            // 
            // idEspecieDestinoLookUpEdit
            // 
            this.idEspecieDestinoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "IdEspecieDestino", true));
            this.idEspecieDestinoLookUpEdit.EnterMoveNextControl = true;
            this.idEspecieDestinoLookUpEdit.Location = new System.Drawing.Point(101, 24);
            this.idEspecieDestinoLookUpEdit.MenuManager = this.barManager1;
            this.idEspecieDestinoLookUpEdit.Name = "idEspecieDestinoLookUpEdit";
            this.idEspecieDestinoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idEspecieDestinoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre7")});
            this.idEspecieDestinoLookUpEdit.Properties.DisplayMember = "Name";
            this.idEspecieDestinoLookUpEdit.Properties.NullText = "";
            this.idEspecieDestinoLookUpEdit.Properties.ShowHeader = false;
            this.idEspecieDestinoLookUpEdit.Properties.ValueMember = "Key";
            this.idEspecieDestinoLookUpEdit.Size = new System.Drawing.Size(168, 20);
            this.idEspecieDestinoLookUpEdit.TabIndex = 0;
            // 
            // transferenciasManagerBindingSource
            // 
            this.transferenciasManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.TransferenciasManager);
            // 
            // cotizacionEspecieDestinoTextEdit
            // 
            this.cotizacionEspecieDestinoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "CotizacionEspecieDestino", true));
            this.cotizacionEspecieDestinoTextEdit.EnterMoveNextControl = true;
            this.cotizacionEspecieDestinoTextEdit.Location = new System.Drawing.Point(101, 50);
            this.cotizacionEspecieDestinoTextEdit.MenuManager = this.barManager1;
            this.cotizacionEspecieDestinoTextEdit.Name = "cotizacionEspecieDestinoTextEdit";
            this.cotizacionEspecieDestinoTextEdit.Properties.DisplayFormat.FormatString = "n4";
            this.cotizacionEspecieDestinoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cotizacionEspecieDestinoTextEdit.Properties.EditFormat.FormatString = "n4";
            this.cotizacionEspecieDestinoTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cotizacionEspecieDestinoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.cotizacionEspecieDestinoTextEdit.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.idEspecieOrigenLookUpEdit);
            this.groupControl2.Controls.Add(idEspecieOrigenLabel);
            this.groupControl2.Controls.Add(this.cotizacionEspecieOrigenTextEdit);
            this.groupControl2.Controls.Add(cotizacionEspecieOrigenLabel);
            this.groupControl2.Location = new System.Drawing.Point(7, 41);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(295, 82);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Origen";
            // 
            // idEspecieOrigenLookUpEdit
            // 
            this.idEspecieOrigenLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "IdEspecieOrigen", true));
            this.idEspecieOrigenLookUpEdit.EnterMoveNextControl = true;
            this.idEspecieOrigenLookUpEdit.Location = new System.Drawing.Point(101, 24);
            this.idEspecieOrigenLookUpEdit.MenuManager = this.barManager1;
            this.idEspecieOrigenLookUpEdit.Name = "idEspecieOrigenLookUpEdit";
            this.idEspecieOrigenLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idEspecieOrigenLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.idEspecieOrigenLookUpEdit.Properties.DisplayMember = "Name";
            this.idEspecieOrigenLookUpEdit.Properties.NullText = "";
            this.idEspecieOrigenLookUpEdit.Properties.ShowHeader = false;
            this.idEspecieOrigenLookUpEdit.Properties.ValueMember = "Key";
            this.idEspecieOrigenLookUpEdit.Size = new System.Drawing.Size(168, 20);
            this.idEspecieOrigenLookUpEdit.TabIndex = 0;
            // 
            // cotizacionEspecieOrigenTextEdit
            // 
            this.cotizacionEspecieOrigenTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "CotizacionEspecieOrigen", true));
            this.cotizacionEspecieOrigenTextEdit.EnterMoveNextControl = true;
            this.cotizacionEspecieOrigenTextEdit.Location = new System.Drawing.Point(101, 50);
            this.cotizacionEspecieOrigenTextEdit.MenuManager = this.barManager1;
            this.cotizacionEspecieOrigenTextEdit.Name = "cotizacionEspecieOrigenTextEdit";
            this.cotizacionEspecieOrigenTextEdit.Properties.DisplayFormat.FormatString = "n4";
            this.cotizacionEspecieOrigenTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cotizacionEspecieOrigenTextEdit.Properties.EditFormat.FormatString = "n4";
            this.cotizacionEspecieOrigenTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cotizacionEspecieOrigenTextEdit.Properties.Mask.EditMask = "n4";
            this.cotizacionEspecieOrigenTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cotizacionEspecieOrigenTextEdit.Size = new System.Drawing.Size(100, 20);
            this.cotizacionEspecieOrigenTextEdit.TabIndex = 1;
            // 
            // debitoTextEdit
            // 
            this.debitoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "EspecieCtaCteDestino.Debito", true));
            this.debitoTextEdit.Enabled = false;
            this.debitoTextEdit.EnterMoveNextControl = true;
            this.debitoTextEdit.Location = new System.Drawing.Point(409, 155);
            this.debitoTextEdit.MenuManager = this.barManager1;
            this.debitoTextEdit.Name = "debitoTextEdit";
            this.debitoTextEdit.Properties.Mask.EditMask = "n2";
            this.debitoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.debitoTextEdit.Properties.ReadOnly = true;
            this.debitoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.debitoTextEdit.TabIndex = 6;
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "EspecieCtaCte.Id_TipoComprobante", true));
            this.id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(409, 15);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(168, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 1;
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "EspecieCtaCte.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(108, 15);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(168, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 0;
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(108, 129);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Size = new System.Drawing.Size(469, 20);
            this.conceptoTextEdit.TabIndex = 4;
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.transferenciasManagerBindingSource, "Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(108, 155);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.EditFormat.FormatString = "n2";
            this.importeTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n2";
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 5;
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 235);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(648, 274);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(648, 274);
            this.Name = "frmTransferencia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencias entre Especies";
            this.Load += new System.EventHandler(this.frmTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieDestinoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionEspecieDestinoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idEspecieOrigenLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionEspecieOrigenTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debitoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnGuradar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource transferenciasManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private DevExpress.XtraEditors.TextEdit cotizacionEspecieDestinoTextEdit;
        private DevExpress.XtraEditors.TextEdit cotizacionEspecieOrigenTextEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit idEspecieDestinoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit idEspecieOrigenLookUpEdit;
        private DevExpress.XtraEditors.TextEdit debitoTextEdit;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}