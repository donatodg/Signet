namespace VENET_General_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTipoViaticos_AddMod : MultiForm, IDisposable
    {
        private TipoViaticosManager manager;
        public List<TipoViaticosPrecios> DetalleList = new List<TipoViaticosPrecios>();

        public frmTipoViaticos_AddMod(TipoViaticos o)
        {
            InitializeComponent();
            manager = new TipoViaticosManager(o);
        }

        private void frmTipoViaticos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                tipoViaticosManagerBindingSource.DataSource = manager;

                DetalleList.Clear();

                if (manager.Viatico.Detalle != null)
                {
                    foreach (TipoViaticosPrecios o in manager.Viatico.Detalle)
                    {
                        TipoViaticosPrecios x = new TipoViaticosPrecios()
                        {
                            Id = o.Id,
                            Id_TipoViatico = o.Id_TipoViatico,
                            Importe = o.Importe,
                            VigenciaDesde = o.VigenciaDesde,
                            VigenciaHasta = o.VigenciaHasta,
                            Borrado = o.Borrado,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                tipoViaticosPreciosManagerBindingSource.DataSource = DetalleList ;

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Save();
                DialogResult = DialogResult.OK;
                Close();
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmTipoViaticos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Agregar()
        {
            try
            {
                DateTime fe = Sistema.ObtenerFecha();
                TipoViaticosPrecios o = new TipoViaticosPrecios() { Id_TipoViatico = manager.Viatico.Id, VigenciaDesde = fe, VigenciaHasta = fe };
                var f = new frmTipoViaticosPrecios_AddMod(o, DetalleList);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Viatico.Detalle.Add(o);
                    DetalleList.Add(o);

                    PrecioGridControl.RefreshDataSource();
                }
                f.Dispose();

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

        private void Modificar()
        {
            try
            {
                if (tipoViaticosPreciosManagerBindingSource.Current == null) return;
                {
                    int i = 0;
                    int ii = tipoViaticosPreciosManagerBindingSource.Position;

                    TipoViaticosPrecios o = new TipoViaticosPrecios();

                    foreach (TipoViaticosPrecios rd in manager.Viatico.Detalle)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmTipoViaticosPrecios_AddMod(o, DetalleList);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        tipoViaticosPreciosManagerBindingSource[tipoViaticosPreciosManagerBindingSource.Position] = o;

                        gridView1.RefreshData();
                        PrecioGridControl.RefreshDataSource();

                        tipoViaticosPreciosManagerBindingSource.EndEdit();
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
                if (tipoViaticosPreciosManagerBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (DetalleList[tipoViaticosPreciosManagerBindingSource.Position].Id != 0)
                        TipoViaticosPreciosManager.Eliminar(new TipoViaticosPrecios() { Id = ((TipoViaticosPrecios)tipoViaticosPreciosManagerBindingSource[tipoViaticosPreciosManagerBindingSource.Position]).Id });

                    int i = 0;
                    int ii = tipoViaticosPreciosManagerBindingSource.Position;

                    TipoViaticosPrecios o = new TipoViaticosPrecios();

                    foreach (TipoViaticosPrecios rd in manager.Viatico.Detalle)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    if (DetalleList[tipoViaticosPreciosManagerBindingSource.Position].Id == 0)
                        o.Borrado = true;

                    DetalleList.Remove(DetalleList[tipoViaticosPreciosManagerBindingSource.Position]);
                    //manager.Recibo.Detalle.Remove(o);
                    gridView1.RefreshData();
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
