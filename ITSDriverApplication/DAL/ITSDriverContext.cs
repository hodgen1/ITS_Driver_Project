using ITSDriverApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ITSDriverApplication.DAL
{
    public class ITSDriverContext : DbContext
    {
        public ITSDriverContext() : base("ITSDriverContext")
        {
        }

        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}