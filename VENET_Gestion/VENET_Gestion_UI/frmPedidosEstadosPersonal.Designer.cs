namespace VENET_Gestion_UI
{
    partial class frmPedidosEstadosPersonal
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
            System.Windows.Forms.Label id_SucursalLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.lookUpEditPersonal1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPersonal2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPersonal3 = new DevExpress.XtraEditors.LookUpEdit();
            id_SucursalLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal3.Properties)).BeginInit();
            this.SuspendLayout();
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(330, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 132);
            this.barDockControlBottom.Size = new System.Drawing.Size(330, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 108);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(330, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 108);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(label2);
            this.groupControl1.Controls.Add(this.lookUpEditPersonal3);
            this.groupControl1.Controls.Add(label1);
            this.groupControl1.Controls.Add(this.lookUpEditPersonal2);
            this.groupControl1.Controls.Add(id_SucursalLabel);
            this.groupControl1.Controls.Add(this.lookUpEditPersonal1);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(306, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // lookUpEditPersonal1
            // 
            this.lookUpEditPersonal1.EnterMoveNextControl = true;
            this.lookUpEditPersonal1.Location = new System.Drawing.Point(78, 10);
            this.lookUpEditPersonal1.MenuManager = this.barManager1;
            this.lookUpEditPersonal1.Name = "lookUpEditPersonal1";
            this.lookUpEditPersonal1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lookUpEditPersonal1.Properties.NullText = "";
            this.lookUpEditPersonal1.Size = new System.Drawing.Size(214, 20);
            this.lookUpEditPersonal1.TabIndex = 0;
            this.lookUpEditPersonal1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // id_SucursalLabel
            // 
            id_SucursalLabel.AutoSize = true;
            id_SucursalLabel.Location = new System.Drawing.Point(11, 13);
            id_SucursalLabel.Name = "id_SucursalLabel";
            id_SucursalLabel.Size = new System.Drawing.Size(61, 13);
            id_SucursalLabel.TabIndex = 3;
            id_SucursalLabel.Text = "Personal 1:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 13);
            label1.TabIndex = 5;
            label1.Text = "Personal 2:";
            // 
            // lookUpEditPersonal2
            // 
            this.lookUpEditPersonal2.EnterMoveNextControl = true;
            this.lookUpEditPersonal2.Location = new System.Drawing.Point(78, 36);
            this.lookUpEditPersonal2.MenuManager = this.barManager1;
            this.lookUpEditPersonal2.Name = "lookUpEditPersonal2";
            this.lookUpEditPersonal2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lookUpEditPersonal2.Properties.NullText = "";
            this.lookUpEditPersonal2.Size = new System.Drawing.Size(214, 20);
            this.lookUpEditPersonal2.TabIndex = 1;
            this.lookUpEditPersonal2.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 7;
            label2.Text = "Personal 3:";
            // 
            // lookUpEditPersonal3
            // 
            this.lookUpEditPersonal3.EnterMoveNextControl = true;
            this.lookUpEditPersonal3.Location = new System.Drawing.Point(78, 62);
            this.lookUpEditPersonal3.MenuManager = this.barManager1;
            this.lookUpEditPersonal3.Name = "lookUpEditPersonal3";
            this.lookUpEditPersonal3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lookUpEditPersonal3.Properties.NullText = "";
            this.lookUpEditPersonal3.Size = new System.Drawing.Size(214, 20);
            this.lookUpEditPersonal3.TabIndex = 2;
            this.lookUpEditPersonal3.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // frmPedidosEstadosPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 132);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidosEstadosPersonal";
            this.Text = "Asignar Personal";
            this.Load += new System.EventHandler(this.frmPedidosEstadosPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPersonal3.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPersonal1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPersonal3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPersonal2;
    }
}