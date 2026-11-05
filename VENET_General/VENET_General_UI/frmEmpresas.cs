namespace VENET_General_UI
{
    using DevExpress.XtraPrinting;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmEmpresas : MultiForm
    {
        EmpresasManager.ParametrosBusquedas par = new EmpresasManager.ParametrosBusquedas();

        public frmEmpresas()
        {
            InitializeComponent();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                empresasManager_ParametrosBusquedasBindingSource.DataSource = par;
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Menu_Configuracion_Sucursales)))
                    barSubItemVer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();

            //PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            //link.Component = gridControl2;
            //link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            //link.CreateDocument();
            //link.ShowPreview();
        }


        //private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        //{
        //    Font f = new Font(new FontFamily("Verdana"), 16);
        //    e.Graph.DefaultFont = f;
        //    e.Graph.DrawString("Reporte de Combustible",Color.Black, new RectangleF(250, 25, e.Graph.ClientPageSize.Width, 20), BorderSide.None);

        //    Image i = Image.FromFile("E:\\Documentos\\Iconos\\Imagenes\\logo.png");

        //    RectangleF rect = new RectangleF(new PointF(0, 0), new SizeF(i.Width, i.Height));

        //    VisualBrick visBrick;
        //    visBrick = e.Graph.DrawImage(i, rect, BorderSide.None, Color.White);
        //}

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Buscar)) return;

                Validate();
                empresasManager_SearchResultBindingSource.DataSource = EmpresasManager.Buscar(par);
                //empresasManager_SearchResultBindingSource.DataSource = EmpresasManager.BuscarAsync(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Agregar)) return;

            Empresas o = new Empresas();
            var f = new frmEmpresas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                empresasManager_SearchResultBindingSource.Add(EmpresasManager.Buscar(new EmpresasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Modificar)) return;

                if (empresasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EmpresasManager.SearchResult)empresasManager_SearchResultBindingSource.Current;
                    var f = new frmEmpresas_AddMod(new Empresas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        empresasManager_SearchResultBindingSource[empresasManager_SearchResultBindingSource.Position] = EmpresasManager.Buscar(new EmpresasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        empresasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Eliminar)) return;

                if (empresasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EmpresasManager.Eliminar(new Empresas() { Id = ((EmpresasManager.SearchResult)empresasManager_SearchResultBindingSource.Current).Id });
                    empresasManager_SearchResultBindingSource.RemoveCurrent();
                    empresasManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void empresasManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + empresasManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnSucursales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Empresas", Enums.Accion.Ver, "Ver Sucursales")) return;

            if (empresasManager_SearchResultBindingSource.Current == null) return;

            var f = new frmSucursales(((EmpresasManager.SearchResult)empresasManager_SearchResultBindingSource.Current).Id);
            f.Show(this);
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }


    }
}
