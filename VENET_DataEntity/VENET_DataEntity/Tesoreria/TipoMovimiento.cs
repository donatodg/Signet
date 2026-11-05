namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TipoMovimiento
    {
        public Int32 Id { get; set; }
        public String Descripcion { get; set; }
        public Nullable<DateTime> FechaDel { get; set; }
        public Nullable<Int32> UserDel { get; set; }
    }
}
