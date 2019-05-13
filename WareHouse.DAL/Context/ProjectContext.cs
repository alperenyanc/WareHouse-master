using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Model.Entity;

namespace WareHouse.DAL.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-1KMD7N2;Database=CodeFirstWareHouse;UID=admin2;PWD=alp123;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
