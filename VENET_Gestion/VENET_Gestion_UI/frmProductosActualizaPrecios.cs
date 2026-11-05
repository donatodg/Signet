namespace VENET_Gestion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Gestion_BL;

    public partial class frmProductosActualizaPrecios : MultiForm
    {
        private ProductosActualizaPreciosManager manager = new ProductosActualizaPreciosManager();
        // private bool Proceso;

        public frmProductosActualizaPrecios()
        {
            InitializeComponent();
        }

        private void frmProductosActualizaPrecios_Load(object sender, EventArgs e)
        {
            manager.Buscar();
            productosActualizaPreciosManager_SearchResultBindingSource.DataSource = manager.ListaProductos;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(porcentajeTextEdit.EditValue) == 0 && Convert.ToDecimal(importeTextEdit.EditValue) == 0) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando nuevos importes.");

                //  Proceso = true;
                foreach (ProductosActualizaPreciosManager.SearchResult r in manager.ListaProductos)
                {
                    if (Convert.ToDecimal(porcentajeTextEdit.EditValue) != 0)
                    {
                        r.NuevoPrecio = r.Importe + (r.Importe * (Convert.ToDecimal(porcentajeTextEdit.EditValue) / 100));
                        r.NuevoPrecioOriginal = Convert.ToDecimal(r.ImporteOriginal) + (Convert.ToDecimal(r.ImporteOriginal) * (Convert.ToDecimal(porcentajeTextEdit.EditValue) / 100));
                    }
                    else
                    {
                        r.NuevoPrecio = r.Importe + Convert.ToDecimal(importeTextEdit.EditValue);
                        r.NuevoPrecioOriginal = Convert.ToDecimal(r.ImporteOriginal) + Convert.ToDecimal(importeTextEdit.EditValue);
                    }
                }
                SplashScreenManager.CloseForm(false);
                //    Proceso = false;

                gridControl1.RefreshDataSource();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
                SplashScreenManager.CloseForm(false);
                //   Proceso = false;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
                SplashScreenManager.CloseForm(false);
                //  Proceso = false;
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();
                int Cant = manager.Save();

                Sistema.Mensaje(string.Format("Se actualizaron {0} precios.", Cant));
                DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void porcentajeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(porcentajeTextEdit.EditValue) > 0)
                importeTextEdit.EditValue = Convert.ToDecimal(0);
        }

        private void importeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(importeTextEdit.EditValue) > 0)
                porcentajeTextEdit.EditValue = Convert.ToDecimal(0);
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //if (!Proceso)
            //    manager.ListaProductos[productosActualizaPreciosManager_SearchResultBindingSource.Position].Seleccionado = ((DevExpress.XtraEditors.CheckEdit)(sender)).Checked;
        }

        private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //if (!Proceso)
            //    if (repositoryItemTextEdit1.ToString() == "")
            //        manager.ListaProductos[productosActualizaPreciosManager_SearchResultBindingSource.Position].NuevoPrecio = 0;
            //    else
            //        manager.ListaProductos[productosActualizaPreciosManager_SearchResultBindingSource.Position].NuevoPrecio = Convert.ToDecimal(repositoryItemTextEdit1.ToString());
        }

        private void productosActualizaPreciosManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosActualizaPreciosManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                manager.DeseleccionarTodo();

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    ProductosActualizaPreciosManager.SearchResult x = (ProductosActualizaPreciosManager.SearchResult)gridView1.GetRow(i);
                    manager.ListaProductos.Where(t => t.Id == x.Id).FirstOrDefault().Seleccionado = true;
                }
                gridControl1.RefreshDataSource();
                Validate();

                Sistema.Mensaje(string.Format("Se seleccionaron {0} productos.", gridView1.RowCount));

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
    }
}
