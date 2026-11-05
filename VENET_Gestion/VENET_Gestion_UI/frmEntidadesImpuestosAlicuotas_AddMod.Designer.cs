namespace VENET_Gestion_UI
{
    partial class frmEntidadesImpuestosAlicuotas_AddMod
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
            System.Windows.Forms.Label id_ImpuestoAlicuotaLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.entidadAlicuotaSinAsignarBindingSource = new System.Windows.Forms.BindingSource();
            this.entidadesImpuestosAlicuotasManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            id_ImpuestoAlicuotaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadAlicuotaSinAsignarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesImpuestosAlicuotasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // id_ImpuestoAlicuotaLabel
            // 
            id_ImpuestoAlicuotaLabel.AutoSize = true;
            id_ImpuestoAlicuotaLabel.Location = new System.Drawing.Point(13, 10);
            id_ImpuestoAlicuotaLabel.Name = "id_ImpuestoAlicuotaLabel";
            id_ImpuestoAlicuotaLabel.Size = new System.Drawing.Size(54, 13);
            id_ImpuestoAlicuotaLabel.TabIndex = 0;
            id_ImpuestoAlicuotaLabel.Text = "Alícuotas:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblSeleccionados);
            this.groupControl1.Controls.Add(this.gridLookUpEdit1);
            this.groupControl1.Controls.Add(id_ImpuestoAlicuotaLabel);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(324, 48);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Location = new System.Drawing.Point(73, 27);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(110, 13);
            this.lblSeleccionados.TabIndex = 4;
            this.lblSeleccionados.Text = "0 items seleccionados";
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(73, 7);
            this.gridLookUpEdit1.MenuManager = this.barManager1;
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.DataSource = this.entidadAlicuotaSinAsignarBindingSource;
            this.gridLookUpEdit1.Properties.ImmediatePopup = true;
            this.gridLookUpEdit1.Properties.NullText = "";
            this.gridLookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(244, 18);
            this.gridLookUpEdit1.TabIndex = 3;
            this.gridLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.gridLookUpEdit1_Closed);
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
            this.barDockControlTop.Size = new System.Drawing.Size(348, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 86);
            this.barDockControlBottom.Size = new System.Drawing.Size(348, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 62);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(348, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 62);
            // 
            // entidadAlicuotaSinAsignarBindingSource
            // 
            this.entidadAlicuotaSinAsignarBindingSource.DataMember = "EntidadAlicuotaSinAsignar";
            this.entidadAlicuotaSinAsignarBindingSource.DataSource = this.entidadesImpuestosAlicuotasManagerBindingSource;
            // 
            // entidadesImpuestosAlicuotasManagerBindingSource
            // 
            this.entidadesImpuestosAlicuotasManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.EntidadesImpuestosAlicuotasManager);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelect = true;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Descripción";
            this.gridColumn1.FieldName = "Descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // frmEntidadesImpuestosAlicuotas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 86);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 125);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 125);
            this.Name = "frmEntidadesImpuestosAlicuotas_AddMod";
            this.Text = "Alta/Modificación de Impuestos Alícuotas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntidadesImpuestosAlicuotas_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmEntidadesImpuestosAlicuotas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadAlicuotaSinAsignarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadesImpuestosAlicuotasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource entidadesImpuestosAlicuotasManagerBindingSource;
        private System.Windows.Forms.BindingSource entidadAlicuotaSinAsignarBindingSource;
        private System.Windows.Forms.Label lblSeleccionados;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}