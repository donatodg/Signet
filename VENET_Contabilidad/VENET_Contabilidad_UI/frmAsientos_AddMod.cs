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

    public partial class frmAsientos_AddMod : MultiForm, IDisposable
    {
        private AsientosManager manager;
        public List<AsientosDetalle> DetalleList = new List<AsientosDetalle>();

        public frmAsientos_AddMod(Asientos o)
        {
            InitializeComponent();
            manager = new AsientosManager(o);
        }

        private void frmAsientos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                fechaDateEdit.Enabled = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Asientos_ModificarFechaCreacion));
                numeroTextEdit.Enabled = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Asientos_ModificarNumero));

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                asientosManagerBindingSource.DataSource = manager;

                DetalleList.Clear();

                if (manager.Asiento.Detalle != null)
                {
                    foreach (AsientosDetalle o in manager.Asiento.Detalle)
                    {
                        AsientosDetalle x = new AsientosDetalle()
                        {
                            Id = o.Id,
                            Asiento = o.Asiento,
                            Borrado = o.Borrado,
                            Cuenta = o.Cuenta,
                            Debe = o.Debe,
                            Haber = o.Haber,
                            Id_Asiento = o.Id_Asiento,
                            Id_CuentaContable = o.Id_CuentaContable,
                            Orden = o.Orden,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                detalleBindingSource.DataSource = DetalleList;

                VerificaFecha();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void VerificaFecha()
        {
            if (AsientosManager.EjercicioCerrado(manager.Asiento.Fecha, manager.Asiento.Id_Empresa))
            {
                btnGuardar.Enabled = false;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
                btnAgregar.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos_AddMod", Enums.Accion.Agregar)) return;

                AsientosDetalle o = new AsientosDetalle();
                o.Orden = DetalleList.Select(t => t.Orden).LastOrDefault() + 1;
                var f = new frmAsientosDetalle_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Asiento.Detalle.Add(o);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos_AddMod", Enums.Accion.Modificar)) return;

                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    AsientosDetalle o = new AsientosDetalle();

                    foreach (AsientosDetalle rd in manager.Asiento.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmAsientosDetalle_AddMod(o);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    foreach (AsientosDetalle rd in manager.Asiento.Detalle.Where(t => t.Borrado == false))
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

        private void frmAsientos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Asiento.Detalle.Count == 0 && manager.Asiento.Id > 0)
            {
                AsientosManager.Eliminar(new Asientos { Id = manager.Asiento.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        private void fechaDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            manager.Asiento.Fecha = Convert.ToDateTime(fechaDateEdit.EditValue);
            VerificaFecha();
        }

    }
}
