using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCEntity
{
    public class DbConfiguration<T> : DbMigrationsConfiguration<T> where T : DbContext
    {
        public DbConfiguration()
        {
            base.AutomaticMigrationsEnabled = true;
            base.ContextKey = typeof(T).FullName;
            base.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
