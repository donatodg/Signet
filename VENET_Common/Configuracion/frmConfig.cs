namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;

    public partial class frmConfig : Form
    {
        private Config _o;

        public frmConfig(Config o)
        {
            InitializeComponent();
            _o = o;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _o.Bases;
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

        private void Agregar()
        {
            ConfigBases o = new ConfigBases();
            var frm = new frmConfig_AddMod(o);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                bindingSource1.Add(o);
            }
            frm.Dispose();
        }

        private void Modificar()
        {
            try
            {
                ConfigBases o = new ConfigBases()
                {
                    DataBase = ((ConfigBases)bindingSource1.Current).DataBase,
                    DataSource = ((ConfigBases)bindingSource1.Current).DataSource,
                    Name = ((ConfigBases)bindingSource1.Current).Name,
                    Pass = ((ConfigBases)bindingSource1.Current).Pass,
                    Provider = ((ConfigBases)bindingSource1.Current).Provider,
                    User = ((ConfigBases)bindingSource1.Current).User
                };

                var f = new frmConfig_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    bindingSource1[bindingSource1.Position] = f._Config;
                    bindingSource1.ResetCurrentItem();
                }
                f.Dispose();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje("Atención", exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", ex.Message);
            }
        }

        private void Eliminar()
        {
            bindingSource1.Remove((ConfigBases)gridView1.GetRow(gridView1.FocusedRowHandle));
            gridView1.RefreshData();
        }

        private void frmConfig_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _o.Bases = (List<ConfigBases>)bindingSource1.DataSource;

            Config.GrabarConfiguracion(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Setup.xml", _o);
        }

        private void bindingSource1_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            lblRegistros.Caption = "Cantidad de Registros: " + bindingSource1.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmConfig_AddMod2 f = new frmConfig_AddMod2(_o);
            f.ShowDialog(this);
            f.Dispose();
        }

    }
}
