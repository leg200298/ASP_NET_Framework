using OGCCodeEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCEntity
{
    public class OGCDbContext : DbContextBase<OGCDbContext>
    {
        public OGCDbContext()
            : base("name=CodeFirstConnection")
        {

        }
        public virtual DbSet<observation> observation { get; set; }
        public virtual DbSet<featureofinterest> featureofinterest { get; set; }
        public virtual DbSet<observedproperty> observedproperty { get; set; }
        public virtual DbSet<sensor> sensor { get; set; }
        public virtual DbSet<datastream> datastream { get; set; }
        public virtual DbSet<thing> thing { get; set; }
        public virtual DbSet<historicallocation> historicallocation { get; set; }
        public virtual DbSet<location> location { get; set; }
    }
}
