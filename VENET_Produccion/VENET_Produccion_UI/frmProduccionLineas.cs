namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionLineas : MultiForm
    {
        private ProduccionLineasManager.ParametrosBusquedas par = new ProduccionLineasManager.ParametrosBusquedas();

        public frmProduccionLineas()
        {
            InitializeComponent();
        }

        private void frmProduccionLineas_Load(object sender, EventArgs e)
        {
            try
            {
                produccionLineasManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        } 
        
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionLineasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionLineasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Buscar)) return;

                Validate();
                produccionLineasManager_SearchResultBindingSource.DataSource = ProduccionLineasManager.Buscar(par);
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

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Agregar)) return;

            Produccion_Lineas o = new Produccion_Lineas();
            var f = new frmProduccionLineas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionLineasManager_SearchResultBindingSource.Add(ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Modificar)) return;

                if (produccionLineasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionLineasManager.SearchResult)produccionLineasManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionLineas_AddMod(new Produccion_Lineas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    f.Dispose();
                }
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Eliminar)) return;

                if (produccionLineasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionLineasManager.Eliminar(new Produccion_Lineas() { Id = ((ProduccionLineasManager.SearchResult)produccionLineasManager_SearchResultBindingSource.Current).Id });
                    produccionLineasManager_SearchResultBindingSource.RemoveCurrent();
                    produccionLineasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnMedidas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Ver, "Medidas Asignadas")) return;

                if (produccionLineasManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmProduccionLineasMedidas(new Produccion_Lineas() { Id = ((ProduccionLineasManager.SearchResult)produccionLineasManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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
