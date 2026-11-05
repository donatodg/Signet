namespace VENET_DataEntity
{
    using System;

    public class ProvFinanciero
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Nullable<DateTime> FechaAdd { get; set; }
        public Nullable<DateTime> FechaMod { get; set; }
        public Nullable<DateTime> FechaDel { get; set; }
        public Nullable<Int32> UserAdd { get; set; }
        public Nullable<Int32> UserMod { get; set; }
        public Nullable<Int32> UserDel { get; set; }
    }
}
