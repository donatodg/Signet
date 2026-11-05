namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using VENET_DataEntity;

    public class GestionAsientos
    {
        public class Conceptos
        {
            public string TipoComprobante { get; set; }
            public string LetraComprobante { get; set; }
            public string NroComprobante { get; set; }
            public string ConceptoComprobante { get; set; }
            public string Id_Comprobante { get; set; }
            public string PuntoVenta { get; set; }
            public string TipoEntidad { get; set; }
            public string NombreEntidad { get; set; }
            public string IdEntidad { get; set; }
        }

        public class CuentasImportes
        {
            public decimal TotalOperacion { get; set; }
            public decimal TotalImpuestos { get; set; }
            public decimal TotalId_Impuesto1 { get; set; }
            public decimal TotalId_Impuesto2 { get; set; }
            public decimal TotalId_Impuesto3 { get; set; }
            public decimal TotalId_Impuesto4 { get; set; }
            public decimal TotalId_Impuesto5 { get; set; }
            public decimal TotalId_Impuesto6 { get; set; }
            public decimal TotalId_Impuesto7 { get; set; }
            public decimal TotalId_Impuesto8 { get; set; }
            public decimal TotalId_Impuesto9 { get; set; }
            public decimal TotalId_Impuesto10 { get; set; }
            public decimal TotalIva { get; set; }
            public decimal TotalId_Alicuota1 { get; set; }
            public decimal TotalId_Alicuota2 { get; set; }
            public decimal TotalId_Alicuota3 { get; set; }
            public decimal TotalId_Alicuota4 { get; set; }
            public decimal TotalId_Alicuota5 { get; set; }
            public decimal TotalId_Alicuota6 { get; set; }
            public decimal TotalId_Alicuota7 { get; set; }
            public decimal TotalId_Alicuota8 { get; set; }
            public decimal TotalId_Alicuota9 { get; set; }
            public decimal TotalId_Alicuota10 { get; set; }


        }

    }
}
