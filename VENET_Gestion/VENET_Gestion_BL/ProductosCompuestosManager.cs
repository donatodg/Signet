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


    public class ProductosCompuestosManager : IDisposable
    {
        private ProduccionContext db;
        public ProductosCompuestos ProductoCompuesto { get; set; }
        public ResultadoCalculo ResultCalulo { get; private set; }
        public int Id_Linea { get; set; }
        public int Id_Medida { get; set; }
        public int Id_Variante { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }

        public ProductosCompuestosManager(ProductosCompuestos o)
        {
            db = new ProduccionContext();
            ProductoCompuesto = o;

            db.ProductosCompuestos.Attach(ProductoCompuesto);

            if (ProductoCompuesto.Id > 0)
            {
                db.Entry(ProductoCompuesto).Reload();

                if (ProductoCompuesto.Detalle == null)
                    db.Entry(ProductoCompuesto).Collection(p => p.Detalle).Load();

                //if (Producto.Detalle.Count > 0)
                //{
                //    foreach (ProductosCompuestosDetalle row in Producto.Detalle)
                //    {
                //        row.Especie = db.Especies.Where(t => t.Id == row.Id_Especie).Select(t => t.Descripcion).SingleOrDefault();
                //    }
                //}
            }
            else
            {
                //Producto.Fecha = Sistema.ObtenerFechaHora();
                db.Entry(ProductoCompuesto).Collection(p => p.Detalle).Load();
                //Producto.Observaciones = "-";

                //try
                //{
                //    Cotiza.Id_FormaPago = Sistema.FormasPagos.First().Key;
                //    Cotiza.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                //}
                //catch { }
            }
        }

        //public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString()}).ToList()); } }
        //public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString().Replace(".", ",") }).ToList()); } }
        public List<KeyNameDecimalPair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNameDecimalPair() { Key = t.Id, Name = t.Alicuota }).ToList()); } }


        public List<KeyNamePair> Tipo
        {
            get
            {
                return (from tp in db.TipoProduccion
                        where tp.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = tp.Id,
                            Name = tp.Codigo + "-" + tp.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Lineas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        where l.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = l.Id,
                            Name = l.Codigo + "-" + l.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Medidas
        {
            get
            {
                return (from l in db.Produccion_Lineas
                        join linm in db.Produccion_LineasMedidas on l.Id equals linm.Id_Linea into listLM
                        from lm in listLM
                        join med in db.Produccion_Medidas on lm.Id_Medida equals med.Id into listMed
                        from m in listMed
                        where l.Id == Id_Linea
                           && l.UserDel == null
                           && lm.UserDel == null
                           && m.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = m.Id,
                            Name = m.Medida  //m.Codigo 
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public List<KeyNamePair> Variantes
        {
            get
            {
                return (from v in db.Produccion_Variantes
                        where v.Id_Linea == Id_Linea
                           && v.UserDel == null
                        select new KeyNamePair()
                        {
                            Key = v.Id,
                            Name = v.Codigo + "-" + v.Descripcion
                        }).OrderBy(t => t.Name).ToList();
            }
        }

        public Productos BuscarProducto(string Codigo)
        {
            return db.Productos.Where(t => t.UserDel == null && t.Codigo == Codigo).FirstOrDefault();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (ProductoCompuesto.Detalle.Where(t => t.Borrado == false).Count() == 0) throw new ValidationException("No se ingresó el detalle del comprobante.");

            if (ProductoCompuesto.Id == 0)
            {
                db.Entry(ProductoCompuesto).State = EntityState.Added;

                ProductoCompuesto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ProductoCompuesto.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(ProductoCompuesto).State = EntityState.Modified;
                ProductoCompuesto.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ProductoCompuesto.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            bool Flag = false;

            using (var db1 = new ProduccionContext())
            {
                Flag = false;
                foreach (ProductosCompuestosDetalle row in ProductoCompuesto.Detalle.Where(t => t.Borrado == true))
                {
                    ProductosCompuestosDetalle o = new ProductosCompuestosDetalle() { Id = row.Id };
                    db1.ProductosCompuestosDetalle.Attach(o);
                    db1.Entry(o).Reload();
                    db1.Entry(o).State = EntityState.Deleted;
                    Flag = true;
                }
                if (Flag) db1.SaveChanges();
            }
        }

        public void Calcular()
        {
            ResultCalulo = new ResultadoCalculo();

            //int Id_ListaPrecio;
            //decimal UtilidadAdicional;
            ProductosListaPrecioActual ListaActual = db.ProductosListaPrecioActual.Where(t => t.UserDel == null).OrderByDescending(t => t.Id).FirstOrDefault();
            //UtilidadAdicional = ListaActual.Porcentaje;
            //Id_ListaPrecio = ListaActual.Id_Produccion_ListaPrecios;

            //  decimal Utilidad;
            Produccion_ListaPrecios Lista = db.Produccion_ListaPrecios.Where(t => t.Id == ListaActual.Id_Produccion_ListaPrecios).FirstOrDefault();
            //    Utilidad = Lista.Utilidad;

            List<SearchResult> rp = new List<SearchResult>();

            rp = (from p in db.Produccion_ListaPrecioActual
                  join var in db.Produccion_Variantes on p.Id_Variante equals var.Id into listVar
                  from v in listVar
                  join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLineas
                  from l in listLineas
                      //join med in db.Produccion_Medidas on p.Id_Medida equals med.Id into listMed
                      //from m in listMed
                      //join prodCat in db.ProductosCategorias on pd.Id_Categoria equals prodCat.Id into listProdCat
                      //from cat in listProdCat.DefaultIfEmpty()
                  join prDeriv in db.ProductosDerivados on p.Id_ProductoDerivado equals prDeriv.Id into listPRD
                  from prder in listPRD.DefaultIfEmpty()
                  where (p.Id_Variante == Id_Variante)
                     && (p.Id_Medida == Id_Medida)
                     && (p.Id_ListaPrecio == Lista.Id)
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
                      Id_Producto = p.Id_Producto,
                      PrecioProducto = p.PrecioProducto,
                      Id_Variante = p.Id_Variante,
                      Incidencia = p.Incidencia,
                      Altos = p.Altos,
                      Operacion = p.Operacion,
                      MedidaAlto = Alto,
                      MedidaAncho = Ancho,
                      Id_ProductoDerivado = p.Id_ProductoDerivado,
                      CantidadProdDerivado = prder.Cantidad,
                      Id_ListaPrecio = p.Id_ListaPrecio,
                      FechaAdd = p.FechaAdd,
                      FechaMod = p.FechaMod,
                      UserAdd = p.UserAdd,
                      UserMod = p.UserMod
                  }).ToList();



            List<SearchResultTareas> rt = new List<SearchResultTareas>();

            rt = (from vt in db.Produccion_ListaPrecioActual_VariantesTareas
                      //join pta in db.Produccion_Tareas on vt.Id_Tarea equals pta.Id into listTareas
                      //from t in listTareas
                      //join var in db.Produccion_Variantes on vt.Id_Variante equals var.Id into listVar
                      //from v in listVar
                      //join lin in db.Produccion_Lineas on v.Id_Linea equals lin.Id into listLin
                      //from l in listLin
                      //join med in db.Produccion_Medidas on vt.Id_Medida equals med.Id into listMed
                      //from me in listMed
                  where (vt.Id_Variante == Id_Variante)
                     && (vt.Id_Medida == Id_Medida)
                     && (vt.Id_ListaPrecio == Lista.Id)
                  select new SearchResultTareas
                  {
                      Id = vt.Id,
                      Id_Variante = vt.Id_Variante,
                      Id_Tarea = vt.Id_Tarea,
                      //Variante = v.Descripcion,
                      //Tarea = t.Descripcion,
                      Id_Medida = vt.Id_Medida,
                      PrecioManoObra = vt.PrecioManoObra,
                      Costo = (vt.PrecioManoObra) * (vt.Unidades) * vt.Cantidad,
                      Cantidad = vt.Cantidad,
                      Unidades = vt.Unidades,
                      Horas = vt.Horas,
                      Id_ManoObra = vt.Id_ManoObra,
                      UserAdd = vt.UserAdd,
                      UserMod = vt.UserMod,
                      FechaAdd = vt.FechaAdd,
                      FechaMod = vt.FechaMod,
                  }).ToList();

            //total de Composicion Productos
            ResultCalulo.Producto = rp.Sum(t => t.Total);
            //total de Composicion Tareas
            ResultCalulo.ManoObra = rt.Sum(t => t.Costo);

            //usar la utilidad de la lista de precio y luego subirle la utilidad adicional
            //decimal UtilidadTotal = Utilidad 
            //   UtilidadAdicional; => 		(UtilidadAdicional-1)*100	5.00	decimal

            ResultCalulo.Utilidad = (db.Produccion_ListaPreciosDetalle.Where(t => t.Id_ListaPrecios == Lista.Id && t.Id_Variante == Id_Variante && t.Id_Medida == Id_Medida).Select(t => t.Utilidad).FirstOrDefault());
            ResultCalulo.UtilidadAdicional = (ListaActual.Porcentaje - 1) * 100;

            //descontar el iva luego

        }

    }

    public class SearchResult : Produccion_ListaPrecioActual
    {
        public decimal MedidaAncho { get; set; }
        public decimal MedidaAlto { get; set; }
        public float? CantidadProdDerivado { get; set; }

        public decimal Total
        {
            get
            {
                try
                {
                    if (CantidadProdDerivado == null || CantidadProdDerivado == 0)
                        CantidadProdDerivado = 1;

                    if (Cantidad > 0) return Cantidad * Incidencia * PrecioProducto * Convert.ToDecimal(CantidadProdDerivado);
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
                            return ((Ancho + Alto) * PrecioProducto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                        else
                        {
                            if (Ancho == 0 && Alto > 0)
                                return ((Alto) * PrecioProducto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                            else if (Alto == 0 && Ancho > 0)
                                return ((Ancho) * PrecioProducto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                            else //if (Alto > 0 && Ancho > 0)
                                return ((Ancho * Alto) * PrecioProducto) * Incidencia * Convert.ToDecimal(CantidadProdDerivado);
                        }
                    }
                }
                catch (Exception) { return 0; }
            }
        }
    }

    public class SearchResultTareas : Produccion_ListaPrecioActual_VariantesTareas
    {
        //public string Variante { get; set; }
        //public string Tarea { get; set; }
        //public decimal CantidadUnidadesHora { get; set; }
        public decimal Costo { get; set; }
    }

    public class ResultadoCalculo
    {
        public decimal Total { get { return Producto + ManoObra; } }
        public decimal Producto { get; set; }
        public decimal ManoObra { get; set; }
        public decimal Utilidad { get; set; }
        public decimal UtilidadAdicional { get; set; }
        public decimal TotalSinIva
        {
            get
            {
                if (UtilidadAdicional > 0)
                {
                    decimal subtotal = 0;
                    decimal subtotal1 = 0;

                    subtotal = (Total * Utilidad / 100) + Total;

                    subtotal1 = (subtotal * UtilidadAdicional / 100) + subtotal;
                    return subtotal1 * 100 / 121;
                }
                else
                    return (Total * Utilidad / 100 + Total) * 100 / 121;
            }
        }
    }

}
