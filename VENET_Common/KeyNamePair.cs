using System.Drawing;

namespace VENET_Common
{
    public class KeyNamePair
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }

    public class Key2NamePair
    {
        public int Key { get; set; }
        public int Key2 { get; set; }
        public string Name { get; set; }
    }

    public class Key2Name2Pair
    {
        public int Key { get; set; }
        public int Key2 { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
    }

    public class Key2Name3Pair
    {
        public int Key { get; set; }
        public int Key2 { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
    }

    public class KeyLongNamePair
    {
        public long Key { get; set; }
        public string Name { get; set; }
    }

    public class KeyName2Pair
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
    }

    public class KeyName3Pair
    {
        public int Key { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
    }

    public class KeyNameDecimalPair
    {
        public int Key { get; set; }
        public decimal Name { get; set; }
    }

    public class PuntoKeyName
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Coordenadas { get; set; }
        public Image Image { get; set; }
    }
}
