using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace test_Task
{
    class AppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public AppContext() : base("DefaultConnection") {
            Database.SetInitializer<AppContext>(null);
        }
        

    }
}
