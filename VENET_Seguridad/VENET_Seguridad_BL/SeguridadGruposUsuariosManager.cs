namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class SeguridadGruposUsuariosManager 
    {
        public static List<SearchResult> Buscar(int Id_Grupo)
        {
            using (var db = new SeguridadContext())
            {
                return (db.SeguridadUsuarios
                    .Where(t => t.Id_Grupo == Id_Grupo && t.UserDel == null)
                    .Select(t => new SearchResult()
                        {
                            Id = t.Id,
                            Username = t.Username,
                            Apellido = t.Apellido,
                            Nombre = t.Nombre,
                            Activo = t.Activo
                        })).ToList();
            }
        }

        public class SearchResult
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
        }
    }
}
