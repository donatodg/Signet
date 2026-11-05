namespace VENET_Common
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Mensaje que el código original quiso mostrar al usuario (Sistema.Mensaje / Sistema.MensajeSiNo).
    /// En la web no se pueden abrir ventanas: el mensaje se propaga como excepción y la API lo devuelve al navegador.
    /// </summary>
    [Serializable]
    public class SistemaMensajeException : Exception
    {
        public SistemaMensajeException(string titulo, string mensaje, string detalle, bool esConfirmacion = false)
            : base(mensaje)
        {
            Titulo = titulo;
            Detalle = detalle;
            EsConfirmacion = esConfirmacion;
        }

        public string Titulo { get; private set; }
        public string Detalle { get; private set; }
        public bool EsConfirmacion { get; private set; }
    }

    /// <summary>Reemplazo web de frmMensaje (WinForms/DevExpress).</summary>
    public class frmMensaje : Form
    {
        public frmMensaje(string Titulo, string Mensaje, string Error)
        {
            throw new SistemaMensajeException(Titulo, Mensaje, Error);
        }
    }

    /// <summary>Reemplazo web de frmMensajeSiNo. Las confirmaciones deben resolverse en el cliente React.</summary>
    public class frmMensajeSiNo : Form
    {
        public frmMensajeSiNo(string Titulo, string Mensaje)
        {
            throw new SistemaMensajeException(Titulo, Mensaje, null, true);
        }
    }

    /// <summary>Reemplazo web de MultiForm (sólo usado por Sistema.AbrirForm, que no aplica en la web).</summary>
    public class MultiForm : Form
    {
    }
}
