namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmListaPagos_AddMod : MultiForm, IDisposable
    {
        private ListaPagosManager manager;
        public List<ListaPagosDetalle> DetalleList = new List<ListaPagosDetalle>();

        public frmListaPagos_AddMod(ListaPagos o)
        {
            InitializeComponent();
            manager = new ListaPagosManager(o);
        }

        private void frmListaPagos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                sentidoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoMovimiento));
                sentidoLookUpEdit.Properties.DisplayMember = "Value";
                sentidoLookUpEdit.Properties.ValueMember = "Key";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
                id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
                id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                listaPagosManagerBindingSource.DataSource = manager;

                DetalleList.Clear();

                if (manager.Lista.Detalle != null)
                {
                    foreach (ListaPagosDetalle o in manager.Lista.Detalle)
                    {
                        ListaPagosDetalle x = new ListaPagosDetalle()
                        {
                            Id = o.Id,
                            Importe = o.Importe,
                            Descripcion = o.Descripcion,
                            Id_Entidad = o.Id_Entidad,
                            Entidad = o.Entidad,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                if (manager.Lista.Detalle.Count > 0)
                {
                    tipoEntidadLookUpEdit.Enabled = false;
                    id_SucursalLookUpEdit.Enabled = false;
                }

                detalleBindingSource.DataSource = DetalleList;

                if (manager.Lista.FechaConfirmacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Operaciones, "Importar Excel con Lista de Pago")) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel|*.xlsx";
                openFileDialog1.Title = "Seleccione el archivo con la configuración";
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Listado desde Excel");

                    List<ListaPagosDetalle> l = manager.ImportarExcel(openFileDialog1.FileName);

                    foreach (ListaPagosDetalle o in l)
                    {
                        manager.Lista.Detalle.Add(o);
                        DetalleList.Add(o);

                        gridControl1.RefreshDataSource();
                        tipoEntidadLookUpEdit.Enabled = false;
                    }

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

        private void btnItemPago_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            try
            {
                ListaPagosDetalle o = new ListaPagosDetalle();
                var f = new frmListaPagosDetalle_AddMod(o, manager.Lista.Id_TipoEntidad);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Lista.Detalle.Add(o);
                    DetalleList.Add(o);

                    gridControl1.RefreshDataSource();
                    tipoEntidadLookUpEdit.Enabled = false;
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
                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    ListaPagosDetalle o = new ListaPagosDetalle();

                    foreach (ListaPagosDetalle rd in manager.Lista.Detalle)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmListaPagosDetalle_AddMod(o, manager.Lista.Id_TipoEntidad);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        detalleBindingSource[detalleBindingSource.Position] = o;

                        gridView1.RefreshData();
                        gridControl1.RefreshDataSource();

                        detalleBindingSource.EndEdit();
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
                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (DetalleList[detalleBindingSource.Position].Id != 0)
                        ListaPagosDetalleManager.Eliminar(new ListaPagosDetalle() { Id = ((ListaPagosDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    ListaPagosDetalle o = new ListaPagosDetalle();

                    foreach (ListaPagosDetalle rd in manager.Lista.Detalle)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    if (DetalleList[detalleBindingSource.Position].Id == 0)
                        o.Borrado = true;

                    DetalleList.Remove(DetalleList[detalleBindingSource.Position]);

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

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Save();

                if (DetalleList.Count == 0)
                    ListaPagosManager.Eliminar(new ListaPagos() { Id = manager.Lista.Id });

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

    }
}
