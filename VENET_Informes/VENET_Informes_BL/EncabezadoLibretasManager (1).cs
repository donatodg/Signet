namespace VENET_Informes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using VENET_DataEntity;

    public class EncabezadoLibretasManager
    {
        public int id_Empresa { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }

        public EncabezadoLibretasManager()
        {

        }

        public List<DatosReporte> Imprimir()
        {
            using (var db = new GeneralContext())
            {
                Empresas o = new Empresas() { Id = id_Empresa };
                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                Localidades l = new Localidades() { Id = o.Id_CodPostal.Value };
                db.Entry(l).State = EntityState.Unchanged;
                db.Entry(l).Reload();

                List<DatosReporte> ListaReporte = new List<DatosReporte>();

                int i = Desde;
                while (i <= Hasta)
                {
                    ListaReporte.Add(new DatosReporte()
                    {
                        PrimerRenglon = o.Nombre + " - C.U.I.T.:" + o.Cuit,
                        SegundoRenglon = o.Direccion + " - " + l.Localidad,
                        TercerRenglon = "Actividad: " + o.Actividad + ". Disp MTSS 17/98 Art. 5",
                        Nro = i
                    });

                    i += 1;
                }

                return ListaReporte;
            }
        }

        public class DatosReporte
        {
            public string PrimerRenglon { get; set; }
            public string SegundoRenglon { get; set; }
            public string TercerRenglon { get; set; }
            public int Nro { get; set; }
        }
    }
}
