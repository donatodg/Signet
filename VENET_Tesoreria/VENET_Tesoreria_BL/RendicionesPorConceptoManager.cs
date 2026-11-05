namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class RendicionesPorConceptoManager
    {
        public RendicionesPorConceptoManager()
        {

        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> result = new List<SearchResult>();

                result = (from r in db.Rendiciones
                          join rd in db.RendicionesDetalle on r.Id equals rd.Id_Rendicion into listDet
                          from det in listDet
                          join c in db.Cajas on r.Id_Caja equals c.Id into listCa
                          from caja in listCa
                          join cc in db.CentrosCostos on r.Id_CentroCosto equals cc.Id into listCC
                          from centro in listCC
                          join cu in db.Cuentas on det.Id_Cuenta equals cu.Id into listCenta
                          from cuenta in listCenta
                          join p in db.Personal on r.Id_Personal equals p.Id into listPer
                          from per in listPer
                          where (det.Id_Cuenta == parametros.Id_Cuenta || parametros.Id_Cuenta == null)
                          && (r.Fecha >= parametros.FechaDesde && r.Fecha <= parametros.FechaHasta)
                          && (r.FechaAnulacion == null)
                          && (r.UserDel == null)
                          && (Seguridad.IdCajasAsignadas.Contains(r.Id_Caja))
                          select new SearchResult
                          {
                              Id = r.Id,
                              Caja = caja.Descripcion,
                              Cuenta = cuenta.Descripcion,
                              CentroCosto = centro.Descripcion,
                              Devolucion = r.Devolucion,
                              Detalle = r.Detalle,
                              Diferencia = r.Diferencia,
                              Fecha = r.Fecha,
                              FechaAnulacion = r.FechaAnulacion,
                              FechaConfirmacion = r.FechaConfirmacion,
                              Ids_Vales = r.Ids_Vales,
                              Id_Caja = r.Id_Caja,
                              Id_CentroCosto = r.Id_CentroCosto,
                              Id_Cuenta = det.Id_Cuenta,
                              Id_Personal = r.Id_Personal,
                              Importe = det.Importe,
                              ImporteVale = r.ImporteVale,
                              MotivoAnulacion = r.MotivoAnulacion,
                              Legajo = per.LaboralLegajo,
                              Personal = per.Apellido + ", " + per.Nombre,
                              FechaAdd = r.FechaAdd,
                              FechaMod = r.FechaMod,
                              UserAdd = r.UserAdd,
                              UserMod = r.UserMod
                          }).ToList();
                return result;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
            }
            public List<KeyNamePair> Cuentas
            {
                get { using (var db = new TesoreriaContext()) { return (db.Cuentas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }
            }
            public int? Id_Cuenta { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
        }

        public class SearchResult : Rendiciones
        {
            public int Id_Cuenta { get; set; }
            public decimal Importe { get; set; }
            public string Caja { get; set; }
            public string Personal { get; set; }
            public int? Legajo { get; set; }
            public string CentroCosto { get; set; }
            public string Cuenta { get; set; }
        }
    }
}