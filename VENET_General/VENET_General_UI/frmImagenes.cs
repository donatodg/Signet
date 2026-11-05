namespace VENET_General_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmImagenes : MultiForm
    {
        private string _Tabla;
        private int _Id_Tabla;
        ImagenesManager manager;
        private int _Id = 0;
        private Image BM1;

        int locX = 20;
        int locY = 10;
        int sizeWidth = 80;
        int sizeHeight = 80;
        int MIX;
        int MIY;
        bool Mueve;


        public frmImagenes(string Tabla, int Id_Tabla)
        {
            InitializeComponent();
            _Id_Tabla = Id_Tabla;
            _Tabla = Tabla;

            manager = new ImagenesManager(_Tabla, _Id_Tabla);

            this.Text = "Imagenes - " + Tabla + " - Registro Id: " + Id_Tabla;
        }

        private void frmImagenes_Load(object sender, EventArgs e)
        {
            id_CategoriaLookUpEdit.Properties.DataSource = manager.Categorias;
            id_CategoriaLookUpEdit.Properties.DisplayMember = "Name";
            id_CategoriaLookUpEdit.Properties.ValueMember = "Key";

            Reload();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (e.Delta <= 0)
                {
                    //set minimum size to zoom
                    if (pictureBox1.Width < 50)
                        // lbl_Zoom.Text = pictureBox1.Image.Size; 
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (pictureBox1.Width > 1000)
                        return;
                }
                pictureBox1.Width += Convert.ToInt32(pictureBox1.Width * e.Delta / 1000);
                pictureBox1.Height += Convert.ToInt32(pictureBox1.Height * e.Delta / 1000);
            }
        }

        private void Reload()
        {
            try
            {
                barStaticItemFooter.Caption = "Cantidad de Imagenes: " + manager.ListImagen.Where(t => t.UserDel == null).Count().ToString();

                pnControls.Controls.Clear();
                pnControls.AutoScroll = false;

                locX = 20;
                locY = 10;

                int locnewX = locX;
                int locnewY = locY;

                foreach (Imagenes i in manager.ListImagen.Where(t => t.Imagen != null && t.UserDel == null).OrderBy(t => t.Orden))
                {
                    //if (i.Imagen != null && i.UserDel == null)
                    using (MemoryStream stream = new MemoryStream(i.Imagen))
                    {
                        if (locnewX >= pnControls.Width - sizeWidth - 10)
                        {
                            locnewX = locX;
                            locY = locY + sizeHeight + 30;
                            locnewY = locY;
                        }
                        else
                        {
                            locnewY = locY;
                        }

                        loadImagestoPanel(i.Id, i.Descripcion + "|" + i.Id_CategoriaImagen + "|" + i.FechaAdd.ToString("dd/MM/yyyy HH:mm") + "|" + i.Orden, Image.FromStream(stream), locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10;
                    }
                }

                pnControls.AutoScroll = true;

            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void loadImagestoPanel(int Id, string ImagenDatos, Image Imagen, int newLocX, int newLocY)
        {
            PictureBox ctrl = new PictureBox();
            ctrl.Image = Imagen;
            ctrl.BackColor = Color.Black;
            ctrl.Location = new Point(newLocX, newLocY);
            ctrl.Size = new Size(sizeWidth, sizeHeight);
            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
            ctrl.MouseClick += new MouseEventHandler(control_Mouse);
            ctrl.Tag = ImagenDatos;
            ctrl.Name = Id.ToString();
            pnControls.Controls.Add(ctrl);
        }

        private void control_Mouse(object sender, MouseEventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            Control control = (Control)sender;
            PictureBox pic = (PictureBox)control;

            BM1 = pic.Image;
            pictureBox1.Image = pic.Image;


            txtDescripcion.Text = pic.Tag.ToString().Split('|')[0];
            //id_CategoriaLookUpEdit.EditValue = pic.Tag.ToString().Split('|')[1];
            //KeyNamePair x = new KeyNamePair() { Key = Convert.ToInt32(pic.Tag.ToString().Split('|')[1]), Name = "" };
            id_CategoriaLookUpEdit.EditValue = (new KeyNamePair() { Key = Convert.ToInt32(pic.Tag.ToString().Split('|')[1]), Name = "" }).Key;
            txtFecha.Text = pic.Tag.ToString().Split('|')[2];
            txtOrden.Text = pic.Tag.ToString().Split('|')[3];

            _Id = Convert.ToInt32(pic.Name);

            panel2.AutoScrollPosition = new Point(0, 0);
        }

        private void btnChico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sizeWidth = 50;
            sizeHeight = 50;
            CambiarTamañoImagenes();
        }

        private void btnMediano_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sizeWidth = 80;
            sizeHeight = 80;
            CambiarTamañoImagenes();
        }

        private void btnGrande_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sizeWidth = 160;
            sizeHeight = 160;
            CambiarTamañoImagenes();
        }

        private void CambiarTamañoImagenes()
        {
            pnControls.AutoScroll = false;

            int SaveVal = 0;
            locX = 20;
            locY = 10;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
            pnControls.AutoScroll = true;
        }

        private void loadControls()
        {
            int locnewX = locX;
            int locnewY = locY;

            foreach (Control p in pnControls.Controls)
            {
                if (locnewX >= pnControls.Width - sizeWidth - 10)
                {
                    locnewX = locX;
                    locY = locY + sizeHeight + 30;
                    locnewY = locY;
                }
                else
                {
                    locnewY = locY;
                }
                p.Location = new Point(locnewX, locnewY);
                p.Size = new Size(sizeWidth, sizeHeight);

                locnewY = locY + sizeHeight + 10;
                locnewX = locnewX + sizeWidth + 10;
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", Enums.Accion.Agregar)) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
                openFileDialog1.Title = "Seleccione el archivo a importar";
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Imagenes.");

                    foreach (String file in openFileDialog1.FileNames)
                    {
                        Image bmp = Image.FromFile(file);
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        Imagenes o = new Imagenes()
                        {
                            Id = 0,
                            Descripcion = "-",
                            Id_CategoriaImagen = 1,
                            Tabla = _Tabla,
                            Imagen = ms.ToArray(),
                            Orden = 1,
                            Id_Tabla = _Id_Tabla
                        };

                        ImagenesManager.Agregar(o);
                    }
                    manager = new ImagenesManager(_Tabla, _Id_Tabla);
                    Reload();

                    SplashScreenManager.CloseForm(false);
                }
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnModifcar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", Enums.Accion.Modificar)) return;

                if (_Id == 0) return;

                if (Sistema.MensajeSiNo("¿Desea Modificar la Imagen Seleccionada?", "Atención..."))
                {
                    if (ImagenesManager.Modificar(new Imagenes() { Id = _Id }, txtDescripcion.Text, Convert.ToInt32(id_CategoriaLookUpEdit.EditValue), Convert.ToInt32(txtOrden.Text)))
                    {
                        (manager.ListImagen.Where(t => t.Id == _Id).FirstOrDefault()).Descripcion = txtDescripcion.Text;
                        (manager.ListImagen.Where(t => t.Id == _Id).FirstOrDefault()).Id_CategoriaImagen = Convert.ToInt32(id_CategoriaLookUpEdit.EditValue);
                        (manager.ListImagen.Where(t => t.Id == _Id).FirstOrDefault()).Orden = Convert.ToInt32(txtOrden.Text);
                        Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", Enums.Accion.Eliminar)) return;

                if (_Id == 0) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar la Imagen Seleccionada?", "Atención..."))
                {
                    if (ImagenesManager.Eliminar(new Imagenes() { Id = _Id }))
                    {
                        manager.ListImagen.Where(t => t.Id == _Id).FirstOrDefault().UserDel = 1;
                        pictureBox1.Image = null;
                        Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                CambiarTamañoImagenes();
            }
            catch (Exception) { }
        }

        private void frmImagenes_Resize(object sender, EventArgs e)
        {
            try
            {
                CambiarTamañoImagenes();
            }
            catch (Exception) { }
        }

        private void btnImprimeImagen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", Enums.Accion.Imprimir, "Imprimir Imagen")) return;
                if (pictureBox1.Image == null) return;

                PrintPreviewDialog ppd = new PrintPreviewDialog();

                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();

                doc.OriginAtMargins = true;
                doc.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);

                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;

                ppd.Document = doc;

                if (ppd.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (e.MarginBounds.Height < pictureBox1.Height || e.MarginBounds.Width < pictureBox1.Width)
            {
                float newWidth = BM1.Width * 100 / BM1.HorizontalResolution;
                float newHeight = BM1.Height * 100 / BM1.VerticalResolution;

                float widthFactor = newWidth / e.MarginBounds.Width;
                float heightFactor = newHeight / e.MarginBounds.Height;

                if (widthFactor > 1 | heightFactor > 1)
                {
                    if (widthFactor > heightFactor)
                    {
                        newWidth = newWidth / widthFactor;
                        newHeight = newHeight / widthFactor;
                    }
                    else
                    {
                        newWidth = newWidth / heightFactor;
                        newHeight = newHeight / heightFactor;
                    }
                }

                e.Graphics.DrawImage(BM1, 0, 0, (int)newWidth, (int)newHeight);
            }
            else

                e.Graphics.DrawImage(pictureBox1.Image, 0, 0);


        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            //Image flipImage = BM1;

            //if (Invertido > 0)
            //{
            //    int Valor = Convert.ToInt32(((Convert.ToDecimal(Invertido / 90) / 4) - Math.Truncate(Convert.ToDecimal(Invertido / 90) / 4)) * 100);
            //    switch (Valor)
            //    {
            //        case 25:
            //        //    flipImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
            //            break;
            //        case 50:
            //  //          flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            //            break;
            //        case 75:
            ////            flipImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
            //            break;
            //    }
            //}
            pictureBox1.Image = new Bitmap(BM1, Convert.ToInt32(pictureBox1.Image.Width * 1.1), Convert.ToInt32(pictureBox1.Image.Height * 1.1));
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            //Image flipImage = BM1;

            //if (Invertido > 0)
            //{
            //    int Valor = Convert.ToInt32(((Convert.ToDecimal(Invertido / 90) / 4) - Math.Truncate(Convert.ToDecimal(Invertido / 90) / 4)) * 100);
            //    switch (Valor)
            //    {
            //        case 25:
            //            //    flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            //            break;
            //        case 50:
            //      //      flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            //            break;
            //        case 75:
            //    //        flipImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
            //            break;
            //    }
            //}
            pictureBox1.Image = new Bitmap(BM1, Convert.ToInt32(pictureBox1.Image.Width * 0.9), Convert.ToInt32(pictureBox1.Image.Height * 0.9));


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MIX = e.Location.X;
            MIY = e.Location.Y;

            Mueve = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mueve)
            {
                int DIFX = (MIX - e.X);
                int DIFY = (MIY - e.Y);

                panel2.AutoScrollPosition = new Point((DIFX - panel2.AutoScrollPosition.X), (DIFY - panel2.AutoScrollPosition.Y));
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Mueve = false;
        }

        private void btnCentrar_Click(object sender, EventArgs e)
        {
            panel2.AutoScrollPosition = new Point(0, 0);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = BM1;
        }

        private void btnGuardaImagen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", Enums.Accion.Operaciones, "Guardar Imagen")) return;
                if (pictureBox1.Image == null) return;

                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "JPEG(*.JPG)|*.jpg|BMP(*.BMP)|*.bmp";
                f.Title = "Ingrese el nombre del archivo";

                if (f.ShowDialog() == DialogResult.OK)
                {
                    Bitmap thumbBMP = new Bitmap(pictureBox1.Image);
                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(f.FileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            thumbBMP.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnRotaDerecha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*    Image flipImage = new Bitmap(BM1, Convert.ToInt32(pictureBox1.Image.Height), Convert.ToInt32(pictureBox1.Image.Width));

                //derecha
                flipImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
                //izquierda
                //flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);

                pictureBox1.Image = flipImage;
                */
            Image flipImage = pictureBox1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
            pictureBox1.Image = flipImage;
            /*original
            Image flipImage = pictureBox1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = flipImage;
            */

        }

        private void btnRotaIzquierda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*   Image flipImage = new Bitmap(BM1, Convert.ToInt32(pictureBox1.Image.Height), Convert.ToInt32(pictureBox1.Image.Width));

               //derecha
               //flipImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
               //izquierda
               flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);

               pictureBox1.Image = flipImage;
               */
            Image flipImage = pictureBox1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = flipImage;

        }
    }
}
