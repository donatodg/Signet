namespace VENET_Contabilidad_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmTipoAsientos_AddMod : MultiForm, IDisposable
    {
        private TipoAsientosManager manager;
        public List<TipoAsientosDetalle> DetalleList = new List<TipoAsientosDetalle>();
        //private bool load;

        public frmTipoAsientos_AddMod(TipoAsientos o)
        {
            InitializeComponent();
            manager = new TipoAsientosManager(o);
        }

        private void frmTipoAsientos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                //load = true;

                id_AsientoPredefinidoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TiposDeAsientos));
                id_AsientoPredefinidoLookUpEdit.Properties.DisplayMember = "Value";
                id_AsientoPredefinidoLookUpEdit.Properties.ValueMember = "Key";

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                tipoAsientosManagerBindingSource.DataSource = manager;

                DetalleList.Clear();

                if (manager.Tipo.Detalle != null)
                {
                    foreach (TipoAsientosDetalle o in manager.Tipo.Detalle)
                    {
                        TipoAsientosDetalle x = new TipoAsientosDetalle()
                        {
                            Id = o.Id,
                            CuentaContable = o.CuentaContable,
                            TipoAsientos = o.TipoAsientos,
                            Debe = o.Debe,
                            Id_CuentaContable = o.Id_CuentaContable,
                            Id_CuentaImporte = o.Id_CuentaImporte,
                            Id_TipoAsiento = o.Id_TipoAsiento,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                //if (manager.Tipo.Detalle.Count > 0)
                //{
                //    id_SucursalLookUpEdit.Enabled = false;
                //    id_EntidadLookUpEdit.Enabled = false;
                //    id_TipoEntidadLookUpEdit.Enabled = false;
                //}

                detalleBindingSource.DataSource = DetalleList;

                //load = false;
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

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos_AddMod", Enums.Accion.Agregar)) return;

                TipoAsientosDetalle o = new TipoAsientosDetalle();
                var f = new frmTipoAsientosDetalle_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Tipo.Detalle.Add(o);
                    DetalleList.Add(o);

                    gridControl1.RefreshDataSource();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos_AddMod", Enums.Accion.Modificar)) return;

                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    TipoAsientosDetalle o = new TipoAsientosDetalle();

                    foreach (TipoAsientosDetalle rd in manager.Tipo.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmTipoAsientosDetalle_AddMod(o);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    foreach (TipoAsientosDetalle rd in manager.Tipo.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            rd.Borrado = true;
                            break;
                        }
                        i++;
                    }

                    detalleBindingSource.RemoveAt(detalleBindingSource.Position);
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

        private void frmTipoAsientos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Tipo.Detalle.Count == 0 && manager.Tipo.Id > 0)
            {
                TipoAsientosManager.Eliminar(new TipoAsientos { Id = manager.Tipo.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

    }
}
