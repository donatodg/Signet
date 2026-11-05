namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmRecibosComprobantes_AddMod : MultiForm
    {
        Enums.TipoEntidad _TipoEntidad;
        int _Id_Entidad;
        List<RecibosComprobantes> _ListaComprobantes = new List<RecibosComprobantes>();
        public List<RecibosComprobantes> _ListaComprobantesSeleccionados = new List<RecibosComprobantes>();
        int _IdRec = 0;
        RecibosComprobantesManager manager = new RecibosComprobantesManager();

        public frmRecibosComprobantes_AddMod(Enums.TipoEntidad TipoEntidad, int Id_Entidad, List<RecibosComprobantes> ListaComprobantes)
        {
            InitializeComponent();
            _TipoEntidad = TipoEntidad;
            _Id_Entidad = Id_Entidad;
            _ListaComprobantes = ListaComprobantes;
        }
        public frmRecibosComprobantes_AddMod(Enums.TipoEntidad TipoEntidad, int Id_Entidad, int IdRec)
        {
            InitializeComponent();
            _TipoEntidad = TipoEntidad;
            _Id_Entidad = Id_Entidad;
            _IdRec = IdRec;
            if (_IdRec <= 0) return;
        }

        private void frmRecibosComprobantes_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                recibosComprobantesManager_SearchResultBindingSource.DataSource = manager.Buscar(_TipoEntidad, _Id_Entidad, _ListaComprobantes);
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

        private void recibosComprobantesManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + recibosComprobantesManager_SearchResultBindingSource.Count.ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "RecibosComprobantes", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
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

                _ListaComprobantesSeleccionados.Clear();

                foreach (RecibosComprobantesManager.SearchResult o in (List<RecibosComprobantesManager.SearchResult>)((BindingSource)(gridControl1.DataSource)).List)
                {
                    if (o.ImportePago > o.ImporteAdeudado)
                    {
                        Sistema.Mensaje("El importe ingresado es mayor al adeudado.");
                        return;
                    }

                    if (o.Seleccionado == true && o.ImportePago > 0)
                    {
                        o.FechaAdd = Sistema.ObtenerFechaHora();
                        o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        _ListaComprobantesSeleccionados.Add(o);
                    }
                }

                if (_IdRec > 0)
                    RecibosComprobantesManager.AsociarComprobantes(_IdRec, _ListaComprobantesSeleccionados);

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
    }
}
