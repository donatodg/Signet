namespace VENET_DataEntity
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;

    public class LoginContext : DbContext, IDisposable
    {
        public LoginContext()
            : base(ConfigurationManager.AppSettings["CurrentConnection"]) { }

        public LoginContext(String nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public LoginContext(DbConnection existingConnection, Boolean contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }


        public DbSet<Usuarios> Usuarios { get; set; }


    }
}
