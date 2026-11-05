namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Unidades
    {
        public int Id { get; set; }
        public string Dominio { get; set; }
        public int Estado { get; set; }
        public string NumMotor { get; set; }
        public string NumChasis { get; set; }
        public int Id_Tipo { get; set; }
        public int Id_TipoExtendido { get; set; }
        public int Id_DescFuncional { get; set; }
        public int Id_Radicacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de radicación es obligatoria")]
        public DateTime FechaRadicacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de alta es obligatoria")]
        public DateTime FechaAlta { get; set; }
        public DateTime FechaAdd { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaDel { get; set; }
        public int UserAdd { get; set; }
        public int UserMod { get; set; }
        public int UserDel { get; set; }

    }
}
