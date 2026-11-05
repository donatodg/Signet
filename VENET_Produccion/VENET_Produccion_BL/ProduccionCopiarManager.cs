namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionCopiarManager
    {
        private ProduccionContext db = new ProduccionContext();

        public int? Id_Linea { get; set; }
        public int? Id_Variante { get; set; }
        public int? Id_Medida { get; set; }

        public int? Id_Linea_Destino { get; set; }
        public int? Id_Variante_Destino { get; set; }
        //public int? Id_Medida_Destino { get; set; }

        public List<KeyName2Pair> Lineas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        join emp in db.Empresas on l.Id_Empresa equals emp.Id into listEmp
                        from e in listEmp
                        where l.UserDel == null
                           && Seguridad.IdEmpresasAsignadas.Contains(l.Id_Empresa)
                        select new KeyName2Pair()
                        {
                            Key = l.Id,
                            Name = l.Codigo + "-" + l.Descripcion,
                            Name2 = e.Nombre
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Variantes
        {
            get
            {
                List<KeyNamePair> r = new List<KeyNamePair>();

                r = (from v in db.Produccion_Variantes
                     where v.UserDel == null
                        && v.Id_Linea == Id_Linea
                     select new KeyNamePair()
                     {
                         Key = v.Id,
                         Name = v.Codigo + "-" + v.Descripcion
                     }).OrderBy(t => t.Name).ToList();

                if (r.Count == 0) throw new ValidationException("La línea no posee variantes asociadas.");
                return r;
            }
        }

        public List<KeyNamePair> Medidas
        {
            get
            {
                List<KeyNamePair> r = new List<KeyNamePair>();

                if (Id_Linea == null)
                    return r;
                else
                {
                    r = (from lm in db.Produccion_LineasMedidas
                         join me in db.Produccion_Medidas on lm.Id_Medida equals me.Id into listMedidas
                         from m in listMedidas
                         where lm.UserDel == null
                            && m.UserDel == null
                            && lm.Id_Linea == Id_Linea
                         //&& lm.Id_Linea == (db.Produccion_Variantes.Where(t2 => t2.Id == Id_Variante).Select(t2 => t2.Id_Linea)).FirstOrDefault()
                         select new KeyNamePair()
                         {
                             Key = m.Id,
                             Name = m.Medida
                         }).OrderBy(t => t.Name).ToList();

                    if (r.Count == 0)
                        throw new ValidationException("La línea no posee medidas asociadas.");

                    return r;
                }
            }
        }

        public List<KeyNamePair> Variantes_Destino
        {
            get
            {
                List<KeyNamePair> r = new List<KeyNamePair>();

                r = (from v in db.Produccion_Variantes
                     where v.UserDel == null
                        && v.Id_Linea == Id_Linea_Destino
                     select new KeyNamePair()
                     {
                         Key = v.Id,
                         Name = v.Codigo + "-" + v.Descripcion
                     }).OrderBy(t => t.Name).ToList();

                if (r.Count == 0) throw new ValidationException("La línea no posee variantes asociadas.");
                return r;
            }
        }

        public List<KeyNamePair> Medidas_Destino
        {
            get
            {
                List<KeyNamePair> r = new List<KeyNamePair>();

                if (Id_Linea_Destino == null)
                    return r;
                else
                {
                    r = (from lm in db.Produccion_LineasMedidas
                         join me in db.Produccion_Medidas on lm.Id_Medida equals me.Id into listMedidas
                         from m in listMedidas
                         where lm.UserDel == null
                            && m.UserDel == null
                            && lm.Id_Linea == Id_Linea_Destino
                         //&& lm.Id_Linea == (db.Produccion_Variantes.Where(t2 => t2.Id == Id_Variante).Select(t2 => t2.Id_Linea)).FirstOrDefault()
                         select new KeyNamePair()
                         {
                             Key = m.Id,
                             Name = m.Medida
                         }).OrderBy(t => t.Name).ToList();

                    if (r.Count == 0) throw new ValidationException("La línea no posee medidas asociadas.");

                    return r;
                }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save(int Copiar, int IdMedida)
        {
            if (IdMedida == 0) throw new ValidationException("Debe ingresar una medida.");

            if (Id_Variante == Id_Variante_Destino && Id_Medida == IdMedida) return;

            bool Caso1 = false;
            bool Caso2 = false;

            if (Copiar == 0) { Caso1 = true; Caso2 = true; }
            if (Copiar == 1) { Caso1 = true; }
            if (Copiar == 2) { Caso2 = true; }

            ProduccionContext db1 = new ProduccionContext();

            if (Caso1)
            {
                //BORRADO
                var query = from p in db.Produccion
                            where p.Id_Variante == Id_Variante_Destino &&
                                  p.Id_Medida == IdMedida &&
                                  p.UserDel == null
                            select p;

                foreach (Produccion c in query)
                {
                    db1.Produccion.Attach(c);
                    db.Entry(c).State = EntityState.Modified;

                    c.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    c.FechaDel = Sistema.ObtenerFechaHora();
                }


                if (((from l in db.Produccion_Lineas
                      join var in db.Produccion_Variantes on l.Id equals var.Id_Linea into listVar
                      from va in listVar
                      join linMed in db.Produccion_LineasMedidas on l.Id equals linMed.Id_Linea into listLM
                      from lm in listLM
                      where l.Id == Id_Linea_Destino
                         && lm.Id_Medida == IdMedida
                         && va.Id == Id_Variante_Destino
                         && l.UserDel == null
                         && va.UserDel == null
                         && lm.UserDel == null
                      select lm.Id_Medida).Count()) > 0)
                {

                    //NUEVO
                    var query1 = from p in db.Produccion
                                 where p.Id_Variante == Id_Variante &&
                                       p.Id_Medida == Id_Medida &&
                                       p.UserDel == null
                                 select p;

                    foreach (Produccion c in query1)
                    {
                        Produccion Prod = new Produccion()
                        {
                            Altos = c.Altos,
                            Id_Medida = IdMedida,
                            Id_Variante = Convert.ToInt32(Id_Variante_Destino),
                            Id_Producto = c.Id_Producto,
                            Id_ProductoDerivado = c.Id_ProductoDerivado,
                            Incidencia = c.Incidencia,
                            Operacion = c.Operacion,
                            OperacionAltos = c.OperacionAltos,
                            OperacionAnchos = c.OperacionAnchos,
                            Cantidad = c.Cantidad,
                            AnchosAjuste = c.AnchosAjuste,
                            AltosAjuste = c.AltosAjuste,
                            Anchos = c.Anchos,
                            FechaAdd = Sistema.ObtenerFechaHora(),
                            UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                        };

                        db1.Produccion.Attach(Prod);
                        db1.Entry(Prod).State = EntityState.Added;
                    }
                }

                var err = db1.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db1.SaveChanges();
            }

            if (Caso2)
            {
                //BORRADO
                var query0 = from p in db.Produccion_VariantesTareas
                             where p.Id_Variante == Id_Variante_Destino &&
                                   p.Id_Medida == IdMedida &&
                                   p.UserDel == null
                             select p;

                foreach (Produccion_VariantesTareas c in query0)
                {
                    db1.Produccion_VariantesTareas.Attach(c);
                    db.Entry(c).State = EntityState.Modified;

                    c.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    c.FechaDel = Sistema.ObtenerFechaHora();
                }

                if (((from l in db.Produccion_Lineas
                      join var in db.Produccion_Variantes on l.Id equals var.Id_Linea into listVar
                      from va in listVar
                      join linMed in db.Produccion_LineasMedidas on l.Id equals linMed.Id_Linea into listLM
                      from lm in listLM
                      where l.Id == Id_Linea_Destino
                         && lm.Id_Medida == IdMedida
                         && va.Id == Id_Variante_Destino
                         && l.UserDel == null
                         && va.UserDel == null
                         && lm.UserDel == null
                      select lm.Id_Medida).Count()) > 0)

                //if (((from vt in db.Produccion_VariantesTareas
                //  join var in db.Produccion_Variantes on vt.Id_Variante equals var.Id into listVar
                //  from va in listVar
                //  join lin in db.Produccion_Lineas on va.Id_Linea equals lin.Id into listLin
                //  from l in listLin
                //  join linMed in db.Produccion_LineasMedidas on l.Id equals linMed.Id_Linea into listLM
                //  from lm in listLM
                //  where l.Id == Id_Linea_Destino
                //     && lm.Id_Medida == IdMedida
                //     && va.Id == Id_Variante_Destino
                //     && l.UserDel == null
                //     && va.UserDel == null
                //     && lm.UserDel == null
                //  select lm.Id_Medida).Count()) > 0)
                {
                    //NUEVO
                    var query1 = from p in db.Produccion_VariantesTareas
                                 where p.Id_Variante == Id_Variante &&
                                       p.Id_Medida == Id_Medida &&
                                       p.UserDel == null
                                 select p;

                    foreach (Produccion_VariantesTareas c in query1)
                    {
                        Produccion_VariantesTareas Prod = new Produccion_VariantesTareas()
                        {
                            Id_Medida = IdMedida,
                            Id_Variante = Convert.ToInt32(Id_Variante_Destino),
                            Cantidad = c.Cantidad,
                            Unidades = c.Unidades,
                            Horas = c.Horas,
                            Id_ManoObra = c.Id_ManoObra,
                            Id_Tarea = c.Id_Tarea,
                            FechaAdd = Sistema.ObtenerFechaHora(),
                            UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                        };

                        db1.Produccion_VariantesTareas.Attach(Prod);
                        db1.Entry(Prod).State = EntityState.Added;
                    }
                }

                var err = db1.GetValidationErrors();
                if (err.Count() > 0)
                    throw new ValidationException(
                        (from e in err
                         from er in e.ValidationErrors
                         select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                db1.SaveChanges();
            }

        }

    }
}
