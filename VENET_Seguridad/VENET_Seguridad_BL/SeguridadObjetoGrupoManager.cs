namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class SeguridadObjetoGrupoManager
    {
        public static List<SearchResult> Buscar(int Id_Objeto)
        {
            using (var db = new SeguridadContext())
            {
                return (from g in db.SeguridadGrupos
                        join o in db.SeguridadGruposObjetos on g.Id equals o.Id_Grupo into listGrupos
                        from grup in listGrupos.DefaultIfEmpty()
                        where grup.Id_Objeto == Id_Objeto && grup.UserDel == null
                        select new SearchResult()
                        {
                            Id = grup.Id,
                            Descripcion = g.Descripcion
                        }).ToList();
            }
        }

        public class SearchResult
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }

        }
    }
}
