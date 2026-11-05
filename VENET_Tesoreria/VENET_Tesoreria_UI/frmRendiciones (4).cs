using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Tesoreria_BL;

namespace VENET_Tesoreria_UI
{
    public partial class frmRendiciones : MultiForm
    {
        private RendicionesManager.ParametrosBusquedas par = new RendicionesManager.ParametrosBusquedas();

        private void frmRendicion_Load(object sender, EventArgs e)
        {
            rendicionesManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void rendicionesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + rendicionesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Buscar)) return;
                this.Validate();
                rendicionesManager_SearchResultBindingSource.DataSource = RendicionesManager.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Agregar)) return;
            Rendiciones o = new Rendiciones();
            var f = new frmRendiciones_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                rendicionesManager_SearchResultBindingSource.Add(RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Modificar)) return;
                if (rendicionesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;
                    var f = new frmRendiciones_AddMod(new Rendiciones() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        rendicionesManager_SearchResultBindingSource[rendicionesManager_SearchResultBindingSource.Position] = RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        rendicionesManager_SearchResultBindingSource.ResetCurrentItem();
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
                Sistema.MensajeError( ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Eliminar)) return;
                if (rendicionesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    RendicionesManager.Eliminar(new Rendiciones() { Id = ((RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current).Id });
                    rendicionesManager_SearchResultBindingSource.RemoveCurrent();
                    rendicionesManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Operaciones, "Confirmar Rendición")) return;

                var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;

                RendicionesManager.Confirmar(new Rendiciones() { Id = curr.Id });
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            {
                try
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Operaciones, "Anular Rendición")) return;

                    var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;

                    RendicionesManager.Anular(new Rendiciones() { Id = curr.Id });
                }
                catch (ValidationException exv)
                {
                    Sistema.Mensaje(exv.Message);
                }
                catch (Exception ex)
                {
                    Sistema.MensajeError( ex);
                }
            }
        }
        
    }
}
