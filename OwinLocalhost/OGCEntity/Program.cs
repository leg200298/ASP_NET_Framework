using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGCEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            OGCDbContext db = new OGCDbContext();
            db.thing.Add(new OGCCodeEF.Model.thing() { Name = "微波爐", Description = "家裡微波用", Properties = "{\"Color\": \"black\"}" });
            db.SaveChanges();
            Console.ReadKey();
        }
    }
}
