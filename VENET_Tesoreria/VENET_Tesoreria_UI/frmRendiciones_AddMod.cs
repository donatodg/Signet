namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmRendiciones_AddMod : MultiForm, IDisposable, IForm
    {
        private RendicionesManager manager;
        public Rendiciones Rendicion;

        public List<RendicionesDetalle> DetalleList = new List<RendicionesDetalle>();

        public frmRendiciones_AddMod(Rendiciones o)
        {
            InitializeComponent();
            manager = new RendicionesManager(o);
        }

        private void frmRendiciones_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                rendicionesManagerBindingSource.DataSource = manager;

                id_CajaLookUpEdit.Properties.DataSource = Sistema.Cajas;
                id_CajaLookUpEdit.Properties.ValueMember = "Id_Caja";
                id_CajaLookUpEdit.Properties.DisplayMember = "Caja";

                if (manager.Rendicion.Id_Caja != 0)
                {
                    id_CajaLookUpEdit.Enabled = false;
                }
                else
                {
                    if (Sistema.Cajas.Count > 0)
                    {
                        id_CajaLookUpEdit.ItemIndex = 0;
                        manager.Rendicion.Id_Caja = (int)id_CajaLookUpEdit.EditValue;
                    }
                    else
                    {
                        Sistema.Mensaje("El usuario no posee cajas asignadas.");
                        Close();
                    }
                }

                id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
                id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
                id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

                idPersonalLookUpEdit.Properties.DataSource = manager.ListaPersonal;
                idPersonalLookUpEdit.Properties.DisplayMember = "Nombre";
                idPersonalLookUpEdit.Properties.ValueMember = "Id";

                DetalleList.Clear();

                if (manager.Rendicion.Detalle != null)
                {
                    foreach (RendicionesDetalle o in manager.Rendicion.Detalle)
                    {
                        RendicionesDetalle x = new RendicionesDetalle()
                        {
                            Id = o.Id,
                            Id_Cuenta = o.Id_Cuenta,
                            Id_Rendicion = o.Id_Rendicion,
                            Importe = o.Importe,
                            Cuenta = o.Cuenta
                        };
                        DetalleList.Add(x);
                    }
                }
                detalleBindingSource.DataSource = DetalleList;

                if (manager.Rendicion.FechaConfirmacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnAgregarVales.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }

                if (!string.IsNullOrEmpty(manager.Rendicion.Ids_Vales))
                {
                    idPersonalLookUpEdit.Enabled = false;
                }

                RecalculaDiferencia();


                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Operaciones, "Permite Ingresar Importe de Devolución"))
                    devolucionTextEdit.Enabled = false;
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

        private void rendicionesManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.Exception != null && e.Exception is ValidationException)
            {
                Sistema.Mensaje(e.Exception.Message, "Atención", e.Exception);
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (manager.Rendicion.FechaConfirmacion == null)
                Modificar();
        }

        private void Agregar()
        {
            try
            {
                RendicionesDetalle o = new RendicionesDetalle();
                var f = new frmRendicionesDetalle_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Rendicion.Detalle.Add(o);
                    DetalleList.Add(o);
                    gridControl1.RefreshDataSource();
                }
                f.Dispose();
                RecalculaDiferencia();
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
                if (detalleBindingSource.Current == null) return;
                int i = 0;
                int ii = detalleBindingSource.Position;

                RendicionesDetalle o = new RendicionesDetalle();
                foreach (RendicionesDetalle rd in manager.Rendicion.Detalle)
                {
                    if (ii == i)
                    {
                        o = rd;
                        break;
                    }
                    i++;
                }

                var f = new frmRendicionesDetalle_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    detalleBindingSource[detalleBindingSource.Position] = o;

                    gridView1.RefreshData();
                    gridControl1.RefreshDataSource();

                    detalleBindingSource.EndEdit();
                }

                f.Dispose();
                RecalculaDiferencia();
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
                    if (DetalleList[detalleBindingSource.Position].Id == 0)
                    {

                        RendicionesDetalle o = new RendicionesDetalle();
                        int i = 0;
                        int ii = detalleBindingSource.Position;

                        foreach (RendicionesDetalle rd in manager.Rendicion.Detalle)
                        {
                            if (ii == i)
                            {
                                o = rd;
                                break;
                            }
                            i++;
                        }
                        detalleBindingSource.RemoveAt(detalleBindingSource.Position);

                        //DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                        manager.Rendicion.Detalle.Remove(o);
                        gridView1.RefreshData();
                    }
                    else
                    {
                        RendicionesDetalle o = (RendicionesDetalle)detalleBindingSource[detalleBindingSource.Position];
                        RendicionesDetalleManager.Eliminar(new RendicionesDetalle() { Id = ((RendicionesDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                        detalleBindingSource.RemoveAt(detalleBindingSource.Position);
                        //DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                        gridView1.RefreshData();
                    }
                }
                RecalculaDiferencia();
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

        private void importeValeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            RecalculaDiferencia();
        }

        private void devolucionTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            RecalculaDiferencia();
        }

        private void RecalculaDiferencia()
        {
            try
            {
                diferenciaTextEdit.EditValue = manager.Rendicion.ImporteVale - Convert.ToDecimal(DetalleList.Sum(d => d.Importe)) - Convert.ToDecimal(devolucionTextEdit.EditValue);
                //  diferenciaTextEdit.EditValue = manager.ImporteVale - Convert.ToDecimal(DetalleList.Sum(d => d.Importe)) - Convert.ToDecimal(devolucionTextEdit.EditValue);
                manager.Rendicion.Diferencia = Convert.ToDecimal(diferenciaTextEdit.EditValue);
            }
            catch (Exception)
            {
                diferenciaTextEdit.EditValue = 0;
            }
        }

        private void frmRendiciones_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void btnAgregarVales_Click(object sender, EventArgs e)
        {
            Validate();
            if (manager.Rendicion.Id_Personal == 0)
            {
                Sistema.Mensaje("Debe seleccionar un personal.");
                return;
            }
            DateTime fe = Sistema.ObtenerFecha();
            ValesManager.ParametrosBusquedas p = new ValesManager.ParametrosBusquedas() { Id_Caja = manager.Rendicion.Id_Caja, Estado = Enums.ValesEstados.SinRendir, FechaHasta = fe, FechaDesde = fe.AddYears(-2), Id_Personal = manager.Rendicion.Id_Personal };
            frmVales f = new frmVales(p);
            f.Owner = this;
            f.Show(this);
        }

        public void IdSeleccionado(int Id)
        {
            try
            {
                id_CajaLookUpEdit.Enabled = false;
                idPersonalLookUpEdit.Enabled = false;

                manager.AgregarVale(Id);
                RecalculaDiferencia();
                Validate();

                id_ValeTextEdit.EditValue = manager.Rendicion.Ids_Vales;
                importeValeTextEdit.EditValue = manager.Rendicion.ImporteVale;
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

        public void IdsSeleccionados(List<int> Ids)
        {
            try
            {
                foreach (int i in Ids)
                    IdSeleccionado(i);
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
