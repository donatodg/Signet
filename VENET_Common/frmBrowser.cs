namespace VENET_Common
{
    using System;
    using VENET_Comun;
    
    public partial class frmBrowser : MultiForm
    {
        private string _Data;
        private Enums.ContenidoBrowser _Tipo;

        public frmBrowser(string Data, Enums.ContenidoBrowser Tipo, string Titulo = "Navegador")
        {
            InitializeComponent();
            _Data = Data;
            _Tipo = Tipo;
            Text = Titulo;
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            switch (_Tipo)
            {
                case Enums.ContenidoBrowser.Contenido:
                    webBrowser1.DocumentText = _Data;
                    break;
                case Enums.ContenidoBrowser.DireccionURL:
                    webBrowser1.Navigate(_Data);
                    break;
            }
        }
    }
}
