namespace VENET_Clientes_BL
{
    using System;
    using System.Data.Entity;
    using VENET_DataEntity;

    public class ClientesEntregasManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public ClientesEntregas Entrega{ get; set; }

        public ClientesEntregasManager(ClientesEntregas  o)
        {
            Entrega = o;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(ClientesEntregas o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ClientesEntregas.Remove(o);

                db.SaveChanges();
            }
        }
    }
}
