namespace VENET_Clientes_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ClientesDescuentosManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public ClientesDescuentos Descuento { get; set; }

        public ClientesDescuentosManager(ClientesDescuentos o)
        {
            Descuento = o;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Categorias
        {
            get
            {
                using (var db = new TesoreriaContext())
                {
                    return db.ProductosCategorias2.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList();
                }
            }
        }

        public static void Eliminar(ClientesDescuentos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ClientesDescuentos.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
