namespace VENET_General_UI
{
    partial class frmLocalidades_AddMod
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
            System.Windows.Forms.Label codPostalLabel;
            System.Windows.Forms.Label localidadLabel;
            System.Windows.Forms.Label id_ProvinciaLabel;
            System.Windows.Forms.Label clearingLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_ProvinciaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.localidadesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.localidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codPostalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.clearingTextEdit = new DevExpress.XtraEditors.TextEdit();
            codPostalLabel = new System.Windows.Forms.Label();
            localidadLabel = new System.Windows.Forms.Label();
            id_ProvinciaLabel = new System.Windows.Forms.Label();
            clearingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearingTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // codPostalLabel
            // 
            codPostalLabel.AutoSize = true;
            codPostalLabel.Location = new System.Drawing.Point(20, 13);
            codPostalLabel.Name = "codPostalLabel";
            codPostalLabel.Size = new System.Drawing.Size(62, 13);
            codPostalLabel.TabIndex = 0;
            codPostalLabel.Text = "Cod Postal:";
            // 
            // localidadLabel
            // 
            localidadLabel.AutoSize = true;
            localidadLabel.Location = new System.Drawing.Point(25, 39);
            localidadLabel.Name = "localidadLabel";
            localidadLabel.Size = new System.Drawing.Size(55, 13);
            localidadLabel.TabIndex = 2;
            localidadLabel.Text = "Localidad:";
            // 
            // id_ProvinciaLabel
            // 
            id_ProvinciaLabel.AutoSize = true;
            id_ProvinciaLabel.Location = new System.Drawing.Point(27, 65);
            id_ProvinciaLabel.Name = "id_ProvinciaLabel";
            id_ProvinciaLabel.Size = new System.Drawing.Size(54, 13);
            id_ProvinciaLabel.TabIndex = 4;
            id_ProvinciaLabel.Text = "Provincia:";
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
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_General_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(351, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 163);
            this.barDockControlBottom.Size = new System.Drawing.Size(351, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 139);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(351, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 139);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(clearingLabel);
            this.groupControl1.Controls.Add(this.clearingTextEdit);
            this.groupControl1.Controls.Add(id_ProvinciaLabel);
            this.groupControl1.Controls.Add(this.id_ProvinciaLookUpEdit);
            this.groupControl1.Controls.Add(localidadLabel);
            this.groupControl1.Controls.Add(this.localidadTextEdit);
            this.groupControl1.Controls.Add(codPostalLabel);
            this.groupControl1.Controls.Add(this.codPostalTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(327, 121);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_ProvinciaLookUpEdit
            // 
            this.id_ProvinciaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManagerBindingSource, "Localidad.Id_Provincia", true));
            this.id_ProvinciaLookUpEdit.EnterMoveNextControl = true;
            this.id_ProvinciaLookUpEdit.Location = new System.Drawing.Point(87, 62);
            this.id_ProvinciaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvinciaLookUpEdit.Name = "id_ProvinciaLookUpEdit";
            this.id_ProvinciaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_ProvinciaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre14")});
            this.id_ProvinciaLookUpEdit.Properties.NullText = "";
            this.id_ProvinciaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvinciaLookUpEdit.Size = new System.Drawing.Size(220, 20);
            this.id_ProvinciaLookUpEdit.TabIndex = 5;
            // 
            // localidadesManagerBindingSource
            // 
            this.localidadesManagerBindingSource.DataSource = typeof(VENET_General_BL.LocalidadesManager);
            // 
            // localidadTextEdit
            // 
            this.localidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManagerBindingSource, "Localidad.Localidad", true));
            this.localidadTextEdit.EnterMoveNextControl = true;
            this.localidadTextEdit.Location = new System.Drawing.Point(87, 36);
            this.localidadTextEdit.MenuManager = this.barManager1;
            this.localidadTextEdit.Name = "localidadTextEdit";
            this.localidadTextEdit.Size = new System.Drawing.Size(220, 20);
            this.localidadTextEdit.TabIndex = 3;
            // 
            // codPostalTextEdit
            // 
            this.codPostalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManagerBindingSource, "Localidad.CodPostal", true));
            this.codPostalTextEdit.EnterMoveNextControl = true;
            this.codPostalTextEdit.Location = new System.Drawing.Point(87, 10);
            this.codPostalTextEdit.MenuManager = this.barManager1;
            this.codPostalTextEdit.Name = "codPostalTextEdit";
            this.codPostalTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codPostalTextEdit.TabIndex = 1;
            // 
            // clearingLabel
            // 
            clearingLabel.AutoSize = true;
            clearingLabel.Location = new System.Drawing.Point(31, 91);
            clearingLabel.Name = "clearingLabel";
            clearingLabel.Size = new System.Drawing.Size(50, 13);
            clearingLabel.TabIndex = 6;
            clearingLabel.Text = "Clearing:";
            // 
            // clearingTextEdit
            // 
            this.clearingTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.localidadesManagerBindingSource, "Localidad.Clearing", true));
            this.clearingTextEdit.Location = new System.Drawing.Point(87, 88);
            this.clearingTextEdit.MenuManager = this.barManager1;
            this.clearingTextEdit.Name = "clearingTextEdit";
            this.clearingTextEdit.Size = new System.Drawing.Size(100, 20);
            this.clearingTextEdit.TabIndex = 7;
            // 
            // frmLocalidades_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 163);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(367, 202);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(367, 202);
            this.Name = "frmLocalidades_AddMod";

            this.Text = "Alta/Modificación de Localidades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLocalidades_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmLocalidades_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearingTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.LookUpEdit id_ProvinciaLookUpEdit;
        private System.Windows.Forms.BindingSource localidadesManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit localidadTextEdit;
        private DevExpress.XtraEditors.TextEdit codPostalTextEdit;
        private DevExpress.XtraEditors.TextEdit clearingTextEdit;
    }
}