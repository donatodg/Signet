using System;
using System.Collections.Generic;
using VENET_Common;
using VENET_Comun;
using VENET_Gestion_BL;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VENET_Gestion_UI
{
    public partial class frmProductosListasPreciosImprimir : MultiForm
    {
        private ProductosListasPreciosImprimirManager manager = new ProductosListasPreciosImprimirManager();

        public List<int> Categorias;
        public List<String> Mails;

        public frmProductosListasPreciosImprimir()
        {
            InitializeComponent();
        }

        private void frmProductosListasPreciosImprimir_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargar Categorias
                productosListasPreciosImprimirManager_CategoriasSelectBindingSource.DataSource = manager.Categorias;

                //Cargar Clientes con Mails
                productosListasPreciosImprimirManager_ClientesMailSelectBindingSource.DataSource = manager.ClientesEmail;
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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();

            Categorias = new List<int>();
            Mails = new List<string>();

            Categorias.AddRange(manager.Categorias.Where(t => t.Seleccionado == true).Select(t => t.Id));
            Mails.AddRange(manager.ClientesEmail.Where(t => t.Seleccionado == true).Select(t => t.Email));

            if (Categorias.Count() == 0)
                Sistema.Mensaje("Debe seleccionar una categoría.", "Categoría");
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SelecCategorias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                manager.SeleccionarTodo(false);
                gridControl1.RefreshDataSource();
                Validate();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void DesSelectCategorias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                manager.DeseleccionarTodo(false);
                gridControl1.RefreshDataSource();
                Validate();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void SelectClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                manager.SeleccionarTodo(true);
                gridControl2.RefreshDataSource();
                Validate();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void DesSelectClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                manager.DeseleccionarTodo(true);
                gridControl2.RefreshDataSource();
                Validate();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}