using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCEntity
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DbContextBase<T>: DbContext where T: DbContext
    {
        public DbContextBase()
            : this("name=CodeFirstConnection")
        {

        }

        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            base.Database.Log = delegate (string message) { Console.Write(message); };
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<T, DbConfiguration<T>>());
        }
    }
}
