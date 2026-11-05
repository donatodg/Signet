namespace VENET_General_UI
{
    partial class frmImagenes
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
            System.Windows.Forms.Label id_EmpresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagenes));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnModifcar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnImprimeImagen = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.btnGuardaImagen = new DevExpress.XtraBars.BarButtonItem();
            this.btnRotaDerecha = new DevExpress.XtraBars.BarButtonItem();
            this.btnRotaIzquierda = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnChico = new DevExpress.XtraBars.BarButtonItem();
            this.btnMediano = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrande = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItemFooter = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnControls = new System.Windows.Forms.Panel();
            this.btnCentrar = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOrden = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.id_CategoriaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CategoriaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(23, 39);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(58, 13);
            id_EmpresaLabel.TabIndex = 9;
            id_EmpresaLabel.Text = "Categoría:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem2,
            this.btnImprimeImagen,
            this.btnAgregar,
            this.btnEliminar,
            this.barStaticItemFooter,
            this.barSubItem3,
            this.btnChico,
            this.btnMediano,
            this.btnGrande,
            this.btnModifcar,
            this.barSubItem4,
            this.btnGuardaImagen,
            this.btnRotaDerecha,
            this.btnRotaIzquierda});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(851, 207);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModifcar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Agregar";
            this.btnAgregar.Glyph = global::VENET_General_UI.Properties.Resources.addfile_16x16;
            this.btnAgregar.Id = 3;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnModifcar
            // 
            this.btnModifcar.Caption = "Modificar";
            this.btnModifcar.Glyph = global::VENET_General_UI.Properties.Resources.loadfrom_16x16;
            this.btnModifcar.Id = 11;
            this.btnModifcar.Name = "btnModifcar";
            this.btnModifcar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModifcar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Glyph = global::VENET_General_UI.Properties.Resources.deletelist_16x16;
            this.btnEliminar.Id = 5;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Imprimir";
            this.barSubItem2.Glyph = global::VENET_General_UI.Properties.Resources.print_16x16;
            this.barSubItem2.Id = 1;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimeImagen)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnImprimeImagen
            // 
            this.btnImprimeImagen.Caption = "Imagen";
            this.btnImprimeImagen.Id = 2;
            this.btnImprimeImagen.Name = "btnImprimeImagen";
            this.btnImprimeImagen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimeImagen_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Operaciones";
            this.barSubItem4.Glyph = global::VENET_General_UI.Properties.Resources.properties_16x16;
            this.barSubItem4.Id = 14;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardaImagen),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnRotaDerecha, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnRotaIzquierda, false)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // btnGuardaImagen
            // 
            this.btnGuardaImagen.Caption = "Guardar Imagen";
            this.btnGuardaImagen.Id = 15;
            this.btnGuardaImagen.Name = "btnGuardaImagen";
            this.btnGuardaImagen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardaImagen_ItemClick);
            // 
            // btnRotaDerecha
            // 
            this.btnRotaDerecha.Caption = "Rotar a la Derecha";
            this.btnRotaDerecha.Id = 16;
            this.btnRotaDerecha.Name = "btnRotaDerecha";
            this.btnRotaDerecha.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRotaDerecha_ItemClick);
            // 
            // btnRotaIzquierda
            // 
            this.btnRotaIzquierda.Caption = "Rotar a la Izquierda";
            this.btnRotaIzquierda.Id = 17;
            this.btnRotaIzquierda.Name = "btnRotaIzquierda";
            this.btnRotaIzquierda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRotaIzquierda_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Ver";
            this.barSubItem3.Glyph = global::VENET_General_UI.Properties.Resources.info_16x16;
            this.barSubItem3.Id = 7;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChico),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMediano),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGrande)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnChico
            // 
            this.btnChico.Caption = "Tamaño Chico";
            this.btnChico.Id = 8;
            this.btnChico.Name = "btnChico";
            this.btnChico.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChico_ItemClick);
            // 
            // btnMediano
            // 
            this.btnMediano.Caption = "Tamaño Mediano";
            this.btnMediano.Id = 9;
            this.btnMediano.Name = "btnMediano";
            this.btnMediano.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMediano_ItemClick);
            // 
            // btnGrande
            // 
            this.btnGrande.Caption = "Tamaño Grande";
            this.btnGrande.Id = 10;
            this.btnGrande.Name = "btnGrande";
            this.btnGrande.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGrande_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFooter)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            // 
            // barStaticItemFooter
            // 
            this.barStaticItemFooter.Id = 6;
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
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(734, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pnControls);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCentrar);
            this.splitContainer1.Panel2.Controls.Add(this.btnMas);
            this.splitContainer1.Panel2.Controls.Add(this.btnMenos);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2MinSize = 530;
            this.splitContainer1.Size = new System.Drawing.Size(734, 412);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 14;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // pnControls
            // 
            this.pnControls.AutoScroll = true;
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControls.Location = new System.Drawing.Point(0, 0);
            this.pnControls.MaximumSize = new System.Drawing.Size(500, 0);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(198, 410);
            this.pnControls.TabIndex = 0;
            // 
            // btnCentrar
            // 
            this.btnCentrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCentrar.Location = new System.Drawing.Point(483, 62);
            this.btnCentrar.Name = "btnCentrar";
            this.btnCentrar.Size = new System.Drawing.Size(26, 22);
            this.btnCentrar.TabIndex = 4;
            this.btnCentrar.Text = "[ ]";
            this.btnCentrar.UseVisualStyleBackColor = true;
            this.btnCentrar.Click += new System.EventHandler(this.btnCentrar_Click);
            // 
            // btnMas
            // 
            this.btnMas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMas.Location = new System.Drawing.Point(483, 6);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(26, 22);
            this.btnMas.TabIndex = 1;
            this.btnMas.Text = "+";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenos.Location = new System.Drawing.Point(483, 34);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(26, 22);
            this.btnMenos.TabIndex = 2;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 340);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(447, 330);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtOrden);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(id_EmpresaLabel);
            this.panel1.Controls.Add(this.id_CategoriaLookUpEdit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 70);
            this.panel1.TabIndex = 0;
            // 
            // txtOrden
            // 
            this.txtOrden.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrden.Location = new System.Drawing.Point(376, 9);
            this.txtOrden.MenuManager = this.barManager1;
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrden.Properties.DisplayFormat.FormatString = "d";
            this.txtOrden.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOrden.Properties.EditFormat.FormatString = "d";
            this.txtOrden.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOrden.Properties.Mask.EditMask = "d";
            this.txtOrden.Size = new System.Drawing.Size(100, 20);
            this.txtOrden.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Orden:";
            // 
            // id_CategoriaLookUpEdit
            // 
            this.id_CategoriaLookUpEdit.EnterMoveNextControl = true;
            this.id_CategoriaLookUpEdit.Location = new System.Drawing.Point(87, 36);
            this.id_CategoriaLookUpEdit.MenuManager = this.barManager1;
            this.id_CategoriaLookUpEdit.Name = "id_CategoriaLookUpEdit";
            this.id_CategoriaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CategoriaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_CategoriaLookUpEdit.Properties.DisplayMember = "Name";
            this.id_CategoriaLookUpEdit.Properties.NullText = "";
            this.id_CategoriaLookUpEdit.Properties.ShowHeader = false;
            this.id_CategoriaLookUpEdit.Properties.ValueMember = "Key";
            this.id_CategoriaLookUpEdit.Size = new System.Drawing.Size(232, 20);
            this.id_CategoriaLookUpEdit.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(376, 36);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 21);
            this.txtFecha.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(87, 9);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(232, 21);
            this.txtDescripcion.TabIndex = 0;
            // 
            // frmImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmImagenes";
            this.Text = "Imagenes";
            this.Load += new System.EventHandler(this.frmImagenes_Load);
            this.Resize += new System.EventHandler(this.frmImagenes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CategoriaLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnImprimeImagen;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFooter;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnChico;
        private DevExpress.XtraBars.BarButtonItem btnMediano;
        private DevExpress.XtraBars.BarButtonItem btnGrande;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraBars.BarButtonItem btnModifcar;
        private DevExpress.XtraEditors.LookUpEdit id_CategoriaLookUpEdit;
        private System.Windows.Forms.Button btnCentrar;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SpinEdit txtOrden;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem btnGuardaImagen;
        private DevExpress.XtraBars.BarButtonItem btnRotaDerecha;
        private DevExpress.XtraBars.BarButtonItem btnRotaIzquierda;
    }
}