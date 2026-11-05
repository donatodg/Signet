namespace VENET_Clientes_BL
{
    using System;
    using System.Data.Entity;
    using VENET_DataEntity;

    public class ClientesContactosManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public ClientesContactos Contacto { get; set; }

        public ClientesContactosManager(ClientesContactos o)
        {
            Contacto = o;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(ClientesContactos o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ClientesContactos.Remove(o);

                db.SaveChanges();
            }
        }
    }
}
