namespace VENET_Produccion_UI
{
    partial class frmProduccionCopiar
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
            System.Windows.Forms.Label id_LineaLabel;
            System.Windows.Forms.Label id_VarianteLabel;
            System.Windows.Forms.Label id_MedidaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label id_Linea_DestinoLabel;
            System.Windows.Forms.Label id_Medida_DestinoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.copiarLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.id_Variante_DestinoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.produccionCopiarManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_Linea_DestinoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.medidasDestinoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.id_LineaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_MedidaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_VarianteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_LineaLabel = new System.Windows.Forms.Label();
            id_VarianteLabel = new System.Windows.Forms.Label();
            id_MedidaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            id_Linea_DestinoLabel = new System.Windows.Forms.Label();
            id_Medida_DestinoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiarLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_Variante_DestinoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionCopiarManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_Linea_DestinoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medidasDestinoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_MedidaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_LineaLabel
            // 
            id_LineaLabel.AutoSize = true;
            id_LineaLabel.Location = new System.Drawing.Point(25, 32);
            id_LineaLabel.Name = "id_LineaLabel";
            id_LineaLabel.Size = new System.Drawing.Size(36, 13);
            id_LineaLabel.TabIndex = 14;
            id_LineaLabel.Text = "Línea:";
            // 
            // id_VarianteLabel
            // 
            id_VarianteLabel.AutoSize = true;
            id_VarianteLabel.Location = new System.Drawing.Point(10, 58);
            id_VarianteLabel.Name = "id_VarianteLabel";
            id_VarianteLabel.Size = new System.Drawing.Size(51, 13);
            id_VarianteLabel.TabIndex = 13;
            id_VarianteLabel.Text = "Variante:";
            // 
            // id_MedidaLabel
            // 
            id_MedidaLabel.AutoSize = true;
            id_MedidaLabel.Location = new System.Drawing.Point(16, 84);
            id_MedidaLabel.Name = "id_MedidaLabel";
            id_MedidaLabel.Size = new System.Drawing.Size(45, 13);
            id_MedidaLabel.TabIndex = 12;
            id_MedidaLabel.Text = "Medida:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 13);
            label1.TabIndex = 15;
            label1.Text = "Copiar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 82);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 13);
            label4.TabIndex = 20;
            label4.Text = "Medida:";
            // 
            // id_Linea_DestinoLabel
            // 
            id_Linea_DestinoLabel.AutoSize = true;
            id_Linea_DestinoLabel.Location = new System.Drawing.Point(25, 30);
            id_Linea_DestinoLabel.Name = "id_Linea_DestinoLabel";
            id_Linea_DestinoLabel.Size = new System.Drawing.Size(36, 13);
            id_Linea_DestinoLabel.TabIndex = 21;
            id_Linea_DestinoLabel.Text = "Línea:";
            // 
            // id_Medida_DestinoLabel
            // 
            id_Medida_DestinoLabel.AutoSize = true;
            id_Medida_DestinoLabel.Location = new System.Drawing.Point(10, 56);
            id_Medida_DestinoLabel.Name = "id_Medida_DestinoLabel";
            id_Medida_DestinoLabel.Size = new System.Drawing.Size(51, 13);
            id_Medida_DestinoLabel.TabIndex = 22;
            id_Medida_DestinoLabel.Text = "Variante:";
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
            this.btnAceptar.Glyph = global::VENET_Produccion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(376, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 330);
            this.barDockControlBottom.Size = new System.Drawing.Size(376, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 306);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(376, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 306);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.copiarLookUpEdit);
            this.groupControl1.Controls.Add(label1);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(352, 292);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // copiarLookUpEdit
            // 
            this.copiarLookUpEdit.EnterMoveNextControl = true;
            this.copiarLookUpEdit.Location = new System.Drawing.Point(77, 11);
            this.copiarLookUpEdit.MenuManager = this.barManager1;
            this.copiarLookUpEdit.Name = "copiarLookUpEdit";
            this.copiarLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.copiarLookUpEdit.Properties.NullText = "";
            this.copiarLookUpEdit.Properties.ShowHeader = false;
            this.copiarLookUpEdit.Size = new System.Drawing.Size(150, 20);
            this.copiarLookUpEdit.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.id_Variante_DestinoLookUpEdit);
            this.groupControl3.Controls.Add(id_Medida_DestinoLabel);
            this.groupControl3.Controls.Add(id_Linea_DestinoLabel);
            this.groupControl3.Controls.Add(this.id_Linea_DestinoLookUpEdit);
            this.groupControl3.Controls.Add(this.lblSeleccionados);
            this.groupControl3.Controls.Add(this.gridLookUpEdit1);
            this.groupControl3.Controls.Add(label4);
            this.groupControl3.Location = new System.Drawing.Point(10, 156);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(331, 123);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Destino";
            // 
            // id_Variante_DestinoLookUpEdit
            // 
            this.id_Variante_DestinoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionCopiarManagerBindingSource, "Id_Variante_Destino", true));
            this.id_Variante_DestinoLookUpEdit.EnterMoveNextControl = true;
            this.id_Variante_DestinoLookUpEdit.Location = new System.Drawing.Point(67, 53);
            this.id_Variante_DestinoLookUpEdit.MenuManager = this.barManager1;
            this.id_Variante_DestinoLookUpEdit.Name = "id_Variante_DestinoLookUpEdit";
            this.id_Variante_DestinoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_Variante_DestinoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.id_Variante_DestinoLookUpEdit.Properties.NullText = "";
            this.id_Variante_DestinoLookUpEdit.Properties.ShowHeader = false;
            this.id_Variante_DestinoLookUpEdit.Size = new System.Drawing.Size(250, 20);
            this.id_Variante_DestinoLookUpEdit.TabIndex = 1;
            this.id_Variante_DestinoLookUpEdit.EditValueChanged += new System.EventHandler(this.id_Variante_DestinoLookUpEdit_EditValueChanged);
            // 
            // produccionCopiarManagerBindingSource
            // 
            this.produccionCopiarManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionCopiarManager);
            // 
            // id_Linea_DestinoLookUpEdit
            // 
            this.id_Linea_DestinoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionCopiarManagerBindingSource, "Id_Linea_Destino", true));
            this.id_Linea_DestinoLookUpEdit.EnterMoveNextControl = true;
            this.id_Linea_DestinoLookUpEdit.Location = new System.Drawing.Point(67, 27);
            this.id_Linea_DestinoLookUpEdit.MenuManager = this.barManager1;
            this.id_Linea_DestinoLookUpEdit.Name = "id_Linea_DestinoLookUpEdit";
            this.id_Linea_DestinoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_Linea_DestinoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Línea"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", "Empresa")});
            this.id_Linea_DestinoLookUpEdit.Properties.NullText = "";
            this.id_Linea_DestinoLookUpEdit.Properties.PopupWidth = 336;
            this.id_Linea_DestinoLookUpEdit.Size = new System.Drawing.Size(250, 20);
            this.id_Linea_DestinoLookUpEdit.TabIndex = 0;
            this.id_Linea_DestinoLookUpEdit.EditValueChanged += new System.EventHandler(this.id_Linea_DestinoLookUpEdit_EditValueChanged);
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Location = new System.Drawing.Point(72, 100);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(110, 13);
            this.lblSeleccionados.TabIndex = 21;
            this.lblSeleccionados.Text = "0 items seleccionados";
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(67, 79);
            this.gridLookUpEdit1.MenuManager = this.barManager1;
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.DataSource = this.medidasDestinoBindingSource;
            this.gridLookUpEdit1.Properties.DisplayMember = "Name";
            this.gridLookUpEdit1.Properties.ImmediatePopup = true;
            this.gridLookUpEdit1.Properties.NullText = "";
            this.gridLookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.gridLookUpEdit1.Properties.ValueMember = "Key";
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(250, 18);
            this.gridLookUpEdit1.TabIndex = 2;
            this.gridLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.gridLookUpEdit1_Closed);
            // 
            // medidasDestinoBindingSource
            // 
            this.medidasDestinoBindingSource.DataMember = "Medidas_Destino";
            this.medidasDestinoBindingSource.DataSource = this.produccionCopiarManagerBindingSource;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelect = true;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Key";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Medida";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(id_LineaLabel);
            this.groupControl2.Controls.Add(this.id_LineaLookUpEdit);
            this.groupControl2.Controls.Add(this.id_MedidaLookUpEdit);
            this.groupControl2.Controls.Add(id_MedidaLabel);
            this.groupControl2.Controls.Add(id_VarianteLabel);
            this.groupControl2.Controls.Add(this.id_VarianteLookUpEdit);
            this.groupControl2.Location = new System.Drawing.Point(10, 37);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(331, 113);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Origen";
            // 
            // id_LineaLookUpEdit
            // 
            this.id_LineaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionCopiarManagerBindingSource, "Id_Linea", true));
            this.id_LineaLookUpEdit.EnterMoveNextControl = true;
            this.id_LineaLookUpEdit.Location = new System.Drawing.Point(67, 29);
            this.id_LineaLookUpEdit.MenuManager = this.barManager1;
            this.id_LineaLookUpEdit.Name = "id_LineaLookUpEdit";
            this.id_LineaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_LineaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Línea"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", "Empresa")});
            this.id_LineaLookUpEdit.Properties.NullText = "";
            this.id_LineaLookUpEdit.Properties.PopupWidth = 336;
            this.id_LineaLookUpEdit.Size = new System.Drawing.Size(250, 20);
            this.id_LineaLookUpEdit.TabIndex = 0;
            this.id_LineaLookUpEdit.EditValueChanged += new System.EventHandler(this.id_LineaLookUpEdit_EditValueChanged);
            // 
            // id_MedidaLookUpEdit
            // 
            this.id_MedidaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionCopiarManagerBindingSource, "Id_Medida", true));
            this.id_MedidaLookUpEdit.EnterMoveNextControl = true;
            this.id_MedidaLookUpEdit.Location = new System.Drawing.Point(67, 81);
            this.id_MedidaLookUpEdit.MenuManager = this.barManager1;
            this.id_MedidaLookUpEdit.Name = "id_MedidaLookUpEdit";
            this.id_MedidaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_MedidaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_MedidaLookUpEdit.Properties.NullText = "";
            this.id_MedidaLookUpEdit.Properties.ShowHeader = false;
            this.id_MedidaLookUpEdit.Size = new System.Drawing.Size(250, 20);
            this.id_MedidaLookUpEdit.TabIndex = 2;
            // 
            // id_VarianteLookUpEdit
            // 
            this.id_VarianteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionCopiarManagerBindingSource, "Id_Variante", true));
            this.id_VarianteLookUpEdit.EnterMoveNextControl = true;
            this.id_VarianteLookUpEdit.Location = new System.Drawing.Point(67, 55);
            this.id_VarianteLookUpEdit.MenuManager = this.barManager1;
            this.id_VarianteLookUpEdit.Name = "id_VarianteLookUpEdit";
            this.id_VarianteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_VarianteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Variante")});
            this.id_VarianteLookUpEdit.Properties.NullText = "";
            this.id_VarianteLookUpEdit.Properties.ShowHeader = false;
            this.id_VarianteLookUpEdit.Size = new System.Drawing.Size(250, 20);
            this.id_VarianteLookUpEdit.TabIndex = 1;
            this.id_VarianteLookUpEdit.EditValueChanged += new System.EventHandler(this.id_VarianteLookUpEdit_EditValueChanged);
            // 
            // frmProduccionCopiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 330);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(392, 369);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 369);
            this.Name = "frmProduccionCopiar";
            this.Text = "Copiar Medida Origen en Medidas Seleccionada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionCopiar_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionCopiar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiarLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_Variante_DestinoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionCopiarManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_Linea_DestinoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medidasDestinoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_MedidaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LookUpEdit id_LineaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_MedidaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_VarianteLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit copiarLookUpEdit;
        private System.Windows.Forms.Label lblSeleccionados;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.BindingSource produccionCopiarManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_Linea_DestinoLookUpEdit;
        private System.Windows.Forms.BindingSource medidasDestinoBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_Variante_DestinoLookUpEdit;
    }
}