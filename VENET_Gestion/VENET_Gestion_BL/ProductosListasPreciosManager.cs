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
    using static VENET_Common.Reportes;

    public class ProductosListasPreciosManager : IDisposable
    {
        private GestionContext db;
        public ProductosListasPrecios Lista { get; set; }

        public ProductosListasPreciosManager(ProductosListasPrecios o)
        {
            db = new GestionContext();
            Lista = o;

            db.ProductosListasPrecios.Attach(o);

            if (Lista.Id > 0) db.Entry(Lista).Reload();
            else
            {
                Lista.Activo = true;
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Lista.Id == 0)
            {
                db.Entry(Lista).State = EntityState.Added;

                Lista.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Lista.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Lista).State = EntityState.Modified;
                Lista.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Lista.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();

            //Crear detalle de lista de precios con la lista de productos
            if (Lista.Id > 0)
            {
                using (var db = new GestionContext())
                {
                    System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Productos_ListasdePrecios", sqlConn);

                    using (cmd)
                    {
                        System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Lista.Id);

                        cmd.CommandTimeout = 0;

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter1);
                        if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Eliminar(ProductosListasPrecios o)
        {
            using (var db = new GestionContext())
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
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.ProductosListasPrecios
                     where (p.Id == parametros.Id || parametros.Id == null)
                            && (p.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (p.UserDel == null)
                     select new SearchResult
                     {
                         Id = p.Id,
                         Descripcion = p.Descripcion,
                         Activo = p.Activo,
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod
                     }).ToList();

                return r;
            }

        }


        public static void ActualizarImporteProductosSegunLista(int Id_ListaPrecio)
        {
            GestionContext db1 = new GestionContext();

            using (var db = new GestionContext())
            {
                var query = from ld in db.ProductosListasPreciosDetalle
                            where ld.Id_Productos_ListasPrecios == Id_ListaPrecio
                            select ld;

                foreach (ProductosListasPreciosDetalle ld in query)
                {
                    Productos p = new Productos() { Id = ld.Id_Producto };
                    db1.Productos.Attach(p);
                    db1.Entry(p).State = EntityState.Modified;
                    db1.Entry(p).Reload();

                    p.Importe = ld.Importe;
                    p.ImporteOriginal = (decimal)ld.ImporteOriginal;

                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    p.FechaMod = Sistema.ObtenerFechaHora();
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


        //public static void ActualizacionCostos()
        //{
        //    List<int> ListaProductos = new List<int>();

        //    using (var db = new GestionContext())
        //    {
        //        ListaProductos = (db.ProductosComposicion.Where(t => t.UserDel == null).Select(t => t.Id_ProductoFinal).Distinct()).ToList();
        //    }

        //    foreach (int o in ListaProductos)
        //        ProductosComposicion_AddModManager.ActualizarCostoProducto(new Productos() { Id = o });
        //}

        //public static void ActualizarImporteSeguncotizacion(int Id_EspecieOriginal, decimal Cotizacion)
        //{
        //    GestionContext db1 = new GestionContext();

        //    using (var db = new GestionContext())
        //    {
        //        var query = from p in db.Productos
        //                    where p.Id_EspecieOriginal == Id_EspecieOriginal &&
        //                          p.ImporteOriginal > 0 &&
        //                          p.UserDel == null
        //                    select p;

        //        foreach (Productos p in query)
        //        {
        //            db1.Productos.Attach(p);
        //            db.Entry(p).State = EntityState.Modified;

        //            p.Importe = (decimal)p.ImporteOriginal * Cotizacion;

        //            p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
        //            p.FechaMod = Sistema.ObtenerFechaHora();
        //        }

        //        var err = db1.GetValidationErrors();
        //        if (err.Count() > 0)
        //            throw new ValidationException(
        //                (from e in err
        //                 from er in e.ValidationErrors
        //                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

        //        db1.SaveChanges();
        //    }
        //}


        public static List<DatosReporte> ImprimeComprobante(int id_ProductosListasPrecios)
        {
            using (var db = new GestionContext())
            {
                ProductosListasPrecios o = new ProductosListasPrecios() { Id = id_ProductosListasPrecios };

                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                //ver de donde sacar la empresa o quitar
                int Id_Empresa = db.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();

                Empresas emp = new Empresas() { Id = Id_Empresa };
                db.Entry(emp).State = EntityState.Unchanged;
                db.Entry(emp).Reload();

                Localidades loc = new Localidades();
                if (emp.Id_CodPostal > 0)
                {
                    loc.Id = emp.Id_CodPostal.Value;
                    db.Entry(loc).State = EntityState.Unchanged;
                    db.Entry(loc).Reload();
                }

                EmpresasReporte EmpReporte = new EmpresasReporte()
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre,
                    Fantasia = emp.Fantasia,
                    Direccion = emp.Direccion,
                    Id_CodPostal = loc.CodPostal,
                    Localidad = loc.Localidad,
                    Cuit = emp.Cuit,
                    Id_TipoIva = emp.Id_TipoIva,
                    TipoIva = (db.TipoIva.Where(t => t.Id == emp.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault()),
                    IngresosBrutos = emp.IngresosBrutos,
                    InicioActividades = emp.InicioActividades
                };


                DatosReporte i = new DatosReporte()
                {
                    Empresa = EmpReporte
                };

                List<DetalleReporte> r = new List<DetalleReporte>();

                r = (from l in db.ProductosListasPrecios
                     join det in db.ProductosListasPreciosDetalle on l.Id equals det.Id_Productos_ListasPrecios into listPD
                     from d in listPD
                     join prod in db.Productos on d.Id_Producto equals prod.Id into listProd
                     from p in listProd
                     join cat in db.ProductosCategorias on p.Id_Categoria equals cat.Id into listCat
                     from c in listCat.DefaultIfEmpty()
                     join esp in db.Especies on d.Id_Especie equals esp.Id into listEsp
                     from e in listEsp
                     join espOrig in db.Especies on d.Id_EspecieOriginal equals espOrig.Id into listEspOrig
                     from eo in listEspOrig.DefaultIfEmpty()
                     where l.Id == o.Id &&
                           l.UserDel == null &&
                           d.UserDel == null &&
                           p.UserDel == null
                     select new DetalleReporte()
                     {
                         Codigo = p.Codigo,
                         Producto = p.Descripcion,
                         Especie = e.Descripcion,
                         Importe = d.Importe,
                         EspecieOriginal = eo.Descripcion,
                         ImporteOriginal = d.ImporteOriginal.Value,
                         Categoria = c.Descripcion
                     }).OrderBy(t => t.Producto).ToList();
                //}).OrderBy(t => t.Categoria).ThenBy(t => t.Producto).ToList();

                i.NombreLista = db.ProductosListasPrecios.Where(t => t.Id == o.Id).Select(t => t.Descripcion).FirstOrDefault();

                i.Detalle = r;

                List<DatosReporte> dr = new List<DatosReporte>();
                dr.Add(i);
                return dr;
            }
        }

        public static List<DatosReporte> ImprimeComprobante(int id_ProductosListasPrecios, List<int> Categorias)
        {
            using (var db = new GestionContext())
            {
                ProductosListasPrecios o = new ProductosListasPrecios() { Id = id_ProductosListasPrecios };

                db.Entry(o).State = EntityState.Unchanged;
                db.Entry(o).Reload();

                //ver de donde sacar la empresa o quitar
                int Id_Empresa = db.Empresas.Where(t => t.UserDel == null).Select(t => t.Id).FirstOrDefault();

                Empresas emp = new Empresas() { Id = Id_Empresa };
                db.Entry(emp).State = EntityState.Unchanged;
                db.Entry(emp).Reload();

                Localidades loc = new Localidades();
                if (emp.Id_CodPostal > 0)
                {
                    loc.Id = emp.Id_CodPostal.Value;
                    db.Entry(loc).State = EntityState.Unchanged;
                    db.Entry(loc).Reload();
                }

                EmpresasReporte EmpReporte = new EmpresasReporte()
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre,
                    Fantasia = emp.Fantasia,
                    Direccion = emp.Direccion,
                    Id_CodPostal = loc.CodPostal,
                    Localidad = loc.Localidad,
                    Cuit = emp.Cuit,
                    Id_TipoIva = emp.Id_TipoIva,
                    TipoIva = (db.TipoIva.Where(t => t.Id == emp.Id_TipoIva).Select(t => t.Nombre).FirstOrDefault()),
                    IngresosBrutos = emp.IngresosBrutos,
                    InicioActividades = emp.InicioActividades
                };


                DatosReporte i = new DatosReporte()
                {
                    Empresa = EmpReporte
                };

                List<DetalleReporte> r = new List<DetalleReporte>();

                r = (from l in db.ProductosListasPrecios
                     join det in db.ProductosListasPreciosDetalle on l.Id equals det.Id_Productos_ListasPrecios into listPD
                     from d in listPD
                     join prod in db.Productos on d.Id_Producto equals prod.Id into listProd
                     from p in listProd
                     join cat in db.ProductosCategorias on p.Id_Categoria equals cat.Id into listCat
                     from c in listCat.DefaultIfEmpty()
                     join esp in db.Especies on d.Id_Especie equals esp.Id into listEsp
                     from e in listEsp
                     join espOrig in db.Especies on d.Id_EspecieOriginal equals espOrig.Id into listEspOrig
                     from eo in listEspOrig.DefaultIfEmpty()
                     where l.Id == o.Id &&
                           Categorias.Contains(p.Id_Categoria) &&
                           l.UserDel == null &&
                           d.UserDel == null &&
                           p.UserDel == null
                     select new DetalleReporte()
                     {
                         Codigo = p.Codigo,
                         Producto = p.Descripcion,
                         Especie = e.Descripcion,
                         Importe = d.Importe,
                         EspecieOriginal = eo.Descripcion,
                         ImporteOriginal = d.ImporteOriginal.Value,
                         Categoria = c.Descripcion
                     }).OrderBy(t => t.Producto).ToList();

                i.NombreLista = db.ProductosListasPrecios.Where(t => t.Id == o.Id).Select(t => t.Descripcion).FirstOrDefault();

                i.Detalle = r;

                List<DatosReporte> dr = new List<DatosReporte>();
                dr.Add(i);
                return dr;
            }
        }


        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : ProductosListasPrecios
        {
        }

        public class DatosReporte
        {
            public EmpresasReporte Empresa { get; set; }
            public string NombreLista { get; set; }
            public List<DetalleReporte> Detalle { get; set; }
        }

        public class DetalleReporte
        {
            public string Codigo { get; set; }
            public string Producto { get; set; }
            public string Especie { get; set; }
            public decimal Importe { get; set; }
            public string EspecieOriginal { get; set; }
            public decimal? ImporteOriginal { get; set; }
            public string Categoria { get; set; }
        }
    }
}