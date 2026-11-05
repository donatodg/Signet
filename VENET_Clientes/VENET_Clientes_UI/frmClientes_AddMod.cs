namespace VENET_Clientes_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Clientes_BL;
    using VENET_Common;
    using VENET_DataEntity;
    using System.Linq;

    public partial class frmClientes_AddMod : MultiForm, IDisposable
    {
        private ClientesManager manager;
        public Clientes Clientes;
        public List<ClientesContactos> ContactosList = new List<ClientesContactos>();
        public List<ClientesDescuentos> DescuentosList = new List<ClientesDescuentos>();
        public List<ClientesEntregas> EntregasList = new List<ClientesEntregas>();

        public frmClientes_AddMod()
        {
            InitializeComponent();
            manager = new ClientesManager(new Clientes() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmClientes_AddMod(Clientes o)
        {
            InitializeComponent();
            manager = new ClientesManager(o);
        }

        private void frmClientes_AddMod_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Clientes_VerDescuentos)))
                tpDescuentos.PageVisible = false;

            id_CodPostalLookUpEdit.Properties.DataSource = Sistema.CodPostal;
            id_CodPostalLookUpEdit.Properties.ValueMember = "Id";
            id_CodPostalLookUpEdit.Properties.DisplayMember = "Descripcion";

            id_TipoIvaLookUpEdit.Properties.DataSource = Sistema.TiposIva;
            id_TipoIvaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoIvaLookUpEdit.Properties.ValueMember = "Key";

            id_ListaPrecioLookUpEdit.Properties.DataSource = manager.ListasPrecios;
            id_ListaPrecioLookUpEdit.Properties.DisplayMember = "Name";
            id_ListaPrecioLookUpEdit.Properties.ValueMember = "Key";

            id_FormaPagoLookUpEdit.Properties.DataSource = Sistema.FormasPagos;
            id_FormaPagoLookUpEdit.Properties.DisplayMember = "Name";
            id_FormaPagoLookUpEdit.Properties.ValueMember = "Key";

            clientesManagerBindingSource.DataSource = manager;

            ContactosList.Clear();
            DescuentosList.Clear();
            EntregasList.Clear();


            if (manager.Cliente.Contactos != null)
                foreach (ClientesContactos o in manager.Cliente.Contactos)
                {
                    ClientesContactos x = new ClientesContactos()
                    {
                        Id = o.Id,
                        Borrado = o.Borrado,
                        Cliente = o.Cliente,
                        Email = o.Email,
                        FechaAdd = o.FechaAdd,
                        FechaMod = o.FechaMod,
                        Id_Cliente = o.Id_Cliente,
                        Nombre = o.Nombre,
                        Telefono1 = o.Telefono1,
                        Telefono2 = o.Telefono2,
                        UserAdd = o.UserAdd,
                        UserMod = o.UserMod
                    };
                    ContactosList.Add(x);
                }

            if (manager.Cliente.Descuentos != null)
                foreach (ClientesDescuentos o in manager.Cliente.Descuentos)
                {
                    ClientesDescuentos x = new ClientesDescuentos()
                    {
                        Id = o.Id,
                        Borrado = o.Borrado,
                        Cliente = o.Cliente,
                        Categoria = o.Categoria,
                        Descuento = o.Descuento,
                        Id_Categoria2 = o.Id_Categoria2,
                        FechaAdd = o.FechaAdd,
                        FechaMod = o.FechaMod,
                        Id_Cliente = o.Id_Cliente,
                        UserAdd = o.UserAdd,
                        UserMod = o.UserMod
                    };
                    DescuentosList.Add(x);
                }

            if (manager.Cliente.Entregas != null)
                foreach (ClientesEntregas o in manager.Cliente.Entregas)
                {
                    ClientesEntregas x = new ClientesEntregas()
                    {
                        Id = o.Id,
                        Borrado = o.Borrado,
                        Cliente = o.Cliente,
                        Direccion = o.Direccion,
                        Email = o.Email,
                        Nombre = o.Nombre,
                        FechaAdd = o.FechaAdd,
                        FechaMod = o.FechaMod,
                        Id_Cliente = o.Id_Cliente,
                        UserAdd = o.UserAdd,
                        UserMod = o.UserMod
                    };
                    EntregasList.Add(x);
                }

            contactosBindingSource.DataSource = ContactosList;
            descuentosBindingSource.DataSource = DescuentosList;
            entregasBindingSource.DataSource = EntregasList;
        }

        private void frmClientes_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
                ConfigurationManager.AppSettings["RetornoId"] = manager.Cliente.Id.ToString();
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

        private void ClientesManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesContactos o = new ClientesContactos();
                var f = new frmClientesContactos_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Cliente.Contactos.Add(o);
                    ContactosList.Add(o);

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (contactosBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = contactosBindingSource.Position;

                    ClientesContactos o = new ClientesContactos();

                    foreach (ClientesContactos rd in manager.Cliente.Contactos)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmClientesContactos_AddMod(o);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {

                        contactosBindingSource[contactosBindingSource.Position] = o;

                        gridView1.RefreshData();
                        gridControl1.RefreshDataSource();

                        contactosBindingSource.EndEdit();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (contactosBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (ContactosList[contactosBindingSource.Position].Id != 0)
                        ClientesContactosManager.Eliminar(new ClientesContactos() { Id = ((ClientesContactos)contactosBindingSource[contactosBindingSource.Position]).Id });

                    int i = 0;
                    int ii = contactosBindingSource.Position;

                    ClientesContactos o = new ClientesContactos();

                    foreach (ClientesContactos rd in manager.Cliente.Contactos)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    if (ContactosList[contactosBindingSource.Position].Id == 0)
                        o.Borrado = true;

                    ContactosList.Remove(ContactosList[contactosBindingSource.Position]);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnModificar_Click(null, null);
        }

        private void btnAgregarD_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesDescuentos o = new ClientesDescuentos();
                var f = new frmClientesDescuentos_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    if (DescuentosList.Where(t => t.Borrado == false && t.UserDel == null && t.Id_Categoria2 == o.Id_Categoria2).Count() > 0)
                    {
                        Sistema.Mensaje("Ya se encuentra la categoría ingresada");
                    }
                    else
                    {
                        manager.Cliente.Descuentos.Add(o);
                        DescuentosList.Add(o);

                        gridControl2.RefreshDataSource();
                    }
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

        private void btnModificarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (descuentosBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = descuentosBindingSource.Position;

                    ClientesDescuentos o = new ClientesDescuentos();

                    foreach (ClientesDescuentos rd in manager.Cliente.Descuentos)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmClientesDescuentos_AddMod(o);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        if (DescuentosList.Where(t => t.Borrado == false && t.UserDel == null && t.Id_Categoria2 == o.Id_Categoria2).Count() > 1)
                        {
                            Sistema.Mensaje("Ya se encuentra la categoría ingresada");
                        }
                        else
                        {
                            descuentosBindingSource[descuentosBindingSource.Position] = o;

                            gridView2.RefreshData();
                            gridControl2.RefreshDataSource();

                            descuentosBindingSource.EndEdit();
                        }
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

        private void btnEliminarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (descuentosBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (DescuentosList[descuentosBindingSource.Position].Id != 0)
                        ClientesDescuentosManager.Eliminar(new ClientesDescuentos() { Id = ((ClientesDescuentos)descuentosBindingSource[descuentosBindingSource.Position]).Id });

                    int i = 0;
                    int ii = descuentosBindingSource.Position;

                    ClientesDescuentos o = new ClientesDescuentos();

                    foreach (ClientesDescuentos rd in manager.Cliente.Descuentos)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    //if (DescuentosList[contactosBindingSource.Position].Id == 0)
                    //    o.Borrado = true;

                    DescuentosList.Remove(DescuentosList[descuentosBindingSource.Position]);
                    gridView2.RefreshData();
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

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            btnModificarD_Click(null, null);
        }

        private void btnAgregarE_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesEntregas o = new ClientesEntregas();
                var f = new frmClientesEntregas_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Cliente.Entregas.Add(o);
                    EntregasList.Add(o);

                    gridControl3.RefreshDataSource();
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

        private void btnModificarE_Click(object sender, EventArgs e)
        {
            try
            {
                if (entregasBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = entregasBindingSource.Position;

                    ClientesEntregas o = new ClientesEntregas();

                    foreach (ClientesEntregas rd in manager.Cliente.Entregas)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmClientesEntregas_AddMod(o);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        entregasBindingSource[entregasBindingSource.Position] = o;

                        gridView3.RefreshData();
                        gridControl3.RefreshDataSource();

                        entregasBindingSource.EndEdit();
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

        private void btnEliminarE_Click(object sender, EventArgs e)
        {
            try
            {
                if (entregasBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (EntregasList[entregasBindingSource.Position].Id != 0)
                        ClientesEntregasManager.Eliminar(new ClientesEntregas() { Id = ((ClientesEntregas)entregasBindingSource[entregasBindingSource.Position]).Id });

                    int i = 0;
                    int ii = entregasBindingSource.Position;

                    ClientesEntregas o = new ClientesEntregas();

                    foreach (ClientesEntregas rd in manager.Cliente.Entregas)
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    //if (DescuentosList[contactosBindingSource.Position].Id == 0)
                    //    o.Borrado = true;

                    EntregasList.Remove(EntregasList[entregasBindingSource.Position]);
                    gridView3.RefreshData();
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

        private void btnGeneraCUIT_Click(object sender, EventArgs e)
        {
            try
            {
                frmGeneraCuit f = new frmGeneraCuit();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    manager.Cliente.Cuit = f.Cuit;
                    cuitTextEdit.EditValue = manager.Cliente.Cuit;
                }
                f.Dispose();
                Validate();
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

        private void id_ListaPrecioLookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }
    }
}