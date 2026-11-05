namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class ProductosListasPreciosImprimirManager : IDisposable
    {
        private readonly GestionContext db;
        public List<CategoriasSelect> Categorias { get; set; }
        public List<ClientesMailSelect> ClientesEmail { get; set; }

        public ProductosListasPreciosImprimirManager()
        {
            db = new GestionContext();
            Categorias = new List<CategoriasSelect>();
            Categorias = (db.ProductosCategorias.Where(t => t.UserDel == null).Select(t => new CategoriasSelect() { Seleccionado = true, Id = t.Id, Descripcion = t.Descripcion }).ToList());

            ClientesEmail = new List<ClientesMailSelect>();
            ClientesEmail = (db.Clientes.Where(t => t.UserDel == null && t.Email.Contains("@")).Select(t => new ClientesMailSelect() { Seleccionado = false, Id = t.Id, Nombre = t.Nombre, Email = t.Email })).ToList();
        }


        public void SeleccionarTodo(bool Clientes)
        {
            if (Clientes)
                ClientesEmail = ClientesEmail.Select(t => { t.Seleccionado = true; return t; }).ToList();
            else
                Categorias = Categorias.Select(t => { t.Seleccionado = true; return t; }).ToList();
        }

        public void DeseleccionarTodo(bool Clientes)
        {
            if (Clientes)
                ClientesEmail = ClientesEmail.Select(t => { t.Seleccionado = false; return t; }).ToList();
            else
                Categorias = Categorias.Select(t => { t.Seleccionado = false; return t; }).ToList();

        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public class ClientesMailSelect
        {
            public bool Seleccionado { get; set; }
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
        }

        public class CategoriasSelect
        {
            public bool Seleccionado { get; set; }
            public int Id { get; set; }
            public string Descripcion { get; set; }

        }
    }
}