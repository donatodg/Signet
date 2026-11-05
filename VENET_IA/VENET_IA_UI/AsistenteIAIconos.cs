using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VENET_IA_UI
{
    /// <summary>Íconos del asistente (destellos ✨ con degradado), dibujados en código para no depender de recursos.</summary>
    public static class AsistenteIAIconos
    {
        private static Icon _icono;

        public static Image Imagen(int tamaño)
        {
            var bmp = new Bitmap(tamaño, tamaño);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var pincel = new LinearGradientBrush(new Rectangle(0, 0, tamaño, tamaño), Color.FromArgb(79, 70, 229), Color.FromArgb(192, 38, 211), 45f))
                {
                    float s = tamaño;
                    Destello(g, pincel, s * 0.42f, s * 0.56f, s * 0.40f);
                    Destello(g, pincel, s * 0.78f, s * 0.22f, s * 0.20f);
                    Destello(g, pincel, s * 0.80f, s * 0.80f, s * 0.13f);
                }
            }
            return bmp;
        }

        public static Icon Icono()
        {
            if (_icono == null)
            {
                try
                {
                    using (var bmp = (Bitmap)Imagen(32))
                        _icono = Icon.FromHandle(bmp.GetHicon());
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return _icono;
        }

        /// <summary>Estrella de 4 puntas de lados cóncavos centrada en (x, y) con radio r.</summary>
        private static void Destello(Graphics g, Brush pincel, float x, float y, float r)
        {
            float c = r * 0.22f;
            using (var p = new GraphicsPath())
            {
                p.AddBezier(x, y - r, x + c * 0.4f, y - c, x + c, y - c * 0.4f, x + r, y);
                p.AddBezier(x + r, y, x + c, y + c * 0.4f, x + c * 0.4f, y + c, x, y + r);
                p.AddBezier(x, y + r, x - c * 0.4f, y + c, x - c, y + c * 0.4f, x - r, y);
                p.AddBezier(x - r, y, x - c, y - c * 0.4f, x - c * 0.4f, y - c, x, y - r);
                p.CloseFigure();
                g.FillPath(pincel, p);
            }
        }
    }
}
