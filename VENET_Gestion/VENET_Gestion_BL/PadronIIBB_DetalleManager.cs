namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class PadronIIBB_DetalleManager
    {
        private int _Id_PadronIIBB;

        public PadronIIBB_DetalleManager(int Id_PadronIIBB)
        {
            _Id_PadronIIBB = Id_PadronIIBB;
        }

        public List<SearchResult> Buscar()
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from d in db.PadronIIBB_Detalle
                     where (d.Id_PadronIIBB == _Id_PadronIIBB)
                            && (d.UserDel == null)
                     select new SearchResult
                     {
                         Id = d.Id,
                         FechaAdd = d.FechaAdd,
                         FechaMod = d.FechaMod,
                         UserAdd = d.UserAdd,
                         UserMod = d.UserMod
                     }).ToList();
                return r;
            }
        }


        public class SearchResult : PadronIIBB_Detalle
        {

        }
    }
}
