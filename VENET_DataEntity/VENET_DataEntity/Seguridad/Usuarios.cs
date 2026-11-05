namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        public Int32 idUsuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Int32 rol { get; set; }
        public Int32 session { get; set; }
        
    }
}
