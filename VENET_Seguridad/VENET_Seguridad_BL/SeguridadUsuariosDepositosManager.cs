namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class SeguridadUsuariosDepositosManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<ComboDepositos> DepositosSinAsignar { get; private set; }

        public SeguridadUsuariosDepositosManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();
            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            DepositosSinAsignar = (from s in db.Depositos
                                   where (s.UserDel == null)
                                   && !(db.SeguridadUsuariosDepositos.Where(t => t.Id_Usuario == o.Id && t.UserDel == null).Select(t => t.Id_Deposito).ToList()).Contains(s.Id)
                                   select new ComboDepositos()
                                   {
                                       Id = s.Id,
                                       Deposito = s.Descripcion
                                   }).OrderBy(t => t.Deposito).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosDepositos o)
        {
            using (var db = new SeguridadContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public List<SearchResult> Buscar()
        {
            using (var db = new SeguridadContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from g in db.SeguridadUsuariosDepositos
                     join s in db.Depositos on g.Id_Deposito equals s.Id into listSuc
                     from suc in listSuc
                     join sucd in db.SeguridadUsuarioDepositoDefault on new { g.Id_Deposito, g.Id_Usuario } equals new { sucd.Id_Deposito, sucd.Id_Usuario } into listDef
                     from def in listDef.DefaultIfEmpty()
                     where (g.Id_Usuario == Usuario.Id)
                           && (g.UserDel == null)
                           && (suc.UserDel == null)
                     select new SearchResult
                     {
                         Id = g.Id,
                         Deposito = suc.Descripcion,
                         Id_Deposito = g.Id_Deposito,
                         Id_Usuario = g.Id_Usuario,
                         UserAdd = g.UserAdd,
                         UserMod = g.UserMod,
                         FechaAdd = g.FechaAdd,
                         FechaMod = g.FechaMod,
                         Default = def.Id_Deposito
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdDeposito)
        {
            if (IdDeposito == 0) throw new ValidationException("Debe ingresar un Depósito.");
            if (db.SeguridadUsuariosDepositos.Where(t => t.Id_Deposito == IdDeposito && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("El depósito ya está asignado");

            SeguridadUsuariosDepositos o = new SeguridadUsuariosDepositos()
            {
                Id_Deposito = IdDeposito,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void SetDefault(int Id_Deposito, int Id_Usuario)
        {
            using (var db = new SeguridadContext())
            {
                //Elimina los asociacion anterior
                var query = from d in db.SeguridadUsuarioDepositoDefault
                            where d.Id_Usuario == Id_Usuario
                            select d;

                foreach (SeguridadUsuarioDepositoDefault def in query)
                {
                    db.SeguridadUsuarioDepositoDefault.Attach(def);
                    db.Entry(def).State = EntityState.Deleted;
                }

                SeguridadUsuarioDepositoDefault o = new SeguridadUsuarioDepositoDefault()
                {
                    Id_Deposito = Id_Deposito,
                    Id_Usuario = Id_Usuario,
                };

                db.Entry(o).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public class SearchResult : SeguridadUsuariosDepositos
        {
            public string Deposito { get; set; }
            public int? Default { get; set; }
        }

        public class ComboDepositos
        {
            public int Id { get; set; }
            public string Deposito { get; set; }
        }
    }
}