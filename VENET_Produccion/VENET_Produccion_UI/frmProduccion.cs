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

    public partial class frmProduccion : MultiForm
    {
        private ProduccionManager.ParametrosBusquedas par = new ProduccionManager.ParametrosBusquedas();
        int Id_Variante;

        public frmProduccion()
        {
            InitializeComponent();
        }

        private void frmProduccion_Load(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.GridControl gridView2 = Controls.Find("gridControl2", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;

                if (gridView2 != null)
                    gridView2.Views[0].RestoreLayoutFromRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text + "-Tareas");

                produccionManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_LineaLookUpEdit.Properties.DataSource = par.Lineas;
                id_LineaLookUpEdit.Properties.DisplayMember = "Name";
                id_LineaLookUpEdit.Properties.ValueMember = "Key";

                //id_VarianteLookUpEdit.Properties.DataSource = par.Variantes;
                id_VarianteLookUpEdit.Properties.DisplayMember = "Name";
                id_VarianteLookUpEdit.Properties.ValueMember = "Key";

                id_MedidaLookUpEdit.Properties.DisplayMember = "Name";
                id_MedidaLookUpEdit.Properties.ValueMember = "Key";

                //if (par.Variantes.Count > 1)
                id_LineaLookUpEdit.EditValue = par.Id_Linea = par.Lineas.ElementAt(0).Key;
                id_VarianteLookUpEdit.EditValue = par.Id_Variante = par.Variantes.ElementAt(0).Key;

                //asignar primer valor
                Id_Variante = (int)par.Id_Variante;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                Agregar();
            else
                AgregarTareas();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                Modificar();
            else
                ModificarTareas();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                Eliminar();
            else
                EliminarTareas();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Imprimir)) return;
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                gridControl1.ShowRibbonPrintPreview();
            else
                gridControl2.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            ModificarTareas();
        }

        private void produccionManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManager_SearchResultBindingSource.Count.ToString();
            else
                barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManager_SearchResultTareasBindingSource.Count.ToString();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text == "Composición")
                barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManager_SearchResultBindingSource.Count.ToString();
            else
                barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManager_SearchResultTareasBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineas", Enums.Accion.Buscar)) return;

                Validate();
                if (par.Id_Variante <= 0)
                {
                    Sistema.Mensaje("Debe seleccionar una variante.");
                    return;
                }

                Id_Variante = (int)par.Id_Variante;

                produccionManager_SearchResultTareasBindingSource.DataSource = ProduccionManager.BuscarTareas(par);
                produccionManager_SearchResultBindingSource.DataSource = ProduccionManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Agregar)) return;

            Produccion o = new Produccion() { Id_Variante = Id_Variante };
            var f = new frmProduccion_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //produccionManager_SearchResultBindingSource.Add(ProduccionManager.Buscar(new ProduccionManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                Buscar();
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Modificar)) return;

                if (produccionManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionManager.SearchResult)produccionManager_SearchResultBindingSource.Current;
                    var f = new frmProduccion_AddMod(new Produccion() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        Buscar();
                        //produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        //produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Eliminar)) return;

                if (produccionManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionManager.Eliminar(new Produccion() { Id = ((ProduccionManager.SearchResult)produccionManager_SearchResultBindingSource.Current).Id });
                    produccionManager_SearchResultBindingSource.RemoveCurrent();
                    produccionManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void AgregarTareas()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Agregar)) return;

            //Produccion_Variantes o = new Produccion_Variantes() { Id = manager.Variante.Id };
            Produccion_VariantesTareas o = new Produccion_VariantesTareas() { Id_Variante = Id_Variante };
            var f = new frmProduccionVariantesTareas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionManager_SearchResultTareasBindingSource.DataSource = ProduccionManager.BuscarTareas(par);
            }
            f.Dispose();
        }

        private void ModificarTareas()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Modificar)) return;

                if (produccionManager_SearchResultTareasBindingSource.Current == null) return;
                {
                    var curr = (ProduccionManager.SearchResultTareas)produccionManager_SearchResultTareasBindingSource.Current;
                    var f = new frmProduccionVariantesTareas_AddMod(new Produccion_VariantesTareas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        Buscar();
                        //produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        //produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void EliminarTareas()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Eliminar)) return;

                if (produccionManager_SearchResultTareasBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionVariantesTareasManager.Eliminar(new Produccion_VariantesTareas() { Id = ((ProduccionManager.SearchResultTareas)produccionManager_SearchResultTareasBindingSource.Current).Id });
                    produccionManager_SearchResultTareasBindingSource.RemoveCurrent();
                    produccionManager_SearchResultTareasBindingSource.ResetBindings(false);
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

        private void id_LineaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (par != null && id_LineaLookUpEdit.ItemIndex != -1)
                {
                    par.Id_Linea = (int)id_LineaLookUpEdit.EditValue;
                    id_VarianteLookUpEdit.Properties.DataSource = par.Variantes;
                    id_VarianteLookUpEdit.EditValue = par.Id_Variante = par.Variantes.ElementAt(0).Key;
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

        private void id_VarianteLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (par != null && id_VarianteLookUpEdit.ItemIndex != -1)
                {
                    par.Id_Variante = (int)id_VarianteLookUpEdit.EditValue;
                    id_MedidaLookUpEdit.Properties.DataSource = par.Medidas;
                    //id_MedidaLookUpEdit.EditValue = par.Id_Medida = par.Medidas.ElementAt(0).Key;
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

        private void frmProduccion_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.GridControl gridView2 = Controls.Find("gridControl2", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;

                if (gridView2 != null)
                    gridView2.Views[0].SaveLayoutToRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text + "-Tareas");
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnCopiarMedidas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Operaciones, "Copiar medidas")) return;

                //if (produccionManager_SearchResultTareasBindingSource.Current == null) return;
                //{
                //    var curr = (ProduccionManager.SearchResultTareas)produccionManager_SearchResultTareasBindingSource.Current;
                var f = new frmProduccionCopiar();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Buscar();
                    //produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    //produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
                }
                f.Dispose();
                //}
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

        private void btnCopiarVariantePorMedida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "Produccion", Enums.Accion.Operaciones, "Copiar Variantes")) return;

                //if (produccionManager_SearchResultTareasBindingSource.Current == null) return;
                //{
                //    var curr = (ProduccionManager.SearchResultTareas)produccionManager_SearchResultTareasBindingSource.Current;
                var f = new frmProduccionCopiarVariante();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Buscar();
                    //produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    //produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
                }
                f.Dispose();
                //}
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
