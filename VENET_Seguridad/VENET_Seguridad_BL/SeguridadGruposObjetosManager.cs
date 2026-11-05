namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;
    using VENET_Comun;
    using System.Data.Entity;
    using System.Configuration;
    using VENET_Common;

    public class SeguridadGruposObjetosManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadGrupos Grupo { get; set; }

        public List<SearchResult> ListResult = new List<SearchResult>();

        public SeguridadGruposObjetosManager(SeguridadGrupos o)
        {
            db = new SeguridadContext();
            Grupo = o;

            db.SeguridadGrupos.Attach(Grupo);

            if (Grupo.Id > 0) db.Entry(Grupo).Reload();

            Buscar();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            using (var db = new SeguridadContext())
            {
                foreach (SearchResult x in ListResult)
                {
                    SeguridadGruposObjetos o = new SeguridadGruposObjetos()
                    {
                        Id = x.Id,
                        Id_Grupo = Grupo.Id,
                        Id_Objeto = x.Id_Objeto,
                        FechaAdd = Convert.ToDateTime(x.FechaAdd),
                        FechaMod = x.FechaMod,
                        UserAdd = Convert.ToInt32(x.UserAdd),
                        UserMod = x.UserMod
                    };

                    if (o.Id == 0)
                    {
                        if (x.Selected)
                        {
                            db.Entry(o).State = EntityState.Added;
                            o.FechaAdd = Sistema.ObtenerFechaHora();
                            o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        }
                    }
                    else
                    {
                        db.Entry(o).State = EntityState.Modified;
                        if (x.Selected)
                        {
                            o.FechaMod = Sistema.ObtenerFechaHora();
                            o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        }
                        else
                        {
                            o.FechaDel = Sistema.ObtenerFechaHora();
                            o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        }
                    }

                }
                db.SaveChanges();
            }
        }

        public void Buscar()
        {
            using (var db = new SeguridadContext())
            {
                var r = (from o in db.SeguridadObjetos
                         join go in db.SeguridadGruposObjetos on o.Id equals go.Id_Objeto into listObj
                         from grupObj in listObj.Where(t => t.Id_Grupo == Grupo.Id).DefaultIfEmpty()
                         where (grupObj.Id_Grupo == Grupo.Id || grupObj.UserDel == null)
                         select new SearchResult()
                         {
                             Id = (grupObj == null ? 0 : grupObj.Id),
                             Id_Objeto = o.Id,
                             Formulario = o.Formulario,
                             Modulo = o.Modulo,
                             Permiso = o.Permiso,
                             Selected = ((grupObj == null || grupObj.FechaDel != null) ? false : true),
                             FechaAdd = grupObj.FechaAdd,
                             FechaMod = grupObj.FechaMod,
                             UserAdd = grupObj.UserAdd,
                             UserMod = grupObj.UserMod
                         }).ToList();

                ListResult = r;
            }
        }


        public void MarcaGrupo(Enums.Modulos Modulo, bool AccionMarcado)
        {
            foreach (SearchResult o in ListResult)
            {
                if (o.Modulo == Modulo)
                    o.Selected = AccionMarcado;
            }
        }

        public class SearchResult : SeguridadObjetos
        {
            public bool Selected { get; set; }
            public int Id_Objeto { get; set; }
            public DateTime? FechaAdd { get; set; }
            public DateTime? FechaMod { get; set; }
            public int? UserAdd { get; set; }
            public int? UserMod { get; set; }

        }
    }
}
