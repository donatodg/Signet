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

    public class ProduccionManager : IDisposable
    {
        private ProduccionContext db;
        public Produccion Produccion { get; set; }

        public ProduccionManager(Produccion o)
        {
            db = new ProduccionContext();
            Produccion = o;

            db.Produccion.Attach(Produccion);

            if (Produccion.Id > 0) db.Entry(Produccion).Reload();
            else
                Produccion.Incidencia = 1;
        }

        public List<ProductosBusqueda> Productos
        {
            get
            {
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_ProductosConPrecio)))
                    return db.Productos.Where(t => t.UserDel == null && t.Importe == 0).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
                else
                    return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
            }
        }

        public List<KeyNamePair> ProductosDerivados
        {
            get
            {
                return (from pd in db.ProductosDerivados
                        join prod in db.Productos on pd.Id_Producto equals prod.Id into listProd
                        from p in listProd
                        where pd.Id_Producto == Produccion.Id_Producto
                        select new KeyNamePair()
                        {
                            Key = pd.Id,
                            Name = pd.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Medidas
        {
            get
            {
                return (from m in db.Produccion_Medidas
                        join linmed in db.Produccion_LineasMedidas on m.Id equals linmed.Id_Medida into listLM
                        from lm in listLM
                        join var in db.Produccion_Variantes on lm.Id_Linea equals var.Id_Linea into listVar
                        from v in listVar
                        where v.Id == Produccion.Id_Variante
                           && lm.UserDel == null
                           && m.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = m.Id,
                            Name = m.Medida
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save(int IdMedida)
        {
            ProduccionContext db1 = new ProduccionContext();

            //Ver si es un Insert o un Update
            int Id = (db1.Produccion.Where(t => t.UserDel == null && t.Id_Variante == Produccion.Id_Variante && t.Id_Producto == Produccion.Id_Producto && t.Id_ProductoDerivado == Produccion.Id_ProductoDerivado && t.Id_Medida == IdMedida).Select(t => t.Id).FirstOrDefault());

            Produccion Prod = new Produccion();
            //db.Produccion.Attach(Prod);

            if (Id == 0)
            {
                db1.Entry(Prod).State = EntityState.Added;
                Prod.FechaAdd = Sistema.ObtenerFechaHora();
                Prod.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                Prod.Id = Id;
                db1.Produccion.Attach(Prod);
                db1.Entry(Prod).Reload();
                db1.Entry(Prod).State = EntityState.Modified;
                Prod.FechaMod = Sistema.ObtenerFechaHora();
                Prod.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            Prod.Id_ProductoDerivado = Produccion.Id_ProductoDerivado;
            Prod.Id_Medida = IdMedida;
            Prod.Anchos = Produccion.Anchos;
            Prod.Cantidad = Produccion.Cantidad;
            Prod.Id_Producto = Produccion.Id_Producto;
            Prod.Id_Variante = Produccion.Id_Variante;
            Prod.Incidencia = Produccion.Incidencia;
            Prod.Altos = Produccion.Altos;
            Prod.Operacion = Produccion.Operacion;
            Prod.OperacionAltos = Produccion.OperacionAltos;
            Prod.OperacionAnchos = Produccion.OperacionAnchos;
            Prod.AltosAjuste = Produccion.AltosAjuste;
            Prod.AnchosAjuste = Produccion.AnchosAjuste;


            var err = db1.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db1.SaveChanges();
        }

        public static void Eliminar(Produccion o)
        {
            using (var db = new ProduccionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Produccion
                     join var in db.Produccion_Variantes on p.Id_Variante equals var.Id into listVar
                     from v in listVar
                     join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLineas
                     from l in listLineas
                     join med in db.Produccion_Medidas on p.Id_Medida equals med.Id into listMed
                     from m in listMed
                     //join linMed in db.Produccion_LineasMedidas on new { l.Id, p.Id_Medida } equals new { linMed.Id_Linea, linMed.Id_Medida } into listLinMed
                     //from lm in listLinMed
                     join prod in db.Productos on p.Id_Producto equals prod.Id into listProd
                     from pd in listProd
                     join prodCat in db.ProductosCategorias on pd.Id_Categoria equals prodCat.Id into listProdCat
                     from cat in listProdCat.DefaultIfEmpty()
                     join prDeriv in db.ProductosDerivados on p.Id_ProductoDerivado equals prDeriv.Id into listPRD
                     from prder in listPRD.DefaultIfEmpty()
                     where (p.Id == parametros.Id || parametros.Id == null)
                        && (p.Id_Variante == parametros.Id_Variante || parametros.Id_Variante == null)
                        && (p.Id_Medida == parametros.Id_Medida || parametros.Id_Medida == null)
                        && (l.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        && (p.UserDel == null)
                        && (v.UserDel == null)
                        && (l.UserDel == null)
                        && (m.UserDel == null)
                        //&& (lm.UserDel == null)
                        && (pd.UserDel == null)
                        && ((db.Produccion_LineasMedidas.Where(t=> t.Id_Linea == l.Id && t.UserDel == null).Select(t=> t.Id_Medida)).Contains(p.Id_Medida))
                     select new SearchResult()
                     {
                         Id = p.Id,
                         AltosAjuste = p.AltosAjuste,
                         OperacionAnchos = p.OperacionAnchos,
                         AnchosAjuste = p.AnchosAjuste,
                         OperacionAltos = p.OperacionAltos,
                         Anchos = p.Anchos,
                         Cantidad = p.Cantidad,
                         Id_Medida = p.Id_Medida,
                         Id_Linea = l.Id,
                         Id_Producto = p.Id_Producto,
                         Id_Variante = p.Id_Variante,
                         Incidencia = p.Incidencia,
                         Altos = p.Altos,
                         Linea = l.Codigo + "-" + l.Descripcion,
                         Medida = m.Medida,
                         Operacion = p.Operacion,
                         Producto = pd.Descripcion,
                         Categoria = cat.Descripcion,
                         ProductoFinal = l.Descripcion + " - " + v.Descripcion + " - " + m.Medida,
                         MedidaAlto = m.Alto,
                         MedidaAncho = m.Ancho,
                         Variante = v.Codigo + "-" + v.Descripcion,
                         ImporteCosto = pd.ImporteCosto,
                         CostoActualizacion = pd.FechaActualizacionCosto,
                         Id_ProductoDerivado = p.Id_ProductoDerivado,
                         ProductoDerivado = prder.Descripcion,
                         CantidadProdDerivado = prder.Cantidad,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod
                     }).ToList();
                return r;

            }
        }

        public static List<SearchResultTareas> BuscarTareas(ParametrosBusquedas parametros)
        {
            using (var db = new ProduccionContext())
            {
                List<SearchResultTareas> r = new List<SearchResultTareas>();

                r = (from vt in db.Produccion_VariantesTareas
                     join pta in db.Produccion_Tareas on vt.Id_Tarea equals pta.Id into listTareas
                     from t in listTareas
                     join mdo in db.Produccion_ManoDeObra on vt.Id_ManoObra equals mdo.Id into listMO
                     from mo in listMO
                     join var in db.Produccion_Variantes on vt.Id_Variante equals var.Id into listVar
                     from v in listVar
                     join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLin
                     from l in listLin
                     join med in db.Produccion_Medidas on vt.Id_Medida equals med.Id into listMed
                     from me in listMed
                     where (vt.Id_Variante == parametros.Id_Variante || parametros.Id_Variante == null)
                        && (vt.Id_Medida == parametros.Id_Medida || parametros.Id_Medida == null)
                        && (l.Id_Empresa == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        && (vt.UserDel == null)
                        && (t.UserDel == null)
                        && (mo.UserDel == null)
                        && (v.UserDel == null)
                     select new SearchResultTareas
                     {
                         Id = vt.Id,
                         Id_Variante = v.Id,
                         Id_Tarea = t.Id,
                         Variante = v.Descripcion,
                         Tarea = t.Descripcion,
                         Id_Medida = vt.Id_Medida,
                         Medida = me.Medida,
                         //CantidadUnidadesHora = vt.Cantidad,
                         //Costo = (mo.PrecioHora / 60) * (vt.Horas.Hour * 60 + vt.Horas.Minute) * vt.Cantidad,
                         Costo = (mo.PrecioHora) * (vt.Unidades) * vt.Cantidad,
                         //Costo = (mo.PrecioHora / 100) * vt.Cantidad,
                         Cantidad = vt.Cantidad,
                         Unidades = vt.Unidades,
                         Horas = vt.Horas,
                         Id_ManoObra = vt.Id_ManoObra,
                         ManoObra = mo.Descripcion,
                         PrecioHora = mo.PrecioHora,
                         UserAdd = vt.UserAdd,
                         UserMod = vt.UserMod,
                         FechaAdd = vt.FechaAdd,
                         FechaMod = vt.FechaMod,
                     }).ToList();

                return r;
            }
        }

        public class ParametrosBusquedas
        {
            private ProduccionContext db = new ProduccionContext();

            public int? Id { get; set; }
            public int Id_Linea { get; set; }
            public int? Id_Variante { get; set; }
            public int? Id_Medida { get; set; }
            public int? Id_Empresa { get; set; }

            public List<KeyName2Pair> Lineas
            {
                get
                {
                    return (from l in db.Produccion_Lineas
                            join emp in db.Empresas on l.Id_Empresa equals emp.Id into lisEmp
                            from e in lisEmp
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

                    r = (from lm in db.Produccion_LineasMedidas
                         join me in db.Produccion_Medidas on lm.Id_Medida equals me.Id into listMedidas
                         from m in listMedidas
                         where lm.UserDel == null
                            && lm.Id_Linea == Id_Linea
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

        public class SearchResult : Produccion
        {
            public int Id_Linea { get; set; }
            public string Linea { get; set; }
            public string Variante { get; set; }
            public string Medida { get; set; }
            public decimal MedidaAncho { get; set; }
            public decimal MedidaAlto { get; set; }
            public string Producto { get; set; }
            public string ProductoFinal { get; set; }
            public string ProductoDerivado { get; set; }
            public string Categoria { get; set; }
            public decimal ImporteCosto { get; set; }
            public DateTime? CostoActualizacion { get; set; }
            public float? CantidadProdDerivado { get; set; }

            public decimal Total
            {
                get
                {
                    try
                    {
                        if (CantidadProdDerivado == null || CantidadProdDerivado == 0)
                            CantidadProdDerivado = 1;

                        if (Cantidad > 0) return Cantidad * Incidencia * ImporteCosto * Convert.ToDecimal(CantidadProdDerivado);
                        else
                        {
                            decimal Alto = MedidaAlto * Altos;
                            decimal Ancho = MedidaAncho * Anchos;

                            if (AltosAjuste > 0)
                                if (OperacionAltos == "+")
                                    Alto = (MedidaAlto + AltosAjuste) * Altos;
                                else
                                    Alto = (MedidaAlto - AltosAjuste) * Altos;

                            if (AnchosAjuste > 0)
                                if (OperacionAnchos == "+")
                                    Ancho = (MedidaAncho + AnchosAjuste) * Anchos;
                                else
                                    Ancho = (MedidaAncho - AnchosAjuste) * Anchos;

                            if (Operacion == "+")
                                return ((Ancho + Alto) * ImporteCosto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                            else
                            {
                                if (Ancho == 0 && Alto > 0)
                                    return ((Alto) * ImporteCosto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                                else if (Alto == 0 && Ancho > 0)
                                    return ((Ancho) * ImporteCosto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                                else //if (Alto > 0 && Ancho > 0)
                                    return ((Ancho * Alto) * ImporteCosto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                            }
                        }
                    }
                    catch (Exception) { return 0; }
                }
            }
        }

        public class SearchResultTareas : Produccion_VariantesTareas
        {
            public string Variante { get; set; }
            public string Tarea { get; set; }
            //public decimal CantidadUnidadesHora { get; set; }
            public string ManoObra { get; set; }
            public string Medida { get; set; }
            public decimal PrecioHora { get; set; }
            public decimal Costo { get; set; }
        }

        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
            //public decimal Descuento { get; set; }
        }

    }
}
