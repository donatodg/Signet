using System.Drawing;
using System.Resources;

namespace VENET_Contabilidad_UI.Properties
{
    internal static class Resources
    {
        private static readonly ResourceManager Manager = new ResourceManager("VENET_Contabilidad_UI.Properties.Resources", typeof(Resources).Assembly);
        internal static Bitmap addfile_16x16 => (Bitmap)Manager.GetObject("addfile_16x16");
        internal static Bitmap loadfrom_16x16 => (Bitmap)Manager.GetObject("loadfrom_16x16");
        internal static Bitmap deletelist_16x16 => (Bitmap)Manager.GetObject("deletelist_16x16");
        internal static Bitmap print_16x16 => (Bitmap)Manager.GetObject("print_16x16");
        internal static Bitmap save_16x16 => (Bitmap)Manager.GetObject("save_16x16");
    }
}
