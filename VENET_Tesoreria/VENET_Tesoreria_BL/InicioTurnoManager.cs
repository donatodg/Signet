namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    
    public class InicioTurnoManager : IDisposable
    {
        private TesoreriaContext db;
        public Turnos Turno { get; set; }
        public int NroTurno { get; set; }

        public InicioTurnoManager(int idUser)
        {
            db = new TesoreriaContext();

            var _Turno = (from d in db.Turnos where (d.FechaFin == null) select d).ToList();

            switch (_Turno.Count())
            {
                case 0:
                    {
                        int? _MaxTurno = db.Turnos.Max(u => (int?)u.Id);
                        if (_MaxTurno == null) NroTurno = 1; else NroTurno = (int)_MaxTurno + 1;

                        Turno = new Turnos { Id_Usuario = idUser, FechaInicio = Sistema.ObtenerFechaHora() };
                        db.Turnos.Attach(Turno);

                        break;
                    }

                case 1:
                    {
                        Turno = _Turno.FirstOrDefault();
                        NroTurno = Turno.Id;
                        db.Turnos.Attach(Turno);
                        //if (Turno.Id_Usuario != idUser) throw new ValidationException("Existe un turno abierto por otro usuario.");
                        break;
                    }

                default: throw new Exception("Hay mas de un turno abierto. Avisar a Sistemas.");
            }

        }

        public string Username { get { return db.SeguridadUsuarios.Where(t => t.Id == Turno.Id_Usuario).Select(t => t.Username).FirstOrDefault(); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Turno.Id == 0)
                db.Entry(Turno).State = EntityState.Added;
            else
                db.Entry(Turno).State = EntityState.Modified;

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public List<InformeCierre> Cierre()
        {

            db.Entry(Turno).State = EntityState.Modified;
            db.Entry(Turno).Reload();

            Turno.FechaFin = Sistema.ObtenerFechaHora();

            InformeCierre ic = new InformeCierre()
            {
                Turno = Turno.Id,
                Inicio = Turno.FechaInicio,
                Fin = (DateTime)Turno.FechaFin,
                Id_Usuario = Turno.Id_Usuario,
                Usuario = db.SeguridadUsuarios.Where(t => t.Id == Turno.Id_Usuario).Select(t => t.Username).FirstOrDefault(),
                //DetalleCierre = (from ecc in db.EspeciesCtaCte.Where(t => t.UserDel == null)
                //                 join e in db.Especies on ecc.Id_Especie equals e.Id into listEspecies
                //                 from esp in listEspecies.DefaultIfEmpty()
                //                 group ecc by new { esp.Descripcion, esp.Id } into g
                //                 select new Detalle() { Especie = g.Key.Descripcion, Importe = g.Sum(s => s.Debito - s.Credito) }).ToList(),
                DetalleVales = (from v in db.Vales
                                join r in db.Rendiciones on v.Id equals r.Id_Vale into listRend
                                from ren in listRend.DefaultIfEmpty()
                                join p in db.Personal on v.Id_Personal equals p.Id into listPer
                                from per in listPer.DefaultIfEmpty()
                                where (ren.UserDel == null && v.UserDel == null && ren.FechaConfirmacion == null && v.FechaConfirmacion != null )
                                select new ValesPendientes() { Vale = v.Id, Legajo = per.LaboralLegajo, Personal = per.Apellido + ", " + per.Nombre, Importe = v.Importe }).ToList()
            };

            List<InformeCierre> i = new List<InformeCierre>();
            i.Add(ic);

            db.SaveChanges();

            return i;
        }
    }

    public class InformeCierre
    {
        public int Turno { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public int Id_Usuario { get; set; }
        public string Usuario { get; set; }

        public List<Detalle> DetalleCierre { get; set; }
        public List<ValesPendientes> DetalleVales { get; set; }
        //public Decimal ImporteVales
        //{
        //    get { return DetalleVales.Sum(t => t.Importe); }
        //    set { ImporteVales = 0; }
        //}

    }

    public class Detalle
    {
        //public Int32 Id_Especie { get; set; }
        public string Especie { get; set; }
        //public String TipoMov { get; set; }
        public decimal Importe { get; set; }
    }

    public class ValesPendientes
    {
        public int Vale { get; set; }
        public int? Legajo { get; set; }
        public string Personal { get; set; }
        public decimal Importe { get; set; }





    }
}
